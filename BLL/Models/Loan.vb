' =====================================================================
' BLL.Models.Loan - a member loan with its calculated totals and
' repayment progress. Outstanding is computed, not stored.
' =====================================================================
Namespace BLL.Models

    Public Class Loan

        Public Property LoanID As Integer
        Public Property MemberID As Integer
        Public Property MemberName As String
        Public Property LoanDate As Date
        Public Property Principal As Decimal
        Public Property InterestRate As Double
        Public Property TermMonths As Integer
        Public Property TotalDue As Decimal
        Public Property Installment As Decimal
        Public Property AmountPaid As Decimal
        Public Property Status As String

        ''' <summary>Amount still owed: TotalDue minus AmountPaid (never below zero).</summary>
        Public ReadOnly Property Outstanding As Decimal
            Get
                Dim remaining As Decimal = TotalDue - AmountPaid
                If remaining < 0D Then
                    Return 0D
                End If
                Return remaining
            End Get
        End Property

    End Class

End Namespace
