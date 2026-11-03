' =====================================================================
' BLL.Services.LoanCalculator - automatic loan calculations.
' Uses simple interest: TotalDue = Principal + Principal * (Rate/100) *
' (TermMonths/12). The monthly installment is TotalDue / TermMonths.
' Kept in its own class so the formula is testable and reusable.
' =====================================================================
Namespace BLL.Services

    Public Class LoanCalculator

        ''' <summary>Total to repay: principal plus simple interest, rounded to 2 dp.</summary>
        Public Shared Function ComputeTotalDue(principal As Decimal, annualRatePercent As Double, termMonths As Integer) As Decimal
            If principal <= 0D Then
                Throw New ArgumentException("Principal must be greater than zero.")
            End If
            If termMonths <= 0 Then
                Throw New ArgumentException("Term must be at least one month.")
            End If
            If annualRatePercent < 0 Then
                Throw New ArgumentException("Interest rate cannot be negative.")
            End If
            Dim rateFactor As Decimal = CDec(annualRatePercent) / 100D
            Dim termYears As Decimal = CDec(termMonths) / 12D
            Dim interest As Decimal = principal * rateFactor * termYears
            Return Decimal.Round(principal + interest, 2)
        End Function

        ''' <summary>Monthly installment: total due divided by the term, rounded to 2 dp.</summary>
        Public Shared Function ComputeInstallment(totalDue As Decimal, termMonths As Integer) As Decimal
            If termMonths <= 0 Then
                Throw New ArgumentException("Term must be at least one month.")
            End If
            Return Decimal.Round(totalDue / CDec(termMonths), 2)
        End Function

    End Class

End Namespace
