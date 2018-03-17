Imports Excel = Microsoft.Office.Interop.Excel

'starting
Public Class Form1

    Private Sub NewEvalMenu_Click(sender As Object, e As EventArgs) Handles NewEvalMenu.Click
        'shows the evaluation form for user to search for professor
        'File > New > Evaluation
        If (String.IsNullOrEmpty(fileName.Text) Or String.IsNullOrEmpty(SemesterSelector.SelectedItem)) Then
            MsgBox("Please make sure you select an Excel file by clicking Browse AND select a semester!")
        Else
            Form2.Show()
        End If
    End Sub

    Private Sub OpenEvalMenu_Click(sender As Object, e As EventArgs) Handles OpenEvalMenu.Click
        'File > Open > Pending Evaluations
        If (String.IsNullOrEmpty(fileName.Text) Or String.IsNullOrEmpty(SemesterSelector.SelectedItem)) Then
            MsgBox("Please make sure you select an Excel file by clicking Browse AND select a semester!")
        Else
            PendingEvaluations.Show()
        End If
    End Sub

    Private Sub EditAddEvalMenu_Click(sender As Object, e As EventArgs) Handles EditAddEvalMenu.Click
        'this brings up a form to enter a new evaluator's name to add to the list of evaluators
        'Edit > Evaluator List > Add Evaluator
        If (String.IsNullOrEmpty(fileName.Text) Or String.IsNullOrEmpty(SemesterSelector.SelectedItem)) Then
            MsgBox("Please make sure you select an Excel file by clicking Browse AND select a semester!")
        Else
            Form3.Show()
        End If
    End Sub

    Private Sub EditRemEvalMenu_Click(sender As Object, e As EventArgs) Handles EditRemEvalMenu.Click
        'brings up list of evaluators to remove a current evaluator from the list
        'Edit > Evaluator List > Edit Evaluator List
        If (String.IsNullOrEmpty(fileName.Text) Or String.IsNullOrEmpty(SemesterSelector.SelectedItem)) Then
            MsgBox("Please make sure you select an Excel file by clicking Browse AND select a semester!")
        Else
            Form5.Show()
        End If
    End Sub

    Private Sub ViewPastEvalMenu_Click(sender As Object, e As EventArgs) Handles ViewPastEvalMenu.Click
        'View > Past Evaluations
        If (String.IsNullOrEmpty(fileName.Text) Or String.IsNullOrEmpty(SemesterSelector.SelectedItem)) Then
            MsgBox("Please make sure you select an Excel file by clicking Browse AND select a semester!")
        Else
            PastEvaluations.Show()
        End If
    End Sub

    Private Sub SemesterSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SemesterSelector.SelectedIndexChanged
        'drop-down menu for user to select a different semester(only shows past four semesters, including the current semester)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("Please browse for an Excel file by clicking the Browse button")
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        'releases objects in use by program, such as Excel applications and workbooks
        'this closes any open tasks that TPE application calls this function for
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub newSemesterButton_Click(sender As Object, e As EventArgs) Handles newSemesterButton.Click
        'File > New > Semester
        'allows creation of new semesters
        If (String.IsNullOrEmpty(fileName.Text) Or String.IsNullOrEmpty(SemesterSelector.SelectedItem)) Then
            MsgBox("Please make sure you select an Excel file by clicking Browse AND select a semester!")
        Else
            NewSemesterForm.Show()
        End If
    End Sub

    Public Sub updateSemesters()
        'updates the drop-down menu in the upper right that contains each of the semesters
        SemesterSelector.Items.Clear()
        Dim semester As String
        Dim wksht As Excel.Worksheet
        Dim sheetNames As New ArrayList
        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook

        xlApp = New Excel.Application
        xlWorkbook = xlApp.Workbooks.Open(getFilePath())
        For Each wksht In xlWorkbook.Worksheets
            'finds each worksheet name in the opened workbook, checks for names that aren't semesters and avoids them, adds semester names to arraylist
            If (Not (String.Compare(wksht.Name, "EvaluatorList") = 0 Or String.Compare(wksht.Name, "PendingEvaluationList") = 0 Or String.Compare(wksht.Name, "EvaluationList") = 0)) Then
                sheetNames.Add(wksht.Name)
            End If

        Next

        'adds each semester name in the arraylist to the drop-down menu
        For Each semester In sheetNames
            SemesterSelector.Items.Add(semester)
        Next

        'closes the workbook and releases each of the running applications from memory
        xlWorkbook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkbook)
        SemesterSelector.SelectedItem = SemesterSelector.Items(0)
    End Sub

    Public Function getSemester()
        'gets the currently selected semester in the drop-down menu in the upper right
        Return SemesterSelector.SelectedItem.ToString
    End Function

    Public Sub updateSelectedSemester(semester As String)
        'updates the selected semester in the drop-down menu in the upper right just in case it was changed in another form
        SemesterSelector.SelectedIndex = SemesterSelector.FindStringExact(semester)
    End Sub

    Private Sub fileBrowseButton_Click(sender As Object, e As EventArgs) Handles fileBrowseButton.Click
        'opens Windows file manager to allow for file selection
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "\\ptloma.edu\peerevaluationscheduling"   'change to \\ptloma.edu\peerevaluationscheduling
        fd.Filter = "Excel Worksheets 2007(*.xlsx)|*.xlsx"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        If (fd.ShowDialog() = DialogResult.OK) Then
            strFileName = fd.FileName
        End If
        fileName.Text = strFileName
        If (Not String.IsNullOrEmpty(fileName.Text)) Then
            updateSemesters()
        End If
    End Sub

    Public Function getFilePath()
        Return fileName.Text
    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'contains the link to the user manual for the application
        VisitLink()
    End Sub

    Private Sub VisitLink()
        'opens internet browser directed to the application's user manual
        LinkLabel1.LinkVisited = True
        System.Diagnostics.Process.Start(LinkLabel1.Text)
    End Sub

    Private Sub DeleteSemesterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSemesterToolStripMenuItem.Click
        'Edit > Delete Semester
        If (String.IsNullOrEmpty(fileName.Text)) Then
            MsgBox("Please make sure you select an Excel file by clicking Browse!")
        Else
            DeleteSemesterForm.Show()
        End If
    End Sub
End Class
