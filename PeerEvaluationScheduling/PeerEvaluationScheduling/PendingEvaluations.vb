Imports Excel = Microsoft.Office.Interop.Excel

Public Class PendingEvaluations
    Dim rows As ArrayList = New ArrayList()
    Dim selectedRow As Integer


    Private Sub updateForm()
        Dim semester As String = Form1.getSemester()
        evaluationList.Items.Clear()
        rows.Clear()
        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim pendEvalSheet As Excel.Worksheet
        Dim lastRow As Integer = 0

        xlApp = New Excel.Application
        xlWorkbook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=False)
        pendEvalSheet = xlWorkbook.Worksheets("PendingEvaluationList")

        With pendEvalSheet 'determine last row of colunm
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on colunm and works up till the first one is found
        End With

        For row As Integer = 1 To lastRow
            If (pendEvalSheet.Cells(row, 1).Value = semester) Then
                rows.Add(row)
            End If
        Next

        If rows.Count > 0 Then
            For Each i As Integer In rows
                evaluationList.Items.Add(pendEvalSheet.Cells(i, 2).Value)
            Next
        Else
            evaluationList.Items.Clear()
        End If

        tpe1.Visible = False
        tpe2.Visible = False
        tpe3.Visible = False
        tpe4.Visible = False
        selectButton.Visible = False

        openButton.Enabled = False

        xlWorkbook.Close()
        xlApp.Quit()
        releaseObject(xlWorkbook)
        releaseObject(xlApp)
        releaseObject(pendEvalSheet)
    End Sub

    Private Sub PendingEvaluations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim semester As String = Form1.getSemester()
        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim pendEvalSheet As Excel.Worksheet

        xlApp = New Excel.Application
        xlWorkbook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=False)
        pendEvalSheet = xlWorkbook.Worksheets("PendingEvaluationList")

        updateForm()

        xlWorkbook.Close()
        xlApp.Quit()
        releaseObject(xlWorkbook)
        releaseObject(xlApp)
        releaseObject(pendEvalSheet)
    End Sub

    Private Sub openButton_Click(sender As Object, e As EventArgs) Handles openButton.Click
        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim pendEvalSheet As Excel.Worksheet
        Dim profSelected As String = evaluationList.SelectedItem
        'Dim r As Integer

        xlApp = New Excel.Application
        xlWorkbook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=False)
        pendEvalSheet = xlWorkbook.Worksheets("PendingEvaluationList")

        For Each i As Integer In rows
            If profSelected = pendEvalSheet.Cells(i, 2).Value Then
                tpe1.Text = pendEvalSheet.Cells(i, 3).Value
                tpe2.Text = pendEvalSheet.Cells(i + 1, 3).Value
                tpe3.Text = pendEvalSheet.Cells(i + 2, 3).Value
                tpe4.Text = pendEvalSheet.Cells(i + 3, 3).Value
                selectedRow = i
            End If
        Next

        tpe1.Visible = True
        tpe2.Visible = True
        tpe3.Visible = True
        tpe4.Visible = True
        selectButton.Visible = True

        xlWorkbook.Close()
        xlApp.Quit()
        releaseObject(xlWorkbook)
        releaseObject(xlApp)
        releaseObject(pendEvalSheet)
    End Sub

    Private Sub evaluationList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles evaluationList.SelectedIndexChanged
        openButton.Enabled = True
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

    Private Sub selectButton_Click(sender As Object, e As EventArgs) Handles selectButton.Click
        Dim selectedEvaluator As String
        Dim unselectedEvaluator1, unselectedEvaluator2, unselectedEvaluator3 As String
        If tpe1.Checked Then
            selectedEvaluator = tpe1.Text
            unselectedEvaluator1 = tpe2.Text
            unselectedEvaluator2 = tpe3.Text
            unselectedEvaluator3 = tpe4.Text
        ElseIf tpe2.Checked Then
            selectedEvaluator = tpe2.Text
            unselectedEvaluator1 = tpe1.Text
            unselectedEvaluator2 = tpe3.Text
            unselectedEvaluator3 = tpe4.Text
        ElseIf tpe3.Checked Then
            selectedEvaluator = tpe3.Text
            unselectedEvaluator1 = tpe2.Text
            unselectedEvaluator2 = tpe1.Text
            unselectedEvaluator3 = tpe4.Text
        Else
            selectedEvaluator = tpe4.Text
            unselectedEvaluator1 = tpe2.Text
            unselectedEvaluator2 = tpe3.Text
            unselectedEvaluator3 = tpe1.Text
        End If

        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim evalSheet As Excel.Worksheet
        Dim evaluatorSheet As Excel.Worksheet
        Dim pendEvalSheet As Excel.Worksheet
        Dim semester As String = Form1.getSemester()
        Dim profSelected As String = evaluationList.SelectedItem
        Dim lastRow As Integer = 0
        Dim lastCol As Integer = 0
        Dim lastRow2 As Integer = 0
        Dim evalSemester As String = Form1.getSemester()
        Dim semColumn As Integer
        Dim evalCount As String
        Dim counter As Integer

        xlApp = New Excel.Application
        xlWorkbook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=False)
        evalSheet = xlWorkbook.Worksheets("EvaluationList")
        pendEvalSheet = xlWorkbook.Worksheets("PendingEvaluationList")
        evaluatorSheet = xlWorkbook.Worksheets("EvaluatorList")

        With evalSheet 'determine last row of colunm
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on colunm and works up till the first one is found
        End With

        With evaluatorSheet
            lastCol = .Cells(1, .Columns.Count).End(Excel.XlDirection.xlToLeft).Column
            lastRow2 = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row
        End With

        For column As Integer = 1 To lastCol
            If evaluatorSheet.Cells(1, column).Value = evalSemester Then
                semColumn = column
                GoTo nextcommand
            End If
        Next

nextcommand:

        For row As Integer = 2 To lastRow2
            If evaluatorSheet.Cells(row, 1).Value = unselectedEvaluator1 Or evaluatorSheet.Cells(row, 1).Value = unselectedEvaluator2 Or evaluatorSheet.Cells(row, 1).Value = unselectedEvaluator3 Then
                evalCount = getEvalCount(evaluatorSheet.Cells(row, semColumn).Value)
                evaluatorSheet.Cells(row, semColumn).Value = "A," + evalCount
            End If
            If evaluatorSheet.Cells(row, 1).Value = selectedEvaluator Then
                counter = Convert.ToInt32(getEvalCount(evaluatorSheet.Cells(row, semColumn).Value)) + 1
                evalCount = counter.ToString
                If Convert.ToInt32(evalCount) > 1 Then
                    evaluatorSheet.Cells(row, semColumn).Value = "U," + evalCount
                Else
                    evaluatorSheet.Cells(row, semColumn).Value = "A," + evalCount
                End If
            End If
        Next
        xlWorkbook.Save()

        evalSheet.Cells(lastRow + 1, 1).Value = semester
        evalSheet.Cells(lastRow + 1, 2).Value = profSelected
        evalSheet.Cells(lastRow + 1, 3).Value = selectedEvaluator

        pendEvalSheet.Rows(selectedRow & ":" & selectedRow + 4).Delete()

        MsgBox("Evaluator " + selectedEvaluator + " selected!")

        xlWorkbook.Save()
        updateForm()
        xlWorkbook.Close()
        xlApp.Quit()
        releaseObject(xlWorkbook)
        releaseObject(xlApp)
        releaseObject(evalSheet)
        releaseObject(pendEvalSheet)
    End Sub

    Private Function getStatus(data As String)
        Dim splitData() As String
        Dim status As String

        splitData = Split(data, ",")
        status = splitData(0)
        Return status
    End Function

    Private Function getEvalCount(data As String)
        Dim splitData() As String
        Dim count As String

        splitData = Split(data, ",")
        count = splitData(1)
        Return count
    End Function

    Private Sub tpe1_CheckedChanged(sender As Object, e As EventArgs) Handles tpe1.CheckedChanged

    End Sub
End Class