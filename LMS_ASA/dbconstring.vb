Imports System.IO

Public Class dbconstring

    Public Shared ReadOnly Property Connection As String
        Get
            Dim configPath As String = Path.Combine(
                Environment.CurrentDirectory, "config.txt")

            If Not File.Exists(configPath) Then
                Throw New InvalidOperationException(
                    "config.txt not found in the application directory." &
                    Environment.NewLine &
                    "Create config.txt with your SQL Server connection string." &
                    Environment.NewLine &
                    "See config.txt.example for the required format.")
            End If

            Return File.ReadAllText(configPath).Trim()
        End Get
    End Property

End Class
