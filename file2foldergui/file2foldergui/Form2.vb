Public Class Form2

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim currApp = Application.ExecutablePath()
        Rename(currApp, Application.StartupPath & "/file2foldergui.old")
        DownloadFile()
        Application.Restart()
        Me.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblNewVersion.Text = "A new version of file2folder is available!" & vbCrLf & "Click OK to update and restart the application."
    End Sub
End Class