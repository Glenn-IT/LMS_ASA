Public Class BorrowerListForm
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
    Friend WithEvents dgvBorrowers As DataGridView
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
        dgvBorrowers = New DataGridView()
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
        lblTitle.Text = "Borrower List"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(400, 30)
        lblTitle.Location = New Point(16, 10)

        ' ?? lblSubtitle ???????????????????????????????????????????
        lblSubtitle.Text = "Manage all borrower records"
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
        pnlGrid.Controls.Add(dgvBorrowers)

        ' ?? dgvBorrowers ??????????????????????????????????????????
        dgvBorrowers.Dock = DockStyle.Fill
        dgvBorrowers.BackgroundColor = Color.White
        dgvBorrowers.BorderStyle = BorderStyle.None
        dgvBorrowers.RowHeadersVisible = False
        dgvBorrowers.AllowUserToAddRows = False
        dgvBorrowers.AllowUserToDeleteRows = False
        dgvBorrowers.ReadOnly = True
        dgvBorrowers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBorrowers.MultiSelect = False
        dgvBorrowers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvBorrowers.Font = New Font("Segoe UI", 9)
        dgvBorrowers.ColumnHeadersHeight = 36
        dgvBorrowers.RowTemplate.Height = 32

        ' Column header style
        dgvBorrowers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(21, 67, 106)
        dgvBorrowers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvBorrowers.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvBorrowers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvBorrowers.EnableHeadersVisualStyles = False

        ' Alternating row style
        dgvBorrowers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253)

        ' Selection style
        dgvBorrowers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 240)
        dgvBorrowers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(21, 67, 106)

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
        Me.Text = "LMS - Borrower List"
        Me.ClientSize = New Size(900, 520)
        Me.BackColor = Color.White
        Me.Controls.Add(pnlGrid)
        Me.Controls.Add(pnlFooter)
        Me.Controls.Add(pnlToolbar)
        Me.Controls.Add(pnlHeader)

        ResumeLayout(False)
    End Sub

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub BorrowerListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GATE — remove this block when unlocking for v1.02
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE
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

    ' ?? Search ????????????????????????????????????????????????
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If _fullData Is Nothing Then Return
        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''") 
        If keyword = "" Then
            _fullData.DefaultView.RowFilter = ""
        Else
            _fullData.DefaultView.RowFilter =
                $"[BorrowerUID] LIKE '%{keyword}%' OR [Full Name] LIKE '%{keyword}%' OR [Contact] LIKE '%{keyword}%'"
        End If
        lblRecordCount.Text = $"Showing {_fullData.DefaultView.Count} record(s)"
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

    ' ?? Delete Button ?????????????????????????????????????????????
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvBorrowers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a borrower record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedName As String = dgvBorrowers.SelectedRows(0).Cells("Full Name").Value?.ToString()
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
    Private Sub btnDelete_MouseEnter(sender As Object, e As EventArgs) Handles btnDelete.MouseEnter
        btnDelete.BackColor = Color.FromArgb(160, 40, 30)
    End Sub
    Private Sub btnDelete_MouseLeave(sender As Object, e As EventArgs) Handles btnDelete.MouseLeave
        btnDelete.BackColor = Color.FromArgb(192, 57, 43)
    End Sub

End Class
