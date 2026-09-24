Imports System.Drawing
Imports System.IO

Public Class DevelopersForm
    Inherits Form

    ' =========================================================================
    ' DEVELOPER CONFIGURATION
    ' =========================================================================
    Private Const DEV1_NAME As String = "Hanna Shane Luis"
    Private Const DEV1_ROLE As String = "Lead Developer & System Architect"
    Private Const DEV1_COURSE As String = "Bachelor of Science in Information Technology (BSIT)"
    Private Const DEV1_EMAIL As String = "hannashaneluis@gmail.com"
    Private Const DEV1_PHONE As String = "09557745454"
    Private Const DEV1_BIO As String = "Responsible for core backend system architecture, database schema, loan calculation engine, and security management."
    Private Const DEV1_PHOTO As String = "Hanna.jpg"

    Private Const DEV2_NAME As String = "Mikayla Ignacio"
    Private Const DEV2_ROLE As String = "Frontend Developer & UI/UX Specialist"
    Private Const DEV2_COURSE As String = "Bachelor of Science in Information Technology (BSIT)"
    Private Const DEV2_EMAIL As String = "kylaignacio0004@gmail.com"
    Private Const DEV2_PHONE As String = "09615395681"
    Private Const DEV2_BIO As String = "Responsible for user interface design, dashboard experience, system documentation, and quality assurance testing."
    Private Const DEV2_PHOTO As String = "Mikayla.jpg"
    ' =========================================================================

    Private ReadOnly loadedImages As New List(Of Image)()

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
        lblTitle.ForeColor = Color.FromArgb(231, 63, 30)
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
        pnlBanner.BackColor = Color.FromArgb(231, 63, 30)
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
        lblBannerDesc.ForeColor = Color.FromArgb(255, 221, 156)
        lblBannerDesc.Location = New Point(20, 44)
        lblBannerDesc.Size = New Size(800, 38)
        pnlBanner.Controls.Add(lblBannerDesc)

        pnlBody.Controls.Add(pnlBanner)

        ' ── Developer Cards ───────────────────────────────────────────
        Dim cardDev1 As Panel = CreateDeveloperCard(
            "DEV 1",
            DEV1_NAME,
            DEV1_ROLE,
            DEV1_COURSE,
            DEV1_EMAIL,
            DEV1_PHONE,
            DEV1_BIO,
            DEV1_PHOTO,
            New Point(20, 125)
        )
        pnlBody.Controls.Add(cardDev1)

        Dim cardDev2 As Panel = CreateDeveloperCard(
            "DEV 2",
            DEV2_NAME,
            DEV2_ROLE,
            DEV2_COURSE,
            DEV2_EMAIL,
            DEV2_PHONE,
            DEV2_BIO,
            DEV2_PHOTO,
            New Point(455, 125)
        )
        pnlBody.Controls.Add(cardDev2)

        ' ── Project Info Card ─────────────────────────────────────────
        Dim pnlProjectInfo As New Panel()
        pnlProjectInfo.BackColor = Color.White
        pnlProjectInfo.BorderStyle = BorderStyle.FixedSingle
        pnlProjectInfo.Size = New Size(860, 140)
        pnlProjectInfo.Location = New Point(20, 445)
        pnlProjectInfo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        Dim lblInfoTitle As New Label()
        lblInfoTitle.Text = "System & Technology Stack"
        lblInfoTitle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblInfoTitle.ForeColor = Color.FromArgb(231, 63, 30)
        lblInfoTitle.Location = New Point(18, 14)
        lblInfoTitle.AutoSize = True
        pnlProjectInfo.Controls.Add(lblInfoTitle)

        Dim lblInfoContent As New Label()
        lblInfoContent.Text = "• Framework: Microsoft .NET 8.0 Windows Forms (VB.NET)" & vbCrLf &
                              "• Database Architecture: Relational Database with Repository Pattern" & vbCrLf &
                              "• Security: BCrypt / SHA-256 Hashed Passwords, Session State Management & Audit Trail Logging" & vbCrLf &
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
        ClientSize = New Size(900, 620)
        Name = "DevelopersForm"
        Text = "Development Team"

        ResumeLayout(False)
    End Sub

    Private Function CreateDeveloperCard(tag As String, name As String, role As String, course As String, email As String, phone As String, bio As String, photoFileName As String, location As Point) As Panel
        Dim card As New Panel()
        card.BackColor = Color.White
        card.BorderStyle = BorderStyle.FixedSingle
        card.Size = New Size(425, 300)
        card.Location = location

        ' Avatar / Photo Container
        Dim pnlPhotoFrame As New Panel()
        pnlPhotoFrame.BackColor = Color.FromArgb(245, 247, 250)
        pnlPhotoFrame.BorderStyle = BorderStyle.FixedSingle
        pnlPhotoFrame.Size = New Size(74, 74)
        pnlPhotoFrame.Location = New Point(18, 14)

        Dim devImg As Image = LoadDeveloperImage(photoFileName)
        Dim imgPath As String = ResolveImagePath(photoFileName)

        If devImg IsNot Nothing Then
            Dim picAvatar As New PictureBox()
            picAvatar.Image = devImg
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom
            picAvatar.Dock = DockStyle.Fill
            picAvatar.Cursor = Cursors.Hand
            picAvatar.BackColor = Color.FromArgb(245, 247, 250)

            Dim tt As New ToolTip()
            tt.SetToolTip(picAvatar, $"Click to view photo of {name}")

            If Not String.IsNullOrEmpty(imgPath) Then
                AddHandler picAvatar.Click, Sub()
                    ShowEnlargedDeveloperPhoto(imgPath, name)
                End Sub
            End If

            pnlPhotoFrame.Controls.Add(picAvatar)
        Else
            pnlPhotoFrame.BackColor = Color.FromArgb(251, 108, 0)
            pnlPhotoFrame.BorderStyle = BorderStyle.None

            Dim lblTag As New Label()
            lblTag.Text = tag
            lblTag.Font = New Font("Segoe UI", 11, FontStyle.Bold)
            lblTag.ForeColor = Color.White
            lblTag.Dock = DockStyle.Fill
            lblTag.TextAlign = ContentAlignment.MiddleCenter
            pnlPhotoFrame.Controls.Add(lblTag)
        End If

        card.Controls.Add(pnlPhotoFrame)

        ' Name
        Dim lblName As New Label()
        lblName.Text = name
        lblName.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblName.ForeColor = Color.FromArgb(231, 63, 30)
        lblName.Location = New Point(102, 14)
        lblName.Size = New Size(305, 26)
        card.Controls.Add(lblName)

        ' Role
        Dim lblRole As New Label()
        lblRole.Text = role
        lblRole.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblRole.ForeColor = Color.FromArgb(251, 108, 0)
        lblRole.Location = New Point(102, 40)
        lblRole.Size = New Size(305, 20)
        card.Controls.Add(lblRole)

        ' Tag badge
        Dim lblTagBadge As New Label()
        lblTagBadge.Text = tag
        lblTagBadge.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblTagBadge.ForeColor = Color.FromArgb(231, 63, 30)
        lblTagBadge.BackColor = Color.FromArgb(255, 238, 235)
        lblTagBadge.TextAlign = ContentAlignment.MiddleCenter
        lblTagBadge.Size = New Size(50, 18)
        lblTagBadge.Location = New Point(102, 65)
        card.Controls.Add(lblTagBadge)

        ' View photo link
        If devImg IsNot Nothing AndAlso Not String.IsNullOrEmpty(imgPath) Then
            Dim lblViewPhoto As New LinkLabel()
            lblViewPhoto.Text = "🔍 View Photo"
            lblViewPhoto.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular)
            lblViewPhoto.LinkColor = Color.FromArgb(231, 63, 30)
            lblViewPhoto.ActiveLinkColor = Color.FromArgb(251, 108, 0)
            lblViewPhoto.AutoSize = True
            lblViewPhoto.Location = New Point(158, 67)
            lblViewPhoto.Cursor = Cursors.Hand
            AddHandler lblViewPhoto.LinkClicked, Sub()
                ShowEnlargedDeveloperPhoto(imgPath, name)
            End Sub
            card.Controls.Add(lblViewPhoto)
        End If

        ' Divider
        Dim div As New Panel()
        div.BackColor = Color.FromArgb(235, 238, 242)
        div.Size = New Size(389, 1)
        div.Location = New Point(18, 96)
        card.Controls.Add(div)

        ' Details
        Dim lblCourse As New Label()
        lblCourse.Text = $"Course / Program: {course}"
        lblCourse.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblCourse.ForeColor = Color.FromArgb(80, 80, 80)
        lblCourse.Location = New Point(18, 106)
        lblCourse.Size = New Size(389, 20)
        card.Controls.Add(lblCourse)

        Dim lblEmail As New Label()
        lblEmail.Text = $"Gmail: {email}"
        lblEmail.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblEmail.ForeColor = Color.FromArgb(80, 80, 80)
        lblEmail.Location = New Point(18, 128)
        lblEmail.Size = New Size(389, 20)
        card.Controls.Add(lblEmail)

        Dim lblPhone As New Label()
        lblPhone.Text = $"Contact No: {phone}"
        lblPhone.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblPhone.ForeColor = Color.FromArgb(80, 80, 80)
        lblPhone.Location = New Point(18, 150)
        lblPhone.Size = New Size(389, 20)
        card.Controls.Add(lblPhone)

        ' Responsibilities Header
        Dim lblBioHeader As New Label()
        lblBioHeader.Text = "Key Responsibilities:"
        lblBioHeader.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        lblBioHeader.ForeColor = Color.FromArgb(231, 63, 30)
        lblBioHeader.Location = New Point(18, 178)
        lblBioHeader.Size = New Size(389, 18)
        card.Controls.Add(lblBioHeader)

        ' Bio text
        Dim lblBio As New Label()
        lblBio.Text = bio
        lblBio.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular)
        lblBio.ForeColor = Color.FromArgb(90, 95, 105)
        lblBio.Location = New Point(18, 198)
        lblBio.Size = New Size(389, 85)
        card.Controls.Add(lblBio)

        Return card
    End Function

    Private Function LoadDeveloperImage(fileName As String) As Image
        Dim imgPath As String = ResolveImagePath(fileName)
        If String.IsNullOrWhiteSpace(imgPath) Then Return Nothing

        Try
            Using fs As New FileStream(imgPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using temp As New Bitmap(fs)
                    Dim bmp As New Bitmap(temp)
                    loadedImages.Add(bmp)
                    Return bmp
                End Using
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    Private Function ResolveImagePath(fileName As String) As String
        If String.IsNullOrWhiteSpace(fileName) Then Return ""

        Dim possiblePaths As String() = {
            Path.Combine(Application.StartupPath, "img", fileName),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", fileName),
            Path.Combine(Application.StartupPath, "..", "..", "..", "img", fileName),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "img", fileName),
            Path.Combine(Application.StartupPath, fileName),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)
        }

        For Each p In possiblePaths
            If File.Exists(p) Then Return p
        Next
        Return ""
    End Function

    Private Sub ShowEnlargedDeveloperPhoto(imagePath As String, devName As String)
        If String.IsNullOrWhiteSpace(imagePath) OrElse Not File.Exists(imagePath) Then
            MessageBox.Show("Developer photo file could not be found.", "Photo Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dlg As New Form()
            dlg.Text = $"Developer Profile — {devName}"
            dlg.Size = New Size(640, 720)
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.BackColor = Color.FromArgb(245, 247, 250)
            dlg.FormBorderStyle = FormBorderStyle.Sizable
            dlg.MinimizeBox = False
            dlg.MaximizeBox = True

            ' Header panel
            Dim pnlTop As New Panel() With {
                .Dock = DockStyle.Top,
                .Height = 54,
                .BackColor = Color.White
            }
            Dim lblHeader As New Label() With {
                .Text = devName,
                .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                .ForeColor = Color.FromArgb(231, 63, 30),
                .Location = New Point(16, 8),
                .AutoSize = True
            }
            Dim lblSubHeader As New Label() With {
                .Text = "Development Team Member — Loan Management System (ASA Philippines)",
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                .ForeColor = Color.Gray,
                .Location = New Point(17, 30),
                .AutoSize = True
            }
            pnlTop.Controls.Add(lblHeader)
            pnlTop.Controls.Add(lblSubHeader)

            ' PictureBox for Full View
            Dim picFull As New PictureBox() With {
                .Dock = DockStyle.Fill,
                .SizeMode = PictureBoxSizeMode.Zoom,
                .BackColor = Color.FromArgb(30, 30, 30)
            }

            Dim loadedBmp As Bitmap = Nothing
            Try
                Using fs As New FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                    Using tempImg As New Bitmap(fs)
                        loadedBmp = New Bitmap(tempImg)
                        picFull.Image = loadedBmp
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Could not load developer photo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            ' Footer panel
            Dim pnlBot As New Panel() With {
                .Dock = DockStyle.Bottom,
                .Height = 48,
                .BackColor = Color.White
            }
            Dim btnClose As New Button() With {
                .Text = "Close",
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .BackColor = Color.FromArgb(231, 63, 30),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(95, 32),
                .Location = New Point(dlg.ClientSize.Width - 115, 8),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Cursor = Cursors.Hand
            }
            btnClose.FlatAppearance.BorderSize = 0
            AddHandler btnClose.Click, Sub() dlg.Close()
            pnlBot.Controls.Add(btnClose)

            dlg.Controls.Add(picFull)
            dlg.Controls.Add(pnlTop)
            dlg.Controls.Add(pnlBot)

            dlg.ShowDialog(Me)

            If loadedBmp IsNot Nothing Then
                picFull.Image = Nothing
                loadedBmp.Dispose()
            End If
        End Using
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)
        For Each img In loadedImages
            Try
                img.Dispose()
            Catch
            End Try
        Next
        loadedImages.Clear()
    End Sub

End Class
