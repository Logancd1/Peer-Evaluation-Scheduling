﻿Imports Excel = Microsoft.Office.Interop.Excel

Public Class NewSemesterForm
    Dim semesterExists As Boolean

    Private Sub saveSemesterButton_Click(sender As Object, e As EventArgs) Handles saveSemesterButton.Click
        Dim xlApp As Excel.Application = New Excel.Application
        Dim xlWorkbook As Excel.Workbook = xlApp.Workbooks.Open(Form1.getFilePath())
        Dim wksht As Excel.Worksheet
        Dim wkshtTemp As Excel.Worksheet
        Dim statement As String = "Are you sure you want to create a new semester called " + semPrefix.SelectedItem + semYear.Text + "?"
        Dim question As DialogResult = MessageBox.Show(statement, "Confirmation", MessageBoxButtons.YesNo)
        If question = DialogResult.Yes Then
            For Each wkshtTemp In xlWorkbook.Worksheets
                If wkshtTemp.Name = semPrefix.SelectedItem + semYear.Text Then
                    MsgBox("You have already created that semester!")
                    semesterExists = True
                End If
            Next
            If Not semesterExists Then
                xlWorkbook.Sheets.Add()
                For Each wksht In xlWorkbook.Worksheets
                    If wksht.Name.Contains("Sheet") Then
                        wksht.Name = "" + semPrefix.SelectedItem + semYear.Text
                    End If
                Next
            End If
            xlWorkbook.Save()
            xlWorkbook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkbook)
            If Not semesterExists Then
                Form1.updateSemesters()
                createNewSemester(semPrefix.SelectedItem + semYear.Text)
                MsgBox(semPrefix.SelectedItem + semYear.Text + " Semester Created. Please paste the schedule data into the Excel file! Information about how to do this can be found in the User Manual at https://goo.gl/1qb9PJ")
            Else
                MsgBox(semPrefix.SelectedItem + semYear.Text + " Semester not Created")
            End If
        Else
            MsgBox(semPrefix.SelectedItem + semYear.Text + " Semester not Created")
            xlWorkbook.Save()
            xlWorkbook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkbook)
            Form1.updateSemesters()
        End If
        Me.Close()
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
            evalList.Cells(row, lastCol + 1).Value = "A,0"
        Next

        xlWorkbook.Save()
        xlWorkbook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkbook)
        releaseObject(evalList)
    End Sub


    Private Sub semPrefix_SelectedIndexChanged(sender As Object, e As EventArgs) Handles semPrefix.SelectedIndexChanged
        If (String.IsNullOrEmpty(semYear.Text)) Then
            'do nothing
        Else
            saveSemesterButton.Enabled = True
        End If
    End Sub

    Private Sub semYear_TextChanged(sender As Object, e As EventArgs) Handles semYear.TextChanged
        If (String.IsNullOrEmpty(semPrefix.SelectedItem)) Then
            'do nothing
        Else
            saveSemesterButton.Enabled = True
        End If
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
        saveSemesterButton.Enabled = False
        semesterExists = False
    End Sub
End Class