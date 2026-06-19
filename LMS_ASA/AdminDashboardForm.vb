Public Class AdminDashboardForm
    Inherits Form

    ' ?? Controls ??????????????????????????????????????????????????
    Private pnlSidebar As Panel
    Private pnlSidebarHeader As Panel
    Private lblSidebarTitle As Label
    Private lblSidebarSub As Label
    Private pnlSidebarDivider As Panel
    Friend WithEvents btnLoanList As Button
    Friend WithEvents btnBorrowerList As Button
    Friend WithEvents btnPaymentList As Button
    Friend WithEvents btnBorrowerAccounts As Button
    Friend WithEvents btnAccountSettings As Button
    Private pnlSidebarFooter As Panel
    Friend WithEvents btnLogout As Button
    Private pnlMain As Panel
    Private pnlTopBar As Panel
    Private lblPageTitle As Label
    Private lblWelcome As Label
    Private pnlContent As Panel
    Friend WithEvents Panel1 As Panel
    Private WithEvents Label1 As Label
    Private WithEvents Label2 As Label
    Private lblPlaceholder As Label

    Private WithEvents _clockTimer As New Timer() With {.Interval = 1000}

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        pnlSidebar = New Panel()
        pnlSidebarFooter = New Panel()
        btnLogout = New Button()
        btnBorrowerAccounts = New Button()
        btnAccountSettings = New Button()
        btnPaymentList = New Button()
        btnBorrowerList = New Button()
        btnLoanList = New Button()
        pnlSidebarDivider = New Panel()
        pnlSidebarHeader = New Panel()
        lblSidebarSub = New Label()
        lblSidebarTitle = New Label()
        pnlMain = New Panel()
        pnlContent = New Panel()
        lblPlaceholder = New Label()
        pnlTopBar = New Panel()
        Panel1 = New Panel()
        Label2 = New Label()
        Label1 = New Label()
        lblWelcome = New Label()
        lblPageTitle = New Label()
        pnlSidebar.SuspendLayout()
        pnlSidebarFooter.SuspendLayout()
        pnlSidebarHeader.SuspendLayout()
        pnlMain.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlTopBar.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        pnlSidebar.Controls.Add(pnlSidebarFooter)
        pnlSidebar.Controls.Add(btnAccountSettings)
        pnlSidebar.Controls.Add(btnBorrowerAccounts)
        pnlSidebar.Controls.Add(btnPaymentList)
        pnlSidebar.Controls.Add(btnBorrowerList)
        pnlSidebar.Controls.Add(btnLoanList)
        pnlSidebar.Controls.Add(pnlSidebarDivider)
        pnlSidebar.Controls.Add(pnlSidebarHeader)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(220, 620)
        pnlSidebar.TabIndex = 1
        ' 
        ' pnlSidebarFooter
        ' 
        pnlSidebarFooter.BackColor = Color.FromArgb(CByte(15), CByte(52), CByte(86))
        pnlSidebarFooter.Controls.Add(btnLogout)
        pnlSidebarFooter.Dock = DockStyle.Bottom
        pnlSidebarFooter.Location = New Point(0, 564)
        pnlSidebarFooter.Name = "pnlSidebarFooter"
        pnlSidebarFooter.Size = New Size(220, 56)
        pnlSidebarFooter.TabIndex = 0
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.Transparent
        btnLogout.Cursor = Cursors.Hand
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(180), CByte(50), CByte(50))
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 10.0F)
        btnLogout.ForeColor = Color.FromArgb(CByte(255), CByte(180), CByte(180))
        btnLogout.Location = New Point(0, 4)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(220, 48)
        btnLogout.TabIndex = 0
        btnLogout.Text = "   Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnBorrowerAccounts
        ' 
        btnBorrowerAccounts.BackColor = Color.Transparent
        btnBorrowerAccounts.Cursor = Cursors.Hand
        btnBorrowerAccounts.FlatAppearance.BorderSize = 0
        btnBorrowerAccounts.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(30), CByte(95), CByte(150))
        btnBorrowerAccounts.FlatStyle = FlatStyle.Flat
        btnBorrowerAccounts.Font = New Font("Segoe UI", 10.0F)
        btnBorrowerAccounts.ForeColor = Color.FromArgb(CByte(200), CByte(230), CByte(255))
        btnBorrowerAccounts.Location = New Point(0, 254)
        btnBorrowerAccounts.Name = "btnBorrowerAccounts"
        btnBorrowerAccounts.Size = New Size(220, 48)
        btnBorrowerAccounts.TabIndex = 1
        btnBorrowerAccounts.Text = "   Borrower Accounts"
        btnBorrowerAccounts.TextAlign = ContentAlignment.MiddleLeft
        btnBorrowerAccounts.UseVisualStyleBackColor = False
        '
        ' btnAccountSettings
        '
        btnAccountSettings.BackColor = Color.Transparent
        btnAccountSettings.Cursor = Cursors.Hand
        btnAccountSettings.FlatAppearance.BorderSize = 0
        btnAccountSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(30), CByte(95), CByte(150))
        btnAccountSettings.FlatStyle = FlatStyle.Flat
        btnAccountSettings.Font = New Font("Segoe UI", 10.0F)
        btnAccountSettings.ForeColor = Color.FromArgb(CByte(200), CByte(230), CByte(255))
        btnAccountSettings.Location = New Point(0, 302)
        btnAccountSettings.Name = "btnAccountSettings"
        btnAccountSettings.Size = New Size(220, 48)
        btnAccountSettings.TabIndex = 1
        btnAccountSettings.Text = "   Account Settings"
        btnAccountSettings.TextAlign = ContentAlignment.MiddleLeft
        btnAccountSettings.UseVisualStyleBackColor = False
        '
        ' btnPaymentList
        ' 
        btnPaymentList.BackColor = Color.Transparent
        btnPaymentList.Cursor = Cursors.Hand
        btnPaymentList.FlatAppearance.BorderSize = 0
        btnPaymentList.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(30), CByte(95), CByte(150))
        btnPaymentList.FlatStyle = FlatStyle.Flat
        btnPaymentList.Font = New Font("Segoe UI", 10.0F)
        btnPaymentList.ForeColor = Color.FromArgb(CByte(200), CByte(230), CByte(255))
        btnPaymentList.Location = New Point(0, 206)
        btnPaymentList.Name = "btnPaymentList"
        btnPaymentList.Size = New Size(220, 48)
        btnPaymentList.TabIndex = 2
        btnPaymentList.Text = "   Payment List"
        btnPaymentList.TextAlign = ContentAlignment.MiddleLeft
        btnPaymentList.UseVisualStyleBackColor = False
        ' 
        ' btnBorrowerList
        ' 
        btnBorrowerList.BackColor = Color.Transparent
        btnBorrowerList.Cursor = Cursors.Hand
        btnBorrowerList.FlatAppearance.BorderSize = 0
        btnBorrowerList.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(30), CByte(95), CByte(150))
        btnBorrowerList.FlatStyle = FlatStyle.Flat
        btnBorrowerList.Font = New Font("Segoe UI", 10.0F)
        btnBorrowerList.ForeColor = Color.FromArgb(CByte(200), CByte(230), CByte(255))
        btnBorrowerList.Location = New Point(0, 158)
        btnBorrowerList.Name = "btnBorrowerList"
        btnBorrowerList.Size = New Size(220, 48)
        btnBorrowerList.TabIndex = 3
        btnBorrowerList.Text = "   Borrower List"
        btnBorrowerList.TextAlign = ContentAlignment.MiddleLeft
        btnBorrowerList.UseVisualStyleBackColor = False
        ' 
        ' btnLoanList
        ' 
        btnLoanList.BackColor = Color.Transparent
        btnLoanList.Cursor = Cursors.Hand
        btnLoanList.FlatAppearance.BorderSize = 0
        btnLoanList.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(30), CByte(95), CByte(150))
        btnLoanList.FlatStyle = FlatStyle.Flat
        btnLoanList.Font = New Font("Segoe UI", 10.0F)
        btnLoanList.ForeColor = Color.FromArgb(CByte(200), CByte(230), CByte(255))
        btnLoanList.Location = New Point(0, 110)
        btnLoanList.Name = "btnLoanList"
        btnLoanList.Size = New Size(220, 48)
        btnLoanList.TabIndex = 4
        btnLoanList.Text = "   Loan List"
        btnLoanList.TextAlign = ContentAlignment.MiddleLeft
        btnLoanList.UseVisualStyleBackColor = False
        ' 
        ' pnlSidebarDivider
        ' 
        pnlSidebarDivider.BackColor = Color.FromArgb(CByte(40), CByte(90), CByte(130))
        pnlSidebarDivider.Dock = DockStyle.Top
        pnlSidebarDivider.Location = New Point(0, 100)
        pnlSidebarDivider.Name = "pnlSidebarDivider"
        pnlSidebarDivider.Size = New Size(220, 1)
        pnlSidebarDivider.TabIndex = 5
        ' 
        ' pnlSidebarHeader
        ' 
        pnlSidebarHeader.BackColor = Color.FromArgb(CByte(15), CByte(52), CByte(86))
        pnlSidebarHeader.Controls.Add(lblSidebarSub)
        pnlSidebarHeader.Controls.Add(lblSidebarTitle)
        pnlSidebarHeader.Dock = DockStyle.Top
        pnlSidebarHeader.Location = New Point(0, 0)
        pnlSidebarHeader.Name = "pnlSidebarHeader"
        pnlSidebarHeader.Size = New Size(220, 100)
        pnlSidebarHeader.TabIndex = 6
        '
        ' lblSidebarSub — live date
        '
        lblSidebarSub.Font = New Font("Segoe UI", 9.0F)
        lblSidebarSub.ForeColor = Color.FromArgb(CByte(173), CByte(216), CByte(255))
        lblSidebarSub.Location = New Point(10, 64)
        lblSidebarSub.Name = "lblSidebarSub"
        lblSidebarSub.Size = New Size(200, 20)
        lblSidebarSub.TabIndex = 0
        lblSidebarSub.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")
        lblSidebarSub.TextAlign = ContentAlignment.MiddleCenter
        lblSidebarSub.Visible = True
        '
        ' lblSidebarTitle — live time
        '
        lblSidebarTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblSidebarTitle.ForeColor = Color.White
        lblSidebarTitle.Location = New Point(10, 18)
        lblSidebarTitle.Name = "lblSidebarTitle"
        lblSidebarTitle.Size = New Size(200, 40)
        lblSidebarTitle.TabIndex = 1
        lblSidebarTitle.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblSidebarTitle.TextAlign = ContentAlignment.MiddleCenter
        lblSidebarTitle.Visible = True
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlMain.Controls.Add(pnlContent)
        pnlMain.Controls.Add(pnlTopBar)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(220, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(780, 620)
        pnlMain.TabIndex = 0
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlContent.Controls.Add(lblPlaceholder)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(0, 101)
        pnlContent.Name = "pnlContent"
        pnlContent.Padding = New Padding(20)
        pnlContent.Size = New Size(780, 519)
        pnlContent.TabIndex = 0
        ' 
        ' lblPlaceholder
        ' 
        lblPlaceholder.Dock = DockStyle.Fill
        lblPlaceholder.Font = New Font("Segoe UI", 11.0F)
        lblPlaceholder.ForeColor = Color.FromArgb(CByte(160), CByte(170), CByte(185))
        lblPlaceholder.Location = New Point(20, 20)
        lblPlaceholder.Name = "lblPlaceholder"
        lblPlaceholder.Size = New Size(740, 479)
        lblPlaceholder.TabIndex = 0
        lblPlaceholder.Text = "Information About LMS" & vbCrLf
        lblPlaceholder.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlTopBar
        ' 
        pnlTopBar.BackColor = Color.White
        pnlTopBar.Controls.Add(Panel1)
        pnlTopBar.Controls.Add(lblWelcome)
        pnlTopBar.Controls.Add(lblPageTitle)
        pnlTopBar.Dock = DockStyle.Top
        pnlTopBar.Location = New Point(0, 0)
        pnlTopBar.Name = "pnlTopBar"
        pnlTopBar.Size = New Size(780, 101)
        pnlTopBar.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(780, 99)
        Panel1.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.White
        Label2.Font = New Font("Segoe UI", 11.0F)
        Label2.ForeColor = Color.FromArgb(CByte(15), CByte(52), CByte(86))
        Label2.Location = New Point(6, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(308, 38)
        Label2.TabIndex = 3
        Label2.Text = "ASA Philippines Foundation, Inc."
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.White
        Label1.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        Label1.ForeColor = Color.FromArgb(CByte(15), CByte(52), CByte(86))
        Label1.Location = New Point(6, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(308, 38)
        Label1.TabIndex = 2
        Label1.Text = "Loan Management System"
        ' 
        ' lblWelcome
        ' 
        lblWelcome.Font = New Font("Segoe UI", 9.0F)
        lblWelcome.ForeColor = Color.Gray
        lblWelcome.Location = New Point(20, 40)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(200, 20)
        lblWelcome.TabIndex = 0
        lblWelcome.Text = "Welcome, Admin"
        ' 
        ' lblPageTitle
        ' 
        lblPageTitle.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblPageTitle.ForeColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        lblPageTitle.Location = New Point(20, 14)
        lblPageTitle.Name = "lblPageTitle"
        lblPageTitle.Size = New Size(400, 36)
        lblPageTitle.TabIndex = 1
        lblPageTitle.Text = "Admin Dashboard"
        ' 
        ' AdminDashboardForm
        ' 
        BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        ClientSize = New Size(1000, 620)
        Controls.Add(pnlMain)
        Controls.Add(pnlSidebar)
        MinimumSize = New Size(900, 580)
        Name = "AdminDashboardForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LMS - Admin Dashboard"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlSidebarFooter.ResumeLayout(False)
        pnlSidebarHeader.ResumeLayout(False)
        pnlMain.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlTopBar.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    ' ── Form Load ─────────────────────────────────────────────────
    Private Sub AdminDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = $"Welcome, {SessionManager.CurrentUsername}!"
        UpdateClock()
        _clockTimer.Start()
        SetActiveButton(btnLoanList)
    End Sub

    Private Sub UpdateClock()
        lblSidebarTitle.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblSidebarSub.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")
    End Sub

    Private Sub _clockTimer_Tick(sender As Object, e As EventArgs) Handles _clockTimer.Tick
        UpdateClock()
    End Sub

    ' ?? Sidebar Navigation ????????????????????????????????????????
    Private Sub btnLoanList_Click(sender As Object, e As EventArgs) Handles btnLoanList.Click
        SetActiveButton(btnLoanList)
        lblPageTitle.Text = "Loan List"
        ' GATE — remove this block when unlocking for v1.05
        LoadGated() : Return
        ' END GATE
        LoadContent(New LoanListForm())
    End Sub

    Private Sub btnBorrowerList_Click(sender As Object, e As EventArgs) Handles btnBorrowerList.Click
        SetActiveButton(btnBorrowerList)
        lblPageTitle.Text = "Borrower List"
        LoadContent(New BorrowerListForm())
    End Sub

    Private Sub btnPaymentList_Click(sender As Object, e As EventArgs) Handles btnPaymentList.Click
        SetActiveButton(btnPaymentList)
        lblPageTitle.Text = "Payment List"
        ' GATE — remove this block when unlocking for v1.06
        LoadGated() : Return
        ' END GATE
        LoadContent(New PaymentListForm())
    End Sub

    Private Sub btnBorrowerAccounts_Click(sender As Object, e As EventArgs) Handles btnBorrowerAccounts.Click
        SetActiveButton(btnBorrowerAccounts)
        lblPageTitle.Text = "Borrower Accounts"
        LoadContent(New BorrowerAccountsForm())
    End Sub

    Private Sub btnAccountSettings_Click(sender As Object, e As EventArgs) Handles btnAccountSettings.Click
        SetActiveButton(btnAccountSettings)
        lblPageTitle.Text = "Account Settings"
        ' GATE — remove this block when unlocking for v1.07
        LoadGated() : Return
        ' END GATE
        LoadContent(New AdminAccountSettingsForm())
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to logout?",
            "Confirm Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return
        _clockTimer.Stop()
        ActivityLogger.Log(SessionManager.CurrentUsername, "Success", "Admin logged out.")
        SessionManager.ClearSession()
        Dim login As New LoginForm()
        login.Show()
        Me.Close()
    End Sub

    ' ?? Helpers ???????????????????????????????????????????????????
    Private Sub LoadContent(frm As Form)
        pnlContent.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        pnlContent.Controls.Add(frm)
        frm.Show()
    End Sub

    Private Sub LoadGated()
        Dim frm As New UnderConstructionForm()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        pnlContent.Controls.Clear()
        pnlContent.Controls.Add(frm)
        frm.Show()
    End Sub

    Private Sub SetActiveButton(activeBtn As Button)
        Dim sidebarBtns As Button() = {btnLoanList, btnBorrowerList, btnPaymentList, btnBorrowerAccounts, btnAccountSettings}
        For Each btn As Button In sidebarBtns
            btn.BackColor = Color.Transparent
            btn.ForeColor = Color.FromArgb(200, 230, 255)
        Next
        activeBtn.BackColor = Color.FromArgb(30, 95, 150)
        activeBtn.ForeColor = Color.White
    End Sub

End Class
