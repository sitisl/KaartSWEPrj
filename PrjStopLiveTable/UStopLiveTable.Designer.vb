<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UStopLiveTable
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.lBoxLiinid = New System.Windows.Forms.ListBox()
        Me.lblPeatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lBoxLiinid
        '
        Me.lBoxLiinid.FormattingEnabled = True
        Me.lBoxLiinid.Location = New System.Drawing.Point(0, 28)
        Me.lBoxLiinid.Name = "lBoxLiinid"
        Me.lBoxLiinid.Size = New System.Drawing.Size(274, 134)
        Me.lBoxLiinid.TabIndex = 22
        Me.lBoxLiinid.Visible = False
        '
        'lblPeatus
        '
        Me.lblPeatus.AutoSize = True
        Me.lblPeatus.Location = New System.Drawing.Point(3, 12)
        Me.lblPeatus.Name = "lblPeatus"
        Me.lblPeatus.Size = New System.Drawing.Size(40, 13)
        Me.lblPeatus.TabIndex = 31
        Me.lblPeatus.Text = "Peatus"
        Me.lblPeatus.Visible = False
        '
        'UStopLiveTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblPeatus)
        Me.Controls.Add(Me.lBoxLiinid)
        Me.Name = "UStopLiveTable"
        Me.Size = New System.Drawing.Size(284, 166)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lBoxLiinid As ListBox
    Friend WithEvents lblPeatus As Label
End Class
