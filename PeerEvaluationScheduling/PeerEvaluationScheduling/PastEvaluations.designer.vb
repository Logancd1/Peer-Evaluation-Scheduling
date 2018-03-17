<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PastEvaluations
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PastEvaluations))
        Me.profList = New System.Windows.Forms.ComboBox()
        Me.evalName = New System.Windows.Forms.Label()
        Me.semesterList = New System.Windows.Forms.ComboBox()
        Me.cancelEval = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'profList
        '
        Me.profList.FormattingEnabled = True
        Me.profList.Location = New System.Drawing.Point(76, 108)
        Me.profList.Name = "profList"
        Me.profList.Size = New System.Drawing.Size(207, 21)
        Me.profList.TabIndex = 0
        '
        'evalName
        '
        Me.evalName.AutoSize = True
        Me.evalName.Location = New System.Drawing.Point(73, 62)
        Me.evalName.Name = "evalName"
        Me.evalName.Size = New System.Drawing.Size(39, 13)
        Me.evalName.TabIndex = 1
        Me.evalName.Text = "Label1"
        Me.evalName.Visible = False
        '
        'semesterList
        '
        Me.semesterList.FormattingEnabled = True
        Me.semesterList.Location = New System.Drawing.Point(223, 13)
        Me.semesterList.Name = "semesterList"
        Me.semesterList.Size = New System.Drawing.Size(121, 21)
        Me.semesterList.TabIndex = 2
        '
        'cancelEval
        '
        Me.cancelEval.Location = New System.Drawing.Point(223, 57)
        Me.cancelEval.Name = "cancelEval"
        Me.cancelEval.Size = New System.Drawing.Size(111, 23)
        Me.cancelEval.TabIndex = 3
        Me.cancelEval.Text = "Cancel Evaluation"
        Me.cancelEval.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(76, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Evaluator"
        '
        'PastEvaluations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 175)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cancelEval)
        Me.Controls.Add(Me.semesterList)
        Me.Controls.Add(Me.evalName)
        Me.Controls.Add(Me.profList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PastEvaluations"
        Me.Text = "PastEvaluations"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents profList As ComboBox
    Friend WithEvents evalName As Label
    Friend WithEvents semesterList As ComboBox
    Friend WithEvents cancelEval As Button
    Friend WithEvents Label1 As Label
End Class
