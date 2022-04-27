Public Class frmexample2
    Dim lblqus() As Label
    Dim lblplaceholder() As Label
    Dim lblansopt() As Label

    Private Sub frmexample2_Load(sender As Object, e As EventArgs) Handles Me.Load
        create_controlforques()
        create_controlforplaceholder()
        create_ansoptioncontrol()
    End Sub
    Private Sub create_controlforques()
        Dim i As Integer
        ReDim lblqus(6)
        For i = 0 To 5
            lblqus(i) = New Label()
            lblqus(i).Name = "lblqus" & i + 1
            lblqus(i).AutoSize = True
            lblqus(i).Size = New Size(74, 18)
            lblqus(i).Visible = True
            lblqus(i).BorderStyle = BorderStyle.FixedSingle
            lblqus(i).Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
            lblqus(i).BackColor = Color.MistyRose
            Me.Controls.Add(lblqus(i))
        Next
        'set the location
        lblqus(0).Location = New Point(26, 25)
        lblqus(0).Text = "India"
        lblqus(1).Location = New Point(26, 61)
        lblqus(1).Text = "Pakistan"
        lblqus(2).Location = New Point(26, 95)
        lblqus(2).Text = "USA"
        lblqus(3).Location = New Point(26, 130)
        lblqus(3).Text = "Canada"
        lblqus(4).Location = New Point(26, 162)
        lblqus(4).Text = "Russia"
        lblqus(5).Location = New Point(26, 197)
        lblqus(5).Text = "Itally"
    End Sub
    Private Sub create_controlforplaceholder()
        Dim i As Integer
        ReDim lblplaceholder(6)
        For i = 0 To 5
            lblplaceholder(i) = New Label()
            lblplaceholder(i).Name = "lblplaceholder" & i + 1
            lblplaceholder(i).AutoSize = True
            lblplaceholder(i).Size = New Size(83, 18)
            lblplaceholder(i).Visible = True
            lblplaceholder(i).BorderStyle = BorderStyle.FixedSingle
            lblplaceholder(i).Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
            lblplaceholder(i).BackColor = Color.SkyBlue
            lblplaceholder(i).AllowDrop = True
            lblplaceholder(i).Text = "Placeholder"
            Me.Controls.Add(lblplaceholder(i))
            AddHandler lblplaceholder(i).DragDrop, AddressOf lblplaceholder_dragdrop
            AddHandler lblplaceholder(i).DragEnter, AddressOf lblplaceholder_dragenter
        Next
        'set the location
        lblplaceholder(0).Location = New Point(157, 25)
        lblplaceholder(1).Location = New Point(157, 61)
        lblplaceholder(2).Location = New Point(157, 95)
        lblplaceholder(3).Location = New Point(157, 130)
        lblplaceholder(4).Location = New Point(157, 162)
        lblplaceholder(5).Location = New Point(157, 197)
    End Sub
    Private Sub create_ansoptioncontrol()
        Dim i As Integer
        ReDim lblansopt(8)
        For i = 0 To 7
            lblansopt(i) = New Label
            lblansopt(i).AutoSize = True
            lblansopt(i).Size = New Size(83, 18)
            lblansopt(i).Visible = True
            lblansopt(i).BorderStyle = BorderStyle.FixedSingle
            lblansopt(i).Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
            lblansopt(i).Name = "lblansopt" & i + 1
            lblansopt(i).BackColor = Color.Plum
            AddHandler lblansopt(i).MouseDown, AddressOf lblansopt_mousedown
            AddHandler lblansopt(i).GiveFeedback, AddressOf lblansopt_givefeedback
            Me.Controls.Add(lblansopt(i))
        Next
        'set the location
        lblansopt(0).Location = New Point(61, 265)
        lblansopt(0).Text = "Chennai"
        lblansopt(1).Location = New Point(157, 265)
        lblansopt(1).Text = "Delhi"
        lblansopt(2).Location = New Point(252, 265)
        lblansopt(2).Text = "Rom"
        lblansopt(3).Location = New Point(354, 265)
        lblansopt(3).Text = "Islamabad"
        lblansopt(4).Location = New Point(61, 299)
        lblansopt(4).Text = "Ottawa"
        lblansopt(5).Location = New Point(157, 299)
        lblansopt(5).Text = "Manila"
        lblansopt(6).Location = New Point(255, 299)
        lblansopt(6).Text = "Moscow"
        lblansopt(7).Location = New Point(354, 299)
        lblansopt(7).Text = "Washington"
    End Sub
    Private Sub lblansopt_mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim lblselans As Label = sender
        lblselans.DoDragDrop(lblselans, DragDropEffects.Copy)
    End Sub

    Private Sub lblplaceholder_dragenter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim lblplace As Label = sender
        If e.Data.GetDataPresent(GetType(Label)) Then
            ' There is Label data. Allow copy.
            e.Effect = DragDropEffects.Copy
            lblplace.BorderStyle = BorderStyle.FixedSingle
        Else
            ' There is no Label. Prohibit drop.
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub lblansopt_givefeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs)
        e.UseDefaultCursors = False

        If ((e.Effect And DragDropEffects.Move) = DragDropEffects.Move) Then
            Cursor.Current = New Cursor(Me.Icon.Handle)
        Else
            Cursor.Current = System.Windows.Forms.Cursors.Hand   'System.Windows.Forms.Cursors.Default
        End If
    End Sub
    Private Sub lblplaceholder_dragdrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim lbl As Label = DirectCast(e.Data.GetData(GetType(Label)), Label)
        Dim tempstr As String
        tempstr = lbl.Text
        Dim lblplace As Label = sender
        lblplace.BorderStyle = BorderStyle.FixedSingle
        lblplace.Text = tempstr
        lblplace.Tag = lbl.Tag
        lblplace.BackColor = lbl.BackColor
        lblplace.AutoSize = True
    End Sub

    Private Sub frmexample2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim UnloadMode As System.Windows.Forms.CloseReason = e.CloseReason
        If UnloadMode = System.Windows.Forms.CloseReason.UserClosing Then
            Application.Exit()
        End If
    End Sub
End Class