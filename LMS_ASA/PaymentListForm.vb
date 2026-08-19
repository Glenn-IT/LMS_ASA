Public Class PaymentListForm
    Inherits Form

    ' ── Controls ──────────────────────────────────────────────────
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label

    ' ── KPI Summary Cards Bar ─────────────────────────────────────
    Private pnlKpiSummary As Panel
    Private grpKpi1 As Panel
    Private lblKpi1Title As Label
    Private lblKpi1Val As Label

    Private grpKpi2 As Panel
    Private lblKpi2Title As Label
    Private lblKpi2Val As Label

    Private grpKpi3 As Panel
    Private lblKpi3Title As Label
    Private lblKpi3Val As Label

    ' ── Toolbar & Action Buttons ──────────────────────────────────
    Private pnlToolbar As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Private lblSearch As Label
    Private WithEvents txtSearch As TextBox

    ' ── Grid & Footer ─────────────────────────────────────────────
    Private pnlGrid As Panel
    Friend WithEvents dgvPayments As DataGridView
    Private pnlFooter As Panel
    Private lblRecordCount As Label

    Private _fullData As DataTable

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()

        pnlKpiSummary = New Panel()
        grpKpi1 = New Panel()
        lblKpi1Title = New Label()
        lblKpi1Val = New Label()
        grpKpi2 = New Panel()
        lblKpi2Title = New Label()
        lblKpi2Val = New Label()
        grpKpi3 = New Panel()
        lblKpi3Title = New Label()
        lblKpi3Val = New Label()

        pnlToolbar = New Panel()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnView = New Button()
        btnDelete = New Button()
        lblSearch = New Label()
        txtSearch = New TextBox()
        pnlGrid = New Panel()
        dgvPayments = New DataGridView()
        pnlFooter = New Panel()
        lblRecordCount = New Label()

        SuspendLayout()

        ' ── pnlHeader ──────────────────────────────────────────────
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 60
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        ' lblTitle
        lblTitle.Text = "Payment List"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(400, 28)
        lblTitle.Location = New Point(16, 8)

        ' lblSubtitle
        lblSubtitle.Text = "Manage payment records, track balances, and amortization schedules"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(500, 18)
        lblSubtitle.Location = New Point(16, 36)

        ' ── pnlKpiSummary Cards Bar ───────────────────────────────
        pnlKpiSummary.BackColor = Color.FromArgb(245, 247, 250)
        pnlKpiSummary.Dock = DockStyle.Top
        pnlKpiSummary.Height = 68
        pnlKpiSummary.Padding = New Padding(12, 6, 12, 6)

        ' Card 1: Total Collections
        grpKpi1.BackColor = Color.White
        grpKpi1.BorderStyle = BorderStyle.FixedSingle
        grpKpi1.Size = New Size(270, 52)
        grpKpi1.Location = New Point(12, 8)
        lblKpi1Title.Text = "TOTAL COLLECTIONS (PAID)"
        lblKpi1Title.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblKpi1Title.ForeColor = Color.Gray
        lblKpi1Title.Location = New Point(10, 6)
        lblKpi1Title.Size = New Size(250, 16)
        lblKpi1Val.Text = "PHP 0.00"
        lblKpi1Val.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblKpi1Val.ForeColor = Color.FromArgb(40, 167, 69)
        lblKpi1Val.Location = New Point(10, 22)
        lblKpi1Val.Size = New Size(250, 24)
        grpKpi1.Controls.Add(lblKpi1Title)
        grpKpi1.Controls.Add(lblKpi1Val)

        ' Card 2: Total Outstanding Balance
        grpKpi2.BackColor = Color.White
        grpKpi2.BorderStyle = BorderStyle.FixedSingle
        grpKpi2.Size = New Size(270, 52)
        grpKpi2.Location = New Point(292, 8)
        lblKpi2Title.Text = "TOTAL OUTSTANDING BALANCE"
        lblKpi2Title.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblKpi2Title.ForeColor = Color.Gray
        lblKpi2Title.Location = New Point(10, 6)
        lblKpi2Title.Size = New Size(250, 16)
        lblKpi2Val.Text = "PHP 0.00"
        lblKpi2Val.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblKpi2Val.ForeColor = Color.FromArgb(220, 53, 69)
        lblKpi2Val.Location = New Point(10, 22)
        lblKpi2Val.Size = New Size(250, 24)
        grpKpi2.Controls.Add(lblKpi2Title)
        grpKpi2.Controls.Add(lblKpi2Val)

        ' Card 3: Payments Recorded
        grpKpi3.BackColor = Color.White
        grpKpi3.BorderStyle = BorderStyle.FixedSingle
        grpKpi3.Size = New Size(270, 52)
        grpKpi3.Location = New Point(572, 8)
        lblKpi3Title.Text = "TOTAL TRANSACTIONS RECORDED"
        lblKpi3Title.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblKpi3Title.ForeColor = Color.Gray
        lblKpi3Title.Location = New Point(10, 6)
        lblKpi3Title.Size = New Size(250, 16)
        lblKpi3Val.Text = "0 Record(s)"
        lblKpi3Val.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblKpi3Val.ForeColor = Color.FromArgb(21, 67, 106)
        lblKpi3Val.Location = New Point(10, 22)
        lblKpi3Val.Size = New Size(250, 24)
        grpKpi3.Controls.Add(lblKpi3Title)
        grpKpi3.Controls.Add(lblKpi3Val)

        pnlKpiSummary.Controls.Add(grpKpi3)
        pnlKpiSummary.Controls.Add(grpKpi2)
        pnlKpiSummary.Controls.Add(grpKpi1)

        ' ── pnlToolbar ─────────────────────────────────────────────
        pnlToolbar.BackColor = Color.FromArgb(245, 247, 250)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Height = 52
        pnlToolbar.Controls.Add(lblSearch)
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Controls.Add(btnDelete)
        pnlToolbar.Controls.Add(btnView)
        pnlToolbar.Controls.Add(btnUpdate)
        pnlToolbar.Controls.Add(btnAdd)

        ' btnAdd
        btnAdd.Text = "+ Add"
        btnAdd.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnAdd.BackColor = Color.FromArgb(21, 67, 106)
        btnAdd.ForeColor = Color.White
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.Size = New Size(90, 34)
        btnAdd.Location = New Point(12, 8)
        btnAdd.Cursor = Cursors.Hand

        ' btnUpdate
        btnUpdate.Text = "Update"
        btnUpdate.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        btnUpdate.BackColor = Color.FromArgb(52, 120, 180)
        btnUpdate.ForeColor = Color.White
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.FlatAppearance.BorderSize = 0
        btnUpdate.Size = New Size(90, 34)
        btnUpdate.Location = New Point(110, 8)
        btnUpdate.Cursor = Cursors.Hand

        ' btnView
        btnView.Text = "View"
        btnView.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        btnView.BackColor = Color.FromArgb(23, 162, 184)
        btnView.ForeColor = Color.White
        btnView.FlatStyle = FlatStyle.Flat
        btnView.FlatAppearance.BorderSize = 0
        btnView.Size = New Size(90, 34)
        btnView.Location = New Point(208, 8)
        btnView.Cursor = Cursors.Hand

        ' btnDelete
        btnDelete.Text = "Delete"
        btnDelete.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        btnDelete.BackColor = Color.FromArgb(192, 57, 43)
        btnDelete.ForeColor = Color.White
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.FlatAppearance.BorderSize = 0
        btnDelete.Size = New Size(90, 34)
        btnDelete.Location = New Point(306, 8)
        btnDelete.Cursor = Cursors.Hand
        btnDelete.Visible = True

        ' lblSearch
        lblSearch.Text = "Search:"
        lblSearch.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSearch.ForeColor = Color.Gray
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(428, 17)

        ' txtSearch
        txtSearch.Font = New Font("Segoe UI", 9)
        txtSearch.Size = New Size(220, 28)
        txtSearch.Location = New Point(478, 12)
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.BackColor = Color.White

        ' ── pnlGrid ────────────────────────────────────────────────
        pnlGrid.BackColor = Color.White
        pnlGrid.Dock = DockStyle.Fill
        pnlGrid.Padding = New Padding(12)
        pnlGrid.Controls.Add(dgvPayments)

        ' dgvPayments
        dgvPayments.Dock = DockStyle.Fill
        dgvPayments.BackgroundColor = Color.White
        dgvPayments.BorderStyle = BorderStyle.None
        dgvPayments.RowHeadersVisible = False
        dgvPayments.AllowUserToAddRows = False
        dgvPayments.AllowUserToDeleteRows = False
        dgvPayments.ReadOnly = True
        dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPayments.MultiSelect = False
        dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPayments.Font = New Font("Segoe UI", 9)
        dgvPayments.ColumnHeadersHeight = 36
        dgvPayments.RowTemplate.Height = 32

        ' Column header style
        dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(21, 67, 106)
        dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvPayments.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvPayments.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPayments.EnableHeadersVisualStyles = False

        ' Alternating row style
        dgvPayments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253)

        ' Selection style
        dgvPayments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 240)
        dgvPayments.DefaultCellStyle.SelectionForeColor = Color.FromArgb(21, 67, 106)

        ' ── pnlFooter ──────────────────────────────────────────────
        pnlFooter.BackColor = Color.FromArgb(245, 247, 250)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 32
        pnlFooter.Controls.Add(lblRecordCount)

        ' lblRecordCount
        lblRecordCount.Text = "Loading..."
        lblRecordCount.Font = New Font("Segoe UI", 8, FontStyle.Regular)
        lblRecordCount.ForeColor = Color.Gray
        lblRecordCount.AutoSize = True
        lblRecordCount.Location = New Point(12, 8)

        ' ── Form Setup ─────────────────────────────────────────────
        Me.Text = "LMS - Payment List"
        Me.ClientSize = New Size(920, 580)
        Me.BackColor = Color.White
        Me.Controls.Add(pnlGrid)
        Me.Controls.Add(pnlFooter)
        Me.Controls.Add(pnlToolbar)
        Me.Controls.Add(pnlKpiSummary)
        Me.Controls.Add(pnlHeader)

        ResumeLayout(False)
    End Sub

    ' ── Form Load ──────────────────────────────────────────────────
    Private Sub PaymentListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPayments()
    End Sub

    ' ── Load Payments from DB ──────────────────────────────────────
    Private Sub LoadPayments()
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim raw As DataTable = PaymentRepository.GetAll()
            _fullData = BuildDisplayTable(raw)
            dgvPayments.DataSource = _fullData

            If dgvPayments.Columns.Contains("PaymentID") Then
                dgvPayments.Columns("PaymentID").Visible = False
            End If

            ConfigureColumns()
            UpdateKpiCards(raw)
            lblRecordCount.Text = $"Showing {_fullData.Rows.Count} record(s)"
        Catch ex As Exception
            MessageBox.Show($"Failed to load payments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub UpdateKpiCards(raw As DataTable)
        If raw Is Nothing Then Return
        Dim totalPaidCollections As Decimal = 0D
        Dim totalRemainingBalance As Decimal = 0D

        ' Track calculated remaining balance per unique loan to avoid double counting
        Dim loanBalances As New Dictionary(Of Integer, Decimal)()

        For Each row As DataRow In raw.Rows
            If row("Status").ToString() = "Paid" Then
                totalPaidCollections += If(row("Amount") IsNot DBNull.Value, CDec(row("Amount")), 0D)
            End If

            If row("LoanID") IsNot DBNull.Value Then
                Dim lId As Integer = CInt(row("LoanID"))
                If Not loanBalances.ContainsKey(lId) Then
                    Dim remBal As Decimal = If(row("RemainingBalance") IsNot DBNull.Value, CDec(row("RemainingBalance")), 0D)
                    loanBalances(lId) = Math.Max(0D, remBal)
                End If
            End If
        Next

        For Each kvp In loanBalances
            totalRemainingBalance += kvp.Value
        Next

        lblKpi1Val.Text = $"PHP {totalPaidCollections:N2}"
        lblKpi2Val.Text = $"PHP {totalRemainingBalance:N2}"
        lblKpi3Val.Text = $"{raw.Rows.Count} Record(s)"
    End Sub

    Private Function BuildDisplayTable(raw As DataTable) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("PaymentID", GetType(Integer))
        dt.Columns.Add("Loan Ref", GetType(String))
        dt.Columns.Add("Borrower", GetType(String))
        dt.Columns.Add("Payee", GetType(String))
        dt.Columns.Add("Amount (PHP)", GetType(Decimal))
        dt.Columns.Add("Penalty (PHP)", GetType(Decimal))
        dt.Columns.Add("Monthly Amort (PHP)", GetType(Decimal))
        dt.Columns.Add("Remaining Bal (PHP)", GetType(Decimal))
        dt.Columns.Add("Months Left", GetType(String))
        dt.Columns.Add("Payment Date", GetType(DateTime))
        dt.Columns.Add("Status", GetType(String))

        For Each row As DataRow In raw.Rows
            Dim totalPayable As Decimal = If(row("TotalPayable") IsNot DBNull.Value, CDec(row("TotalPayable")), 0D)
            Dim term As Integer = If(row("Term") IsNot DBNull.Value, CInt(row("Term")), 1)
            Dim monthlyAmort As Decimal = If(row("MonthlyAmortization") IsNot DBNull.Value, CDec(row("MonthlyAmortization")), 0D)
            Dim remBal As Decimal = If(row("RemainingBalance") IsNot DBNull.Value, CDec(row("RemainingBalance")), 0D)
            remBal = Math.Max(0D, remBal)

            Dim mosLeft As Integer = If(monthlyAmort > 0, CInt(Math.Ceiling(remBal / monthlyAmort)), 0)
            Dim mosLeftStr As String = If(remBal <= 0, "Paid Off", $"{mosLeft} mos")

            dt.Rows.Add(
                row("PaymentID"),
                row("LoanReferenceID").ToString(),
                row("BorrowerName").ToString(),
                row("Payee").ToString(),
                row("Amount"),
                row("Penalty"),
                monthlyAmort,
                remBal,
                mosLeftStr,
                row("PaymentDate"),
                row("Status").ToString())
        Next
        Return dt
    End Function

    Private Sub ConfigureColumns()
        With dgvPayments
            If .Columns.Contains("Loan Ref") Then .Columns("Loan Ref").FillWeight = 11
            If .Columns.Contains("Borrower") Then .Columns("Borrower").FillWeight = 16
            If .Columns.Contains("Payee") Then .Columns("Payee").FillWeight = 14
            If .Columns.Contains("Amount (PHP)") Then
                .Columns("Amount (PHP)").DefaultCellStyle.Format = "N2"
                .Columns("Amount (PHP)").FillWeight = 12
            End If
            If .Columns.Contains("Penalty (PHP)") Then
                .Columns("Penalty (PHP)").DefaultCellStyle.Format = "N2"
                .Columns("Penalty (PHP)").FillWeight = 10
            End If
            If .Columns.Contains("Monthly Amort (PHP)") Then
                .Columns("Monthly Amort (PHP)").DefaultCellStyle.Format = "N2"
                .Columns("Monthly Amort (PHP)").FillWeight = 13
            End If
            If .Columns.Contains("Remaining Bal (PHP)") Then
                .Columns("Remaining Bal (PHP)").DefaultCellStyle.Format = "N2"
                .Columns("Remaining Bal (PHP)").FillWeight = 13
            End If
            If .Columns.Contains("Months Left") Then
                .Columns("Months Left").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Months Left").FillWeight = 10
            End If
            If .Columns.Contains("Payment Date") Then
                .Columns("Payment Date").DefaultCellStyle.Format = "MMM dd, yyyy"
                .Columns("Payment Date").FillWeight = 13
            End If
            If .Columns.Contains("Status") Then .Columns("Status").FillWeight = 9
        End With
    End Sub

    ' ── Search ─────────────────────────────────────────────────────
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If _fullData Is Nothing Then Return
        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")
        If keyword = "" Then
            _fullData.DefaultView.RowFilter = ""
        Else
            _fullData.DefaultView.RowFilter =
                $"[Loan Ref] LIKE '%{keyword}%' OR [Borrower] LIKE '%{keyword}%' OR " &
                $"[Payee] LIKE '%{keyword}%' OR [Status] LIKE '%{keyword}%' OR [Months Left] LIKE '%{keyword}%'"
        End If
        lblRecordCount.Text = $"Showing {_fullData.DefaultView.Count} record(s)"
    End Sub

    ' ── Add Button ─────────────────────────────────────────────────
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New NewPaymentForm()
        frm.ShowDialog()
        LoadPayments()
    End Sub

    ' ── Update Button ──────────────────────────────────────────────
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvPayments.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a payment record to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedID As Integer = CInt(dgvPayments.SelectedRows(0).Cells("PaymentID").Value)
        Dim frm As New NewPaymentForm()
        frm.PaymentID = selectedID
        frm.ShowDialog()
        LoadPayments()
    End Sub

    ' ── View Button ───────────────────────────────────────────────
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If dgvPayments.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a payment record to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedID As Integer = CInt(dgvPayments.SelectedRows(0).Cells("PaymentID").Value)
        Dim frm As New ViewPaymentForm(selectedID)
        frm.ShowDialog()
    End Sub

    ' ── Delete Button ──────────────────────────────────────────────
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvPayments.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a payment record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedRef As String = dgvPayments.SelectedRows(0).Cells("Loan Ref").Value?.ToString()
        Dim selectedPayee As String = dgvPayments.SelectedRows(0).Cells("Payee").Value?.ToString()
        Dim confirm As DialogResult = MessageBox.Show(
            $"Delete payment for loan ""{selectedRef}"" by ""{selectedPayee}""? This action cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)
        If confirm = DialogResult.Yes Then
            Try
                Dim selectedID As Integer = CInt(dgvPayments.SelectedRows(0).Cells("PaymentID").Value)
                PaymentRepository.Delete(selectedID)
                ActivityLogger.Log(SessionManager.CurrentUsername, "Success",
                    $"Deleted payment ID {selectedID}: {selectedRef} / {selectedPayee}")
                LoadPayments()
            Catch ex As Exception
                MessageBox.Show($"Delete failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ── Hover Effects ──────────────────────────────────────────────
    Private Sub btnAdd_MouseEnter(sender As Object, e As EventArgs) Handles btnAdd.MouseEnter
        btnAdd.BackColor = Color.FromArgb(30, 95, 150)
    End Sub
    Private Sub btnAdd_MouseLeave(sender As Object, e As EventArgs) Handles btnAdd.MouseLeave
        btnAdd.BackColor = Color.FromArgb(21, 67, 106)
    End Sub
    Private Sub btnUpdate_MouseEnter(sender As Object, e As EventArgs) Handles btnUpdate.MouseEnter
        btnUpdate.BackColor = Color.FromArgb(40, 100, 160)
    End Sub
    Private Sub btnUpdate_MouseLeave(sender As Object, e As EventArgs) Handles btnUpdate.MouseLeave
        btnUpdate.BackColor = Color.FromArgb(52, 120, 180)
    End Sub
    Private Sub btnView_MouseEnter(sender As Object, e As EventArgs) Handles btnView.MouseEnter
        btnView.BackColor = Color.FromArgb(19, 132, 150)
    End Sub
    Private Sub btnView_MouseLeave(sender As Object, e As EventArgs) Handles btnView.MouseLeave
        btnView.BackColor = Color.FromArgb(23, 162, 184)
    End Sub
    Private Sub btnDelete_MouseEnter(sender As Object, e As EventArgs) Handles btnDelete.MouseEnter
        btnDelete.BackColor = Color.FromArgb(160, 40, 30)
    End Sub
    Private Sub btnDelete_MouseLeave(sender As Object, e As EventArgs) Handles btnDelete.MouseLeave
        btnDelete.BackColor = Color.FromArgb(192, 57, 43)
    End Sub

    ' ── Status Color Coding ────────────────────────────────────────
    Private Sub dgvPayments_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvPayments.CellFormatting
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return
        If dgvPayments.Columns(e.ColumnIndex).Name = "Status" Then
            Select Case e.Value.ToString()
                Case "Paid"
                    e.CellStyle.BackColor = Color.FromArgb(212, 237, 218)
                    e.CellStyle.ForeColor = Color.FromArgb(21, 87, 36)
                Case "Pending"
                    e.CellStyle.BackColor = Color.FromArgb(255, 243, 205)
                    e.CellStyle.ForeColor = Color.FromArgb(133, 100, 4)
                Case "Overdue"
                    e.CellStyle.BackColor = Color.FromArgb(248, 215, 218)
                    e.CellStyle.ForeColor = Color.FromArgb(114, 28, 36)
            End Select
            e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            e.FormattingApplied = True
        ElseIf dgvPayments.Columns(e.ColumnIndex).Name = "Remaining Bal (PHP)" Then
            Dim val As Decimal = 0D
            If Decimal.TryParse(e.Value.ToString(), val) Then
                If val <= 0 Then
                    e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69)
                    e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                Else
                    e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69)
                End If
            End If
        End If
    End Sub

End Class
