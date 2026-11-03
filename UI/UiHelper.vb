' =====================================================================
' UI.UiHelper - shared user interface utilities.
' Centralises fonts, grid styling, standard message boxes and the form
' factory used by the screenshot capture mode, so every form looks and
' behaves consistently (UX consistency requirement).
' Also provides SortableBindingList, which makes object lists sortable
' by clicking DataGridView column headers.
' =====================================================================
Imports System.ComponentModel
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms

Namespace UI

    Public Module UiHelper

        ''' <summary>The application font used by every form and control.</summary>
        Public ReadOnly AppFont As New Font("Segoe UI", 9.75F)

        ''' <summary>Applies the standard read-only grid style (consistent data display).</summary>
        Public Sub StyleGrid(grid As DataGridView)
            grid.ReadOnly = True
            grid.AllowUserToAddRows = False
            grid.AllowUserToDeleteRows = False
            grid.AllowUserToOrderColumns = False
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            grid.MultiSelect = False
            grid.RowHeadersVisible = False
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            grid.BackgroundColor = Color.White
            grid.BorderStyle = BorderStyle.None
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 245)
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 78, 121)
            grid.DefaultCellStyle.SelectionForeColor = Color.White
        End Sub

        ''' <summary>Hides the given columns of a grid (for example internal id columns).</summary>
        Public Sub HideColumns(grid As DataGridView, ParamArray columnNames As String())
            For Each name As String In columnNames
                Dim column As DataGridViewColumn = grid.Columns(name)
                If column IsNot Nothing Then
                    column.Visible = False
                End If
            Next
        End Sub

        ''' <summary>Shows an information message with the standard title.</summary>
        Public Sub Info(message As String)
            MessageBox.Show(message, "Sacco Manager", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        ''' <summary>Shows a warning message with the standard title.</summary>
        Public Sub Warn(message As String)
            MessageBox.Show(message, "Sacco Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub

        ''' <summary>Shows an error message with the standard title.</summary>
        Public Sub [Error](message As String)
            MessageBox.Show(message, "Sacco Manager", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub

        ''' <summary>Asks a yes/no confirmation question; True only when the user answers Yes.</summary>
        Public Function Confirm(message As String) As Boolean
            Return MessageBox.Show(message, "Please confirm", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes
        End Function

        ''' <summary>Shows all validation errors in one message box.</summary>
        Public Sub ShowErrors(errors As List(Of String))
            Warn("Please correct the following:" & Environment.NewLine & Environment.NewLine &
                 String.Join(Environment.NewLine, errors))
        End Sub

        ''' <summary>Creates one instance of every main form (screenshot capture mode).</summary>
        Public Function CreateAllForms() As List(Of Form)
            Return New List(Of Form) From {
                New frmLogin(), New frmMain(), New frmMembers(), New frmAccounts(),
                New frmSavings(), New frmLoans(), New frmReports(),
                New frmUsers(), New frmBackup()
            }
        End Function

    End Module

    ''' <summary>A simple name/value pair used to bind ComboBox selections.</summary>
    Public Class ComboItem

        Public Property Key As Integer
        Public Property Display As String

        Public Overrides Function ToString() As String
            Return Display
        End Function

    End Class

    ''' <summary>
    ''' A BindingList that supports sorting by clicking DataGridView column
    ''' headers, which the plain BindingList does not do for object lists.
    ''' </summary>
    Public Class SortableBindingList(Of T)
        Inherits BindingList(Of T)

        Private _isSorted As Boolean
        Private _sortProperty As PropertyDescriptor
        Private _sortDirection As ListSortDirection

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(list As IList(Of T))
            MyBase.New(list)
        End Sub

        Protected Overrides ReadOnly Property SupportsSortingCore As Boolean
            Get
                Return True
            End Get
        End Property

        Protected Overrides ReadOnly Property IsSortedCore As Boolean
            Get
                Return _isSorted
            End Get
        End Property

        Protected Overrides ReadOnly Property SortPropertyCore As PropertyDescriptor
            Get
                Return _sortProperty
            End Get
        End Property

        Protected Overrides ReadOnly Property SortDirectionCore As ListSortDirection
            Get
                Return _sortDirection
            End Get
        End Property

        ''' <summary>Sorts the underlying list by the clicked property and direction.</summary>
        Protected Overrides Sub ApplySortCore(prop As PropertyDescriptor, direction As ListSortDirection)
            _sortProperty = prop
            _sortDirection = direction
            Dim sortedList As List(Of T) = TryCast(Items, List(Of T))
            If sortedList IsNot Nothing Then
                sortedList.Sort(New PropertyComparer(prop, direction))
                _isSorted = True
                OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
            End If
        End Sub

        Protected Overrides Sub RemoveSortCore()
            _isSorted = False
            OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
        End Sub

        ''' <summary>Compares two items by one property, using IComparable when possible.</summary>
        Private Class PropertyComparer
            Implements IComparer(Of T)

            Private ReadOnly _prop As PropertyDescriptor
            Private ReadOnly _dir As ListSortDirection

            Public Sub New(prop As PropertyDescriptor, dir As ListSortDirection)
                _prop = prop
                _dir = dir
            End Sub

            Public Function Compare(x As T, y As T) As Integer Implements IComparer(Of T).Compare
                Dim vx As Object = _prop.GetValue(x)
                Dim vy As Object = _prop.GetValue(y)
                Dim result As Integer
                If vx Is Nothing AndAlso vy Is Nothing Then
                    result = 0
                ElseIf vx Is Nothing Then
                    result = -1
                ElseIf vy Is Nothing Then
                    result = 1
                Else
                    Dim comparable As IComparable = TryCast(vx, IComparable)
                    If comparable IsNot Nothing Then
                        result = comparable.CompareTo(vy)
                    Else
                        result = String.Compare(vx.ToString(), vy.ToString(), StringComparison.CurrentCulture)
                    End If
                End If
                If _dir = ListSortDirection.Descending Then
                    result = -result
                End If
                Return result
            End Function

        End Class

    End Class

End Namespace
