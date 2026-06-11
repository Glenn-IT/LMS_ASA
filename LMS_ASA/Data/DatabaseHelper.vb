Imports Microsoft.Data.SqlClient

Public Class DatabaseHelper

    Private Shared ReadOnly ConnectionString As String =
        "Server=.\SQLEXPRESS;Database=LMS_DB;Trusted_Connection=True;TrustServerCertificate=True;"

    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
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
