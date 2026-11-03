Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmReports
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
            Me.grpSettings = New System.Windows.Forms.GroupBox()
            Me.lblReport = New System.Windows.Forms.Label()
            Me.cboReport = New System.Windows.Forms.ComboBox()
            Me.lblMember = New System.Windows.Forms.Label()
            Me.cboMember = New System.Windows.Forms.ComboBox()
            Me.lblFrom = New System.Windows.Forms.Label()
            Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
            Me.lblTo = New System.Windows.Forms.Label()
            Me.dtpTo = New System.Windows.Forms.DateTimePicker()
            Me.lblDay = New System.Windows.Forms.Label()
            Me.dtpDay = New System.Windows.Forms.DateTimePicker()
            Me.btnGenerate = New System.Windows.Forms.Button()
            Me.btnExport = New System.Windows.Forms.Button()
            Me.btnPrint = New System.Windows.Forms.Button()
            Me.lblSummaryText = New System.Windows.Forms.Label()
            Me.dgvReport = New System.Windows.Forms.DataGridView()
            Me.grpSettings.SuspendLayout()
            CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grpSettings
            '
            Me.grpSettings.Controls.Add(Me.lblReport)
            Me.grpSettings.Controls.Add(Me.cboReport)
            Me.grpSettings.Controls.Add(Me.lblMember)
            Me.grpSettings.Controls.Add(Me.cboMember)
            Me.grpSettings.Controls.Add(Me.lblFrom)
            Me.grpSettings.Controls.Add(Me.dtpFrom)
            Me.grpSettings.Controls.Add(Me.lblTo)
            Me.grpSettings.Controls.Add(Me.dtpTo)
            Me.grpSettings.Controls.Add(Me.lblDay)
            Me.grpSettings.Controls.Add(Me.dtpDay)
            Me.grpSettings.Controls.Add(Me.btnGenerate)
            Me.grpSettings.Controls.Add(Me.btnExport)
            Me.grpSettings.Controls.Add(Me.btnPrint)
            Me.grpSettings.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpSettings.Location = New System.Drawing.Point(0, 0)
            Me.grpSettings.Name = "grpSettings"
            Me.grpSettings.Size = New System.Drawing.Size(850, 92)
            Me.grpSettings.TabIndex = 0
            Me.grpSettings.TabStop = False
            Me.grpSettings.Text = "Report settings"
            '
            'lblReport
            '
            Me.lblReport.AutoSize = True
            Me.lblReport.Location = New System.Drawing.Point(15, 27)
            Me.lblReport.Name = "lblReport"
            Me.lblReport.TabIndex = 0
            Me.lblReport.Text = "Report:*"
            '
            'cboReport
            '
            Me.cboReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboReport.Location = New System.Drawing.Point(80, 23)
            Me.cboReport.Name = "cboReport"
            Me.cboReport.Size = New System.Drawing.Size(210, 25)
            Me.cboReport.TabIndex = 1
            '
            'lblMember
            '
            Me.lblMember.AutoSize = True
            Me.lblMember.Location = New System.Drawing.Point(310, 27)
            Me.lblMember.Name = "lblMember"
            Me.lblMember.TabIndex = 2
            Me.lblMember.Text = "Member:"
            '
            'cboMember
            '
            Me.cboMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboMember.Location = New System.Drawing.Point(370, 23)
            Me.cboMember.Name = "cboMember"
            Me.cboMember.Size = New System.Drawing.Size(200, 25)
            Me.cboMember.TabIndex = 3
            '
            'lblFrom
            '
            Me.lblFrom.AutoSize = True
            Me.lblFrom.Location = New System.Drawing.Point(15, 57)
            Me.lblFrom.Name = "lblFrom"
            Me.lblFrom.TabIndex = 4
            Me.lblFrom.Text = "From:"
            '
            'dtpFrom
            '
            Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFrom.Location = New System.Drawing.Point(60, 53)
            Me.dtpFrom.Name = "dtpFrom"
            Me.dtpFrom.Size = New System.Drawing.Size(110, 25)
            Me.dtpFrom.TabIndex = 5
            '
            'lblTo
            '
            Me.lblTo.AutoSize = True
            Me.lblTo.Location = New System.Drawing.Point(180, 57)
            Me.lblTo.Name = "lblTo"
            Me.lblTo.TabIndex = 6
            Me.lblTo.Text = "To:"
            '
            'dtpTo
            '
            Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpTo.Location = New System.Drawing.Point(210, 53)
            Me.dtpTo.Name = "dtpTo"
            Me.dtpTo.Size = New System.Drawing.Size(110, 25)
            Me.dtpTo.TabIndex = 7
            '
            'lblDay
            '
            Me.lblDay.AutoSize = True
            Me.lblDay.Location = New System.Drawing.Point(310, 57)
            Me.lblDay.Name = "lblDay"
            Me.lblDay.TabIndex = 8
            Me.lblDay.Text = "Day:"
            '
            'dtpDay
            '
            Me.dtpDay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDay.Location = New System.Drawing.Point(345, 53)
            Me.dtpDay.Name = "dtpDay"
            Me.dtpDay.Size = New System.Drawing.Size(110, 25)
            Me.dtpDay.TabIndex = 9
            '
            'btnGenerate
            '
            Me.btnGenerate.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.btnGenerate.ForeColor = System.Drawing.Color.White
            Me.btnGenerate.Location = New System.Drawing.Point(600, 20)
            Me.btnGenerate.Name = "btnGenerate"
            Me.btnGenerate.Size = New System.Drawing.Size(100, 55)
            Me.btnGenerate.TabIndex = 10
            Me.btnGenerate.Text = "Generate"
            Me.btnGenerate.UseVisualStyleBackColor = False
            '
            'btnExport
            '
            Me.btnExport.Location = New System.Drawing.Point(715, 20)
            Me.btnExport.Name = "btnExport"
            Me.btnExport.Size = New System.Drawing.Size(115, 26)
            Me.btnExport.TabIndex = 11
            Me.btnExport.Text = "Export CSV..."
            Me.btnExport.UseVisualStyleBackColor = True
            '
            'btnPrint
            '
            Me.btnPrint.Location = New System.Drawing.Point(715, 50)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(115, 26)
            Me.btnPrint.TabIndex = 12
            Me.btnPrint.Text = "Print preview..."
            Me.btnPrint.UseVisualStyleBackColor = True
            '
            'lblSummaryText
            '
            Me.lblSummaryText.AutoSize = True
            Me.lblSummaryText.ForeColor = System.Drawing.Color.Gray
            Me.lblSummaryText.Location = New System.Drawing.Point(15, 522)
            Me.lblSummaryText.Name = "lblSummaryText"
            Me.lblSummaryText.TabIndex = 1
            Me.lblSummaryText.Text = "Generate a report to see results."
            '
            'dgvReport
            '
            Me.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvReport.Location = New System.Drawing.Point(0, 92)
            Me.dgvReport.Name = "dgvReport"
            Me.dgvReport.Size = New System.Drawing.Size(850, 430)
            Me.dgvReport.TabIndex = 2
            '
            'frmReports
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(850, 560)
            Me.Controls.Add(Me.dgvReport)
            Me.Controls.Add(Me.lblSummaryText)
            Me.Controls.Add(Me.grpSettings)
            Me.Name = "frmReports"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Reports"
            Me.grpSettings.ResumeLayout(False)
            Me.grpSettings.PerformLayout()
            CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents grpSettings As System.Windows.Forms.GroupBox
        Friend WithEvents lblReport As System.Windows.Forms.Label
        Friend WithEvents cboReport As System.Windows.Forms.ComboBox
        Friend WithEvents lblMember As System.Windows.Forms.Label
        Friend WithEvents cboMember As System.Windows.Forms.ComboBox
        Friend WithEvents lblFrom As System.Windows.Forms.Label
        Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblTo As System.Windows.Forms.Label
        Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDay As System.Windows.Forms.Label
        Friend WithEvents dtpDay As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnGenerate As System.Windows.Forms.Button
        Friend WithEvents btnExport As System.Windows.Forms.Button
        Friend WithEvents btnPrint As System.Windows.Forms.Button
        Friend WithEvents lblSummaryText As System.Windows.Forms.Label
        Friend WithEvents dgvReport As System.Windows.Forms.DataGridView

    End Class
End Namespace
