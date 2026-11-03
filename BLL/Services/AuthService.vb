' =====================================================================
' BLL.Services.AuthService - authentication and session management.
' Login verifies the SHA-256 hash of the entered password against the
' stored salt + hash; the authenticated user is kept as the shared
' session user and used for role-based access control.
' =====================================================================
Imports SaccoManager.BLL.Models

Namespace BLL.Services

    Public Class AuthService

        ''' <summary>The currently logged-in user for this session.</summary>
        Public Shared Property CurrentUser As User

        ''' <summary>Attempts to log a user in; returns the user on success, Nothing otherwise.</summary>
        Public Function Login(username As String, password As String) As User
            Dim repo As New DAL.UserRepository()
            Dim user As User = repo.GetByUsername(username)
            If user IsNot Nothing AndAlso DAL.PasswordHasher.Verify(password, user.Salt, user.PasswordHash) Then
                CurrentUser = user
                Return user
            End If
            Return Nothing
        End Function

        ''' <summary>Hashes a password with a new random salt; returns (hash, salt).</summary>
        Public Shared Function CreatePasswordRecord(password As String) As Tuple(Of String, String)
            Dim salt As String = DAL.PasswordHasher.NewSalt()
            Return Tuple.Create(DAL.PasswordHasher.Hash(password, salt), salt)
        End Function

        ''' <summary>Verifies a password against a stored hash + salt pair.</summary>
        Public Shared Function VerifyPassword(password As String, salt As String, expectedHash As String) As Boolean
            Return DAL.PasswordHasher.Verify(password, salt, expectedHash)
        End Function

        ''' <summary>Clears the session user.</summary>
        Public Shared Sub Logout()
            CurrentUser = Nothing
        End Sub

    End Class

End Namespace
