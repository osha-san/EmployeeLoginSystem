<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblEmployeeCount = New System.Windows.Forms.Label()
        Me.lblAdminCount = New System.Windows.Forms.Label()
        Me.lblActiveEmployees = New System.Windows.Forms.Label()
        Me.lblTotalEmployees = New System.Windows.Forms.Label()
        Me.dgvEmployees = New System.Windows.Forms.DataGridView()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnDeleteEmployee = New System.Windows.Forms.Button()
        Me.btnAddEmployee = New System.Windows.Forms.Button()
        Me.btnViewDetails = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.SeaGreen
        Me.pnlHeader.Controls.Add(Me.btnLogout)
        Me.pnlHeader.Controls.Add(Me.lblWelcome)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(714, 74)
        Me.pnlHeader.TabIndex = 0
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(627, 25)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(75, 23)
        Me.btnLogout.TabIndex = 1
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.Location = New System.Drawing.Point(12, 26)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(126, 22)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "Admin Panel"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.lblEmployeeCount)
        Me.Panel1.Controls.Add(Me.lblAdminCount)
        Me.Panel1.Controls.Add(Me.lblActiveEmployees)
        Me.Panel1.Controls.Add(Me.lblTotalEmployees)
        Me.Panel1.Location = New System.Drawing.Point(0, 73)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(714, 82)
        Me.Panel1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(62, 33)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(640, 20)
        Me.txtSearch.TabIndex = 4
        Me.txtSearch.Text = "Search Employees..."
        '
        'lblEmployeeCount
        '
        Me.lblEmployeeCount.AutoSize = True
        Me.lblEmployeeCount.Location = New System.Drawing.Point(515, 8)
        Me.lblEmployeeCount.Name = "lblEmployeeCount"
        Me.lblEmployeeCount.Size = New System.Drawing.Size(61, 13)
        Me.lblEmployeeCount.TabIndex = 3
        Me.lblEmployeeCount.Text = "Employees:"
        '
        'lblAdminCount
        '
        Me.lblAdminCount.AutoSize = True
        Me.lblAdminCount.Location = New System.Drawing.Point(347, 8)
        Me.lblAdminCount.Name = "lblAdminCount"
        Me.lblAdminCount.Size = New System.Drawing.Size(44, 13)
        Me.lblAdminCount.TabIndex = 2
        Me.lblAdminCount.Text = "Admins:"
        '
        'lblActiveEmployees
        '
        Me.lblActiveEmployees.AutoSize = True
        Me.lblActiveEmployees.Location = New System.Drawing.Point(176, 8)
        Me.lblActiveEmployees.Name = "lblActiveEmployees"
        Me.lblActiveEmployees.Size = New System.Drawing.Size(40, 13)
        Me.lblActiveEmployees.TabIndex = 1
        Me.lblActiveEmployees.Text = "Active:"
        '
        'lblTotalEmployees
        '
        Me.lblTotalEmployees.AutoSize = True
        Me.lblTotalEmployees.Location = New System.Drawing.Point(12, 8)
        Me.lblTotalEmployees.Name = "lblTotalEmployees"
        Me.lblTotalEmployees.Size = New System.Drawing.Size(34, 13)
        Me.lblTotalEmployees.TabIndex = 0
        Me.lblTotalEmployees.Text = "Total:"
        '
        'dgvEmployees
        '
        Me.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployees.Location = New System.Drawing.Point(0, 150)
        Me.dgvEmployees.Name = "dgvEmployees"
        Me.dgvEmployees.Size = New System.Drawing.Size(714, 228)
        Me.dgvEmployees.TabIndex = 2
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.lblStatus)
        Me.pnlBottom.Controls.Add(Me.btnDeleteEmployee)
        Me.pnlBottom.Controls.Add(Me.btnAddEmployee)
        Me.pnlBottom.Controls.Add(Me.btnViewDetails)
        Me.pnlBottom.Controls.Add(Me.btnRefresh)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 381)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(714, 69)
        Me.pnlBottom.TabIndex = 3
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(9, 39)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Status"
        '
        'btnDeleteEmployee
        '
        Me.btnDeleteEmployee.Location = New System.Drawing.Point(627, 3)
        Me.btnDeleteEmployee.Name = "btnDeleteEmployee"
        Me.btnDeleteEmployee.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteEmployee.TabIndex = 4
        Me.btnDeleteEmployee.Text = "Delete"
        Me.btnDeleteEmployee.UseVisualStyleBackColor = True
        '
        'btnAddEmployee
        '
        Me.btnAddEmployee.Location = New System.Drawing.Point(536, 3)
        Me.btnAddEmployee.Name = "btnAddEmployee"
        Me.btnAddEmployee.Size = New System.Drawing.Size(75, 23)
        Me.btnAddEmployee.TabIndex = 3
        Me.btnAddEmployee.Text = "Add"
        Me.btnAddEmployee.UseVisualStyleBackColor = True
        '
        'btnViewDetails
        '
        Me.btnViewDetails.Location = New System.Drawing.Point(87, 3)
        Me.btnViewDetails.Name = "btnViewDetails"
        Me.btnViewDetails.Size = New System.Drawing.Size(75, 23)
        Me.btnViewDetails.TabIndex = 1
        Me.btnViewDetails.Text = "View Details"
        Me.btnViewDetails.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(6, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'AdminDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 450)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.dgvEmployees)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "AdminDashboard"
        Me.Text = "AdminDashboard"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblEmployeeCount As Label
    Friend WithEvents lblAdminCount As Label
    Friend WithEvents lblActiveEmployees As Label
    Friend WithEvents lblTotalEmployees As Label
    Friend WithEvents dgvEmployees As DataGridView
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnDeleteEmployee As Button
    Friend WithEvents btnAddEmployee As Button
    Friend WithEvents btnViewDetails As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents Label3 As Label
End Class
