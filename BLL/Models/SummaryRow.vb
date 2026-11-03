' =====================================================================
' BLL.Models.SummaryRow - one aggregated row of the daily transactions
' summary report (type, count and total).
' =====================================================================
Namespace BLL.Models

    Public Class SummaryRow

        Public Property TransType As String
        Public Property Count As Integer
        Public Property Total As Decimal

    End Class

End Namespace
