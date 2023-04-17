Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Windows.Forms.VisualStyles
Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers




' This class realizes the functionality of the map viewer graphic component
Public Class UCtrlMapViewer

    ' Flag for checking if the layerPanel is resized
    Private isResized As Boolean = False

    Private Sub UCtrlMapViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This code will run when the user control is loaded into a form or another container control
        panelLayers_Init()
        cbStops.Checked = True
    End Sub

    Private Sub panelLayers_Init()
        panelLayers.Parent = gMap1
        panelLayers.BackColor = Color.Transparent
        panelLayers.Controls.Clear()
        panelLayers.Controls.Add(btnLayers)
        Dim padding As Integer = 10 ' Padding from the right and top edges of the form
        Dim menuLocation As New Point(Me.ClientSize.Width - btnLayers.Width - padding, padding)
        panelLayers.Location = menuLocation
        panelLayers.Size = btnLayers.Size
        btnLayers.Location = New Point(panelLayers.Width - btnLayers.Width, 0)
    End Sub
    Private Sub btnLayers_Paint(sender As Object, e As PaintEventArgs) Handles btnLayers.Paint
        Dim originalImage As Image = My.Resources.layers_white
        ' Create a smaller copy of the original image
        Dim imageSize As New Size(32, 32)
        Dim resizedImage As New Bitmap(originalImage, imageSize)
        ' Calculate the target location
        Dim targetLocation As New Point((btnLayers.Width - imageSize.Width) \ 2, (btnLayers.Height - imageSize.Height) \ 2)
        ' Draw the image in the target location
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImage(resizedImage, targetLocation)
    End Sub

    ' Events to see coordinates and stops on the form
    Public Event LocationClicked(ByVal latitude As Double, ByVal longitude As Double)
    Public Event MarkerClicked(ByVal value As String, ByVal latitude As Double, ByVal longitude As Double)

    Public Sub initMap()
        initializeMap()
    End Sub
    'The map is initialized in this sub
    Private Sub initializeMap()
        gMap1.MapProvider = BingMapProvider.Instance 'Bing for map provider
        'API key
        BingMapProvider.Instance.ClientKey = "9uNDiiSRdZbV6ok9Ec5t~H2haoDb04SzxUDigaGoUfg~Ajj9p1O58cpXmy-Y-BbTNAF8M1Ws3HjoFHGWOaSgIYCucioMsIkP3BpBZGI3XtWr"
        GMaps.Instance.Mode = AccessMode.ServerAndCache
        gMap1.ShowCenter = False
        gMap1.Position = New GMap.NET.PointLatLng(59.43, 24.75)
        gMap1.MinZoom = 11
        gMap1.MaxZoom = 20
        gMap1.Zoom = 11
        gMap1.DragButton = MouseButtons.Left
        'GMapControl1.BoundsOfMap = New RectLatLng(59.43, 24.75, 0.1, 0.1)
    End Sub

    Public Sub test()
        MsgBox("tere koik tootab")
    End Sub

    Public Sub showHideStops(ByRef isChecked As Boolean, ByRef stopsOverlay As GMapOverlay)
        If (isChecked = True) Then
            gMap1.Overlays.Add(stopsOverlay)
            gMap1.Refresh()
        Else
            gMap1.Overlays.Clear()
            gMap1.Refresh()
        End If
    End Sub

    Public Function drawMarker()
        ' Create a custom marker with 80% fill opacity, orange fill, black stroke, and circle shape
        Dim markerSize As Integer = 10
        Dim markerBitmap As New Bitmap(markerSize, markerSize)
        Using g As Graphics = Graphics.FromImage(markerBitmap)
            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim brush As New SolidBrush(Color.FromArgb(204, Color.Orange))
            Dim pen As New Pen(Color.Black)
            Dim circleRect As New Rectangle(0, 0, markerSize - 1, markerSize - 1)
            g.FillEllipse(brush, circleRect)
            g.DrawEllipse(pen, circleRect)
        End Using
        Return markerBitmap
    End Function

    Public Sub gMap1_MouseDown(sender As Object, e As MouseEventArgs) _
        Handles gMap1.MouseDown
        If e.Button = MouseButtons.Right Then
            ' Get the latitude and longitude of the clicked point
            Dim pointLatLng As PointLatLng = gMap1.FromLocalToLatLng(e.X, e.Y)
            RaiseEvent LocationClicked(pointLatLng.Lat, pointLatLng.Lng)
        End If
    End Sub

    Public Function getStops(ByRef markerBitmap As Bitmap)
        ' Read the stops data from the URL
        Dim url As String = "https://transport.tallinn.ee/data/stops.txt"
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "GET"
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        ' Parse the CSV data and add markers for each stop
        Dim stopsOverlay As New GMapOverlay("stopsOverlay")
        Dim marker As GMarkerGoogle
        Dim latitude, longitude As Double
        Dim stopName As String
        Using reader As New StreamReader(response.GetResponseStream())
            reader.ReadLine() ' skip the first line
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()
                Dim fields As String() = line.Split(";")
                If fields.Length >= 6 Then
                    stopName = fields(5)
                    latitude = Double.Parse(fields(2), CultureInfo.InvariantCulture) / 100000
                    longitude = Double.Parse(fields(3), CultureInfo.InvariantCulture) / 100000
                    marker = New GMarkerGoogle(New PointLatLng(latitude, longitude), markerBitmap)
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
                    Dim toolTip As New CustomToolTip(marker)
                    toolTip.Offset = New Point(5, -markerBitmap.Height / 2)
                    marker.ToolTip = toolTip
                    marker.ToolTipText = stopName
                    gMap1.UpdateMarkerLocalPosition(marker) 'This ensures that the markers appear on map
                    stopsOverlay.Markers.Add(marker)               'without refreshing in the beginning
                End If
            End While
        End Using
        response.Close()
        Return stopsOverlay
    End Function

    Public Sub getRoute(startPoint As PointLatLng, endPoint As PointLatLng)
        showHideStops(False, getStops(drawMarker()))
        ' Define the route overlay and add it to the map
        Dim mapOverlay As GMapOverlay = New GMapOverlay("routes")
        'Gets route using Bing API with start and destination coordinate
        Dim route As MapRoute = GMapProviders.BingMap.GetRoute(startPoint, endPoint, False, False, 15)

        If route IsNot Nothing AndAlso route.Points.Count > 1 Then
            Dim routeOverlay As GMapRoute = New GMapRoute(route.Points, "Route")
            routeOverlay.Stroke = New Pen(Color.FromArgb(128, Color.Red), 5)
            Dim routePoints As List(Of PointLatLng) = route.Points
            mapOverlay.Routes.Add(routeOverlay)

            Dim startMarker As GMarkerGoogle = New GMarkerGoogle(startPoint, GMarkerGoogleType.green)
            'startMarker.ToolTipText = "Start"
            mapOverlay.Markers.Add(startMarker)

            Dim endMarker As GMarkerGoogle = New GMarkerGoogle(endPoint, GMarkerGoogleType.red)
            'endMarker.ToolTipText = "End"
            mapOverlay.Markers.Add(endMarker)

            gMap1.Overlays.Clear()
            gMap1.Overlays.Add(mapOverlay)

            gMap1.ZoomAndCenterRoute(routeOverlay)
        Else
            MessageBox.Show("No route found.")
        End If
    End Sub

    Public Sub clearRoute()
        gMap1.Overlays.Clear()
        gMap1.Refresh()
        cbStops.Checked = False
        cbStops.Checked = True
    End Sub

    Private Sub gMap1_OnMarkerClick(item As GMapMarker, e As MouseEventArgs) _
        Handles gMap1.OnMarkerClick
        Dim marker As GMarkerGoogle = TryCast(item, GMarkerGoogle)
        If marker IsNot Nothing Then
            RaiseEvent MarkerClicked(marker.ToolTipText, item.Position.Lat, item.Position.Lng)
        End If
    End Sub


    Private Sub btnLayers_MouseEnter(sender As Object, e As EventArgs) Handles btnLayers.MouseEnter
        panelLayers.Hide()
        panelLayers.Controls.Clear()
        panelLayers.Cursor = Cursors.Arrow
        panelLayers.Width = cbStops.Width * 1.4
        panelLayers.Height = cbStops.Height * 6
        panelLayers.Left = Me.ClientSize.Width - panelLayers.Width - 10
        panelLayers.Controls.Add(cbStops)
        panelLayers.Controls.Add(cbBuses)
        panelLayers.Controls.Add(cbTram)
        panelLayers.Controls.Add(cbTroll)
        cbStops.Location = New Point(10, 10)
        cbBuses.Location = New Point(10, 35)
        cbTram.Location = New Point(10, 60)
        cbTroll.Location = New Point(10, 85)
        panelLayers.Show()
        isResized = True
    End Sub

    Private Sub panelLayers_MouseLeave(sender As Object, e As EventArgs) Handles panelLayers.MouseLeave
        Dim panelBounds As Rectangle = panelLayers.RectangleToScreen(panelLayers.ClientRectangle)
        If Not panelBounds.Contains(Control.MousePosition) Then
            panelLayers.Hide()
            panelLayers.Controls.Clear()
            panelLayers.Controls.Add(btnLayers)
            Dim padding As Integer = 10 ' Padding from the right and top edges of the form
            Dim menuLocation As New Point(Me.ClientSize.Width - btnLayers.Width - padding, padding)
            panelLayers.Location = menuLocation
            panelLayers.Size = btnLayers.Size
            btnLayers.Location = New Point(panelLayers.Width - btnLayers.Width, 0)
            isResized = False
            panelLayers.Show()
        End If
    End Sub


    Private Sub cbStops_CheckedChanged(sender As Object, e As EventArgs) Handles cbStops.CheckedChanged
        showHideStops(cbStops.Checked, getStops(drawMarker()))
    End Sub


    Private Sub panelLayers_Paint(sender As Object, e As PaintEventArgs) Handles panelLayers.Paint
        Dim g As Graphics = e.Graphics
        Dim rect As Rectangle = panelLayers.ClientRectangle
        Dim padding As Integer = 5
        Dim path As New GraphicsPath()
        path.AddRectangle(rect)
        ' Use a gradient brush to fill the panel with a modern color scheme
        Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
        g.FillPath(brush, path)
        g.DrawPath(New Pen(Color.FromArgb(255, 15, 15, 15), 1), path)
    End Sub

End Class


'Class for creating a modern tooltip box for the bus stop markers
Public Class CustomToolTip
    Inherits GMapToolTip

    Public Sub New(marker As GMapMarker)
        MyBase.New(marker)
    End Sub
    Public Overrides Sub OnRender(g As Graphics)
        Dim textSize As SizeF = g.MeasureString(Marker.ToolTipText, New Font("Segoe UI", 10))
        Dim padding As Integer = 5
        Dim rect As New RectangleF(Marker.ToolTipPosition.X, Marker.ToolTipPosition.Y - textSize.Height - padding, textSize.Width + padding * 2, textSize.Height + padding * 2)

        Dim path As New GraphicsPath()
        Dim radius As Integer = CInt(rect.Height / 2)
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        ' Use a gradient brush to fill the tooltip with a modern color scheme
        Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
        g.FillPath(brush, path)
        g.DrawPath(New Pen(Color.FromArgb(255, 15, 15, 15), 1), path)

        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center

        ' Use a light text color for the tooltip
        g.DrawString(Marker.ToolTipText, New Font("Segoe UI", 10), Brushes.Snow, rect, format)
    End Sub


End Class




