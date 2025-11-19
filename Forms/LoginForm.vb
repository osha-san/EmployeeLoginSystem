Imports System.Linq
Public Class LoginForm

    Private repository As New EmployeeRepository()

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Employee Login  System"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen

        txtPassword.PasswordChar = "*"c

        Me.AcceptButton = btnLogin

        If Not DatabaseHelper.TestConnection() Then
            MessageBox.Show("Cannot connect to database. Please check your connection settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
        txtUsername.Focus()

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Not ValidateInput() Then
            Return
        End If



        btnLogin.Enabled = False
        btnLogin.Text = "Logging in..."

        'Get values from textboxes
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' DEBUG: Show what we're trying to login with
        'MessageBox.Show($"Attempting login with:{vbCrLf}" &
        '           $"Username: '{username}'{vbCrLf}" &
        '           $"Password: '{password}'{vbCrLf}" &
        '           $"Username Length: {username.Length}{vbCrLf}" &
        '           $"Password Length: {password.Length}",
        '           "Debug Info")

        Try
            'Attempt authentication
            Dim employee As Employee = repository.AuthenticateUser(username, password)

            If employee IsNot Nothing Then
                ' Login Successful!
                MessageBox.Show($"Welcome back, {employee.FullName}!", "Login Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Store current user in a shared location
                CurrentUser.LoggedInEmployee = employee

                'Open appropriate dashboard based on role

                If employee.IsAdmin Then
                    Dim AdminDashboard As New AdminDashboard()
                    AdminDashboard.Show()
                Else
                    Dim empDashboard As New EmployeeDashboard()
                    empDashboard.Show()
                End If

                'Hide LoginForm
                Me.Hide()
            Else
                ' Login Failed
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                'Clear password field for security
                txtPassword.Clear()
                txtPassword.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show($"An error occured during login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            'Re-enable button
            btnLogin.Enabled = True
            btnLogin.Text = "Login"
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter your username.", "Validate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If

        'Check if Password is empty
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        'Check minimum password length 

        If txtPassword.Text.Length < 3 Then
            MessageBox.Show("Password must be at least 3 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        Return True
    End Function
    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.PasswordChar = " "c  ' Show password
        Else
            txtPassword.PasswordChar = "*"c ' Hide password
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnLogin.PerformClick()
            e.Handled = True ' Prevent the "ding" sound
        End If
    End Sub


    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtPassword.Focus() ' Move to password field
            e.Handled = True
        End If
    End Sub


    Private Sub btnTest_Click(sender As Object, e As EventArgs)
        If DatabaseHelper.TestConnection() Then
            MessageBox.Show("✓ Connection successful!" & vbCrLf & vbCrLf &
                           "Database: employee_login_system" & vbCrLf &
                           "Status: Connected",
                           "Success",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information)
        End If
    End Sub


End Class