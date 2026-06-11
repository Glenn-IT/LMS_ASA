# Database Connection Pattern
**Author:** Glenn
**Last Updated:** 2026-06-10
> This document explains the `config.txt` + `dbconstring` connection pattern used in this project.
> Copy this pattern as-is into any new VB.NET WinForms system.

---

## How It Works

The connection string is **never hardcoded** in source code. Instead it lives in a plain text file (`config.txt`) placed next to the compiled `.exe`. The `dbconstring` class reads that file at runtime every time a connection is needed.

```
MyApp/
├── MyApp.exe
├── config.txt          ← your real connection string (never commit this)
├── config.txt.example  ← safe placeholder committed to git
└── ...
```

---

## Step 1 — The `config.txt.example` File

Commit this file to git. It shows the format without exposing real credentials.

```
Data Source=SERVER\INSTANCE;Initial Catalog=DATABASE_NAME;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;
```

**Examples for common setups:**

```
' Windows Authentication (SQL Express — most common for local dev)
Data Source=Glenn\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;

' SQL Server Authentication (username + password)
Data Source=Glenn\SQLEXPRESS;Initial Catalog=mydb;User Id=sa;Password=yourpassword;TrustServerCertificate=True;Encrypt=False;

' Remote / Named server
Data Source=192.168.1.10,1433;Initial Catalog=mydb;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;

' LocalDB (Visual Studio default)
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=mydb;Integrated Security=True;
```

---

## Step 2 — The `dbconstring.vb` File

Create this file in the root of your project. It is a single `Class` with one `Shared ReadOnly Property`.

```vb
Imports System.IO

Public Class dbconstring

    Public Shared ReadOnly Property Connection As String
        Get
            Dim configPath As String = Path.Combine(
                Environment.CurrentDirectory, "config.txt")

            If Not File.Exists(configPath) Then
                Throw New InvalidOperationException(
                    "config.txt not found in the application directory." &
                    Environment.NewLine &
                    "Create config.txt with your SQL Server connection string." &
                    Environment.NewLine &
                    "See config.txt.example for the required format.")
            End If

            Return File.ReadAllText(configPath).Trim()
        End Get
    End Property

End Class
```

**Why `Environment.CurrentDirectory`?**
It resolves to the folder where the `.exe` lives at runtime (`bin\Debug\net8.0-windows\`), so `config.txt` placed next to the exe is always found regardless of the project folder name.

---

## Step 3 — The `.gitignore` Entry

Add this line to `.gitignore` so `config.txt` is never accidentally committed:

```
config.txt
```

Keep `config.txt.example` tracked in git — it documents the format for anyone setting up the project.

---

## Step 4 — Using the Connection String

Use `dbconstring.Connection` anywhere you open a `SqlConnection`. Always wrap in `Using` so the connection is closed and disposed automatically even if an exception is thrown.

```vb
Imports Microsoft.Data.SqlClient

' SELECT — returns a DataTable
Public Function GetAllUsers() As DataTable
    Dim dt As New DataTable()
    Using con As New SqlConnection(dbconstring.Connection)
        con.Open()
        Dim cmd As New SqlCommand("SELECT * FROM tbl_Users", con)
        Dim adapter As New SqlDataAdapter(cmd)
        adapter.Fill(dt)
    End Using
    Return dt
End Function

' INSERT / UPDATE / DELETE
Public Sub DeleteUser(userID As Integer)
    Using con As New SqlConnection(dbconstring.Connection)
        con.Open()
        Using cmd As New SqlCommand(
            "DELETE FROM tbl_Users WHERE UserID = @id", con)
            cmd.Parameters.AddWithValue("@id", userID)
            cmd.ExecuteNonQuery()
        End Using
    End Using
End Sub
```

**Always use `Parameters.AddWithValue`** — never concatenate user input into SQL strings.

---

## Step 5 — The Repository Pattern (Recommended)

Keep all SQL in dedicated `Public Module` files under a `DataAccess/` folder. Forms and panels never touch `SqlConnection` directly.

```
DataAccess/
├── UserRepository.vb
├── DocumentRepository.vb
└── ActivityLogRepository.vb
```

**Minimal repository template:**

```vb
Imports Microsoft.Data.SqlClient

Public Module UserRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT * FROM tbl_Users ORDER BY CreatedAt DESC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByUsername(username As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT * FROM tbl_Users WHERE Username = @username", con)
            cmd.Parameters.AddWithValue("@username", username)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Sub Insert(username As String, passwordHash As String, userType As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Users (Username, PasswordHash, UserType) " &
                "VALUES (@username, @hash, @type)", con)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@hash",     passwordHash)
                cmd.Parameters.AddWithValue("@type",     userType)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Delete(userID As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "DELETE FROM tbl_Users WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@id", userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
```

**Calling from a form or panel:**

```vb
Try
    Dim dt As DataTable = UserRepository.GetAll()
    For Each row As DataRow In dt.Rows
        dgvUsers.Rows.Add(row("Username").ToString(), row("UserType").ToString())
    Next
Catch ex As Exception
    MessageBox.Show("Database error: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
End Try
```

---

## Step 6 — Activity Logging (Optional but Recommended)

A lightweight logger that swallows its own exceptions so a logging failure never crashes the app.

**`ActivityLogger.vb`**

```vb
Public Class ActivityLogger

    Public Shared Sub Log(username As String, result As String, description As String)
        Try
            ActivityLogRepository.Insert(username, result, description)
        Catch
            ' Logging failure should never crash the app
        End Try
    End Sub

End Class
```

**`DataAccess/ActivityLogRepository.vb`**

```vb
Imports Microsoft.Data.SqlClient

Public Module ActivityLogRepository

    Public Sub Insert(username As String, result As String, description As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim sql As String =
                "INSERT INTO tbl_ActivityLogs (Username, LogDate, Result, Description) " &
                "VALUES (@username, GETDATE(), @result, @description)"
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@username",    username)
                cmd.Parameters.AddWithValue("@result",      result)
                cmd.Parameters.AddWithValue("@description", description)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
```

**Usage anywhere in the app:**

```vb
ActivityLogger.Log(SessionManager.Username, "Success", "User logged in.")
ActivityLogger.Log(SessionManager.Username, "Failed",  "Login failed - wrong password.")
```

---

## Required NuGet Package

| Package | Version | Purpose |
|---------|---------|---------|
| `Microsoft.Data.SqlClient` | 5.x | SQL Server driver for .NET 6/7/8 |

Install via Package Manager Console:
```
Install-Package Microsoft.Data.SqlClient
```

Or `.csproj` / `.vbproj`:
```xml
<PackageReference Include="Microsoft.Data.SqlClient" Version="5.*" />
```

---

## Project Setup Checklist for a New System

- [ ] Add `Microsoft.Data.SqlClient` NuGet package
- [ ] Create `dbconstring.vb` (copy from above)
- [ ] Create `config.txt.example` with the connection string template
- [ ] Add `config.txt` to `.gitignore`
- [ ] Create `config.txt` next to the `.exe` (in `bin\Debug\net8.0-windows\`) with the real connection string
- [ ] Create `DataAccess/` folder
- [ ] Add one repository module per table (e.g., `UserRepository.vb`)
- [ ] Add `ActivityLogger.vb` + `ActivityLogRepository.vb` if activity logging is needed
- [ ] Never write `SqlConnection` inside a Form or UserControl — only in repository modules

---

## AI Prompt — Use This When Starting a New System

Copy and paste this prompt when starting a new WinForms VB.NET project with Claude:

---

> **New VB.NET WinForms System — Base Setup Prompt**
>
> I am building a VB.NET Windows Forms application targeting .NET 8.0 on Windows.
>
> **Database connection pattern to follow:**
> - Use `Microsoft.Data.SqlClient` (not `System.Data.SqlClient`)
> - Connection string is stored in `config.txt` placed next to the `.exe`, read by a `Public Class dbconstring` with a `Shared ReadOnly Property Connection As String`
> - `config.txt` is in `.gitignore`; `config.txt.example` is committed as a template
> - All SQL lives in `Public Module` repository files under a `DataAccess/` folder — no `SqlConnection` in forms or panels
> - Repository SELECT methods return `DataTable`; mutations (`INSERT`/`UPDATE`/`DELETE`) throw on failure
> - Always use `Using` blocks for `SqlConnection` and `SqlCommand`
> - Always use `Parameters.AddWithValue` — never string-concatenate user input into SQL
> - Activity logging via `ActivityLogger.Log(username, result, description)` which delegates to `ActivityLogRepository.Insert` and swallows its own exceptions
>
> **Session pattern:**
> - `Public Module SessionManager` with `Username As String`, `UserType As String`, `UserCode As String`, and a `Clear()` sub
>
> **Helper pattern:**
> - `InputHelper.SanitizeInput(text)` — trims whitespace, strips `<>` characters and null bytes
> - `PasswordHelper.HashPassword(plain)` / `VerifyPassword(plain, hash)` — BCrypt.Net-Next wrappers
> - `Helpers/Constants.vb` — `Public Module Constants` for all magic strings (user types, statuses, etc.)
>
> **Project:** [DESCRIBE YOUR SYSTEM HERE]
> **Database:** SQL Server, instance `[SERVER\INSTANCE]`, database `[DB_NAME]`
> **Tables:** [LIST YOUR TABLES AND COLUMNS]
>
> Follow this pattern for all code you generate in this session.

---

*Save this document and paste the prompt at the start of each new project session.*