' =====================================================================
' UI.frmMain - main dashboard and navigation hub.
' A menu strip plus dashboard buttons reach every module; menu items
' and buttons are enabled or disabled according to the logged-in
' user's role (Administrator sees all, Teller cannot manage users or
' run backups). Modules open as regular windows.
' =====================================================================
Imports System.Windows.Forms
Imports SaccoManager.BLL.Services

Namespace UI

    Public Class frmMain

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        Private ReadOnly _auth As New AuthService()

        Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Font = UiHelper.AppFont
            If AuthService.CurrentUser Is Nothing Then
                Me.Close()
                Return
            End If
            ApplyRole()
            RefreshStatusBar()

            ' Keep the MDI client area behind the docked header, buttons and status bar.
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is MdiClient Then
                    ctrl.SendToBack()
                    Exit For
                End If
            Next

            Dim tips As New ToolTip()
            tips.SetToolTip(btnMembers, "Register and manage sacco members")
            tips.SetToolTip(btnAccounts, "Open and manage members' savings accounts")
            tips.SetToolTip(btnSavings, "Post deposits and withdrawals")
            tips.SetToolTip(btnLoans, "Issue loans and post repayments")
            tips.SetToolTip(btnReports, "Generate, print and export reports")
            tips.SetToolTip(btnUsers, "Manage system users (Administrator only)")
            tips.SetToolTip(btnBackup, "Backup and restore the database (Administrator only)")
        End Sub

        ''' <summary>Enables or disables the administrator-only controls by role.</summary>
        Private Sub ApplyRole()
            Dim isAdmin As Boolean = AuthService.CurrentUser.IsAdmin
            mMnuUsers.Enabled = isAdmin
            mMnuBackup.Enabled = isAdmin
            btnUsers.Enabled = isAdmin
            btnBackup.Enabled = isAdmin
        End Sub

        ''' <summary>Shows the logged-in user and today's date in the status bar.</summary>
        Private Sub RefreshStatusBar()
            tssUser.Text = "Logged in: " & AuthService.CurrentUser.FullName & " (" & AuthService.CurrentUser.Role & ")"
            tssDate.Text = "Today: " & Date.Now.ToString("dddd, dd MMMM yyyy")
        End Sub

        ''' <summary>Opens a child form as a window.</summary>
        Private Sub ShowChild(child As Form)
            Try
                child.Show()
            Catch ex As Exception
                MessageBox.Show("ShowChild Error: " & ex.Message & vbCrLf & "Type: " & ex.GetType().FullName & vbCrLf & vbCrLf & ex.StackTrace, "Error")
            End Try
        End Sub

        ''' <summary>Opens an administrator-only child form.</summary>
        Private Sub ShowChildAdmin(child As Form)
            If Not AuthService.CurrentUser.IsAdmin Then
                UiHelper.Warn("Only administrators can use this module.")
                Return
            End If
            ShowChild(child)
        End Sub

        Private Sub OpenMembers(sender As Object, e As EventArgs) Handles btnMembers.Click
            Try
                ShowChild(New frmMembers())
            Catch ex As Exception
                MessageBox.Show("OpenMembers Error: " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Sub

        Private Sub OpenAccounts(sender As Object, e As EventArgs) Handles btnAccounts.Click
            Try
                ShowChild(New frmAccounts())
            Catch ex As Exception
                MessageBox.Show("OpenAccounts Error: " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Sub

        Private Sub OpenSavings() Handles mMnuSavings.Click, btnSavings.Click
            Try
                ShowChild(New frmSavings())
            Catch ex As Exception
                MessageBox.Show("OpenSavings Error: " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Sub

        Private Sub OpenLoans() Handles mMnuLoans.Click, btnLoans.Click
            Try
                ShowChild(New frmLoans())
            Catch ex As Exception
                MessageBox.Show("OpenLoans Error: " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Sub

        Private Sub OpenReports() Handles mMnuReports.Click, btnReports.Click
            Try
                ShowChild(New frmReports())
            Catch ex As Exception
                MessageBox.Show("OpenReports Error: " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Sub

        Private Sub OpenUsers() Handles mMnuUsers.Click, btnUsers.Click
            Try
                ShowChildAdmin(New frmUsers())
            Catch ex As Exception
                MessageBox.Show("OpenUsers Error: " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Sub

        Private Sub OpenBackup() Handles mMnuBackup.Click, btnBackup.Click
            Try
                ShowChildAdmin(New frmBackup())
            Catch ex As Exception
                MessageBox.Show("OpenBackup Error: " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End Sub

        ''' <summary>Logs out and returns to the login screen; closes the app if cancelled.</summary>
        Private Sub LogOut() Handles mMnuLogout.Click
            If Not UiHelper.Confirm("Log out of the system?") Then
                Return
            End If
            AuthService.Logout()
            Using login As New frmLogin()
                If login.ShowDialog(Me) = DialogResult.OK Then
                    ApplyRole()
                    RefreshStatusBar()
                Else
                    Me.Close()
                End If
            End Using
        End Sub

        Private Sub ExitApp() Handles mMnuExit.Click
            If UiHelper.Confirm("Exit the Sacco Manager?") Then
                Me.Close()
            End If
        End Sub

        Private Sub About() Handles mMnuAbout.Click
            UiHelper.Info("Sacco Savings and Loan Management System v1.0" & Environment.NewLine & Environment.NewLine &
                          "Built with VB.NET Windows Forms, .NET 8 and SQLite." & Environment.NewLine &
                          "A visual programming project.")
        End Sub

    End Class

End Namespace
