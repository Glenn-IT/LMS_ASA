Public Class NewPaymentForm
    Inherits Form

    ' ── Controls ──────────────────────────────────────────────────
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlDividerTop As Panel
    Private pnlBody As Panel
    
    Private grpPaymentInfo As GroupBox
    Private lblLoanRef As Label
    Friend WithEvents cmbLoanRef As ComboBox
    Private lblPayee As Label
    Friend WithEvents txtPayee As TextBox
    Private lblStatus As Label
    Friend WithEvents cmbStatus As ComboBox

    ' ── Loan Summary & Amortization Box ───────────────────────────
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

    ' ── Amounts Box ───────────────────────────────────────────────
    Private grpAmounts As GroupBox
    Private lblAmount As Label
    Friend WithEvents txtAmount As TextBox
    Private lblPenalty As Label
    Friend WithEvents txtPenalty As TextBox
    Private lblCalcPreview As Label

    ' ── Schedule Box ──────────────────────────────────────────────
    Private grpSchedule As GroupBox
    Private lblPaymentDate As Label
    Friend WithEvents dtpPaymentDate As DateTimePicker

    ' ── Footer Controls ───────────────────────────────────────────
    Private pnlFooter As Panel
    Private pnlDividerBottom As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button

    Public Property PaymentID As Integer = 0
    Private _loans As DataTable

    ' ── Real-time balance calculations state ──────────────────────
    Private _currentLoanPayable As Decimal = 0D
    Private _currentMonthlyAmort As Decimal = 0D
    Private _currentTotalPaid As Decimal = 0D
    Private _currentRemainingBal As Decimal = 0D
    Private _currentTerm As Integer = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlDividerTop = New Panel()
        pnlBody = New Panel()

        grpPaymentInfo = New GroupBox()
        lblLoanRef = New Label()
        cmbLoanRef = New ComboBox()
        lblPayee = New Label()
        txtPayee = New TextBox()
        lblStatus = New Label()
        cmbStatus = New ComboBox()

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
        lblCalcPreview = New Label()

        grpSchedule = New GroupBox()
        lblPaymentDate = New Label()
        dtpPaymentDate = New DateTimePicker()

        pnlFooter = New Panel()
        pnlDividerBottom = New Panel()
        btnSave = New Button()
        btnCancel = New Button()

        SuspendLayout()

        ' ── pnlHeader ──────────────────────────────────────────────
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        ' ── lblTitle ───────────────────────────────────────────────
        lblTitle.Text = "New Payment"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        ' ── lblSubtitle ────────────────────────────────────────────
        lblSubtitle.Text = "Fill in the form below to record a new payment"
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
        pnlBody.Controls.Add(grpSchedule)
        pnlBody.Controls.Add(grpAmounts)
        pnlBody.Controls.Add(grpLoanSummary)
        pnlBody.Controls.Add(grpPaymentInfo)

        ' ── grpPaymentInfo — Loan Reference, Payee, Status ────────
        grpPaymentInfo.Text = "Payment Information"
        grpPaymentInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpPaymentInfo.ForeColor = Color.FromArgb(21, 67, 106)
        grpPaymentInfo.BackColor = Color.White
        grpPaymentInfo.Size = New Size(830, 95)
        grpPaymentInfo.Location = New Point(16, 16)
        grpPaymentInfo.Controls.Add(cmbStatus)
        grpPaymentInfo.Controls.Add(lblStatus)
        grpPaymentInfo.Controls.Add(txtPayee)
        grpPaymentInfo.Controls.Add(lblPayee)
        grpPaymentInfo.Controls.Add(cmbLoanRef)
        grpPaymentInfo.Controls.Add(lblLoanRef)

        ' Loan Reference
        lblLoanRef.Text = "LOAN REFERENCE"
        lblLoanRef.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblLoanRef.ForeColor = Color.FromArgb(100, 100, 100)
        lblLoanRef.AutoSize = False
        lblLoanRef.Size = New Size(260, 18)
        lblLoanRef.Location = New Point(16, 25)

        cmbLoanRef.Font = New Font("Segoe UI", 10)
        cmbLoanRef.Size = New Size(260, 28)
        cmbLoanRef.Location = New Point(16, 45)
        cmbLoanRef.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLoanRef.BackColor = Color.FromArgb(245, 248, 252)
        cmbLoanRef.FlatStyle = FlatStyle.Flat

        ' Payee
        lblPayee.Text = "PAYEE (BORROWER NAME)"
        lblPayee.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblPayee.ForeColor = Color.FromArgb(100, 100, 100)
        lblPayee.AutoSize = False
        lblPayee.Size = New Size(260, 18)
        lblPayee.Location = New Point(296, 25)

        txtPayee.Font = New Font("Segoe UI", 10)
        txtPayee.Size = New Size(260, 28)
        txtPayee.Location = New Point(296, 45)
        txtPayee.BorderStyle = BorderStyle.FixedSingle
        txtPayee.BackColor = Color.FromArgb(245, 248, 252)

        ' Status
        lblStatus.Text = "STATUS"
        lblStatus.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblStatus.ForeColor = Color.FromArgb(100, 100, 100)
        lblStatus.AutoSize = False
        lblStatus.Size = New Size(240, 18)
        lblStatus.Location = New Point(574, 25)

        cmbStatus.Font = New Font("Segoe UI", 10)
        cmbStatus.Size = New Size(240, 28)
        cmbStatus.Location = New Point(574, 45)
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.BackColor = Color.FromArgb(245, 248, 252)
        cmbStatus.FlatStyle = FlatStyle.Flat
        cmbStatus.Items.AddRange(New Object() {"Paid", "Pending", "Overdue"})

        ' ── grpLoanSummary — Loan & Amortization Summary Cards ──────
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
        lblLblTotalPaid.Text = "TOTAL PAID"
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

        ' ── grpAmounts — Amount, Penalty, Preview Calculation ────
        grpAmounts.Text = "Amounts"
        grpAmounts.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpAmounts.ForeColor = Color.FromArgb(21, 67, 106)
        grpAmounts.BackColor = Color.White
        grpAmounts.Size = New Size(830, 125)
        grpAmounts.Location = New Point(16, 245)
        grpAmounts.Controls.Add(lblCalcPreview)
        grpAmounts.Controls.Add(txtPenalty)
        grpAmounts.Controls.Add(lblPenalty)
        grpAmounts.Controls.Add(txtAmount)
        grpAmounts.Controls.Add(lblAmount)

        ' Amount (PHP)
        lblAmount.Text = "AMOUNT TO PAY (PHP)"
        lblAmount.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblAmount.ForeColor = Color.FromArgb(100, 100, 100)
        lblAmount.AutoSize = False
        lblAmount.Size = New Size(390, 18)
        lblAmount.Location = New Point(16, 25)

        txtAmount.Font = New Font("Segoe UI", 10)
        txtAmount.Size = New Size(390, 28)
        txtAmount.Location = New Point(16, 45)
        txtAmount.BorderStyle = BorderStyle.FixedSingle
        txtAmount.BackColor = Color.FromArgb(245, 248, 252)

        ' Penalty (PHP)
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
        txtPenalty.BackColor = Color.FromArgb(245, 248, 252)

        ' Real-time Calculation Preview Note
        lblCalcPreview.Text = "💡 Enter payment amount to preview updated balance."
        lblCalcPreview.Font = New Font("Segoe UI", 8.5F, FontStyle.Italic)
        lblCalcPreview.ForeColor = Color.Gray
        lblCalcPreview.Location = New Point(16, 82)
        lblCalcPreview.Size = New Size(798, 28)

        ' ── grpSchedule — Payment Date ─────────────────────────────
        grpSchedule.Text = "Schedule"
        grpSchedule.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpSchedule.ForeColor = Color.FromArgb(21, 67, 106)
        grpSchedule.BackColor = Color.White
        grpSchedule.Size = New Size(830, 85)
        grpSchedule.Location = New Point(16, 380)
        grpSchedule.Controls.Add(dtpPaymentDate)
        grpSchedule.Controls.Add(lblPaymentDate)

        ' Payment Date
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

        ' ── pnlFooter ──────────────────────────────────────────────
        pnlFooter.BackColor = Color.White
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 60
        pnlFooter.Controls.Add(btnCancel)
        pnlFooter.Controls.Add(btnSave)
        pnlFooter.Controls.Add(pnlDividerBottom)

        ' pnlDividerBottom
        pnlDividerBottom.BackColor = Color.FromArgb(220, 220, 220)
        pnlDividerBottom.Dock = DockStyle.Top
        pnlDividerBottom.Height = 1

        ' btnSave
        btnSave.Text = "Add Payment"
        btnSave.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnSave.BackColor = Color.FromArgb(21, 67, 106)
        btnSave.ForeColor = Color.White
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.Size = New Size(130, 38)
        btnSave.Location = New Point(16, 12)
        btnSave.Cursor = Cursors.Hand

        ' btnCancel
        btnCancel.Text = "Cancel"
        btnCancel.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnCancel.BackColor = Color.FromArgb(240, 240, 240)
        btnCancel.ForeColor = Color.FromArgb(60, 60, 60)
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 1
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
        btnCancel.Size = New Size(130, 38)
        btnCancel.Location = New Point(160, 12)
        btnCancel.Cursor = Cursors.Hand

        ' ── Form Setup ─────────────────────────────────────────────
        Me.Text = "LMS - New Payment"
        Me.AcceptButton = btnSave
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

    ' ── Form Load ──────────────────────────────────────────────────
    Private Sub NewPaymentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLoansIntoCombo()
        cmbStatus.SelectedIndex = 0
        dtpPaymentDate.Value = DateTime.Today

        If PaymentID = 0 Then
            lblTitle.Text = "New Payment"
            lblSubtitle.Text = "Fill in the form below to record a new payment"
            btnSave.Text = "Add Payment"
            Me.Text = "LMS - New Payment"
        Else
            lblTitle.Text = "Edit Payment"
            lblSubtitle.Text = "Update the payment record below"
            btnSave.Text = "Save Changes"
            Me.Text = "LMS - Edit Payment"
            LoadPaymentForEdit()
        End If
    End Sub

    Private Sub LoadLoansIntoCombo()
        Try
            _loans = LoanRepository.GetAll()
            cmbLoanRef.Items.Clear()
            For Each row As DataRow In _loans.Rows
                cmbLoanRef.Items.Add($"{row("LoanReferenceID")} — {row("BorrowerName")}")
            Next
            If cmbLoanRef.Items.Count > 0 Then
                cmbLoanRef.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to load loans: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbLoanRef_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLoanRef.SelectedIndexChanged
        If _loans Is Nothing OrElse cmbLoanRef.SelectedIndex < 0 Then Return
        Dim loanRow As DataRow = _loans.Rows(cmbLoanRef.SelectedIndex)
        Dim loanID As Integer = CInt(loanRow("LoanID"))

        Try
            Dim summaryDt As DataTable = PaymentRepository.GetLoanPaymentSummary(loanID)
            If summaryDt.Rows.Count > 0 Then
                Dim sRow As DataRow = summaryDt.Rows(0)

                ' Auto-fill Payee with BorrowerName if adding new payment
                If PaymentID = 0 Then
                    txtPayee.Text = sRow("BorrowerName").ToString()
                End If

                _currentLoanPayable = If(sRow("TotalPayable") IsNot DBNull.Value, CDec(sRow("TotalPayable")), 0D)
                _currentMonthlyAmort = If(sRow("MonthlyAmortization") IsNot DBNull.Value, CDec(sRow("MonthlyAmortization")), 0D)
                _currentTotalPaid = If(sRow("TotalPaid") IsNot DBNull.Value, CDec(sRow("TotalPaid")), 0D)
                _currentRemainingBal = If(sRow("RemainingBalance") IsNot DBNull.Value, CDec(sRow("RemainingBalance")), 0D)
                _currentTerm = If(sRow("Term") IsNot DBNull.Value, CInt(sRow("Term")), 0)

                Dim monthsPaid As Integer = If(_currentMonthlyAmort > 0, Math.Min(_currentTerm, CInt(Math.Floor(_currentTotalPaid / _currentMonthlyAmort))), 0)
                Dim remainingMonths As Integer = Math.Max(0, _currentTerm - monthsPaid)

                lblValTotalLoan.Text = $"PHP {_currentLoanPayable:N2}"
                lblValMonthlyAmort.Text = $"PHP {_currentMonthlyAmort:N2}"
                lblValTotalPaid.Text = $"PHP {_currentTotalPaid:N2}"
                lblValRemainingBal.Text = $"PHP {_currentRemainingBal:N2}"
                lblValMonthsLeft.Text = $"{remainingMonths} of {_currentTerm} Mos"

                If _currentRemainingBal <= 0 Then
                    lblValRemainingBal.ForeColor = Color.FromArgb(40, 167, 69)
                Else
                    lblValRemainingBal.ForeColor = Color.FromArgb(220, 53, 69)
                End If

                ' Auto fill amount box if adding new payment
                If PaymentID = 0 Then
                    Dim suggestedAmount As Decimal = If(_currentRemainingBal < _currentMonthlyAmort AndAlso _currentRemainingBal > 0, _currentRemainingBal, _currentMonthlyAmort)
                    If suggestedAmount > 0 Then
                        txtAmount.Text = suggestedAmount.ToString("0.00")
                    End If
                End If

                UpdateCalcPreview()
            End If
        Catch ex As Exception
            ' Keep UI safe
        End Try
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        UpdateCalcPreview()
    End Sub

    Private Sub UpdateCalcPreview()
        If lblCalcPreview Is Nothing Then Return
        Dim payAmt As Decimal = 0D
        If Decimal.TryParse(txtAmount.Text.Trim(), payAmt) AndAlso payAmt > 0 Then
            Dim newBal As Decimal = _currentRemainingBal - payAmt
            If newBal < 0 Then
                lblCalcPreview.Text = $"💡 Note: Payment exceeds remaining balance by PHP {Math.Abs(newBal):N2}."
                lblCalcPreview.ForeColor = Color.DarkOrange
            ElseIf newBal = 0 Then
                lblCalcPreview.Text = "🎉 Note: This payment will fully pay off the loan balance!"
                lblCalcPreview.ForeColor = Color.FromArgb(40, 167, 69)
            Else
                Dim newMosLeft As Integer = If(_currentMonthlyAmort > 0, CInt(Math.Ceiling(newBal / _currentMonthlyAmort)), 0)
                lblCalcPreview.Text = $"💡 New Balance after payment: PHP {newBal:N2} (~{newMosLeft} month(s) remaining)"
                lblCalcPreview.ForeColor = Color.FromArgb(21, 67, 106)
            End If
        Else
            lblCalcPreview.Text = $"💡 Enter payment amount. Current Balance: PHP {_currentRemainingBal:N2}"
            lblCalcPreview.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub LoadPaymentForEdit()
        Try
            Dim dt As DataTable = PaymentRepository.GetByID(PaymentID)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Payment record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If
            Dim row As DataRow = dt.Rows(0)

            Dim loanID As Integer = CInt(row("LoanID"))
            For i As Integer = 0 To _loans.Rows.Count - 1
                If CInt(_loans.Rows(i)("LoanID")) = loanID Then
                    cmbLoanRef.SelectedIndex = i
                    Exit For
                End If
            Next

            txtPayee.Text = row("Payee").ToString()
            txtAmount.Text = row("Amount").ToString()
            txtPenalty.Text = row("Penalty").ToString()
            If row("PaymentDate") IsNot DBNull.Value Then dtpPaymentDate.Value = CDate(row("PaymentDate"))

            Dim statusVal As String = row("Status").ToString()
            Dim statusIdx As Integer = cmbStatus.Items.IndexOf(statusVal)
            If statusIdx >= 0 Then cmbStatus.SelectedIndex = statusIdx
        Catch ex As Exception
            MessageBox.Show($"Failed to load payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Save Button ────────────────────────────────────────────────
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateFields() Then Return
        Try
            If PaymentID = 0 Then
                InsertNewPayment()
            Else
                UpdateExistingPayment()
            End If
        Catch ex As Exception
            MessageBox.Show($"Save failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateFields() As Boolean
        If cmbLoanRef.SelectedIndex < 0 Then
            MessageBox.Show("Please select a loan.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbLoanRef.Focus() : Return False
        End If
        If txtPayee.Text.Trim() = "" Then
            MessageBox.Show("Payee is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPayee.Focus() : Return False
        End If
        Dim amount As Decimal
        If Not Decimal.TryParse(txtAmount.Text.Trim(), amount) OrElse amount <= 0 Then
            MessageBox.Show("Amount must be a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmount.Focus() : Return False
        End If
        Dim penalty As Decimal
        If txtPenalty.Text.Trim() <> "" AndAlso (Not Decimal.TryParse(txtPenalty.Text.Trim(), penalty) OrElse penalty < 0) Then
            MessageBox.Show("Penalty must be a valid non-negative number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPenalty.Focus() : Return False
        End If
        Return True
    End Function

    Private Sub InsertNewPayment()
        Dim loanRow As DataRow = _loans.Rows(cmbLoanRef.SelectedIndex)
        Dim loanID As Integer = CInt(loanRow("LoanID"))
        Dim loanRef As String = loanRow("LoanReferenceID").ToString()
        Dim payee As String = txtPayee.Text.Trim()
        Dim amount As Decimal = Decimal.Parse(txtAmount.Text.Trim())
        Dim penalty As Decimal = If(txtPenalty.Text.Trim() = "", 0D, Decimal.Parse(txtPenalty.Text.Trim()))
        Dim status As String = cmbStatus.SelectedItem.ToString()

        PaymentRepository.Insert(loanID, payee, amount, penalty, dtpPaymentDate.Value, status)
        ActivityLogger.Log(SessionManager.CurrentUsername, "Success",
            $"Added payment for loan {loanRef}: {payee} / PHP {amount:N2}")
        MessageBox.Show("Payment recorded successfully.", "Payment Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub UpdateExistingPayment()
        Dim loanRow As DataRow = _loans.Rows(cmbLoanRef.SelectedIndex)
        Dim loanID As Integer = CInt(loanRow("LoanID"))
        Dim loanRef As String = loanRow("LoanReferenceID").ToString()
        Dim payee As String = txtPayee.Text.Trim()
        Dim amount As Decimal = Decimal.Parse(txtAmount.Text.Trim())
        Dim penalty As Decimal = If(txtPenalty.Text.Trim() = "", 0D, Decimal.Parse(txtPenalty.Text.Trim()))
        Dim status As String = cmbStatus.SelectedItem.ToString()

        PaymentRepository.Update(PaymentID, loanID, payee, amount, penalty, dtpPaymentDate.Value, status)
        ActivityLogger.Log(SessionManager.CurrentUsername, "Success",
            $"Updated payment ID {PaymentID}: {loanRef} / {payee}")
        MessageBox.Show("Payment record updated successfully.", "Payment Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    ' ── Cancel ─────────────────────────────────────────────────────
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ' ── Hover Effects ──────────────────────────────────────────────
    Private Sub btnSave_MouseEnter(sender As Object, e As EventArgs) Handles btnSave.MouseEnter
        btnSave.BackColor = Color.FromArgb(30, 95, 150)
    End Sub
    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        btnSave.BackColor = Color.FromArgb(21, 67, 106)
    End Sub
    Private Sub btnCancel_MouseEnter(sender As Object, e As EventArgs) Handles btnCancel.MouseEnter
        btnCancel.BackColor = Color.FromArgb(220, 220, 220)
    End Sub
    Private Sub btnCancel_MouseLeave(sender As Object, e As EventArgs) Handles btnCancel.MouseLeave
        btnCancel.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

End Class
