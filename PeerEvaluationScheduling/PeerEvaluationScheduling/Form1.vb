﻿Imports Excel = Microsoft.Office.Interop.Excel

Public Class Form1

    Private Sub NewEvalMenu_Click(sender As Object, e As EventArgs) Handles NewEvalMenu.Click
        'shows the evaluation form for user to search for professor
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
        If (String.IsNullOrEmpty(fileName.Text) Or String.IsNullOrEmpty(SemesterSelector.SelectedItem)) Then
            MsgBox("Please make sure you select an Excel file by clicking Browse AND select a semester!")
        Else
            Form3.Show()
        End If
    End Sub

    Private Sub EditRemEvalMenu_Click(sender As Object, e As EventArgs) Handles EditRemEvalMenu.Click
        'brings up list of evaluators to remove a current evaluator from the list
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
        If (String.IsNullOrEmpty(fileName.Text) Or String.IsNullOrEmpty(SemesterSelector.SelectedItem)) Then
            MsgBox("Please make sure you select an Excel file by clicking Browse AND select a semester!")
        Else
            NewSemesterForm.Show()
        End If
    End Sub

    Public Sub updateSemesters()
        SemesterSelector.Items.Clear()
        Dim semester As String
        Dim wksht As Excel.Worksheet
        Dim sheetNames As New ArrayList
        Dim xlApp As Excel.Application
        Dim xlWorkbook As Excel.Workbook

        xlApp = New Excel.Application
        xlWorkbook = xlApp.Workbooks.Open(getFilePath())
        For Each wksht In xlWorkbook.Worksheets
            If (Not (String.Compare(wksht.Name, "EvaluatorList") = 0 Or String.Compare(wksht.Name, "PendingEvaluationList") = 0 Or String.Compare(wksht.Name, "EvaluationList") = 0)) Then
                sheetNames.Add(wksht.Name)
            End If

        Next

        For Each semester In sheetNames
            SemesterSelector.Items.Add(semester)
        Next

        xlWorkbook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkbook)
    End Sub

    Public Function getSemester()
        Return SemesterSelector.SelectedItem.ToString
    End Function

    Public Sub updateSelectedSemester()
        SemesterSelector.SelectedIndex = SemesterSelector.FindStringExact(Form2.getSemester())
    End Sub

    Private Sub fileBrowseButton_Click(sender As Object, e As EventArgs) Handles fileBrowseButton.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
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
End Class
