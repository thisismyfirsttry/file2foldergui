Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Diagnostics


Public Class Form1
    Dim moveItems As New BindingList(Of MoveItem)
    Dim isUndo As Boolean = False
    Public monitorFolder As FileSystemWatcher

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

    Private Sub bgwMover_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwMover.DoWork 'background worker process for move'
        If isUndo = False Then
            Dim files() As String = IO.Directory.GetFiles(txtBoxDir.Text.Trim)
            If files.Length > 0 Then moveItems.Clear()
            Dim i As Integer = 1
            For Each filePath As String In files
                Dim fi As New FileInfo(filePath)
                If (fi.Attributes And IO.FileAttributes.Hidden) = IO.FileAttributes.Hidden Or (fi.Attributes And IO.FileAttributes.System) = IO.FileAttributes.System Then Continue For 'Check for hidden or system attribute and exclude for each'
                Try
                    Dim newFolderPath As String = IO.Path.Combine(txtBoxDir.Text.Trim, IO.Path.GetFileNameWithoutExtension(filePath))
                    If Not IO.Directory.Exists(newFolderPath) Then
                        IO.Directory.CreateDirectory(newFolderPath) 'create new directory based on filename minus extension if it does not exist'
                    End If

                    Dim mi As New MoveItem
                    mi.OldPath = filePath
                    mi.NewPath = IO.Path.Combine(newFolderPath, IO.Path.GetFileName(filePath))
                    moveItems.Add(mi) 'move files by name into folders by name'

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
                    bgwMover.ReportProgress((i / moveItems.Count) * 100, "Undoing """ & IO.Path.GetFileName(mi.NewPath) & """ to """ & mi.OldPath & """...") 'progress bar stuff'
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
        If e.ProgressPercentage <> 0 Then
            ProgressBar1.Value = e.ProgressPercentage
        End If
        If Not e.UserState Is Nothing Then
            txtLog.Text &= e.UserState
        End If
    End Sub
    Private Sub bgwMover_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwMover.RunWorkerCompleted
        If menuitemShowDir.Checked = True AndAlso menuitemAutoClose.Checked = True Then
            Process.Start("explorer.exe", txtBoxDir.Text)
            Me.Close()
        ElseIf menuitemShowDir.Checked = True And menuitemAutoClose.Checked = False Then
            Process.Start("explorer.exe", txtBoxDir.Text)
        ElseIf menuitemAutoClose.Checked = True Then
            Me.Close()
        End If
        ProgressBar1.Value = 100
        btnMove.Enabled = True
        btnUndo.Enabled = True
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

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = " file2folder GUI v" & Application.ProductVersion.ToString
        btnStart.Enabled = True
        btnStop.Enabled = False
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
        If Me.WindowState = FormWindowState.Minimized Then 'send to tray on minimize
            Me.Hide()
        End If
    End Sub

    Private Sub NotifyIcon1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        If Me.WindowState = FormWindowState.Minimized Then 'maximize on system tray icon mouse click
            Me.Show()
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        monitorFolder = New FileSystemWatcher() 'start the folder monitoring process.  disable everything else while running
        If String.IsNullOrEmpty(txtBoxDir.Text.Trim) = False AndAlso IO.Directory.Exists(txtBoxDir.Text) Then
            monitorFolder.Path = txtBoxDir.Text.Trim
        Else : Exit Sub
        End If
        txtBoxDir.Enabled = False
        btnBrowse.Enabled = False
        btnStart.Enabled = False
        btnStop.Enabled = True
        btnMove.Enabled = False
        btnUndo.Enabled = False
        monitorFolder.NotifyFilter = NotifyFilters.FileName
        AddHandler monitorFolder.Created, AddressOf fileAdded
        monitorFolder.EnableRaisingEvents = True
    End Sub

    Private Sub fileAdded(ByVal source As Object, ByVal e As System.IO.FileSystemEventArgs)
        If e.ChangeType = IO.WatcherChangeTypes.Created Then 'call main thread to run bgwMover on new file
            Dim u As New myDelegate(AddressOf bgwRun)
            Me.Invoke(u)
        End If
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        btnStart.Enabled = True
        txtBoxDir.Enabled = True
        btnBrowse.Enabled = True
        monitorFolder.EnableRaisingEvents = False
        btnMove.Enabled = True
        btnUndo.Enabled = True
        btnStop.Enabled = False
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
