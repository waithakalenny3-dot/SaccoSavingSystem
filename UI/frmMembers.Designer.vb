Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmMembers
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
            Me.grpSearch = New System.Windows.Forms.GroupBox()
            Me.lblSearch = New System.Windows.Forms.Label()
            Me.txtSearch = New System.Windows.Forms.TextBox()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.btnShowAll = New System.Windows.Forms.Button()
            Me.grpDetails = New System.Windows.Forms.GroupBox()
            Me.lblMemberNo = New System.Windows.Forms.Label()
            Me.txtMemberNo = New System.Windows.Forms.TextBox()
            Me.lblName = New System.Windows.Forms.Label()
            Me.txtFullName = New System.Windows.Forms.TextBox()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.txtPhone = New System.Windows.Forms.TextBox()
            Me.lblEmail = New System.Windows.Forms.Label()
            Me.txtEmail = New System.Windows.Forms.TextBox()
            Me.lblJoin = New System.Windows.Forms.Label()
            Me.dtpJoin = New System.Windows.Forms.DateTimePicker()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.cboStatus = New System.Windows.Forms.ComboBox()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnNew = New System.Windows.Forms.Button()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.lblHint = New System.Windows.Forms.Label()
            Me.dgvMembers = New System.Windows.Forms.DataGridView()
            Me.grpSearch.SuspendLayout()
            Me.grpDetails.SuspendLayout()
            CType(Me.dgvMembers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grpSearch
            '
            Me.grpSearch.Controls.Add(Me.lblSearch)
            Me.grpSearch.Controls.Add(Me.txtSearch)
            Me.grpSearch.Controls.Add(Me.btnSearch)
            Me.grpSearch.Controls.Add(Me.btnShowAll)
            Me.grpSearch.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpSearch.Location = New System.Drawing.Point(0, 0)
            Me.grpSearch.Name = "grpSearch"
            Me.grpSearch.Size = New System.Drawing.Size(900, 56)
            Me.grpSearch.TabIndex = 0
            Me.grpSearch.TabStop = False
            Me.grpSearch.Text = "Search"
            '
            'lblSearch
            '
            Me.lblSearch.AutoSize = True
            Me.lblSearch.Location = New System.Drawing.Point(15, 24)
            Me.lblSearch.Name = "lblSearch"
            Me.lblSearch.TabIndex = 0
            Me.lblSearch.Text = "Member no. or name:"
            '
            'txtSearch
            '
            Me.txtSearch.Location = New System.Drawing.Point(135, 21)
            Me.txtSearch.Name = "txtSearch"
            Me.txtSearch.Size = New System.Drawing.Size(220, 25)
            Me.txtSearch.TabIndex = 1
            '
            'btnSearch
            '
            Me.btnSearch.Location = New System.Drawing.Point(370, 19)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(90, 28)
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "Search"
            Me.btnSearch.UseVisualStyleBackColor = True
            '
            'btnShowAll
            '
            Me.btnShowAll.Location = New System.Drawing.Point(470, 19)
            Me.btnShowAll.Name = "btnShowAll"
            Me.btnShowAll.Size = New System.Drawing.Size(90, 28)
            Me.btnShowAll.TabIndex = 3
            Me.btnShowAll.Text = "Show all"
            Me.btnShowAll.UseVisualStyleBackColor = True
            '
            'grpDetails
            '
            Me.grpDetails.Controls.Add(Me.lblMemberNo)
            Me.grpDetails.Controls.Add(Me.txtMemberNo)
            Me.grpDetails.Controls.Add(Me.lblName)
            Me.grpDetails.Controls.Add(Me.txtFullName)
            Me.grpDetails.Controls.Add(Me.lblPhone)
            Me.grpDetails.Controls.Add(Me.txtPhone)
            Me.grpDetails.Controls.Add(Me.lblEmail)
            Me.grpDetails.Controls.Add(Me.txtEmail)
            Me.grpDetails.Controls.Add(Me.lblJoin)
            Me.grpDetails.Controls.Add(Me.dtpJoin)
            Me.grpDetails.Controls.Add(Me.lblStatus)
            Me.grpDetails.Controls.Add(Me.cboStatus)
            Me.grpDetails.Controls.Add(Me.btnSave)
            Me.grpDetails.Controls.Add(Me.btnNew)
            Me.grpDetails.Controls.Add(Me.btnDelete)
            Me.grpDetails.Controls.Add(Me.lblHint)
            Me.grpDetails.Dock = System.Windows.Forms.DockStyle.Right
            Me.grpDetails.Location = New System.Drawing.Point(590, 56)
            Me.grpDetails.Name = "grpDetails"
            Me.grpDetails.Size = New System.Drawing.Size(310, 504)
            Me.grpDetails.TabIndex = 1
            Me.grpDetails.TabStop = False
            Me.grpDetails.Text = "Member details"
            '
            'lblMemberNo
            '
            Me.lblMemberNo.AutoSize = True
            Me.lblMemberNo.Location = New System.Drawing.Point(20, 38)
            Me.lblMemberNo.Name = "lblMemberNo"
            Me.lblMemberNo.TabIndex = 0
            Me.lblMemberNo.Text = "Member no:*"
            '
            'txtMemberNo
            '
            Me.txtMemberNo.Location = New System.Drawing.Point(125, 34)
            Me.txtMemberNo.Name = "txtMemberNo"
            Me.txtMemberNo.Size = New System.Drawing.Size(165, 25)
            Me.txtMemberNo.TabIndex = 1
            '
            'lblName
            '
            Me.lblName.AutoSize = True
            Me.lblName.Location = New System.Drawing.Point(20, 73)
            Me.lblName.Name = "lblName"
            Me.lblName.TabIndex = 2
            Me.lblName.Text = "Full name:*"
            '
            'txtFullName
            '
            Me.txtFullName.Location = New System.Drawing.Point(125, 69)
            Me.txtFullName.Name = "txtFullName"
            Me.txtFullName.Size = New System.Drawing.Size(165, 25)
            Me.txtFullName.TabIndex = 3
            '
            'lblPhone
            '
            Me.lblPhone.AutoSize = True
            Me.lblPhone.Location = New System.Drawing.Point(20, 108)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.TabIndex = 4
            Me.lblPhone.Text = "Phone:*"
            '
            'txtPhone
            '
            Me.txtPhone.Location = New System.Drawing.Point(125, 104)
            Me.txtPhone.Name = "txtPhone"
            Me.txtPhone.Size = New System.Drawing.Size(165, 25)
            Me.txtPhone.TabIndex = 5
            '
            'lblEmail
            '
            Me.lblEmail.AutoSize = True
            Me.lblEmail.Location = New System.Drawing.Point(20, 143)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.TabIndex = 6
            Me.lblEmail.Text = "Email:"
            '
            'txtEmail
            '
            Me.txtEmail.Location = New System.Drawing.Point(125, 139)
            Me.txtEmail.Name = "txtEmail"
            Me.txtEmail.Size = New System.Drawing.Size(165, 25)
            Me.txtEmail.TabIndex = 7
            '
            'lblJoin
            '
            Me.lblJoin.AutoSize = True
            Me.lblJoin.Location = New System.Drawing.Point(20, 178)
            Me.lblJoin.Name = "lblJoin"
            Me.lblJoin.TabIndex = 8
            Me.lblJoin.Text = "Join date:"
            '
            'dtpJoin
            '
            Me.dtpJoin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpJoin.Location = New System.Drawing.Point(125, 174)
            Me.dtpJoin.Name = "dtpJoin"
            Me.dtpJoin.Size = New System.Drawing.Size(165, 25)
            Me.dtpJoin.TabIndex = 9
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Location = New System.Drawing.Point(20, 213)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.TabIndex = 10
            Me.lblStatus.Text = "Status:"
            '
            'cboStatus
            '
            Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboStatus.Items.AddRange(New Object() {"Active", "Dormant", "Closed"})
            Me.cboStatus.Location = New System.Drawing.Point(125, 209)
            Me.cboStatus.Name = "cboStatus"
            Me.cboStatus.Size = New System.Drawing.Size(165, 25)
            Me.cboStatus.TabIndex = 11
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(20, 258)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(145, 34)
            Me.btnSave.TabIndex = 12
            Me.btnSave.Text = "Save new member"
            Me.btnSave.UseVisualStyleBackColor = False
            '
            'btnNew
            '
            Me.btnNew.Location = New System.Drawing.Point(175, 258)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(115, 34)
            Me.btnNew.TabIndex = 13
            Me.btnNew.Text = "New / Clear"
            Me.btnNew.UseVisualStyleBackColor = True
            '
            'btnDelete
            '
            Me.btnDelete.Location = New System.Drawing.Point(20, 302)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(145, 34)
            Me.btnDelete.TabIndex = 14
            Me.btnDelete.Text = "Delete"
            Me.btnDelete.UseVisualStyleBackColor = True
            '
            'lblHint
            '
            Me.lblHint.AutoSize = True
            Me.lblHint.ForeColor = System.Drawing.Color.Gray
            Me.lblHint.Location = New System.Drawing.Point(20, 352)
            Me.lblHint.Name = "lblHint"
            Me.lblHint.TabIndex = 15
            Me.lblHint.Text = "* required fields"
            '
            'dgvMembers
            '
            Me.dgvMembers.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvMembers.Location = New System.Drawing.Point(0, 56)
            Me.dgvMembers.Name = "dgvMembers"
            Me.dgvMembers.Size = New System.Drawing.Size(590, 504)
            Me.dgvMembers.TabIndex = 2
            '
            'frmMembers
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(900, 560)
            Me.Controls.Add(Me.dgvMembers)
            Me.Controls.Add(Me.grpSearch)
            Me.Controls.Add(Me.grpDetails)
            Me.Name = "frmMembers"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Member Management"
            Me.grpSearch.ResumeLayout(False)
            Me.grpSearch.PerformLayout()
            Me.grpDetails.ResumeLayout(False)
            Me.grpDetails.PerformLayout()
            CType(Me.dgvMembers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
        Friend WithEvents lblSearch As System.Windows.Forms.Label
        Friend WithEvents txtSearch As System.Windows.Forms.TextBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnShowAll As System.Windows.Forms.Button
        Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
        Friend WithEvents lblMemberNo As System.Windows.Forms.Label
        Friend WithEvents txtMemberNo As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtFullName As System.Windows.Forms.TextBox
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents lblEmail As System.Windows.Forms.Label
        Friend WithEvents txtEmail As System.Windows.Forms.TextBox
        Friend WithEvents lblJoin As System.Windows.Forms.Label
        Friend WithEvents dtpJoin As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents lblHint As System.Windows.Forms.Label
        Friend WithEvents dgvMembers As System.Windows.Forms.DataGridView

    End Class
End Namespace
