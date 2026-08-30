Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class DashboardSummaryStats
    Public Property TotalBorrowers As Integer = 0
    Public Property ActiveLoansCount As Integer = 0
    Public Property TotalLoansCount As Integer = 0
    Public Property PendingApplicationsCount As Integer = 0
    Public Property TotalDisbursed As Decimal = 0D
    Public Property TotalPayable As Decimal = 0D
    Public Property TotalCollections As Decimal = 0D
    Public Property TotalOutstanding As Decimal = 0D
    Public Property CollectionRate As Double = 0.0
End Class

Public Module DashboardRepository

    Public Function GetSummaryStats() As DashboardSummaryStats
        Dim stats As New DashboardSummaryStats()

        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()

            ' 1. Total Borrowers
            Using cmd As New SqlCommand("SELECT COUNT(*) FROM tbl_Borrowers", con)
                Dim res = cmd.ExecuteScalar()
                If res IsNot Nothing AndAlso Not DBNull.Value.Equals(res) Then
                    stats.TotalBorrowers = Convert.ToInt32(res)
                End If
            End Using

            ' 2. Total Loans and Active Loans
            Using cmd As New SqlCommand(
                "SELECT " &
                "COUNT(*) AS TotalLoans, " &
                "ISNULL(SUM(CASE WHEN Status IN ('Active', 'Approved') THEN 1 ELSE 0 END), 0) AS ActiveLoans, " &
                "ISNULL(SUM(PrincipalAmount), 0) AS TotalPrincipal, " &
                "ISNULL(SUM(TotalPayable), 0) AS TotalPayable " &
                "FROM tbl_Loans", con)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        stats.TotalLoansCount = If(reader.IsDBNull(0), 0, reader.GetInt32(0))
                        stats.ActiveLoansCount = If(reader.IsDBNull(1), 0, reader.GetInt32(1))
                        stats.TotalDisbursed = If(reader.IsDBNull(2), 0D, reader.GetDecimal(2))
                        stats.TotalPayable = If(reader.IsDBNull(3), 0D, reader.GetDecimal(3))
                    End If
                End Using
            End Using

            ' 3. Total Collections from Payments
            Using cmd As New SqlCommand("SELECT ISNULL(SUM(Amount), 0) FROM tbl_Payments WHERE Status = 'Paid' OR Status IS NULL", con)
                Dim res = cmd.ExecuteScalar()
                If res IsNot Nothing AndAlso Not DBNull.Value.Equals(res) Then
                    stats.TotalCollections = Convert.ToDecimal(res)
                End If
            End Using

            ' Calculate Outstanding
            stats.TotalOutstanding = Math.Max(0D, stats.TotalPayable - stats.TotalCollections)

            ' Calculate Collection Rate
            If stats.TotalPayable > 0 Then
                stats.CollectionRate = Math.Round((CDbl(stats.TotalCollections) / CDbl(stats.TotalPayable)) * 100.0, 1)
                If stats.CollectionRate > 100.0 Then stats.CollectionRate = 100.0
            Else
                stats.CollectionRate = 0.0
            End If

            ' 4. Pending Applications
            Using cmd As New SqlCommand("SELECT COUNT(*) FROM tbl_LoanApplications WHERE Status = 'Pending' OR Status IS NULL", con)
                Dim res = cmd.ExecuteScalar()
                If res IsNot Nothing AndAlso Not DBNull.Value.Equals(res) Then
                    stats.PendingApplicationsCount = Convert.ToInt32(res)
                End If
            End Using
        End Using

        Return stats
    End Function

    Public Function GetLoansByStatus() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT ISNULL(Status, 'Unknown') AS Status, COUNT(*) AS [Count], " &
                "ISNULL(SUM(PrincipalAmount), 0) AS TotalAmount " &
                "FROM tbl_Loans " &
                "GROUP BY Status " &
                "ORDER BY [Count] DESC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetLoansByType() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT " &
                "ISNULL(l.LoanType, 'General') AS LoanType, " &
                "COUNT(l.LoanID) AS LoanCount, " &
                "ISNULL(SUM(l.PrincipalAmount), 0) AS TotalPrincipal, " &
                "ISNULL(SUM(l.TotalPayable), 0) AS TotalPayable, " &
                "ISNULL(SUM(p.PaidAmount), 0) AS TotalPaid " &
                "FROM tbl_Loans l " &
                "LEFT JOIN ( " &
                "    SELECT LoanID, SUM(Amount) AS PaidAmount " &
                "    FROM tbl_Payments " &
                "    WHERE Status = 'Paid' OR Status IS NULL " &
                "    GROUP BY LoanID " &
                ") p ON l.LoanID = p.LoanID " &
                "GROUP BY l.LoanType " &
                "ORDER BY TotalPrincipal DESC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetRecentLoans(topN As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                $"SELECT TOP ({topN}) l.LoanID, l.LoanReferenceID, " &
                "b.FirstName + ' ' + b.LastName AS BorrowerName, " &
                "l.LoanType, l.PrincipalAmount, l.TotalPayable, l.Status, l.CreatedAt " &
                "FROM tbl_Loans l " &
                "INNER JOIN tbl_Borrowers b ON l.BorrowerID = b.BorrowerID " &
                "ORDER BY l.CreatedAt DESC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetRecentPayments(topN As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                $"SELECT TOP ({topN}) p.PaymentID, l.LoanReferenceID, " &
                "b.FirstName + ' ' + b.LastName AS BorrowerName, " &
                "p.Payee, p.Amount, p.PaymentDate, p.Status " &
                "FROM tbl_Payments p " &
                "INNER JOIN tbl_Loans l ON p.LoanID = l.LoanID " &
                "INNER JOIN tbl_Borrowers b ON l.BorrowerID = b.BorrowerID " &
                "ORDER BY p.PaymentDate DESC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

End Module
