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
    Private txtSearch As TextBox
    Private pnlGrid As Panel
    Friend WithEvents dgvAccounts As DataGridView
    Private pnlFooter As Panel
    Private lblRecordCount As Label

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
        btnDelete.Visible = False

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

        ' ?? Columns ???????????????????????????????????????????????
        Dim colBorrowerName As New DataGridViewTextBoxColumn()
        colBorrowerName.Name = "BorrowerName"
        colBorrowerName.HeaderText = "Borrower Name"
        colBorrowerName.FillWeight = 30

        Dim colUsername As New DataGridViewTextBoxColumn()
        colUsername.Name = "Username"
        colUsername.HeaderText = "Username"
        colUsername.FillWeight = 25

        Dim colPassword As New DataGridViewTextBoxColumn()
        colPassword.Name = "Password"
        colPassword.HeaderText = "Password"
        colPassword.FillWeight = 25

        Dim colStatus As New DataGridViewTextBoxColumn()
        colStatus.Name = "Status"
        colStatus.HeaderText = "Status"
        colStatus.FillWeight = 20

        dgvAccounts.Columns.AddRange(colBorrowerName, colUsername, colPassword, colStatus)

        ' ?? pnlFooter ?????????????????????????????????????????????
        pnlFooter.BackColor = Color.FromArgb(245, 247, 250)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 32
        pnlFooter.Controls.Add(lblRecordCount)

        ' ?? lblRecordCount ????????????????????????????????????????
        lblRecordCount.Text = "Showing 5 records"
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
        LoadSampleData()
    End Sub

    ' ?? Load Sample Data ??????????????????????????????????????????
    Private Sub LoadSampleData()
        dgvAccounts.Rows.Clear()
        dgvAccounts.Rows.Add("Juan dela Cruz",  "juan.delacruz",  "••••••••", "Active")
        dgvAccounts.Rows.Add("Maria Santos",    "maria.santos",   "••••••••", "Active")
        dgvAccounts.Rows.Add("Pedro Reyes",     "pedro.reyes",    "••••••••", "Active")
        dgvAccounts.Rows.Add("Ana Bautista",    "ana.bautista",   "••••••••", "Inactive")
        dgvAccounts.Rows.Add("Carlos Mendoza",  "carlos.mendoza", "••••••••", "Inactive")
        lblRecordCount.Text = $"Showing {dgvAccounts.Rows.Count} records"
    End Sub

    ' ?? Add Button ????????????????????????????????????????????????
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        MessageBox.Show(
            "Add Borrower Account feature will be available here.",
            "Add Account",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )
    End Sub

    ' ?? Update Button ?????????????????????????????????????????????
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvAccounts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an account to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        MessageBox.Show(
            "Update Borrower Account feature will be available here.",
            "Update Account",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )
    End Sub

    ' ?? Delete Button ?????????????????????????????????????????????
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvAccounts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an account to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this borrower account?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )
        If result = DialogResult.Yes Then
            dgvAccounts.Rows.Remove(dgvAccounts.SelectedRows(0))
            lblRecordCount.Text = $"Showing {dgvAccounts.Rows.Count} records"
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
