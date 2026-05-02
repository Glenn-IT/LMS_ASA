Public Class MyAccountForm
    Inherits Form

    ' ?? Controls ??????????????????????????????????????????????????
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlDividerTop As Panel
    Private pnlBody As Panel
    Private grpCredentials As GroupBox
    Private lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Private lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Private lblConfirmPassword As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Private grpSecurity As GroupBox
    Private lblSecurityQuestion As Label
    Friend WithEvents cmbSecurityQuestion As ComboBox
    Private lblSecurityAnswer As Label
    Friend WithEvents txtSecurityAnswer As TextBox
    Private pnlFooter As Panel
    Private pnlDividerBottom As Panel
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnCancel As Button

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlDividerTop = New Panel()
        pnlBody = New Panel()
        grpCredentials = New GroupBox()
        lblUsername = New Label()
        txtUsername = New TextBox()
        lblPassword = New Label()
        txtPassword = New TextBox()
        lblConfirmPassword = New Label()
        txtConfirmPassword = New TextBox()
        grpSecurity = New GroupBox()
        lblSecurityQuestion = New Label()
        cmbSecurityQuestion = New ComboBox()
        lblSecurityAnswer = New Label()
        txtSecurityAnswer = New TextBox()
        pnlFooter = New Panel()
        pnlDividerBottom = New Panel()
        btnUpdate = New Button()
        btnCancel = New Button()

        SuspendLayout()

        ' ?? pnlHeader ?????????????????????????????????????????????
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        lblTitle.Text = "My Account"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        lblSubtitle.Text = "Update your login credentials and security settings"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(500, 18)
        lblSubtitle.Location = New Point(16, 40)

        ' ?? pnlDividerTop ?????????????????????????????????????????
        pnlDividerTop.BackColor = Color.FromArgb(220, 220, 220)
        pnlDividerTop.Dock = DockStyle.Top
        pnlDividerTop.Height = 1

        ' ?? pnlBody ???????????????????????????????????????????????
        pnlBody.BackColor = Color.FromArgb(245, 247, 250)
        pnlBody.Dock = DockStyle.Fill
        pnlBody.Padding = New Padding(16)
        pnlBody.AutoScroll = True
        pnlBody.Controls.Add(grpSecurity)
        pnlBody.Controls.Add(grpCredentials)

        ' ??????????????????????????????????????????????????????????
        ' grpCredentials — Username, Password, Confirm Password
        ' ??????????????????????????????????????????????????????????
        grpCredentials.Text = "Login Credentials"
        grpCredentials.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpCredentials.ForeColor = Color.FromArgb(21, 67, 106)
        grpCredentials.BackColor = Color.White
        grpCredentials.Size = New Size(830, 140)
        grpCredentials.Location = New Point(16, 16)
        grpCredentials.Controls.Add(txtConfirmPassword)
        grpCredentials.Controls.Add(lblConfirmPassword)
        grpCredentials.Controls.Add(txtPassword)
        grpCredentials.Controls.Add(lblPassword)
        grpCredentials.Controls.Add(txtUsername)
        grpCredentials.Controls.Add(lblUsername)

        ' Username
        lblUsername.Text = "USERNAME"
        lblUsername.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblUsername.ForeColor = Color.FromArgb(100, 100, 100)
        lblUsername.AutoSize = False
        lblUsername.Size = New Size(256, 18)
        lblUsername.Location = New Point(16, 28)

        txtUsername.Font = New Font("Segoe UI", 10)
        txtUsername.Size = New Size(256, 28)
        txtUsername.Location = New Point(16, 48)
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.BackColor = Color.FromArgb(245, 248, 252)
        txtUsername.Text = "juan.delacruz"

        ' Password
        lblPassword.Text = "NEW PASSWORD"
        lblPassword.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblPassword.ForeColor = Color.FromArgb(100, 100, 100)
        lblPassword.AutoSize = False
        lblPassword.Size = New Size(256, 18)
        lblPassword.Location = New Point(290, 28)

        txtPassword.Font = New Font("Segoe UI", 10)
        txtPassword.Size = New Size(256, 28)
        txtPassword.Location = New Point(290, 48)
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.BackColor = Color.FromArgb(245, 248, 252)
        txtPassword.PasswordChar = "*"c

        ' Confirm Password
        lblConfirmPassword.Text = "CONFIRM PASSWORD"
        lblConfirmPassword.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblConfirmPassword.ForeColor = Color.FromArgb(100, 100, 100)
        lblConfirmPassword.AutoSize = False
        lblConfirmPassword.Size = New Size(256, 18)
        lblConfirmPassword.Location = New Point(564, 28)

        txtConfirmPassword.Font = New Font("Segoe UI", 10)
        txtConfirmPassword.Size = New Size(250, 28)
        txtConfirmPassword.Location = New Point(564, 48)
        txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle
        txtConfirmPassword.BackColor = Color.FromArgb(245, 248, 252)
        txtConfirmPassword.PasswordChar = "*"c

        ' ??????????????????????????????????????????????????????????
        ' grpSecurity — Security Question, Security Answer
        ' ??????????????????????????????????????????????????????????
        grpSecurity.Text = "Security Settings"
        grpSecurity.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpSecurity.ForeColor = Color.FromArgb(21, 67, 106)
        grpSecurity.BackColor = Color.White
        grpSecurity.Size = New Size(830, 140)
        grpSecurity.Location = New Point(16, 172)
        grpSecurity.Controls.Add(txtSecurityAnswer)
        grpSecurity.Controls.Add(lblSecurityAnswer)
        grpSecurity.Controls.Add(cmbSecurityQuestion)
        grpSecurity.Controls.Add(lblSecurityQuestion)

        ' Security Question
        lblSecurityQuestion.Text = "SECURITY QUESTION"
        lblSecurityQuestion.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblSecurityQuestion.ForeColor = Color.FromArgb(100, 100, 100)
        lblSecurityQuestion.AutoSize = False
        lblSecurityQuestion.Size = New Size(500, 18)
        lblSecurityQuestion.Location = New Point(16, 28)

        cmbSecurityQuestion.Font = New Font("Segoe UI", 10)
        cmbSecurityQuestion.Size = New Size(500, 28)
        cmbSecurityQuestion.Location = New Point(16, 48)
        cmbSecurityQuestion.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSecurityQuestion.BackColor = Color.FromArgb(245, 248, 252)
        cmbSecurityQuestion.FlatStyle = FlatStyle.Flat
        cmbSecurityQuestion.Items.AddRange(New Object() {
            "What is your mother's maiden name?",
            "What was the name of your first pet?",
            "What city were you born in?",
            "What is your favorite childhood food?",
            "What is the name of your elementary school?"
        })

        ' Security Answer
        lblSecurityAnswer.Text = "SECURITY ANSWER"
        lblSecurityAnswer.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblSecurityAnswer.ForeColor = Color.FromArgb(100, 100, 100)
        lblSecurityAnswer.AutoSize = False
        lblSecurityAnswer.Size = New Size(298, 18)
        lblSecurityAnswer.Location = New Point(534, 28)

        txtSecurityAnswer.Font = New Font("Segoe UI", 10)
        txtSecurityAnswer.Size = New Size(280, 28)
        txtSecurityAnswer.Location = New Point(534, 48)
        txtSecurityAnswer.BorderStyle = BorderStyle.FixedSingle
        txtSecurityAnswer.BackColor = Color.FromArgb(245, 248, 252)

        ' ?? pnlFooter ?????????????????????????????????????????????
        pnlFooter.BackColor = Color.White
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 60
        pnlFooter.Controls.Add(btnCancel)
        pnlFooter.Controls.Add(btnUpdate)
        pnlFooter.Controls.Add(pnlDividerBottom)

        pnlDividerBottom.BackColor = Color.FromArgb(220, 220, 220)
        pnlDividerBottom.Dock = DockStyle.Top
        pnlDividerBottom.Height = 1

        ' btnUpdate
        btnUpdate.Text = "Update Account"
        btnUpdate.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnUpdate.BackColor = Color.FromArgb(21, 67, 106)
        btnUpdate.ForeColor = Color.White
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.FlatAppearance.BorderSize = 0
        btnUpdate.Size = New Size(140, 38)
        btnUpdate.Location = New Point(16, 12)
        btnUpdate.Cursor = Cursors.Hand

        ' btnCancel
        btnCancel.Text = "Cancel"
        btnCancel.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnCancel.BackColor = Color.FromArgb(240, 240, 240)
        btnCancel.ForeColor = Color.FromArgb(60, 60, 60)
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 1
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
        btnCancel.Size = New Size(130, 38)
        btnCancel.Location = New Point(168, 12)
        btnCancel.Cursor = Cursors.Hand

        ' ?? Form ??????????????????????????????????????????????????
        Me.Text = "LMS - My Account"
        Me.ClientSize = New Size(880, 420)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(245, 247, 250)
        Me.Controls.Add(pnlBody)
        Me.Controls.Add(pnlFooter)
        Me.Controls.Add(pnlDividerTop)
        Me.Controls.Add(pnlHeader)

        ResumeLayout(False)
    End Sub

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub MyAccountForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSecurityQuestion.SelectedIndex = 0
    End Sub

    ' ?? Update Button ?????????????????????????????????????????????
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        MessageBox.Show(
            "Your account information has been updated successfully.",
            "Account Updated",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )
    End Sub

    ' ?? Cancel Button ?????????????????????????????????????????????
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ' ?? Hover Effects ?????????????????????????????????????????????
    Private Sub btnUpdate_MouseEnter(sender As Object, e As EventArgs) Handles btnUpdate.MouseEnter
        btnUpdate.BackColor = Color.FromArgb(30, 95, 150)
    End Sub
    Private Sub btnUpdate_MouseLeave(sender As Object, e As EventArgs) Handles btnUpdate.MouseLeave
        btnUpdate.BackColor = Color.FromArgb(21, 67, 106)
    End Sub
    Private Sub btnCancel_MouseEnter(sender As Object, e As EventArgs) Handles btnCancel.MouseEnter
        btnCancel.BackColor = Color.FromArgb(220, 220, 220)
    End Sub
    Private Sub btnCancel_MouseLeave(sender As Object, e As EventArgs) Handles btnCancel.MouseLeave
        btnCancel.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

End Class
