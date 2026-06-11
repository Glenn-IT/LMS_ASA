Imports Microsoft.Data.SqlClient

Public Module ActivityLogRepository

    Public Sub Insert(username As String, result As String, description As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Dim sql As String =
                "INSERT INTO tbl_ActivityLogs (Username, LogDate, Result, Description) " &
                "VALUES (@username, GETDATE(), @result, @description)"
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@result", result)
                cmd.Parameters.AddWithValue("@description", description)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
