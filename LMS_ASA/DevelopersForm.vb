Public Class DevelopersForm
    Inherits Form

    ' =========================================================================
    ' DEVELOPER CONFIGURATION / PLACEHOLDERS
    ' Edit the constants or properties below to update developer details
    ' =========================================================================
    Private Const DEV1_NAME As String = "[Developer 1 Name]"
    Private Const DEV1_ROLE As String = "Lead Developer & System Architect"
    Private Const DEV1_ID As String = "ID No. 202X-XXXXX"
    Private Const DEV1_EMAIL As String = "developer1@domain.com"
    Private Const DEV1_COURSE As String = "BS Information Technology"
    Private Const DEV1_BIO As String = "Responsible for core backend system architecture, database schema, loan calculation engine, and security management."

    Private Const DEV2_NAME As String = "[Developer 2 Name]"
    Private Const DEV2_ROLE As String = "Frontend Developer & UI/UX Specialist"
    Private Const DEV2_ID As String = "ID No. 202X-XXXXX"
    Private Const DEV2_EMAIL As String = "developer2@domain.com"
    Private Const DEV2_COURSE As String = "BS Information Technology"
    Private Const DEV2_BIO As String = "Responsible for user interface design, dashboard experience, system documentation, and quality assurance testing."
    ' =========================================================================

    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlDividerTop As Panel
    Private pnlBody As Panel

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlDividerTop = New Panel()
        pnlBody = New Panel()

        SuspendLayout()

        ' ── Header Panel ──────────────────────────────────────────────
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        lblTitle.Text = "Development Team"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        lblSubtitle.Text = "System developers and technical contributors behind LMS-ASA"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(500, 18)
        lblSubtitle.Location = New Point(16, 40)

        ' ── Divider ───────────────────────────────────────────────────
        pnlDividerTop.BackColor = Color.FromArgb(220, 220, 220)
        pnlDividerTop.Dock = DockStyle.Top
        pnlDividerTop.Height = 1

        ' ── Body (Scrollable Container) ──────────────────────────────
        pnlBody.BackColor = Color.FromArgb(245, 247, 250)
        pnlBody.Dock = DockStyle.Fill
        pnlBody.Padding = New Padding(20)
        pnlBody.AutoScroll = True

        ' ── Banner Card ───────────────────────────────────────────────
        Dim pnlBanner As New Panel()
        pnlBanner.BackColor = Color.FromArgb(21, 67, 106)
        pnlBanner.Size = New Size(860, 95)
        pnlBanner.Location = New Point(20, 16)
        pnlBanner.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        Dim lblBannerTitle As New Label()
        lblBannerTitle.Text = "Loan Management System — ASA Philippines"
        lblBannerTitle.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        lblBannerTitle.ForeColor = Color.White
        lblBannerTitle.Location = New Point(20, 14)
        lblBannerTitle.AutoSize = True
        pnlBanner.Controls.Add(lblBannerTitle)

        Dim lblBannerDesc As New Label()
        lblBannerDesc.Text = "Designed and developed to automate microfinance loan applications, credit evaluations, amortization tracking, and payment processing."
        lblBannerDesc.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        lblBannerDesc.ForeColor = Color.FromArgb(200, 230, 255)
        lblBannerDesc.Location = New Point(20, 44)
        lblBannerDesc.Size = New Size(800, 38)
        pnlBanner.Controls.Add(lblBannerDesc)

        pnlBody.Controls.Add(pnlBanner)

        ' ── Developer Cards ───────────────────────────────────────────
        Dim cardDev1 As Panel = CreateDeveloperCard(
            "DEV 1",
            DEV1_NAME,
            DEV1_ROLE,
            DEV1_ID,
            DEV1_EMAIL,
            DEV1_COURSE,
            DEV1_BIO,
            New Point(20, 125)
        )
        pnlBody.Controls.Add(cardDev1)

        Dim cardDev2 As Panel = CreateDeveloperCard(
            "DEV 2",
            DEV2_NAME,
            DEV2_ROLE,
            DEV2_ID,
            DEV2_EMAIL,
            DEV2_COURSE,
            DEV2_BIO,
            New Point(455, 125)
        )
        pnlBody.Controls.Add(cardDev2)

        ' ── Project Info Card ─────────────────────────────────────────
        Dim pnlProjectInfo As New Panel()
        pnlProjectInfo.BackColor = Color.White
        pnlProjectInfo.BorderStyle = BorderStyle.FixedSingle
        pnlProjectInfo.Size = New Size(860, 140)
        pnlProjectInfo.Location = New Point(20, 420)
        pnlProjectInfo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        Dim lblInfoTitle As New Label()
        lblInfoTitle.Text = "System & Technology Stack"
        lblInfoTitle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblInfoTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblInfoTitle.Location = New Point(18, 14)
        lblInfoTitle.AutoSize = True
        pnlProjectInfo.Controls.Add(lblInfoTitle)

        Dim lblInfoContent As New Label()
        lblInfoContent.Text = "• Framework: Microsoft .NET 8.0 Windows Forms (VB.NET)" & vbCrLf &
                              "• Database Architecture: Relational Database with Repository Pattern" & vbCrLf &
                              "• Security: SHA-256 Hashed Passwords, Session State Management & Audit Trail Logging" & vbCrLf &
                              "• Client / Target: ASA Philippines Microfinance Operations"
        lblInfoContent.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        lblInfoContent.ForeColor = Color.FromArgb(50, 50, 50)
        lblInfoContent.Location = New Point(18, 42)
        lblInfoContent.Size = New Size(820, 85)
        pnlProjectInfo.Controls.Add(lblInfoContent)

        pnlBody.Controls.Add(pnlProjectInfo)

        ' ── Form Assembly ─────────────────────────────────────────────
        Controls.Add(pnlBody)
        Controls.Add(pnlDividerTop)
        Controls.Add(pnlHeader)
        BackColor = Color.FromArgb(245, 247, 250)
        ClientSize = New Size(900, 600)
        Name = "DevelopersForm"
        Text = "Development Team"

        ResumeLayout(False)
    End Sub

    Private Function CreateDeveloperCard(tag As String, name As String, role As String, idNo As String, email As String, course As String, bio As String, location As Point) As Panel
        Dim card As New Panel()
        card.BackColor = Color.White
        card.BorderStyle = BorderStyle.FixedSingle
        card.Size = New Size(425, 280)
        card.Location = location

        ' Avatar / Monogram Box
        Dim pnlAvatar As New Panel()
        pnlAvatar.BackColor = Color.FromArgb(30, 95, 150)
        pnlAvatar.Size = New Size(54, 54)
        pnlAvatar.Location = New Point(18, 18)

        Dim lblTag As New Label()
        lblTag.Text = tag
        lblTag.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblTag.ForeColor = Color.White
        lblTag.Dock = DockStyle.Fill
        lblTag.TextAlign = ContentAlignment.MiddleCenter
        pnlAvatar.Controls.Add(lblTag)
        card.Controls.Add(pnlAvatar)

        ' Name
        Dim lblName As New Label()
        lblName.Text = name
        lblName.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblName.ForeColor = Color.FromArgb(21, 67, 106)
        lblName.Location = New Point(82, 16)
        lblName.Size = New Size(325, 26)
        card.Controls.Add(lblName)

        ' Role
        Dim lblRole As New Label()
        lblRole.Text = role
        lblRole.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblRole.ForeColor = Color.FromArgb(30, 95, 150)
        lblRole.Location = New Point(82, 42)
        lblRole.Size = New Size(325, 20)
        card.Controls.Add(lblRole)

        ' Divider
        Dim div As New Panel()
        div.BackColor = Color.FromArgb(235, 238, 242)
        div.Size = New Size(389, 1)
        div.Location = New Point(18, 82)
        card.Controls.Add(div)

        ' Details
        Dim lblID As New Label()
        lblID.Text = $"Student / Staff ID: {idNo}"
        lblID.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblID.ForeColor = Color.FromArgb(80, 80, 80)
        lblID.Location = New Point(18, 92)
        lblID.Size = New Size(389, 20)
        card.Controls.Add(lblID)

        Dim lblCourse As New Label()
        lblCourse.Text = $"Program / Department: {course}"
        lblCourse.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblCourse.ForeColor = Color.FromArgb(80, 80, 80)
        lblCourse.Location = New Point(18, 114)
        lblCourse.Size = New Size(389, 20)
        card.Controls.Add(lblCourse)

        Dim lblEmail As New Label()
        lblEmail.Text = $"Contact: {email}"
        lblEmail.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblEmail.ForeColor = Color.FromArgb(80, 80, 80)
        lblEmail.Location = New Point(18, 136)
        lblEmail.Size = New Size(389, 20)
        card.Controls.Add(lblEmail)

        ' Responsibilities Header
        Dim lblBioHeader As New Label()
        lblBioHeader.Text = "Key Responsibilities:"
        lblBioHeader.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        lblBioHeader.ForeColor = Color.FromArgb(21, 67, 106)
        lblBioHeader.Location = New Point(18, 166)
        lblBioHeader.Size = New Size(389, 18)
        card.Controls.Add(lblBioHeader)

        ' Bio text
        Dim lblBio As New Label()
        lblBio.Text = bio
        lblBio.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular)
        lblBio.ForeColor = Color.FromArgb(90, 95, 105)
        lblBio.Location = New Point(18, 186)
        lblBio.Size = New Size(389, 80)
        card.Controls.Add(lblBio)

        Return card
    End Function

End Class
