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
    Private txtSearch As TextBox
    Private pnlGrid As Panel
    Friend WithEvents dgvPayments As DataGridView
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

        ' ?? Columns ???????????????????????????????????????????????
        Dim colRefID As New DataGridViewTextBoxColumn()
        colRefID.Name = "LoanReferenceID"
        colRefID.HeaderText = "Loan Reference ID"
        colRefID.FillWeight = 20

        Dim colPayee As New DataGridViewTextBoxColumn()
        colPayee.Name = "Payee"
        colPayee.HeaderText = "Payee"
        colPayee.FillWeight = 22

        Dim colAmount As New DataGridViewTextBoxColumn()
        colAmount.Name = "Amount"
        colAmount.HeaderText = "Amount"
        colAmount.FillWeight = 20

        Dim colPenalty As New DataGridViewTextBoxColumn()
        colPenalty.Name = "Penalty"
        colPenalty.HeaderText = "Penalty"
        colPenalty.FillWeight = 20

        Dim colStatus As New DataGridViewTextBoxColumn()
        colStatus.Name = "Status"
        colStatus.HeaderText = "Status"
        colStatus.FillWeight = 18

        dgvPayments.Columns.AddRange(colRefID, colPayee, colAmount, colPenalty, colStatus)

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
        LoadSampleData()
    End Sub

    ' ?? Load Sample Data ??????????????????????????????????????????
    Private Sub LoadSampleData()
        dgvPayments.Rows.Clear()
        dgvPayments.Rows.Add("LN-0001", "Juan dela Cruz",  "PHP 4,583.33", "PHP 0.00",   "Paid")
        dgvPayments.Rows.Add("LN-0002", "Maria Santos",    "PHP 4,666.67", "PHP 0.00",   "Paid")
        dgvPayments.Rows.Add("LN-0003", "Pedro Reyes",     "PHP 4,333.33", "PHP 150.00", "Overdue")
        dgvPayments.Rows.Add("LN-0001", "Juan dela Cruz",  "PHP 4,583.33", "PHP 0.00",   "Pending")
        dgvPayments.Rows.Add("LN-0004", "Ana Bautista",    "PHP 5,150.00", "PHP 200.00", "Overdue")
        lblRecordCount.Text = $"Showing {dgvPayments.Rows.Count} records"
    End Sub

    ' ?? Add Button ????????????????????????????????????????????????
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        MessageBox.Show(
            "Add Payment feature will be available here.",
            "Add Payment",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )
    End Sub

    ' ?? Update Button ?????????????????????????????????????????????
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvPayments.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a payment record to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        MessageBox.Show(
            "Update Payment feature will be available here.",
            "Update Payment",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )
    End Sub

    ' ?? Delete Button ?????????????????????????????????????????????
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvPayments.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a payment record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this payment record?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )
        If result = DialogResult.Yes Then
            dgvPayments.Rows.Remove(dgvPayments.SelectedRows(0))
            lblRecordCount.Text = $"Showing {dgvPayments.Rows.Count} records"
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
