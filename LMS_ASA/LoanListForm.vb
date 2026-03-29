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
    Private txtSearch As TextBox
    Private lblSearch As Label
    Private pnlGrid As Panel
    Friend WithEvents dgvLoans As DataGridView
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
        btnUpdate.Text = "? Update"
        btnUpdate.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        btnUpdate.BackColor = Color.FromArgb(52, 120, 180)
        btnUpdate.ForeColor = Color.White
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.FlatAppearance.BorderSize = 0
        btnUpdate.Size = New Size(90, 34)
        btnUpdate.Location = New Point(110, 11)
        btnUpdate.Cursor = Cursors.Hand

        ' ?? btnDelete ?????????????????????????????????????????????
        btnDelete.Text = "? Delete"
        btnDelete.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        btnDelete.BackColor = Color.FromArgb(192, 57, 43)
        btnDelete.ForeColor = Color.White
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.FlatAppearance.BorderSize = 0
        btnDelete.Size = New Size(90, 34)
        btnDelete.Location = New Point(208, 11)
        btnDelete.Cursor = Cursors.Hand

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

        ' ?? Columns ???????????????????????????????????????????????
        Dim colLoanID As New DataGridViewTextBoxColumn()
        colLoanID.Name = "LoanID"
        colLoanID.HeaderText = "Loan ID"
        colLoanID.FillWeight = 10

        Dim colBorrowerName As New DataGridViewTextBoxColumn()
        colBorrowerName.Name = "BorrowerName"
        colBorrowerName.HeaderText = "Borrower Name"
        colBorrowerName.FillWeight = 20

        Dim colLoanDetails As New DataGridViewTextBoxColumn()
        colLoanDetails.Name = "LoanDetails"
        colLoanDetails.HeaderText = "Loan Details"
        colLoanDetails.FillWeight = 25

        Dim colNextPayment As New DataGridViewTextBoxColumn()
        colNextPayment.Name = "NextPaymentDetails"
        colNextPayment.HeaderText = "Next Payment Details"
        colNextPayment.FillWeight = 25

        Dim colStatus As New DataGridViewTextBoxColumn()
        colStatus.Name = "Status"
        colStatus.HeaderText = "Status"
        colStatus.FillWeight = 20

        dgvLoans.Columns.AddRange(colLoanID, colBorrowerName, colLoanDetails, colNextPayment, colStatus)

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
        LoadSampleData()
    End Sub

    ' ?? Load Sample Data ??????????????????????????????????????????
    Private Sub LoadSampleData()
        dgvLoans.Rows.Clear()
        dgvLoans.Rows.Add("LN-0001", "Juan dela Cruz",    "Personal Loan | PHP 50,000 | 12 mos @ 5%",  "PHP 4,583.33 – Jul 15, 2025", "Active")
        dgvLoans.Rows.Add("LN-0002", "Maria Santos",      "Business Loan | PHP 100,000 | 24 mos @ 6%", "PHP 4,666.67 – Jul 20, 2025", "Active")
        dgvLoans.Rows.Add("LN-0003", "Pedro Reyes",       "Salary Loan | PHP 25,000 | 6 mos @ 4%",    "PHP 4,333.33 – Jul 10, 2025", "Active")
        dgvLoans.Rows.Add("LN-0004", "Ana Bautista",      "Emergency Loan | PHP 15,000 | 3 mos @ 3%", "PHP 5,150.00 – Aug 01, 2025", "Pending")
        dgvLoans.Rows.Add("LN-0005", "Carlos Mendoza",    "Personal Loan | PHP 30,000 | 12 mos @ 5%", "—",                           "Closed")
        lblRecordCount.Text = $"Showing {dgvLoans.Rows.Count} records"
    End Sub

    ' ?? Add Button ????????????????????????????????????????????????
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New NewLoanForm()
        frm.ShowDialog()
    End Sub

    ' ?? Update Button ?????????????????????????????????????????????
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvLoans.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a loan record to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim frm As New NewLoanForm()
        frm.ShowDialog()
    End Sub

    ' ?? Delete Button ?????????????????????????????????????????????
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvLoans.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a loan record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this loan record?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )
        If result = DialogResult.Yes Then
            dgvLoans.Rows.Remove(dgvLoans.SelectedRows(0))
            lblRecordCount.Text = $"Showing {dgvLoans.Rows.Count} records"
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

End Class
