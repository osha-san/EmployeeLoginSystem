<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeDashboard
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
        Me.grpUserInfo = New System.Windows.Forms.GroupBox()
        Me.lblLastLogin = New System.Windows.Forms.Label()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.btnViewProfile = New System.Windows.Forms.Button()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.grpUserInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.CornflowerBlue
        Me.pnlHeader.Controls.Add(Me.btnLogout)
        Me.pnlHeader.Controls.Add(Me.lblWelcome)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(347, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(269, 3)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(75, 23)
        Me.btnLogout.TabIndex = 4
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.ForeColor = System.Drawing.Color.White
        Me.lblWelcome.Location = New System.Drawing.Point(8, 30)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(83, 19)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "Welcome!"
        '
        'grpUserInfo
        '
        Me.grpUserInfo.Controls.Add(Me.lblLastLogin)
        Me.grpUserInfo.Controls.Add(Me.lblRole)
        Me.grpUserInfo.Controls.Add(Me.lblEmail)
        Me.grpUserInfo.Controls.Add(Me.lblUsername)
        Me.grpUserInfo.Location = New System.Drawing.Point(12, 76)
        Me.grpUserInfo.Name = "grpUserInfo"
        Me.grpUserInfo.Size = New System.Drawing.Size(322, 125)
        Me.grpUserInfo.TabIndex = 1
        Me.grpUserInfo.TabStop = False
        Me.grpUserInfo.Text = "Your Information"
        '
        'lblLastLogin
        '
        Me.lblLastLogin.AutoSize = True
        Me.lblLastLogin.Location = New System.Drawing.Point(18, 100)
        Me.lblLastLogin.Name = "lblLastLogin"
        Me.lblLastLogin.Size = New System.Drawing.Size(59, 13)
        Me.lblLastLogin.TabIndex = 2
        Me.lblLastLogin.Text = "LastLogin: "
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.Location = New System.Drawing.Point(18, 75)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(35, 13)
        Me.lblRole.TabIndex = 2
        Me.lblRole.Text = "Role: "
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(18, 51)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(38, 13)
        Me.lblEmail.TabIndex = 1
        Me.lblEmail.Text = "Email: "
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(18, 29)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(63, 13)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "UserName: "
        '
        'btnViewProfile
        '
        Me.btnViewProfile.Location = New System.Drawing.Point(12, 222)
        Me.btnViewProfile.Name = "btnViewProfile"
        Me.btnViewProfile.Size = New System.Drawing.Size(75, 23)
        Me.btnViewProfile.TabIndex = 2
        Me.btnViewProfile.Text = "View Profile"
        Me.btnViewProfile.UseVisualStyleBackColor = True
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Location = New System.Drawing.Point(229, 222)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(106, 23)
        Me.btnChangePassword.TabIndex = 3
        Me.btnChangePassword.Text = "Change Password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'EmployeeDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 450)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.btnViewProfile)
        Me.Controls.Add(Me.grpUserInfo)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "EmployeeDashboard"
        Me.Text = "Employee Dashboard"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.grpUserInfo.ResumeLayout(False)
        Me.grpUserInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents grpUserInfo As GroupBox
    Friend WithEvents lblRole As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblLastLogin As Label
    Friend WithEvents btnViewProfile As Button
    Friend WithEvents btnChangePassword As Button
    Friend WithEvents btnLogout As Button
End Class
