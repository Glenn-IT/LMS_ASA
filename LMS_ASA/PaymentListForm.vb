Public Class PaymentListForm
    Inherits Form

    ' ?? Controls ??????????????????????????????????????????????????
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlToolbar As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Private lblSearch As Label
    Private WithEvents txtSearch As TextBox
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
        pnlToolbar = New Panel()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        lblSearch = New Label()
        txtSearch = New TextBox()
        pnlGrid = New Panel()
        dgvPayments = New DataGridView()
        pnlFooter = New Panel()
        lblRecordCount = New Label()

        SuspendLayout()

        ' ?? pnlHeader ?????????????????????????????????????????????
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        ' ?? lblTitle ??????????????????????????????????????????????
        lblTitle.Text = "Payment List"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(400, 30)
        lblTitle.Location = New Point(16, 10)

        ' ?? lblSubtitle ???????????????????????????????????????????
        lblSubtitle.Text = "Manage all payment records"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(400, 18)
        lblSubtitle.Location = New Point(16, 40)

        ' ?? pnlToolbar ????????????????????????????????????????????
        pnlToolbar.BackColor = Color.FromArgb(245, 247, 250)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Height = 56
        pnlToolbar.Controls.Add(lblSearch)
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Controls.Add(btnDelete)
        pnlToolbar.Controls.Add(btnUpdate)
        pnlToolbar.Controls.Add(btnAdd)

        ' ?? btnAdd ????????????????????????????????????????????????
        btnAdd.Text = "+ Add"
        btnAdd.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnAdd.BackColor = Color.FromArgb(21, 67, 106)
        btnAdd.ForeColor = Color.White
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.Size = New Size(90, 34)
        btnAdd.Location = New Point(12, 11)
        btnAdd.Cursor = Cursors.Hand

        ' ?? btnUpdate ?????????????????????????????????????????????
        btnUpdate.Text = "Update"
        btnUpdate.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        btnUpdate.BackColor = Color.FromArgb(52, 120, 180)
        btnUpdate.ForeColor = Color.White
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.FlatAppearance.BorderSize = 0
        btnUpdate.Size = New Size(90, 34)
        btnUpdate.Location = New Point(110, 11)
        btnUpdate.Cursor = Cursors.Hand

        ' ?? btnDelete ?????????????????????????????????????????????
        btnDelete.Text = "Delete"
        btnDelete.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        btnDelete.BackColor = Color.FromArgb(192, 57, 43)
        btnDelete.ForeColor = Color.White
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.FlatAppearance.BorderSize = 0
        btnDelete.Size = New Size(90, 34)
        btnDelete.Location = New Point(208, 11)
        btnDelete.Cursor = Cursors.Hand
        btnDelete.Visible = True

        ' ?? lblSearch ?????????????????????????????????????????????
        lblSearch.Text = "Search:"
        lblSearch.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSearch.ForeColor = Color.Gray
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(330, 20)

        ' ?? txtSearch ?????????????????????????????????????????????
        txtSearch.Font = New Font("Segoe UI", 9)
        txtSearch.Size = New Size(200, 28)
        txtSearch.Location = New Point(380, 15)
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.BackColor = Color.White

        ' ?? pnlGrid ???????????????????????????????????????????????
        pnlGrid.BackColor = Color.White
        pnlGrid.Dock = DockStyle.Fill
        pnlGrid.Padding = New Padding(12)
        pnlGrid.Controls.Add(dgvPayments)

        ' ?? dgvPayments ???????????????????????????????????????????
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

        ' ?? pnlFooter ?????????????????????????????????????????????
        pnlFooter.BackColor = Color.FromArgb(245, 247, 250)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 32
        pnlFooter.Controls.Add(lblRecordCount)

        ' ?? lblRecordCount ????????????????????????????????????????
        lblRecordCount.Text = "Loading..."
        lblRecordCount.Font = New Font("Segoe UI", 8, FontStyle.Regular)
        lblRecordCount.ForeColor = Color.Gray
        lblRecordCount.AutoSize = True
        lblRecordCount.Location = New Point(12, 8)

        ' ?? Form ??????????????????????????????????????????????????
        Me.Text = "LMS - Payment List"
        Me.ClientSize = New Size(900, 520)
        Me.BackColor = Color.White
        Me.Controls.Add(pnlGrid)
        Me.Controls.Add(pnlFooter)
        Me.Controls.Add(pnlToolbar)
        Me.Controls.Add(pnlHeader)

        ResumeLayout(False)
    End Sub

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub PaymentListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GATE — remove this block when unlocking for v1.06
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE
        LoadPayments()
    End Sub

    ' ?? Load Payments from DB ?????????????????????????????????????
    Private Sub LoadPayments()
        Cursor.Current = Cursors.WaitCursor
        Try
            _fullData = BuildDisplayTable(PaymentRepository.GetAll())
            dgvPayments.DataSource = _fullData
            If dgvPayments.Columns.Contains("PaymentID") Then
                dgvPayments.Columns("PaymentID").Visible = False
            End If
            ConfigureColumns()
            lblRecordCount.Text = $"Showing {_fullData.Rows.Count} record(s)"
        Catch ex As Exception
            MessageBox.Show($"Failed to load payments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function BuildDisplayTable(raw As DataTable) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("PaymentID", GetType(Integer))
        dt.Columns.Add("Loan Ref", GetType(String))
        dt.Columns.Add("Borrower", GetType(String))
        dt.Columns.Add("Payee", GetType(String))
        dt.Columns.Add("Amount (PHP)", GetType(Decimal))
        dt.Columns.Add("Penalty (PHP)", GetType(Decimal))
        dt.Columns.Add("Payment Date", GetType(DateTime))
        dt.Columns.Add("Status", GetType(String))
        For Each row As DataRow In raw.Rows
            dt.Rows.Add(
                row("PaymentID"),
                row("LoanReferenceID").ToString(),
                row("BorrowerName").ToString(),
                row("Payee").ToString(),
                row("Amount"),
                row("Penalty"),
                row("PaymentDate"),
                row("Status").ToString())
        Next
        Return dt
    End Function

    Private Sub ConfigureColumns()
        With dgvPayments
            If .Columns.Contains("Loan Ref") Then .Columns("Loan Ref").FillWeight = 12
            If .Columns.Contains("Borrower") Then .Columns("Borrower").FillWeight = 20
            If .Columns.Contains("Payee") Then .Columns("Payee").FillWeight = 18
            If .Columns.Contains("Amount (PHP)") Then
                .Columns("Amount (PHP)").DefaultCellStyle.Format = "N2"
                .Columns("Amount (PHP)").FillWeight = 14
            End If
            If .Columns.Contains("Penalty (PHP)") Then
                .Columns("Penalty (PHP)").DefaultCellStyle.Format = "N2"
                .Columns("Penalty (PHP)").FillWeight = 13
            End If
            If .Columns.Contains("Payment Date") Then
                .Columns("Payment Date").DefaultCellStyle.Format = "MMM dd, yyyy"
                .Columns("Payment Date").FillWeight = 15
            End If
            If .Columns.Contains("Status") Then .Columns("Status").FillWeight = 8
        End With
    End Sub

    ' ?? Search ????????????????????????????????????????????????
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If _fullData Is Nothing Then Return
        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")
        If keyword = "" Then
            _fullData.DefaultView.RowFilter = ""
        Else
            _fullData.DefaultView.RowFilter =
                $"[Loan Ref] LIKE '%{keyword}%' OR [Borrower] LIKE '%{keyword}%' OR " &
                $"[Payee] LIKE '%{keyword}%' OR [Status] LIKE '%{keyword}%'"
        End If
        lblRecordCount.Text = $"Showing {_fullData.DefaultView.Count} record(s)"
    End Sub

    ' ?? Add Button ????????????????????????????????????????????????
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New NewPaymentForm()
        frm.ShowDialog()
        LoadPayments()
    End Sub

    ' ?? Update Button ?????????????????????????????????????????????
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

    ' ?? Delete Button ?????????????????????????????????????????????
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

    ' ?? Hover Effects ?????????????????????????????????????????????
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
    Private Sub btnDelete_MouseEnter(sender As Object, e As EventArgs) Handles btnDelete.MouseEnter
        btnDelete.BackColor = Color.FromArgb(160, 40, 30)
    End Sub
    Private Sub btnDelete_MouseLeave(sender As Object, e As EventArgs) Handles btnDelete.MouseLeave
        btnDelete.BackColor = Color.FromArgb(192, 57, 43)
    End Sub

    ' ?? Status Color Coding ???????????????????????????????????????????
    Private Sub dgvPayments_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvPayments.CellFormatting
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return
        If dgvPayments.Columns(e.ColumnIndex).Name <> "Status" Then Return
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
    End Sub

End Class
