Public Class Employee
    Public Property EmployeeId As Integer
    Public Property Username As String
    Public Property PasswordHash As String
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Email As String
    Public Property Role As String
    Public Property IsActive As Boolean
    Public Property CreatedAt As DateTime
    Public Property LastLogin As DateTime?

    Public ReadOnly Property FullName As String
        Get
            Return $"{FirstName} {LastName}"
        End Get
    End Property

    Public ReadOnly Property IsAdmin As Boolean
        Get
            Return Role.ToLower() = "admin"
        End Get
    End Property

End Class
