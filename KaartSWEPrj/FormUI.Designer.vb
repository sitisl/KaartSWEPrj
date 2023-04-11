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
        Me.tblLayoutForm = New System.Windows.Forms.TableLayoutPanel()
        Me.UCtrlMapViewer1 = New UCtrlMapViewer.UCtrlMapViewer()
        Me.tblLayoutStops = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLongName = New System.Windows.Forms.Label()
        Me.lblLat = New System.Windows.Forms.Label()
        Me.lblChooseStop = New System.Windows.Forms.Label()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.txtLongName = New System.Windows.Forms.TextBox()
        Me.txtLat = New System.Windows.Forms.TextBox()
        Me.checkBoxStops = New System.Windows.Forms.CheckBox()
        Me.tblLayoutForm.SuspendLayout()
        Me.tblLayoutStops.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblLayoutForm
        '
        Me.tblLayoutForm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblLayoutForm.AutoSize = True
        Me.tblLayoutForm.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tblLayoutForm.ColumnCount = 2
        Me.tblLayoutForm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.55879!))
        Me.tblLayoutForm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.44122!))
        Me.tblLayoutForm.Controls.Add(Me.UCtrlMapViewer1, 1, 0)
        Me.tblLayoutForm.Controls.Add(Me.tblLayoutStops, 0, 0)
        Me.tblLayoutForm.Location = New System.Drawing.Point(0, 0)
        Me.tblLayoutForm.Margin = New System.Windows.Forms.Padding(1)
        Me.tblLayoutForm.MinimumSize = New System.Drawing.Size(1200, 500)
        Me.tblLayoutForm.Name = "tblLayoutForm"
        Me.tblLayoutForm.Padding = New System.Windows.Forms.Padding(4)
        Me.tblLayoutForm.RowCount = 1
        Me.tblLayoutForm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutForm.Size = New System.Drawing.Size(1200, 559)
        Me.tblLayoutForm.TabIndex = 14
        '
        'UCtrlMapViewer1
        '
        Me.UCtrlMapViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UCtrlMapViewer1.AutoSize = True
        Me.UCtrlMapViewer1.Location = New System.Drawing.Point(266, 10)
        Me.UCtrlMapViewer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UCtrlMapViewer1.MaximumSize = New System.Drawing.Size(1880, 1076)
        Me.UCtrlMapViewer1.MinimumSize = New System.Drawing.Size(920, 510)
        Me.UCtrlMapViewer1.Name = "UCtrlMapViewer1"
        Me.UCtrlMapViewer1.Size = New System.Drawing.Size(925, 539)
        Me.UCtrlMapViewer1.TabIndex = 10
        '
        'tblLayoutStops
        '
        Me.tblLayoutStops.AutoSize = True
        Me.tblLayoutStops.ColumnCount = 2
        Me.tblLayoutStops.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayoutStops.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayoutStops.Controls.Add(Me.checkBoxStops, 0, 6)
        Me.tblLayoutStops.Controls.Add(Me.txtLat, 0, 5)
        Me.tblLayoutStops.Controls.Add(Me.txtLongName, 0, 3)
        Me.tblLayoutStops.Controls.Add(Me.btnDisplay, 1, 1)
        Me.tblLayoutStops.Controls.Add(Me.btnChoose, 0, 1)
        Me.tblLayoutStops.Controls.Add(Me.lblChooseStop, 0, 0)
        Me.tblLayoutStops.Controls.Add(Me.lblLat, 0, 4)
        Me.tblLayoutStops.Controls.Add(Me.lblLongName, 0, 2)
        Me.tblLayoutStops.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblLayoutStops.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.tblLayoutStops.Location = New System.Drawing.Point(8, 8)
        Me.tblLayoutStops.Name = "tblLayoutStops"
        Me.tblLayoutStops.RowCount = 7
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88822!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66649!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88822!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88822!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88822!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.88822!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.89239!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblLayoutStops.Size = New System.Drawing.Size(250, 281)
        Me.tblLayoutStops.TabIndex = 12
        '
        'lblLongName
        '
        Me.lblLongName.AutoSize = True
        Me.lblLongName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLongName.Location = New System.Drawing.Point(4, 93)
        Me.lblLongName.Margin = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.lblLongName.Name = "lblLongName"
        Me.lblLongName.Size = New System.Drawing.Size(117, 23)
        Me.lblLongName.TabIndex = 3
        Me.lblLongName.Text = "Longitude"
        '
        'lblLat
        '
        Me.lblLat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLat.AutoSize = True
        Me.lblLat.Location = New System.Drawing.Point(4, 171)
        Me.lblLat.Margin = New System.Windows.Forms.Padding(4, 8, 0, 8)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(121, 23)
        Me.lblLat.TabIndex = 2
        Me.lblLat.Text = "Latitude"
        '
        'lblChooseStop
        '
        Me.lblChooseStop.AutoSize = True
        Me.lblChooseStop.BackColor = System.Drawing.SystemColors.Control
        Me.tblLayoutStops.SetColumnSpan(Me.lblChooseStop, 2)
        Me.lblChooseStop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChooseStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblChooseStop.Location = New System.Drawing.Point(4, 8)
        Me.lblChooseStop.Margin = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.lblChooseStop.Name = "lblChooseStop"
        Me.lblChooseStop.Size = New System.Drawing.Size(242, 23)
        Me.lblChooseStop.TabIndex = 4
        Me.lblChooseStop.Text = "Choose stop"
        Me.lblChooseStop.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnChoose
        '
        Me.btnChoose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnChoose.Location = New System.Drawing.Point(4, 44)
        Me.btnChoose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(117, 36)
        Me.btnChoose.TabIndex = 1
        Me.btnChoose.Text = "Name"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'btnDisplay
        '
        Me.btnDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDisplay.Location = New System.Drawing.Point(129, 44)
        Me.btnDisplay.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(117, 36)
        Me.btnDisplay.TabIndex = 5
        Me.btnDisplay.Text = "Display"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        'txtLongName
        '
        Me.tblLayoutStops.SetColumnSpan(Me.txtLongName, 2)
        Me.txtLongName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLongName.Location = New System.Drawing.Point(4, 129)
        Me.txtLongName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLongName.Name = "txtLongName"
        Me.txtLongName.Size = New System.Drawing.Size(242, 29)
        Me.txtLongName.TabIndex = 6
        '
        'txtLat
        '
        Me.tblLayoutStops.SetColumnSpan(Me.txtLat, 2)
        Me.txtLat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLat.Location = New System.Drawing.Point(4, 207)
        Me.txtLat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLat.Name = "txtLat"
        Me.txtLat.Size = New System.Drawing.Size(242, 29)
        Me.txtLat.TabIndex = 7
        '
        'checkBoxStops
        '
        Me.checkBoxStops.AutoSize = True
        Me.tblLayoutStops.SetColumnSpan(Me.checkBoxStops, 2)
        Me.checkBoxStops.Dock = System.Windows.Forms.DockStyle.Fill
        Me.checkBoxStops.Location = New System.Drawing.Point(3, 244)
        Me.checkBoxStops.Name = "checkBoxStops"
        Me.checkBoxStops.Size = New System.Drawing.Size(244, 34)
        Me.checkBoxStops.TabIndex = 11
        Me.checkBoxStops.Text = "Show all stops"
        Me.checkBoxStops.UseVisualStyleBackColor = True
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1200, 559)
        Me.Controls.Add(Me.tblLayoutForm)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(1220, 600)
        Me.Name = "Kaardirakendus"
        Me.Text = "Ühistransport"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tblLayoutForm.ResumeLayout(False)
        Me.tblLayoutForm.PerformLayout()
        Me.tblLayoutStops.ResumeLayout(False)
        Me.tblLayoutStops.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UCtrlMapViewer1 As UCtrlMapViewer.UCtrlMapViewer
    Friend WithEvents tblLayoutForm As TableLayoutPanel
    Friend WithEvents tblLayoutStops As TableLayoutPanel
    Friend WithEvents checkBoxStops As CheckBox
    Friend WithEvents txtLat As TextBox
    Friend WithEvents txtLongName As TextBox
    Friend WithEvents btnDisplay As Button
    Friend WithEvents btnChoose As Button
    Friend WithEvents lblChooseStop As Label
    Friend WithEvents lblLat As Label
    Friend WithEvents lblLongName As Label
End Class
