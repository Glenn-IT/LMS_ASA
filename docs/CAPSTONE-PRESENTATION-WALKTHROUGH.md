# LMSAP — Capstone Defense Presentation Walkthrough & Panelist Demonstration Guide
<!-- System: Loan Management System for ASA Philippines (LMSAP / LMS-ASA) -->
<!-- Target Organization: ASA Philippines Foundation Inc. (Microfinance NGO) -->
<!-- Program: Bachelor of Science in Information Technology (BSIT) -->
<!-- Target Audience: Capstone Defense Panelists, Technical Advisers, Deans, and Evaluators -->

---

## 🧭 Executive Summary & Timing Strategy

| Phase | Section | Recommended Duration | Primary Interface |
| :--- | :--- | :--- | :--- |
| **Phase 1** | Project Rationale, Microfinance Context & ASA Philippines Problem Statement | 1.5 mins | Title Slide / [Form1.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Form1.vb) |
| **Phase 2** | Technical Architecture, Tiered Structure & Defensive Security Baseline | 1.0 min | [PROJECT_STRUCTURE.md](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/docs/PROJECT_STRUCTURE.md) / [dbconstring.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/dbconstring.vb) |
| **Phase 3** | Secure Authentication, Role-Based Routing & Brute-Force Lockout Defense | 1.0 min | [Form1.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Form1.vb) |
| **Phase 4** | Autonomous Self-Service Credential Recovery & Security Question Trapping | 1.0 min | [ForgotPasswordForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ForgotPasswordForm.vb) |
| **Phase 5** | Executive Administrator Command Center & Real-Time Portfolio Analytics | 1.5 mins | [AdminOverviewForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/AdminOverviewForm.vb) |
| **Phase 6** | Borrower Portfolio Management, UID Generation & Valid ID Zoom Inspection | 1.5 mins | [BorrowerListForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/BorrowerListForm.vb) & [ViewBorrowerForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ViewBorrowerForm.vb) |
| **Phase 7** | Automated Borrower Account Provisioning & Input Validation Integrity | 1.0 min | [NewBorrowerForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/NewBorrowerForm.vb) |
| **Phase 8** | Credit Evaluation, Loan Origination & Mathematical Interest Engine | 1.5 mins | [LoanListForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/LoanListForm.vb) & [NewLoanForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/NewLoanForm.vb) |
| **Phase 9** | Loan Amortization Schedule, Real-Time Balance Reductions & Repayment Processing | 1.5 mins | [PaymentListForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/PaymentListForm.vb) & [NewPaymentForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/NewPaymentForm.vb) |
| **Phase 10** | Borrower Self-Service Portal & Loan Application Filing Wizard | 1.5 mins | [BorrowerDashboardForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/BorrowerDashboardForm.vb) & [LoanApplicationForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/LoanApplicationForm.vb) |
| **Phase 11** | Borrower Loan Monitoring, Status Lifecycle Badges & Application Inspection | 1.0 min | [TrackLoanForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/TrackLoanForm.vb) & [ViewLoanApplicationForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ViewLoanApplicationForm.vb) |
| **Phase 12** | Borrower Credential Governance & Self-Service Account Maintenance | 0.5 min | [MyAccountForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/MyAccountForm.vb) |
| **Phase 13** | Administrative Identity Governance & Non-Destructive Soft-Delete Auditing | 1.0 min | [BorrowerAccountsForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/BorrowerAccountsForm.vb) & [EditAccountForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/EditAccountForm.vb) |
| **Phase 14** | Administrator Security Settings & Dynamic In-Memory Session Synchronization | 0.5 min | [AdminAccountSettingsForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/AdminAccountSettingsForm.vb) |
| **Phase 15** | Interactive Built-in System Manual & Multi-Tier Operational Knowledgebase | 1.0 min | [SystemManualForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/SystemManualForm.vb) |
| **Phase 16** | Development Team Attribution & Institutional Contributions | 0.5 min | [DevelopersForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DevelopersForm.vb) |
| **Phase 17** | Centralized Activity Logging, Audit Trail Verification & Concluding Transition | 0.5 min | [ActivityLogger.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ActivityLogger.vb) & Database Query |
| **Total** | **Full System Defense Presentation** | **~17.5 mins** | — |

---

## 🛠️ Pre-Defense Staging & Credentials Setup

Before commencing the defense presentation, prepare your demonstration workstation:

1. **Dual-Instance Demonstration Setup**:
   * **Instance 1 (Primary Desktop Screen):** Logged in as **Microfinance Administrator** (`admin`). This instance showcases executive analytics, borrower records, loan portfolio management, payment collection entries, and account governance.
   * **Instance 2 (Secondary / Side-by-Side Screen):** Ready on the [LoginForm](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Form1.vb) to log in as a **Registered Borrower** (e.g., `brw0001` or a newly registered borrower). This enables live demonstration of borrower self-service loan application filing, real-time calculation previews, and status monitoring.
2. **Standard Demonstration Accounts**:
   * **System Administrator:** Username: `admin` | Password: `Password@1` (or `Admin@123`) | Role: `Admin`
   * **Default Borrower Accounts:** Username format: `brw0001` (derived from Borrower UID without hyphens) | Default Password: `Password@1` | Default Security Question Answer: `default`
3. **Database Configuration & Connection Verification**:
   * Ensure Microsoft SQL Server (`LMS_DB`) is active.
   * Verify [`config.txt`](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/bin/Debug/net8.0-windows/config.txt) exists in your application startup directory pointing to:
     ```text
     Data Source=.\SQLEXPRESS;Initial Catalog=LMS_DB;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;
     ```
   * Ensure sample borrower, loan, and payment records are seeded via [`docs/seed_loans_v4.sql`](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/docs/seed_loans_v4.sql).
4. **Branding & Assets Verification**:
   * Verify system logo asset [`img/Logo.png`](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/img/Logo.png) loads seamlessly across topbars, login banners, and dashboard hero headers via [`AppTheme.GetLogoImage()`](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Helpers/AppTheme.vb).

### 👥 Seeded Demonstration Accounts

| # | Borrower UID | Full Name | Contact Number | Email Address | Assigned Loan Reference | Loan Type | Principal | Loan Status |
| :- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| 1 | `BRW-0001` | **Maria Elena Santos** | `09171234567` | `maria.santos@gmail.com` | `LN-0001` | Micro-Business Loan | ₱25,000.00 | **Active** |
| 2 | `BRW-0002` | **Juan Carlos Reyes** | `09281234568` | `juan.reyes@gmail.com` | `LN-0002` | Agricultural Loan | ₱80,000.00 | **Approved** |
| 3 | `BRW-0003` | **Luzviminda Bautista** | `09391234569` | `luz.bautista@gmail.com` | `LN-0003` | Educational Loan | ₱15,000.00 | **Pending** |
| 4 | `BRW-0004` | **Rodrigo Dela Cruz** | `09551234570` | `rodrigo.delacruz@gmail.com` | `LN-0004` | Emergency Loan | ₱5,000.00 | **Overdue** |
| 5 | `BRW-0005` | **Corazon Aquino Ramos** | `09661234571` | `corazon.ramos@gmail.com` | `LN-0005` | Salary Loan | ₱10,000.00 | **Closed / Fully Paid** |

### 💼 Seeded Loan Products & Terms

| Loan Product | Target Beneficiary | Standard Principal Range | Interest Rate | Standard Term | Payment Frequency |
| :--- | :--- | :--- | :--- | :--- | :--- |
| **Micro-Business Loan** | Sari-sari stores, market vendors, food stalls | ₱10,000 – ₱150,000 | 3.5% – 4.5% | 6 to 24 Months | Monthly Amortization |
| **Agricultural Loan** | Rice/corn farmers, livestock raisers, fisheries | ₱20,000 – ₱100,000 | 3.0% – 4.0% | 12 to 18 Months | Monthly / Seasonal |
| **Educational Loan** | Tuition assistance for dependent students | ₱5,000 – ₱30,000 | 2.5% – 3.0% | 6 to 12 Months | Monthly Amortization |
| **Emergency Loan** | Medical crisis, natural calamity relief | ₱3,000 – ₱15,000 | 4.0% – 5.0% | 3 to 6 Months | Monthly Amortization |
| **Salary Loan** | Employed community members, micro-workers | ₱5,000 – ₱50,000 | 2.5% – 3.5% | 6 to 12 Months | Monthly Amortization |

---

## 🎬 Step-by-Step Presentation Script (From First to Last)

---

### Step 1: Project Rationale, Microfinance Context & ASA Philippines Problem Statement
* **Screen Display:** Application Launch / [Form1.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Form1.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:** Present the clean, ASA Philippines-branded login window displaying the institutional warm orange/crimson visual identity and official system logo.
* **🗣️ Verbal Script:**
  > *"Good morning, honorable members of the panel, project adviser, and guests. Today, we are proud to present **LMSAP — the Loan Management System for ASA Philippines**.
  >
  > *ASA Philippines Foundation is one of the largest and most impactful microfinance non-government organizations in our country, empowering over two million women micro-entrepreneurs, small farmers, and low-income families through accessible credit facilities.
  >
  > *However, many microfinance branch operations continue to grapple with severe operational bottlenecks: paper-based borrower master ledgers, manual interest and amortization calculations prone to human error, physical document misplacement, and delayed transaction reporting. When clients make payments in the field or at the branch counter, loan officers must manually reconcile passbooks with physical cards, leading to discrepancies, delayed balance updates, and vulnerability during audits.
  >
  > *LMSAP directly addresses these challenges by delivering an automated, secure, and resilient microfinance management ecosystem. It streamlines borrower registration, automates loan evaluation and amortization scheduling, tracks collections in real time, and equips both branch administrators and borrowers with transparent, role-gated interfaces."*

---

### Step 2: Technical Architecture, Tiered Structure & Defensive Security Baseline
* **Screen Display:** Architecture Overview / [PROJECT_STRUCTURE.md](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/docs/PROJECT_STRUCTURE.md) & [dbconstring.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/dbconstring.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:** Briefly explain the software engineering stack, clean separation of concerns, and defensive data access patterns.
* **🗣️ Verbal Script:**
  > *"Under the hood, LMSAP is engineered as a robust desktop enterprise application using modern software engineering principles:
  >
  > 1. **Framework & Language:** Built on **Microsoft .NET 8.0 Windows Forms (WinForms)** with VB.NET, delivering responsive desktop performance, low hardware resource utilization, and offline-resilient local execution ideal for rural microfinance branch offices.
  > 2. **Modular Data Access Layer (DAL):** Decoupled architecture separating Presentation Forms from Data Repositories ([BorrowerRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/BorrowerRepository.vb), [LoanRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/LoanRepository.vb), [PaymentRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/PaymentRepository.vb), and [DashboardRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/DashboardRepository.vb)).
  > 3. **Defensive SQL Security:** Communicates with **Microsoft SQL Server (`LMS_DB`)** via `Microsoft.Data.SqlClient` using 100% parameterized SQL commands (`SqlCommand.Parameters.AddWithValue`), entirely eliminating SQL injection risks.
  > 4. **Military-Grade Password Hashing:** User passwords are encrypted using **BCrypt.Net-Next** with a work factor of 11 in [PasswordHelper.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Helpers/PasswordHelper.vb). Plain-text passwords are never stored in the database nor displayed on screen.
  > 5. **ASA Brand Color System:** Styled with centralized brand constants in [AppTheme.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Helpers/AppTheme.vb) reflecting ASA Philippines' corporate identity: `#E73F1E` Primary Red-Orange, `#FB6C00` Vibrant Orange, and `#F9B637` Warm Amber."*

---

### Step 3: Secure Authentication, Role-Based Routing & Brute-Force Lockout Defense
* **Screen Display:** [Form1.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Form1.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Highlight the clean login UI with Show/Hide Password checkbox toggling the password character.
  2. Demonstrate the **Brute-Force Lockout Defense**:
     * Enter incorrect credentials 3 times consecutively.
     * Show the system alert: *"Too many failed attempts. Login is locked for 15 seconds."*
     * Highlight how the `Login` button is disabled with a live countdown timer (`Locked (15s)... Locked (14s)...`).
  3. Once countdown expires, enter valid credentials for the **System Administrator** (`admin`).
  4. Showcase the welcome confirmation dialog: *"Login successful! Welcome, admin."*
  5. Demonstrate how the session manager ([SessionManager.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Helpers/SessionManager.vb)) captures the logged-in User ID, Username, and Role, directing the user to the [AdminDashboardForm](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/AdminDashboardForm.vb).
* **🗣️ Verbal Script:**
  > *"To safeguard sensitive financial records from dictionary and credential-stuffing attacks, LMSAP implements an automated **Brute-Force Lockout Engine**:
  >
  > *After three consecutive invalid attempts, the login interface enters a strict temporary lockout with a visible countdown timer, while silently registering the failed access attempt in our centralized audit log.
  >
  > *Upon supplying valid credentials, the system verifies the BCrypt hash, captures the authenticated context into `SessionManager`, and routes the user strictly according to their assigned role — Admin or Borrower."*

---

### Step 4: Autonomous Self-Service Credential Recovery & Security Question Trapping
* **Screen Display:** [ForgotPasswordForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ForgotPasswordForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Click **"Forgot Password?"** link on the login form.
  2. Explain the 3-step recovery workflow:
     * **Step 1:** Username Lookup — enter a valid username (e.g., `brw0001`). Click *Verify*.
     * **Step 2:** Security Challenge — the system retrieves and displays the borrower's registered security question (e.g., *"What is your mother's maiden name?"*).
     * **Step 3:** Password Reset — enter the registered security answer (`default`) and type the new password.
  3. Explain that upon submission, the new password is encrypted via BCrypt and the update is permanently committed.
* **🗣️ Verbal Script:**
  > *"Branch IT staff should not be burdened with routine password resets. Through `ForgotPasswordForm`, both borrowers and administrative staff can recover their accounts autonomously.
  >
  > *The workflow challenges the user with their pre-configured security question. Only upon matching the hashed security answer can the user define a new password, ensuring complete self-service recovery without compromising identity verification."*

---

### Step 5: Executive Administrator Command Center & Real-Time Portfolio Analytics
* **Screen Display:** [AdminOverviewForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/AdminOverviewForm.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:**
  1. Showcase the **Executive Dashboard Overview** loaded directly upon admin login.
  2. Point out the live sidebar header displaying real-time system clock and date dynamically ticking every second.
  3. Review the **6 Real-Time KPI Metric Cards**:
     * **Total Borrowers:** Count of registered microfinance clients.
     * **Active Loans:** Active and approved loan accounts currently running.
     * **Total Disbursed:** Total principal capital released (₱).
     * **Total Collected:** Cumulative payments received to date (₱).
     * **Outstanding Balance:** Net remaining balance across the portfolio (₱).
     * **Pending Applications:** Borrowers awaiting credit review.
  4. Showcase the **Custom GDI+ Graphical Analytics**:
     * **Loan Portfolio by Status:** Anti-aliased Donut Chart displaying distribution of Active, Approved, Pending, Overdue, and Closed loans.
     * **Disbursements vs. Collections by Loan Type:** Multi-column bar chart comparing Micro-Business, Agricultural, Salary, and Emergency loans.
     * **Collection Efficiency Gauge:** Visual radial meter indicating overall loan recovery percentage.
  5. Point out the bottom summary tables showing recent loan approvals and latest payment collection vouchers.
  6. Click **"🔄 Refresh Data"** to demonstrate live database recalculation.
* **🗣️ Verbal Script:**
  > *"When the administrator logs in, they are immediately welcomed by the **Executive Analytics & Performance Dashboard**.
  >
  > *This command center provides branch managers and credit supervisors with instant visibility over the six vital microfinance health indicators: client count, active portfolio, total capital disbursed, actual collections received, total outstanding balance, and pending review requests.
  >
  > *Rather than relying on third-party web libraries, our system employs custom GDI+ drawing routines with full anti-aliasing to render a status donut chart, a loan product comparative bar chart, and a collection efficiency gauge. This gives executive decision-makers immediate clarity on repayment health without any internet dependency."*

---

### Step 6: Borrower Portfolio Management, UID Generation & Valid ID Zoom Inspection
* **Screen Display:** [BorrowerListForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/BorrowerListForm.vb) & [ViewBorrowerForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ViewBorrowerForm.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:**
  1. Click **"Borrower List"** on the admin sidebar.
  2. Demonstrate the responsive DataGridView listing all borrowers with their unique identifier (`BorrowerUID`, e.g. `BRW-0001`), full name, age, contact, and email.
  3. Test the **Search Debounce Feature**:
     * Type a search query (e.g., `Maria`).
     * Type an intentionally nonexistent borrower name (e.g., `NonExistentName`).
     * Show the prompt: *"The searched data does not exist."*
  4. Select a borrower row (e.g., *Maria Elena Santos*) and click **"View Details"**:
     * Showcase [ViewBorrowerForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ViewBorrowerForm.vb).
     * Highlight the **Valid ID Inspection Panel**: observe the embedded picture box previewing the borrower's submitted government-issued ID.
     * Click **"🔍 View Full ID"**: demonstrate the dedicated modal popup rendering the ID image in high-resolution zoom mode for identity verification.
* **🗣️ Verbal Script:**
  > *"In microfinance, rigorous Know-Your-Customer (KYC) compliance is non-negotiable.
  >
  > *Under the Borrower List, administrators maintain all client profiles. In our latest update, we integrated a dedicated **Valid ID Inspection Engine** within `ViewBorrowerForm`.
  >
  > *Loan officers can preview government-issued IDs directly on screen and launch a high-resolution zoom modal to inspect signatures, photo authenticity, and ID validity before approving credit disbursements."*

---

### Step 7: Automated Borrower Account Provisioning & Input Validation Integrity
* **Screen Display:** [NewBorrowerForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/NewBorrowerForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Click **"Add Borrower"** to open `NewBorrowerForm`.
  2. Point out the auto-generated unique `BorrowerUID` (`BRW-####`).
  3. Demonstrate strict client-side validation rules:
     * **Name Fields:** KeyPress filter restricting inputs strictly to letters, spaces, hyphens, and apostrophes.
     * **Date of Birth & Age:** Change the `DateTimePicker` date — show how `txtAge` is completely read-only and automatically computes exact chronological age.
     * **Contact Number:** KeyPress trap enforcing digits only and validating exact 11-digit Philippine mobile formatting (`09XXXXXXXXX`).
     * **Email Address:** RegEx validation enforcing valid `@gmail.com` syntax.
     * **Valid ID File Upload:** Click *Upload ID* to attach an image or PDF document.
  4. Explain what happens upon clicking **"Save Borrower"**:
     * Highlights transactional creation in [BorrowerRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/BorrowerRepository.vb): the system inserts the borrower record into `tbl_Borrowers` AND automatically provisions a linked user account in `tbl_Users` with default username (e.g., `brw0006`) and hashed password (`Password@1`).
* **🗣️ Verbal Script:**
  > *"When registering a new borrower, LMSAP enforces multi-layered data sanitization. Age is calculated automatically from birthdate, mobile numbers require 11 digits, and email formats are strictly validated.
  >
  > *More importantly, our database repository automatically provisions a corresponding Borrower Portal login credential in `tbl_Users` inside a single transactional block. Clients can immediately log in using their credentials to track their loan status without manual IT provisioning."*

---

### Step 8: Credit Evaluation, Loan Origination & Mathematical Interest Engine
* **Screen Display:** [LoanListForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/LoanListForm.vb) & [NewLoanForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/NewLoanForm.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:**
  1. Navigate to **"Loan List"** in the sidebar.
  2. Highlight the color-coded loan status badges:
     * 🟢 **Active / Approved:** Operational credit accounts in good standing.
     * 🟡 **Pending:** Applications currently under review.
     * 🔴 **Overdue:** Accounts with delinquent or delayed payments.
     * ⚪ **Closed:** Fully satisfied and cleared loan facilities.
  3. Click **"New Loan"** to launch `NewLoanForm`:
     * Select a borrower from the dynamic dropdown.
     * Select Loan Type: *Micro-Business Loan*.
     * Enter Principal: `₱20,000.00`, Interest Rate: `4.0%`, Term: `12 Months`.
     * Point out the live formula calculation:
       $$\text{Total Payable} = \text{Principal} \times \left(1 + \frac{\text{Rate}}{100}\right) = ₱20,000 \times 1.04 = ₱20,800.00$$
     * Select Release Date and Due Date.
     * Click **"Save Loan"** to commit the record into `tbl_Loans`.
  4. Demonstrate the **"View Loan"** button on an existing loan to inspect the full amortization breakdown and linked borrower history in [ViewLoanForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ViewLoanForm.vb).
* **🗣️ Verbal Script:**
  > *"Under the Loan Portfolio module, administrators process and evaluate credit facilities.
  >
  > *In `NewLoanForm`, our mathematical calculation engine eliminates spreadsheet math errors. The total payable amount is dynamically computed in real time from the principal, annual rate, and repayment term.
  >
  > *Every status change is logged, and visual badges immediately alert loan officers regarding overdue accounts that require field follow-up."*

---

### Step 9: Loan Amortization Schedule, Real-Time Balance Reductions & Repayment Processing
* **Screen Display:** [PaymentListForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/PaymentListForm.vb) & [NewPaymentForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/NewPaymentForm.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:**
  1. Open **"Payment List"** on the admin sidebar.
  2. Highlight the **Top KPI Summary Header**:
     * **Total Collections (₱):** Cumulative collections recorded.
     * **Total Outstanding Balance (₱):** Uncollected portfolio balance.
     * **Total Transactions:** Total payment vouchers issued.
  3. Point out the grid columns: *Payment ID, Loan Ref, Borrower Name, Amount, Date, Monthly Amortization, Remaining Balance, and Months Left*.
  4. Click **"Record Payment"** to open `NewPaymentForm`:
     * Select an active loan reference (e.g., `LN-0001`).
     * Notice how the **Loan & Amortization Overview Card** automatically populates:
       * *Total Loan Amount, Monthly Amortization, Total Paid, Current Remaining Balance, and Schedule Months Left*.
       * Payee Name and suggested Monthly Amortization are automatically pre-filled.
     * Type an installment amount (e.g., `₱2,100.00`) and optional penalty.
     * Point out the **Real-Time Live Calculation Preview**: showing exactly what the new remaining balance will be before saving!
     * Click **"Save Payment"**.
  5. Back in `PaymentListForm`, point out how the remaining balance column and KPI cards instantly update to reflect the new payment.
* **🗣️ Verbal Script:**
  > *"The heart of any microfinance platform is the collection engine. In `NewPaymentForm`, loan officers experience an intelligent repayment workflow:
  >
  > *When a loan reference is selected, our backend repository calculates the complete financial snapshot: total loan obligation, monthly amortization due, total collections to date, and remaining balance.
  >
  > *As the officer types the payment amount, a live balance preview demonstrates the exact mathematical impact of the payment before saving. Once saved, the remaining balance is updated, and if the balance reaches zero, the loan status automatically transitions to 'Paid'."*

---

### Step 10: Borrower Self-Service Portal & Loan Application Filing Wizard
* **Screen Display:** Switch to Instance 2: [BorrowerDashboardForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/BorrowerDashboardForm.vb) & [LoanApplicationForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/LoanApplicationForm.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:**
  1. Switch to the second application window logged in as borrower **Maria Elena Santos** (`brw0001`).
  2. Showcase the **Borrower Portal Interface**: customized warm sidebar with options: *File Loan Application, Loan Monitoring, My Account, System Manual, and Developers*.
  3. Click **"File Loan Application"** to launch `LoanApplicationForm`:
     * Applicant name is pre-filled from session memory.
     * Select Loan Type: *Micro-Business Loan*.
     * Input Desired Principal: `₱15,000.00` and Term: `6 Months`.
     * Point out how the interest rate (3.5%) and total payable (₱15,525.00) are automatically calculated for the borrower.
     * Check the formal declaration affirming accuracy of information.
     * Click **"Submit Application"**.
  4. Showcase the submission success confirmation dialog.
* **🗣️ Verbal Script:**
  > *"Now switching to our secondary demonstration instance: the Borrower Self-Service Portal.
  >
  > *Rather than traveling long distances to a physical branch just to request a loan application slip, clients can access the portal from a branch terminal or local kiosk.
  >
  > *In `LoanApplicationForm`, borrowers select their desired credit product, specify their capital requirement, and inspect the exact interest and total repayment obligation upfront, providing 100% financial transparency before formally submitting their application."*

---

### Step 11: Borrower Loan Monitoring, Status Lifecycle Badges & Application Inspection
* **Screen Display:** [TrackLoanForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/TrackLoanForm.vb) & [ViewLoanApplicationForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ViewLoanApplicationForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Click **"Loan Monitoring"** on the borrower sidebar.
  2. Showcase the tracking DataGridView displaying all historical and pending applications filed by this specific borrower.
  3. Highlight the color-coded status badges: `Pending` in yellow, `Approved` in green, and `Rejected` in red.
  4. Double-click or select an application and click **"View Details"**:
     * Open [ViewLoanApplicationForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ViewLoanApplicationForm.vb).
     * Point out the read-only inspection dialog showing release dates, interest rates, scheduled due dates, and administrative remarks.
* **🗣️ Verbal Script:**
  > *"Through the 'Loan Monitoring' module, borrowers maintain continuous, real-time visibility over their applications.
  >
  > *Clients no longer experience anxiety or uncertainty regarding their credit review. They can view whether their application is pending, approved, or requires supplementary documentation, fostering trust between ASA Philippines and its members."*

---

### Step 12: Borrower Credential Governance & Self-Service Account Maintenance
* **Screen Display:** [MyAccountForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/MyAccountForm.vb)
* **Estimated Time:** 0.5 minute
* **Screen Action:**
  1. Navigate to **"My Account"** in the borrower portal.
  2. Point out that the borrower's username is fixed to prevent identity tampering.
  3. Showcase updating the account password:
     * Requires verifying the current password via BCrypt.
     * Enforces minimum password complexity.
  4. Showcase configuring or updating the **Security Question and Answer** for future self-service password recovery.
* **🗣️ Verbal Script:**
  > *"In `MyAccountForm`, borrowers have complete autonomy over their credentials. They can update their passwords and configure personal security recovery questions, ensuring account security while adhering to data privacy standards."*

---

### Step 13: Administrative Identity Governance & Non-Destructive Soft-Delete Auditing
* **Screen Display:** Switch back to Admin Instance: [BorrowerAccountsForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/BorrowerAccountsForm.vb) & [EditAccountForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/EditAccountForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Click **"Borrower Accounts"** on the admin sidebar.
  2. Highlight the accounts grid: User ID, Username, Linked Borrower Name, Role, Account Status (`Active` / `Inactive`), and Account Creation Date.
  3. **Security Highlight:** Point out that password hashes are strictly excluded from the grid display — passwords are never exposed in memory or UI.
  4. Demonstrate the **Soft-Delete Architecture**:
     * Select an account and click **"Deactivate Account"**.
     * Confirm the dialog: observe how the status flips from green `Active` to red `Inactive`.
     * Explain that `tbl_Users.IsActive` is set to `0`. Historical loans and payment vouchers remain 100% intact because relational foreign keys are never broken by hard deletes.
  5. Click **"Edit Account"** to showcase [EditAccountForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/EditAccountForm.vb) for administrative username adjustments or credential resets.
* **🗣️ Verbal Script:**
  > *"Under Borrower Accounts, administrators oversee system credentials without compromising user privacy.
  >
  > *Critically, LMSAP implements a **non-destructive soft-delete pattern**: deactivating an account simply flags `IsActive = 0`. This locks out the client from logging in while preserving every historical loan, ledger entry, and payment voucher for financial auditing."*

---

### Step 14: Administrator Security Settings & Dynamic In-Memory Session Synchronization
* **Screen Display:** [AdminAccountSettingsForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/AdminAccountSettingsForm.vb)
* **Estimated Time:** 0.5 minute
* **Screen Action:**
  1. Click **"Account Settings"** on the admin sidebar.
  2. Showcase the three administrative security maintenance panels:
     * **Update Username:** Demonstrates updating admin credentials. Explain how changing the username dynamically updates [SessionManager.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Helpers/SessionManager.vb) and refreshes the dashboard topbar welcome label (`lblWelcome`) immediately without requiring a logout.
     * **Change Password:** Requires current password BCrypt verification before hashing the new credential.
     * **Security Question & Answer:** Updating recovery challenges.
* **🗣️ Verbal Script:**
  > *"In `AdminAccountSettingsForm`, administrators can update their login credentials and security recovery settings.
  >
  > *If an administrator updates their username, the change immediately synchronizes with `SessionManager`, dynamically refreshing all open UI headers across the application without requiring a disruptive system restart."*

---

### Step 15: Interactive Built-in System Manual & Multi-Tier Operational Knowledgebase
* **Screen Display:** [SystemManualForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/SystemManualForm.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Click **"System Manual"** on either the Admin or Borrower navigation bar.
  2. Showcase the interactive, tabbed documentation center:
     * **Tab 1: Overview & Architecture** — High-level platform purpose, institutional workflows, and role breakdown.
     * **Tab 2: Borrower Guide** — End-to-end instructions on filing applications, monitoring status, and account maintenance.
     * **Tab 3: Administrator Operations** — Operational workflows for KYC borrower registration, loan review, payment collection, and user governance.
     * **Tab 4: Financial Formulas & Calculation Engine** — Full mathematical documentation of Principal, Annual Interest Rate, Total Payable, Monthly Amortization, and Balance Reduction algorithms.
     * **Tab 5: Frequently Asked Questions & Troubleshooting** — Solutions for forgotten passwords, multiple loan policies, and branch contact procedures.
* **🗣️ Verbal Script:**
  > *"To ensure seamless user onboarding and field adoption, we integrated a comprehensive **Interactive System Manual** directly inside the application.
  >
  > *Staff and borrowers do not need to locate physical binder manuals. The built-in documentation details step-by-step procedures, troubleshooting tips, and the complete mathematical formulas driving interest and amortization schedules."*

---

### Step 16: Development Team Attribution & Institutional Contributions
* **Screen Display:** [DevelopersForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DevelopersForm.vb)
* **Estimated Time:** 0.5 minute
* **Screen Action:**
  1. Click **"Developers"** in the sidebar.
  2. Present the developer profile cards with team photographs, roles, program details, contact emails, and project contributions:
     * **Hanna Shane Luis:** *Lead Developer & System Architect* — Responsible for core backend architecture, SQL Server database schema, loan calculation engine, and security management.
     * **Mikayla Ignacio:** *Frontend Developer & UI/UX Specialist* — Responsible for WinForms interface design, ASA brand theme integration, visual analytics dashboard, and system documentation.
* **🗣️ Verbal Script:**
  > *"The Developers module formally attributes the authors of LMSAP:
  >
  > *Our team consists of **Hanna Shane Luis** as Lead Developer and System Architect, and **Mikayla Ignacio** as Frontend Developer and UI/UX Specialist. Together, we designed, developed, and evaluated this system as our BSIT Capstone Project."*

---

### Step 17: Centralized Activity Logging, Audit Trail Verification & Concluding Transition
* **Screen Display:** [ActivityLogger.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ActivityLogger.vb) & Database Query / SSMS Table Inspection
* **Estimated Time:** 0.5 minute
* **Screen Action:**
  1. Explain that every critical action performed during our demonstration — logins, failed brute-force attempts, borrower additions, loan origination, and payment collection — was silently captured by `ActivityLogger.Log()`.
  2. Point out `tbl_ActivityLogs` containing timestamped records: `Username`, `LogDate`, `Result` (`Success`/`Failed`), and `Description`.
  3. Deliver concluding remarks and invite panel questions.
* **🗣️ Verbal Script:**
  > *"To guarantee institutional accountability and financial regulatory compliance, LMSAP routes every transaction through our centralized `ActivityLogger`. Every login, loan creation, payment collection, and account deactivation generates an immutable audit record with precise timestamps.
  >
  > *In conclusion, LMSAP transforms microfinance loan operations from a labor-intensive, error-prone paper workflow into a modern, transparent, and mathematically accurate digital platform for ASA Philippines.
  >
  > *Thank you very much, honorable members of the panel. We are now ready and eager to entertain your questions."*

---

## 🛡️ Capstone Defense Panelist Q&A Cheat Sheet

| Question | Recommended Technical & Institutional Answer |
| :--- | :--- |
| **Q1: Why build a custom desktop application rather than an Excel workbook, Google Sheets, or a web system?** | *"Spreadsheets lack **relational integrity, automated concurrency control, role-based security, and non-repudiation audit trails**. In Excel, any user can accidentally overwrite cell formulas, delete transaction histories, or alter past interest calculations without leaving a trace. Furthermore, spreadsheets cannot enforce strict KYC validations or provide masked password security. While web systems require constant high-speed internet, many ASA Philippines rural branch offices operate in areas with intermittent connectivity. A **.NET 8 WinForms desktop solution** provides zero latency, robust local offline execution, and high security while connecting securely to an enterprise Microsoft SQL Server database."* |
| **Q2: How does the system prevent financial calculation discrepancies and rounding errors across loan terms?** | *"All currency, interest rates, and amortization computations in [LoanRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/LoanRepository.vb) and [PaymentRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/PaymentRepository.vb) utilize the exact 128-bit **`Decimal` data type** (`CDec()`) rather than binary floating-point types (`Single` or `Double`). In SQL Server, fields are defined as `DECIMAL(18,2)`. This completely eliminates binary floating-point rounding errors. Formulas for total payable: $\text{Principal} \times (1 + \text{Rate}/100)$ and monthly due: $\text{TotalPayable} / \text{Term}$ are centralized in our data access layers, ensuring identical calculations across all forms."* |
| **Q3: How are passwords protected against cracking and database leaks?** | *"We employ industry-standard **BCrypt.Net-Next** with a cost factor (work factor) of 11 in [PasswordHelper.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Helpers/PasswordHelper.vb). BCrypt incorporates an automatic random 128-bit salt and computationally expensive key derivation, rendering rainbow table attacks and GPU-accelerated hash cracking infeasible. Furthermore, passwords are never stored in plain text, are omitted entirely from grid queries in [BorrowerAccountsForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/BorrowerAccountsForm.vb), and are masked on the login form."* |
| **Q4: How does the system defend against brute-force login attacks?** | *"In [Form1.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/Form1.vb), LMSAP implements an automated **Lockout Governor**: failed attempts are tracked in memory (`_failedAttempts`). If an attacker inputs incorrect credentials three consecutive times, the system triggers a 15-second lockout timer, completely disabling the login button and displaying a live countdown. Simultaneously, `ActivityLogger.Log()` registers the failed attempt and username for security auditing."* |
| **Q5: How does borrower account provisioning work, and how is data integrity maintained?** | *"In [NewBorrowerForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/NewBorrowerForm.vb), adding a borrower does not require manual user creation by an IT admin. The method `BorrowerRepository.InsertWithUser()` executes within a **SQL transaction**: it generates the user account in `tbl_Users` with role `'Borrower'` and hashed default password (`Password@1`), retrieves the generated `UserID`, and inserts the profile into `tbl_Borrowers` with foreign key linkage. If either operation fails, the transaction rolls back, preventing orphaned records."* |
| **Q6: Why use soft-deletes (`IsActive = 0`) instead of hard SQL `DELETE` for borrower accounts?** | *"In financial systems, hard deletes are strictly avoided because they violate accounting integrity and regulatory compliance. If an account were deleted via `DELETE FROM tbl_Users`, foreign key constraints would either throw errors or cascade-delete all historical loans, amortization schedules, and payment vouchers. With **soft-deletion** in [UserRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/UserRepository.vb), setting `IsActive = 0` revokes login permissions immediately while keeping all financial ledgers 100% intact for audits."* |
| **Q7: How does the system handle borrower Valid ID image verification?** | *"In [NewBorrowerForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/NewBorrowerForm.vb), loan officers upload image or PDF proof of identity, storing the validated file path in `tbl_Borrowers.IDImagePath`. In [ViewBorrowerForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/ViewBorrowerForm.vb), the application renders an inline preview. When the officer clicks **'View Full ID'**, a high-resolution zoom viewer modal launches, allowing officers to inspect details without distorting the main window layout."* |
| **Q8: How are real-time balance calculations handled during payment collection?** | *"In [PaymentRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/PaymentRepository.vb), the function `GetLoanPaymentSummary()` computes the active financial state dynamically using SQL aggregate subqueries: $\text{RemainingBalance} = \text{TotalPayable} - \sum(\text{PaidAmounts})$. In [NewPaymentForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/NewPaymentForm.vb), client-side text change events calculate a live preview: subtracting the newly entered installment from current balance so the loan officer can confirm the expected remaining balance before clicking save."* |
| **Q9: How are SQL injection attacks prevented?** | *"Across all repositories ([UserRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/UserRepository.vb), [BorrowerRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/BorrowerRepository.vb), [LoanRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/LoanRepository.vb), and [PaymentRepository.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/DataAccess/PaymentRepository.vb)), queries are executed strictly through **parameterized SQL commands** (`cmd.Parameters.AddWithValue`). Parameter values are treated strictly as data literals by SQL Server, never as executable SQL code, completely neutralizing SQL injection vulnerabilities."* |
| **Q10: How scalable is LMSAP for deployment across hundreds of ASA Philippines branch offices?** | *"LMSAP is structured with clean separation between UI forms, business repositories, and database configuration. Connection strings are isolated in [`config.txt`](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/config.txt.example). The database can be hosted on a local branch SQL Server or centralized on an enterprise Microsoft Azure SQL instance. Furthermore, branch identifiers can be partitioned seamlessly without altering the core loan calculation and repayment engine."* |

---

## 💡 Pro-Tips for Defense Day

1. **Dual-Instance Live Synchronization Demo**:
   * Open **Instance 1** on the left side of the screen logged in as **Admin**.
   * Open **Instance 2** on the right side of the screen logged in as **Borrower Maria Santos** (`brw0001`).
   * Submit a loan application on the Borrower side, then click Refresh on the Admin Dashboard to show the *Pending Applications* counter increase in real time. Panels love seeing live cross-role workflow interactions!
2. **Highlight Local ASA Philippines Microfinance Grounding**:
   * Ground every feature in real microfinance scenarios: explain how micro-entrepreneurs running neighborhood sari-sari stores, vegetable stalls, or bakeries rely on weekly or monthly microloans, and how paper ledger errors can harm both the borrower's credit standing and the NGO's recovery rate.
3. **Showcase the GDI+ Visual Analytics Dashboard**:
   * Emphasize during Step 5 that the Donut Chart, Type Comparison Bar Chart, and Repayment Efficiency Gauge in [AdminOverviewForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/AdminOverviewForm.vb) are custom-engineered using .NET GDI+ with anti-aliasing. Demonstrating custom rendering shows deep technical mastery of the .NET framework.
4. **Demonstrate Live Input Trapping & Validation**:
   * Intentionally type letters in the Contact Number box in [NewBorrowerForm.vb](file:///C:/Users/GLENN/source/repos/LMSAP-Loan-Management-System-ASA-Phil/LMS_ASA/NewBorrowerForm.vb) to show how the KeyPress filter rejects non-numeric input. Change the birthdate picker to show the age label computing automatically.
5. **Ensure Offline Readiness**:
   * Verify your SQL Server service (`MSSQLSERVER` or `SQLEXPRESS`) is running in Windows Services before entering the defense venue. Because LMSAP is a standalone .NET 8 WinForms application with zero cloud runtime dependencies, your defense presentation can be delivered flawlessly even without campus Wi-Fi or internet access.
