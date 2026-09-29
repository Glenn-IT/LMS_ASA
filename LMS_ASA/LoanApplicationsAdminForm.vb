Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class LoanApplicationsAdminForm
    Inherits Form

    ' ── Controls ──────────────────────────────────────────────────
    Private pnlHeader As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private pnlDividerHeader As Panel

    ' ── KPI Cards ─────────────────────────────────────────────────
    Private WithEvents pnlKpiSummary As Panel
    Private grpKpiTotal As Panel
    Private lblKpiTotalTitle As Label
    Private lblKpiTotalVal As Label

    Private grpKpiPending As Panel
    Private lblKpiPendingTitle As Label
    Private lblKpiPendingVal As Label

    Private grpKpiApproved As Panel
    Private lblKpiApprovedTitle As Label
    Private lblKpiApprovedVal As Label

    Private grpKpiRejected As Panel
    Private lblKpiRejectedTitle As Label
    Private lblKpiRejectedVal As Label

    ' ── Toolbar ───────────────────────────────────────────────────
    Private pnlToolbar As Panel
    Friend WithEvents btnApprove As Button
    Friend WithEvents btnReject As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnPrint As Button
    Private lblFilter As Label
    Friend WithEvents cmbFilter As ComboBox
    Private lblSearch As Label
    Private WithEvents txtSearch As TextBox

    ' ── Grid & Footer ─────────────────────────────────────────────
    Private pnlGrid As Panel
    Friend WithEvents dgvApplications As DataGridView
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
        pnlDividerHeader = New Panel()

        pnlKpiSummary = New Panel()
        grpKpiTotal = New Panel()
        lblKpiTotalTitle = New Label()
        lblKpiTotalVal = New Label()

        grpKpiPending = New Panel()
        lblKpiPendingTitle = New Label()
        lblKpiPendingVal = New Label()

        grpKpiApproved = New Panel()
        lblKpiApprovedTitle = New Label()
        lblKpiApprovedVal = New Label()

        grpKpiRejected = New Panel()
        lblKpiRejectedTitle = New Label()
        lblKpiRejectedVal = New Label()

        pnlToolbar = New Panel()
        btnApprove = New Button()
        btnReject = New Button()
        btnView = New Button()
        btnPrint = New Button()
        lblFilter = New Label()
        cmbFilter = New ComboBox()
        lblSearch = New Label()
        txtSearch = New TextBox()

        pnlGrid = New Panel()
        dgvApplications = New DataGridView()
        pnlFooter = New Panel()
        lblRecordCount = New Label()

        SuspendLayout()

        ' ── pnlHeader ──────────────────────────────────────────────
        pnlHeader.BackColor = Color.White
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 60
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(pnlDividerHeader)

        ' lblTitle
        lblTitle.Text = "Loan Applications"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(231, 63, 30)
        lblTitle.AutoSize = False
        lblTitle.Size = New Size(400, 28)
        lblTitle.Location = New Point(16, 8)

        ' lblSubtitle
        lblSubtitle.Text = "Review, approve, or reject borrower-submitted loan applications"
        lblSubtitle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.Gray
        lblSubtitle.AutoSize = False
        lblSubtitle.Size = New Size(500, 18)
        lblSubtitle.Location = New Point(16, 36)

        ' pnlDividerHeader
        pnlDividerHeader.BackColor = Color.FromArgb(225, 228, 234)
        pnlDividerHeader.Dock = DockStyle.Bottom
        pnlDividerHeader.Height = 1

        ' ── pnlKpiSummary ──────────────────────────────────────────
        pnlKpiSummary.BackColor = Color.FromArgb(245, 247, 250)
        pnlKpiSummary.Dock = DockStyle.Top
        pnlKpiSummary.Height = 68
        pnlKpiSummary.Padding = New Padding(12, 6, 12, 6)

        ' Card 1: Total
        SetupKpiCard(grpKpiTotal, lblKpiTotalTitle, lblKpiTotalVal, "TOTAL APPLICATIONS", "0", Color.FromArgb(40, 50, 70))
        ' Card 2: Pending
        SetupKpiCard(grpKpiPending, lblKpiPendingTitle, lblKpiPendingVal, "AWAITING REVIEW", "0", Color.FromArgb(251, 108, 0))
        ' Card 3: Approved
        SetupKpiCard(grpKpiApproved, lblKpiApprovedTitle, lblKpiApprovedVal, "APPROVED", "0", Color.FromArgb(40, 167, 69))
        ' Card 4: Rejected
        SetupKpiCard(grpKpiRejected, lblKpiRejectedTitle, lblKpiRejectedVal, "REJECTED", "0", Color.FromArgb(220, 53, 69))

        pnlKpiSummary.Controls.Add(grpKpiRejected)
        pnlKpiSummary.Controls.Add(grpKpiApproved)
        pnlKpiSummary.Controls.Add(grpKpiPending)
        pnlKpiSummary.Controls.Add(grpKpiTotal)

        ' ── pnlToolbar ─────────────────────────────────────────────
        pnlToolbar.BackColor = Color.FromArgb(245, 247, 250)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Height = 52
        pnlToolbar.Controls.Add(lblSearch)
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Controls.Add(cmbFilter)
        pnlToolbar.Controls.Add(lblFilter)
        pnlToolbar.Controls.Add(btnPrint)
        pnlToolbar.Controls.Add(btnView)
        pnlToolbar.Controls.Add(btnReject)
        pnlToolbar.Controls.Add(btnApprove)

        ' btnApprove
        btnApprove.Text = "✓ Approve"
        btnApprove.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnApprove.BackColor = Color.FromArgb(40, 167, 69)
        btnApprove.ForeColor = Color.White
        btnApprove.FlatStyle = FlatStyle.Flat
        btnApprove.FlatAppearance.BorderSize = 0
        btnApprove.Size = New Size(95, 34)
        btnApprove.Location = New Point(12, 8)
        btnApprove.Cursor = Cursors.Hand

        ' btnReject
        btnReject.Text = "✗ Reject"
        btnReject.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnReject.BackColor = Color.FromArgb(220, 53, 69)
        btnReject.ForeColor = Color.White
        btnReject.FlatStyle = FlatStyle.Flat
        btnReject.FlatAppearance.BorderSize = 0
        btnReject.Size = New Size(95, 34)
        btnReject.Location = New Point(115, 8)
        btnReject.Cursor = Cursors.Hand

        ' btnView
        btnView.Text = "View Details"
        btnView.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnView.BackColor = Color.FromArgb(231, 63, 30)
        btnView.ForeColor = Color.White
        btnView.FlatStyle = FlatStyle.Flat
        btnView.FlatAppearance.BorderSize = 0
        btnView.Size = New Size(110, 34)
        btnView.Location = New Point(218, 8)
        btnView.Cursor = Cursors.Hand

        ' btnPrint
        btnPrint.Text = "🖨️ Print"
        btnPrint.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        btnPrint.BackColor = Color.FromArgb(41, 128, 185)
        btnPrint.ForeColor = Color.White
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.FlatAppearance.BorderSize = 0
        btnPrint.Size = New Size(95, 34)
        btnPrint.Location = New Point(336, 8)
        btnPrint.Cursor = Cursors.Hand

        ' lblFilter
        lblFilter.Text = "Filter:"
        lblFilter.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblFilter.ForeColor = Color.Gray
        lblFilter.AutoSize = True
        lblFilter.Location = New Point(446, 17)

        ' cmbFilter
        cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilter.Font = New Font("Segoe UI", 9)
        cmbFilter.Items.AddRange(New Object() {"All Applications", "Pending Only", "Approved Only", "Rejected Only"})
        cmbFilter.SelectedIndex = 0
        cmbFilter.Size = New Size(140, 28)
        cmbFilter.Location = New Point(486, 12)

        ' lblSearch
        lblSearch.Text = "Search:"
        lblSearch.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSearch.ForeColor = Color.Gray
        lblSearch.AutoSize = True
        lblSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSearch.Location = New Point(630, 17)

        ' txtSearch
        txtSearch.Font = New Font("Segoe UI", 9)
        txtSearch.Size = New Size(220, 28)
        txtSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtSearch.Location = New Point(684, 12)
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.BackColor = Color.White

        ' ── pnlGrid ────────────────────────────────────────────────
        pnlGrid.BackColor = Color.White
        pnlGrid.Dock = DockStyle.Fill
        pnlGrid.Padding = New Padding(12)
        pnlGrid.Controls.Add(dgvApplications)

        ' dgvApplications
        dgvApplications.Dock = DockStyle.Fill
        dgvApplications.BackgroundColor = Color.White
        dgvApplications.BorderStyle = BorderStyle.None
        dgvApplications.RowHeadersVisible = False
        dgvApplications.AllowUserToAddRows = False
        dgvApplications.AllowUserToDeleteRows = False
        dgvApplications.ReadOnly = True
        dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvApplications.MultiSelect = False
        dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvApplications.Font = New Font("Segoe UI", 9)
        dgvApplications.ColumnHeadersHeight = 36
        dgvApplications.RowTemplate.Height = 32

        ' Column header style
        dgvApplications.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 63, 30)
        dgvApplications.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvApplications.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 63, 30)
        dgvApplications.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White
        dgvApplications.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvApplications.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvApplications.EnableHeadersVisualStyles = False

        ' Alternating row style
        dgvApplications.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(253, 253, 254)

        ' Selection style
        dgvApplications.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 237, 222)
        dgvApplications.DefaultCellStyle.SelectionForeColor = Color.FromArgb(184, 46, 18)

        ' ── pnlFooter ──────────────────────────────────────────────
        pnlFooter.BackColor = Color.FromArgb(245, 247, 250)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 32
        pnlFooter.Controls.Add(lblRecordCount)

        ' lblRecordCount
        lblRecordCount.Text = "Loading applications..."
        lblRecordCount.Font = New Font("Segoe UI", 8, FontStyle.Regular)
        lblRecordCount.ForeColor = Color.Gray
        lblRecordCount.AutoSize = True
        lblRecordCount.Location = New Point(12, 8)

        ' ── Form Setup ─────────────────────────────────────────────
        Me.Text = "LMS - Loan Applications"
        Me.ClientSize = New Size(960, 580)
        Me.BackColor = Color.White
        Me.Controls.Add(pnlGrid)
        Me.Controls.Add(pnlFooter)
        Me.Controls.Add(pnlToolbar)
        Me.Controls.Add(pnlKpiSummary)
        Me.Controls.Add(pnlHeader)

        ResumeLayout(False)
    End Sub

    Private Sub SetupKpiCard(pnl As Panel, lblTitle As Label, lblVal As Label, titleText As String, valText As String, valColor As Color)
        pnl.BackColor = Color.White
        pnl.BorderStyle = BorderStyle.FixedSingle
        pnl.Size = New Size(210, 52)
        pnl.Location = New Point(12, 8)

        lblTitle.Text = titleText
        lblTitle.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblTitle.ForeColor = Color.Gray
        lblTitle.Location = New Point(10, 6)
        lblTitle.Size = New Size(190, 16)

        lblVal.Text = valText
        lblVal.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblVal.ForeColor = valColor
        lblVal.Location = New Point(10, 22)
        lblVal.Size = New Size(190, 24)

        pnl.Controls.Add(lblTitle)
        pnl.Controls.Add(lblVal)
    End Sub

    Private Sub LoanApplicationsAdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LayoutKpiCards()
        LoadApplications()
    End Sub

    Private Sub LoanApplicationsAdminForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LayoutKpiCards()
    End Sub

    Private Sub pnlKpiSummary_Resize(sender As Object, e As EventArgs) Handles pnlKpiSummary.Resize
        LayoutKpiCards()
    End Sub

    Private Sub LayoutKpiCards()
        If pnlKpiSummary Is Nothing OrElse grpKpiTotal Is Nothing Then Return
        Dim totalW As Integer = pnlKpiSummary.ClientSize.Width
        If totalW <= 0 Then Return
        Dim margin As Integer = 12
        Dim gap As Integer = 10
        Dim cardW As Integer = Math.Max(100, (totalW - (margin * 2) - (gap * 3)) \ 4)

        grpKpiTotal.SetBounds(margin, 8, cardW, 52)
        grpKpiPending.SetBounds(margin + cardW + gap, 8, cardW, 52)
        grpKpiApproved.SetBounds(margin + (cardW + gap) * 2, 8, cardW, 52)
        grpKpiRejected.SetBounds(margin + (cardW + gap) * 3, 8, cardW, 52)

        lblKpiTotalTitle.Width = cardW - 20
        lblKpiTotalVal.Width = cardW - 20
        lblKpiPendingTitle.Width = cardW - 20
        lblKpiPendingVal.Width = cardW - 20
        lblKpiApprovedTitle.Width = cardW - 20
        lblKpiApprovedVal.Width = cardW - 20
        lblKpiRejectedTitle.Width = cardW - 20
        lblKpiRejectedVal.Width = cardW - 20
    End Sub

    Public Sub LoadApplications()
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim raw As DataTable = LoanApplicationRepository.GetAll()
            _fullData = BuildDisplayTable(raw)
            ApplyFilter()
            UpdateKpiCards(raw)
        Catch ex As Exception
            MessageBox.Show($"Failed to load loan applications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub UpdateKpiCards(raw As DataTable)
        If raw Is Nothing Then Return
        Dim total As Integer = raw.Rows.Count
        Dim pending As Integer = 0
        Dim approved As Integer = 0
        Dim rejected As Integer = 0

        For Each row As DataRow In raw.Rows
            Dim st As String = row("Status").ToString().Trim()
            Select Case st
                Case "Pending"
                    pending += 1
                Case "Approved"
                    approved += 1
                Case "Rejected"
                    rejected += 1
            End Select
        Next

        lblKpiTotalVal.Text = $"{total} Record(s)"
        lblKpiPendingVal.Text = $"{pending} Pending"
        lblKpiApprovedVal.Text = $"{approved} Approved"
        lblKpiRejectedVal.Text = $"{rejected} Rejected"
    End Sub

    Private Function BuildDisplayTable(raw As DataTable) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("ApplicationID", GetType(Integer))
        dt.Columns.Add("BorrowerID", GetType(Integer))
        dt.Columns.Add("App Ref", GetType(String))
        dt.Columns.Add("Borrower", GetType(String))
        dt.Columns.Add("Borrower UID", GetType(String))
        dt.Columns.Add("Loan Type", GetType(String))
        dt.Columns.Add("Principal (PHP)", GetType(Decimal))
        dt.Columns.Add("Rate (%)", GetType(Decimal))
        dt.Columns.Add("Total Payable (PHP)", GetType(Decimal))
        dt.Columns.Add("Term (mos)", GetType(Integer))
        dt.Columns.Add("Submitted Date", GetType(DateTime))
        dt.Columns.Add("Status", GetType(String))

        If raw IsNot Nothing Then
            For Each row As DataRow In raw.Rows
                Dim appID As Integer = CInt(row("ApplicationID"))
                Dim bID As Integer = If(row.Table.Columns.Contains("BorrowerID") AndAlso row("BorrowerID") IsNot DBNull.Value, CInt(row("BorrowerID")), 0)
                Dim bUID As String = If(row.Table.Columns.Contains("BorrowerUID") AndAlso row("BorrowerUID") IsNot DBNull.Value, row("BorrowerUID").ToString(), "")
                Dim bName As String = If(row("BorrowerName") IsNot DBNull.Value, row("BorrowerName").ToString(), "")
                Dim lType As String = If(row("LoanType") IsNot DBNull.Value, row("LoanType").ToString(), "")
                Dim principal As Decimal = If(row("PrincipalAmount") IsNot DBNull.Value, CDec(row("PrincipalAmount")), 0D)
                Dim rate As Decimal = If(row("InterestRate") IsNot DBNull.Value, CDec(row("InterestRate")), 0D)
                Dim totalPayable As Decimal = If(row("TotalPayable") IsNot DBNull.Value, CDec(row("TotalPayable")), 0D)
                Dim term As Integer = If(row("Term") IsNot DBNull.Value, CInt(row("Term")), 1)
                Dim subDate As DateTime = If(row("SubmittedAt") IsNot DBNull.Value, CDate(row("SubmittedAt")), DateTime.Today)
                Dim st As String = If(row("Status") IsNot DBNull.Value, row("Status").ToString(), "Pending")

                dt.Rows.Add(
                    appID,
                    bID,
                    $"APP-{appID:D4}",
                    bName,
                    bUID,
                    lType,
                    principal,
                    rate,
                    totalPayable,
                    term,
                    subDate,
                    st)
            Next
        End If
        Return dt
    End Function

    Private Sub ConfigureColumns()
        With dgvApplications
            If .Columns.Contains("ApplicationID") Then .Columns("ApplicationID").Visible = False
            If .Columns.Contains("BorrowerID") Then .Columns("BorrowerID").Visible = False

            If .Columns.Contains("App Ref") Then
                .Columns("App Ref").FillWeight = 11
                .Columns("App Ref").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("App Ref").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If

            If .Columns.Contains("Borrower") Then
                .Columns("Borrower").FillWeight = 18
                .Columns("Borrower").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("Borrower").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If

            If .Columns.Contains("Borrower UID") Then
                .Columns("Borrower UID").FillWeight = 12
                .Columns("Borrower UID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("Borrower UID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If

            If .Columns.Contains("Loan Type") Then
                .Columns("Loan Type").FillWeight = 14
                .Columns("Loan Type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("Loan Type").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If

            If .Columns.Contains("Principal (PHP)") Then
                .Columns("Principal (PHP)").DefaultCellStyle.Format = "N2"
                .Columns("Principal (PHP)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Principal (PHP)").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Principal (PHP)").FillWeight = 13
            End If

            If .Columns.Contains("Rate (%)") Then
                .Columns("Rate (%)").DefaultCellStyle.Format = "N2"
                .Columns("Rate (%)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Rate (%)").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Rate (%)").FillWeight = 8
            End If

            If .Columns.Contains("Total Payable (PHP)") Then
                .Columns("Total Payable (PHP)").DefaultCellStyle.Format = "N2"
                .Columns("Total Payable (PHP)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Total Payable (PHP)").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Total Payable (PHP)").FillWeight = 14
            End If

            If .Columns.Contains("Term (mos)") Then
                .Columns("Term (mos)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Term (mos)").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Term (mos)").FillWeight = 9
            End If

            If .Columns.Contains("Submitted Date") Then
                .Columns("Submitted Date").DefaultCellStyle.Format = "yyyy-MM-dd"
                .Columns("Submitted Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Submitted Date").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Submitted Date").FillWeight = 12
            End If

            If .Columns.Contains("Status") Then
                .Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Status").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Status").FillWeight = 10
            End If
        End With
    End Sub

    Private Sub ApplyFilter()
        If _fullData Is Nothing Then Return
        Dim statusFilter As String = ""
        Select Case cmbFilter.SelectedIndex
            Case 1 ' Pending
                statusFilter = "[Status] = 'Pending'"
            Case 2 ' Approved
                statusFilter = "[Status] = 'Approved'"
            Case 3 ' Rejected
                statusFilter = "[Status] = 'Rejected'"
        End Select

        Dim keyword As String = txtSearch.Text.Trim().Replace("'", "''")
        Dim searchFilter As String = ""
        If keyword <> "" Then
            searchFilter = $"([App Ref] LIKE '%{keyword}%' OR [Borrower] LIKE '%{keyword}%' OR [Borrower UID] LIKE '%{keyword}%' OR [Loan Type] LIKE '%{keyword}%')"
        End If

        Dim combined As String = ""
        If statusFilter <> "" AndAlso searchFilter <> "" Then
            combined = $"{statusFilter} AND {searchFilter}"
        ElseIf statusFilter <> "" Then
            combined = statusFilter
        ElseIf searchFilter <> "" Then
            combined = searchFilter
        End If

        _fullData.DefaultView.RowFilter = combined
        dgvApplications.DataSource = _fullData
        ConfigureColumns()
        dgvApplications.ClearSelection()
        lblRecordCount.Text = $"Showing {_fullData.DefaultView.Count} application record(s)"
    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilter.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub

    ' ── Print Action ──────────────────────────────────────────────
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ReportPrinter.PrintApplicants(Me)
    End Sub

    ' ── Approve Action ────────────────────────────────────────────
    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If dgvApplications.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an application to approve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = dgvApplications.SelectedRows(0)
        Dim appID As Integer = CInt(row.Cells("ApplicationID").Value)
        Dim appRef As String = row.Cells("App Ref").Value.ToString()
        Dim borrowerName As String = row.Cells("Borrower").Value.ToString()
        Dim principal As Decimal = CDec(row.Cells("Principal (PHP)").Value)
        Dim currentStatus As String = row.Cells("Status").Value.ToString()

        If currentStatus = "Approved" Then
            MessageBox.Show($"Application {appRef} has already been approved!", "Already Approved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If currentStatus = "Rejected" Then
            Dim confirmReApprove As DialogResult = MessageBox.Show(
                $"Application {appRef} was previously Rejected. Do you want to reconsider and approve it now?",
                "Re-Approve Application",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
            If confirmReApprove <> DialogResult.Yes Then Return
        Else
            Dim confirm As DialogResult = MessageBox.Show(
                $"Approve loan application {appRef} for {borrowerName}?" & vbCrLf & vbCrLf &
                $"Principal Amount: PHP {principal:N2}" & vbCrLf &
                "This will activate the loan and create an active loan account in the system.",
                "Confirm Loan Approval",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
            If confirm <> DialogResult.Yes Then Return
        End If

        Try
            Dim newLoanRef As String = ""
            Dim success As Boolean = LoanApplicationRepository.ApproveApplication(appID, SessionManager.CurrentUsername, newLoanRef)
            If success Then
                MessageBox.Show(
                    $"Loan application {appRef} approved successfully!" & vbCrLf & vbCrLf &
                    $"Official Loan Reference: {newLoanRef}" & vbCrLf &
                    $"Client: {borrowerName}",
                    "Loan Approved & Activated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
                LoadApplications()
            Else
                MessageBox.Show("Failed to approve application. Record could not be retrieved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Approval failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Reject Action ─────────────────────────────────────────────
    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If dgvApplications.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an application to reject.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = dgvApplications.SelectedRows(0)
        Dim appID As Integer = CInt(row.Cells("ApplicationID").Value)
        Dim appRef As String = row.Cells("App Ref").Value.ToString()
        Dim borrowerName As String = row.Cells("Borrower").Value.ToString()
        Dim currentStatus As String = row.Cells("Status").Value.ToString()

        If currentStatus = "Rejected" Then
            MessageBox.Show($"Application {appRef} is already marked as Rejected.", "Already Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If currentStatus = "Approved" Then
            MessageBox.Show($"Application {appRef} has already been approved and active loan records exist. It cannot be rejected.", "Cannot Reject", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show(
            $"Are you sure you want to reject loan application {appRef} for {borrowerName}?",
            "Confirm Rejection",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)
        If confirm <> DialogResult.Yes Then Return

        Try
            Dim success As Boolean = LoanApplicationRepository.RejectApplication(appID, SessionManager.CurrentUsername)
            If success Then
                MessageBox.Show($"Application {appRef} has been marked as Rejected.", "Application Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadApplications()
            Else
                MessageBox.Show("Failed to reject application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Rejection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── View Details Action ───────────────────────────────────────
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If dgvApplications.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an application to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim appID As Integer = CInt(dgvApplications.SelectedRows(0).Cells("ApplicationID").Value)
        Dim frm As New ViewLoanApplicationForm(appID)
        frm.ShowDialog()
        LoadApplications()
    End Sub

    Private Sub dgvApplications_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApplications.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim appID As Integer = CInt(dgvApplications.Rows(e.RowIndex).Cells("ApplicationID").Value)
            Dim frm As New ViewLoanApplicationForm(appID)
            frm.ShowDialog()
            LoadApplications()
        End If
    End Sub

    ' ── Hover Effects ─────────────────────────────────────────────
    Private Sub btnApprove_MouseEnter(sender As Object, e As EventArgs) Handles btnApprove.MouseEnter
        btnApprove.BackColor = Color.FromArgb(34, 142, 58)
    End Sub
    Private Sub btnApprove_MouseLeave(sender As Object, e As EventArgs) Handles btnApprove.MouseLeave
        btnApprove.BackColor = Color.FromArgb(40, 167, 69)
    End Sub

    Private Sub btnReject_MouseEnter(sender As Object, e As EventArgs) Handles btnReject.MouseEnter
        btnReject.BackColor = Color.FromArgb(189, 33, 48)
    End Sub
    Private Sub btnReject_MouseLeave(sender As Object, e As EventArgs) Handles btnReject.MouseLeave
        btnReject.BackColor = Color.FromArgb(220, 53, 69)
    End Sub

    Private Sub btnView_MouseEnter(sender As Object, e As EventArgs) Handles btnView.MouseEnter
        btnView.BackColor = Color.FromArgb(251, 108, 0)
    End Sub
    Private Sub btnView_MouseLeave(sender As Object, e As EventArgs) Handles btnView.MouseLeave
        btnView.BackColor = Color.FromArgb(231, 63, 30)
    End Sub

    ' ── Cell Formatting (Color-coded Status) ───────────────────────
    Private Sub dgvApplications_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvApplications.CellFormatting
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return
        If dgvApplications.Columns(e.ColumnIndex).Name = "Status" Then
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
        End If
    End Sub

End Class
