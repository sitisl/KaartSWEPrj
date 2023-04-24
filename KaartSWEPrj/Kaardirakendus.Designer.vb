<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Kaardirakendus
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnDisplayStops = New System.Windows.Forms.Button()
        Me.UCtrlMapViewer = New UCtrlMapViewer.UCtrlMapViewer()
        Me.UTimeTable = New UTimeTable.UTimeTable()
        Me.SuspendLayout()
        '
        'btnDisplayStops
        '
        Me.btnDisplayStops.Location = New System.Drawing.Point(12, 12)
        Me.btnDisplayStops.Name = "btnDisplayStops"
        Me.btnDisplayStops.Size = New System.Drawing.Size(112, 41)
        Me.btnDisplayStops.TabIndex = 23
        Me.btnDisplayStops.Text = "Display all stops"
        Me.btnDisplayStops.UseVisualStyleBackColor = True
        '
        'UCtrlMapViewer
        '
        Me.UCtrlMapViewer.BackColor = System.Drawing.Color.Transparent
        Me.UCtrlMapViewer.Location = New System.Drawing.Point(130, 12)
        Me.UCtrlMapViewer.Name = "UCtrlMapViewer"
        Me.UCtrlMapViewer.Size = New System.Drawing.Size(757, 406)
        Me.UCtrlMapViewer.TabIndex = 24
        '
        'UTimeTable
        '
        Me.UTimeTable.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.UTimeTable.Location = New System.Drawing.Point(893, 12)
        Me.UTimeTable.Name = "UTimeTable"
        Me.UTimeTable.Size = New System.Drawing.Size(559, 406)
        Me.UTimeTable.TabIndex = 21
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1464, 595)
        Me.Controls.Add(Me.UCtrlMapViewer)
        Me.Controls.Add(Me.btnDisplayStops)
        Me.Controls.Add(Me.UTimeTable)
        Me.Name = "Kaardirakendus"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UTimeTable As UTimeTable.UTimeTable
    Friend WithEvents UCtrlMapViewer1 As UCtrlMapViewer.UCtrlMapViewer
    Friend WithEvents btnDisplayStops As Button
    Friend WithEvents UCtrlMapViewer As UCtrlMapViewer.UCtrlMapViewer
End Class
