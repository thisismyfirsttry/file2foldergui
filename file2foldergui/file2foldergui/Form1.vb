Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Diagnostics

Public Class Form1
    Dim moveItems As New BindingList(Of MoveItem)
    Dim isUndo As Boolean = False
    Dim countDown As Integer
    Dim timeLeft As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NotifyIcon1.Icon = Me.Icon
        NotifyIcon1.ContextMenu = contextmenuSysTray
        Me.MaximizeBox = False
        Me.Text = " file2folder GUI v" & Application.ProductVersion.ToString
        btnStart.Enabled = True
        btnStop.Enabled = False
        menuitemStartMon.Enabled = True
        menuitemStopMon.Enabled = False
        menuitemIgnoreMP.Checked = False
        Me.AllowDrop = True
        txtBoxDir.AllowDrop = True
        Try 'check for previous update "old" file.  delete if exists.
            If File.Exists(Application.StartupPath & "\file2foldergui.old") = True Then
                File.Delete(Application.StartupPath & "\file2foldergui.old")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Dim url As New System.Uri("http://update.thehtpc.net/file2foldergui/UpdateVersion.txt") 'update check on application launch.  ignore errors.'
        Dim req As WebRequest
        req = WebRequest.Create(url)
        Dim resp As WebResponse
        resp = req.GetResponse()
        resp.Close()
        req = Nothing
        webBrwsStartup.Navigate(url)
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click 'file browser initiate'
        FolderBrowserDialog1.ShowDialog()
        txtBoxDir.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        If String.IsNullOrEmpty(txtBoxDir.Text.Trim) = False AndAlso IO.Directory.Exists(txtBoxDir.Text) Then 'don't allow invalid or null directory entries'
            btnUndo.Enabled = False
            btnMove.Enabled = False
            isUndo = False
            ProgressBar1.Value = 0
            bgwMover.RunWorkerAsync()
        Else
            txtBoxDir.Text = "Choose a valid directory!"
        End If
    End Sub

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click ' background worker process for undo'
        btnUndo.Enabled = False
        btnMove.Enabled = False
        isUndo = True
        ProgressBar1.Value = 0
        bgwMover.RunWorkerAsync()
    End Sub

    Private Sub bgwRun()
        bgwMover.RunWorkerAsync()
    End Sub

    Private Delegate Sub myDelegate()

    Private Sub bgwMover_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwMover.DoWork
        'background worker process for move
        If isUndo = False AndAlso menuitemIgnoreMP.Checked = True Then 'Ignore multipart files
            Dim files() As String = IO.Directory.GetFiles(txtBoxDir.Text.Trim)
            If files.Length > 0 Then moveItems.Clear()
            Dim i As Integer = 1
            For Each filePath As String In files
                Dim fi As New FileInfo(filePath)
                Dim m As Match = Regex.Match(IO.Path.GetFileName(filePath), "(.*?)([ _.-]*(?:cd|dvd|p(?:ar)?t|dis[ck]|d)[ _.-]*[0-9]+)(.*?)(\.[^.]+)$") 'regex for multipart filename detection
                If (fi.Attributes And IO.FileAttributes.Hidden) = IO.FileAttributes.Hidden Or (fi.Attributes And IO.FileAttributes.System) _
                = IO.FileAttributes.System Or m.Success = True Then Continue For 'Check for hidden or system attribute, multipart filename regex match and exclude for each
                Try
                    Dim newFolderPath As String = IO.Path.Combine(txtBoxDir.Text.Trim, IO.Path.GetFileNameWithoutExtension(filePath))
                    If Not IO.Directory.Exists(newFolderPath) Then
                        IO.Directory.CreateDirectory(newFolderPath) 'create new directory based on filename minus extension if it does not exist
                    End If

                    Dim mi As New MoveItem
                    mi.OldPath = filePath
                    mi.NewPath = IO.Path.Combine(newFolderPath, IO.Path.GetFileName(filePath))
                    moveItems.Add(mi) 'move files by name into folders by name

                    bgwMover.ReportProgress((i / files.Length) * 100, "Moving """ & IO.Path.GetFileName(mi.OldPath) & """ to """ & mi.NewPath & """...")
                    IO.File.Move(mi.OldPath, mi.NewPath)
                    bgwMover.ReportProgress(0, "Done." & vbCrLf)
                    i += 1
                Catch ex As Exception
                    bgwMover.ReportProgress(0, "Error: " & ex.Message & vbCrLf)
                End Try
            Next

        ElseIf isUndo = False AndAlso menuitemIgnoreMP.Checked = False Then 'move all files
            Dim files() As String = IO.Directory.GetFiles(txtBoxDir.Text.Trim)
            If files.Length > 0 Then moveItems.Clear()
            Dim i As Integer = 1
            For Each filePath As String In files
                Dim fi As New FileInfo(filePath)
                If (fi.Attributes And IO.FileAttributes.Hidden) = IO.FileAttributes.Hidden Or (fi.Attributes And IO.FileAttributes.System) _
                = IO.FileAttributes.System Then Continue For 'Check for hidden or system attribute and exclude for each
                Try
                    Dim newFolderPath As String = IO.Path.Combine(txtBoxDir.Text.Trim, IO.Path.GetFileNameWithoutExtension(filePath))
                    If Not IO.Directory.Exists(newFolderPath) Then
                        IO.Directory.CreateDirectory(newFolderPath) 'create new directory based on filename minus extension if it does not exist
                    End If

                    Dim mi As New MoveItem
                    mi.OldPath = filePath
                    mi.NewPath = IO.Path.Combine(newFolderPath, IO.Path.GetFileName(filePath))
                    moveItems.Add(mi) 'move files by name into folders by name

                    bgwMover.ReportProgress((i / files.Length) * 100, "Moving """ & IO.Path.GetFileName(mi.OldPath) & """ to """ & mi.NewPath & """...")
                    IO.File.Move(mi.OldPath, mi.NewPath)
                    bgwMover.ReportProgress(0, "Done." & vbCrLf)
                    i += 1
                Catch ex As Exception
                    bgwMover.ReportProgress(0, "Error: " & ex.Message & vbCrLf)
                End Try
            Next

        Else
            Dim i As Integer = 1
            For Each mi As MoveItem In moveItems
                Try
                    'progress bar stuff
                    bgwMover.ReportProgress((i / moveItems.Count) * 100, "Undoing """ & IO.Path.GetFileName(mi.NewPath) & """ to """ & mi.OldPath & """...")
                    IO.File.Move(mi.NewPath, mi.OldPath)
                    IO.Directory.Delete(My.Computer.FileSystem.GetParentPath(mi.NewPath))
                    bgwMover.ReportProgress(0, "Done." & vbCrLf)
                    i += 1
                Catch ex As Exception
                    bgwMover.ReportProgress(0, "Error: " & ex.Message & vbCrLf)
                End Try
            Next
        End If

    End Sub

    Private Sub bgwMover_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwMover.ProgressChanged
        If e.ProgressPercentage <> 0 Then 'update progress bar
            ProgressBar1.Value = e.ProgressPercentage
        End If
        If Not e.UserState Is Nothing Then
            txtLog.Text &= e.UserState
        End If
    End Sub

    Private Sub bgwMover_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwMover.RunWorkerCompleted
        If menuitemShowDir.Checked = True AndAlso menuitemAutoClose.Checked = True Then 'things to do when the mover completes
            Process.Start("explorer.exe", txtBoxDir.Text)
            Me.Close()
        ElseIf menuitemShowDir.Checked = True And menuitemAutoClose.Checked = False Then
            Process.Start("explorer.exe", txtBoxDir.Text)
        ElseIf menuitemAutoClose.Checked = True Then
            Me.Close()
        End If
        ProgressBar1.Value = 100
        If btnStart.Enabled = True Then
            btnMove.Enabled = True
            btnUndo.Enabled = True
        Else
            btnMove.Enabled = False
            btnUndo.Enabled = False
        End If
    End Sub

    Private Sub SaveLogToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveLogToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog() 'saves currently shown textbox contents to log file
        Try
            System.IO.File.WriteAllText(SaveFileDialog1.FileName, txtLog.Text)
        Catch ex As Exception
            System.IO.File.WriteAllText(0, "Error: " & ex.Message & vbCrLf)
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        AboutBox1.ShowDialog() 'about box = whoopie'
    End Sub

    Private Sub Form1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Try 'enable drag and drop of directories to get full path name for processing on the form
            If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
                Dim draggedFolder As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
                e.Effect = DragDropEffects.Copy
                For Each foldername In draggedFolder
                    txtBoxDir.Text = Path.GetFullPath(foldername)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then 'detect data dragged into form
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Public Sub webBrwsStartup_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles webBrwsStartup.DocumentCompleted
        Try
            Dim m As Match = Regex.Match(webBrwsStartup.DocumentText, "<PRE>(?<version>(.*?))</PRE>") 'popup dialog if update is available'
            If m.Success = True Then
                If Application.ProductVersion <> m.Groups("version").Value Then
                    Form2.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtBoxDir_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtBoxDir.DragDrop
        Try 'enable drag and drop of directories to get full path name for processing on the text box also
            If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
                Dim draggedFolder As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
                e.Effect = DragDropEffects.Copy
                For Each foldername In draggedFolder
                    txtBoxDir.Text = Path.GetFullPath(foldername)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtBoxDir_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtBoxDir.DragEnter
        Try 'detects dragged item entering form
            If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
                e.Effect = DragDropEffects.All
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If menuitemMinSysTray.Checked = True Then
            NotifyIcon1.Visible = True
            If Me.WindowState = FormWindowState.Minimized Then 'send to tray on minimize
                Me.Hide()
                NotifyIcon1.ShowBalloonTip(1000)
                If btnStart.Enabled = False Then
                    NotifyIcon1.Text = "Folder monitoring is started." & vbCrLf & "Watching " & txtBoxDir.Text & "."
                Else
                    NotifyIcon1.Text = "Folder monitoring is stopped."
                End If
            End If
        ElseIf menuitemMinSysTray.Checked = False Then
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        'start the time and disable all the buttons that would break something
        If String.IsNullOrEmpty(txtBoxDir.Text.Trim) = False AndAlso IO.Directory.Exists(txtBoxDir.Text) Then
            Dim oStream As System.IO.Stream
            Dim oAssembly As System.Reflection.Assembly
            Dim sIcon As String
            Dim oBitmap As Bitmap
            sIcon = "file2foldergui.icon-hot.ico"
            oAssembly = System.Reflection.Assembly.LoadFrom(Application.ExecutablePath)
            oStream = oAssembly.GetManifestResourceStream(sIcon)
            oBitmap = CType(Image.FromStream(oStream), Bitmap)
            NotifyIcon1.Icon = Icon.FromHandle(oBitmap.GetHicon)
            timeLeft = 180
            Label1.Text = "Next run in " & timeLeft & " seconds"
            Timer1.Start()
            Timer2.Start()
            txtBoxDir.Enabled = False
            btnBrowse.Enabled = False
            btnStart.Enabled = False
            menuitemStartMon.Enabled = False
            btnStop.Enabled = True
            menuitemStopMon.Enabled = True
            btnMove.Enabled = False
            btnUndo.Enabled = False
            menuitemAutoClose.CheckState = False 'turn off process options if using monitor
            menuitemShowDir.CheckState = False
        Else : MessageBox.Show("Please enter a valid path monitor.")
            Exit Sub
        End If
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Dim oStream As System.IO.Stream
        Dim oAssembly As System.Reflection.Assembly
        Dim sIcon As String
        Dim oBitmap As Bitmap
        sIcon = "file2foldergui.icon.ico"
        oAssembly = System.Reflection.Assembly.LoadFrom(Application.ExecutablePath)
        oStream = oAssembly.GetManifestResourceStream(sIcon)
        oBitmap = CType(Image.FromStream(oStream), Bitmap)
        NotifyIcon1.Icon = Icon.FromHandle(oBitmap.GetHicon)
        Timer1.Stop() 'stop the time and re-enable the buttons
        Timer2.Stop()
        timeLeft = 179
        Label1.Text = "Next run in 180 seconds"
        btnStart.Enabled = True
        menuitemStartMon.Enabled = True
        txtBoxDir.Enabled = True
        btnBrowse.Enabled = True
        btnMove.Enabled = True
        btnUndo.Enabled = True
        btnStop.Enabled = False
        menuitemStopMon.Enabled = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If String.IsNullOrEmpty(txtBoxDir.Text.Trim) = False AndAlso IO.Directory.Exists(txtBoxDir.Text) Then 'run bgw in delegate of main thread
            Dim u As New myDelegate(AddressOf bgwRun)
            Me.Invoke(u)
            Timer2.Stop()
            timeLeft = 180
            Timer2.Start()
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show() 'bring app back into focus from systray on double click
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        timeLeft = timeLeft - 1 'subtract 1 from previous time and update label
        Label1.Text = "Next run in " & timeLeft & " seconds"
    End Sub

    Private Sub ReleaseNotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleaseNotesToolStripMenuItem.Click
        Form3.ShowDialog() 'show release notes box
    End Sub

    Private Sub menuitemClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuitemClose.Click
        Me.Close() 'close from systray context menu
    End Sub

    Private Sub menuitemStartMon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuitemStartMon.Click
        'start the time and disable all the buttons that would break something.  systray context menu cmd
        If String.IsNullOrEmpty(txtBoxDir.Text.Trim) = False AndAlso IO.Directory.Exists(txtBoxDir.Text) Then
            Dim oStream As System.IO.Stream
            Dim oAssembly As System.Reflection.Assembly
            Dim sIcon As String
            Dim oBitmap As Bitmap
            sIcon = "file2foldergui.icon-hot.ico"
            oAssembly = System.Reflection.Assembly.LoadFrom(Application.ExecutablePath)
            oStream = oAssembly.GetManifestResourceStream(sIcon)
            oBitmap = CType(Image.FromStream(oStream), Bitmap)
            NotifyIcon1.Icon = Icon.FromHandle(oBitmap.GetHicon)
            timeLeft = 180
            Label1.Text = "Next run in " & timeLeft & " seconds"
            Timer1.Start()
            Timer2.Start()
            txtBoxDir.Enabled = False
            btnBrowse.Enabled = False
            btnStart.Enabled = False
            menuitemStartMon.Enabled = False
            btnStop.Enabled = True
            menuitemStopMon.Enabled = True
            btnMove.Enabled = False
            btnUndo.Enabled = False
            menuitemAutoClose.CheckState = False 'turn off process options if using monitor
            menuitemShowDir.CheckState = False
        Else : MessageBox.Show("Please enter a valid path monitor.")
            Exit Sub
        End If
    End Sub

    Private Sub menuitemStopMon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuitemStopMon.Click
        Dim oStream As System.IO.Stream
        Dim oAssembly As System.Reflection.Assembly
        Dim sIcon As String
        Dim oBitmap As Bitmap
        sIcon = "file2foldergui.icon.ico"
        oAssembly = System.Reflection.Assembly.LoadFrom(Application.ExecutablePath)
        oStream = oAssembly.GetManifestResourceStream(sIcon)
        oBitmap = CType(Image.FromStream(oStream), Bitmap)
        NotifyIcon1.Icon = Icon.FromHandle(oBitmap.GetHicon)
        Timer1.Stop() 'stop the time and re-enable the buttons.  systray context menu cmd
        Timer2.Stop()
        timeLeft = 179
        Label1.Text = "Next run in 180 seconds"
        btnStart.Enabled = True
        menuitemStartMon.Enabled = True
        txtBoxDir.Enabled = True
        btnBrowse.Enabled = True
        btnMove.Enabled = True
        btnUndo.Enabled = True
        btnStop.Enabled = False
        menuitemStopMon.Enabled = False
    End Sub
End Class

Public Class MoveItem 'variables for handling undo feature
    Dim _oldPath As String = String.Empty
    Public Property OldPath() As String
        Get
            Return _oldPath
        End Get
        Set(ByVal value As String)
            _oldPath = value
        End Set
    End Property

    Dim _newPath As String = String.Empty
    Public Property NewPath() As String
        Get
            Return _newPath
        End Get
        Set(ByVal value As String)
            _newPath = value
        End Set
    End Property
End Class
