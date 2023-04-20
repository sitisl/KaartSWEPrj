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
        Me.btnShowLines = New System.Windows.Forms.Button()
        Me.lBoxLiinid = New System.Windows.Forms.ListBox()
        Me.lBoxPeatused = New System.Windows.Forms.ListBox()
        Me.btnAB = New System.Windows.Forms.Button()
        Me.btnBA = New System.Windows.Forms.Button()
        Me.tBoxLink = New System.Windows.Forms.TextBox()
        Me.lBoxAjad = New System.Windows.Forms.ListBox()
        Me.btnShowStops = New System.Windows.Forms.Button()
        Me.lBoxRealTime = New System.Windows.Forms.ListBox()
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
        'btnShowLines
        '
        Me.btnShowLines.Location = New System.Drawing.Point(784, 24)
        Me.btnShowLines.Name = "btnShowLines"
        Me.btnShowLines.Size = New System.Drawing.Size(125, 23)
        Me.btnShowLines.TabIndex = 9
        Me.btnShowLines.Text = "Show all lines"
        Me.btnShowLines.UseVisualStyleBackColor = True
        '
        'lBoxLiinid
        '
        Me.lBoxLiinid.FormattingEnabled = True
        Me.lBoxLiinid.Location = New System.Drawing.Point(784, 129)
        Me.lBoxLiinid.Name = "lBoxLiinid"
        Me.lBoxLiinid.Size = New System.Drawing.Size(100, 264)
        Me.lBoxLiinid.TabIndex = 10
        Me.lBoxLiinid.Visible = False
        '
        'lBoxPeatused
        '
        Me.lBoxPeatused.FormattingEnabled = True
        Me.lBoxPeatused.Location = New System.Drawing.Point(890, 129)
        Me.lBoxPeatused.Name = "lBoxPeatused"
        Me.lBoxPeatused.Size = New System.Drawing.Size(130, 264)
        Me.lBoxPeatused.TabIndex = 11
        Me.lBoxPeatused.Visible = False
        '
        'btnAB
        '
        Me.btnAB.Location = New System.Drawing.Point(925, 24)
        Me.btnAB.Name = "btnAB"
        Me.btnAB.Size = New System.Drawing.Size(329, 23)
        Me.btnAB.TabIndex = 12
        Me.btnAB.UseVisualStyleBackColor = True
        Me.btnAB.Visible = False
        '
        'btnBA
        '
        Me.btnBA.Location = New System.Drawing.Point(925, 53)
        Me.btnBA.Name = "btnBA"
        Me.btnBA.Size = New System.Drawing.Size(329, 23)
        Me.btnBA.TabIndex = 13
        Me.btnBA.UseVisualStyleBackColor = True
        Me.btnBA.Visible = False
        '
        'tBoxLink
        '
        Me.tBoxLink.Location = New System.Drawing.Point(784, 406)
        Me.tBoxLink.Name = "tBoxLink"
        Me.tBoxLink.Size = New System.Drawing.Size(259, 20)
        Me.tBoxLink.TabIndex = 16
        '
        'lBoxAjad
        '
        Me.lBoxAjad.FormattingEnabled = True
        Me.lBoxAjad.Location = New System.Drawing.Point(1026, 129)
        Me.lBoxAjad.Name = "lBoxAjad"
        Me.lBoxAjad.Size = New System.Drawing.Size(208, 264)
        Me.lBoxAjad.TabIndex = 17
        Me.lBoxAjad.Visible = False
        '
        'btnShowStops
        '
        Me.btnShowStops.Location = New System.Drawing.Point(784, 53)
        Me.btnShowStops.Name = "btnShowStops"
        Me.btnShowStops.Size = New System.Drawing.Size(125, 23)
        Me.btnShowStops.TabIndex = 18
        Me.btnShowStops.Text = "Show all stops"
        Me.btnShowStops.UseVisualStyleBackColor = True
        '
        'lBoxRealTime
        '
        Me.lBoxRealTime.FormattingEnabled = True
        Me.lBoxRealTime.Location = New System.Drawing.Point(1240, 129)
        Me.lBoxRealTime.Name = "lBoxRealTime"
        Me.lBoxRealTime.Size = New System.Drawing.Size(95, 56)
        Me.lBoxRealTime.TabIndex = 20
        Me.lBoxRealTime.Visible = False
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1464, 595)
        Me.Controls.Add(Me.lBoxRealTime)
        Me.Controls.Add(Me.btnShowStops)
        Me.Controls.Add(Me.lBoxAjad)
        Me.Controls.Add(Me.tBoxLink)
        Me.Controls.Add(Me.btnBA)
        Me.Controls.Add(Me.btnAB)
        Me.Controls.Add(Me.lBoxPeatused)
        Me.Controls.Add(Me.lBoxLiinid)
        Me.Controls.Add(Me.btnShowLines)
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
    Friend WithEvents btnShowLines As Button
    Friend WithEvents lBoxLiinid As ListBox
    Friend WithEvents lBoxPeatused As ListBox
    Friend WithEvents btnAB As Button
    Friend WithEvents btnBA As Button
    Friend WithEvents tBoxLink As TextBox
    Friend WithEvents lBoxAjad As ListBox
    Friend WithEvents btnShowStops As Button
    Friend WithEvents lBoxRealTime As ListBox
End Class
