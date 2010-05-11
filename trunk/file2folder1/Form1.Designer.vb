<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdDirSelect = New System.Windows.Forms.Button()
        Me.dirText = New System.Windows.Forms.TextBox()
        Me.cmdMove = New System.Windows.Forms.Button()
        Me.dirLabel = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblDone = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdDirSelect
        '
        Me.cmdDirSelect.Location = New System.Drawing.Point(241, 46)
        Me.cmdDirSelect.Name = "cmdDirSelect"
        Me.cmdDirSelect.Size = New System.Drawing.Size(32, 20)
        Me.cmdDirSelect.TabIndex = 0
        Me.cmdDirSelect.Text = "..."
        Me.cmdDirSelect.UseVisualStyleBackColor = True
        '
        'dirText
        '
        Me.dirText.Location = New System.Drawing.Point(23, 46)
        Me.dirText.Name = "dirText"
        Me.dirText.Size = New System.Drawing.Size(212, 20)
        Me.dirText.TabIndex = 1
        '
        'cmdMove
        '
        Me.cmdMove.Location = New System.Drawing.Point(109, 82)
        Me.cmdMove.Name = "cmdMove"
        Me.cmdMove.Size = New System.Drawing.Size(75, 23)
        Me.cmdMove.TabIndex = 2
        Me.cmdMove.Text = "Move!"
        Me.cmdMove.UseVisualStyleBackColor = True
        '
        'dirLabel
        '
        Me.dirLabel.AutoSize = True
        Me.dirLabel.Location = New System.Drawing.Point(20, 30)
        Me.dirLabel.Name = "dirLabel"
        Me.dirLabel.Size = New System.Drawing.Size(144, 13)
        Me.dirLabel.TabIndex = 3
        Me.dirLabel.Text = "Select a directory to process:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(292, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(21, 111)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(250, 23)
        Me.ProgressBar1.TabIndex = 5
        '
        'lblDone
        '
        Me.lblDone.AutoSize = True
        Me.lblDone.Location = New System.Drawing.Point(127, 116)
        Me.lblDone.Name = "lblDone"
        Me.lblDone.Size = New System.Drawing.Size(36, 13)
        Me.lblDone.TabIndex = 6
        Me.lblDone.Text = "Done!"
        Me.lblDone.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 138)
        Me.Controls.Add(Me.lblDone)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.dirLabel)
        Me.Controls.Add(Me.cmdMove)
        Me.Controls.Add(Me.dirText)
        Me.Controls.Add(Me.cmdDirSelect)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "file2folderGUI"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cmdDirSelect As System.Windows.Forms.Button
    Friend WithEvents dirText As System.Windows.Forms.TextBox
    Friend WithEvents cmdMove As System.Windows.Forms.Button
    Friend WithEvents dirLabel As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDone As System.Windows.Forms.Label

End Class
