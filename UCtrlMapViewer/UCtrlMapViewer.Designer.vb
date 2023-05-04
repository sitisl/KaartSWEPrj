<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCtrlMapViewer
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
        Me.gMap1 = New GMap.NET.WindowsForms.GMapControl()
        Me.panelLayers = New System.Windows.Forms.Panel()
        Me.cbTroll = New System.Windows.Forms.CheckBox()
        Me.cbTram = New System.Windows.Forms.CheckBox()
        Me.cbBuses = New System.Windows.Forms.CheckBox()
        Me.cbStops = New System.Windows.Forms.CheckBox()
        Me.btnLayers = New System.Windows.Forms.Button()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.lblDest = New System.Windows.Forms.Label()
        Me.btnRoute = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.panelPopup = New System.Windows.Forms.Panel()
        Me.lBoxRealTime = New System.Windows.Forms.ListBox()
        Me.btnZoomIn = New System.Windows.Forms.Button()
        Me.btnZoomOut = New System.Windows.Forms.Button()
        Me.panelLayers.SuspendLayout()
        Me.panelPopup.SuspendLayout()
        Me.SuspendLayout()
        '
        'gMap1
        '
        Me.gMap1.AutoSize = True
        Me.gMap1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gMap1.BackColor = System.Drawing.Color.Transparent
        Me.gMap1.Bearing = 0!
        Me.gMap1.CanDragMap = True
        Me.gMap1.CausesValidation = False
        Me.gMap1.Cursor = System.Windows.Forms.Cursors.Default
        Me.gMap1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gMap1.EmptyTileColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gMap1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gMap1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gMap1.GrayScaleMode = False
        Me.gMap1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.gMap1.LevelsKeepInMemory = 5
        Me.gMap1.Location = New System.Drawing.Point(0, 0)
        Me.gMap1.Margin = New System.Windows.Forms.Padding(4)
        Me.gMap1.MarkersEnabled = True
        Me.gMap1.MaxZoom = 2
        Me.gMap1.MinZoom = 2
        Me.gMap1.MouseWheelZoomEnabled = True
        Me.gMap1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.gMap1.Name = "gMap1"
        Me.gMap1.NegativeMode = False
        Me.gMap1.PolygonsEnabled = True
        Me.gMap1.RetryLoadTile = 0
        Me.gMap1.RoutesEnabled = True
        Me.gMap1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.gMap1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.gMap1.ShowTileGridLines = False
        Me.gMap1.Size = New System.Drawing.Size(823, 415)
        Me.gMap1.TabIndex = 0
        Me.gMap1.Zoom = 0R
        '
        'panelLayers
        '
        Me.panelLayers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelLayers.BackColor = System.Drawing.Color.Transparent
        Me.panelLayers.Controls.Add(Me.cbTroll)
        Me.panelLayers.Controls.Add(Me.cbTram)
        Me.panelLayers.Controls.Add(Me.cbBuses)
        Me.panelLayers.Controls.Add(Me.cbStops)
        Me.panelLayers.Controls.Add(Me.btnLayers)
        Me.panelLayers.ForeColor = System.Drawing.Color.Transparent
        Me.panelLayers.Location = New System.Drawing.Point(708, 2)
        Me.panelLayers.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.panelLayers.Name = "panelLayers"
        Me.panelLayers.Size = New System.Drawing.Size(112, 182)
        Me.panelLayers.TabIndex = 3
        '
        'cbTroll
        '
        Me.cbTroll.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbTroll.AutoSize = True
        Me.cbTroll.BackColor = System.Drawing.Color.Transparent
        Me.cbTroll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.cbTroll.ForeColor = System.Drawing.Color.Snow
        Me.cbTroll.Location = New System.Drawing.Point(7, 127)
        Me.cbTroll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbTroll.Name = "cbTroll"
        Me.cbTroll.Size = New System.Drawing.Size(73, 24)
        Me.cbTroll.TabIndex = 4
        Me.cbTroll.Text = "Trollid"
        Me.cbTroll.UseVisualStyleBackColor = False
        '
        'cbTram
        '
        Me.cbTram.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbTram.AutoSize = True
        Me.cbTram.BackColor = System.Drawing.Color.Transparent
        Me.cbTram.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.cbTram.ForeColor = System.Drawing.Color.Snow
        Me.cbTram.Location = New System.Drawing.Point(7, 103)
        Me.cbTram.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbTram.Name = "cbTram"
        Me.cbTram.Size = New System.Drawing.Size(90, 24)
        Me.cbTram.TabIndex = 3
        Me.cbTram.Text = "Trammid"
        Me.cbTram.UseVisualStyleBackColor = False
        '
        'cbBuses
        '
        Me.cbBuses.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbBuses.AutoSize = True
        Me.cbBuses.BackColor = System.Drawing.Color.Transparent
        Me.cbBuses.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.cbBuses.ForeColor = System.Drawing.Color.Snow
        Me.cbBuses.Location = New System.Drawing.Point(7, 79)
        Me.cbBuses.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbBuses.Name = "cbBuses"
        Me.cbBuses.Size = New System.Drawing.Size(73, 24)
        Me.cbBuses.TabIndex = 2
        Me.cbBuses.Text = "Bussid"
        Me.cbBuses.UseVisualStyleBackColor = False
        '
        'cbStops
        '
        Me.cbStops.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbStops.AutoSize = True
        Me.cbStops.BackColor = System.Drawing.Color.Transparent
        Me.cbStops.FlatAppearance.BorderSize = 0
        Me.cbStops.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.cbStops.ForeColor = System.Drawing.Color.Snow
        Me.cbStops.Location = New System.Drawing.Point(7, 57)
        Me.cbStops.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbStops.Name = "cbStops"
        Me.cbStops.Size = New System.Drawing.Size(90, 24)
        Me.cbStops.TabIndex = 1
        Me.cbStops.Text = "Peatused"
        Me.cbStops.UseVisualStyleBackColor = False
        '
        'btnLayers
        '
        Me.btnLayers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLayers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnLayers.BackColor = System.Drawing.Color.Transparent
        Me.btnLayers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnLayers.FlatAppearance.BorderSize = 0
        Me.btnLayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLayers.ForeColor = System.Drawing.Color.Transparent
        Me.btnLayers.Location = New System.Drawing.Point(49, 1)
        Me.btnLayers.Margin = New System.Windows.Forms.Padding(1)
        Me.btnLayers.Name = "btnLayers"
        Me.btnLayers.Size = New System.Drawing.Size(63, 57)
        Me.btnLayers.TabIndex = 0
        Me.btnLayers.UseVisualStyleBackColor = False
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblStart.ForeColor = System.Drawing.Color.Transparent
        Me.lblStart.Location = New System.Drawing.Point(10, 10)
        Me.lblStart.MinimumSize = New System.Drawing.Size(210, 30)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(210, 30)
        Me.lblStart.TabIndex = 8
        '
        'lblDest
        '
        Me.lblDest.AutoSize = True
        Me.lblDest.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDest.ForeColor = System.Drawing.Color.Transparent
        Me.lblDest.Location = New System.Drawing.Point(10, 40)
        Me.lblDest.MinimumSize = New System.Drawing.Size(210, 30)
        Me.lblDest.Name = "lblDest"
        Me.lblDest.Size = New System.Drawing.Size(210, 30)
        Me.lblDest.TabIndex = 9
        '
        'btnRoute
        '
        Me.btnRoute.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnRoute.FlatAppearance.BorderSize = 0
        Me.btnRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRoute.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRoute.ForeColor = System.Drawing.Color.White
        Me.btnRoute.Location = New System.Drawing.Point(120, 73)
        Me.btnRoute.Name = "btnRoute"
        Me.btnRoute.Size = New System.Drawing.Size(100, 35)
        Me.btnRoute.TabIndex = 10
        Me.btnRoute.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(11, 73)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 35)
        Me.btnClear.TabIndex = 11
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'panelPopup
        '
        Me.panelPopup.AutoSize = True
        Me.panelPopup.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.panelPopup.Controls.Add(Me.lBoxRealTime)
        Me.panelPopup.Location = New System.Drawing.Point(676, 285)
        Me.panelPopup.Name = "panelPopup"
        Me.panelPopup.Size = New System.Drawing.Size(144, 127)
        Me.panelPopup.TabIndex = 12
        '
        'lBoxRealTime
        '
        Me.lBoxRealTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lBoxRealTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lBoxRealTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lBoxRealTime.ForeColor = System.Drawing.Color.Snow
        Me.lBoxRealTime.FormattingEnabled = True
        Me.lBoxRealTime.ItemHeight = 20
        Me.lBoxRealTime.Location = New System.Drawing.Point(9, 19)
        Me.lBoxRealTime.Name = "lBoxRealTime"
        Me.lBoxRealTime.Size = New System.Drawing.Size(120, 80)
        Me.lBoxRealTime.TabIndex = 0
        '
        'btnZoomIn
        '
        Me.btnZoomIn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnZoomIn.BackColor = System.Drawing.Color.Transparent
        Me.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnZoomIn.FlatAppearance.BorderSize = 0
        Me.btnZoomIn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZoomIn.Font = New System.Drawing.Font("Shapiro 65 Light Heavy Extd", 32.0!, System.Drawing.FontStyle.Bold)
        Me.btnZoomIn.ForeColor = System.Drawing.Color.Transparent
        Me.btnZoomIn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnZoomIn.Location = New System.Drawing.Point(12, 129)
        Me.btnZoomIn.Margin = New System.Windows.Forms.Padding(50, 0, 50, 0)
        Me.btnZoomIn.MaximumSize = New System.Drawing.Size(50, 50)
        Me.btnZoomIn.MinimumSize = New System.Drawing.Size(50, 50)
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(50, 50)
        Me.btnZoomIn.TabIndex = 5
        Me.btnZoomIn.UseVisualStyleBackColor = False
        '
        'btnZoomOut
        '
        Me.btnZoomOut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnZoomOut.FlatAppearance.BorderSize = 0
        Me.btnZoomOut.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZoomOut.Font = New System.Drawing.Font("Shapiro 65 Light Heavy Extd", 32.0!, System.Drawing.FontStyle.Bold)
        Me.btnZoomOut.ForeColor = System.Drawing.Color.Transparent
        Me.btnZoomOut.Location = New System.Drawing.Point(12, 178)
        Me.btnZoomOut.Margin = New System.Windows.Forms.Padding(50, 0, 50, 0)
        Me.btnZoomOut.MaximumSize = New System.Drawing.Size(50, 50)
        Me.btnZoomOut.MinimumSize = New System.Drawing.Size(50, 50)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(50, 50)
        Me.btnZoomOut.TabIndex = 13
        Me.btnZoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnZoomOut.UseVisualStyleBackColor = False
        '
        'UCtrlMapViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.btnZoomOut)
        Me.Controls.Add(Me.btnZoomIn)
        Me.Controls.Add(Me.panelPopup)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnRoute)
        Me.Controls.Add(Me.lblDest)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.panelLayers)
        Me.Controls.Add(Me.gMap1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCtrlMapViewer"
        Me.Size = New System.Drawing.Size(823, 415)
        Me.panelLayers.ResumeLayout(False)
        Me.panelLayers.PerformLayout()
        Me.panelPopup.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gMap1 As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents panelLayers As Panel
    Friend WithEvents btnLayers As Button
    Friend WithEvents cbTram As CheckBox
    Friend WithEvents cbBuses As CheckBox
    Friend WithEvents cbStops As CheckBox
    Friend WithEvents cbTroll As CheckBox
    Friend WithEvents lblStart As Label
    Friend WithEvents lblDest As Label
    Friend WithEvents btnRoute As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents panelPopup As Panel
    Friend WithEvents btnZoomIn As Button
    Friend WithEvents btnZoomOut As Button
    Friend WithEvents lBoxRealTime As ListBox
End Class
