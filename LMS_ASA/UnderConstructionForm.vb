Public Class UnderConstructionForm
    Inherits Form

    Public Const CURRENT_VERSION As String = "v5.00"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        lblEmoji = New Label()
        lblVersion = New Label()
        lblTitle = New Label()
        lblDesc = New Label()
        btnBack = New Button()
        SuspendLayout()
        ' 
        ' lblEmoji
        ' 
        lblEmoji.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblEmoji.Font = New Font("Segoe UI Emoji", 36F)
        lblEmoji.ForeColor = Color.White
        lblEmoji.Location = New Point(0, 20)
        lblEmoji.Name = "lblEmoji"
        lblEmoji.Size = New Size(480, 60)
        lblEmoji.TabIndex = 0
        lblEmoji.Text = "🚧"
        lblEmoji.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblVersion
        ' 
        lblVersion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblVersion.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        lblVersion.ForeColor = Color.Orange
        lblVersion.Location = New Point(0, 95)
        lblVersion.Name = "lblVersion"
        lblVersion.Size = New Size(480, 28)
        lblVersion.TabIndex = 1
        lblVersion.Text = "Current Version: " & CURRENT_VERSION
        lblVersion.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTitle
        ' 
        lblTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(0, 133)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(480, 40)
        lblTitle.TabIndex = 2
        lblTitle.Text = "Under Construction"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDesc
        ' 
        lblDesc.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblDesc.Font = New Font("Segoe UI", 9.5F)
        lblDesc.ForeColor = Color.FromArgb(CByte(200), CByte(200), CByte(255))
        lblDesc.Location = New Point(20, 183)
        lblDesc.Name = "lblDesc"
        lblDesc.Size = New Size(440, 36)
        lblDesc.TabIndex = 3
        lblDesc.Text = "This feature is not yet available in the current presentation version."
        lblDesc.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnBack
        ' 
        btnBack.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnBack.BackColor = Color.FromArgb(CByte(48), CByte(63), CByte(159))
        btnBack.Cursor = Cursors.Hand
        btnBack.FlatAppearance.BorderColor = Color.FromArgb(CByte(92), CByte(107), CByte(192))
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Segoe UI", 10F)
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(175, 248)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(130, 38)
        btnBack.TabIndex = 4
        btnBack.Text = "← Go Back"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' UnderConstructionForm
        ' 
        BackColor = Color.FromArgb(CByte(26), CByte(35), CByte(126))
        ClientSize = New Size(480, 320)
        Controls.Add(lblEmoji)
        Controls.Add(lblVersion)
        Controls.Add(lblTitle)
        Controls.Add(lblDesc)
        Controls.Add(btnBack)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "UnderConstructionForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Under Construction"
        WindowState = FormWindowState.Maximized
        ResumeLayout(False)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Friend WithEvents lblEmoji As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblDesc As Label
    Friend WithEvents btnBack As Button

End Class
