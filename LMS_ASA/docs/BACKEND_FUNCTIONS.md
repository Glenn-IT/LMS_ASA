# Backend Functions & Database Setup
# Loan Management System (LMS) — ASA Philippines Foundation, Inc.

> **Technology:** VB.NET WinForms · .NET 8.0 · SQL Server · ADO.NET (`Microsoft.Data.SqlClient`)
> **Last Updated:** 2026-06-11
> **Status:** All phases complete (0–9) — Phase 10 End-to-End Testing next
> **Related Docs:**
> - `SYSTEM_AUDIT_CHECKLIST.md` — issue tracker, progress checklist, form status
> - `DB_Connection_Pattern.md` — dbconstring + config.txt pattern reference
> - `PROJECT_STRUCTURE.md` — folder/file layout

---

## How to Use This Document

1. **Start with Part 0** — run the SQL scripts in SSMS to create all tables in `LMS_DB`.
2. **Part 1** — infrastructure helpers (`SessionManager`, `PasswordHelper`) that everything else depends on.
3. **Parts 2–5** — the VB.NET repository code and form wiring, in implementation order.
4. Cross-check the `SYSTEM_AUDIT_CHECKLIST.md` as you complete each phase.

---

## PART 0 — SQL: Create Tables in SSMS

> Open SSMS → connect to `.\SQLEXPRESS` → select `LMS_DB` → New Query → paste and run.

```sql
-- ============================================================
-- LMS_DB — Full Table Creation Script
-- Run once on a fresh LMS_DB database
-- ============================================================

USE LMS_DB;
GO

-- ── tbl_Users ────────────────────────────────────────────────
CREATE TABLE tbl_Users (
    UserID           INT            NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Username         NVARCHAR(50)   NOT NULL UNIQUE,
    PasswordHash     NVARCHAR(255)  NOT NULL,
    Role             NVARCHAR(20)   NOT NULL,          -- 'Admin' or 'Borrower'
    SecurityQuestion NVARCHAR(255)  NOT NULL,
    SecurityAnswer   NVARCHAR(255)  NOT NULL,
    IsActive         BIT            NOT NULL DEFAULT 1,
    CreatedAt        DATETIME       NOT NULL DEFAULT GETDATE()
);
GO

-- ── tbl_Borrowers ────────────────────────────────────────────
CREATE TABLE tbl_Borrowers (
    BorrowerID   INT            NOT NULL IDENTITY(1,1) PRIMARY KEY,
    BorrowerUID  NVARCHAR(20)   NOT NULL UNIQUE,        -- e.g. BRW-0001
    FirstName    NVARCHAR(50)   NOT NULL,
    MiddleName   NVARCHAR(50)   NULL,
    LastName     NVARCHAR(50)   NOT NULL,
    Age          INT            NOT NULL,
    DateOfBirth  DATE           NOT NULL,
    Contact      NVARCHAR(20)   NOT NULL,
    Email        NVARCHAR(100)  NOT NULL UNIQUE,
    IDImagePath  NVARCHAR(255)  NULL,
    UserID       INT            NOT NULL,
    CreatedAt    DATETIME       NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Borrowers_Users FOREIGN KEY (UserID) REFERENCES tbl_Users(UserID)
);
GO

-- ── tbl_Loans ────────────────────────────────────────────────
CREATE TABLE tbl_Loans (
    LoanID          INT            NOT NULL IDENTITY(1,1) PRIMARY KEY,
    LoanReferenceID NVARCHAR(20)   NOT NULL UNIQUE,     -- e.g. LN-0001
    BorrowerID      INT            NOT NULL,
    LoanType        NVARCHAR(50)   NOT NULL,
    PrincipalAmount DECIMAL(18,2)  NOT NULL,
    InterestRate    DECIMAL(5,2)   NOT NULL,
    TotalPayable    DECIMAL(18,2)  NOT NULL,
    Term            INT            NOT NULL,             -- months
    ReleaseDate     DATE           NOT NULL,
    DueDate         DATE           NOT NULL,
    Status          NVARCHAR(20)   NOT NULL DEFAULT 'Pending',  -- Pending/Active/Closed/Overdue
    CreatedAt       DATETIME       NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Loans_Borrowers FOREIGN KEY (BorrowerID) REFERENCES tbl_Borrowers(BorrowerID)
);
GO

-- ── tbl_Payments ─────────────────────────────────────────────
CREATE TABLE tbl_Payments (
    PaymentID   INT            NOT NULL IDENTITY(1,1) PRIMARY KEY,
    LoanID      INT            NOT NULL,
    Payee       NVARCHAR(100)  NOT NULL,
    Amount      DECIMAL(18,2)  NOT NULL,
    Penalty     DECIMAL(18,2)  NOT NULL DEFAULT 0,
    PaymentDate DATE           NOT NULL,
    Status      NVARCHAR(20)   NOT NULL DEFAULT 'Paid',   -- Paid/Pending/Late
    CreatedAt   DATETIME       NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Payments_Loans FOREIGN KEY (LoanID) REFERENCES tbl_Loans(LoanID)
);
GO

-- ── tbl_LoanApplications ─────────────────────────────────────
CREATE TABLE tbl_LoanApplications (
    ApplicationID   INT            NOT NULL IDENTITY(1,1) PRIMARY KEY,
    BorrowerID      INT            NOT NULL,
    LoanType        NVARCHAR(50)   NOT NULL,
    PrincipalAmount DECIMAL(18,2)  NOT NULL,
    InterestRate    DECIMAL(5,2)   NOT NULL,
    TotalPayable    DECIMAL(18,2)  NOT NULL,
    Term            INT            NOT NULL,
    ReleaseDate     DATE           NOT NULL,
    DueDate         DATE           NOT NULL,
    Status          NVARCHAR(20)   NOT NULL DEFAULT 'Pending',  -- Pending/Approved/Rejected
    SubmittedAt     DATETIME       NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Applications_Borrowers FOREIGN KEY (BorrowerID) REFERENCES tbl_Borrowers(BorrowerID)
);
GO

-- ── tbl_ActivityLogs ─────────────────────────────────────────
CREATE TABLE tbl_ActivityLogs (
    LogID       INT            NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Username    NVARCHAR(50)   NOT NULL,
    LogDate     DATETIME       NOT NULL DEFAULT GETDATE(),
    Result      NVARCHAR(20)   NOT NULL,    -- 'Success' or 'Failed'
    Description NVARCHAR(500)  NOT NULL
);
GO

-- ── Indexes ──────────────────────────────────────────────────
CREATE INDEX IX_Borrowers_BorrowerUID  ON tbl_Borrowers(BorrowerUID);
CREATE INDEX IX_Loans_LoanReferenceID  ON tbl_Loans(LoanReferenceID);
CREATE INDEX IX_Users_Username         ON tbl_Users(Username);
GO

-- ── Seed: default admin account ──────────────────────────────
-- Password is 'Admin@123' hashed with BCrypt (replace hash after PasswordHelper is implemented)
-- For now insert a placeholder — update via app after BCrypt is working
INSERT INTO tbl_Users (Username, PasswordHash, Role, SecurityQuestion, SecurityAnswer)
VALUES (
    'admin',
    '$2a$11$PLACEHOLDER_REPLACE_WITH_REAL_BCRYPT_HASH',
    'Admin',
    'What is the system name?',
    'LMS'
);
GO
```

> **After running:** Right-click `LMS_DB` in SSMS → Refresh → expand Tables. You should see all 6 tables.

---

## PART 1 — Infrastructure Helpers

Create these first. All other code depends on them.

---

### `Helpers/SessionManager.vb`

> Status: **Not yet created** — create this file now.

```vb
Public Module SessionManager

    Public CurrentUserID     As Integer = 0
    Public CurrentUsername   As String  = ""
    Public CurrentRole       As String  = ""       ' "Admin" or "Borrower"
    Public CurrentBorrowerID As Integer = 0        ' 0 when user is Admin

    Public Sub SetSession(userID As Integer, username As String, role As String,
                          Optional borrowerID As Integer = 0)
        CurrentUserID     = userID
        CurrentUsername   = username
        CurrentRole       = role
        CurrentBorrowerID = borrowerID
    End Sub

    Public Sub ClearSession()
        CurrentUserID     = 0
        CurrentUsername   = ""
        CurrentRole       = ""
        CurrentBorrowerID = 0
    End Sub

    Public Function IsAdmin() As Boolean
        Return CurrentRole = "Admin"
    End Function

End Module
```

---

### `Helpers/PasswordHelper.vb`

> Status: **Not yet created** — requires `BCrypt.Net-Next` NuGet package.
> Install: `Install-Package BCrypt.Net-Next` in Package Manager Console.

```vb
Imports BCrypt.Net

Public Module PasswordHelper

    Public Function HashPassword(plainText As String) As String
        Return BCrypt.HashPassword(plainText, workFactor:=11)
    End Function

    Public Function VerifyPassword(plainText As String, hash As String) As Boolean
        Return BCrypt.Verify(plainText, hash)
    End Function

End Module
```

---

## PART 2 — DB Connection Layer

> Status: **Done** — implemented via `DB_Connection_Pattern.md`.

| File | Status |
|------|--------|
| `dbconstring.vb` | ✅ Created |
| `Data/DatabaseHelper.vb` | ✅ Updated (delegates to `dbconstring`) |
| `bin\Debug\net8.0-windows\config.txt` | ✅ Created (`.\SQLEXPRESS`, `LMS_DB`) |
| `config.txt.example` | ✅ Committed to git |
| `config.txt` in `.gitignore` | ✅ Added |

**Connection string in use:**
```
Data Source=.\SQLEXPRESS;Initial Catalog=LMS_DB;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;
```

---

## PART 3 — DataAccess Repositories

> Status: **Files created** — column names match the schema above.
> All repositories are in `DataAccess/` and use `dbconstring.Connection` directly.

| File | Tables | Key Functions |
|------|--------|---------------|
| `DataAccess/UserRepository.vb` | `tbl_Users` | `GetAll`, `GetByUsername`, `GetByID`, `Insert`, `UpdatePassword`, `Deactivate` |
| `DataAccess/BorrowerRepository.vb` | `tbl_Borrowers` | `GetAll`, `GetByID`, `GetByUserID`, `GetNextUID`, `Insert`, `Update`, `Delete` |
| `DataAccess/LoanRepository.vb` | `tbl_Loans` | `GetAll`, `GetByBorrowerID`, `GetByID`, `GetNextReferenceID`, `Insert`, `UpdateStatus`, `Delete` |
| `DataAccess/PaymentRepository.vb` | `tbl_Payments` | `GetAll`, `GetByLoanID`, `GetByID`, `Insert`, `Delete` |
| `DataAccess/LoanApplicationRepository.vb` | `tbl_LoanApplications` | `GetAll`, `GetByBorrowerID`, `GetByID`, `Insert`, `UpdateStatus`, `Delete` |
| `DataAccess/ActivityLogRepository.vb` | `tbl_ActivityLogs` | `Insert` |
| `ActivityLogger.vb` | — | `Log(username, result, description)` — swallows its own exceptions |

---

## PART 4 — Authentication (Phase 3)

> Status: **Not started** — implement after tables are created and BCrypt is installed.

### `Form1.vb` (LoginForm) — wire up real login

```vb
Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
    Dim username As String = txtUsername.Text.Trim()
    Dim password As String = txtPassword.Text

    If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
        MessageBox.Show("Please enter your username and password.",
                        "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If

    Try
        Dim dt As DataTable = UserRepository.GetByUsername(username)

        If dt.Rows.Count = 0 Then
            MessageBox.Show("Invalid username or password.",
                            "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ActivityLogger.Log(username, "Failed", "Login failed — username not found.")
            Return
        End If

        Dim row As DataRow = dt.Rows(0)
        Dim storedHash As String = row("PasswordHash").ToString()

        If Not PasswordHelper.VerifyPassword(password, storedHash) Then
            MessageBox.Show("Invalid username or password.",
                            "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ActivityLogger.Log(username, "Failed", "Login failed — wrong password.")
            Return
        End If

        Dim userID   As Integer = CInt(row("UserID"))
        Dim role     As String  = row("Role").ToString()
        Dim borrowerID As Integer = 0

        If role = "Borrower" Then
            Dim bRow As DataTable = BorrowerRepository.GetByUserID(userID)
            If bRow.Rows.Count > 0 Then borrowerID = CInt(bRow.Rows(0)("BorrowerID"))
        End If

        SessionManager.SetSession(userID, username, role, borrowerID)
        ActivityLogger.Log(username, "Success", "User logged in.")

        If role = "Admin" Then
            Dim dashboard As New AdminDashboardForm()
            dashboard.Show()
            Me.Hide()
        Else
            Dim dashboard As New BorrowerDashboardForm()
            dashboard.Show()
            Me.Hide()
        End If

    Catch ex As Exception
        MessageBox.Show("A database error occurred: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

**Also do:**
- Remove `btnAdmin` and `btnUser` bypass buttons from `Form1.vb` and their Designer.
- Update `lnkForgotPassword_LinkClicked` — already wired, but `ForgotPasswordForm` needs DB logic.

### `ForgotPasswordForm.vb` — real password reset

```vb
' Step 1 — verify username exists and security question matches
' Step 2 — hash new password and call UserRepository.UpdatePassword
Private Sub btnReset_Click(...)
    Dim username As String = txtUsername.Text.Trim()
    Dim answer   As String = txtSecurityAnswer.Text.Trim()
    Dim newPw    As String = txtNewPassword.Text
    Dim confirm  As String = txtConfirmPassword.Text

    If newPw <> confirm Then
        MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If

    Try
        Dim dt As DataTable = UserRepository.GetByUsername(username)
        If dt.Rows.Count = 0 Then
            MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataRow = dt.Rows(0)
        If row("SecurityAnswer").ToString().ToLower() <> answer.ToLower() Then
            MessageBox.Show("Security answer is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim newHash As String = PasswordHelper.HashPassword(newPw)
        UserRepository.UpdatePassword(CInt(row("UserID")), newHash)

        MessageBox.Show("Password reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ActivityLogger.Log(username, "Success", "Password reset via security question.")
    Catch ex As Exception
        MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

### Logout (all dashboards)

```vb
Private Sub btnLogout_Click(sender As Object, e As EventArgs)
    ActivityLogger.Log(SessionManager.CurrentUsername, "Success", "User logged out.")
    SessionManager.ClearSession()
    Dim login As New Form1()
    login.Show()
    Me.Close()   ' Close (dispose) — not Hide
End Sub
```

### `AdminDashboardForm` — show real username

```vb
Private Sub AdminDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    lblWelcome.Text = $"Welcome, {SessionManager.CurrentUsername}!"
End Sub
```

---

## PART 5 — CRUD Module Wiring

### Phase 4 — Borrower Module

**`BorrowerListForm.vb` — load from DB:**
```vb
Private Sub LoadBorrowers()
    Try
        dgvBorrowers.DataSource = BorrowerRepository.GetAll()
    Catch ex As Exception
        MessageBox.Show("Error loading borrowers: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

**`NewBorrowerForm.vb` — auto-generate BorrowerUID on load:**
```vb
Private Sub NewBorrowerForm_Load(...)
    txtBorrowerUID.Text = BorrowerRepository.GetNextUID()
    txtBorrowerUID.ReadOnly = True
End Sub
```

**`NewBorrowerForm.vb` — Save button:**
```vb
' 1. Validate required fields
' 2. Create the tbl_Users row first (if creating a brand-new borrower account)
' 3. Call BorrowerRepository.Insert with the new UserID
' 4. ActivityLogger.Log
```

---

### Phase 5 — Loan Module

**`LoanListForm.vb` — load from DB:**
```vb
Private Sub LoadLoans()
    Try
        dgvLoans.DataSource = LoanRepository.GetAll()
    Catch ex As Exception
        MessageBox.Show("Error loading loans: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

**`NewLoanForm.vb` — auto-generate LoanReferenceID:**
```vb
Private Sub NewLoanForm_Load(...)
    txtLoanID.Text = LoanRepository.GetNextReferenceID()
    txtLoanID.ReadOnly = True
End Sub
```

**TotalPayable formula:**
```vb
' Simple interest: Total = Principal + (Principal × Rate/100 × Term/12)
Private Sub CalculateTotalPayable()
    Dim principal As Decimal
    Dim rate      As Decimal
    Dim term      As Integer
    If Decimal.TryParse(txtPrincipalAmount.Text, principal) AndAlso
       Decimal.TryParse(txtInterestRate.Text, rate) AndAlso
       Integer.TryParse(txtTerm.Text, term) Then
        Dim interest As Decimal = principal * (rate / 100) * (term / 12)
        txtTotalPayable.Text = (principal + interest).ToString("N2")
    End If
End Sub
```

---

### Phase 6 — Payment Module

**`PaymentListForm.vb` — load from DB:**
```vb
Private Sub LoadPayments()
    Try
        dgvPayments.DataSource = PaymentRepository.GetAll()
    Catch ex As Exception
        MessageBox.Show("Error loading payments: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

> A `NewPaymentForm.vb` still needs to be created. Wire `btnAdd` to open it.

---

### Phase 7 — Borrower Account Module

**`BorrowerAccountsForm.vb`:**
```vb
Private Sub LoadAccounts()
    ' Load only Role = 'Borrower' users
    Dim dt As DataTable = UserRepository.GetAll()
    ' Filter in memory or add a GetByRole() overload to UserRepository
    Dim borrowers = dt.Select("Role = 'Borrower'")
    ' Bind to grid — mask the PasswordHash column
End Sub
```

**`MyAccountForm.vb` — pre-fill from session:**
```vb
Private Sub MyAccountForm_Load(...)
    txtUsername.Text = SessionManager.CurrentUsername
    txtUsername.ReadOnly = True
End Sub
```

---

### Phase 8 — Loan Application Module (Borrower Side)

**`LoanApplicationForm.vb` — insert application:**
```vb
Private Sub btnSubmit_Click(...)
    Try
        LoanApplicationRepository.Insert(
            borrowerID    := SessionManager.CurrentBorrowerID,
            loanType      := cmbLoanType.Text,
            principalAmount := CDec(txtPrincipalAmount.Text),
            interestRate  := CDec(txtInterestRate.Text),
            totalPayable  := CDec(txtTotalPayable.Text),
            term          := CInt(txtTerm.Text),
            releaseDate   := dtpReleaseDate.Value,
            dueDate       := dtpDueDate.Value)

        ActivityLogger.Log(SessionManager.CurrentUsername, "Success", "Loan application submitted.")
        MessageBox.Show("Application submitted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    Catch ex As Exception
        MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub
```

**`TrackLoanForm.vb` — load only this borrower's applications:**
```vb
Private Sub LoadApplications()
    dgvApplications.DataSource =
        LoanApplicationRepository.GetByBorrowerID(SessionManager.CurrentBorrowerID)
End Sub
```

**`ViewLoanApplicationForm.vb` — pass ApplicationID from TrackLoanForm:**
```vb
' In TrackLoanForm, before opening ViewLoanApplicationForm:
Dim appID As Integer = CInt(dgvApplications.CurrentRow.Cells("ApplicationID").Value)
Dim view As New ViewLoanApplicationForm(appID)
view.Show()

' In ViewLoanApplicationForm, add a constructor:
Public Sub New(applicationID As Integer)
    InitializeComponent()
    Dim dt As DataTable = LoanApplicationRepository.GetByID(applicationID)
    If dt.Rows.Count > 0 Then
        Dim row As DataRow = dt.Rows(0)
        txtLoanType.Text       = row("LoanType").ToString()
        txtPrincipalAmount.Text = row("PrincipalAmount").ToString()
        ' ... populate all fields
    End If
End Sub
```

---

## PART 6 — Remaining Tasks Checklist

### Infrastructure ✅ Complete
- [x] `dbconstring.vb` — connection string reader
- [x] `Data/DatabaseHelper.vb` — thin wrapper
- [x] `config.txt` beside exe, `config.txt.example` committed
- [x] `config.txt` in `.gitignore`
- [x] `Helpers/SessionManager.vb`
- [x] `Helpers/PasswordHelper.vb` — BCrypt.Net-Next v4.2.0

### Database (SSMS) ✅ Complete
- [x] `LMS_DB` database created
- [x] `tbl_Users` created
- [x] `tbl_Borrowers` created
- [x] `tbl_Loans` created
- [x] `tbl_Payments` created
- [x] `tbl_LoanApplications` created
- [x] `tbl_ActivityLogs` created
- [x] Seed admin account — Username: `admin` / Password: `Admin@123`

### DataAccess Repositories ✅ Complete
- [x] `DataAccess/UserRepository.vb`
- [x] `DataAccess/BorrowerRepository.vb`
- [x] `DataAccess/LoanRepository.vb`
- [x] `DataAccess/PaymentRepository.vb`
- [x] `DataAccess/LoanApplicationRepository.vb`
- [x] `DataAccess/ActivityLogRepository.vb`
- [x] `ActivityLogger.vb`

### Authentication (Form Wiring) ✅ Complete
- [x] `Form1.vb` — real login with DB check + BCrypt verify + role redirect
- [x] `Form1.vb` — `btnAdmin` / `btnUser` bypass buttons removed
- [x] `ForgotPasswordForm.vb` — username field + security Q&A + BCrypt reset
- [x] All dashboards — logout clears session, `Me.Close()`
- [x] `AdminDashboardForm` — shows `SessionManager.CurrentUsername`
- [x] `BorrowerDashboardForm` — shows `SessionManager.CurrentUsername`

### CRUD Wiring — Phase 4: Borrower Module ✅ Complete
- [x] `BorrowerListForm` — load from `BorrowerRepository.GetAll()`; search, update, delete
- [x] `NewBorrowerForm` — save to DB, auto-UID, ID image upload

### CRUD Wiring — Phase 5: Loan Module ✅ Complete
- [x] `LoanListForm` — load, show `btnDelete`, wire update
- [x] `NewLoanForm` — save, auto-RefID, TotalPayable formula

### CRUD Wiring — Phase 6: Payment Module ✅ Complete
- [x] `NewPaymentForm.vb` — created with Add/Edit mode
- [x] `PaymentListForm` — load, show `btnDelete`, wire Add/Update

### CRUD Wiring — Phase 7: Borrower Accounts ✅ Complete
- [x] `BorrowerAccountsForm` — load borrower users, no password column, deactivate
- [x] `MyAccountForm` — pre-fill from session, BCrypt hash on save
- [x] `EditAccountForm` — admin resets username/password for borrower account

### CRUD Wiring — Phase 8: Loan Applications ✅ Complete
- [x] `LoanApplicationForm` — insert to DB using `SessionManager.CurrentBorrowerID`
- [x] `TrackLoanForm` — filter by `SessionManager.CurrentBorrowerID`
- [x] `ViewLoanApplicationForm` — accepts `ApplicationID` via constructor, loads from DB JOIN

---

*Last Updated: 2026-06-11 (All phases 0–9 complete) | LMS Backend Functions — ASA Philippines Foundation, Inc.*
