Public Class TrackLoanForm
    Inherits Form

    ' ?? Controls ??????????????????????????????????????????????????
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlGrid As Panel
    Friend WithEvents dgvTrackLoans As DataGridView
    Private pnlFooter As Panel
    Private lblRecordCount As Label

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        pnlGrid = New Panel()
        dgvTrackLoans = New DataGridView()
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
        lblTitle.Text = "Track Loan Application"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(21, 67, 106)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(500, 30)
        lblTitle.Location = New Point(16, 10)

        ' ?? lblSubtitle ???????????????????????????????????????????
        lblSubtitle.Text = "View the status of your submitted loan applications"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(500, 18)
        lblSubtitle.Location = New Point(16, 40)

        ' ?? pnlGrid ???????????????????????????????????????????????
        pnlGrid.BackColor = Color.White
        pnlGrid.Dock = DockStyle.Fill
        pnlGrid.Padding = New Padding(12)
        pnlGrid.Controls.Add(dgvTrackLoans)

        ' ?? dgvTrackLoans ?????????????????????????????????????????
        dgvTrackLoans.Dock = DockStyle.Fill
        dgvTrackLoans.BackgroundColor = Color.White
        dgvTrackLoans.BorderStyle = BorderStyle.None
        dgvTrackLoans.RowHeadersVisible = False
        dgvTrackLoans.AllowUserToAddRows = False
        dgvTrackLoans.AllowUserToDeleteRows = False
        dgvTrackLoans.ReadOnly = False
        dgvTrackLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTrackLoans.MultiSelect = False
        dgvTrackLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTrackLoans.Font = New Font("Segoe UI", 9)
        dgvTrackLoans.ColumnHeadersHeight = 36
        dgvTrackLoans.RowTemplate.Height = 36

        ' Column header style
        dgvTrackLoans.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(21, 67, 106)
        dgvTrackLoans.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvTrackLoans.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvTrackLoans.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTrackLoans.EnableHeadersVisualStyles = False

        ' Alternating row style
        dgvTrackLoans.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253)

        ' Selection style
        dgvTrackLoans.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 240)
        dgvTrackLoans.DefaultCellStyle.SelectionForeColor = Color.FromArgb(21, 67, 106)

        ' ?? Columns ???????????????????????????????????????????????
        Dim colRefID As New DataGridViewTextBoxColumn()
        colRefID.Name = "LoanReferenceID"
        colRefID.HeaderText = "Loan Reference ID"
        colRefID.FillWeight = 22
        colRefID.ReadOnly = True

        Dim colAmount As New DataGridViewTextBoxColumn()
        colAmount.Name = "Amount"
        colAmount.HeaderText = "Amount"
        colAmount.FillWeight = 20
        colAmount.ReadOnly = True

        Dim colNextPayment As New DataGridViewTextBoxColumn()
        colNextPayment.Name = "NextPaymentSchedule"
        colNextPayment.HeaderText = "Next Payment Schedule"
        colNextPayment.FillWeight = 28
        colNextPayment.ReadOnly = True

        Dim colStatus As New DataGridViewTextBoxColumn()
        colStatus.Name = "Status"
        colStatus.HeaderText = "Status"
        colStatus.FillWeight = 18
        colStatus.ReadOnly = True

        Dim colView As New DataGridViewButtonColumn()
        colView.Name = "ViewBtn"
        colView.HeaderText = "Action"
        colView.Text = "View"
        colView.UseColumnTextForButtonValue = True
        colView.FillWeight = 12
        colView.DefaultCellStyle.BackColor = Color.FromArgb(21, 67, 106)
        colView.DefaultCellStyle.ForeColor = Color.White
        colView.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        colView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colView.FlatStyle = FlatStyle.Flat

        dgvTrackLoans.Columns.AddRange(colRefID, colAmount, colNextPayment, colStatus, colView)

        ' ?? pnlFooter ?????????????????????????????????????????????
        pnlFooter.BackColor = Color.FromArgb(245, 247, 250)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 32
        pnlFooter.Controls.Add(lblRecordCount)

        ' ?? lblRecordCount ????????????????????????????????????????
        lblRecordCount.Text = "Showing 2 records"
        lblRecordCount.Font = New Font("Segoe UI", 8, FontStyle.Regular)
        lblRecordCount.ForeColor = Color.Gray
        lblRecordCount.AutoSize = True
        lblRecordCount.Location = New Point(12, 8)

        ' ?? Form ??????????????????????????????????????????????????
        Me.Text = "LMS - Track Loan Application"
        Me.ClientSize = New Size(860, 480)
        Me.BackColor = Color.White
        Me.Controls.Add(pnlGrid)
        Me.Controls.Add(pnlFooter)
        Me.Controls.Add(pnlHeader)

        ResumeLayout(False)
    End Sub

    ' ?? Form Load ?????????????????????????????????????????????????
    Private Sub TrackLoanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSampleData()
    End Sub

    ' ?? Load Sample Data ??????????????????????????????????????????
    Private Sub LoadSampleData()
        dgvTrackLoans.Rows.Clear()
        dgvTrackLoans.Rows.Add("LN001", "PHP 10,000.00", "June 1, 2025",  "Pending")
        dgvTrackLoans.Rows.Add("LN002", "PHP 5,000.00",  "June 15, 2025", "Approved")
        lblRecordCount.Text = $"Showing {dgvTrackLoans.Rows.Count} records"
    End Sub

    ' ?? View Button Click ?????????????????????????????????????????
    Private Sub dgvTrackLoans_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTrackLoans.CellContentClick
        If e.ColumnIndex = dgvTrackLoans.Columns("ViewBtn").Index AndAlso e.RowIndex >= 0 Then
            Dim refID As String = dgvTrackLoans.Rows(e.RowIndex).Cells("LoanReferenceID").Value?.ToString()
            Dim amount As String = dgvTrackLoans.Rows(e.RowIndex).Cells("Amount").Value?.ToString()
            Dim status As String = dgvTrackLoans.Rows(e.RowIndex).Cells("Status").Value?.ToString()
            Dim frm As New ViewLoanApplicationForm(refID, amount, status)
            frm.ShowDialog()
        End If
    End Sub

End Class
