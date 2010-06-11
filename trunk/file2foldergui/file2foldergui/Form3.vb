Public Class Form3

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtboxReleaseNotes.Text = "Release notes for v1.4.1.0" & vbCrLf & vbCrLf & "* New application icon" & vbCrLf & vbCrLf & "* Context menu option to close from system tray context menu" & vbCrLf & vbCrLf & "* Option to enable/disable minimize to system tray (disabled by default)" & vbCrLf & vbCrLf & "* Countdown timer for monitor" & vbCrLf & vbCrLf & "This release notes box!"
    End Sub
End Class