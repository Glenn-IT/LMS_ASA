Public Class LoginForm

    ' ── Form Load ────────────────────────────────────────────────
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtUsername.Focus()
    End Sub

    ' ── LOGIN button — opens Admin Dashboard ──────────────────────
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dashboard As New AdminDashboardForm()
        dashboard.Show()
        Me.Hide()
    End Sub

    ' ── Admin role button ─────────────────────────────────────────
    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Dim dashboard As New AdminDashboardForm()
        dashboard.Show()
        Me.Hide()
    End Sub

    ' ── Borrower / User role button ───────────────────────────────
    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        Dim dashboard As New BorrowerDashboardForm()
        dashboard.Show()
        Me.Hide()
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
        btnLogin.BackColor = Color.FromArgb(30, 95, 150)
    End Sub
    Private Sub btnLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.FromArgb(21, 67, 106)
    End Sub

    Private Sub btnAdmin_MouseEnter(sender As Object, e As EventArgs) Handles btnAdmin.MouseEnter
        btnAdmin.BackColor = Color.FromArgb(40, 100, 160)
    End Sub
    Private Sub btnAdmin_MouseLeave(sender As Object, e As EventArgs) Handles btnAdmin.MouseLeave
        btnAdmin.BackColor = Color.FromArgb(52, 120, 180)
    End Sub

    Private Sub btnUser_MouseEnter(sender As Object, e As EventArgs) Handles btnUser.MouseEnter
        btnUser.BackColor = Color.FromArgb(30, 140, 75)
    End Sub
    Private Sub btnUser_MouseLeave(sender As Object, e As EventArgs) Handles btnUser.MouseLeave
        btnUser.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

End Class
