Public Class UnderConstructionForm
    Inherits Form

    Public Const CURRENT_VERSION As String = "v1.09"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Dim lblEmoji As New Label()
        Dim lblVersion As New Label()
        Dim lblTitle As New Label()
        Dim lblDesc As New Label()
        Dim btnBack As New Button()

        SuspendLayout()

        Me.BackColor = Color.FromArgb(26, 35, 126)
        Me.ClientSize = New Size(480, 320)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "Under Construction"

        lblEmoji.Text = "🚧"
        lblEmoji.Font = New Font("Segoe UI Emoji", 36.0F)
        lblEmoji.ForeColor = Color.White
        lblEmoji.AutoSize = False
        lblEmoji.Size = New Size(480, 60)
        lblEmoji.Location = New Point(0, 20)
        lblEmoji.TextAlign = ContentAlignment.MiddleCenter

        lblVersion.Text = "Current Version: " & CURRENT_VERSION
        lblVersion.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblVersion.ForeColor = Color.Orange
        lblVersion.AutoSize = False
        lblVersion.Size = New Size(480, 28)
        lblVersion.Location = New Point(0, 95)
        lblVersion.TextAlign = ContentAlignment.MiddleCenter

        lblTitle.Text = "Under Construction"
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(480, 40)
        lblTitle.Location = New Point(0, 133)
        lblTitle.TextAlign = ContentAlignment.MiddleCenter

        lblDesc.Text = "This feature is not yet available in the current presentation version."
        lblDesc.Font = New Font("Segoe UI", 9.5F)
        lblDesc.ForeColor = Color.FromArgb(200, 200, 255)
        lblDesc.AutoSize = False
        lblDesc.Size = New Size(440, 36)
        lblDesc.Location = New Point(20, 183)
        lblDesc.TextAlign = ContentAlignment.MiddleCenter

        btnBack.Text = "← Go Back"
        btnBack.Font = New Font("Segoe UI", 10.0F)
        btnBack.BackColor = Color.FromArgb(48, 63, 159)
        btnBack.ForeColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.FlatAppearance.BorderColor = Color.FromArgb(92, 107, 192)
        btnBack.Size = New Size(130, 38)
        btnBack.Location = New Point(175, 248)
        btnBack.Cursor = Cursors.Hand
        AddHandler btnBack.Click, AddressOf btnBack_Click

        Me.Controls.AddRange({lblEmoji, lblVersion, lblTitle, lblDesc, btnBack})

        ResumeLayout(False)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

End Class
