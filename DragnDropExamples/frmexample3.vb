Public Class frmexample3
    Dim strtemp As String
    Dim lbldragtypeques() As Label  'labels for dragtype question
    Dim lblplaceholder() As Label   'Place holder label in dragtype question
    Dim lblseldragtypeans() As Label 'Ans option label control for drag type question
    Dim IntDragNo As Integer

    Private Sub frmexample3_Load(sender As Object, e As EventArgs) Handles Me.Load
        strtemp = "import java.util.regex.*;" & vbCrLf & "public class test_reg" & vbCrLf & "{" & vbCrLf &
                  "public static void main(String args[])" & vbCrLf & "{" & vbCrLf &
                   "*************** p= *************** . *************** ( "" *************** "");" & vbCrLf & vbCrLf & " *************** m= *************** . matcher ( "" *************** "");" &
                   vbCrLf & vbCrLf & "boolean b=false;" & vbCrLf & vbCrLf & "while(b= *************** . find())" & vbCrLf & "{" & vbCrLf &
                   "System.out.println(m. *************** );" & "}" & vbCrLf & "}" & vbCrLf & "}" & vbCrLf & "Drag & Drop the following into appropriate places " &
                   vbCrLf & "to get the required output" & vbCrLf & "axx" & vbCrLf & "ax" & vbCrLf & "axx" & vbCrLf & "ax"
        Call displaydragtypeques()
        createctlforansopt()
    End Sub
    Private Sub displaydragtypeques()
        Dim strremaingstring As String
        Dim intspecilpoint As Short
        Dim Intcountvbcrlf As Integer
        Dim Intcountspecialchar As Integer
        Dim intmaxlenght As Short
        Dim i As Short
        Dim strlines As String
        Dim cntindex As Short
        Dim strquestion As String
        strquestion = strtemp
        strremaingstring = strquestion
        Intcountspecialchar = 0
        Intcountvbcrlf = 0

        'no of enter keys
        Do While Not InStr(1, strremaingstring, vbCrLf) = 0
            intspecilpoint = InStr(1, strremaingstring, vbCrLf, CompareMethod.Text)
            If intspecilpoint > intmaxlenght Then
                intmaxlenght = intspecilpoint
            End If
            strremaingstring = Mid(strremaingstring, intspecilpoint + 1)
            Intcountvbcrlf = Intcountvbcrlf + 1
        Loop
        'no of special character
        strremaingstring = strquestion
        Do While Not InStr(1, strremaingstring, "***************") = 0
            intspecilpoint = InStr(1, strremaingstring, "***************", CompareMethod.Text)
            strremaingstring = Mid(strremaingstring, intspecilpoint + 15)
            Intcountspecialchar = Intcountspecialchar + 1
        Loop
        'creating control for questions
        For i = 0 To Intcountvbcrlf
            ReDim Preserve lbldragtypeques(i)
            lbldragtypeques(i) = New Label
            lbldragtypeques(i).AutoSize = True
            lbldragtypeques(i).Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
            If i = 0 Then
                lbldragtypeques(i).Top = 13
                lbldragtypeques(i).Left = 17
            Else
                lbldragtypeques(i).Top = lbldragtypeques(i - 1).Top + lbldragtypeques(i - 1).Height
                lbldragtypeques(i).Left = lbldragtypeques(i - 1).Left
            End If
            Me.Controls.Add(lbldragtypeques(i))
        Next

        'creating control for placeholder
        For i = 0 To Intcountspecialchar
            ReDim Preserve lblplaceholder(i)
            lblplaceholder(i) = New Label
            lblplaceholder(i).AutoSize = True
            lblplaceholder(i).Name = "lblplaceholder" & i
            lblplaceholder(i).AllowDrop = True
            AddHandler lblplaceholder(i).DragDrop, AddressOf lblplaceholder_dragdrop
            AddHandler lblplaceholder(i).DragEnter, AddressOf lblplaceholder_dragenter
            Me.Controls.Add(lblplaceholder(i))
        Next

        'Displaying the question into the control
        strremaingstring = strquestion
        cntindex = 0
        IntDragNo = 0

        Do While Not strremaingstring = "" 'InStr(1, strremaingstring, vbCrLf) = 0
            intspecilpoint = InStr(1, strremaingstring, vbCrLf)
            strlines = Mid(strremaingstring, 1, IIf(intspecilpoint = 0, Len(strremaingstring), intspecilpoint - 1))
            Call displaythestring(Trim(strlines), cntindex)
            If intspecilpoint > 0 Then
                strremaingstring = Mid(strremaingstring, intspecilpoint + 1)
                cntindex = cntindex + 1
            Else
                strremaingstring = ""
            End If
        Loop
    End Sub
    Private Sub displaythestring(ByRef strline As String, ByRef ctrlindex As Short)
        Dim tempstr As String
        Dim intpoint As Short
        Dim strtempline As String
        tempstr = strline
        Do While Not tempstr = ""
            intpoint = InStr(1, tempstr, "***************", CompareMethod.Text)
            If intpoint = 0 Then
                tempstr = Replace(tempstr, vbCrLf, "")
                tempstr = Replace(tempstr, Chr(13), "")
                lbldragtypeques(ctrlindex).Text = lbldragtypeques(ctrlindex).Text & IIf(ctrlindex = 0, tempstr, Mid(tempstr, 2))
                Exit Sub
            End If
            strtempline = Mid(tempstr, 1, IIf(intpoint = 0, Len(tempstr), intpoint - 1))
            If Trim(strtempline) <> "" Then lbldragtypeques(ctrlindex).Text = lbldragtypeques(ctrlindex).Text & IIf(ctrlindex = 0, strtempline, Mid(strtempline, 2))
            lblplaceholder(IntDragNo).Top = lbldragtypeques(ctrlindex).Top
            lblplaceholder(IntDragNo).Left = lbldragtypeques(ctrlindex).Left + lbldragtypeques(ctrlindex).Width
            lblplaceholder(IntDragNo).Height = lbldragtypeques(ctrlindex).Height
            lblplaceholder(IntDragNo).Text = "PlaceHolder"
            lblplaceholder(IntDragNo).AutoSize = True
            lbldragtypeques(ctrlindex).Text = lbldragtypeques(ctrlindex).Text & Space(25)
            lblplaceholder(IntDragNo).BackColor = Color.Pink
            lblplaceholder(IntDragNo).ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            lblplaceholder(IntDragNo).BorderStyle = BorderStyle.FixedSingle
            lblplaceholder(IntDragNo).Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
            lblplaceholder(IntDragNo).BringToFront()
            IntDragNo = IntDragNo + 1
            If intpoint > 0 Then
                tempstr = Mid(tempstr, intpoint + 15)
            Else
                tempstr = ""
            End If
        Loop
    End Sub
    Private Sub lblseldragtypeans_mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
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
    Private Sub lblseldragtypeans_givefeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs)
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
    Private Sub createctlforansopt()
        ReDim lblseldragtypeans(12)
        For i = 0 To 11
            lblseldragtypeans(i) = New Label
            lblseldragtypeans(i).AutoSize = True
            lblseldragtypeans(i).Name = "lblseldragtypeans" & i + 1
            lblseldragtypeans(i).BorderStyle = BorderStyle.FixedSingle
            lblseldragtypeans(i).Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
            lblseldragtypeans(i).BackColor = Color.Plum
            AddHandler lblseldragtypeans(i).MouseDown, AddressOf lblseldragtypeans_mousedown
            AddHandler lblseldragtypeans(i).GiveFeedback, AddressOf lblseldragtypeans_givefeedback
            Me.grpansopt.Controls.Add(lblseldragtypeans(i))
        Next
        setthelocation()
    End Sub
    Private Sub setthelocation()
        lblseldragtypeans(0).Location = New Point(6, 15)
        lblseldragtypeans(0).Text = "start"
        lblseldragtypeans(1).Location = New Point(299, 15)
        lblseldragtypeans(1).Text = "matcher"
        lblseldragtypeans(2).Location = New Point(593, 15)
        lblseldragtypeans(2).Text = "Pattern"
        lblseldragtypeans(3).Location = New Point(6, 43)
        lblseldragtypeans(3).Text = "m"
        lblseldragtypeans(4).Location = New Point(299, 43)
        lblseldragtypeans(4).Text = "[a][x]+"
        lblseldragtypeans(5).Location = New Point(593, 43)
        lblseldragtypeans(5).Text = "p"
        lblseldragtypeans(6).Location = New Point(6, 71)
        lblseldragtypeans(6).Text = "compile"
        lblseldragtypeans(7).Location = New Point(299, 71)
        lblseldragtypeans(7).Text = "Matcher"
        lblseldragtypeans(8).Location = New Point(593, 71)
        lblseldragtypeans(8).Text = "pattern"
        lblseldragtypeans(9).Location = New Point(6, 98)
        lblseldragtypeans(9).Text = "axxaxaxxax"
        lblseldragtypeans(10).Location = New Point(299, 98)
        lblseldragtypeans(10).Text = "group()"
        lblseldragtypeans(11).Location = New Point(593, 98)
        lblseldragtypeans(11).Text = "ax"
    End Sub

    Private Sub frmexample3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim UnloadMode As System.Windows.Forms.CloseReason = e.CloseReason
        If UnloadMode = System.Windows.Forms.CloseReason.UserClosing Then
            Application.Exit()
        End If
    End Sub
End Class