' =====================================================================
' UI.frmAccounts - account management (CRUD).
' Lists accounts (with member, type and balance) in a read-only grid,
' opens new accounts with an automatically generated unique number and
' deletes accounts (administrator-only, with confirmation).
' =====================================================================
Imports System.Windows.Forms
Imports SaccoManager.BLL.Models
Imports SaccoManager.BLL.Services
Imports SaccoManager.DAL

Namespace UI

    Public Class frmAccounts

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        Private ReadOnly _accounts As New AccountRepository()
        Private ReadOnly _members As New MemberRepository()

        Private Sub frmAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Font = UiHelper.AppFont
            UiHelper.StyleGrid(dgvAccounts)
            btnDeleteAccount.Enabled = AuthService.CurrentUser IsNot Nothing AndAlso AuthService.CurrentUser.IsAdmin

            Dim tips As New ToolTip()
            tips.SetToolTip(btnOpen, "Open a new account for the selected member")
            tips.SetToolTip(btnDeleteAccount, "Delete the selected account (Administrator only)")

            LoadMemberCombo()
            LoadTypeCombo()
            LoadAccounts()
        End Sub

        ''' <summary>Fills the member combo box (displayed as number - name).</summary>
        Private Sub LoadMemberCombo()
            cboMember.DisplayMember = "Display"
            cboMember.ValueMember = "Key"
            cboMember.DataSource = _members.GetAll().Select(
                Function(m) New ComboItem With {.Key = m.MemberID, .Display = m.MemberNo & " - " & m.FullName}).ToList()
        End Sub

        ''' <summary>Fills the account type combo box.</summary>
        Private Sub LoadTypeCombo()
            cboType.DisplayMember = "TypeName"
            cboType.ValueMember = "TypeID"
            cboType.DataSource = _accounts.GetAccountTypes()
        End Sub

        ''' <summary>Loads all accounts into the grid.</summary>
        Private Sub LoadAccounts()
            dgvAccounts.DataSource = New SortableBindingList(Of Account)(_accounts.GetAll())
            UiHelper.HideColumns(dgvAccounts, "AccountID", "MemberID", "TypeID", "MinBalance")
            If dgvAccounts.Columns("Balance") IsNot Nothing Then
                dgvAccounts.Columns("Balance").DefaultCellStyle.Format = "N2"
            End If
        End Sub

        ''' <summary>Opens a new account after validating the selections.</summary>
        Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
            If cboMember.SelectedIndex < 0 OrElse cboMember.SelectedValue Is Nothing Then
                UiHelper.Warn("Select the member the account belongs to first.")
                Return
            End If
            If cboType.SelectedIndex < 0 OrElse cboType.SelectedValue Is Nothing Then
                UiHelper.Warn("Select the account type first.")
                Return
            End If
            Try
                Dim account As Account = _accounts.Add(CInt(cboMember.SelectedValue), CInt(cboType.SelectedValue))
                UiHelper.Info("Account " & account.AccountNumber & " opened for " & account.MemberName & ".")
                LoadAccounts()
            Catch ex As Exception
                UiHelper.[Error]("The account could not be opened: " & ex.Message)
            End Try
        End Sub

        ''' <summary>Deletes the selected account after a confirmation warning.</summary>
        Private Sub btnDeleteAccount_Click(sender As Object, e As EventArgs) Handles btnDeleteAccount.Click
            If dgvAccounts.CurrentRow Is Nothing Then
                UiHelper.Warn("Select an account in the table first, then click Delete.")
                Return
            End If
            Dim account As Account = TryCast(dgvAccounts.CurrentRow.DataBoundItem, Account)
            If account Is Nothing Then
                Return
            End If
            If Not UiHelper.Confirm("Delete account " & account.AccountNumber & " (" & account.MemberName & ")?" &
                                    Environment.NewLine & "All its transactions will also be removed. This cannot be undone.") Then
                Return
            End If
            Try
                _accounts.Delete(account.AccountID)
                UiHelper.Info("Account deleted successfully.")
                LoadAccounts()
            Catch ex As Exception
                UiHelper.[Error]("The account could not be deleted: " & ex.Message)
            End Try
        End Sub

    End Class

End Namespace
