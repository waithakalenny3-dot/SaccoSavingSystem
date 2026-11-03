' =====================================================================
' BLL.Services.DatabaseInitializer - prepares the database for use.
' Creates the schema (if the database file is new) and seeds demo data
' (users, account types, members, accounts, transactions, one loan)
' the first time the system runs, so it can be demonstrated at once.
' All seeding goes through the repositories so the same business rules
' (hashing, atomic transactions, auto numbers) apply.
' =====================================================================
Imports Microsoft.Data.Sqlite
Imports SaccoManager.BLL.Models

Namespace BLL.Services

    Public Class DatabaseInitializer

        ''' <summary>Creates the schema and seeds demo data when the database is empty.</summary>
        Public Shared Sub EnsureDatabase()
            DAL.Db.EnsureSchema()
            Using cnn As SqliteConnection = DAL.Db.GetConnection()
                If DAL.Db.CountRows(cnn, "Users") = 0 Then
                    Seed()
                End If
            End Using
        End Sub

        ''' <summary>Inserts the sample data used for demonstration and testing.</summary>
        Private Shared Sub Seed()
            Dim userRepo As New DAL.UserRepository()
            Dim typeRepo As New DAL.AccountRepository()
            Dim memberRepo As New DAL.MemberRepository()
            Dim transRepo As New DAL.TransactionRepository()
            Dim loanRepo As New DAL.LoanRepository()

            ' --- Users (passwords hashed with random salts, never plain text) ---
            Dim adminRecord As Tuple(Of String, String) = AuthService.CreatePasswordRecord("Admin@123")
            Dim adminId As Integer = userRepo.Add(New User With {
                .Username = "admin", .PasswordHash = adminRecord.Item1, .Salt = adminRecord.Item2,
                .FullName = "System Administrator", .Role = "Administrator"})
            Dim tellerRecord As Tuple(Of String, String) = AuthService.CreatePasswordRecord("Teller@123")
            Dim tellerId As Integer = userRepo.Add(New User With {
                .Username = "teller", .PasswordHash = tellerRecord.Item1, .Salt = tellerRecord.Item2,
                .FullName = "Front Desk Teller", .Role = "Teller"})

            ' --- Account types ---
            typeRepo.GetAccountTypes()
            Dim savingsTypeId As Integer = InsertAccountType("Savings", 0D)
            Dim fixedTypeId As Integer = InsertAccountType("Fixed Deposit", 1000D)

            ' --- Members ---
            Dim janeId As Integer = memberRepo.Add(New Member With {
                .MemberNo = "M001", .FullName = "Jane Wanjiku", .Phone = "+254712345678",
                .Email = "jane.wanjiku@example.com", .JoinDate = Date.Now.AddMonths(-14), .Status = "Active"})
            Dim peterId As Integer = memberRepo.Add(New Member With {
                .MemberNo = "M002", .FullName = "Peter Otieno", .Phone = "+254723456789",
                .Email = Nothing, .JoinDate = Date.Now.AddMonths(-11), .Status = "Active"})
            Dim graceId As Integer = memberRepo.Add(New Member With {
                .MemberNo = "M003", .FullName = "Grace Achieng", .Phone = "+254734567890",
                .Email = "grace.a@example.com", .JoinDate = Date.Now.AddMonths(-8), .Status = "Active"})
            Dim samuelId As Integer = memberRepo.Add(New Member With {
                .MemberNo = "M004", .FullName = "Samuel Kariuki", .Phone = "+254745678901",
                .Email = Nothing, .JoinDate = Date.Now.AddMonths(-6), .Status = "Active"})
            Dim maryId As Integer = memberRepo.Add(New Member With {
                .MemberNo = "M005", .FullName = "Mary Nasimiyu", .Phone = "+254756789012",
                .Email = "mary.n@example.com", .JoinDate = Date.Now.AddMonths(-2), .Status = "Active"})

            ' --- Accounts (numbers generated automatically) ---
            Dim janeAcc As Account = typeRepo.Add(janeId, savingsTypeId)
            Dim peterAcc As Account = typeRepo.Add(peterId, savingsTypeId)
            Dim peterFixed As Account = typeRepo.Add(peterId, fixedTypeId)
            Dim graceAcc As Account = typeRepo.Add(graceId, savingsTypeId)
            Dim samuelAcc As Account = typeRepo.Add(samuelId, fixedTypeId)
            Dim maryAcc As Account = typeRepo.Add(maryId, savingsTypeId)

            ' --- Savings transactions spread over recent days (seeded through the
            '     atomic PostTransaction method so balances stay consistent) ---
            transRepo.PostTransaction(janeAcc.AccountID, "Deposit", 5000D, tellerId, "Opening deposit", Date.Now.AddDays(-10))
            transRepo.PostTransaction(janeAcc.AccountID, "Deposit", 2500D, tellerId, Nothing, Date.Now.AddDays(-5))
            transRepo.PostTransaction(janeAcc.AccountID, "Withdrawal", 1000D, adminId, "School fees", Date.Now.AddDays(-2))
            transRepo.PostTransaction(peterAcc.AccountID, "Deposit", 20000D, tellerId, "Opening deposit", Date.Now.AddDays(-9))
            transRepo.PostTransaction(peterAcc.AccountID, "Deposit", 15000D, tellerId, Nothing, Date.Now.AddDays(-4))
            transRepo.PostTransaction(graceAcc.AccountID, "Deposit", 8000D, tellerId, "Monthly savings", Date.Now.AddDays(-7))
            transRepo.PostTransaction(samuelAcc.AccountID, "Deposit", 12000D, adminId, "Opening deposit", Date.Now.AddDays(-6))
            transRepo.PostTransaction(maryAcc.AccountID, "Deposit", 3000D, tellerId, "Opening deposit", Date.Now.AddDays(-3))
            transRepo.PostTransaction(maryAcc.AccountID, "Deposit", 1500D, tellerId, Nothing, Date.Now)

            ' --- One loan with a partial repayment ---
            Dim loanId As Integer = loanRepo.IssueLoan(New Loan With {
                .MemberID = peterId, .LoanDate = Date.Now.AddDays(-20), .Principal = 20000D,
                .InterestRate = 10.0, .TermMonths = 12,
                .TotalDue = LoanCalculator.ComputeTotalDue(20000D, 10.0, 12),
                .Installment = LoanCalculator.ComputeInstallment(LoanCalculator.ComputeTotalDue(20000D, 10.0, 12), 12)}, adminId)
            loanRepo.RepayLoan(loanId, 5000D, tellerId)
        End Sub

        ''' <summary>Inserts one account type row directly (types are reference data).</summary>
        Private Shared Function InsertAccountType(typeName As String, minBalance As Decimal) As Integer
            Using cnn As SqliteConnection = DAL.Db.GetConnection()
                Using cmd As SqliteCommand = cnn.CreateCommand()
                    cmd.CommandText = "INSERT INTO AccountTypes (TypeName, MinBalance) VALUES (@n, @m); SELECT last_insert_rowid();"
                    cmd.Parameters.AddWithValue("@n", typeName)
                    cmd.Parameters.AddWithValue("@m", minBalance)
                    Return CInt(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

    End Class

End Namespace
