<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.UTimeTable1 = New UTimeTable.UTimeTable()
        Me.SuspendLayout()
        '
        'UTimeTable1
        '
        Me.UTimeTable1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UTimeTable1.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.UTimeTable1.Location = New System.Drawing.Point(77, 12)
        Me.UTimeTable1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.UTimeTable1.Name = "UTimeTable1"
        Me.UTimeTable1.Size = New System.Drawing.Size(632, 652)
        Me.UTimeTable1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 711)
        Me.Controls.Add(Me.UTimeTable1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UTimeTable1 As UTimeTable.UTimeTable
End Class
