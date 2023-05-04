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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSuund = New System.Windows.Forms.Label()
        Me.btnDay1 = New System.Windows.Forms.Button()
        Me.btnDay2 = New System.Windows.Forms.Button()
        Me.btnDay3 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnDisplayLine = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lBoxRealTime
        '
        Me.lBoxRealTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lBoxRealTime.FormattingEnabled = True
        Me.lBoxRealTime.ItemHeight = 20
        Me.lBoxRealTime.Location = New System.Drawing.Point(336, 516)
        Me.lBoxRealTime.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.lBoxRealTime.Name = "lBoxRealTime"
        Me.lBoxRealTime.Size = New System.Drawing.Size(270, 84)
        Me.lBoxRealTime.TabIndex = 29
        '
        'btnBA
        '
        Me.btnBA.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBA.Location = New System.Drawing.Point(226, 37)
        Me.btnBA.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnBA.Name = "btnBA"
        Me.btnBA.Size = New System.Drawing.Size(374, 27)
        Me.btnBA.TabIndex = 25
        Me.btnBA.UseVisualStyleBackColor = True
        '
        'btnAB
        '
        Me.btnAB.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAB.Location = New System.Drawing.Point(226, 3)
        Me.btnAB.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnAB.Name = "btnAB"
        Me.btnAB.Size = New System.Drawing.Size(374, 27)
        Me.btnAB.TabIndex = 24
        Me.btnAB.UseVisualStyleBackColor = True
        '
        'lBoxPeatused
        '
        Me.lBoxPeatused.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lBoxPeatused.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lBoxPeatused.FormattingEnabled = True
        Me.lBoxPeatused.HorizontalScrollbar = True
        Me.lBoxPeatused.ItemHeight = 20
        Me.lBoxPeatused.Location = New System.Drawing.Point(148, 35)
        Me.lBoxPeatused.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.lBoxPeatused.Name = "lBoxPeatused"
        Me.lBoxPeatused.Size = New System.Drawing.Size(170, 482)
        Me.lBoxPeatused.TabIndex = 23
        '
        'lBoxLiinid
        '
        Me.lBoxLiinid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lBoxLiinid.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lBoxLiinid.FormattingEnabled = True
        Me.lBoxLiinid.ItemHeight = 20
        Me.lBoxLiinid.Location = New System.Drawing.Point(4, 35)
        Me.lBoxLiinid.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.lBoxLiinid.Name = "lBoxLiinid"
        Me.lBoxLiinid.Size = New System.Drawing.Size(136, 482)
        Me.lBoxLiinid.TabIndex = 22
        '
        'rtbAjad
        '
        Me.rtbAjad.BackColor = System.Drawing.SystemColors.Window
        Me.rtbAjad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbAjad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.rtbAjad.DetectUrls = False
        Me.rtbAjad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rtbAjad.Location = New System.Drawing.Point(336, 150)
        Me.rtbAjad.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rtbAjad.Name = "rtbAjad"
        Me.rtbAjad.ReadOnly = True
        Me.rtbAjad.Size = New System.Drawing.Size(274, 321)
        Me.rtbAjad.TabIndex = 30
        Me.rtbAjad.Text = ""
        '
        'lblLiinid
        '
        Me.lblLiinid.AutoSize = True
        Me.lblLiinid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLiinid.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLiinid.Location = New System.Drawing.Point(4, 0)
        Me.lblLiinid.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLiinid.Name = "lblLiinid"
        Me.lblLiinid.Size = New System.Drawing.Size(136, 32)
        Me.lblLiinid.TabIndex = 31
        Me.lblLiinid.Text = "Liinid"
        Me.lblLiinid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPeatused
        '
        Me.lblPeatused.AutoSize = True
        Me.lblPeatused.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPeatused.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeatused.Location = New System.Drawing.Point(148, 0)
        Me.lblPeatused.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPeatused.Name = "lblPeatused"
        Me.lblPeatused.Size = New System.Drawing.Size(170, 32)
        Me.lblPeatused.TabIndex = 32
        Me.lblPeatused.Text = "Peatused"
        Me.lblPeatused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAjad
        '
        Me.lblAjad.AutoSize = True
        Me.lblAjad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAjad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAjad.Location = New System.Drawing.Point(94, 0)
        Me.lblAjad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAjad.Name = "lblAjad"
        Me.lblAjad.Size = New System.Drawing.Size(82, 31)
        Me.lblAjad.TabIndex = 33
        Me.lblAjad.Text = "Ajad"
        Me.lblAjad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblReaalajad
        '
        Me.lblReaalajad.AutoSize = True
        Me.lblReaalajad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblReaalajad.Location = New System.Drawing.Point(432, 494)
        Me.lblReaalajad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReaalajad.Name = "lblReaalajad"
        Me.lblReaalajad.Size = New System.Drawing.Size(75, 20)
        Me.lblReaalajad.TabIndex = 34
        Me.lblReaalajad.Text = "Reaalajad"
        Me.lblReaalajad.Visible = False
        '
        'lblAbi
        '
        Me.lblAbi.AutoSize = True
        Me.lblAbi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAbi.Location = New System.Drawing.Point(388, 474)
        Me.lblAbi.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAbi.Name = "lblAbi"
        Me.lblAbi.Size = New System.Drawing.Size(198, 20)
        Me.lblAbi.TabIndex = 35
        Me.lblAbi.Text = "Madala sisenemisega sõiduk"
        Me.lblAbi.Visible = False
        '
        'btnShowLines
        '
        Me.btnShowLines.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowLines.Location = New System.Drawing.Point(4, 3)
        Me.btnShowLines.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnShowLines.Name = "btnShowLines"
        Me.btnShowLines.Size = New System.Drawing.Size(149, 27)
        Me.btnShowLines.TabIndex = 21
        Me.btnShowLines.Text = "Kuva kõik liinid"
        Me.btnShowLines.UseVisualStyleBackColor = True
        '
        'btnShowStops
        '
        Me.btnShowStops.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowStops.Location = New System.Drawing.Point(4, 37)
        Me.btnShowStops.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnShowStops.Name = "btnShowStops"
        Me.btnShowStops.Size = New System.Drawing.Size(149, 27)
        Me.btnShowStops.TabIndex = 28
        Me.btnShowStops.Text = "Kuva kõik peatused"
        Me.btnShowStops.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.04502!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.7717!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.18328!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowLines, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowStops, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnBA, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAB, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSuund, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 12)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(604, 69)
        Me.TableLayoutPanel1.TabIndex = 36
        '
        'lblSuund
        '
        Me.lblSuund.AutoSize = True
        Me.lblSuund.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSuund.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSuund.Location = New System.Drawing.Point(161, 0)
        Me.lblSuund.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSuund.Name = "lblSuund"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblSuund, 2)
        Me.lblSuund.Size = New System.Drawing.Size(57, 69)
        Me.lblSuund.TabIndex = 37
        Me.lblSuund.Text = "Suund:"
        Me.lblSuund.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDay1
        '
        Me.btnDay1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDay1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDay1.Location = New System.Drawing.Point(4, 33)
        Me.btnDay1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btnDay1.Name = "btnDay1"
        Me.btnDay1.Size = New System.Drawing.Size(82, 27)
        Me.btnDay1.TabIndex = 37
        Me.btnDay1.Text = "Tööpäev"
        Me.btnDay1.UseVisualStyleBackColor = True
        '
        'btnDay2
        '
        Me.btnDay2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDay2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDay2.Location = New System.Drawing.Point(94, 33)
        Me.btnDay2.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btnDay2.Name = "btnDay2"
        Me.btnDay2.Size = New System.Drawing.Size(82, 27)
        Me.btnDay2.TabIndex = 38
        Me.btnDay2.Text = "Laupäev"
        Me.btnDay2.UseVisualStyleBackColor = True
        '
        'btnDay3
        '
        Me.btnDay3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDay3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDay3.Location = New System.Drawing.Point(184, 33)
        Me.btnDay3.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btnDay3.Name = "btnDay3"
        Me.btnDay3.Size = New System.Drawing.Size(84, 27)
        Me.btnDay3.TabIndex = 39
        Me.btnDay3.Text = "Pühapäev"
        Me.btnDay3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnDay1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnDay2, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnDay3, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblAjad, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(338, 85)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(272, 62)
        Me.TableLayoutPanel2.TabIndex = 40
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lBoxPeatused, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lBoxLiinid, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblPeatused, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblLiinid, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(6, 83)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.163328!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.83667!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(322, 521)
        Me.TableLayoutPanel3.TabIndex = 41
        '
        'btnDisplayLine
        '
        Me.btnDisplayLine.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDisplayLine.Location = New System.Drawing.Point(10, 606)
        Me.btnDisplayLine.Name = "btnDisplayLine"
        Me.btnDisplayLine.Size = New System.Drawing.Size(136, 31)
        Me.btnDisplayLine.TabIndex = 42
        Me.btnDisplayLine.Text = "Kuva liin kaardil"
        Me.btnDisplayLine.UseVisualStyleBackColor = True
        '
        'UTimeTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.btnDisplayLine)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblAbi)
        Me.Controls.Add(Me.lblReaalajad)
        Me.Controls.Add(Me.rtbAjad)
        Me.Controls.Add(Me.lBoxRealTime)
        Me.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "UTimeTable"
        Me.Size = New System.Drawing.Size(632, 683)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
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
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblSuund As Label
    Friend WithEvents btnDay1 As Button
    Friend WithEvents btnDay2 As Button
    Friend WithEvents btnDay3 As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents btnDisplayLine As Button
End Class
