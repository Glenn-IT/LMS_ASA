Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module UserRepository

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT UserID, Username, Role, IsActive, CreatedAt " &
                "FROM tbl_Users ORDER BY CreatedAt DESC", con)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByUsername(username As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT * FROM tbl_Users WHERE Username = @username AND IsActive = 1", con)
            cmd.Parameters.AddWithValue("@username", username)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function GetByID(userID As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim cmd As New SqlCommand(
                "SELECT * FROM tbl_Users WHERE UserID = @id", con)
            cmd.Parameters.AddWithValue("@id", userID)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using
        Return dt
    End Function

    Public Sub Insert(username As String, passwordHash As String, role As String,
                      securityQuestion As String, securityAnswer As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Users (Username, PasswordHash, Role, SecurityQuestion, SecurityAnswer, IsActive, CreatedAt) " &
                "VALUES (@username, @hash, @role, @question, @answer, 1, GETDATE())", con)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@hash", passwordHash)
                cmd.Parameters.AddWithValue("@role", role)
                cmd.Parameters.AddWithValue("@question", securityQuestion)
                cmd.Parameters.AddWithValue("@answer", securityAnswer)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdatePassword(userID As Integer, passwordHash As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Users SET PasswordHash = @hash WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@hash", passwordHash)
                cmd.Parameters.AddWithValue("@id", userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function InsertAndGetID(username As String, passwordHash As String, role As String,
                                   securityQuestion As String, securityAnswer As String) As Integer
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Users (Username, PasswordHash, Role, SecurityQuestion, SecurityAnswer, IsActive, CreatedAt) " &
                "VALUES (@username, @hash, @role, @question, @answer, 1, GETDATE()); " &
                "SELECT CAST(SCOPE_IDENTITY() AS INT)", con)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@hash", passwordHash)
                cmd.Parameters.AddWithValue("@role", role)
                cmd.Parameters.AddWithValue("@question", securityQuestion)
                cmd.Parameters.AddWithValue("@answer", securityAnswer)
                Return CInt(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Public Sub UpdateAccount(userID As Integer, username As String, passwordHash As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Users SET Username = @username, PasswordHash = @hash WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@hash", passwordHash)
                cmd.Parameters.AddWithValue("@id", userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdateMyAccount(userID As Integer, passwordHash As String,
                               securityQuestion As String, securityAnswer As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Users SET PasswordHash = @hash, SecurityQuestion = @question, " &
                "SecurityAnswer = @answer WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@hash", passwordHash)
                cmd.Parameters.AddWithValue("@question", securityQuestion)
                cmd.Parameters.AddWithValue("@answer", securityAnswer)
                cmd.Parameters.AddWithValue("@id", userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdateAdminAccount(userID As Integer, username As String, passwordHash As String,
                                  securityQuestion As String, securityAnswer As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Users SET Username = @username, PasswordHash = @hash, " &
                "SecurityQuestion = @question, SecurityAnswer = @answer WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@hash", passwordHash)
                cmd.Parameters.AddWithValue("@question", securityQuestion)
                cmd.Parameters.AddWithValue("@answer", securityAnswer)
                cmd.Parameters.AddWithValue("@id", userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Deactivate(userID As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Users SET IsActive = 0 WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@id", userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
