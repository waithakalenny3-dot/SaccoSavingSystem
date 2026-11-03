' =====================================================================
' BLL.Services.ValidationService - all business input validation rules.
' Each method returns a list of user-readable error messages; an empty
' list means the input is valid. Called by the UI forms before any
' data reaches the database.
' =====================================================================
Imports System.Text.RegularExpressions

Namespace BLL.Services

    Public Class ValidationService

        ''' <summary>Validates member details: required fields, phone and email formats.</summary>
        Public Shared Function ValidateMember(memberNo As String, fullName As String, phone As String, email As String) As List(Of String)
            Dim errors As New List(Of String)()
            If String.IsNullOrWhiteSpace(memberNo) Then
                errors.Add("Member number is required.")
            End If
            If String.IsNullOrWhiteSpace(fullName) Then
                errors.Add("Full name is required.")
            End If
            If Not Regex.IsMatch(If(phone, ""), "^\+?\d{9,15}$") Then
                errors.Add("Phone must be 9 to 15 digits, optionally starting with '+' (example: +254712345678).")
            End If
            If Not String.IsNullOrWhiteSpace(email) AndAlso Not Regex.IsMatch(email, "^[\w.+-]+@[\w-]+\.[\w.-]+$") Then
                errors.Add("The email address is not valid.")
            End If
            Return errors
        End Function

        ''' <summary>Validates that a money amount is greater than zero.</summary>
        Public Shared Function ValidateAmount(amount As Decimal) As List(Of String)
            Dim errors As New List(Of String)()
            If amount <= 0D Then
                errors.Add("The amount must be greater than zero.")
            End If
            Return errors
        End Function

        ''' <summary>Validates a withdrawal against the balance and the minimum balance of the account type.</summary>
        Public Shared Function ValidateWithdrawal(amount As Decimal, balance As Decimal, minBalance As Decimal) As List(Of String)
            Dim errors As List(Of String) = ValidateAmount(amount)
            Dim available As Decimal = balance - minBalance
            If amount > available Then
                errors.Add($"Withdrawal exceeds available funds. Available: {available:N2} (balance {balance:N2} minus minimum {minBalance:N2}).")
            End If
            Return errors
        End Function

        ''' <summary>Validates loan issue parameters: principal, rate and term ranges.</summary>
        Public Shared Function ValidateLoanIssue(principal As Decimal, annualRatePercent As Double, termMonths As Integer) As List(Of String)
            Dim errors As New List(Of String)()
            If principal <= 0D Then
                errors.Add("The loan principal must be greater than zero.")
            End If
            If annualRatePercent < 0 OrElse annualRatePercent > 100 Then
                errors.Add("The interest rate must be between 0 and 100 percent per year.")
            End If
            If termMonths <= 0 OrElse termMonths > 120 Then
                errors.Add("The term must be between 1 and 120 months.")
            End If
            Return errors
        End Function

        ''' <summary>Validates a loan repayment against the outstanding amount.</summary>
        Public Shared Function ValidateRepayment(amount As Decimal, outstanding As Decimal) As List(Of String)
            Dim errors As List(Of String) = ValidateAmount(amount)
            If amount > outstanding Then
                errors.Add($"The repayment exceeds the outstanding amount of {outstanding:N2}.")
            End If
            Return errors
        End Function

        ''' <summary>Validates a new user: username, full name, role and password length.</summary>
        Public Shared Function ValidateUser(username As String, fullName As String, role As String, password As String) As List(Of String)
            Dim errors As New List(Of String)()
            If String.IsNullOrWhiteSpace(username) Then
                errors.Add("Username is required.")
            ElseIf username.Trim().Contains(" "c) Then
                errors.Add("Username must not contain spaces.")
            End If
            If String.IsNullOrWhiteSpace(fullName) Then
                errors.Add("Full name is required.")
            End If
            If role <> "Administrator" AndAlso role <> "Teller" Then
                errors.Add("A role (Administrator or Teller) must be selected.")
            End If
            If String.IsNullOrEmpty(password) OrElse password.Length < 6 Then
                errors.Add("The password must be at least 6 characters long.")
            End If
            Return errors
        End Function

    End Class

End Namespace
