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
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lBoxRealTime
        '
        Me.lBoxRealTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lBoxRealTime.FormattingEnabled = True
        Me.lBoxRealTime.ItemHeight = 20
        Me.lBoxRealTime.Location = New System.Drawing.Point(399, 492)
        Me.lBoxRealTime.Margin = New System.Windows.Forms.Padding(4)
        Me.lBoxRealTime.Name = "lBoxRealTime"
        Me.lBoxRealTime.Size = New System.Drawing.Size(145, 64)
        Me.lBoxRealTime.TabIndex = 29
        Me.lBoxRealTime.Visible = False
        '
        'btnBA
        '
        Me.btnBA.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBA.Location = New System.Drawing.Point(247, 41)
        Me.btnBA.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBA.Name = "btnBA"
        Me.btnBA.Size = New System.Drawing.Size(380, 28)
        Me.btnBA.TabIndex = 25
        Me.btnBA.UseVisualStyleBackColor = True
        Me.btnBA.Visible = False
        '
        'btnAB
        '
        Me.btnAB.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAB.Location = New System.Drawing.Point(247, 4)
        Me.btnAB.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAB.Name = "btnAB"
        Me.btnAB.Size = New System.Drawing.Size(381, 28)
        Me.btnAB.TabIndex = 24
        Me.btnAB.UseVisualStyleBackColor = True
        Me.btnAB.Visible = False
        '
        'lBoxPeatused
        '
        Me.lBoxPeatused.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lBoxPeatused.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lBoxPeatused.FormattingEnabled = True
        Me.lBoxPeatused.HorizontalScrollbar = True
        Me.lBoxPeatused.ItemHeight = 20
        Me.lBoxPeatused.Location = New System.Drawing.Point(148, 114)
        Me.lBoxPeatused.Margin = New System.Windows.Forms.Padding(4)
        Me.lBoxPeatused.Name = "lBoxPeatused"
        Me.lBoxPeatused.Size = New System.Drawing.Size(172, 442)
        Me.lBoxPeatused.TabIndex = 23
        Me.lBoxPeatused.Visible = False
        '
        'lBoxLiinid
        '
        Me.lBoxLiinid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lBoxLiinid.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lBoxLiinid.FormattingEnabled = True
        Me.lBoxLiinid.ItemHeight = 20
        Me.lBoxLiinid.Location = New System.Drawing.Point(7, 114)
        Me.lBoxLiinid.Margin = New System.Windows.Forms.Padding(4)
        Me.lBoxLiinid.Name = "lBoxLiinid"
        Me.lBoxLiinid.Size = New System.Drawing.Size(133, 442)
        Me.lBoxLiinid.TabIndex = 22
        Me.lBoxLiinid.Visible = False
        '
        'rtbAjad
        '
        Me.rtbAjad.BackColor = System.Drawing.SystemColors.Window
        Me.rtbAjad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbAjad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.rtbAjad.DetectUrls = False
        Me.rtbAjad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rtbAjad.Location = New System.Drawing.Point(328, 114)
        Me.rtbAjad.Margin = New System.Windows.Forms.Padding(4)
        Me.rtbAjad.Name = "rtbAjad"
        Me.rtbAjad.ReadOnly = True
        Me.rtbAjad.Size = New System.Drawing.Size(311, 324)
        Me.rtbAjad.TabIndex = 30
        Me.rtbAjad.Text = ""
        Me.rtbAjad.Visible = False
        '
        'lblLiinid
        '
        Me.lblLiinid.AutoSize = True
        Me.lblLiinid.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLiinid.Location = New System.Drawing.Point(44, 91)
        Me.lblLiinid.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLiinid.Name = "lblLiinid"
        Me.lblLiinid.Size = New System.Drawing.Size(45, 20)
        Me.lblLiinid.TabIndex = 31
        Me.lblLiinid.Text = "Liinid"
        Me.lblLiinid.Visible = False
        '
        'lblPeatused
        '
        Me.lblPeatused.AutoSize = True
        Me.lblPeatused.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeatused.Location = New System.Drawing.Point(191, 91)
        Me.lblPeatused.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPeatused.Name = "lblPeatused"
        Me.lblPeatused.Size = New System.Drawing.Size(68, 20)
        Me.lblPeatused.TabIndex = 32
        Me.lblPeatused.Text = "Peatused"
        Me.lblPeatused.Visible = False
        '
        'lblAjad
        '
        Me.lblAjad.AutoSize = True
        Me.lblAjad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAjad.Location = New System.Drawing.Point(463, 90)
        Me.lblAjad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAjad.Name = "lblAjad"
        Me.lblAjad.Size = New System.Drawing.Size(40, 20)
        Me.lblAjad.TabIndex = 33
        Me.lblAjad.Text = "Ajad"
        Me.lblAjad.Visible = False
        '
        'lblReaalajad
        '
        Me.lblReaalajad.AutoSize = True
        Me.lblReaalajad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblReaalajad.Location = New System.Drawing.Point(428, 468)
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
        Me.lblAbi.Location = New System.Drawing.Point(395, 442)
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
        Me.btnShowLines.Location = New System.Drawing.Point(4, 4)
        Me.btnShowLines.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowLines.Name = "btnShowLines"
        Me.btnShowLines.Size = New System.Drawing.Size(165, 28)
        Me.btnShowLines.TabIndex = 21
        Me.btnShowLines.Text = "Kuva kõik liinid"
        Me.btnShowLines.UseVisualStyleBackColor = True
        '
        'btnShowStops
        '
        Me.btnShowStops.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowStops.Location = New System.Drawing.Point(4, 41)
        Me.btnShowStops.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowStops.Name = "btnShowStops"
        Me.btnShowStops.Size = New System.Drawing.Size(165, 28)
        Me.btnShowStops.TabIndex = 28
        Me.btnShowStops.Text = "Kuva kõik peatused"
        Me.btnShowStops.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.68987!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.75949!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.39241!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowLines, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowStops, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnBA, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAB, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSuund, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(7, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(632, 74)
        Me.TableLayoutPanel1.TabIndex = 36
        '
        'lblSuund
        '
        Me.lblSuund.AutoSize = True
        Me.lblSuund.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSuund.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSuund.Location = New System.Drawing.Point(178, 0)
        Me.lblSuund.Name = "lblSuund"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblSuund, 2)
        Me.lblSuund.Size = New System.Drawing.Size(62, 74)
        Me.lblSuund.TabIndex = 37
        Me.lblSuund.Text = "Suund:"
        Me.lblSuund.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UTimeTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblAbi)
        Me.Controls.Add(Me.lblReaalajad)
        Me.Controls.Add(Me.lblAjad)
        Me.Controls.Add(Me.lblPeatused)
        Me.Controls.Add(Me.lblLiinid)
        Me.Controls.Add(Me.rtbAjad)
        Me.Controls.Add(Me.lBoxRealTime)
        Me.Controls.Add(Me.lBoxPeatused)
        Me.Controls.Add(Me.lBoxLiinid)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UTimeTable"
        Me.Size = New System.Drawing.Size(647, 566)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
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
End Class
