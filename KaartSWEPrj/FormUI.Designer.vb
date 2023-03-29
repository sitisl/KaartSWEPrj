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
        Me.GMapControl1 = New GMap.NET.WindowsForms.GMapControl()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.lblLat = New System.Windows.Forms.Label()
        Me.lblLongName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.txtLongName = New System.Windows.Forms.TextBox()
        Me.txtLat = New System.Windows.Forms.TextBox()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.btnDisplayComponent = New System.Windows.Forms.Button()
        Me.UCtrlMapViewer1 = New UCtrlMapViewer.UCtrlMapViewer()
        Me.SuspendLayout()
        '
        'GMapControl1
        '
        Me.GMapControl1.Bearing = 0!
        Me.GMapControl1.CanDragMap = True
        Me.GMapControl1.EmptyTileColor = System.Drawing.Color.Navy
        Me.GMapControl1.GrayScaleMode = False
        Me.GMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.GMapControl1.LevelsKeepInMemory = 5
        Me.GMapControl1.Location = New System.Drawing.Point(298, 37)
        Me.GMapControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GMapControl1.MarkersEnabled = True
        Me.GMapControl1.MaxZoom = 2
        Me.GMapControl1.MinZoom = 2
        Me.GMapControl1.MouseWheelZoomEnabled = True
        Me.GMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.GMapControl1.Name = "GMapControl1"
        Me.GMapControl1.NegativeMode = False
        Me.GMapControl1.PolygonsEnabled = True
        Me.GMapControl1.RetryLoadTile = 0
        Me.GMapControl1.RoutesEnabled = True
        Me.GMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.GMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GMapControl1.ShowTileGridLines = False
        Me.GMapControl1.Size = New System.Drawing.Size(904, 618)
        Me.GMapControl1.TabIndex = 0
        Me.GMapControl1.Zoom = 0R
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(18, 71)
        Me.btnChoose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(112, 35)
        Me.btnChoose.TabIndex = 1
        Me.btnChoose.Text = "Name"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'lblLat
        '
        Me.lblLat.AutoSize = True
        Me.lblLat.Location = New System.Drawing.Point(18, 198)
        Me.lblLat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(67, 20)
        Me.lblLat.TabIndex = 2
        Me.lblLat.Text = "Latitude"
        '
        'lblLongName
        '
        Me.lblLongName.AutoSize = True
        Me.lblLongName.Location = New System.Drawing.Point(14, 129)
        Me.lblLongName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLongName.Name = "lblLongName"
        Me.lblLongName.Size = New System.Drawing.Size(80, 20)
        Me.lblLongName.TabIndex = 3
        Me.lblLongName.Text = "Longitude"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 37)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Choose stop"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(140, 71)
        Me.btnDisplay.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(112, 35)
        Me.btnDisplay.TabIndex = 5
        Me.btnDisplay.Text = "Display"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        'txtLongName
        '
        Me.txtLongName.Location = New System.Drawing.Point(18, 154)
        Me.txtLongName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLongName.Name = "txtLongName"
        Me.txtLongName.Size = New System.Drawing.Size(232, 26)
        Me.txtLongName.TabIndex = 6
        '
        'txtLat
        '
        Me.txtLat.Location = New System.Drawing.Point(18, 223)
        Me.txtLat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLat.Name = "txtLat"
        Me.txtLat.Size = New System.Drawing.Size(232, 26)
        Me.txtLat.TabIndex = 7
        '
        'btnAll
        '
        Me.btnAll.Location = New System.Drawing.Point(22, 278)
        Me.btnAll.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(230, 35)
        Me.btnAll.TabIndex = 8
        Me.btnAll.Text = "Display All"
        Me.btnAll.UseVisualStyleBackColor = True
        '
        'btnDisplayComponent
        '
        Me.btnDisplayComponent.Location = New System.Drawing.Point(22, 366)
        Me.btnDisplayComponent.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDisplayComponent.Name = "btnDisplayComponent"
        Me.btnDisplayComponent.Size = New System.Drawing.Size(230, 35)
        Me.btnDisplayComponent.TabIndex = 9
        Me.btnDisplayComponent.Text = "Display all using component"
        Me.btnDisplayComponent.UseVisualStyleBackColor = True
        '
        'UCtrlMapViewer1
        '
        Me.UCtrlMapViewer1.Location = New System.Drawing.Point(298, 37)
        Me.UCtrlMapViewer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UCtrlMapViewer1.Name = "UCtrlMapViewer1"
        Me.UCtrlMapViewer1.Size = New System.Drawing.Size(940, 538)
        Me.UCtrlMapViewer1.TabIndex = 10
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 858)
        Me.Controls.Add(Me.UCtrlMapViewer1)
        Me.Controls.Add(Me.btnDisplayComponent)
        Me.Controls.Add(Me.btnAll)
        Me.Controls.Add(Me.txtLat)
        Me.Controls.Add(Me.txtLongName)
        Me.Controls.Add(Me.btnDisplay)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblLongName)
        Me.Controls.Add(Me.lblLat)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.GMapControl1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Kaardirakendus"
        Me.Text = "Ühistransport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GMapControl1 As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents btnChoose As Button
    Friend WithEvents lblLat As Label
    Friend WithEvents lblLongName As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnDisplay As Button
    Friend WithEvents txtLongName As TextBox
    Friend WithEvents txtLat As TextBox
    Friend WithEvents btnAll As Button
    Friend WithEvents btnDisplayComponent As Button
    Friend WithEvents UCtrlMapViewer1 As UCtrlMapViewer.UCtrlMapViewer
End Class
