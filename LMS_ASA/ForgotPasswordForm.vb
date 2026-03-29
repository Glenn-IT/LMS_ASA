Public Class ForgotPasswordForm
    Inherits Form

    Private pnlBackground As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlCard As Panel
    Private pnlAccent As Panel
    Private lblHeader As Label
    Private lblHeaderSub As Label
    Private pnlDividerTop As Panel
    Private grpSecurityQuestion As GroupBox
    Private lblSecurityQuestionStatic As Label
    Friend WithEvents cmbSecurityQuestion As ComboBox
    Private lblAnswer As Label
    Friend WithEvents txtAnswer As TextBox
    Private grpNewPassword As GroupBox
    Private lblNewPassword As Label
    Friend WithEvents txtNewPassword As TextBox
    Private lblConfirmPassword As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Private pnlButtons As Panel
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnBackToLogin As Button
    Private lblFooter As Label

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        pnlBackground = New Panel()
        lblFooter = New Label()
        pnlCard = New Panel()
        pnlButtons = New Panel()
        btnBackToLogin = New Button()
        btnSubmit = New Button()
        grpNewPassword = New GroupBox()
        txtConfirmPassword = New TextBox()
        lblConfirmPassword = New Label()
        txtNewPassword = New TextBox()
        lblNewPassword = New Label()
        grpSecurityQuestion = New GroupBox()
        txtAnswer = New TextBox()
        lblAnswer = New Label()
        cmbSecurityQuestion = New ComboBox()
        lblSecurityQuestionStatic = New Label()
        pnlDividerTop = New Panel()
        lblHeaderSub = New Label()
        lblHeader = New Label()
        pnlAccent = New Panel()
        lblSubtitle = New Label()
        lblTitle = New Label()
        pnlBackground.SuspendLayout()
        pnlCard.SuspendLayout()
        pnlButtons.SuspendLayout()
        grpNewPassword.SuspendLayout()
        grpSecurityQuestion.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlBackground
        ' 
        pnlBackground.BackColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        pnlBackground.Controls.Add(lblFooter)
        pnlBackground.Controls.Add(pnlCard)
        pnlBackground.Controls.Add(lblSubtitle)
        pnlBackground.Controls.Add(lblTitle)
        pnlBackground.Dock = DockStyle.Fill
        pnlBackground.Location = New Point(0, 0)
        pnlBackground.Name = "pnlBackground"
        pnlBackground.Size = New Size(800, 680)
        pnlBackground.TabIndex = 0
        ' 
        ' lblFooter
        ' 
        lblFooter.Font = New Font("Segoe UI", 8.0F)
        lblFooter.ForeColor = Color.FromArgb(CByte(120), CByte(160), CByte(200))
        lblFooter.Location = New Point(0, 640)
        lblFooter.Name = "lblFooter"
        lblFooter.Size = New Size(800, 24)
        lblFooter.TabIndex = 0
        lblFooter.Text = "© 2025 ASA Philippines Foundation, Inc. — For Presentation Use Only"
        lblFooter.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlCard
        ' 
        pnlCard.BackColor = Color.White
        pnlCard.Controls.Add(pnlButtons)
        pnlCard.Controls.Add(grpNewPassword)
        pnlCard.Controls.Add(grpSecurityQuestion)
        pnlCard.Controls.Add(pnlDividerTop)
        pnlCard.Controls.Add(lblHeaderSub)
        pnlCard.Controls.Add(lblHeader)
        pnlCard.Controls.Add(pnlAccent)
        pnlCard.Location = New Point(160, 138)
        pnlCard.Name = "pnlCard"
        pnlCard.Size = New Size(480, 510)
        pnlCard.TabIndex = 1
        ' 
        ' pnlButtons
        ' 
        pnlButtons.BackColor = Color.Transparent
        pnlButtons.Controls.Add(btnBackToLogin)
        pnlButtons.Controls.Add(btnSubmit)
        pnlButtons.Location = New Point(20, 452)
        pnlButtons.Name = "pnlButtons"
        pnlButtons.Size = New Size(440, 44)
        pnlButtons.TabIndex = 0
        ' 
        ' btnBackToLogin
        ' 
        btnBackToLogin.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        btnBackToLogin.Cursor = Cursors.Hand
        btnBackToLogin.FlatAppearance.BorderColor = Color.FromArgb(CByte(200), CByte(200), CByte(200))
        btnBackToLogin.FlatStyle = FlatStyle.Flat
        btnBackToLogin.Font = New Font("Segoe UI", 10.0F)
        btnBackToLogin.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        btnBackToLogin.Location = New Point(230, 0)
        btnBackToLogin.Name = "btnBackToLogin"
        btnBackToLogin.Size = New Size(210, 42)
        btnBackToLogin.TabIndex = 0
        btnBackToLogin.Text = "Back to Login"
        btnBackToLogin.UseVisualStyleBackColor = False
        ' 
        ' btnSubmit
        ' 
        btnSubmit.BackColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        btnSubmit.Cursor = Cursors.Hand
        btnSubmit.FlatAppearance.BorderSize = 0
        btnSubmit.FlatStyle = FlatStyle.Flat
        btnSubmit.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnSubmit.ForeColor = Color.White
        btnSubmit.Location = New Point(0, 0)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(210, 42)
        btnSubmit.TabIndex = 1
        btnSubmit.Text = "SUBMIT"
        btnSubmit.UseVisualStyleBackColor = False
        ' 
        ' grpNewPassword
        ' 
        grpNewPassword.Controls.Add(txtConfirmPassword)
        grpNewPassword.Controls.Add(lblConfirmPassword)
        grpNewPassword.Controls.Add(txtNewPassword)
        grpNewPassword.Controls.Add(lblNewPassword)
        grpNewPassword.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        grpNewPassword.ForeColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        grpNewPassword.Location = New Point(20, 266)
        grpNewPassword.Name = "grpNewPassword"
        grpNewPassword.Size = New Size(440, 170)
        grpNewPassword.TabIndex = 1
        grpNewPassword.TabStop = False
        grpNewPassword.Text = "Reset Password"
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.BackColor = Color.FromArgb(CByte(245), CByte(248), CByte(252))
        txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle
        txtConfirmPassword.Font = New Font("Segoe UI", 10.0F)
        txtConfirmPassword.Location = New Point(12, 116)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.PasswordChar = "*"c
        txtConfirmPassword.Size = New Size(408, 27)
        txtConfirmPassword.TabIndex = 0
        ' 
        ' lblConfirmPassword
        ' 
        lblConfirmPassword.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        lblConfirmPassword.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblConfirmPassword.Location = New Point(12, 96)
        lblConfirmPassword.Name = "lblConfirmPassword"
        lblConfirmPassword.Size = New Size(408, 18)
        lblConfirmPassword.TabIndex = 1
        lblConfirmPassword.Text = "CONFIRM PASSWORD"
        ' 
        ' txtNewPassword
        ' 
        txtNewPassword.BackColor = Color.FromArgb(CByte(245), CByte(248), CByte(252))
        txtNewPassword.BorderStyle = BorderStyle.FixedSingle
        txtNewPassword.Font = New Font("Segoe UI", 10.0F)
        txtNewPassword.Location = New Point(12, 46)
        txtNewPassword.Name = "txtNewPassword"
        txtNewPassword.PasswordChar = "*"c
        txtNewPassword.Size = New Size(408, 27)
        txtNewPassword.TabIndex = 2
        ' 
        ' lblNewPassword
        ' 
        lblNewPassword.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        lblNewPassword.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblNewPassword.Location = New Point(12, 26)
        lblNewPassword.Name = "lblNewPassword"
        lblNewPassword.Size = New Size(408, 18)
        lblNewPassword.TabIndex = 3
        lblNewPassword.Text = "NEW PASSWORD"
        ' 
        ' grpSecurityQuestion
        ' 
        grpSecurityQuestion.Controls.Add(txtAnswer)
        grpSecurityQuestion.Controls.Add(lblAnswer)
        grpSecurityQuestion.Controls.Add(cmbSecurityQuestion)
        grpSecurityQuestion.Controls.Add(lblSecurityQuestionStatic)
        grpSecurityQuestion.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        grpSecurityQuestion.ForeColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        grpSecurityQuestion.Location = New Point(20, 102)
        grpSecurityQuestion.Name = "grpSecurityQuestion"
        grpSecurityQuestion.Size = New Size(440, 152)
        grpSecurityQuestion.TabIndex = 2
        grpSecurityQuestion.TabStop = False
        grpSecurityQuestion.Text = "Security Question"
        ' 
        ' txtAnswer
        ' 
        txtAnswer.BackColor = Color.FromArgb(CByte(245), CByte(248), CByte(252))
        txtAnswer.BorderStyle = BorderStyle.FixedSingle
        txtAnswer.Font = New Font("Segoe UI", 10.0F)
        txtAnswer.Location = New Point(12, 116)
        txtAnswer.Name = "txtAnswer"
        txtAnswer.Size = New Size(408, 27)
        txtAnswer.TabIndex = 0
        ' 
        ' lblAnswer
        ' 
        lblAnswer.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        lblAnswer.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblAnswer.Location = New Point(12, 96)
        lblAnswer.Name = "lblAnswer"
        lblAnswer.Size = New Size(408, 18)
        lblAnswer.TabIndex = 1
        lblAnswer.Text = "ANSWER"
        ' 
        ' cmbSecurityQuestion
        ' 
        cmbSecurityQuestion.BackColor = Color.FromArgb(CByte(245), CByte(248), CByte(252))
        cmbSecurityQuestion.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSecurityQuestion.FlatStyle = FlatStyle.Flat
        cmbSecurityQuestion.Font = New Font("Segoe UI", 10.0F)
        cmbSecurityQuestion.Items.AddRange(New Object() {"What is your mother's maiden name?", "What was the name of your first pet?", "What is the name of the city where you were born?", "What was the name of your elementary school?", "What is your favorite childhood nickname?"})
        cmbSecurityQuestion.Location = New Point(12, 44)
        cmbSecurityQuestion.Name = "cmbSecurityQuestion"
        cmbSecurityQuestion.Size = New Size(408, 28)
        cmbSecurityQuestion.TabIndex = 2
        ' 
        ' lblSecurityQuestionStatic
        ' 
        lblSecurityQuestionStatic.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        lblSecurityQuestionStatic.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblSecurityQuestionStatic.Location = New Point(12, 24)
        lblSecurityQuestionStatic.Name = "lblSecurityQuestionStatic"
        lblSecurityQuestionStatic.Size = New Size(408, 18)
        lblSecurityQuestionStatic.TabIndex = 3
        lblSecurityQuestionStatic.Text = "SELECT QUESTION"
        ' 
        ' pnlDividerTop
        ' 
        pnlDividerTop.BackColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        pnlDividerTop.Location = New Point(20, 90)
        pnlDividerTop.Name = "pnlDividerTop"
        pnlDividerTop.Size = New Size(440, 1)
        pnlDividerTop.TabIndex = 3
        ' 
        ' lblHeaderSub
        ' 
        lblHeaderSub.Font = New Font("Segoe UI", 9.0F)
        lblHeaderSub.ForeColor = Color.Gray
        lblHeaderSub.Location = New Point(20, 60)
        lblHeaderSub.Name = "lblHeaderSub"
        lblHeaderSub.Size = New Size(440, 20)
        lblHeaderSub.TabIndex = 4
        lblHeaderSub.Text = "Select a security question and enter your answer to reset your password."
        ' 
        ' lblHeader
        ' 
        lblHeader.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblHeader.ForeColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        lblHeader.Location = New Point(20, 18)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(440, 40)
        lblHeader.TabIndex = 5
        lblHeader.Text = "Forgot Password"
        ' 
        ' pnlAccent
        ' 
        pnlAccent.BackColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        pnlAccent.Location = New Point(0, 0)
        pnlAccent.Name = "pnlAccent"
        pnlAccent.Size = New Size(480, 6)
        pnlAccent.TabIndex = 6
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Font = New Font("Segoe UI", 11.0F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(173), CByte(216), CByte(255))
        lblSubtitle.Location = New Point(0, 96)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(800, 28)
        lblSubtitle.TabIndex = 2
        lblSubtitle.Text = "ASA Philippines Foundation, Inc."
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTitle
        ' 
        lblTitle.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(0, 42)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(800, 52)
        lblTitle.TabIndex = 3
        lblTitle.Text = "Loan Management System"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ForgotPasswordForm
        ' 
        BackColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        ClientSize = New Size(800, 680)
        Controls.Add(pnlBackground)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "ForgotPasswordForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LMS - Forgot Password"
        pnlBackground.ResumeLayout(False)
        pnlCard.ResumeLayout(False)
        pnlButtons.ResumeLayout(False)
        grpNewPassword.ResumeLayout(False)
        grpNewPassword.PerformLayout()
        grpSecurityQuestion.ResumeLayout(False)
        grpSecurityQuestion.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' ── Form Load ─────────────────────────────────────────────────
    Private Sub ForgotPasswordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSecurityQuestion.SelectedIndex = 0
        txtAnswer.Text = ""
        txtNewPassword.Text = ""
        txtConfirmPassword.Text = ""
        txtAnswer.Focus()
    End Sub

    ' ── Submit ────────────────────────────────────────────────────
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        MessageBox.Show(
            "Your password has been reset successfully." & Environment.NewLine &
            "Please log in with your new password.",
            "Password Reset Successful",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )
        Dim login As New LoginForm()
        login.Show()
        Me.Hide()
    End Sub

    ' ── Back to Login ─────────────────────────────────────────────
    Private Sub btnBackToLogin_Click(sender As Object, e As EventArgs) Handles btnBackToLogin.Click
        Dim login As New LoginForm()
        login.Show()
        Me.Hide()
    End Sub

    ' ── Hover Effects ─────────────────────────────────────────────
    Private Sub btnSubmit_MouseEnter(sender As Object, e As EventArgs) Handles btnSubmit.MouseEnter
        btnSubmit.BackColor = Color.FromArgb(30, 95, 150)
    End Sub

    Private Sub btnSubmit_MouseLeave(sender As Object, e As EventArgs) Handles btnSubmit.MouseLeave
        btnSubmit.BackColor = Color.FromArgb(21, 67, 106)
    End Sub

    Private Sub btnBackToLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnBackToLogin.MouseEnter
        btnBackToLogin.BackColor = Color.FromArgb(220, 220, 220)
    End Sub

    Private Sub btnBackToLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnBackToLogin.MouseLeave
        btnBackToLogin.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

End Class
