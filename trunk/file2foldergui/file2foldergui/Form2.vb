Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblNewVersion.Text = "A new version of file2folder is available!" & vbCrLf & "Click OK to update and restart the application."
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim currApp = Application.ExecutablePath()
        Rename(currApp, Application.StartupPath & "/file2foldergui.old")
        DownloadFile()
        Application.Restart()
    End Sub
End Class