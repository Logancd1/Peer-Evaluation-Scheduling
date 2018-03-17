<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadingBar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoadingBar))
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.percentDone = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(64, 25)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(155, 23)
        Me.progressBar.TabIndex = 0
        '
        'percentDone
        '
        Me.percentDone.AutoSize = True
        Me.percentDone.Location = New System.Drawing.Point(130, 9)
        Me.percentDone.Name = "percentDone"
        Me.percentDone.Size = New System.Drawing.Size(21, 13)
        Me.percentDone.TabIndex = 1
        Me.percentDone.Text = "0%"
        '
        'LoadingBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 70)
        Me.Controls.Add(Me.percentDone)
        Me.Controls.Add(Me.progressBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LoadingBar"
        Me.Text = "Loading..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents percentDone As Label
End Class
