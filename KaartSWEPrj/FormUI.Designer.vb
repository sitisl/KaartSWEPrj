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
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.lblLat = New System.Windows.Forms.Label()
        Me.lblLongName = New System.Windows.Forms.Label()
        Me.lblChooseStop = New System.Windows.Forms.Label()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.txtLongName = New System.Windows.Forms.TextBox()
        Me.txtLat = New System.Windows.Forms.TextBox()
        Me.checkBoxStops = New System.Windows.Forms.CheckBox()
        Me.UCtrlMapViewer1 = New UCtrlMapViewer.UCtrlMapViewer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnChoose
        '
        Me.btnChoose.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChoose.Location = New System.Drawing.Point(4, 42)
        Me.btnChoose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(116, 34)
        Me.btnChoose.TabIndex = 1
        Me.btnChoose.Text = "Name"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'lblLat
        '
        Me.lblLat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLat.AutoSize = True
        Me.lblLat.Location = New System.Drawing.Point(4, 155)
        Me.lblLat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(116, 37)
        Me.lblLat.TabIndex = 2
        Me.lblLat.Text = "Latitude"
        '
        'lblLongName
        '
        Me.lblLongName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLongName.AutoSize = True
        Me.lblLongName.Location = New System.Drawing.Point(4, 81)
        Me.lblLongName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLongName.Name = "lblLongName"
        Me.lblLongName.Size = New System.Drawing.Size(116, 37)
        Me.lblLongName.TabIndex = 3
        Me.lblLongName.Text = "Longitude"
        '
        'lblChooseStop
        '
        Me.lblChooseStop.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChooseStop.AutoSize = True
        Me.lblChooseStop.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblChooseStop, 2)
        Me.lblChooseStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblChooseStop.Location = New System.Drawing.Point(4, 0)
        Me.lblChooseStop.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChooseStop.Name = "lblChooseStop"
        Me.lblChooseStop.Size = New System.Drawing.Size(240, 37)
        Me.lblChooseStop.TabIndex = 4
        Me.lblChooseStop.Text = "Choose stop"
        Me.lblChooseStop.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnDisplay
        '
        Me.btnDisplay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDisplay.Location = New System.Drawing.Point(128, 42)
        Me.btnDisplay.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(116, 34)
        Me.btnDisplay.TabIndex = 5
        Me.btnDisplay.Text = "Display"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        'txtLongName
        '
        Me.txtLongName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtLongName, 2)
        Me.txtLongName.Location = New System.Drawing.Point(4, 123)
        Me.txtLongName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLongName.Name = "txtLongName"
        Me.txtLongName.Size = New System.Drawing.Size(240, 26)
        Me.txtLongName.TabIndex = 6
        '
        'txtLat
        '
        Me.txtLat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtLat, 2)
        Me.txtLat.Location = New System.Drawing.Point(4, 197)
        Me.txtLat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLat.Name = "txtLat"
        Me.txtLat.Size = New System.Drawing.Size(240, 26)
        Me.txtLat.TabIndex = 7
        '
        'checkBoxStops
        '
        Me.checkBoxStops.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.checkBoxStops.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.checkBoxStops, 2)
        Me.checkBoxStops.Location = New System.Drawing.Point(3, 232)
        Me.checkBoxStops.Name = "checkBoxStops"
        Me.checkBoxStops.Size = New System.Drawing.Size(242, 34)
        Me.checkBoxStops.TabIndex = 11
        Me.checkBoxStops.Text = "Show all stops"
        Me.checkBoxStops.UseVisualStyleBackColor = True
        '
        'UCtrlMapViewer1
        '
        Me.UCtrlMapViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UCtrlMapViewer1.Location = New System.Drawing.Point(267, 5)
        Me.UCtrlMapViewer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UCtrlMapViewer1.Name = "UCtrlMapViewer1"
        Me.UCtrlMapViewer1.Size = New System.Drawing.Size(951, 554)
        Me.UCtrlMapViewer1.TabIndex = 10
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.checkBoxStops, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtLat, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtLongName, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDisplay, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnChoose, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblChooseStop, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLat, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLongName, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88822!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66649!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88822!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88822!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88822!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88822!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.89239!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(248, 269)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(251, 272)
        Me.FlowLayoutPanel1.TabIndex = 13
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.55879!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.44122!))
        Me.TableLayoutPanel2.Controls.Add(Me.UCtrlMapViewer1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1222, 564)
        Me.TableLayoutPanel2.TabIndex = 14
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1222, 564)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Kaardirakendus"
        Me.Text = "Ühistransport"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnChoose As Button
    Friend WithEvents lblLat As Label
    Friend WithEvents lblLongName As Label
    Friend WithEvents lblChooseStop As Label
    Friend WithEvents btnDisplay As Button
    Friend WithEvents txtLongName As TextBox
    Friend WithEvents txtLat As TextBox
    Friend WithEvents UCtrlMapViewer1 As UCtrlMapViewer.UCtrlMapViewer
    Friend WithEvents checkBoxStops As CheckBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
End Class
