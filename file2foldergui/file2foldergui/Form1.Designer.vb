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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.btnMove = New System.Windows.Forms.Button
        Me.txtboxDir = New System.Windows.Forms.TextBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.menuitemShowDir = New System.Windows.Forms.ToolStripMenuItem
        Me.menuitemAutoClose = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.lblDirInfo = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.tooltipF2F = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnUndo = New System.Windows.Forms.Button
        Me.bgwMover = New System.ComponentModel.BackgroundWorker
        Me.txtLog = New System.Windows.Forms.TextBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(256, 47)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 23)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "..."
        Me.tooltipF2F.SetToolTip(Me.btnBrowse, "Click to browse for a directory")
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(204, 271)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(75, 23)
        Me.btnMove.TabIndex = 1
        Me.btnMove.Text = "Move!"
        Me.tooltipF2F.SetToolTip(Me.btnMove, "Click to process selected directory")
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'txtboxDir
        '
        Me.txtboxDir.Location = New System.Drawing.Point(12, 50)
        Me.txtboxDir.Name = "txtboxDir"
        Me.txtboxDir.Size = New System.Drawing.Size(238, 20)
        Me.txtboxDir.TabIndex = 2
        Me.tooltipF2F.SetToolTip(Me.txtboxDir, "Manually enter a directory")
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(11, 242)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(268, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(291, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveLogToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveLogToolStripMenuItem
        '
        Me.SaveLogToolStripMenuItem.Name = "SaveLogToolStripMenuItem"
        Me.SaveLogToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveLogToolStripMenuItem.Text = "Save log"
        Me.SaveLogToolStripMenuItem.ToolTipText = "Save log as text file"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemShowDir, Me.menuitemAutoClose})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'menuitemShowDir
        '
        Me.menuitemShowDir.CheckOnClick = True
        Me.menuitemShowDir.Name = "menuitemShowDir"
        Me.menuitemShowDir.Size = New System.Drawing.Size(156, 22)
        Me.menuitemShowDir.Text = "Show directory"
        Me.menuitemShowDir.ToolTipText = "Opens the directory after processing"
        '
        'menuitemAutoClose
        '
        Me.menuitemAutoClose.CheckOnClick = True
        Me.menuitemAutoClose.Name = "menuitemAutoClose"
        Me.menuitemAutoClose.Size = New System.Drawing.Size(156, 22)
        Me.menuitemAutoClose.Text = "Close after move"
        Me.menuitemAutoClose.ToolTipText = "Closes the application after processing"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'lblDirInfo
        '
        Me.lblDirInfo.AutoSize = True
        Me.lblDirInfo.Location = New System.Drawing.Point(9, 34)
        Me.lblDirInfo.Name = "lblDirInfo"
        Me.lblDirInfo.Size = New System.Drawing.Size(148, 13)
        Me.lblDirInfo.TabIndex = 6
        Me.lblDirInfo.Text = "Enter or browse for a directory"
        '
        'btnUndo
        '
        Me.btnUndo.Location = New System.Drawing.Point(123, 271)
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(75, 23)
        Me.btnUndo.TabIndex = 8
        Me.btnUndo.Text = "Undo!"
        Me.tooltipF2F.SetToolTip(Me.btnUndo, "Undo last move")
        Me.btnUndo.UseVisualStyleBackColor = True
        '
        'bgwMover
        '
        Me.bgwMover.WorkerReportsProgress = True
        Me.bgwMover.WorkerSupportsCancellation = True
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(12, 76)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.Size = New System.Drawing.Size(238, 160)
        Me.txtLog.TabIndex = 9
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Text files |*.txt|All files|*.*"
        Me.SaveFileDialog1.Title = "Save log..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 297)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.btnUndo)
        Me.Controls.Add(Me.lblDirInfo)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.txtboxDir)
        Me.Controls.Add(Me.btnMove)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "file2folder GUI"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnMove As System.Windows.Forms.Button
    Friend WithEvents txtboxDir As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblDirInfo As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemShowDir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemAutoClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tooltipF2F As System.Windows.Forms.ToolTip
    Friend WithEvents btnUndo As System.Windows.Forms.Button
    Friend WithEvents bgwMover As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
