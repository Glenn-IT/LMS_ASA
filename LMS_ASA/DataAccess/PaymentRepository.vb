Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module PaymentRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT p.PaymentID, p.LoanID, l.LoanReferenceID, " &
                "b.FirstName + ' ' + b.LastName AS BorrowerName, " &
                "p.Payee, p.Amount, p.Penalty, p.PaymentDate, p.Status, " &
                "l.TotalPayable, l.Term, " &
                "(l.TotalPayable / CASE WHEN l.Term = 0 THEN 1 ELSE l.Term END) AS MonthlyAmortization, " &
                "ISNULL(paid.TotalPaid, 0) AS TotalPaidForLoan, " &
                "(l.TotalPayable - ISNULL(paid.TotalPaid, 0)) AS RemainingBalance " &
                "FROM tbl_Payments p " &
                "INNER JOIN tbl_Loans l ON p.LoanID = l.LoanID " &
                "INNER JOIN tbl_Borrowers b ON l.BorrowerID = b.BorrowerID " &
                "LEFT JOIN ( " &
                "    SELECT LoanID, SUM(Amount) AS TotalPaid " &
                "    FROM tbl_Payments " &
                "    WHERE Status = 'Paid' " &
                "    GROUP BY LoanID " &
                ") paid ON l.LoanID = paid.LoanID " &
                "ORDER BY p.PaymentDate DESC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetLoanPaymentSummary(loanID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT l.LoanID, l.LoanReferenceID, " &
                "b.FirstName + ' ' + ISNULL(b.MiddleName + ' ', '') + b.LastName AS BorrowerName, " &
                "l.PrincipalAmount, l.InterestRate, l.TotalPayable, l.Term, " &
                "ISNULL(paid.TotalPaid, 0) AS TotalPaid, " &
                "(l.TotalPayable - ISNULL(paid.TotalPaid, 0)) AS RemainingBalance, " &
                "(l.TotalPayable / CASE WHEN l.Term = 0 THEN 1 ELSE l.Term END) AS MonthlyAmortization " &
                "FROM tbl_Loans l " &
                "INNER JOIN tbl_Borrowers b ON l.BorrowerID = b.BorrowerID " &
                "LEFT JOIN ( " &
                "    SELECT LoanID, SUM(Amount) AS TotalPaid " &
                "    FROM tbl_Payments " &
                "    WHERE Status = 'Paid' " &
                "    GROUP BY LoanID " &
                ") paid ON l.LoanID = paid.LoanID " &
                "WHERE l.LoanID = @loanID", con)
            cmd.Parameters.AddWithValue("@loanID", loanID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByLoanID(loanID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT * FROM tbl_Payments WHERE LoanID = @loanID ORDER BY PaymentDate DESC", con)
            cmd.Parameters.AddWithValue("@loanID", loanID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByID(paymentID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT p.*, l.LoanReferenceID, " &
                "b.FirstName + ' ' + ISNULL(b.MiddleName + ' ', '') + b.LastName AS BorrowerName " &
                "FROM tbl_Payments p " &
                "INNER JOIN tbl_Loans l ON p.LoanID = l.LoanID " &
                "INNER JOIN tbl_Borrowers b ON l.BorrowerID = b.BorrowerID " &
                "WHERE p.PaymentID = @id", con)
            cmd.Parameters.AddWithValue("@id", paymentID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Sub Insert(loanID As Integer, payee As String,
                      amount As Decimal, penalty As Decimal,
                      paymentDate As DateTime, status As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Payments (LoanID, Payee, Amount, Penalty, PaymentDate, Status, CreatedAt) " &
                "VALUES (@loanID, @payee, @amount, @penalty, @paymentDate, @status, GETDATE())", con)
                cmd.Parameters.AddWithValue("@loanID", loanID)
                cmd.Parameters.AddWithValue("@payee", payee)
                cmd.Parameters.AddWithValue("@amount", amount)
                cmd.Parameters.AddWithValue("@penalty", penalty)
                cmd.Parameters.AddWithValue("@paymentDate", paymentDate)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Update(paymentID As Integer, loanID As Integer, payee As String,
                      amount As Decimal, penalty As Decimal,
                      paymentDate As DateTime, status As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Payments SET LoanID = @loanID, Payee = @payee, Amount = @amount, " &
                "Penalty = @penalty, PaymentDate = @paymentDate, Status = @status " &
                "WHERE PaymentID = @id", con)
                cmd.Parameters.AddWithValue("@loanID", loanID)
                cmd.Parameters.AddWithValue("@payee", payee)
                cmd.Parameters.AddWithValue("@amount", amount)
                cmd.Parameters.AddWithValue("@penalty", penalty)
                cmd.Parameters.AddWithValue("@paymentDate", paymentDate)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@id", paymentID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Delete(paymentID As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "DELETE FROM tbl_Payments WHERE PaymentID = @id", con)
                cmd.Parameters.AddWithValue("@id", paymentID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
