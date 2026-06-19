Public Class LoanListForm
    Inherits Form

    ' ?? Controls ??????????????????????????????????????????????????
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlToolbar As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Private WithEvents txtSearch As TextBox
    Private lblSearch As Label
    Private pnlGrid As Panel
    Friend WithEvents dgvLoans As DataGridView
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
        txtSearch = New TextBox()
        lblSearch = New Label()
        pnlGrid = New Panel()
        dgvLoans = New DataGridView()
        pnlFooter = New Panel()
        lblRecordCount = New Label()

        SuspendLayout()

        ' ?? pnlHeader ?????????????????????????????????????????????
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 64
        pnlHeader.Padding = New Padding(16, 0, 0, 0)
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)

        ' ?? lblTitle ??????????????????????????????????????????????
        lblTitle.Text = "Loan List"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(400, 30)
        lblTitle.Location = New Point(16, 10)

        ' ?? lblSubtitle ???????????????????????????????????????????
        lblSubtitle.Text = "Manage all loan records"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(400, 18)
        lblSubtitle.Location = New Point(16, 40)

        ' ?? pnlToolbar ????????????????????????????????????????????
        pnlToolbar.BackColor = Color.FromArgb(245, 247, 250)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Height = 56
        pnlToolbar.Padding = New Padding(12, 0, 12, 0)
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
        pnlGrid.Controls.Add(dgvLoans)

        ' ?? dgvLoans ??????????????????????????????????????????????
        dgvLoans.Dock = DockStyle.Fill
        dgvLoans.BackgroundColor = Color.White
        dgvLoans.BorderStyle = BorderStyle.None
        dgvLoans.RowHeadersVisible = False
        dgvLoans.AllowUserToAddRows = False
        dgvLoans.AllowUserToDeleteRows = False
        dgvLoans.ReadOnly = True
        dgvLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLoans.MultiSelect = False
        dgvLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvLoans.Font = New Font("Segoe UI", 9)
        dgvLoans.ColumnHeadersHeight = 36
        dgvLoans.RowTemplate.Height = 32

        ' Column header style
        dgvLoans.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(21, 67, 106)
        dgvLoans.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvLoans.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvLoans.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvLoans.EnableHeadersVisualStyles = False

        ' Alternating row style
        dgvLoans.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253)

        ' Selection style
        dgvLoans.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 240)
        dgvLoans.DefaultCellStyle.SelectionForeColor = Color.FromArgb(21, 67, 106)

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
        Me.Text = "LMS - Loan List"
        Me.ClientSize = New Size(900, 520)
        Me.BackColor = Color.White
        Me.Controls.Add(pnlGrid)
        Me.Controls.Add(pnlFooter)
        Me.Controls.Add(pnlToolbar)
        Me.Controls.Add(pnlHeader)

        ResumeLayout(False)
    End Sub

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub LoanListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLoans()
    End Sub

    ' ?? Load Loans from DB ????????????????????????????????????????
    Private Sub LoadLoans()
        Cursor.Current = Cursors.WaitCursor
        Try
            _fullData = BuildDisplayTable(LoanRepository.GetAll())
            dgvLoans.DataSource = _fullData
            If dgvLoans.Columns.Contains("LoanID") Then
                dgvLoans.Columns("LoanID").Visible = False
            End If
            ConfigureColumns()
            lblRecordCount.Text = $"Showing {_fullData.Rows.Count} record(s)"
        Catch ex As Exception
            MessageBox.Show($"Failed to load loans: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function BuildDisplayTable(raw As DataTable) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("LoanID", GetType(Integer))
        dt.Columns.Add("Reference ID", GetType(String))
        dt.Columns.Add("Borrower", GetType(String))
        dt.Columns.Add("Loan Type", GetType(String))
        dt.Columns.Add("Principal (PHP)", GetType(Decimal))
        dt.Columns.Add("Rate (%)", GetType(Decimal))
        dt.Columns.Add("Total Payable", GetType(Decimal))
        dt.Columns.Add("Term (mos)", GetType(Integer))
        dt.Columns.Add("Status", GetType(String))
        For Each row As DataRow In raw.Rows
            dt.Rows.Add(
                row("LoanID"),
                row("LoanReferenceID"),
                row("BorrowerName").ToString(),
                row("LoanType").ToString(),
                row("PrincipalAmount"),
                row("InterestRate"),
                row("TotalPayable"),
                row("Term"),
                row("Status").ToString())
        Next
        Return dt
    End Function

    Private Sub ConfigureColumns()
        With dgvLoans
            If .Columns.Contains("Reference ID") Then .Columns("Reference ID").FillWeight = 12
            If .Columns.Contains("Borrower") Then .Columns("Borrower").FillWeight = 20
            If .Columns.Contains("Loan Type") Then .Columns("Loan Type").FillWeight = 15
            If .Columns.Contains("Principal (PHP)") Then
                .Columns("Principal (PHP)").DefaultCellStyle.Format = "N2"
                .Columns("Principal (PHP)").FillWeight = 14
            End If
            If .Columns.Contains("Rate (%)") Then
                .Columns("Rate (%)").DefaultCellStyle.Format = "N2"
                .Columns("Rate (%)").FillWeight = 8
            End If
            If .Columns.Contains("Total Payable") Then
                .Columns("Total Payable").DefaultCellStyle.Format = "N2"
                .Columns("Total Payable").FillWeight = 14
            End If
            If .Columns.Contains("Term (mos)") Then .Columns("Term (mos)").FillWeight = 9
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
                $"[Reference ID] LIKE '%{keyword}%' OR [Borrower] LIKE '%{keyword}%' OR " &
                $"[Loan Type] LIKE '%{keyword}%' OR [Status] LIKE '%{keyword}%'"
        End If
        lblRecordCount.Text = $"Showing {_fullData.DefaultView.Count} record(s)"
    End Sub

    ' ?? Add Button ????????????????????????????????????????????????
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New NewLoanForm()
        frm.ShowDialog()
        LoadLoans()
    End Sub

    ' ?? Update Button ?????????????????????????????????????????????
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvLoans.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a loan record to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedID As Integer = CInt(dgvLoans.SelectedRows(0).Cells("LoanID").Value)
        Dim frm As New NewLoanForm()
        frm.LoanID = selectedID
        frm.ShowDialog()
        LoadLoans()
    End Sub

    ' ?? Delete Button ?????????????????????????????????????????????
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvLoans.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a loan record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedRef As String = dgvLoans.SelectedRows(0).Cells("Reference ID").Value?.ToString()
        Dim confirm As DialogResult = MessageBox.Show(
            $"Delete loan ""{selectedRef}""? This action cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)
        If confirm = DialogResult.Yes Then
            Try
                Dim selectedID As Integer = CInt(dgvLoans.SelectedRows(0).Cells("LoanID").Value)
                LoanRepository.Delete(selectedID)
                ActivityLogger.Log(SessionManager.CurrentUsername, "Success", $"Deleted loan ID {selectedID}: {selectedRef}")
                LoadLoans()
            Catch ex As Exception
                MessageBox.Show($"Delete failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ?? Button Hover Effects ??????????????????????????????????????
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
    Private Sub dgvLoans_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvLoans.CellFormatting
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return
        If dgvLoans.Columns(e.ColumnIndex).Name <> "Status" Then Return
        Select Case e.Value.ToString()
            Case "Active", "Approved"
                e.CellStyle.BackColor = Color.FromArgb(212, 237, 218)
                e.CellStyle.ForeColor = Color.FromArgb(21, 87, 36)
            Case "Pending"
                e.CellStyle.BackColor = Color.FromArgb(255, 243, 205)
                e.CellStyle.ForeColor = Color.FromArgb(133, 100, 4)
            Case "Overdue", "Rejected"
                e.CellStyle.BackColor = Color.FromArgb(248, 215, 218)
                e.CellStyle.ForeColor = Color.FromArgb(114, 28, 36)
            Case "Closed"
                e.CellStyle.BackColor = Color.FromArgb(226, 227, 229)
                e.CellStyle.ForeColor = Color.FromArgb(56, 61, 65)
        End Select
        e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        e.FormattingApplied = True
    End Sub

End Class
