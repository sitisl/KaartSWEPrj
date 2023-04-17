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
        Me.panelLayers.SuspendLayout()
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
        Me.gMap1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gMap1.EmptyTileColor = System.Drawing.Color.Transparent
        Me.gMap1.GrayScaleMode = False
        Me.gMap1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.gMap1.LevelsKeepInMemory = 5
        Me.gMap1.Location = New System.Drawing.Point(0, 0)
        Me.gMap1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
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
        Me.gMap1.Size = New System.Drawing.Size(925, 518)
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
        Me.panelLayers.Location = New System.Drawing.Point(796, 3)
        Me.panelLayers.Name = "panelLayers"
        Me.panelLayers.Size = New System.Drawing.Size(126, 228)
        Me.panelLayers.TabIndex = 3
        '
        'cbTroll
        '
        Me.cbTroll.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbTroll.AutoSize = True
        Me.cbTroll.BackColor = System.Drawing.Color.Transparent
        Me.cbTroll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.cbTroll.ForeColor = System.Drawing.Color.Snow
        Me.cbTroll.Location = New System.Drawing.Point(7, 159)
        Me.cbTroll.Name = "cbTroll"
        Me.cbTroll.Size = New System.Drawing.Size(85, 29)
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
        Me.cbTram.Location = New System.Drawing.Point(7, 129)
        Me.cbTram.Name = "cbTram"
        Me.cbTram.Size = New System.Drawing.Size(107, 29)
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
        Me.cbBuses.Location = New System.Drawing.Point(7, 99)
        Me.cbBuses.Name = "cbBuses"
        Me.cbBuses.Size = New System.Drawing.Size(89, 29)
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
        Me.cbStops.Location = New System.Drawing.Point(7, 71)
        Me.cbStops.Name = "cbStops"
        Me.cbStops.Size = New System.Drawing.Size(109, 29)
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
        Me.btnLayers.Location = New System.Drawing.Point(55, 1)
        Me.btnLayers.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLayers.Name = "btnLayers"
        Me.btnLayers.Size = New System.Drawing.Size(70, 70)
        Me.btnLayers.TabIndex = 0
        Me.btnLayers.UseVisualStyleBackColor = False
        '
        'UCtrlMapViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.panelLayers)
        Me.Controls.Add(Me.gMap1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "UCtrlMapViewer"
        Me.Size = New System.Drawing.Size(925, 518)
        Me.panelLayers.ResumeLayout(False)
        Me.panelLayers.PerformLayout()
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
End Class
