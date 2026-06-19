Public Class AdminAccountSettingsForm
    Inherits Form

    ' ── Controls ─────────────────────────────────────────────────────
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlBody As Panel
    Private grpProfile As GroupBox
    Private lblUsernameField As Label
    Private WithEvents txtUsername As TextBox
    Private lblRoleLabel As Label
    Private lblRoleValue As Label
    Private grpPassword As GroupBox
    Private lblCurrentPw As Label
    Private WithEvents txtCurrentPw As TextBox
    Private lblNewPw As Label
    Private WithEvents txtNewPw As TextBox
    Private lblConfirmPw As Label
    Private WithEvents txtConfirmPw As TextBox
    Private lblPwHint As Label
    Private grpSecurity As GroupBox
    Private lblSecurityQuestion As Label
    Private WithEvents cmbSecurityQuestion As ComboBox
    Private lblSecurityAnswer As Label
    Private WithEvents txtSecurityAnswer As TextBox
    Private pnlFooter As Panel
    Private pnlDivider As Panel
    Friend WithEvents btnSave As Button

    Private _currentHash As String = ""

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlBody = New Panel()
        grpProfile = New GroupBox()
        lblUsernameField = New Label()
        txtUsername = New TextBox()
        lblRoleLabel = New Label()
        lblRoleValue = New Label()
        grpPassword = New GroupBox()
        lblCurrentPw = New Label()
        txtCurrentPw = New TextBox()
        lblNewPw = New Label()
        txtNewPw = New TextBox()
        lblConfirmPw = New Label()
        txtConfirmPw = New TextBox()
        lblPwHint = New Label()
        grpSecurity = New GroupBox()
        lblSecurityQuestion = New Label()
        cmbSecurityQuestion = New ComboBox()
        lblSecurityAnswer = New Label()
        txtSecurityAnswer = New TextBox()
        pnlFooter = New Panel()
        pnlDivider = New Panel()
        btnSave = New Button()

        SuspendLayout()

        ' ── pnlHeader ────────────────────────────────────────────────
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        lblTitle.Text = "Account Settings"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        lblSubtitle.Text = "Update your username, password, and security settings"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(500, 18)
        lblSubtitle.Location = New Point(16, 40)

        ' ── pnlBody ──────────────────────────────────────────────────
        pnlBody.BackColor = Color.FromArgb(245, 247, 250)
        pnlBody.Dock = DockStyle.Fill
        pnlBody.Padding = New Padding(16)
        pnlBody.AutoScroll = True
        pnlBody.Controls.Add(grpSecurity)
        pnlBody.Controls.Add(grpPassword)
        pnlBody.Controls.Add(grpProfile)

        ' ── grpProfile ───────────────────────────────────────────────
        grpProfile.Text = "Profile"
        grpProfile.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpProfile.ForeColor = Color.FromArgb(21, 67, 106)
        grpProfile.BackColor = Color.White
        grpProfile.Size = New Size(830, 100)
        grpProfile.Location = New Point(16, 16)
        grpProfile.Controls.Add(lblRoleValue)
        grpProfile.Controls.Add(lblRoleLabel)
        grpProfile.Controls.Add(txtUsername)
        grpProfile.Controls.Add(lblUsernameField)

        lblUsernameField.Text = "USERNAME"
        lblUsernameField.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblUsernameField.ForeColor = Color.FromArgb(100, 100, 100)
        lblUsernameField.AutoSize = False
        lblUsernameField.Size = New Size(256, 18)
        lblUsernameField.Location = New Point(16, 26)

        txtUsername.Font = New Font("Segoe UI", 10)
        txtUsername.Size = New Size(256, 28)
        txtUsername.Location = New Point(16, 46)
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.BackColor = Color.FromArgb(245, 248, 252)

        lblRoleLabel.Text = "ROLE"
        lblRoleLabel.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblRoleLabel.ForeColor = Color.FromArgb(100, 100, 100)
        lblRoleLabel.AutoSize = False
        lblRoleLabel.Size = New Size(200, 18)
        lblRoleLabel.Location = New Point(290, 26)

        lblRoleValue.Text = "Administrator"
        lblRoleValue.Font = New Font("Segoe UI", 10)
        lblRoleValue.ForeColor = Color.FromArgb(21, 67, 106)
        lblRoleValue.AutoSize = False
        lblRoleValue.Size = New Size(200, 28)
        lblRoleValue.Location = New Point(290, 46)

        ' ── grpPassword ──────────────────────────────────────────────
        grpPassword.Text = "Change Password"
        grpPassword.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpPassword.ForeColor = Color.FromArgb(21, 67, 106)
        grpPassword.BackColor = Color.White
        grpPassword.Size = New Size(830, 140)
        grpPassword.Location = New Point(16, 132)
        grpPassword.Controls.Add(lblPwHint)
        grpPassword.Controls.Add(txtConfirmPw)
        grpPassword.Controls.Add(lblConfirmPw)
        grpPassword.Controls.Add(txtNewPw)
        grpPassword.Controls.Add(lblNewPw)
        grpPassword.Controls.Add(txtCurrentPw)
        grpPassword.Controls.Add(lblCurrentPw)

        lblCurrentPw.Text = "CURRENT PASSWORD"
        lblCurrentPw.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblCurrentPw.ForeColor = Color.FromArgb(100, 100, 100)
        lblCurrentPw.AutoSize = False
        lblCurrentPw.Size = New Size(256, 18)
        lblCurrentPw.Location = New Point(16, 28)

        txtCurrentPw.Font = New Font("Segoe UI", 10)
        txtCurrentPw.Size = New Size(256, 28)
        txtCurrentPw.Location = New Point(16, 48)
        txtCurrentPw.BorderStyle = BorderStyle.FixedSingle
        txtCurrentPw.BackColor = Color.FromArgb(245, 248, 252)
        txtCurrentPw.PasswordChar = "*"c

        lblNewPw.Text = "NEW PASSWORD"
        lblNewPw.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblNewPw.ForeColor = Color.FromArgb(100, 100, 100)
        lblNewPw.AutoSize = False
        lblNewPw.Size = New Size(256, 18)
        lblNewPw.Location = New Point(290, 28)

        txtNewPw.Font = New Font("Segoe UI", 10)
        txtNewPw.Size = New Size(256, 28)
        txtNewPw.Location = New Point(290, 48)
        txtNewPw.BorderStyle = BorderStyle.FixedSingle
        txtNewPw.BackColor = Color.FromArgb(245, 248, 252)
        txtNewPw.PasswordChar = "*"c

        lblConfirmPw.Text = "CONFIRM NEW PASSWORD"
        lblConfirmPw.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblConfirmPw.ForeColor = Color.FromArgb(100, 100, 100)
        lblConfirmPw.AutoSize = False
        lblConfirmPw.Size = New Size(256, 18)
        lblConfirmPw.Location = New Point(564, 28)

        txtConfirmPw.Font = New Font("Segoe UI", 10)
        txtConfirmPw.Size = New Size(250, 28)
        txtConfirmPw.Location = New Point(564, 48)
        txtConfirmPw.BorderStyle = BorderStyle.FixedSingle
        txtConfirmPw.BackColor = Color.FromArgb(245, 248, 252)
        txtConfirmPw.PasswordChar = "*"c

        lblPwHint.Text = "Current password required to save any changes. Leave New Password blank to keep your current password."
        lblPwHint.Font = New Font("Segoe UI", 8, FontStyle.Italic)
        lblPwHint.ForeColor = Color.Gray
        lblPwHint.AutoSize = False
        lblPwHint.Size = New Size(800, 18)
        lblPwHint.Location = New Point(16, 94)

        ' ── grpSecurity ──────────────────────────────────────────────
        grpSecurity.Text = "Security Settings"
        grpSecurity.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpSecurity.ForeColor = Color.FromArgb(21, 67, 106)
        grpSecurity.BackColor = Color.White
        grpSecurity.Size = New Size(830, 100)
        grpSecurity.Location = New Point(16, 288)
        grpSecurity.Controls.Add(txtSecurityAnswer)
        grpSecurity.Controls.Add(lblSecurityAnswer)
        grpSecurity.Controls.Add(cmbSecurityQuestion)
        grpSecurity.Controls.Add(lblSecurityQuestion)

        lblSecurityQuestion.Text = "SECURITY QUESTION"
        lblSecurityQuestion.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblSecurityQuestion.ForeColor = Color.FromArgb(100, 100, 100)
        lblSecurityQuestion.AutoSize = False
        lblSecurityQuestion.Size = New Size(500, 18)
        lblSecurityQuestion.Location = New Point(16, 26)

        cmbSecurityQuestion.Font = New Font("Segoe UI", 10)
        cmbSecurityQuestion.Size = New Size(500, 28)
        cmbSecurityQuestion.Location = New Point(16, 46)
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

        lblSecurityAnswer.Text = "SECURITY ANSWER"
        lblSecurityAnswer.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblSecurityAnswer.ForeColor = Color.FromArgb(100, 100, 100)
        lblSecurityAnswer.AutoSize = False
        lblSecurityAnswer.Size = New Size(298, 18)
        lblSecurityAnswer.Location = New Point(534, 26)

        txtSecurityAnswer.Font = New Font("Segoe UI", 10)
        txtSecurityAnswer.Size = New Size(280, 28)
        txtSecurityAnswer.Location = New Point(534, 46)
        txtSecurityAnswer.BorderStyle = BorderStyle.FixedSingle
        txtSecurityAnswer.BackColor = Color.FromArgb(245, 248, 252)

        ' ── pnlFooter ────────────────────────────────────────────────
        pnlFooter.BackColor = Color.White
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 60
        pnlFooter.Controls.Add(btnSave)
        pnlFooter.Controls.Add(pnlDivider)

        pnlDivider.BackColor = Color.FromArgb(220, 220, 220)
        pnlDivider.Dock = DockStyle.Top
        pnlDivider.Height = 1

        btnSave.Text = "Save Changes"
        btnSave.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnSave.BackColor = Color.FromArgb(21, 67, 106)
        btnSave.ForeColor = Color.White
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.Size = New Size(140, 38)
        btnSave.Location = New Point(16, 12)
        btnSave.Cursor = Cursors.Hand

        ' ── Form ─────────────────────────────────────────────────────
        Me.Text = "LMS - Account Settings"
        Me.ClientSize = New Size(880, 520)
        Me.BackColor = Color.White
        Me.Controls.Add(pnlBody)
        Me.Controls.Add(pnlFooter)
        Me.Controls.Add(pnlHeader)

        ResumeLayout(False)
    End Sub

    ' ── Form Load ─────────────────────────────────────────────────────
    Private Sub AdminAccountSettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GATE — remove this block when unlocking for v1.07
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE
        Try
            Dim dt As DataTable = UserRepository.GetByID(SessionManager.CurrentUserID)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Your account record could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim row As DataRow = dt.Rows(0)
            txtUsername.Text = row("Username").ToString()
            _currentHash = row("PasswordHash").ToString()

            Dim question As String = row("SecurityQuestion").ToString()
            Dim questionIdx As Integer = cmbSecurityQuestion.Items.IndexOf(question)
            cmbSecurityQuestion.SelectedIndex = If(questionIdx >= 0, questionIdx, 0)
            txtSecurityAnswer.Text = row("SecurityAnswer").ToString()
        Catch ex As Exception
            MessageBox.Show($"Failed to load account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Save Button ───────────────────────────────────────────────────
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim newUsername As String = txtUsername.Text.Trim()
        Dim currentPw As String = txtCurrentPw.Text
        Dim newPw As String = txtNewPw.Text
        Dim confirmPw As String = txtConfirmPw.Text
        Dim securityAnswer As String = txtSecurityAnswer.Text.Trim()

        If newUsername = "" Then
            MessageBox.Show("Username cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus() : Return
        End If

        If currentPw = "" Then
            MessageBox.Show("Current password is required to save changes.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCurrentPw.Focus() : Return
        End If

        If securityAnswer = "" Then
            MessageBox.Show("Security answer is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSecurityAnswer.Focus() : Return
        End If

        If Not PasswordHelper.VerifyPassword(currentPw, _currentHash) Then
            MessageBox.Show("Current password is incorrect.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCurrentPw.Clear()
            txtCurrentPw.Focus()
            Return
        End If

        If newPw <> "" Then
            If newPw <> confirmPw Then
                MessageBox.Show("New passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtConfirmPw.Focus() : Return
            End If
            If newPw.Length < 6 Then
                MessageBox.Show("New password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNewPw.Focus() : Return
            End If
        End If

        Try
            Dim hashToSave As String = If(newPw = "", _currentHash, PasswordHelper.HashPassword(newPw))
            Dim securityQuestion As String = cmbSecurityQuestion.SelectedItem.ToString()

            UserRepository.UpdateAdminAccount(SessionManager.CurrentUserID, newUsername, hashToSave, securityQuestion, securityAnswer)

            If newUsername <> SessionManager.CurrentUsername Then
                SessionManager.SetSession(SessionManager.CurrentUserID, newUsername, SessionManager.CurrentRole, SessionManager.CurrentBorrowerID)
            End If

            _currentHash = hashToSave
            txtCurrentPw.Clear()
            txtNewPw.Clear()
            txtConfirmPw.Clear()

            ActivityLogger.Log(SessionManager.CurrentUsername, "Success", "Admin updated own account settings.")
            MessageBox.Show("Account settings saved successfully.", "Account Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Save failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Hover Effects ─────────────────────────────────────────────────
    Private Sub btnSave_MouseEnter(sender As Object, e As EventArgs) Handles btnSave.MouseEnter
        btnSave.BackColor = Color.FromArgb(30, 95, 150)
    End Sub
    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        btnSave.BackColor = Color.FromArgb(21, 67, 106)
    End Sub

End Class
