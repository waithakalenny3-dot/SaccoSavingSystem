' =====================================================================
' UI.frmUsers - user management (Administrator only).
' Adds users (passwords stored as salted SHA-256 hashes, never shown
' in the grid), resets passwords and deletes users. The form refuses
' to open for non-administrators and protects the last admin account.
' =====================================================================
Imports System.Windows.Forms
Imports SaccoManager.BLL.Models
Imports SaccoManager.BLL.Services
Imports SaccoManager.DAL

Namespace UI

    Public Class frmUsers

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        Private ReadOnly _users As New UserRepository()
        Private _selectedUserId As Integer = -1

        Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' Defence in depth: the menu already hides this form for tellers.
            If AuthService.CurrentUser Is Nothing OrElse Not AuthService.CurrentUser.IsAdmin Then
                UiHelper.Warn("Only administrators can manage users.")
                Me.Close()
                Return
            End If
            Me.Font = UiHelper.AppFont
            UiHelper.StyleGrid(dgvUsers)
            cboRole.Items.AddRange(New Object() {"Administrator", "Teller"})
            cboRole.SelectedIndex = 1

            Dim tips As New ToolTip()
            tips.SetToolTip(btnAdd, "Create the user account")
            tips.SetToolTip(btnReset, "Change the password of the selected user")
            tips.SetToolTip(btnDelete, "Delete the selected user")

            LoadUsers()
            ClearSelection()
        End Sub

        ''' <summary>Loads all users; password columns are hidden (security).</summary>
        Private Sub LoadUsers()
            dgvUsers.DataSource = New SortableBindingList(Of User)(_users.GetAll())
            UiHelper.HideColumns(dgvUsers, "UserID", "PasswordHash", "Salt", "IsAdmin")
        End Sub

        ''' <summary>Clears the selection state of the manage buttons.</summary>
        Private Sub ClearSelection()
            _selectedUserId = -1
            txtNewPassword.Clear()
            btnReset.Enabled = False
            btnDelete.Enabled = False
        End Sub

        ''' <summary>Tracks the user selected in the grid.</summary>
        Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
            If e.RowIndex < 0 Then
                Return
            End If
            Dim user As User = TryCast(dgvUsers.Rows(e.RowIndex).DataBoundItem, User)
            If user Is Nothing Then
                Return
            End If
            _selectedUserId = user.UserID
            txtNewPassword.Clear()
            btnReset.Enabled = True
            btnDelete.Enabled = True
        End Sub

        ''' <summary>Creates a new user after validation; the password is hashed.</summary>
        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            Dim username As String = txtUsername.Text.Trim()
            Dim fullName As String = txtFullName.Text.Trim()
            Dim role As String = If(CStr(cboRole.SelectedItem), "")
            Dim password As String = txtPassword.Text

            Dim errors As List(Of String) = ValidationService.ValidateUser(username, fullName, role, password)
            If errors.Count > 0 Then
                UiHelper.ShowErrors(errors)
                Return
            End If
            If _users.UsernameExists(username, 0) Then
                UiHelper.Warn("The username '" & username & "' is already taken. Please choose another one.")
                Return
            End If

            Try
                Dim record As Tuple(Of String, String) = AuthService.CreatePasswordRecord(password)
                _users.Add(New User With {
                    .Username = username, .PasswordHash = record.Item1, .Salt = record.Item2,
                    .FullName = fullName, .Role = role})
                UiHelper.Info("User '" & username & "' created. They can now log in.")
                LoadUsers()
                txtUsername.Clear()
                txtFullName.Clear()
                txtPassword.Clear()
                cboRole.SelectedIndex = 1
            Catch ex As Exception
                UiHelper.[Error]("The user could not be created: " & ex.Message)
            End Try
        End Sub

        ''' <summary>Changes the password of the selected user.</summary>
        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
            If _selectedUserId = -1 Then
                UiHelper.Warn("Select a user in the table first.")
                Return
            End If
            If txtNewPassword.Text.Length < 6 Then
                UiHelper.Warn("The new password must be at least 6 characters long.")
                Return
            End If
            Try
                Dim record As Tuple(Of String, String) = AuthService.CreatePasswordRecord(txtNewPassword.Text)
                _users.UpdatePassword(_selectedUserId, record.Item1, record.Item2)
                UiHelper.Info("Password changed successfully.")
                ClearSelection()
            Catch ex As Exception
                UiHelper.[Error]("The password could not be changed: " & ex.Message)
            End Try
        End Sub

        ''' <summary>Deletes the selected user, protecting own and last admin accounts.</summary>
        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            If _selectedUserId = -1 Then
                UiHelper.Warn("Select a user in the table first.")
                Return
            End If
            If _selectedUserId = AuthService.CurrentUser.UserID Then
                UiHelper.Warn("You cannot delete your own account while logged in.")
                Return
            End If
            Dim user As User = _users.GetAll().FirstOrDefault(Function(u) u.UserID = _selectedUserId)
            If user Is Nothing Then
                UiHelper.Warn("The selected user no longer exists.")
                LoadUsers()
                ClearSelection()
                Return
            End If
            If user.IsAdmin AndAlso _users.CountAdmins() <= 1 Then
                UiHelper.Warn("The last administrator account cannot be deleted.")
                Return
            End If
            If Not UiHelper.Confirm("Delete user '" & user.Username & "'?" & Environment.NewLine &
                                    "They will no longer be able to log in.") Then
                Return
            End If
            Try
                _users.Delete(_selectedUserId)
                UiHelper.Info("User deleted successfully.")
                LoadUsers()
                ClearSelection()
            Catch ex As Exception
                UiHelper.[Error]("The user could not be deleted: " & ex.Message)
            End Try
        End Sub

    End Class

End Namespace
