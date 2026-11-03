Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmUsers
        Inherits System.Windows.Forms.Form

        Private components As System.ComponentModel.IContainer

        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.grpAdd = New System.Windows.Forms.GroupBox()
            Me.lblUsername = New System.Windows.Forms.Label()
            Me.txtUsername = New System.Windows.Forms.TextBox()
            Me.lblFullName = New System.Windows.Forms.Label()
            Me.txtFullName = New System.Windows.Forms.TextBox()
            Me.lblRole = New System.Windows.Forms.Label()
            Me.cboRole = New System.Windows.Forms.ComboBox()
            Me.lblPassword = New System.Windows.Forms.Label()
            Me.txtPassword = New System.Windows.Forms.TextBox()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.lblHint = New System.Windows.Forms.Label()
            Me.grpManage = New System.Windows.Forms.GroupBox()
            Me.lblNewPass = New System.Windows.Forms.Label()
            Me.txtNewPassword = New System.Windows.Forms.TextBox()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.lblManageHint = New System.Windows.Forms.Label()
            Me.dgvUsers = New System.Windows.Forms.DataGridView()
            Me.grpAdd.SuspendLayout()
            Me.grpManage.SuspendLayout()
            CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grpAdd
            '
            Me.grpAdd.Controls.Add(Me.lblUsername)
            Me.grpAdd.Controls.Add(Me.txtUsername)
            Me.grpAdd.Controls.Add(Me.lblFullName)
            Me.grpAdd.Controls.Add(Me.txtFullName)
            Me.grpAdd.Controls.Add(Me.lblRole)
            Me.grpAdd.Controls.Add(Me.cboRole)
            Me.grpAdd.Controls.Add(Me.lblPassword)
            Me.grpAdd.Controls.Add(Me.txtPassword)
            Me.grpAdd.Controls.Add(Me.btnAdd)
            Me.grpAdd.Controls.Add(Me.lblHint)
            Me.grpAdd.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpAdd.Location = New System.Drawing.Point(0, 0)
            Me.grpAdd.Name = "grpAdd"
            Me.grpAdd.Size = New System.Drawing.Size(720, 140)
            Me.grpAdd.TabIndex = 0
            Me.grpAdd.TabStop = False
            Me.grpAdd.Text = "Add user"
            '
            'lblUsername
            '
            Me.lblUsername.AutoSize = True
            Me.lblUsername.Location = New System.Drawing.Point(15, 33)
            Me.lblUsername.Name = "lblUsername"
            Me.lblUsername.TabIndex = 0
            Me.lblUsername.Text = "Username:*"
            '
            'txtUsername
            '
            Me.txtUsername.Location = New System.Drawing.Point(105, 29)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.Size = New System.Drawing.Size(150, 25)
            Me.txtUsername.TabIndex = 1
            '
            'lblFullName
            '
            Me.lblFullName.AutoSize = True
            Me.lblFullName.Location = New System.Drawing.Point(280, 33)
            Me.lblFullName.Name = "lblFullName"
            Me.lblFullName.TabIndex = 2
            Me.lblFullName.Text = "Full name:*"
            '
            'txtFullName
            '
            Me.txtFullName.Location = New System.Drawing.Point(360, 29)
            Me.txtFullName.Name = "txtFullName"
            Me.txtFullName.Size = New System.Drawing.Size(220, 25)
            Me.txtFullName.TabIndex = 3
            '
            'lblRole
            '
            Me.lblRole.AutoSize = True
            Me.lblRole.Location = New System.Drawing.Point(15, 73)
            Me.lblRole.Name = "lblRole"
            Me.lblRole.TabIndex = 4
            Me.lblRole.Text = "Role:*"
            '
            'cboRole
            '
            Me.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboRole.Location = New System.Drawing.Point(105, 69)
            Me.cboRole.Name = "cboRole"
            Me.cboRole.Size = New System.Drawing.Size(150, 25)
            Me.cboRole.TabIndex = 5
            '
            'lblPassword
            '
            Me.lblPassword.AutoSize = True
            Me.lblPassword.Location = New System.Drawing.Point(280, 73)
            Me.lblPassword.Name = "lblPassword"
            Me.lblPassword.TabIndex = 6
            Me.lblPassword.Text = "Password:*"
            '
            'txtPassword
            '
            Me.txtPassword.Location = New System.Drawing.Point(360, 69)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
            Me.txtPassword.Size = New System.Drawing.Size(220, 25)
            Me.txtPassword.TabIndex = 7
            '
            'btnAdd
            '
            Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.btnAdd.ForeColor = System.Drawing.Color.White
            Me.btnAdd.Location = New System.Drawing.Point(105, 103)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(130, 30)
            Me.btnAdd.TabIndex = 8
            Me.btnAdd.Text = "Add user"
            Me.btnAdd.UseVisualStyleBackColor = False
            '
            'lblHint
            '
            Me.lblHint.AutoSize = True
            Me.lblHint.ForeColor = System.Drawing.Color.Gray
            Me.lblHint.Location = New System.Drawing.Point(280, 109)
            Me.lblHint.Name = "lblHint"
            Me.lblHint.TabIndex = 9
            Me.lblHint.Text = "Passwords are stored as salted SHA-256 hashes."
            '
            'grpManage
            '
            Me.grpManage.Controls.Add(Me.lblNewPass)
            Me.grpManage.Controls.Add(Me.txtNewPassword)
            Me.grpManage.Controls.Add(Me.btnReset)
            Me.grpManage.Controls.Add(Me.btnDelete)
            Me.grpManage.Controls.Add(Me.lblManageHint)
            Me.grpManage.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.grpManage.Location = New System.Drawing.Point(0, 412)
            Me.grpManage.Name = "grpManage"
            Me.grpManage.Size = New System.Drawing.Size(720, 88)
            Me.grpManage.TabIndex = 1
            Me.grpManage.TabStop = False
            Me.grpManage.Text = "Manage selected user"
            '
            'lblNewPass
            '
            Me.lblNewPass.AutoSize = True
            Me.lblNewPass.Location = New System.Drawing.Point(15, 22)
            Me.lblNewPass.Name = "lblNewPass"
            Me.lblNewPass.TabIndex = 0
            Me.lblNewPass.Text = "New password:"
            '
            'txtNewPassword
            '
            Me.txtNewPassword.Location = New System.Drawing.Point(120, 18)
            Me.txtNewPassword.Name = "txtNewPassword"
            Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
            Me.txtNewPassword.Size = New System.Drawing.Size(150, 25)
            Me.txtNewPassword.TabIndex = 1
            '
            'btnReset
            '
            Me.btnReset.Enabled = False
            Me.btnReset.Location = New System.Drawing.Point(290, 16)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(140, 28)
            Me.btnReset.TabIndex = 2
            Me.btnReset.Text = "Reset password"
            Me.btnReset.UseVisualStyleBackColor = True
            '
            'btnDelete
            '
            Me.btnDelete.Enabled = False
            Me.btnDelete.Location = New System.Drawing.Point(450, 16)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(130, 28)
            Me.btnDelete.TabIndex = 3
            Me.btnDelete.Text = "Delete user"
            Me.btnDelete.UseVisualStyleBackColor = True
            '
            'lblManageHint
            '
            Me.lblManageHint.AutoSize = True
            Me.lblManageHint.ForeColor = System.Drawing.Color.Gray
            Me.lblManageHint.Location = New System.Drawing.Point(15, 54)
            Me.lblManageHint.Name = "lblManageHint"
            Me.lblManageHint.TabIndex = 4
            Me.lblManageHint.Text = "Select a user in the table first."
            '
            'dgvUsers
            '
            Me.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvUsers.Location = New System.Drawing.Point(0, 140)
            Me.dgvUsers.Name = "dgvUsers"
            Me.dgvUsers.Size = New System.Drawing.Size(720, 272)
            Me.dgvUsers.TabIndex = 2
            '
            'frmUsers
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(720, 500)
            Me.Controls.Add(Me.dgvUsers)
            Me.Controls.Add(Me.grpAdd)
            Me.Controls.Add(Me.grpManage)
            Me.Name = "frmUsers"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "User Management (Administrator)"
            Me.grpAdd.ResumeLayout(False)
            Me.grpAdd.PerformLayout()
            Me.grpManage.ResumeLayout(False)
            Me.grpManage.PerformLayout()
            CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents grpAdd As System.Windows.Forms.GroupBox
        Friend WithEvents lblUsername As System.Windows.Forms.Label
        Friend WithEvents txtUsername As System.Windows.Forms.TextBox
        Friend WithEvents lblFullName As System.Windows.Forms.Label
        Friend WithEvents txtFullName As System.Windows.Forms.TextBox
        Friend WithEvents lblRole As System.Windows.Forms.Label
        Friend WithEvents cboRole As System.Windows.Forms.ComboBox
        Friend WithEvents lblPassword As System.Windows.Forms.Label
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents lblHint As System.Windows.Forms.Label
        Friend WithEvents grpManage As System.Windows.Forms.GroupBox
        Friend WithEvents lblNewPass As System.Windows.Forms.Label
        Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents lblManageHint As System.Windows.Forms.Label
        Friend WithEvents dgvUsers As System.Windows.Forms.DataGridView

    End Class
End Namespace
