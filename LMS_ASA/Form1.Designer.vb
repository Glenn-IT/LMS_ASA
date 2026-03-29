<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlMain = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlCard = New Panel()
        lblHeader = New Label()
        lblUsername = New Label()
        txtUsername = New TextBox()
        lblPassword = New Label()
        txtPassword = New TextBox()
        btnLogin = New Button()
        lnkForgotPassword = New LinkLabel()
        pnlMain.SuspendLayout()
        pnlCard.SuspendLayout()
        SuspendLayout()

        ' pnlMain
        pnlMain.BackColor = Color.FromArgb(31, 78, 121)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Controls.Add(lblTitle)
        pnlMain.Controls.Add(lblSubtitle)
        pnlMain.Controls.Add(pnlCard)

        ' lblTitle
        lblTitle.Text = "Loan Management System"
        lblTitle.Font = New Font("Segoe UI", 22, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Size = New Size(760, 50)
        lblTitle.Location = New Point(20, 60)

        ' lblSubtitle
        lblSubtitle.Text = "ASA Philippines Foundation, Inc."
        lblSubtitle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.FromArgb(180, 220, 255)
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        lblSubtitle.Size = New Size(760, 28)
        lblSubtitle.Location = New Point(20, 112)

        ' pnlCard
        pnlCard.BackColor = Color.White
        pnlCard.Size = New Size(380, 370)
        pnlCard.Location = New Point(210, 158)

        ' lblHeader
        lblHeader.Text = "Sign In"
        lblHeader.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblHeader.ForeColor = Color.FromArgb(31, 78, 121)
        lblHeader.Size = New Size(340, 36)
        lblHeader.Location = New Point(20, 24)
        pnlCard.Controls.Add(lblHeader)

        ' lblUsername
        lblUsername.Text = "Username"
        lblUsername.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblUsername.ForeColor = Color.Gray
        lblUsername.Size = New Size(340, 20)
        lblUsername.Location = New Point(20, 80)
        pnlCard.Controls.Add(lblUsername)

        ' txtUsername
        txtUsername.Font = New Font("Segoe UI", 10)
        txtUsername.Size = New Size(340, 28)
        txtUsername.Location = New Point(20, 102)
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        pnlCard.Controls.Add(txtUsername)

        ' lblPassword
        lblPassword.Text = "Password"
        lblPassword.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblPassword.ForeColor = Color.Gray
        lblPassword.Size = New Size(340, 20)
        lblPassword.Location = New Point(20, 148)
        pnlCard.Controls.Add(lblPassword)

        ' txtPassword
        txtPassword.Font = New Font("Segoe UI", 10)
        txtPassword.Size = New Size(340, 28)
        txtPassword.Location = New Point(20, 170)
        txtPassword.PasswordChar = "●"c
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        pnlCard.Controls.Add(txtPassword)

        ' btnLogin
        btnLogin.Text = "LOGIN"
        btnLogin.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnLogin.BackColor = Color.FromArgb(31, 78, 121)
        btnLogin.ForeColor = Color.White
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.Size = New Size(340, 42)
        btnLogin.Location = New Point(20, 224)
        btnLogin.Cursor = Cursors.Hand
        pnlCard.Controls.Add(btnLogin)

        ' lnkForgotPassword
        lnkForgotPassword.Text = "Forgot Password?"
        lnkForgotPassword.Font = New Font("Segoe UI", 9)
        lnkForgotPassword.LinkColor = Color.FromArgb(31, 78, 121)
        lnkForgotPassword.Size = New Size(340, 20)
        lnkForgotPassword.Location = New Point(20, 288)
        lnkForgotPassword.TextAlign = ContentAlignment.MiddleCenter
        pnlCard.Controls.Add(lnkForgotPassword)

        ' LoginForm
        Me.AutoScaleDimensions = New SizeF(7F, 15F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(800, 580)
        Me.Controls.Add(pnlMain)
        Me.Text = "LMS – Login"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        pnlMain.ResumeLayout(False)
        pnlCard.ResumeLayout(False)
        pnlCard.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlCard As Panel
    Friend WithEvents lblHeader As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents lnkForgotPassword As LinkLabel

End Class
