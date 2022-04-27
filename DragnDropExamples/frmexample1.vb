Public Class frmexample1
    Dim MouseIsDown As Boolean
    Dim m_MouseIsDown As Boolean

    Private Sub TextBox1_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles TextBox1.GiveFeedback
        e.UseDefaultCursors = False

        If ((e.Effect And DragDropEffects.Move) = DragDropEffects.Move) Then
            Cursor.Current = New Cursor(Me.Icon.Handle)
        Else
            Cursor.Current = System.Windows.Forms.Cursors.Hand   'System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub TextBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDown
        ' Set a flag to show that the mouse is down.
        MouseIsDown = True
    End Sub

    Private Sub TextBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseMove
        If MouseIsDown Then
            ' Initiate dragging.
            TextBox1.DoDragDrop(TextBox1.Text, DragDropEffects.Copy)
        End If
        MouseIsDown = False
    End Sub

    Private Sub TextBox2_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox2.DragDrop
        ' Paste the text.
        TextBox2.Text = e.Data.GetData(DataFormats.Text)
    End Sub

    Private Sub TextBox2_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox2.DragEnter
        ' Check the format of the data being dropped.
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        If Not PictureBox1.Image Is Nothing Then
            ' Set a flag to show that the mouse is down.
            m_MouseIsDown = True
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If m_MouseIsDown Then
            ' Initiate dragging and allow either copy or move.
            PictureBox1.DoDragDrop(PictureBox1.Image, DragDropEffects.Copy Or DragDropEffects.Move)
        End If
        m_MouseIsDown = False
    End Sub

    Private Sub PictureBox2_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox2.DragDrop
        ' Assign the image to the PictureBox.
        PictureBox2.Image = e.Data.GetData(DataFormats.Bitmap)
        ' If the CTRL key is not pressed, delete the source picture.
        If Not e.KeyState = 8 Then
            PictureBox1.Image = Nothing
        End If
    End Sub

    Private Sub PictureBox2_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox2.DragEnter
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            ' Check for the CTRL key. 
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub frmexample1_Load(sender As Object, e As EventArgs) Handles Me.Load
        PictureBox2.AllowDrop = True
    End Sub

    Private Sub frmexample1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim UnloadMode As System.Windows.Forms.CloseReason = e.CloseReason
        If UnloadMode = System.Windows.Forms.CloseReason.UserClosing Then
            Application.Exit()
        End If
    End Sub
End Class