Imports Excel = Microsoft.Office.Interop.Excel

Public Class PastEvaluations
    Dim rows As ArrayList = New ArrayList()

    Private Sub profList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles profList.SelectedIndexChanged
        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim evalSheet As Excel.Worksheet
        Dim lastRow As Integer = 0

        xlApp = New Excel.Application
        xlWorkbook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=True)
        evalSheet = xlWorkbook.Worksheets("EvaluationList")

        With evalSheet 'determine last row of colunm
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on colunm and works up till the first one is found
        End With

        For row As Integer = 1 To lastRow
            If (evalSheet.Cells(row, 2).Value = profList.SelectedItem) Then
                evalName.Text = evalSheet.Cells(row, 3).Value
            End If
        Next

        evalName.Visible = True

        xlWorkbook.Close()
        xlApp.Quit()
        releaseObject(xlWorkbook)
        releaseObject(xlApp)
        releaseObject(evalSheet)
    End Sub

    Private Sub evalName_Click(sender As Object, e As EventArgs) Handles evalName.Click

    End Sub

    Private Sub PastEvaluations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateForm()
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
        updateSelectedSemester()
    End Sub

    Public Sub updateSelectedSemester()
        semesterList.SelectedIndex = semesterList.FindStringExact(Form1.getSemester())
    End Sub

    Private Sub updateForm()
        Dim semester As String = Form1.getSemester()
        profList.Items.Clear()
        rows.Clear()
        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim evalSheet As Excel.Worksheet
        Dim lastRow As Integer = 0

        xlApp = New Excel.Application
        xlWorkbook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=True)
        evalSheet = xlWorkbook.Worksheets("EvaluationList")

        With evalSheet 'determine last row of colunm
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on colunm and works up till the first one is found
        End With

        For row As Integer = 1 To lastRow
            If (evalSheet.Cells(row, 1).Value = semester) Then
                rows.Add(row)
            End If
        Next

        If rows.Count > 0 Then
            For Each i As Integer In rows
                profList.Items.Add(evalSheet.Cells(i, 2).Value)
            Next
        Else
            profList.Items.Clear()
        End If

        xlWorkbook.Close()
        xlApp.Quit()
        releaseObject(xlWorkbook)
        releaseObject(xlApp)
        releaseObject(evalSheet)
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

    Private Sub semesterList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles semesterList.SelectedIndexChanged

    End Sub
End Class