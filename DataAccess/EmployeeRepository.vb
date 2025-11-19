Imports MySql.Data.MySqlClient
Public Class EmployeeRepository
    ''Authenticate user by username and password
    '' Returns employee object if successful
    Public Function AuthenticateUser(username As String, password As String) As Employee
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                conn.Open()
                Dim query As String = "SELECT * FROM employees WHERE username = @username AND is_active = 1"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim storedPassword As String = reader("password_hash").ToString()
                            '' checks password
                            If password.Trim() = storedPassword.Trim() Then
                                Dim employee As New Employee With {
                                    .EmployeeId = Convert.ToInt32(reader("employee_id")),
                                    .Username = reader("username").ToString(),
                                    .FirstName = reader("first_name").ToString(),
                                    .LastName = reader("last_name").ToString(),
                                    .Email = reader("email").ToString(),
                                    .Role = reader("role").ToString(),
                                    .IsActive = Convert.ToBoolean(reader("is_active")),
                                    .CreatedAt = Convert.ToDateTime(reader("created_at"))
                                }

                                If Not IsDBNull(reader("last_login")) Then
                                    employee.LastLogin = Convert.ToDateTime(reader("last_login"))
                                End If
                                'Update last login time
                                UpdateLastLogin(employee.EmployeeId)
                                Return employee
                            Else
                                Console.WriteLine($"Password mismatch: '{password}' vs '{storedPassword}'")
                                Return Nothing
                            End If
                        Else
                            ' User not found
                            Console.WriteLine($"User not found: {username}")
                            Return Nothing
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            'Log error
            MessageBox.Show($"Authentication error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function
    ''Update last login timestamp
    Private Sub UpdateLastLogin(employeeId As Integer)
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                conn.Open()

                Dim query As String = "UPDATE employees SET last_login =  NOW() WHERE employee_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", employeeId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Failed to update last login: {ex.Message}")
        End Try
    End Sub
    ''Gets all employees
    Public Function GetAllEmployees() As List(Of Employee)
        Dim employees As New List(Of Employee)()

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                conn.Open()

                Dim query As String = "SELECT * FROM employees ORDER BY last_name, first_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim employee As New Employee With {
                                .EmployeeId = Convert.ToInt32(reader("employee_id")),
                                .Username = reader("username").ToString(),
                                .FirstName = reader("first_name").ToString(),
                                .LastName = reader("last_name").ToString(),
                                .Email = reader("email").ToString(),
                                .Role = reader("role").ToString(),
                                .IsActive = Convert.ToBoolean(reader("is_active")),
                                .CreatedAt = Convert.ToDateTime(reader("created_at"))
                            }
                            If Not IsDBNull(reader("last_login")) Then
                                employee.LastLogin = Convert.ToDateTime(reader("last_login"))
                            End If
                            employees.Add(employee)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return employees
    End Function
End Class
