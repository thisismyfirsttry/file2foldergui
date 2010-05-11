Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDirSelect.Click
        FolderBrowserDialog1.ShowDialog()
        dirText.Text = FolderBrowserDialog1.SelectedPath
        lblDone.Visible = False
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dirLabel.Click

    End Sub

    Private Sub cmdMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMove.Click
        Dim rootPath As String = dirText.Text
        ProgressBar1.Minimum = 0
        ProgressBar1.Step = 1

        If String.IsNullOrEmpty(dirText.Text.Trim) = False AndAlso IO.Directory.Exists(dirText.Text) Then
            ProgressBar1.Maximum = IO.Directory.GetFiles(rootPath).Length()
            For Each filepath As String In IO.Directory.GetFiles(rootPath)
                Dim folderName As String = IO.Path.GetFileNameWithoutExtension(filepath)
                Dim folderPath As String = IO.Path.Combine(rootPath, folderName)
                If Not IO.Directory.Exists(folderPath) Then
                    IO.Directory.CreateDirectory(folderPath)
                End If
                Dim fileName As String = IO.Path.GetFileName(filepath)
                Dim newFilePath As String = IO.Path.Combine(folderPath, fileName)
                IO.File.Move(filepath, newFilePath)
                ProgressBar1.PerformStep()
            Next
            lblDone.Visible = True
        Else : dirText.Text = "Choose a valid directory!"
            lblDone.Visible = False
        End If

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub
End Class