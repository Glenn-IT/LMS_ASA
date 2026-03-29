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
        pnlBackground = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlCard = New Panel()
        pnlAccent = New Panel()
        lblHeader = New Label()
        lblWelcome = New Label()
        lblUsername = New Label()
        txtUsername = New TextBox()
        lblPassword = New Label()
        txtPassword = New TextBox()
        btnLogin = New Button()
        pnlDivider = New Panel()
        lblRolePrompt = New Label()
        btnAdmin = New Button()
        btnUser = New Button()
        lnkForgotPassword = New LinkLabel()
        lblFooter = New Label()

        pnlBackground.SuspendLayout()
        pnlCard.SuspendLayout()
        SuspendLayout()

        ' ── pnlBackground ────────────────────────────────────────
        pnlBackground.BackColor = Color.FromArgb(21, 67, 106)
        pnlBackground.Dock = DockStyle.Fill
        pnlBackground.Controls.Add(lblTitle)
        pnlBackground.Controls.Add(lblSubtitle)
        pnlBackground.Controls.Add(pnlCard)
        pnlBackground.Controls.Add(lblFooter)

        ' ── lblTitle ─────────────────────────────────────────────
        lblTitle.Text = "Loan Management System"
        lblTitle.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Size = New Size(800, 52)
        lblTitle.Location = New Point(0, 40)
        lblTitle.AutoSize = False

        ' ── lblSubtitle ───────────────────────────────────────────
        lblSubtitle.Text = "ASA Philippines Foundation, Inc."
        lblSubtitle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.FromArgb(173, 216, 255)
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        lblSubtitle.Size = New Size(800, 28)
        lblSubtitle.Location = New Point(0, 94)
        lblSubtitle.AutoSize = False

        ' ── pnlCard ──────────────────────────────────────────────
        pnlCard.BackColor = Color.White
        pnlCard.Size = New Size(400, 500)
        pnlCard.Location = New Point(200, 134)
        pnlCard.Controls.Add(pnlAccent)
        pnlCard.Controls.Add(lblHeader)
        pnlCard.Controls.Add(lblWelcome)
        pnlCard.Controls.Add(lblUsername)
        pnlCard.Controls.Add(txtUsername)
        pnlCard.Controls.Add(lblPassword)
        pnlCard.Controls.Add(txtPassword)
        pnlCard.Controls.Add(btnLogin)
        pnlCard.Controls.Add(pnlDivider)
        pnlCard.Controls.Add(lblRolePrompt)
        pnlCard.Controls.Add(btnAdmin)
        pnlCard.Controls.Add(btnUser)
        pnlCard.Controls.Add(lnkForgotPassword)

        ' ── pnlAccent (top colored bar on card) ──────────────────
        pnlAccent.BackColor = Color.FromArgb(21, 67, 106)
        pnlAccent.Size = New Size(400, 6)
        pnlAccent.Location = New Point(0, 0)

        ' ── lblHeader ────────────────────────────────────────────
        lblHeader.Text = "Sign In"
        lblHeader.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblHeader.ForeColor = Color.FromArgb(21, 67, 106)
        lblHeader.AutoSize = False
        lblHeader.Size = New Size(360, 40)
        lblHeader.Location = New Point(20, 20)

        ' ── lblWelcome ───────────────────────────────────────────
        lblWelcome.Text = "Welcome back! Please enter your credentials."
        lblWelcome.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblWelcome.ForeColor = Color.Gray
        lblWelcome.AutoSize = False
        lblWelcome.Size = New Size(360, 20)
        lblWelcome.Location = New Point(20, 62)

        ' ── lblUsername ───────────────────────────────────────────
        lblUsername.Text = "USERNAME"
        lblUsername.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblUsername.ForeColor = Color.FromArgb(100, 100, 100)
        lblUsername.AutoSize = False
        lblUsername.Size = New Size(360, 18)
        lblUsername.Location = New Point(20, 100)

        ' ── txtUsername ───────────────────────────────────────────
        txtUsername.Font = New Font("Segoe UI", 10)
        txtUsername.Size = New Size(360, 28)
        txtUsername.Location = New Point(20, 120)
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.BackColor = Color.FromArgb(245, 248, 252)

        ' ── lblPassword ───────────────────────────────────────────
        lblPassword.Text = "PASSWORD"
        lblPassword.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblPassword.ForeColor = Color.FromArgb(100, 100, 100)
        lblPassword.AutoSize = False
        lblPassword.Size = New Size(360, 18)
        lblPassword.Location = New Point(20, 166)

        ' ── txtPassword ───────────────────────────────────────────
        txtPassword.Font = New Font("Segoe UI", 10)
        txtPassword.Size = New Size(360, 28)
        txtPassword.Location = New Point(20, 186)
        txtPassword.PasswordChar = "●"c
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.BackColor = Color.FromArgb(245, 248, 252)

        ' ── btnLogin ──────────────────────────────────────────────
        btnLogin.Text = "LOGIN"
        btnLogin.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnLogin.BackColor = Color.FromArgb(21, 67, 106)
        btnLogin.ForeColor = Color.White
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.Size = New Size(360, 44)
        btnLogin.Location = New Point(20, 234)
        btnLogin.Cursor = Cursors.Hand

        ' ── pnlDivider ────────────────────────────────────────────
        pnlDivider.BackColor = Color.FromArgb(220, 220, 220)
        pnlDivider.Size = New Size(360, 1)
        pnlDivider.Location = New Point(20, 296)

        ' ── lblRolePrompt ─────────────────────────────────────────
        lblRolePrompt.Text = "OR CONTINUE AS"
        lblRolePrompt.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblRolePrompt.ForeColor = Color.FromArgb(160, 160, 160)
        lblRolePrompt.AutoSize = False
        lblRolePrompt.Size = New Size(360, 20)
        lblRolePrompt.Location = New Point(20, 308)
        lblRolePrompt.TextAlign = ContentAlignment.MiddleCenter

        ' ── btnAdmin ──────────────────────────────────────────────
        btnAdmin.Text = "Admin"
        btnAdmin.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnAdmin.BackColor = Color.FromArgb(52, 120, 180)
        btnAdmin.ForeColor = Color.White
        btnAdmin.FlatStyle = FlatStyle.Flat
        btnAdmin.FlatAppearance.BorderSize = 0
        btnAdmin.Size = New Size(174, 44)
        btnAdmin.Location = New Point(20, 334)
        btnAdmin.Cursor = Cursors.Hand

        ' ── btnUser ───────────────────────────────────────────────
        btnUser.Text = "Borrower / User"
        btnUser.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnUser.BackColor = Color.FromArgb(39, 174, 96)
        btnUser.ForeColor = Color.White
        btnUser.FlatStyle = FlatStyle.Flat
        btnUser.FlatAppearance.BorderSize = 0
        btnUser.Size = New Size(174, 44)
        btnUser.Location = New Point(206, 334)
        btnUser.Cursor = Cursors.Hand

        ' ── lnkForgotPassword ─────────────────────────────────────
        lnkForgotPassword.Text = "Forgot Password?"
        lnkForgotPassword.Font = New Font("Segoe UI", 9)
        lnkForgotPassword.LinkColor = Color.FromArgb(21, 67, 106)
        lnkForgotPassword.ActiveLinkColor = Color.FromArgb(52, 152, 219)
        lnkForgotPassword.AutoSize = False
        lnkForgotPassword.Size = New Size(360, 24)
        lnkForgotPassword.Location = New Point(20, 396)
        lnkForgotPassword.TextAlign = ContentAlignment.MiddleCenter

        ' ── lblFooter ─────────────────────────────────────────────
        lblFooter.Text = "© 2025 ASA Philippines Foundation, Inc. — For Presentation Use Only"
        lblFooter.Font = New Font("Segoe UI", 8, FontStyle.Regular)
        lblFooter.ForeColor = Color.FromArgb(120, 160, 200)
        lblFooter.TextAlign = ContentAlignment.MiddleCenter
        lblFooter.AutoSize = False
        lblFooter.Size = New Size(800, 24)
        lblFooter.Location = New Point(0, 652)

        ' ── LoginForm ─────────────────────────────────────────────
        Me.AutoScaleDimensions = New SizeF(7F, 15F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(800, 690)
        Me.Controls.Add(pnlBackground)
        Me.Text = "LMS – Login"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = True
        Me.BackColor = Color.FromArgb(21, 67, 106)

        pnlBackground.ResumeLayout(False)
        pnlCard.ResumeLayout(False)
        pnlCard.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlBackground As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlCard As Panel
    Friend WithEvents pnlAccent As Panel
    Friend WithEvents lblHeader As Label
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents pnlDivider As Panel
    Friend WithEvents lblRolePrompt As Label
    Friend WithEvents btnAdmin As Button
    Friend WithEvents btnUser As Button
    Friend WithEvents lnkForgotPassword As LinkLabel
    Friend WithEvents lblFooter As Label

End Class
