<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Kaardirakendus
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
        Me.btnShowLines = New System.Windows.Forms.Button()
        Me.lBoxLiinid = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnShowLines
        '
        Me.btnShowLines.Location = New System.Drawing.Point(229, 31)
        Me.btnShowLines.Name = "btnShowLines"
        Me.btnShowLines.Size = New System.Drawing.Size(125, 52)
        Me.btnShowLines.TabIndex = 9
        Me.btnShowLines.Text = "Show lines"
        Me.btnShowLines.UseVisualStyleBackColor = True
        '
        'lBoxLiinid
        '
        Me.lBoxLiinid.FormattingEnabled = True
        Me.lBoxLiinid.Location = New System.Drawing.Point(231, 89)
        Me.lBoxLiinid.Name = "lBoxLiinid"
        Me.lBoxLiinid.Size = New System.Drawing.Size(123, 368)
        Me.lBoxLiinid.TabIndex = 10
        Me.lBoxLiinid.Visible = False
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 595)
        Me.Controls.Add(Me.lBoxLiinid)
        Me.Controls.Add(Me.btnShowLines)
        Me.Name = "Kaardirakendus"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnShowLines As Button
    Friend WithEvents lBoxLiinid As ListBox
End Class
