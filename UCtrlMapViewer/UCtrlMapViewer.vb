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
Imports Microsoft.VisualBasic.FileIO
Imports File = System.IO.File
Public Class UCtrlMapViewer
    Public Sub map_Init()
        GMapControl1.MapProvider = GoogleMapProvider.Instance
        GMaps.Instance.Mode = AccessMode.ServerAndCache
        GMapControl1.ShowCenter = False

        GMapControl1.Position = New GMap.NET.PointLatLng(59.4001962726054, 24.664921814958522)
        '59.4001962726054, 24.66492181495852
        '59,4001962726054, 24,66492181495852
        GMapControl1.MinZoom = 5
        GMapControl1.MaxZoom = 100
        GMapControl1.Zoom = 10
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

        ' Parse the CSV data and add markers for each stop
        Dim stopsOverlay As New GMapOverlay("stopsOverlay")
        Dim markerType As GMarkerGoogleType = GMarkerGoogleType.red_small
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
                    latitude = Double.Parse(fields(2), CultureInfo.InvariantCulture)
                    longitude = Double.Parse(fields(3), CultureInfo.InvariantCulture)
                    latitude = latitude / 100000.0
                    longitude = longitude / 100000.0
                    marker = New GMarkerGoogle(New PointLatLng(latitude, longitude), markerType)
                    marker.ToolTipText = stopName
                    stopsOverlay.Markers.Add(marker)
                End If
            End While
        End Using
        GMapControl1.Overlays.Add(stopsOverlay)
        GMapControl1.Refresh()

        response.Close()
    End Sub
End Class
