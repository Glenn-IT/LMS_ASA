# Changelog — LMS ASA Philippines

Records all bugs fixed and features implemented throughout development.
Format: `[Date] | Type | File(s) | Description`

---

## Bugs Fixed

| Date | Code | File(s) | Description |
|------|------|---------|-------------|
| 2026-06-11 | BC30506 | BorrowerListForm.vb, BorrowerAccountsForm.vb, LoanListForm.vb, PaymentListForm.vb | `txtSearch` declared without `WithEvents` — `Handles txtSearch.TextChanged` clause failed at compile time. Fixed by changing `Private txtSearch As TextBox` → `Private WithEvents txtSearch As TextBox` in all 4 list forms. |
| 2026-06-11 | BC30451 | TrackLoanForm.vb, ViewLoanApplicationForm.vb | `CDecimal()` is not a valid VB.NET conversion function. Fixed by replacing all 4 occurrences with the correct `CDec()` built-in. |

---

## Features Implemented

### Phase 0 — Project Setup
| Date | File(s) | Description |
|------|---------|-------------|
| — | LMS_ASA.vbproj, config.txt, dbconstring.vb | Project scaffolding, .NET 8 WinForms, connection string via `config.txt` (gitignored) |

### Phase 1 — Database & Schema
| Date | File(s) | Description |
|------|---------|-------------|
| — | DB scripts | Tables: Users, Borrowers, Loans, Payments, LoanApplications, ActivityLogs |

### Phase 2 — Core Architecture
| Date | File(s) | Description |
|------|---------|-------------|
| — | DataAccess/BorrowerRepository.vb | Borrower CRUD (GetAll, GetByID, Add, Update, Delete) |
| — | DataAccess/LoanRepository.vb | Loan CRUD |
| — | DataAccess/PaymentRepository.vb | Payment CRUD |
| — | DataAccess/UserRepository.vb | User management: GetAll, GetByUsername, Add, Deactivate (soft-delete) |
| — | DataAccess/LoanApplicationRepository.vb | Application CRUD: GetByBorrowerID, GetAll, UpdateStatus |
| — | DataAccess/ActivityLogger.vb | Log all user actions to ActivityLogs table |
| — | SessionManager.vb | Module holding CurrentUserID, CurrentUsername, CurrentRole, CurrentBorrowerID |

### Phase 3 — Authentication
| Date | File(s) | Description |
|------|---------|-------------|
| — | LoginForm.vb | Login with BCrypt password verification, role-based redirect |
| — | ForgotPasswordForm.vb | Password reset via username lookup + BCrypt re-hash |
| — | BCrypt.Net-Next v4.2.0 | All passwords hashed; plain-text passwords never stored or displayed |

### Phase 4 — Admin Forms
| Date | File(s) | Description |
|------|---------|-------------|
| — | AdminDashboard.vb | Role-gated admin home with navigation sidebar |
| — | BorrowerListForm.vb | List, search, add, update, delete borrowers |
| — | NewBorrowerForm.vb | Add/Edit borrower with auto-created login account |
| — | LoanListForm.vb | List, search, add, update, delete loans |
| — | NewLoanForm.vb | Add/Edit loan linked to borrower |
| — | PaymentListForm.vb | List, search, add, update, delete payments |
| — | NewPaymentForm.vb | Record payment against a loan |
| — | BorrowerAccountsForm.vb | View/deactivate borrower login accounts |
| — | EditAccountForm.vb | Change username or reset password for a borrower account |

### Phase 5 — Borrower Portal
| Date | File(s) | Description |
|------|---------|-------------|
| — | BorrowerDashboard.vb | Role-gated borrower home with navigation |
| — | LoanApplicationForm.vb | Submit new loan application |
| — | TrackLoanForm.vb | View own submitted applications and their status |
| — | ViewLoanApplicationForm.vb | Read-only detail view of a single application |
| — | MyAccountForm.vb | Change own password |

### Phase 6 — Loan Application Workflow (Admin)
| Date | File(s) | Description |
|------|---------|-------------|
| — | LoanApplicationsAdminForm.vb | Admin view of all pending applications; Approve / Reject with status update |

### Phase 7 — UI/UX Improvements
| Date | File(s) | Description |
|------|---------|-------------|
| 2026-06-11 | LoanListForm.vb, PaymentListForm.vb, BorrowerAccountsForm.vb, TrackLoanForm.vb | Status badge color coding via `CellFormatting` event (green=Active/Approved/Paid, yellow=Pending, red=Overdue/Rejected, gray=Closed/Inactive) |
| 2026-06-11 | BorrowerListForm.vb, LoanListForm.vb, PaymentListForm.vb, BorrowerAccountsForm.vb, TrackLoanForm.vb | Loading cursor (`WaitCursor`) on all data-load methods |
| 2026-06-11 | NewBorrowerForm.vb, NewLoanForm.vb, NewPaymentForm.vb, EditAccountForm.vb, LoanApplicationForm.vb, ForgotPasswordForm.vb, MyAccountForm.vb | `AcceptButton` set so Enter key submits the primary action button on all entry forms |
| 2026-06-11 | All list forms | Confirm dialog on all delete/deactivate buttons (already existed from prior phases — verified) |
| 2026-06-11 | BorrowerListForm.vb, BorrowerAccountsForm.vb, LoanListForm.vb, PaymentListForm.vb | Real-time search via `txtSearch.TextChanged` filtering `DefaultView.RowFilter` (already existed — verified) |

### Phase 8 — Security & Validation
| Date | File(s) | Description |
|------|---------|-------------|
| — | All entry forms | Required field validation before DB write |
| — | BorrowerAccountsForm.vb | Password column removed from grid entirely — never displayed in plain text |
| — | UserRepository.vb | Deactivate uses soft-delete (`IsActive = 0`), not hard delete |

### Phase 9 — Activity Logging
| Date | File(s) | Description |
|------|---------|-------------|
| — | ActivityLogger.vb | Centralized logging module called on every Create / Update / Delete / Login / Logout action |

---

### Phase 10 — Features & Fixes (Post-Testing)
| Date | File(s) | Description |
|------|---------|-------------|
| 2026-06-11 | Form1.vb (LoginForm) | Success login MessageBox — shows "Login successful! Welcome, {username}." after valid credentials |
| 2026-06-11 | Form1.vb (LoginForm) | Brute-force lockout — 3 failed attempts disables Login button with 30-second countdown; counter resets on successful login or after lockout expires |
| 2026-06-12 | AdminDashboardForm.vb, BorrowerDashboardForm.vb | Logout confirm dialog — Yes/No MessageBox before logging out; cancelling returns user to dashboard |
| 2026-06-12 | AdminDashboardForm.vb | Live date/time in sidebar header — `lblSidebarTitle` shows current time (hh:mm:ss tt), `lblSidebarSub` shows full date; updates every second via WinForms Timer |
| 2026-06-12 | AdminAccountSettingsForm.vb (new), AdminDashboardForm.vb, UserRepository.vb | Account Settings sidebar tab — admin can update username, change password (current password verified via BCrypt), and update security question/answer; username change syncs SessionManager |
| 2026-06-12 | NewBorrowerForm.vb | Age auto-computed from DOB — `txtAge` is now read-only; updates live via `dtpDateOfBirth.ValueChanged` using birthday-aware calculation |
| 2026-06-12 | NewBorrowerForm.vb | Contact Number — digits-only `KeyPress` guard + `MaxLength = 11`; validation requires exactly 11 digits |
| 2026-06-12 | NewBorrowerForm.vb | Email validation — must match `^[^@\s]+@gmail\.com$`; rejects non-gmail and malformed addresses |
| 2026-06-12 | Form1.vb, Form1.Designer.vb (LoginForm) | Show Password checkbox — toggles `txtPassword.PasswordChar` between masked (●) and plain text |
| 2026-07-15 | NewBorrowerForm.vb | First/Middle/Last Name — letters, spaces, hyphens, and apostrophes only via shared `KeyPress` guard |

### Phase 11 — v2.00 Presentation Reset
| Date | File(s) | Description |
|------|---------|-------------|
| 2026-07-15 | AdminDashboardForm.vb | Re-gated Loan List, Payment List, Borrower Accounts, Account Settings tabs (`LoadGated()`); Borrower List remains unlocked; default active tab changed to Borrower List |
| 2026-07-15 | BorrowerDashboardForm.vb | Re-gated File Loan Application, Track Loan, My Account tabs (`LoadGated()`) |
| 2026-07-15 | UnderConstructionForm.vb | `CURRENT_VERSION` bumped to "v2.00" |
| 2026-07-15 | docs/Version-Control.md | Added v2.00 rollout row: Login + Admin Dashboard + Borrower List/Add New Borrower unlocked, all other forms gated |
| 2026-07-15 | UnderConstructionForm.vb | Cherry-picked onto the `v2.00` tag per docs/Cherry-Pick-Guide.md — designer-style field declarations, anchored controls, `WindowState=Maximized`; tag re-pointed to `09fba67077b58c66e9907d7c8a469e72e3f58340` |

### Phase 12 — v3.00 Release
| Date | File(s) | Description |
|------|---------|-------------|
| 2026-07-20 | AdminDashboardForm.vb | Unlocked Borrower Accounts and Account Settings tabs |
| 2026-07-20 | BorrowerDashboardForm.vb | Unlocked Borrower Dashboard and My Account tabs |
| 2026-07-20 | UnderConstructionForm.vb | `CURRENT_VERSION` bumped to "v3.00" |

### Phase 13 — v4.00 Release
| Date | File(s) | Description |
|------|---------|-------------|
| 2026-07-28 | AdminDashboardForm.vb | Unlocked Loan List tab in Admin Dashboard |
| 2026-07-28 | LoanListForm.vb | View action enabled on Loan List; 5 sample loan records seeded (`docs/seed_loans_v4.sql`) |
| 2026-07-28 | UnderConstructionForm.vb | `CURRENT_VERSION` bumped to "v4.00" |

### Phase 14 — v5.00 Release
| Date | File(s) | Description |
|------|---------|-------------|
| 2026-08-05 | LoanListForm.vb | Unlocked Add, Update, and Delete buttons on Loan List (Add/Edit opens `NewLoanForm`, Delete confirms and removes loan record via `LoanRepository`) |
| 2026-08-05 | UnderConstructionForm.vb | `CURRENT_VERSION` bumped to "v5.00" |
| 2026-08-05 | docs/Version-Control.md | Added v5.00 rollout row in documentation |

### Phase 15 — v5.10 Release
| Date | File(s) | Description |
|------|---------|-------------|
| 2026-08-13 | LoanListForm.vb, BorrowerListForm.vb, BorrowerAccountsForm.vb | Added search debounce timer and "The searched data does not exist." popup message box when search yields 0 records |
| 2026-08-13 | UnderConstructionForm.vb | `CURRENT_VERSION` bumped to "v5.10" |
| 2026-08-13 | docs/Version-Control.md | Added v5.10 rollout row in documentation |

### Phase 16 — Payment List & Amortization Release
| Date | File(s) | Description |
|------|---------|-------------|
| 2026-08-19 | AdminDashboardForm.vb | Unlocked Payment List tab in Admin Dashboard (`LoadContent(New PaymentListForm())`) |
| 2026-08-19 | PaymentRepository.vb | Added `GetLoanPaymentSummary()` and updated `GetAll()` to calculate monthly amortization, total paid, remaining balance, and remaining schedule months |
| 2026-08-19 | NewPaymentForm.vb | Added Loan & Amortization Overview card section (Total Loan, Monthly Payment, Total Paid, Remaining Balance, Schedule Months Left), auto-fill payee name and monthly payment amount, and real-time balance calculation preview |
| 2026-08-19 | PaymentListForm.vb | Added KPI Summary Cards (Total Collections, Total Outstanding Balance, Total Transactions) and added Monthly Amortization, Remaining Balance, and Months Left columns to DataGridView |
| 2026-08-19 | ViewPaymentForm.vb | Added Loan & Amortization Overview card section when viewing payment details |


---

## Pending

| Item | Priority | Notes |
|------|----------|-------|
| Tab order verification | Low | Not yet set on any form; minor UX item |
| Phase 10 End-to-End Testing | High | User testing manually; bugs found will be logged here |
