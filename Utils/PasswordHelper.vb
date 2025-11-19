Imports System.Security.Cryptography
Imports System.Text
Public Class PasswordHelper
    Public Shared Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()

            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Dim builder As New StringBuilder()
            For i As Integer = 0 To hash.Length - 1
                builder.Append(hash(i).ToString("x2"))
            Next

            Return builder.ToString()
        End Using
    End Function

    Public Shared Function VerifyPassword(password As String, hash As String) As Boolean
        Dim passwordHash As String = HashPassword(password)
        Return passwordHash.Equals(hash, StringComparison.OrdinalIgnoreCase)
    End Function
End Class
