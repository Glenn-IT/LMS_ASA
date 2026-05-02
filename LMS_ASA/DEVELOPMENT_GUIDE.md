# ?? Loan Management System (LMS) – UI Prototype Development Guide

> **Technology:** VB.NET WinForms · Visual Studio 2022 · .NET 8.0  
> **Purpose:** Frontend UI Prototype for Presentation Only  
> **Repository:** https://github.com/Glenn-IT/LMS_ASA  
> **Branch:** master

---

## ?? Important Rules

- ? Frontend / UI Only
- ? No Database
- ? No Backend Logic
- ? No Authentication Logic
- ? Sample Placeholder Data Only
- ? WinForms Designer Layout
- ? Navigation between forms only

---

## ??? Project Structure

```
LMS_ASA/
??? DEVELOPMENT_GUIDE.md         ? This file
??? LMS_ASA.vbproj
??? ApplicationEvents.vb
??? My Project/
?   ??? Application.Designer.vb
?
??? Forms/
?   ??? Form1.vb                 ? Login Form        (Step 1)
?   ??? ForgotPasswordForm.vb    ? Forgot Password   (Step 2)
?   ??? AdminDashboardForm.vb    ? Admin Dashboard   (Step 3)
?   ??? LoanListForm.vb          ? Loan List         (Step 4)
?   ??? NewLoanForm.vb           ? New Loan          (Step 5)
?   ??? BorrowerListForm.vb      ? Borrower List     (Step 6)
?   ??? NewBorrowerForm.vb       ? New Borrower      (Step 7)
?   ??? PaymentListForm.vb       ? Payment List      (Step 8)
?   ??? BorrowerAccountsForm.vb  ? Borrower Accounts (Step 9)
?   ??? BorrowerDashboardForm.vb ? Borrower Dashboard(Step 10)
?   ??? LoanApplicationForm.vb   ? Loan Application  (Step 11)
```

---

## ? Development Checklist

| Step | Form Name | Description | Status |
|------|-----------|-------------|--------|
| 1 | `LoginForm` | Login UI with username, password, forgot password link | ? Done |
| 2 | `ForgotPasswordForm` | Security question, new password fields | ? Done |
| 3 | `AdminDashboardForm` | Left sidebar + main content panel | ? Done |
| 4 | `LoanListForm` | DataGridView with loan records + Add/Update/Delete | ✅ Done |
| 5 | `NewLoanForm` | Loan entry form with all loan fields | ✅ Done |
| 6 | `BorrowerListForm` | DataGridView with borrower records | ✅ Done |
| 7 | `NewBorrowerForm` | Borrower entry form with personal info fields | ✅ Done |
| 8 | `PaymentListForm` | DataGridView with payment records | ✅ Done |
| 9 | `BorrowerAccountsForm` | DataGridView with borrower account credentials | ✅ Done |
| 10 | `BorrowerDashboardForm` | Borrower-side dashboard with menu options | ✅ Done |
| 11 | `LoanApplicationForm` | Borrower loan application entry form | ✅ Done |
| 12   | `TrackLoanForm`           | Borrower loan tracking page       | ✅ Done |
| 13   | `ViewLoanApplicationForm` | Displays loan application details | ✅ Done |
| 14   | `MyAccountForm`           | Borrower account settings         | ✅ Done |

---

## ?? Step-by-Step Form Specifications

---

### STEP 1 – Login Form (`Form1.vb` ? renamed: `LoginForm`)

| Control Type | Name | Label / Text |
|---|---|---|
| Label | — | `"Loan Management System"` |
| TextBox | `txtUsername` | Username |
| TextBox | `txtPassword` | Password (PasswordChar: `*`) |
| Button | `btnLogin` | Login |
| LinkLabel | `lnkForgotPassword` | Forgot Password? |

**Navigation:**
- `btnLogin` ? Opens `AdminDashboardForm`
- `lnkForgotPassword` ? Opens `ForgotPasswordForm`

---

### STEP 2 – Forgot Password Form (`ForgotPasswordForm.vb`)

| Control Type | Name | Label / Text |
|---|---|---|
| Label | — | `"Security Question:"` |
| Label | — | Sample question (e.g., "What is your mother's maiden name?") |
| TextBox | `txtAnswer` | Answer |
| TextBox | `txtNewPassword` | New Password |
| TextBox | `txtConfirmPassword` | Confirm Password |
| Button | `btnSubmit` | Submit |
| Button | `btnBackToLogin` | Back to Login |

**Navigation:**
- `btnSubmit` ? Shows confirmation MessageBox
- `btnBackToLogin` ? Returns to `LoginForm`

---

### STEP 3 – Admin Dashboard (`AdminDashboardForm.vb`)

| Area | Controls |
|---|---|
| Left Sidebar Panel | Buttons: Loan List, Borrower List, Payment List, Borrower Accounts, Logout |
| Main Content Panel | Placeholder label or embedded form content |

**Sidebar Button Navigation:**
- `btnLoanList` ? Shows `LoanListForm` in main panel
- `btnBorrowerList` ? Shows `BorrowerListForm` in main panel
- `btnPaymentList` ? Shows `PaymentListForm` in main panel
- `btnBorrowerAccounts` ? Shows `BorrowerAccountsForm` in main panel
- `btnLogout` ? Returns to `LoginForm`

---

### STEP 4 – Loan List (`LoanListForm.vb`)

**DataGridView Columns:**

| Column | Header Text |
|---|---|
| `LoanID` | Loan ID |
| `BorrowerName` | Borrower Name |
| `LoanDetails` | Loan Details |
| `NextPaymentDetails` | Next Payment Details |
| `Status` | Status |

**Buttons:** `btnAdd`, `btnUpdate`, `btnDelete`

**Sample Data:** 3–5 placeholder rows

---

### STEP 5 – New Loan Form (`NewLoanForm.vb`)

| Control | Name | Type |
|---|---|---|
| Loan ID | `txtLoanID` | TextBox (read-only) |
| Borrower Name | `cmbBorrowerName` | ComboBox |
| Loan Type | `cmbLoanType` | ComboBox |
| Principal Amount | `txtPrincipalAmount` | TextBox |
| Interest Rate | `txtInterestRate` | TextBox |
| Total Payable Amount | `txtTotalPayable` | TextBox |
| Term / Duration | `txtTerm` | TextBox |
| Release Date | `dtpReleaseDate` | DateTimePicker |
| Due Date | `dtpDueDate` | DateTimePicker |

**Buttons:** `btnAdd`, `btnCancel`

---

### STEP 6 – Borrower List (`BorrowerListForm.vb`)

**DataGridView Columns:**

| Column | Header Text |
|---|---|
| `BorrowerUID` | Borrower UID |
| `BorrowerName` | Borrower Name |
| `CurrentLoan` | Current Loan |
| `NextPaymentSchedule` | Next Payment Schedule |
| `Status` | Status |

**Buttons:** `btnAdd`, `btnUpdate`, `btnDelete`

---

### STEP 7 – New Borrower Form (`NewBorrowerForm.vb`)

| Field | Control Name | Type |
|---|---|---|
| Borrower UID | `txtBorrowerUID` | TextBox |
| First Name | `txtFirstName` | TextBox |
| Middle Name | `txtMiddleName` | TextBox |
| Last Name | `txtLastName` | TextBox |
| Age | `txtAge` | TextBox |
| Date of Birth | `dtpDateOfBirth` | DateTimePicker |
| Contact | `txtContact` | TextBox |
| Email | `txtEmail` | TextBox |
| Upload ID | `btnUploadID` | Button |

**Buttons:** `btnAdd`, `btnCancel`

---

### STEP 8 – Payment List (`PaymentListForm.vb`)

**DataGridView Columns:**

| Column | Header Text |
|---|---|
| `LoanReferenceID` | Loan Reference ID |
| `Payee` | Payee |
| `Amount` | Amount |
| `Penalty` | Penalty |
| `Status` | Status |

**Buttons:** `btnAdd`, `btnUpdate`, `btnDelete`

---

### STEP 9 – Borrower Accounts (`BorrowerAccountsForm.vb`)

**DataGridView Columns:**

| Column | Header Text |
|---|---|
| `BorrowerName` | Borrower Name |
| `Username` | Username |
| `Password` | Password |
| `Status` | Status |

**Buttons:** `btnAdd`, `btnUpdate`, `btnDelete`

---

### STEP 10 – Borrower Dashboard (`BorrowerDashboardForm.vb`)

| Menu Item | Action |
|---|---|
| File Loan Application | Opens `LoanApplicationForm` |
| Track Loan Application | Shows placeholder panel |
| My Account | Shows placeholder panel |
| Logout | Returns to `LoginForm` |

---

### STEP 11 – Loan Application Form (`LoanApplicationForm.vb`)

| Field | Control Name | Type |
|---|---|---|
| Loan ID | `txtLoanID` | TextBox |
| Borrower Name | `txtBorrowerName` | TextBox |
| Loan Type | `cmbLoanType` | ComboBox |
| Principal Amount | `txtPrincipalAmount` | TextBox |
| Interest Rate | `txtInterestRate` | TextBox |
| Total Payable Amount | `txtTotalPayable` | TextBox |
| Term | `txtTerm` | TextBox |
| Release Date | `dtpReleaseDate` | DateTimePicker |
| Due Date | `dtpDueDate` | DateTimePicker |

**Buttons:** `btnSubmit`, `btnCancel`

---

## ?? Design Guidelines

| Rule | Detail |
|---|---|
| Layout | Use `Panel` controls to separate sidebar and content areas |
| Grouping | Use `GroupBox` for form sections |
| Lists | Use `DataGridView` for all list/table views |
| Spacing | Keep consistent padding (12px minimum) |
| Colors | Clean, neutral color palette (whites, light grays, accent blue) |
| Fonts | Use `Segoe UI`, size 9–11pt |
| Overlapping | Avoid overlapping controls at all times |

---

## ?? Navigation Flow Diagram

```
LoginForm
  ??? [Login] ??????????????????????? AdminDashboardForm
  ?                                         ??? [Loan List] ??????? LoanListForm
  ?                                         ?                           ??? [Add] ??? NewLoanForm
  ?                                         ??? [Borrower List] ??? BorrowerListForm
  ?                                         ?                           ??? [Add] ??? NewBorrowerForm
  ?                                         ??? [Payment List] ???? PaymentListForm
  ?                                         ??? [Borrower Acc.] ??? BorrowerAccountsForm
  ?                                         ?                           ??? [Login as Borrower] ??? BorrowerDashboardForm
  ?                                         ??? [Logout] ?????????? LoginForm
  ?
  ??? [Forgot Password] ??????????? ForgotPasswordForm
                                          ??? [Back to Login] ??? LoginForm
```

---

*Last Updated: 2025 | LMS UI Prototype — For Presentation Use Only*


-----------
## 👤 Borrower / User Module

This module represents the **borrower side of the Loan Management System**.
Borrowers can:

* File a Loan Application
* Track Loan Applications
* View Loan Details
* Update Account Information
* Logout

This interface is **separate from the Admin Dashboard** and is intended for **borrowers only**.

---

## 📁 Additional Forms for Borrower Module

Update the **project structure** to include the following borrower-related forms:

```
Forms/
   Auth/
      LoginForm.vb
      ForgotPasswordForm.vb

   Admin/
      AdminDashboardForm.vb
      LoanListForm.vb
      NewLoanForm.vb
      BorrowerListForm.vb
      NewBorrowerForm.vb
      PaymentListForm.vb
      BorrowerAccountsForm.vb

   Borrower/
      BorrowerDashboardForm.vb
      LoanApplicationForm.vb
      TrackLoanForm.vb
      ViewLoanApplicationForm.vb
      MyAccountForm.vb
```

---

## STEP 12 – Track Loan Application (`TrackLoanForm.vb`)

This page allows borrowers to **track submitted loan applications**.

### DataGridView Columns

| Column Name         | Header Text           |
| ------------------- | --------------------- |
| LoanReferenceID     | Loan Reference ID     |
| Amount              | Amount                |
| NextPaymentSchedule | Next Payment Schedule |
| Status              | Status                |

### Action Column

| Button | Action                          |
| ------ | ------------------------------- |
| View   | Opens `ViewLoanApplicationForm` |

### Sample Placeholder Data

| Loan Ref | Amount | Next Payment  | Status   |
| -------- | ------ | ------------- | -------- |
| LN001    | 10,000 | June 1, 2025  | Pending  |
| LN002    | 5,000  | June 15, 2025 | Approved |

---

## STEP 13 – View Loan Application (`ViewLoanApplicationForm.vb`)

Displays **complete details of a loan application**.

### Fields

| Field                | Control Name         | Type           |
| -------------------- | -------------------- | -------------- |
| Loan ID              | `txtLoanID`          | TextBox        |
| Borrower Name        | `txtBorrowerName`    | TextBox        |
| Loan Type            | `txtLoanType`        | TextBox        |
| Principal Amount     | `txtPrincipalAmount` | TextBox        |
| Interest Rate        | `txtInterestRate`    | TextBox        |
| Total Payable Amount | `txtTotalPayable`    | TextBox        |
| Term / Duration      | `txtTerm`            | TextBox        |
| Release Date         | `dtpReleaseDate`     | DateTimePicker |
| Due Date             | `dtpDueDate`         | DateTimePicker |

### Buttons

| Button | Action                     |
| ------ | -------------------------- |
| Back   | Returns to `TrackLoanForm` |

---

## STEP 14 – My Account (`MyAccountForm.vb`)

Allows borrowers to **update their account credentials**.

### Fields

| Field             | Control Name          | Type     |
| ----------------- | --------------------- | -------- |
| Username          | `txtUsername`         | TextBox  |
| Password          | `txtPassword`         | TextBox  |
| Confirm Password  | `txtConfirmPassword`  | TextBox  |
| Security Question | `cmbSecurityQuestion` | ComboBox |
| Security Answer   | `txtSecurityAnswer`   | TextBox  |

### Buttons

| Button | Action                             |
| ------ | ---------------------------------- |
| Update | Shows confirmation `MessageBox`    |
| Cancel | Returns to `BorrowerDashboardForm` |

---

## 🔄 Borrower Navigation Flow

```
BorrowerDashboardForm
   |
   |-- File Loan Application --> LoanApplicationForm
   |
   |-- Track Loan Application --> TrackLoanForm
   |                                 |
   |                                 └── ViewLoanApplicationForm
   |
   |-- My Account -------------> MyAccountForm
   |
   |-- Logout -----------------> LoginForm
```

---

## ✅ Updated Development Checklist

| Step | Form Name                 | Description                       | Status    |
| ---- | ------------------------- | --------------------------------- | --------- |
| 12   | `TrackLoanForm`           | Borrower loan tracking page       | ✅ Done |
| 13   | `ViewLoanApplicationForm` | Displays loan application details | ✅ Done |
| 14   | `MyAccountForm`           | Borrower account settings         | ✅ Done |


Updated to check if the other repos check this file for the development guide. This file is intended to be a comprehensive guide for developing the UI prototype of the Loan Management System (LMS) using VB.NET WinForms. It includes detailed specifications for each form, navigation flow, design guidelines, and a development checklist to ensure all components are implemented correctly.