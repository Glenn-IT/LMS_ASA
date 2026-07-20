Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module BorrowerRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT BorrowerID, BorrowerUID, FirstName, MiddleName, LastName, " &
                "Age, Contact, Email, CreatedAt " &
                "FROM tbl_Borrowers ORDER BY LastName ASC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByID(borrowerID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT * FROM tbl_Borrowers WHERE BorrowerID = @id", con)
            cmd.Parameters.AddWithValue("@id", borrowerID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByUserID(userID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT * FROM tbl_Borrowers WHERE UserID = @userID", con)
            cmd.Parameters.AddWithValue("@userID", userID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetNextUID() As String
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT TOP 1 BorrowerUID FROM tbl_Borrowers ORDER BY BorrowerID DESC", con)
            Dim last = cmd.ExecuteScalar()
            If last Is Nothing OrElse last Is DBNull.Value Then Return "BRW-0001"
            Dim num As Integer = Integer.Parse(last.ToString().Split("-"c)(1)) + 1
            Return $"BRW-{num:D4}"
        End Using
    End Function

    Public Sub Insert(userID As Integer, borrowerUID As String,
                      firstName As String, middleName As String, lastName As String,
                      age As Integer, dateOfBirth As DateTime,
                      contact As String, email As String, idImagePath As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Borrowers " &
                "(UserID, BorrowerUID, FirstName, MiddleName, LastName, Age, DateOfBirth, Contact, Email, IDImagePath, CreatedAt) " &
                "VALUES (@userID, @uid, @first, @middle, @last, @age, @dob, @contact, @email, @idPath, GETDATE())", con)
                cmd.Parameters.AddWithValue("@userID", userID)
                cmd.Parameters.AddWithValue("@uid", borrowerUID)
                cmd.Parameters.AddWithValue("@first", firstName)
                cmd.Parameters.AddWithValue("@middle", If(String.IsNullOrEmpty(middleName), DBNull.Value, middleName))
                cmd.Parameters.AddWithValue("@last", lastName)
                cmd.Parameters.AddWithValue("@age", age)
                cmd.Parameters.AddWithValue("@dob", dateOfBirth)
                cmd.Parameters.AddWithValue("@contact", contact)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@idPath", If(String.IsNullOrEmpty(idImagePath), DBNull.Value, idImagePath))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Creates the tbl_Users login and the tbl_Borrowers record in a single
    ''' transaction, so a failure partway through cannot leave an orphaned
    ''' login behind (see docs/cleanup_orphaned_users.sql for the symptom
    ''' this caused before this fix).
    ''' </summary>
    Public Sub InsertWithUser(username As String, passwordHash As String, role As String,
                              securityQuestion As String, securityAnswer As String,
                              borrowerUID As String,
                              firstName As String, middleName As String, lastName As String,
                              age As Integer, dateOfBirth As DateTime,
                              contact As String, email As String, idImagePath As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using tx = con.BeginTransaction()
                Dim newUserID As Integer
                Using cmd As New SqlCommand(
                    "INSERT INTO tbl_Users (Username, PasswordHash, Role, SecurityQuestion, SecurityAnswer, IsActive, CreatedAt) " &
                    "VALUES (@username, @hash, @role, @question, @answer, 1, GETDATE()); " &
                    "SELECT CAST(SCOPE_IDENTITY() AS INT)", con, tx)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@hash", passwordHash)
                    cmd.Parameters.AddWithValue("@role", role)
                    cmd.Parameters.AddWithValue("@question", securityQuestion)
                    cmd.Parameters.AddWithValue("@answer", securityAnswer)
                    newUserID = CInt(cmd.ExecuteScalar())
                End Using

                Using cmd As New SqlCommand(
                    "INSERT INTO tbl_Borrowers " &
                    "(UserID, BorrowerUID, FirstName, MiddleName, LastName, Age, DateOfBirth, Contact, Email, IDImagePath, CreatedAt) " &
                    "VALUES (@userID, @uid, @first, @middle, @last, @age, @dob, @contact, @email, @idPath, GETDATE())", con, tx)
                    cmd.Parameters.AddWithValue("@userID", newUserID)
                    cmd.Parameters.AddWithValue("@uid", borrowerUID)
                    cmd.Parameters.AddWithValue("@first", firstName)
                    cmd.Parameters.AddWithValue("@middle", If(String.IsNullOrEmpty(middleName), DBNull.Value, middleName))
                    cmd.Parameters.AddWithValue("@last", lastName)
                    cmd.Parameters.AddWithValue("@age", age)
                    cmd.Parameters.AddWithValue("@dob", dateOfBirth)
                    cmd.Parameters.AddWithValue("@contact", contact)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue("@idPath", If(String.IsNullOrEmpty(idImagePath), DBNull.Value, idImagePath))
                    cmd.ExecuteNonQuery()
                End Using

                tx.Commit()
            End Using
        End Using
    End Sub

    Public Sub Update(borrowerID As Integer,
                      firstName As String, middleName As String, lastName As String,
                      age As Integer, dateOfBirth As DateTime,
                      contact As String, email As String, idImagePath As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Borrowers SET " &
                "FirstName = @first, MiddleName = @middle, LastName = @last, " &
                "Age = @age, DateOfBirth = @dob, Contact = @contact, Email = @email, IDImagePath = @idPath " &
                "WHERE BorrowerID = @id", con)
                cmd.Parameters.AddWithValue("@first", firstName)
                cmd.Parameters.AddWithValue("@middle", If(String.IsNullOrEmpty(middleName), DBNull.Value, middleName))
                cmd.Parameters.AddWithValue("@last", lastName)
                cmd.Parameters.AddWithValue("@age", age)
                cmd.Parameters.AddWithValue("@dob", dateOfBirth)
                cmd.Parameters.AddWithValue("@contact", contact)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@idPath", If(String.IsNullOrEmpty(idImagePath), DBNull.Value, idImagePath))
                cmd.Parameters.AddWithValue("@id", borrowerID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function HasLoans(borrowerID As Integer) As Boolean
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT COUNT(1) FROM tbl_Loans WHERE BorrowerID = @id", con)
            cmd.Parameters.AddWithValue("@id", borrowerID)
            Return CInt(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Public Sub Delete(borrowerID As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using tx = con.BeginTransaction()
                Dim userID As Integer
                Using cmd As New SqlCommand(
                    "SELECT UserID FROM tbl_Borrowers WHERE BorrowerID = @id", con, tx)
                    cmd.Parameters.AddWithValue("@id", borrowerID)
                    userID = CInt(cmd.ExecuteScalar())
                End Using

                Using cmd As New SqlCommand(
                    "DELETE FROM tbl_Borrowers WHERE BorrowerID = @id", con, tx)
                    cmd.Parameters.AddWithValue("@id", borrowerID)
                    cmd.ExecuteNonQuery()
                End Using

                Using cmd As New SqlCommand(
                    "DELETE FROM tbl_Users WHERE UserID = @userID", con, tx)
                    cmd.Parameters.AddWithValue("@userID", userID)
                    cmd.ExecuteNonQuery()
                End Using

                tx.Commit()
            End Using
        End Using
    End Sub

End Module
