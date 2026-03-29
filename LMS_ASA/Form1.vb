Public Class LoginForm

    ' ── Form Load ────────────────────────────────────────────────
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtUsername.Focus()
    End Sub

    ' ── Login Button ─────────────────────────────────────────────
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dashboard As New AdminDashboardForm()
        dashboard.Show()
        Me.Hide()
    End Sub

    ' ── Forgot Password Link ──────────────────────────────────────
    Private Sub lnkForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkForgotPassword.LinkClicked
        Dim forgotPw As New ForgotPasswordForm()
        forgotPw.Show()
        Me.Hide()
    End Sub

    ' ── Button Hover Effects ──────────────────────────────────────
    Private Sub btnLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnLogin.MouseEnter
        btnLogin.BackColor = Color.FromArgb(30, 95, 150)
    End Sub

    Private Sub btnLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.FromArgb(21, 67, 106)
    End Sub

    ' ── Allow Enter Key to Trigger Login ─────────────────────────
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click(sender, e)
        End If
    End Sub

End Class
