<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewEvalMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.newSemesterButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenEvalMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditEvalListMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditAddEvalMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditRemEvalMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewPastEvalMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SemesterSelector = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.fileBrowseButton = New System.Windows.Forms.Button()
        Me.fileName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.DeleteSemesterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.EditMenu, Me.ViewMenu})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(626, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMenu, Me.OpenMenu})
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(37, 20)
        Me.FileMenu.Text = "File"
        '
        'NewMenu
        '
        Me.NewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewEvalMenu, Me.newSemesterButton})
        Me.NewMenu.Name = "NewMenu"
        Me.NewMenu.Size = New System.Drawing.Size(103, 22)
        Me.NewMenu.Text = "New"
        '
        'NewEvalMenu
        '
        Me.NewEvalMenu.Name = "NewEvalMenu"
        Me.NewEvalMenu.Size = New System.Drawing.Size(129, 22)
        Me.NewEvalMenu.Text = "Evaluation"
        '
        'newSemesterButton
        '
        Me.newSemesterButton.Name = "newSemesterButton"
        Me.newSemesterButton.Size = New System.Drawing.Size(129, 22)
        Me.newSemesterButton.Text = "Semester"
        '
        'OpenMenu
        '
        Me.OpenMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenEvalMenu})
        Me.OpenMenu.Name = "OpenMenu"
        Me.OpenMenu.Size = New System.Drawing.Size(103, 22)
        Me.OpenMenu.Text = "Open"
        '
        'OpenEvalMenu
        '
        Me.OpenEvalMenu.Name = "OpenEvalMenu"
        Me.OpenEvalMenu.Size = New System.Drawing.Size(176, 22)
        Me.OpenEvalMenu.Text = "Pending Evaluation"
        '
        'EditMenu
        '
        Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditEvalListMenu, Me.DeleteSemesterToolStripMenuItem})
        Me.EditMenu.Name = "EditMenu"
        Me.EditMenu.Size = New System.Drawing.Size(39, 20)
        Me.EditMenu.Text = "Edit"
        '
        'EditEvalListMenu
        '
        Me.EditEvalListMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditAddEvalMenu, Me.EditRemEvalMenu})
        Me.EditEvalListMenu.Name = "EditEvalListMenu"
        Me.EditEvalListMenu.Size = New System.Drawing.Size(158, 22)
        Me.EditEvalListMenu.Text = "Evaluator List"
        '
        'EditAddEvalMenu
        '
        Me.EditAddEvalMenu.Name = "EditAddEvalMenu"
        Me.EditAddEvalMenu.Size = New System.Drawing.Size(167, 22)
        Me.EditAddEvalMenu.Text = "Add Evaluator"
        '
        'EditRemEvalMenu
        '
        Me.EditRemEvalMenu.Name = "EditRemEvalMenu"
        Me.EditRemEvalMenu.Size = New System.Drawing.Size(167, 22)
        Me.EditRemEvalMenu.Text = "Edit Evaluator List"
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewPastEvalMenu})
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(44, 20)
        Me.ViewMenu.Text = "View"
        '
        'ViewPastEvalMenu
        '
        Me.ViewPastEvalMenu.Name = "ViewPastEvalMenu"
        Me.ViewPastEvalMenu.Size = New System.Drawing.Size(159, 22)
        Me.ViewPastEvalMenu.Text = "Past Evaluations"
        '
        'SemesterSelector
        '
        Me.SemesterSelector.FormattingEnabled = True
        Me.SemesterSelector.Location = New System.Drawing.Point(493, 12)
        Me.SemesterSelector.Name = "SemesterSelector"
        Me.SemesterSelector.Size = New System.Drawing.Size(121, 21)
        Me.SemesterSelector.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = Global.PeerEvaluationScheduling.My.Resources.Resources.plnulogo
        Me.PictureBox1.Location = New System.Drawing.Point(51, 177)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(513, 99)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'fileBrowseButton
        '
        Me.fileBrowseButton.Location = New System.Drawing.Point(412, 87)
        Me.fileBrowseButton.Name = "fileBrowseButton"
        Me.fileBrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.fileBrowseButton.TabIndex = 4
        Me.fileBrowseButton.Text = "Browse"
        Me.fileBrowseButton.UseVisualStyleBackColor = True
        '
        'fileName
        '
        Me.fileName.Location = New System.Drawing.Point(145, 90)
        Me.fileName.Name = "fileName"
        Me.fileName.Size = New System.Drawing.Size(247, 20)
        Me.fileName.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(213, 338)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "User Manual:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(279, 338)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(113, 13)
        Me.LinkLabel1.TabIndex = 7
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "https://goo.gl/1qb9PJ"
        '
        'DeleteSemesterToolStripMenuItem
        '
        Me.DeleteSemesterToolStripMenuItem.Name = "DeleteSemesterToolStripMenuItem"
        Me.DeleteSemesterToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.DeleteSemesterToolStripMenuItem.Text = "Delete Semester"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(626, 483)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.fileName)
        Me.Controls.Add(Me.fileBrowseButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.SemesterSelector)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Evaluator Selection"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileMenu As ToolStripMenuItem
    Friend WithEvents NewMenu As ToolStripMenuItem
    Friend WithEvents OpenMenu As ToolStripMenuItem
    Friend WithEvents EditMenu As ToolStripMenuItem
    Friend WithEvents NewEvalMenu As ToolStripMenuItem
    Friend WithEvents ViewMenu As ToolStripMenuItem
    Friend WithEvents OpenEvalMenu As ToolStripMenuItem
    Friend WithEvents EditEvalListMenu As ToolStripMenuItem
    Friend WithEvents EditAddEvalMenu As ToolStripMenuItem
    Friend WithEvents EditRemEvalMenu As ToolStripMenuItem
    Friend WithEvents ViewPastEvalMenu As ToolStripMenuItem
    Friend WithEvents SemesterSelector As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents newSemesterButton As ToolStripMenuItem
    Friend WithEvents fileBrowseButton As Button
    Friend WithEvents fileName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents DeleteSemesterToolStripMenuItem As ToolStripMenuItem
End Class
