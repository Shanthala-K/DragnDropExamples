Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frex1 As New frmexample1
        frex1.Show()
        Me.Dispose(False)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frex2 As New frmexample2
        frex2.Show()
        Me.Dispose(False)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frex3 As New frmexample3
        frex3.Show()
        Me.Dispose(False)
    End Sub
End Class
