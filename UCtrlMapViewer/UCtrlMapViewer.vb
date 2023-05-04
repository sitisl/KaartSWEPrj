Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports Newtonsoft.Json.Linq
Imports PrjRealTime
Imports PrjRealTime.CRealTime
Imports UTimeTable.UTimeTable


' This class realizes the functionality of the map viewer graphic component
Public Class UCtrlMapViewer
    ' Flag for checking if the layerPanel is resized
    Private isResized As Boolean = False
    Private startCoord As PointLatLng
    Private endCoord As PointLatLng
    Private startAddress As String
    Private destAddress As String
    Private stopMarker As GMarkerGoogle
    Private apiKey As String = "9uNDiiSRdZbV6ok9Ec5t~H2haoDb04SzxUDigaGoUfg~Ajj9p1O58cpXmy-Y-BbTNAF8M1Ws3HjoFHGWOaSgIYCucioMsIkP3BpBZGI3XtWr"

    Public timeT As New UTimeTable.UTimeTable
    Private WithEvents transportTimer As New Timer()
    Dim busesOverlay As New GMapOverlay("busesOverlay")
    Dim stopsOverlay As New GMapOverlay("stopsOverlay")
    Dim trolleysOverlay As New GMapOverlay("trolleysOverlay")
    Dim tramsOverlay As New GMapOverlay("tramsOverlay")
    Dim routesOverlay As New WindowsForms.GMapOverlay("RoutesOverlay")


    Private Sub UCtrlMapViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This code will run when the user control is loaded into a form or another container control
        panelLayers_Init()
        cbStops.Checked = True
        transportTimer.Interval = 5000 ' 1 second
        transportTimer.Enabled = True
        lblStart.Parent = gMap1
        lblDest.Parent = gMap1
        btnClear.Enabled = False
        btnRoute.Enabled = False
        panelPopup.Visible = False
        btnZoomIn.Parent = gMap1
        btnZoomOut.Parent = gMap1
        btnRoute.Parent = gMap1
        btnClear.Parent = gMap1
    End Sub

    Public Sub initMap()
        initializeMap()
    End Sub
    'The map is initialized in this sub
    Private Sub initializeMap()
        gMap1.MapProvider = BingMapProvider.Instance 'Bing for map provider
        'API key
        BingMapProvider.Instance.ClientKey = apiKey
        GMaps.Instance.Mode = AccessMode.ServerAndCache
        gMap1.ShowCenter = False
        gMap1.Position = New GMap.NET.PointLatLng(59.43, 24.75)
        gMap1.MinZoom = 11
        gMap1.MaxZoom = 20
        gMap1.Zoom = 12
        gMap1.DragButton = MouseButtons.Left
        'gMap1.ForceDoubleBuffer = True
        'GMaps.Instance.UseMemoryCache = True
        'GMapControl1.BoundsOfMap = New RectLatLng(59.43, 24.75, 0.1, 0.1)
    End Sub

    Private Sub panelLayers_Init()
        'panelLayers.Parent = gMap1
        panelLayers.BackColor = Color.Transparent
        panelLayers.Controls.Clear()
        panelLayers.Controls.Add(btnLayers)
        Dim padding As Integer = 10 ' Padding from the right and top edges of the form
        Dim menuLocation As New Point(Me.ClientSize.Width - btnLayers.Width - padding, padding)
        panelLayers.Location = menuLocation
        panelLayers.Size = btnLayers.Size
        btnLayers.Location = New Point(panelLayers.Width - btnLayers.Width, 0)
    End Sub

    'Gets stops from database and adds them to the map
    Public Function getStopsSQL(ByRef markerBitmap As Bitmap)
        Dim stops As List(Of StopStruct) = timeT.GetStopsCoordinates()
        Dim marker As GMarkerGoogle
        For Each stop_el As StopStruct In stops
            marker = New GMarkerGoogle(New PointLatLng(stop_el.Latitude, stop_el.Longitude), markerBitmap)
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
            Dim toolTip As New CustomToolTip(marker)
            toolTip.Offset = New Point(5, -markerBitmap.Height / 2)
            marker.ToolTip = toolTip
            marker.ToolTipText = stop_el.Name
            gMap1.UpdateMarkerLocalPosition(marker) 'This ensures that the markers appear on map
            stopsOverlay.Markers.Add(marker)
        Next
        Return stopsOverlay
    End Function

    Public Sub DisplayShapes(ByVal routePoints As List(Of StopStruct), ByVal routeStops As List(Of StopStruct))
        Dim route As New WindowsForms.GMapRoute(New List(Of PointLatLng), "My Route")
        For Each point As StopStruct In routePoints
            route.Points.Add(New PointLatLng(point.Latitude, point.Longitude))
        Next
        Dim marker As GMarkerGoogle
        Dim markerBitmap As Bitmap = drawMarker("Orange")
        For i As Integer = 0 To routeStops.Count - 1
            Dim stop_el As StopStruct = routeStops(i)
            marker = New GMarkerGoogle(New PointLatLng(stop_el.Latitude, stop_el.Longitude), markerBitmap)
            If i = 0 OrElse i = routeStops.Count - 1 Then
                marker.ToolTipMode = MarkerTooltipMode.Always
            Else
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
            End If
            Dim toolTip As New CustomToolTip(marker)
            toolTip.Offset = New Point(5, -drawMarker("Orange").Height / 2)
            marker.ToolTip = toolTip
            marker.ToolTipText = stop_el.Name
            gMap1.UpdateMarkerLocalPosition(marker) 'This ensures that the markers appear on map
            routesOverlay.Markers.Add(marker)
        Next
        routesOverlay.Routes.Add(route)
        gMap1.Overlays.Insert(0, routesOverlay)
        gMap1.UpdateRouteLocalPosition(route)
        gMap1.Refresh()
    End Sub
    Public Sub ClearShapes()
        routesOverlay.Clear()
        gMap1.Refresh()
    End Sub

    ' Events to see coordinates and stops on the form
    Public Event LocationClicked(ByVal latitude As Double, ByVal longitude As Double)
    Public Event MarkerClicked(ByVal value As String, ByVal latitude As Double, ByVal longitude As Double)

    '------------------Paint events and personalization of the user controls-------------------
    'These events and functions override the default behaviour and appearance of the controls
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
    Public Function drawMarker(colorDot As String)
        ' Create a custom marker with 80% fill opacity, orange fill, black stroke, and circle shape
        Dim markerSize As Integer = 10
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

    Private Sub lblStart_Paint(sender As Object, e As PaintEventArgs) Handles lblStart.Paint
        Using brush As New LinearGradientBrush(lblStart.ClientRectangle, Color.FromArgb(204, 25, 25, 25), Color.FromArgb(204, 10, 10, 10), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, lblStart.ClientRectangle)
        End Using
        Dim textFont = New Font("Segoe UI", 10, FontStyle.Regular)
        Dim textFormat = New StringFormat() With {.LineAlignment = StringAlignment.Center}
        Dim textRect = New RectangleF(PointF.Empty, lblStart.Size)
        If lblStart.Text = "" Then
            Dim textColor = Color.Gray
            Dim text As String = "Algus"
            e.Graphics.DrawString(" " + text, textFont, New SolidBrush(textColor), textRect, textFormat)
        Else
            Dim textColor = Color.Snow
            e.Graphics.DrawString(" " + lblStart.Text, textFont, New SolidBrush(textColor), textRect, textFormat)
        End If

    End Sub

    Private Sub lblDest_Paint(sender As Object, e As PaintEventArgs) Handles lblDest.Paint
        Using brush As New LinearGradientBrush(lblDest.ClientRectangle, Color.FromArgb(204, 25, 25, 25), Color.FromArgb(204, 10, 10, 10), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, lblDest.ClientRectangle)
        End Using
        Dim textFont = New Font("Segoe UI", 10, FontStyle.Regular)
        Dim textFormat = New StringFormat() With {.LineAlignment = StringAlignment.Center}
        Dim textRect = New RectangleF(PointF.Empty, lblDest.Size)
        If lblDest.Text = "" Then
            Dim textColor = Color.Gray
            Dim text As String = "Sihtkoht"
            e.Graphics.DrawString(" " + text, textFont, New SolidBrush(textColor), textRect, textFormat)
        Else
            Dim textColor = Color.Snow
            e.Graphics.DrawString(" " + lblDest.Text, textFont, New SolidBrush(textColor), textRect, textFormat)
        End If
    End Sub

    Private Sub btnZoomIn_Paint(sender As Object, e As PaintEventArgs) Handles btnZoomIn.Paint
        ' Draw background gradient
        If btnZoomIn.ClientRectangle.Contains(btnZoomIn.PointToClient(Control.MousePosition)) Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnZoomIn.ClientRectangle)
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnZoomIn.Width, btnZoomIn.Height)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
        End If

        Dim text As String = "+"
        Dim font As New Font("Segoe UI", 32, FontStyle.Bold)
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)
        Dim textX As Single = (btnZoomIn.Width - textSize.Width) / 2
        Dim textY As Single = (btnZoomIn.Height - textSize.Height / 1.05)
        e.Graphics.DrawString(text, font, Brushes.Snow, textX, textY)
    End Sub

    Private Sub btnZoomOut_Paint(sender As Object, e As PaintEventArgs) Handles btnZoomOut.Paint
        ' Draw background gradient
        If btnZoomOut.ClientRectangle.Contains(btnZoomOut.PointToClient(Control.MousePosition)) Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnZoomOut.ClientRectangle)
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnZoomOut.Width, btnZoomOut.Height)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
        End If

        ' Draw centered text
        Dim text As String = ChrW(&H2212)
        Dim font As New Font("Segoe UI", 32, FontStyle.Bold)
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)
        Dim textX As Single = (btnZoomIn.Width - textSize.Width) / 2
        Dim textY As Single = (btnZoomIn.Height - textSize.Height / 1.05)
        e.Graphics.DrawString(text, font, Brushes.Snow, textX, textY)
    End Sub

    Private Sub btnRoute_Paint(sender As Object, e As PaintEventArgs) Handles btnRoute.Paint
        ' Draw background gradient
        If btnRoute.ClientRectangle.Contains(btnRoute.PointToClient(Control.MousePosition)) AndAlso btnRoute.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnRoute.ClientRectangle)
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnRoute.Width, btnRoute.Height)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
        End If
        ' Draw centered text
        Dim text As String = "Mine"
        Dim font As New Font("Segoe UI", 10)
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)

        Dim textRect As New RectangleF(0, 0, btnRoute.Width, btnRoute.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center

        If btnRoute.Enabled = True Then
            e.Graphics.DrawString(text, font, Brushes.Snow, textRect, format)
        Else
            e.Graphics.DrawString(text, font, Brushes.Gray, textRect, format)
        End If
    End Sub

    Private Sub btnClear_Paint(sender As Object, e As PaintEventArgs) Handles btnClear.Paint
        ' Draw background gradient
        If btnClear.ClientRectangle.Contains(btnClear.PointToClient(Control.MousePosition)) AndAlso btnClear.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnClear.ClientRectangle)
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnClear.Width, btnClear.Height)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
        End If
        ' Draw centered text
        Dim text As String = "Tühjenda"
        Dim font As New Font("Segoe UI", 10)
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)

        Dim textRect As New RectangleF(0, 0, btnClear.Width, btnClear.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        If btnClear.Enabled = True Then
            e.Graphics.DrawString(text, font, Brushes.Snow, textRect, format)
        Else
            e.Graphics.DrawString(text, font, Brushes.Gray, textRect, format)
        End If

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



    Private Sub btnRoute_Click(sender As Object, e As EventArgs) Handles btnRoute.Click
        If lblStart.Text IsNot "" And lblDest.Text IsNot "" _
            And lblStart.Text IsNot lblDest.Text Then
            getRoute(startCoord, endCoord)
        End If
        btnRoute.Enabled = False
        cbStops.Checked = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lblStart.Text = ""
        lblDest.Text = ""
        btnClear.Enabled = False
        btnRoute.Enabled = False
        clearRoute()
        gMap1.Position = New GMap.NET.PointLatLng(59.43, 24.75)
        gMap1.Zoom = 12
    End Sub

    Public Sub gMap1_MouseDown(sender As Object, e As MouseEventArgs) _
        Handles gMap1.MouseDown
        If e.Button = MouseButtons.Right Then
            ' Get the latitude and longitude of the clicked point
            Dim pointLatLng As PointLatLng = gMap1.FromLocalToLatLng(e.X, e.Y)
            RaiseEvent LocationClicked(pointLatLng.Lat, pointLatLng.Lng)
        End If
    End Sub
    Private Sub gMap1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gMap1.MouseDoubleClick
        Dim point As PointLatLng = gMap1.FromLocalToLatLng(e.X, e.Y)
        Dim lat As String = point.Lat.ToString.Replace(",", ".")
        Dim lng As String = point.Lng.ToString.Replace(",", ".")

        Dim apiUrl As String = "http://dev.virtualearth.net/REST/v1/Locations/{latitude},{longitude}?&key={apiKey}"
        apiUrl = apiUrl.Replace("{latitude}", lat)
        apiUrl = apiUrl.Replace("{longitude}", lng)
        apiUrl = apiUrl.Replace("{apiKey}", apiKey)
        ' Create a request to the API
        Dim request As WebRequest = WebRequest.Create(apiUrl)
        request.Method = "GET"
        Try
            ' Get the response from the API
            Dim response As WebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(responseStream)
            Dim responseBody As String = reader.ReadToEnd()

            'Parse the response And extract the route path
            Dim jsonResponse As JObject = JObject.Parse(responseBody)

            If jsonResponse("statusCode").ToString() = "200" AndAlso jsonResponse("resourceSets")(0)("estimatedTotal").ToObject(Of Integer) > 0 Then
                If jsonResponse("resourceSets")(0)("resources")(0)("address")("addressLine") IsNot Nothing Then
                    Dim address As String = jsonResponse("resourceSets")(0)("resources")(0)("address")("addressLine").ToString()
                    If lblStart.Text = "" Then
                        startCoord = point
                        lblStart.Text = address
                        btnClear.Enabled = True
                        startAddress = address
                    Else
                        endCoord = point
                        lblDest.Text = address
                        btnRoute.Enabled = True
                        destAddress = address
                    End If
                Else
                    MessageBox.Show("Aadressi ei leitud!")
                End If
            Else
                MessageBox.Show("Aadressi ei leitud!")
            End If
        Catch ex As Exception
            MessageBox.Show("Viga: " & ex.Message)
        End Try

    End Sub


    Private Sub gMap1_OnMarkerClick(item As GMapMarker, e As MouseEventArgs) _
        Handles gMap1.OnMarkerClick
        stopMarker = TryCast(item, GMarkerGoogle)
        'Checks if marker exists and is a stop marker not a bus or tram or trolley marker
        If stopMarker IsNot Nothing And Regex.IsMatch(stopMarker.ToolTipText, "^[a-zA-ZäöüõšžÄÖÜÕŠŽ][a-zA-ZäöüõšžÄÖÜÕŠŽ\s\-0-9.]*$") Then

            stopMarker.ToolTipMode = MarkerTooltipMode.Never
            Dim clientPoint As Point = Me.PointToClient(e.Location)
            Dim screenPoint As Point = Me.PointToScreen(clientPoint)
            panelPopup.Location = New Point(screenPoint.X, screenPoint.Y - panelPopup.Height)
            panelPopup.Visible = True

        End If
    End Sub

    Private Sub gMap1_OnMarkerLeave(item As GMapMarker) _
        Handles gMap1.OnMarkerLeave
        panelPopup.Visible = False
    End Sub
    Private Sub panelPopup_OnMouseLeave(sender As Object, e As EventArgs) _
        Handles panelPopup.MouseLeave
        Dim panelBounds As Rectangle = panelPopup.RectangleToScreen(panelPopup.ClientRectangle)
        If Not panelBounds.Contains(Control.MousePosition) Then
            panelPopup.Visible = False
            stopMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver
        End If

    End Sub

    Private Sub btnLayers_MouseClick(sender As Object, e As EventArgs) Handles btnLayers.MouseClick
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
        showHideStops(cbStops.Checked, getStopsSQL(drawMarker("Orange")))
    End Sub

    Public Sub showHideStops(ByRef isChecked As Boolean, ByRef stopsOverlay As GMapOverlay)
        If (isChecked = True) Then
            gMap1.Overlays.Add(stopsOverlay)
            gMap1.Refresh()
        Else
            stopsOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub

    Public Sub getRoute(startCoord As PointLatLng, endCoord As PointLatLng)
        showHideStops(False, getStopsSQL(drawMarker("Orange")))
        ' Define the route overlay and add it to the map
        Dim mapOverlay As GMapOverlay = New GMapOverlay("routes")

        'Define current time
        Dim currentTime As DateTime = DateTime.UtcNow
        Dim formattedTime As String = currentTime.ToString("yyyy-MM-ddTHH:mm:ssZ")

        ' Construct the Bing Maps API URL with necessary parameters
        Dim apiUrl As String = "https://dev.virtualearth.net/REST/v1/Routes/Transit?wayPoint.1={latitude1},{longitude1}&wayPoint.2={latitude2},{longitude2}&key={BingMapsAPIKey}&routeAttributes=routePath,transitStops&dateTime={dateTime}&timeType=Departure"

        ' Replace the placeholders with actual values
        apiUrl = apiUrl.Replace("{latitude1}", startCoord.Lat)
        apiUrl = apiUrl.Replace("{longitude1}", startCoord.Lng)
        apiUrl = apiUrl.Replace("{latitude2}", endCoord.Lat)
        apiUrl = apiUrl.Replace("{longitude2}", endCoord.Lng)
        apiUrl = apiUrl.Replace("{BingMapsAPIKey}", apiKey)
        apiUrl = apiUrl.Replace("{dateTime}", formattedTime)

        ' Create a request to the API
        Dim request As WebRequest = WebRequest.Create(apiUrl)
        request.Method = "GET"

        Try
            ' Get the response from the API
            Dim response As WebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(responseStream)
            Dim responseBody As String = reader.ReadToEnd()

            'Parse the response And extract the route path
            Dim jsonResponse As JObject = JObject.Parse(responseBody)
            Dim busPath As List(Of List(Of PointLatLng)) = Nothing
            Dim walkingPath As List(Of List(Of PointLatLng)) = Nothing
            Dim walkCount As Integer = 0
            Dim busCount As Integer = 0
            If jsonResponse("statusCode").ToString() = "200" AndAlso jsonResponse("resourceSets")(0)("estimatedTotal").ToObject(Of Integer) > 0 Then
                busPath = New List(Of List(Of PointLatLng))
                walkingPath = New List(Of List(Of PointLatLng))
                Dim coordinates As JArray = jsonResponse("resourceSets")(0)("resources")(0)("routePath")("line")("coordinates")

                For Each leg In jsonResponse("resourceSets")(0)("resources")(0)("routeLegs")
                    For Each item In leg("itineraryItems")
                        If item("details")(0)("startPathIndices") IsNot Nothing AndAlso item("details")(0)("startPathIndices") IsNot Nothing Then

                            If item("iconType") IsNot Nothing AndAlso item("iconType") = "Walk" Then
                                For i = CType(item("details")(0)("startPathIndices")(0), Integer) To CType(item("details")(0)("endPathIndices")(0), Integer)
                                    Debug.WriteLine("startIndeks: " & item("details")(0)("startPathIndices")(0).ToString & " " & item("details")(0)("endPathIndices")(0).ToString)
                                    walkingPath.Add(New List(Of PointLatLng))

                                    Dim latitude As Double = coordinates(i)(0)
                                    Dim longitude As Double = coordinates(i)(1)
                                    Dim loc As New PointLatLng(latitude, longitude)
                                    walkingPath(walkCount).Add(loc)
                                Next
                                walkCount = walkCount + 1

                            Else
                                For i = CType(item("details")(0)("startPathIndices")(0), Integer) To CType(item("details")(0)("endPathIndices")(0), Integer)
                                    Debug.WriteLine("startIndeks: " & item("details")(0)("startPathIndices")(0).ToString & " " & item("details")(0)("endPathIndices")(0).ToString)
                                    busPath.Add(New List(Of PointLatLng))
                                    Dim latitude As Double = jsonResponse("resourceSets")(0)("resources")(0)("routePath")("line")("coordinates")(i)(0)
                                    Dim longitude As Double = jsonResponse("resourceSets")(0)("resources")(0)("routePath")("line")("coordinates")(i)(1)
                                    Dim loc As New PointLatLng(latitude, longitude)
                                    busPath(busCount).Add(loc)
                                Next
                                busCount = busCount + 1
                            End If
                        End If

                        If item("transitStops") IsNot Nothing Then
                            For Each point In item("transitStops")
                                If point IsNot Nothing AndAlso point("position") IsNot Nothing AndAlso point("position")("coordinates") IsNot Nothing Then
                                    Dim loc As New PointLatLng(point("position")("coordinates")(0), point("position")("coordinates")(1))
                                    Dim stopMarker As GMarkerGoogle = New GMarkerGoogle(loc, CType(drawMarker("orange"), Bitmap))
                                    Dim toolTipStop As New CustomToolTip(stopMarker)
                                    stopMarker.ToolTip = toolTipStop
                                    stopMarker.ToolTipText = point("stopName")
                                    mapOverlay.Markers.Add(stopMarker)
                                End If
                            Next
                        End If
                    Next
                Next
            Else
                MessageBox.Show("Sobivat marsuuti ei leitud!")
            End If

            For Each busPathList As List(Of PointLatLng) In busPath
                Dim busPathOverlay As New GMapRoute(busPathList, "Bus Path")
                busPathOverlay.Stroke = New Pen(Color.Blue, 5)
                mapOverlay.Routes.Add(busPathOverlay)
            Next

            For Each walkingPathList As List(Of PointLatLng) In walkingPath
                Dim walkingPathOverlay As New GMapRoute(walkingPathList, "Walking Path")
                walkingPathOverlay.Stroke = New Pen(Color.Blue, 4)
                walkingPathOverlay.Stroke.DashStyle = Drawing2D.DashStyle.Dash
                mapOverlay.Routes.Add(walkingPathOverlay)
            Next

            Dim startMarker As GMarkerGoogle = New GMarkerGoogle(startCoord, CType(drawMarker("lightgreen"), Bitmap))
            Dim toolTipStart As New CustomToolTip(startMarker)
            startMarker.ToolTip = toolTipStart
            startMarker.ToolTipText = "Algus: " & startAddress
            startMarker.Size = New Size(14, 14)
            mapOverlay.Markers.Add(startMarker)
            gMap1.UpdateMarkerLocalPosition(startMarker)
            Dim endMarker As GMarkerGoogle = New GMarkerGoogle(endCoord, CType(drawMarker("red"), Bitmap))
            Dim toolTipEnd As New CustomToolTip(endMarker)
            endMarker.ToolTip = toolTipEnd
            endMarker.ToolTipText = "Sihtkoht: " & destAddress
            endMarker.Size = New Size(14, 14)
            mapOverlay.Markers.Add(endMarker)

            gMap1.Overlays.Clear()
            gMap1.Overlays.Add(mapOverlay)

            ' Code for zooming in on the route
            Dim minLat As Double = Double.MaxValue
            Dim maxLat As Double = Double.MinValue
            Dim minLng As Double = Double.MaxValue
            Dim maxLng As Double = Double.MinValue

            For Each marker In gMap1.Overlays(0).Markers
                minLat = Math.Min(minLat, marker.Position.Lat)
                maxLat = Math.Max(maxLat, marker.Position.Lat)
                minLng = Math.Min(minLng, marker.Position.Lng)
                maxLng = Math.Max(maxLng, marker.Position.Lng)
            Next

            Dim boundingBox = RectLatLng.FromLTRB(minLng, maxLat, maxLng, minLat)
            gMap1.SetZoomToFitRect(boundingBox)
            gMap1.Position = New PointLatLng(boundingBox.Lat - ((maxLat - minLat) / 2), boundingBox.Lng + ((maxLng - minLng) / 2))
            gMap1.Refresh()


        Catch ex As WebException
            ' Handle web request errors
            Dim errorResponse As HttpWebResponse = ex.Response
            Dim errorStream As Stream = errorResponse.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(errorStream)
            Dim errorBody As String = reader.ReadToEnd()
            Console.WriteLine("Web Exception: " + ex.Message + " Response body: " + errorBody)

        Catch ex As Exception
            ' Handle other types of exceptions
            Console.WriteLine("Exception: " + ex.Message)

        End Try

    End Sub

    Public Sub clearRoute()
        gMap1.Overlays.Clear()
        gMap1.Refresh()
        cbStops.Checked = False
        cbStops.Checked = True
    End Sub

    Private Sub GMap1_OnMapZoomChanged() Handles gMap1.OnMapZoomChanged
        Dim zoomLevel As Double = gMap1.Zoom
        Dim markerSize As Integer
        ' Adjust the marker size based on the zoom level
        Select Case zoomLevel
            Case Is <= 11
                markerSize = 8
            Case Is <= 14
                markerSize = 9
            Case Is <= 16
                markerSize = 11
            Case Is <= 17
                markerSize = 13
            Case Is <= 20
                markerSize = 15
            Case Else
                markerSize = 10
        End Select

        ' Set the new marker size for each marker
        For Each marker As GMarkerGoogle In gMap1.Overlays.SelectMany(Function(o) o.Markers).OfType(Of GMarkerGoogle)()
            If Regex.IsMatch(marker.ToolTipText, "^[a-zA-ZäöüõšžÄÖÜÕŠŽ][a-zA-ZäöüõšžÄÖÜÕŠŽ\s\-0-9.]*$") Then
                marker.Size = New Size(markerSize, markerSize)
            End If
        Next
    End Sub

    Private Sub cbBuses_CheckedChanged(sender As Object, e As EventArgs) Handles cbBuses.CheckedChanged
        showHideBuses(cbBuses.Checked, GetBuses(drawMarker("Cyan")))
    End Sub

    Private Sub transportTimer_Tick(sender As Object, e As EventArgs) Handles transportTimer.Tick
        showHideBuses(cbBuses.Checked, GetBuses(drawMarker("Cyan")))
        showHideTrams(cbTram.Checked, GetTrams(drawMarker("LightGreen")))
        showHideTrolleys(cbTroll.Checked, GetTrolleys(drawMarker("Yellow")))
    End Sub

    Public Sub showHideBuses(ByRef isChecked As Boolean, ByRef busesOverlay As GMapOverlay)
        If (isChecked = True) Then
            gMap1.Overlays.Add(busesOverlay)
            gMap1.Refresh()
        Else
            busesOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub

    Private Sub cbTram_CheckedChanged(sender As Object, e As EventArgs) Handles cbTram.CheckedChanged
        showHideTrams(cbTram.Checked, GetTrams(drawMarker("LightGreen")))
    End Sub

    Public Sub showHideTrams(ByRef isChecked As Boolean, ByRef tramsOverlay As GMapOverlay)
        If (isChecked = True) Then
            gMap1.Overlays.Add(tramsOverlay)
            gMap1.Refresh()
        Else
            tramsOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub

    Private Sub cbTroll_CheckedChanged(sender As Object, e As EventArgs) Handles cbTroll.CheckedChanged
        showHideTrolleys(cbTroll.Checked, GetTrolleys(drawMarker("Yellow")))
    End Sub

    Public Sub showHideTrolleys(ByRef isChecked As Boolean, ByRef trolleysOverlay As GMapOverlay)
        If (isChecked = True) Then
            gMap1.Overlays.Add(trolleysOverlay)
            gMap1.Refresh()
        Else
            trolleysOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub

    Public Function GetBuses(ByRef markerBitmap As Bitmap)

        Dim realTime As New CRealTime
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

    Public Function GetTrams(ByRef markerBitmap As Bitmap)
        Dim realTime As New CRealTime
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

    Public Function GetTrolleys(ByRef markerBitmap As Bitmap)

        Dim realTime As New CRealTime
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

    'Private Sub btnLayers_MouseClick(sender As Object, e As MouseEventArgs) Handles btnLayers.MouseClick

    'End Sub

    Private Sub btnZoomIn_Click(sender As Object, e As EventArgs) Handles btnZoomIn.Click
        gMap1.Zoom = gMap1.Zoom + 1
    End Sub

    Private Sub btnZoomOut_Click(sender As Object, e As EventArgs) Handles btnZoomOut.Click
        gMap1.Zoom = gMap1.Zoom - 1
    End Sub
End Class


'Class for creating a modern tooltip box For the bus Stop markers
Public Class CustomToolTip
    Inherits GMapToolTip
    Public Sub New(marker As GMapMarker)
        MyBase.New(marker)
    End Sub
    Public Overrides Sub OnRender(g As Graphics)
        Dim textSize As SizeF = g.MeasureString(Marker.ToolTipText, New Font("Segoe UI", 10))
        Dim padding As Integer = 8
        Dim rectWidth As Integer = CInt(textSize.Width + padding * 2)
        Dim rectHeight As Integer = CInt(textSize.Height + padding * 2)
        Dim rect As New RectangleF(Marker.ToolTipPosition.X - 6, Marker.ToolTipPosition.Y - rectHeight - 5, rectWidth, rectHeight)
        '-rectWidth / 2
        Dim path As New GraphicsPath()
        Dim radius As Integer = CInt(rect.Height / 3)
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius - 10, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius - 10, radius, radius, 90, 90)
        path.CloseFigure()

        ' Use a gradient brush to fill the tooltip with a modern color scheme
        Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
        g.FillPath(brush, path)
        g.DrawPath(New Pen(Color.FromArgb(255, 15, 15, 15), 1), path)

        ' Draw the triangle on the top center of the rectangle, outside of the rectangle
        Dim triangle As New PointF(rect.Left + 6, rect.Bottom - 1)
        Dim trianglePath As New GraphicsPath()
        trianglePath.AddLine(triangle.X, triangle.Y, triangle.X + 10, triangle.Y - 8)
        trianglePath.AddLine(triangle.X + 1, triangle.Y - 8, triangle.X, triangle.Y)
        trianglePath.CloseFigure()
        g.FillPath(brush, trianglePath)
        g.DrawPath(New Pen(Color.FromArgb(255, 15, 15, 15), 1), trianglePath)

        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center

        ' Center the text vertically in the rectangle
        Dim textRect As New RectangleF(rect.X, rect.Y + 4, rect.Width, textSize.Height)
        ' Use a light text color for the tooltip
        g.DrawString(Marker.ToolTipText, New Font("Segoe UI", 10), Brushes.Snow, textRect, format)
        ' + (rect.Height - textSize.Height) / 2
    End Sub
End Class
