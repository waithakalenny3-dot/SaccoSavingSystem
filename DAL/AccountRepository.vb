' =====================================================================
' DAL.AccountRepository - access to Accounts and AccountTypes.
' Account numbers are generated automatically (AC00001, AC00002, ...)
' inside a single database transaction. All SQL is parameterised.
' =====================================================================
Imports Microsoft.Data.Sqlite
Imports SaccoManager.BLL.Models

Namespace DAL

    Public Class AccountRepository

        ''' <summary>Loads the list of account types (Savings, Fixed Deposit, ...).</summary>
        Public Function GetAccountTypes() As List(Of AccountType)
            Dim types As New List(Of AccountType)()
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "SELECT TypeID, TypeName, MinBalance FROM AccountTypes ORDER BY TypeName;"
                    Using r As SqliteDataReader = cmd.ExecuteReader()
                        While r.Read()
                            types.Add(New AccountType With {
                                .TypeID = r.GetInt32(0),
                                .TypeName = r.GetString(1),
                                .MinBalance = r.GetDecimal(2)
                            })
                        End While
                    End Using
                End Using
            End Using
            Return types
        End Function

        ''' <summary>Finds one account type by id; returns Nothing when not found.</summary>
        Public Function GetAccountTypeById(typeId As Integer) As AccountType
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "SELECT TypeID, TypeName, MinBalance FROM AccountTypes WHERE TypeID = @id;"
                    cmd.Parameters.AddWithValue("@id", typeId)
                    Using r As SqliteDataReader = cmd.ExecuteReader()
                        If r.Read() Then
                            Return New AccountType With {
                                .TypeID = r.GetInt32(0),
                                .TypeName = r.GetString(1),
                                .MinBalance = r.GetDecimal(2)
                            }
                        End If
                    End Using
                End Using
            End Using
            Return Nothing
        End Function

        ''' <summary>Loads all accounts with member and type names, ordered by member.</summary>
        Public Function GetAll() As List(Of Account)
            Return QueryAccounts(
                "SELECT a.AccountID, a.MemberID, m.FullName AS MemberName, a.TypeID, t.TypeName, a.AccountNumber, a.Balance, t.MinBalance " &
                "FROM Accounts a JOIN Members m ON m.MemberID = a.MemberID JOIN AccountTypes t ON t.TypeID = a.TypeID " &
                "ORDER BY m.FullName, a.AccountNumber;", Nothing)
        End Function

        ''' <summary>Loads the accounts of one member.</summary>
        Public Function GetByMember(memberId As Integer) As List(Of Account)
            Return QueryAccounts(
                "SELECT a.AccountID, a.MemberID, m.FullName AS MemberName, a.TypeID, t.TypeName, a.AccountNumber, a.Balance, t.MinBalance " &
                "FROM Accounts a JOIN Members m ON m.MemberID = a.MemberID JOIN AccountTypes t ON t.TypeID = a.TypeID " &
                "WHERE a.MemberID = @id ORDER BY a.AccountNumber;",
                Function(cmd) cmd.Parameters.AddWithValue("@id", memberId))
        End Function

        ''' <summary>Finds one account by id; returns Nothing when not found.</summary>
        Public Function GetById(accountId As Integer) As Account
            Dim list As List(Of Account) = QueryAccounts(
                "SELECT a.AccountID, a.MemberID, m.FullName AS MemberName, a.TypeID, t.TypeName, a.AccountNumber, a.Balance, t.MinBalance " &
                "FROM Accounts a JOIN Members m ON m.MemberID = a.MemberID JOIN AccountTypes t ON t.TypeID = a.TypeID " &
                "WHERE a.AccountID = @id;",
                Function(cmd) cmd.Parameters.AddWithValue("@id", accountId))
            If list.Count = 0 Then
                Return Nothing
            End If
            Return list(0)
        End Function

        ''' <summary>Opens a new account with an auto-generated unique number; returns the created account.</summary>
        Public Function Add(memberId As Integer, typeId As Integer) As Account
            Dim newId As Integer
            Using cnn As SqliteConnection = Db.GetConnection()
                Using tr As SqliteTransaction = cnn.BeginTransaction()
                    Try
                        Using cmd As SqliteCommand = cnn.CreateCommand()
                            cmd.Transaction = tr
                            cmd.CommandText = "INSERT INTO Accounts (MemberID, TypeID, AccountNumber, Balance) VALUES (@m, @t, '', '0'); SELECT last_insert_rowid();"
                            cmd.Parameters.AddWithValue("@m", memberId)
                            cmd.Parameters.AddWithValue("@t", typeId)
                            newId = CInt(cmd.ExecuteScalar())
                        End Using
                        Using cmd2 As SqliteCommand = cnn.CreateCommand()
                            cmd2.Transaction = tr
                            cmd2.CommandText = "UPDATE Accounts SET AccountNumber = @no WHERE AccountID = @id;"
                            cmd2.Parameters.AddWithValue("@no", "AC" & newId.ToString("D5"))
                            cmd2.Parameters.AddWithValue("@id", newId)
                            cmd2.ExecuteNonQuery()
                        End Using
                        tr.Commit()
                    Catch
                        tr.Rollback()
                        Throw
                    End Try
                End Using
            End Using
            Return GetById(newId)
        End Function

        ''' <summary>Deletes an account (its transactions cascade).</summary>
        Public Sub Delete(accountId As Integer)
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "DELETE FROM Accounts WHERE AccountID = @id;"
                    cmd.Parameters.AddWithValue("@id", accountId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Private Shared Function QueryAccounts(sql As String, setParams As Action(Of SqliteCommand)) As List(Of Account)
            Dim accounts As New List(Of Account)()
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = sql
                    If setParams IsNot Nothing Then
                        setParams(cmd)
                    End If
                    Using r As SqliteDataReader = cmd.ExecuteReader()
                        While r.Read()
                            accounts.Add(New Account With {
                                .AccountID = r.GetInt32(0),
                                .MemberID = r.GetInt32(1),
                                .MemberName = r.GetString(2),
                                .TypeID = r.GetInt32(3),
                                .TypeName = r.GetString(4),
                                .AccountNumber = r.GetString(5),
                                .Balance = r.GetDecimal(6),
                                .MinBalance = r.GetDecimal(7)
                            })
                        End While
                    End Using
                End Using
            End Using
            Return accounts
        End Function

    End Class

End Namespace
