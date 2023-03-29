Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.WebRequestMethods
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms.ToolTips
Imports Microsoft.VisualBasic.FileIO
Imports File = System.IO.File
Public Class UCtrlMapViewer
    Public Sub map_Init()
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

    Public Sub Get_Stops()
        ' Read the stops data from the URL
        Dim url As String = "https://transport.tallinn.ee/data/stops.txt"
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "GET"
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

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
                    Dim tooltip As New GMapToolTip(marker)
                    tooltip.BackColor = Color.White
                    tooltip.AutoClosing = True
                    tooltip.AutoEllipsis = True
                    tooltip.MaximumSize = New Size(400, 0)
                    tooltip.Font = New Font("Segoe UI", 11, FontStyle.Bold)
                    tooltip.ForeColor = Color.Black
                    tooltip.Stroke = New Pen(Color.Transparent, 0)
                    tooltip.Offset = New Point(25, -45)
                    tooltip.IsBalloon = False
                    tooltip.TitleFont = New Font("Segoe UI", 12, FontStyle.Bold)
                    tooltip.TitleForeColor = Color.Black
                    tooltip.TitleText = stopName
                    tooltip.Text = "<div style='padding: 10px;'><p style='font-size: 12px; line-height: 150%;'>" & stopName & "</p></div>"
                    marker.ToolTip = tooltip
                    GMapControl1.UpdateMarkerLocalPosition(marker)
                    stopsOverlay.Markers.Add(marker)
                End If
            End While
        End Using
        GMapControl1.Overlays.Add(stopsOverlay)
        GMapControl1.Refresh()

        response.Close()
    End Sub




End Class
