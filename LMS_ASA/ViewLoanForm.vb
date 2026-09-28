Public Class ViewLoanForm
    Inherits Form

    ' ?? Controls ??????????????????????????????????????????????????
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlDividerTop As Panel
    Private pnlBody As Panel
    Private grpLoanInfo As GroupBox
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
    Private lblCreatedLabel As Label
    Private lblCreatedValue As Label
    Private grpPaymentHistory As GroupBox
    Private lblPaymentSummary As Label
    Friend WithEvents dgvPayments As DataGridView
    Private lblNoPayments As Label
    Private pnlFooter As Panel
    Private pnlDividerBottom As Panel
    Friend WithEvents btnBack As Button

    Public Sub New(loanID As Integer)
        InitializeComponent()
        LoadLoan(loanID)
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlDividerTop = New Panel()
        pnlBody = New Panel()
        grpLoanInfo = New GroupBox()
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
        lblCreatedLabel = New Label()
        lblCreatedValue = New Label()
        grpPaymentHistory = New GroupBox()
        lblPaymentSummary = New Label()
        dgvPayments = New DataGridView()
        lblNoPayments = New Label()
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

        ' ── lblTitle ──────────────────────────────────────────────────
        lblTitle.Text = "Loan Details"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(231, 63, 30)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        ' ── lblSubtitle ───────────────────────────────────────────────
        lblSubtitle.Text = "Read-only view of the loan record"
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
        pnlBody.Controls.Add(grpPaymentHistory)
        pnlBody.Controls.Add(grpStatusInfo)
        pnlBody.Controls.Add(grpSchedule)
        pnlBody.Controls.Add(grpLoanDetails)
        pnlBody.Controls.Add(grpLoanInfo)

        ' ──────────────────────────────────────────────────────────────
        ' grpLoanInfo – Loan Reference, Borrower Name, Loan Type
        ' ──────────────────────────────────────────────────────────────
        grpLoanInfo.Text = "Loan Information"
        grpLoanInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpLoanInfo.ForeColor = Color.FromArgb(231, 63, 30)
        grpLoanInfo.BackColor = Color.White
        grpLoanInfo.Size = New Size(830, 140)
        grpLoanInfo.Location = New Point(16, 16)
        grpLoanInfo.Controls.Add(txtLoanType)
        grpLoanInfo.Controls.Add(lblLoanType)
        grpLoanInfo.Controls.Add(txtBorrowerName)
        grpLoanInfo.Controls.Add(lblBorrowerName)
        grpLoanInfo.Controls.Add(txtLoanID)
        grpLoanInfo.Controls.Add(lblLoanID)

        ' Loan Reference ID
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
        lblBorrowerName.Location = New Point(280, 28)

        txtBorrowerName.Font = New Font("Segoe UI", 10)
        txtBorrowerName.Size = New Size(270, 28)
        txtBorrowerName.Location = New Point(280, 48)
        txtBorrowerName.BorderStyle = BorderStyle.FixedSingle
        txtBorrowerName.BackColor = Color.FromArgb(235, 240, 245)
        txtBorrowerName.ReadOnly = True

        ' Loan Type
        lblLoanType.Text = "LOAN TYPE"
        lblLoanType.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblLoanType.ForeColor = Color.FromArgb(100, 100, 100)
        lblLoanType.AutoSize = False
        lblLoanType.Size = New Size(240, 18)
        lblLoanType.Location = New Point(574, 28)

        txtLoanType.Font = New Font("Segoe UI", 10)
        txtLoanType.Size = New Size(240, 28)
        txtLoanType.Location = New Point(574, 48)
        txtLoanType.BorderStyle = BorderStyle.FixedSingle
        txtLoanType.BackColor = Color.FromArgb(235, 240, 245)
        txtLoanType.ReadOnly = True

        ' ──────────────────────────────────────────────────────────────
        ' grpLoanDetails – Principal, Rate, Total Payable, Term
        ' ──────────────────────────────────────────────────────────────
        grpLoanDetails.Text = "Loan Details"
        grpLoanDetails.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpLoanDetails.ForeColor = Color.FromArgb(231, 63, 30)
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

        ' ──────────────────────────────────────────────────────────────
        ' grpSchedule – Release Date, Due Date
        ' ──────────────────────────────────────────────────────────────
        grpSchedule.Text = "Schedule"
        grpSchedule.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpSchedule.ForeColor = Color.FromArgb(231, 63, 30)
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

        ' ──────────────────────────────────────────────────────────────
        ' grpStatusInfo – Current Status, Created On
        ' ──────────────────────────────────────────────────────────────
        grpStatusInfo.Text = "Loan Status"
        grpStatusInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpStatusInfo.ForeColor = Color.FromArgb(231, 63, 30)
        grpStatusInfo.BackColor = Color.FromArgb(255, 250, 245)
        grpStatusInfo.Size = New Size(830, 60)
        grpStatusInfo.Location = New Point(16, 444)
        grpStatusInfo.Controls.Add(lblCreatedValue)
        grpStatusInfo.Controls.Add(lblCreatedLabel)
        grpStatusInfo.Controls.Add(lblStatusValue)
        grpStatusInfo.Controls.Add(lblStatusLabel)

        lblStatusLabel.Text = "Current Status:"
        lblStatusLabel.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        lblStatusLabel.ForeColor = Color.FromArgb(60, 80, 100)
        lblStatusLabel.AutoSize = True
        lblStatusLabel.Location = New Point(12, 26)

        lblStatusValue.Text = "Pending"
        lblStatusValue.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        lblStatusValue.ForeColor = Color.FromArgb(231, 63, 30)
        lblStatusValue.AutoSize = True
        lblStatusValue.Location = New Point(110, 26)

        lblCreatedLabel.Text = "Created On:"
        lblCreatedLabel.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        lblCreatedLabel.ForeColor = Color.FromArgb(60, 80, 100)
        lblCreatedLabel.AutoSize = True
        lblCreatedLabel.Location = New Point(400, 26)

        lblCreatedValue.Text = ""
        lblCreatedValue.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        lblCreatedValue.ForeColor = Color.FromArgb(231, 63, 30)
        lblCreatedValue.AutoSize = True
        lblCreatedValue.Location = New Point(490, 26)

        ' ──────────────────────────────────────────────────────────────
        ' grpPaymentHistory – Payment Summary & Payment List
        ' ──────────────────────────────────────────────────────────────
        grpPaymentHistory.Text = "Payment History"
        grpPaymentHistory.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpPaymentHistory.ForeColor = Color.FromArgb(231, 63, 30)
        grpPaymentHistory.BackColor = Color.White
        grpPaymentHistory.Size = New Size(830, 220)
        grpPaymentHistory.Location = New Point(16, 520)
        grpPaymentHistory.Controls.Add(lblNoPayments)
        grpPaymentHistory.Controls.Add(dgvPayments)
        grpPaymentHistory.Controls.Add(lblPaymentSummary)

        ' lblPaymentSummary
        lblPaymentSummary.Text = "Total Paid: PHP 0.00    |    Remaining Balance: PHP 0.00"
        lblPaymentSummary.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        lblPaymentSummary.ForeColor = Color.FromArgb(60, 80, 100)
        lblPaymentSummary.AutoSize = False
        lblPaymentSummary.Size = New Size(798, 22)
        lblPaymentSummary.Location = New Point(16, 26)

        ' dgvPayments
        dgvPayments.Location = New Point(16, 52)
        dgvPayments.Size = New Size(798, 152)
        dgvPayments.BackgroundColor = Color.White
        dgvPayments.BorderStyle = BorderStyle.Fixed3D
        dgvPayments.RowHeadersVisible = False
        dgvPayments.AllowUserToAddRows = False
        dgvPayments.AllowUserToDeleteRows = False
        dgvPayments.ReadOnly = True
        dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPayments.MultiSelect = False
        dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPayments.Font = New Font("Segoe UI", 9)
        dgvPayments.ColumnHeadersHeight = 32
        dgvPayments.RowTemplate.Height = 28
        dgvPayments.EnableHeadersVisualStyles = False
        dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 63, 30)
        dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvPayments.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvPayments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 252)

        ' lblNoPayments
        lblNoPayments.Text = "No payment records found for this loan."
        lblNoPayments.Font = New Font("Segoe UI", 9, FontStyle.Italic)
        lblNoPayments.ForeColor = Color.Gray
        lblNoPayments.AutoSize = True
        lblNoPayments.Location = New Point(280, 110)
        lblNoPayments.Visible = False

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
        Me.Text = "LMS - Loan Details"
        Me.ClientSize = New Size(880, 680)
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

    ' ── Load Loan from DB ─────────────────────────────────────────
    Private Sub LoadLoan(loanID As Integer)
        Try
            Dim dt As DataTable = LoanRepository.GetByID(loanID)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Loan record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If

            Dim row As DataRow = dt.Rows(0)
            txtLoanID.Text = row("LoanReferenceID").ToString()
            txtBorrowerName.Text = row("BorrowerName").ToString()
            txtLoanType.Text = row("LoanType").ToString()
            txtPrincipalAmount.Text = $"PHP {CDec(row("PrincipalAmount")):N2}"
            txtInterestRate.Text = $"{CDec(row("InterestRate")):N2}%"
            txtTotalPayable.Text = $"PHP {CDec(row("TotalPayable")):N2}"
            txtTerm.Text = $"{row("Term")} Month(s)"

            If row("ReleaseDate") IsNot DBNull.Value Then
                dtpReleaseDate.Value = CDate(row("ReleaseDate"))
            End If

            If row("DueDate") IsNot DBNull.Value Then
                dtpDueDate.Value = CDate(row("DueDate"))
            End If

            Dim status As String = row("Status").ToString()
            lblStatusValue.Text = status

            If row("CreatedAt") IsNot DBNull.Value Then
                lblCreatedValue.Text = CDate(row("CreatedAt")).ToString("MMMM dd, yyyy")
            End If

            Select Case status
                Case "Active", "Approved"
                    lblStatusValue.ForeColor = Color.FromArgb(40, 167, 69)
                Case "Pending"
                    lblStatusValue.ForeColor = Color.FromArgb(211, 84, 0)
                Case "Overdue", "Rejected"
                    lblStatusValue.ForeColor = Color.FromArgb(192, 57, 43)
                Case "Closed"
                    lblStatusValue.ForeColor = Color.FromArgb(90, 95, 100)
                Case Else
                    lblStatusValue.ForeColor = Color.FromArgb(231, 63, 30)
            End Select

            LoadPaymentHistory(loanID)
        Catch ex As Exception
            MessageBox.Show($"Failed to load loan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Payment History ───────────────────────────────────────────
    Private Sub LoadPaymentHistory(loanID As Integer)
        Try
            ' 1. Payment summary
            Dim summaryDt As DataTable = PaymentRepository.GetLoanPaymentSummary(loanID)
            If summaryDt IsNot Nothing AndAlso summaryDt.Rows.Count > 0 Then
                Dim sRow As DataRow = summaryDt.Rows(0)
                Dim totalPaid As Decimal = If(sRow("TotalPaid") IsNot DBNull.Value, CDec(sRow("TotalPaid")), 0D)
                Dim remBal As Decimal = If(sRow("RemainingBalance") IsNot DBNull.Value, CDec(sRow("RemainingBalance")), 0D)
                Dim monthlyAmort As Decimal = If(sRow("MonthlyAmortization") IsNot DBNull.Value, CDec(sRow("MonthlyAmortization")), 0D)

                lblPaymentSummary.Text = $"Total Paid: PHP {totalPaid:N2}    |    Remaining Balance: PHP {remBal:N2}    |    Monthly Amortization: PHP {monthlyAmort:N2}"
            Else
                lblPaymentSummary.Text = "Total Paid: PHP 0.00    |    Remaining Balance: PHP 0.00"
            End If

            ' 2. Payment list
            Dim raw As DataTable = PaymentRepository.GetByLoanID(loanID)
            Dim displayDt As New DataTable()
            displayDt.Columns.Add("PaymentDate", GetType(DateTime))
            displayDt.Columns.Add("Payee", GetType(String))
            displayDt.Columns.Add("Amount", GetType(Decimal))
            displayDt.Columns.Add("Penalty", GetType(Decimal))
            displayDt.Columns.Add("Status", GetType(String))

            If raw IsNot Nothing Then
                For Each row As DataRow In raw.Rows
                    Dim pDate As DateTime = If(row("PaymentDate") IsNot DBNull.Value, CDate(row("PaymentDate")), DateTime.MinValue)
                    Dim payee As String = If(row("Payee") IsNot DBNull.Value, row("Payee").ToString(), "")
                    Dim amt As Decimal = If(row("Amount") IsNot DBNull.Value, CDec(row("Amount")), 0D)
                    Dim pen As Decimal = If(row("Penalty") IsNot DBNull.Value, CDec(row("Penalty")), 0D)
                    Dim st As String = If(row("Status") IsNot DBNull.Value, row("Status").ToString(), "")
                    displayDt.Rows.Add(pDate, payee, amt, pen, st)
                Next
            End If

            dgvPayments.DataSource = displayDt

            If dgvPayments.Columns.Contains("PaymentDate") Then
                With dgvPayments.Columns("PaymentDate")
                    .HeaderText = "Date Paid"
                    .DefaultCellStyle.Format = "yyyy-MM-dd"
                    .FillWeight = 20
                End With
            End If
            If dgvPayments.Columns.Contains("Payee") Then
                With dgvPayments.Columns("Payee")
                    .HeaderText = "Payee / Member"
                    .FillWeight = 30
                End With
            End If
            If dgvPayments.Columns.Contains("Amount") Then
                With dgvPayments.Columns("Amount")
                    .HeaderText = "Amount (PHP)"
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .FillWeight = 20
                End With
            End If
            If dgvPayments.Columns.Contains("Penalty") Then
                With dgvPayments.Columns("Penalty")
                    .HeaderText = "Penalty (PHP)"
                    .DefaultCellStyle.Format = "N2"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .FillWeight = 15
                End With
            End If
            If dgvPayments.Columns.Contains("Status") Then
                With dgvPayments.Columns("Status")
                    .HeaderText = "Status"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .FillWeight = 15
                End With
            End If

            If displayDt.Rows.Count = 0 Then
                lblNoPayments.Visible = True
                lblNoPayments.BringToFront()
            Else
                lblNoPayments.Visible = False
            End If

        Catch ex As Exception
            lblPaymentSummary.Text = "Unable to load payment history: " & ex.Message
        End Try
    End Sub

    Private Sub dgvPayments_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvPayments.CellFormatting
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return
        If dgvPayments.Columns(e.ColumnIndex).Name = "Status" Then
            Dim status As String = e.Value.ToString()
            Select Case status
                Case "Paid"
                    e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69)
                    e.CellStyle.Font = New Font(dgvPayments.Font, FontStyle.Bold)
                Case "Pending"
                    e.CellStyle.ForeColor = Color.FromArgb(251, 108, 0)
                    e.CellStyle.Font = New Font(dgvPayments.Font, FontStyle.Bold)
                Case "Overdue"
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69)
                    e.CellStyle.Font = New Font(dgvPayments.Font, FontStyle.Bold)
                Case Else
                    e.CellStyle.ForeColor = Color.FromArgb(108, 117, 125)
            End Select
        End If
    End Sub

    ' ── Form Load ─────────────────────────────────────────────────
    Private Sub ViewLoanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    ' ── Back Button ───────────────────────────────────────────────
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    ' ── Hover Effects ─────────────────────────────────────────────
    Private Sub btnBack_MouseEnter(sender As Object, e As EventArgs) Handles btnBack.MouseEnter
        btnBack.BackColor = Color.FromArgb(251, 108, 0)
    End Sub
    Private Sub btnBack_MouseLeave(sender As Object, e As EventArgs) Handles btnBack.MouseLeave
        btnBack.BackColor = Color.FromArgb(231, 63, 30)
    End Sub

End Class
