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
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRoute = New System.Windows.Forms.Button()
        Me.txtEnd = New System.Windows.Forms.TextBox()
        Me.txtStart = New System.Windows.Forms.TextBox()
        Me.checkBoxStops = New System.Windows.Forms.CheckBox()
        Me.txtLat = New System.Windows.Forms.TextBox()
        Me.txtLongName = New System.Windows.Forms.TextBox()
        Me.btnStopsList = New System.Windows.Forms.Button()
        Me.lblLat = New System.Windows.Forms.Label()
        Me.lblLongName = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.lblEnd = New System.Windows.Forms.Label()
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
        Me.tblLayoutForm.BackColor = System.Drawing.SystemColors.Control
        Me.tblLayoutForm.ColumnCount = 2
        Me.tblLayoutForm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.55879!))
        Me.tblLayoutForm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.44122!))
        Me.tblLayoutForm.Controls.Add(Me.UCtrlMapViewer1, 1, 0)
        Me.tblLayoutForm.Controls.Add(Me.tblLayoutStops, 0, 0)
        Me.tblLayoutForm.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
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
        Me.UCtrlMapViewer1.BackColor = System.Drawing.Color.Transparent
        Me.UCtrlMapViewer1.CausesValidation = False
        Me.UCtrlMapViewer1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.UCtrlMapViewer1.Location = New System.Drawing.Point(264, 9)
        Me.UCtrlMapViewer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UCtrlMapViewer1.MaximumSize = New System.Drawing.Size(1880, 1076)
        Me.UCtrlMapViewer1.MinimumSize = New System.Drawing.Size(920, 510)
        Me.UCtrlMapViewer1.Name = "UCtrlMapViewer1"
        Me.UCtrlMapViewer1.Size = New System.Drawing.Size(928, 541)
        Me.UCtrlMapViewer1.TabIndex = 10
        '
        'tblLayoutStops
        '
        Me.tblLayoutStops.AutoSize = True
        Me.tblLayoutStops.ColumnCount = 2
        Me.tblLayoutStops.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayoutStops.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayoutStops.Controls.Add(Me.btnClear, 0, 8)
        Me.tblLayoutStops.Controls.Add(Me.btnRoute, 1, 8)
        Me.tblLayoutStops.Controls.Add(Me.txtEnd, 0, 7)
        Me.tblLayoutStops.Controls.Add(Me.txtStart, 0, 5)
        Me.tblLayoutStops.Controls.Add(Me.checkBoxStops, 0, 3)
        Me.tblLayoutStops.Controls.Add(Me.txtLat, 1, 1)
        Me.tblLayoutStops.Controls.Add(Me.txtLongName, 1, 2)
        Me.tblLayoutStops.Controls.Add(Me.btnStopsList, 0, 0)
        Me.tblLayoutStops.Controls.Add(Me.lblLat, 0, 1)
        Me.tblLayoutStops.Controls.Add(Me.lblLongName, 0, 2)
        Me.tblLayoutStops.Controls.Add(Me.lblStart, 0, 4)
        Me.tblLayoutStops.Controls.Add(Me.lblEnd, 0, 6)
        Me.tblLayoutStops.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblLayoutStops.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.tblLayoutStops.Location = New System.Drawing.Point(7, 7)
        Me.tblLayoutStops.Name = "tblLayoutStops"
        Me.tblLayoutStops.RowCount = 9
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.678377!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.065012!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.065012!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.062345!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.066045!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.066045!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.065862!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.062345!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.673923!))
        Me.tblLayoutStops.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblLayoutStops.Size = New System.Drawing.Size(250, 545)
        Me.tblLayoutStops.TabIndex = 12
        '
        'btnClear
        '
        Me.btnClear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClear.Location = New System.Drawing.Point(4, 473)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(117, 67)
        Me.btnClear.TabIndex = 17
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRoute
        '
        Me.btnRoute.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRoute.Location = New System.Drawing.Point(129, 473)
        Me.btnRoute.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnRoute.Name = "btnRoute"
        Me.btnRoute.Size = New System.Drawing.Size(117, 67)
        Me.btnRoute.TabIndex = 16
        Me.btnRoute.Text = "Go"
        Me.btnRoute.UseVisualStyleBackColor = True
        '
        'txtEnd
        '
        Me.tblLayoutStops.SetColumnSpan(Me.txtEnd, 2)
        Me.txtEnd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEnd.Location = New System.Drawing.Point(4, 416)
        Me.txtEnd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.ReadOnly = True
        Me.txtEnd.Size = New System.Drawing.Size(242, 29)
        Me.txtEnd.TabIndex = 15
        '
        'txtStart
        '
        Me.tblLayoutStops.SetColumnSpan(Me.txtStart, 2)
        Me.txtStart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStart.Location = New System.Drawing.Point(4, 302)
        Me.txtStart.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.ReadOnly = True
        Me.txtStart.Size = New System.Drawing.Size(242, 29)
        Me.txtStart.TabIndex = 13
        '
        'checkBoxStops
        '
        Me.checkBoxStops.AutoSize = True
        Me.tblLayoutStops.SetColumnSpan(Me.checkBoxStops, 2)
        Me.checkBoxStops.Dock = System.Windows.Forms.DockStyle.Fill
        Me.checkBoxStops.Location = New System.Drawing.Point(3, 186)
        Me.checkBoxStops.Name = "checkBoxStops"
        Me.checkBoxStops.Size = New System.Drawing.Size(244, 51)
        Me.checkBoxStops.TabIndex = 11
        Me.checkBoxStops.Text = "Show all stops"
        Me.checkBoxStops.UseVisualStyleBackColor = True
        '
        'txtLat
        '
        Me.txtLat.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtLat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLat.Location = New System.Drawing.Point(129, 74)
        Me.txtLat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLat.Name = "txtLat"
        Me.txtLat.ReadOnly = True
        Me.txtLat.Size = New System.Drawing.Size(117, 29)
        Me.txtLat.TabIndex = 7
        '
        'txtLongName
        '
        Me.txtLongName.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtLongName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLongName.Location = New System.Drawing.Point(129, 131)
        Me.txtLongName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLongName.Name = "txtLongName"
        Me.txtLongName.ReadOnly = True
        Me.txtLongName.Size = New System.Drawing.Size(117, 29)
        Me.txtLongName.TabIndex = 6
        '
        'btnStopsList
        '
        Me.tblLayoutStops.SetColumnSpan(Me.btnStopsList, 2)
        Me.btnStopsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnStopsList.Location = New System.Drawing.Point(4, 5)
        Me.btnStopsList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnStopsList.Name = "btnStopsList"
        Me.btnStopsList.Size = New System.Drawing.Size(242, 59)
        Me.btnStopsList.TabIndex = 1
        Me.btnStopsList.Text = "List of stops"
        Me.btnStopsList.UseVisualStyleBackColor = True
        '
        'lblLat
        '
        Me.lblLat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLat.AutoSize = True
        Me.lblLat.Location = New System.Drawing.Point(4, 77)
        Me.lblLat.Margin = New System.Windows.Forms.Padding(4, 8, 0, 8)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(121, 41)
        Me.lblLat.TabIndex = 2
        Me.lblLat.Text = "Latitude"
        '
        'lblLongName
        '
        Me.lblLongName.AutoSize = True
        Me.lblLongName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLongName.Location = New System.Drawing.Point(4, 134)
        Me.lblLongName.Margin = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.lblLongName.Name = "lblLongName"
        Me.lblLongName.Size = New System.Drawing.Size(117, 41)
        Me.lblLongName.TabIndex = 3
        Me.lblLongName.Text = "Longitude"
        '
        'lblStart
        '
        Me.lblStart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(4, 248)
        Me.lblStart.Margin = New System.Windows.Forms.Padding(4, 8, 0, 8)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(121, 41)
        Me.lblStart.TabIndex = 12
        Me.lblStart.Text = "Start"
        '
        'lblEnd
        '
        Me.lblEnd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Location = New System.Drawing.Point(4, 362)
        Me.lblEnd.Margin = New System.Windows.Forms.Padding(4, 8, 0, 8)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(121, 41)
        Me.lblEnd.TabIndex = 14
        Me.lblEnd.Text = "End"
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
    Friend WithEvents btnStopsList As Button
    Friend WithEvents lblLat As Label
    Friend WithEvents lblLongName As Label
    Friend WithEvents btnRoute As Button
    Friend WithEvents txtEnd As TextBox
    Friend WithEvents txtStart As TextBox
    Friend WithEvents lblStart As Label
    Friend WithEvents lblEnd As Label
    Friend WithEvents btnClear As Button
End Class
