Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module LoanRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT l.LoanID, l.LoanReferenceID, " &
                "b.FirstName + ' ' + b.LastName AS BorrowerName, b.BorrowerUID, " &
                "l.LoanType, l.PrincipalAmount, l.InterestRate, l.TotalPayable, " &
                "l.Term, l.ReleaseDate, l.DueDate, l.Status, l.CreatedAt " &
                "FROM tbl_Loans l " &
                "INNER JOIN tbl_Borrowers b ON l.BorrowerID = b.BorrowerID " &
                "ORDER BY l.CreatedAt DESC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByBorrowerID(borrowerID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT * FROM tbl_Loans WHERE BorrowerID = @borrowerID ORDER BY CreatedAt DESC", con)
            cmd.Parameters.AddWithValue("@borrowerID", borrowerID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByID(loanID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT * FROM tbl_Loans WHERE LoanID = @id", con)
            cmd.Parameters.AddWithValue("@id", loanID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetNextReferenceID() As String
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT TOP 1 LoanReferenceID FROM tbl_Loans ORDER BY LoanID DESC", con)
            Dim last = cmd.ExecuteScalar()
            If last Is Nothing OrElse last Is DBNull.Value Then Return "LN-0001"
            Dim num As Integer = Integer.Parse(last.ToString().Split("-"c)(1)) + 1
            Return $"LN-{num:D4}"
        End Using
    End Function

    Public Sub Insert(borrowerID As Integer, loanReferenceID As String, loanType As String,
                      principalAmount As Decimal, interestRate As Decimal, totalPayable As Decimal,
                      term As Integer, releaseDate As DateTime, dueDate As DateTime, status As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Loans " &
                "(BorrowerID, LoanReferenceID, LoanType, PrincipalAmount, InterestRate, TotalPayable, " &
                "Term, ReleaseDate, DueDate, Status, CreatedAt) " &
                "VALUES (@borrowerID, @refID, @loanType, @principal, @rate, @total, " &
                "@term, @release, @due, @status, GETDATE())", con)
                cmd.Parameters.AddWithValue("@borrowerID", borrowerID)
                cmd.Parameters.AddWithValue("@refID", loanReferenceID)
                cmd.Parameters.AddWithValue("@loanType", loanType)
                cmd.Parameters.AddWithValue("@principal", principalAmount)
                cmd.Parameters.AddWithValue("@rate", interestRate)
                cmd.Parameters.AddWithValue("@total", totalPayable)
                cmd.Parameters.AddWithValue("@term", term)
                cmd.Parameters.AddWithValue("@release", releaseDate)
                cmd.Parameters.AddWithValue("@due", dueDate)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Update(loanID As Integer, loanType As String, principalAmount As Decimal,
                      interestRate As Decimal, totalPayable As Decimal, term As Integer,
                      releaseDate As DateTime, dueDate As DateTime, status As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Loans SET LoanType = @loanType, PrincipalAmount = @principal, " &
                "InterestRate = @rate, TotalPayable = @total, Term = @term, " &
                "ReleaseDate = @release, DueDate = @due, Status = @status " &
                "WHERE LoanID = @id", con)
                cmd.Parameters.AddWithValue("@loanType", loanType)
                cmd.Parameters.AddWithValue("@principal", principalAmount)
                cmd.Parameters.AddWithValue("@rate", interestRate)
                cmd.Parameters.AddWithValue("@total", totalPayable)
                cmd.Parameters.AddWithValue("@term", term)
                cmd.Parameters.AddWithValue("@release", releaseDate)
                cmd.Parameters.AddWithValue("@due", dueDate)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@id", loanID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdateStatus(loanID As Integer, status As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Loans SET Status = @status WHERE LoanID = @id", con)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@id", loanID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Delete(loanID As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "DELETE FROM tbl_Loans WHERE LoanID = @id", con)
                cmd.Parameters.AddWithValue("@id", loanID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
