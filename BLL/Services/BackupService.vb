' =====================================================================
' BLL.Services.BackupService - database backup and restore (admin only).
' A backup is a timestamped file copy of the SQLite database. Restore
' overwrites the live database file with the chosen backup copy.
' =====================================================================
Namespace BLL.Services

    Public Class BackupService

        ''' <summary>Copies the database to a destination file; returns the backup path used.</summary>
        Public Function Backup(databaseFile As String, destinationFile As String) As String
            If Not IO.File.Exists(databaseFile) Then
                Throw New IO.FileNotFoundException("The database file was not found.", databaseFile)
            End If
            Dim target As String = destinationFile
            If String.IsNullOrWhiteSpace(target) Then
                Dim stamp As String = Date.Now.ToString("yyyyMMdd_HHmmss")
                target = IO.Path.Combine(IO.Path.GetDirectoryName(databaseFile), "sacco_backup_" & stamp & ".db")
            End If
            IO.File.Copy(databaseFile, target, True)
            Return target
        End Function

        ''' <summary>Overwrites the live database file with the chosen backup copy.</summary>
        Public Sub Restore(backupFile As String, databaseFile As String)
            If Not IO.File.Exists(backupFile) Then
                Throw New IO.FileNotFoundException("The backup file was not found.", backupFile)
            End If
            IO.File.Copy(backupFile, databaseFile, True)
        End Sub

    End Class

End Namespace
