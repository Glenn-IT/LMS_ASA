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
    Private lblUsernameLabel As Label
    Friend WithEvents txtUsernameReset As TextBox
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
        pnlBackground        = New Panel()
        lblFooter            = New Label()
        pnlCard              = New Panel()
        pnlAccent            = New Panel()
        lblHeader            = New Label()
        lblHeaderSub         = New Label()
        pnlDividerTop        = New Panel()
        lblUsernameLabel     = New Label()
        txtUsernameReset     = New TextBox()
        grpSecurityQuestion  = New GroupBox()
        lblSecurityQuestionStatic = New Label()
        cmbSecurityQuestion  = New ComboBox()
        lblAnswer            = New Label()
        txtAnswer            = New TextBox()
        grpNewPassword       = New GroupBox()
        lblNewPassword       = New Label()
        txtNewPassword       = New TextBox()
        lblConfirmPassword   = New Label()
        txtConfirmPassword   = New TextBox()
        pnlButtons           = New Panel()
        btnSubmit            = New Button()
        btnBackToLogin       = New Button()
        lblTitle             = New Label()
        lblSubtitle          = New Label()

        pnlBackground.SuspendLayout()
        pnlCard.SuspendLayout()
        pnlButtons.SuspendLayout()
        grpNewPassword.SuspendLayout()
        grpSecurityQuestion.SuspendLayout()
        SuspendLayout()

        ' ── pnlBackground ─────────────────────────────────────────
        pnlBackground.BackColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        pnlBackground.Controls.Add(lblFooter)
        pnlBackground.Controls.Add(pnlCard)
        pnlBackground.Controls.Add(lblSubtitle)
        pnlBackground.Controls.Add(lblTitle)
        pnlBackground.Dock = DockStyle.Fill
        pnlBackground.Location = New Point(0, 0)
        pnlBackground.Name = "pnlBackground"
        pnlBackground.Size = New Size(800, 740)

        ' ── lblFooter ──────────────────────────────────────────────
        lblFooter.Font = New Font("Segoe UI", 8.0F)
        lblFooter.ForeColor = Color.FromArgb(CByte(255), CByte(221), CByte(156))
        lblFooter.Location = New Point(0, 710)
        lblFooter.Name = "lblFooter"
        lblFooter.Size = New Size(800, 24)
        lblFooter.Text = "© 2025 ASA Philippines Foundation, Inc. — For Presentation Use Only"
        lblFooter.TextAlign = ContentAlignment.MiddleCenter

        ' ── lblTitle ───────────────────────────────────────────────
        lblTitle.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(0, 42)
        lblTitle.Size = New Size(800, 52)
        lblTitle.Text = "Loan Management System"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter

        ' ── lblSubtitle ────────────────────────────────────────────
        lblSubtitle.Font = New Font("Segoe UI", 11.0F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(255), CByte(221), CByte(156))
        lblSubtitle.Location = New Point(0, 96)
        lblSubtitle.Size = New Size(800, 28)
        lblSubtitle.Text = "ASA Philippines Foundation, Inc."
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter

        ' ── pnlCard ────────────────────────────────────────────────
        pnlCard.BackColor = Color.White
        pnlCard.Controls.Add(pnlAccent)
        pnlCard.Controls.Add(lblHeader)
        pnlCard.Controls.Add(lblHeaderSub)
        pnlCard.Controls.Add(pnlDividerTop)
        pnlCard.Controls.Add(lblUsernameLabel)
        pnlCard.Controls.Add(txtUsernameReset)
        pnlCard.Controls.Add(grpSecurityQuestion)
        pnlCard.Controls.Add(grpNewPassword)
        pnlCard.Controls.Add(pnlButtons)
        pnlCard.Location = New Point(160, 138)
        pnlCard.Name = "pnlCard"
        pnlCard.Size = New Size(480, 568)

        ' ── pnlAccent ──────────────────────────────────────────────
        pnlAccent.BackColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        pnlAccent.Location = New Point(0, 0)
        pnlAccent.Size = New Size(480, 6)

        ' ── lblHeader ──────────────────────────────────────────────
        lblHeader.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblHeader.ForeColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        lblHeader.Location = New Point(20, 18)
        lblHeader.Size = New Size(440, 40)
        lblHeader.Text = "Forgot Password"

        ' ── lblHeaderSub ───────────────────────────────────────────
        lblHeaderSub.Font = New Font("Segoe UI", 9.0F)
        lblHeaderSub.ForeColor = Color.Gray
        lblHeaderSub.Location = New Point(20, 60)
        lblHeaderSub.Size = New Size(440, 20)
        lblHeaderSub.Text = "Enter your username, security question, and new password."

        ' ── pnlDividerTop ──────────────────────────────────────────
        pnlDividerTop.BackColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        pnlDividerTop.Location = New Point(20, 90)
        pnlDividerTop.Size = New Size(440, 1)

        ' ── lblUsernameLabel [NEW] ─────────────────────────────────
        lblUsernameLabel.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        lblUsernameLabel.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblUsernameLabel.Location = New Point(20, 98)
        lblUsernameLabel.Size = New Size(440, 18)
        lblUsernameLabel.Text = "USERNAME"

        ' ── txtUsernameReset [NEW] ─────────────────────────────────
        txtUsernameReset.BackColor = Color.FromArgb(CByte(255), CByte(252), CByte(248))
        txtUsernameReset.BorderStyle = BorderStyle.FixedSingle
        txtUsernameReset.Font = New Font("Segoe UI", 10.0F)
        txtUsernameReset.Location = New Point(20, 118)
        txtUsernameReset.Name = "txtUsernameReset"
        txtUsernameReset.Size = New Size(440, 27)
        txtUsernameReset.TabIndex = 0

        ' ── grpSecurityQuestion (shifted down 58px) ────────────────
        grpSecurityQuestion.Controls.Add(lblSecurityQuestionStatic)
        grpSecurityQuestion.Controls.Add(cmbSecurityQuestion)
        grpSecurityQuestion.Controls.Add(lblAnswer)
        grpSecurityQuestion.Controls.Add(txtAnswer)
        grpSecurityQuestion.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        grpSecurityQuestion.ForeColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        grpSecurityQuestion.Location = New Point(20, 160)
        grpSecurityQuestion.Name = "grpSecurityQuestion"
        grpSecurityQuestion.Size = New Size(440, 152)
        grpSecurityQuestion.TabStop = False
        grpSecurityQuestion.Text = "Security Question"

        lblSecurityQuestionStatic.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        lblSecurityQuestionStatic.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblSecurityQuestionStatic.Location = New Point(12, 24)
        lblSecurityQuestionStatic.Size = New Size(408, 18)
        lblSecurityQuestionStatic.Text = "SELECT QUESTION"

        cmbSecurityQuestion.BackColor = Color.FromArgb(CByte(255), CByte(252), CByte(248))
        cmbSecurityQuestion.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSecurityQuestion.FlatStyle = FlatStyle.Flat
        cmbSecurityQuestion.Font = New Font("Segoe UI", 10.0F)
        cmbSecurityQuestion.Items.AddRange(New Object() {
            "What is your mother's maiden name?",
            "What was the name of your first pet?",
            "What is the name of the city where you were born?",
            "What was the name of your elementary school?",
            "What is your favorite childhood nickname?"})
        cmbSecurityQuestion.Location = New Point(12, 44)
        cmbSecurityQuestion.Name = "cmbSecurityQuestion"
        cmbSecurityQuestion.Size = New Size(408, 28)
        cmbSecurityQuestion.TabIndex = 1

        lblAnswer.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        lblAnswer.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblAnswer.Location = New Point(12, 96)
        lblAnswer.Size = New Size(408, 18)
        lblAnswer.Text = "ANSWER"

        txtAnswer.BackColor = Color.FromArgb(CByte(255), CByte(252), CByte(248))
        txtAnswer.BorderStyle = BorderStyle.FixedSingle
        txtAnswer.Font = New Font("Segoe UI", 10.0F)
        txtAnswer.Location = New Point(12, 116)
        txtAnswer.Name = "txtAnswer"
        txtAnswer.Size = New Size(408, 27)
        txtAnswer.TabIndex = 2

        ' ── grpNewPassword (shifted down 58px) ────────────────────
        grpNewPassword.Controls.Add(lblNewPassword)
        grpNewPassword.Controls.Add(txtNewPassword)
        grpNewPassword.Controls.Add(lblConfirmPassword)
        grpNewPassword.Controls.Add(txtConfirmPassword)
        grpNewPassword.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        grpNewPassword.ForeColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        grpNewPassword.Location = New Point(20, 324)
        grpNewPassword.Name = "grpNewPassword"
        grpNewPassword.Size = New Size(440, 170)
        grpNewPassword.TabStop = False
        grpNewPassword.Text = "Reset Password"

        lblNewPassword.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        lblNewPassword.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblNewPassword.Location = New Point(12, 26)
        lblNewPassword.Size = New Size(408, 18)
        lblNewPassword.Text = "NEW PASSWORD"

        txtNewPassword.BackColor = Color.FromArgb(CByte(255), CByte(252), CByte(248))
        txtNewPassword.BorderStyle = BorderStyle.FixedSingle
        txtNewPassword.Font = New Font("Segoe UI", 10.0F)
        txtNewPassword.Location = New Point(12, 46)
        txtNewPassword.Name = "txtNewPassword"
        txtNewPassword.PasswordChar = "*"c
        txtNewPassword.Size = New Size(408, 27)
        txtNewPassword.TabIndex = 3

        lblConfirmPassword.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        lblConfirmPassword.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblConfirmPassword.Location = New Point(12, 96)
        lblConfirmPassword.Size = New Size(408, 18)
        lblConfirmPassword.Text = "CONFIRM PASSWORD"

        txtConfirmPassword.BackColor = Color.FromArgb(CByte(255), CByte(252), CByte(248))
        txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle
        txtConfirmPassword.Font = New Font("Segoe UI", 10.0F)
        txtConfirmPassword.Location = New Point(12, 116)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.PasswordChar = "*"c
        txtConfirmPassword.Size = New Size(408, 27)
        txtConfirmPassword.TabIndex = 4

        ' ── pnlButtons (shifted down 58px) ────────────────────────
        pnlButtons.BackColor = Color.Transparent
        pnlButtons.Controls.Add(btnBackToLogin)
        pnlButtons.Controls.Add(btnSubmit)
        pnlButtons.Location = New Point(20, 508)
        pnlButtons.Size = New Size(440, 44)

        btnSubmit.BackColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        btnSubmit.Cursor = Cursors.Hand
        btnSubmit.FlatAppearance.BorderSize = 0
        btnSubmit.FlatStyle = FlatStyle.Flat
        btnSubmit.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnSubmit.ForeColor = Color.White
        btnSubmit.Location = New Point(0, 0)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(210, 42)
        btnSubmit.Text = "RESET PASSWORD"
        btnSubmit.UseVisualStyleBackColor = False

        btnBackToLogin.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        btnBackToLogin.Cursor = Cursors.Hand
        btnBackToLogin.FlatAppearance.BorderColor = Color.FromArgb(CByte(200), CByte(200), CByte(200))
        btnBackToLogin.FlatStyle = FlatStyle.Flat
        btnBackToLogin.Font = New Font("Segoe UI", 10.0F)
        btnBackToLogin.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        btnBackToLogin.Location = New Point(230, 0)
        btnBackToLogin.Name = "btnBackToLogin"
        btnBackToLogin.Size = New Size(210, 42)
        btnBackToLogin.Text = "Back to Login"
        btnBackToLogin.UseVisualStyleBackColor = False

        ' ── Form ───────────────────────────────────────────────────
        BackColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        ClientSize = New Size(800, 740)
        Controls.Add(pnlBackground)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "ForgotPasswordForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LMS - Forgot Password"
        AcceptButton = btnSubmit

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
        txtUsernameReset.Text = ""
        txtAnswer.Text = ""
        txtNewPassword.Text = ""
        txtConfirmPassword.Text = ""
        txtUsernameReset.Focus()
    End Sub

    ' ── Reset Password ────────────────────────────────────────────
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim username  As String = txtUsernameReset.Text.Trim()
        Dim question  As String = cmbSecurityQuestion.SelectedItem.ToString()
        Dim answer    As String = txtAnswer.Text.Trim()
        Dim newPw     As String = txtNewPassword.Text
        Dim confirmPw As String = txtConfirmPassword.Text

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(answer) OrElse
           String.IsNullOrEmpty(newPw) OrElse String.IsNullOrEmpty(confirmPw) Then
            MessageBox.Show("Please fill in all fields.",
                            "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If newPw <> confirmPw Then
            MessageBox.Show("New password and confirm password do not match.",
                            "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtConfirmPassword.Clear()
            txtConfirmPassword.Focus()
            Return
        End If

        If newPw.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.",
                            "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim dt As DataTable = UserRepository.GetByUsername(username)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Username not found.",
                                "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim row As DataRow = dt.Rows(0)

            If row("SecurityQuestion").ToString() <> question Then
                MessageBox.Show("The selected security question does not match your account.",
                                "Incorrect Question", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If row("SecurityAnswer").ToString().ToLower() <> answer.ToLower() Then
                MessageBox.Show("Incorrect security answer.",
                                "Incorrect Answer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAnswer.Clear()
                txtAnswer.Focus()
                Return
            End If

            Dim newHash As String = PasswordHelper.HashPassword(newPw)
            UserRepository.UpdatePassword(CInt(row("UserID")), newHash)
            ActivityLogger.Log(username, "Success", "Password reset via security question.")

            MessageBox.Show("Password reset successfully. Please log in with your new password.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim login As New LoginForm()
            login.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("A database error occurred:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Back to Login ─────────────────────────────────────────────
    Private Sub btnBackToLogin_Click(sender As Object, e As EventArgs) Handles btnBackToLogin.Click
        Dim login As New LoginForm()
        login.Show()
        Me.Close()
    End Sub

    ' ── Hover Effects ─────────────────────────────────────────────
    Private Sub btnSubmit_MouseEnter(sender As Object, e As EventArgs) Handles btnSubmit.MouseEnter
        btnSubmit.BackColor = Color.FromArgb(251, 108, 0)
    End Sub

    Private Sub btnSubmit_MouseLeave(sender As Object, e As EventArgs) Handles btnSubmit.MouseLeave
        btnSubmit.BackColor = Color.FromArgb(231, 63, 30)
    End Sub

    Private Sub btnBackToLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnBackToLogin.MouseEnter
        btnBackToLogin.BackColor = Color.FromArgb(220, 220, 220)
    End Sub

    Private Sub btnBackToLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnBackToLogin.MouseLeave
        btnBackToLogin.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

End Class
