# System Audit & Checklist
# Loan Management System (LMS) — ASA Philippines Foundation, Inc.

> **Audited:** 2026-06-09  
> **Technology:** VB.NET WinForms · .NET 8.0  
> **Current State:** UI Prototype (Frontend Only — No Database, No Backend)  
> **Auditor:** Claude Code (AI-assisted code review)  
> **Related Docs:**
> - `BACKEND_ROADMAP.md` — Database schema and implementation phases  
> - `BACKEND_FUNCTIONS.md` — Full VB.NET function specifications for every form and repository

---

## Executive Summary

The LMS is a well-structured **UI prototype** with 14 forms covering both the Admin and Borrower modules. The visual design is consistent and professional. However, the system is **not yet functional** — it has no real authentication, no database, no input validation, and several UI-level gaps that must be resolved before it can be used in any real environment.

---

## 1. Form Completion Status

| # | Form File | Purpose | UI Done | Backend Ready | Notes |
|---|-----------|---------|---------|---------------|-------|
| 1 | `Form1.vb` (LoginForm) | Login screen | ✅ | ❌ | No credential check; has bypass buttons |
| 2 | `ForgotPasswordForm.vb` | Password reset | ✅ | ❌ | No DB query; no password match validation |
| 3 | `AdminDashboardForm.vb` | Admin navigation shell | ✅ | ❌ | "Welcome, Admin" is hardcoded |
| 4 | `LoanListForm.vb` | Manage loans | ✅ | ❌ | Sample data only; search non-functional |
| 5 | `NewLoanForm.vb` | Add/Edit loan | ✅ | ❌ | Loan ID hardcoded; no DB save |
| 6 | `BorrowerListForm.vb` | Manage borrowers | ✅ | ❌ | Sample data only; search non-functional |
| 7 | `NewBorrowerForm.vb` | Add/Edit borrower | ✅ | ❌ | No DB save; ID upload non-functional |
| 8 | `PaymentListForm.vb` | Manage payments | ✅ | ❌ | Add/Update are MessageBox stubs |
| 9 | `BorrowerAccountsForm.vb` | Manage user accounts | ✅ | ❌ | Passwords shown as plain text |
| 10 | `BorrowerDashboardForm.vb` | Borrower navigation shell | ✅ | ❌ | Name hardcoded "Juan dela Cruz" |
| 11 | `LoanApplicationForm.vb` | Submit loan application | ✅ | ❌ | No DB insert; no validation |
| 12 | `TrackLoanForm.vb` | Track loan applications | ✅ | ❌ | Sample data only |
| 13 | `ViewLoanApplicationForm.vb` | View loan details | ✅ | ❌ | Data not passed from TrackLoanForm |
| 14 | `MyAccountForm.vb` | Update account credentials | ✅ | ❌ | No DB update; no password validation |

**UI Completion: 14 / 14 forms done (100%)**  
**Backend Completion: 0 / 14 forms done (0%)**

---

## 2. Critical Issues (Must Fix Before Production)

### 2.1 Security Issues — HIGH PRIORITY

- [ ] **No authentication logic** — `btnLogin` in `Form1.vb` opens `AdminDashboardForm` without checking any credentials. Any user can log in.
- [ ] **Role bypass buttons exist** — `btnAdmin` and `btnUser` in `LoginForm` skip login entirely and jump directly to dashboards. These must be removed before deployment.
- [ ] **Passwords displayed as plain text** — `BorrowerAccountsForm` DataGridView shows a `Password` column with no masking. This is a data exposure risk.
- [ ] **No password hashing** — `ForgotPasswordForm` stores/resets passwords without any hashing (`BCrypt` or `SHA256` not implemented).
- [ ] **No session management** — There is no `SessionManager` module. After login, no user identity is tracked; any form can be opened by any user.

### 2.2 Data Integrity Issues — HIGH PRIORITY

- [ ] **No database connected** — All data is hardcoded sample/placeholder data. Nothing persists between sessions.
- [ ] **Hardcoded Loan ID** — `NewLoanForm` sets `txtLoanID.Text = "LN-0006"` statically. No auto-increment logic exists.
- [ ] **Hardcoded Borrower Name** — `BorrowerDashboardForm` displays `"Welcome, Juan dela Cruz"` for all borrowers.
- [ ] **No input validation anywhere** — All form fields accept any input. No required-field checks, no numeric validation, no date range validation.
- [ ] **TotalPayable not calculated** — `NewLoanForm` has `txtTotalPayable` but no formula connecting it to principal, interest rate, and term.
- [ ] **ForgotPasswordForm does not validate** that `txtNewPassword` and `txtConfirmPassword` match before proceeding.

### 2.3 Functional Gaps — MEDIUM PRIORITY

- [ ] **Search boxes are non-functional** — `txtSearch` exists in `LoanListForm`, `BorrowerListForm`, `PaymentListForm`, and `BorrowerAccountsForm` but has no event handler or filter logic.
- [ ] **Delete button hidden in LoanListForm** — `btnDelete.Visible = False` is set in `InitializeComponent`. Delete is not accessible to admin users.
- [ ] **Delete button hidden in PaymentListForm** — Same issue as above.
- [ ] **PaymentListForm Add button is a stub** — Shows `"Add Payment feature will be available here."` MessageBox instead of opening a form.
- [ ] **PaymentListForm Update button is a stub** — Shows `"Update Payment feature will be available here."` MessageBox.
- [ ] **No NewPaymentForm exists** — There is no form for adding or editing a payment record.
- [ ] **ViewLoanApplicationForm receives no data** — When the View button is clicked in `TrackLoanForm`, no loan data is passed to `ViewLoanApplicationForm`. Fields will display empty or default values.
- [ ] **ID Upload non-functional** — `NewBorrowerForm` has a `btnUploadID` button but no file dialog or image handling code.
- [ ] **Logout does not close the form** — `btnLogout` calls `login.Show()` then `Me.Hide()`. The old dashboard form stays hidden in memory instead of being properly disposed.

---

## 3. Backend Implementation Checklist

All phases below are **Not Started**. Reference `BACKEND_ROADMAP.md` for full specifications.

### Phase 1 — Database Design & Setup
- [ ] Install and configure SQL Server / SQL Server Express
- [ ] Create database `LMS_DB`
- [ ] Create `tbl_Users` (UserID, Username, PasswordHash, Role, SecurityQuestion, SecurityAnswer, IsActive, CreatedAt)
- [ ] Create `tbl_Borrowers` (BorrowerID, BorrowerUID, FirstName, MiddleName, LastName, Age, DateOfBirth, Contact, Email, IDImagePath, UserID, CreatedAt)
- [ ] Create `tbl_Loans` (LoanID, LoanReferenceID, BorrowerID, LoanType, PrincipalAmount, InterestRate, TotalPayable, Term, ReleaseDate, DueDate, Status, CreatedAt)
- [ ] Create `tbl_Payments` (PaymentID, LoanID, Payee, Amount, Penalty, PaymentDate, Status, CreatedAt)
- [ ] Create `tbl_LoanApplications` (ApplicationID, BorrowerID, LoanType, PrincipalAmount, InterestRate, TotalPayable, Term, ReleaseDate, DueDate, Status, SubmittedAt)
- [ ] Add Foreign Key constraints between all related tables
- [ ] Add indexes on `BorrowerUID`, `LoanReferenceID`, `Username`
- [ ] Insert seed/default admin account

### Phase 2 — Database Connection Layer
- [ ] Add `App.config` with connection string
- [ ] Create `Data/DatabaseHelper.vb` with `GetConnection()` function
- [ ] Choose ADO.NET or Entity Framework Core
- [ ] Create `Data/` folder with repository classes:
  - [ ] `UserRepository.vb`
  - [ ] `BorrowerRepository.vb`
  - [ ] `LoanRepository.vb`
  - [ ] `PaymentRepository.vb`
  - [ ] `LoanApplicationRepository.vb`
- [ ] Create `Models/` folder with model classes:
  - [ ] `UserModel.vb`
  - [ ] `BorrowerModel.vb`
  - [ ] `LoanModel.vb`
  - [ ] `PaymentModel.vb`
  - [ ] `LoanApplicationModel.vb`

### Phase 3 — Authentication
- [ ] Create `Helpers/SessionManager.vb` — stores `UserID`, `Username`, `Role`
- [ ] Create `Helpers/PasswordHelper.vb` — BCrypt hashing utilities
- [ ] Implement real login: query `tbl_Users`, verify hashed password, redirect by role
- [ ] Remove `btnAdmin` and `btnUser` bypass buttons from `LoginForm`
- [ ] Show error message on invalid credentials
- [ ] Implement forgot password: verify security answer, hash and save new password
- [ ] Implement logout: clear session, dispose dashboard form, show `LoginForm`

### Phase 4 — Borrower Module CRUD
- [ ] Load borrowers from DB into `BorrowerListForm` DataGridView
- [ ] Wire up search/filter by name or UID in `BorrowerListForm`
- [ ] Wire up `btnUpdate` → populate `NewBorrowerForm` with selected row data
- [ ] Wire up `btnDelete` → confirm and delete from `tbl_Borrowers`
- [ ] Auto-generate `BorrowerUID` (e.g., `BRW-0001`) in `NewBorrowerForm`
- [ ] Implement file dialog for ID upload in `NewBorrowerForm`
- [ ] Save new borrower to `tbl_Borrowers`

### Phase 5 — Loan Module CRUD
- [ ] Load loans from DB (JOIN with `tbl_Borrowers`) into `LoanListForm` DataGridView
- [ ] Wire up search/filter in `LoanListForm`
- [ ] Make `btnDelete` visible and functional in `LoanListForm`
- [ ] Wire up `btnUpdate` → populate `NewLoanForm` with selected row data
- [ ] Auto-generate `LoanReferenceID` in `NewLoanForm`
- [ ] Populate `cmbBorrowerName` from `tbl_Borrowers`
- [ ] Implement TotalPayable auto-calculation formula
- [ ] Save new loan to `tbl_Loans`

### Phase 6 — Payment Module CRUD
- [ ] Create `NewPaymentForm.vb`
- [ ] Load payments from DB into `PaymentListForm` DataGridView
- [ ] Wire up `btnAdd` → open `NewPaymentForm`
- [ ] Wire up `btnUpdate` → open `NewPaymentForm` with selected data
- [ ] Make `btnDelete` visible and functional in `PaymentListForm`
- [ ] Implement penalty calculation for late payments
- [ ] Validate payment amount against loan balance
- [ ] Update corresponding loan status on payment

### Phase 7 — Borrower Account Module
- [ ] Load borrower accounts from `tbl_Users` (Role = 'Borrower') into `BorrowerAccountsForm`
- [ ] Mask password column in DataGridView (show `****` instead of plain text)
- [ ] Wire up Add/Update/Delete for borrower accounts
- [ ] Deactivate account on delete (`IsActive = 0`) instead of hard-delete
- [ ] Pre-fill `MyAccountForm` fields from `SessionManager`
- [ ] Validate new password matches confirm password in `MyAccountForm`
- [ ] Hash password before saving in `MyAccountForm`

### Phase 8 — Loan Application Module
- [ ] Pre-fill borrower name from `SessionManager` in `LoanApplicationForm`
- [ ] Implement TotalPayable auto-calculation in `LoanApplicationForm`
- [ ] Insert application into `tbl_LoanApplications` with `Status = 'Pending'`
- [ ] Load applications filtered by logged-in borrower in `TrackLoanForm`
- [ ] Pass selected application data to `ViewLoanApplicationForm`
- [ ] Load and display full application details in `ViewLoanApplicationForm`
- [ ] Add Approve/Reject buttons to admin view of loan applications
- [ ] Auto-create `tbl_Loans` record on application approval

### Phase 9 — Validation & Error Handling
- [ ] Add required-field validation on all forms
- [ ] Add numeric input validation (no negatives, valid percentages)
- [ ] Add date range validation (DueDate must be after ReleaseDate)
- [ ] Wrap all database operations in `Try/Catch` blocks
- [ ] Show user-friendly error messages via `MessageBox`
- [ ] Use parameterized queries everywhere to prevent SQL injection
- [ ] Add error logging to a text file or Windows Event Log

### Phase 10 — Testing
- [ ] Test login with valid admin credentials
- [ ] Test login with valid borrower credentials
- [ ] Test login with invalid credentials (error message shown)
- [ ] Test forgot password flow end-to-end
- [ ] Test Add / Update / Delete for Borrowers
- [ ] Test Add / Update / Delete for Loans
- [ ] Test Add / Update / Delete for Payments
- [ ] Test Add / Update / Delete for Borrower Accounts
- [ ] Test loan application submission from borrower
- [ ] Test loan tracking shows only logged-in borrower's applications
- [ ] Test My Account password change
- [ ] Test logout clears session and redirects

---

## 4. Code Quality Issues

| Issue | File | Line | Severity |
|-------|------|------|----------|
| Bypass role buttons bypass authentication | `Form1.vb` | 18–28 | Critical |
| Hardcoded Loan ID "LN-0006" | `NewLoanForm.vb` | 141 | High |
| Hardcoded welcome name "Juan dela Cruz" | `BorrowerDashboardForm.vb` | 165 | High |
| `btnDelete.Visible = False` (hidden, unused) | `LoanListForm.vb` | 107 | Medium |
| `btnDelete.Visible = False` (hidden, unused) | `PaymentListForm.vb` | 105 | Medium |
| No form disposal on logout (`Me.Hide()` instead of `Me.Close()`) | All dashboards | — | Medium |
| `txtSearch` has no event handler | `LoanListForm.vb`, `BorrowerListForm.vb`, `PaymentListForm.vb` | — | Medium |
| Passwords shown in plain text in DataGridView | `BorrowerAccountsForm.vb` | — | High |
| No password match check before reset | `ForgotPasswordForm.vb` | 342 | High |
| No required-field checks before form submit | All entry forms | — | Medium |
| Placeholder data hardcoded in `LoadSampleData()` | `LoanListForm.vb`, `PaymentListForm.vb`, etc. | — | Low (prototype) |

---

## 5. Project Structure — Current vs. Planned

### Current (Flat/Unorganized)
```
LMS_ASA/
├── Form1.vb
├── ForgotPasswordForm.vb
├── AdminDashboardForm.vb
├── LoanListForm.vb
├── NewLoanForm.vb
├── BorrowerListForm.vb
├── NewBorrowerForm.vb
├── PaymentListForm.vb
├── BorrowerAccountsForm.vb
├── BorrowerDashboardForm.vb
├── LoanApplicationForm.vb
├── TrackLoanForm.vb
├── ViewLoanApplicationForm.vb
└── MyAccountForm.vb
```

### Planned (Organized — from BACKEND_ROADMAP.md)
```
LMS_ASA/
├── App.config                          ← MISSING
├── Data/                               ← MISSING (entire folder)
│   ├── DatabaseHelper.vb
│   ├── UserRepository.vb
│   ├── BorrowerRepository.vb
│   ├── LoanRepository.vb
│   ├── PaymentRepository.vb
│   └── LoanApplicationRepository.vb
├── Models/                             ← MISSING (entire folder)
│   ├── UserModel.vb
│   ├── BorrowerModel.vb
│   ├── LoanModel.vb
│   ├── PaymentModel.vb
│   └── LoanApplicationModel.vb
├── Helpers/                            ← MISSING (entire folder)
│   ├── SessionManager.vb
│   ├── PasswordHelper.vb
│   └── ValidationHelper.vb
└── Forms/                              ← NOT YET REORGANIZED
    ├── Auth/
    │   ├── LoginForm.vb
    │   └── ForgotPasswordForm.vb
    ├── Admin/
    │   ├── AdminDashboardForm.vb
    │   ├── LoanListForm.vb
    │   ├── NewLoanForm.vb
    │   ├── BorrowerListForm.vb
    │   ├── NewBorrowerForm.vb
    │   ├── PaymentListForm.vb
    │   └── BorrowerAccountsForm.vb
    └── Borrower/
        ├── BorrowerDashboardForm.vb
        ├── LoanApplicationForm.vb
        ├── TrackLoanForm.vb
        ├── ViewLoanApplicationForm.vb
        └── MyAccountForm.vb
```

### Missing Files Summary
- [ ] `App.config` — connection string configuration
- [ ] `Data/DatabaseHelper.vb`
- [ ] `Data/UserRepository.vb`
- [ ] `Data/BorrowerRepository.vb`
- [ ] `Data/LoanRepository.vb`
- [ ] `Data/PaymentRepository.vb`
- [ ] `Data/LoanApplicationRepository.vb`
- [ ] `Models/UserModel.vb`
- [ ] `Models/BorrowerModel.vb`
- [ ] `Models/LoanModel.vb`
- [ ] `Models/PaymentModel.vb`
- [ ] `Models/LoanApplicationModel.vb`
- [ ] `Helpers/SessionManager.vb`
- [ ] `Helpers/PasswordHelper.vb`
- [ ] `Helpers/ValidationHelper.vb`
- [ ] `Forms/Admin/NewPaymentForm.vb` ← form does not exist yet

---

## 6. NuGet Packages Needed

| Package | Purpose | Status |
|---------|---------|--------|
| `Microsoft.Data.SqlClient` | SQL Server ADO.NET driver | Not Added |
| `BCrypt.Net-Next` | Secure password hashing | Not Added |
| `Dapper` *(optional)* | Lightweight ORM over ADO.NET | Not Added |
| `Microsoft.EntityFrameworkCore.SqlServer` *(optional)* | Full ORM alternative | Not Added |

---

## 7. UI / UX Improvements Needed

- [ ] **Status color coding** — In all DataGridViews, status values like `Pending`, `Approved`, `Active`, `Overdue`, `Closed` should be color-coded (e.g., green for Approved, red for Overdue, yellow for Pending).
- [ ] **Loading indicators** — Once DB is connected, add a loading spinner or progress bar for slow queries.
- [ ] **Confirm dialogs** — Add confirmation dialogs for destructive actions (Delete is partially done in LoanList but missing elsewhere).
- [ ] **Form title updates** — `AdminDashboardForm` changes `lblPageTitle.Text` on navigation but the window title bar (`Me.Text`) stays as `"LMS - Admin Dashboard"` always.
- [ ] **Resizing behavior** — Some forms have a fixed `MinimumSize` but content layout uses absolute pixel positions. On smaller screens some controls may be cut off.
- [ ] **Tab order** — Verify tab order is logical on all data-entry forms (Form1, NewLoanForm, NewBorrowerForm, LoanApplicationForm, MyAccountForm).
- [ ] **Enter key to submit** — Only `LoginForm` handles the Enter key. All other data-entry forms should also support `Enter` to submit.

---

## 8. Overall Progress Score

| Category | Score | Notes |
|----------|-------|-------|
| UI / Forms Completion | 14/14 (100%) | All forms exist and look correct |
| Navigation | 12/14 (85%) | ViewLoanApplicationForm receives no data; search is non-functional |
| Authentication | 0/1 (0%) | Completely bypassed |
| Database Integration | 0/10 phases (0%) | Not started |
| Input Validation | 0/14 (0%) | No validation on any form |
| Error Handling | 0/14 (0%) | No try-catch blocks |
| Security | 0/5 (0%) | Passwords plain text, no hashing, no session |
| **Overall System Readiness** | **~15%** | Ready as UI demo only |

---

## 9. Recommended Next Steps (Priority Order)

1. **Implement `SessionManager.vb`** and `PasswordHelper.vb` — needed by everything else.
2. **Set up SQL Server DB** and create all tables per `BACKEND_ROADMAP.md` Phase 1.
3. **Create `DatabaseHelper.vb`** and test the connection (Phase 2).
4. **Wire up real authentication** in `LoginForm` — remove bypass buttons (Phase 3).
5. **Implement Borrower CRUD** (Phase 4) — this unblocks the Loan module.
6. **Implement Loan CRUD** (Phase 5).
7. **Create `NewPaymentForm.vb`** and implement Payment CRUD (Phase 6).
8. **Implement Borrower Account module** — hide passwords, link to `tbl_Users` (Phase 7).
9. **Implement Loan Application module** for borrower side (Phase 8).
10. **Add global input validation** via `ValidationHelper.vb` (Phase 9).
11. **End-to-end testing** of all flows (Phase 10).

---

---

## 10. Documents in This Docs Folder

| File | Purpose |
|------|---------|
| `SYSTEM_AUDIT_CHECKLIST.md` | This file — audit findings, issues, and overall checklists |
| `BACKEND_ROADMAP.md` | Database schema design (tables, columns, relationships) |
| `BACKEND_FUNCTIONS.md` | Complete VB.NET function code for every repository, helper class, and form |
| `PROJECT_STRUCTURE.md` | Folder/file layout reference |

> **Start here when implementing:** Open `BACKEND_FUNCTIONS.md` — it contains ready-to-copy VB.NET code for every function that needs to be written.

---

*Last Updated: 2026-06-09 | LMS System Audit — ASA Philippines Foundation, Inc.*
