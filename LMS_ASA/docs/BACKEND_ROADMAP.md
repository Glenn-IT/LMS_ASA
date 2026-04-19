# 🗺️ Backend & Database Implementation Roadmap
# Loan Management System (LMS)

> **Technology:** VB.NET WinForms · .NET 8.0 · SQL Server (SSMS) · ADO.NET or Entity Framework Core
> **Current State:** UI Prototype (Frontend Only)
> **Goal:** Implement a fully functional backend with database integration

---

## 📌 Overview

This roadmap outlines all the steps required to transition the LMS from a
**UI-only prototype** into a **fully functional system** with a real database,
authentication, business logic, and data persistence.

---

## 🏗️ Phase 1 – Database Design & Setup

> Goal: Design and create the SQL Server database schema

### ✅ Checklist

- [ ] Install and configure **SQL Server** (or SQL Server Express)
- [ ] Create the database: `LMS_DB`
- [ ] Design and create the following tables:

#### 📋 Tables

- [ ] **`tbl_Users`** – Admin and Borrower accounts

  | Column           | Type          | Constraint         |
  |------------------|---------------|--------------------|
  | UserID           | INT           | PK, IDENTITY       |
  | Username         | NVARCHAR(50)  | NOT NULL, UNIQUE   |
  | PasswordHash     | NVARCHAR(255) | NOT NULL           |
  | Role             | NVARCHAR(20)  | Admin / Borrower   |
  | SecurityQuestion | NVARCHAR(255) | NOT NULL           |
  | SecurityAnswer   | NVARCHAR(255) | NOT NULL           |
  | IsActive         | BIT           | DEFAULT 1          |
  | CreatedAt        | DATETIME      | DEFAULT GETDATE()  |

- [ ] **`tbl_Borrowers`** – Borrower personal information

  | Column          | Type          | Constraint        |
  |-----------------|---------------|-------------------|
  | BorrowerID      | INT           | PK, IDENTITY      |
  | BorrowerUID     | NVARCHAR(20)  | NOT NULL, UNIQUE  |
  | FirstName       | NVARCHAR(50)  | NOT NULL          |
  | MiddleName      | NVARCHAR(50)  | NULLABLE          |
  | LastName        | NVARCHAR(50)  | NOT NULL          |
  | Age             | INT           | NOT NULL          |
  | DateOfBirth     | DATE          | NOT NULL          |
  | Contact         | NVARCHAR(20)  | NOT NULL          |
  | Email           | NVARCHAR(100) | NOT NULL, UNIQUE  |
  | IDImagePath     | NVARCHAR(255) | NULLABLE          |
  | UserID          | INT           | FK → tbl_Users    |
  | CreatedAt       | DATETIME      | DEFAULT GETDATE() |

- [ ] **`tbl_Loans`** – Loan records

  | Column          | Type           | Constraint           |
  |-----------------|----------------|----------------------|
  | LoanID          | INT            | PK, IDENTITY         |
  | LoanReferenceID | NVARCHAR(20)   | NOT NULL, UNIQUE     |
  | BorrowerID      | INT            | FK → tbl_Borrowers   |
  | LoanType        | NVARCHAR(50)   | NOT NULL             |
  | PrincipalAmount | DECIMAL(18,2)  | NOT NULL             |
  | InterestRate    | DECIMAL(5,2)   | NOT NULL             |
  | TotalPayable    | DECIMAL(18,2)  | NOT NULL             |
  | Term            | INT            | Months               |
  | ReleaseDate     | DATE           | NOT NULL             |
  | DueDate         | DATE           | NOT NULL             |
  | Status          | NVARCHAR(20)   | Pending/Approved/etc |
  | CreatedAt       | DATETIME       | DEFAULT GETDATE()    |

- [ ] **`tbl_Payments`** – Payment records

  | Column          | Type          | Constraint        |
  |-----------------|---------------|-------------------|
  | PaymentID       | INT           | PK, IDENTITY      |
  | LoanID          | INT           | FK → tbl_Loans    |
  | Payee           | NVARCHAR(100) | NOT NULL          |
  | Amount          | DECIMAL(18,2) | NOT NULL          |
  | Penalty         | DECIMAL(18,2) | DEFAULT 0         |
  | PaymentDate     | DATE          | NOT NULL          |
  | Status          | NVARCHAR(20)  | Paid/Pending/Late |
  | CreatedAt       | DATETIME      | DEFAULT GETDATE() |

- [ ] **`tbl_LoanApplications`** – Borrower-submitted loan applications

  | Column          | Type          | Constraint           |
  |-----------------|---------------|----------------------|
  | ApplicationID   | INT           | PK, IDENTITY         |
  | BorrowerID      | INT           | FK → tbl_Borrowers   |
  | LoanType        | NVARCHAR(50)  | NOT NULL             |
  | PrincipalAmount | DECIMAL(18,2) | NOT NULL             |
  | InterestRate    | DECIMAL(5,2)  | NOT NULL             |
  | TotalPayable    | DECIMAL(18,2) | NOT NULL             |
  | Term            | INT           | NOT NULL             |
  | ReleaseDate     | DATE          | NOT NULL             |
  | DueDate         | DATE          | NOT NULL             |
  | Status          | NVARCHAR(20)  | Pending/Approved/etc |
  | SubmittedAt     | DATETIME      | DEFAULT GETDATE()    |

- [ ] Add **Foreign Key constraints** between all related tables
- [ ] Add **indexes** on frequently queried columns (e.g., `BorrowerUID`, `LoanReferenceID`)
- [ ] Insert **seed/default admin account** for initial login

---

## 🔌 Phase 2 – Database Connection Layer

> Goal: Set up the data access layer (DAL) to connect VB.NET to SQL Server

### ✅ Checklist

- [ ] Add a **`DatabaseHelper.vb`** class (connection factory)
  - [ ] Store connection string in `App.config` or `appsettings.json`
  - [ ] Create a `GetConnection()` function returning `SqlConnection`
- [ ] Choose a data access strategy:
  - [ ] **Option A:** ADO.NET (manual SQL queries — lightweight)
  - [ ] **Option B:** Entity Framework Core (ORM — recommended for scalability)
- [ ] Create a **`/Data`** folder in the project for all DAL classes
- [ ] Test the database connection successfully on app startup

---

## 🔐 Phase 3 – Authentication

> Goal: Implement real login, logout, and password reset

### ✅ Checklist

- [ ] **Login (`Form1.vb`)**
  - [ ] Query `tbl_Users` by username
  - [ ] Compare hashed password using **BCrypt** or `SHA256`
  - [ ] Distinguish role: `Admin` vs `Borrower`
  - [ ] Redirect to `AdminDashboardForm` or `BorrowerDashboardForm` based on role
  - [ ] Show error message on invalid credentials
  - [ ] Prevent empty field submission

- [ ] **Forgot Password (`ForgotPasswordForm.vb`)**
  - [ ] Verify security question answer against `tbl_Users`
  - [ ] Hash and update new password in the database
  - [ ] Show success/failure `MessageBox`

- [ ] **Session / Current User**
  - [ ] Create a **`SessionManager.vb`** module to hold the logged-in user's info
  - [ ] Store `UserID`, `Username`, `Role` globally during a session
  - [ ] Clear session on logout

- [ ] **Logout (all dashboard forms)**
  - [ ] Clear the session
  - [ ] Return to `LoginForm`

---

## 👤 Phase 4 – Borrower Module (CRUD)

> Goal: Connect borrower forms to the database

### ✅ Checklist

- [ ] **Borrower List (`BorrowerListForm.vb`)**
  - [ ] Load borrowers from `tbl_Borrowers` into `DataGridView`
  - [ ] Implement search/filter by name or UID
  - [ ] Wire up `btnUpdate` → populate `NewBorrowerForm` with selected row data
  - [ ] Wire up `btnDelete` → confirm and delete from `tbl_Borrowers`

- [ ] **New Borrower Form (`NewBorrowerForm.vb`)**
  - [ ] Auto-generate `BorrowerUID` (e.g., `BRW-0001`)
  - [ ] Validate all required fields
  - [ ] Save new borrower to `tbl_Borrowers`
  - [ ] Handle ID image upload (store file path in `IDImagePath`)
  - [ ] Show success/error feedback

---

## 💰 Phase 5 – Loan Module (CRUD)

> Goal: Connect loan forms to the database

### ✅ Checklist

- [ ] **Loan List (`LoanListForm.vb`)**
  - [ ] Load loans from `tbl_Loans` with `JOIN tbl_Borrowers` into `DataGridView`
  - [ ] Implement search/filter by loan ID or borrower name
  - [ ] Wire up `btnUpdate` → populate `NewLoanForm` with selected row data
  - [ ] Wire up `btnDelete` → confirm and delete from `tbl_Loans`

- [ ] **New Loan Form (`NewLoanForm.vb`)**
  - [ ] Auto-generate `LoanReferenceID` (e.g., `LN-0001`)
  - [ ] Populate `cmbBorrowerName` from `tbl_Borrowers`
  - [ ] Validate all required fields
  - [ ] Auto-calculate `TotalPayable` from principal + interest + term
  - [ ] Save new loan to `tbl_Loans`
  - [ ] Show success/error feedback

---

## 💳 Phase 6 – Payment Module (CRUD)

> Goal: Connect payment forms to the database

### ✅ Checklist

- [ ] **Payment List (`PaymentListForm.vb`)**
  - [ ] Load payments from `tbl_Payments` with `JOIN tbl_Loans` into `DataGridView`
  - [ ] Wire up `btnUpdate` → open payment update dialog
  - [ ] Wire up `btnDelete` → confirm and delete from `tbl_Payments`

- [ ] **New Payment Entry**
  - [ ] Validate payment amount against loan balance
  - [ ] Calculate and apply penalty for late payments
  - [ ] Save payment record to `tbl_Payments`
  - [ ] Update corresponding loan status in `tbl_Loans`

---

## 🏦 Phase 7 – Borrower Account Module

> Goal: Connect borrower account management to the database

### ✅ Checklist

- [ ] **Borrower Accounts (`BorrowerAccountsForm.vb`)**
  - [ ] Load accounts from `tbl_Users` WHERE `Role = 'Borrower'` into `DataGridView`
  - [ ] Wire up `btnAdd` → create new user account linked to a borrower
  - [ ] Wire up `btnUpdate` → update credentials
  - [ ] Wire up `btnDelete` → deactivate account (`IsActive = 0`)
  - [ ] Never display plain-text passwords — mask in `DataGridView`

- [ ] **My Account (`MyAccountForm.vb`)**
  - [ ] Pre-fill fields with current logged-in user data from session
  - [ ] Validate new password and confirm password match
  - [ ] Validate security question and answer
  - [ ] Hash password before saving
  - [ ] Update `tbl_Users` on confirm

---

## 📋 Phase 8 – Loan Application Module (Borrower Side)

> Goal: Allow borrowers to submit, track, and view loan applications

### ✅ Checklist

- [ ] **Loan Application Form (`LoanApplicationForm.vb`)**
  - [ ] Pre-fill `txtBorrowerName` from the current session
  - [ ] Validate all required fields
  - [ ] Auto-calculate `TotalPayable`
  - [ ] Insert new record into `tbl_LoanApplications` with `Status = 'Pending'`
  - [ ] Show confirmation `MessageBox` on success

- [ ] **Track Loan Form (`TrackLoanForm.vb`)**
  - [ ] Load loan applications from `tbl_LoanApplications` filtered by logged-in borrower
  - [ ] Show `LoanReferenceID`, `Amount`, `NextPaymentSchedule`, `Status`
  - [ ] Wire up `View` button → open `ViewLoanApplicationForm` with selected row data

- [ ] **View Loan Application Form (`ViewLoanApplicationForm.vb`)**
  - [ ] Receive loan application ID/data from `TrackLoanForm`
  - [ ] Load full application details from `tbl_LoanApplications`
  - [ ] Display all fields as read-only
  - [ ] Wire up `btnBack` → return to `TrackLoanForm`

- [ ] **Admin: Approve / Reject Applications**
  - [ ] Add Approve/Reject buttons on admin's loan list view
  - [ ] Update `Status` in `tbl_LoanApplications`
  - [ ] Optionally auto-create a record in `tbl_Loans` on approval

---

## 🛡️ Phase 9 – Validation & Error Handling

> Goal: Make the system robust and user-friendly

### ✅ Checklist

- [ ] Add **input validation** on all forms (required fields, data types, length)
- [ ] Add **try-catch blocks** around all database operations
- [ ] Show user-friendly **error messages** via `MessageBox`
- [ ] Log errors to a **text file or event log** for debugging
- [ ] Prevent **SQL Injection** by using parameterized queries throughout
- [ ] Validate **date ranges** (e.g., DueDate must be after ReleaseDate)
- [ ] Validate **numeric fields** (no negative amounts, valid interest rates)

---

## 🧪 Phase 10 – Testing

> Goal: Verify all features work correctly end-to-end

### ✅ Checklist

- [ ] Test **login** with valid admin credentials
- [ ] Test **login** with valid borrower credentials
- [ ] Test **login** with invalid credentials (should show error)
- [ ] Test **forgot password** flow end-to-end
- [ ] Test **Add / Update / Delete** for all CRUD modules:
  - [ ] Borrowers
  - [ ] Loans
  - [ ] Payments
  - [ ] Borrower Accounts
- [ ] Test **loan application submission** from borrower side
- [ ] Test **loan tracking** shows only the logged-in borrower's applications
- [ ] Test **My Account** update (password change, security question)
- [ ] Test **logout** clears session and redirects properly
- [ ] Test all **navigation flows** match the diagram in `DEVELOPMENT_GUIDE.md`

---

## 📁 Recommended Backend Project Structure

```
LMS_ASA/
├── App.config                        ← Connection string config
│
├── Data/                             ← Data Access Layer (DAL)
│   ├── DatabaseHelper.vb             ← Connection factory
│   ├── UserRepository.vb             ← CRUD for tbl_Users
│   ├── BorrowerRepository.vb         ← CRUD for tbl_Borrowers
│   ├── LoanRepository.vb             ← CRUD for tbl_Loans
│   ├── PaymentRepository.vb          ← CRUD for tbl_Payments
│   └── LoanApplicationRepository.vb  ← CRUD for tbl_LoanApplications
│
├── Models/                           ← Data model classes
│   ├── UserModel.vb
│   ├── BorrowerModel.vb
│   ├── LoanModel.vb
│   ├── PaymentModel.vb
│   └── LoanApplicationModel.vb
│
├── Helpers/                          ← Utility/helper classes
│   ├── SessionManager.vb             ← Stores logged-in user info
│   ├── PasswordHelper.vb             ← Hashing utilities
│   └── ValidationHelper.vb          ← Common input validation
│
└── Forms/                            ← All existing WinForms (unchanged)
    ├── Auth/
    ├── Admin/
    └── Borrower/
```

---

## 🧰 Recommended NuGet Packages

| Package | Purpose |
|---------|---------|
| `Microsoft.Data.SqlClient` | SQL Server ADO.NET driver |
| `BCrypt.Net-Next` | Secure password hashing |
| `Dapper` *(optional)* | Lightweight ORM over ADO.NET |
| `Microsoft.EntityFrameworkCore.SqlServer` *(optional)* | Full ORM alternative |

---

## 📊 Implementation Progress Tracker

| Phase | Description                        | Status      |
|-------|------------------------------------|-------------|
| 1     | Database Design & Setup            | ⬜ Not Started |
| 2     | Database Connection Layer          | ⬜ Not Started |
| 3     | Authentication                     | ⬜ Not Started |
| 4     | Borrower Module (CRUD)             | ⬜ Not Started |
| 5     | Loan Module (CRUD)                 | ⬜ Not Started |
| 6     | Payment Module (CRUD)              | ⬜ Not Started |
| 7     | Borrower Account Module            | ⬜ Not Started |
| 8     | Loan Application Module            | ⬜ Not Started |
| 9     | Validation & Error Handling        | ⬜ Not Started |
| 10    | Testing                            | ⬜ Not Started |

---

*Last Updated: 2025 | LMS Backend Roadmap — Implementation Guide*
