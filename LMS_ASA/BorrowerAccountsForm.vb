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
        dgvAccounts = New DataGridView()
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
        lblTitle.Text = "Borrower Accounts"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(400, 30)
        lblTitle.Location = New Point(16, 10)

        ' ?? lblSubtitle ???????????????????????????????????????????
        lblSubtitle.Text = "Manage borrower login credentials"
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
        pnlGrid.Controls.Add(dgvAccounts)

        ' ?? dgvAccounts ???????????????????????????????????????????
        dgvAccounts.Dock = DockStyle.Fill
        dgvAccounts.BackgroundColor = Color.White
        dgvAccounts.BorderStyle = BorderStyle.None
        dgvAccounts.RowHeadersVisible = False
        dgvAccounts.AllowUserToAddRows = False
        dgvAccounts.AllowUserToDeleteRows = False
        dgvAccounts.ReadOnly = True
        dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAccounts.MultiSelect = False
        dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAccounts.Font = New Font("Segoe UI", 9)
        dgvAccounts.ColumnHeadersHeight = 36
        dgvAccounts.RowTemplate.Height = 32

        ' Column header style
        dgvAccounts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(21, 67, 106)
        dgvAccounts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvAccounts.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvAccounts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvAccounts.EnableHeadersVisualStyles = False

        ' Alternating row style
        dgvAccounts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253)

        ' Selection style
        dgvAccounts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 240)
        dgvAccounts.DefaultCellStyle.SelectionForeColor = Color.FromArgb(21, 67, 106)

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
        Me.Text = "LMS - Borrower Accounts"
        Me.ClientSize = New Size(900, 520)
        Me.BackColor = Color.White
        Me.Controls.Add(pnlGrid)
        Me.Controls.Add(pnlFooter)
        Me.Controls.Add(pnlToolbar)
        Me.Controls.Add(pnlHeader)

        ResumeLayout(False)
    End Sub

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub BorrowerAccountsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GATE — remove this block when unlocking for v1.03
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE
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

    ' ?? Search ????????????????????????????????????????????????
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If _fullData Is Nothing Then Return
        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")
        If keyword = "" Then
            _fullData.DefaultView.RowFilter = ""
        Else
            _fullData.DefaultView.RowFilter =
                $"[Username] LIKE '%{keyword}%' OR [Status] LIKE '%{keyword}%'"
        End If
        lblRecordCount.Text = $"Showing {_fullData.DefaultView.Count} record(s)"
    End Sub

    ' ?? Add Button ????????????????????????????????????????????????
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        MessageBox.Show(
            "Borrower accounts are created automatically when adding a new borrower." &
            Environment.NewLine & "Use the Borrower List to add a new borrower.",
            "Information",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
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
