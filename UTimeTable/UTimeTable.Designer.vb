﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UTimeTable
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.lBoxRealTime = New System.Windows.Forms.ListBox()
        Me.btnBA = New System.Windows.Forms.Button()
        Me.btnAB = New System.Windows.Forms.Button()
        Me.lBoxPeatused = New System.Windows.Forms.ListBox()
        Me.lBoxLiinid = New System.Windows.Forms.ListBox()
        Me.lblLiinid = New System.Windows.Forms.Label()
        Me.lblPeatused = New System.Windows.Forms.Label()
        Me.lblAjad = New System.Windows.Forms.Label()
        Me.lblReaalajad = New System.Windows.Forms.Label()
        Me.lblAbi = New System.Windows.Forms.Label()
        Me.btnShowLines = New System.Windows.Forms.Button()
        Me.btnShowStops = New System.Windows.Forms.Button()
        Me.rtbAjad = New System.Windows.Forms.RichTextBox()
        Me.btnDay1 = New System.Windows.Forms.Button()
        Me.btnDay2 = New System.Windows.Forms.Button()
        Me.btnDay3 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnDisplayLines = New System.Windows.Forms.Button()
        Me.panelRtbAjad = New System.Windows.Forms.Panel()
        Me.panelLboxRealtime = New System.Windows.Forms.Panel()
        Me.panelLBoxPeatused = New System.Windows.Forms.Panel()
        Me.panelLBoxLiinid = New System.Windows.Forms.Panel()
        Me.panelRtbAjad.SuspendLayout()
        Me.panelLboxRealtime.SuspendLayout()
        Me.panelLBoxPeatused.SuspendLayout()
        Me.panelLBoxLiinid.SuspendLayout()
        Me.SuspendLayout()
        '
        'lBoxRealTime
        '
        Me.lBoxRealTime.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lBoxRealTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lBoxRealTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lBoxRealTime.CausesValidation = False
        Me.lBoxRealTime.ForeColor = System.Drawing.Color.White
        Me.lBoxRealTime.FormattingEnabled = True
        Me.lBoxRealTime.ItemHeight = 16
        Me.lBoxRealTime.Location = New System.Drawing.Point(1, 1)
        Me.lBoxRealTime.Margin = New System.Windows.Forms.Padding(0)
        Me.lBoxRealTime.MaximumSize = New System.Drawing.Size(268, 80)
        Me.lBoxRealTime.Name = "lBoxRealTime"
        Me.lBoxRealTime.Size = New System.Drawing.Size(268, 80)
        Me.lBoxRealTime.TabIndex = 29
        '
        'btnBA
        '
        Me.btnBA.BackColor = System.Drawing.Color.Transparent
        Me.btnBA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBA.Location = New System.Drawing.Point(192, 38)
        Me.btnBA.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBA.Name = "btnBA"
        Me.btnBA.Size = New System.Drawing.Size(447, 28)
        Me.btnBA.TabIndex = 25
        Me.btnBA.UseVisualStyleBackColor = False
        '
        'btnAB
        '
        Me.btnAB.BackColor = System.Drawing.Color.Transparent
        Me.btnAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAB.Location = New System.Drawing.Point(192, 2)
        Me.btnAB.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAB.Name = "btnAB"
        Me.btnAB.Size = New System.Drawing.Size(447, 28)
        Me.btnAB.TabIndex = 24
        Me.btnAB.UseVisualStyleBackColor = False
        '
        'lBoxPeatused
        '
        Me.lBoxPeatused.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lBoxPeatused.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lBoxPeatused.CausesValidation = False
        Me.lBoxPeatused.ForeColor = System.Drawing.Color.White
        Me.lBoxPeatused.FormattingEnabled = True
        Me.lBoxPeatused.ItemHeight = 16
        Me.lBoxPeatused.Location = New System.Drawing.Point(1, 1)
        Me.lBoxPeatused.Margin = New System.Windows.Forms.Padding(4)
        Me.lBoxPeatused.MaximumSize = New System.Drawing.Size(225, 448)
        Me.lBoxPeatused.Name = "lBoxPeatused"
        Me.lBoxPeatused.Size = New System.Drawing.Size(225, 448)
        Me.lBoxPeatused.TabIndex = 23
        '
        'lBoxLiinid
        '
        Me.lBoxLiinid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lBoxLiinid.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lBoxLiinid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lBoxLiinid.CausesValidation = False
        Me.lBoxLiinid.ForeColor = System.Drawing.Color.White
        Me.lBoxLiinid.FormattingEnabled = True
        Me.lBoxLiinid.ItemHeight = 16
        Me.lBoxLiinid.Location = New System.Drawing.Point(2, 2)
        Me.lBoxLiinid.Margin = New System.Windows.Forms.Padding(4)
        Me.lBoxLiinid.MaximumSize = New System.Drawing.Size(129, 447)
        Me.lBoxLiinid.Name = "lBoxLiinid"
        Me.lBoxLiinid.Size = New System.Drawing.Size(129, 447)
        Me.lBoxLiinid.TabIndex = 22
        '
        'lblLiinid
        '
        Me.lblLiinid.AutoSize = True
        Me.lblLiinid.ForeColor = System.Drawing.Color.White
        Me.lblLiinid.Location = New System.Drawing.Point(46, 74)
        Me.lblLiinid.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLiinid.Name = "lblLiinid"
        Me.lblLiinid.Size = New System.Drawing.Size(38, 16)
        Me.lblLiinid.TabIndex = 31
        Me.lblLiinid.Text = "Liinid"
        '
        'lblPeatused
        '
        Me.lblPeatused.AutoSize = True
        Me.lblPeatused.ForeColor = System.Drawing.Color.White
        Me.lblPeatused.Location = New System.Drawing.Point(216, 74)
        Me.lblPeatused.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPeatused.Name = "lblPeatused"
        Me.lblPeatused.Size = New System.Drawing.Size(65, 16)
        Me.lblPeatused.TabIndex = 32
        Me.lblPeatused.Text = "Peatused"
        '
        'lblAjad
        '
        Me.lblAjad.AutoSize = True
        Me.lblAjad.ForeColor = System.Drawing.Color.White
        Me.lblAjad.Location = New System.Drawing.Point(493, 74)
        Me.lblAjad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAjad.Name = "lblAjad"
        Me.lblAjad.Size = New System.Drawing.Size(35, 16)
        Me.lblAjad.TabIndex = 33
        Me.lblAjad.Text = "Ajad"
        '
        'lblReaalajad
        '
        Me.lblReaalajad.AutoSize = True
        Me.lblReaalajad.BackColor = System.Drawing.Color.Transparent
        Me.lblReaalajad.ForeColor = System.Drawing.Color.White
        Me.lblReaalajad.Location = New System.Drawing.Point(480, 444)
        Me.lblReaalajad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReaalajad.Name = "lblReaalajad"
        Me.lblReaalajad.Size = New System.Drawing.Size(71, 16)
        Me.lblReaalajad.TabIndex = 34
        Me.lblReaalajad.Text = "Reaalajad"
        '
        'lblAbi
        '
        Me.lblAbi.AutoSize = True
        Me.lblAbi.ForeColor = System.Drawing.Color.White
        Me.lblAbi.Location = New System.Drawing.Point(431, 421)
        Me.lblAbi.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAbi.Name = "lblAbi"
        Me.lblAbi.Size = New System.Drawing.Size(184, 16)
        Me.lblAbi.TabIndex = 35
        Me.lblAbi.Text = "Madala sisenemisega sõiduk"
        Me.lblAbi.Visible = False
        '
        'btnShowLines
        '
        Me.btnShowLines.BackColor = System.Drawing.Color.Transparent
        Me.btnShowLines.FlatAppearance.BorderSize = 0
        Me.btnShowLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowLines.ForeColor = System.Drawing.Color.White
        Me.btnShowLines.Location = New System.Drawing.Point(4, 2)
        Me.btnShowLines.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowLines.Name = "btnShowLines"
        Me.btnShowLines.Size = New System.Drawing.Size(167, 28)
        Me.btnShowLines.TabIndex = 21
        Me.btnShowLines.Text = "Kuva kõik liinid"
        Me.btnShowLines.UseVisualStyleBackColor = False
        '
        'btnShowStops
        '
        Me.btnShowStops.BackColor = System.Drawing.Color.Transparent
        Me.btnShowStops.FlatAppearance.BorderSize = 0
        Me.btnShowStops.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowStops.ForeColor = System.Drawing.Color.White
        Me.btnShowStops.Location = New System.Drawing.Point(4, 38)
        Me.btnShowStops.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShowStops.Name = "btnShowStops"
        Me.btnShowStops.Size = New System.Drawing.Size(167, 28)
        Me.btnShowStops.TabIndex = 28
        Me.btnShowStops.Text = "Kuva kõik peatused"
        Me.btnShowStops.UseVisualStyleBackColor = False
        '
        'rtbAjad
        '
        Me.rtbAjad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rtbAjad.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.rtbAjad.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbAjad.CausesValidation = False
        Me.rtbAjad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.rtbAjad.DetectUrls = False
        Me.rtbAjad.ForeColor = System.Drawing.Color.White
        Me.rtbAjad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rtbAjad.Location = New System.Drawing.Point(1, 1)
        Me.rtbAjad.Margin = New System.Windows.Forms.Padding(4)
        Me.rtbAjad.MaximumSize = New System.Drawing.Size(270, 287)
        Me.rtbAjad.Name = "rtbAjad"
        Me.rtbAjad.ReadOnly = True
        Me.rtbAjad.Size = New System.Drawing.Size(270, 287)
        Me.rtbAjad.TabIndex = 37
        Me.rtbAjad.Text = ""
        '
        'btnDay1
        '
        Me.btnDay1.BackColor = System.Drawing.Color.Transparent
        Me.btnDay1.FlatAppearance.BorderSize = 0
        Me.btnDay1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDay1.ForeColor = System.Drawing.Color.White
        Me.btnDay1.Location = New System.Drawing.Point(383, 94)
        Me.btnDay1.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDay1.Name = "btnDay1"
        Me.btnDay1.Size = New System.Drawing.Size(90, 28)
        Me.btnDay1.TabIndex = 38
        Me.btnDay1.Text = "Tööpäev"
        Me.btnDay1.UseVisualStyleBackColor = False
        '
        'btnDay2
        '
        Me.btnDay2.BackColor = System.Drawing.Color.Transparent
        Me.btnDay2.FlatAppearance.BorderSize = 0
        Me.btnDay2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDay2.ForeColor = System.Drawing.Color.White
        Me.btnDay2.Location = New System.Drawing.Point(473, 94)
        Me.btnDay2.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDay2.Name = "btnDay2"
        Me.btnDay2.Size = New System.Drawing.Size(90, 28)
        Me.btnDay2.TabIndex = 39
        Me.btnDay2.Text = "Laupäev"
        Me.btnDay2.UseVisualStyleBackColor = False
        '
        'btnDay3
        '
        Me.btnDay3.BackColor = System.Drawing.Color.Transparent
        Me.btnDay3.FlatAppearance.BorderSize = 0
        Me.btnDay3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDay3.ForeColor = System.Drawing.Color.White
        Me.btnDay3.Location = New System.Drawing.Point(564, 94)
        Me.btnDay3.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDay3.Name = "btnDay3"
        Me.btnDay3.Size = New System.Drawing.Size(90, 28)
        Me.btnDay3.TabIndex = 40
        Me.btnDay3.Text = "Pühapäev"
        Me.btnDay3.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'btnDisplayLines
        '
        Me.btnDisplayLines.BackColor = System.Drawing.Color.Transparent
        Me.btnDisplayLines.FlatAppearance.BorderSize = 0
        Me.btnDisplayLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisplayLines.ForeColor = System.Drawing.Color.White
        Me.btnDisplayLines.Location = New System.Drawing.Point(4, 550)
        Me.btnDisplayLines.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDisplayLines.Name = "btnDisplayLines"
        Me.btnDisplayLines.Size = New System.Drawing.Size(133, 28)
        Me.btnDisplayLines.TabIndex = 41
        Me.btnDisplayLines.Text = "Kuva liin kaardil"
        Me.btnDisplayLines.UseVisualStyleBackColor = False
        '
        'panelRtbAjad
        '
        Me.panelRtbAjad.Controls.Add(Me.rtbAjad)
        Me.panelRtbAjad.Location = New System.Drawing.Point(383, 129)
        Me.panelRtbAjad.Name = "panelRtbAjad"
        Me.panelRtbAjad.Size = New System.Drawing.Size(272, 289)
        Me.panelRtbAjad.TabIndex = 42
        '
        'panelLboxRealtime
        '
        Me.panelLboxRealtime.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.panelLboxRealtime.Controls.Add(Me.lBoxRealTime)
        Me.panelLboxRealtime.Location = New System.Drawing.Point(383, 463)
        Me.panelLboxRealtime.Margin = New System.Windows.Forms.Padding(0)
        Me.panelLboxRealtime.Name = "panelLboxRealtime"
        Me.panelLboxRealtime.Padding = New System.Windows.Forms.Padding(1)
        Me.panelLboxRealtime.Size = New System.Drawing.Size(271, 82)
        Me.panelLboxRealtime.TabIndex = 43
        '
        'panelLBoxPeatused
        '
        Me.panelLBoxPeatused.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.panelLBoxPeatused.Controls.Add(Me.lBoxPeatused)
        Me.panelLBoxPeatused.Location = New System.Drawing.Point(143, 95)
        Me.panelLBoxPeatused.Name = "panelLBoxPeatused"
        Me.panelLBoxPeatused.Size = New System.Drawing.Size(228, 450)
        Me.panelLBoxPeatused.TabIndex = 38
        '
        'panelLBoxLiinid
        '
        Me.panelLBoxLiinid.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.panelLBoxLiinid.Controls.Add(Me.lBoxLiinid)
        Me.panelLBoxLiinid.Location = New System.Drawing.Point(3, 95)
        Me.panelLBoxLiinid.Name = "panelLBoxLiinid"
        Me.panelLBoxLiinid.Size = New System.Drawing.Size(134, 450)
        Me.panelLBoxLiinid.TabIndex = 38
        '
        'UTimeTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.panelLBoxLiinid)
        Me.Controls.Add(Me.panelLBoxPeatused)
        Me.Controls.Add(Me.panelLboxRealtime)
        Me.Controls.Add(Me.panelRtbAjad)
        Me.Controls.Add(Me.btnDisplayLines)
        Me.Controls.Add(Me.btnDay3)
        Me.Controls.Add(Me.btnDay2)
        Me.Controls.Add(Me.btnDay1)
        Me.Controls.Add(Me.lblAbi)
        Me.Controls.Add(Me.lblReaalajad)
        Me.Controls.Add(Me.lblAjad)
        Me.Controls.Add(Me.lblPeatused)
        Me.Controls.Add(Me.lblLiinid)
        Me.Controls.Add(Me.btnShowStops)
        Me.Controls.Add(Me.btnBA)
        Me.Controls.Add(Me.btnAB)
        Me.Controls.Add(Me.btnShowLines)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UTimeTable"
        Me.Size = New System.Drawing.Size(658, 590)
        Me.panelRtbAjad.ResumeLayout(False)
        Me.panelLboxRealtime.ResumeLayout(False)
        Me.panelLBoxPeatused.ResumeLayout(False)
        Me.panelLBoxLiinid.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lBoxRealTime As ListBox
    Friend WithEvents btnBA As Button
    Friend WithEvents btnAB As Button
    Friend WithEvents lBoxPeatused As ListBox
    Friend WithEvents lBoxLiinid As ListBox
    Friend WithEvents lblLiinid As Label
    Friend WithEvents lblPeatused As Label
    Friend WithEvents lblAjad As Label
    Friend WithEvents lblReaalajad As Label
    Friend WithEvents lblAbi As Label
    Friend WithEvents btnShowLines As Button
    Friend WithEvents btnShowStops As Button
    Friend WithEvents rtbAjad As RichTextBox
    Friend WithEvents btnDay1 As Button
    Friend WithEvents btnDay2 As Button
    Friend WithEvents btnDay3 As Button

    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnDisplayLines As Button
    Friend WithEvents panelRtbAjad As Panel
    Friend WithEvents panelLboxRealtime As Panel
    Friend WithEvents panelLBoxPeatused As Panel
    Friend WithEvents panelLBoxLiinid As Panel
End Class