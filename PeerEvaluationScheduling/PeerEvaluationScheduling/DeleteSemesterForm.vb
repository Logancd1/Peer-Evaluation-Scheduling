Imports Excel = Microsoft.Office.Interop.Excel

Public Class DeleteSemesterForm
    Private Sub semesterList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles semesterList.SelectedIndexChanged
        deleteSemesterButton.Enabled = True
    End Sub

    Private Sub deleteSemesterButton_Click(sender As Object, e As EventArgs) Handles deleteSemesterButton.Click
        deleteSemesterButton.Enabled = False
        Dim deleteThis As String
        deleteThis = semesterList.SelectedItem.ToString
        Dim wksht As Excel.Worksheet
        Dim sheetNames As New ArrayList
        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim evaluatorSheet, pendEvalSheet, pastEvalSheet As Excel.Worksheet
        Dim lastCol, lastRow As Integer
        Dim statement As String

        statement = "Are you sure you want to delete all data for semester " + deleteThis + "? This will delete ALL schedule data, pending evaluations, and past evaluations permanently!"
        Dim question As DialogResult = MessageBox.Show(statement, "Confirmation", MessageBoxButtons.YesNo)
        If question = DialogResult.Yes Then
            xlApp = New Excel.Application
            xlWorkbook = xlApp.Workbooks.Open(Form1.getFilePath())
            evaluatorSheet = xlWorkbook.Worksheets("EvaluatorList")
            pendEvalSheet = xlWorkbook.Worksheets("PendingEvaluationList")
            pastEvalSheet = xlWorkbook.Worksheets("EvaluationList")
            For Each wksht In xlWorkbook.Worksheets
                If (Not (String.Compare(wksht.Name, "EvaluatorList") = 0 Or String.Compare(wksht.Name, "PendingEvaluationList") = 0 Or String.Compare(wksht.Name, "EvaluationList") = 0)) Then
                    sheetNames.Add(wksht.Name)
                End If
            Next

            With evaluatorSheet
                lastCol = .Cells(1, .Columns.Count).End(Excel.XlDirection.xlToLeft).Column
            End With

            With pendEvalSheet
                lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row
            End With

            For column As Integer = 1 To lastCol
                If evaluatorSheet.Cells(1, column).Value = deleteThis Then
                    evaluatorSheet.Columns(column).Delete()
                End If
            Next

            For row As Integer = 1 To lastRow
                If pendEvalSheet.Cells(row, 1).Value = deleteThis Then
                    pendEvalSheet.Rows(row & ":" & row + 4).Delete()
                End If
            Next

            With pastEvalSheet
                lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row
            End With

            For row As Integer = 1 To lastRow
                If pastEvalSheet.Cells(row, 1).Value = deleteThis Then
                    pastEvalSheet.Rows(row & ":" & row + 4).Delete()
                End If
            Next

            For Each wksht In xlWorkbook.Worksheets
                If wksht.Name.ToString = deleteThis Then
                    MsgBox(wksht.Name.ToString + " has been deleted!")
                    wksht.Delete()
                End If
            Next

            xlWorkbook.Save()
            xlWorkbook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkbook)
            releaseObject(wksht)
            releaseObject(pendEvalSheet)
            releaseObject(pastEvalSheet)
            releaseObject(evaluatorSheet)
            Form1.updateSemesters()
            Form2.updateSemesters()
            Me.Close()
        Else
            MsgBox("Action Cancelled. No semesters are being deleted!")
        End If
    End Sub

    Private Sub DeleteSemesterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        deleteSemesterButton.Enabled = False
        updateSemesters()
    End Sub

    Public Sub updateSemesters()
        semesterList.Items.Clear()
        Dim semester As String
        Dim wksht As Excel.Worksheet
        Dim sheetNames As New ArrayList
        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook

        xlApp = New Excel.Application
        xlWorkbook = xlApp.Workbooks.Open(Form1.getFilePath())
        For Each wksht In xlWorkbook.Worksheets
            If (Not (String.Compare(wksht.Name, "EvaluatorList") = 0 Or String.Compare(wksht.Name, "PendingEvaluationList") = 0 Or String.Compare(wksht.Name, "EvaluationList") = 0)) Then
                sheetNames.Add(wksht.Name)
            End If
        Next

        For Each semester In sheetNames
            semesterList.Items.Add(semester)
        Next

        xlWorkbook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkbook)
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Class