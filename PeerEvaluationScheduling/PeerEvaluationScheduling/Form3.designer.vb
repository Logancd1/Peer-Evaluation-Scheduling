<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.addEval = New System.Windows.Forms.Label()
        Me.evalName = New System.Windows.Forms.TextBox()
        Me.addButton = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.PeerEvaluationScheduling.My.Resources.Resources.plnulogo
        Me.PictureBox1.Location = New System.Drawing.Point(26, 125)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(517, 100)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'addEval
        '
        Me.addEval.AutoSize = True
        Me.addEval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addEval.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.addEval.Location = New System.Drawing.Point(79, 53)
        Me.addEval.Name = "addEval"
        Me.addEval.Size = New System.Drawing.Size(64, 15)
        Me.addEval.TabIndex = 1
        Me.addEval.Text = "Evaluator: "
        '
        'evalName
        '
        Me.evalName.Location = New System.Drawing.Point(196, 55)
        Me.evalName.Name = "evalName"
        Me.evalName.Size = New System.Drawing.Size(168, 20)
        Me.evalName.TabIndex = 2
        '
        'addButton
        '
        Me.addButton.Location = New System.Drawing.Point(441, 52)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(75, 23)
        Me.addButton.TabIndex = 3
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(572, 285)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.evalName)
        Me.Controls.Add(Me.addEval)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form3"
        Me.Text = "Add Evaluator"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents addEval As Label
    Friend WithEvents evalName As TextBox
    Friend WithEvents addButton As Button
End Class
