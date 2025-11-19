Imports System.Linq

Imports MySql.Data.MySqlClient

Public Class AdminDashboard
    Private repository As New EmployeeRepository()

    ''' <summary>
    ''' Form Load Event
    ''' </summary>
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Verify user is actually an admin
        If Not CurrentUser.IsAdmin Then
            MessageBox.Show("Access Denied. Admin privileges required.",
                          "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If

        ' Set up form
        Me.Text = "Admin Dashboard"
        'Me.WindowState = FormWindowState.Maximized
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Display welcome message
        lblWelcome.Text = $"Admin Panel - Welcome, {CurrentUser.FullName}!"

        ' Load employee list
        LoadEmployeeList()

        ' Setup DataGridView
        SetupDataGridView()
    End Sub

    ''' <summary>
    ''' Configure the DataGridView appearance and behavior
    ''' </summary>
    Private Sub SetupDataGridView()
        With dgvEmployees
            ' Appearance
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False

            ' Alternating row colors for better readability
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

            ' Column headers
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        End With
    End Sub

    ''' <summary>
    ''' Load all employees into the DataGridView
    ''' </summary>
    Private Sub LoadEmployeeList()
        Try
            ' Show loading message
            lblStatus.Text = "Loading employees..."
            lblStatus.ForeColor = Color.Blue

            ' Get all employees from database
            Dim employees As List(Of Employee) = repository.GetAllEmployees()

            ' Create a DataTable for binding
            Dim dt As New DataTable()
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Username", GetType(String))
            dt.Columns.Add("Full Name", GetType(String))
            dt.Columns.Add("Email", GetType(String))
            dt.Columns.Add("Role", GetType(String))
            dt.Columns.Add("Status", GetType(String))
            dt.Columns.Add("Created", GetType(String))

            ' Populate DataTable
            For Each emp As Employee In employees
                dt.Rows.Add(
                    emp.EmployeeId,
                    emp.Username,
                    emp.FullName,
                    emp.Email,
                    emp.Role.ToUpper(),
                    If(emp.IsActive, "Active", "Inactive"),
                    emp.CreatedAt.ToString("MM/dd/yyyy")
                )
            Next

            ' Bind to DataGridView
            dgvEmployees.DataSource = dt

            ' Update status
            lblStatus.Text = $"Total Employees: {employees.Count}"
            lblStatus.ForeColor = Color.Green

            ' Update statistics
            UpdateStatistics(employees)

        Catch ex As Exception
            lblStatus.Text = "Error loading employees"
            lblStatus.ForeColor = Color.Red
            MessageBox.Show($"Error: {ex.Message}", "Load Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Update dashboard statistics
    ''' </summary>

    Private Sub UpdateStatistics(employees As List(Of Employee))
        Dim totalCount As Integer = employees.Count
        Dim activeCount As Integer = 0
        Dim adminCount As Integer = 0

        ' Loop through and count manually
        For Each emp As Employee In employees
            If emp.IsActive Then
                activeCount += 1
            End If

            If emp.IsAdmin Then
                adminCount += 1
            End If
        Next

        Dim employeeCount As Integer = totalCount - adminCount

        lblTotalEmployees.Text = $"Total: {totalCount}"
        lblActiveEmployees.Text = $"Active: {activeCount}"
        lblAdminCount.Text = $"Admins: {adminCount}"
        lblEmployeeCount.Text = $"Employees: {employeeCount}"
    End Sub

    ''''''''''''''''''btnRefresh
    ' Loop through and count manually


    ''' <summary>
    ''' Refresh Button - Reload employee list
    ''' </summary>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadEmployeeList()
    End Sub

    ''' <summary>
    ''' View Selected Employee Details
    ''' </summary>
    Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an employee first.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvEmployees.SelectedRows(0)

        Dim details As String = "Employee Details" & vbCrLf & vbCrLf &
                               $"ID: {selectedRow.Cells("ID").Value}" & vbCrLf &
                               $"Username: {selectedRow.Cells("Username").Value}" & vbCrLf &
                               $"Name: {selectedRow.Cells("Full Name").Value}" & vbCrLf &
                               $"Email: {selectedRow.Cells("Email").Value}" & vbCrLf &
                               $"Role: {selectedRow.Cells("Role").Value}" & vbCrLf &
                               $"Status: {selectedRow.Cells("Status").Value}" & vbCrLf &
                               $"Created: {selectedRow.Cells("Created").Value}"

        MessageBox.Show(details, "Employee Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Search/Filter Employees
    ''' </summary>
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If dgvEmployees.DataSource Is Nothing Then Return

        Dim dt As DataTable = CType(dgvEmployees.DataSource, DataTable)
        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        If String.IsNullOrEmpty(searchText) Then
            ' Show all rows
            For Each row As DataGridViewRow In dgvEmployees.Rows
                row.Visible = True
            Next
        Else
            ' Filter rows
            For Each row As DataGridViewRow In dgvEmployees.Rows
                Dim visible As Boolean = False

                ' Search in multiple columns
                If row.Cells("Username").Value.ToString().ToLower().Contains(searchText) OrElse
                   row.Cells("Full Name").Value.ToString().ToLower().Contains(searchText) OrElse
                   row.Cells("Email").Value.ToString().ToLower().Contains(searchText) Then
                    visible = True
                End If

                row.Visible = visible
            Next
        End If
    End Sub

    ''' <summary>
    ''' Add New Employee Button (Placeholder)
    ''' </summary>
    Private Sub btnAddEmployee_Click(sender As Object, e As EventArgs) Handles btnAddEmployee.Click
        Try
            Using addForm As New AddEmployeeForm()
                Dim result As DialogResult = addForm.ShowDialog()

                If result = DialogResult.OK Then
                    LoadEmployeeList()
                    MessageBox.Show("Employee list has been refreshed.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error opening add employee form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    ''' <summary>
    ''' Delete Employee Button (Placeholder)
    ''' </summary>
    Private Sub btnDeleteEmployee_Click(sender As Object, e As EventArgs) Handles btnDeleteEmployee.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an employee to delete.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        MessageBox.Show("Delete Employee feature coming soon!" & vbCrLf & vbCrLf &
                       "Best practice: Don't actually delete records." & vbCrLf &
                       "Instead, mark them as inactive (soft delete).",
                       "Feature", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Logout Button
    ''' </summary>
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?",
                                                     "Confirm Logout", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            CurrentUser.Logout()
            Me.Close()

            Dim loginForm As LoginForm = Application.OpenForms.OfType(Of LoginForm)().FirstOrDefault()
            If loginForm IsNot Nothing Then
                loginForm.Show()
                loginForm.txtUsername.Clear()
                loginForm.txtPassword.Clear()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Handle form closing
    ''' </summary>
    Private Sub AdminDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim loginForm As LoginForm = Application.OpenForms.OfType(Of LoginForm)().FirstOrDefault()
        If loginForm IsNot Nothing Then
            loginForm.Show()
        End If
    End Sub

End Class

