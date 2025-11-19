<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEmployeeForm
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
        Me.grpAccount = New System.Windows.Forms.GroupBox()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.lblPasswordStrength = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGenerateUsername = New System.Windows.Forms.Button()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpPersonal = New System.Windows.Forms.GroupBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.label = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboRole = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpRole = New System.Windows.Forms.GroupBox()
        Me.grpAccount.SuspendLayout()
        Me.grpPersonal.SuspendLayout()
        Me.grpRole.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpAccount
        '
        Me.grpAccount.BackColor = System.Drawing.Color.Transparent
        Me.grpAccount.Controls.Add(Me.txtConfirmPassword)
        Me.grpAccount.Controls.Add(Me.Label5)
        Me.grpAccount.Controls.Add(Me.chkShowPassword)
        Me.grpAccount.Controls.Add(Me.lblPasswordStrength)
        Me.grpAccount.Controls.Add(Me.txtPassword)
        Me.grpAccount.Controls.Add(Me.Label2)
        Me.grpAccount.Controls.Add(Me.btnGenerateUsername)
        Me.grpAccount.Controls.Add(Me.txtUsername)
        Me.grpAccount.Controls.Add(Me.Label1)
        Me.grpAccount.Location = New System.Drawing.Point(20, 20)
        Me.grpAccount.Name = "grpAccount"
        Me.grpAccount.Size = New System.Drawing.Size(390, 180)
        Me.grpAccount.TabIndex = 0
        Me.grpAccount.TabStop = False
        Me.grpAccount.Text = "Account Information"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(99, 114)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(184, 20)
        Me.txtConfirmPassword.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Confirm :"
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.Location = New System.Drawing.Point(26, 152)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(107, 17)
        Me.chkShowPassword.TabIndex = 6
        Me.chkShowPassword.Text = "Show Passwords"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'lblPasswordStrength
        '
        Me.lblPasswordStrength.AutoSize = True
        Me.lblPasswordStrength.BackColor = System.Drawing.Color.Transparent
        Me.lblPasswordStrength.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblPasswordStrength.Location = New System.Drawing.Point(96, 94)
        Me.lblPasswordStrength.Name = "lblPasswordStrength"
        Me.lblPasswordStrength.Size = New System.Drawing.Size(53, 13)
        Me.lblPasswordStrength.TabIndex = 5
        Me.lblPasswordStrength.Text = "Strength:-"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(99, 71)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(184, 20)
        Me.txtPassword.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password:"
        '
        'btnGenerateUsername
        '
        Me.btnGenerateUsername.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnGenerateUsername.Location = New System.Drawing.Point(304, 28)
        Me.btnGenerateUsername.Name = "btnGenerateUsername"
        Me.btnGenerateUsername.Size = New System.Drawing.Size(80, 25)
        Me.btnGenerateUsername.TabIndex = 2
        Me.btnGenerateUsername.Text = "Suggest"
        Me.btnGenerateUsername.UseVisualStyleBackColor = False
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(99, 31)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(184, 20)
        Me.txtUsername.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username:"
        '
        'grpPersonal
        '
        Me.grpPersonal.Controls.Add(Me.txtEmail)
        Me.grpPersonal.Controls.Add(Me.Label6)
        Me.grpPersonal.Controls.Add(Me.Label3)
        Me.grpPersonal.Controls.Add(Me.txtLastName)
        Me.grpPersonal.Controls.Add(Me.txtFirstName)
        Me.grpPersonal.Controls.Add(Me.label)
        Me.grpPersonal.Location = New System.Drawing.Point(12, 217)
        Me.grpPersonal.Name = "grpPersonal"
        Me.grpPersonal.Size = New System.Drawing.Size(410, 133)
        Me.grpPersonal.TabIndex = 1
        Me.grpPersonal.TabStop = False
        Me.grpPersonal.Text = "Personal Information"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(107, 98)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(192, 20)
        Me.txtEmail.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Email: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Last Name: "
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(107, 62)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(192, 20)
        Me.txtLastName.TabIndex = 2
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(107, 27)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(192, 20)
        Me.txtFirstName.TabIndex = 1
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Location = New System.Drawing.Point(31, 30)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(63, 13)
        Me.label.TabIndex = 0
        Me.label.Text = "First Name: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Select Role: "
        '
        'cboRole
        '
        Me.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRole.FormattingEnabled = True
        Me.cboRole.Location = New System.Drawing.Point(107, 31)
        Me.cboRole.Name = "cboRole"
        Me.cboRole.Size = New System.Drawing.Size(192, 21)
        Me.cboRole.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Gray
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(310, 460)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Green
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(180, 460)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Create Account"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'grpRole
        '
        Me.grpRole.Controls.Add(Me.cboRole)
        Me.grpRole.Controls.Add(Me.Label4)
        Me.grpRole.Location = New System.Drawing.Point(12, 367)
        Me.grpRole.Name = "grpRole"
        Me.grpRole.Size = New System.Drawing.Size(410, 79)
        Me.grpRole.TabIndex = 8
        Me.grpRole.TabStop = False
        Me.grpRole.Text = "Role"
        '
        'AddEmployeeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 511)
        Me.Controls.Add(Me.grpRole)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grpPersonal)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpAccount)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "AddEmployeeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Employee"
        Me.grpAccount.ResumeLayout(False)
        Me.grpAccount.PerformLayout()
        Me.grpPersonal.ResumeLayout(False)
        Me.grpPersonal.PerformLayout()
        Me.grpRole.ResumeLayout(False)
        Me.grpRole.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpAccount As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblPasswordStrength As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGenerateUsername As Button
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents grpPersonal As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents label As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents grpRole As GroupBox
End Class
