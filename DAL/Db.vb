' =====================================================================
' DAL.Db - the single home of the database connection details.
' Every data access class obtains its SQLite connection from here, so
' the storage location is configured in exactly one place. The schema
' is created automatically on first use and the file can be redirected
' (for example to a temporary copy in the unit tests) via Configure().
' =====================================================================
Imports Microsoft.Data.Sqlite

Namespace DAL

    Public Class Db

        ' Default storage: sacco_manager.db in AppData\Roaming\SaccoManager for per-user isolation.
        Private Shared _dbFile As String = GetDefaultDatabasePath()

        ''' <summary>Constructs the default database path in AppData and ensures the folder exists.</summary>
        Private Shared Function GetDefaultDatabasePath() As String
            Dim appDataPath As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SaccoManager")
            IO.Directory.CreateDirectory(appDataPath)
            Return IO.Path.Combine(appDataPath, "sacco_manager.db")
        End Function

        ''' <summary>Full path of the SQLite database file currently in use.</summary>
        Public Shared ReadOnly Property DatabaseFile As String
            Get
                Return _dbFile
            End Get
        End Property

        ''' <summary>Redirects the database to a specific file (used by tests and restore).</summary>
        Public Shared Sub Configure(filePath As String)
            _dbFile = filePath
        End Sub

        ''' <summary>Opens and returns a new connection with foreign keys enforced.</summary>
        Public Shared Function GetConnection() As SqliteConnection
            Dim cnn As New SqliteConnection($"Data Source={_dbFile}")
            cnn.Open()
            Using pragma As SqliteCommand = cnn.CreateCommand()
                pragma.CommandText = "PRAGMA foreign_keys = ON;"
                pragma.ExecuteNonQuery()
            End Using
            Return cnn
        End Function

        ''' <summary>Creates all tables if the database file is new. Safe to call repeatedly.</summary>
        Public Shared Sub EnsureSchema()
            Using cnn As SqliteConnection = GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = ReadResource("SaccoManager.sacco_schema.sql")
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        ''' <summary>Counts the rows of a table (table names come from code, never user input).</summary>
        Public Shared Function CountRows(cnn As SqliteConnection, tableName As String) As Integer
            Using cmd As SqliteCommand = cnn.CreateCommand()
                cmd.CommandText = $"SELECT COUNT(*) FROM {tableName};"
                Return CInt(cmd.ExecuteScalar())
            End Using
        End Function

        ''' <summary>Converts a date-only value stored as yyyy-MM-dd text back to a Date.</summary>
        Public Shared Function ParseDate(value As String) As Date
            Return Date.ParseExact(value, "yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture)
        End Function

        ''' <summary>Maps empty or Nothing strings to DBNull for optional columns.</summary>
        Public Shared Function ToDbNull(value As String) As Object
            If String.IsNullOrWhiteSpace(value) Then
                Return DBNull.Value
            End If
            Return value
        End Function

        ''' <summary>Reads an embedded resource (for example the schema script) as text.</summary>
        Private Shared Function ReadResource(name As String) As String
            ' Use the assembly that contains Db itself, not the executing assembly,
            ' so the schema is found no matter which project calls this code.
            Dim asm As Reflection.Assembly = GetType(Db).Assembly
            Using stream As IO.Stream = asm.GetManifestResourceStream(name)
                If stream Is Nothing Then
                    Throw New IO.FileNotFoundException("Embedded resource not found: " & name)
                End If
                Using reader As New IO.StreamReader(stream)
                    Return reader.ReadToEnd()
                End Using
            End Using
        End Function

    End Class

End Namespace
