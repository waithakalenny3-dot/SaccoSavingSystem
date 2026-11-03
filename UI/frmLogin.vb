' =====================================================================
' UI.frmLogin - login screen. Verifies credentials against the Users
' table (salted SHA-256 hashes) and opens the main dashboard on
' success. Acts as a modal dialog whose DialogResult drives startup.
' =====================================================================
Imports System.Windows.Forms
Imports SaccoManager.BLL.Services

Namespace UI

    Public Class frmLogin

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        Private ReadOnly _auth As New AuthService()

        Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Font = UiHelper.AppFont
            txtUsername.Focus()
        End Sub

        ''' <summary>Checks the entered credentials and opens the main window on success.</summary>
        Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
            lblError.Visible = False
            If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
                lblError.Text = "Please enter both your username and password."
                lblError.Visible = True
                If String.IsNullOrWhiteSpace(txtUsername.Text) Then
                    txtUsername.Focus()
                Else
                    txtPassword.Focus()
                End If
                Return
            End If

            Dim user As BLL.Models.User = _auth.Login(txtUsername.Text.Trim(), txtPassword.Text)
            If user Is Nothing Then
                ' Security: the message does not reveal whether the username or password was wrong.
                lblError.Text = "Invalid username or password. Please try again."
                lblError.Visible = True
                txtPassword.Clear()
                txtUsername.Focus()
                Return
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub

    End Class

End Namespace
