Imports MySql.Data.MySqlClient
Public Class AddEmployeeForm
    Private repository As New EmployeeRepository()
    Private Sub AddEmployeeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Add New Employee"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        cboRole.Items.Clear()
        cboRole.Items.Add("employee")
        cboRole.Items.Add("Admin")
        cboRole.SelectedIndex = 0

        txtPassword.PasswordChar = "*"c
        txtConfirmPassword.PasswordChar = "*"c

        txtUsername.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
            $"Create new employee account?{vbCrLf}{vbCrLf}" &
            $"Username: {txtUsername.Text}{vbCrLf}" &
            $"Name: {txtFirstName.Text} {txtLastName.Text}{vbCrLf}" &
            $"Role: {cboRole.SelectedItem.ToString()}",
            "Confirm",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Return
        End If

        btnSave.Enabled = False
        btnSave.Text = "Creating..."

        Try
            Dim success As Boolean = CreateEmployee()

            If success Then
                MessageBox.Show(
                "Employee account created successfully!" & vbCrLf & vbCrLf &
                    $"Username: {txtUsername.Text}" & vbCrLf &
                    $"The employee can now log in.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                'Set dialog result and close
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show($"Error creating: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnSave.Enabled = True
            btnSave.Text = "Create Account"
        End Try
    End Sub
    Private Function CreateEmployee() As Boolean
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                conn.Open()

                If UsernameExists(txtUsername.Text.Trim(), conn) Then
                    MessageBox.Show("Username already exists. Please choose another.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUsername.Focus()
                    Return False
                End If

                If EmailExists(txtEmail.Text.Trim(), conn) Then
                    MessageBox.Show("Email already exists. Please use another.",
                                  "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtEmail.Focus()
                    Return False
                End If

                Dim query As String = "INSERT INTO employees" &
                    "(username, password_hash, first_name, last_name, email, role, is_active) " &
                    "VALUES (@username, @password, @firstName, @lastName, @email, @role, 1)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim()) 'TODO: Hash this
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim())
                    cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim())
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@role", cboRole.SelectedItem.ToString())

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    'Check if username already exists
    Private Function UsernameExists(username As String, conn As MySqlConnection) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM employees WHERE username = @username"
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", username)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count > 0
        End Using
    End Function

    'Check if email already exists
    Private Function EmailExists(email As String, conn As MySqlConnection) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM employees WHERE email = @email"
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@email", email)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count > 0
        End Using
    End Function

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter a username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If
        If txtUsername.Text.Length < 3 Then
            MessageBox.Show("Username must be at least 3 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If
        ' Check for spaces in username
        If txtUsername.Text.Contains(" ") Then
            MessageBox.Show("Username cannot contain spaces.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If

        ' Password validation
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter a password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        If txtPassword.Text.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        ' Confirm password
        If txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtConfirmPassword.Focus()
            Return False
        End If

        ' First name
        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MessageBox.Show("Please enter first name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstName.Focus()
            Return False
        End If

        ' Last name
        If String.IsNullOrWhiteSpace(txtLastName.Text) Then
            MessageBox.Show("Please enter last name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLastName.Focus()
            Return False
        End If

        ' Email validation
        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Please enter email address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return False
        End If

        If Not IsValidEmail(txtEmail.Text) Then
            MessageBox.Show("Please enter a valid email address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return False
        End If

        ' Role selection
        If cboRole.SelectedIndex = -1 Then
            MessageBox.Show("Please select a role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboRole.Focus()
            Return False
        End If

        Return True
    End Function
    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr = New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function
    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.PasswordChar = " "c
            txtConfirmPassword.PasswordChar = " "c
        Else
            txtPassword.PasswordChar = "*"c
            txtConfirmPassword.PasswordChar = "*"c
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Check if form has unsaved changes
        If HasUnsavedChanges() Then
            Dim result As DialogResult = MessageBox.Show(
                "Are you sure you want to cancel? All data will be lost.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If result = DialogResult.No Then
                Return
            End If
        End If

        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' Check if form has any data entered
    ''' </summary>
    Private Function HasUnsavedChanges() As Boolean
        Return Not String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
               Not String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
               Not String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
               Not String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
               Not String.IsNullOrWhiteSpace(txtEmail.Text)
    End Function

    ''' <summary>
    ''' Password strength indicator (real-time)
    ''' </summary>
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        Dim password As String = txtPassword.Text
        Dim strength As String = "Weak"
        Dim color As Color = Color.Red

        If password.Length >= 8 Then
            strength = "Medium"
            color = Color.Orange

            ' Check for strong password (has uppercase, lowercase, number, special char)
            Dim hasUpper As Boolean = password.Any(Function(c) Char.IsUpper(c))
            Dim hasLower As Boolean = password.Any(Function(c) Char.IsLower(c))
            Dim hasDigit As Boolean = password.Any(Function(c) Char.IsDigit(c))
            Dim hasSpecial As Boolean = password.Any(Function(c) Not Char.IsLetterOrDigit(c))

            If hasUpper AndAlso hasLower AndAlso hasDigit AndAlso hasSpecial Then
                strength = "Strong"
                color = Color.Green
            End If
        End If

        lblPasswordStrength.Text = $"Strength: {strength}"
        lblPasswordStrength.ForeColor = color
    End Sub

    ''' <summary>
    ''' Auto-generate username suggestion
    ''' </summary>
    Private Sub btnGenerateUsername_Click(sender As Object, e As EventArgs) Handles btnGenerateUsername.Click
        Dim firstName As String = txtFirstName.Text.Trim().ToLower()
        Dim lastName As String = txtLastName.Text.Trim().ToLower()

        If String.IsNullOrEmpty(firstName) Or String.IsNullOrEmpty(lastName) Then
            MessageBox.Show("Please enter first and last name first.", "Info",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Generate username: first letter of first name + last name
        Dim suggestedUsername As String = firstName.Substring(0, 1) & lastName
        txtUsername.Text = suggestedUsername
    End Sub


End Class