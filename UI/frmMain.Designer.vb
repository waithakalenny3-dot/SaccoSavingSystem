Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmMain
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
            Me.lblWelcome = New System.Windows.Forms.Label()
            Me.flpButtons = New System.Windows.Forms.FlowLayoutPanel()
            Me.btnMembers = New System.Windows.Forms.Button()
            Me.btnAccounts = New System.Windows.Forms.Button()
            Me.btnSavings = New System.Windows.Forms.Button()
            Me.btnLoans = New System.Windows.Forms.Button()
            Me.btnReports = New System.Windows.Forms.Button()
            Me.btnUsers = New System.Windows.Forms.Button()
            Me.btnBackup = New System.Windows.Forms.Button()
            Me.sslMain = New System.Windows.Forms.StatusStrip()
            Me.tssUser = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tssDate = New System.Windows.Forms.ToolStripStatusLabel()
            Me.mnuMain = New System.Windows.Forms.MenuStrip()
            Me.mMnuFile = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuLogout = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuSep1 = New System.Windows.Forms.ToolStripSeparator()
            Me.mMnuExit = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuModules = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuMembers = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuAccounts = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuSavings = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuLoans = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuUsers = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuBackup = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuWindow = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuHelp = New System.Windows.Forms.ToolStripMenuItem()
            Me.mMnuAbout = New System.Windows.Forms.ToolStripMenuItem()
            Me.pnlHeader.SuspendLayout()
            Me.flpButtons.SuspendLayout()
            Me.sslMain.SuspendLayout()
            Me.mnuMain.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
            Me.pnlHeader.Controls.Add(Me.lblWelcome)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(960, 54)
            Me.pnlHeader.TabIndex = 0
            '
            'lblWelcome
            '
            Me.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblWelcome.ForeColor = System.Drawing.Color.White
            Me.lblWelcome.Location = New System.Drawing.Point(0, 0)
            Me.lblWelcome.Name = "lblWelcome"
            Me.lblWelcome.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)
            Me.lblWelcome.Size = New System.Drawing.Size(960, 54)
            Me.lblWelcome.TabIndex = 0
            Me.lblWelcome.Text = "SACCO SAVINGS & LOAN MANAGEMENT SYSTEM"
            Me.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'flpButtons
            '
            Me.flpButtons.BackColor = System.Drawing.Color.White
            Me.flpButtons.Controls.Add(Me.btnMembers)
            Me.flpButtons.Controls.Add(Me.btnAccounts)
            Me.flpButtons.Controls.Add(Me.btnSavings)
            Me.flpButtons.Controls.Add(Me.btnLoans)
            Me.flpButtons.Controls.Add(Me.btnReports)
            Me.flpButtons.Controls.Add(Me.btnUsers)
            Me.flpButtons.Controls.Add(Me.btnBackup)
            Me.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill
            Me.flpButtons.Location = New System.Drawing.Point(0, 78)
            Me.flpButtons.Name = "flpButtons"
            Me.flpButtons.Padding = New System.Windows.Forms.Padding(40, 35, 40, 35)
            Me.flpButtons.Size = New System.Drawing.Size(960, 514)
            Me.flpButtons.TabIndex = 1
            '
            'btnMembers
            '
            Me.btnMembers.Location = New System.Drawing.Point(43, 38)
            Me.btnMembers.Margin = New System.Windows.Forms.Padding(3, 3, 3, 12)
            Me.btnMembers.Name = "btnMembers"
            Me.btnMembers.Size = New System.Drawing.Size(190, 62)
            Me.btnMembers.TabIndex = 0
            Me.btnMembers.Text = "Members"
            Me.btnMembers.UseVisualStyleBackColor = True
            '
            'btnAccounts
            '
            Me.btnAccounts.Location = New System.Drawing.Point(248, 38)
            Me.btnAccounts.Margin = New System.Windows.Forms.Padding(3, 3, 3, 12)
            Me.btnAccounts.Name = "btnAccounts"
            Me.btnAccounts.Size = New System.Drawing.Size(190, 62)
            Me.btnAccounts.TabIndex = 1
            Me.btnAccounts.Text = "Accounts"
            Me.btnAccounts.UseVisualStyleBackColor = True
            '
            'btnSavings
            '
            Me.btnSavings.Location = New System.Drawing.Point(453, 38)
            Me.btnSavings.Margin = New System.Windows.Forms.Padding(3, 3, 3, 12)
            Me.btnSavings.Name = "btnSavings"
            Me.btnSavings.Size = New System.Drawing.Size(190, 62)
            Me.btnSavings.TabIndex = 2
            Me.btnSavings.Text = "Savings Transactions"
            Me.btnSavings.UseVisualStyleBackColor = True
            '
            'btnLoans
            '
            Me.btnLoans.Location = New System.Drawing.Point(658, 38)
            Me.btnLoans.Margin = New System.Windows.Forms.Padding(3, 3, 3, 12)
            Me.btnLoans.Name = "btnLoans"
            Me.btnLoans.Size = New System.Drawing.Size(190, 62)
            Me.btnLoans.TabIndex = 3
            Me.btnLoans.Text = "Loans"
            Me.btnLoans.UseVisualStyleBackColor = True
            '
            'btnReports
            '
            Me.btnReports.Location = New System.Drawing.Point(43, 112)
            Me.btnReports.Margin = New System.Windows.Forms.Padding(3, 3, 3, 12)
            Me.btnReports.Name = "btnReports"
            Me.btnReports.Size = New System.Drawing.Size(190, 62)
            Me.btnReports.TabIndex = 4
            Me.btnReports.Text = "Reports"
            Me.btnReports.UseVisualStyleBackColor = True
            '
            'btnUsers
            '
            Me.btnUsers.Location = New System.Drawing.Point(248, 112)
            Me.btnUsers.Margin = New System.Windows.Forms.Padding(3, 3, 3, 12)
            Me.btnUsers.Name = "btnUsers"
            Me.btnUsers.Size = New System.Drawing.Size(190, 62)
            Me.btnUsers.TabIndex = 5
            Me.btnUsers.Text = "User Management"
            Me.btnUsers.UseVisualStyleBackColor = True
            '
            'btnBackup
            '
            Me.btnBackup.Location = New System.Drawing.Point(453, 112)
            Me.btnBackup.Margin = New System.Windows.Forms.Padding(3, 3, 3, 12)
            Me.btnBackup.Name = "btnBackup"
            Me.btnBackup.Size = New System.Drawing.Size(190, 62)
            Me.btnBackup.TabIndex = 6
            Me.btnBackup.Text = "Backup && Restore"
            Me.btnBackup.UseVisualStyleBackColor = True
            '
            'sslMain
            '
            Me.sslMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssUser, Me.tssDate})
            Me.sslMain.Location = New System.Drawing.Point(0, 592)
            Me.sslMain.Name = "sslMain"
            Me.sslMain.Size = New System.Drawing.Size(960, 22)
            Me.sslMain.TabIndex = 2
            '
            'tssUser
            '
            Me.tssUser.Name = "tssUser"
            Me.tssUser.Size = New System.Drawing.Size(786, 17)
            Me.tssUser.Spring = True
            Me.tssUser.Text = "Logged in:"
            Me.tssUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tssDate
            '
            Me.tssDate.Name = "tssDate"
            Me.tssDate.Size = New System.Drawing.Size(159, 17)
            Me.tssDate.Text = "Today:"
            Me.tssDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mnuMain
            '
            Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mMnuFile, Me.mMnuModules, Me.mMnuWindow, Me.mMnuHelp})
            Me.mnuMain.Location = New System.Drawing.Point(0, 0)
            Me.mnuMain.Name = "mnuMain"
            Me.mnuMain.Size = New System.Drawing.Size(960, 24)
            Me.mnuMain.TabIndex = 3
            '
            'mMnuFile
            '
            Me.mMnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mMnuLogout, Me.mnuSep1, Me.mMnuExit})
            Me.mMnuFile.Name = "mMnuFile"
            Me.mMnuFile.Size = New System.Drawing.Size(37, 20)
            Me.mMnuFile.Text = "&File"
            '
            'mMnuLogout
            '
            Me.mMnuLogout.Name = "mMnuLogout"
            Me.mMnuLogout.Size = New System.Drawing.Size(132, 22)
            Me.mMnuLogout.Text = "Log &out"
            '
            'mnuSep1
            '
            Me.mnuSep1.Name = "mnuSep1"
            Me.mnuSep1.Size = New System.Drawing.Size(129, 6)
            '
            'mMnuExit
            '
            Me.mMnuExit.Name = "mMnuExit"
            Me.mMnuExit.Size = New System.Drawing.Size(132, 22)
            Me.mMnuExit.Text = "E&xit"
            '
            'mMnuModules
            '
            Me.mMnuModules.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mMnuMembers, Me.mMnuAccounts, Me.mMnuSavings, Me.mMnuLoans, Me.mMnuReports, Me.mMnuUsers, Me.mMnuBackup})
            Me.mMnuModules.Name = "mMnuModules"
            Me.mMnuModules.Size = New System.Drawing.Size(66, 20)
            Me.mMnuModules.Text = "&Modules"
            '
            'mMnuMembers
            '
            Me.mMnuMembers.Name = "mMnuMembers"
            Me.mMnuMembers.Size = New System.Drawing.Size(198, 22)
            Me.mMnuMembers.Text = "&Members"
            '
            'mMnuAccounts
            '
            Me.mMnuAccounts.Name = "mMnuAccounts"
            Me.mMnuAccounts.Size = New System.Drawing.Size(198, 22)
            Me.mMnuAccounts.Text = "&Accounts"
            '
            'mMnuSavings
            '
            Me.mMnuSavings.Name = "mMnuSavings"
            Me.mMnuSavings.Size = New System.Drawing.Size(198, 22)
            Me.mMnuSavings.Text = "&Savings Transactions"
            '
            'mMnuLoans
            '
            Me.mMnuLoans.Name = "mMnuLoans"
            Me.mMnuLoans.Size = New System.Drawing.Size(198, 22)
            Me.mMnuLoans.Text = "&Loans"
            '
            'mMnuReports
            '
            Me.mMnuReports.Name = "mMnuReports"
            Me.mMnuReports.Size = New System.Drawing.Size(198, 22)
            Me.mMnuReports.Text = "Re&ports"
            '
            'mMnuUsers
            '
            Me.mMnuUsers.Name = "mMnuUsers"
            Me.mMnuUsers.Size = New System.Drawing.Size(198, 22)
            Me.mMnuUsers.Text = "&User Management"
            '
            'mMnuBackup
            '
            Me.mMnuBackup.Name = "mMnuBackup"
            Me.mMnuBackup.Size = New System.Drawing.Size(198, 22)
            Me.mMnuBackup.Text = "&Backup && Restore"
            '
        'mMnuWindow
        '
        Me.mMnuWindow.Name = "mMnuWindow"
            Me.mMnuWindow.Size = New System.Drawing.Size(63, 20)
            Me.mMnuWindow.Text = "&Window"
            '
            'mMnuHelp
            '
            Me.mMnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mMnuAbout})
            Me.mMnuHelp.Name = "mMnuHelp"
            Me.mMnuHelp.Size = New System.Drawing.Size(44, 20)
            Me.mMnuHelp.Text = "&Help"
            '
            'mMnuAbout
            '
            Me.mMnuAbout.Name = "mMnuAbout"
            Me.mMnuAbout.Size = New System.Drawing.Size(116, 22)
            Me.mMnuAbout.Text = "&About"
            '
            'frmMain
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(960, 614)
            Me.Controls.Add(Me.pnlHeader)
            Me.Controls.Add(Me.flpButtons)
            Me.Controls.Add(Me.sslMain)
            Me.Controls.Add(Me.mnuMain)
            Me.IsMdiContainer = True
            Me.MainMenuStrip = Me.mnuMain
            Me.Name = "frmMain"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Sacco Manager - Main"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.pnlHeader.ResumeLayout(False)
            Me.flpButtons.ResumeLayout(False)
            Me.sslMain.ResumeLayout(False)
            Me.sslMain.PerformLayout()
            Me.mnuMain.ResumeLayout(False)
            Me.mnuMain.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblWelcome As System.Windows.Forms.Label
        Friend WithEvents flpButtons As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents btnMembers As System.Windows.Forms.Button
        Friend WithEvents btnAccounts As System.Windows.Forms.Button
        Friend WithEvents btnSavings As System.Windows.Forms.Button
        Friend WithEvents btnLoans As System.Windows.Forms.Button
        Friend WithEvents btnReports As System.Windows.Forms.Button
        Friend WithEvents btnUsers As System.Windows.Forms.Button
        Friend WithEvents btnBackup As System.Windows.Forms.Button
        Friend WithEvents sslMain As System.Windows.Forms.StatusStrip
        Friend WithEvents tssUser As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tssDate As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
        Friend WithEvents mMnuFile As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuLogout As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuSep1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mMnuExit As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuModules As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuMembers As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuAccounts As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuSavings As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuLoans As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuReports As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuUsers As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuBackup As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuWindow As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuHelp As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mMnuAbout As System.Windows.Forms.ToolStripMenuItem

    End Class
End Namespace
