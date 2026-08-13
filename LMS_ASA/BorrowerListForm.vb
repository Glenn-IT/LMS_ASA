Public Class BorrowerListForm
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
    Private lblSearch As Label
    Private WithEvents txtSearch As TextBox
    Private pnlGrid As Panel
    Friend WithEvents dgvBorrowers As DataGridView
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
        dgvBorrowers = New DataGridView()
        pnlFooter = New Panel()
        lblRecordCount = New Label()
        searchTimer = New System.Windows.Forms.Timer()
        searchTimer.Interval = 700
        pnlHeader.SuspendLayout()
        pnlToolbar.SuspendLayout()
        pnlGrid.SuspendLayout()
        CType(dgvBorrowers, ComponentModel.ISupportInitialize).BeginInit()
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
        lblSubtitle.Text = "Manage all borrower records"
        ' 
        ' lblTitle
        ' 
        lblTitle.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        lblTitle.Location = New Point(16, 10)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(400, 30)
        lblTitle.TabIndex = 1
        lblTitle.Text = "Borrower List"
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
        pnlToolbar.Size = New Size(900, 56)
        pnlToolbar.TabIndex = 2
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Font = New Font("Segoe UI", 9F)
        lblSearch.ForeColor = Color.Gray
        lblSearch.Location = New Point(324, 21)
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
        txtSearch.Location = New Point(382, 19)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(286, 25)
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
        btnDelete.Location = New Point(798, 11)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(90, 34)
        btnDelete.TabIndex = 2
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        btnDelete.Visible = False
        '
        ' btnView
        '
        btnView.BackColor = Color.FromArgb(CByte(23), CByte(162), CByte(184))
        btnView.Cursor = Cursors.Hand
        btnView.FlatAppearance.BorderSize = 0
        btnView.FlatStyle = FlatStyle.Flat
        btnView.Font = New Font("Segoe UI", 9F)
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
        btnUpdate.BackColor = Color.FromArgb(CByte(52), CByte(120), CByte(180))
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
        btnAdd.BackColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
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
        pnlGrid.Controls.Add(dgvBorrowers)
        pnlGrid.Dock = DockStyle.Fill
        pnlGrid.Location = New Point(0, 120)
        pnlGrid.Name = "pnlGrid"
        pnlGrid.Padding = New Padding(12)
        pnlGrid.Size = New Size(900, 368)
        pnlGrid.TabIndex = 0
        ' 
        ' dgvBorrowers
        ' 
        dgvBorrowers.AllowUserToAddRows = False
        dgvBorrowers.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(245), CByte(249), CByte(253))
        dgvBorrowers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvBorrowers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvBorrowers.BackgroundColor = Color.White
        dgvBorrowers.BorderStyle = BorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvBorrowers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvBorrowers.ColumnHeadersHeight = 36
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(173), CByte(216), CByte(240))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(21), CByte(67), CByte(106))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvBorrowers.DefaultCellStyle = DataGridViewCellStyle3
        dgvBorrowers.Dock = DockStyle.Fill
        dgvBorrowers.EnableHeadersVisualStyles = False
        dgvBorrowers.Font = New Font("Segoe UI", 9F)
        dgvBorrowers.Location = New Point(12, 12)
        dgvBorrowers.MultiSelect = False
        dgvBorrowers.Name = "dgvBorrowers"
        dgvBorrowers.ReadOnly = True
        dgvBorrowers.RowHeadersVisible = False
        dgvBorrowers.RowHeadersWidth = 45
        dgvBorrowers.RowTemplate.Height = 32
        dgvBorrowers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBorrowers.Size = New Size(876, 344)
        dgvBorrowers.TabIndex = 0
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
        ' BorrowerListForm
        ' 
        BackColor = Color.White
        ClientSize = New Size(900, 520)
        Controls.Add(pnlGrid)
        Controls.Add(pnlFooter)
        Controls.Add(pnlToolbar)
        Controls.Add(pnlHeader)
        Name = "BorrowerListForm"
        Text = "LMS - Borrower List"
        pnlHeader.ResumeLayout(False)
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        pnlGrid.ResumeLayout(False)
        CType(dgvBorrowers, ComponentModel.ISupportInitialize).EndInit()
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub BorrowerListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBorrowers()
    End Sub

    ' ?? Load Borrowers from DB ????????????????????????????????????
    Private Sub LoadBorrowers()
        Cursor.Current = Cursors.WaitCursor
        Try
            _fullData = BuildDisplayTable(BorrowerRepository.GetAll())
            dgvBorrowers.DataSource = _fullData
            If dgvBorrowers.Columns.Contains("BorrowerID") Then
                dgvBorrowers.Columns("BorrowerID").Visible = False
            End If
            ConfigureColumns()
            lblRecordCount.Text = $"Showing {_fullData.Rows.Count} record(s)"
        Catch ex As Exception
            MessageBox.Show($"Failed to load borrowers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function BuildDisplayTable(raw As DataTable) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("BorrowerID", GetType(Integer))
        dt.Columns.Add("BorrowerUID", GetType(String))
        dt.Columns.Add("Full Name", GetType(String))
        dt.Columns.Add("Age", GetType(Integer))
        dt.Columns.Add("Contact", GetType(String))
        dt.Columns.Add("Email", GetType(String))
        For Each row As DataRow In raw.Rows
            Dim mid As String = If(row("MiddleName") Is DBNull.Value OrElse row("MiddleName").ToString() = "",
                                   "", row("MiddleName").ToString() & " ")
            dt.Rows.Add(
                row("BorrowerID"),
                row("BorrowerUID"),
                row("FirstName").ToString() & " " & mid & row("LastName").ToString(),
                row("Age"),
                row("Contact"),
                row("Email"))
        Next
        Return dt
    End Function

    Private Sub ConfigureColumns()
        With dgvBorrowers
            If .Columns.Contains("BorrowerUID") Then
                .Columns("BorrowerUID").HeaderText = "Borrower UID"
                .Columns("BorrowerUID").FillWeight = 15
            End If
            If .Columns.Contains("Full Name") Then .Columns("Full Name").FillWeight = 30
            If .Columns.Contains("Age") Then .Columns("Age").FillWeight = 8
            If .Columns.Contains("Contact") Then
                .Columns("Contact").HeaderText = "Contact No."
                .Columns("Contact").FillWeight = 20
            End If
            If .Columns.Contains("Email") Then .Columns("Email").FillWeight = 27
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
                $"[BorrowerUID] LIKE '%{keyword}%' OR [Full Name] LIKE '%{keyword}%' OR [Contact] LIKE '%{keyword}%'"
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
        LoadBorrowers()
    End Sub

    ' ?? Update Button ?????????????????????????????????????????????
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvBorrowers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a borrower record to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedID As Integer = CInt(dgvBorrowers.SelectedRows(0).Cells("BorrowerID").Value)
        Dim frm As New NewBorrowerForm()
        frm.BorrowerID = selectedID
        frm.ShowDialog()
        LoadBorrowers()
    End Sub

    ' ?? View Button ???????????????????????????????????????????????
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If dgvBorrowers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a borrower record to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedID As Integer = CInt(dgvBorrowers.SelectedRows(0).Cells("BorrowerID").Value)
        Dim frm As New ViewBorrowerForm(selectedID)
        frm.ShowDialog()
    End Sub

    ' ?? Delete Button ?????????????????????????????????????????????
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvBorrowers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a borrower record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedName As String = dgvBorrowers.SelectedRows(0).Cells("Full Name").Value?.ToString()
        Dim selectedIDCheck As Integer = CInt(dgvBorrowers.SelectedRows(0).Cells("BorrowerID").Value)
        If BorrowerRepository.HasLoans(selectedIDCheck) Then
            MessageBox.Show(
                $"""{selectedName}"" cannot be deleted because they have existing loan records. Remove or reassign those loans first.",
                "Cannot Delete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If
        Dim confirm As DialogResult = MessageBox.Show(
            $"Delete borrower ""{selectedName}""? This action cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)
        If confirm = DialogResult.Yes Then
            Try
                Dim selectedID As Integer = CInt(dgvBorrowers.SelectedRows(0).Cells("BorrowerID").Value)
                BorrowerRepository.Delete(selectedID)
                ActivityLogger.Log(SessionManager.CurrentUsername, "Success", $"Deleted borrower ID {selectedID}: {selectedName}")
                LoadBorrowers()
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

End Class
