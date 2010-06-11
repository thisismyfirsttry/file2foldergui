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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.menuitemShowDir = New System.Windows.Forms.ToolStripMenuItem
        Me.menuitemAutoClose = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.lblDirInfo = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.tooltipF2F = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnUndo = New System.Windows.Forms.Button
        Me.txtBoxDir = New System.Windows.Forms.TextBox
        Me.bgwMover = New System.ComponentModel.BackgroundWorker
        Me.txtLog = New System.Windows.Forms.TextBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.webBrwsStartup = New System.Windows.Forms.WebBrowser
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnStop = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.MenuStrip1.Size = New System.Drawing.Size(458, 24)
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
        Me.SaveLogToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
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
        Me.menuitemShowDir.Size = New System.Drawing.Size(288, 22)
        Me.menuitemShowDir.Text = "Show directory"
        Me.menuitemShowDir.ToolTipText = "Opens the directory after processing"
        '
        'menuitemAutoClose
        '
        Me.menuitemAutoClose.CheckOnClick = True
        Me.menuitemAutoClose.Name = "menuitemAutoClose"
        Me.menuitemAutoClose.Size = New System.Drawing.Size(288, 22)
        Me.menuitemAutoClose.Text = "Close after move (No undo will be available!)"
        Me.menuitemAutoClose.ToolTipText = "Closes the application after processing"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuItem1.Text = "About file2folder GUI"
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
        'txtBoxDir
        '
        Me.txtBoxDir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtBoxDir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtBoxDir.Location = New System.Drawing.Point(12, 50)
        Me.txtBoxDir.Name = "txtBoxDir"
        Me.txtBoxDir.Size = New System.Drawing.Size(238, 20)
        Me.txtBoxDir.TabIndex = 10
        Me.tooltipF2F.SetToolTip(Me.txtBoxDir, "Manually enter or browse for a directory")
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
        Me.txtLog.Size = New System.Drawing.Size(267, 160)
        Me.txtLog.TabIndex = 9
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Text files |*.txt|All files|*.*"
        Me.SaveFileDialog1.Title = "Save log..."
        '
        'webBrwsStartup
        '
        Me.webBrwsStartup.Location = New System.Drawing.Point(12, 271)
        Me.webBrwsStartup.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webBrwsStartup.Name = "webBrwsStartup"
        Me.webBrwsStartup.Size = New System.Drawing.Size(60, 23)
        Me.webBrwsStartup.TabIndex = 11
        Me.webBrwsStartup.Visible = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "file2folder GUI"
        Me.NotifyIcon1.Visible = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnStop)
        Me.GroupBox1.Controls.Add(Me.btnStart)
        Me.GroupBox1.Location = New System.Drawing.Point(296, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(150, 160)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "file2folder Monitor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Next run in 180 seconds"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(37, 84)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(37, 46)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 297)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.webBrwsStartup)
        Me.Controls.Add(Me.txtBoxDir)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.btnUndo)
        Me.Controls.Add(Me.lblDirInfo)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnMove)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "file2folder GUI"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnMove As System.Windows.Forms.Button
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
    Friend WithEvents txtBoxDir As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents webBrwsStartup As System.Windows.Forms.WebBrowser
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
