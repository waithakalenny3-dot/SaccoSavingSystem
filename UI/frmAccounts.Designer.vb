Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmAccounts
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
            Me.grpOpen = New System.Windows.Forms.GroupBox()
            Me.lblMember = New System.Windows.Forms.Label()
            Me.cboMember = New System.Windows.Forms.ComboBox()
            Me.lblType = New System.Windows.Forms.Label()
            Me.cboType = New System.Windows.Forms.ComboBox()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.btnOpen = New System.Windows.Forms.Button()
            Me.grpActions = New System.Windows.Forms.GroupBox()
            Me.btnDeleteAccount = New System.Windows.Forms.Button()
            Me.dgvAccounts = New System.Windows.Forms.DataGridView()
            Me.grpOpen.SuspendLayout()
            Me.grpActions.SuspendLayout()
            CType(Me.dgvAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grpOpen
            '
            Me.grpOpen.Controls.Add(Me.lblMember)
            Me.grpOpen.Controls.Add(Me.cboMember)
            Me.grpOpen.Controls.Add(Me.lblType)
            Me.grpOpen.Controls.Add(Me.cboType)
            Me.grpOpen.Controls.Add(Me.lblNote)
            Me.grpOpen.Controls.Add(Me.btnOpen)
            Me.grpOpen.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpOpen.Location = New System.Drawing.Point(0, 0)
            Me.grpOpen.Name = "grpOpen"
            Me.grpOpen.Size = New System.Drawing.Size(800, 92)
            Me.grpOpen.TabIndex = 0
            Me.grpOpen.TabStop = False
            Me.grpOpen.Text = "Open new account"
            '
            'lblMember
            '
            Me.lblMember.AutoSize = True
            Me.lblMember.Location = New System.Drawing.Point(15, 27)
            Me.lblMember.Name = "lblMember"
            Me.lblMember.TabIndex = 0
            Me.lblMember.Text = "Member:*"
            '
            'cboMember
            '
            Me.cboMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboMember.Location = New System.Drawing.Point(85, 23)
            Me.cboMember.Name = "cboMember"
            Me.cboMember.Size = New System.Drawing.Size(250, 25)
            Me.cboMember.TabIndex = 1
            '
            'lblType
            '
            Me.lblType.AutoSize = True
            Me.lblType.Location = New System.Drawing.Point(355, 27)
            Me.lblType.Name = "lblType"
            Me.lblType.TabIndex = 2
            Me.lblType.Text = "Account type:*"
            '
            'cboType
            '
            Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboType.Location = New System.Drawing.Point(460, 23)
            Me.cboType.Name = "cboType"
            Me.cboType.Size = New System.Drawing.Size(170, 25)
            Me.cboType.TabIndex = 3
            '
            'lblNote
            '
            Me.lblNote.AutoSize = True
            Me.lblNote.ForeColor = System.Drawing.Color.Gray
            Me.lblNote.Location = New System.Drawing.Point(15, 58)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.TabIndex = 4
            Me.lblNote.Text = "A unique account number (AC00001, AC00002, ...) is generated automatically."
            '
            'btnOpen
            '
            Me.btnOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.btnOpen.ForeColor = System.Drawing.Color.White
            Me.btnOpen.Location = New System.Drawing.Point(645, 45)
            Me.btnOpen.Name = "btnOpen"
            Me.btnOpen.Size = New System.Drawing.Size(130, 32)
            Me.btnOpen.TabIndex = 5
            Me.btnOpen.Text = "Open account"
            Me.btnOpen.UseVisualStyleBackColor = False
            '
            'grpActions
            '
            Me.grpActions.Controls.Add(Me.btnDeleteAccount)
            Me.grpActions.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.grpActions.Location = New System.Drawing.Point(0, 470)
            Me.grpActions.Name = "grpActions"
            Me.grpActions.Size = New System.Drawing.Size(800, 50)
            Me.grpActions.TabIndex = 1
            Me.grpActions.TabStop = False
            '
            'btnDeleteAccount
            '
            Me.btnDeleteAccount.Location = New System.Drawing.Point(15, 12)
            Me.btnDeleteAccount.Name = "btnDeleteAccount"
            Me.btnDeleteAccount.Size = New System.Drawing.Size(190, 30)
            Me.btnDeleteAccount.TabIndex = 0
            Me.btnDeleteAccount.Text = "Delete selected account"
            Me.btnDeleteAccount.UseVisualStyleBackColor = True
            '
            'dgvAccounts
            '
            Me.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvAccounts.Location = New System.Drawing.Point(0, 92)
            Me.dgvAccounts.Name = "dgvAccounts"
            Me.dgvAccounts.Size = New System.Drawing.Size(800, 378)
            Me.dgvAccounts.TabIndex = 2
            '
            'frmAccounts
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(800, 520)
            Me.Controls.Add(Me.dgvAccounts)
            Me.Controls.Add(Me.grpOpen)
            Me.Controls.Add(Me.grpActions)
            Me.Name = "frmAccounts"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Account Management"
            Me.grpOpen.ResumeLayout(False)
            Me.grpOpen.PerformLayout()
            Me.grpActions.ResumeLayout(False)
            CType(Me.dgvAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents grpOpen As System.Windows.Forms.GroupBox
        Friend WithEvents lblMember As System.Windows.Forms.Label
        Friend WithEvents cboMember As System.Windows.Forms.ComboBox
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents cboType As System.Windows.Forms.ComboBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents btnOpen As System.Windows.Forms.Button
        Friend WithEvents grpActions As System.Windows.Forms.GroupBox
        Friend WithEvents btnDeleteAccount As System.Windows.Forms.Button
        Friend WithEvents dgvAccounts As System.Windows.Forms.DataGridView

    End Class
End Namespace
