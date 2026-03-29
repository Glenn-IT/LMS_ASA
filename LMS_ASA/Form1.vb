Public Class LoginForm

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dashboard As New AdminDashboardForm()
        dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub lnkForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkForgotPassword.LinkClicked
        Dim forgotPw As New ForgotPasswordForm()
        forgotPw.Show()
        Me.Hide()
    End Sub

End Class
