' =====================================================================
' BLL.Models.User - a system user (Administrator or Teller).
' PasswordHash and Salt travel with the model but are never shown in
' the user interface.
' =====================================================================
Namespace BLL.Models

    Public Class User

        Public Property UserID As Integer
        Public Property Username As String
        Public Property PasswordHash As String
        Public Property Salt As String
        Public Property FullName As String
        Public Property Role As String

        ''' <summary>True when the user holds the Administrator role.</summary>
        Public ReadOnly Property IsAdmin As Boolean
            Get
                Return Role = "Administrator"
            End Get
        End Property

    End Class

End Namespace
