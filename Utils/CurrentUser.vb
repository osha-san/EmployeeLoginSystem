Public Class CurrentUser
    ' Shared property - accessible from anywhere in the application
    Public Shared Property LoggedInEmployee As Employee

    ''' <summary>
    ''' Checks if a user is currently logged in
    ''' </summary>
    Public Shared ReadOnly Property IsLoggedIn As Boolean
        Get
            Return LoggedInEmployee IsNot Nothing
        End Get
    End Property

    ''' <summary>
    ''' Checks if the current user is an admin
    ''' </summary>
    Public Shared ReadOnly Property IsAdmin As Boolean
        Get
            If Not IsLoggedIn Then Return False
            Return LoggedInEmployee.IsAdmin
        End Get
    End Property

    ''' <summary>
    ''' Gets the current user's full name
    ''' </summary>
    Public Shared ReadOnly Property FullName As String
        Get
            If Not IsLoggedIn Then Return "Guest"
            Return LoggedInEmployee.FullName
        End Get
    End Property

    ''' <summary>
    ''' Logs out the current user
    ''' </summary>
    Public Shared Sub Logout()
        LoggedInEmployee = Nothing
    End Sub
End Class
