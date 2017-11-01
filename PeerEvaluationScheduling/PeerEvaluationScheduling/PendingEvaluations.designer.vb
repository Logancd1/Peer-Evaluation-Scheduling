<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PendingEvaluations
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
        Me.openButton = New System.Windows.Forms.Button()
        Me.evaluationList = New System.Windows.Forms.ComboBox()
        Me.tpe1 = New System.Windows.Forms.RadioButton()
        Me.tpe2 = New System.Windows.Forms.RadioButton()
        Me.tpe3 = New System.Windows.Forms.RadioButton()
        Me.tpe4 = New System.Windows.Forms.RadioButton()
        Me.selectButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'openButton
        '
        Me.openButton.Location = New System.Drawing.Point(292, 93)
        Me.openButton.Name = "openButton"
        Me.openButton.Size = New System.Drawing.Size(75, 23)
        Me.openButton.TabIndex = 0
        Me.openButton.Text = "Open"
        Me.openButton.UseVisualStyleBackColor = True
        '
        'evaluationList
        '
        Me.evaluationList.FormattingEnabled = True
        Me.evaluationList.Location = New System.Drawing.Point(51, 95)
        Me.evaluationList.Name = "evaluationList"
        Me.evaluationList.Size = New System.Drawing.Size(221, 21)
        Me.evaluationList.TabIndex = 1
        '
        'tpe1
        '
        Me.tpe1.AutoSize = True
        Me.tpe1.Location = New System.Drawing.Point(51, 155)
        Me.tpe1.Name = "tpe1"
        Me.tpe1.Size = New System.Drawing.Size(90, 17)
        Me.tpe1.TabIndex = 6
        Me.tpe1.TabStop = True
        Me.tpe1.Text = "RadioButton1"
        Me.tpe1.UseVisualStyleBackColor = True
        Me.tpe1.Visible = False
        '
        'tpe2
        '
        Me.tpe2.AutoSize = True
        Me.tpe2.Location = New System.Drawing.Point(51, 190)
        Me.tpe2.Name = "tpe2"
        Me.tpe2.Size = New System.Drawing.Size(90, 17)
        Me.tpe2.TabIndex = 7
        Me.tpe2.TabStop = True
        Me.tpe2.Text = "RadioButton2"
        Me.tpe2.UseVisualStyleBackColor = True
        Me.tpe2.Visible = False
        '
        'tpe3
        '
        Me.tpe3.AutoSize = True
        Me.tpe3.Location = New System.Drawing.Point(166, 155)
        Me.tpe3.Name = "tpe3"
        Me.tpe3.Size = New System.Drawing.Size(90, 17)
        Me.tpe3.TabIndex = 8
        Me.tpe3.TabStop = True
        Me.tpe3.Text = "RadioButton3"
        Me.tpe3.UseVisualStyleBackColor = True
        Me.tpe3.Visible = False
        '
        'tpe4
        '
        Me.tpe4.AutoSize = True
        Me.tpe4.Location = New System.Drawing.Point(166, 190)
        Me.tpe4.Name = "tpe4"
        Me.tpe4.Size = New System.Drawing.Size(90, 17)
        Me.tpe4.TabIndex = 9
        Me.tpe4.TabStop = True
        Me.tpe4.Text = "RadioButton4"
        Me.tpe4.UseVisualStyleBackColor = True
        Me.tpe4.Visible = False
        '
        'selectButton
        '
        Me.selectButton.Location = New System.Drawing.Point(278, 173)
        Me.selectButton.Name = "selectButton"
        Me.selectButton.Size = New System.Drawing.Size(112, 23)
        Me.selectButton.TabIndex = 10
        Me.selectButton.Text = "Select Evaluator"
        Me.selectButton.UseVisualStyleBackColor = True
        Me.selectButton.Visible = False
        '
        'PendingEvaluations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 319)
        Me.Controls.Add(Me.selectButton)
        Me.Controls.Add(Me.tpe4)
        Me.Controls.Add(Me.tpe3)
        Me.Controls.Add(Me.tpe2)
        Me.Controls.Add(Me.tpe1)
        Me.Controls.Add(Me.evaluationList)
        Me.Controls.Add(Me.openButton)
        Me.Name = "PendingEvaluations"
        Me.Text = "PendingEvaluations"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents openButton As Button
    Friend WithEvents evaluationList As ComboBox
    Friend WithEvents tpe1 As RadioButton
    Friend WithEvents tpe2 As RadioButton
    Friend WithEvents tpe3 As RadioButton
    Friend WithEvents tpe4 As RadioButton
    Friend WithEvents selectButton As Button
End Class
