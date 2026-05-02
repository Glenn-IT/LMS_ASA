Public Class ViewLoanApplicationForm
    Inherits Form

    ' ?? Controls ??????????????????????????????????????????????????
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlDividerTop As Panel
    Private pnlBody As Panel
    Private grpApplicantInfo As GroupBox
    Private lblLoanID As Label
    Friend WithEvents txtLoanID As TextBox
    Private lblBorrowerName As Label
    Friend WithEvents txtBorrowerName As TextBox
    Private lblLoanType As Label
    Friend WithEvents txtLoanType As TextBox
    Private grpLoanDetails As GroupBox
    Private lblPrincipalAmount As Label
    Friend WithEvents txtPrincipalAmount As TextBox
    Private lblInterestRate As Label
    Friend WithEvents txtInterestRate As TextBox
    Private lblTotalPayable As Label
    Friend WithEvents txtTotalPayable As TextBox
    Private lblTerm As Label
    Friend WithEvents txtTerm As TextBox
    Private grpSchedule As GroupBox
    Private lblReleaseDate As Label
    Friend WithEvents dtpReleaseDate As DateTimePicker
    Private lblDueDate As Label
    Friend WithEvents dtpDueDate As DateTimePicker
    Private grpStatusInfo As GroupBox
    Private lblStatusLabel As Label
    Private lblStatusValue As Label
    Private pnlFooter As Panel
    Private pnlDividerBottom As Panel
    Friend WithEvents btnBack As Button

    Public Sub New(loanRefID As String, amount As String, status As String)
        InitializeComponent()
        PopulateFields(loanRefID, amount, status)
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlDividerTop = New Panel()
        pnlBody = New Panel()
        grpApplicantInfo = New GroupBox()
        lblLoanID = New Label()
        txtLoanID = New TextBox()
        lblBorrowerName = New Label()
        txtBorrowerName = New TextBox()
        lblLoanType = New Label()
        txtLoanType = New TextBox()
        grpLoanDetails = New GroupBox()
        lblPrincipalAmount = New Label()
        txtPrincipalAmount = New TextBox()
        lblInterestRate = New Label()
        txtInterestRate = New TextBox()
        lblTotalPayable = New Label()
        txtTotalPayable = New TextBox()
        lblTerm = New Label()
        txtTerm = New TextBox()
        grpSchedule = New GroupBox()
        lblReleaseDate = New Label()
        dtpReleaseDate = New DateTimePicker()
        lblDueDate = New Label()
        dtpDueDate = New DateTimePicker()
        grpStatusInfo = New GroupBox()
        lblStatusLabel = New Label()
        lblStatusValue = New Label()
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

        lblTitle.Text = "Loan Application Details"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        lblSubtitle.Text = "Read-only view of your submitted loan application"
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
        pnlBody.Controls.Add(grpStatusInfo)
        pnlBody.Controls.Add(grpSchedule)
        pnlBody.Controls.Add(grpLoanDetails)
        pnlBody.Controls.Add(grpApplicantInfo)

        ' ??????????????????????????????????????????????????????????
        ' grpApplicantInfo
        ' ??????????????????????????????????????????????????????????
        grpApplicantInfo.Text = "Applicant Information"
        grpApplicantInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpApplicantInfo.ForeColor = Color.FromArgb(21, 67, 106)
        grpApplicantInfo.BackColor = Color.White
        grpApplicantInfo.Size = New Size(830, 140)
        grpApplicantInfo.Location = New Point(16, 16)
        grpApplicantInfo.Controls.Add(txtLoanType)
        grpApplicantInfo.Controls.Add(lblLoanType)
        grpApplicantInfo.Controls.Add(txtBorrowerName)
        grpApplicantInfo.Controls.Add(lblBorrowerName)
        grpApplicantInfo.Controls.Add(txtLoanID)
        grpApplicantInfo.Controls.Add(lblLoanID)

        ' Loan ID
        lblLoanID.Text = "LOAN REFERENCE ID"
        lblLoanID.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblLoanID.ForeColor = Color.FromArgb(100, 100, 100)
        lblLoanID.AutoSize = False
        lblLoanID.Size = New Size(240, 18)
        lblLoanID.Location = New Point(16, 28)

        txtLoanID.Font = New Font("Segoe UI", 10)
        txtLoanID.Size = New Size(240, 28)
        txtLoanID.Location = New Point(16, 48)
        txtLoanID.BorderStyle = BorderStyle.FixedSingle
        txtLoanID.BackColor = Color.FromArgb(235, 240, 245)
        txtLoanID.ReadOnly = True

        ' Borrower Name
        lblBorrowerName.Text = "BORROWER NAME"
        lblBorrowerName.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblBorrowerName.ForeColor = Color.FromArgb(100, 100, 100)
        lblBorrowerName.AutoSize = False
        lblBorrowerName.Size = New Size(270, 18)
        lblBorrowerName.Location = New Point(274, 28)

        txtBorrowerName.Font = New Font("Segoe UI", 10)
        txtBorrowerName.Size = New Size(270, 28)
        txtBorrowerName.Location = New Point(274, 48)
        txtBorrowerName.BorderStyle = BorderStyle.FixedSingle
        txtBorrowerName.BackColor = Color.FromArgb(235, 240, 245)
        txtBorrowerName.ReadOnly = True
        txtBorrowerName.Text = "Juan dela Cruz"

        ' Loan Type
        lblLoanType.Text = "LOAN TYPE"
        lblLoanType.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblLoanType.ForeColor = Color.FromArgb(100, 100, 100)
        lblLoanType.AutoSize = False
        lblLoanType.Size = New Size(252, 18)
        lblLoanType.Location = New Point(562, 28)

        txtLoanType.Font = New Font("Segoe UI", 10)
        txtLoanType.Size = New Size(252, 28)
        txtLoanType.Location = New Point(562, 48)
        txtLoanType.BorderStyle = BorderStyle.FixedSingle
        txtLoanType.BackColor = Color.FromArgb(235, 240, 245)
        txtLoanType.ReadOnly = True
        txtLoanType.Text = "Personal Loan"

        ' ??????????????????????????????????????????????????????????
        ' grpLoanDetails
        ' ??????????????????????????????????????????????????????????
        grpLoanDetails.Text = "Loan Details"
        grpLoanDetails.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpLoanDetails.ForeColor = Color.FromArgb(21, 67, 106)
        grpLoanDetails.BackColor = Color.White
        grpLoanDetails.Size = New Size(830, 140)
        grpLoanDetails.Location = New Point(16, 172)
        grpLoanDetails.Controls.Add(txtTerm)
        grpLoanDetails.Controls.Add(lblTerm)
        grpLoanDetails.Controls.Add(txtTotalPayable)
        grpLoanDetails.Controls.Add(lblTotalPayable)
        grpLoanDetails.Controls.Add(txtInterestRate)
        grpLoanDetails.Controls.Add(lblInterestRate)
        grpLoanDetails.Controls.Add(txtPrincipalAmount)
        grpLoanDetails.Controls.Add(lblPrincipalAmount)

        ' Principal Amount
        lblPrincipalAmount.Text = "PRINCIPAL AMOUNT (PHP)"
        lblPrincipalAmount.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblPrincipalAmount.ForeColor = Color.FromArgb(100, 100, 100)
        lblPrincipalAmount.AutoSize = False
        lblPrincipalAmount.Size = New Size(190, 18)
        lblPrincipalAmount.Location = New Point(16, 28)

        txtPrincipalAmount.Font = New Font("Segoe UI", 10)
        txtPrincipalAmount.Size = New Size(190, 28)
        txtPrincipalAmount.Location = New Point(16, 48)
        txtPrincipalAmount.BorderStyle = BorderStyle.FixedSingle
        txtPrincipalAmount.BackColor = Color.FromArgb(235, 240, 245)
        txtPrincipalAmount.ReadOnly = True

        ' Interest Rate
        lblInterestRate.Text = "INTEREST RATE (%)"
        lblInterestRate.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblInterestRate.ForeColor = Color.FromArgb(100, 100, 100)
        lblInterestRate.AutoSize = False
        lblInterestRate.Size = New Size(190, 18)
        lblInterestRate.Location = New Point(224, 28)

        txtInterestRate.Font = New Font("Segoe UI", 10)
        txtInterestRate.Size = New Size(190, 28)
        txtInterestRate.Location = New Point(224, 48)
        txtInterestRate.BorderStyle = BorderStyle.FixedSingle
        txtInterestRate.BackColor = Color.FromArgb(235, 240, 245)
        txtInterestRate.ReadOnly = True
        txtInterestRate.Text = "5%"

        ' Total Payable
        lblTotalPayable.Text = "TOTAL PAYABLE AMOUNT (PHP)"
        lblTotalPayable.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblTotalPayable.ForeColor = Color.FromArgb(100, 100, 100)
        lblTotalPayable.AutoSize = False
        lblTotalPayable.Size = New Size(210, 18)
        lblTotalPayable.Location = New Point(432, 28)

        txtTotalPayable.Font = New Font("Segoe UI", 10)
        txtTotalPayable.Size = New Size(210, 28)
        txtTotalPayable.Location = New Point(432, 48)
        txtTotalPayable.BorderStyle = BorderStyle.FixedSingle
        txtTotalPayable.BackColor = Color.FromArgb(235, 240, 245)
        txtTotalPayable.ReadOnly = True

        ' Term
        lblTerm.Text = "TERM (Months)"
        lblTerm.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblTerm.ForeColor = Color.FromArgb(100, 100, 100)
        lblTerm.AutoSize = False
        lblTerm.Size = New Size(172, 18)
        lblTerm.Location = New Point(660, 28)

        txtTerm.Font = New Font("Segoe UI", 10)
        txtTerm.Size = New Size(154, 28)
        txtTerm.Location = New Point(660, 48)
        txtTerm.BorderStyle = BorderStyle.FixedSingle
        txtTerm.BackColor = Color.FromArgb(235, 240, 245)
        txtTerm.ReadOnly = True
        txtTerm.Text = "12"

        ' ??????????????????????????????????????????????????????????
        ' grpSchedule
        ' ??????????????????????????????????????????????????????????
        grpSchedule.Text = "Schedule"
        grpSchedule.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpSchedule.ForeColor = Color.FromArgb(21, 67, 106)
        grpSchedule.BackColor = Color.White
        grpSchedule.Size = New Size(830, 100)
        grpSchedule.Location = New Point(16, 328)
        grpSchedule.Controls.Add(dtpDueDate)
        grpSchedule.Controls.Add(lblDueDate)
        grpSchedule.Controls.Add(dtpReleaseDate)
        grpSchedule.Controls.Add(lblReleaseDate)

        lblReleaseDate.Text = "RELEASE DATE"
        lblReleaseDate.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblReleaseDate.ForeColor = Color.FromArgb(100, 100, 100)
        lblReleaseDate.AutoSize = False
        lblReleaseDate.Size = New Size(390, 18)
        lblReleaseDate.Location = New Point(16, 28)

        dtpReleaseDate.Font = New Font("Segoe UI", 10)
        dtpReleaseDate.Size = New Size(390, 28)
        dtpReleaseDate.Location = New Point(16, 48)
        dtpReleaseDate.Format = DateTimePickerFormat.Long
        dtpReleaseDate.Enabled = False

        lblDueDate.Text = "DUE DATE"
        lblDueDate.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblDueDate.ForeColor = Color.FromArgb(100, 100, 100)
        lblDueDate.AutoSize = False
        lblDueDate.Size = New Size(390, 18)
        lblDueDate.Location = New Point(424, 28)

        dtpDueDate.Font = New Font("Segoe UI", 10)
        dtpDueDate.Size = New Size(390, 28)
        dtpDueDate.Location = New Point(424, 48)
        dtpDueDate.Format = DateTimePickerFormat.Long
        dtpDueDate.Enabled = False
        dtpDueDate.Value = DateTime.Today.AddMonths(12)

        ' ??????????????????????????????????????????????????????????
        ' grpStatusInfo
        ' ??????????????????????????????????????????????????????????
        grpStatusInfo.Text = "Application Status"
        grpStatusInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpStatusInfo.ForeColor = Color.FromArgb(21, 67, 106)
        grpStatusInfo.BackColor = Color.FromArgb(240, 246, 252)
        grpStatusInfo.Size = New Size(830, 60)
        grpStatusInfo.Location = New Point(16, 444)
        grpStatusInfo.Controls.Add(lblStatusValue)
        grpStatusInfo.Controls.Add(lblStatusLabel)

        lblStatusLabel.Text = "Current Status:"
        lblStatusLabel.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        lblStatusLabel.ForeColor = Color.FromArgb(60, 80, 100)
        lblStatusLabel.AutoSize = True
        lblStatusLabel.Location = New Point(12, 26)

        lblStatusValue.Text = "Pending"
        lblStatusValue.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        lblStatusValue.ForeColor = Color.FromArgb(21, 67, 106)
        lblStatusValue.AutoSize = True
        lblStatusValue.Location = New Point(110, 26)

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
        Me.Text = "LMS - Loan Application Details"
        Me.ClientSize = New Size(880, 620)
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

    ' ?? Populate Fields from selected row ?????????????????????????
    Private Sub PopulateFields(loanRefID As String, amount As String, status As String)
        txtLoanID.Text = loanRefID
        txtPrincipalAmount.Text = amount
        txtTotalPayable.Text = amount

        lblStatusValue.Text = status
        Select Case status
            Case "Approved"
                lblStatusValue.ForeColor = Color.FromArgb(39, 174, 96)
            Case "Pending"
                lblStatusValue.ForeColor = Color.FromArgb(211, 84, 0)
            Case "Rejected"
                lblStatusValue.ForeColor = Color.FromArgb(192, 57, 43)
            Case Else
                lblStatusValue.ForeColor = Color.FromArgb(21, 67, 106)
        End Select
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
