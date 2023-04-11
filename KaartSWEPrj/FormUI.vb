Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Kaardirakendus
    'Dim choose As Boolean = True

    Private Sub Kaardirakendus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnClear.Enabled = False
        btnRoute.Enabled = False
        checkBoxStops.Checked = True
        UCtrlMapViewer1.initMap()

    End Sub

    Private Sub checkBoxStops_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxStops.CheckedChanged
        UCtrlMapViewer1.showHideStops(checkBoxStops.Checked, UCtrlMapViewer1.getStops(UCtrlMapViewer1.drawMarker()))
    End Sub

    Private Sub UCtrlMapViewer1_LocationClicked(ByVal latitude As Double, ByVal longitude As Double) _
    Handles UCtrlMapViewer1.LocationClicked
        txtLat.Text = Math.Round(latitude, 5).ToString()
        txtLongName.Text = Math.Round(longitude, 5).ToString()
    End Sub

    Private Sub UCtrlMapViewer1_MarkerClicked(ByVal value As String) Handles UCtrlMapViewer1.MarkerClicked
        btnClear.Enabled = True
        If (txtStart.Text = "") Then
            txtStart.Text = value
        Else
            txtEnd.Text = value
            btnRoute.Enabled = True
        End If
    End Sub

    Private Sub btnRoute_Click(sender As Object, e As EventArgs) Handles btnRoute.Click
        If txtStart.Text IsNot "" And txtEnd.Text IsNot "" _
            And txtStart.Text IsNot txtEnd.Text Then
            UCtrlMapViewer1.GetRoute(txtStart.Text, txtEnd.Text)
        End If
        btnRoute.Enabled = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtStart.Text = ""
        txtEnd.Text = ""
        btnClear.Enabled = False
        btnRoute.Enabled = False
    End Sub

    'Private Sub txtStart_MouseClick(sender As Object, e As MouseEventArgs) Handles txtStart.MouseClick
    '   txtStart.Focus()
    'End Sub








    'Private Sub GMapControl1_OnMapClick(sender As Object, e As MouseEventArgs) Handles GMapControl1.OnMapClick
    ' Get the latitude and longitude of the clicked point
    'Dim lat As Double = GMapControl1.FromLocalToLatLng(e.X, e.Y).Lat
    'Dim lng As Double = GMapControl1.FromLocalToLatLng(e.X, e.Y).Lng
    'If (choose) Then
    '       btnChoose.Text = "Name"
    '      lblLongName.Text = "Longitude"
    '     lblLat.Visible = True
    '    txtLat.Visible = True
    '   choose = False
    'End If
    '   txtLongName.Text = lng
    '  txtLat.Text = lat
    'End Sub


    'Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
    'If (choose) Then
    '       btnChoose.Text = "Name"
    '      lblLongName.Text = "Longitude"
    '     txtLongName.Text = ""
    '    lblLat.Visible = True
    '   txtLat.Visible = True
    '  choose = False
    'Else
    '       btnChoose.Text = "Coordinates"
    '      lblLongName.Text = "Name"
    '     txtLongName.Text = ""
    '    txtLat.Text = ""
    '   lblLat.Visible = False
    '  txtLat.Visible = False
    ' choose = True
    'End If
    'End Sub

    'Private lastMarker As GMapMarker

    'Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
    'If (choose) Then

    'Else
    ' Clear all markers from the map
    '       GMapControl1.Overlays.Clear()

    ' Get the longitude and latitude coordinates from the textboxes
    'Dim longCoord As Double = CDbl(Val(txtLat.Text))
    'Dim latCoord As Double = CDbl(Val(txtLongName.Text))

    ' Set the position of the map control to the specified coordinates
    '       GMapControl1.ShowCenter = False
    '      GMapControl1.Position = New GMap.NET.PointLatLng(longCoord, latCoord)

    ' Create a new marker and add it to the map
    'Dim markers As GMapOverlay = New GMapOverlay("polygons")
    'Dim marker As GMapMarker = New GMarkerGoogle(GMapControl1.Position, GMarkerGoogleType.blue_dot)
    '       markers.Markers.Add(marker)
    '      GMapControl1.Overlays.Add(markers)

    ' Set some zoom properties and tooltip mode for the marker
    '     GMapControl1.MinZoom = 5
    '    GMapControl1.MaxZoom = 100
    '   GMapControl1.Zoom = 14
    '  marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
    'End If
    'End Sub

End Class
