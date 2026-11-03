' =====================================================================
' DAL.MemberRepository - CRUD and search access to the Members table.
' All SQL is parameterised to prevent SQL injection.
' =====================================================================
Imports Microsoft.Data.Sqlite
Imports SaccoManager.BLL.Models

Namespace DAL

    Public Class MemberRepository

        ''' <summary>Loads all members ordered by name.</summary>
        Public Function GetAll() As List(Of Member)
            Return QueryMembers("SELECT MemberID, MemberNo, FullName, Phone, Email, JoinDate, Status FROM Members ORDER BY FullName;", Nothing)
        End Function

        ''' <summary>Searches members by number or name (partial match).</summary>
        Public Function Search(term As String) As List(Of Member)
            Dim pattern As String = "%" & term & "%"
            Return QueryMembers(
                "SELECT MemberID, MemberNo, FullName, Phone, Email, JoinDate, Status FROM Members " &
                "WHERE MemberNo LIKE @t OR FullName LIKE @t ORDER BY FullName;",
                Function(cmd) cmd.Parameters.AddWithValue("@t", pattern))
        End Function

        ''' <summary>Finds one member by id; returns Nothing when not found.</summary>
        Public Function GetById(memberId As Integer) As Member
            Dim list As List(Of Member) = QueryMembers(
                "SELECT MemberID, MemberNo, FullName, Phone, Email, JoinDate, Status FROM Members WHERE MemberID = @id;",
                Function(cmd) cmd.Parameters.AddWithValue("@id", memberId))
            If list.Count = 0 Then
                Return Nothing
            End If
            Return list(0)
        End Function

        ''' <summary>Inserts a member and returns the new MemberID.</summary>
        Public Function Add(member As Member) As Integer
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "INSERT INTO Members (MemberNo, FullName, Phone, Email, JoinDate, Status) VALUES (@no, @f, @p, @e, @d, @s); SELECT last_insert_rowid();"
                    cmd.Parameters.AddWithValue("@no", member.MemberNo)
                    cmd.Parameters.AddWithValue("@f", member.FullName)
                    cmd.Parameters.AddWithValue("@p", member.Phone)
                    cmd.Parameters.AddWithValue("@e", Db.ToDbNull(member.Email))
                    cmd.Parameters.AddWithValue("@d", member.JoinDate.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@s", member.Status)
                    Return CInt(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        ''' <summary>Updates an existing member's details.</summary>
        Public Sub Update(member As Member)
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "UPDATE Members SET MemberNo = @no, FullName = @f, Phone = @p, Email = @e, JoinDate = @d, Status = @s WHERE MemberID = @id;"
                    cmd.Parameters.AddWithValue("@no", member.MemberNo)
                    cmd.Parameters.AddWithValue("@f", member.FullName)
                    cmd.Parameters.AddWithValue("@p", member.Phone)
                    cmd.Parameters.AddWithValue("@e", Db.ToDbNull(member.Email))
                    cmd.Parameters.AddWithValue("@d", member.JoinDate.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@s", member.Status)
                    cmd.Parameters.AddWithValue("@id", member.MemberID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        ''' <summary>Deletes a member (their accounts and transactions cascade).</summary>
        Public Sub Delete(memberId As Integer)
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "DELETE FROM Members WHERE MemberID = @id;"
                    cmd.Parameters.AddWithValue("@id", memberId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        ''' <summary>True when the member number is already used by another member.</summary>
        Public Function MemberNoExists(memberNo As String, excludeMemberId As Integer) As Boolean
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "SELECT COUNT(*) FROM Members WHERE MemberNo = @no AND MemberID <> @id;"
                    cmd.Parameters.AddWithValue("@no", memberNo)
                    cmd.Parameters.AddWithValue("@id", excludeMemberId)
                    Return CInt(cmd.ExecuteScalar()) > 0
                End Using
            End Using
        End Function

        Private Shared Function QueryMembers(sql As String, setParams As Action(Of SqliteCommand)) As List(Of Member)
            Dim members As New List(Of Member)()
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = sql
                    If setParams IsNot Nothing Then
                        setParams(cmd)
                    End If
                    Using r As SqliteDataReader = cmd.ExecuteReader()
                        While r.Read()
                            members.Add(New Member With {
                                .MemberID = r.GetInt32(0),
                                .MemberNo = r.GetString(1),
                                .FullName = r.GetString(2),
                                .Phone = r.GetString(3),
                                .Email = If(r.IsDBNull(4), Nothing, r.GetString(4)),
                                .JoinDate = Db.ParseDate(r.GetString(5)),
                                .Status = r.GetString(6)
                            })
                        End While
                    End Using
                End Using
            End Using
            Return members
        End Function

    End Class

End Namespace
