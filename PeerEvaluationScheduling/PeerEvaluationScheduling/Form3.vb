Imports Excel = Microsoft.Office.Interop.Excel

Public Class Form3
    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        'this button will add the evaluator whose name is in the text box to the left
        'MessageBox.Show(evalName.Text)
        Dim selected As String = evalName.Text 'captures entered evaluator
        evalName.Clear() 'clears searchbox
        AddNewProf(selected)
    End Sub


    Private Sub AddNewProf(selectedProf As String) 'adds in entered evaluator
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim TPESheet As Excel.Worksheet

        Dim lastRow As Integer = 0
        Dim lastCol As Integer = 0
        Dim keepTrack As Integer = 0
        Dim newProfRow As Integer = 0



        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=False) 'Open Excel file with writing capabilities
        TPESheet = xlWorkBook.Worksheets("EvaluatorList") 'Open list of TPE Sheet

        With TPESheet 'determine last row of colunm
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on colunm and works up till the first one is found
            lastCol = .Cells(1, .Columns.Count).End(Excel.XlDirection.xlToLeft).Column
        End With

        newProfRow = lastRow + 1

        For row As Integer = 1 To lastRow
            Name = TPESheet.Cells(row, 1).Value
            If Name = selectedProf Then 'if entered evaluator found, the form will close
                MessageBox.Show("Evaluator already added!")
                keepTrack = keepTrack + 1
            End If
        Next
        If keepTrack < 1 Then
            TPESheet.Cells(newProfRow, 1).Value = selectedProf 'set the value of this cell to the value of the last row
            MessageBox.Show(selectedProf + " has been added to the evaluator list.")
            For col As Integer = 2 To lastCol
                If Not String.IsNullOrEmpty(TPESheet.Cells(1, col).Value) Then
                    If TPESheet.Cells(1, col).Value = Form1.getSemester() Then
                        TPESheet.Cells(newProfRow, col).Value = "A,0"
                    Else
                        TPESheet.Cells(newProfRow, col).Value = "U,0"
                    End If
                End If
            Next
        End If

        xlWorkBook.Save() 'save changes
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(TPESheet)
        Form5.CreateList()

        Me.Close()
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