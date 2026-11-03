' =====================================================================
' UI.frmMembers - member records management (CRUD + search).
' Lists members in a read-only grid, searches by number or name and
' adds/edits/deletes members through a details group. Deletion is
' administrator-only and always confirmed first.
' =====================================================================
Imports System.Windows.Forms
Imports SaccoManager.BLL.Models
Imports SaccoManager.BLL.Services
Imports SaccoManager.DAL

Namespace UI

    Public Class frmMembers

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        Private ReadOnly _members As New MemberRepository()
        Private _selectedId As Integer = -1

        Private Sub frmMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Font = UiHelper.AppFont
            UiHelper.StyleGrid(dgvMembers)
            btnDelete.Enabled = AuthService.CurrentUser IsNot Nothing AndAlso AuthService.CurrentUser.IsAdmin

            Dim tips As New ToolTip()
            tips.SetToolTip(btnSearch, "Search members by number or name")
            tips.SetToolTip(btnShowAll, "Clear the search and show all members")
            tips.SetToolTip(btnSave, "Save a new member or update the selected one")
            tips.SetToolTip(btnDelete, "Delete the selected member (Administrator only)")

            LoadMembers(Nothing)
            ClearFields()
        End Sub

        ''' <summary>Loads members into the grid, optionally filtered by a search term.</summary>
        Private Sub LoadMembers(term As String)
            Dim list As List(Of Member) =
                If(String.IsNullOrWhiteSpace(term), _members.GetAll(), _members.Search(term.Trim()))
            dgvMembers.DataSource = New SortableBindingList(Of Member)(list)
            UiHelper.HideColumns(dgvMembers, "MemberID")
        End Sub

        ''' <summary>Clears the details panel back to add mode.</summary>
        Private Sub ClearFields()
            _selectedId = -1
            txtMemberNo.Clear()
            txtFullName.Clear()
            txtPhone.Clear()
            txtEmail.Clear()
            dtpJoin.Value = Date.Now
            cboStatus.SelectedItem = "Active"
            btnSave.Text = "Save new member"
        End Sub

        ''' <summary>Fills the details panel from the clicked grid row (edit mode).</summary>
        Private Sub dgvMembers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMembers.CellClick
            If e.RowIndex < 0 Then
                Return
            End If
            Dim member As Member = TryCast(dgvMembers.Rows(e.RowIndex).DataBoundItem, Member)
            If member Is Nothing Then
                Return
            End If
            _selectedId = member.MemberID
            txtMemberNo.Text = member.MemberNo
            txtFullName.Text = member.FullName
            txtPhone.Text = member.Phone
            txtEmail.Text = If(member.Email, "")
            dtpJoin.Value = member.JoinDate
            cboStatus.SelectedItem = member.Status
            btnSave.Text = "Update member"
        End Sub

        ''' <summary>Searches by the term typed in the search box.</summary>
        Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            If String.IsNullOrWhiteSpace(txtSearch.Text) Then
                UiHelper.Warn("Type a member number or name to search for first.")
                Return
            End If
            LoadMembers(txtSearch.Text)
        End Sub

        Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
            txtSearch.Clear()
            LoadMembers(Nothing)
        End Sub

        Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
            ClearFields()
            txtMemberNo.Focus()
        End Sub

        ''' <summary>Saves a new member or updates the selected member after validation.</summary>
        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            Dim memberNo As String = txtMemberNo.Text.Trim()
            Dim fullName As String = txtFullName.Text.Trim()
            Dim phone As String = txtPhone.Text.Trim()
            Dim email As String = txtEmail.Text.Trim()
            Dim status As String = If(CStr(cboStatus.SelectedItem), "Active")

            Dim errors As List(Of String) = ValidationService.ValidateMember(memberNo, fullName, phone, email)
            If errors.Count > 0 Then
                UiHelper.ShowErrors(errors)
                Return
            End If
            If _members.MemberNoExists(memberNo, _selectedId) Then
                UiHelper.Warn("The member number '" & memberNo & "' is already used by another member. Please enter a unique number.")
                Return
            End If

            Dim member As New Member With {
                .MemberID = _selectedId, .MemberNo = memberNo, .FullName = fullName, .Phone = phone,
                .Email = If(email = "", Nothing, email), .JoinDate = dtpJoin.Value.Date, .Status = status}

            Try
                If _selectedId = -1 Then
                    _members.Add(member)
                    UiHelper.Info("Member '" & fullName & "' saved successfully.")
                Else
                    _members.Update(member)
                    UiHelper.Info("Member '" & fullName & "' updated successfully.")
                End If
                LoadMembers(txtSearch.Text)
                ClearFields()
            Catch ex As Exception
                UiHelper.[Error]("The member could not be saved: " & ex.Message)
            End Try
        End Sub

        ''' <summary>Deletes the selected member after a confirmation warning.</summary>
        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            If _selectedId = -1 Then
                UiHelper.Warn("Select a member in the table first, then click Delete.")
                Return
            End If
            Dim member As Member = _members.GetById(_selectedId)
            If member Is Nothing Then
                UiHelper.Warn("The selected member no longer exists.")
                LoadMembers(txtSearch.Text)
                ClearFields()
                Return
            End If
            If Not UiHelper.Confirm("Delete member '" & member.FullName & "' and ALL their accounts, " &
                                    "transactions and loans?" & Environment.NewLine & "This cannot be undone.") Then
                Return
            End If
            Try
                _members.Delete(_selectedId)
                UiHelper.Info("Member deleted successfully.")
                LoadMembers(txtSearch.Text)
                ClearFields()
            Catch ex As Exception
                UiHelper.[Error]("The member could not be deleted: " & ex.Message)
            End Try
        End Sub

    End Class

End Namespace
