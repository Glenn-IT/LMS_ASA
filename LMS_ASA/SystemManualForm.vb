Public Class SystemManualForm
    Inherits Form

    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlDividerTop As Panel
    Private pnlNav As Panel
    Private pnlBody As Panel

    ' Navigation Tabs
    Private btnTabOverview As Button
    Private btnTabBorrower As Button
    Private btnTabAdmin As Button
    Private btnTabFormulas As Button
    Private btnTabFaq As Button

    Private activeTabBtn As Button = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlDividerTop = New Panel()
        pnlNav = New Panel()
        pnlBody = New Panel()

        btnTabOverview = New Button()
        btnTabBorrower = New Button()
        btnTabAdmin = New Button()
        btnTabFormulas = New Button()
        btnTabFaq = New Button()

        SuspendLayout()

        ' ── Header Panel ──────────────────────────────────────────────
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        lblTitle.Text = "System Manual & Documentation"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        lblSubtitle.Text = "Step-by-step user guide, administrative workflows, and calculation rules"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(500, 18)
        lblSubtitle.Location = New Point(16, 40)

        ' ── Nav Bar (Tabs) ─────────────────────────────────────────────
        pnlNav.BackColor = Color.FromArgb(235, 240, 246)
        pnlNav.Dock = DockStyle.Top
        pnlNav.Height = 44
        pnlNav.Padding = New Padding(16, 4, 16, 0)

        ConfigureTabButton(btnTabOverview, "1. Overview & Roles", 0)
        ConfigureTabButton(btnTabBorrower, "2. Borrower Guide", 180)
        ConfigureTabButton(btnTabAdmin, "3. Admin Guide", 360)
        ConfigureTabButton(btnTabFormulas, "4. Loan Formulas", 540)
        ConfigureTabButton(btnTabFaq, "5. FAQ & Troubleshooting", 720)

        AddHandler btnTabOverview.Click, Sub(s, e) ShowTab(btnTabOverview, AddressOf LoadOverviewSection)
        AddHandler btnTabBorrower.Click, Sub(s, e) ShowTab(btnTabBorrower, AddressOf LoadBorrowerSection)
        AddHandler btnTabAdmin.Click, Sub(s, e) ShowTab(btnTabAdmin, AddressOf LoadAdminSection)
        AddHandler btnTabFormulas.Click, Sub(s, e) ShowTab(btnTabFormulas, AddressOf LoadFormulasSection)
        AddHandler btnTabFaq.Click, Sub(s, e) ShowTab(btnTabFaq, AddressOf LoadFaqSection)

        pnlNav.Controls.Add(btnTabFaq)
        pnlNav.Controls.Add(btnTabFormulas)
        pnlNav.Controls.Add(btnTabAdmin)
        pnlNav.Controls.Add(btnTabBorrower)
        pnlNav.Controls.Add(btnTabOverview)

        ' ── Top Divider ───────────────────────────────────────────────
        pnlDividerTop.BackColor = Color.FromArgb(215, 222, 230)
        pnlDividerTop.Dock = DockStyle.Top
        pnlDividerTop.Height = 1

        ' ── Body (Scrollable Container) ──────────────────────────────
        pnlBody.BackColor = Color.FromArgb(245, 247, 250)
        pnlBody.Dock = DockStyle.Fill
        pnlBody.Padding = New Padding(20)
        pnlBody.AutoScroll = True

        ' ── Form Assembly ─────────────────────────────────────────────
        Controls.Add(pnlBody)
        Controls.Add(pnlDividerTop)
        Controls.Add(pnlNav)
        Controls.Add(pnlHeader)
        BackColor = Color.FromArgb(245, 247, 250)
        ClientSize = New Size(950, 620)
        Name = "SystemManualForm"
        Text = "System Manual"

        ResumeLayout(False)

        ' Show initial tab
        ShowTab(btnTabOverview, AddressOf LoadOverviewSection)
    End Sub

    Private Sub ConfigureTabButton(btn As Button, text As String, xPos As Integer)
        btn.Text = text
        btn.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        btn.ForeColor = Color.FromArgb(70, 80, 95)
        btn.BackColor = Color.Transparent
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Size = New Size(170, 38)
        btn.Location = New Point(16 + xPos, 4)
        btn.Cursor = Cursors.Hand
    End Sub

    Private Sub ShowTab(btn As Button, loadAction As Action)
        Dim allBtns As Button() = {btnTabOverview, btnTabBorrower, btnTabAdmin, btnTabFormulas, btnTabFaq}
        For Each b In allBtns
            b.BackColor = Color.Transparent
            b.ForeColor = Color.FromArgb(70, 80, 95)
            b.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        Next
        btn.BackColor = Color.White
        btn.ForeColor = Color.FromArgb(21, 67, 106)
        btn.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        activeTabBtn = btn

        pnlBody.Controls.Clear()
        pnlBody.SuspendLayout()
        loadAction.Invoke()
        pnlBody.ResumeLayout(True)
    End Sub

    ' ═════════════════════════════════════════════════════════════════════
    ' SECTIONS CONTENT
    ' ═════════════════════════════════════════════════════════════════════

    Private Sub LoadOverviewSection()
        Dim pnlCard As Panel = CreateContentCard("1. System Overview & Architecture", 860, 480)

        Dim content As String =
            "Welcome to the Loan Management System (LMS-ASA)!" & vbCrLf & vbCrLf &
            "The LMS-ASA software platform is designed to automate and streamline the microfinance loan process for ASA Philippines. It eliminates manual ledger errors, enforces structured credit workflows, tracks repayment schedules, and provides comprehensive accountability through audit logging." & vbCrLf & vbCrLf &
            "KEY USER ROLES:" & vbCrLf &
            "• Borrower Role:" & vbCrLf &
            "   - Can file online loan applications for Micro-Business, Agricultural, Educational, and Emergency loans." & vbCrLf &
            "   - Can track the real-time review status of submitted loan applications." & vbCrLf &
            "   - Can view account details, change passwords, and update security questions." & vbCrLf & vbCrLf &
            "• Administrator Role:" & vbCrLf &
            "   - Full visibility and control over all Borrower Profiles and Accounts." & vbCrLf &
            "   - Review, approve, or reject incoming loan applications with automatic balance scheduling." & vbCrLf &
            "   - Record loan repayments, track balance reductions, and inspect transaction histories." & vbCrLf &
            "   - System configuration, administrator password updates, and real-time security audit trails." & vbCrLf & vbCrLf &
            "SECURITY & AUTHENTICATION:" & vbCrLf &
            "• Passwords are protected using cryptographic SHA-256 hashing." & vbCrLf &
            "• Session state prevents unauthorized cross-role access." & vbCrLf &
            "• Security questions enable self-service password resets from the login screen."

        AddContentLabel(pnlCard, content, 20, 20, 820, 440)
        pnlBody.Controls.Add(pnlCard)
    End Sub

    Private Sub LoadBorrowerSection()
        Dim pnlCard As Panel = CreateContentCard("2. Borrower User Guide", 860, 520)

        Dim content As String =
            "HOW TO USE THE BORROWER PORTAL:" & vbCrLf & vbCrLf &
            "1. Filing a Loan Application:" & vbCrLf &
            "   • Navigate to 'File Loan Application' in the left sidebar." & vbCrLf &
            "   • Select your Loan Type (e.g. Micro-Business Loan, Agricultural Loan, Educational Loan)." & vbCrLf &
            "   • Enter the Principal Amount (PHP) and desired Term in months." & vbCrLf &
            "   • The interest rate and total payable amount will automatically compute." & vbCrLf &
            "   • Review the Release Date and Due Date, then click 'Submit Application'." & vbCrLf & vbCrLf &
            "2. Tracking Your Loan Status:" & vbCrLf &
            "   • Click 'Track Loan Application' to view all your past and active applications." & vbCrLf &
            "   • Status Indicators:" & vbCrLf &
            "     - PENDING: Your application is under review by loan officers." & vbCrLf &
            "     - APPROVED: Your application has been approved and disbursed." & vbCrLf &
            "     - REJECTED: Your application did not meet the criteria. Contact admin for details." & vbCrLf &
            "     - FULLY PAID: All scheduled amortizations have been satisfied." & vbCrLf & vbCrLf &
            "3. Updating Security & Account Information:" & vbCrLf &
            "   • Click 'My Account' to update your password or change your security question." & vbCrLf &
            "   • Make sure to remember your security question answer for account recovery."

        AddContentLabel(pnlCard, content, 20, 20, 820, 480)
        pnlBody.Controls.Add(pnlCard)
    End Sub

    Private Sub LoadAdminSection()
        Dim pnlCard As Panel = CreateContentCard("3. Administrator Guide & Operations", 860, 540)

        Dim content As String =
            "ADMINISTRATOR OPERATIONAL WORKFLOW:" & vbCrLf & vbCrLf &
            "1. Loan Application Review (Loan List):" & vbCrLf &
            "   • Open 'Loan List' from the admin sidebar." & vbCrLf &
            "   • Review applicant details, loan amount, terms, and interest rate." & vbCrLf &
            "   • Select an application to Approve or Reject. Approving automatically generates active repayment schedules." & vbCrLf & vbCrLf &
            "2. Managing Borrowers (Borrower List):" & vbCrLf &
            "   • Register new borrowers with full personal and contact details." & vbCrLf &
            "   • View individual borrower profiles, total loans availed, and active repayment records." & vbCrLf & vbCrLf &
            "3. Processing Repayments (Payment List):" & vbCrLf &
            "   • Click 'Payment List' to view collection transactions." & vbCrLf &
            "   • Record new payments by selecting the loan account and entering the payment amount." & vbCrLf &
            "   • The system automatically recalculates outstanding balance and marks fully paid loans." & vbCrLf & vbCrLf &
            "4. Managing Borrower Accounts & Security Settings:" & vbCrLf &
            "   • Use 'Borrower Accounts' to monitor usernames, reset passwords, or enable/disable accounts." & vbCrLf &
            "   • Use 'Account Settings' to update administrator credentials and security preferences."

        AddContentLabel(pnlCard, content, 20, 20, 820, 500)
        pnlBody.Controls.Add(pnlCard)
    End Sub

    Private Sub LoadFormulasSection()
        Dim pnlCard As Panel = CreateContentCard("4. Loan Formulas & Calculation Engine", 860, 480)

        Dim content As String =
            "FINANCIAL CALCULATION SPECIFICATIONS:" & vbCrLf & vbCrLf &
            "1. Total Interest Calculation:" & vbCrLf &
            "   Total Interest = Principal Amount × (Annual Interest Rate % / 100)" & vbCrLf & vbCrLf &
            "2. Total Payable Amount:" & vbCrLf &
            "   Total Payable = Principal Amount + Total Interest" & vbCrLf &
            "   Formula: Total Payable = Principal × (1 + (Rate / 100))" & vbCrLf & vbCrLf &
            "3. Monthly Amortization Schedule:" & vbCrLf &
            "   Monthly Due = Total Payable / Term in Months" & vbCrLf & vbCrLf &
            "4. Outstanding Balance Reduction:" & vbCrLf &
            "   Remaining Balance = Total Payable - Total Payments Received" & vbCrLf & vbCrLf &
            "EXAMPLE CALCULATION:" & vbCrLf &
            "• Principal: PHP 10,000.00 | Interest Rate: 5% | Term: 5 Months" & vbCrLf &
            "• Total Interest = PHP 500.00" & vbCrLf &
            "• Total Payable = PHP 10,500.00" & vbCrLf &
            "• Monthly Amortization = PHP 2,100.00 / month for 5 months"

        AddContentLabel(pnlCard, content, 20, 20, 820, 440)
        pnlBody.Controls.Add(pnlCard)
    End Sub

    Private Sub LoadFaqSection()
        Dim pnlCard As Panel = CreateContentCard("5. Frequently Asked Questions & Troubleshooting", 860, 480)

        Dim content As String =
            "FREQUENTLY ASKED QUESTIONS:" & vbCrLf & vbCrLf &
            "Q: What should I do if I forgot my password?" & vbCrLf &
            "A: On the login screen, click 'Forgot Password?'. Enter your username and answer your configured security question to create a new password." & vbCrLf & vbCrLf &
            "Q: Can a borrower submit multiple loan applications simultaneously?" & vbCrLf &
            "A: Yes, however approval depends on administrative credit assessment and active balance status." & vbCrLf & vbCrLf &
            "Q: How is an approved loan disbursed?" & vbCrLf &
            "A: Once marked Approved by Admin, disbursement is finalized according to ASA microfinance branch procedures." & vbCrLf & vbCrLf &
            "Q: Who should I contact for technical or account support?" & vbCrLf &
            "A: Check the 'Developers' tab for technical team details or contact your local ASA Philippines branch coordinator."

        AddContentLabel(pnlCard, content, 20, 20, 820, 440)
        pnlBody.Controls.Add(pnlCard)
    End Sub

    Private Function CreateContentCard(headerText As String, width As Integer, height As Integer) As Panel
        Dim card As New Panel()
        card.BackColor = Color.White
        card.BorderStyle = BorderStyle.FixedSingle
        card.Size = New Size(width, height)
        card.Location = New Point(20, 16)
        card.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        Dim lblHead As New Label()
        lblHead.Text = headerText
        lblHead.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblHead.ForeColor = Color.FromArgb(21, 67, 106)
        lblHead.Location = New Point(20, 16)
        lblHead.AutoSize = True
        card.Controls.Add(lblHead)

        Dim div As New Panel()
        div.BackColor = Color.FromArgb(230, 235, 242)
        div.Size = New Size(width - 40, 1)
        div.Location = New Point(20, 48)
        div.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        card.Controls.Add(div)

        Return card
    End Function

    Private Sub AddContentLabel(parent As Panel, text As String, x As Integer, y As Integer, w As Integer, h As Integer)
        Dim lbl As New Label()
        lbl.Text = text
        lbl.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular)
        lbl.ForeColor = Color.FromArgb(50, 60, 75)
        lbl.Location = New Point(x, y + 40)
        lbl.Size = New Size(w, h)
        lbl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        parent.Controls.Add(lbl)
    End Sub

End Class
