' =====================================================================
' DAL.PasswordHasher - low-level password security utility.
' Passwords are never stored as plain text: they are hashed with
' SHA-256 together with a random 32-byte salt. Verification compares
' hashes in constant time to avoid timing attacks. Both the seeding
' routine and BLL authentication use this module.
' =====================================================================
Imports System.Security.Cryptography

Namespace DAL

    Public Module PasswordHasher

        ''' <summary>Generates a new random salt as a hex string.</summary>
        Public Function NewSalt() As String
            Dim bytes(31) As Byte
            Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
                rng.GetBytes(bytes)
            End Using
            Return BytesToHex(bytes)
        End Function

        ''' <summary>Hashes a password with the given salt (SHA-256, hex output).</summary>
        Public Function Hash(password As String, saltHex As String) As String
            Dim salt As Byte() = HexToBytes(saltHex)
            Dim pwBytes As Byte() = Text.Encoding.UTF8.GetBytes(password)
            Dim combined(salt.Length + pwBytes.Length - 1) As Byte
            Buffer.BlockCopy(salt, 0, combined, 0, salt.Length)
            Buffer.BlockCopy(pwBytes, 0, combined, salt.Length, pwBytes.Length)
            Using sha As SHA256 = SHA256.Create()
                Return BytesToHex(sha.ComputeHash(combined))
            End Using
        End Function

        ''' <summary>Checks a password against a stored salt + hash pair.</summary>
        Public Function Verify(password As String, saltHex As String, expectedHashHex As String) As Boolean
            Dim actual As Byte() = HexToBytes(Hash(password, saltHex))
            Dim expected As Byte() = HexToBytes(expectedHashHex)
            If actual.Length <> expected.Length Then
                Return False
            End If
            Dim diff As Integer = 0
            For i As Integer = 0 To actual.Length - 1
                diff = diff Or (actual(i) Xor expected(i))
            Next
            Return diff = 0
        End Function

        Private Function BytesToHex(bytes As Byte()) As String
            Dim sb As New Text.StringBuilder(bytes.Length * 2)
            For Each b As Byte In bytes
                sb.Append(b.ToString("x2"))
            Next
            Return sb.ToString()
        End Function

        Private Function HexToBytes(hex As String) As Byte()
            If hex Is Nothing OrElse hex.Length Mod 2 <> 0 Then
                Throw New ArgumentException("Invalid hex string.")
            End If
            Dim bytes(hex.Length \ 2 - 1) As Byte
            For i As Integer = 0 To bytes.Length - 1
                bytes(i) = Convert.ToByte(hex.Substring(i * 2, 2), 16)
            Next
            Return bytes
        End Function

    End Module

End Namespace
