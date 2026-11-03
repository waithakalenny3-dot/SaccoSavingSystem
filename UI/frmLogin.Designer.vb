Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmLogin
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
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.grpLogin = New System.Windows.Forms.GroupBox()
            Me.lblUser = New System.Windows.Forms.Label()
            Me.txtUsername = New System.Windows.Forms.TextBox()
            Me.lblPass = New System.Windows.Forms.Label()
            Me.txtPassword = New System.Windows.Forms.TextBox()
            Me.lblError = New System.Windows.Forms.Label()
            Me.btnLogin = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.pnlHeader.SuspendLayout()
            Me.grpLogin.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.pnlHeader.Controls.Add(Me.lblTitle)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(600, 70)
            Me.pnlHeader.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.White
            Me.lblTitle.Location = New System.Drawing.Point(0, 0)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(600, 70)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "SACCO SAVINGS & LOAN MANAGEMENT SYSTEM"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grpLogin
            '
            Me.grpLogin.Controls.Add(Me.lblUser)
            Me.grpLogin.Controls.Add(Me.txtUsername)
            Me.grpLogin.Controls.Add(Me.lblPass)
            Me.grpLogin.Controls.Add(Me.txtPassword)
            Me.grpLogin.Controls.Add(Me.lblError)
            Me.grpLogin.Controls.Add(Me.btnLogin)
            Me.grpLogin.Controls.Add(Me.btnCancel)
            Me.grpLogin.Location = New System.Drawing.Point(100, 100)
            Me.grpLogin.Name = "grpLogin"
            Me.grpLogin.Size = New System.Drawing.Size(400, 210)
            Me.grpLogin.TabIndex = 1
            Me.grpLogin.TabStop = False
            Me.grpLogin.Text = "Sign in to your account"
            '
            'lblUser
            '
            Me.lblUser.AutoSize = True
            Me.lblUser.Location = New System.Drawing.Point(30, 42)
            Me.lblUser.Name = "lblUser"
            Me.lblUser.TabIndex = 0
            Me.lblUser.Text = "Username:"
            '
            'txtUsername
            '
            Me.txtUsername.Location = New System.Drawing.Point(140, 38)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.Size = New System.Drawing.Size(220, 25)
            Me.txtUsername.TabIndex = 1
            '
            'lblPass
            '
            Me.lblPass.AutoSize = True
            Me.lblPass.Location = New System.Drawing.Point(30, 82)
            Me.lblPass.Name = "lblPass"
            Me.lblPass.TabIndex = 2
            Me.lblPass.Text = "Password:"
            '
            'txtPassword
            '
            Me.txtPassword.Location = New System.Drawing.Point(140, 78)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
            Me.txtPassword.Size = New System.Drawing.Size(220, 25)
            Me.txtPassword.TabIndex = 3
            '
            'lblError
            '
            Me.lblError.ForeColor = System.Drawing.Color.Firebrick
            Me.lblError.Location = New System.Drawing.Point(30, 113)
            Me.lblError.Name = "lblError"
            Me.lblError.Size = New System.Drawing.Size(340, 20)
            Me.lblError.TabIndex = 4
            Me.lblError.Visible = False
            '
            'btnLogin
            '
            Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.btnLogin.ForeColor = System.Drawing.Color.White
            Me.btnLogin.Location = New System.Drawing.Point(140, 150)
            Me.btnLogin.Name = "btnLogin"
            Me.btnLogin.Size = New System.Drawing.Size(110, 34)
            Me.btnLogin.TabIndex = 5
            Me.btnLogin.Text = "Login"
            Me.btnLogin.UseVisualStyleBackColor = False
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(262, 150)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(105, 34)
            Me.btnCancel.TabIndex = 6
            Me.btnCancel.Text = "Exit"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'frmLogin
            '
            Me.AcceptButton = Me.btnLogin
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(600, 340)
            Me.Controls.Add(Me.grpLogin)
            Me.Controls.Add(Me.pnlHeader)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmLogin"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Login - Sacco Manager"
            Me.pnlHeader.ResumeLayout(False)
            Me.grpLogin.ResumeLayout(False)
            Me.grpLogin.PerformLayout()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents grpLogin As System.Windows.Forms.GroupBox
        Friend WithEvents lblUser As System.Windows.Forms.Label
        Friend WithEvents txtUsername As System.Windows.Forms.TextBox
        Friend WithEvents lblPass As System.Windows.Forms.Label
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
        Friend WithEvents lblError As System.Windows.Forms.Label
        Friend WithEvents btnLogin As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button

    End Class
End Namespace
