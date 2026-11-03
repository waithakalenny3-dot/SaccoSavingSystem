' =====================================================================
' UI.frmSavings - deposit and withdrawal processing.
' Posts transactions through the atomic DAL method (balance update +
' transaction row in one database transaction) and shows the account
' balance and its latest transactions. Amounts come from a NumericUpDown
' control and types from a ComboBox to prevent invalid input.
' =====================================================================
Imports System.Windows.Forms
Imports SaccoManager.BLL.Models
Imports SaccoManager.BLL.Services
Imports SaccoManager.DAL

Namespace UI

    Public Class frmSavings

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        Private ReadOnly _accountRepo As New AccountRepository()
        Private ReadOnly _transRepo As New TransactionRepository()

        Private Sub frmSavings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Font = UiHelper.AppFont
            UiHelper.StyleGrid(dgvTransactions)
            cboType.Items.AddRange(New Object() {"Deposit", "Withdrawal"})
            cboType.SelectedIndex = 0

            Dim tips As New ToolTip()
            tips.SetToolTip(btnPost, "Post the transaction and update the balance")
            tips.SetToolTip(nudAmount, "Amount in shillings; must be greater than zero")

            LoadAccountCombo()
        End Sub

        ''' <summary>Fills the account combo box and loads the first account's data.</summary>
        Private Sub LoadAccountCombo()
            Dim accounts As List(Of Account) = _accountRepo.GetAll()
            ' Set the display/value members BEFORE the data source so the binding
            ' completes in one step and the selection event sees valid data.
            cboAccount.DisplayMember = "Display"
            cboAccount.ValueMember = "Key"
            cboAccount.DataSource = accounts.Select(
                Function(a) New ComboItem With {.Key = a.AccountID, .Display = a.AccountNumber & " - " & a.MemberName}).ToList()
            RefreshAccountData()
        End Sub

        ''' <summary>Refreshes the balance label and the transaction grid for the selected account.</summary>
        Private Sub RefreshAccountData()
            dgvTransactions.DataSource = Nothing
            lblBalance.Text = "-"
            If cboAccount.SelectedIndex < 0 OrElse Not TypeOf cboAccount.SelectedValue Is Integer Then
                Return
            End If
            Dim accountId As Integer = CInt(cboAccount.SelectedValue)
            Try
                Dim account As Account = _accountRepo.GetById(accountId)
                If account IsNot Nothing Then
                    lblBalance.Text = account.Balance.ToString("N2")
                End If
                dgvTransactions.DataSource = New SortableBindingList(Of SavingsTransaction)(_transRepo.GetByAccount(accountId))
                UiHelper.HideColumns(dgvTransactions, "TransID", "AccountID", "AccountNumber")
                If dgvTransactions.Columns("Amount") IsNot Nothing Then
                    dgvTransactions.Columns("Amount").DefaultCellStyle.Format = "N2"
                End If
            Catch ex As Exception
                UiHelper.[Error]("The account data could not be loaded: " & ex.Message)
            End Try
        End Sub

        Private Sub cboAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAccount.SelectedIndexChanged
            RefreshAccountData()
        End Sub

        ''' <summary>Validates and posts the deposit or withdrawal atomically.</summary>
        Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
            If cboAccount.SelectedIndex < 0 OrElse cboAccount.SelectedValue Is Nothing Then
                UiHelper.Warn("Select an account first. Open one in the Accounts module if none exists.")
                Return
            End If
            If cboType.SelectedItem Is Nothing Then
                UiHelper.Warn("Select the transaction type (Deposit or Withdrawal).")
                Return
            End If

            Dim accountId As Integer = CInt(cboAccount.SelectedValue)
            Dim transType As String = CStr(cboType.SelectedItem)
            Dim amount As Decimal = nudAmount.Value
            Dim note As String = txtNote.Text.Trim()

            Dim errors As List(Of String) = ValidationService.ValidateAmount(amount)
            If errors.Count = 0 AndAlso transType = "Withdrawal" Then
                Dim account As Account = _accountRepo.GetById(accountId)
                If account IsNot Nothing Then
                    errors = ValidationService.ValidateWithdrawal(amount, account.Balance, account.MinBalance)
                End If
            End If
            If errors.Count > 0 Then
                UiHelper.ShowErrors(errors)
                Return
            End If

            Try
                Dim newBalance As Decimal = _transRepo.PostTransaction(
                    accountId, transType, amount, AuthService.CurrentUser.UserID,
                    If(note = "", Nothing, note))
                UiHelper.Info("Transaction posted successfully. New balance: " & newBalance.ToString("N2"))
                nudAmount.Value = 0
                txtNote.Clear()
                RefreshAccountData()
            Catch ex As Exception
                UiHelper.[Error]("The transaction could not be posted: " & ex.Message)
            End Try
        End Sub

    End Class

End Namespace
