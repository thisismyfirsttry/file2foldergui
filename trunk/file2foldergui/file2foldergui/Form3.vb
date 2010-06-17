Public Class Form3

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load  'latest release notes
        txtboxReleaseNotes.Text = "Release notes for v1.4.3.0" _
        & vbCrLf & vbCrLf & "* New logo." _
        & vbCrLf & vbCrLf & "* Rudimentary multi-part file support.  Multi-part files can be ignored so that you can handle them yourself.  File names must contain cd, dvd, part, disc or disk followed by number (ex. movie-cd1.avi)."
    End Sub
End Class
