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
    Private pnlSidebarFooter As Panel
    Friend WithEvents btnLogout As Button
    Private pnlMain As Panel
    Private pnlTopBar As Panel
    Private lblPageTitle As Label
    Private lblWelcome As Label
    Private pnlContent As Panel
    Private lblPlaceholder As Label
    Private pnlPlaceholderIcon As Panel

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        pnlSidebar = New Panel()
        pnlSidebarHeader = New Panel()
        lblSidebarTitle = New Label()
        lblSidebarSub = New Label()
        pnlSidebarDivider = New Panel()
        btnLoanList = New Button()
        btnBorrowerList = New Button()
        btnPaymentList = New Button()
        btnBorrowerAccounts = New Button()
        pnlSidebarFooter = New Panel()
        btnLogout = New Button()
        pnlMain = New Panel()
        pnlTopBar = New Panel()
        lblPageTitle = New Label()
        lblWelcome = New Label()
        pnlContent = New Panel()
        lblPlaceholder = New Label()
        pnlPlaceholderIcon = New Panel()

        SuspendLayout()

        ' ?? pnlSidebar ????????????????????????????????????????????
        pnlSidebar.BackColor = Color.FromArgb(21, 67, 106)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Width = 220
        pnlSidebar.Controls.Add(pnlSidebarFooter)
        pnlSidebar.Controls.Add(btnBorrowerAccounts)
        pnlSidebar.Controls.Add(btnPaymentList)
        pnlSidebar.Controls.Add(btnBorrowerList)
        pnlSidebar.Controls.Add(btnLoanList)
        pnlSidebar.Controls.Add(pnlSidebarDivider)
        pnlSidebar.Controls.Add(pnlSidebarHeader)

        ' ?? pnlSidebarHeader ??????????????????????????????????????
        pnlSidebarHeader.BackColor = Color.FromArgb(15, 52, 86)
        pnlSidebarHeader.Dock = DockStyle.Top
        pnlSidebarHeader.Height = 100
        pnlSidebarHeader.Controls.Add(lblSidebarSub)
        pnlSidebarHeader.Controls.Add(lblSidebarTitle)

        ' ?? lblSidebarTitle ???????????????????????????????????????
        lblSidebarTitle.Text = "LMS Admin"
        lblSidebarTitle.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        lblSidebarTitle.ForeColor = Color.White
        lblSidebarTitle.AutoSize = False
        lblSidebarTitle.Size = New Size(200, 30)
        lblSidebarTitle.Location = New Point(12, 28)

        ' ?? lblSidebarSub ?????????????????????????????????????????
        lblSidebarSub.Text = "Administrator"
        lblSidebarSub.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSidebarSub.ForeColor = Color.FromArgb(173, 216, 255)
        lblSidebarSub.AutoSize = False
        lblSidebarSub.Size = New Size(200, 20)
        lblSidebarSub.Location = New Point(12, 60)

        ' ?? pnlSidebarDivider ?????????????????????????????????????
        pnlSidebarDivider.BackColor = Color.FromArgb(40, 90, 130)
        pnlSidebarDivider.Dock = DockStyle.Top
        pnlSidebarDivider.Height = 1

        ' ?? btnLoanList ???????????????????????????????????????????
        btnLoanList.Text = "   Loan List"
        btnLoanList.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnLoanList.ForeColor = Color.FromArgb(200, 230, 255)
        btnLoanList.BackColor = Color.Transparent
        btnLoanList.FlatStyle = FlatStyle.Flat
        btnLoanList.FlatAppearance.BorderSize = 0
        btnLoanList.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 95, 150)
        btnLoanList.TextAlign = ContentAlignment.MiddleLeft
        btnLoanList.Size = New Size(220, 48)
        btnLoanList.Location = New Point(0, 110)
        btnLoanList.Cursor = Cursors.Hand

        ' ?? btnBorrowerList ???????????????????????????????????????
        btnBorrowerList.Text = "   Borrower List"
        btnBorrowerList.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnBorrowerList.ForeColor = Color.FromArgb(200, 230, 255)
        btnBorrowerList.BackColor = Color.Transparent
        btnBorrowerList.FlatStyle = FlatStyle.Flat
        btnBorrowerList.FlatAppearance.BorderSize = 0
        btnBorrowerList.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 95, 150)
        btnBorrowerList.TextAlign = ContentAlignment.MiddleLeft
        btnBorrowerList.Size = New Size(220, 48)
        btnBorrowerList.Location = New Point(0, 158)
        btnBorrowerList.Cursor = Cursors.Hand

        ' ?? btnPaymentList ????????????????????????????????????????
        btnPaymentList.Text = "   Payment List"
        btnPaymentList.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnPaymentList.ForeColor = Color.FromArgb(200, 230, 255)
        btnPaymentList.BackColor = Color.Transparent
        btnPaymentList.FlatStyle = FlatStyle.Flat
        btnPaymentList.FlatAppearance.BorderSize = 0
        btnPaymentList.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 95, 150)
        btnPaymentList.TextAlign = ContentAlignment.MiddleLeft
        btnPaymentList.Size = New Size(220, 48)
        btnPaymentList.Location = New Point(0, 206)
        btnPaymentList.Cursor = Cursors.Hand

        ' ?? btnBorrowerAccounts ???????????????????????????????????
        btnBorrowerAccounts.Text = "   Borrower Accounts"
        btnBorrowerAccounts.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnBorrowerAccounts.ForeColor = Color.FromArgb(200, 230, 255)
        btnBorrowerAccounts.BackColor = Color.Transparent
        btnBorrowerAccounts.FlatStyle = FlatStyle.Flat
        btnBorrowerAccounts.FlatAppearance.BorderSize = 0
        btnBorrowerAccounts.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 95, 150)
        btnBorrowerAccounts.TextAlign = ContentAlignment.MiddleLeft
        btnBorrowerAccounts.Size = New Size(220, 48)
        btnBorrowerAccounts.Location = New Point(0, 254)
        btnBorrowerAccounts.Cursor = Cursors.Hand

        ' ?? pnlSidebarFooter ??????????????????????????????????????
        pnlSidebarFooter.BackColor = Color.FromArgb(15, 52, 86)
        pnlSidebarFooter.Dock = DockStyle.Bottom
        pnlSidebarFooter.Height = 56
        pnlSidebarFooter.Controls.Add(btnLogout)

        ' ?? btnLogout ?????????????????????????????????????????????
        btnLogout.Text = "   Logout"
        btnLogout.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnLogout.ForeColor = Color.FromArgb(255, 180, 180)
        btnLogout.BackColor = Color.Transparent
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 50, 50)
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.Size = New Size(220, 48)
        btnLogout.Location = New Point(0, 4)
        btnLogout.Cursor = Cursors.Hand

        ' ?? pnlMain ???????????????????????????????????????????????
        pnlMain.BackColor = Color.FromArgb(245, 247, 250)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Controls.Add(pnlContent)
        pnlMain.Controls.Add(pnlTopBar)

        ' ?? pnlTopBar ?????????????????????????????????????????????
        pnlTopBar.BackColor = Color.White
        pnlTopBar.Dock = DockStyle.Top
        pnlTopBar.Height = 64
        pnlTopBar.Controls.Add(lblWelcome)
        pnlTopBar.Controls.Add(lblPageTitle)

        ' ?? lblPageTitle ??????????????????????????????????????????
        lblPageTitle.Text = "Admin Dashboard"
        lblPageTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblPageTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblPageTitle.AutoSize = False
        lblPageTitle.Size = New Size(400, 36)
        lblPageTitle.Location = New Point(20, 14)

        ' ?? lblWelcome ????????????????????????????????????????????
        lblWelcome.Text = "Welcome, Admin"
        lblWelcome.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblWelcome.ForeColor = Color.Gray
        lblWelcome.AutoSize = False
        lblWelcome.Size = New Size(200, 20)
        lblWelcome.Location = New Point(20, 40)

        ' ?? pnlContent ????????????????????????????????????????????
        pnlContent.BackColor = Color.FromArgb(245, 247, 250)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Padding = New Padding(20)
        pnlContent.Controls.Add(lblPlaceholder)
        pnlContent.Controls.Add(pnlPlaceholderIcon)

        ' ?? pnlPlaceholderIcon ????????????????????????????????????
        pnlPlaceholderIcon.BackColor = Color.FromArgb(220, 235, 250)
        pnlPlaceholderIcon.Size = New Size(80, 80)
        pnlPlaceholderIcon.Location = New Point(310, 140)

        ' ?? lblPlaceholder ????????????????????????????????????????
        lblPlaceholder.Text = "Select a menu item from the sidebar to get started."
        lblPlaceholder.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        lblPlaceholder.ForeColor = Color.FromArgb(160, 170, 185)
        lblPlaceholder.TextAlign = ContentAlignment.MiddleCenter
        lblPlaceholder.AutoSize = False
        lblPlaceholder.Size = New Size(500, 40)
        lblPlaceholder.Location = New Point(150, 240)

        ' ?? Form ??????????????????????????????????????????????????
        Me.Text = "LMS - Admin Dashboard"
        Me.ClientSize = New Size(1000, 620)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MinimumSize = New Size(900, 580)
        Me.BackColor = Color.FromArgb(245, 247, 250)
        Me.Controls.Add(pnlMain)
        Me.Controls.Add(pnlSidebar)

        ResumeLayout(False)
    End Sub

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub AdminDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetActiveButton(btnLoanList)
    End Sub

    ' ?? Sidebar Navigation ????????????????????????????????????????
    Private Sub btnLoanList_Click(sender As Object, e As EventArgs) Handles btnLoanList.Click
        SetActiveButton(btnLoanList)
        lblPageTitle.Text = "Loan List"
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
        LoadContent(New PaymentListForm())
    End Sub

    Private Sub btnBorrowerAccounts_Click(sender As Object, e As EventArgs) Handles btnBorrowerAccounts.Click
        SetActiveButton(btnBorrowerAccounts)
        lblPageTitle.Text = "Borrower Accounts"
        LoadContent(New BorrowerAccountsForm())
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim login As New LoginForm()
        login.Show()
        Me.Hide()
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

    Private Sub SetActiveButton(activeBtn As Button)
        Dim sidebarBtns As Button() = {btnLoanList, btnBorrowerList, btnPaymentList, btnBorrowerAccounts}
        For Each btn As Button In sidebarBtns
            btn.BackColor = Color.Transparent
            btn.ForeColor = Color.FromArgb(200, 230, 255)
        Next
        activeBtn.BackColor = Color.FromArgb(30, 95, 150)
        activeBtn.ForeColor = Color.White
    End Sub

End Class
