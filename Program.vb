' =====================================================================
' Application entry point.
' Prepares the database (schema + demo data on first run), then shows
' the login screen as a modal dialog; only a successful login starts
' the main dashboard. The optional --capture argument renders every
' main form to a PNG file for the project report screenshots.
' =====================================================================
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms

Module Program

    <STAThread>
    Sub Main(args As String())
        Application.SetHighDpiMode(HighDpiMode.SystemAware)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Try
            BLL.Services.DatabaseInitializer.EnsureDatabase()
        Catch ex As Exception
            MessageBox.Show("The database could not be prepared: " & ex.Message,
                            "Sacco Manager", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If args IsNot Nothing AndAlso Array.IndexOf(args, "--capture") >= 0 Then
            CaptureScreenshots()
            Return
        End If

        Using login As New UI.frmLogin()
            If login.ShowDialog() <> DialogResult.OK Then
                Return
            End If
        End Using
        Application.Run(New UI.frmMain())
    End Sub

    ''' <summary>Renders each main form to docs\screenshots\*.png for the report.</summary>
    Private Sub CaptureScreenshots()
        ' Give role-based forms an administrator session while capturing.
        BLL.Services.AuthService.CurrentUser = New BLL.Models.User With {
            .UserID = 0, .Username = "admin", .FullName = "System Administrator", .Role = "Administrator"}

        Dim outDir As String = IO.Path.Combine(GetSolutionRoot(), "docs", "screenshots")
        IO.Directory.CreateDirectory(outDir)

        For Each form As Form In UI.UiHelper.CreateAllForms()
            form.StartPosition = FormStartPosition.Manual
            form.Show()
            Application.DoEvents()
            Using bmp As New Bitmap(form.Width, form.Height)
                form.DrawToBitmap(bmp, New Rectangle(0, 0, form.Width, form.Height))
                bmp.Save(IO.Path.Combine(outDir, form.Name & ".png"), ImageFormat.Png)
            End Using
            form.Close()
            form.Dispose()
        Next
    End Sub

    ''' <summary>Walks up from the executable to find the solution folder.</summary>
    Private Function GetSolutionRoot() As String
        Dim dir As New IO.DirectoryInfo(AppContext.BaseDirectory)
        While dir IsNot Nothing
            If IO.File.Exists(IO.Path.Combine(dir.FullName, "SaccoManager.sln")) Then
                Return dir.FullName
            End If
            dir = dir.Parent
        End While
        Return AppContext.BaseDirectory
    End Function

End Module
