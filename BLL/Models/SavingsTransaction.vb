' =====================================================================
' BLL.Models.SavingsTransaction - one deposit or withdrawal, joined
' with the account number and posting user name for display.
' =====================================================================
Namespace BLL.Models

    Public Class SavingsTransaction

        Public Property TransID As Integer
        Public Property AccountID As Integer
        Public Property AccountNumber As String
        Public Property TransDate As Date
        Public Property TransType As String
        Public Property Amount As Decimal
        Public Property Note As String
        Public Property PostedBy As String

    End Class

End Namespace
