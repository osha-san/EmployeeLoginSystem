Imports System.Linq
Public Class EmployeeDashboard

    Private Sub EmployeeDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set up form
        Me.Text = "Employee Dashboard"
        'Me.WindowState = FormWindowState.Maximized
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Display welcome message
        LoadUserInfo()
    End Sub

    Private Sub LoadUserInfo()
        If Not CurrentUser.IsLoggedIn Then
            MessageBox.Show("No user logged in. Returning to login screen.")
            Me.Close()
            Return
        End If

        Dim employee As Employee = CurrentUser.LoggedInEmployee

        ' Update labels with user info
        lblWelcome.Text = $"Welcome, {employee.FullName}!"
        lblUsername.Text = $"Username: {employee.Username}"
        lblEmail.Text = $"Email: {employee.Email}"
        lblRole.Text = $"Role: {employee.Role}"

        ' Display last login (if available)
        If employee.LastLogin.HasValue Then
            lblLastLogin.Text = $"Last Login: {employee.LastLogin.Value.ToString("MMMM dd, yyyy hh:mm tt")}"
        Else
            lblLastLogin.Text = "Last Login: First time login"
        End If
    End Sub

    Private Sub btnViewProfile_Click(sender As Object, e As EventArgs) Handles btnViewProfile.Click
        Dim employee As Employee = CurrentUser.LoggedInEmployee

        Dim profileInfo As String = $"Employee Profile" & vbCrLf & vbCrLf &
                                   $"ID: {employee.EmployeeId}" & vbCrLf &
                                   $"Name: {employee.FullName}" & vbCrLf &
                                   $"Username: {employee.Username}" & vbCrLf &
                                   $"Email: {employee.Email}" & vbCrLf &
                                   $"Role: {employee.Role}" & vbCrLf &
                                   $"Account Status: {If(employee.IsActive, "Active", "Inactive")}" & vbCrLf &
                                   $"Member Since: {employee.CreatedAt.ToString("MMMM dd, yyyy")}"

        MessageBox.Show(profileInfo, "My Profile", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Change Password Button (placeholder)
    ''' </summary>
    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        MessageBox.Show("Change Password feature coming soon!", "Feature",
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?",
                                                     "Confirm Logout", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Clear current user session
            CurrentUser.Logout()

            ' Close this form
            Me.Close()

            ' Show login form again
            Dim loginForm As LoginForm = Application.OpenForms.OfType(Of LoginForm)().FirstOrDefault()
            If loginForm IsNot Nothing Then
                loginForm.Show()
                ' Clear previous credentials
                loginForm.txtUsername.Clear()
                loginForm.txtPassword.Clear()
                loginForm.txtUsername.Focus()
            End If
        End If
    End Sub

    Private Sub EmployeeDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' When dashboard closes, show login form
        Dim loginForm As LoginForm = Application.OpenForms.OfType(Of LoginForm)().FirstOrDefault()
        If loginForm IsNot Nothing Then
            loginForm.Show()
        End If
    End Sub


End Class