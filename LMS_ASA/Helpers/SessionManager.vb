Public Module SessionManager

    Public CurrentUserID     As Integer = 0
    Public CurrentUsername   As String  = ""
    Public CurrentRole       As String  = ""       ' "Admin" or "Borrower"
    Public CurrentBorrowerID As Integer = 0        ' 0 when user is Admin

    Public Sub SetSession(userID As Integer, username As String, role As String,
                          Optional borrowerID As Integer = 0)
        CurrentUserID     = userID
        CurrentUsername   = username
        CurrentRole       = role
        CurrentBorrowerID = borrowerID
    End Sub

    Public Sub ClearSession()
        CurrentUserID     = 0
        CurrentUsername   = ""
        CurrentRole       = ""
        CurrentBorrowerID = 0
    End Sub

    Public Function IsAdmin() As Boolean
        Return CurrentRole = "Admin"
    End Function

End Module
