Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module LoanApplicationRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT a.ApplicationID, b.BorrowerUID, " &
                "b.FirstName + ' ' + b.LastName AS BorrowerName, " &
                "a.LoanType, a.PrincipalAmount, a.InterestRate, a.TotalPayable, " &
                "a.Term, a.ReleaseDate, a.DueDate, a.Status, a.SubmittedAt " &
                "FROM tbl_LoanApplications a " &
                "INNER JOIN tbl_Borrowers b ON a.BorrowerID = b.BorrowerID " &
                "ORDER BY a.SubmittedAt DESC", con)
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
                "SELECT * FROM tbl_LoanApplications WHERE BorrowerID = @borrowerID " &
                "ORDER BY SubmittedAt DESC", con)
            cmd.Parameters.AddWithValue("@borrowerID", borrowerID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetNextApplicationID() As String
        Dim nextID As Integer = 1
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT ISNULL(MAX(ApplicationID), 0) + 1 FROM tbl_LoanApplications", con)
            nextID = CInt(cmd.ExecuteScalar())
        End Using
        Return $"APP-{nextID:D4}"
    End Function

    Public Function GetByID(applicationID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT a.*, b.FirstName + ' ' + ISNULL(b.MiddleName + ' ', '') + b.LastName AS BorrowerName " &
                "FROM tbl_LoanApplications a " &
                "INNER JOIN tbl_Borrowers b ON a.BorrowerID = b.BorrowerID " &
                "WHERE a.ApplicationID = @id", con)
            cmd.Parameters.AddWithValue("@id", applicationID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Sub Insert(borrowerID As Integer, loanType As String,
                      principalAmount As Decimal, interestRate As Decimal, totalPayable As Decimal,
                      term As Integer, releaseDate As DateTime, dueDate As DateTime)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_LoanApplications " &
                "(BorrowerID, LoanType, PrincipalAmount, InterestRate, TotalPayable, " &
                "Term, ReleaseDate, DueDate, Status, SubmittedAt) " &
                "VALUES (@borrowerID, @loanType, @principal, @rate, @total, " &
                "@term, @release, @due, 'Pending', GETDATE())", con)
                cmd.Parameters.AddWithValue("@borrowerID", borrowerID)
                cmd.Parameters.AddWithValue("@loanType", loanType)
                cmd.Parameters.AddWithValue("@principal", principalAmount)
                cmd.Parameters.AddWithValue("@rate", interestRate)
                cmd.Parameters.AddWithValue("@total", totalPayable)
                cmd.Parameters.AddWithValue("@term", term)
                cmd.Parameters.AddWithValue("@release", releaseDate)
                cmd.Parameters.AddWithValue("@due", dueDate)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdateStatus(applicationID As Integer, status As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_LoanApplications SET Status = @status WHERE ApplicationID = @id", con)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@id", applicationID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Delete(applicationID As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "DELETE FROM tbl_LoanApplications WHERE ApplicationID = @id", con)
                cmd.Parameters.AddWithValue("@id", applicationID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
