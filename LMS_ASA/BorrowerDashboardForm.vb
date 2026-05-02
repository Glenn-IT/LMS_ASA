Public Class BorrowerDashboardForm
    Inherits Form

    ' ?? Controls ??????????????????????????????????????????????????
    Private pnlSidebar As Panel
    Private pnlSidebarHeader As Panel
    Private lblSidebarTitle As Label
    Private lblSidebarSub As Label
    Private pnlSidebarDivider As Panel
    Friend WithEvents btnFileLoan As Button
    Friend WithEvents btnTrackLoan As Button
    Friend WithEvents btnMyAccount As Button
    Private pnlSidebarFooter As Panel
    Friend WithEvents btnLogout As Button
    Private pnlMain As Panel
    Private pnlTopBar As Panel
    Private lblPageTitle As Label
    Private lblWelcome As Label
    Private pnlContent As Panel
    Private lblPlaceholder As Label

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        pnlSidebar = New Panel()
        pnlSidebarHeader = New Panel()
        lblSidebarTitle = New Label()
        lblSidebarSub = New Label()
        pnlSidebarDivider = New Panel()
        btnFileLoan = New Button()
        btnTrackLoan = New Button()
        btnMyAccount = New Button()
        pnlSidebarFooter = New Panel()
        btnLogout = New Button()
        pnlMain = New Panel()
        pnlTopBar = New Panel()
        lblPageTitle = New Label()
        lblWelcome = New Label()
        pnlContent = New Panel()
        lblPlaceholder = New Label()

        SuspendLayout()

        ' ?? pnlSidebar ????????????????????????????????????????????
        pnlSidebar.BackColor = Color.FromArgb(21, 67, 106)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Width = 220
        pnlSidebar.Controls.Add(pnlSidebarFooter)
        pnlSidebar.Controls.Add(btnMyAccount)
        pnlSidebar.Controls.Add(btnTrackLoan)
        pnlSidebar.Controls.Add(btnFileLoan)
        pnlSidebar.Controls.Add(pnlSidebarDivider)
        pnlSidebar.Controls.Add(pnlSidebarHeader)

        ' ?? pnlSidebarHeader ??????????????????????????????????????
        pnlSidebarHeader.BackColor = Color.FromArgb(15, 52, 86)
        pnlSidebarHeader.Dock = DockStyle.Top
        pnlSidebarHeader.Height = 100
        pnlSidebarHeader.Controls.Add(lblSidebarSub)
        pnlSidebarHeader.Controls.Add(lblSidebarTitle)

        ' ?? lblSidebarTitle ???????????????????????????????????????
        lblSidebarTitle.Text = "LMS Borrower"
        lblSidebarTitle.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        lblSidebarTitle.ForeColor = Color.White
        lblSidebarTitle.AutoSize = False
        lblSidebarTitle.Size = New Size(200, 30)
        lblSidebarTitle.Location = New Point(12, 28)

        ' ?? lblSidebarSub ?????????????????????????????????????????
        lblSidebarSub.Text = "Borrower Portal"
        lblSidebarSub.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSidebarSub.ForeColor = Color.FromArgb(173, 216, 255)
        lblSidebarSub.AutoSize = False
        lblSidebarSub.Size = New Size(200, 20)
        lblSidebarSub.Location = New Point(12, 60)

        ' ?? pnlSidebarDivider ?????????????????????????????????????
        pnlSidebarDivider.BackColor = Color.FromArgb(40, 90, 130)
        pnlSidebarDivider.Dock = DockStyle.Top
        pnlSidebarDivider.Height = 1

        ' ?? btnFileLoan ???????????????????????????????????????????
        btnFileLoan.Text = "   File Loan Application"
        btnFileLoan.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnFileLoan.ForeColor = Color.FromArgb(200, 230, 255)
        btnFileLoan.BackColor = Color.Transparent
        btnFileLoan.FlatStyle = FlatStyle.Flat
        btnFileLoan.FlatAppearance.BorderSize = 0
        btnFileLoan.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 95, 150)
        btnFileLoan.TextAlign = ContentAlignment.MiddleLeft
        btnFileLoan.Size = New Size(220, 48)
        btnFileLoan.Location = New Point(0, 110)
        btnFileLoan.Cursor = Cursors.Hand

        ' ?? btnTrackLoan ??????????????????????????????????????????
        btnTrackLoan.Text = "   Track Loan Application"
        btnTrackLoan.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnTrackLoan.ForeColor = Color.FromArgb(200, 230, 255)
        btnTrackLoan.BackColor = Color.Transparent
        btnTrackLoan.FlatStyle = FlatStyle.Flat
        btnTrackLoan.FlatAppearance.BorderSize = 0
        btnTrackLoan.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 95, 150)
        btnTrackLoan.TextAlign = ContentAlignment.MiddleLeft
        btnTrackLoan.Size = New Size(220, 48)
        btnTrackLoan.Location = New Point(0, 158)
        btnTrackLoan.Cursor = Cursors.Hand

        ' ?? btnMyAccount ??????????????????????????????????????????
        btnMyAccount.Text = "   My Account"
        btnMyAccount.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnMyAccount.ForeColor = Color.FromArgb(200, 230, 255)
        btnMyAccount.BackColor = Color.Transparent
        btnMyAccount.FlatStyle = FlatStyle.Flat
        btnMyAccount.FlatAppearance.BorderSize = 0
        btnMyAccount.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 95, 150)
        btnMyAccount.TextAlign = ContentAlignment.MiddleLeft
        btnMyAccount.Size = New Size(220, 48)
        btnMyAccount.Location = New Point(0, 206)
        btnMyAccount.Cursor = Cursors.Hand

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
        lblPageTitle.Text = "Borrower Dashboard"
        lblPageTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblPageTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblPageTitle.AutoSize = False
        lblPageTitle.Size = New Size(500, 30)
        lblPageTitle.Location = New Point(20, 14)

        ' ?? lblWelcome ????????????????????????????????????????????
        lblWelcome.Text = "Welcome, Juan dela Cruz"
        lblWelcome.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblWelcome.ForeColor = Color.Gray
        lblWelcome.AutoSize = False
        lblWelcome.Size = New Size(300, 20)
        lblWelcome.Location = New Point(20, 40)

        ' ?? pnlContent ????????????????????????????????????????????
        pnlContent.BackColor = Color.FromArgb(245, 247, 250)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Padding = New Padding(20)
        pnlContent.Controls.Add(lblPlaceholder)

        ' ?? lblPlaceholder ????????????????????????????????????????
        lblPlaceholder.Text = "Select a menu item from the sidebar to get started."
        lblPlaceholder.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        lblPlaceholder.ForeColor = Color.FromArgb(160, 170, 185)
        lblPlaceholder.TextAlign = ContentAlignment.MiddleCenter
        lblPlaceholder.AutoSize = False
        lblPlaceholder.Size = New Size(500, 40)
        lblPlaceholder.Location = New Point(120, 220)

        ' ?? Form ??????????????????????????????????????????????????
        Me.Text = "LMS - Borrower Dashboard"
        Me.ClientSize = New Size(1000, 620)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MinimumSize = New Size(860, 540)
        Me.BackColor = Color.FromArgb(245, 247, 250)
        Me.Controls.Add(pnlMain)
        Me.Controls.Add(pnlSidebar)

        ResumeLayout(False)
    End Sub

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub BorrowerDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetActiveButton(btnFileLoan)
        ShowWelcomePanel()
    End Sub

    ' ?? File Loan Application ?????????????????????????????????????
    Private Sub btnFileLoan_Click(sender As Object, e As EventArgs) Handles btnFileLoan.Click
        SetActiveButton(btnFileLoan)
        lblPageTitle.Text = "File Loan Application"
        Dim frm As New LoanApplicationForm()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        pnlContent.Controls.Clear()
        pnlContent.Controls.Add(frm)
        frm.Show()
    End Sub

    ' ?? Track Loan Application ????????????????????????????????????
    Private Sub btnTrackLoan_Click(sender As Object, e As EventArgs) Handles btnTrackLoan.Click
        SetActiveButton(btnTrackLoan)
        lblPageTitle.Text = "Track Loan Application"
        Dim frm As New TrackLoanForm()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        pnlContent.Controls.Clear()
        pnlContent.Controls.Add(frm)
        frm.Show()
    End Sub

    ' ?? My Account ????????????????????????????????????????????????
    Private Sub btnMyAccount_Click(sender As Object, e As EventArgs) Handles btnMyAccount.Click
        SetActiveButton(btnMyAccount)
        lblPageTitle.Text = "My Account"
        Dim frm As New MyAccountForm()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        pnlContent.Controls.Clear()
        pnlContent.Controls.Add(frm)
        frm.Show()
    End Sub

    ' ?? Logout ????????????????????????????????????????????????????
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim login As New LoginForm()
        login.Show()
        Me.Hide()
    End Sub

    ' ?? Helpers ???????????????????????????????????????????????????
    Private Sub ShowWelcomePanel()
        ShowPlaceholder("Select a menu item from the sidebar to get started.")
    End Sub

    Private Sub ShowPlaceholder(message As String)
        pnlContent.Controls.Clear()
        Dim lbl As New Label()
        lbl.Text = message
        lbl.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        lbl.ForeColor = Color.FromArgb(160, 170, 185)
        lbl.TextAlign = ContentAlignment.MiddleCenter
        lbl.AutoSize = False
        lbl.Size = New Size(500, 40)
        lbl.Location = New Point(120, 220)
        pnlContent.Controls.Add(lbl)
    End Sub

    Private Sub SetActiveButton(activeBtn As Button)
        Dim sidebarBtns As Button() = {btnFileLoan, btnTrackLoan, btnMyAccount}
        For Each btn As Button In sidebarBtns
            btn.BackColor = Color.Transparent
            btn.ForeColor = Color.FromArgb(200, 230, 255)
        Next
        activeBtn.BackColor = Color.FromArgb(30, 95, 150)
        activeBtn.ForeColor = Color.White
    End Sub

End Class
