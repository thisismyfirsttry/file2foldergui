<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblUpdateCheck = New System.Windows.Forms.Label
        Me.linklblDownload = New System.Windows.Forms.LinkLabel
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.lblYourVersion = New System.Windows.Forms.Label
        Me.lblAvailableVer = New System.Windows.Forms.Label
        Me.lblShowYourVer = New System.Windows.Forms.Label
        Me.lblShowAvailVer = New System.Windows.Forms.Label
        Me.OK_Button = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblUpdateCheck
        '
        Me.lblUpdateCheck.Location = New System.Drawing.Point(12, 21)
        Me.lblUpdateCheck.Name = "lblUpdateCheck"
        Me.lblUpdateCheck.Size = New System.Drawing.Size(251, 13)
        Me.lblUpdateCheck.TabIndex = 1
        Me.lblUpdateCheck.Text = "Checking for update.  Please wait..."
        Me.lblUpdateCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'linklblDownload
        '
        Me.linklblDownload.AutoSize = True
        Me.linklblDownload.Location = New System.Drawing.Point(110, 75)
        Me.linklblDownload.Name = "linklblDownload"
        Me.linklblDownload.Size = New System.Drawing.Size(55, 13)
        Me.linklblDownload.TabIndex = 2
        Me.linklblDownload.TabStop = True
        Me.linklblDownload.Text = "Download"
        Me.linklblDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.linklblDownload.Visible = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(12, 92)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(60, 29)
        Me.WebBrowser1.TabIndex = 3
        Me.WebBrowser1.Visible = False
        '
        'lblYourVersion
        '
        Me.lblYourVersion.AutoSize = True
        Me.lblYourVersion.Location = New System.Drawing.Point(9, 46)
        Me.lblYourVersion.Name = "lblYourVersion"
        Me.lblYourVersion.Size = New System.Drawing.Size(70, 13)
        Me.lblYourVersion.TabIndex = 4
        Me.lblYourVersion.Text = "Your Version:"
        '
        'lblAvailableVer
        '
        Me.lblAvailableVer.AutoSize = True
        Me.lblAvailableVer.Location = New System.Drawing.Point(133, 46)
        Me.lblAvailableVer.Name = "lblAvailableVer"
        Me.lblAvailableVer.Size = New System.Drawing.Size(91, 13)
        Me.lblAvailableVer.TabIndex = 5
        Me.lblAvailableVer.Text = "Available Version:"
        '
        'lblShowYourVer
        '
        Me.lblShowYourVer.AutoSize = True
        Me.lblShowYourVer.Location = New System.Drawing.Point(79, 46)
        Me.lblShowYourVer.Name = "lblShowYourVer"
        Me.lblShowYourVer.Size = New System.Drawing.Size(0, 13)
        Me.lblShowYourVer.TabIndex = 6
        '
        'lblShowAvailVer
        '
        Me.lblShowAvailVer.AutoSize = True
        Me.lblShowAvailVer.Location = New System.Drawing.Point(224, 46)
        Me.lblShowAvailVer.Name = "lblShowAvailVer"
        Me.lblShowAvailVer.Size = New System.Drawing.Size(0, 13)
        Me.lblShowAvailVer.TabIndex = 7
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(196, 98)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 8
        Me.OK_Button.Text = "OK"
        '
        'Dialog1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 133)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.lblShowAvailVer)
        Me.Controls.Add(Me.lblShowYourVer)
        Me.Controls.Add(Me.lblAvailableVer)
        Me.Controls.Add(Me.lblYourVersion)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.linklblDownload)
        Me.Controls.Add(Me.lblUpdateCheck)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "file2folder GUI Update"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUpdateCheck As System.Windows.Forms.Label
    Friend WithEvents linklblDownload As System.Windows.Forms.LinkLabel
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents lblYourVersion As System.Windows.Forms.Label
    Friend WithEvents lblAvailableVer As System.Windows.Forms.Label
    Friend WithEvents lblShowYourVer As System.Windows.Forms.Label
    Friend WithEvents lblShowAvailVer As System.Windows.Forms.Label
    Friend WithEvents OK_Button As System.Windows.Forms.Button

End Class
