Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Net

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim url As New System.Uri("http://update.thehtpc.net/file2foldergui/UpdateVersion.txt")
        Dim req As WebRequest
        req = WebRequest.Create(url)
        Dim resp As WebResponse
        Try
            OK_Button.Enabled = False
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            WebBrowser1.Navigate("http://update.thehtpc.net/file2foldergui/UpdateVersion.txt")
        Catch ex As Exception
            req = Nothing
            MessageBox.Show("The following error was encountered: " & ex.Message & "  Please try again later.")
            Me.Close()
        End Try

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Dim m As Match = Regex.Match(WebBrowser1.DocumentText, "<PRE>(?<version>(.*?))</PRE>")
        If m.Success = True Then
            If Application.ProductVersion <> m.Groups("version").Value Then
                lblUpdateCheck.Text = "Update available!"
                linklblDownload.Visible = True
            Else
                Me.lblUpdateCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                lblUpdateCheck.Text = "No update available."
            End If
        End If
        lblShowAvailVer.Text = m.Groups("version").Value
        lblShowYourVer.Text = Application.ProductVersion
        OK_Button.Enabled = True
    End Sub

    Private Sub linklblDownload_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linklblDownload.LinkClicked
        Process.Start("http://update.thehtpc.net/file2foldergui/latest-version/file2foldergui.exe")
    End Sub

    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Close()
    End Sub
End Class
