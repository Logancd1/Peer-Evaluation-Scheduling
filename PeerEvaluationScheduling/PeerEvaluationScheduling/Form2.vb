Imports Excel = Microsoft.Office.Interop.Excel


Public Class Form2
    Dim TPE As Integer = 1
    Dim keepTrackArray As New ArrayList
    Dim keepTrackTPE As New ArrayList
    Dim TPEList As New ArrayList

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        If Not String.IsNullOrEmpty(availabilityCount.SelectedItem.ToString) And Not String.IsNullOrEmpty(evalNameMenu.SelectedItem.ToString) Then
            Dim selected As String = evalNameMenu.Text 'captures entered evaluatee
            EvalList.Items.Clear()
            SearchProf(selected)
        Else
            MsgBox("Please select a professor and an availability count!")
        End If
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        'saves the current evaluation search as an evaluation in excel spreadsheet
        'saves both the professor and the four evaluators that were offered as options to the professor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim EvaluationList As Excel.Worksheet
        Dim EvaluatorList As Excel.Worksheet
        Dim prof As String
        Dim Semester As String
        Dim row As Integer = 1
        Dim lastRow As Integer = 0
        Dim nameProf As String
        Dim semCol As Integer
        Dim lastCol As Integer = 0

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=False) 'Open Excel file
        EvaluationList = xlWorkBook.Worksheets("PendingEvaluationList") 'Open list of TPE Sheet
        EvaluatorList = xlWorkBook.Worksheets("EvaluatorList")

        'finds next section where cell is empty
        While Not EvaluationList.Cells(row, 2).Value = ""
            row += 5
        End While

        'adds Semester on 1st col
        Semester = semesterList.SelectedItem.ToString
        EvaluationList.Cells(row, 1).Value = Semester

        'adds professors name on 2nd col
        prof = evalNameMenu.SelectedItem.ToString
        EvaluationList.Cells(row, 2).Value = prof

        'adds TPE to the right of professors name
        For Each word As Object In EvalList.Items
            EvaluationList.Cells(row, 3).Value = word
            row = row + 1

            With EvaluatorList 'determine last row of colunm
                lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on colunm and works up till the first one is found
                lastCol = .Cells(1, .Columns.Count).End(Excel.XlDirection.xlToLeft).Column
            End With

            For column As Integer = 1 To lastCol
                If EvaluatorList.Cells(1, column).Value = semesterList.SelectedItem Then
                    semCol = column
                    GoTo foundsem
                End If
            Next

foundsem:

            For r As Integer = 1 To lastRow
                nameProf = EvaluatorList.Cells(r, 1).Value
                ' Status = EvaluatorList.Cells(r, 2).Value
                If nameProf = word Then 'if selected evaluator found go in here
                    EvaluatorList.Cells(r, semCol).Value = "P"
                End If
            Next
        Next

        xlWorkBook.Save() 'save changes
        MsgBox("Changes have been saved")
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(EvaluationList)
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

    Private Sub evalNameMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles evalNameMenu.SelectedIndexChanged
        EvalList.Items.Clear()
        availabilityCount.Items.Clear()
        populateAvailabilityCounts()
    End Sub

    Private Sub populateAvailabilityCounts()
        LoadingBar.Show()
        LoadingBar.setMaximum(1550)
        keepTrackArray.Clear()
        availabilityCount.Items.Clear()
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim TPESheet As Excel.Worksheet
        Dim i As Integer
        Dim lastRow As Integer = 0
        Dim evaluatorList As New ArrayList()
        Dim s As String
        Dim Pname As String
        Dim selectedProf As String = evalNameMenu.SelectedItem

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=True) 'Open Excel file with writing capabilities
        TPESheet = xlWorkBook.Worksheets(semesterList.SelectedItem) 'Opens excel sheet to current semester

        With TPESheet 'determine last row of colunm
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on colunm and works up till the first one is found
        End With

        For row As Integer = 3 To lastRow
            Name = TPESheet.Cells(row, 3).Value
            Pname = Name
            If compareNames(Pname, selectedProf) = 1 And Not String.IsNullOrEmpty(TPESheet.Cells(row, 11).Value) And Not String.Compare("TBA", TPESheet.Cells(row, 11).Value) = 0 Then 'when evaluatee is found, their schedule will be accessed
                keepTrackArray.Add(row)
            End If
            LoadingBar.increaseProgress(1)
        Next

        For i = 0 To keepTrackArray.Count - 1
            availabilityCount.Items.Add((i + 1).ToString)
        Next

        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(TPESheet)
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        availabilityTooltip.SetToolTip(availabilityLabel, "Number of professor's classes an evaluator should be available for")
        updateSemesters()
        LoadingBar.Show()
        LoadingBar.setMaximum(1550)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim profList As Excel.Worksheet

        Dim lastRow As Integer = 0
        Dim profNames As New ArrayList
        Dim result As String
        Dim name As String
        Dim exists As Boolean = False

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(Form1.getFilePath())
        profList = xlWorkBook.Worksheets(semesterList.SelectedItem)

        With profList
            lastRow = .Range("C" & .Rows.Count).End(Excel.XlDirection.xlUp).Row
        End With

        For row As Integer = 3 To lastRow
            result = profList.Cells(row, 3).Value
            For Each name In profNames
                If (String.Compare(name, result) = 0) Then
                    exists = True
                End If
            Next
            If (Not exists And Not String.IsNullOrEmpty(result) And Not (String.Compare(result, "STAFF") = 0)) Then
                profNames.Add(result)
            End If
            exists = False
            LoadingBar.increaseProgress(1)
        Next
        profNames.Sort()
        For Each name In profNames
            evalNameMenu.Items.Add(name)
        Next

        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(profList)
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

    Public Sub randomize(list As ArrayList)
        Dim r As Random = New Random()
        For cnt As Integer = 0 To list.Count - 1
            Dim tmp As Object = list(cnt)
            Dim idx As Integer = r.Next(list.Count - cnt) + cnt
            list(cnt) = list(idx)
            list(idx) = tmp
        Next
    End Sub

    Private Sub SearchProf(selectedProf As String)
        TPEList.Clear()
        LoadingBar.Show()
        LoadingBar.setMaximum(68000)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim TPESheet As Excel.Worksheet
        Dim i As Integer = 0
        Dim lastRow As Integer = 0
        Dim TPEName As String
        Dim PName As String
        Dim EName As String
        Dim evaluatorList As New ArrayList()
        Dim s As String
        Dim lastRow2 As Integer = 0
        Dim evaluatorName As String
        Dim evaluatorSheet As Excel.Worksheet
        Dim lastCol As Integer = 0
        Dim semCol As Integer

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=True) 'Open Excel file with writing capabilities
        TPESheet = xlWorkBook.Worksheets(semesterList.SelectedItem) 'Opens excel sheet to current semester
        evaluatorSheet = xlWorkBook.Worksheets("EvaluatorList")

        With evaluatorSheet
            lastRow2 = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row
            lastCol = .Cells(1, .Columns.Count).End(Excel.XlDirection.xlToLeft).Column
        End With

        With TPESheet 'determine last row of colunm
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on colunm and works up till the first one is found
        End With

        For row As Integer = 3 To lastRow
            Name = TPESheet.Cells(row, 3).Value
            PName = Name
            If compareNames(PName, selectedProf) = 1 And Not String.IsNullOrEmpty(TPESheet.Cells(row, 11).Value) And Not String.Compare("TBA", TPESheet.Cells(row, 11).Value) = 0 Then 'when evaluatee is found, their schedule will be accessed
                keepTrackArray.Add(row)
            End If
        Next

        For column As Integer = 1 To lastCol
            If evaluatorSheet.Cells(1, column).Value = semesterList.SelectedItem Then
                semCol = column
                GoTo foundsemestercolumn
            End If
        Next

foundsemestercolumn:

        For row As Integer = 1 To lastRow2
            evaluatorName = evaluatorSheet.Cells(row, 1).Value
            If evaluatorSheet.Cells(row, semCol).Value = "A" Then
                evaluatorList.Add(evaluatorName)
            End If
        Next

        randomize(evaluatorList)

        For Each s In evaluatorList
            LoadingBar.increaseProgress(1)
            If TPEList.Count > 3 Then
                LoadingBar.increaseProgress(LoadingBar.getMax() - LoadingBar.getValue())
                GoTo endloop
            End If
            TPEName = s
            For row As Integer = 3 To lastRow
                LoadingBar.increaseProgress(1)
                Name = TPESheet.Cells(row, 3).Value
                EName = Name
                If compareNames(EName, TPEName) = 1 And Not String.IsNullOrEmpty(TPESheet.Cells(row, 11).Value) And Not String.Compare("TBA", TPESheet.Cells(row, 11).Value) = 0 Then 'when evaluator is found, their schedule will be accessed
                    'code to access schedules and compare the two
                    keepTrackTPE.Add(row)
                    'need to crease a variable that can hold the amount of times the TPE is "available" if not available TPE++
                    'loops to next TPE
                    ' If they are both avail TimesAvail++
                End If
            Next
            If (CompareSchedule(keepTrackArray, keepTrackTPE) = 1) Then
                LoadingBar.increaseProgress(LoadingBar.getMax() / 4.5)
                TPEList.Add(TPEName)
                EvalList.Items.Add(TPEName)
            End If
            keepTrackTPE.Clear()
        Next
endloop:
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(TPESheet)
        releaseObject(evaluatorSheet)
    End Sub

    Private Function CompareSchedule(profArray As ArrayList, evalArray As ArrayList)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim TPESheet As Excel.Worksheet
        Dim lastRow As Integer = 0
        Dim PClassDays As String
        Dim PDepartment As String
        Dim PBegTime As String
        Dim PEndTime As String
        Dim EClassDays As String
        Dim EDepartment As String
        Dim EBegTime As String
        Dim EEndTime As String
        Dim Availability As Integer
        Dim isAvailable As Boolean = True

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(Form1.getFilePath(), ReadOnly:=True) 'Open Excel file with writing capabilities
        TPESheet = xlWorkBook.Worksheets(semesterList.SelectedItem) 'Opens excel sheet to current semester

        With TPESheet 'determine last row of colunm
            lastRow = .Range("A" & .Rows.Count).End(Excel.XlDirection.xlUp).Row 'starts from last row on colunm and works up till the first one is found
        End With

        For row As Integer = 0 To profArray.Count - 1
            'PDepartment = TPESheet.Cells(keepTrackArray(row), 1).Value
            PClassDays = TPESheet.Cells(profArray(row), 11).Value
            PBegTime = TPESheet.Cells(profArray(row), 12).Value
            PEndTime = TPESheet.Cells(profArray(row), 13).Value
            isAvailable = True
            For row2 As Integer = 0 To evalArray.Count - 1
                'EDepartment = TPESheet.Cells(keepTrackTPE(row2), 1).Value
                EClassDays = TPESheet.Cells(evalArray(row2), 11).Value
                EBegTime = TPESheet.Cells(evalArray(row2), 12).Value
                EEndTime = TPESheet.Cells(evalArray(row2), 13).Value
                If compareDays(PClassDays, EClassDays) = 0 Then
                    If compareBegTime(PBegTime, EBegTime) = 0 Then
                        isAvailable = False
                    End If
                End If
            Next
            If isAvailable Then
                Availability = Availability + 1
            End If
            If Availability > Convert.ToInt32(availabilityCount.SelectedItem) Then
                GoTo done
            End If
        Next
done:
        If Availability > Convert.ToInt32(availabilityCount.SelectedItem) Then
            'The TPE is available during at least 3 times to evalaute the professor
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(TPESheet)
            Return 1
        Else
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(TPESheet)
            Return 0
        End If
    End Function

    Private Function compareBegTime(PBegin As String, EBegin As String)
        If PBegin = EBegin Then
            Return 0
        Else
            Return 1
        End If
    End Function

    Private Function compareDays(ProfDays As String, EvalDays As String)
        If ProfDays.Equals(EvalDays) Then
            Return 0
        Else
            Return 1
        End If
    End Function

    Private Function compareNames(listName As String, searchName As String)
        'take a substring up until you see a comma or a space from each string, then compare
        'if equal, then we need to compare the stuff after the comma/space
        Dim listNameTemp() As String
        searchName = searchName.Replace(" ", "")
        If (listName.Contains(" ")) Then
            listNameTemp = Split(listName, " ")
            If (listNameTemp(0).Contains(",")) Then
                listName = listNameTemp(0) + listNameTemp(1)
            Else
                listName = listNameTemp(0)
            End If
        End If
        listName = listName.Replace(" ", "")
        Dim listNameSplit() As String
        Dim searchNameSplit() As String
        Dim listNameFirst As String
        Dim listNameFirstLen As Integer
        Dim searchNameFirst As String
        Dim listNameLast As String
        Dim searchNameLast As String

        If (listName.Contains(",")) Then
            listNameSplit = Split(listName, ",") 'contains Anderson and D
            listNameLast = listNameSplit(0)
            listNameFirst = listNameSplit(1)
        Else
            listNameLast = listName
            listNameFirst = ""
        End If
        If (searchName.Contains(",")) Then
            searchNameSplit = Split(searchName, ",") 'this should contain Anderson and Dianne
            searchNameLast = searchNameSplit(0)
            searchNameFirst = searchNameSplit(1)
        Else
            searchNameLast = searchName
            searchNameFirst = ""
        End If
        'get the length of the second item in the listNameLast
        listNameFirstLen = listNameFirst.Length
        If (Not String.IsNullOrEmpty(listNameFirst) And Not String.IsNullOrEmpty(searchNameFirst)) Then
            If listNameFirst.Length > searchNameFirst.Length Then
                listNameFirst = listNameFirst.Substring(0, searchNameFirst.Length)
            Else
                searchNameFirst = searchNameFirst.Substring(0, listNameFirstLen)
            End If
        End If
        If (String.IsNullOrEmpty(listNameFirst)) Then
            If (String.Compare(listNameLast, searchNameLast) = 0) Then
                Return 1
            Else
                Return 0
            End If
        Else
            If (String.Compare(listNameLast, searchNameLast) = 0 And String.Compare(listNameFirst, searchNameFirst) = 0) Then
                Return 1
            Else
                Return 0
            End If
        End If
    End Function

    Private Sub availabilityTooltip_Popup(sender As Object, e As PopupEventArgs) Handles availabilityTooltip.Popup

    End Sub

    Private Sub availabilityCount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles availabilityCount.SelectedIndexChanged

    End Sub
End Class