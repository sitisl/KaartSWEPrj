Imports System.Drawing.Drawing2D
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports StopStruct = UTimeTable.ITimeTable.StopStruct
Imports TransportStruct = UTimeTable.ITimeTable.TransportStruct
Public Class CStopsAndVehicles

    Private busesOverlay As New GMapOverlay("busesOverlay")
    Private trolleysOverlay As New GMapOverlay("trolleysOverlay")
    Private tramsOverlay As New GMapOverlay("tramsOverlay")
    Private stopsOverlay As New GMapOverlay("stopsOverlay")

    Public Sub showHideStops(ByRef isChecked As Boolean, ByRef gMap1 As GMapControl)
        getStops(gMap1)
        If (isChecked = True) Then
            gMap1.Overlays.Add(stopsOverlay)
            gMap1.Refresh()
        Else
            stopsOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub

    'This method shows or hides the trams on the map
    Public Sub showHideTrams(ByRef isChecked As Boolean, ByRef gMap1 As GMapControl)
        GetTrams(drawMarker("LightGreen", 10), gMap1)
        If (isChecked = True) Then
            gMap1.Overlays.Add(tramsOverlay)
            gMap1.Refresh()
        Else
            tramsOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub

    'This method shows or hides the trolleys on the map
    Public Sub showHideTrolleys(ByRef isChecked As Boolean, ByRef gMap1 As GMapControl)
        GetTrolleys(drawMarker("Yellow", 10), gMap1)
        If (isChecked = True) Then
            gMap1.Overlays.Add(trolleysOverlay)
            gMap1.Refresh()
        Else
            trolleysOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub

    Public Sub showHideBuses(ByRef isChecked As Boolean, ByRef gMap1 As GMapControl)
        GetBuses(drawMarker("Cyan", 10), gMap1)
        If (isChecked = True) Then
            gMap1.Overlays.Add(busesOverlay)
            gMap1.Refresh()
        Else
            busesOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub
    Public Function drawMarker(colorDot As String, markerSize As Integer)
        ' Create a custom marker with 80% fill opacity, orange fill, black stroke, and circle shape
        Dim markerBitmap As New Bitmap(markerSize, markerSize)
        Using g As Graphics = Graphics.FromImage(markerBitmap)
            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim brush As New SolidBrush(Color.FromArgb(204, Color.FromName(colorDot)))
            Dim pen As New Pen(Color.Black)
            Dim circleRect As New Rectangle(0, 0, markerSize - 1, markerSize - 1)
            g.FillEllipse(brush, circleRect)
            g.DrawEllipse(pen, circleRect)
        End Using
        Return markerBitmap
    End Function

    Private Function GetBuses(ByRef markerBitmap As Bitmap, ByRef gMap1 As GMapControl)
        Dim realTime As UTimeTable.ITimeTable = New UTimeTable.UTimeTable
        Dim buses As List(Of TransportStruct) = realTime.GetRealTimeTransport("bus")
        Dim marker As GMarkerGoogle
        busesOverlay.Markers.Clear()
        For Each buses_el As TransportStruct In buses
            marker = New GMarkerGoogle(New PointLatLng(buses_el.Latitude, buses_el.Longitude), markerBitmap)
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
            Dim toolTip As New CustomToolTip(marker)
            toolTip.Offset = New Point(5, -markerBitmap.Height / 2)
            marker.ToolTip = toolTip
            marker.ToolTipText = buses_el.Number
            gMap1.UpdateMarkerLocalPosition(marker) 'This ensures that the markers appear on map
            busesOverlay.Markers.Add(marker)
        Next
        Return busesOverlay
    End Function
    Private Function GetTrams(ByRef markerBitmap As Bitmap, ByRef gMap1 As GMapControl)
        Dim realTime As UTimeTable.ITimeTable = New UTimeTable.UTimeTable
        Dim trams As List(Of TransportStruct) = realTime.GetRealTimeTransport("tram")
        Dim marker As GMarkerGoogle
        tramsOverlay.Markers.Clear()
        For Each trams_el As TransportStruct In trams
            marker = New GMarkerGoogle(New PointLatLng(trams_el.Latitude, trams_el.Longitude), markerBitmap)
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
            Dim toolTip As New CustomToolTip(marker)
            toolTip.Offset = New Point(5, -markerBitmap.Height / 2)
            marker.ToolTip = toolTip
            marker.ToolTipText = trams_el.Number
            gMap1.UpdateMarkerLocalPosition(marker) 'This ensures that the markers appear on map
            tramsOverlay.Markers.Add(marker)
        Next
        Return tramsOverlay
    End Function
    Private Function GetTrolleys(ByRef markerBitmap As Bitmap, ByRef gMap1 As GMapControl)
        Dim realTime As UTimeTable.ITimeTable = New UTimeTable.UTimeTable
        Dim trolleys As List(Of TransportStruct) = realTime.GetRealTimeTransport("trolley")
        Dim marker As GMarkerGoogle
        trolleysOverlay.Markers.Clear()
        For Each trolleys_el As TransportStruct In trolleys
            marker = New GMarkerGoogle(New PointLatLng(trolleys_el.Latitude, trolleys_el.Longitude), markerBitmap)
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
            Dim toolTip As New CustomToolTip(marker)
            toolTip.Offset = New Point(5, -markerBitmap.Height / 2)
            marker.ToolTip = toolTip
            marker.ToolTipText = trolleys_el.Number
            gMap1.UpdateMarkerLocalPosition(marker) 'This ensures that the markers appear on map
            trolleysOverlay.Markers.Add(marker)
        Next
        Return trolleysOverlay
    End Function
    Private Function getStopsData(ByRef markerBitmap As Bitmap, ByRef gMap1 As GMapControl)
        Dim timeT As UTimeTable.ITimeTable = New UTimeTable.UTimeTable
        Dim stops As List(Of StopStruct) = timeT.GetStopsCoordinates()
        Dim marker As GMarkerGoogle
        For Each stop_el As StopStruct In stops
            marker = New GMarkerGoogle(New PointLatLng(stop_el.Latitude, stop_el.Longitude), markerBitmap)
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
            Dim toolTip As New CustomToolTip(marker)
            'toolTip.Offset = New Point(20, -markerBitmap.Height / 2)
            marker.ToolTip = toolTip
            marker.ToolTipText = stop_el.Name
            marker.Tag = stop_el.ID
            gMap1.UpdateMarkerLocalPosition(marker) 'This ensures that the markers appear on map
            stopsOverlay.Markers.Add(marker)
        Next
        Return stopsOverlay
    End Function
    Public Function getStops(ByRef gMap1 As GMapControl) As Object
        Return getStopsData(drawMarker("Orange", 9), gMap1)
    End Function
End Class
