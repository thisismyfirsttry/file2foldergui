Module Module1
    Public Sub DownloadFile()
        'download latest version of file2folder GUI
        Dim updateClient As New System.Net.WebClient
        updateClient.DownloadFile("http://update.thehtpc.net/file2foldergui/latest-version/file2foldergui.exe", Application.StartupPath & "/file2foldergui.exe")
    End Sub
End Module
