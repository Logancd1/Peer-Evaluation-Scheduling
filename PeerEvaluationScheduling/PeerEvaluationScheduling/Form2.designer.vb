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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.ProfSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.EvalList = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.evalNameMenu = New System.Windows.Forms.ComboBox()
        Me.semesterList = New System.Windows.Forms.ComboBox()
        Me.availabilityLabel = New System.Windows.Forms.Label()
        Me.availabilityCount = New System.Windows.Forms.ComboBox()
        Me.availabilityTooltip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProfSearch
        '
        Me.ProfSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProfSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.ProfSearch.Location = New System.Drawing.Point(218, 375)
        Me.ProfSearch.Name = "ProfSearch"
        Me.ProfSearch.Size = New System.Drawing.Size(156, 21)
        Me.ProfSearch.TabIndex = 0
        Me.ProfSearch.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(59, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Professor to be Evaluated: "
        '
        'SearchButton
        '
        Me.SearchButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchButton.Location = New System.Drawing.Point(400, 75)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(75, 23)
        Me.SearchButton.TabIndex = 2
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'EvalList
        '
        Me.EvalList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.EvalList.FormattingEnabled = True
        Me.EvalList.Location = New System.Drawing.Point(237, 135)
        Me.EvalList.Name = "EvalList"
        Me.EvalList.Size = New System.Drawing.Size(120, 95)
        Me.EvalList.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(141, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Evaluators: "
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(400, 166)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveButton.TabIndex = 5
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.PeerEvaluationScheduling.My.Resources.Resources.plnulogo
        Me.PictureBox1.Location = New System.Drawing.Point(29, 249)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(514, 100)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'evalNameMenu
        '
        Me.evalNameMenu.FormattingEnabled = True
        Me.evalNameMenu.Location = New System.Drawing.Point(218, 60)
        Me.evalNameMenu.Name = "evalNameMenu"
        Me.evalNameMenu.Size = New System.Drawing.Size(157, 21)
        Me.evalNameMenu.TabIndex = 7
        '
        'semesterList
        '
        Me.semesterList.FormattingEnabled = True
        Me.semesterList.Location = New System.Drawing.Point(443, 13)
        Me.semesterList.Name = "semesterList"
        Me.semesterList.Size = New System.Drawing.Size(121, 21)
        Me.semesterList.TabIndex = 8
        '
        'availabilityLabel
        '
        Me.availabilityLabel.AutoSize = True
        Me.availabilityLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.availabilityLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.availabilityLabel.Location = New System.Drawing.Point(88, 101)
        Me.availabilityLabel.Name = "availabilityLabel"
        Me.availabilityLabel.Size = New System.Drawing.Size(123, 15)
        Me.availabilityLabel.TabIndex = 9
        Me.availabilityLabel.Text = "Evaluator Availability: "
        '
        'availabilityCount
        '
        Me.availabilityCount.FormattingEnabled = True
        Me.availabilityCount.Location = New System.Drawing.Point(236, 95)
        Me.availabilityCount.Name = "availabilityCount"
        Me.availabilityCount.Size = New System.Drawing.Size(121, 21)
        Me.availabilityCount.TabIndex = 10
        '
        'availabilityTooltip
        '
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(576, 425)
        Me.Controls.Add(Me.availabilityCount)
        Me.Controls.Add(Me.availabilityLabel)
        Me.Controls.Add(Me.semesterList)
        Me.Controls.Add(Me.evalNameMenu)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.EvalList)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProfSearch)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.Text = "Evaluator Selection"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProfSearch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SearchButton As Button
    Friend WithEvents EvalList As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents SaveButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents evalNameMenu As ComboBox
    Friend WithEvents semesterList As ComboBox
    Friend WithEvents availabilityLabel As Label
    Friend WithEvents availabilityCount As ComboBox
    Friend WithEvents availabilityTooltip As ToolTip
End Class
