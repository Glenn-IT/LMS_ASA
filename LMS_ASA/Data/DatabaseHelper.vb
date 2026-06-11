Imports Microsoft.Data.SqlClient

Public Class DatabaseHelper

    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection(dbconstring.Connection)
    End Function

    Public Shared Function TestConnection() As Boolean
        Try
            Using conn = GetConnection()
                conn.Open()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function

End Class
