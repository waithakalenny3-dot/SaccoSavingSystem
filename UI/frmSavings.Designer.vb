Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmSavings
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
            Me.grpPost = New System.Windows.Forms.GroupBox()
            Me.lblAccount = New System.Windows.Forms.Label()
            Me.cboAccount = New System.Windows.Forms.ComboBox()
            Me.lblType = New System.Windows.Forms.Label()
            Me.cboType = New System.Windows.Forms.ComboBox()
            Me.lblAmount = New System.Windows.Forms.Label()
            Me.nudAmount = New System.Windows.Forms.NumericUpDown()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.txtNote = New System.Windows.Forms.TextBox()
            Me.btnPost = New System.Windows.Forms.Button()
            Me.grpBalance = New System.Windows.Forms.GroupBox()
            Me.lblBalanceTitle = New System.Windows.Forms.Label()
            Me.lblBalance = New System.Windows.Forms.Label()
            Me.dgvTransactions = New System.Windows.Forms.DataGridView()
            Me.grpPost.SuspendLayout()
            Me.grpBalance.SuspendLayout()
            CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grpPost
            '
            Me.grpPost.Controls.Add(Me.lblAccount)
            Me.grpPost.Controls.Add(Me.cboAccount)
            Me.grpPost.Controls.Add(Me.lblType)
            Me.grpPost.Controls.Add(Me.cboType)
            Me.grpPost.Controls.Add(Me.lblAmount)
            Me.grpPost.Controls.Add(Me.nudAmount)
            Me.grpPost.Controls.Add(Me.lblNote)
            Me.grpPost.Controls.Add(Me.txtNote)
            Me.grpPost.Controls.Add(Me.btnPost)
            Me.grpPost.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpPost.Location = New System.Drawing.Point(0, 0)
            Me.grpPost.Name = "grpPost"
            Me.grpPost.Size = New System.Drawing.Size(900, 125)
            Me.grpPost.TabIndex = 0
            Me.grpPost.TabStop = False
            Me.grpPost.Text = "Post transaction"
            '
            'lblAccount
            '
            Me.lblAccount.AutoSize = True
            Me.lblAccount.Location = New System.Drawing.Point(15, 27)
            Me.lblAccount.Name = "lblAccount"
            Me.lblAccount.TabIndex = 0
            Me.lblAccount.Text = "Account:*"
            '
            'cboAccount
            '
            Me.cboAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboAccount.Location = New System.Drawing.Point(90, 23)
            Me.cboAccount.Name = "cboAccount"
            Me.cboAccount.Size = New System.Drawing.Size(280, 25)
            Me.cboAccount.TabIndex = 1
            '
            'lblType
            '
            Me.lblType.AutoSize = True
            Me.lblType.Location = New System.Drawing.Point(390, 27)
            Me.lblType.Name = "lblType"
            Me.lblType.TabIndex = 2
            Me.lblType.Text = "Type:*"
            '
            'cboType
            '
            Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboType.Location = New System.Drawing.Point(440, 23)
            Me.cboType.Name = "cboType"
            Me.cboType.Size = New System.Drawing.Size(150, 25)
            Me.cboType.TabIndex = 3
            '
            'lblAmount
            '
            Me.lblAmount.AutoSize = True
            Me.lblAmount.Location = New System.Drawing.Point(15, 67)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.TabIndex = 4
            Me.lblAmount.Text = "Amount:*"
            '
            'nudAmount
            '
            Me.nudAmount.DecimalPlaces = CInt(New Decimal(New Integer() {2, 0, 0, 0}))
            Me.nudAmount.Location = New System.Drawing.Point(90, 63)
            Me.nudAmount.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
            Me.nudAmount.Name = "nudAmount"
            Me.nudAmount.Size = New System.Drawing.Size(150, 25)
            Me.nudAmount.TabIndex = 5
            Me.nudAmount.ThousandsSeparator = True
            '
            'lblNote
            '
            Me.lblNote.AutoSize = True
            Me.lblNote.Location = New System.Drawing.Point(390, 67)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.TabIndex = 6
            Me.lblNote.Text = "Note:"
            '
            'txtNote
            '
            Me.txtNote.Location = New System.Drawing.Point(440, 63)
            Me.txtNote.Name = "txtNote"
            Me.txtNote.Size = New System.Drawing.Size(300, 25)
            Me.txtNote.TabIndex = 7
            '
            'btnPost
            '
            Me.btnPost.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.btnPost.ForeColor = System.Drawing.Color.White
            Me.btnPost.Location = New System.Drawing.Point(755, 55)
            Me.btnPost.Name = "btnPost"
            Me.btnPost.Size = New System.Drawing.Size(130, 50)
            Me.btnPost.TabIndex = 8
            Me.btnPost.Text = "Post transaction"
            Me.btnPost.UseVisualStyleBackColor = False
            '
            'grpBalance
            '
            Me.grpBalance.Controls.Add(Me.lblBalanceTitle)
            Me.grpBalance.Controls.Add(Me.lblBalance)
            Me.grpBalance.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.grpBalance.Location = New System.Drawing.Point(0, 516)
            Me.grpBalance.Name = "grpBalance"
            Me.grpBalance.Size = New System.Drawing.Size(900, 44)
            Me.grpBalance.TabIndex = 1
            Me.grpBalance.TabStop = False
            '
            'lblBalanceTitle
            '
            Me.lblBalanceTitle.AutoSize = True
            Me.lblBalanceTitle.Font = New System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold)
            Me.lblBalanceTitle.Location = New System.Drawing.Point(15, 15)
            Me.lblBalanceTitle.Name = "lblBalanceTitle"
            Me.lblBalanceTitle.TabIndex = 0
            Me.lblBalanceTitle.Text = "Current balance:"
            '
            'lblBalance
            '
            Me.lblBalance.AutoSize = True
            Me.lblBalance.Font = New System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold)
            Me.lblBalance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.lblBalance.Location = New System.Drawing.Point(130, 15)
            Me.lblBalance.Name = "lblBalance"
            Me.lblBalance.TabIndex = 1
            Me.lblBalance.Text = "-"
            '
            'dgvTransactions
            '
            Me.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvTransactions.Location = New System.Drawing.Point(0, 125)
            Me.dgvTransactions.Name = "dgvTransactions"
            Me.dgvTransactions.Size = New System.Drawing.Size(900, 391)
            Me.dgvTransactions.TabIndex = 2
            '
            'frmSavings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(900, 560)
            Me.Controls.Add(Me.dgvTransactions)
            Me.Controls.Add(Me.grpPost)
            Me.Controls.Add(Me.grpBalance)
            Me.Name = "frmSavings"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Savings Transactions"
            Me.grpPost.ResumeLayout(False)
            Me.grpPost.PerformLayout()
            Me.grpBalance.ResumeLayout(False)
            Me.grpBalance.PerformLayout()
            CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvTransactions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents grpPost As System.Windows.Forms.GroupBox
        Friend WithEvents lblAccount As System.Windows.Forms.Label
        Friend WithEvents cboAccount As System.Windows.Forms.ComboBox
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents cboType As System.Windows.Forms.ComboBox
        Friend WithEvents lblAmount As System.Windows.Forms.Label
        Friend WithEvents nudAmount As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents btnPost As System.Windows.Forms.Button
        Friend WithEvents grpBalance As System.Windows.Forms.GroupBox
        Friend WithEvents lblBalanceTitle As System.Windows.Forms.Label
        Friend WithEvents lblBalance As System.Windows.Forms.Label
        Friend WithEvents dgvTransactions As System.Windows.Forms.DataGridView

    End Class
End Namespace

