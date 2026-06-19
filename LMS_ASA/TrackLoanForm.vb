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
        dgvTrackLoans.ReadOnly = True
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
        colNextPayment.Name = "LoanType"
        colNextPayment.HeaderText = "Loan Type"
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
        lblRecordCount.Text = "Loading..."
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
        ' GATE — remove this block when unlocking for v1.10
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE
        LoadApplications()
    End Sub

    ' ?? Load Applications from DB ?????????????????????????????????
    Private Sub LoadApplications()
        Cursor.Current = Cursors.WaitCursor
        Try
            If Not dgvTrackLoans.Columns.Contains("AppID") Then
                Dim colHidden As New DataGridViewTextBoxColumn()
                colHidden.Name = "AppID"
                colHidden.Visible = False
                dgvTrackLoans.Columns.Insert(0, colHidden)
            End If

            dgvTrackLoans.Rows.Clear()
            Dim dt As DataTable = LoanApplicationRepository.GetByBorrowerID(SessionManager.CurrentBorrowerID)
            For Each row As DataRow In dt.Rows
                Dim appID As Integer = CInt(row("ApplicationID"))
                Dim rowIdx As Integer = dgvTrackLoans.Rows.Add()
                dgvTrackLoans.Rows(rowIdx).Cells("AppID").Value = appID
                dgvTrackLoans.Rows(rowIdx).Cells("LoanReferenceID").Value = $"APP-{appID:D4}"
                dgvTrackLoans.Rows(rowIdx).Cells("Amount").Value = $"PHP {CDec(row("PrincipalAmount")):N2}"
                dgvTrackLoans.Rows(rowIdx).Cells("LoanType").Value = row("LoanType").ToString()
                dgvTrackLoans.Rows(rowIdx).Cells("Status").Value = row("Status").ToString()
            Next
            lblRecordCount.Text = $"Showing {dgvTrackLoans.Rows.Count} record(s)"
        Catch ex As Exception
            MessageBox.Show($"Failed to load applications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblRecordCount.Text = "0 record(s)"
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ' ?? View Button Click ?????????????????????????????????????????
    Private Sub dgvTrackLoans_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTrackLoans.CellContentClick
        If e.ColumnIndex = dgvTrackLoans.Columns("ViewBtn").Index AndAlso e.RowIndex >= 0 Then
            Dim appID As Integer = CInt(dgvTrackLoans.Rows(e.RowIndex).Cells("AppID").Value)
            Dim frm As New ViewLoanApplicationForm(appID)
            frm.ShowDialog()
        End If
    End Sub

    ' ?? Status Color Coding ???????????????????????????????????????????
    Private Sub dgvTrackLoans_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvTrackLoans.CellFormatting
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return
        If dgvTrackLoans.Columns(e.ColumnIndex).Name <> "Status" Then Return
        Select Case e.Value.ToString()
            Case "Approved"
                e.CellStyle.BackColor = Color.FromArgb(212, 237, 218)
                e.CellStyle.ForeColor = Color.FromArgb(21, 87, 36)
            Case "Pending"
                e.CellStyle.BackColor = Color.FromArgb(255, 243, 205)
                e.CellStyle.ForeColor = Color.FromArgb(133, 100, 4)
            Case "Rejected"
                e.CellStyle.BackColor = Color.FromArgb(248, 215, 218)
                e.CellStyle.ForeColor = Color.FromArgb(114, 28, 36)
        End Select
        e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        e.FormattingApplied = True
    End Sub

End Class
