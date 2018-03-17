Imports Excel = Microsoft.Office.Interop.Excel
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Me.EvaluatorsList = New System.Windows.Forms.ListBox()
        Me.removeEvaluator = New System.Windows.Forms.Button()
        Me.editStatus = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.semesterList = New System.Windows.Forms.ComboBox()
        Me.statusKey = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'EvaluatorsList
        '
        Me.EvaluatorsList.FormattingEnabled = True
        Me.EvaluatorsList.Location = New System.Drawing.Point(23, 88)
        Me.EvaluatorsList.Name = "EvaluatorsList"
        Me.EvaluatorsList.Size = New System.Drawing.Size(248, 121)
        Me.EvaluatorsList.TabIndex = 0
        '
        'removeEvaluator
        '
        Me.removeEvaluator.Location = New System.Drawing.Point(277, 135)
        Me.removeEvaluator.Name = "removeEvaluator"
        Me.removeEvaluator.Size = New System.Drawing.Size(75, 23)
        Me.removeEvaluator.TabIndex = 1
        Me.removeEvaluator.Text = "Remove"
        Me.removeEvaluator.UseVisualStyleBackColor = True
        '
        'editStatus
        '
        Me.editStatus.Location = New System.Drawing.Point(277, 181)
        Me.editStatus.Name = "editStatus"
        Me.editStatus.Size = New System.Drawing.Size(75, 23)
        Me.editStatus.TabIndex = 2
        Me.editStatus.Text = "Edit"
        Me.editStatus.UseVisualStyleBackColor = True
        '
        'addButton
        '
        Me.addButton.Location = New System.Drawing.Point(277, 88)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(75, 23)
        Me.addButton.TabIndex = 3
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = True
        '
        'semesterList
        '
        Me.semesterList.FormattingEnabled = True
        Me.semesterList.Location = New System.Drawing.Point(263, 12)
        Me.semesterList.Name = "semesterList"
        Me.semesterList.Size = New System.Drawing.Size(121, 21)
        Me.semesterList.TabIndex = 4
        '
        'statusKey
        '
        Me.statusKey.BackColor = System.Drawing.SystemColors.Control
        Me.statusKey.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.statusKey.FormattingEnabled = True
        Me.statusKey.Items.AddRange(New Object() {"A = Available", "U = Unavailable", "P = Pending"})
        Me.statusKey.Location = New System.Drawing.Point(23, 12)
        Me.statusKey.Name = "statusKey"
        Me.statusKey.Size = New System.Drawing.Size(120, 52)
        Me.statusKey.TabIndex = 5
        '
        'Form5
        '
        Me.ClientSize = New System.Drawing.Size(396, 263)
        Me.Controls.Add(Me.statusKey)
        Me.Controls.Add(Me.semesterList)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.editStatus)
        Me.Controls.Add(Me.removeEvaluator)
        Me.Controls.Add(Me.EvaluatorsList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form5"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents EvaluatorsList As ListBox
    Friend WithEvents removeEvaluator As Button
    Friend WithEvents editStatus As Button
    Friend WithEvents addButton As Button
    Friend WithEvents semesterList As ComboBox
    Friend WithEvents statusKey As ListBox
End Class
