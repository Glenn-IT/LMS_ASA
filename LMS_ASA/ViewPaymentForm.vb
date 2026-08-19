Public Class ViewPaymentForm
    Inherits Form

    ' ── Controls ──────────────────────────────────────────────────
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlDividerTop As Panel
    Private pnlBody As Panel

    Private grpPaymentInfo As GroupBox
    Private lblLoanRef As Label
    Friend WithEvents txtLoanRef As TextBox
    Private lblBorrowerName As Label
    Friend WithEvents txtBorrowerName As TextBox
    Private lblPayee As Label
    Friend WithEvents txtPayee As TextBox

    ' ── Loan Summary GroupBox ─────────────────────────────────────
    Private grpLoanSummary As GroupBox
    Private lblLblTotalLoan As Label
    Private lblValTotalLoan As Label
    Private lblLblMonthlyAmort As Label
    Private lblValMonthlyAmort As Label
    Private lblLblTotalPaid As Label
    Private lblValTotalPaid As Label
    Private lblLblRemainingBal As Label
    Private lblValRemainingBal As Label
    Private lblLblMonthsLeft As Label
    Private lblValMonthsLeft As Label

    Private grpAmounts As GroupBox
    Private lblAmount As Label
    Friend WithEvents txtAmount As TextBox
    Private lblPenalty As Label
    Friend WithEvents txtPenalty As TextBox

    Private grpSchedule As GroupBox
    Private lblPaymentDate As Label
    Friend WithEvents dtpPaymentDate As DateTimePicker

    Private grpStatusInfo As GroupBox
    Private lblStatusLabel As Label
    Private lblStatusValue As Label
    Private lblRecordedLabel As Label
    Private lblRecordedValue As Label

    Private pnlFooter As Panel
    Private pnlDividerBottom As Panel
    Friend WithEvents btnBack As Button

    Public Sub New(paymentID As Integer)
        InitializeComponent()
        LoadPayment(paymentID)
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlDividerTop = New Panel()
        pnlBody = New Panel()

        grpPaymentInfo = New GroupBox()
        lblLoanRef = New Label()
        txtLoanRef = New TextBox()
        lblBorrowerName = New Label()
        txtBorrowerName = New TextBox()
        lblPayee = New Label()
        txtPayee = New TextBox()

        grpLoanSummary = New GroupBox()
        lblLblTotalLoan = New Label()
        lblValTotalLoan = New Label()
        lblLblMonthlyAmort = New Label()
        lblValMonthlyAmort = New Label()
        lblLblTotalPaid = New Label()
        lblValTotalPaid = New Label()
        lblLblRemainingBal = New Label()
        lblValRemainingBal = New Label()
        lblLblMonthsLeft = New Label()
        lblValMonthsLeft = New Label()

        grpAmounts = New GroupBox()
        lblAmount = New Label()
        txtAmount = New TextBox()
        lblPenalty = New Label()
        txtPenalty = New TextBox()

        grpSchedule = New GroupBox()
        lblPaymentDate = New Label()
        dtpPaymentDate = New DateTimePicker()

        grpStatusInfo = New GroupBox()
        lblStatusLabel = New Label()
        lblStatusValue = New Label()
        lblRecordedLabel = New Label()
        lblRecordedValue = New Label()

        pnlFooter = New Panel()
        pnlDividerBottom = New Panel()
        btnBack = New Button()

        SuspendLayout()

        ' ── pnlHeader ──────────────────────────────────────────────
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        lblTitle.Text = "Payment Details"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        lblSubtitle.Text = "Read-only view of payment details, amortization, and balance status"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(500, 18)
        lblSubtitle.Location = New Point(16, 40)

        ' ── pnlDividerTop ──────────────────────────────────────────
        pnlDividerTop.BackColor = Color.FromArgb(220, 220, 220)
        pnlDividerTop.Dock = DockStyle.Top
        pnlDividerTop.Height = 1

        ' ── pnlBody ────────────────────────────────────────────────
        pnlBody.BackColor = Color.FromArgb(245, 247, 250)
        pnlBody.Dock = DockStyle.Fill
        pnlBody.Padding = New Padding(16)
        pnlBody.AutoScroll = True
        pnlBody.Controls.Add(grpStatusInfo)
        pnlBody.Controls.Add(grpSchedule)
        pnlBody.Controls.Add(grpAmounts)
        pnlBody.Controls.Add(grpLoanSummary)
        pnlBody.Controls.Add(grpPaymentInfo)

        ' ── grpPaymentInfo — Loan Reference, Borrower Name, Payee ────
        grpPaymentInfo.Text = "Payment Information"
        grpPaymentInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpPaymentInfo.ForeColor = Color.FromArgb(21, 67, 106)
        grpPaymentInfo.BackColor = Color.White
        grpPaymentInfo.Size = New Size(830, 95)
        grpPaymentInfo.Location = New Point(16, 16)
        grpPaymentInfo.Controls.Add(txtPayee)
        grpPaymentInfo.Controls.Add(lblPayee)
        grpPaymentInfo.Controls.Add(txtBorrowerName)
        grpPaymentInfo.Controls.Add(lblBorrowerName)
        grpPaymentInfo.Controls.Add(txtLoanRef)
        grpPaymentInfo.Controls.Add(lblLoanRef)

        ' Loan Reference
        lblLoanRef.Text = "LOAN REFERENCE"
        lblLoanRef.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblLoanRef.ForeColor = Color.FromArgb(100, 100, 100)
        lblLoanRef.AutoSize = False
        lblLoanRef.Size = New Size(260, 18)
        lblLoanRef.Location = New Point(16, 25)

        txtLoanRef.Font = New Font("Segoe UI", 10)
        txtLoanRef.Size = New Size(260, 28)
        txtLoanRef.Location = New Point(16, 45)
        txtLoanRef.BorderStyle = BorderStyle.FixedSingle
        txtLoanRef.BackColor = Color.FromArgb(235, 240, 245)
        txtLoanRef.ReadOnly = True

        ' Borrower Name
        lblBorrowerName.Text = "BORROWER NAME"
        lblBorrowerName.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblBorrowerName.ForeColor = Color.FromArgb(100, 100, 100)
        lblBorrowerName.AutoSize = False
        lblBorrowerName.Size = New Size(260, 18)
        lblBorrowerName.Location = New Point(296, 25)

        txtBorrowerName.Font = New Font("Segoe UI", 10)
        txtBorrowerName.Size = New Size(260, 28)
        txtBorrowerName.Location = New Point(296, 45)
        txtBorrowerName.BorderStyle = BorderStyle.FixedSingle
        txtBorrowerName.BackColor = Color.FromArgb(235, 240, 245)
        txtBorrowerName.ReadOnly = True

        ' Payee
        lblPayee.Text = "PAYEE"
        lblPayee.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblPayee.ForeColor = Color.FromArgb(100, 100, 100)
        lblPayee.AutoSize = False
        lblPayee.Size = New Size(240, 18)
        lblPayee.Location = New Point(574, 25)

        txtPayee.Font = New Font("Segoe UI", 10)
        txtPayee.Size = New Size(240, 28)
        txtPayee.Location = New Point(574, 45)
        txtPayee.BorderStyle = BorderStyle.FixedSingle
        txtPayee.BackColor = Color.FromArgb(235, 240, 245)
        txtPayee.ReadOnly = True

        ' ── grpLoanSummary — Loan & Amortization Overview ─────────
        grpLoanSummary.Text = "Loan & Amortization Overview"
        grpLoanSummary.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpLoanSummary.ForeColor = Color.FromArgb(21, 67, 106)
        grpLoanSummary.BackColor = Color.FromArgb(248, 250, 254)
        grpLoanSummary.Size = New Size(830, 115)
        grpLoanSummary.Location = New Point(16, 120)

        ' Total Loan
        lblLblTotalLoan.Text = "TOTAL LOAN"
        lblLblTotalLoan.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblLblTotalLoan.ForeColor = Color.Gray
        lblLblTotalLoan.Location = New Point(16, 30)
        lblLblTotalLoan.Size = New Size(140, 16)

        lblValTotalLoan.Text = "PHP 0.00"
        lblValTotalLoan.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblValTotalLoan.ForeColor = Color.FromArgb(30, 40, 60)
        lblValTotalLoan.Location = New Point(16, 48)
        lblValTotalLoan.Size = New Size(140, 24)

        ' Monthly Amortization
        lblLblMonthlyAmort.Text = "MONTHLY PAYMENT"
        lblLblMonthlyAmort.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblLblMonthlyAmort.ForeColor = Color.Gray
        lblLblMonthlyAmort.Location = New Point(170, 30)
        lblLblMonthlyAmort.Size = New Size(150, 16)

        lblValMonthlyAmort.Text = "PHP 0.00"
        lblValMonthlyAmort.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblValMonthlyAmort.ForeColor = Color.FromArgb(21, 67, 106)
        lblValMonthlyAmort.Location = New Point(170, 48)
        lblValMonthlyAmort.Size = New Size(150, 24)

        ' Total Paid
        lblLblTotalPaid.Text = "TOTAL PAID SO FAR"
        lblLblTotalPaid.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblLblTotalPaid.ForeColor = Color.Gray
        lblLblTotalPaid.Location = New Point(335, 30)
        lblLblTotalPaid.Size = New Size(140, 16)

        lblValTotalPaid.Text = "PHP 0.00"
        lblValTotalPaid.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblValTotalPaid.ForeColor = Color.FromArgb(40, 167, 69)
        lblValTotalPaid.Location = New Point(335, 48)
        lblValTotalPaid.Size = New Size(140, 24)

        ' Remaining Balance
        lblLblRemainingBal.Text = "REMAINING BALANCE"
        lblLblRemainingBal.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblLblRemainingBal.ForeColor = Color.Gray
        lblLblRemainingBal.Location = New Point(490, 30)
        lblLblRemainingBal.Size = New Size(160, 16)

        lblValRemainingBal.Text = "PHP 0.00"
        lblValRemainingBal.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblValRemainingBal.ForeColor = Color.FromArgb(220, 53, 69)
        lblValRemainingBal.Location = New Point(490, 48)
        lblValRemainingBal.Size = New Size(160, 24)

        ' Months Left
        lblLblMonthsLeft.Text = "SCHEDULE (MONTHS)"
        lblLblMonthsLeft.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblLblMonthsLeft.ForeColor = Color.Gray
        lblLblMonthsLeft.Location = New Point(665, 30)
        lblLblMonthsLeft.Size = New Size(145, 16)

        lblValMonthsLeft.Text = "0 of 0 Mos"
        lblValMonthsLeft.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblValMonthsLeft.ForeColor = Color.FromArgb(30, 40, 60)
        lblValMonthsLeft.Location = New Point(665, 48)
        lblValMonthsLeft.Size = New Size(145, 24)

        grpLoanSummary.Controls.Add(lblLblTotalLoan)
        grpLoanSummary.Controls.Add(lblValTotalLoan)
        grpLoanSummary.Controls.Add(lblLblMonthlyAmort)
        grpLoanSummary.Controls.Add(lblValMonthlyAmort)
        grpLoanSummary.Controls.Add(lblLblTotalPaid)
        grpLoanSummary.Controls.Add(lblValTotalPaid)
        grpLoanSummary.Controls.Add(lblLblRemainingBal)
        grpLoanSummary.Controls.Add(lblValRemainingBal)
        grpLoanSummary.Controls.Add(lblLblMonthsLeft)
        grpLoanSummary.Controls.Add(lblValMonthsLeft)

        ' ── grpAmounts — Amount, Penalty ───────────────────────────
        grpAmounts.Text = "Transaction Amount"
        grpAmounts.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpAmounts.ForeColor = Color.FromArgb(21, 67, 106)
        grpAmounts.BackColor = Color.White
        grpAmounts.Size = New Size(830, 95)
        grpAmounts.Location = New Point(16, 245)
        grpAmounts.Controls.Add(txtPenalty)
        grpAmounts.Controls.Add(lblPenalty)
        grpAmounts.Controls.Add(txtAmount)
        grpAmounts.Controls.Add(lblAmount)

        ' Amount
        lblAmount.Text = "AMOUNT PAID (PHP)"
        lblAmount.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblAmount.ForeColor = Color.FromArgb(100, 100, 100)
        lblAmount.AutoSize = False
        lblAmount.Size = New Size(390, 18)
        lblAmount.Location = New Point(16, 25)

        txtAmount.Font = New Font("Segoe UI", 10)
        txtAmount.Size = New Size(390, 28)
        txtAmount.Location = New Point(16, 45)
        txtAmount.BorderStyle = BorderStyle.FixedSingle
        txtAmount.BackColor = Color.FromArgb(235, 240, 245)
        txtAmount.ReadOnly = True

        ' Penalty
        lblPenalty.Text = "PENALTY (PHP)"
        lblPenalty.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblPenalty.ForeColor = Color.FromArgb(100, 100, 100)
        lblPenalty.AutoSize = False
        lblPenalty.Size = New Size(390, 18)
        lblPenalty.Location = New Point(424, 25)

        txtPenalty.Font = New Font("Segoe UI", 10)
        txtPenalty.Size = New Size(390, 28)
        txtPenalty.Location = New Point(424, 45)
        txtPenalty.BorderStyle = BorderStyle.FixedSingle
        txtPenalty.BackColor = Color.FromArgb(235, 240, 245)
        txtPenalty.ReadOnly = True

        ' ── grpSchedule — Payment Date ─────────────────────────────
        grpSchedule.Text = "Schedule"
        grpSchedule.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpSchedule.ForeColor = Color.FromArgb(21, 67, 106)
        grpSchedule.BackColor = Color.White
        grpSchedule.Size = New Size(830, 85)
        grpSchedule.Location = New Point(16, 350)
        grpSchedule.Controls.Add(dtpPaymentDate)
        grpSchedule.Controls.Add(lblPaymentDate)

        lblPaymentDate.Text = "PAYMENT DATE"
        lblPaymentDate.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblPaymentDate.ForeColor = Color.FromArgb(100, 100, 100)
        lblPaymentDate.AutoSize = False
        lblPaymentDate.Size = New Size(390, 18)
        lblPaymentDate.Location = New Point(16, 22)

        dtpPaymentDate.Font = New Font("Segoe UI", 10)
        dtpPaymentDate.Size = New Size(390, 28)
        dtpPaymentDate.Location = New Point(16, 42)
        dtpPaymentDate.Format = DateTimePickerFormat.Long
        dtpPaymentDate.Enabled = False

        ' ── grpStatusInfo — Current Status, Recorded On ───────────
        grpStatusInfo.Text = "Payment Status"
        grpStatusInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpStatusInfo.ForeColor = Color.FromArgb(21, 67, 106)
        grpStatusInfo.BackColor = Color.FromArgb(240, 246, 252)
        grpStatusInfo.Size = New Size(830, 60)
        grpStatusInfo.Location = New Point(16, 445)
        grpStatusInfo.Controls.Add(lblRecordedValue)
        grpStatusInfo.Controls.Add(lblRecordedLabel)
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

        lblRecordedLabel.Text = "Recorded On:"
        lblRecordedLabel.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        lblRecordedLabel.ForeColor = Color.FromArgb(60, 80, 100)
        lblRecordedLabel.AutoSize = True
        lblRecordedLabel.Location = New Point(400, 26)

        lblRecordedValue.Text = ""
        lblRecordedValue.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        lblRecordedValue.ForeColor = Color.FromArgb(21, 67, 106)
        lblRecordedValue.AutoSize = True
        lblRecordedValue.Location = New Point(498, 26)

        ' ── pnlFooter ──────────────────────────────────────────────
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

        ' ── Form Setup ─────────────────────────────────────────────
        Me.Text = "LMS - Payment Details"
        Me.ClientSize = New Size(880, 600)
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

    ' ── Load Payment from DB ───────────────────────────────────────
    Private Sub LoadPayment(paymentID As Integer)
        Try
            Dim dt As DataTable = PaymentRepository.GetByID(paymentID)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Payment record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If
            Dim row As DataRow = dt.Rows(0)
            txtLoanRef.Text = row("LoanReferenceID").ToString()
            txtBorrowerName.Text = row("BorrowerName").ToString()
            txtPayee.Text = row("Payee").ToString()
            txtAmount.Text = CDec(row("Amount")).ToString("N2")
            txtPenalty.Text = CDec(row("Penalty")).ToString("N2")
            If row("PaymentDate") IsNot DBNull.Value Then dtpPaymentDate.Value = CDate(row("PaymentDate"))
            lblRecordedValue.Text = If(row("CreatedAt") Is DBNull.Value, "", CDate(row("CreatedAt")).ToString("MMMM dd, yyyy"))

            Dim loanID As Integer = CInt(row("LoanID"))
            LoadLoanSummary(loanID)

            Dim status As String = row("Status").ToString()
            lblStatusValue.Text = status
            Select Case status
                Case "Paid"
                    lblStatusValue.ForeColor = Color.FromArgb(39, 174, 96)
                Case "Pending"
                    lblStatusValue.ForeColor = Color.FromArgb(211, 84, 0)
                Case "Overdue"
                    lblStatusValue.ForeColor = Color.FromArgb(192, 57, 43)
                Case Else
                    lblStatusValue.ForeColor = Color.FromArgb(21, 67, 106)
            End Select
        Catch ex As Exception
            MessageBox.Show($"Failed to load payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadLoanSummary(loanID As Integer)
        Try
            Dim summaryDt As DataTable = PaymentRepository.GetLoanPaymentSummary(loanID)
            If summaryDt.Rows.Count > 0 Then
                Dim sRow As DataRow = summaryDt.Rows(0)
                Dim totalLoan As Decimal = If(sRow("TotalPayable") IsNot DBNull.Value, CDec(sRow("TotalPayable")), 0D)
                Dim monthlyAmort As Decimal = If(sRow("MonthlyAmortization") IsNot DBNull.Value, CDec(sRow("MonthlyAmortization")), 0D)
                Dim totalPaid As Decimal = If(sRow("TotalPaid") IsNot DBNull.Value, CDec(sRow("TotalPaid")), 0D)
                Dim remBal As Decimal = If(sRow("RemainingBalance") IsNot DBNull.Value, CDec(sRow("RemainingBalance")), 0D)
                Dim term As Integer = If(sRow("Term") IsNot DBNull.Value, CInt(sRow("Term")), 0)

                Dim monthsPaid As Integer = If(monthlyAmort > 0, Math.Min(term, CInt(Math.Floor(totalPaid / monthlyAmort))), 0)
                Dim remainingMonths As Integer = Math.Max(0, term - monthsPaid)

                lblValTotalLoan.Text = $"PHP {totalLoan:N2}"
                lblValMonthlyAmort.Text = $"PHP {monthlyAmort:N2}"
                lblValTotalPaid.Text = $"PHP {totalPaid:N2}"
                lblValRemainingBal.Text = $"PHP {remBal:N2}"
                lblValMonthsLeft.Text = $"{remainingMonths} of {term} Mos"

                If remBal <= 0 Then
                    lblValRemainingBal.ForeColor = Color.FromArgb(40, 167, 69)
                Else
                    lblValRemainingBal.ForeColor = Color.FromArgb(220, 53, 69)
                End If
            End If
        Catch ex As Exception
            ' Keep UI resilient
        End Try
    End Sub

    Private Sub ViewPaymentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    Private Sub btnBack_MouseEnter(sender As Object, e As EventArgs) Handles btnBack.MouseEnter
        btnBack.BackColor = Color.FromArgb(30, 95, 150)
    End Sub
    Private Sub btnBack_MouseLeave(sender As Object, e As EventArgs) Handles btnBack.MouseLeave
        btnBack.BackColor = Color.FromArgb(21, 67, 106)
    End Sub

End Class
