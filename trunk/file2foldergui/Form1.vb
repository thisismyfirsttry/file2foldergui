Public Class Form1

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        FolderBrowserDialog1.ShowDialog()
        txtboxDir.Text = FolderBrowserDialog1.SelectedPath
        lblDone.Visible = False
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        Dim rootPath As String = txtboxDir.Text
        ProgressBar1.Minimum = 0
        ProgressBar1.Step = 1

        If String.IsNullOrEmpty(txtboxDir.Text.Trim) = False AndAlso IO.Directory.Exists(txtboxDir.Text) Then
            ProgressBar1.Maximum = IO.Directory.GetFiles(rootPath).Length()
            For Each filePath As String In IO.Directory.GetFiles(rootPath)
                Dim folderName As String = IO.Path.GetFileNameWithoutExtension(filePath)
                Dim folderPath As String = IO.Path.Combine(rootPath, folderName)
                If Not IO.Directory.Exists(folderPath) Then
                    IO.Directory.CreateDirectory(folderPath)
                End If
                Dim fileName As String = IO.Path.GetFileName(filePath)
                Dim newfilePath As String = IO.Path.Combine(folderPath, fileName)
                IO.File.Move(filePath, newfilePath)
                ProgressBar1.PerformStep()
            Next
            lblDone.Visible = True
        Else : txtboxDir.Text = "Choose a valid directory!"
            lblDone.Visible = False
        End If
    End Sub
End Class
