Public Class ViewBorrowerForm
    Inherits Form

    ' ?? Controls ??????????????????????????????????????????????????
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
    Private lblIDFile As Label
    Friend WithEvents txtIDFile As TextBox
    Private lblRegisteredOn As Label
    Friend WithEvents txtRegisteredOn As TextBox
    Private pnlFooter As Panel
    Private pnlDividerBottom As Panel
    Friend WithEvents btnBack As Button

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
        lblIDFile = New Label()
        txtIDFile = New TextBox()
        lblRegisteredOn = New Label()
        txtRegisteredOn = New TextBox()
        pnlFooter = New Panel()
        pnlDividerBottom = New Panel()
        btnBack = New Button()

        SuspendLayout()

        ' ?? pnlHeader ?????????????????????????????????????????????
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        lblTitle.Text = "Borrower Details"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        lblSubtitle.Text = "Read-only view of the borrower's information"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(500, 18)
        lblSubtitle.Location = New Point(16, 40)

        ' ?? pnlDividerTop ?????????????????????????????????????????
        pnlDividerTop.BackColor = Color.FromArgb(220, 220, 220)
        pnlDividerTop.Dock = DockStyle.Top
        pnlDividerTop.Height = 1

        ' ?? pnlBody ???????????????????????????????????????????????
        pnlBody.BackColor = Color.FromArgb(245, 247, 250)
        pnlBody.Dock = DockStyle.Fill
        pnlBody.Padding = New Padding(16)
        pnlBody.AutoScroll = True
        pnlBody.Controls.Add(grpAdditional)
        pnlBody.Controls.Add(grpDetails)
        pnlBody.Controls.Add(grpPersonalInfo)

        ' ??????????????????????????????????????????????????????????
        ' grpPersonalInfo ? Borrower UID, First, Middle, Last Name
        ' ??????????????????????????????????????????????????????????
        grpPersonalInfo.Text = "Personal Information"
        grpPersonalInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpPersonalInfo.ForeColor = Color.FromArgb(21, 67, 106)
        grpPersonalInfo.BackColor = Color.White
        grpPersonalInfo.Size = New Size(830, 140)
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
        lblBorrowerUID.Location = New Point(16, 28)

        txtBorrowerUID.Font = New Font("Segoe UI", 10)
        txtBorrowerUID.Size = New Size(180, 28)
        txtBorrowerUID.Location = New Point(16, 48)
        txtBorrowerUID.BorderStyle = BorderStyle.FixedSingle
        txtBorrowerUID.BackColor = Color.FromArgb(235, 240, 245)
        txtBorrowerUID.ReadOnly = True

        ' First Name
        lblFirstName.Text = "FIRST NAME"
        lblFirstName.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblFirstName.ForeColor = Color.FromArgb(100, 100, 100)
        lblFirstName.AutoSize = False
        lblFirstName.Size = New Size(200, 18)
        lblFirstName.Location = New Point(214, 28)

        txtFirstName.Font = New Font("Segoe UI", 10)
        txtFirstName.Size = New Size(200, 28)
        txtFirstName.Location = New Point(214, 48)
        txtFirstName.BorderStyle = BorderStyle.FixedSingle
        txtFirstName.BackColor = Color.FromArgb(235, 240, 245)
        txtFirstName.ReadOnly = True

        ' Middle Name
        lblMiddleName.Text = "MIDDLE NAME"
        lblMiddleName.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblMiddleName.ForeColor = Color.FromArgb(100, 100, 100)
        lblMiddleName.AutoSize = False
        lblMiddleName.Size = New Size(200, 18)
        lblMiddleName.Location = New Point(432, 28)

        txtMiddleName.Font = New Font("Segoe UI", 10)
        txtMiddleName.Size = New Size(200, 28)
        txtMiddleName.Location = New Point(432, 48)
        txtMiddleName.BorderStyle = BorderStyle.FixedSingle
        txtMiddleName.BackColor = Color.FromArgb(235, 240, 245)
        txtMiddleName.ReadOnly = True

        ' Last Name
        lblLastName.Text = "LAST NAME"
        lblLastName.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblLastName.ForeColor = Color.FromArgb(100, 100, 100)
        lblLastName.AutoSize = False
        lblLastName.Size = New Size(182, 18)
        lblLastName.Location = New Point(650, 28)

        txtLastName.Font = New Font("Segoe UI", 10)
        txtLastName.Size = New Size(164, 28)
        txtLastName.Location = New Point(650, 48)
        txtLastName.BorderStyle = BorderStyle.FixedSingle
        txtLastName.BackColor = Color.FromArgb(235, 240, 245)
        txtLastName.ReadOnly = True

        ' ??????????????????????????????????????????????????????????
        ' grpDetails ? Age, DOB, Contact, Email
        ' ??????????????????????????????????????????????????????????
        grpDetails.Text = "Contact Details"
        grpDetails.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpDetails.ForeColor = Color.FromArgb(21, 67, 106)
        grpDetails.BackColor = Color.White
        grpDetails.Size = New Size(830, 140)
        grpDetails.Location = New Point(16, 172)
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
        lblAge.Location = New Point(16, 28)

        txtAge.Font = New Font("Segoe UI", 10)
        txtAge.Size = New Size(100, 28)
        txtAge.Location = New Point(16, 48)
        txtAge.BorderStyle = BorderStyle.FixedSingle
        txtAge.BackColor = Color.FromArgb(235, 240, 245)
        txtAge.ReadOnly = True

        ' Date of Birth
        lblDateOfBirth.Text = "DATE OF BIRTH"
        lblDateOfBirth.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblDateOfBirth.ForeColor = Color.FromArgb(100, 100, 100)
        lblDateOfBirth.AutoSize = False
        lblDateOfBirth.Size = New Size(260, 18)
        lblDateOfBirth.Location = New Point(134, 28)

        txtDateOfBirth.Font = New Font("Segoe UI", 10)
        txtDateOfBirth.Size = New Size(260, 28)
        txtDateOfBirth.Location = New Point(134, 48)
        txtDateOfBirth.BorderStyle = BorderStyle.FixedSingle
        txtDateOfBirth.BackColor = Color.FromArgb(235, 240, 245)
        txtDateOfBirth.ReadOnly = True

        ' Contact
        lblContact.Text = "CONTACT NUMBER"
        lblContact.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblContact.ForeColor = Color.FromArgb(100, 100, 100)
        lblContact.AutoSize = False
        lblContact.Size = New Size(200, 18)
        lblContact.Location = New Point(412, 28)

        txtContact.Font = New Font("Segoe UI", 10)
        txtContact.Size = New Size(200, 28)
        txtContact.Location = New Point(412, 48)
        txtContact.BorderStyle = BorderStyle.FixedSingle
        txtContact.BackColor = Color.FromArgb(235, 240, 245)
        txtContact.ReadOnly = True

        ' Email
        lblEmail.Text = "EMAIL ADDRESS"
        lblEmail.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblEmail.ForeColor = Color.FromArgb(100, 100, 100)
        lblEmail.AutoSize = False
        lblEmail.Size = New Size(202, 18)
        lblEmail.Location = New Point(630, 28)

        txtEmail.Font = New Font("Segoe UI", 10)
        txtEmail.Size = New Size(184, 28)
        txtEmail.Location = New Point(630, 48)
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        txtEmail.BackColor = Color.FromArgb(235, 240, 245)
        txtEmail.ReadOnly = True

        ' ??????????????????????????????????????????????????????????
        ' grpAdditional ? Valid ID file, Registered On
        ' ??????????????????????????????????????????????????????????
        grpAdditional.Text = "Additional Information"
        grpAdditional.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpAdditional.ForeColor = Color.FromArgb(21, 67, 106)
        grpAdditional.BackColor = Color.White
        grpAdditional.Size = New Size(830, 100)
        grpAdditional.Location = New Point(16, 328)
        grpAdditional.Controls.Add(txtRegisteredOn)
        grpAdditional.Controls.Add(lblRegisteredOn)
        grpAdditional.Controls.Add(txtIDFile)
        grpAdditional.Controls.Add(lblIDFile)

        lblIDFile.Text = "VALID ID ON FILE"
        lblIDFile.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblIDFile.ForeColor = Color.FromArgb(100, 100, 100)
        lblIDFile.AutoSize = False
        lblIDFile.Size = New Size(390, 18)
        lblIDFile.Location = New Point(16, 28)

        txtIDFile.Font = New Font("Segoe UI", 10)
        txtIDFile.Size = New Size(390, 28)
        txtIDFile.Location = New Point(16, 48)
        txtIDFile.BorderStyle = BorderStyle.FixedSingle
        txtIDFile.BackColor = Color.FromArgb(235, 240, 245)
        txtIDFile.ReadOnly = True

        lblRegisteredOn.Text = "REGISTERED ON"
        lblRegisteredOn.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblRegisteredOn.ForeColor = Color.FromArgb(100, 100, 100)
        lblRegisteredOn.AutoSize = False
        lblRegisteredOn.Size = New Size(390, 18)
        lblRegisteredOn.Location = New Point(424, 28)

        txtRegisteredOn.Font = New Font("Segoe UI", 10)
        txtRegisteredOn.Size = New Size(390, 28)
        txtRegisteredOn.Location = New Point(424, 48)
        txtRegisteredOn.BorderStyle = BorderStyle.FixedSingle
        txtRegisteredOn.BackColor = Color.FromArgb(235, 240, 245)
        txtRegisteredOn.ReadOnly = True

        ' ?? pnlFooter ?????????????????????????????????????????????
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
        btnBack.BackColor = Color.FromArgb(21, 67, 106)
        btnBack.ForeColor = Color.White
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.Size = New Size(130, 38)
        btnBack.Location = New Point(16, 12)
        btnBack.Cursor = Cursors.Hand

        ' ?? Form ??????????????????????????????????????????????????
        Me.Text = "LMS - Borrower Details"
        Me.ClientSize = New Size(880, 560)
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

    ' ?? Load Borrower from DB ????????????????????????????????????????????
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
            txtDateOfBirth.Text = If(row("DateOfBirth") Is DBNull.Value, "", CDate(row("DateOfBirth")).ToString("MMMM dd, yyyy"))
            txtContact.Text = row("Contact").ToString()
            txtEmail.Text = If(row("Email") Is DBNull.Value, "", row("Email").ToString())

            If row("IDImagePath") IsNot DBNull.Value AndAlso row("IDImagePath").ToString() <> "" Then
                txtIDFile.Text = IO.Path.GetFileName(row("IDImagePath").ToString())
            Else
                txtIDFile.Text = "No file on record"
            End If

            txtRegisteredOn.Text = If(row("CreatedAt") Is DBNull.Value, "", CDate(row("CreatedAt")).ToString("MMMM dd, yyyy"))
        Catch ex As Exception
            MessageBox.Show($"Failed to load borrower: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub ViewBorrowerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    ' ?? Back Button ???????????????????????????????????????????????
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    ' ?? Hover Effects ?????????????????????????????????????????????
    Private Sub btnBack_MouseEnter(sender As Object, e As EventArgs) Handles btnBack.MouseEnter
        btnBack.BackColor = Color.FromArgb(30, 95, 150)
    End Sub
    Private Sub btnBack_MouseLeave(sender As Object, e As EventArgs) Handles btnBack.MouseLeave
        btnBack.BackColor = Color.FromArgb(21, 67, 106)
    End Sub

End Class
