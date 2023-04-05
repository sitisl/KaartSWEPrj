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

    'The map is initialized in this sub
    Public Sub initMap()
        GMapControl1.MapProvider = BingMapProvider.Instance
        GMaps.Instance.Mode = AccessMode.ServerAndCache
        GMapControl1.ShowCenter = False
        GMapControl1.Position = New GMap.NET.PointLatLng(59.4001962726054, 24.664921814958522)
        '59.4001962726054, 24.66492181495852
        '59,4001962726054, 24,66492181495852
        GMapControl1.MinZoom = 5
        GMapControl1.MaxZoom = 100
        GMapControl1.Zoom = 10
        GMapControl1.DragButton = MouseButtons.Left
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
        ' Add the markers overlay to the map
        'GMapControl1.Overlays.Add(stopsOverlay)
        'GMapControl1.Refresh()
        response.Close()
        Return stopsOverlay
    End Function

End Class

'Class for creating a modern looking tooltip for the bus stop markers
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




