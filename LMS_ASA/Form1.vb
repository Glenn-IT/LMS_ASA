Public Class LoginForm

    Private _failedAttempts As Integer = 0
    Private _countdown As Integer = 0
    Private WithEvents _lockoutTimer As New Timer() With {.Interval = 1000}

    ' ── Form Load ────────────────────────────────────────────────
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtUsername.Focus()
    End Sub

    ' ── LOGIN button ─────────────────────────────────────────────
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter your username and password.",
                            "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim dt As DataTable = UserRepository.GetByUsername(username)

            If dt.Rows.Count = 0 Then
                HandleFailedLogin(username, "Login failed — username not found.")
                Return
            End If

            Dim row As DataRow = dt.Rows(0)

            If Not PasswordHelper.VerifyPassword(password, row("PasswordHash").ToString()) Then
                HandleFailedLogin(username, "Login failed — incorrect password.")
                Return
            End If

            ' ── Successful login ──────────────────────────────────
            _failedAttempts = 0

            Dim userID     As Integer = CInt(row("UserID"))
            Dim role       As String  = row("Role").ToString()
            Dim borrowerID As Integer = 0

            If role = "Borrower" Then
                Dim bDt As DataTable = BorrowerRepository.GetByUserID(userID)
                If bDt.Rows.Count > 0 Then borrowerID = CInt(bDt.Rows(0)("BorrowerID"))
            End If

            SessionManager.SetSession(userID, username, role, borrowerID)
            ActivityLogger.Log(username, "Success", "User logged in.")

            MessageBox.Show($"Login successful! Welcome, {username}.",
                            "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If role = "Admin" Then
                Dim dashboard As New AdminDashboardForm()
                dashboard.Show()
            Else
                Dim dashboard As New BorrowerDashboardForm()
                dashboard.Show()
            End If
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("A database error occurred:" & Environment.NewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Brute-force lockout helpers ───────────────────────────────
    Private Sub HandleFailedLogin(username As String, logMsg As String)
        ActivityLogger.Log(username, "Failed", logMsg)
        txtPassword.Clear()
        _failedAttempts += 1

        If _failedAttempts >= 3 Then
            StartLockout()
        Else
            Dim attemptsLeft As Integer = 3 - _failedAttempts
            MessageBox.Show($"Invalid username or password. {attemptsLeft} attempt(s) remaining before lockout.",
                            "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
        End If
    End Sub

    Private Sub StartLockout()
        _countdown = 15
        btnLogin.Enabled = False
        btnLogin.Text = $"Locked ({_countdown}s)"
        _lockoutTimer.Start()
        MessageBox.Show("Too many failed attempts. Login is locked for 15 seconds.",
                        "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub _lockoutTimer_Tick(sender As Object, e As EventArgs) Handles _lockoutTimer.Tick
        _countdown -= 1
        btnLogin.Text = $"Locked ({_countdown}s)"
        If _countdown <= 0 Then
            _lockoutTimer.Stop()
            _failedAttempts = 0
            btnLogin.Enabled = True
            btnLogin.Text = "Login"
            txtUsername.Focus()
        End If
    End Sub

    ' ── Show Password Toggle ──────────────────────────────────────
    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.PasswordChar = If(chkShowPassword.Checked, Chr(0), "●"c)
    End Sub

    ' ── Forgot Password Link ──────────────────────────────────────
    Private Sub lnkForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkForgotPassword.LinkClicked
        Dim forgotPw As New ForgotPasswordForm()
        forgotPw.Show()
        Me.Hide()
    End Sub

    ' ── Allow Enter Key to Trigger Login ─────────────────────────
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click(sender, e)
        End If
    End Sub

    ' ── Hover Effects ─────────────────────────────────────────────
    Private Sub btnLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnLogin.MouseEnter
        If btnLogin.Enabled Then btnLogin.BackColor = Color.FromArgb(30, 95, 150)
    End Sub
    Private Sub btnLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        If btnLogin.Enabled Then btnLogin.BackColor = Color.FromArgb(21, 67, 106)
    End Sub

End Class
