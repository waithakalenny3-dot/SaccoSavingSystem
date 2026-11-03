' =====================================================================
' DAL.LoanRepository - loan processing access to the Loans table.
' RepayLoan updates AmountPaid and flips Status to 'Cleared' inside ONE
' SQLite transaction so data stays consistent. All SQL is parameterised.
' =====================================================================
Imports Microsoft.Data.Sqlite
Imports SaccoManager.BLL.Models

Namespace DAL

    Public Class LoanRepository

        ''' <summary>Loads all loans with member names; optionally filtered by status.</summary>
        Public Function GetAll(Optional status As String = Nothing) As List(Of Loan)
            Dim sql As String =
                "SELECT l.LoanID, l.MemberID, m.FullName AS MemberName, l.LoanDate, l.Principal, l.InterestRate, " &
                "l.TermMonths, l.TotalDue, l.Installment, l.AmountPaid, l.Status " &
                "FROM Loans l JOIN Members m ON m.MemberID = l.MemberID"
            If Not String.IsNullOrWhiteSpace(status) Then
                sql &= " WHERE l.Status = @status"
            End If
            sql &= " ORDER BY l.LoanID DESC;"
            Dim setParams As Action(Of SqliteCommand) = Nothing
            If Not String.IsNullOrWhiteSpace(status) Then
                setParams = Sub(cmd) cmd.Parameters.AddWithValue("@status", status)
            End If
            Return QueryLoans(sql, setParams)
        End Function

        ''' <summary>Finds one loan by id; returns Nothing when not found.</summary>
        Public Function GetById(loanId As Integer) As Loan
            Dim list As List(Of Loan) = QueryLoans(
                "SELECT l.LoanID, l.MemberID, m.FullName AS MemberName, l.LoanDate, l.Principal, l.InterestRate, " &
                "l.TermMonths, l.TotalDue, l.Installment, l.AmountPaid, l.Status " &
                "FROM Loans l JOIN Members m ON m.MemberID = l.MemberID WHERE l.LoanID = @id;",
                Function(cmd) cmd.Parameters.AddWithValue("@id", loanId))
            If list.Count = 0 Then
                Return Nothing
            End If
            Return list(0)
        End Function

        ''' <summary>Inserts a new loan with its calculated totals and returns the new LoanID.</summary>
        Public Function IssueLoan(loan As Loan, issuedByUserId As Integer) As Integer
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "INSERT INTO Loans (MemberID, UserID, LoanDate, Principal, InterestRate, TermMonths, TotalDue, Installment, AmountPaid, Status) " &
                                      "VALUES (@m, @u, @d, @p, @r, @t, @td, @inst, '0', 'Active'); SELECT last_insert_rowid();"
                    cmd.Parameters.AddWithValue("@m", loan.MemberID)
                    cmd.Parameters.AddWithValue("@u", issuedByUserId)
                    cmd.Parameters.AddWithValue("@d", loan.LoanDate.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@p", loan.Principal)
                    cmd.Parameters.AddWithValue("@r", loan.InterestRate)
                    cmd.Parameters.AddWithValue("@t", loan.TermMonths)
                    cmd.Parameters.AddWithValue("@td", loan.TotalDue)
                    cmd.Parameters.AddWithValue("@inst", loan.Installment)
                    Return CInt(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Posts a repayment atomically: increases AmountPaid and automatically
        ''' flips Status to 'Cleared' when the loan is fully repaid.
        ''' </summary>
        Public Function RepayLoan(loanId As Integer, amount As Decimal, repaidByUserId As Integer) As Loan
            If amount <= 0D Then
                Throw New ArgumentException("Repayment must be greater than zero.")
            End If
            Using cnn As SqliteConnection = Db.GetConnection()
                Using tr As SqliteTransaction = cnn.BeginTransaction()
                    Try
                        Dim totalDue As Decimal
                        Dim amountPaid As Decimal
                        Using cmd As SqliteCommand = cnn.CreateCommand()
                            cmd.Transaction = tr
                            cmd.CommandText = "SELECT TotalDue, AmountPaid FROM Loans WHERE LoanID = @id;"
                            cmd.Parameters.AddWithValue("@id", loanId)
                            Using r As SqliteDataReader = cmd.ExecuteReader()
                                If Not r.Read() Then
                                    Throw New InvalidOperationException("Loan not found.")
                                End If
                                totalDue = r.GetDecimal(0)
                                amountPaid = r.GetDecimal(1)
                            End Using
                        End Using

                        ' Defence in depth: repayment rules re-checked inside the transaction.
                        Dim outstanding As Decimal = totalDue - amountPaid
                        If outstanding <= 0D Then
                            Throw New InvalidOperationException("This loan is already fully repaid.")
                        End If
                        If amount > outstanding Then
                            Throw New InvalidOperationException(
                                "Repayment exceeds the outstanding amount of " & outstanding.ToString("N2") & ".")
                        End If

                        Dim newPaid As Decimal = amountPaid + amount
                        Dim newStatus As String = If(newPaid >= totalDue, "Cleared", "Active")

                        Using cmd As SqliteCommand = cnn.CreateCommand()
                            cmd.Transaction = tr
                            cmd.CommandText = "UPDATE Loans SET AmountPaid = @paid, Status = @status WHERE LoanID = @id;"
                            cmd.Parameters.AddWithValue("@paid", newPaid)
                            cmd.Parameters.AddWithValue("@status", newStatus)
                            cmd.Parameters.AddWithValue("@id", loanId)
                            cmd.ExecuteNonQuery()
                        End Using

                        tr.Commit()
                    Catch
                        tr.Rollback()
                        Throw
                    End Try
                End Using
            End Using
            Return GetById(loanId)
        End Function

        Private Shared Function QueryLoans(sql As String, setParams As Action(Of SqliteCommand)) As List(Of Loan)
            Dim loans As New List(Of Loan)()
            Using cnn As SqliteConnection = Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = sql
                    If setParams IsNot Nothing Then
                        setParams(cmd)
                    End If
                    Using r As SqliteDataReader = cmd.ExecuteReader()
                        While r.Read()
                            loans.Add(New Loan With {
                                .LoanID = r.GetInt32(0),
                                .MemberID = r.GetInt32(1),
                                .MemberName = r.GetString(2),
                                .LoanDate = Db.ParseDate(r.GetString(3)),
                                .Principal = r.GetDecimal(4),
                                .InterestRate = r.GetDouble(5),
                                .TermMonths = r.GetInt32(6),
                                .TotalDue = r.GetDecimal(7),
                                .Installment = r.GetDecimal(8),
                                .AmountPaid = r.GetDecimal(9),
                                .Status = r.GetString(10)
                            })
                        End While
                    End Using
                End Using
            End Using
            Return loans
        End Function

    End Class

End Namespace
