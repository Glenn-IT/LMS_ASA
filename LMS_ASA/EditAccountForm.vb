Public Class EditAccountForm
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
    Private lblNewPassword As Label
    Friend WithEvents txtNewPassword As TextBox
    Private lblConfirmPassword As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Private pnlFooter As Panel
    Private pnlDividerBottom As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button

    Public Property UserID As Integer = 0

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
        lblNewPassword = New Label()
        txtNewPassword = New TextBox()
        lblConfirmPassword = New Label()
        txtConfirmPassword = New TextBox()
        pnlFooter = New Panel()
        pnlDividerBottom = New Panel()
        btnSave = New Button()
        btnCancel = New Button()

        SuspendLayout()

        ' ?? pnlHeader ?????????????????????????????????????????????
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        lblTitle.Text = "Edit Account"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(231, 63, 30)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        lblSubtitle.Text = "Update username and reset password for this borrower account"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(500, 18)
        lblSubtitle.Location = New Point(16, 40)

        ' ── pnlDividerTop ─────────────────────────────────────────────
        pnlDividerTop.BackColor = Color.FromArgb(220, 220, 220)
        pnlDividerTop.Dock = DockStyle.Top
        pnlDividerTop.Height = 1

        ' ── pnlBody ───────────────────────────────────────────────────
        pnlBody.BackColor = Color.FromArgb(245, 247, 250)
        pnlBody.Dock = DockStyle.Fill
        pnlBody.Padding = New Padding(16)
        pnlBody.Controls.Add(grpCredentials)

        ' ── grpCredentials ────────────────────────────────────────────
        grpCredentials.Text = "Account Credentials"
        grpCredentials.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpCredentials.ForeColor = Color.FromArgb(231, 63, 30)
        grpCredentials.BackColor = Color.White
        grpCredentials.Size = New Size(700, 160)
        grpCredentials.Location = New Point(16, 16)
        grpCredentials.Controls.Add(txtConfirmPassword)
        grpCredentials.Controls.Add(lblConfirmPassword)
        grpCredentials.Controls.Add(txtNewPassword)
        grpCredentials.Controls.Add(lblNewPassword)
        grpCredentials.Controls.Add(txtUsername)
        grpCredentials.Controls.Add(lblUsername)

        ' Username
        lblUsername.Text = "USERNAME"
        lblUsername.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblUsername.ForeColor = Color.FromArgb(100, 100, 100)
        lblUsername.AutoSize = False
        lblUsername.Size = New Size(210, 18)
        lblUsername.Location = New Point(16, 28)

        txtUsername.Font = New Font("Segoe UI", 10)
        txtUsername.Size = New Size(210, 28)
        txtUsername.Location = New Point(16, 48)
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.BackColor = Color.FromArgb(255, 252, 248)

        ' New Password
        lblNewPassword.Text = "NEW PASSWORD (leave blank to keep)"
        lblNewPassword.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblNewPassword.ForeColor = Color.FromArgb(100, 100, 100)
        lblNewPassword.AutoSize = False
        lblNewPassword.Size = New Size(226, 18)
        lblNewPassword.Location = New Point(242, 28)

        txtNewPassword.Font = New Font("Segoe UI", 10)
        txtNewPassword.Size = New Size(226, 28)
        txtNewPassword.Location = New Point(242, 48)
        txtNewPassword.BorderStyle = BorderStyle.FixedSingle
        txtNewPassword.BackColor = Color.FromArgb(255, 252, 248)
        txtNewPassword.PasswordChar = "*"c

        ' Confirm Password
        lblConfirmPassword.Text = "CONFIRM PASSWORD"
        lblConfirmPassword.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblConfirmPassword.ForeColor = Color.FromArgb(100, 100, 100)
        lblConfirmPassword.AutoSize = False
        lblConfirmPassword.Size = New Size(220, 18)
        lblConfirmPassword.Location = New Point(484, 28)

        txtConfirmPassword.Font = New Font("Segoe UI", 10)
        txtConfirmPassword.Size = New Size(200, 28)
        txtConfirmPassword.Location = New Point(484, 48)
        txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle
        txtConfirmPassword.BackColor = Color.FromArgb(255, 252, 248)
        txtConfirmPassword.PasswordChar = "*"c

        ' Hint label for password field
        Dim lblHint As New Label()
        lblHint.Text = "Leave New Password blank to keep the current password unchanged."
        lblHint.Font = New Font("Segoe UI", 8, FontStyle.Italic)
        lblHint.ForeColor = Color.Gray
        lblHint.AutoSize = False
        lblHint.Size = New Size(660, 18)
        lblHint.Location = New Point(16, 90)
        grpCredentials.Controls.Add(lblHint)

        ' ── pnlFooter ─────────────────────────────────────────────────
        pnlFooter.BackColor = Color.White
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 60
        pnlFooter.Controls.Add(btnCancel)
        pnlFooter.Controls.Add(btnSave)
        pnlFooter.Controls.Add(pnlDividerBottom)

        pnlDividerBottom.BackColor = Color.FromArgb(220, 220, 220)
        pnlDividerBottom.Dock = DockStyle.Top
        pnlDividerBottom.Height = 1

        btnSave.Text = "Save Changes"
        btnSave.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnSave.BackColor = Color.FromArgb(231, 63, 30)
        btnSave.ForeColor = Color.White
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.Size = New Size(130, 38)
        btnSave.Location = New Point(16, 12)
        btnSave.Cursor = Cursors.Hand

        btnCancel.Text = "Cancel"
        btnCancel.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnCancel.BackColor = Color.FromArgb(240, 240, 240)
        btnCancel.ForeColor = Color.FromArgb(60, 60, 60)
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 1
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
        btnCancel.Size = New Size(130, 38)
        btnCancel.Location = New Point(160, 12)
        btnCancel.Cursor = Cursors.Hand

        ' ?? Form ??????????????????????????????????????????????????
        Me.Text = "LMS - Edit Account"
        Me.AcceptButton = btnSave
        Me.ClientSize = New Size(750, 320)
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
    Private Sub EditAccountForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dt As DataTable = UserRepository.GetByID(UserID)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If
            txtUsername.Text = dt.Rows(0)("Username").ToString()
        Catch ex As Exception
            MessageBox.Show($"Failed to load account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ?? Save Button ???????????????????????????????????????????????
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim newUsername As String = txtUsername.Text.Trim()
        If newUsername = "" Then
            MessageBox.Show("Username cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus() : Return
        End If

        Dim newPassword As String = txtNewPassword.Text
        Dim confirmPassword As String = txtConfirmPassword.Text

        If newPassword <> "" Then
            If newPassword <> confirmPassword Then
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtConfirmPassword.Focus() : Return
            End If
            If newPassword.Length < 6 Then
                MessageBox.Show("Password must be at least 6 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNewPassword.Focus() : Return
            End If
        End If

        Try
            Dim hashToSave As String
            If newPassword = "" Then
                Dim dt As DataTable = UserRepository.GetByID(UserID)
                hashToSave = dt.Rows(0)("PasswordHash").ToString()
            Else
                hashToSave = PasswordHelper.HashPassword(newPassword)
            End If

            UserRepository.UpdateAccount(UserID, newUsername, hashToSave)
            ActivityLogger.Log(SessionManager.CurrentUsername, "Success",
                $"Updated account ID {UserID}: username set to {newUsername}")
            MessageBox.Show("Account updated successfully.", "Account Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Save failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ?? Cancel Button ?????????????????????????????????????????????
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ' ── Hover Effects ─────────────────────────────────────────────
    Private Sub btnSave_MouseEnter(sender As Object, e As EventArgs) Handles btnSave.MouseEnter
        btnSave.BackColor = Color.FromArgb(251, 108, 0)
    End Sub
    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        btnSave.BackColor = Color.FromArgb(231, 63, 30)
    End Sub
    Private Sub btnCancel_MouseEnter(sender As Object, e As EventArgs) Handles btnCancel.MouseEnter
        btnCancel.BackColor = Color.FromArgb(220, 220, 220)
    End Sub
    Private Sub btnCancel_MouseLeave(sender As Object, e As EventArgs) Handles btnCancel.MouseLeave
        btnCancel.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

End Class
