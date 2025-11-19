Public Class AppConfigSample
    Public Shared ReadOnly Property ConnectionString As String
        Get
            Return "Server=localhost;" &
                   "Port=3306;" &
                   "Database=employee_login_system;" &
                   "Uid=root;" &
                   "Pwd=YOUR_MYSQL_PASSWORD;" &
                   "SslMode=Required;"
        End Get
    End Property
End Class
