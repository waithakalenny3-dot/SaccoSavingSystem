' =====================================================================
' DAL.TransactionRepository - savings transaction processing.
' PostTransaction is the core business process: it updates the account
' balance AND inserts the transaction row inside ONE SQLite transaction
' so the data stays consistent even if the operation fails midway.
' All SQL is parameterised.
' =====================================================================
Imports Microsoft.Data.Sqlite
Imports SaccoManager.BLL.Models

Namespace DAL

    Public Class TransactionRepository

        ''' <summary>
        ''' Posts a deposit or withdrawal atomically (balance update + transaction row)
        ''' and returns the new balance. Rolls back completely on any failure.
        ''' </summary>
        Public Function PostTransaction(accountId As Integer, transType As String, amount As Decimal,
                                        userId As Integer, note As String, Optional transDate As Date = Nothing) As Decimal
            If amount <= 0D Then
                Throw New ArgumentException("Amount must be greater than zero.")
            End If
            If transType <> "Deposit" AndAlso transType <> "Withdrawal" Then
                Throw New ArgumentException("Unsupported transaction type: " & transType)
            End If
            Dim whenPosted As Date = If(transDate = Date.MinValue, Date.Now, transDate)

            Using cnn As SqliteConnection = Db.GetConnection()
                Using tr As SqliteTransaction = cnn.BeginTransaction()
                    Try
                        ' Read the current balance and the minimum allowed balance of the account type.
                        Dim balance As Decimal
                        Dim minBalance As Decimal
                        Using cmd As SqliteCommand = cnn.CreateCommand()
                            cmd.Transaction = tr
                            cmd.CommandText = "SELECT a.Balance, t.MinBalance FROM Accounts a " &
                                              "JOIN AccountTypes t ON t.TypeID = a.TypeID WHERE a.AccountID = @id;"
                            cmd.Parameters.AddWithValue("@id", accountId)
                            Using r As SqliteDataReader = cmd.ExecuteReader()
                                If Not r.Read() Then
                                    Throw New InvalidOperationException("Account not found.")
                                End If
                                balance = r.GetDecimal(0)
                                minBalance = r.GetDecimal(1)
                            End Using
                        End Using

                        ' Defence in depth: the balance rule is re-checked inside the transaction.
                        Dim newBalance As Decimal = balance
                        If transType = "Deposit" Then
                            newBalance += amount
                        Else
                            If amount > balance - minBalance Then
                                Throw New InvalidOperationException(
                                    "Insufficient funds. Available for withdrawal: " & (balance - minBalance).ToString("N2") & ".")
                            End If
                            newBalance -= amount
                        End If

                        Using cmd As SqliteCommand = cnn.CreateCommand()
                            cmd.Transaction = tr
                            cmd.CommandText = "UPDATE Accounts SET Balance = @bal WHERE AccountID = @id;"
                            cmd.Parameters.AddWithValue("@bal", newBalance)
                            cmd.Parameters.AddWithValue("@id", accountId)
                            cmd.ExecuteNonQuery()
                        End Using

                        Using cmd As SqliteCommand = cnn.CreateCommand()
                            cmd.Transaction = tr
                            cmd.CommandText = "INSERT INTO Transactions (AccountID, UserID, TransDate, TransType, Amount, Note) " &
                                              "VALUES (@acc, @usr, @dt, @type, @amt, @note);"
                            cmd.Parameters.AddWithValue("@acc", accountId)
                            cmd.Parameters.AddWithValue("@usr", userId)
                            cmd.Parameters.AddWithValue("@dt", whenPosted.ToString("yyyy-MM-dd HH:mm:ss"))
                            cmd.Parameters.AddWithValue("@type", transType)
                            cmd.Parameters.AddWithValue("@amt", amount)
                            cmd.Parameters.AddWithValue("@note", Db.ToDbNull(note))
                            cmd.ExecuteNonQuery()
                        End Using

                        tr.Commit()
                        Return newBalance
                    Catch
                        tr.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Function

        ''' <summary>Loads the latest transactions of one account, newest first.</summary>
        Public Function GetByAccount(accountId As Integer, Optional limit As Integer = 200) As List(Of SavingsTransaction)
            Return QueryTransactions(
                "SELECT t.TransID, t.AccountID, a.AccountNumber, t.TransDate, t.TransType, t.Amount, t.Note, u.FullName AS PostedBy " &
                "FROM Transactions t JOIN Accounts a ON a.AccountID = t.AccountID JOIN Users u ON u.UserID = t.UserID " &
                "WHERE t.AccountID = @id ORDER BY t.TransDate DESC, t.TransID DESC LIMIT @lim;",
                Sub(cmd)
                    cmd.Parameters.AddWithValue("@id", accountId)
                    cmd.Parameters.AddWithValue("@lim", limit)
                End Sub)
        End Function

        ''' <summary>Loads transactions of one member's accounts within a date range (inclusive).</summary>
        Public Function GetByMemberAndDateRange(memberId As Integer, fromDate As Date, toDate As Date) As List(Of SavingsTransaction)
            Return QueryTransactions(
                "SELECT t.TransID, t.AccountID, a.AccountNumber, t.TransDate, t.TransType, t.Amount, t.Note, u.FullName AS PostedBy " &
                "FROM Transactions t JOIN Accounts a ON a.AccountID = t.AccountID JOIN Users u ON u.UserID = t.UserID " &
                "WHERE a.MemberID = @id AND t.TransDate >= @from AND t.TransDate <= @to " &
                "ORDER BY t.TransDate, t.TransID;",
                Sub(cmd)
                    cmd.Parameters.AddWithValue("@id", memberId)
                    cmd.Parameters.AddWithValue("@from", fromDate.ToString("yyyy-MM-dd 00:00:00"))
                    cmd.Parameters.AddWithValue("@to", toDate.ToString("yyyy-MM-dd 23:59:59"))
                End Sub)
        End Function

        ''' <summary>Aggregated totals per transaction type for one day (daily summary report).</summary>
        Public Function DailySummary(day As Date) As List(Of SummaryRow)
            Dim rows As New List(Of SummaryRow)()
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "SELECT TransType, COUNT(*), SUM(CAST(Amount AS REAL)) FROM Transactions " &
                                      "WHERE substr(TransDate, 1, 10) = @day GROUP BY TransType ORDER BY TransType;"
                    cmd.Parameters.AddWithValue("@day", day.ToString("yyyy-MM-dd"))
                    Using r As SqliteDataReader = cmd.ExecuteReader()
                        While r.Read()
                            rows.Add(New SummaryRow With {
                                .TransType = r.GetString(0),
                                .Count = CInt(r.GetInt64(1)),
                                .Total = CDec(r.GetDouble(2))
                            })
                        End While
                    End Using
                End Using
            End Using
            Return rows
        End Function

        Private Shared Function QueryTransactions(sql As String, setParams As Action(Of SqliteCommand)) As List(Of SavingsTransaction)
            Dim list As New List(Of SavingsTransaction)()
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = sql
                    setParams(cmd)
                    Using r As SqliteDataReader = cmd.ExecuteReader()
                        While r.Read()
                            list.Add(New SavingsTransaction With {
                                .TransID = r.GetInt32(0),
                                .AccountID = r.GetInt32(1),
                                .AccountNumber = r.GetString(2),
                                .TransDate = Date.ParseExact(r.GetString(3), "yyyy-MM-dd HH:mm:ss", Nothing),
                                .TransType = r.GetString(4),
                                .Amount = r.GetDecimal(5),
                                .Note = If(r.IsDBNull(6), Nothing, r.GetString(6)),
                                .PostedBy = r.GetString(7)
                            })
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function

    End Class

End Namespace
