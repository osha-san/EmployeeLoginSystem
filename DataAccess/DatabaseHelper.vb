Imports MySql.Data.MySqlClient
Public Class DatabaseHelper
    ''Gets a database connection
    Public Shared Function GetConnection() As MySqlConnection
        Return New MySqlConnection(AppConfig.ConnectionString)
    End Function

    'Tests database connection
    Public Shared Function TestConnection() As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Return True
            End Using
        Catch ex As MySqlException
            ''Logs the error

            Dim ErrorMsg As String = "MySQL Connection Error:" & vbCrLf & vbCrLf

            Select Case ex.Number
                Case 0
                    ErrorMsg &= "Cannot connect to MySQL server." & vbCrLf & "Check if MySQL is running."
                Case 1042
                    ErrorMsg &= "Unable to connect t host." & vbCrLf & "Server:" & ex.Message
                Case 1045
                    ErrorMsg &= "Access denied!" & vbCrLf &
                               "Wrong username or password." & vbCrLf & vbCrLf &
                               "Current settings:" & vbCrLf &
                               "Server: localhost" & vbCrLf &
                               "Database: employee_login_system" & vbCrLf &
                               "Username: Check AppConfig.vb"
                Case 1049
                    ErrorMsg &= "Database 'employee_login_system' doesn't exist!" & vbCrLf & vbCrLf &
                               "Run this in MySQL Workbench:" & vbCrLf &
                               "CREATE DATABASE employee_login_system;"
                Case Else
                    ErrorMsg &= $"Error Code: {ex.Number}" & vbCrLf &
                               $"Message: {ex.Message}"
            End Select
            MessageBox.Show(ErrorMsg, "Database Connection Failed",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        Catch ex As Exception
            ' General errors
            MessageBox.Show($"Unexpected Error:{vbCrLf}{vbCrLf}" &
                          $"Type: {ex.GetType().Name}{vbCrLf}" &
                          $"Message: {ex.Message}{vbCrLf}{vbCrLf}" &
                          $"Check:{vbCrLf}" &
                          $"1. MySQL is running{vbCrLf}" &
                          $"2. Connection string in AppConfig.vb{vbCrLf}" &
                          $"3. MySql.Data package is installed",
                          "Connection Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class
