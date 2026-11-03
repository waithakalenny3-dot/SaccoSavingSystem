' =====================================================================
' UI.frmReports - report generation, printing and CSV export.
' Two reports: Member Statement (one member's transactions over a date
' range) and Daily Transactions Summary (totals per type for one day).
' Results can be exported to CSV or previewed for printing.
' =====================================================================
Imports System.Drawing
Imports System.Windows.Forms
Imports SaccoManager.BLL.Models
Imports SaccoManager.BLL.Services
Imports SaccoManager.DAL

Namespace UI

    Public Class frmReports

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        Private ReadOnly _memberRepo As New MemberRepository()
        Private ReadOnly _transRepo As New TransactionRepository()
        Private _printLines As List(Of String)
        Private _lineIndex As Integer

        Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Font = UiHelper.AppFont
            UiHelper.StyleGrid(dgvReport)

            cboReport.Items.AddRange(New Object() {"Member Statement", "Daily Transactions Summary"})
            cboReport.SelectedIndex = 0

            cboMember.DisplayMember = "Display"
            cboMember.ValueMember = "Key"
            cboMember.DataSource = _memberRepo.GetAll().Select(
                Function(m) New ComboItem With {.Key = m.MemberID, .Display = m.MemberNo & " - " & m.FullName}).ToList()

            Dim tips As New ToolTip()
            tips.SetToolTip(btnGenerate, "Generate the selected report")
            tips.SetToolTip(btnExport, "Export the report to a CSV file")
            tips.SetToolTip(btnPrint, "Preview the report for printing")

            AddHandler cboReport.SelectedIndexChanged, AddressOf ReportTypeChanged
            ToggleVisibility()
        End Sub

        ''' <summary>Shows only the settings relevant to the selected report type.</summary>
        Private Sub ReportTypeChanged(sender As Object, e As EventArgs)
            ToggleVisibility()
        End Sub

        Private Sub ToggleVisibility()
            Dim statement As Boolean = CStr(cboReport.SelectedItem) = "Member Statement"
            lblMember.Visible = statement
            cboMember.Visible = statement
            lblFrom.Visible = statement
            dtpFrom.Visible = statement
            lblTo.Visible = statement
            dtpTo.Visible = statement
            lblDay.Visible = Not statement
            dtpDay.Visible = Not statement
        End Sub

        ''' <summary>Generates the selected report into the grid.</summary>
        Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
            Try
                If CStr(cboReport.SelectedItem) = "Member Statement" Then
                    If cboMember.SelectedIndex < 0 OrElse cboMember.SelectedValue Is Nothing Then
                        UiHelper.Warn("Select the member whose statement you want first.")
                        Return
                    End If
                    Dim memberId As Integer = CInt(cboMember.SelectedValue)
                    Dim rows As List(Of SavingsTransaction) =
                        _transRepo.GetByMemberAndDateRange(memberId, dtpFrom.Value.Date, dtpTo.Value.Date)
                    dgvReport.DataSource = New SortableBindingList(Of SavingsTransaction)(rows)
                    UiHelper.HideColumns(dgvReport, "TransID", "AccountID")
                    If dgvReport.Columns("Amount") IsNot Nothing Then
                        dgvReport.Columns("Amount").DefaultCellStyle.Format = "N2"
                    End If
                    Dim deposits As Decimal = rows.Where(Function(t) t.TransType = "Deposit").Sum(Function(t) t.Amount)
                    Dim withdrawals As Decimal = rows.Where(Function(t) t.TransType = "Withdrawal").Sum(Function(t) t.Amount)
                    lblSummaryText.Text = $"{rows.Count} transaction(s) from {dtpFrom.Value.Date:d} to {dtpTo.Value.Date:d}. " &
                                          $"Deposits: {deposits:N2}. Withdrawals: {withdrawals:N2}."
                Else
                    Dim day As Date = dtpDay.Value.Date
                    Dim rows As List(Of SummaryRow) = _transRepo.DailySummary(day)
                    dgvReport.DataSource = New SortableBindingList(Of SummaryRow)(rows)
                    If dgvReport.Columns("Total") IsNot Nothing Then
                        dgvReport.Columns("Total").DefaultCellStyle.Format = "N2"
                    End If
                    Dim total As Decimal = rows.Sum(Function(r) r.Total)
                    lblSummaryText.Text = $"{day:d}: total {total:N2} across {rows.Count} transaction type(s)."
                End If
            Catch ex As Exception
                UiHelper.[Error]("The report could not be generated: " & ex.Message)
            End Try
        End Sub

        ''' <summary>Exports the visible grid content to a CSV file.</summary>
        Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            If dgvReport.Rows.Count = 0 Then
                UiHelper.Warn("Generate a report first, then export it.")
                Return
            End If
            Using dlg As New SaveFileDialog()
                dlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
                Dim stamp As String = Date.Now.ToString("yyyyMMdd")
                dlg.FileName = If(CStr(cboReport.SelectedItem) = "Member Statement",
                                  $"member_statement_{stamp}.csv", $"daily_summary_{stamp}.csv")
                If dlg.ShowDialog(Me) <> DialogResult.OK Then
                    Return
                End If
                Try
                    Using writer As New IO.StreamWriter(dlg.FileName, False, System.Text.Encoding.UTF8)
                        writer.WriteLine(CsvLine(VisibleColumns().Select(Function(c) c.HeaderText)))
                        For Each row As DataGridViewRow In dgvReport.Rows
                            writer.WriteLine(CsvLine(VisibleColumns().Select(
                                Function(c) If(row.Cells(c.Index).Value Is Nothing, "", row.Cells(c.Index).Value.ToString()))))
                        Next
                    End Using
                    UiHelper.Info("Report exported successfully to:" & Environment.NewLine & dlg.FileName)
                Catch ex As Exception
                    UiHelper.[Error]("The report could not be exported: " & ex.Message)
                End Try
            End Using
        End Sub

        ''' <summary>Visible grid columns in display order.</summary>
        Private Function VisibleColumns() As IEnumerable(Of DataGridViewColumn)
            Return dgvReport.Columns.Cast(Of DataGridViewColumn)().Where(Function(c) c.Visible)
        End Function

        ''' <summary>Joins values into one CSV line, quoting and escaping where needed.</summary>
        Private Shared Function CsvLine(values As IEnumerable(Of String)) As String
            Return String.Join(",", values.Select(
                Function(v As String)
                    If v.Contains(","c) OrElse v.Contains(""""c) OrElse v.Contains(Environment.NewLine) Then
                        Return """" & v.Replace("""", """""") & """"
                    End If
                    Return v
                End Function))
        End Function

        ''' <summary>Prepares the report as text lines and shows the print preview.</summary>
        Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
            If dgvReport.Rows.Count = 0 Then
                UiHelper.Warn("Generate a report first, then print it.")
                Return
            End If
            BuildPrintLines()
            _lineIndex = 0
            Using doc As New Printing.PrintDocument()
                AddHandler doc.PrintPage, AddressOf PrintPageHandler
                doc.DocumentName = CStr(cboReport.SelectedItem)
                Using dlg As New PrintPreviewDialog()
                    dlg.Document = doc
                    dlg.WindowState = FormWindowState.Maximized
                    dlg.ShowDialog(Me)
                End Using
            End Using
        End Sub

        ''' <summary>Builds the fixed-width text lines that make up the printed report.</summary>
        Private Sub BuildPrintLines()
            _printLines = New List(Of String)()
            _printLines.Add("SACCO MANAGER - " & CStr(cboReport.SelectedItem).ToUpper())
            If CStr(cboReport.SelectedItem) = "Member Statement" Then
                _printLines.Add("Member: " & CStr(cboMember.Text) & "    Period: " & dtpFrom.Value.Date.ToString("dd MMM yyyy") & " to " & dtpTo.Value.Date.ToString("dd MMM yyyy"))
            Else
                _printLines.Add("Day: " & dtpDay.Value.Date.ToString("dd MMM yyyy"))
            End If
            _printLines.Add("Generated: " & Date.Now.ToString("dd MMM yyyy HH:mm"))
            _printLines.Add(New String("-"c, 80))
            Dim widths() As Integer = {20, 18, 15, 15}
            Dim i As Integer = 0
            Dim header As New System.Text.StringBuilder()
            For Each column As DataGridViewColumn In VisibleColumns()
                header.Append(column.HeaderText.PadRight(widths(Math.Min(i, widths.Length - 1))))
                i += 1
            Next
            _printLines.Add(header.ToString())
            For Each row As DataGridViewRow In dgvReport.Rows
                Dim line As New System.Text.StringBuilder()
                Dim j As Integer = 0
                For Each column As DataGridViewColumn In VisibleColumns()
                    Dim cell As String = If(row.Cells(column.Index).Value Is Nothing, "", row.Cells(column.Index).Value.ToString())
                    ' Money-like columns are right-aligned so figures line up.
                    If column.ValueType IsNot Nothing AndAlso column.ValueType Is GetType(Decimal) Then
                        line.Append(cell.PadLeft(widths(Math.Min(j, widths.Length - 1))))
                    Else
                        line.Append(cell.PadRight(widths(Math.Min(j, widths.Length - 1))))
                    End If
                    j += 1
                Next
                _printLines.Add(line.ToString())
            Next
        End Sub

        ''' <summary>Prints the prepared lines, flowing onto further pages when needed.</summary>
        Private Sub PrintPageHandler(sender As Object, e As Printing.PrintPageEventArgs)
            Dim y As Single = e.MarginBounds.Top
            Using font As New Font("Consolas", 8.5F)
                While _lineIndex < _printLines.Count
                    e.Graphics.DrawString(_printLines(_lineIndex), font, Brushes.Black, e.MarginBounds.Left, y)
                    y += font.GetHeight(e.Graphics)
                    If y > e.MarginBounds.Bottom Then
                        e.HasMorePages = True
                        Return
                    End If
                    _lineIndex += 1
                End While
            End Using
            e.HasMorePages = False
            _lineIndex = 0
        End Sub

    End Class

End Namespace
