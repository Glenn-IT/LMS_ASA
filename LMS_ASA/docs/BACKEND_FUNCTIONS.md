# Backend Functions Specification
# Loan Management System (LMS) — ASA Philippines Foundation, Inc.

> **Technology:** VB.NET WinForms · .NET 8.0 · SQL Server · ADO.NET  
> **Purpose:** Complete function-by-function implementation guide for converting the UI prototype into a fully working system  
> **Depends on:** `BACKEND_ROADMAP.md` (database schema), `SYSTEM_AUDIT_CHECKLIST.md` (issue tracker)

---

## How to Use This Document

Each section below describes **exactly what code to write** for every file that needs to be created or modified. Functions include:
- The VB.NET method signature
- What it does
- The SQL query it runs (where applicable)
- What to wire it to in the UI

Follow the sections in order — each phase depends on the ones before it.

---

## PART 1 — Infrastructure / Helper Classes

These must be created first. Everything else depends on them.

---

### `Helpers/SessionManager.vb`

**Purpose:** Stores the currently logged-in user's identity for the lifetime of the app session.

```vbnet
Public Module SessionManager

    Public CurrentUserID    As Integer = 0
    Public CurrentUsername  As String = ""
    Public CurrentRole      As String = ""       ' "Admin" or "Borrower"
    Public CurrentBorrowerID As Integer = 0      ' 0 if user is Admin

    Public Sub SetSession(userID As Integer, username As String, role As String, Optional borrowerID As Integer = 0)
        CurrentUserID    = userID
        CurrentUsername  = username
        CurrentRole      = role
        CurrentBorrowerID = borrowerID
    End Sub

    Public Sub ClearSession()
        CurrentUserID    = 0
        CurrentUsername  = ""
        CurrentRole      = ""
        CurrentBorrowerID = 0
    End Sub

    Public Function IsLoggedIn() As Boolean
        Return CurrentUserID > 0
    End Function

    Public Function IsAdmin() As Boolean
        Return CurrentRole = "Admin"
    End Function

End Module
```

**Wire up:** Call `SessionManager.ClearSession()` on every Logout button click. Call `SessionManager.SetSession(...)` after successful login.

---

### `Data/DatabaseHelper.vb`

**Purpose:** Single place to get a SQL connection. All repositories use this.

```vbnet
Imports System.Data.SqlClient

Public Class DatabaseHelper

    ' Store your connection string in App.config under <connectionStrings>
    Private Shared ReadOnly ConnectionString As String =
        "Server=.\SQLEXPRESS;Database=LMS_DB;Trusted_Connection=True;"

    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function

    ' Call this on app startup (ApplicationEvents.vb) to verify DB is reachable
    Public Shared Function TestConnection() As Boolean
        Try
            Using conn = GetConnection()
                conn.Open()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function

End Class
```

**Wire up:** In `ApplicationEvents.vb → MyApplication_Startup`, call `DatabaseHelper.TestConnection()`. If False, show a MessageBox and exit.

---

### `Helpers/PasswordHelper.vb`

**Purpose:** Hash and verify passwords using BCrypt. Requires NuGet: `BCrypt.Net-Next`.

```vbnet
Imports BCrypt.Net

Public Class PasswordHelper

    ' Hash a plain-text password before saving to DB
    Public Shared Function HashPassword(plainText As String) As String
        Return BCrypt.HashPassword(plainText, workFactor:=12)
    End Function

    ' Verify a plain-text password against a stored hash
    Public Shared Function VerifyPassword(plainText As String, hash As String) As Boolean
        Try
            Return BCrypt.Verify(plainText, hash)
        Catch
            Return False
        End Try
    End Function

End Class
```

**Wire up:** Use `PasswordHelper.HashPassword()` when saving a new password. Use `PasswordHelper.VerifyPassword()` when checking login credentials.

---

### `Helpers/ValidationHelper.vb`

**Purpose:** Reusable input validation functions used across all forms.

```vbnet
Public Class ValidationHelper

    ' Returns True if the string is not empty/whitespace
    Public Shared Function IsRequired(value As String, fieldName As String, ByRef errorMsg As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            errorMsg = $"{fieldName} is required."
            Return False
        End If
        Return True
    End Function

    ' Returns True if the string is a valid positive decimal number
    Public Shared Function IsPositiveDecimal(value As String, fieldName As String, ByRef errorMsg As String) As Boolean
        Dim result As Decimal
        If Not Decimal.TryParse(value, result) OrElse result <= 0 Then
            errorMsg = $"{fieldName} must be a positive number."
            Return False
        End If
        Return True
    End Function

    ' Returns True if the string is a valid positive integer
    Public Shared Function IsPositiveInteger(value As String, fieldName As String, ByRef errorMsg As String) As Boolean
        Dim result As Integer
        If Not Integer.TryParse(value, result) OrElse result <= 0 Then
            errorMsg = $"{fieldName} must be a whole positive number."
            Return False
        End If
        Return True
    End Function

    ' Returns True if startDate is before endDate
    Public Shared Function IsDateRangeValid(startDate As Date, endDate As Date, ByRef errorMsg As String) As Boolean
        If endDate <= startDate Then
            errorMsg = "Due Date must be after Release Date."
            Return False
        End If
        Return True
    End Function

    ' Returns True if both password fields match
    Public Shared Function PasswordsMatch(pw As String, confirmPw As String, ByRef errorMsg As String) As Boolean
        If pw <> confirmPw Then
            errorMsg = "Passwords do not match."
            Return False
        End If
        Return True
    End Function

    ' Validate email format
    Public Shared Function IsValidEmail(email As String, ByRef errorMsg As String) As Boolean
        If Not email.Contains("@") OrElse Not email.Contains(".") Then
            errorMsg = "Please enter a valid email address."
            Return False
        End If
        Return True
    End Function

    ' Returns True if phone number is numeric and 10-11 digits
    Public Shared Function IsValidPhone(phone As String, ByRef errorMsg As String) As Boolean
        Dim digits = New String(phone.Where(Function(c) Char.IsDigit(c)).ToArray())
        If digits.Length < 10 OrElse digits.Length > 11 Then
            errorMsg = "Contact number must be 10-11 digits."
            Return False
        End If
        Return True
    End Function

    ' Show all errors in one MessageBox
    Public Shared Sub ShowErrors(errors As List(Of String))
        If errors.Count > 0 Then
            MessageBox.Show(
                String.Join(Environment.NewLine, errors),
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
        End If
    End Sub

End Class
```

---

## PART 2 — Model Classes

These are plain data objects (no DB logic). Create a `Models/` folder.

---

### `Models/UserModel.vb`

```vbnet
Public Class UserModel
    Public Property UserID As Integer
    Public Property Username As String
    Public Property PasswordHash As String
    Public Property Role As String
    Public Property SecurityQuestion As String
    Public Property SecurityAnswer As String
    Public Property IsActive As Boolean
    Public Property CreatedAt As DateTime
End Class
```

### `Models/BorrowerModel.vb`

```vbnet
Public Class BorrowerModel
    Public Property BorrowerID As Integer
    Public Property BorrowerUID As String
    Public Property FirstName As String
    Public Property MiddleName As String
    Public Property LastName As String
    Public Property FullName As String
        Get
            Return $"{FirstName} {MiddleName} {LastName}".Replace("  ", " ").Trim()
        End Get
    End Property
    Public Property Age As Integer
    Public Property DateOfBirth As Date
    Public Property Contact As String
    Public Property Email As String
    Public Property IDImagePath As String
    Public Property UserID As Integer
    Public Property CreatedAt As DateTime
End Class
```

### `Models/LoanModel.vb`

```vbnet
Public Class LoanModel
    Public Property LoanID As Integer
    Public Property LoanReferenceID As String
    Public Property BorrowerID As Integer
    Public Property BorrowerName As String      ' Joined from tbl_Borrowers
    Public Property LoanType As String
    Public Property PrincipalAmount As Decimal
    Public Property InterestRate As Decimal
    Public Property TotalPayable As Decimal
    Public Property Term As Integer
    Public Property ReleaseDate As Date
    Public Property DueDate As Date
    Public Property Status As String
    Public Property CreatedAt As DateTime
End Class
```

### `Models/PaymentModel.vb`

```vbnet
Public Class PaymentModel
    Public Property PaymentID As Integer
    Public Property LoanID As Integer
    Public Property LoanReferenceID As String   ' Joined from tbl_Loans
    Public Property Payee As String
    Public Property Amount As Decimal
    Public Property Penalty As Decimal
    Public Property PaymentDate As Date
    Public Property Status As String
    Public Property CreatedAt As DateTime
End Class
```

### `Models/LoanApplicationModel.vb`

```vbnet
Public Class LoanApplicationModel
    Public Property ApplicationID As Integer
    Public Property BorrowerID As Integer
    Public Property BorrowerName As String      ' Joined from tbl_Borrowers
    Public Property LoanType As String
    Public Property PrincipalAmount As Decimal
    Public Property InterestRate As Decimal
    Public Property TotalPayable As Decimal
    Public Property Term As Integer
    Public Property ReleaseDate As Date
    Public Property DueDate As Date
    Public Property Status As String
    Public Property SubmittedAt As DateTime
End Class
```

---

## PART 3 — Repository Classes (Data Access Layer)

Create a `Data/` folder. Each repository handles one table.

---

### `Data/UserRepository.vb`

```vbnet
Imports System.Data.SqlClient

Public Class UserRepository

    ' Used by LoginForm — find user by username and verify password
    Public Function GetUserByUsername(username As String) As UserModel
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT UserID, Username, PasswordHash, Role, SecurityQuestion, SecurityAnswer, IsActive
                 FROM tbl_Users WHERE Username = @Username AND IsActive = 1", conn)
            cmd.Parameters.AddWithValue("@Username", username)
            Using reader = cmd.ExecuteReader()
                If reader.Read() Then
                    Return New UserModel() With {
                        .UserID           = reader.GetInt32(0),
                        .Username         = reader.GetString(1),
                        .PasswordHash     = reader.GetString(2),
                        .Role             = reader.GetString(3),
                        .SecurityQuestion = reader.GetString(4),
                        .SecurityAnswer   = reader.GetString(5),
                        .IsActive         = reader.GetBoolean(6)
                    }
                End If
            End Using
        End Using
        Return Nothing
    End Function

    ' Used by ForgotPasswordForm — verify security answer
    Public Function VerifySecurityAnswer(username As String, question As String, answer As String) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT COUNT(*) FROM tbl_Users
                 WHERE Username = @Username AND SecurityQuestion = @Question AND SecurityAnswer = @Answer", conn)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Question", question)
            cmd.Parameters.AddWithValue("@Answer", answer)
            Return CInt(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    ' Used by ForgotPasswordForm — update password
    Public Function UpdatePassword(username As String, newPasswordHash As String) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "UPDATE tbl_Users SET PasswordHash = @Hash WHERE Username = @Username", conn)
            cmd.Parameters.AddWithValue("@Hash", newPasswordHash)
            cmd.Parameters.AddWithValue("@Username", username)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Used by MyAccountForm — update username, password, security Q&A
    Public Function UpdateAccountCredentials(userID As Integer, username As String,
                                             passwordHash As String, question As String,
                                             answer As String) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "UPDATE tbl_Users SET Username = @Username, PasswordHash = @Hash,
                 SecurityQuestion = @Question, SecurityAnswer = @Answer
                 WHERE UserID = @UserID", conn)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Hash", passwordHash)
            cmd.Parameters.AddWithValue("@Question", question)
            cmd.Parameters.AddWithValue("@Answer", answer)
            cmd.Parameters.AddWithValue("@UserID", userID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Used by BorrowerAccountsForm — get all borrower accounts
    Public Function GetAllBorrowerAccounts() As List(Of UserModel)
        Dim list As New List(Of UserModel)()
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT u.UserID, u.Username, u.IsActive, b.FirstName + ' ' + b.LastName AS FullName
                 FROM tbl_Users u
                 INNER JOIN tbl_Borrowers b ON b.UserID = u.UserID
                 WHERE u.Role = 'Borrower'
                 ORDER BY b.LastName", conn)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    list.Add(New UserModel() With {
                        .UserID   = reader.GetInt32(0),
                        .Username = reader.GetString(1),
                        .IsActive = reader.GetBoolean(2)
                    })
                End While
            End Using
        End Using
        Return list
    End Function

    ' Used by BorrowerAccountsForm — create a new borrower user account
    Public Function CreateBorrowerAccount(username As String, passwordHash As String,
                                          question As String, answer As String) As Integer
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "INSERT INTO tbl_Users (Username, PasswordHash, Role, SecurityQuestion, SecurityAnswer, IsActive, CreatedAt)
                 VALUES (@Username, @Hash, 'Borrower', @Question, @Answer, 1, GETDATE());
                 SELECT SCOPE_IDENTITY();", conn)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Hash", passwordHash)
            cmd.Parameters.AddWithValue("@Question", question)
            cmd.Parameters.AddWithValue("@Answer", answer)
            Return CInt(cmd.ExecuteScalar())
        End Using
    End Function

    ' Used by BorrowerAccountsForm — soft-delete (deactivate) account
    Public Function DeactivateAccount(userID As Integer) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "UPDATE tbl_Users SET IsActive = 0 WHERE UserID = @UserID", conn)
            cmd.Parameters.AddWithValue("@UserID", userID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

End Class
```

---

### `Data/BorrowerRepository.vb`

```vbnet
Imports System.Data.SqlClient

Public Class BorrowerRepository

    ' Used by BorrowerListForm — load all borrowers with their active loan summary
    Public Function GetAllBorrowers() As List(Of BorrowerModel)
        Dim list As New List(Of BorrowerModel)()
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT b.BorrowerID, b.BorrowerUID, b.FirstName, b.MiddleName, b.LastName,
                        b.Age, b.DateOfBirth, b.Contact, b.Email, b.IDImagePath, b.UserID, b.CreatedAt
                 FROM tbl_Borrowers b
                 ORDER BY b.LastName, b.FirstName", conn)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    list.Add(MapBorrower(reader))
                End While
            End Using
        End Using
        Return list
    End Function

    ' Used by NewBorrowerForm (Update mode) — load a single borrower
    Public Function GetBorrowerByID(borrowerID As Integer) As BorrowerModel
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT BorrowerID, BorrowerUID, FirstName, MiddleName, LastName,
                        Age, DateOfBirth, Contact, Email, IDImagePath, UserID, CreatedAt
                 FROM tbl_Borrowers WHERE BorrowerID = @ID", conn)
            cmd.Parameters.AddWithValue("@ID", borrowerID)
            Using reader = cmd.ExecuteReader()
                If reader.Read() Then Return MapBorrower(reader)
            End Using
        End Using
        Return Nothing
    End Function

    ' Used by NewLoanForm — populate borrower name dropdown
    Public Function GetAllBorrowerNames() As List(Of BorrowerModel)
        Dim list As New List(Of BorrowerModel)()
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT BorrowerID, FirstName, MiddleName, LastName
                 FROM tbl_Borrowers ORDER BY LastName, FirstName", conn)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    list.Add(New BorrowerModel() With {
                        .BorrowerID = reader.GetInt32(0),
                        .FirstName  = reader.GetString(1),
                        .MiddleName = If(reader.IsDBNull(2), "", reader.GetString(2)),
                        .LastName   = reader.GetString(3)
                    })
                End While
            End Using
        End Using
        Return list
    End Function

    ' Used by NewBorrowerForm — generate next BorrowerUID like BRW-0006
    Public Function GetNextBorrowerUID() As String
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand("SELECT COUNT(*) FROM tbl_Borrowers", conn)
            Dim count As Integer = CInt(cmd.ExecuteScalar()) + 1
            Return $"BRW-{count:D4}"
        End Using
    End Function

    ' Used by NewBorrowerForm (Add mode) — insert new borrower
    Public Function AddBorrower(b As BorrowerModel) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "INSERT INTO tbl_Borrowers
                 (BorrowerUID, FirstName, MiddleName, LastName, Age, DateOfBirth,
                  Contact, Email, IDImagePath, UserID, CreatedAt)
                 VALUES
                 (@UID, @First, @Middle, @Last, @Age, @DOB,
                  @Contact, @Email, @IDPath, @UserID, GETDATE())", conn)
            cmd.Parameters.AddWithValue("@UID",    b.BorrowerUID)
            cmd.Parameters.AddWithValue("@First",  b.FirstName)
            cmd.Parameters.AddWithValue("@Middle", If(b.MiddleName, DBNull.Value))
            cmd.Parameters.AddWithValue("@Last",   b.LastName)
            cmd.Parameters.AddWithValue("@Age",    b.Age)
            cmd.Parameters.AddWithValue("@DOB",    b.DateOfBirth)
            cmd.Parameters.AddWithValue("@Contact",b.Contact)
            cmd.Parameters.AddWithValue("@Email",  b.Email)
            cmd.Parameters.AddWithValue("@IDPath", If(b.IDImagePath, DBNull.Value))
            cmd.Parameters.AddWithValue("@UserID", b.UserID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Used by NewBorrowerForm (Update mode) — update existing borrower
    Public Function UpdateBorrower(b As BorrowerModel) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "UPDATE tbl_Borrowers SET
                 FirstName = @First, MiddleName = @Middle, LastName = @Last,
                 Age = @Age, DateOfBirth = @DOB, Contact = @Contact,
                 Email = @Email, IDImagePath = @IDPath
                 WHERE BorrowerID = @ID", conn)
            cmd.Parameters.AddWithValue("@First",  b.FirstName)
            cmd.Parameters.AddWithValue("@Middle", If(b.MiddleName, DBNull.Value))
            cmd.Parameters.AddWithValue("@Last",   b.LastName)
            cmd.Parameters.AddWithValue("@Age",    b.Age)
            cmd.Parameters.AddWithValue("@DOB",    b.DateOfBirth)
            cmd.Parameters.AddWithValue("@Contact",b.Contact)
            cmd.Parameters.AddWithValue("@Email",  b.Email)
            cmd.Parameters.AddWithValue("@IDPath", If(b.IDImagePath, DBNull.Value))
            cmd.Parameters.AddWithValue("@ID",     b.BorrowerID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Used by BorrowerListForm — hard delete (only if no loans linked)
    Public Function DeleteBorrower(borrowerID As Integer) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "DELETE FROM tbl_Borrowers WHERE BorrowerID = @ID", conn)
            cmd.Parameters.AddWithValue("@ID", borrowerID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    Private Function MapBorrower(reader As SqlDataReader) As BorrowerModel
        Return New BorrowerModel() With {
            .BorrowerID  = reader.GetInt32(0),
            .BorrowerUID = reader.GetString(1),
            .FirstName   = reader.GetString(2),
            .MiddleName  = If(reader.IsDBNull(3), "", reader.GetString(3)),
            .LastName    = reader.GetString(4),
            .Age         = reader.GetInt32(5),
            .DateOfBirth = reader.GetDateTime(6),
            .Contact     = reader.GetString(7),
            .Email       = reader.GetString(8),
            .IDImagePath = If(reader.IsDBNull(9), "", reader.GetString(9)),
            .UserID      = If(reader.IsDBNull(10), 0, reader.GetInt32(10)),
            .CreatedAt   = reader.GetDateTime(11)
        }
    End Function

End Class
```

---

### `Data/LoanRepository.vb`

```vbnet
Imports System.Data.SqlClient

Public Class LoanRepository

    ' Used by LoanListForm — load all loans with borrower name
    Public Function GetAllLoans() As List(Of LoanModel)
        Dim list As New List(Of LoanModel)()
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT l.LoanID, l.LoanReferenceID,
                        b.FirstName + ' ' + b.LastName AS BorrowerName,
                        l.BorrowerID, l.LoanType, l.PrincipalAmount, l.InterestRate,
                        l.TotalPayable, l.Term, l.ReleaseDate, l.DueDate, l.Status, l.CreatedAt
                 FROM tbl_Loans l
                 INNER JOIN tbl_Borrowers b ON b.BorrowerID = l.BorrowerID
                 ORDER BY l.CreatedAt DESC", conn)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    list.Add(MapLoan(reader))
                End While
            End Using
        End Using
        Return list
    End Function

    ' Used by LoanListForm (search) — filter by keyword
    Public Function SearchLoans(keyword As String) As List(Of LoanModel)
        Dim list As New List(Of LoanModel)()
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT l.LoanID, l.LoanReferenceID,
                        b.FirstName + ' ' + b.LastName AS BorrowerName,
                        l.BorrowerID, l.LoanType, l.PrincipalAmount, l.InterestRate,
                        l.TotalPayable, l.Term, l.ReleaseDate, l.DueDate, l.Status, l.CreatedAt
                 FROM tbl_Loans l
                 INNER JOIN tbl_Borrowers b ON b.BorrowerID = l.BorrowerID
                 WHERE l.LoanReferenceID LIKE @kw
                    OR b.FirstName + ' ' + b.LastName LIKE @kw
                    OR l.Status LIKE @kw
                 ORDER BY l.CreatedAt DESC", conn)
            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%")
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    list.Add(MapLoan(reader))
                End While
            End Using
        End Using
        Return list
    End Function

    ' Used by NewLoanForm — generate next LoanReferenceID like LN-0006
    Public Function GetNextLoanReferenceID() As String
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand("SELECT COUNT(*) FROM tbl_Loans", conn)
            Dim count As Integer = CInt(cmd.ExecuteScalar()) + 1
            Return $"LN-{count:D4}"
        End Using
    End Function

    ' Used by NewLoanForm (Add mode) — insert new loan
    Public Function AddLoan(loan As LoanModel) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "INSERT INTO tbl_Loans
                 (LoanReferenceID, BorrowerID, LoanType, PrincipalAmount, InterestRate,
                  TotalPayable, Term, ReleaseDate, DueDate, Status, CreatedAt)
                 VALUES
                 (@RefID, @BorrID, @Type, @Principal, @Rate,
                  @Total, @Term, @Release, @Due, 'Active', GETDATE())", conn)
            cmd.Parameters.AddWithValue("@RefID",    loan.LoanReferenceID)
            cmd.Parameters.AddWithValue("@BorrID",   loan.BorrowerID)
            cmd.Parameters.AddWithValue("@Type",     loan.LoanType)
            cmd.Parameters.AddWithValue("@Principal",loan.PrincipalAmount)
            cmd.Parameters.AddWithValue("@Rate",     loan.InterestRate)
            cmd.Parameters.AddWithValue("@Total",    loan.TotalPayable)
            cmd.Parameters.AddWithValue("@Term",     loan.Term)
            cmd.Parameters.AddWithValue("@Release",  loan.ReleaseDate)
            cmd.Parameters.AddWithValue("@Due",      loan.DueDate)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Used by NewLoanForm (Update mode) — update existing loan
    Public Function UpdateLoan(loan As LoanModel) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "UPDATE tbl_Loans SET
                 BorrowerID = @BorrID, LoanType = @Type, PrincipalAmount = @Principal,
                 InterestRate = @Rate, TotalPayable = @Total, Term = @Term,
                 ReleaseDate = @Release, DueDate = @Due
                 WHERE LoanID = @ID", conn)
            cmd.Parameters.AddWithValue("@BorrID",   loan.BorrowerID)
            cmd.Parameters.AddWithValue("@Type",     loan.LoanType)
            cmd.Parameters.AddWithValue("@Principal",loan.PrincipalAmount)
            cmd.Parameters.AddWithValue("@Rate",     loan.InterestRate)
            cmd.Parameters.AddWithValue("@Total",    loan.TotalPayable)
            cmd.Parameters.AddWithValue("@Term",     loan.Term)
            cmd.Parameters.AddWithValue("@Release",  loan.ReleaseDate)
            cmd.Parameters.AddWithValue("@Due",      loan.DueDate)
            cmd.Parameters.AddWithValue("@ID",       loan.LoanID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Used by LoanListForm — delete a loan
    Public Function DeleteLoan(loanID As Integer) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand("DELETE FROM tbl_Loans WHERE LoanID = @ID", conn)
            cmd.Parameters.AddWithValue("@ID", loanID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Used when approving a loan application — create loan from application
    Public Function CreateLoanFromApplication(app As LoanApplicationModel) As Boolean
        Dim loan As New LoanModel() With {
            .LoanReferenceID = GetNextLoanReferenceID(),
            .BorrowerID      = app.BorrowerID,
            .LoanType        = app.LoanType,
            .PrincipalAmount = app.PrincipalAmount,
            .InterestRate    = app.InterestRate,
            .TotalPayable    = app.TotalPayable,
            .Term            = app.Term,
            .ReleaseDate     = app.ReleaseDate,
            .DueDate         = app.DueDate
        }
        Return AddLoan(loan)
    End Function

    Private Function MapLoan(reader As SqlDataReader) As LoanModel
        Return New LoanModel() With {
            .LoanID          = reader.GetInt32(0),
            .LoanReferenceID = reader.GetString(1),
            .BorrowerName    = reader.GetString(2),
            .BorrowerID      = reader.GetInt32(3),
            .LoanType        = reader.GetString(4),
            .PrincipalAmount = reader.GetDecimal(5),
            .InterestRate    = reader.GetDecimal(6),
            .TotalPayable    = reader.GetDecimal(7),
            .Term            = reader.GetInt32(8),
            .ReleaseDate     = reader.GetDateTime(9),
            .DueDate         = reader.GetDateTime(10),
            .Status          = reader.GetString(11),
            .CreatedAt       = reader.GetDateTime(12)
        }
    End Function

End Class
```

---

### `Data/PaymentRepository.vb`

```vbnet
Imports System.Data.SqlClient

Public Class PaymentRepository

    ' Used by PaymentListForm — load all payments with loan reference ID
    Public Function GetAllPayments() As List(Of PaymentModel)
        Dim list As New List(Of PaymentModel)()
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT p.PaymentID, l.LoanReferenceID, p.LoanID,
                        p.Payee, p.Amount, p.Penalty, p.PaymentDate, p.Status, p.CreatedAt
                 FROM tbl_Payments p
                 INNER JOIN tbl_Loans l ON l.LoanID = p.LoanID
                 ORDER BY p.PaymentDate DESC", conn)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    list.Add(MapPayment(reader))
                End While
            End Using
        End Using
        Return list
    End Function

    ' Used by PaymentListForm (search)
    Public Function SearchPayments(keyword As String) As List(Of PaymentModel)
        Dim list As New List(Of PaymentModel)()
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT p.PaymentID, l.LoanReferenceID, p.LoanID,
                        p.Payee, p.Amount, p.Penalty, p.PaymentDate, p.Status, p.CreatedAt
                 FROM tbl_Payments p
                 INNER JOIN tbl_Loans l ON l.LoanID = p.LoanID
                 WHERE l.LoanReferenceID LIKE @kw OR p.Payee LIKE @kw OR p.Status LIKE @kw
                 ORDER BY p.PaymentDate DESC", conn)
            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%")
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    list.Add(MapPayment(reader))
                End While
            End Using
        End Using
        Return list
    End Function

    ' Used by NewPaymentForm — insert new payment
    Public Function AddPayment(payment As PaymentModel) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "INSERT INTO tbl_Payments
                 (LoanID, Payee, Amount, Penalty, PaymentDate, Status, CreatedAt)
                 VALUES
                 (@LoanID, @Payee, @Amount, @Penalty, @Date, @Status, GETDATE())", conn)
            cmd.Parameters.AddWithValue("@LoanID",  payment.LoanID)
            cmd.Parameters.AddWithValue("@Payee",   payment.Payee)
            cmd.Parameters.AddWithValue("@Amount",  payment.Amount)
            cmd.Parameters.AddWithValue("@Penalty", payment.Penalty)
            cmd.Parameters.AddWithValue("@Date",    payment.PaymentDate)
            cmd.Parameters.AddWithValue("@Status",  payment.Status)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Used by NewPaymentForm (Update mode) — update existing payment
    Public Function UpdatePayment(payment As PaymentModel) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "UPDATE tbl_Payments SET
                 Payee = @Payee, Amount = @Amount, Penalty = @Penalty,
                 PaymentDate = @Date, Status = @Status
                 WHERE PaymentID = @ID", conn)
            cmd.Parameters.AddWithValue("@Payee",   payment.Payee)
            cmd.Parameters.AddWithValue("@Amount",  payment.Amount)
            cmd.Parameters.AddWithValue("@Penalty", payment.Penalty)
            cmd.Parameters.AddWithValue("@Date",    payment.PaymentDate)
            cmd.Parameters.AddWithValue("@Status",  payment.Status)
            cmd.Parameters.AddWithValue("@ID",      payment.PaymentID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Used by PaymentListForm — delete a payment
    Public Function DeletePayment(paymentID As Integer) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand("DELETE FROM tbl_Payments WHERE PaymentID = @ID", conn)
            cmd.Parameters.AddWithValue("@ID", paymentID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Calculate penalty: 2% of amount per day overdue (example rule)
    Public Shared Function CalculatePenalty(amount As Decimal, dueDate As Date) As Decimal
        Dim daysOverdue As Integer = (Date.Today - dueDate).Days
        If daysOverdue <= 0 Then Return 0
        Return Math.Round(amount * 0.02D * daysOverdue, 2)
    End Function

    Private Function MapPayment(reader As SqlDataReader) As PaymentModel
        Return New PaymentModel() With {
            .PaymentID       = reader.GetInt32(0),
            .LoanReferenceID = reader.GetString(1),
            .LoanID          = reader.GetInt32(2),
            .Payee           = reader.GetString(3),
            .Amount          = reader.GetDecimal(4),
            .Penalty         = reader.GetDecimal(5),
            .PaymentDate     = reader.GetDateTime(6),
            .Status          = reader.GetString(7),
            .CreatedAt       = reader.GetDateTime(8)
        }
    End Function

End Class
```

---

### `Data/LoanApplicationRepository.vb`

```vbnet
Imports System.Data.SqlClient

Public Class LoanApplicationRepository

    ' Used by TrackLoanForm — load applications for the logged-in borrower only
    Public Function GetApplicationsByBorrower(borrowerID As Integer) As List(Of LoanApplicationModel)
        Dim list As New List(Of LoanApplicationModel)()
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT a.ApplicationID, a.BorrowerID,
                        b.FirstName + ' ' + b.LastName AS BorrowerName,
                        a.LoanType, a.PrincipalAmount, a.InterestRate,
                        a.TotalPayable, a.Term, a.ReleaseDate, a.DueDate, a.Status, a.SubmittedAt
                 FROM tbl_LoanApplications a
                 INNER JOIN tbl_Borrowers b ON b.BorrowerID = a.BorrowerID
                 WHERE a.BorrowerID = @BorrID
                 ORDER BY a.SubmittedAt DESC", conn)
            cmd.Parameters.AddWithValue("@BorrID", borrowerID)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    list.Add(MapApplication(reader))
                End While
            End Using
        End Using
        Return list
    End Function

    ' Used by Admin LoanList — load all pending applications
    Public Function GetAllApplications() As List(Of LoanApplicationModel)
        Dim list As New List(Of LoanApplicationModel)()
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "SELECT a.ApplicationID, a.BorrowerID,
                        b.FirstName + ' ' + b.LastName AS BorrowerName,
                        a.LoanType, a.PrincipalAmount, a.InterestRate,
                        a.TotalPayable, a.Term, a.ReleaseDate, a.DueDate, a.Status, a.SubmittedAt
                 FROM tbl_LoanApplications a
                 INNER JOIN tbl_Borrowers b ON b.BorrowerID = a.BorrowerID
                 ORDER BY a.SubmittedAt DESC", conn)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    list.Add(MapApplication(reader))
                End While
            End Using
        End Using
        Return list
    End Function

    ' Used by LoanApplicationForm — generate next application ID like APP-0002
    Public Function GetNextApplicationID() As String
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand("SELECT COUNT(*) FROM tbl_LoanApplications", conn)
            Dim count As Integer = CInt(cmd.ExecuteScalar()) + 1
            Return $"APP-{count:D4}"
        End Using
    End Function

    ' Used by LoanApplicationForm — submit new loan application
    Public Function SubmitApplication(app As LoanApplicationModel) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "INSERT INTO tbl_LoanApplications
                 (BorrowerID, LoanType, PrincipalAmount, InterestRate,
                  TotalPayable, Term, ReleaseDate, DueDate, Status, SubmittedAt)
                 VALUES
                 (@BorrID, @Type, @Principal, @Rate,
                  @Total, @Term, @Release, @Due, 'Pending', GETDATE())", conn)
            cmd.Parameters.AddWithValue("@BorrID",   app.BorrowerID)
            cmd.Parameters.AddWithValue("@Type",     app.LoanType)
            cmd.Parameters.AddWithValue("@Principal",app.PrincipalAmount)
            cmd.Parameters.AddWithValue("@Rate",     app.InterestRate)
            cmd.Parameters.AddWithValue("@Total",    app.TotalPayable)
            cmd.Parameters.AddWithValue("@Term",     app.Term)
            cmd.Parameters.AddWithValue("@Release",  app.ReleaseDate)
            cmd.Parameters.AddWithValue("@Due",      app.DueDate)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    ' Used by Admin — approve or reject an application
    Public Function UpdateApplicationStatus(applicationID As Integer, status As String) As Boolean
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand(
                "UPDATE tbl_LoanApplications SET Status = @Status WHERE ApplicationID = @ID", conn)
            cmd.Parameters.AddWithValue("@Status", status)  ' "Approved" or "Rejected"
            cmd.Parameters.AddWithValue("@ID", applicationID)
            Return cmd.ExecuteNonQuery() > 0
        End Using
    End Function

    Private Function MapApplication(reader As SqlDataReader) As LoanApplicationModel
        Return New LoanApplicationModel() With {
            .ApplicationID   = reader.GetInt32(0),
            .BorrowerID      = reader.GetInt32(1),
            .BorrowerName    = reader.GetString(2),
            .LoanType        = reader.GetString(3),
            .PrincipalAmount = reader.GetDecimal(4),
            .InterestRate    = reader.GetDecimal(5),
            .TotalPayable    = reader.GetDecimal(6),
            .Term            = reader.GetInt32(7),
            .ReleaseDate     = reader.GetDateTime(8),
            .DueDate         = reader.GetDateTime(9),
            .Status          = reader.GetString(10),
            .SubmittedAt     = reader.GetDateTime(11)
        }
    End Function

End Class
```

---

## PART 4 — Form-Level Backend Functions

This section shows exactly what to replace/add in each existing form file.

---

### `Form1.vb` — LoginForm

**Functions to add/replace:**

```vbnet
' REPLACE the existing btnLogin_Click — add real authentication
Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
    Dim username = txtUsername.Text.Trim()
    Dim password = txtPassword.Text

    If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
        MessageBox.Show("Please enter your username and password.", "Login Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If

    Try
        Dim repo As New UserRepository()
        Dim user = repo.GetUserByUsername(username)

        If user Is Nothing OrElse Not PasswordHelper.VerifyPassword(password, user.PasswordHash) Then
            MessageBox.Show("Invalid username or password. Please try again.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Clear()
            txtPassword.Focus()
            Return
        End If

        ' Set session
        Dim borrowerID As Integer = 0
        If user.Role = "Borrower" Then
            ' Look up BorrowerID linked to this UserID
            Dim bRepo As New BorrowerRepository()
            ' (add GetBorrowerByUserID to BorrowerRepository — see note below)
        End If
        SessionManager.SetSession(user.UserID, user.Username, user.Role, borrowerID)

        If user.Role = "Admin" Then
            Dim dash As New AdminDashboardForm()
            dash.Show()
        Else
            Dim dash As New BorrowerDashboardForm()
            dash.Show()
        End If
        Me.Hide()

    Catch ex As Exception
        MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub

' REMOVE btnAdmin_Click and btnUser_Click (the bypass buttons)
' DELETE those two buttons from the form entirely
```

> **Note:** Add `GetBorrowerByUserID(userID As Integer) As BorrowerModel` to `BorrowerRepository.vb`:
> ```vbnet
> Public Function GetBorrowerByUserID(userID As Integer) As BorrowerModel
>     Using conn = DatabaseHelper.GetConnection()
>         conn.Open()
>         Dim cmd As New SqlCommand(
>             "SELECT BorrowerID, BorrowerUID, FirstName, MiddleName, LastName,
>                     Age, DateOfBirth, Contact, Email, IDImagePath, UserID, CreatedAt
>              FROM tbl_Borrowers WHERE UserID = @ID", conn)
>         cmd.Parameters.AddWithValue("@ID", userID)
>         Using reader = cmd.ExecuteReader()
>             If reader.Read() Then Return MapBorrower(reader)
>         End Using
>     End Using
>     Return Nothing
> End Function
> ```

---

### `ForgotPasswordForm.vb`

**Functions to add/replace:**

```vbnet
' REPLACE btnSubmit_Click
Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
    Dim errors As New List(Of String)()
    Dim msg As String = ""

    If Not ValidationHelper.IsRequired(txtAnswer.Text, "Security Answer", msg) Then errors.Add(msg)
    If Not ValidationHelper.IsRequired(txtNewPassword.Text, "New Password", msg) Then errors.Add(msg)
    If Not ValidationHelper.PasswordsMatch(txtNewPassword.Text, txtConfirmPassword.Text, msg) Then errors.Add(msg)

    If errors.Count > 0 Then
        ValidationHelper.ShowErrors(errors)
        Return
    End If

    ' txtUsername must exist on the form — add a TextBox for username input
    Dim username = txtUsername.Text.Trim()
    Dim repo As New UserRepository()

    Try
        If Not repo.VerifySecurityAnswer(username, cmbSecurityQuestion.SelectedItem.ToString(), txtAnswer.Text.Trim()) Then
            MessageBox.Show("Security answer is incorrect.", "Verification Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim newHash = PasswordHelper.HashPassword(txtNewPassword.Text)
        repo.UpdatePassword(username, newHash)

        MessageBox.Show("Your password has been reset successfully." & Environment.NewLine &
                        "Please log in with your new password.",
                        "Password Reset Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dim login As New LoginForm()
        login.Show()
        Me.Close()

    Catch ex As Exception
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

> **Note:** Add a `txtUsername` TextBox to `ForgotPasswordForm` UI above the security question group so the user can enter their username first.

---

### `AdminDashboardForm.vb`

**Functions to modify:**

```vbnet
' UPDATE Form_Load — show actual username from session
Private Sub AdminDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    lblWelcome.Text = $"Welcome, {SessionManager.CurrentUsername}"
    SetActiveButton(btnLoanList)
End Sub

' UPDATE btnLogout_Click — clear session and properly dispose form
Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
    Dim result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    If result = DialogResult.Yes Then
        SessionManager.ClearSession()
        Dim login As New LoginForm()
        login.Show()
        Me.Close()    ' Close instead of Hide to free memory
    End If
End Sub
```

---

### `BorrowerDashboardForm.vb`

**Functions to modify:**

```vbnet
' UPDATE Form_Load — show actual borrower name from session
Private Sub BorrowerDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ' Load borrower full name using session BorrowerID
    Try
        Dim repo As New BorrowerRepository()
        Dim borrower = repo.GetBorrowerByID(SessionManager.CurrentBorrowerID)
        If borrower IsNot Nothing Then
            lblWelcome.Text = $"Welcome, {borrower.FullName}"
        End If
    Catch ex As Exception
        lblWelcome.Text = $"Welcome, {SessionManager.CurrentUsername}"
    End Try
    SetActiveButton(btnFileLoan)
    ShowWelcomePanel()
End Sub

' UPDATE btnLogout_Click — clear session
Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
    SessionManager.ClearSession()
    Dim login As New LoginForm()
    login.Show()
    Me.Close()
End Sub
```

---

### `LoanListForm.vb`

**Functions to add/replace:**

```vbnet
' REPLACE LoadSampleData with LoadFromDatabase
Private Sub LoadFromDatabase(Optional keyword As String = "")
    Try
        Dim repo As New LoanRepository()
        Dim loans = If(String.IsNullOrWhiteSpace(keyword),
                       repo.GetAllLoans(),
                       repo.SearchLoans(keyword))
        dgvLoans.Rows.Clear()
        For Each loan In loans
            dgvLoans.Rows.Add(
                loan.LoanReferenceID,
                loan.BorrowerName,
                $"{loan.LoanType} | PHP {loan.PrincipalAmount:N2} | {loan.Term} mos @ {loan.InterestRate}%",
                $"PHP {loan.TotalPayable / loan.Term:N2} — Due {loan.DueDate:MMM dd, yyyy}",
                loan.Status
            )
            ' Store LoanID as Tag on the row for update/delete
            dgvLoans.Rows(dgvLoans.Rows.Count - 1).Tag = loan.LoanID
        Next
        lblRecordCount.Text = $"Showing {dgvLoans.Rows.Count} records"
    Catch ex As Exception
        MessageBox.Show($"Error loading loans: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub

' ADD search handler — wire to txtSearch.TextChanged
Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
    LoadFromDatabase(txtSearch.Text.Trim())
End Sub

' REPLACE btnUpdate_Click — pass selected loan data to NewLoanForm
Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
    If dgvLoans.SelectedRows.Count = 0 Then
        MessageBox.Show("Please select a loan record to update.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If
    Dim loanID As Integer = CInt(dgvLoans.SelectedRows(0).Tag)
    Dim frm As New NewLoanForm(loanID)   ' Pass LoanID to NewLoanForm
    frm.ShowDialog()
    LoadFromDatabase()   ' Refresh after update
End Sub

' REPLACE btnDelete_Click — delete from DB
Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    If dgvLoans.SelectedRows.Count = 0 Then
        MessageBox.Show("Please select a loan record to delete.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If
    Dim result = MessageBox.Show("Are you sure you want to delete this loan record?",
                                 "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    If result = DialogResult.Yes Then
        Try
            Dim loanID As Integer = CInt(dgvLoans.SelectedRows(0).Tag)
            Dim repo As New LoanRepository()
            repo.DeleteLoan(loanID)
            LoadFromDatabase()
        Catch ex As Exception
            MessageBox.Show($"Error deleting loan: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End If
End Sub

' ALSO: Set btnDelete.Visible = True in InitializeComponent
```

---

### `NewLoanForm.vb`

**Functions to add/replace:**

```vbnet
' ADD a LoanID parameter for Edit mode (0 = Add mode)
Private _loanID As Integer = 0

Public Sub New(Optional loanID As Integer = 0)
    InitializeComponent()
    _loanID = loanID
End Sub

' REPLACE Form_Load — populate borrowers from DB, auto-gen Loan ID, load data if editing
Private Sub NewLoanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    LoadBorrowerNames()
    cmbLoanType.SelectedIndex = 0
    dtpReleaseDate.Value = DateTime.Today
    dtpDueDate.Value = DateTime.Today.AddMonths(12)

    If _loanID = 0 Then
        ' Add mode — generate next Loan ID
        Dim repo As New LoanRepository()
        txtLoanID.Text = repo.GetNextLoanReferenceID()
    Else
        ' Edit mode — load existing loan data
        LoadLoanData(_loanID)
        btnAdd.Text = "Update Loan"
    End If
End Sub

Private Sub LoadBorrowerNames()
    Try
        Dim repo As New BorrowerRepository()
        Dim borrowers = repo.GetAllBorrowerNames()
        cmbBorrowerName.Items.Clear()
        For Each b In borrowers
            cmbBorrowerName.Items.Add(b)   ' Display uses ToString override or FullName
        Next
        If cmbBorrowerName.Items.Count > 0 Then cmbBorrowerName.SelectedIndex = 0
    Catch ex As Exception
        MessageBox.Show($"Error loading borrowers: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub

Private Sub LoadLoanData(loanID As Integer)
    Try
        Dim repo As New LoanRepository()
        ' Add GetLoanByID to LoanRepository
        ' Populate all fields from the returned LoanModel
    Catch ex As Exception
        MessageBox.Show($"Error loading loan data: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub

' ADD TotalPayable auto-calculation — wire to txtPrincipalAmount.TextChanged,
'     txtInterestRate.TextChanged, txtTerm.TextChanged
Private Sub CalculateTotalPayable()
    Dim principal As Decimal
    Dim rate As Decimal
    Dim term As Integer
    If Decimal.TryParse(txtPrincipalAmount.Text, principal) AndAlso
       Decimal.TryParse(txtInterestRate.Text, rate) AndAlso
       Integer.TryParse(txtTerm.Text, term) AndAlso term > 0 Then
        Dim total = principal + (principal * (rate / 100) * (term / 12))
        txtTotalPayable.Text = Math.Round(total, 2).ToString("N2")
    End If
End Sub

' REPLACE btnAdd_Click — validate and save to DB
Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
    Dim errors As New List(Of String)()
    Dim msg As String = ""

    If cmbBorrowerName.SelectedIndex < 0 Then errors.Add("Please select a Borrower.")
    If cmbLoanType.SelectedIndex < 0 Then errors.Add("Please select a Loan Type.")
    If Not ValidationHelper.IsPositiveDecimal(txtPrincipalAmount.Text, "Principal Amount", msg) Then errors.Add(msg)
    If Not ValidationHelper.IsPositiveDecimal(txtInterestRate.Text, "Interest Rate", msg) Then errors.Add(msg)
    If Not ValidationHelper.IsPositiveInteger(txtTerm.Text, "Term", msg) Then errors.Add(msg)
    If Not ValidationHelper.IsDateRangeValid(dtpReleaseDate.Value, dtpDueDate.Value, msg) Then errors.Add(msg)

    If errors.Count > 0 Then
        ValidationHelper.ShowErrors(errors)
        Return
    End If

    Try
        Dim selectedBorrower = CType(cmbBorrowerName.SelectedItem, BorrowerModel)
        Dim loan As New LoanModel() With {
            .LoanID          = _loanID,
            .LoanReferenceID = txtLoanID.Text,
            .BorrowerID      = selectedBorrower.BorrowerID,
            .LoanType        = cmbLoanType.SelectedItem.ToString(),
            .PrincipalAmount = Decimal.Parse(txtPrincipalAmount.Text),
            .InterestRate    = Decimal.Parse(txtInterestRate.Text),
            .TotalPayable    = Decimal.Parse(txtTotalPayable.Text.Replace(",", "")),
            .Term            = Integer.Parse(txtTerm.Text),
            .ReleaseDate     = dtpReleaseDate.Value,
            .DueDate         = dtpDueDate.Value
        }

        Dim repo As New LoanRepository()
        Dim success = If(_loanID = 0, repo.AddLoan(loan), repo.UpdateLoan(loan))

        If success Then
            MessageBox.Show(If(_loanID = 0, "Loan added successfully.", "Loan updated successfully."),
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    Catch ex As Exception
        MessageBox.Show($"Error saving loan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

---

### `BorrowerListForm.vb`

**Functions to add/replace:** *(same pattern as LoanListForm)*

```vbnet
' REPLACE LoadSampleData → LoadFromDatabase
Private Sub LoadFromDatabase(Optional keyword As String = "")
    Try
        Dim repo As New BorrowerRepository()
        Dim borrowers = repo.GetAllBorrowers()
        ' If keyword given, filter in memory or add SearchBorrowers to repo
        dgvBorrowers.Rows.Clear()
        For Each b In borrowers
            If String.IsNullOrWhiteSpace(keyword) OrElse
               b.FullName.ToLower().Contains(keyword.ToLower()) OrElse
               b.BorrowerUID.ToLower().Contains(keyword.ToLower()) Then
                dgvBorrowers.Rows.Add(b.BorrowerUID, b.FullName, "—", "—", "Active")
                dgvBorrowers.Rows(dgvBorrowers.Rows.Count - 1).Tag = b.BorrowerID
            End If
        Next
        lblRecordCount.Text = $"Showing {dgvBorrowers.Rows.Count} records"
    Catch ex As Exception
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub

' ADD search wire-up
Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
    LoadFromDatabase(txtSearch.Text.Trim())
End Sub

' REPLACE btnUpdate_Click — pass BorrowerID to NewBorrowerForm
Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
    If dgvBorrowers.SelectedRows.Count = 0 Then
        MessageBox.Show("Please select a borrower to update.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
    End If
    Dim borrowerID As Integer = CInt(dgvBorrowers.SelectedRows(0).Tag)
    Dim frm As New NewBorrowerForm(borrowerID)
    frm.ShowDialog()
    LoadFromDatabase()
End Sub

' REPLACE btnDelete_Click — delete from DB
Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    If dgvBorrowers.SelectedRows.Count = 0 Then
        MessageBox.Show("Please select a borrower to delete.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
    End If
    If MessageBox.Show("Delete this borrower?", "Confirm Delete",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        Try
            Dim borrowerID As Integer = CInt(dgvBorrowers.SelectedRows(0).Tag)
            Dim repo As New BorrowerRepository()
            repo.DeleteBorrower(borrowerID)
            LoadFromDatabase()
        Catch ex As Exception
            MessageBox.Show($"Cannot delete: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End If
End Sub

' ALSO: Set btnDelete.Visible = True in InitializeComponent
```

---

### `NewBorrowerForm.vb`

**Functions to add/replace:**

```vbnet
Private _borrowerID As Integer = 0

Public Sub New(Optional borrowerID As Integer = 0)
    InitializeComponent()
    _borrowerID = borrowerID
End Sub

Private Sub NewBorrowerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    If _borrowerID = 0 Then
        Dim repo As New BorrowerRepository()
        txtBorrowerUID.Text = repo.GetNextBorrowerUID()
        txtBorrowerUID.ReadOnly = True
    Else
        LoadBorrowerData(_borrowerID)
        btnAdd.Text = "Update Borrower"
    End If
End Sub

Private Sub LoadBorrowerData(id As Integer)
    Dim repo As New BorrowerRepository()
    Dim b = repo.GetBorrowerByID(id)
    If b IsNot Nothing Then
        txtBorrowerUID.Text  = b.BorrowerUID
        txtFirstName.Text    = b.FirstName
        txtMiddleName.Text   = b.MiddleName
        txtLastName.Text     = b.LastName
        txtAge.Text          = b.Age.ToString()
        dtpDateOfBirth.Value = b.DateOfBirth
        txtContact.Text      = b.Contact
        txtEmail.Text        = b.Email
    End If
End Sub

' ADD ID upload button handler
Private _idImagePath As String = ""
Private Sub btnUploadID_Click(sender As Object, e As EventArgs) Handles btnUploadID.Click
    Using dlg As New OpenFileDialog()
        dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        dlg.Title  = "Select Valid ID"
        If dlg.ShowDialog() = DialogResult.OK Then
            _idImagePath = dlg.FileName
            btnUploadID.Text = "ID Selected: " & IO.Path.GetFileName(_idImagePath)
        End If
    End Using
End Sub

' REPLACE btnAdd_Click
Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
    Dim errors As New List(Of String)()
    Dim msg As String = ""

    If Not ValidationHelper.IsRequired(txtFirstName.Text, "First Name", msg) Then errors.Add(msg)
    If Not ValidationHelper.IsRequired(txtLastName.Text, "Last Name", msg) Then errors.Add(msg)
    If Not ValidationHelper.IsPositiveInteger(txtAge.Text, "Age", msg) Then errors.Add(msg)
    If Not ValidationHelper.IsRequired(txtContact.Text, "Contact", msg) Then errors.Add(msg) _
    Else If Not ValidationHelper.IsValidPhone(txtContact.Text, msg) Then errors.Add(msg)
    If Not ValidationHelper.IsRequired(txtEmail.Text, "Email", msg) Then errors.Add(msg) _
    Else If Not ValidationHelper.IsValidEmail(txtEmail.Text, msg) Then errors.Add(msg)

    If errors.Count > 0 Then
        ValidationHelper.ShowErrors(errors)
        Return
    End If

    Try
        Dim b As New BorrowerModel() With {
            .BorrowerID  = _borrowerID,
            .BorrowerUID = txtBorrowerUID.Text,
            .FirstName   = txtFirstName.Text.Trim(),
            .MiddleName  = txtMiddleName.Text.Trim(),
            .LastName    = txtLastName.Text.Trim(),
            .Age         = Integer.Parse(txtAge.Text),
            .DateOfBirth = dtpDateOfBirth.Value,
            .Contact     = txtContact.Text.Trim(),
            .Email       = txtEmail.Text.Trim(),
            .IDImagePath = _idImagePath
        }
        Dim repo As New BorrowerRepository()
        Dim success = If(_borrowerID = 0, repo.AddBorrower(b), repo.UpdateBorrower(b))

        If success Then
            MessageBox.Show(If(_borrowerID = 0, "Borrower added.", "Borrower updated."),
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    Catch ex As Exception
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

---

### `PaymentListForm.vb`

**Functions to add/replace:**

```vbnet
' REPLACE LoadSampleData → LoadFromDatabase
Private Sub LoadFromDatabase(Optional keyword As String = "")
    Try
        Dim repo As New PaymentRepository()
        Dim payments = If(String.IsNullOrWhiteSpace(keyword),
                          repo.GetAllPayments(),
                          repo.SearchPayments(keyword))
        dgvPayments.Rows.Clear()
        For Each p In payments
            dgvPayments.Rows.Add(p.LoanReferenceID, p.Payee,
                                 $"PHP {p.Amount:N2}", $"PHP {p.Penalty:N2}", p.Status)
            dgvPayments.Rows(dgvPayments.Rows.Count - 1).Tag = p.PaymentID
        Next
        lblRecordCount.Text = $"Showing {dgvPayments.Rows.Count} records"
    Catch ex As Exception
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub

Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
    LoadFromDatabase(txtSearch.Text.Trim())
End Sub

' REPLACE btnAdd_Click — open NewPaymentForm
Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
    Dim frm As New NewPaymentForm()
    frm.ShowDialog()
    LoadFromDatabase()
End Sub

' REPLACE btnUpdate_Click
Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
    If dgvPayments.SelectedRows.Count = 0 Then
        MessageBox.Show("Please select a payment to update.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
    End If
    Dim paymentID As Integer = CInt(dgvPayments.SelectedRows(0).Tag)
    Dim frm As New NewPaymentForm(paymentID)
    frm.ShowDialog()
    LoadFromDatabase()
End Sub

' REPLACE btnDelete_Click
Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    If dgvPayments.SelectedRows.Count = 0 Then
        MessageBox.Show("Please select a payment to delete.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
    End If
    If MessageBox.Show("Delete this payment?", "Confirm Delete",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        Dim paymentID As Integer = CInt(dgvPayments.SelectedRows(0).Tag)
        Dim repo As New PaymentRepository()
        repo.DeletePayment(paymentID)
        LoadFromDatabase()
    End If
End Sub

' ALSO: Set btnDelete.Visible = True
```

---

### `LoanApplicationForm.vb`

**Functions to add/replace:**

```vbnet
' REPLACE Form_Load
Private Sub LoanApplicationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    cmbLoanType.SelectedIndex = 0
    dtpReleaseDate.Value = DateTime.Today
    dtpDueDate.Value = DateTime.Today.AddMonths(12)

    ' Pre-fill borrower name from session
    Dim repo As New BorrowerRepository()
    Dim borrower = repo.GetBorrowerByID(SessionManager.CurrentBorrowerID)
    If borrower IsNot Nothing Then
        txtBorrowerName.Text = borrower.FullName
        txtBorrowerName.ReadOnly = True
    End If

    ' Auto-gen Application ID
    Dim appRepo As New LoanApplicationRepository()
    txtLoanID.Text = appRepo.GetNextApplicationID()
End Sub

' ADD TotalPayable calculation — wire to txtPrincipalAmount, txtInterestRate, txtTerm TextChanged
Private Sub CalculateTotalPayable()
    Dim principal, rate As Decimal
    Dim term As Integer
    If Decimal.TryParse(txtPrincipalAmount.Text, principal) AndAlso
       Decimal.TryParse(txtInterestRate.Text, rate) AndAlso
       Integer.TryParse(txtTerm.Text, term) AndAlso term > 0 Then
        Dim total = principal + (principal * (rate / 100) * (term / 12))
        txtTotalPayable.Text = Math.Round(total, 2).ToString("N2")
    End If
End Sub

' REPLACE btnSubmit_Click
Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
    Dim errors As New List(Of String)()
    Dim msg As String = ""

    If cmbLoanType.SelectedIndex < 0 Then errors.Add("Please select a Loan Type.")
    If Not ValidationHelper.IsPositiveDecimal(txtPrincipalAmount.Text, "Principal Amount", msg) Then errors.Add(msg)
    If Not ValidationHelper.IsPositiveDecimal(txtInterestRate.Text, "Interest Rate", msg) Then errors.Add(msg)
    If Not ValidationHelper.IsPositiveInteger(txtTerm.Text, "Term", msg) Then errors.Add(msg)
    If Not ValidationHelper.IsDateRangeValid(dtpReleaseDate.Value, dtpDueDate.Value, msg) Then errors.Add(msg)

    If errors.Count > 0 Then
        ValidationHelper.ShowErrors(errors)
        Return
    End If

    Try
        Dim app As New LoanApplicationModel() With {
            .BorrowerID      = SessionManager.CurrentBorrowerID,
            .LoanType        = cmbLoanType.SelectedItem.ToString(),
            .PrincipalAmount = Decimal.Parse(txtPrincipalAmount.Text),
            .InterestRate    = Decimal.Parse(txtInterestRate.Text),
            .TotalPayable    = Decimal.Parse(txtTotalPayable.Text.Replace(",", "")),
            .Term            = Integer.Parse(txtTerm.Text),
            .ReleaseDate     = dtpReleaseDate.Value,
            .DueDate         = dtpDueDate.Value
        }
        Dim repo As New LoanApplicationRepository()
        repo.SubmitApplication(app)

        MessageBox.Show($"Loan application submitted successfully.{Environment.NewLine}" &
                        $"Application ID: {txtLoanID.Text}{Environment.NewLine}Status: Pending Review",
                        "Application Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information)
    Catch ex As Exception
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

---

### `TrackLoanForm.vb`

**Functions to add/replace:**

```vbnet
' REPLACE LoadSampleData → LoadFromDatabase (borrower-filtered)
Private Sub LoadFromDatabase()
    Try
        Dim repo As New LoanApplicationRepository()
        Dim apps = repo.GetApplicationsByBorrower(SessionManager.CurrentBorrowerID)
        ' Populate DataGridView with apps
        ' Store ApplicationID as Tag on each row
        ' Wire the View button column to open ViewLoanApplicationForm
    Catch ex As Exception
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub

' Add CellContentClick handler for the View button column
Private Sub dgvTrackLoans_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvTrackLoans.CellContentClick
    If e.ColumnIndex = dgvTrackLoans.Columns("View").Index AndAlso e.RowIndex >= 0 Then
        Dim appID As Integer = CInt(dgvTrackLoans.Rows(e.RowIndex).Tag)
        Dim frm As New ViewLoanApplicationForm(appID)
        frm.ShowDialog()
    End If
End Sub
```

---

### `ViewLoanApplicationForm.vb`

**Functions to add/replace:**

```vbnet
' ADD ApplicationID parameter — this is how data gets passed from TrackLoanForm
Private _applicationID As Integer

Public Sub New(applicationID As Integer)
    InitializeComponent()
    _applicationID = applicationID
End Sub

Private Sub ViewLoanApplicationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    LoadApplicationData()
End Sub

Private Sub LoadApplicationData()
    Try
        Dim repo As New LoanApplicationRepository()
        ' Add GetApplicationByID to LoanApplicationRepository
        Dim app = repo.GetApplicationByID(_applicationID)
        If app IsNot Nothing Then
            txtLoanID.Text        = app.ApplicationID.ToString()
            txtBorrowerName.Text  = app.BorrowerName
            txtLoanType.Text      = app.LoanType
            txtPrincipalAmount.Text = $"PHP {app.PrincipalAmount:N2}"
            txtInterestRate.Text  = $"{app.InterestRate}%"
            txtTotalPayable.Text  = $"PHP {app.TotalPayable:N2}"
            txtTerm.Text          = $"{app.Term} months"
            dtpReleaseDate.Value  = app.ReleaseDate
            dtpDueDate.Value      = app.DueDate
        End If
    Catch ex As Exception
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

---

### `MyAccountForm.vb`

**Functions to add/replace:**

```vbnet
' ADD Form_Load — pre-fill from session
Private Sub MyAccountForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    txtUsername.Text = SessionManager.CurrentUsername
    txtPassword.Text = ""
    txtConfirmPassword.Text = ""
    ' Pre-select security question if stored in session or loaded from DB
End Sub

' REPLACE btnUpdate_Click
Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
    Dim errors As New List(Of String)()
    Dim msg As String = ""

    If Not ValidationHelper.IsRequired(txtUsername.Text, "Username", msg) Then errors.Add(msg)
    If Not ValidationHelper.IsRequired(txtPassword.Text, "Password", msg) Then errors.Add(msg)
    If Not ValidationHelper.PasswordsMatch(txtPassword.Text, txtConfirmPassword.Text, msg) Then errors.Add(msg)
    If cmbSecurityQuestion.SelectedIndex < 0 Then errors.Add("Please select a security question.")
    If Not ValidationHelper.IsRequired(txtSecurityAnswer.Text, "Security Answer", msg) Then errors.Add(msg)

    If errors.Count > 0 Then
        ValidationHelper.ShowErrors(errors)
        Return
    End If

    Try
        Dim newHash = PasswordHelper.HashPassword(txtPassword.Text)
        Dim repo As New UserRepository()
        repo.UpdateAccountCredentials(
            SessionManager.CurrentUserID,
            txtUsername.Text.Trim(),
            newHash,
            cmbSecurityQuestion.SelectedItem.ToString(),
            txtSecurityAnswer.Text.Trim()
        )
        ' Update session username
        SessionManager.CurrentUsername = txtUsername.Text.Trim()
        MessageBox.Show("Account updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    Catch ex As Exception
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

---

### `BorrowerAccountsForm.vb`

**Functions to add/replace:**

```vbnet
' REPLACE LoadSampleData → LoadFromDatabase
Private Sub LoadFromDatabase()
    Try
        Dim repo As New UserRepository()
        Dim accounts = repo.GetAllBorrowerAccounts()
        dgvAccounts.Rows.Clear()
        For Each acc In accounts
            dgvAccounts.Rows.Add(acc.Username, "••••••••",
                                 If(acc.IsActive, "Active", "Inactive"))
            dgvAccounts.Rows(dgvAccounts.Rows.Count - 1).Tag = acc.UserID
        Next
        lblRecordCount.Text = $"Showing {dgvAccounts.Rows.Count} records"
    Catch ex As Exception
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub

' REPLACE btnDelete_Click — soft-delete (deactivate)
Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    If dgvAccounts.SelectedRows.Count = 0 Then
        MessageBox.Show("Please select an account.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
    End If
    If MessageBox.Show("Deactivate this account?", "Confirm",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        Dim userID As Integer = CInt(dgvAccounts.SelectedRows(0).Tag)
        Dim repo As New UserRepository()
        repo.DeactivateAccount(userID)
        LoadFromDatabase()
    End If
End Sub

' ALSO: Change Password column in DataGridView to always show "••••••••"
' ALSO: Set btnDelete.Visible = True
```

---

## PART 5 — New Files to Create

### `Forms/Admin/NewPaymentForm.vb` (does not exist yet)

This form needs to be created from scratch. Minimum fields:

| Field | Control | Type |
|-------|---------|------|
| Loan Reference ID | `cmbLoanReferenceID` | ComboBox (loaded from tbl_Loans) |
| Payee | `txtPayee` | TextBox |
| Amount | `txtAmount` | TextBox |
| Penalty (auto-calculated) | `txtPenalty` | TextBox (read-only) |
| Payment Date | `dtpPaymentDate` | DateTimePicker |
| Status | `cmbStatus` | ComboBox (Paid / Pending / Late) |

**Buttons:** `btnSave`, `btnCancel`

**Key backend function:**

```vbnet
Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    ' Validate fields
    ' Build PaymentModel from form fields
    ' Call PaymentRepository.AddPayment() or UpdatePayment()
    ' Close form
End Sub
```

---

## PART 6 — Summary: What to Wire Up Per Form

| Form | Remove | Add | Change |
|------|--------|-----|--------|
| `LoginForm` | `btnAdmin`, `btnUser` (bypass) | Real auth in `btnLogin_Click` | — |
| `ForgotPasswordForm` | Stub MessageBox | DB verify + hash save | Add `txtUsername` field |
| `AdminDashboardForm` | — | Session name in welcome label | `Me.Close()` on logout |
| `BorrowerDashboardForm` | Hardcoded name | Session-based name | `Me.Close()` on logout |
| `LoanListForm` | `LoadSampleData` | `LoadFromDatabase`, search, pass ID to Update | `btnDelete.Visible = True` |
| `NewLoanForm` | Hardcoded ID, stub save | DB load names, auto-ID, calc, save | Add `loanID` param |
| `BorrowerListForm` | `LoadSampleData` | `LoadFromDatabase`, search, pass ID to Update | `btnDelete.Visible = True` |
| `NewBorrowerForm` | Stub save | Auto-UID, file dialog, DB save | Add `borrowerID` param |
| `PaymentListForm` | `LoadSampleData`, stub buttons | `LoadFromDatabase`, open `NewPaymentForm` | `btnDelete.Visible = True` |
| `BorrowerAccountsForm` | `LoadSampleData`, stub buttons | DB accounts, mask password | `btnDelete.Visible = True`, soft-delete |
| `LoanApplicationForm` | Hardcoded name/ID, stub submit | Session name, auto-ID, calc, DB insert | — |
| `TrackLoanForm` | `LoadSampleData` | DB filtered by session BorrowerID, pass ID to View | — |
| `ViewLoanApplicationForm` | No data passed | Accept `applicationID` param, load from DB | — |
| `MyAccountForm` | Stub update | Pre-fill from session, validate, hash, DB update | — |

---

*Last Updated: 2026-06-09 | LMS Backend Functions Specification — ASA Philippines Foundation, Inc.*
