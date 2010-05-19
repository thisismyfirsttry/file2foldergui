Public Class Form2

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub linklblDownload_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linklblDownload.LinkClicked
        Process.Start("http://update.thehtpc.net/file2foldergui/latest-version/file2foldergui.exe")
        Me.Close()
    End Sub
End Class