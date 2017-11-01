Public Class LoadingBar
    Dim value As Double
    Private Sub percentDone_Click(sender As Object, e As EventArgs) Handles percentDone.Click

    End Sub

    Private Sub progressBar_Click(sender As Object, e As EventArgs) Handles progressBar.Click

    End Sub

    Private Sub LoadingBar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        progressBar.Value = 0
        percentDone.Text = "0% Completed"
    End Sub

    Public Sub increaseProgress(amount As Integer)
        progressBar.Increment(amount)
        value = (progressBar.Value / progressBar.Maximum) * 100
        percentDone.Text = FormatNumber(CDbl(value.ToString), 0) + "% Completed"
        If progressBar.Value = progressBar.Maximum Then
            progressBar.Value = 0
            Me.Close()
        End If
    End Sub

    Public Sub setMaximum(max As Integer)
        progressBar.Maximum = max
    End Sub

    Public Function getMax()
        Return progressBar.Maximum
    End Function

    Public Function getValue()
        Return progressBar.Value
    End Function
End Class