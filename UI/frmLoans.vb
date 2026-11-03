' =====================================================================
' UI.frmLoans - loan issuing and repayment.
' Issue loans with live preview of the calculated total due and monthly
' installment (LoanCalculator); post repayments that automatically
' update AmountPaid and flip the status to 'Cleared' when fully repaid.
' =====================================================================
Imports System.Windows.Forms
Imports SaccoManager.BLL.Models
Imports SaccoManager.BLL.Services
Imports SaccoManager.DAL

Namespace UI

    Public Class frmLoans

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        Private ReadOnly _loanRepo As New LoanRepository()
        Private ReadOnly _memberRepo As New MemberRepository()
        Private _selectedLoan As Loan

        Private Sub frmLoans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Font = UiHelper.AppFont
            UiHelper.StyleGrid(dgvLoans)

            Dim tips As New ToolTip()
            tips.SetToolTip(btnIssue, "Issue the loan with the calculated totals")
            tips.SetToolTip(btnRepay, "Post the repayment against the selected loan")
            tips.SetToolTip(nudRate, "Annual interest rate in percent")

            LoadMemberCombo()
            LoadLoans()
            UpdatePreview()
        End Sub

        ''' <summary>Fills the member combo box (displayed as number - name).</summary>
        Private Sub LoadMemberCombo()
            cboMember.DisplayMember = "Display"
            cboMember.ValueMember = "Key"
            cboMember.DataSource = _memberRepo.GetAll().Select(
                Function(m) New ComboItem With {.Key = m.MemberID, .Display = m.MemberNo & " - " & m.FullName}).ToList()
        End Sub

        ''' <summary>Loads all loans into the grid.</summary>
        Private Sub LoadLoans()
            dgvLoans.DataSource = New SortableBindingList(Of Loan)(_loanRepo.GetAll())
            UiHelper.HideColumns(dgvLoans, "LoanID", "MemberID")
            For Each name As String In {"Principal", "TotalDue", "Installment", "AmountPaid"}
                If dgvLoans.Columns(name) IsNot Nothing Then
                    dgvLoans.Columns(name).DefaultCellStyle.Format = "N2"
                End If
            Next
            ClearRepaymentPanel()
        End Sub

        ''' <summary>Clears the repayment panel back to no selection.</summary>
        Private Sub ClearRepaymentPanel()
            _selectedLoan = Nothing
            lblLoanInfo.Text = "None - click a loan in the table above"
            nudRepay.Value = 0
            btnRepay.Enabled = False
        End Sub

        ''' <summary>Shows the calculated totals for the values currently entered.</summary>
        Private Sub UpdatePreview()
            If nudPrincipal.Value <= 0 OrElse nudTerm.Value < 1 Then
                lblPreview.Text = "Total due: -    Monthly installment: -"
                Return
            End If
            Try
                Dim total As Decimal = LoanCalculator.ComputeTotalDue(nudPrincipal.Value, CDbl(nudRate.Value), CInt(nudTerm.Value))
                Dim installment As Decimal = LoanCalculator.ComputeInstallment(total, CInt(nudTerm.Value))
                lblPreview.Text = $"Total due: {total:N2}    Monthly installment: {installment:N2}"
            Catch ex As ArgumentException
                lblPreview.Text = "Total due: -    Monthly installment: -"
            End Try
        End Sub

        Private Sub PreviewChanged(sender As Object, e As EventArgs) Handles nudPrincipal.ValueChanged, nudRate.ValueChanged, nudTerm.ValueChanged
            UpdatePreview()
        End Sub

        ''' <summary>Fills the repayment panel from the clicked loan row.</summary>
        Private Sub dgvLoans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLoans.CellClick
            If e.RowIndex < 0 Then
                Return
            End If
            Dim loan As Loan = TryCast(dgvLoans.Rows(e.RowIndex).DataBoundItem, Loan)
            If loan Is Nothing Then
                Return
            End If
            _selectedLoan = loan
            lblLoanInfo.Text = $"Loan #{loan.LoanID} - {loan.MemberName} - Outstanding: {loan.Outstanding:N2} of {loan.TotalDue:N2}"
            nudRepay.Maximum = loan.Outstanding
            nudRepay.Value = loan.Outstanding
            btnRepay.Enabled = (loan.Status = "Active" AndAlso loan.Outstanding > 0D)
        End Sub

        ''' <summary>Validates and issues the loan with its calculated totals.</summary>
        Private Sub btnIssue_Click(sender As Object, e As EventArgs) Handles btnIssue.Click
            If cboMember.SelectedIndex < 0 OrElse cboMember.SelectedValue Is Nothing Then
                UiHelper.Warn("Select the member who is borrowing first.")
                Return
            End If
            Dim principal As Decimal = nudPrincipal.Value
            Dim rate As Double = CDbl(nudRate.Value)
            Dim term As Integer = CInt(nudTerm.Value)

            Dim errors As List(Of String) = ValidationService.ValidateLoanIssue(principal, rate, term)
            If errors.Count > 0 Then
                UiHelper.ShowErrors(errors)
                Return
            End If

            Try
                Dim total As Decimal = LoanCalculator.ComputeTotalDue(principal, rate, term)
                Dim installment As Decimal = LoanCalculator.ComputeInstallment(total, term)
                Dim loan As New Loan With {
                    .MemberID = CInt(cboMember.SelectedValue), .LoanDate = Date.Now, .Principal = principal,
                    .InterestRate = rate, .TermMonths = term, .TotalDue = total, .Installment = installment}
                _loanRepo.IssueLoan(loan, AuthService.CurrentUser.UserID)
                UiHelper.Info($"Loan issued successfully. Total due: {total:N2}, monthly installment: {installment:N2}.")
                nudPrincipal.Value = 0
                LoadLoans()
                UpdatePreview()
            Catch ex As Exception
                UiHelper.[Error]("The loan could not be issued: " & ex.Message)
            End Try
        End Sub

        ''' <summary>Validates and posts the repayment; the status updates automatically.</summary>
        Private Sub btnRepay_Click(sender As Object, e As EventArgs) Handles btnRepay.Click
            If _selectedLoan Is Nothing Then
                UiHelper.Warn("Select a loan in the table first, then enter the repayment amount.")
                Return
            End If
            Dim amount As Decimal = nudRepay.Value
            Dim errors As List(Of String) = ValidationService.ValidateRepayment(amount, _selectedLoan.Outstanding)
            If errors.Count > 0 Then
                UiHelper.ShowErrors(errors)
                Return
            End If
            Try
                Dim updated As Loan = _loanRepo.RepayLoan(_selectedLoan.LoanID, amount, AuthService.CurrentUser.UserID)
                If updated.Status = "Cleared" Then
                    UiHelper.Info("Repayment posted. The loan is now fully CLEARED.")
                Else
                    UiHelper.Info("Repayment posted. Outstanding amount: " & updated.Outstanding.ToString("N2"))
                End If
                LoadLoans()
            Catch ex As Exception
                UiHelper.[Error]("The repayment could not be posted: " & ex.Message)
            End Try
        End Sub

    End Class

End Namespace
