Imports Excel = Microsoft.Office.Interop.Excel

Public Class NewSemesterForm

    Private Sub scheduleData_TextChanged(sender As Object, e As EventArgs) Handles scheduleData.TextChanged

    End Sub

    Private Sub saveSemesterButton_Click(sender As Object, e As EventArgs) Handles saveSemesterButton.Click
        Dim xlApp As Excel.Application = New Excel.Application
        Dim xlWorkbook As Excel.Workbook = xlApp.Workbooks.Open(Form1.getFilePath())
        Dim wksht As Excel.Worksheet
        Dim statement As String = "Are you sure you want to create a new semester called " + semPrefix.SelectedItem + semYear.Text + "?"
        Dim question As DialogResult = MessageBox.Show(statement, "Confirmation", MessageBoxButtons.YesNo)
        If question = DialogResult.Yes Then
            xlWorkbook.Sheets.Add()
            For Each wksht In xlWorkbook.Worksheets
                If (wksht.Name.Contains("Sheet")) Then
                    wksht.Name = "" + semPrefix.SelectedItem + semYear.Text
                End If
            Next
            xlWorkbook.Save()
            xlWorkbook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkbook)
            Form1.updateSemesters()
            createNewSemester(semPrefix.SelectedItem + semYear.Text)
            MsgBox(semPrefix.SelectedItem + semYear.Text + " Semester Created")
        Else
            MsgBox(semPrefix.SelectedItem + semYear.Text + " Semester not Created")
            xlWorkbook.Save()
            xlWorkbook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkbook)
            Form1.updateSemesters()
        End If
    End Sub

    Private Sub createNewSemester(semName As String)
        Dim xlApp As Excel.Application = New Excel.Application
        Dim xlWorkbook As Excel.Workbook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=False)
        Dim evalList As Excel.Worksheet = xlWorkbook.Worksheets("EvaluatorList")
        Dim lastCol As Integer
        Dim lastRow As Integer

        With evalList
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row
            lastCol = .Cells(1, .Columns.Count).End(Excel.XlDirection.xlToLeft).Column
        End With

        evalList.Cells(1, lastCol + 1).Value = semName
        For row As Integer = 2 To lastRow
            evalList.Cells(row, lastCol + 1).Value = "A"
            evalList.Cells(row, 2).Value = "0"
        Next

        xlWorkbook.Save()
        xlWorkbook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkbook)
        releaseObject(evalList)
    End Sub


    Private Sub semPrefix_SelectedIndexChanged(sender As Object, e As EventArgs) Handles semPrefix.SelectedIndexChanged

    End Sub

    Private Sub semYear_TextChanged(sender As Object, e As EventArgs) Handles semYear.TextChanged

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

    Private Sub NewSemesterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        semPrefix.Items.Add("FA")
        semPrefix.Items.Add("SP")
    End Sub
End Class