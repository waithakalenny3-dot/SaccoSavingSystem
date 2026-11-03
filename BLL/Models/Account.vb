' =====================================================================
' BLL.Models.Account - a member's savings account (joined with the
' member and account type names for display).
' =====================================================================
Namespace BLL.Models

    Public Class Account

        Public Property AccountID As Integer
        Public Property MemberID As Integer
        Public Property MemberName As String
        Public Property TypeID As Integer
        Public Property TypeName As String
        Public Property AccountNumber As String
        Public Property Balance As Decimal
        Public Property MinBalance As Decimal

    End Class

End Namespace
