Public Class BorrowerAccountsForm
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
    Friend WithEvents dgvAccounts As DataGridView
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
        btnUpdate = New Button()
        btnAdd = New Button()
        pnlGrid = New Panel()
        dgvAccounts = New DataGridView()
        pnlFooter = New Panel()
        lblRecordCount = New Label()
        searchTimer = New System.Windows.Forms.Timer()
        searchTimer.Interval = 700
        pnlHeader.SuspendLayout()
        pnlToolbar.SuspendLayout()
        pnlGrid.SuspendLayout()
        CType(dgvAccounts, ComponentModel.ISupportInitialize).BeginInit()
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
        lblSubtitle.Text = "Manage borrower login credentials"
        ' 
        ' lblTitle
        ' 
        lblTitle.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        lblTitle.Location = New Point(16, 10)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(400, 30)
        lblTitle.TabIndex = 1
        lblTitle.Text = "Borrower Accounts"
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlToolbar.Controls.Add(lblSearch)
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Controls.Add(btnDelete)
        pnlToolbar.Controls.Add(btnUpdate)
        pnlToolbar.Controls.Add(btnAdd)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 64)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Size = New Size(900, 56)
        pnlToolbar.TabIndex = 2
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Font = New Font("Segoe UI", 9F)
        lblSearch.ForeColor = Color.Gray
        lblSearch.Location = New Point(206, 20)
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
        txtSearch.Location = New Point(264, 15)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(258, 25)
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
        btnDelete.Location = New Point(798, 8)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(90, 34)
        btnDelete.TabIndex = 2
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        btnDelete.Visible = False
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
        pnlGrid.Controls.Add(dgvAccounts)
        pnlGrid.Dock = DockStyle.Fill
        pnlGrid.Location = New Point(0, 120)
        pnlGrid.Name = "pnlGrid"
        pnlGrid.Padding = New Padding(12)
        pnlGrid.Size = New Size(900, 368)
        pnlGrid.TabIndex = 0
        ' 
        ' dgvAccounts
        ' 
        dgvAccounts.AllowUserToAddRows = False
        dgvAccounts.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(255), CByte(250), CByte(245))
        dgvAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAccounts.BackgroundColor = Color.White
        dgvAccounts.BorderStyle = BorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(231), CByte(63), CByte(30))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(251), CByte(108), CByte(0))
        DataGridViewCellStyle2.SelectionForeColor = Color.White
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvAccounts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvAccounts.ColumnHeadersHeight = 36
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(255), CByte(221), CByte(156))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(184), CByte(46), CByte(18))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvAccounts.DefaultCellStyle = DataGridViewCellStyle3
        dgvAccounts.Dock = DockStyle.Fill
        dgvAccounts.EnableHeadersVisualStyles = False
        dgvAccounts.Font = New Font("Segoe UI", 9F)
        dgvAccounts.Location = New Point(12, 12)
        dgvAccounts.MultiSelect = False
        dgvAccounts.Name = "dgvAccounts"
        dgvAccounts.ReadOnly = True
        dgvAccounts.RowHeadersVisible = False
        dgvAccounts.RowHeadersWidth = 45
        dgvAccounts.RowTemplate.Height = 32
        dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAccounts.Size = New Size(876, 344)
        dgvAccounts.TabIndex = 0
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
        ' BorrowerAccountsForm
        ' 
        BackColor = Color.White
        ClientSize = New Size(900, 520)
        Controls.Add(pnlGrid)
        Controls.Add(pnlFooter)
        Controls.Add(pnlToolbar)
        Controls.Add(pnlHeader)
        Name = "BorrowerAccountsForm"
        Text = "LMS - Borrower Accounts"
        pnlHeader.ResumeLayout(False)
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        pnlGrid.ResumeLayout(False)
        CType(dgvAccounts, ComponentModel.ISupportInitialize).EndInit()
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub BorrowerAccountsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAccounts()
    End Sub

    ' ?? Load Accounts from DB ?????????????????????????????????????
    Private Sub LoadAccounts()
        Cursor.Current = Cursors.WaitCursor
        Try
            _fullData = BuildDisplayTable(UserRepository.GetAll())
            dgvAccounts.DataSource = _fullData
            If dgvAccounts.Columns.Contains("UserID") Then
                dgvAccounts.Columns("UserID").Visible = False
            End If
            ConfigureColumns()
            lblRecordCount.Text = $"Showing {_fullData.Rows.Count} record(s)"
        Catch ex As Exception
            MessageBox.Show($"Failed to load accounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function BuildDisplayTable(raw As DataTable) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("UserID", GetType(Integer))
        dt.Columns.Add("Username", GetType(String))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("Created At", GetType(String))
        For Each row As DataRow In raw.Rows
            If row("Role").ToString() <> "Borrower" Then Continue For
            Dim isActive As Boolean = CBool(row("IsActive"))
            dt.Rows.Add(
                row("UserID"),
                row("Username").ToString(),
                If(isActive, "Active", "Inactive"),
                CDate(row("CreatedAt")).ToString("MMM dd, yyyy"))
        Next
        Return dt
    End Function

    Private Sub ConfigureColumns()
        With dgvAccounts
            If .Columns.Contains("Username") Then .Columns("Username").FillWeight = 40
            If .Columns.Contains("Status") Then .Columns("Status").FillWeight = 20
            If .Columns.Contains("Created At") Then .Columns("Created At").FillWeight = 40
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
                $"[Username] LIKE '%{keyword}%' OR [Status] LIKE '%{keyword}%'"
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

    ' ?? Add Button ????????????????????????????????????????????????
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New NewBorrowerForm()
        frm.ShowDialog()
        LoadAccounts()
    End Sub

    ' ?? Update Button ?????????????????????????????????????????????
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvAccounts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an account to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedID As Integer = CInt(dgvAccounts.SelectedRows(0).Cells("UserID").Value)
        Dim frm As New EditAccountForm()
        frm.UserID = selectedID
        frm.ShowDialog()
        LoadAccounts()
    End Sub

    ' ?? Delete (Deactivate) Button ??????????????????????????
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvAccounts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an account to deactivate.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedUsername As String = dgvAccounts.SelectedRows(0).Cells("Username").Value?.ToString()
        Dim confirm As DialogResult = MessageBox.Show(
            $"Deactivate account ""{selectedUsername}""? The borrower will no longer be able to log in.",
            "Confirm Deactivate",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)
        If confirm = DialogResult.Yes Then
            Try
                Dim selectedID As Integer = CInt(dgvAccounts.SelectedRows(0).Cells("UserID").Value)
                UserRepository.Deactivate(selectedID)
                ActivityLogger.Log(SessionManager.CurrentUsername, "Success",
                    $"Deactivated account for user ID {selectedID}: {selectedUsername}")
                LoadAccounts()
            Catch ex As Exception
                MessageBox.Show($"Deactivate failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ── Hover Effects ─────────────────────────────────────────────
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
    Private Sub btnDelete_MouseEnter(sender As Object, e As EventArgs) Handles btnDelete.MouseEnter
        btnDelete.BackColor = Color.FromArgb(160, 40, 30)
    End Sub
    Private Sub btnDelete_MouseLeave(sender As Object, e As EventArgs) Handles btnDelete.MouseLeave
        btnDelete.BackColor = Color.FromArgb(192, 57, 43)
    End Sub

    ' ?? Status Color Coding ???????????????????????????????????????????
    Private Sub dgvAccounts_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvAccounts.CellFormatting
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return
        If dgvAccounts.Columns(e.ColumnIndex).Name <> "Status" Then Return
        Select Case e.Value.ToString()
            Case "Active"
                e.CellStyle.BackColor = Color.FromArgb(212, 237, 218)
                e.CellStyle.ForeColor = Color.FromArgb(21, 87, 36)
            Case "Inactive"
                e.CellStyle.BackColor = Color.FromArgb(226, 227, 229)
                e.CellStyle.ForeColor = Color.FromArgb(56, 61, 65)
        End Select
        e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        e.FormattingApplied = True
    End Sub

End Class
