' =====================================================================
' DAL.UserRepository - CRUD access to the Users table.
' All SQL is parameterised; password hashes and salts are handled by
' the PasswordHasher module and are never written as plain text.
' =====================================================================
Imports Microsoft.Data.Sqlite
Imports SaccoManager.BLL.Models

Namespace DAL

    Public Class UserRepository

        ''' <summary>Loads all users ordered by username.</summary>
        Public Function GetAll() As List(Of User)
            Dim users As New List(Of User)()
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "SELECT UserID, Username, PasswordHash, Salt, FullName, Role FROM Users ORDER BY Username;"
                    Using r As SqliteDataReader = cmd.ExecuteReader()
                        While r.Read()
                            users.Add(MapUser(r))
                        End While
                    End Using
                End Using
            End Using
            Return users
        End Function

        ''' <summary>Finds a user by username; returns Nothing when not found.</summary>
        Public Function GetByUsername(username As String) As User
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "SELECT UserID, Username, PasswordHash, Salt, FullName, Role FROM Users WHERE Username = @u;"
                    cmd.Parameters.AddWithValue("@u", username)
                    Using r As SqliteDataReader = cmd.ExecuteReader()
                        If r.Read() Then
                            Return MapUser(r)
                        End If
                    End Using
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>Inserts a new user (hash and salt already computed) and returns the new UserID.</summary>
        Public Function Add(user As User) As Integer
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "INSERT INTO Users (Username, PasswordHash, Salt, FullName, Role) VALUES (@u, @h, @s, @f, @r); SELECT last_insert_rowid();"
                    cmd.Parameters.AddWithValue("@u", user.Username)
                    cmd.Parameters.AddWithValue("@h", user.PasswordHash)
                    cmd.Parameters.AddWithValue("@s", user.Salt)
                    cmd.Parameters.AddWithValue("@f", user.FullName)
                    cmd.Parameters.AddWithValue("@r", user.Role)
                    Return CInt(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        ''' <summary>Replaces the stored password hash and salt for a user.</summary>
        Public Sub UpdatePassword(userId As Integer, passwordHash As String, salt As String)
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "UPDATE Users SET PasswordHash = @h, Salt = @s WHERE UserID = @id;"
                    cmd.Parameters.AddWithValue("@h", passwordHash)
                    cmd.Parameters.AddWithValue("@s", salt)
                    cmd.Parameters.AddWithValue("@id", userId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        ''' <summary>Deletes a user by id.</summary>
        Public Sub Delete(userId As Integer)
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "DELETE FROM Users WHERE UserID = @id;"
                    cmd.Parameters.AddWithValue("@id", userId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        ''' <summary>True when the username is already taken by another user.</summary>
        Public Function UsernameExists(username As String, excludeUserId As Integer) As Boolean
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @u AND UserID <> @id;"
                    cmd.Parameters.AddWithValue("@u", username)
                    cmd.Parameters.AddWithValue("@id", excludeUserId)
                    Return CInt(cmd.ExecuteScalar()) > 0
                End Using
            End Using
        End Function

        ''' <summary>Number of users holding the Administrator role.</summary>
        Public Function CountAdmins() As Integer
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Role = 'Administrator';"
                    Return CInt(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        Private Shared Function MapUser(r As SqliteDataReader) As User
            Return New User With {
                .UserID = r.GetInt32(0),
                .Username = r.GetString(1),
                .PasswordHash = r.GetString(2),
                .Salt = r.GetString(3),
                .FullName = r.GetString(4),
                .Role = r.GetString(5)
            }
        End Function

    End Class

End Namespace
