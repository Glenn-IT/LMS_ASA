Public Class LoanListForm
    Inherits Form

    ' ?? Controls ??????????????????????????????????????????????????
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlToolbar As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Private WithEvents txtSearch As TextBox
    Private lblSearch As Label
    Private pnlGrid As Panel
    Friend WithEvents dgvLoans As DataGridView
    Private pnlFooter As Panel
    Private lblRecordCount As Label

    Private _fullData As DataTable
    Private WithEvents searchTimer As System.Windows.Forms.Timer

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlHeader = New Panel()
        lblSubtitle = New Label()
        lblTitle = New Label()
        pnlToolbar = New Panel()
        lblSearch = New Label()
        txtSearch = New TextBox()
        btnDelete = New Button()
        btnView = New Button()
        btnUpdate = New Button()
        btnAdd = New Button()
        pnlGrid = New Panel()
        dgvLoans = New DataGridView()
        pnlFooter = New Panel()
        lblRecordCount = New Label()
        searchTimer = New System.Windows.Forms.Timer()
        searchTimer.Interval = 700
        pnlHeader.SuspendLayout()
        pnlToolbar.SuspendLayout()
        pnlGrid.SuspendLayout()
        CType(dgvLoans, ComponentModel.ISupportInitialize).BeginInit()
        pnlFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(16, 0, 0, 0)
        pnlHeader.Size = New Size(900, 64)
        pnlHeader.TabIndex = 3
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Font = New Font("Segoe UI", 9F)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.Location = New Point(16, 40)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(400, 18)
        lblSubtitle.TabIndex = 0
        lblSubtitle.Text = "Manage all loan records"
        ' 
        ' lblTitle
        ' 
        lblTitle.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        lblTitle.Location = New Point(16, 10)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(400, 30)
        lblTitle.TabIndex = 1
        lblTitle.Text = "Loan List"
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlToolbar.Controls.Add(lblSearch)
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Controls.Add(btnDelete)
        pnlToolbar.Controls.Add(btnView)
        pnlToolbar.Controls.Add(btnUpdate)
        pnlToolbar.Controls.Add(btnAdd)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 64)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Padding = New Padding(12, 0, 12, 0)
        pnlToolbar.Size = New Size(900, 56)
        pnlToolbar.TabIndex = 2
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Font = New Font("Segoe UI", 9F)
        lblSearch.ForeColor = Color.Gray
        lblSearch.Location = New Point(428, 20)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(52, 19)
        lblSearch.TabIndex = 0
        lblSearch.Text = "Search:"
        '
        ' txtSearch
        '
        txtSearch.BackColor = Color.White
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Segoe UI", 9F)
        txtSearch.Location = New Point(486, 18)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(200, 25)
        txtSearch.TabIndex = 1
        '
        ' btnDelete
        '
        btnDelete.BackColor = Color.FromArgb(CByte(192), CByte(57), CByte(43))
        btnDelete.Cursor = Cursors.Hand
        btnDelete.FlatAppearance.BorderSize = 0
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI", 9F)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(306, 11)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(90, 34)
        btnDelete.TabIndex = 2
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        '
        ' btnView
        '
        btnView.BackColor = Color.FromArgb(CByte(249), CByte(182), CByte(55))
        btnView.Cursor = Cursors.Hand
        btnView.FlatAppearance.BorderSize = 0
        btnView.FlatStyle = FlatStyle.Flat
        btnView.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnView.ForeColor = Color.White
        btnView.Location = New Point(208, 11)
        btnView.Name = "btnView"
        btnView.Size = New Size(90, 34)
        btnView.TabIndex = 5
        btnView.Text = "View"
        btnView.UseVisualStyleBackColor = False
        '
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.FromArgb(CByte(251), CByte(108), CByte(0))
        btnUpdate.Cursor = Cursors.Hand
        btnUpdate.FlatAppearance.BorderSize = 0
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 9F)
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location = New Point(110, 11)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(90, 34)
        btnUpdate.TabIndex = 3
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        btnAdd.Cursor = Cursors.Hand
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(12, 11)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(90, 34)
        btnAdd.TabIndex = 4
        btnAdd.Text = "+ Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' pnlGrid
        ' 
        pnlGrid.BackColor = Color.White
        pnlGrid.Controls.Add(dgvLoans)
        pnlGrid.Dock = DockStyle.Fill
        pnlGrid.Location = New Point(0, 120)
        pnlGrid.Name = "pnlGrid"
        pnlGrid.Padding = New Padding(12)
        pnlGrid.Size = New Size(900, 368)
        pnlGrid.TabIndex = 0
        ' 
        ' dgvLoans
        ' 
        dgvLoans.AllowUserToAddRows = False
        dgvLoans.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(255), CByte(250), CByte(245))
        dgvLoans.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvLoans.BackgroundColor = Color.White
        dgvLoans.BorderStyle = BorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(251), CByte(108), CByte(0))
        DataGridViewCellStyle2.SelectionForeColor = Color.White
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvLoans.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvLoans.ColumnHeadersHeight = 36
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(255), CByte(221), CByte(156))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(184), CByte(46), CByte(18))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvLoans.DefaultCellStyle = DataGridViewCellStyle3
        dgvLoans.Dock = DockStyle.Fill
        dgvLoans.EnableHeadersVisualStyles = False
        dgvLoans.Font = New Font("Segoe UI", 9F)
        dgvLoans.Location = New Point(12, 12)
        dgvLoans.MultiSelect = False
        dgvLoans.Name = "dgvLoans"
        dgvLoans.ReadOnly = True
        dgvLoans.RowHeadersVisible = False
        dgvLoans.RowHeadersWidth = 45
        dgvLoans.RowTemplate.Height = 32
        dgvLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLoans.Size = New Size(876, 344)
        dgvLoans.TabIndex = 0
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlFooter.Controls.Add(lblRecordCount)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 488)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(900, 32)
        pnlFooter.TabIndex = 1
        ' 
        ' lblRecordCount
        ' 
        lblRecordCount.AutoSize = True
        lblRecordCount.Font = New Font("Segoe UI", 8F)
        lblRecordCount.ForeColor = Color.Gray
        lblRecordCount.Location = New Point(12, 8)
        lblRecordCount.Name = "lblRecordCount"
        lblRecordCount.Size = New Size(59, 15)
        lblRecordCount.TabIndex = 0
        lblRecordCount.Text = "Loading..."
        ' 
        ' LoanListForm
        ' 
        BackColor = Color.White
        ClientSize = New Size(900, 520)
        Controls.Add(pnlGrid)
        Controls.Add(pnlFooter)
        Controls.Add(pnlToolbar)
        Controls.Add(pnlHeader)
        Name = "LoanListForm"
        Text = "LMS - Loan List"
        pnlHeader.ResumeLayout(False)
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        pnlGrid.ResumeLayout(False)
        CType(dgvLoans, ComponentModel.ISupportInitialize).EndInit()
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
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

    ' ── Search ────────────────────────────────────────────────────
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If _fullData Is Nothing Then Return

        If searchTimer IsNot Nothing Then
            searchTimer.Stop()
        End If

        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")
        If keyword = "" Then
            _fullData.DefaultView.RowFilter = ""
        Else
            _fullData.DefaultView.RowFilter =
                $"[Reference ID] LIKE '%{keyword}%' OR [Borrower] LIKE '%{keyword}%' OR " &
                $"[Loan Type] LIKE '%{keyword}%' OR [Status] LIKE '%{keyword}%'"
        End If
        lblRecordCount.Text = $"Showing {_fullData.DefaultView.Count} record(s)"

        If keyword <> "" AndAlso _fullData.DefaultView.Count = 0 Then
            searchTimer.Start()
        End If
    End Sub

    Private Sub searchTimer_Tick(sender As Object, e As EventArgs) Handles searchTimer.Tick
        searchTimer.Stop()
        If _fullData Is Nothing Then Return
        If txtSearch.Text.Trim() <> "" AndAlso _fullData.DefaultView.Count = 0 Then
            MessageBox.Show("The searched data does not exist.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If searchTimer IsNot Nothing Then
                searchTimer.Stop()
            End If
            If _fullData Is Nothing Then Return
            If txtSearch.Text.Trim() <> "" AndAlso _fullData.DefaultView.Count = 0 Then
                MessageBox.Show("The searched data does not exist.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    ' ── Add Button ────────────────────────────────────────────────
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New NewLoanForm()
        frm.ShowDialog()
        LoadLoans()
    End Sub

    ' ── Update Button ─────────────────────────────────────────────
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

    ' ── View Button ───────────────────────────────────────────────
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If dgvLoans.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a loan record to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedID As Integer = CInt(dgvLoans.SelectedRows(0).Cells("LoanID").Value)
        Dim frm As New ViewLoanForm(selectedID)
        frm.ShowDialog()
    End Sub

    ' ── Delete Button ─────────────────────────────────────────────
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvLoans.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a loan record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedRef As String = dgvLoans.SelectedRows(0).Cells("Reference ID").Value?.ToString()
        Dim selectedBorrower As String = dgvLoans.SelectedRows(0).Cells("Borrower").Value?.ToString()
        Dim confirm As DialogResult = MessageBox.Show(
            $"Delete loan record ""{selectedRef}"" for ""{selectedBorrower}""? This action cannot be undone.",
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

    ' ── Button Hover Effects ──────────────────────────────────────
    Private Sub btnAdd_MouseEnter(sender As Object, e As EventArgs) Handles btnAdd.MouseEnter
        btnAdd.BackColor = Color.FromArgb(251, 108, 0)
    End Sub
    Private Sub btnAdd_MouseLeave(sender As Object, e As EventArgs) Handles btnAdd.MouseLeave
        btnAdd.BackColor = Color.FromArgb(231, 63, 30)
    End Sub
    Private Sub btnUpdate_MouseEnter(sender As Object, e As EventArgs) Handles btnUpdate.MouseEnter
        btnUpdate.BackColor = Color.FromArgb(231, 63, 30)
    End Sub
    Private Sub btnUpdate_MouseLeave(sender As Object, e As EventArgs) Handles btnUpdate.MouseLeave
        btnUpdate.BackColor = Color.FromArgb(251, 108, 0)
    End Sub
    Private Sub btnView_MouseEnter(sender As Object, e As EventArgs) Handles btnView.MouseEnter
        btnView.BackColor = Color.FromArgb(231, 140, 20)
    End Sub
    Private Sub btnView_MouseLeave(sender As Object, e As EventArgs) Handles btnView.MouseLeave
        btnView.BackColor = Color.FromArgb(249, 182, 55)
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
