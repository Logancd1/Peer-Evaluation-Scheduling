﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewSemesterForm
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
        Me.scheduleData = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.saveSemesterButton = New System.Windows.Forms.Button()
        Me.semPrefix = New System.Windows.Forms.ComboBox()
        Me.semYear = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'scheduleData
        '
        Me.scheduleData.Location = New System.Drawing.Point(208, 116)
        Me.scheduleData.Multiline = True
        Me.scheduleData.Name = "scheduleData"
        Me.scheduleData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.scheduleData.Size = New System.Drawing.Size(202, 207)
        Me.scheduleData.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(84, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Semester Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Paste Schedules Here:"
        '
        'saveSemesterButton
        '
        Me.saveSemesterButton.Location = New System.Drawing.Point(455, 150)
        Me.saveSemesterButton.Name = "saveSemesterButton"
        Me.saveSemesterButton.Size = New System.Drawing.Size(75, 23)
        Me.saveSemesterButton.TabIndex = 4
        Me.saveSemesterButton.Text = "Save"
        Me.saveSemesterButton.UseVisualStyleBackColor = True
        '
        'semPrefix
        '
        Me.semPrefix.FormattingEnabled = True
        Me.semPrefix.Location = New System.Drawing.Point(208, 50)
        Me.semPrefix.Name = "semPrefix"
        Me.semPrefix.Size = New System.Drawing.Size(65, 21)
        Me.semPrefix.TabIndex = 5
        '
        'semYear
        '
        Me.semYear.Location = New System.Drawing.Point(309, 50)
        Me.semYear.Name = "semYear"
        Me.semYear.Size = New System.Drawing.Size(100, 20)
        Me.semYear.TabIndex = 6
        '
        'NewSemesterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 377)
        Me.Controls.Add(Me.semYear)
        Me.Controls.Add(Me.semPrefix)
        Me.Controls.Add(Me.saveSemesterButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.scheduleData)
        Me.Name = "NewSemesterForm"
        Me.Text = "NewSemesterForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents scheduleData As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents saveSemesterButton As Button
    Friend WithEvents semPrefix As ComboBox
    Friend WithEvents semYear As TextBox
End Class
