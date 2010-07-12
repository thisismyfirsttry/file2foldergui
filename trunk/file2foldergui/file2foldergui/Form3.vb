Public Class Form3

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load  'latest release notes
        txtboxReleaseNotes.Text = "Release notes for v1.4.4.0" _
        & vbCrLf & vbCrLf & "* Fixed exception on update if no Internet connection."
    End Sub
End Class
