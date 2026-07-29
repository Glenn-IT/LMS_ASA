Public Class ViewPaymentForm
    Inherits Form

    ' ?? Controls ??????????????????????????????????????????????????
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

        ' ?? pnlHeader ?????????????????????????????????????????????
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

        lblSubtitle.Text = "Read-only view of the payment record"
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
        pnlBody.Controls.Add(grpAmounts)
        pnlBody.Controls.Add(grpPaymentInfo)

        ' ??????????????????????????????????????????????????????????
        ' grpPaymentInfo ? Loan Reference, Borrower Name, Payee
        ' ??????????????????????????????????????????????????????????
        grpPaymentInfo.Text = "Payment Information"
        grpPaymentInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpPaymentInfo.ForeColor = Color.FromArgb(21, 67, 106)
        grpPaymentInfo.BackColor = Color.White
        grpPaymentInfo.Size = New Size(830, 140)
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
        lblLoanRef.Location = New Point(16, 28)

        txtLoanRef.Font = New Font("Segoe UI", 10)
        txtLoanRef.Size = New Size(260, 28)
        txtLoanRef.Location = New Point(16, 48)
        txtLoanRef.BorderStyle = BorderStyle.FixedSingle
        txtLoanRef.BackColor = Color.FromArgb(235, 240, 245)
        txtLoanRef.ReadOnly = True

        ' Borrower Name
        lblBorrowerName.Text = "BORROWER NAME"
        lblBorrowerName.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblBorrowerName.ForeColor = Color.FromArgb(100, 100, 100)
        lblBorrowerName.AutoSize = False
        lblBorrowerName.Size = New Size(260, 18)
        lblBorrowerName.Location = New Point(296, 28)

        txtBorrowerName.Font = New Font("Segoe UI", 10)
        txtBorrowerName.Size = New Size(260, 28)
        txtBorrowerName.Location = New Point(296, 48)
        txtBorrowerName.BorderStyle = BorderStyle.FixedSingle
        txtBorrowerName.BackColor = Color.FromArgb(235, 240, 245)
        txtBorrowerName.ReadOnly = True

        ' Payee
        lblPayee.Text = "PAYEE"
        lblPayee.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblPayee.ForeColor = Color.FromArgb(100, 100, 100)
        lblPayee.AutoSize = False
        lblPayee.Size = New Size(240, 18)
        lblPayee.Location = New Point(574, 28)

        txtPayee.Font = New Font("Segoe UI", 10)
        txtPayee.Size = New Size(240, 28)
        txtPayee.Location = New Point(574, 48)
        txtPayee.BorderStyle = BorderStyle.FixedSingle
        txtPayee.BackColor = Color.FromArgb(235, 240, 245)
        txtPayee.ReadOnly = True

        ' ??????????????????????????????????????????????????????????
        ' grpAmounts ? Amount, Penalty
        ' ??????????????????????????????????????????????????????????
        grpAmounts.Text = "Amounts"
        grpAmounts.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpAmounts.ForeColor = Color.FromArgb(21, 67, 106)
        grpAmounts.BackColor = Color.White
        grpAmounts.Size = New Size(830, 100)
        grpAmounts.Location = New Point(16, 172)
        grpAmounts.Controls.Add(txtPenalty)
        grpAmounts.Controls.Add(lblPenalty)
        grpAmounts.Controls.Add(txtAmount)
        grpAmounts.Controls.Add(lblAmount)

        ' Amount
        lblAmount.Text = "AMOUNT (PHP)"
        lblAmount.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblAmount.ForeColor = Color.FromArgb(100, 100, 100)
        lblAmount.AutoSize = False
        lblAmount.Size = New Size(390, 18)
        lblAmount.Location = New Point(16, 28)

        txtAmount.Font = New Font("Segoe UI", 10)
        txtAmount.Size = New Size(390, 28)
        txtAmount.Location = New Point(16, 48)
        txtAmount.BorderStyle = BorderStyle.FixedSingle
        txtAmount.BackColor = Color.FromArgb(235, 240, 245)
        txtAmount.ReadOnly = True

        ' Penalty
        lblPenalty.Text = "PENALTY (PHP)"
        lblPenalty.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblPenalty.ForeColor = Color.FromArgb(100, 100, 100)
        lblPenalty.AutoSize = False
        lblPenalty.Size = New Size(390, 18)
        lblPenalty.Location = New Point(424, 28)

        txtPenalty.Font = New Font("Segoe UI", 10)
        txtPenalty.Size = New Size(390, 28)
        txtPenalty.Location = New Point(424, 48)
        txtPenalty.BorderStyle = BorderStyle.FixedSingle
        txtPenalty.BackColor = Color.FromArgb(235, 240, 245)
        txtPenalty.ReadOnly = True

        ' ??????????????????????????????????????????????????????????
        ' grpSchedule ? Payment Date
        ' ??????????????????????????????????????????????????????????
        grpSchedule.Text = "Schedule"
        grpSchedule.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpSchedule.ForeColor = Color.FromArgb(21, 67, 106)
        grpSchedule.BackColor = Color.White
        grpSchedule.Size = New Size(830, 100)
        grpSchedule.Location = New Point(16, 288)
        grpSchedule.Controls.Add(dtpPaymentDate)
        grpSchedule.Controls.Add(lblPaymentDate)

        lblPaymentDate.Text = "PAYMENT DATE"
        lblPaymentDate.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblPaymentDate.ForeColor = Color.FromArgb(100, 100, 100)
        lblPaymentDate.AutoSize = False
        lblPaymentDate.Size = New Size(390, 18)
        lblPaymentDate.Location = New Point(16, 28)

        dtpPaymentDate.Font = New Font("Segoe UI", 10)
        dtpPaymentDate.Size = New Size(390, 28)
        dtpPaymentDate.Location = New Point(16, 48)
        dtpPaymentDate.Format = DateTimePickerFormat.Long
        dtpPaymentDate.Enabled = False

        ' ??????????????????????????????????????????????????????????
        ' grpStatusInfo ? Current Status, Recorded On
        ' ??????????????????????????????????????????????????????????
        grpStatusInfo.Text = "Payment Status"
        grpStatusInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpStatusInfo.ForeColor = Color.FromArgb(21, 67, 106)
        grpStatusInfo.BackColor = Color.FromArgb(240, 246, 252)
        grpStatusInfo.Size = New Size(830, 60)
        grpStatusInfo.Location = New Point(16, 404)
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

    ' ?? Load Payment from DB ?????????????????????????????????????????????
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

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub ViewPaymentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
