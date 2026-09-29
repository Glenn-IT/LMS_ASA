Imports System.Data
Imports System.Diagnostics
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Windows.Forms

''' <summary>
''' Generates professional, publication-quality printable reports for loan applicants 
''' and registered borrowers, styled with ASA Philippines Foundation branding and 
''' automatically redirected to Google Chrome or the default browser for PDF preview and printing.
''' </summary>
Public Class ReportPrinter

    Public Enum ReportType
        ApplicantsOnly
        BorrowersOnly
        Combined
    End Enum

    ' ── Public Entry Points ───────────────────────────────────────

    ''' <summary>
    ''' Generates and redirects the Loan Applicants report to the browser for printing/saving as PDF.
    ''' </summary>
    Public Shared Sub PrintApplicants(Optional owner As IWin32Window = Nothing)
        Try
            Dim dt = LoanApplicationRepository.GetAll()
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                MessageBox.Show("There are no loan applicants found in the database to print.",
                                "Report Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim htmlContent = GenerateApplicantsHtml(dt)
            Dim filePath = SaveTempReport(htmlContent, "Loan_Applicants_Report")
            OpenReportInBrowser(filePath)

            ActivityLogger.Log(SessionManager.CurrentUsername, "Success",
                               $"Redirected Loan Applicants Report to browser for printing ({dt.Rows.Count} records).")
        Catch ex As Exception
            MessageBox.Show($"Unable to generate Loan Applicants Report:" & vbCrLf & ex.Message,
                            "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Generates and redirects the Registered Borrowers report to the browser for printing/saving as PDF.
    ''' </summary>
    Public Shared Sub PrintBorrowers(Optional owner As IWin32Window = Nothing)
        Try
            Dim dt = BorrowerRepository.GetAll()
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                MessageBox.Show("There are no borrower records found in the database to print.",
                                "Report Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim htmlContent = GenerateBorrowersHtml(dt)
            Dim filePath = SaveTempReport(htmlContent, "Registered_Borrowers_Report")
            OpenReportInBrowser(filePath)

            ActivityLogger.Log(SessionManager.CurrentUsername, "Success",
                               $"Redirected Registered Borrowers Report to browser for printing ({dt.Rows.Count} records).")
        Catch ex As Exception
            MessageBox.Show($"Unable to generate Borrowers Report:" & vbCrLf & ex.Message,
                            "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Generates and redirects a combined audit report of both borrowers and applicants to the browser.
    ''' </summary>
    Public Shared Sub PrintCombined(Optional owner As IWin32Window = Nothing)
        Try
            Dim dtBorrowers = BorrowerRepository.GetAll()
            Dim dtApplicants = LoanApplicationRepository.GetAll()

            Dim borrowerCount = If(dtBorrowers IsNot Nothing, dtBorrowers.Rows.Count, 0)
            Dim applicantCount = If(dtApplicants IsNot Nothing, dtApplicants.Rows.Count, 0)

            If borrowerCount = 0 AndAlso applicantCount = 0 Then
                MessageBox.Show("No borrower or applicant records were found in the database to print.",
                                "Report Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim htmlContent = GenerateCombinedHtml(dtBorrowers, dtApplicants)
            Dim filePath = SaveTempReport(htmlContent, "LMS_Combined_Master_Report")
            OpenReportInBrowser(filePath)

            ActivityLogger.Log(SessionManager.CurrentUsername, "Success",
                               $"Redirected Combined Report to browser for printing ({borrowerCount} borrowers, {applicantCount} applicants).")
        Catch ex As Exception
            MessageBox.Show($"Unable to generate Combined Report:" & vbCrLf & ex.Message,
                            "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── HTML Generation: Applicants ───────────────────────────────
    Private Shared Function GenerateApplicantsHtml(dt As DataTable) As String
        Dim totalCount = dt.Rows.Count
        Dim pendingCount = 0
        Dim approvedCount = 0
        Dim rejectedCount = 0
        Dim totalPrincipal As Decimal = 0D
        Dim totalPayable As Decimal = 0D

        For Each row As DataRow In dt.Rows
            Dim st = If(row("Status") IsNot DBNull.Value, row("Status").ToString().Trim().ToLower(), "")
            Select Case st
                Case "approved", "active"
                    approvedCount += 1
                Case "rejected", "declined"
                    rejectedCount += 1
                Case Else
                    pendingCount += 1
            End Select
            If row("PrincipalAmount") IsNot DBNull.Value Then totalPrincipal += CDec(row("PrincipalAmount"))
            If row("TotalPayable") IsNot DBNull.Value Then totalPayable += CDec(row("TotalPayable"))
        Next

        Dim sbRows As New StringBuilder()
        Dim idx As Integer = 1
        For Each row As DataRow In dt.Rows
            Dim appID As Integer = CInt(row("ApplicationID"))
            Dim appRef As String = $"APP-{appID:D4}"
            Dim bName As String = WebUtility.HtmlEncode(If(row("BorrowerName") IsNot DBNull.Value, row("BorrowerName").ToString(), "N/A"))
            Dim bUID As String = WebUtility.HtmlEncode(If(row.Table.Columns.Contains("BorrowerUID") AndAlso row("BorrowerUID") IsNot DBNull.Value, row("BorrowerUID").ToString(), "N/A"))
            Dim loanType As String = WebUtility.HtmlEncode(If(row("LoanType") IsNot DBNull.Value, row("LoanType").ToString(), "N/A"))
            Dim principal As Decimal = If(row("PrincipalAmount") IsNot DBNull.Value, CDec(row("PrincipalAmount")), 0D)
            Dim rate As Decimal = If(row("InterestRate") IsNot DBNull.Value, CDec(row("InterestRate")), 0D)
            Dim term As Integer = If(row("Term") IsNot DBNull.Value, CInt(row("Term")), 1)
            Dim payable As Decimal = If(row("TotalPayable") IsNot DBNull.Value, CDec(row("TotalPayable")), 0D)
            Dim stRaw As String = If(row("Status") IsNot DBNull.Value, row("Status").ToString().Trim(), "Pending")
            Dim submitted As String = If(row("SubmittedAt") IsNot DBNull.Value, CDate(row("SubmittedAt")).ToString("yyyy-MM-dd"), "-")

            Dim badgeClass = "badge-pending"
            Select Case stRaw.ToLower()
                Case "approved", "active"
                    badgeClass = "badge-approved"
                Case "rejected", "declined"
                    badgeClass = "badge-rejected"
            End Select

            sbRows.Append($"" &
                $"<tr>" &
                $"<td class='text-center'>{idx}</td>" &
                $"<td class='text-center font-mono font-bold'>{appRef}</td>" &
                $"<td class='font-bold'>{bName}</td>" &
                $"<td class='text-center font-mono'>{bUID}</td>" &
                $"<td>{loanType}</td>" &
                $"<td class='text-right'>₱{principal:N2}</td>" &
                $"<td class='text-center'>{rate:0.#}%</td>" &
                $"<td class='text-center'>{term} mo</td>" &
                $"<td class='text-right font-bold'>₱{payable:N2}</td>" &
                $"<td class='text-center'><span class='badge {badgeClass}'>{WebUtility.HtmlEncode(stRaw)}</span></td>" &
                $"<td class='text-center'>{submitted}</td>" &
                $"</tr>")
            idx += 1
        Next

        Dim summaryHtml = $"" &
            $"<div class='summary-card'>" &
            $"  <div class='summary-title'>📊 Loan Applicants Summary Statistics</div>" &
            $"  <div class='summary-grid'>" &
            $"    <div class='summary-item'><div class='summary-label'>Total Applications</div><div class='summary-value highlight'>{totalCount:N0}</div></div>" &
            $"    <div class='summary-item'><div class='summary-label'>Pending Review</div><div class='summary-value' style='color:#B45309;'>{pendingCount:N0}</div></div>" &
            $"    <div class='summary-item'><div class='summary-label'>Approved</div><div class='summary-value' style='color:#047857;'>{approvedCount:N0}</div></div>" &
            $"    <div class='summary-item'><div class='summary-label'>Rejected</div><div class='summary-value' style='color:#B91C1C;'>{rejectedCount:N0}</div></div>" &
            $"    <div class='summary-item'><div class='summary-label'>Total Principal</div><div class='summary-value'>₱{totalPrincipal:N2}</div></div>" &
            $"    <div class='summary-item'><div class='summary-label'>Total Payable Value</div><div class='summary-value highlight'>₱{totalPayable:N2}</div></div>" &
            $"  </div>" &
            $"</div>"

        Dim tableHtml = $"" &
            $"<table>" &
            $"  <thead>" &
            $"    <tr>" &
            $"      <th style='width:35px;' class='text-center'>#</th>" &
            $"      <th style='width:85px;' class='text-center'>App Ref</th>" &
            $"      <th>Borrower Name</th>" &
            $"      <th style='width:90px;' class='text-center'>Borrower UID</th>" &
            $"      <th style='width:125px;'>Loan Type</th>" &
            $"      <th style='width:105px;' class='text-right'>Principal (PHP)</th>" &
            $"      <th style='width:55px;' class='text-center'>Rate</th>" &
            $"      <th style='width:55px;' class='text-center'>Term</th>" &
            $"      <th style='width:115px;' class='text-right'>Total Payable</th>" &
            $"      <th style='width:85px;' class='text-center'>Status</th>" &
            $"      <th style='width:95px;' class='text-center'>Applied Date</th>" &
            $"    </tr>" &
            $"  </thead>" &
            $"  <tbody>" &
            sbRows.ToString() &
            $"  </tbody>" &
            $"</table>"

        Return BuildHtmlDocument("MASTERLIST OF LOAN APPLICANTS",
                                 "Official register of all submitted loan applications, terms, and approval statuses",
                                 tableHtml, summaryHtml)
    End Function

    ' ── HTML Generation: Borrowers ────────────────────────────────
    Private Shared Function GenerateBorrowersHtml(dt As DataTable) As String
        Dim totalCount = dt.Rows.Count
        Dim withContact = 0
        Dim withEmail = 0

        For Each row As DataRow In dt.Rows
            If row("Contact") IsNot DBNull.Value AndAlso Not String.IsNullOrWhiteSpace(row("Contact").ToString()) Then withContact += 1
            If row("Email") IsNot DBNull.Value AndAlso Not String.IsNullOrWhiteSpace(row("Email").ToString()) Then withEmail += 1
        Next

        Dim sbRows As New StringBuilder()
        Dim idx As Integer = 1
        For Each row As DataRow In dt.Rows
            Dim bUID As String = WebUtility.HtmlEncode(If(row("BorrowerUID") IsNot DBNull.Value, row("BorrowerUID").ToString(), "N/A"))
            Dim first As String = If(row("FirstName") IsNot DBNull.Value, row("FirstName").ToString().Trim(), "")
            Dim middle As String = If(row.Table.Columns.Contains("MiddleName") AndAlso row("MiddleName") IsNot DBNull.Value AndAlso Not String.IsNullOrWhiteSpace(row("MiddleName").ToString()), row("MiddleName").ToString().Trim() & " ", "")
            Dim last As String = If(row("LastName") IsNot DBNull.Value, row("LastName").ToString().Trim(), "")
            Dim fullName As String = WebUtility.HtmlEncode($"{first} {middle}{last}".Trim())
            If String.IsNullOrWhiteSpace(fullName) Then fullName = "N/A"

            Dim age As String = WebUtility.HtmlEncode(If(row("Age") IsNot DBNull.Value, row("Age").ToString(), "-"))
            Dim contact As String = WebUtility.HtmlEncode(If(row("Contact") IsNot DBNull.Value, row("Contact").ToString(), "-"))
            Dim email As String = WebUtility.HtmlEncode(If(row("Email") IsNot DBNull.Value, row("Email").ToString(), "-"))
            Dim createdDate As String = If(row.Table.Columns.Contains("CreatedAt") AndAlso row("CreatedAt") IsNot DBNull.Value,
                                           CDate(row("CreatedAt")).ToString("yyyy-MM-dd"), "-")

            sbRows.Append($"" &
                $"<tr>" &
                $"<td class='text-center'>{idx}</td>" &
                $"<td class='text-center font-mono font-bold'>{bUID}</td>" &
                $"<td class='font-bold'>{fullName}</td>" &
                $"<td class='text-center'>{age}</td>" &
                $"<td>{contact}</td>" &
                $"<td>{email}</td>" &
                $"<td class='text-center'>{createdDate}</td>" &
                $"<td class='text-center'><span class='badge badge-approved'>Registered</span></td>" &
                $"</tr>")
            idx += 1
        Next

        Dim summaryHtml = $"" &
            $"<div class='summary-card'>" &
            $"  <div class='summary-title'>👥 Registered Borrowers Summary</div>" &
            $"  <div class='summary-grid'>" &
            $"    <div class='summary-item'><div class='summary-label'>Total Registered Clients</div><div class='summary-value highlight'>{totalCount:N0}</div></div>" &
            $"    <div class='summary-item'><div class='summary-label'>Verified Contacts</div><div class='summary-value'>{withContact:N0}</div></div>" &
            $"    <div class='summary-item'><div class='summary-label'>Registered Emails</div><div class='summary-value'>{withEmail:N0}</div></div>" &
            $"    <div class='summary-item'><div class='summary-label'>Profile Completion</div><div class='summary-value' style='color:#047857;'>{(If(totalCount > 0, Math.Round((withContact / totalCount) * 100, 1), 0))}%</div></div>" &
            $"  </div>" &
            $"</div>"

        Dim tableHtml = $"" &
            $"<table>" &
            $"  <thead>" &
            $"    <tr>" &
            $"      <th style='width:40px;' class='text-center'>#</th>" &
            $"      <th style='width:110px;' class='text-center'>Borrower UID</th>" &
            $"      <th>Full Name</th>" &
            $"      <th style='width:60px;' class='text-center'>Age</th>" &
            $"      <th style='width:150px;'>Contact Number</th>" &
            $"      <th style='width:220px;'>Email Address</th>" &
            $"      <th style='width:110px;' class='text-center'>Date Registered</th>" &
            $"      <th style='width:90px;' class='text-center'>Status</th>" &
            $"    </tr>" &
            $"  </thead>" &
            $"  <tbody>" &
            sbRows.ToString() &
            $"  </tbody>" &
            $"</table>"

        Return BuildHtmlDocument("MASTERLIST OF REGISTERED BORROWERS",
                                 "Official directory of approved client profiles, demographic details, and contact information",
                                 tableHtml, summaryHtml)
    End Function

    ' ── HTML Generation: Combined ─────────────────────────────────
    Private Shared Function GenerateCombinedHtml(dtBorrowers As DataTable, dtApplicants As DataTable) As String
        Dim bCount = If(dtBorrowers IsNot Nothing, dtBorrowers.Rows.Count, 0)
        Dim aCount = If(dtApplicants IsNot Nothing, dtApplicants.Rows.Count, 0)

        Dim sbContent As New StringBuilder()

        ' Section 1: Borrowers
        sbContent.Append("<div style='margin-bottom: 30px;'>")
        sbContent.Append("<h3 style='font-size: 14px; font-weight: 800; color: #E73F1E; margin-bottom: 10px; border-left: 4px solid #E73F1E; padding-left: 8px;'>SECTION 1: REGISTERED BORROWERS DIRECTORY</h3>")
        If dtBorrowers IsNot Nothing AndAlso dtBorrowers.Rows.Count > 0 Then
            sbContent.Append("<table><thead><tr>" &
                             "<th style='width:40px;' class='text-center'>#</th>" &
                             "<th style='width:110px;' class='text-center'>Borrower UID</th>" &
                             "<th>Full Name</th>" &
                             "<th style='width:60px;' class='text-center'>Age</th>" &
                             "<th style='width:150px;'>Contact Number</th>" &
                             "<th style='width:220px;'>Email Address</th>" &
                             "<th style='width:110px;' class='text-center'>Date Registered</th>" &
                             "</tr></thead><tbody>")
            Dim bIdx = 1
            For Each row As DataRow In dtBorrowers.Rows
                Dim bUID = WebUtility.HtmlEncode(If(row("BorrowerUID") IsNot DBNull.Value, row("BorrowerUID").ToString(), "N/A"))
                Dim first = If(row("FirstName") IsNot DBNull.Value, row("FirstName").ToString().Trim(), "")
                Dim middle = If(row.Table.Columns.Contains("MiddleName") AndAlso row("MiddleName") IsNot DBNull.Value AndAlso Not String.IsNullOrWhiteSpace(row("MiddleName").ToString()), row("MiddleName").ToString().Trim() & " ", "")
                Dim last = If(row("LastName") IsNot DBNull.Value, row("LastName").ToString().Trim(), "")
                Dim fullName = WebUtility.HtmlEncode($"{first} {middle}{last}".Trim())
                Dim age = WebUtility.HtmlEncode(If(row("Age") IsNot DBNull.Value, row("Age").ToString(), "-"))
                Dim contact = WebUtility.HtmlEncode(If(row("Contact") IsNot DBNull.Value, row("Contact").ToString(), "-"))
                Dim email = WebUtility.HtmlEncode(If(row("Email") IsNot DBNull.Value, row("Email").ToString(), "-"))
                Dim createdDate = If(row.Table.Columns.Contains("CreatedAt") AndAlso row("CreatedAt") IsNot DBNull.Value, CDate(row("CreatedAt")).ToString("yyyy-MM-dd"), "-")

                sbContent.Append($"<tr><td class='text-center'>{bIdx}</td><td class='text-center font-mono font-bold'>{bUID}</td><td class='font-bold'>{fullName}</td><td class='text-center'>{age}</td><td>{contact}</td><td>{email}</td><td class='text-center'>{createdDate}</td></tr>")
                bIdx += 1
            Next
            sbContent.Append("</tbody></table>")
        Else
            sbContent.Append("<p style='font-style:italic; color:#6B7280;'>No borrower records available.</p>")
        End If
        sbContent.Append("</div>")

        ' Page break before Section 2 for printing
        sbContent.Append("<div style='page-break-before: always; margin-top: 30px; margin-bottom: 30px;'>")
        sbContent.Append("<h3 style='font-size: 14px; font-weight: 800; color: #E73F1E; margin-bottom: 10px; border-left: 4px solid #E73F1E; padding-left: 8px;'>SECTION 2: LOAN APPLICATIONS MASTERLIST</h3>")
        If dtApplicants IsNot Nothing AndAlso dtApplicants.Rows.Count > 0 Then
            sbContent.Append("<table><thead><tr>" &
                             "<th style='width:35px;' class='text-center'>#</th>" &
                             "<th style='width:85px;' class='text-center'>App Ref</th>" &
                             "<th>Borrower Name</th>" &
                             "<th style='width:90px;' class='text-center'>Borrower UID</th>" &
                             "<th style='width:125px;'>Loan Type</th>" &
                             "<th style='width:105px;' class='text-right'>Principal (PHP)</th>" &
                             "<th style='width:55px;' class='text-center'>Rate</th>" &
                             "<th style='width:55px;' class='text-center'>Term</th>" &
                             "<th style='width:115px;' class='text-right'>Total Payable</th>" &
                             "<th style='width:85px;' class='text-center'>Status</th>" &
                             "<th style='width:95px;' class='text-center'>Applied Date</th>" &
                             "</tr></thead><tbody>")
            Dim aIdx = 1
            For Each row As DataRow In dtApplicants.Rows
                Dim appID = CInt(row("ApplicationID"))
                Dim appRef = $"APP-{appID:D4}"
                Dim bName = WebUtility.HtmlEncode(If(row("BorrowerName") IsNot DBNull.Value, row("BorrowerName").ToString(), "N/A"))
                Dim bUID = WebUtility.HtmlEncode(If(row.Table.Columns.Contains("BorrowerUID") AndAlso row("BorrowerUID") IsNot DBNull.Value, row("BorrowerUID").ToString(), "N/A"))
                Dim loanType = WebUtility.HtmlEncode(If(row("LoanType") IsNot DBNull.Value, row("LoanType").ToString(), "N/A"))
                Dim principal = If(row("PrincipalAmount") IsNot DBNull.Value, CDec(row("PrincipalAmount")), 0D)
                Dim rate = If(row("InterestRate") IsNot DBNull.Value, CDec(row("InterestRate")), 0D)
                Dim term = If(row("Term") IsNot DBNull.Value, CInt(row("Term")), 1)
                Dim payable = If(row("TotalPayable") IsNot DBNull.Value, CDec(row("TotalPayable")), 0D)
                Dim stRaw = If(row("Status") IsNot DBNull.Value, row("Status").ToString().Trim(), "Pending")
                Dim submitted = If(row("SubmittedAt") IsNot DBNull.Value, CDate(row("SubmittedAt")).ToString("yyyy-MM-dd"), "-")

                Dim badgeClass = "badge-pending"
                Select Case stRaw.ToLower()
                    Case "approved", "active"
                        badgeClass = "badge-approved"
                    Case "rejected", "declined"
                        badgeClass = "badge-rejected"
                End Select

                sbContent.Append($"<tr><td class='text-center'>{aIdx}</td><td class='text-center font-mono font-bold'>{appRef}</td><td class='font-bold'>{bName}</td><td class='text-center font-mono'>{bUID}</td><td>{loanType}</td><td class='text-right'>₱{principal:N2}</td><td class='text-center'>{rate:0.#}%</td><td class='text-center'>{term} mo</td><td class='text-right font-bold'>₱{payable:N2}</td><td class='text-center'><span class='badge {badgeClass}'>{WebUtility.HtmlEncode(stRaw)}</span></td><td class='text-center'>{submitted}</td></tr>")
                aIdx += 1
            Next
            sbContent.Append("</tbody></table>")
        Else
            sbContent.Append("<p style='font-style:italic; color:#6B7280;'>No loan application records available.</p>")
        End If
        sbContent.Append("</div>")

        Dim summaryHtml = $"" &
            $"<div class='summary-card'>" &
            $"  <div class='summary-title'>📑 Combined Audit Summary</div>" &
            $"  <div class='summary-grid'>" &
            $"    <div class='summary-item'><div class='summary-label'>Total Borrowers</div><div class='summary-value highlight'>{bCount:N0}</div></div>" &
            $"    <div class='summary-item'><div class='summary-label'>Total Applications</div><div class='summary-value'>{aCount:N0}</div></div>" &
            $"    <div class='summary-item'><div class='summary-label'>Report Date</div><div class='summary-value'>{DateTime.Now:yyyy-MM-dd}</div></div>" &
            $"    <div class='summary-item'><div class='summary-label'>Prepared By</div><div class='summary-value'>{WebUtility.HtmlEncode(SessionManager.CurrentUsername)}</div></div>" &
            $"  </div>" &
            $"</div>"

        Return BuildHtmlDocument("COMBINED AUDIT REPORT: APPLICANTS & BORROWERS",
                                 "Consolidated administrative masterlist of all registered client profiles and loan applications",
                                 sbContent.ToString(), summaryHtml)
    End Function

    ' ── Master HTML Template Builder ──────────────────────────────
    Private Shared Function BuildHtmlDocument(reportTitle As String, reportSubtitle As String,
                                              mainTableHtml As String, summaryCardHtml As String) As String

        Dim logoBase64 = GetLogoBase64()
        Dim logoTag = If(Not String.IsNullOrEmpty(logoBase64),
                         $"<img src='{logoBase64}' class='header-logo' alt='ASA Logo' />",
                         "")

        Dim genTime = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm tt")
        Dim adminUser = WebUtility.HtmlEncode(If(String.IsNullOrEmpty(SessionManager.CurrentUsername), "Admin", SessionManager.CurrentUsername))

        Dim html = $"" &
"<!DOCTYPE html>
<html lang='en'>
<head>
<meta charset='utf-8'>
<meta name='viewport' content='width=device-width, initial-scale=1.0'>
<title>" & WebUtility.HtmlEncode(reportTitle) & " - ASA Philippines Foundation</title>
<style>
    :root {
        --primary: #E73F1E;
        --primary-dark: #B82E12;
        --secondary: #FB6C00;
        --accent: #F9B637;
        --bg-gray: #F1F5F9;
        --text-dark: #1E293B;
        --text-muted: #64748B;
        --border-color: #CBD5E1;
    }
    * {
        box-sizing: border-box;
        margin: 0;
        padding: 0;
    }
    body {
        font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
        color: var(--text-dark);
        background-color: var(--bg-gray);
        font-size: 12px;
        line-height: 1.4;
        -webkit-print-color-adjust: exact;
        print-color-adjust: exact;
    }
    .top-toolbar {
        position: sticky;
        top: 0;
        z-index: 9999;
        background: #0F172A;
        color: white;
        padding: 12px 24px;
        display: flex;
        justify-content: space-between;
        align-items: center;
        box-shadow: 0 4px 6px -1px rgba(0,0,0,0.1);
    }
    .top-toolbar .title {
        font-weight: 600;
        font-size: 13.5px;
        display: flex;
        align-items: center;
        gap: 8px;
    }
    .top-toolbar .actions {
        display: flex;
        gap: 10px;
        align-items: center;
    }
    .btn {
        display: inline-flex;
        align-items: center;
        gap: 6px;
        padding: 8px 16px;
        font-size: 13px;
        font-weight: 700;
        border-radius: 6px;
        cursor: pointer;
        border: none;
        transition: all 0.15s ease;
        text-decoration: none;
    }
    .btn-print {
        background: var(--primary);
        color: white;
    }
    .btn-print:hover {
        background: var(--primary-dark);
    }
    .btn-secondary {
        background: #334155;
        color: white;
    }
    .btn-secondary:hover {
        background: #475569;
    }
    .toolbar-tip {
        font-size: 11px;
        color: #94A3B8;
        margin-right: 12px;
    }
    .paper-container {
        padding: 24px 20px 40px 20px;
        display: flex;
        justify-content: center;
    }
    .paper-sheet {
        background: white;
        width: 100%;
        max-width: 1240px;
        padding: 36px 42px;
        box-shadow: 0 10px 15px -3px rgba(0,0,0,0.1), 0 4px 6px -2px rgba(0,0,0,0.05);
        border-radius: 8px;
    }
    .doc-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding-bottom: 16px;
        border-bottom: 3px solid var(--primary);
        margin-bottom: 22px;
        position: relative;
    }
    .doc-header::after {
        content: '';
        position: absolute;
        bottom: -6px;
        left: 0;
        right: 0;
        height: 1.5px;
        background: var(--accent);
    }
    .header-branding {
        display: flex;
        align-items: center;
        gap: 16px;
    }
    .header-logo {
        width: 62px;
        height: 62px;
        object-fit: contain;
    }
    .org-title {
        font-size: 16px;
        font-weight: 800;
        color: var(--primary);
        letter-spacing: 0.5px;
        text-transform: uppercase;
    }
    .org-subtitle {
        font-size: 11px;
        font-weight: 600;
        color: var(--text-muted);
        text-transform: uppercase;
        letter-spacing: 0.5px;
        margin-top: 1px;
    }
    .doc-title {
        font-size: 18px;
        font-weight: 800;
        color: #0F172A;
        margin-top: 3px;
    }
    .meta-box {
        text-align: right;
        font-size: 11px;
        color: #475569;
        line-height: 1.6;
    }
    .meta-box strong {
        color: #0F172A;
    }
    table {
        width: 100%;
        border-collapse: collapse;
        margin-bottom: 20px;
        font-size: 11px;
    }
    thead {
        display: table-header-group;
    }
    tfoot {
        display: table-footer-group;
    }
    tr {
        page-break-inside: avoid;
    }
    th {
        background-color: var(--primary) !important;
        color: white !important;
        font-weight: 700;
        text-align: left;
        padding: 9px 10px;
        font-size: 11px;
        border: 1px solid #D83616;
        text-transform: uppercase;
        letter-spacing: 0.3px;
    }
    td {
        padding: 7.5px 10px;
        border: 1px solid #E2E8F0;
        color: #1E293B;
        vertical-align: middle;
    }
    tbody tr:nth-child(even) {
        background-color: #F8FAFC !important;
    }
    .text-center { text-align: center; }
    .text-right { text-align: right; font-variant-numeric: tabular-nums; }
    .font-mono { font-family: ui-monospace, SFMono-Regular, Menlo, Monaco, Consolas, monospace; font-size: 10.5px; }
    .font-bold { font-weight: 700; }
    .badge {
        display: inline-block;
        padding: 2.5px 8px;
        border-radius: 9999px;
        font-size: 10px;
        font-weight: 700;
        text-align: center;
        letter-spacing: 0.2px;
        border: 1px solid transparent;
    }
    .badge-approved {
        background-color: #DEF7EC;
        color: #03543F;
        border-color: #BCF0DA;
    }
    .badge-pending {
        background-color: #FEF3C7;
        color: #92400E;
        border-color: #FDE68A;
    }
    .badge-rejected {
        background-color: #FDE8E8;
        color: #9B1C1C;
        border-color: #F8B4B4;
    }
    .summary-card {
        background-color: #F8FAFC;
        border: 1px solid #CBD5E1;
        border-left: 5px solid var(--primary);
        border-radius: 6px;
        padding: 16px 20px;
        margin-top: 24px;
        page-break-inside: avoid;
    }
    .summary-title {
        font-size: 12.5px;
        font-weight: 800;
        color: #0F172A;
        text-transform: uppercase;
        letter-spacing: 0.5px;
        margin-bottom: 10px;
    }
    .summary-grid {
        display: grid;
        grid-template-columns: repeat(auto-fit, minmax(180px, 1fr));
        gap: 12px;
    }
    .summary-item {
        background: white;
        padding: 10px 14px;
        border-radius: 5px;
        border: 1px solid #E2E8F0;
    }
    .summary-label {
        font-size: 10px;
        color: var(--text-muted);
        text-transform: uppercase;
        font-weight: 700;
    }
    .summary-value {
        font-size: 14.5px;
        font-weight: 800;
        color: #0F172A;
        margin-top: 3px;
    }
    .summary-value.highlight {
        color: var(--primary);
    }
    .doc-signatures {
        margin-top: 45px;
        margin-bottom: 25px;
        display: flex;
        justify-content: space-between;
        page-break-inside: avoid;
    }
    .signature-block {
        width: 240px;
        text-align: center;
    }
    .signature-line {
        border-bottom: 1.5px solid #334155;
        margin-bottom: 6px;
    }
    .signature-name {
        font-weight: 700;
        font-size: 11px;
        color: #0F172A;
    }
    .signature-title {
        font-size: 10px;
        color: var(--text-muted);
    }
    .doc-footer {
        margin-top: 30px;
        padding-top: 14px;
        border-top: 1px solid #E2E8F0;
        display: flex;
        justify-content: space-between;
        align-items: center;
        font-size: 10px;
        color: #64748B;
        page-break-inside: avoid;
    }
    .doc-footer .notice {
        font-weight: 600;
        letter-spacing: 0.3px;
    }
    @media print {
        @page {
            size: landscape;
            margin: 12mm 10mm 14mm 10mm;
        }
        body {
            background-color: white !important;
            font-size: 10.5px;
        }
        .no-print {
            display: none !important;
        }
        .paper-container {
            padding: 0 !important;
        }
        .paper-sheet {
            box-shadow: none !important;
            border-radius: 0 !important;
            padding: 0 !important;
            max-width: 100% !important;
        }
        th {
            background-color: #E73F1E !important;
            color: white !important;
            -webkit-print-color-adjust: exact;
            print-color-adjust: exact;
        }
        tbody tr:nth-child(even) {
            background-color: #F8FAFC !important;
            -webkit-print-color-adjust: exact;
            print-color-adjust: exact;
        }
        .badge-approved {
            background-color: #DEF7EC !important;
            color: #03543F !important;
        }
        .badge-pending {
            background-color: #FEF3C7 !important;
            color: #92400E !important;
        }
        .badge-rejected {
            background-color: #FDE8E8 !important;
            color: #9B1C1C !important;
        }
    }
</style>
</head>
<body>
    <div class='top-toolbar no-print'>
        <div class='title'>
            <span>🖨️ ASA LMS Report Viewer</span>
            <span style='color: #64748B;'>•</span>
            <span style='font-weight: 400; font-size: 12px; color: #CBD5E1;'>" & WebUtility.HtmlEncode(reportTitle) & "</span>
        </div>
        <div class='actions'>
            <span class='toolbar-tip'>Select <strong>""Save as PDF""</strong> in destination to export as PDF file</span>
            <button class='btn btn-print' onclick='window.print()'>🖨️ Print / Save as PDF</button>
            <button class='btn btn-secondary' onclick='window.close()'>✕ Close</button>
        </div>
    </div>

    <div class='paper-container'>
        <div class='paper-sheet'>
            <!-- Document Header -->
            <div class='doc-header'>
                <div class='header-branding'>
                    " & logoTag & "
                    <div>
                        <div class='org-title'>ASA PHILIPPINES FOUNDATION, INC.</div>
                        <div class='org-subtitle'>LOAN MANAGEMENT SYSTEM (LMS)</div>
                        <div class='doc-title'>" & WebUtility.HtmlEncode(reportTitle) & "</div>
                    </div>
                </div>
                <div class='meta-box'>
                    <div><strong>Generated:</strong> " & genTime & "</div>
                    <div><strong>Administrator:</strong> " & adminUser & "</div>
                    <div><strong>Classification:</strong> Internal Confidential</div>
                </div>
            </div>

            <!-- Main Data Table -->
            " & mainTableHtml & "

            <!-- Summary Metrics Card -->
            " & summaryCardHtml & "

            <!-- Signatures Block -->
            <div class='doc-signatures'>
                <div class='signature-block'>
                    <div class='signature-line'></div>
                    <div class='signature-name'>" & adminUser & "</div>
                    <div class='signature-title'>Prepared By (Administrator)</div>
                </div>
                <div class='signature-block'>
                    <div class='signature-line'></div>
                    <div class='signature-name'>Loan Operations Division</div>
                    <div class='signature-title'>Verified & Endorsed</div>
                </div>
                <div class='signature-block'>
                    <div class='signature-line'></div>
                    <div class='signature-name'>Branch / Regional Head</div>
                    <div class='signature-title'>Official Approval</div>
                </div>
            </div>

            <!-- Document Footer -->
            <div class='doc-footer'>
                <div class='notice'>CONFIDENTIAL • ASA Philippines Foundation, Inc. — Loan Management System • Internal Official Use Only</div>
                <div>System-Generated Document • Printed from LMS Dashboard</div>
            </div>
        </div>
    </div>

    <script>
        // Automatically prompt the browser print/PDF preview dialog
        window.addEventListener('load', function() {
            setTimeout(function() {
                window.print();
            }, 500);
        });
    </script>
</body>
</html>"

        Return html
    End Function

    ' ── Utilities: Saving & Browser Launching ─────────────────────

    ''' <summary>
    ''' Converts the embedded system logo into a Base64 data URI string.
    ''' </summary>
    Private Shared Function GetLogoBase64() As String
        Try
            Dim img = AppTheme.GetLogoImage()
            If img IsNot Nothing Then
                Using ms As New MemoryStream()
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    Return "data:image/png;base64," & Convert.ToBase64String(ms.ToArray())
                End Using
            End If
        Catch
        End Try
        Return ""
    End Function

    ''' <summary>
    ''' Writes the generated HTML report to a temporary folder and returns the file path.
    ''' </summary>
    Private Shared Function SaveTempReport(htmlContent As String, prefix As String) As String
        Dim reportsDir = Path.Combine(Path.GetTempPath(), "LMS_ASA_Reports")
        If Not Directory.Exists(reportsDir) Then
            Directory.CreateDirectory(reportsDir)
        End If

        Dim fileName = $"{prefix}_{DateTime.Now:yyyyMMdd_HHmmss}.html"
        Dim fullPath = Path.Combine(reportsDir, fileName)
        File.WriteAllText(fullPath, htmlContent, Encoding.UTF8)
        Return fullPath
    End Function

    ''' <summary>
    ''' Launches Google Chrome if installed, or falls back to the default system browser.
    ''' </summary>
    Public Shared Sub OpenReportInBrowser(htmlFilePath As String)
        Try
            Dim chromePath = GetChromeExecutablePath()
            If Not String.IsNullOrEmpty(chromePath) AndAlso File.Exists(chromePath) Then
                Dim psi As New ProcessStartInfo() With {
                    .FileName = chromePath,
                    .Arguments = $"""{htmlFilePath}""",
                    .UseShellExecute = False
                }
                Process.Start(psi)
                Return
            End If
        Catch
        End Try

        ' Fallback to default browser
        Try
            Dim psi As New ProcessStartInfo() With {
                .FileName = htmlFilePath,
                .UseShellExecute = True
            }
            Process.Start(psi)
        Catch ex As Exception
            MessageBox.Show($"Unable to open report in browser: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Detects the installation path of Google Chrome on Windows.
    ''' </summary>
    Private Shared Function GetChromeExecutablePath() As String
        Dim paths As String() = {
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Google\Chrome\Application\chrome.exe"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Google\Chrome\Application\chrome.exe"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google\Chrome\Application\chrome.exe")
        }

        For Each p In paths
            If File.Exists(p) Then Return p
        Next

        Try
            Using key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe")
                If key IsNot Nothing Then
                    Dim val = key.GetValue("")?.ToString()
                    If Not String.IsNullOrEmpty(val) AndAlso File.Exists(val) Then Return val
                End If
            End Using
        Catch
        End Try

        Return Nothing
    End Function

End Class
