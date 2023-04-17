Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers




' This class realizes the functionality of the map viewer graphic component
Public Class UCtrlMapViewer


    Private Sub UCtrlMapViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This code will run when the user control is loaded into a form or another container control
        '' Adjust the position of the button so it stays within the bounds of the form
        Panel1.Controls.Remove(CheckBox1)
        Panel1.Controls.Remove(CheckBox2)
        Panel1.Controls.Remove(CheckBox3)
        Panel1.Controls.Remove(CheckBox4)
        Dim padding As Integer = 10 ' Padding from the right and top edges of the form
        'Dim menuSize As Size = Panel1.Size
        Dim menuLocation As New Point(Me.ClientSize.Width - Button1.Width - padding, padding)
        Panel1.Location = menuLocation
        'menuPanel.Visible = False
        Panel1.Size = Button1.Size
        Button1.Location = New Point(Panel1.Width - Button1.Width, 0)
        CheckBox1.Checked = True
    End Sub




    ' Events to see coordinates and stops on the form
    Public Event LocationClicked(ByVal latitude As Double, ByVal longitude As Double)
    Public Event MarkerClicked(ByVal value As String, ByVal latitude As Double, ByVal longitude As Double)

    'The map is initialized in this sub
    Public Sub initMap()
        GMapControl1.MapProvider = BingMapProvider.Instance 'Bing for map provider
        'API key
        BingMapProvider.Instance.ClientKey = "9uNDiiSRdZbV6ok9Ec5t~H2haoDb04SzxUDigaGoUfg~Ajj9p1O58cpXmy-Y-BbTNAF8M1Ws3HjoFHGWOaSgIYCucioMsIkP3BpBZGI3XtWr"
        GMaps.Instance.Mode = AccessMode.ServerAndCache
        GMapControl1.ShowCenter = False
        GMapControl1.Position = New GMap.NET.PointLatLng(59.43, 24.75)
        GMapControl1.MinZoom = 11
        GMapControl1.MaxZoom = 20
        GMapControl1.Zoom = 11
        GMapControl1.DragButton = MouseButtons.Left
        'GMapControl1.BoundsOfMap = New RectLatLng(59.43, 24.75, 0.1, 0.1)
    End Sub

    Public Sub test()
        MsgBox("tere koik tootab")
    End Sub

    Public Sub showHideStops(ByRef isChecked As Boolean, ByRef stopsOverlay As GMapOverlay)
        If (isChecked = True) Then
            GMapControl1.Overlays.Add(stopsOverlay)
            GMapControl1.Refresh()
        Else
            GMapControl1.Overlays.Clear()
            GMapControl1.Refresh()
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

    Public Sub GMapControl1_MouseDown(sender As Object, e As MouseEventArgs) _
        Handles GMapControl1.MouseDown
        If e.Button = MouseButtons.Right Then
            ' Get the latitude and longitude of the clicked point
            Dim pointLatLng As PointLatLng = GMapControl1.FromLocalToLatLng(e.X, e.Y)
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
                    GMapControl1.UpdateMarkerLocalPosition(marker) 'This ensures that the markers appear on map
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

            GMapControl1.Overlays.Clear()
            GMapControl1.Overlays.Add(mapOverlay)

            GMapControl1.ZoomAndCenterRoute(routeOverlay)
        Else
            MessageBox.Show("No route found.")
        End If

    End Sub

    Public Sub clearRoute()
        GMapControl1.Overlays.Clear()
        GMapControl1.Refresh()
        CheckBox1.Checked = False
        CheckBox1.Checked = True
    End Sub


    Private Sub GMapControl1_OnMarkerClick(item As GMapMarker, e As MouseEventArgs) _
        Handles GMapControl1.OnMarkerClick
        Dim marker As GMarkerGoogle = TryCast(item, GMarkerGoogle)
        If marker IsNot Nothing Then
            RaiseEvent MarkerClicked(marker.ToolTipText, item.Position.Lat, item.Position.Lng)
        End If
    End Sub
    Private isResized As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Controls.Remove(Button1)
        Panel1.Hide()
        'Panel1.Location = New Point(Me.ClientSize.Width - Panel1.Width - 10, 10)
        Panel1.Width = CheckBox1.Width * 1.4
        Panel1.Height = CheckBox1.Height * 7
        'Panel1.AutoSize = True
        Panel1.Left = Me.ClientSize.Width - Panel1.Width - 10
        Panel1.Controls.Add(CheckBox1)
        Panel1.Controls.Add(CheckBox2)
        Panel1.Controls.Add(CheckBox3)
        Panel1.Controls.Add(CheckBox4)
        CheckBox1.Location = New Point(10, 10)
        CheckBox2.Location = New Point(10, 35)
        CheckBox3.Location = New Point(10, 60)
        CheckBox4.Location = New Point(10, 85)
        Panel1.Show()
        isResized = True
    End Sub

    Private Sub Panel1_MouseLeave(sender As Object, e As EventArgs) Handles Panel1.MouseLeave
        Dim panelBounds As Rectangle = Panel1.RectangleToScreen(Panel1.ClientRectangle)
        If Not panelBounds.Contains(Control.MousePosition) Then
            Panel1.Controls.Remove(CheckBox1)
            Panel1.Controls.Remove(CheckBox2)
            Panel1.Controls.Remove(CheckBox3)
            Panel1.Controls.Remove(CheckBox4)
            Panel1.Controls.Add(Button1)
            'Panel1.AutoSize = False
            Dim padding As Integer = 10 ' Padding from the right and top edges of the form
            'Dim menuSize As Size = Panel1.Size
            Dim menuLocation As New Point(Me.ClientSize.Width - Button1.Width - padding, padding)
            Panel1.Location = menuLocation
            'menuPanel.Visible = False
            Panel1.Size = Button1.Size
            Button1.Location = New Point(Panel1.Width - Button1.Width, 0)
            'Panel1.Size = Button1.Size
            isResized = False
            'Button1.Location = New Point(126 - Button1.Width, 0)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        showHideStops(CheckBox1.Checked, getStops(drawMarker()))
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




