<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.linklblDownload = New System.Windows.Forms.LinkLabel
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblNewVersion = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'linklblDownload
        '
        Me.linklblDownload.AutoSize = True
        Me.linklblDownload.Location = New System.Drawing.Point(117, 56)
        Me.linklblDownload.Name = "linklblDownload"
        Me.linklblDownload.Size = New System.Drawing.Size(58, 13)
        Me.linklblDownload.TabIndex = 0
        Me.linklblDownload.TabStop = True
        Me.linklblDownload.Text = "Download!"
        Me.linklblDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(205, 89)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "OK"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblNewVersion
        '
        Me.lblNewVersion.AutoSize = True
        Me.lblNewVersion.Location = New System.Drawing.Point(50, 22)
        Me.lblNewVersion.Name = "lblNewVersion"
        Me.lblNewVersion.Size = New System.Drawing.Size(192, 13)
        Me.lblNewVersion.TabIndex = 2
        Me.lblNewVersion.Text = "A new version of file2folder is available!"
        Me.lblNewVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 124)
        Me.Controls.Add(Me.lblNewVersion)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.linklblDownload)
        Me.Name = "Form2"
        Me.Text = "file2folder GUI Update Available"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents linklblDownload As System.Windows.Forms.LinkLabel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblNewVersion As System.Windows.Forms.Label
End Class
