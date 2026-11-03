Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmLoans
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
            Me.grpIssue = New System.Windows.Forms.GroupBox()
            Me.lblMember = New System.Windows.Forms.Label()
            Me.cboMember = New System.Windows.Forms.ComboBox()
            Me.lblPrincipal = New System.Windows.Forms.Label()
            Me.nudPrincipal = New System.Windows.Forms.NumericUpDown()
            Me.lblRate = New System.Windows.Forms.Label()
            Me.nudRate = New System.Windows.Forms.NumericUpDown()
            Me.lblTerm = New System.Windows.Forms.Label()
            Me.nudTerm = New System.Windows.Forms.NumericUpDown()
            Me.lblPreview = New System.Windows.Forms.Label()
            Me.btnIssue = New System.Windows.Forms.Button()
            Me.grpRepay = New System.Windows.Forms.GroupBox()
            Me.lblLoan = New System.Windows.Forms.Label()
            Me.lblLoanInfo = New System.Windows.Forms.Label()
            Me.lblAmount = New System.Windows.Forms.Label()
            Me.nudRepay = New System.Windows.Forms.NumericUpDown()
            Me.btnRepay = New System.Windows.Forms.Button()
            Me.dgvLoans = New System.Windows.Forms.DataGridView()
            Me.grpIssue.SuspendLayout()
            Me.grpRepay.SuspendLayout()
            CType(Me.nudPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nudRate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nudTerm, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nudRepay, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgvLoans, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grpIssue
            '
            Me.grpIssue.Controls.Add(Me.lblMember)
            Me.grpIssue.Controls.Add(Me.cboMember)
            Me.grpIssue.Controls.Add(Me.lblPrincipal)
            Me.grpIssue.Controls.Add(Me.nudPrincipal)
            Me.grpIssue.Controls.Add(Me.lblRate)
            Me.grpIssue.Controls.Add(Me.nudRate)
            Me.grpIssue.Controls.Add(Me.lblTerm)
            Me.grpIssue.Controls.Add(Me.nudTerm)
            Me.grpIssue.Controls.Add(Me.lblPreview)
            Me.grpIssue.Controls.Add(Me.btnIssue)
            Me.grpIssue.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpIssue.Location = New System.Drawing.Point(0, 0)
            Me.grpIssue.Name = "grpIssue"
            Me.grpIssue.Size = New System.Drawing.Size(950, 140)
            Me.grpIssue.TabIndex = 0
            Me.grpIssue.TabStop = False
            Me.grpIssue.Text = "Issue loan"
            '
            'lblMember
            '
            Me.lblMember.AutoSize = True
            Me.lblMember.Location = New System.Drawing.Point(15, 29)
            Me.lblMember.Name = "lblMember"
            Me.lblMember.TabIndex = 0
            Me.lblMember.Text = "Member:*"
            '
            'cboMember
            '
            Me.cboMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboMember.Location = New System.Drawing.Point(95, 25)
            Me.cboMember.Name = "cboMember"
            Me.cboMember.Size = New System.Drawing.Size(220, 25)
            Me.cboMember.TabIndex = 1
            '
            'lblPrincipal
            '
            Me.lblPrincipal.AutoSize = True
            Me.lblPrincipal.Location = New System.Drawing.Point(335, 29)
            Me.lblPrincipal.Name = "lblPrincipal"
            Me.lblPrincipal.TabIndex = 2
            Me.lblPrincipal.Text = "Principal:*"
            '
            'nudPrincipal
            '
            Me.nudPrincipal.DecimalPlaces = CInt(New Decimal(New Integer() {2, 0, 0, 0}))
            Me.nudPrincipal.Location = New System.Drawing.Point(420, 25)
            Me.nudPrincipal.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
            Me.nudPrincipal.Name = "nudPrincipal"
            Me.nudPrincipal.Size = New System.Drawing.Size(130, 25)
            Me.nudPrincipal.TabIndex = 3
            Me.nudPrincipal.ThousandsSeparator = True
            '
            'lblRate
            '
            Me.lblRate.AutoSize = True
            Me.lblRate.Location = New System.Drawing.Point(570, 29)
            Me.lblRate.Name = "lblRate"
            Me.lblRate.TabIndex = 4
            Me.lblRate.Text = "Rate (%/yr):*"
            '
            'nudRate
            '
            Me.nudRate.DecimalPlaces = CInt(New Decimal(New Integer() {2, 0, 0, 0}))
            Me.nudRate.Location = New System.Drawing.Point(665, 25)
            Me.nudRate.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
            Me.nudRate.Name = "nudRate"
            Me.nudRate.Size = New System.Drawing.Size(90, 25)
            Me.nudRate.TabIndex = 5
            Me.nudRate.Value = New Decimal(New Integer() {12, 0, 0, 0})
            '
            'lblTerm
            '
            Me.lblTerm.AutoSize = True
            Me.lblTerm.Location = New System.Drawing.Point(15, 69)
            Me.lblTerm.Name = "lblTerm"
            Me.lblTerm.TabIndex = 6
            Me.lblTerm.Text = "Term (months):*"
            '
            'nudTerm
            '
            Me.nudTerm.Location = New System.Drawing.Point(110, 65)
            Me.nudTerm.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
            Me.nudTerm.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.nudTerm.Name = "nudTerm"
            Me.nudTerm.Size = New System.Drawing.Size(90, 25)
            Me.nudTerm.TabIndex = 7
            Me.nudTerm.Value = New Decimal(New Integer() {12, 0, 0, 0})
            '
            'lblPreview
            '
            Me.lblPreview.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.lblPreview.Location = New System.Drawing.Point(335, 65)
            Me.lblPreview.Name = "lblPreview"
            Me.lblPreview.Size = New System.Drawing.Size(420, 24)
            Me.lblPreview.TabIndex = 8
            Me.lblPreview.Text = "Total due: -    Monthly installment: -"
            '
            'btnIssue
            '
            Me.btnIssue.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.btnIssue.ForeColor = System.Drawing.Color.White
            Me.btnIssue.Location = New System.Drawing.Point(110, 100)
            Me.btnIssue.Name = "btnIssue"
            Me.btnIssue.Size = New System.Drawing.Size(130, 32)
            Me.btnIssue.TabIndex = 9
            Me.btnIssue.Text = "Issue loan"
            Me.btnIssue.UseVisualStyleBackColor = False
            '
            'grpRepay
            '
            Me.grpRepay.Controls.Add(Me.lblLoan)
            Me.grpRepay.Controls.Add(Me.lblLoanInfo)
            Me.grpRepay.Controls.Add(Me.lblAmount)
            Me.grpRepay.Controls.Add(Me.nudRepay)
            Me.grpRepay.Controls.Add(Me.btnRepay)
            Me.grpRepay.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.grpRepay.Location = New System.Drawing.Point(0, 528)
            Me.grpRepay.Name = "grpRepay"
            Me.grpRepay.Size = New System.Drawing.Size(950, 92)
            Me.grpRepay.TabIndex = 1
            Me.grpRepay.TabStop = False
            Me.grpRepay.Text = "Repayment"
            '
            'lblLoan
            '
            Me.lblLoan.AutoSize = True
            Me.lblLoan.Location = New System.Drawing.Point(15, 27)
            Me.lblLoan.Name = "lblLoan"
            Me.lblLoan.TabIndex = 0
            Me.lblLoan.Text = "Selected loan:"
            '
            'lblLoanInfo
            '
            Me.lblLoanInfo.ForeColor = System.Drawing.Color.Gray
            Me.lblLoanInfo.Location = New System.Drawing.Point(110, 27)
            Me.lblLoanInfo.Name = "lblLoanInfo"
            Me.lblLoanInfo.Size = New System.Drawing.Size(560, 20)
            Me.lblLoanInfo.TabIndex = 1
            Me.lblLoanInfo.Text = "None - click a loan in the table above"
            '
            'lblAmount
            '
            Me.lblAmount.AutoSize = True
            Me.lblAmount.Location = New System.Drawing.Point(15, 59)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.TabIndex = 2
            Me.lblAmount.Text = "Repay amount:*"
            '
            'nudRepay
            '
            Me.nudRepay.DecimalPlaces = CInt(New Decimal(New Integer() {2, 0, 0, 0}))
            Me.nudRepay.Location = New System.Drawing.Point(110, 55)
            Me.nudRepay.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
            Me.nudRepay.Name = "nudRepay"
            Me.nudRepay.Size = New System.Drawing.Size(130, 25)
            Me.nudRepay.TabIndex = 3
            Me.nudRepay.ThousandsSeparator = True
            '
            'btnRepay
            '
            Me.btnRepay.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.btnRepay.Enabled = False
            Me.btnRepay.ForeColor = System.Drawing.Color.White
            Me.btnRepay.Location = New System.Drawing.Point(260, 53)
            Me.btnRepay.Name = "btnRepay"
            Me.btnRepay.Size = New System.Drawing.Size(140, 30)
            Me.btnRepay.TabIndex = 4
            Me.btnRepay.Text = "Post repayment"
            Me.btnRepay.UseVisualStyleBackColor = False
            '
            'dgvLoans
            '
            Me.dgvLoans.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvLoans.Location = New System.Drawing.Point(0, 140)
            Me.dgvLoans.Name = "dgvLoans"
            Me.dgvLoans.Size = New System.Drawing.Size(950, 388)
            Me.dgvLoans.TabIndex = 2
            '
            'frmLoans
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(950, 620)
            Me.Controls.Add(Me.dgvLoans)
            Me.Controls.Add(Me.grpIssue)
            Me.Controls.Add(Me.grpRepay)
            Me.Name = "frmLoans"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Loan Management"
            Me.grpIssue.ResumeLayout(False)
            Me.grpIssue.PerformLayout()
            Me.grpRepay.ResumeLayout(False)
            Me.grpRepay.PerformLayout()
            CType(Me.nudPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nudRate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nudTerm, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nudRepay, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgvLoans, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents grpIssue As System.Windows.Forms.GroupBox
        Friend WithEvents lblMember As System.Windows.Forms.Label
        Friend WithEvents cboMember As System.Windows.Forms.ComboBox
        Friend WithEvents lblPrincipal As System.Windows.Forms.Label
        Friend WithEvents nudPrincipal As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblRate As System.Windows.Forms.Label
        Friend WithEvents nudRate As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblTerm As System.Windows.Forms.Label
        Friend WithEvents nudTerm As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblPreview As System.Windows.Forms.Label
        Friend WithEvents btnIssue As System.Windows.Forms.Button
        Friend WithEvents grpRepay As System.Windows.Forms.GroupBox
        Friend WithEvents lblLoan As System.Windows.Forms.Label
        Friend WithEvents lblLoanInfo As System.Windows.Forms.Label
        Friend WithEvents lblAmount As System.Windows.Forms.Label
        Friend WithEvents nudRepay As System.Windows.Forms.NumericUpDown
        Friend WithEvents btnRepay As System.Windows.Forms.Button
        Friend WithEvents dgvLoans As System.Windows.Forms.DataGridView

    End Class
End Namespace

