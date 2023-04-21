<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UTimeTable
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
        Me.lBoxRealTime = New System.Windows.Forms.ListBox()
        Me.btnShowStops = New System.Windows.Forms.Button()
        Me.lBoxAjad = New System.Windows.Forms.ListBox()
        Me.tBoxLink = New System.Windows.Forms.TextBox()
        Me.btnBA = New System.Windows.Forms.Button()
        Me.btnAB = New System.Windows.Forms.Button()
        Me.lBoxPeatused = New System.Windows.Forms.ListBox()
        Me.lBoxLiinid = New System.Windows.Forms.ListBox()
        Me.btnShowLines = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lBoxRealTime
        '
        Me.lBoxRealTime.FormattingEnabled = True
        Me.lBoxRealTime.Location = New System.Drawing.Point(459, 107)
        Me.lBoxRealTime.Name = "lBoxRealTime"
        Me.lBoxRealTime.Size = New System.Drawing.Size(95, 56)
        Me.lBoxRealTime.TabIndex = 29
        Me.lBoxRealTime.Visible = False
        '
        'btnShowStops
        '
        Me.btnShowStops.Location = New System.Drawing.Point(3, 31)
        Me.btnShowStops.Name = "btnShowStops"
        Me.btnShowStops.Size = New System.Drawing.Size(125, 23)
        Me.btnShowStops.TabIndex = 28
        Me.btnShowStops.Text = "Show all stops"
        Me.btnShowStops.UseVisualStyleBackColor = True
        '
        'lBoxAjad
        '
        Me.lBoxAjad.FormattingEnabled = True
        Me.lBoxAjad.Location = New System.Drawing.Point(245, 107)
        Me.lBoxAjad.Name = "lBoxAjad"
        Me.lBoxAjad.Size = New System.Drawing.Size(208, 264)
        Me.lBoxAjad.TabIndex = 27
        Me.lBoxAjad.Visible = False
        '
        'tBoxLink
        '
        Me.tBoxLink.Location = New System.Drawing.Point(3, 384)
        Me.tBoxLink.Name = "tBoxLink"
        Me.tBoxLink.Size = New System.Drawing.Size(259, 20)
        Me.tBoxLink.TabIndex = 26
        '
        'btnBA
        '
        Me.btnBA.Location = New System.Drawing.Point(144, 31)
        Me.btnBA.Name = "btnBA"
        Me.btnBA.Size = New System.Drawing.Size(329, 23)
        Me.btnBA.TabIndex = 25
        Me.btnBA.UseVisualStyleBackColor = True
        Me.btnBA.Visible = False
        '
        'btnAB
        '
        Me.btnAB.Location = New System.Drawing.Point(144, 2)
        Me.btnAB.Name = "btnAB"
        Me.btnAB.Size = New System.Drawing.Size(329, 23)
        Me.btnAB.TabIndex = 24
        Me.btnAB.UseVisualStyleBackColor = True
        Me.btnAB.Visible = False
        '
        'lBoxPeatused
        '
        Me.lBoxPeatused.FormattingEnabled = True
        Me.lBoxPeatused.Location = New System.Drawing.Point(109, 107)
        Me.lBoxPeatused.Name = "lBoxPeatused"
        Me.lBoxPeatused.Size = New System.Drawing.Size(130, 264)
        Me.lBoxPeatused.TabIndex = 23
        Me.lBoxPeatused.Visible = False
        '
        'lBoxLiinid
        '
        Me.lBoxLiinid.FormattingEnabled = True
        Me.lBoxLiinid.Location = New System.Drawing.Point(3, 107)
        Me.lBoxLiinid.Name = "lBoxLiinid"
        Me.lBoxLiinid.Size = New System.Drawing.Size(100, 264)
        Me.lBoxLiinid.TabIndex = 22
        Me.lBoxLiinid.Visible = False
        '
        'btnShowLines
        '
        Me.btnShowLines.Location = New System.Drawing.Point(3, 2)
        Me.btnShowLines.Name = "btnShowLines"
        Me.btnShowLines.Size = New System.Drawing.Size(125, 23)
        Me.btnShowLines.TabIndex = 21
        Me.btnShowLines.Text = "Show all lines"
        Me.btnShowLines.UseVisualStyleBackColor = True
        '
        'UTimeTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lBoxRealTime)
        Me.Controls.Add(Me.btnShowStops)
        Me.Controls.Add(Me.lBoxAjad)
        Me.Controls.Add(Me.tBoxLink)
        Me.Controls.Add(Me.btnBA)
        Me.Controls.Add(Me.btnAB)
        Me.Controls.Add(Me.lBoxPeatused)
        Me.Controls.Add(Me.lBoxLiinid)
        Me.Controls.Add(Me.btnShowLines)
        Me.Name = "UTimeTable"
        Me.Size = New System.Drawing.Size(559, 406)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lBoxRealTime As ListBox
    Friend WithEvents btnShowStops As Button
    Friend WithEvents lBoxAjad As ListBox
    Friend WithEvents tBoxLink As TextBox
    Friend WithEvents btnBA As Button
    Friend WithEvents btnAB As Button
    Friend WithEvents lBoxPeatused As ListBox
    Friend WithEvents lBoxLiinid As ListBox
    Friend WithEvents btnShowLines As Button
End Class
