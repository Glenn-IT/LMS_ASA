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
        ' 
        ' pnlBackground
        ' 
        pnlBackground.BackColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        pnlBackground.Controls.Add(lblTitle)
        pnlBackground.Controls.Add(lblSubtitle)
        pnlBackground.Controls.Add(pnlCard)
        pnlBackground.Controls.Add(lblFooter)
        pnlBackground.Dock = DockStyle.Fill
        pnlBackground.Location = New Point(0, 0)
        pnlBackground.Name = "pnlBackground"
        pnlBackground.Size = New Size(800, 782)
        pnlBackground.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(0, 45)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(800, 59)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Loan Management System"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Font = New Font("Segoe UI", 11F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(173), CByte(216), CByte(255))
        lblSubtitle.Location = New Point(0, 107)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(800, 32)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "ASA Philippines Foundation, Inc."
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlCard
        ' 
        pnlCard.BackColor = Color.White
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
        pnlCard.Location = New Point(200, 152)
        pnlCard.Name = "pnlCard"
        pnlCard.Size = New Size(400, 567)
        pnlCard.TabIndex = 2
        ' 
        ' pnlAccent
        ' 
        pnlAccent.BackColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        pnlAccent.Location = New Point(0, 0)
        pnlAccent.Name = "pnlAccent"
        pnlAccent.Size = New Size(400, 7)
        pnlAccent.TabIndex = 0
        ' 
        ' lblHeader
        ' 
        lblHeader.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblHeader.ForeColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        lblHeader.Location = New Point(20, 23)
        lblHeader.Name = "lblHeader"
        lblHeader.Size = New Size(360, 45)
        lblHeader.TabIndex = 1
        lblHeader.Text = "Sign In"
        ' 
        ' lblWelcome
        ' 
        lblWelcome.Font = New Font("Segoe UI", 9F)
        lblWelcome.ForeColor = Color.Gray
        lblWelcome.Location = New Point(20, 70)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(360, 23)
        lblWelcome.TabIndex = 2
        lblWelcome.Text = "Welcome back! Please enter your credentials."
        ' 
        ' lblUsername
        ' 
        lblUsername.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblUsername.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblUsername.Location = New Point(20, 113)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(360, 20)
        lblUsername.TabIndex = 3
        lblUsername.Text = "USERNAME"
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.FromArgb(CByte(245), CByte(248), CByte(252))
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.Font = New Font("Segoe UI", 10F)
        txtUsername.Location = New Point(20, 136)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(360, 27)
        txtUsername.TabIndex = 4
        ' 
        ' lblPassword
        ' 
        lblPassword.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblPassword.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblPassword.Location = New Point(20, 188)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(360, 20)
        lblPassword.TabIndex = 5
        lblPassword.Text = "PASSWORD"
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.FromArgb(CByte(245), CByte(248), CByte(252))
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Font = New Font("Segoe UI", 10F)
        txtPassword.Location = New Point(20, 211)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "●"c
        txtPassword.Size = New Size(360, 27)
        txtPassword.TabIndex = 6
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        btnLogin.Cursor = Cursors.Hand
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(20, 265)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(360, 50)
        btnLogin.TabIndex = 7
        btnLogin.Text = "LOGIN"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' pnlDivider
        ' 
        pnlDivider.BackColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        pnlDivider.Location = New Point(20, 335)
        pnlDivider.Name = "pnlDivider"
        pnlDivider.Size = New Size(360, 1)
        pnlDivider.TabIndex = 8
        ' 
        ' lblRolePrompt
        ' 
        lblRolePrompt.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblRolePrompt.ForeColor = Color.FromArgb(CByte(160), CByte(160), CByte(160))
        lblRolePrompt.Location = New Point(20, 349)
        lblRolePrompt.Name = "lblRolePrompt"
        lblRolePrompt.Size = New Size(360, 23)
        lblRolePrompt.TabIndex = 9
        lblRolePrompt.Text = "OR CONTINUE AS"
        lblRolePrompt.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnAdmin
        ' 
        btnAdmin.BackColor = Color.FromArgb(CByte(52), CByte(120), CByte(180))
        btnAdmin.Cursor = Cursors.Hand
        btnAdmin.FlatAppearance.BorderSize = 0
        btnAdmin.FlatStyle = FlatStyle.Flat
        btnAdmin.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnAdmin.ForeColor = Color.White
        btnAdmin.Location = New Point(20, 379)
        btnAdmin.Name = "btnAdmin"
        btnAdmin.Size = New Size(174, 50)
        btnAdmin.TabIndex = 10
        btnAdmin.Text = "Admin"
        btnAdmin.UseVisualStyleBackColor = False
        ' 
        ' btnUser
        ' 
        btnUser.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnUser.Cursor = Cursors.Hand
        btnUser.FlatAppearance.BorderSize = 0
        btnUser.FlatStyle = FlatStyle.Flat
        btnUser.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnUser.ForeColor = Color.White
        btnUser.Location = New Point(206, 379)
        btnUser.Name = "btnUser"
        btnUser.Size = New Size(174, 50)
        btnUser.TabIndex = 11
        btnUser.Text = "Borrower / User"
        btnUser.UseVisualStyleBackColor = False
        ' 
        ' lnkForgotPassword
        ' 
        lnkForgotPassword.ActiveLinkColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        lnkForgotPassword.Font = New Font("Segoe UI", 9F)
        lnkForgotPassword.LinkColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        lnkForgotPassword.Location = New Point(20, 449)
        lnkForgotPassword.Name = "lnkForgotPassword"
        lnkForgotPassword.Size = New Size(360, 27)
        lnkForgotPassword.TabIndex = 12
        lnkForgotPassword.TabStop = True
        lnkForgotPassword.Text = "Forgot Password?"
        lnkForgotPassword.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblFooter
        ' 
        lblFooter.Font = New Font("Segoe UI", 8F)
        lblFooter.ForeColor = Color.FromArgb(CByte(120), CByte(160), CByte(200))
        lblFooter.Location = New Point(0, 739)
        lblFooter.Name = "lblFooter"
        lblFooter.Size = New Size(800, 27)
        lblFooter.TabIndex = 3
        lblFooter.Text = "© 2025 ASA Philippines Foundation, Inc. — For Presentation Use Only"
        lblFooter.TextAlign = ContentAlignment.MiddleCenter
        lblFooter.Visible = False
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        ClientSize = New Size(800, 782)
        Controls.Add(pnlBackground)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LMS – Login"
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
