<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Kaardirakendus
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.GMapControl1 = New GMap.NET.WindowsForms.GMapControl()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.lblLat = New System.Windows.Forms.Label()
        Me.lblLongName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.txtLongName = New System.Windows.Forms.TextBox()
        Me.txtLat = New System.Windows.Forms.TextBox()
        Me.btnAll = New System.Windows.Forms.Button()
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
        Me.GMapControl1.Location = New System.Drawing.Point(175, 24)
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
        Me.GMapControl1.Size = New System.Drawing.Size(603, 402)
        Me.GMapControl1.TabIndex = 0
        Me.GMapControl1.Zoom = 0R
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(12, 46)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(75, 23)
        Me.btnChoose.TabIndex = 1
        Me.btnChoose.Text = "Name"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'lblLat
        '
        Me.lblLat.AutoSize = True
        Me.lblLat.Location = New System.Drawing.Point(12, 129)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(45, 13)
        Me.lblLat.TabIndex = 2
        Me.lblLat.Text = "Latitude"
        '
        'lblLongName
        '
        Me.lblLongName.AutoSize = True
        Me.lblLongName.Location = New System.Drawing.Point(9, 84)
        Me.lblLongName.Name = "lblLongName"
        Me.lblLongName.Size = New System.Drawing.Size(54, 13)
        Me.lblLongName.TabIndex = 3
        Me.lblLongName.Text = "Longitude"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Choose stop"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(93, 46)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(75, 23)
        Me.btnDisplay.TabIndex = 5
        Me.btnDisplay.Text = "Display"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        'txtLongName
        '
        Me.txtLongName.Location = New System.Drawing.Point(12, 100)
        Me.txtLongName.Name = "txtLongName"
        Me.txtLongName.Size = New System.Drawing.Size(100, 20)
        Me.txtLongName.TabIndex = 6
        '
        'txtLat
        '
        Me.txtLat.Location = New System.Drawing.Point(12, 145)
        Me.txtLat.Name = "txtLat"
        Me.txtLat.Size = New System.Drawing.Size(100, 20)
        Me.txtLat.TabIndex = 7
        '
        'btnAll
        '
        Me.btnAll.Location = New System.Drawing.Point(15, 181)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(75, 23)
        Me.btnAll.TabIndex = 8
        Me.btnAll.Text = "Display All"
        Me.btnAll.UseVisualStyleBackColor = True
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnAll)
        Me.Controls.Add(Me.txtLat)
        Me.Controls.Add(Me.txtLongName)
        Me.Controls.Add(Me.btnDisplay)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblLongName)
        Me.Controls.Add(Me.lblLat)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.GMapControl1)
        Me.Name = "Kaardirakendus"
        Me.Text = "Form1"
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
End Class
