Public Class Form3

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load  'latest release notes
        txtboxReleaseNotes.Text = "Release notes for v1.4.2.0" _
        & vbCrLf & vbCrLf & "* Balloon notification when sending to system tray." _
        & vbCrLf & vbCrLf & "* Added system tray context menu for starting and stopping the folder monitor service." _
        & vbCrLf & vbCrLf & "* System tray tooltip shows currently monitored folder or states monitoring is stopped if not running." _
        & vbCrLf & vbCrLf & "* Minor interface cleanup."
    End Sub
End Class