Public Class NewBorrowerForm
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
    Friend WithEvents dtpDateOfBirth As DateTimePicker
    Private lblContact As Label
    Friend WithEvents txtContact As TextBox
    Private lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Private grpID As GroupBox
    Private lblIDInstruction As Label
    Friend WithEvents btnUploadID As Button
    Private lblIDFileName As Label
    Private pnlFooter As Panel
    Private pnlDividerBottom As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnCancel As Button

    Public Sub New()
        InitializeComponent()
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
        dtpDateOfBirth = New DateTimePicker()
        lblContact = New Label()
        txtContact = New TextBox()
        lblEmail = New Label()
        txtEmail = New TextBox()
        grpID = New GroupBox()
        lblIDInstruction = New Label()
        btnUploadID = New Button()
        lblIDFileName = New Label()
        pnlFooter = New Panel()
        pnlDividerBottom = New Panel()
        btnAdd = New Button()
        btnCancel = New Button()

        SuspendLayout()

        ' ?? pnlHeader ?????????????????????????????????????????????
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        ' ?? lblTitle ??????????????????????????????????????????????
        lblTitle.Text = "New Borrower"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        ' ?? lblSubtitle ???????????????????????????????????????????
        lblSubtitle.Text = "Fill in the form below to register a new borrower"
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
        pnlBody.Controls.Add(grpID)
        pnlBody.Controls.Add(grpDetails)
        pnlBody.Controls.Add(grpPersonalInfo)

        ' ??????????????????????????????????????????????????????????
        ' grpPersonalInfo — UID, First, Middle, Last Name
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

        ' ?? Borrower UID ??????????????????????????????????????????
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
        txtBorrowerUID.Text = "BR-0006"

        ' ?? First Name ????????????????????????????????????????????
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
        txtFirstName.BackColor = Color.FromArgb(245, 248, 252)

        ' ?? Middle Name ???????????????????????????????????????????
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
        txtMiddleName.BackColor = Color.FromArgb(245, 248, 252)

        ' ?? Last Name ?????????????????????????????????????????????
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
        txtLastName.BackColor = Color.FromArgb(245, 248, 252)

        ' ??????????????????????????????????????????????????????????
        ' grpDetails — Age, DOB, Contact, Email
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
        grpDetails.Controls.Add(dtpDateOfBirth)
        grpDetails.Controls.Add(lblDateOfBirth)
        grpDetails.Controls.Add(txtAge)
        grpDetails.Controls.Add(lblAge)

        ' ?? Age ???????????????????????????????????????????????????
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
        txtAge.BackColor = Color.FromArgb(245, 248, 252)

        ' ?? Date of Birth ?????????????????????????????????????????
        lblDateOfBirth.Text = "DATE OF BIRTH"
        lblDateOfBirth.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblDateOfBirth.ForeColor = Color.FromArgb(100, 100, 100)
        lblDateOfBirth.AutoSize = False
        lblDateOfBirth.Size = New Size(260, 18)
        lblDateOfBirth.Location = New Point(134, 28)

        dtpDateOfBirth.Font = New Font("Segoe UI", 10)
        dtpDateOfBirth.Size = New Size(260, 28)
        dtpDateOfBirth.Location = New Point(134, 48)
        dtpDateOfBirth.Format = DateTimePickerFormat.Long
        dtpDateOfBirth.Value = New DateTime(1995, 1, 1)

        ' ?? Contact ???????????????????????????????????????????????
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
        txtContact.BackColor = Color.FromArgb(245, 248, 252)

        ' ?? Email ?????????????????????????????????????????????????
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
        txtEmail.BackColor = Color.FromArgb(245, 248, 252)

        ' ??????????????????????????????????????????????????????????
        ' grpID — Upload ID
        ' ??????????????????????????????????????????????????????????
        grpID.Text = "Valid ID"
        grpID.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpID.ForeColor = Color.FromArgb(21, 67, 106)
        grpID.BackColor = Color.White
        grpID.Size = New Size(830, 90)
        grpID.Location = New Point(16, 328)
        grpID.Controls.Add(lblIDFileName)
        grpID.Controls.Add(btnUploadID)
        grpID.Controls.Add(lblIDInstruction)

        ' ?? lblIDInstruction ??????????????????????????????????????
        lblIDInstruction.Text = "Upload a valid government-issued ID (JPG, PNG, PDF):"
        lblIDInstruction.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblIDInstruction.ForeColor = Color.FromArgb(80, 80, 80)
        lblIDInstruction.AutoSize = False
        lblIDInstruction.Size = New Size(420, 22)
        lblIDInstruction.Location = New Point(16, 28)

        ' ?? btnUploadID ???????????????????????????????????????????
        btnUploadID.Text = "Browse File..."
        btnUploadID.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        btnUploadID.BackColor = Color.FromArgb(245, 247, 250)
        btnUploadID.ForeColor = Color.FromArgb(21, 67, 106)
        btnUploadID.FlatStyle = FlatStyle.Flat
        btnUploadID.FlatAppearance.BorderSize = 1
        btnUploadID.FlatAppearance.BorderColor = Color.FromArgb(21, 67, 106)
        btnUploadID.Size = New Size(130, 34)
        btnUploadID.Location = New Point(16, 50)
        btnUploadID.Cursor = Cursors.Hand

        ' ?? lblIDFileName ?????????????????????????????????????????
        lblIDFileName.Text = "No file selected"
        lblIDFileName.Font = New Font("Segoe UI", 9, FontStyle.Italic)
        lblIDFileName.ForeColor = Color.Gray
        lblIDFileName.AutoSize = False
        lblIDFileName.Size = New Size(450, 34)
        lblIDFileName.Location = New Point(160, 56)

        ' ?? pnlFooter ?????????????????????????????????????????????
        pnlFooter.BackColor = Color.White
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 60
        pnlFooter.Controls.Add(btnCancel)
        pnlFooter.Controls.Add(btnAdd)
        pnlFooter.Controls.Add(pnlDividerBottom)

        ' ?? pnlDividerBottom ??????????????????????????????????????
        pnlDividerBottom.BackColor = Color.FromArgb(220, 220, 220)
        pnlDividerBottom.Dock = DockStyle.Top
        pnlDividerBottom.Height = 1

        ' ?? btnAdd ????????????????????????????????????????????????
        btnAdd.Text = "Add Borrower"
        btnAdd.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnAdd.BackColor = Color.FromArgb(21, 67, 106)
        btnAdd.ForeColor = Color.White
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.Size = New Size(140, 38)
        btnAdd.Location = New Point(16, 12)
        btnAdd.Cursor = Cursors.Hand

        ' ?? btnCancel ?????????????????????????????????????????????
        btnCancel.Text = "Cancel"
        btnCancel.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnCancel.BackColor = Color.FromArgb(240, 240, 240)
        btnCancel.ForeColor = Color.FromArgb(60, 60, 60)
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 1
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
        btnCancel.Size = New Size(130, 38)
        btnCancel.Location = New Point(168, 12)
        btnCancel.Cursor = Cursors.Hand

        ' ?? Form ??????????????????????????????????????????????????
        Me.Text = "LMS - New Borrower"
        Me.ClientSize = New Size(880, 530)
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

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub NewBorrowerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpDateOfBirth.Value = New DateTime(1995, 1, 1)
    End Sub

    ' ?? Upload ID ?????????????????????????????????????????????????
    Private Sub btnUploadID_Click(sender As Object, e As EventArgs) Handles btnUploadID.Click
        Using dlg As New OpenFileDialog()
            dlg.Title = "Select Valid ID"
            dlg.Filter = "Image & PDF Files|*.jpg;*.jpeg;*.png;*.pdf"
            dlg.Multiselect = False
            If dlg.ShowDialog() = DialogResult.OK Then
                lblIDFileName.Text = IO.Path.GetFileName(dlg.FileName)
                lblIDFileName.ForeColor = Color.FromArgb(21, 67, 106)
            End If
        End Using
    End Sub

    ' ?? Add Borrower ??????????????????????????????????????????????
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        MessageBox.Show(
            "Borrower record has been added successfully.",
            "Borrower Added",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )
        Me.Close()
    End Sub

    ' ?? Cancel ????????????????????????????????????????????????????
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ' ?? Hover Effects ?????????????????????????????????????????????
    Private Sub btnAdd_MouseEnter(sender As Object, e As EventArgs) Handles btnAdd.MouseEnter
        btnAdd.BackColor = Color.FromArgb(30, 95, 150)
    End Sub
    Private Sub btnAdd_MouseLeave(sender As Object, e As EventArgs) Handles btnAdd.MouseLeave
        btnAdd.BackColor = Color.FromArgb(21, 67, 106)
    End Sub
    Private Sub btnCancel_MouseEnter(sender As Object, e As EventArgs) Handles btnCancel.MouseEnter
        btnCancel.BackColor = Color.FromArgb(220, 220, 220)
    End Sub
    Private Sub btnCancel_MouseLeave(sender As Object, e As EventArgs) Handles btnCancel.MouseLeave
        btnCancel.BackColor = Color.FromArgb(240, 240, 240)
    End Sub
    Private Sub btnUploadID_MouseEnter(sender As Object, e As EventArgs) Handles btnUploadID.MouseEnter
        btnUploadID.BackColor = Color.FromArgb(21, 67, 106)
        btnUploadID.ForeColor = Color.White
    End Sub
    Private Sub btnUploadID_MouseLeave(sender As Object, e As EventArgs) Handles btnUploadID.MouseLeave
        btnUploadID.BackColor = Color.FromArgb(245, 247, 250)
        btnUploadID.ForeColor = Color.FromArgb(21, 67, 106)
    End Sub

End Class
