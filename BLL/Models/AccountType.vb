' =====================================================================
' BLL.Models.AccountType - a savings account product with its minimum
' allowed balance (for example Savings or Fixed Deposit).
' =====================================================================
Namespace BLL.Models

    Public Class AccountType

        Public Property TypeID As Integer
        Public Property TypeName As String
        Public Property MinBalance As Decimal

    End Class

End Namespace
