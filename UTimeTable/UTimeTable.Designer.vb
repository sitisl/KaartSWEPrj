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
        Me.btnBA = New System.Windows.Forms.Button()
        Me.btnAB = New System.Windows.Forms.Button()
        Me.lBoxPeatused = New System.Windows.Forms.ListBox()
        Me.lBoxLiinid = New System.Windows.Forms.ListBox()
        Me.rtbAjad = New System.Windows.Forms.RichTextBox()
        Me.lblLiinid = New System.Windows.Forms.Label()
        Me.lblPeatused = New System.Windows.Forms.Label()
        Me.lblAjad = New System.Windows.Forms.Label()
        Me.lblReaalajad = New System.Windows.Forms.Label()
        Me.lblAbi = New System.Windows.Forms.Label()
        Me.btnShowLines = New System.Windows.Forms.Button()
        Me.btnShowStops = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lBoxRealTime
        '
        Me.lBoxRealTime.FormattingEnabled = True
        Me.lBoxRealTime.Location = New System.Drawing.Point(297, 388)
        Me.lBoxRealTime.Name = "lBoxRealTime"
        Me.lBoxRealTime.Size = New System.Drawing.Size(110, 56)
        Me.lBoxRealTime.TabIndex = 29
        Me.lBoxRealTime.Visible = False
        '
        'btnBA
        '
        Me.btnBA.Location = New System.Drawing.Point(144, 31)
        Me.btnBA.Name = "btnBA"
        Me.btnBA.Size = New System.Drawing.Size(335, 23)
        Me.btnBA.TabIndex = 25
        Me.btnBA.UseVisualStyleBackColor = True
        Me.btnBA.Visible = False
        '
        'btnAB
        '
        Me.btnAB.Location = New System.Drawing.Point(144, 2)
        Me.btnAB.Name = "btnAB"
        Me.btnAB.Size = New System.Drawing.Size(335, 23)
        Me.btnAB.TabIndex = 24
        Me.btnAB.UseVisualStyleBackColor = True
        Me.btnAB.Visible = False
        '
        'lBoxPeatused
        '
        Me.lBoxPeatused.FormattingEnabled = True
        Me.lBoxPeatused.Location = New System.Drawing.Point(109, 76)
        Me.lBoxPeatused.Name = "lBoxPeatused"
        Me.lBoxPeatused.Size = New System.Drawing.Size(130, 368)
        Me.lBoxPeatused.TabIndex = 23
        Me.lBoxPeatused.Visible = False
        '
        'lBoxLiinid
        '
        Me.lBoxLiinid.FormattingEnabled = True
        Me.lBoxLiinid.Location = New System.Drawing.Point(3, 76)
        Me.lBoxLiinid.Name = "lBoxLiinid"
        Me.lBoxLiinid.Size = New System.Drawing.Size(100, 368)
        Me.lBoxLiinid.TabIndex = 22
        Me.lBoxLiinid.Visible = False
        '
        'rtbAjad
        '
        Me.rtbAjad.BackColor = System.Drawing.SystemColors.Window
        Me.rtbAjad.DetectUrls = False
        Me.rtbAjad.Location = New System.Drawing.Point(245, 76)
        Me.rtbAjad.Name = "rtbAjad"
        Me.rtbAjad.ReadOnly = True
        Me.rtbAjad.Size = New System.Drawing.Size(234, 264)
        Me.rtbAjad.TabIndex = 30
        Me.rtbAjad.Text = ""
        Me.rtbAjad.Visible = False
        '
        'lblLiinid
        '
        Me.lblLiinid.AutoSize = True
        Me.lblLiinid.Location = New System.Drawing.Point(27, 60)
        Me.lblLiinid.Name = "lblLiinid"
        Me.lblLiinid.Size = New System.Drawing.Size(31, 13)
        Me.lblLiinid.TabIndex = 31
        Me.lblLiinid.Text = "Liinid"
        Me.lblLiinid.Visible = False
        '
        'lblPeatused
        '
        Me.lblPeatused.AutoSize = True
        Me.lblPeatused.Location = New System.Drawing.Point(141, 60)
        Me.lblPeatused.Name = "lblPeatused"
        Me.lblPeatused.Size = New System.Drawing.Size(52, 13)
        Me.lblPeatused.TabIndex = 32
        Me.lblPeatused.Text = "Peatused"
        Me.lblPeatused.Visible = False
        '
        'lblAjad
        '
        Me.lblAjad.AutoSize = True
        Me.lblAjad.Location = New System.Drawing.Point(349, 60)
        Me.lblAjad.Name = "lblAjad"
        Me.lblAjad.Size = New System.Drawing.Size(28, 13)
        Me.lblAjad.TabIndex = 33
        Me.lblAjad.Text = "Ajad"
        Me.lblAjad.Visible = False
        '
        'lblReaalajad
        '
        Me.lblReaalajad.AutoSize = True
        Me.lblReaalajad.Location = New System.Drawing.Point(322, 372)
        Me.lblReaalajad.Name = "lblReaalajad"
        Me.lblReaalajad.Size = New System.Drawing.Size(55, 13)
        Me.lblReaalajad.TabIndex = 34
        Me.lblReaalajad.Text = "Reaalajad"
        Me.lblReaalajad.Visible = False
        '
        'lblAbi
        '
        Me.lblAbi.AutoSize = True
        Me.lblAbi.Location = New System.Drawing.Point(284, 343)
        Me.lblAbi.Name = "lblAbi"
        Me.lblAbi.Size = New System.Drawing.Size(142, 13)
        Me.lblAbi.TabIndex = 35
        Me.lblAbi.Text = "Madala sisenemisega sõiduk"
        Me.lblAbi.Visible = False
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
        'btnShowStops
        '
        Me.btnShowStops.Location = New System.Drawing.Point(3, 31)
        Me.btnShowStops.Name = "btnShowStops"
        Me.btnShowStops.Size = New System.Drawing.Size(125, 23)
        Me.btnShowStops.TabIndex = 28
        Me.btnShowStops.Text = "Show all stops"
        Me.btnShowStops.UseVisualStyleBackColor = True
        '
        'UTimeTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblAbi)
        Me.Controls.Add(Me.lblReaalajad)
        Me.Controls.Add(Me.lblAjad)
        Me.Controls.Add(Me.lblPeatused)
        Me.Controls.Add(Me.lblLiinid)
        Me.Controls.Add(Me.rtbAjad)
        Me.Controls.Add(Me.lBoxRealTime)
        Me.Controls.Add(Me.btnShowStops)
        Me.Controls.Add(Me.btnBA)
        Me.Controls.Add(Me.btnAB)
        Me.Controls.Add(Me.lBoxPeatused)
        Me.Controls.Add(Me.lBoxLiinid)
        Me.Controls.Add(Me.btnShowLines)
        Me.Name = "UTimeTable"
        Me.Size = New System.Drawing.Size(486, 456)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lBoxRealTime As ListBox
    Friend WithEvents btnBA As Button
    Friend WithEvents btnAB As Button
    Friend WithEvents lBoxPeatused As ListBox
    Friend WithEvents lBoxLiinid As ListBox
    Friend WithEvents rtbAjad As RichTextBox
    Friend WithEvents lblLiinid As Label
    Friend WithEvents lblPeatused As Label
    Friend WithEvents lblAjad As Label
    Friend WithEvents lblReaalajad As Label
    Friend WithEvents lblAbi As Label
    Friend WithEvents btnShowLines As Button
    Friend WithEvents btnShowStops As Button
End Class
