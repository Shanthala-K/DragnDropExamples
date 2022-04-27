<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmexample3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpansopt = New System.Windows.Forms.GroupBox()
        Me.SuspendLayout()
        '
        'grpansopt
        '
        Me.grpansopt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpansopt.Location = New System.Drawing.Point(2, 407)
        Me.grpansopt.Name = "grpansopt"
        Me.grpansopt.Size = New System.Drawing.Size(769, 121)
        Me.grpansopt.TabIndex = 2
        Me.grpansopt.TabStop = False
        '
        'frmexample3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 528)
        Me.Controls.Add(Me.grpansopt)
        Me.Name = "frmexample3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DragnDropExample3"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpansopt As GroupBox
End Class
