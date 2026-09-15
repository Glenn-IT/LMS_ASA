Public Class ViewBorrowerForm
    Inherits Form

    ' ── Controls ──────────────────────────────────────────────────
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlDividerTop As Panel
    Private pnlBody As Panel
    Private grpPersonalInfo As GroupBox
    Private lblBorrowerUID As Label
    Friend WithEvents txtBorrowerUID As TextBox
    Private lblFirstName As Label
    Friend WithEvents txtFirstName As TextBox
    Private lblMiddleName As Label
    Friend WithEvents txtMiddleName As TextBox
    Private lblLastName As Label
    Friend WithEvents txtLastName As TextBox
    Private grpDetails As GroupBox
    Private lblAge As Label
    Friend WithEvents txtAge As TextBox
    Private lblDateOfBirth As Label
    Friend WithEvents txtDateOfBirth As TextBox
    Private lblContact As Label
    Friend WithEvents txtContact As TextBox
    Private lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Private grpAdditional As GroupBox
    Private lblIDPreview As Label
    Friend WithEvents picValidID As PictureBox
    Private lblIDFile As Label
    Friend WithEvents txtIDFile As TextBox
    Friend WithEvents btnViewFullID As Button
    Private lblRegisteredOn As Label
    Friend WithEvents txtRegisteredOn As TextBox
    Private lblIDStatusNote As Label
    Private pnlFooter As Panel
    Private pnlDividerBottom As Panel
    Friend WithEvents btnBack As Button

    Private _currentIDPath As String = ""
    Private _borrowerFullName As String = ""

    Public Sub New(borrowerID As Integer)
        InitializeComponent()
        LoadBorrower(borrowerID)
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlDividerTop = New Panel()
        pnlBody = New Panel()
        grpPersonalInfo = New GroupBox()
        lblBorrowerUID = New Label()
        txtBorrowerUID = New TextBox()
        lblFirstName = New Label()
        txtFirstName = New TextBox()
        lblMiddleName = New Label()
        txtMiddleName = New TextBox()
        lblLastName = New Label()
        txtLastName = New TextBox()
        grpDetails = New GroupBox()
        lblAge = New Label()
        txtAge = New TextBox()
        lblDateOfBirth = New Label()
        txtDateOfBirth = New TextBox()
        lblContact = New Label()
        txtContact = New TextBox()
        lblEmail = New Label()
        txtEmail = New TextBox()
        grpAdditional = New GroupBox()
        lblIDPreview = New Label()
        picValidID = New PictureBox()
        lblIDFile = New Label()
        txtIDFile = New TextBox()
        btnViewFullID = New Button()
        lblRegisteredOn = New Label()
        txtRegisteredOn = New TextBox()
        lblIDStatusNote = New Label()
        pnlFooter = New Panel()
        pnlDividerBottom = New Panel()
        btnBack = New Button()

        SuspendLayout()

        ' ── pnlHeader ─────────────────────────────────────────────────
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        ' ── lblTitle ──────────────────────────────────────────────────
        lblTitle.Text = "Borrower Details"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(231, 63, 30)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        ' ── lblSubtitle ───────────────────────────────────────────────
        lblSubtitle.Text = "Read-only view of the borrower's information"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(500, 18)
        lblSubtitle.Location = New Point(16, 40)

        ' ── pnlDividerTop ─────────────────────────────────────────────
        pnlDividerTop.BackColor = Color.FromArgb(220, 220, 220)
        pnlDividerTop.Dock = DockStyle.Top
        pnlDividerTop.Height = 1

        ' ── pnlBody ───────────────────────────────────────────────────
        pnlBody.BackColor = Color.FromArgb(245, 247, 250)
        pnlBody.Dock = DockStyle.Fill
        pnlBody.Padding = New Padding(16)
        pnlBody.AutoScroll = True
        pnlBody.Controls.Add(grpAdditional)
        pnlBody.Controls.Add(grpDetails)
        pnlBody.Controls.Add(grpPersonalInfo)

        ' ──────────────────────────────────────────────────────────────
        ' grpPersonalInfo – Borrower UID, First, Middle, Last Name
        ' ──────────────────────────────────────────────────────────────
        grpPersonalInfo.Text = "Personal Information"
        grpPersonalInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpPersonalInfo.ForeColor = Color.FromArgb(231, 63, 30)
        grpPersonalInfo.BackColor = Color.White
        grpPersonalInfo.Size = New Size(830, 95)
        grpPersonalInfo.Location = New Point(16, 16)
        grpPersonalInfo.Controls.Add(txtLastName)
        grpPersonalInfo.Controls.Add(lblLastName)
        grpPersonalInfo.Controls.Add(txtMiddleName)
        grpPersonalInfo.Controls.Add(lblMiddleName)
        grpPersonalInfo.Controls.Add(txtFirstName)
        grpPersonalInfo.Controls.Add(lblFirstName)
        grpPersonalInfo.Controls.Add(txtBorrowerUID)
        grpPersonalInfo.Controls.Add(lblBorrowerUID)

        ' Borrower UID
        lblBorrowerUID.Text = "BORROWER UID"
        lblBorrowerUID.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblBorrowerUID.ForeColor = Color.FromArgb(100, 100, 100)
        lblBorrowerUID.AutoSize = False
        lblBorrowerUID.Size = New Size(180, 18)
        lblBorrowerUID.Location = New Point(16, 22)

        txtBorrowerUID.Font = New Font("Segoe UI", 10)
        txtBorrowerUID.Size = New Size(180, 28)
        txtBorrowerUID.Location = New Point(16, 44)
        txtBorrowerUID.BorderStyle = BorderStyle.FixedSingle
        txtBorrowerUID.BackColor = Color.FromArgb(235, 240, 245)
        txtBorrowerUID.ReadOnly = True

        ' First Name
        lblFirstName.Text = "FIRST NAME"
        lblFirstName.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblFirstName.ForeColor = Color.FromArgb(100, 100, 100)
        lblFirstName.AutoSize = False
        lblFirstName.Size = New Size(200, 18)
        lblFirstName.Location = New Point(214, 22)

        txtFirstName.Font = New Font("Segoe UI", 10)
        txtFirstName.Size = New Size(200, 28)
        txtFirstName.Location = New Point(214, 44)
        txtFirstName.BorderStyle = BorderStyle.FixedSingle
        txtFirstName.BackColor = Color.FromArgb(235, 240, 245)
        txtFirstName.ReadOnly = True

        ' Middle Name
        lblMiddleName.Text = "MIDDLE NAME"
        lblMiddleName.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblMiddleName.ForeColor = Color.FromArgb(100, 100, 100)
        lblMiddleName.AutoSize = False
        lblMiddleName.Size = New Size(200, 18)
        lblMiddleName.Location = New Point(432, 22)

        txtMiddleName.Font = New Font("Segoe UI", 10)
        txtMiddleName.Size = New Size(200, 28)
        txtMiddleName.Location = New Point(432, 44)
        txtMiddleName.BorderStyle = BorderStyle.FixedSingle
        txtMiddleName.BackColor = Color.FromArgb(235, 240, 245)
        txtMiddleName.ReadOnly = True

        ' Last Name
        lblLastName.Text = "LAST NAME"
        lblLastName.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblLastName.ForeColor = Color.FromArgb(100, 100, 100)
        lblLastName.AutoSize = False
        lblLastName.Size = New Size(182, 18)
        lblLastName.Location = New Point(650, 22)

        txtLastName.Font = New Font("Segoe UI", 10)
        txtLastName.Size = New Size(164, 28)
        txtLastName.Location = New Point(650, 44)
        txtLastName.BorderStyle = BorderStyle.FixedSingle
        txtLastName.BackColor = Color.FromArgb(235, 240, 245)
        txtLastName.ReadOnly = True

        ' ──────────────────────────────────────────────────────────────
        ' grpDetails – Age, DOB, Contact, Email
        ' ──────────────────────────────────────────────────────────────
        grpDetails.Text = "Contact Details"
        grpDetails.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpDetails.ForeColor = Color.FromArgb(231, 63, 30)
        grpDetails.BackColor = Color.White
        grpDetails.Size = New Size(830, 95)
        grpDetails.Location = New Point(16, 122)
        grpDetails.Controls.Add(txtEmail)
        grpDetails.Controls.Add(lblEmail)
        grpDetails.Controls.Add(txtContact)
        grpDetails.Controls.Add(lblContact)
        grpDetails.Controls.Add(txtDateOfBirth)
        grpDetails.Controls.Add(lblDateOfBirth)
        grpDetails.Controls.Add(txtAge)
        grpDetails.Controls.Add(lblAge)

        ' Age
        lblAge.Text = "AGE"
        lblAge.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblAge.ForeColor = Color.FromArgb(100, 100, 100)
        lblAge.AutoSize = False
        lblAge.Size = New Size(100, 18)
        lblAge.Location = New Point(16, 22)

        txtAge.Font = New Font("Segoe UI", 10)
        txtAge.Size = New Size(100, 28)
        txtAge.Location = New Point(16, 44)
        txtAge.BorderStyle = BorderStyle.FixedSingle
        txtAge.BackColor = Color.FromArgb(235, 240, 245)
        txtAge.ReadOnly = True

        ' Date of Birth
        lblDateOfBirth.Text = "DATE OF BIRTH"
        lblDateOfBirth.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblDateOfBirth.ForeColor = Color.FromArgb(100, 100, 100)
        lblDateOfBirth.AutoSize = False
        lblDateOfBirth.Size = New Size(260, 18)
        lblDateOfBirth.Location = New Point(134, 22)

        txtDateOfBirth.Font = New Font("Segoe UI", 10)
        txtDateOfBirth.Size = New Size(260, 28)
        txtDateOfBirth.Location = New Point(134, 44)
        txtDateOfBirth.BorderStyle = BorderStyle.FixedSingle
        txtDateOfBirth.BackColor = Color.FromArgb(235, 240, 245)
        txtDateOfBirth.ReadOnly = True

        ' Contact
        lblContact.Text = "CONTACT NUMBER"
        lblContact.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblContact.ForeColor = Color.FromArgb(100, 100, 100)
        lblContact.AutoSize = False
        lblContact.Size = New Size(200, 18)
        lblContact.Location = New Point(412, 22)

        txtContact.Font = New Font("Segoe UI", 10)
        txtContact.Size = New Size(200, 28)
        txtContact.Location = New Point(412, 44)
        txtContact.BorderStyle = BorderStyle.FixedSingle
        txtContact.BackColor = Color.FromArgb(235, 240, 245)
        txtContact.ReadOnly = True

        ' Email
        lblEmail.Text = "EMAIL ADDRESS"
        lblEmail.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblEmail.ForeColor = Color.FromArgb(100, 100, 100)
        lblEmail.AutoSize = False
        lblEmail.Size = New Size(202, 18)
        lblEmail.Location = New Point(630, 22)

        txtEmail.Font = New Font("Segoe UI", 10)
        txtEmail.Size = New Size(184, 28)
        txtEmail.Location = New Point(630, 44)
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        txtEmail.BackColor = Color.FromArgb(235, 240, 245)
        txtEmail.ReadOnly = True

        ' ──────────────────────────────────────────────────────────────
        ' grpAdditional – Valid ID preview, file info, Registered On
        ' ──────────────────────────────────────────────────────────────
        grpAdditional.Text = "Valid Identification & Registration"
        grpAdditional.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpAdditional.ForeColor = Color.FromArgb(231, 63, 30)
        grpAdditional.BackColor = Color.White
        grpAdditional.Size = New Size(830, 270)
        grpAdditional.Location = New Point(16, 228)
        grpAdditional.Controls.Add(lblIDPreview)
        grpAdditional.Controls.Add(picValidID)
        grpAdditional.Controls.Add(lblIDFile)
        grpAdditional.Controls.Add(txtIDFile)
        grpAdditional.Controls.Add(btnViewFullID)
        grpAdditional.Controls.Add(lblRegisteredOn)
        grpAdditional.Controls.Add(txtRegisteredOn)
        grpAdditional.Controls.Add(lblIDStatusNote)

        ' Valid ID Preview Label
        lblIDPreview.Text = "VALID ID PREVIEW (Click to view full size)"
        lblIDPreview.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblIDPreview.ForeColor = Color.FromArgb(100, 100, 100)
        lblIDPreview.AutoSize = False
        lblIDPreview.Size = New Size(410, 18)
        lblIDPreview.Location = New Point(16, 24)

        ' Valid ID PictureBox
        picValidID.Location = New Point(16, 44)
        picValidID.Size = New Size(410, 210)
        picValidID.BorderStyle = BorderStyle.FixedSingle
        picValidID.BackColor = Color.FromArgb(240, 243, 246)
        picValidID.SizeMode = PictureBoxSizeMode.Zoom
        picValidID.Cursor = Cursors.Hand

        ' Valid ID File Label
        lblIDFile.Text = "VALID ID FILE"
        lblIDFile.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblIDFile.ForeColor = Color.FromArgb(100, 100, 100)
        lblIDFile.AutoSize = False
        lblIDFile.Size = New Size(370, 18)
        lblIDFile.Location = New Point(444, 24)

        ' Valid ID File Name / Path
        txtIDFile.Font = New Font("Segoe UI", 10)
        txtIDFile.Size = New Size(370, 28)
        txtIDFile.Location = New Point(444, 44)
        txtIDFile.BorderStyle = BorderStyle.FixedSingle
        txtIDFile.BackColor = Color.FromArgb(235, 240, 245)
        txtIDFile.ReadOnly = True

        ' Button View Full Size
        btnViewFullID.Text = "View Full Size"
        btnViewFullID.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnViewFullID.BackColor = Color.FromArgb(231, 63, 30)
        btnViewFullID.ForeColor = Color.White
        btnViewFullID.FlatStyle = FlatStyle.Flat
        btnViewFullID.FlatAppearance.BorderSize = 0
        btnViewFullID.Size = New Size(150, 32)
        btnViewFullID.Location = New Point(444, 80)
        btnViewFullID.Cursor = Cursors.Hand

        ' Registered On Label
        lblRegisteredOn.Text = "REGISTERED ON"
        lblRegisteredOn.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblRegisteredOn.ForeColor = Color.FromArgb(100, 100, 100)
        lblRegisteredOn.AutoSize = False
        lblRegisteredOn.Size = New Size(370, 18)
        lblRegisteredOn.Location = New Point(444, 126)

        ' Registered On TextBox
        txtRegisteredOn.Font = New Font("Segoe UI", 10)
        txtRegisteredOn.Size = New Size(370, 28)
        txtRegisteredOn.Location = New Point(444, 146)
        txtRegisteredOn.BorderStyle = BorderStyle.FixedSingle
        txtRegisteredOn.BackColor = Color.FromArgb(235, 240, 245)
        txtRegisteredOn.ReadOnly = True

        ' Status Note
        lblIDStatusNote.Font = New Font("Segoe UI", 8.5, FontStyle.Italic)
        lblIDStatusNote.ForeColor = Color.FromArgb(110, 110, 110)
        lblIDStatusNote.AutoSize = False
        lblIDStatusNote.Size = New Size(370, 60)
        lblIDStatusNote.Location = New Point(444, 186)
        lblIDStatusNote.Text = "Click on the ID preview image or the button above to view the full resolution document."

        ' ── pnlFooter ─────────────────────────────────────────────────
        pnlFooter.BackColor = Color.White
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 60
        pnlFooter.Controls.Add(btnBack)
        pnlFooter.Controls.Add(pnlDividerBottom)

        pnlDividerBottom.BackColor = Color.FromArgb(220, 220, 220)
        pnlDividerBottom.Dock = DockStyle.Top
        pnlDividerBottom.Height = 1

        btnBack.Text = "Back to List"
        btnBack.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnBack.BackColor = Color.FromArgb(231, 63, 30)
        btnBack.ForeColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.Size = New Size(130, 38)
        btnBack.Location = New Point(16, 12)
        btnBack.Cursor = Cursors.Hand

        ' ── Form ──────────────────────────────────────────────────────
        Me.Text = "LMS - Borrower Details"
        Me.ClientSize = New Size(880, 650)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(245, 247, 250)
        Me.Controls.Add(pnlBody)
        Me.Controls.Add(pnlFooter)
        Me.Controls.Add(pnlDividerTop)
        Me.Controls.Add(pnlHeader)

        ResumeLayout(False)
    End Sub

    ' ── Load Borrower from DB ─────────────────────────────────────
    Private Sub LoadBorrower(borrowerID As Integer)
        Try
            Dim dt As DataTable = BorrowerRepository.GetByID(borrowerID)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Borrower record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If

            Dim row As DataRow = dt.Rows(0)
            txtBorrowerUID.Text = row("BorrowerUID").ToString()
            txtFirstName.Text = row("FirstName").ToString()
            txtMiddleName.Text = If(row("MiddleName") Is DBNull.Value, "", row("MiddleName").ToString())
            txtLastName.Text = row("LastName").ToString()
            txtAge.Text = row("Age").ToString()

            _borrowerFullName = $"{txtFirstName.Text} {txtLastName.Text}".Trim()

            If row("DateOfBirth") IsNot DBNull.Value Then
                txtDateOfBirth.Text = CDate(row("DateOfBirth")).ToString("MMMM dd, yyyy")
            End If

            txtContact.Text = row("Contact").ToString()
            txtEmail.Text = row("Email").ToString()

            ' ID Image Handling
            If row("IDImagePath") IsNot DBNull.Value AndAlso Not String.IsNullOrWhiteSpace(row("IDImagePath").ToString()) Then
                Dim rawPath As String = row("IDImagePath").ToString().Trim()
                _currentIDPath = ResolveFilePath(rawPath)
                txtIDFile.Text = IO.Path.GetFileName(_currentIDPath)
                DisplayValidID(_currentIDPath)
            Else
                _currentIDPath = ""
                txtIDFile.Text = "None uploaded"
                picValidID.Image = GeneratePlaceholderImage("No Valid ID Uploaded", picValidID.Width, picValidID.Height)
                btnViewFullID.Enabled = False
                lblIDStatusNote.Text = "No valid ID document was uploaded for this borrower."
            End If

            txtRegisteredOn.Text = If(row("CreatedAt") Is DBNull.Value, "", CDate(row("CreatedAt")).ToString("MMMM dd, yyyy"))
        Catch ex As Exception
            MessageBox.Show($"Failed to load borrower: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Resolve File Path ──────────────────────────────────────────
    Private Function ResolveFilePath(path As String) As String
        If String.IsNullOrWhiteSpace(path) Then Return ""

        ' 1. Check direct path
        If IO.File.Exists(path) Then Return path

        ' 2. Check relative to StartupPath
        Dim startupRelative As String = IO.Path.Combine(Application.StartupPath, path)
        If IO.File.Exists(startupRelative) Then Return startupRelative

        ' 3. Check filename in StartupPath / Uploads
        Dim fileName As String = IO.Path.GetFileName(path)
        Dim inUploads As String = IO.Path.Combine(Application.StartupPath, "Uploads", fileName)
        If IO.File.Exists(inUploads) Then Return inUploads

        Dim inStartup As String = IO.Path.Combine(Application.StartupPath, fileName)
        If IO.File.Exists(inStartup) Then Return inStartup

        ' Default to original string
        Return path
    End Function

    ' ── Display Valid ID Image ────────────────────────────────────
    Private Sub DisplayValidID(filePath As String)
        If String.IsNullOrWhiteSpace(filePath) OrElse Not IO.File.Exists(filePath) Then
            picValidID.Image = GeneratePlaceholderImage("File Not Found on Disk", picValidID.Width, picValidID.Height)
            btnViewFullID.Enabled = False
            lblIDStatusNote.Text = $"The file was not found on disk:{Environment.NewLine}{filePath}"
            Return
        End If

        Dim ext As String = IO.Path.GetExtension(filePath).ToLowerInvariant()
        If ext = ".pdf" Then
            picValidID.Image = GeneratePlaceholderImage("PDF Document" & Environment.NewLine & "(Click to open)", picValidID.Width, picValidID.Height)
            btnViewFullID.Enabled = True
            btnViewFullID.Text = "Open PDF"
            lblIDStatusNote.Text = "PDF document on file. Click the preview or button to open in default viewer."
        Else
            Try
                If picValidID.Image IsNot Nothing Then
                    Dim oldImg = picValidID.Image
                    picValidID.Image = Nothing
                    oldImg.Dispose()
                End If

                Using fs As New IO.FileStream(filePath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
                    Using tempImg As New Bitmap(fs)
                        picValidID.Image = New Bitmap(tempImg)
                    End Using
                End Using

                btnViewFullID.Enabled = True
                btnViewFullID.Text = "View Full Size"
                lblIDStatusNote.Text = "Click on the ID image or button to view full resolution."
            Catch ex As Exception
                picValidID.Image = GeneratePlaceholderImage("Unable to Display Image", picValidID.Width, picValidID.Height)
                btnViewFullID.Enabled = False
                lblIDStatusNote.Text = $"Unable to load image: {ex.Message}"
            End Try
        End If
    End Sub

    ' ── Generate Placeholder Bitmap ───────────────────────────────
    Private Function GeneratePlaceholderImage(message As String, width As Integer, height As Integer) As Bitmap
        Dim w As Integer = Math.Max(width, 120)
        Dim h As Integer = Math.Max(height, 80)
        Dim bmp As New Bitmap(w, h)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.FromArgb(240, 243, 246))
            Using pen As New Pen(Color.FromArgb(205, 210, 216), 2)
                pen.DashStyle = Drawing2D.DashStyle.Dash
                g.DrawRectangle(pen, 6, 6, w - 12, h - 12)
            End Using
            Using font As New Font("Segoe UI", 9.5F, FontStyle.Bold)
                Using brush As New SolidBrush(Color.FromArgb(130, 140, 150))
                    Dim sf As New StringFormat() With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    g.DrawString(message, font, brush, New RectangleF(12, 12, w - 24, h - 24), sf)
                End Using
            End Using
        End Using
        Return bmp
    End Function

    ' ── Open / View ID Full Size ──────────────────────────────────
    Private Sub OpenOrViewID()
        If String.IsNullOrEmpty(_currentIDPath) Then
            MessageBox.Show("No Valid ID file is associated with this borrower.", "Valid ID", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If Not IO.File.Exists(_currentIDPath) Then
            MessageBox.Show($"The ID file could not be found at:{Environment.NewLine}{_currentIDPath}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim ext As String = IO.Path.GetExtension(_currentIDPath).ToLowerInvariant()
            If ext = ".pdf" Then
                Dim psi As New ProcessStartInfo(_currentIDPath) With {.UseShellExecute = True}
                Process.Start(psi)
            Else
                ShowEnlargedImageDialog(_currentIDPath)
            End If
        Catch ex As Exception
            MessageBox.Show($"Unable to open file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Modal Enlarged Image Viewer ───────────────────────────────
    Private Sub ShowEnlargedImageDialog(imagePath As String)
        Using dlg As New Form()
            dlg.Text = $"Valid ID - {_borrowerFullName}"
            dlg.Size = New Size(900, 680)
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.BackColor = Color.FromArgb(245, 247, 250)
            dlg.FormBorderStyle = FormBorderStyle.Sizable
            dlg.MinimizeBox = False
            dlg.MaximizeBox = True

            ' Header panel
            Dim pnlTop As New Panel() With {
                .Dock = DockStyle.Top,
                .Height = 50,
                .BackColor = Color.White
            }
            Dim lblHeader As New Label() With {
                .Text = $"Valid ID Document - {_borrowerFullName}",
                .Font = New Font("Segoe UI", 11, FontStyle.Bold),
                .ForeColor = Color.FromArgb(231, 63, 30),
                .Location = New Point(16, 14),
                .AutoSize = True
            }
            Dim btnExtViewer As New Button() With {
                .Text = "Open in Windows Viewer",
                .Font = New Font("Segoe UI", 9, FontStyle.Regular),
                .BackColor = Color.FromArgb(240, 240, 240),
                .ForeColor = Color.FromArgb(40, 40, 40),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(170, 30),
                .Location = New Point(dlg.ClientSize.Width - 190, 10),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Cursor = Cursors.Hand
            }
            btnExtViewer.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
            AddHandler btnExtViewer.Click, Sub()
                Try
                    Dim psi As New ProcessStartInfo(imagePath) With {.UseShellExecute = True}
                    Process.Start(psi)
                Catch ex As Exception
                    MessageBox.Show($"Failed to launch viewer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Sub

            pnlTop.Controls.Add(lblHeader)
            pnlTop.Controls.Add(btnExtViewer)

            ' PictureBox for Full View
            Dim picFull As New PictureBox() With {
                .Dock = DockStyle.Fill,
                .SizeMode = PictureBoxSizeMode.Zoom,
                .BackColor = Color.FromArgb(30, 30, 30)
            }

            Try
                Using fs As New IO.FileStream(imagePath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
                    Using tempImg As New Bitmap(fs)
                        picFull.Image = New Bitmap(tempImg)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Could not load image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            ' Footer panel
            Dim pnlBot As New Panel() With {
                .Dock = DockStyle.Bottom,
                .Height = 50,
                .BackColor = Color.White
            }
            Dim btnClose As New Button() With {
                .Text = "Close",
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .BackColor = Color.FromArgb(231, 63, 30),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(100, 32),
                .Location = New Point(dlg.ClientSize.Width - 120, 9),
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
        End Using
    End Sub

    ' ── Picture & Button Click Handlers ───────────────────────────
    Private Sub picValidID_Click(sender As Object, e As EventArgs) Handles picValidID.Click
        OpenOrViewID()
    End Sub

    Private Sub btnViewFullID_Click(sender As Object, e As EventArgs) Handles btnViewFullID.Click
        OpenOrViewID()
    End Sub

    ' ── Hover Effects ─────────────────────────────────────────────
    Private Sub btnViewFullID_MouseEnter(sender As Object, e As EventArgs) Handles btnViewFullID.MouseEnter
        btnViewFullID.BackColor = Color.FromArgb(251, 108, 0)
    End Sub

    Private Sub btnViewFullID_MouseLeave(sender As Object, e As EventArgs) Handles btnViewFullID.MouseLeave
        btnViewFullID.BackColor = Color.FromArgb(231, 63, 30)
    End Sub

    Private Sub btnBack_MouseEnter(sender As Object, e As EventArgs) Handles btnBack.MouseEnter
        btnBack.BackColor = Color.FromArgb(251, 108, 0)
    End Sub

    Private Sub btnBack_MouseLeave(sender As Object, e As EventArgs) Handles btnBack.MouseLeave
        btnBack.BackColor = Color.FromArgb(231, 63, 30)
    End Sub

    ' ── Back Button ───────────────────────────────────────────────
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    ' ── Form Cleanup ──────────────────────────────────────────────
    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)
        If picValidID IsNot Nothing AndAlso picValidID.Image IsNot Nothing Then
            picValidID.Image.Dispose()
            picValidID.Image = Nothing
        End If
    End Sub

    Private Sub ViewBorrowerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

End Class
