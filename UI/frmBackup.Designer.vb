Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmBackup
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
            Me.grpBackup = New System.Windows.Forms.GroupBox()
            Me.lblDbTitle = New System.Windows.Forms.Label()
            Me.lblDbPath = New System.Windows.Forms.Label()
            Me.btnBackup = New System.Windows.Forms.Button()
            Me.grpRestore = New System.Windows.Forms.GroupBox()
            Me.btnRestore = New System.Windows.Forms.Button()
            Me.lblWarn = New System.Windows.Forms.Label()
            Me.grpBackup.SuspendLayout()
            Me.grpRestore.SuspendLayout()
            Me.SuspendLayout()
            '
            'grpBackup
            '
            Me.grpBackup.Controls.Add(Me.lblDbTitle)
            Me.grpBackup.Controls.Add(Me.lblDbPath)
            Me.grpBackup.Controls.Add(Me.btnBackup)
            Me.grpBackup.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpBackup.Location = New System.Drawing.Point(0, 0)
            Me.grpBackup.Name = "grpBackup"
            Me.grpBackup.Size = New System.Drawing.Size(640, 115)
            Me.grpBackup.TabIndex = 0
            Me.grpBackup.TabStop = False
            Me.grpBackup.Text = "Backup"
            '
            'lblDbTitle
            '
            Me.lblDbTitle.AutoSize = True
            Me.lblDbTitle.Location = New System.Drawing.Point(15, 27)
            Me.lblDbTitle.Name = "lblDbTitle"
            Me.lblDbTitle.TabIndex = 0
            Me.lblDbTitle.Text = "Database file:"
            '
            'lblDbPath
            '
            Me.lblDbPath.ForeColor = System.Drawing.Color.Gray
            Me.lblDbPath.Location = New System.Drawing.Point(15, 48)
            Me.lblDbPath.Name = "lblDbPath"
            Me.lblDbPath.Size = New System.Drawing.Size(600, 20)
            Me.lblDbPath.TabIndex = 1
            '
            'btnBackup
            '
            Me.btnBackup.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.btnBackup.ForeColor = System.Drawing.Color.White
            Me.btnBackup.Location = New System.Drawing.Point(15, 75)
            Me.btnBackup.Name = "btnBackup"
            Me.btnBackup.Size = New System.Drawing.Size(170, 30)
            Me.btnBackup.TabIndex = 2
            Me.btnBackup.Text = "Create backup..."
            Me.btnBackup.UseVisualStyleBackColor = False
            '
            'grpRestore
            '
            Me.grpRestore.Controls.Add(Me.btnRestore)
            Me.grpRestore.Controls.Add(Me.lblWarn)
            Me.grpRestore.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpRestore.Location = New System.Drawing.Point(0, 115)
            Me.grpRestore.Name = "grpRestore"
            Me.grpRestore.Size = New System.Drawing.Size(640, 120)
            Me.grpRestore.TabIndex = 1
            Me.grpRestore.TabStop = False
            Me.grpRestore.Text = "Restore"
            '
            'btnRestore
            '
            Me.btnRestore.Location = New System.Drawing.Point(15, 30)
            Me.btnRestore.Name = "btnRestore"
            Me.btnRestore.Size = New System.Drawing.Size(190, 30)
            Me.btnRestore.TabIndex = 0
            Me.btnRestore.Text = "Restore from backup..."
            Me.btnRestore.UseVisualStyleBackColor = True
            '
            'lblWarn
            '
            Me.lblWarn.ForeColor = System.Drawing.Color.Firebrick
            Me.lblWarn.Location = New System.Drawing.Point(15, 70)
            Me.lblWarn.Name = "lblWarn"
            Me.lblWarn.Size = New System.Drawing.Size(600, 34)
            Me.lblWarn.TabIndex = 1
            Me.lblWarn.Text = "Restoring overwrites ALL current data with the backup copy. Restart the application afterwards."
            '
            'frmBackup
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(640, 380)
            Me.Controls.Add(Me.grpBackup)
            Me.Controls.Add(Me.grpRestore)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "frmBackup"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Backup && Restore (Administrator)"
            Me.grpBackup.ResumeLayout(False)
            Me.grpBackup.PerformLayout()
            Me.grpRestore.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents grpBackup As System.Windows.Forms.GroupBox
        Friend WithEvents lblDbTitle As System.Windows.Forms.Label
        Friend WithEvents lblDbPath As System.Windows.Forms.Label
        Friend WithEvents btnBackup As System.Windows.Forms.Button
        Friend WithEvents grpRestore As System.Windows.Forms.GroupBox
        Friend WithEvents btnRestore As System.Windows.Forms.Button
        Friend WithEvents lblWarn As System.Windows.Forms.Label

    End Class
End Namespace
