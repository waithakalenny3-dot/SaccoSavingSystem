' =====================================================================
' UI.frmBackup - database backup and restore (Administrator only).
' A backup is a timestamped copy of the SQLite database file chosen by
' the user; restore overwrites the live database after a strong
' confirmation and recommends a restart.
' =====================================================================
Imports System.Windows.Forms
Imports SaccoManager.BLL.Services
Imports SaccoManager.DAL

Namespace UI

    Public Class frmBackup

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        Private ReadOnly _backup As New BackupService()

        Private Sub frmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' Defence in depth: the menu already hides this form for tellers.
            If AuthService.CurrentUser Is Nothing OrElse Not AuthService.CurrentUser.IsAdmin Then
                UiHelper.Warn("Only administrators can back up or restore the database.")
                Me.Close()
                Return
            End If
            Me.Font = UiHelper.AppFont
            lblDbPath.Text = Db.DatabaseFile

            Dim tips As New ToolTip()
            tips.SetToolTip(btnBackup, "Copy the database to a backup file")
            tips.SetToolTip(btnRestore, "Overwrite the database with a backup copy")
        End Sub

        ''' <summary>Copies the live database to a chosen backup file.</summary>
        Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
            Using dlg As New SaveFileDialog()
                dlg.Filter = "Database files (*.db)|*.db|All files (*.*)|*.*"
                dlg.FileName = "sacco_backup_" & Date.Now.ToString("yyyyMMdd_HHmmss") & ".db"
                If dlg.ShowDialog(Me) <> DialogResult.OK Then
                    Return
                End If
                Try
                    Dim path As String = _backup.Backup(Db.DatabaseFile, dlg.FileName)
                    UiHelper.Info("Backup created successfully:" & Environment.NewLine & path)
                Catch ex As Exception
                    UiHelper.[Error]("The backup could not be created: " & ex.Message)
                End Try
            End Using
        End Sub

        ''' <summary>Overwrites the live database with a chosen backup after confirmation.</summary>
        Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
            Using dlg As New OpenFileDialog()
                dlg.Filter = "Database files (*.db)|*.db|All files (*.*)|*.*"
                dlg.Title = "Choose the backup file to restore"
                If dlg.ShowDialog(Me) <> DialogResult.OK Then
                    Return
                End If
                If Not UiHelper.Confirm("Restoring will OVERWRITE all current data with the selected backup." &
                                        Environment.NewLine & "Continue?") Then
                    Return
                End If
                Try
                    _backup.Restore(dlg.FileName, Db.DatabaseFile)
                    UiHelper.Info("Restore completed. Please close and restart the application to load the restored data.")
                Catch ex As Exception
                    UiHelper.[Error]("The restore could not be completed: " & ex.Message)
                End Try
            End Using
        End Sub

    End Class

End Namespace
