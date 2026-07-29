Public Class NewLoanForm
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
    Friend WithEvents cmbBorrowerName As ComboBox
    Private lblLoanType As Label
    Friend WithEvents cmbLoanType As ComboBox
    Private lblStatus As Label
    Friend WithEvents cmbStatus As ComboBox
    Private grpLoanDetails As GroupBox
    Private lblPrincipalAmount As Label
    Friend WithEvents txtPrincipalAmount As TextBox
    Private lblInterestRate As Label
    Friend WithEvents txtInterestRate As TextBox
    Private lblTotalPayable As Label
    Friend WithEvents txtTotalPayable As TextBox
    Private lblTerm As Label
    Friend WithEvents txtTerm As TextBox
    Private grpDates As GroupBox
    Private lblReleaseDate As Label
    Friend WithEvents dtpReleaseDate As DateTimePicker
    Private lblDueDate As Label
    Friend WithEvents dtpDueDate As DateTimePicker
    Private pnlFooter As Panel
    Private pnlDividerBottom As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnCancel As Button

    Public Property LoanID As Integer = 0
    Private _borrowers As DataTable

    Public Sub New()
        InitializeComponent()
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
        cmbBorrowerName = New ComboBox()
        lblLoanType = New Label()
        cmbLoanType = New ComboBox()
        lblStatus = New Label()
        cmbStatus = New ComboBox()
        grpLoanDetails = New GroupBox()
        lblPrincipalAmount = New Label()
        txtPrincipalAmount = New TextBox()
        lblInterestRate = New Label()
        txtInterestRate = New TextBox()
        lblTotalPayable = New Label()
        txtTotalPayable = New TextBox()
        lblTerm = New Label()
        txtTerm = New TextBox()
        grpDates = New GroupBox()
        lblReleaseDate = New Label()
        dtpReleaseDate = New DateTimePicker()
        lblDueDate = New Label()
        dtpDueDate = New DateTimePicker()
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
        lblTitle.Text = "New Loan"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        ' ?? lblSubtitle ???????????????????????????????????????????
        lblSubtitle.Text = "Fill in the form below to create a new loan record"
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
        pnlBody.Controls.Add(grpDates)
        pnlBody.Controls.Add(grpLoanDetails)
        pnlBody.Controls.Add(grpLoanInfo)

        ' ??????????????????????????????????????????????????????????
        ' grpLoanInfo � Loan ID, Borrower Name, Loan Type
        ' ??????????????????????????????????????????????????????????
        grpLoanInfo.Text = "Loan Information"
        grpLoanInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpLoanInfo.ForeColor = Color.FromArgb(21, 67, 106)
        grpLoanInfo.BackColor = Color.White
        grpLoanInfo.Size = New Size(830, 156)
        grpLoanInfo.Location = New Point(16, 16)
        grpLoanInfo.Controls.Add(cmbStatus)
        grpLoanInfo.Controls.Add(lblStatus)
        grpLoanInfo.Controls.Add(cmbLoanType)
        grpLoanInfo.Controls.Add(lblLoanType)
        grpLoanInfo.Controls.Add(cmbBorrowerName)
        grpLoanInfo.Controls.Add(lblBorrowerName)
        grpLoanInfo.Controls.Add(txtLoanID)
        grpLoanInfo.Controls.Add(lblLoanID)

        ' ?? Loan ID ???????????????????????????????????????????????
        lblLoanID.Text = "LOAN ID"
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
        txtLoanID.Text = ""

        ' ?? Borrower Name ?????????????????????????????????????????
        lblBorrowerName.Text = "BORROWER NAME"
        lblBorrowerName.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblBorrowerName.ForeColor = Color.FromArgb(100, 100, 100)
        lblBorrowerName.AutoSize = False
        lblBorrowerName.Size = New Size(270, 18)
        lblBorrowerName.Location = New Point(280, 28)

        cmbBorrowerName.Font = New Font("Segoe UI", 10)
        cmbBorrowerName.Size = New Size(270, 28)
        cmbBorrowerName.Location = New Point(280, 48)
        cmbBorrowerName.DropDownStyle = ComboBoxStyle.DropDownList
        cmbBorrowerName.BackColor = Color.FromArgb(245, 248, 252)
        cmbBorrowerName.FlatStyle = FlatStyle.Flat
        ' Borrower list populated from DB in Form Load

        ' ?? Loan Type ?????????????????????????????????????????????
        lblLoanType.Text = "LOAN TYPE"
        lblLoanType.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblLoanType.ForeColor = Color.FromArgb(100, 100, 100)
        lblLoanType.AutoSize = False
        lblLoanType.Size = New Size(270, 18)
        lblLoanType.Location = New Point(574, 28)

        cmbLoanType.Font = New Font("Segoe UI", 10)
        cmbLoanType.Size = New Size(240, 28)
        cmbLoanType.Location = New Point(574, 48)
        cmbLoanType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLoanType.BackColor = Color.FromArgb(245, 248, 252)
        cmbLoanType.FlatStyle = FlatStyle.Flat
        cmbLoanType.Items.AddRange(New Object() {
            "Personal Loan",
            "Business Loan",
            "Salary Loan",
            "Emergency Loan",
            "Agricultural Loan"
        })

        ' ?? Status ????????????????????????????????????????????????
        lblStatus.Text = "STATUS"
        lblStatus.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblStatus.ForeColor = Color.FromArgb(100, 100, 100)
        lblStatus.AutoSize = False
        lblStatus.Size = New Size(240, 18)
        lblStatus.Location = New Point(16, 88)

        cmbStatus.Font = New Font("Segoe UI", 10)
        cmbStatus.Size = New Size(240, 28)
        cmbStatus.Location = New Point(16, 108)
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.BackColor = Color.FromArgb(245, 248, 252)
        cmbStatus.FlatStyle = FlatStyle.Flat
        cmbStatus.Items.AddRange(New Object() {
            "Pending",
            "Approved",
            "Active",
            "Overdue",
            "Rejected",
            "Closed"
        })

        ' ??????????????????????????????????????????????????????????
        ' grpLoanDetails � Amounts, Rate, Term
        ' ??????????????????????????????????????????????????????????
        grpLoanDetails.Text = "Loan Details"
        grpLoanDetails.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpLoanDetails.ForeColor = Color.FromArgb(21, 67, 106)
        grpLoanDetails.BackColor = Color.White
        grpLoanDetails.Size = New Size(830, 140)
        grpLoanDetails.Location = New Point(16, 188)
        grpLoanDetails.Controls.Add(txtTerm)
        grpLoanDetails.Controls.Add(lblTerm)
        grpLoanDetails.Controls.Add(txtTotalPayable)
        grpLoanDetails.Controls.Add(lblTotalPayable)
        grpLoanDetails.Controls.Add(txtInterestRate)
        grpLoanDetails.Controls.Add(lblInterestRate)
        grpLoanDetails.Controls.Add(txtPrincipalAmount)
        grpLoanDetails.Controls.Add(lblPrincipalAmount)

        ' ?? Principal Amount ??????????????????????????????????????
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
        txtPrincipalAmount.BackColor = Color.FromArgb(245, 248, 252)

        ' ?? Interest Rate ?????????????????????????????????????????
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
        txtInterestRate.BackColor = Color.FromArgb(245, 248, 252)

        ' ?? Total Payable Amount ??????????????????????????????????
        lblTotalPayable.Text = "TOTAL PAYABLE AMOUNT (PHP)"
        lblTotalPayable.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblTotalPayable.ForeColor = Color.FromArgb(100, 100, 100)
        lblTotalPayable.AutoSize = False
        lblTotalPayable.Size = New Size(200, 18)
        lblTotalPayable.Location = New Point(432, 28)

        txtTotalPayable.Font = New Font("Segoe UI", 10)
        txtTotalPayable.Size = New Size(200, 28)
        txtTotalPayable.Location = New Point(432, 48)
        txtTotalPayable.BorderStyle = BorderStyle.FixedSingle
        txtTotalPayable.BackColor = Color.FromArgb(235, 240, 245)
        txtTotalPayable.ReadOnly = True

        ' ?? Term / Duration ???????????????????????????????????????
        lblTerm.Text = "TERM / DURATION (Months)"
        lblTerm.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        lblTerm.ForeColor = Color.FromArgb(100, 100, 100)
        lblTerm.AutoSize = False
        lblTerm.Size = New Size(190, 18)
        lblTerm.Location = New Point(650, 28)

        txtTerm.Font = New Font("Segoe UI", 10)
        txtTerm.Size = New Size(164, 28)
        txtTerm.Location = New Point(650, 48)
        txtTerm.BorderStyle = BorderStyle.FixedSingle
        txtTerm.BackColor = Color.FromArgb(245, 248, 252)

        ' ??????????????????????????????????????????????????????????
        ' grpDates � Release Date, Due Date
        ' ??????????????????????????????????????????????????????????
        grpDates.Text = "Schedule"
        grpDates.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        grpDates.ForeColor = Color.FromArgb(21, 67, 106)
        grpDates.BackColor = Color.White
        grpDates.Size = New Size(830, 100)
        grpDates.Location = New Point(16, 344)
        grpDates.Controls.Add(dtpDueDate)
        grpDates.Controls.Add(lblDueDate)
        grpDates.Controls.Add(dtpReleaseDate)
        grpDates.Controls.Add(lblReleaseDate)

        ' ?? Release Date ??????????????????????????????????????????
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

        ' ?? Due Date ??????????????????????????????????????????????
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
        btnAdd.Text = "Add Loan"
        btnAdd.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnAdd.BackColor = Color.FromArgb(21, 67, 106)
        btnAdd.ForeColor = Color.White
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.Size = New Size(130, 38)
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
        btnCancel.Location = New Point(160, 12)
        btnCancel.Cursor = Cursors.Hand

        ' ?? Form ??????????????????????????????????????????????????
        Me.Text = "LMS - New Loan"
        Me.AcceptButton = btnAdd
        Me.ClientSize = New Size(880, 576)
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
    Private Sub NewLoanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBorrowersIntoCombo()
        cmbLoanType.SelectedIndex = 0
        dtpReleaseDate.Value = DateTime.Today
        dtpDueDate.Value = DateTime.Today.AddMonths(12)

        If LoanID = 0 Then
            Try
                txtLoanID.Text = LoanRepository.GetNextReferenceID()
            Catch ex As Exception
                txtLoanID.Text = "LN-0001"
            End Try
            cmbStatus.SelectedIndex = 0 ' Pending
            cmbStatus.Enabled = False
            lblTitle.Text = "New Loan"
            lblSubtitle.Text = "Fill in the form below to create a new loan record"
            btnAdd.Text = "Add Loan"
            Me.Text = "LMS - New Loan"
        Else
            lblTitle.Text = "Edit Loan"
            lblSubtitle.Text = "Update the loan record below"
            btnAdd.Text = "Save Changes"
            Me.Text = "LMS - Edit Loan"
            LoadLoanForEdit()
        End If
    End Sub

    Private Sub LoadBorrowersIntoCombo()
        Try
            _borrowers = BorrowerRepository.GetAll()
            cmbBorrowerName.Items.Clear()
            For Each row As DataRow In _borrowers.Rows
                Dim mid As String = If(row("MiddleName") Is DBNull.Value OrElse row("MiddleName").ToString() = "",
                                       "", " " & row("MiddleName").ToString())
                cmbBorrowerName.Items.Add($"{row("FirstName")}{mid} {row("LastName")} ({row("BorrowerUID")})")
            Next
            If cmbBorrowerName.Items.Count > 0 Then cmbBorrowerName.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show($"Failed to load borrowers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadLoanForEdit()
        Try
            Dim dt As DataTable = LoanRepository.GetByID(LoanID)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Loan record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If
            Dim row As DataRow = dt.Rows(0)
            txtLoanID.Text = row("LoanReferenceID").ToString()

            ' Select matching borrower in combo
            Dim borrowerID As Integer = CInt(row("BorrowerID"))
            For i As Integer = 0 To _borrowers.Rows.Count - 1
                If CInt(_borrowers.Rows(i)("BorrowerID")) = borrowerID Then
                    cmbBorrowerName.SelectedIndex = i
                    Exit For
                End If
            Next

            ' Select loan type
            Dim loanType As String = row("LoanType").ToString()
            Dim typeIdx As Integer = cmbLoanType.Items.IndexOf(loanType)
            If typeIdx >= 0 Then cmbLoanType.SelectedIndex = typeIdx

            txtPrincipalAmount.Text = row("PrincipalAmount").ToString()
            txtInterestRate.Text = row("InterestRate").ToString()
            txtTotalPayable.Text = row("TotalPayable").ToString()
            txtTerm.Text = row("Term").ToString()
            If row("ReleaseDate") IsNot DBNull.Value Then dtpReleaseDate.Value = CDate(row("ReleaseDate"))
            If row("DueDate") IsNot DBNull.Value Then dtpDueDate.Value = CDate(row("DueDate"))

            Dim statusIdx As Integer = cmbStatus.Items.IndexOf(row("Status").ToString())
            cmbStatus.SelectedIndex = If(statusIdx >= 0, statusIdx, 0)
            cmbStatus.Enabled = True
        Catch ex As Exception
            MessageBox.Show($"Failed to load loan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ?? Auto-calculate TotalPayable ???????????????????????????
    Private Sub txtPrincipalAmount_TextChanged(sender As Object, e As EventArgs) Handles txtPrincipalAmount.TextChanged
        CalculateTotalPayable()
    End Sub

    Private Sub txtInterestRate_TextChanged(sender As Object, e As EventArgs) Handles txtInterestRate.TextChanged
        CalculateTotalPayable()
    End Sub

    Private Sub CalculateTotalPayable()
        Dim principal As Decimal
        Dim rate As Decimal
        If Decimal.TryParse(txtPrincipalAmount.Text.Trim(), principal) AndAlso
           Decimal.TryParse(txtInterestRate.Text.Trim(), rate) Then
            Dim total As Decimal = principal * (1 + rate / 100)
            txtTotalPayable.Text = total.ToString("F2")
        Else
            txtTotalPayable.Text = ""
        End If
    End Sub

    ' ?? Add / Save Button ?????????????????????????????????????????
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateFields() Then Return
        Try
            If LoanID = 0 Then
                InsertNewLoan()
            Else
                UpdateExistingLoan()
            End If
        Catch ex As Exception
            MessageBox.Show($"Save failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateFields() As Boolean
        If cmbBorrowerName.SelectedIndex < 0 Then
            MessageBox.Show("Please select a borrower.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbBorrowerName.Focus() : Return False
        End If
        If cmbLoanType.SelectedIndex < 0 Then
            MessageBox.Show("Please select a loan type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbLoanType.Focus() : Return False
        End If
        If txtPrincipalAmount.Text.Trim() = "" Then
            MessageBox.Show("Principal Amount is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrincipalAmount.Focus() : Return False
        End If
        Dim principal As Decimal
        If Not Decimal.TryParse(txtPrincipalAmount.Text.Trim(), principal) OrElse principal <= 0 Then
            MessageBox.Show("Principal Amount must be a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrincipalAmount.Focus() : Return False
        End If
        Dim rate As Decimal
        If Not Decimal.TryParse(txtInterestRate.Text.Trim(), rate) OrElse rate < 0 Then
            MessageBox.Show("Interest Rate must be a valid non-negative number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInterestRate.Focus() : Return False
        End If
        Dim term As Integer
        If Not Integer.TryParse(txtTerm.Text.Trim(), term) OrElse term <= 0 Then
            MessageBox.Show("Term must be a valid positive number of months.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTerm.Focus() : Return False
        End If
        If dtpDueDate.Value.Date <= dtpReleaseDate.Value.Date Then
            MessageBox.Show("Due Date must be after Release Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub InsertNewLoan()
        Dim borrowerRow As DataRow = _borrowers.Rows(cmbBorrowerName.SelectedIndex)
        Dim borrowerID As Integer = CInt(borrowerRow("BorrowerID"))
        Dim refID As String = txtLoanID.Text.Trim()
        Dim loanType As String = cmbLoanType.SelectedItem.ToString()
        Dim principal As Decimal = Decimal.Parse(txtPrincipalAmount.Text.Trim())
        Dim rate As Decimal = Decimal.Parse(txtInterestRate.Text.Trim())
        Dim total As Decimal = Decimal.Parse(txtTotalPayable.Text.Trim())
        Dim term As Integer = Integer.Parse(txtTerm.Text.Trim())

        LoanRepository.Insert(borrowerID, refID, loanType, principal, rate, total,
                              term, dtpReleaseDate.Value, dtpDueDate.Value, cmbStatus.SelectedItem.ToString())
        ActivityLogger.Log(SessionManager.CurrentUsername, "Success",
            $"Added new loan {refID} for borrower ID {borrowerID}")
        MessageBox.Show($"Loan {refID} added successfully.", "Loan Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub UpdateExistingLoan()
        Dim loanType As String = cmbLoanType.SelectedItem.ToString()
        Dim principal As Decimal = Decimal.Parse(txtPrincipalAmount.Text.Trim())
        Dim rate As Decimal = Decimal.Parse(txtInterestRate.Text.Trim())
        Dim total As Decimal = Decimal.Parse(txtTotalPayable.Text.Trim())
        Dim term As Integer = Integer.Parse(txtTerm.Text.Trim())

        LoanRepository.Update(LoanID, loanType, principal, rate, total,
                              term, dtpReleaseDate.Value, dtpDueDate.Value, cmbStatus.SelectedItem.ToString())
        ActivityLogger.Log(SessionManager.CurrentUsername, "Success",
            $"Updated loan ID {LoanID}: {txtLoanID.Text.Trim()}")
        MessageBox.Show("Loan record updated successfully.", "Loan Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

End Class
