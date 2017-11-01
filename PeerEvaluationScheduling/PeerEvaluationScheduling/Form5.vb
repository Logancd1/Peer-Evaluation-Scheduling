Imports Excel = Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Text

Partial Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateSemesters()
        CreateList()
        'disable those unavailable
    End Sub

    Private Sub removeEvaluator_Click(sender As Object, e As EventArgs) Handles removeEvaluator.Click
        'this button will remove the evaluator whose name is in the text box to the left
        RemoveProf()
        EvaluatorsList.Items.Clear() 'clear listbox data
        CreateList() 'refill listbox with updated list
    End Sub

    Private Sub editStatus_Click(sender As Object, e As EventArgs) Handles editStatus.Click
        'this button will edit the evaluators status of availability
        EditProf()
    End Sub

    Public Function getSemester()
        Return semesterList.SelectedItem
    End Function

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

    Public Sub CreateList() 'creates list using excel sheet
        EvaluatorsList.Items.Clear()
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim TPESheet As Excel.Worksheet

        Dim lastRow As Integer = 0
        Dim lastCol As Integer = 0
        Dim result As String
        Dim status1 As String
        Dim semester As String

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(Form1.getFilePath()) 'Open Excel file
        TPESheet = xlWorkBook.Worksheets("EvaluatorList") 'Open list of TPE Sheet

        With TPESheet 'determine last row of colunm
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on column and works up till the first one is found
        End With

        With TPESheet
            lastCol = .Cells(1, .Columns.Count).End(Excel.XlDirection.xlToLeft).Column
        End With

        EvaluatorsList.Items.Add("Status" & vbTab & "Evaluator")
        For col As Integer = 3 To lastCol
            semester = TPESheet.Cells(1, col).Value
            If semester = semesterList.SelectedItem Then 'finds column of selcted semester
                For row As Integer = 2 To lastRow
                    result = TPESheet.Cells(row, 1).Value
                    status1 = TPESheet.Cells(row, col).Value
                    EvaluatorsList.Items.Add(status1 & vbTab & result) 'add each name of evaluator with status to listbox
                Next
                col = lastCol
            End If
        Next

        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(TPESheet)
    End Sub

    Private Sub RemoveProf() 'removes selected evaluator
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim TPESheet As Excel.Worksheet

        Dim lastRow As Integer = 0
        Dim name As String

        Dim selectedProf As String = EvaluatorsList.SelectedItem.ToString() 'captures selected evaluator

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=False) 'Open Excel file with writing capabilities
        TPESheet = xlWorkBook.Worksheets("EvaluatorList") 'Open list of TPE Sheet

        With TPESheet 'determine last row of colunm
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on colunm and works up till the first one is found
        End With

        For row As Integer = 1 To lastRow
            name = TPESheet.Cells(row, 1).Value
            If name = selectedProf Then 'if selected evaluator found go in here
                TPESheet.Cells(row, 1).Value = "" 'delete evaluator
                TPESheet.Cells(row, 2).Value = "" 'delete status
                If Not row = lastRow Then 'if location of evaluator removed is not the last row go in here
                    TPESheet.Cells(row, 1).Value = TPESheet.Cells(lastRow, 1).Value 'set the value of this cell to the value of the last row
                    TPESheet.Cells(lastRow, 1).Value = "" 'delete last row content
                    TPESheet.Cells(row, 2).Value = TPESheet.Cells(lastRow, 2).Value 'set the value of this cell to the value of the last row
                    TPESheet.Cells(lastRow, 2).Value = "" 'delete last row content
                End If
            End If
        Next
        xlWorkBook.Save() 'save changes
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(TPESheet)
    End Sub

    Private Sub EditProf() 'removes selected evaluator
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim TPESheet As Excel.Worksheet

        Dim lastRow As Integer = 0
        Dim name As String
        Dim Status As String
        Dim available As String
        Dim selectedProf As String
        Dim semester As String = semesterList.SelectedItem.ToString
        Dim lastCol As Integer = 0
        Dim semesterCol As Integer


        Dim selectedProfString() As String = Split(EvaluatorsList.SelectedItem.ToString(), vbTab) 'captures selected evaluator
        selectedProf = selectedProfString(1)

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=False) 'Open Excel file with writing capabilities
        TPESheet = xlWorkBook.Worksheets("EvaluatorList") 'Open list of TPE Sheet

        With TPESheet 'determine last row of colunm
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on colunm and works up till the first one is found
            lastCol = .Cells(1, .Columns.Count).End(Excel.XlDirection.xlToLeft).Column
        End With

        For column As Integer = 1 To lastCol
            If TPESheet.Cells(1, column).Value = semester Then
                semesterCol = column
                GoTo endloop
            End If
        Next
endloop:
        For row As Integer = 1 To lastRow
            name = TPESheet.Cells(row, 1).Value
            If name = selectedProf Then 'if selected evaluator found go in here
                Status = TPESheet.Cells(row, semesterCol).Value 'check status of availability

                If Status = "A" Then
                    available = "available"
                ElseIf Status = "U" Then
                    available = "unavailable"
                ElseIf Status = "P" Then
                    available = "pending"
                End If

                Dim statement As String = name + " is " + available + ", do you want to change availability?"
                Dim question As DialogResult = MessageBox.Show(statement, "Confirmation", MessageBoxButtons.YesNo)
                If question = DialogResult.Yes Then
                    If Status = "A" Then
                        TPESheet.Cells(row, semesterCol).Value = "U" 'unavailable evaluator
                        MessageBox.Show("Changed to unavailable")
                    ElseIf Status = "U" Then
                        TPESheet.Cells(row, semesterCol).Value = "A" 'available evaluator
                        MessageBox.Show("Changed to available")
                    ElseIf Status = "P" Then
                        MessageBox.Show("Status didn't change because this professor is in a Pending Evaluation")
                    End If
                End If


            End If
        Next
        xlWorkBook.Save() 'save changes
        CreateList()
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(TPESheet)
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

    Private Sub Form5_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        Form3.Show()
    End Sub

    Private Sub semesterList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles semesterList.SelectedIndexChanged
        CreateList()
    End Sub
End Class