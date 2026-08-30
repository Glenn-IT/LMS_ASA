Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class AdminOverviewForm
    Inherits Form

    ' ── Controls ──────────────────────────────────────────────────
    Private pnlRoot As Panel
    Private pnlBanner As Panel
    Private picLogo As PictureBox
    Private lblBannerTitle As Label
    Private lblBannerSubtitle As Label
    Private btnRefresh As Button
    Private lblLastUpdated As Label

    ' KPI Cards
    Private pnlKpiContainer As TableLayoutPanel
    Private cardBorrowers As Panel
    Private cardActiveLoans As Panel
    Private cardDisbursements As Panel
    Private cardCollections As Panel
    Private cardOutstanding As Panel
    Private cardPendingApps As Panel

    ' Charts Container
    Private pnlChartsContainer As TableLayoutPanel
    Private pnlStatusChartCard As Panel
    Private pnlTypeChartCard As Panel
    Private pnlHealthChartCard As Panel

    ' Recent Tables Container
    Private pnlTablesContainer As TableLayoutPanel
    Private pnlRecentLoansCard As Panel
    Private pnlRecentPaymentsCard As Panel
    Private dgvRecentLoans As DataGridView
    Private dgvRecentPayments As DataGridView

    ' Data Caches
    Private _stats As DashboardSummaryStats
    Private _dtStatus As DataTable
    Private _dtType As DataTable
    Private _dtRecentLoans As DataTable
    Private _dtRecentPayments As DataTable

    Public Sub New()
        InitializeComponent()
        DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
    End Sub

    Private Sub InitializeComponent()
        pnlRoot = New Panel()
        pnlBanner = New Panel()
        picLogo = New PictureBox()
        lblBannerTitle = New Label()
        lblBannerSubtitle = New Label()
        btnRefresh = New Button()
        lblLastUpdated = New Label()

        pnlKpiContainer = New TableLayoutPanel()
        pnlChartsContainer = New TableLayoutPanel()
        pnlTablesContainer = New TableLayoutPanel()

        SuspendLayout()

        ' ── Root Panel with Scroll ────────────────────────────────
        pnlRoot.Dock = DockStyle.Fill
        pnlRoot.AutoScroll = True
        pnlRoot.BackColor = Color.FromArgb(245, 247, 250)
        pnlRoot.Padding = New Padding(20, 15, 20, 25)
        Controls.Add(pnlRoot)

        ' ── Banner Card ───────────────────────────────────────────
        pnlBanner.BackColor = Color.White
        pnlBanner.Dock = DockStyle.Top
        pnlBanner.Height = 90
        pnlBanner.Padding = New Padding(15, 12, 15, 12)
        pnlBanner.Margin = New Padding(0, 0, 0, 15)

        picLogo.Size = New Size(65, 65)
        picLogo.Location = New Point(15, 12)
        picLogo.SizeMode = PictureBoxSizeMode.Zoom
        picLogo.Image = AppTheme.GetLogoImage()
        pnlBanner.Controls.Add(picLogo)

        lblBannerTitle.Text = "System Analytics & Performance Dashboard"
        lblBannerTitle.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblBannerTitle.ForeColor = Color.FromArgb(231, 63, 30)
        lblBannerTitle.Location = New Point(90, 15)
        lblBannerTitle.AutoSize = True
        pnlBanner.Controls.Add(lblBannerTitle)

        lblBannerSubtitle.Text = "Real-time overview of borrowers, loan disbursements, payment collections, and portfolio health."
        lblBannerSubtitle.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        lblBannerSubtitle.ForeColor = Color.FromArgb(110, 115, 125)
        lblBannerSubtitle.Location = New Point(90, 43)
        lblBannerSubtitle.AutoSize = True
        pnlBanner.Controls.Add(lblBannerSubtitle)

        btnRefresh.Text = "🔄 Refresh Data"
        btnRefresh.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.White
        btnRefresh.BackColor = Color.FromArgb(231, 63, 30)
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.FlatAppearance.BorderSize = 0
        btnRefresh.Size = New Size(130, 36)
        btnRefresh.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefresh.Location = New Point(pnlBanner.Width - 145, 16)
        btnRefresh.Cursor = Cursors.Hand
        AddHandler btnRefresh.Click, AddressOf btnRefresh_Click
        pnlBanner.Controls.Add(btnRefresh)

        lblLastUpdated.Text = "Updated: " & DateTime.Now.ToString("hh:mm:ss tt")
        lblLastUpdated.Font = New Font("Segoe UI", 8.0F, FontStyle.Italic)
        lblLastUpdated.ForeColor = Color.FromArgb(150, 155, 165)
        lblLastUpdated.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblLastUpdated.Location = New Point(pnlBanner.Width - 180, 56)
        lblLastUpdated.Size = New Size(170, 20)
        lblLastUpdated.TextAlign = ContentAlignment.MiddleRight
        pnlBanner.Controls.Add(lblLastUpdated)

        pnlRoot.Controls.Add(pnlBanner)

        ' ── KPI Summary Cards Grid ────────────────────────────────
        pnlKpiContainer.Dock = DockStyle.Top
        pnlKpiContainer.Height = 110
        pnlKpiContainer.ColumnCount = 6
        pnlKpiContainer.RowCount = 1
        pnlKpiContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 16.66F))
        pnlKpiContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 16.66F))
        pnlKpiContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 16.66F))
        pnlKpiContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 16.66F))
        pnlKpiContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 16.66F))
        pnlKpiContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 16.7F))
        pnlKpiContainer.Margin = New Padding(0, 15, 0, 15)

        cardBorrowers = CreateKpiCard("👥 TOTAL BORROWERS", "0", "Registered Clients", Color.FromArgb(41, 128, 185))
        cardActiveLoans = CreateKpiCard("📄 ACTIVE LOANS", "0", "Active & Approved", Color.FromArgb(39, 174, 96))
        cardDisbursements = CreateKpiCard("💰 TOTAL DISBURSED", "₱0.00", "Principal Released", Color.FromArgb(231, 63, 30))
        cardCollections = CreateKpiCard("💵 TOTAL COLLECTED", "₱0.00", "Payments Received", Color.FromArgb(251, 108, 0))
        cardOutstanding = CreateKpiCard("⏳ OUTSTANDING", "₱0.00", "Remaining Balance", Color.FromArgb(211, 84, 0))
        cardPendingApps = CreateKpiCard("📋 PENDING APPS", "0", "Awaiting Review", Color.FromArgb(142, 68, 173))

        pnlKpiContainer.Controls.Add(cardBorrowers, 0, 0)
        pnlKpiContainer.Controls.Add(cardActiveLoans, 1, 0)
        pnlKpiContainer.Controls.Add(cardDisbursements, 2, 0)
        pnlKpiContainer.Controls.Add(cardCollections, 3, 0)
        pnlKpiContainer.Controls.Add(cardOutstanding, 4, 0)
        pnlKpiContainer.Controls.Add(cardPendingApps, 5, 0)

        pnlRoot.Controls.Add(pnlKpiContainer)

        ' ── Charts Container Grid ─────────────────────────────────
        pnlChartsContainer.Dock = DockStyle.Top
        pnlChartsContainer.Height = 310
        pnlChartsContainer.ColumnCount = 3
        pnlChartsContainer.RowCount = 1
        pnlChartsContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.0F))
        pnlChartsContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 43.0F))
        pnlChartsContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 23.0F))
        pnlChartsContainer.Margin = New Padding(0, 15, 0, 15)

        pnlStatusChartCard = CreateChartPanel("📊 Loan Portfolio by Status", AddressOf PaintStatusChart)
        pnlTypeChartCard = CreateChartPanel("📈 Disbursements vs Collections by Loan Type", AddressOf PaintTypeChart)
        pnlHealthChartCard = CreateChartPanel("🎯 Collection Efficiency", AddressOf PaintHealthGauge)

        pnlChartsContainer.Controls.Add(pnlStatusChartCard, 0, 0)
        pnlChartsContainer.Controls.Add(pnlTypeChartCard, 1, 0)
        pnlChartsContainer.Controls.Add(pnlHealthChartCard, 2, 0)

        pnlRoot.Controls.Add(pnlChartsContainer)

        ' ── Recent Tables Container ───────────────────────────────
        pnlTablesContainer.Dock = DockStyle.Top
        pnlTablesContainer.Height = 280
        pnlTablesContainer.ColumnCount = 2
        pnlTablesContainer.RowCount = 1
        pnlTablesContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        pnlTablesContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        pnlTablesContainer.Margin = New Padding(0, 15, 0, 20)

        pnlRecentLoansCard = CreateRecentLoansCard()
        pnlRecentPaymentsCard = CreateRecentPaymentsCard()

        pnlTablesContainer.Controls.Add(pnlRecentLoansCard, 0, 0)
        pnlTablesContainer.Controls.Add(pnlRecentPaymentsCard, 1, 0)

        pnlRoot.Controls.Add(pnlTablesContainer)

        ' Order controls from top to bottom
        pnlRoot.Controls.SetChildIndex(pnlTablesContainer, 0)
        pnlRoot.Controls.SetChildIndex(pnlChartsContainer, 1)
        pnlRoot.Controls.SetChildIndex(pnlKpiContainer, 2)
        pnlRoot.Controls.SetChildIndex(pnlBanner, 3)

        ' ── Form Settings ─────────────────────────────────────────
        BackColor = Color.FromArgb(245, 247, 250)
        ClientSize = New Size(1100, 780)
        Font = New Font("Segoe UI", 9.0F)
        Name = "AdminOverviewForm"
        Text = "Dashboard Overview"

        ResumeLayout(False)
    End Sub

    Private Sub AdminOverviewForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDashboardData()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        LoadDashboardData()
    End Sub

    Public Sub LoadDashboardData()
        Try
            Cursor = Cursors.WaitCursor
            _stats = DashboardRepository.GetSummaryStats()
            _dtStatus = DashboardRepository.GetLoansByStatus()
            _dtType = DashboardRepository.GetLoansByType()
            _dtRecentLoans = DashboardRepository.GetRecentLoans(5)
            _dtRecentPayments = DashboardRepository.GetRecentPayments(5)

            ' Update KPI Card values
            UpdateKpiCard(cardBorrowers, _stats.TotalBorrowers.ToString("N0"), "Registered Clients")
            UpdateKpiCard(cardActiveLoans, _stats.ActiveLoansCount.ToString("N0"), $"Total: {_stats.TotalLoansCount}")
            UpdateKpiCard(cardDisbursements, "₱" & _stats.TotalDisbursed.ToString("N2"), "Principal Released")
            UpdateKpiCard(cardCollections, "₱" & _stats.TotalCollections.ToString("N2"), "Total Received")
            UpdateKpiCard(cardOutstanding, "₱" & _stats.TotalOutstanding.ToString("N2"), "Remaining Balance")
            UpdateKpiCard(cardPendingApps, _stats.PendingApplicationsCount.ToString("N0"), "Awaiting Review")

            lblLastUpdated.Text = "Updated: " & DateTime.Now.ToString("hh:mm:ss tt")

            ' Bind tables
            BindRecentLoans()
            BindRecentPayments()

            ' Repaint chart panels
            pnlStatusChartCard.Invalidate()
            pnlTypeChartCard.Invalidate()
            pnlHealthChartCard.Invalidate()

        Catch ex As Exception
            MessageBox.Show("Failed to load dashboard metrics:" & vbCrLf & ex.Message, "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    ' ── KPI Card Factory ──────────────────────────────────────────
    Private Function CreateKpiCard(title As String, value As String, subText As String, accentColor As Color) As Panel
        Dim card As New Panel()
        card.Dock = DockStyle.Fill
        card.BackColor = Color.White
        card.Margin = New Padding(4, 0, 4, 0)
        card.Padding = New Padding(12, 10, 10, 10)

        ' Left accent bar
        Dim bar As New Panel()
        bar.Dock = DockStyle.Left
        bar.Width = 5
        bar.BackColor = accentColor
        card.Controls.Add(bar)

        Dim lblTitle As New Label()
        lblTitle.Text = title
        lblTitle.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(120, 125, 135)
        lblTitle.Location = New Point(15, 8)
        lblTitle.Size = New Size(card.Width - 20, 16)
        lblTitle.Name = "lblTitle"
        card.Controls.Add(lblTitle)

        Dim lblVal As New Label()
        lblVal.Text = value
        lblVal.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        lblVal.ForeColor = Color.FromArgb(35, 35, 45)
        lblVal.Location = New Point(14, 26)
        lblVal.Size = New Size(card.Width - 18, 30)
        lblVal.Name = "lblVal"
        card.Controls.Add(lblVal)

        Dim lblSub As New Label()
        lblSub.Text = subText
        lblSub.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular)
        lblSub.ForeColor = Color.FromArgb(150, 155, 165)
        lblSub.Location = New Point(15, 58)
        lblSub.Size = New Size(card.Width - 20, 16)
        lblSub.Name = "lblSub"
        card.Controls.Add(lblSub)

        Return card
    End Function

    Private Sub UpdateKpiCard(card As Panel, value As String, subText As String)
        For Each c As Control In card.Controls
            If c.Name = "lblVal" Then c.Text = value
            If c.Name = "lblSub" Then c.Text = subText
        Next
    End Sub

    ' ── Chart Panel Factory ───────────────────────────────────────
    Private Function CreateChartPanel(title As String, paintHandler As PaintEventHandler) As Panel
        Dim card As New Panel()
        card.Dock = DockStyle.Fill
        card.BackColor = Color.White
        card.Margin = New Padding(5, 0, 5, 0)
        card.Padding = New Padding(12, 10, 12, 10)

        Dim lblHeader As New Label()
        lblHeader.Text = title
        lblHeader.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblHeader.ForeColor = Color.FromArgb(45, 50, 60)
        lblHeader.Dock = DockStyle.Top
        lblHeader.Height = 28
        card.Controls.Add(lblHeader)

        AddHandler card.Paint, paintHandler
        Return card
    End Function

    ' ── Status Donut Chart Painter ────────────────────────────────
    Private Sub PaintStatusChart(sender As Object, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim pnl As Panel = CType(sender, Panel)
        Dim clientW As Integer = pnl.ClientSize.Width
        Dim clientH As Integer = pnl.ClientSize.Height

        If _dtStatus Is Nothing OrElse _dtStatus.Rows.Count = 0 OrElse _stats Is Nothing OrElse _stats.TotalLoansCount = 0 Then
            Dim sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
            g.DrawString("No loan records found to display.", New Font("Segoe UI", 9.5F, FontStyle.Italic), Brushes.Gray, New RectangleF(0, 30, clientW, clientH - 30), sfCenter)
            Return
        End If

        ' Color palette for statuses
        Dim colors As Color() = {
            Color.FromArgb(39, 174, 96),   ' Active - Green
            Color.FromArgb(41, 128, 185),  ' Approved - Blue
            Color.FromArgb(243, 156, 18),  ' Pending - Amber
            Color.FromArgb(142, 68, 173),  ' Paid - Purple
            Color.FromArgb(231, 76, 60),   ' Overdue - Red
            Color.FromArgb(127, 140, 141), ' Closed - Gray
            Color.FromArgb(22, 160, 133)   ' Other - Teal
        }

        Dim totalLoans As Integer = _stats.TotalLoansCount
        Dim topMargin As Integer = 40
        Dim availH As Integer = clientH - topMargin - 15
        Dim chartSize As Integer = Math.Max(110, Math.Min(160, availH))
        Dim chartY As Integer = topMargin + (availH - chartSize) \ 2
        Dim chartRect As New Rectangle(14, chartY, chartSize, chartSize)
        Dim startAngle As Single = 0.0F

        For i As Integer = 0 To _dtStatus.Rows.Count - 1
            Dim count As Integer = Convert.ToInt32(_dtStatus.Rows(i)("Count"))
            Dim sweepAngle As Single = (CSng(count) / CSng(totalLoans)) * 360.0F
            Dim brushColor As Color = colors(i Mod colors.Length)

            Using b As New SolidBrush(brushColor)
                g.FillPie(b, chartRect, startAngle, sweepAngle)
            End Using

            startAngle += sweepAngle
        Next

        ' Donut Hole
        Dim holeSize As Integer = CInt(chartSize * 0.52)
        Dim holeRect As New Rectangle(chartRect.X + (chartSize - holeSize) \ 2, chartRect.Y + (chartSize - holeSize) \ 2, holeSize, holeSize)
        Using bHole As New SolidBrush(Color.White)
            g.FillEllipse(bHole, holeRect)
        End Using

        ' Center text inside Donut
        Dim sfDonutVal As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
        Dim numRect As New Rectangle(holeRect.X, holeRect.Y - 4, holeRect.Width, holeRect.Height \ 2 + 6)
        Dim lblRect As New Rectangle(holeRect.X, holeRect.Y + holeRect.Height \ 2 - 2, holeRect.Width, holeRect.Height \ 2)
        g.DrawString(totalLoans.ToString(), New Font("Segoe UI", 13.0F, FontStyle.Bold), Brushes.Black, numRect, sfDonutVal)
        g.DrawString("Loans", New Font("Segoe UI", 7.5F, FontStyle.Regular), Brushes.Gray, lblRect, sfDonutVal)

        ' Legend on the right with vertical centering
        Dim legX As Integer = chartRect.Right + 14
        Dim rowCount As Integer = Math.Min(_dtStatus.Rows.Count, 6)
        Dim itemH As Integer = 24
        Dim totalLegH As Integer = rowCount * itemH
        Dim startLegY As Integer = Math.Max(topMargin, chartY + (chartSize - totalLegH) \ 2)

        For i As Integer = 0 To rowCount - 1
            Dim statusName As String = _dtStatus.Rows(i)("Status").ToString()
            Dim count As Integer = Convert.ToInt32(_dtStatus.Rows(i)("Count"))
            Dim pct As Double = (CDbl(count) / CDbl(totalLoans)) * 100.0
            Dim brushColor As Color = colors(i Mod colors.Length)
            Dim curLegY As Integer = startLegY + (i * itemH)

            ' Color square badge
            Using b As New SolidBrush(brushColor)
                g.FillRectangle(b, legX, curLegY + 4, 11, 11)
            End Using

            ' Legend text perfectly vertically aligned
            Dim legText As String = $"{statusName}: {count} ({pct:F0}%)"
            Using bTxt As New SolidBrush(Color.FromArgb(50, 55, 65))
                g.DrawString(legText, New Font("Segoe UI", 8.5F, FontStyle.Regular), bTxt, legX + 16, curLegY + 1)
            End Using
        Next
    End Sub

    ' ── Type Bar Chart Painter ────────────────────────────────────
    Private Sub PaintTypeChart(sender As Object, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim pnl As Panel = CType(sender, Panel)
        Dim clientW As Integer = pnl.ClientSize.Width
        Dim clientH As Integer = pnl.ClientSize.Height

        If _dtType Is Nothing OrElse _dtType.Rows.Count = 0 Then
            Dim sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
            g.DrawString("No loan type distribution data available.", New Font("Segoe UI", 9.5F, FontStyle.Italic), Brushes.Gray, New RectangleF(0, 30, clientW, clientH - 30), sfCenter)
            Return
        End If

        ' Find max principal for scaling
        Dim maxVal As Decimal = 1D
        For Each r As DataRow In _dtType.Rows
            Dim p As Decimal = Convert.ToDecimal(r("TotalPrincipal"))
            If p > maxVal Then maxVal = p
        Next

        ' Calculate dynamic label width so text NEVER overlaps bars
        Dim typeFont As New Font("Segoe UI", 8.5F, FontStyle.Bold)
        Dim maxMeasuredWidth As Single = 0F
        For Each r As DataRow In _dtType.Rows
            Dim sz As SizeF = g.MeasureString(r("LoanType").ToString(), typeFont)
            If sz.Width > maxMeasuredWidth Then maxMeasuredWidth = sz.Width
        Next
        Dim labelW As Integer = Math.Max(135, CInt(Math.Ceiling(maxMeasuredWidth)) + 14)

        ' Legend at Top Right
        Dim legRightX As Integer = clientW - 155
        If legRightX > labelW + 40 Then
            Using bDisp As New SolidBrush(Color.FromArgb(231, 63, 30)), bPaid As New SolidBrush(Color.FromArgb(39, 174, 96))
                g.FillRectangle(bDisp, legRightX, 10, 9, 9)
                g.DrawString("Disbursed", New Font("Segoe UI", 7.5F), Brushes.Gray, legRightX + 12, 8)
                g.FillRectangle(bPaid, legRightX + 75, 10, 9, 9)
                g.DrawString("Collected", New Font("Segoe UI", 7.5F), Brushes.Gray, legRightX + 87, 8)
            End Using
        End If

        Dim startY As Integer = 40
        Dim rowCount As Integer = Math.Min(_dtType.Rows.Count, 5)
        Dim availH As Integer = clientH - startY - 10
        Dim rowH As Integer = Math.Min(48, availH \ Math.Max(1, rowCount))
        Dim barStartX As Integer = labelW + 6
        Dim valLabelW As Integer = 72
        Dim barMaxW As Integer = Math.Max(50, clientW - barStartX - valLabelW - 12)

        Dim sfLabel As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .Trimming = StringTrimming.EllipsisCharacter}

        For i As Integer = 0 To rowCount - 1
            Dim typeName As String = _dtType.Rows(i)("LoanType").ToString()
            Dim principal As Decimal = Convert.ToDecimal(_dtType.Rows(i)("TotalPrincipal"))
            Dim paid As Decimal = Convert.ToDecimal(_dtType.Rows(i)("TotalPaid"))
            Dim curY As Integer = startY + (i * rowH)

            ' Draw Type Label perfectly vertically centered and separated
            Dim labelRect As New RectangleF(10, curY, labelW - 12, rowH - 4)
            Using bLabel As New SolidBrush(Color.FromArgb(40, 45, 55))
                g.DrawString(typeName, typeFont, bLabel, labelRect, sfLabel)
            End Using

            ' Background Track for Bars
            Using bTrack As New SolidBrush(Color.FromArgb(243, 245, 248))
                g.FillRectangle(bTrack, barStartX, curY + 6, barMaxW, 9)
                g.FillRectangle(bTrack, barStartX, curY + 18, barMaxW, 9)
            End Using

            ' Principal Disbursed Bar (Red)
            Dim pWidth As Integer = CInt((principal / maxVal) * barMaxW)
            If pWidth < 3 AndAlso principal > 0 Then pWidth = 3
            Using b As New SolidBrush(Color.FromArgb(231, 63, 30))
                g.FillRectangle(b, barStartX, curY + 6, pWidth, 9)
            End Using

            ' Paid Collected Bar (Green)
            Dim paidWidth As Integer = If(paid > 0, Math.Max(3, CInt((paid / maxVal) * barMaxW)), 0)
            If paidWidth > 0 Then
                Using b As New SolidBrush(Color.FromArgb(39, 174, 96))
                    g.FillRectangle(b, barStartX, curY + 18, paidWidth, 9)
                End Using
            End If

            ' Amount Label (formatted neatly to the right of the longest bar)
            Dim maxBarEnd As Integer = barStartX + Math.Max(pWidth, paidWidth)
            Dim textX As Integer = Math.Min(clientW - valLabelW, maxBarEnd + 6)
            Using bVal As New SolidBrush(Color.FromArgb(70, 75, 85))
                g.DrawString("₱" & principal.ToString("N0"), New Font("Segoe UI", 7.5F, FontStyle.Bold), bVal, textX, curY + 4)
            End Using
            If paid > 0 Then
                Using bPaidVal As New SolidBrush(Color.FromArgb(39, 174, 96))
                    g.DrawString("₱" & paid.ToString("N0"), New Font("Segoe UI", 7.0F, FontStyle.Regular), bPaidVal, textX, curY + 17)
                End Using
            End If
        Next
    End Sub

    ' ── Collection Health Gauge Painter ───────────────────────────
    Private Sub PaintHealthGauge(sender As Object, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim pnl As Panel = CType(sender, Panel)
        Dim clientW As Integer = pnl.ClientSize.Width
        Dim clientH As Integer = pnl.ClientSize.Height

        Dim rate As Double = If(_stats IsNot Nothing, _stats.CollectionRate, 0.0)
        Dim gaugeRect As New Rectangle((clientW - 130) \ 2, 45, 130, 130)

        ' Background Track Arc
        Using pTrack As New Pen(Color.FromArgb(235, 238, 242), 14)
            g.DrawArc(pTrack, gaugeRect, 135, 270)
        End Using

        ' Progress Arc
        Dim sweep As Single = CSng((rate / 100.0) * 270.0)
        Dim progressColor As Color = Color.FromArgb(39, 174, 96)
        If rate < 50.0 Then
            progressColor = Color.FromArgb(231, 76, 60)
        ElseIf rate < 75.0 Then
            progressColor = Color.FromArgb(243, 156, 18)
        End If

        Using pProg As New Pen(progressColor, 14)
            pProg.StartCap = LineCap.Round
            pProg.EndCap = LineCap.Round
            If sweep > 0 Then g.DrawArc(pProg, gaugeRect, 135, sweep)
        End Using

        ' Percentage Text
        Dim sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
        g.DrawString($"{rate:F1}%", New Font("Segoe UI", 16.0F, FontStyle.Bold), Brushes.Black, gaugeRect, sfCenter)

        ' Subtitle summary text below gauge
        Dim infoY As Integer = gaugeRect.Bottom + 12
        Dim sfInfo As New StringFormat() With {.Alignment = StringAlignment.Center}
        g.DrawString("Repayment Collection Rate", New Font("Segoe UI", 8.5F, FontStyle.Bold), Brushes.DimGray, New RectangleF(0, infoY, clientW, 20), sfInfo)

        Dim healthStatus As String = "Portfolio Status: Excellent"
        If rate < 50.0 Then
            healthStatus = "Portfolio Status: Needs Attention"
        ElseIf rate < 75.0 Then
            healthStatus = "Portfolio Status: Moderate"
        End If
        g.DrawString(healthStatus, New Font("Segoe UI", 8.0F, FontStyle.Regular), Brushes.Gray, New RectangleF(0, infoY + 20, clientW, 20), sfInfo)
    End Sub

    ' ── Recent Loans Card ─────────────────────────────────────────
    Private Function CreateRecentLoansCard() As Panel
        Dim card As New Panel()
        card.Dock = DockStyle.Fill
        card.BackColor = Color.White
        card.Margin = New Padding(5, 0, 5, 0)
        card.Padding = New Padding(12, 10, 12, 10)

        Dim pnlHeader As New Panel()
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 32

        Dim lblTitle As New Label()
        lblTitle.Text = "📋 Recent Loans Disbursed"
        lblTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(45, 50, 60)
        lblTitle.Dock = DockStyle.Left
        lblTitle.AutoSize = True
        pnlHeader.Controls.Add(lblTitle)
        card.Controls.Add(pnlHeader)

        dgvRecentLoans = New DataGridView()
        dgvRecentLoans.Dock = DockStyle.Fill
        dgvRecentLoans.BackgroundColor = Color.White
        dgvRecentLoans.BorderStyle = BorderStyle.None
        dgvRecentLoans.AllowUserToAddRows = False
        dgvRecentLoans.AllowUserToDeleteRows = False
        dgvRecentLoans.ReadOnly = True
        dgvRecentLoans.RowHeadersVisible = False
        dgvRecentLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRecentLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvRecentLoans.EnableHeadersVisualStyles = False
        dgvRecentLoans.ColumnHeadersHeight = 28
        dgvRecentLoans.RowTemplate.Height = 28
        dgvRecentLoans.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250)
        dgvRecentLoans.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(80, 85, 95)
        dgvRecentLoans.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        dgvRecentLoans.DefaultCellStyle.Font = New Font("Segoe UI", 8.5F)
        dgvRecentLoans.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 237, 220)
        dgvRecentLoans.DefaultCellStyle.SelectionForeColor = Color.Black

        card.Controls.Add(dgvRecentLoans)
        dgvRecentLoans.BringToFront()
        Return card
    End Function

    Private Sub BindRecentLoans()
        If _dtRecentLoans Is Nothing Then Return
        dgvRecentLoans.DataSource = _dtRecentLoans

        If dgvRecentLoans.Columns.Contains("LoanID") Then dgvRecentLoans.Columns("LoanID").Visible = False
        If dgvRecentLoans.Columns.Contains("CreatedAt") Then dgvRecentLoans.Columns("CreatedAt").Visible = False

        If dgvRecentLoans.Columns.Contains("LoanReferenceID") Then
            dgvRecentLoans.Columns("LoanReferenceID").HeaderText = "Ref ID"
            dgvRecentLoans.Columns("LoanReferenceID").FillWeight = 22
        End If
        If dgvRecentLoans.Columns.Contains("BorrowerName") Then
            dgvRecentLoans.Columns("BorrowerName").HeaderText = "Borrower"
            dgvRecentLoans.Columns("BorrowerName").FillWeight = 30
        End If
        If dgvRecentLoans.Columns.Contains("LoanType") Then
            dgvRecentLoans.Columns("LoanType").HeaderText = "Type"
            dgvRecentLoans.Columns("LoanType").FillWeight = 20
        End If
        If dgvRecentLoans.Columns.Contains("PrincipalAmount") Then
            dgvRecentLoans.Columns("PrincipalAmount").HeaderText = "Principal"
            dgvRecentLoans.Columns("PrincipalAmount").DefaultCellStyle.Format = "₱#,##0.00"
            dgvRecentLoans.Columns("PrincipalAmount").FillWeight = 20
        End If
        If dgvRecentLoans.Columns.Contains("Status") Then
            dgvRecentLoans.Columns("Status").HeaderText = "Status"
            dgvRecentLoans.Columns("Status").FillWeight = 18
        End If
    End Sub

    ' ── Recent Payments Card ──────────────────────────────────────
    Private Function CreateRecentPaymentsCard() As Panel
        Dim card As New Panel()
        card.Dock = DockStyle.Fill
        card.BackColor = Color.White
        card.Margin = New Padding(5, 0, 5, 0)
        card.Padding = New Padding(12, 10, 12, 10)

        Dim pnlHeader As New Panel()
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 32

        Dim lblTitle As New Label()
        lblTitle.Text = "💳 Recent Payments Collected"
        lblTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(45, 50, 60)
        lblTitle.Dock = DockStyle.Left
        lblTitle.AutoSize = True
        pnlHeader.Controls.Add(lblTitle)
        card.Controls.Add(pnlHeader)

        dgvRecentPayments = New DataGridView()
        dgvRecentPayments.Dock = DockStyle.Fill
        dgvRecentPayments.BackgroundColor = Color.White
        dgvRecentPayments.BorderStyle = BorderStyle.None
        dgvRecentPayments.AllowUserToAddRows = False
        dgvRecentPayments.AllowUserToDeleteRows = False
        dgvRecentPayments.ReadOnly = True
        dgvRecentPayments.RowHeadersVisible = False
        dgvRecentPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRecentPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvRecentPayments.EnableHeadersVisualStyles = False
        dgvRecentPayments.ColumnHeadersHeight = 28
        dgvRecentPayments.RowTemplate.Height = 28
        dgvRecentPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250)
        dgvRecentPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(80, 85, 95)
        dgvRecentPayments.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        dgvRecentPayments.DefaultCellStyle.Font = New Font("Segoe UI", 8.5F)
        dgvRecentPayments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 237, 220)
        dgvRecentPayments.DefaultCellStyle.SelectionForeColor = Color.Black

        card.Controls.Add(dgvRecentPayments)
        dgvRecentPayments.BringToFront()
        Return card
    End Function

    Private Sub BindRecentPayments()
        If _dtRecentPayments Is Nothing Then Return
        dgvRecentPayments.DataSource = _dtRecentPayments

        If dgvRecentPayments.Columns.Contains("PaymentID") Then dgvRecentPayments.Columns("PaymentID").Visible = False

        If dgvRecentPayments.Columns.Contains("LoanReferenceID") Then
            dgvRecentPayments.Columns("LoanReferenceID").HeaderText = "Ref ID"
            dgvRecentPayments.Columns("LoanReferenceID").FillWeight = 20
        End If
        If dgvRecentPayments.Columns.Contains("BorrowerName") Then
            dgvRecentPayments.Columns("BorrowerName").HeaderText = "Borrower"
            dgvRecentPayments.Columns("BorrowerName").FillWeight = 28
        End If
        If dgvRecentPayments.Columns.Contains("Amount") Then
            dgvRecentPayments.Columns("Amount").HeaderText = "Amount Paid"
            dgvRecentPayments.Columns("Amount").DefaultCellStyle.Format = "₱#,##0.00"
            dgvRecentPayments.Columns("Amount").FillWeight = 22
        End If
        If dgvRecentPayments.Columns.Contains("PaymentDate") Then
            dgvRecentPayments.Columns("PaymentDate").HeaderText = "Date"
            dgvRecentPayments.Columns("PaymentDate").DefaultCellStyle.Format = "yyyy-MM-dd"
            dgvRecentPayments.Columns("PaymentDate").FillWeight = 18
        End If
        If dgvRecentPayments.Columns.Contains("Status") Then
            dgvRecentPayments.Columns("Status").HeaderText = "Status"
            dgvRecentPayments.Columns("Status").FillWeight = 16
        End If
    End Sub

End Class
