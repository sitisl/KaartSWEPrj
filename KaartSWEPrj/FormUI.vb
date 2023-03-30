Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports System.IO
Imports System.Net
Imports System.Windows

Public Class Kaardirakendus
    'Dim choose As Boolean = True

    'Private Sub Kaardirakendus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '   GMapControl1.MapProvider = GoogleMapProvider.Instance
    '  GMaps.Instance.Mode = AccessMode.ServerAndCache
    ' GMapControl1.ShowCenter = False

    ' GMapControl1.Position = New GMap.NET.PointLatLng(59.4380930599551, 24.7590637207031)
    'GMapControl1.MinZoom = 5
    'GMapControl1.MaxZoom = 100
    'GMapControl1.Zoom = 10

    'End Sub

    Private Sub btnDisplayComponent_Click(sender As Object, e As EventArgs) Handles btnDisplayComponent.Click
        UCtrlMapViewer1.map_Init()
        UCtrlMapViewer1.Get_Stops(UCtrlMapViewer1.drawMarker())
    End Sub

    Private Sub checkBoxStops_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxStops.CheckedChanged

    End Sub

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

    'Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
    ' Clear all markers from the map
    '   GMapControl1.Overlays.Clear()

    ' Download the stops.txt file
    'Dim client As WebClient = New WebClient()
    'Dim data As Stream = client.OpenRead("https://transport.tallinn.ee/data/stops.txt")
    'Dim reader As New StreamReader(data)
    'Dim line As String
    'Dim fields As String()
    'Dim lat As Double
    'Dim lng As Double

    '   GMapControl1.ShowCenter = False
    'Dim markers As GMapOverlay = New GMapOverlay("markers")
    'While Not reader.EndOfStream
    '       line = reader.ReadLine()
    '      fields = line.Split(";")
    'If fields.Length >= 4 AndAlso Integer.TryParse(fields(2), Nothing) AndAlso Integer.TryParse(fields(3), Nothing) Then
    '           lat = CDbl(fields(2)) / 100000
    '          lng = CDbl(fields(3)) / 100000
    'Dim busStop As PointLatLng = New GMap.NET.PointLatLng(lat, lng)
    'Dim marker As GMapMarker = New GMarkerGoogle(busStop, GMarkerGoogleType.red_small)
    '           markers.Markers.Add(marker)
    'Console.WriteLine("Bus Stop at Latitude: " & busStop.Lat.ToString() & ", Longitude: " & busStop.Lng.ToString())
    'End If
    'End While

    ' Add the markers overlay to the map
    '   GMapControl1.Overlays.Add(markers)
    '  GMapControl1.Refresh()
    'End Sub


End Class
