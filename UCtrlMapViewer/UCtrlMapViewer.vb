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
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports UTimeTable.UTimeTable
Imports System.Windows
Imports PrjRealTime
Imports PrjRealTime.CRealTime
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Reflection.Emit
Imports Newtonsoft.Json.Linq
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports Newtonsoft.Json
Imports System.Net.Http
Imports HtmlAgilityPack
Imports System.Xml
Imports System.Security.Authentication.ExtendedProtection
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports PrjTransitRouteInfo.URouteInfo
Imports PrjTransitRouteInfo
Imports TheArtOfDev.HtmlRenderer.Adapters
Imports System
' This class realizes the functionality of the map viewer graphic component
Public Class UCtrlMapViewer

    '----------Class properties and globals-------------

    'Flag for checking the btnOptimize state
    Private optimizeByDist As Boolean = False
    ' Flag for checking if the layerPanel is resized
    Private isResized As Boolean = False
    Private startCoord As PointLatLng
    Private endCoord As PointLatLng
    Private startAddress As String
    Private destAddress As String
    Private pointCoord As PointLatLng
    Private stopMarker As GMarkerGoogle
    'Key to access Bing Map provider routing
    Private apiKey As String = "9uNDiiSRdZbV6ok9Ec5t~H2haoDb04SzxUDigaGoUfg~Ajj9p1O58cpXmy-Y-BbTNAF8M1Ws3HjoFHGWOaSgIYCucioMsIkP3BpBZGI3XtWr"
    Public timeT As New UTimeTable.UTimeTable
    Private WithEvents transportTimer As New Timer()
    Private busesOverlay As New GMapOverlay("busesOverlay")
    Private stopsOverlay As New GMapOverlay("stopsOverlay")
    Private trolleysOverlay As New GMapOverlay("trolleysOverlay")
    Private tramsOverlay As New GMapOverlay("tramsOverlay")
    Private routesOverlay As New WindowsForms.GMapOverlay("RoutesOverlay")


    '---------------Load and init methods-------------------
    Private Sub UCtrlMapViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This code will run when the user control is loaded into a form or another container control
        panelLayers_Init()
        cbStops.Checked = True
        transportTimer.Interval = 5000 ' 1 second
        transportTimer.Enabled = True
        lblStart.Parent = gMap1 'Parent set as gMap1 to get transparency effect for controls
        lblDest.Parent = gMap1
        btnClear.Enabled = False
        btnRoute.Enabled = False
        panelPopup.Visible = False
        btnZoomIn.Parent = gMap1
        btnZoomOut.Parent = gMap1
        btnRoute.Parent = gMap1
        btnClear.Parent = gMap1
        btnNearestStopDest.Parent = gMap1
        btnNearestStopStart.Parent = gMap1
        btnNearestStopDest.Enabled = False
        btnNearestStopStart.Enabled = False
        btnOptimize.Parent = gMap1
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
        gMap1.Refresh()
        'GMaps.Instance.UseMemoryCache = True
        'GMapControl1.BoundsOfMap = New RectLatLng(59.43, 24.75, 0.1, 0.1)
    End Sub



    '------------------Paint events and personalization of the user controls-------------------------
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

    Private Sub toolTipNearestStop_Draw(sender As Object, e As DrawToolTipEventArgs) Handles toolTipNearestStop.Draw
        ' Set tooltip color scheme
        Dim tooltipColor As Color() = {Color.FromArgb(204, 25, 25, 25), Color.FromArgb(204, 10, 10, 10)}

        ' Create a LinearGradientBrush with the tooltip color scheme
        Dim brush As New LinearGradientBrush(e.Bounds, tooltipColor(0), tooltipColor(1), LinearGradientMode.Vertical)

        ' Fill the tooltip background with the LinearGradientBrush
        e.Graphics.FillRectangle(brush, e.Bounds)

        ' Draw the tooltip text in the middle with "Snow" color
        Dim font As Font = New Font("Segoe UI", 9, FontStyle.Regular)
        Using brushText As New SolidBrush(Color.Snow)
            Dim format As New StringFormat()
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(e.ToolTipText, font, brushText, e.Bounds, format)
            format.Dispose()
        End Using
        brush.Dispose()
        toolTipNearestStop.AutoPopDelay = 4000
        toolTipNearestStop.InitialDelay = 0
        toolTipNearestStop.ReshowDelay = 50
    End Sub

    Private Sub lblStopPopup_Paint(sender As Object, e As PaintEventArgs) Handles lblStopPopup.Paint
        Dim pen As New Pen(Color.Gray)
        e.Graphics.DrawLine(pen, New Point(0, lblStopPopup.Height - 1), New Point(lblStopPopup.Width, lblStopPopup.Height - 1))
    End Sub
    Private Sub btnZoomIn_Paint(sender As Object, e As PaintEventArgs) Handles btnZoomIn.Paint
        Dim text As String = "+"
        Dim font As New Font("Segoe UI", 32, FontStyle.Bold)
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)
        Dim textX As Single = (btnZoomIn.Width - textSize.Width) / 2
        Dim textY As Single = (btnZoomIn.Height - textSize.Height / 1.05)
        If btnZoomIn.ClientRectangle.Contains(btnZoomIn.PointToClient(Control.MousePosition)) Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnZoomIn.ClientRectangle)
            e.Graphics.DrawString(text, font, Brushes.Black, textX, textY)
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnZoomIn.Width, btnZoomIn.Height)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            e.Graphics.DrawString(text, font, Brushes.Snow, textX, textY)
        End If
    End Sub

    Private Sub btnZoomOut_Paint(sender As Object, e As PaintEventArgs) Handles btnZoomOut.Paint
        ' Draw centered text
        Dim text As String = ChrW(&H2212)
        Dim font As New Font("Segoe UI", 32, FontStyle.Bold)
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)
        Dim textX As Single = (btnZoomIn.Width - textSize.Width) / 2
        Dim textY As Single = (btnZoomIn.Height - textSize.Height / 1.05)
        If btnZoomOut.ClientRectangle.Contains(btnZoomOut.PointToClient(Control.MousePosition)) Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnZoomOut.ClientRectangle)
            e.Graphics.DrawString(text, font, Brushes.Black, textX, textY)
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnZoomOut.Width, btnZoomOut.Height)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            e.Graphics.DrawString(text, font, Brushes.Snow, textX, textY)
        End If

    End Sub

    Private Sub btnNearestStopStart_Paint(sender As Object, e As PaintEventArgs) Handles btnNearestStopStart.Paint
        If btnNearestStopStart.ClientRectangle.Contains(btnNearestStopStart.PointToClient(Control.MousePosition)) AndAlso btnNearestStopStart.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnNearestStopStart.ClientRectangle)
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnNearestStopStart.Width, btnNearestStopStart.Height)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
        End If
        Dim markerBitmap As Bitmap = drawMarker("LightGreen", 15) ' Replace "Red" with the desired color for the marker
        Dim markerSize As Integer = markerBitmap.Width
        Dim x As Integer = (btnNearestStopStart.Width - markerSize) \ 2
        Dim y As Integer = (btnNearestStopStart.Height - markerSize) \ 2
        e.Graphics.DrawImage(markerBitmap, x, y)
    End Sub

    Private Sub btnNearestStopDest_Paint(sender As Object, e As PaintEventArgs) Handles btnNearestStopDest.Paint
        If btnNearestStopDest.ClientRectangle.Contains(btnNearestStopDest.PointToClient(Control.MousePosition)) AndAlso btnNearestStopDest.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnNearestStopDest.ClientRectangle)
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnNearestStopDest.Width, btnNearestStopDest.Height)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
        End If
        ' Load the marker bitmap using the drawMarker function
        Dim markerBitmap As Bitmap = drawMarker("Red", 15)
        Dim markerSize As Integer = markerBitmap.Width
        Dim x As Integer = (btnNearestStopStart.Width - markerSize) \ 2
        Dim y As Integer = (btnNearestStopStart.Height - markerSize) \ 2
        e.Graphics.DrawImage(markerBitmap, x, y)
    End Sub

    Private Sub btnOptimize_Paint(sender As Object, e As PaintEventArgs) Handles btnOptimize.Paint
        Dim rect As Rectangle = New Rectangle(0, 0, btnOptimize.Width, btnOptimize.Height)
        Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(brush, rect)
        If optimizeByDist Then
            Dim resizedImage As New Bitmap(My.Resources.dist_icon, New Size(btnOptimize.Width - 9, btnOptimize.Height - 9))
            e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            e.Graphics.DrawImage(resizedImage, (btnOptimize.Width - resizedImage.Width) \ 2, (btnOptimize.Height - resizedImage.Height) \ 2)
        Else
            Dim resizedImage As New Bitmap(My.Resources.hourglass_icon, New Size(btnOptimize.Width - 9, btnOptimize.Height - 9))
            e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            e.Graphics.DrawImage(resizedImage, (btnOptimize.Width - resizedImage.Width) \ 2, (btnOptimize.Height - resizedImage.Height) \ 2)
        End If
    End Sub

    Private Sub btnRoute_Paint(sender As Object, e As PaintEventArgs) Handles btnRoute.Paint
        ' Draw centered text
        Dim text As String = "Mine"
        Dim font As New Font("Segoe UI", 10)
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)
        Dim textRect As New RectangleF(0, 0, btnRoute.Width, btnRoute.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        ' Draw background gradient

        If btnRoute.ClientRectangle.Contains(btnRoute.PointToClient(Control.MousePosition)) AndAlso btnRoute.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnRoute.ClientRectangle)
            If btnRoute.Enabled = True Then
                e.Graphics.DrawString(text, font, Brushes.Black, textRect, format)
            Else
                e.Graphics.DrawString(text, font, Brushes.Gray, textRect, format)
            End If
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnRoute.Width, btnRoute.Height)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            If btnRoute.Enabled = True Then
                e.Graphics.DrawString(text, font, Brushes.Snow, textRect, format)
            Else
                e.Graphics.DrawString(text, font, Brushes.Gray, textRect, format)
            End If
        End If
    End Sub

    Private Sub btnClear_Paint(sender As Object, e As PaintEventArgs) Handles btnClear.Paint
        Dim text As String = "Tühjenda"
        Dim font As New Font("Segoe UI", 10)
        Dim textSize As SizeF = e.Graphics.MeasureString(text, font)

        Dim textRect As New RectangleF(0, 0, btnClear.Width, btnClear.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        If btnClear.ClientRectangle.Contains(btnClear.PointToClient(Control.MousePosition)) AndAlso btnClear.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnClear.ClientRectangle)
            If btnClear.Enabled = True Then
                e.Graphics.DrawString(text, font, Brushes.Black, textRect, format)
            Else
                e.Graphics.DrawString(text, font, Brushes.Gray, textRect, format)
            End If
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnClear.Width, btnClear.Height)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            If btnClear.Enabled = True Then
                e.Graphics.DrawString(text, font, Brushes.Snow, textRect, format)
            Else
                e.Graphics.DrawString(text, font, Brushes.Gray, textRect, format)
            End If
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

    Private Sub UpdateOptimizeTooltipText()
        If optimizeByDist Then
            toolTipNearestStop.Show("Optimeeri: lühem distants", btnOptimize, btnOptimize.Width + 3, 6)
        Else
            toolTipNearestStop.Show("Optimeeri: lühem aeg", btnOptimize, btnOptimize.Width + 3, 6)
        End If
    End Sub
    '------------------------------------------------------------------

    '------------------------------------Button, panel, checkbox, timer events----------------------------------------------'
    'Events that are triggered when the user clicks, ticks, hovers or leaves the control element, also timer tick

    Private Sub btnNearestStopStart_MouseHover(sender As Object, e As EventArgs) Handles btnNearestStopStart.MouseHover
        toolTipNearestStop.Show("Leia lähim peatus", btnNearestStopStart, btnNearestStopStart.Width + 3, 6)
    End Sub

    Private Sub btnNearestStopStart_MouseLeave(sender As Object, e As EventArgs) Handles btnNearestStopStart.MouseLeave
        toolTipNearestStop.Hide(btnNearestStopStart)
    End Sub

    Private Sub btnNearestStopDest_MouseHover(sender As Object, e As EventArgs) Handles btnNearestStopDest.MouseHover
        toolTipNearestStop.Show("Leia lähim peatus", btnNearestStopDest, btnNearestStopDest.Width + 3, 6)
    End Sub

    Private Sub btnNearestStopDest_MouseLeave(sender As Object, e As EventArgs) Handles btnNearestStopDest.MouseLeave
        toolTipNearestStop.Hide(btnNearestStopDest)
    End Sub
    Private Sub btnZoomIn_MouseHover(sender As Object, e As EventArgs) Handles btnZoomIn.MouseHover
        toolTipNearestStop.Show("Suumi sisse", btnZoomIn, btnZoomIn.Width + 3, 6)
        btnZoomIn.Invalidate()
    End Sub

    Private Sub btnZoomOut_MouseLeave(sender As Object, e As EventArgs) Handles btnZoomOut.MouseLeave
        toolTipNearestStop.Hide(btnZoomIn)
    End Sub

    Private Sub btnZoomOut_MouseHover(sender As Object, e As EventArgs) Handles btnZoomOut.MouseHover
        toolTipNearestStop.Show("Suumi välja", btnZoomOut, btnZoomOut.Width + 3, 6)
        btnZoomOut.Invalidate()
    End Sub

    Private Sub btnZoomIn_MouseLeave(sender As Object, e As EventArgs) Handles btnZoomIn.MouseLeave
        toolTipNearestStop.Hide(btnZoomIn)
    End Sub

    Private Sub btnOptimize_MouseHover(sender As Object, e As EventArgs) Handles btnOptimize.MouseHover
        UpdateOptimizeTooltipText()
    End Sub

    Private Sub btnOptimize_MouseLeave(sender As Object, e As EventArgs) Handles btnOptimize.MouseLeave
        toolTipNearestStop.Hide(btnOptimize)
    End Sub

    Private Sub btnLayers_MouseHover(sender As Object, e As EventArgs) Handles btnLayers.MouseHover
        toolTipNearestStop.Show("Kihid", btnLayers, -45, 10)
    End Sub

    Private Sub btnLayers_MouseLeave(sender As Object, e As EventArgs) Handles btnLayers.MouseLeave
        toolTipNearestStop.Hide(btnLayers)
    End Sub

    Private Sub btnRoute_Click(sender As Object, e As EventArgs) Handles btnRoute.Click
        If lblStart.Text IsNot "" And lblDest.Text IsNot "" _
            And lblStart.Text IsNot lblDest.Text Then
            If optimizeByDist Then
                RaiseEvent DisplayRouteInfo(getRoute(startCoord, endCoord, "distance"))
            Else
                RaiseEvent DisplayRouteInfo(getRoute(startCoord, endCoord, "time"))
            End If
        End If
        btnRoute.Enabled = False
        cbStops.Checked = False
        btnNearestStopDest.Enabled = False
        btnNearestStopStart.Enabled = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lblStart.Text = ""
        lblDest.Text = ""
        btnClear.Enabled = False
        btnRoute.Enabled = False
        btnNearestStopStart.Enabled = False
        btnNearestStopDest.Enabled = False
        RaiseEvent ClearRouteInfo()
        clearRoute()
        gMap1.Position = New GMap.NET.PointLatLng(59.43, 24.75)
        gMap1.Zoom = 12
    End Sub

    Private Sub panelPopup_OnMouseLeave(sender As Object, e As EventArgs) _
        Handles panelPopup.MouseLeave
        Dim panelBounds As Rectangle = panelPopup.RectangleToScreen(panelPopup.ClientRectangle)
        If Not panelBounds.Contains(Control.MousePosition) Then
            panelPopup.Visible = False
            lBoxRealTime.Items.Clear()
            stopMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver
        End If
    End Sub

    Private Sub btnOptimize_Click(sender As Object, e As EventArgs) Handles btnOptimize.Click
        optimizeByDist = Not optimizeByDist
        UpdateOptimizeTooltipText()
        btnOptimize.Invalidate()
        If btnClear.Enabled = True AndAlso btnRoute.Enabled = False AndAlso lblStart.Text <> "" AndAlso lblDest.Text <> "" Then
            btnRoute.Enabled = True
        End If
    End Sub
    Private Sub btnNearestStopStart_Click(sender As Object, e As EventArgs) Handles btnNearestStopStart.Click
        If lblStart.Text IsNot "" Then
            For Each marker As GMapMarker In stopsOverlay.Markers
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
            Next
            Dim closestMarker As GMarkerGoogle = Nothing
            Dim closestDistance As Double = Double.MaxValue
            stopsOverlay = getStopsSQL(drawMarker("Orange", 9))
            For Each marker As GMarkerGoogle In stopsOverlay.Markers
                Dim position As PointLatLng = marker.Position
                Dim tooltipText As String = marker.ToolTipText
                Dim distance As Double = DistanceBetweenPoints(startCoord.Lat, startCoord.Lng, position.Lat, position.Lng)
                If distance < closestDistance Then
                    closestMarker = marker
                    closestDistance = distance
                End If
            Next
            If closestMarker IsNot Nothing Then
                closestMarker.ToolTipMode = MarkerTooltipMode.Always
            End If
            If cbStops.Checked Then
                gMap1.UpdateMarkerLocalPosition(closestMarker)
                gMap1.Refresh()
            Else
                stopsOverlay.Clear()
                stopsOverlay.Markers.Add(closestMarker)
                gMap1.UpdateMarkerLocalPosition(closestMarker)
                gMap1.Refresh()
            End If
        End If
        btnNearestStopStart.Enabled = False
        If lblDest.Text <> "" Then
            btnNearestStopDest.Enabled = True
        End If
    End Sub
    Private Sub btnNearestStopDest_Click(sender As Object, e As EventArgs) Handles btnNearestStopDest.Click
        If lblDest.Text IsNot "" Then
            For Each marker As GMapMarker In stopsOverlay.Markers
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
            Next
            Dim closestMarker As GMarkerGoogle = Nothing
            Dim closestDistance As Double = Double.MaxValue
            stopsOverlay = getStopsSQL(drawMarker("Orange", 9))
            For Each marker As GMarkerGoogle In stopsOverlay.Markers
                Dim position As PointLatLng = marker.Position
                Dim tooltipText As String = marker.ToolTipText
                Dim distance As Double = DistanceBetweenPoints(endCoord.Lat, endCoord.Lng, position.Lat, position.Lng)
                If distance < closestDistance Then
                    closestMarker = marker
                    closestDistance = distance
                End If
            Next
            If closestMarker IsNot Nothing Then
                closestMarker.ToolTipMode = MarkerTooltipMode.Always
            End If
            gMap1.UpdateMarkerLocalPosition(closestMarker)
            gMap1.Refresh()
        End If
        btnNearestStopDest.Enabled = False
        btnNearestStopStart.Enabled = True
    End Sub

    Private Sub btnZoomIn_Click(sender As Object, e As EventArgs) Handles btnZoomIn.Click
        gMap1.Zoom = gMap1.Zoom + 1
    End Sub

    Private Sub btnZoomOut_Click(sender As Object, e As EventArgs) Handles btnZoomOut.Click
        gMap1.Zoom = gMap1.Zoom - 1
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
        showHideStops(cbStops.Checked, getStopsSQL(drawMarker("Orange", 9)))
    End Sub

    Private Sub cbBuses_CheckedChanged(sender As Object, e As EventArgs) Handles cbBuses.CheckedChanged
        showHideBuses(cbBuses.Checked, GetBuses(drawMarker("Cyan", 10)))
    End Sub
    Private Sub cbTram_CheckedChanged(sender As Object, e As EventArgs) Handles cbTram.CheckedChanged
        showHideTrams(cbTram.Checked, GetTrams(drawMarker("LightGreen", 10)))
    End Sub

    Private Sub cbTroll_CheckedChanged(sender As Object, e As EventArgs) Handles cbTroll.CheckedChanged
        showHideTrolleys(cbTroll.Checked, GetTrolleys(drawMarker("Yellow", 10)))
    End Sub

    Private Sub transportTimer_Tick(sender As Object, e As EventArgs) Handles transportTimer.Tick
        showHideBuses(cbBuses.Checked, GetBuses(drawMarker("Cyan", 10)))
        showHideTrams(cbTram.Checked, GetTrams(drawMarker("LightGreen", 10)))
        showHideTrolleys(cbTroll.Checked, GetTrolleys(drawMarker("Yellow", 10)))
    End Sub
    '--------------------------------------------------

    '--------------------------------------------Map events-------------------------------------------
    'All events that are triggered when doing something on the gMap1 control element

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
                        btnNearestStopStart.Enabled = True
                    Else
                        endCoord = point
                        lblDest.Text = address
                        btnRoute.Enabled = True
                        destAddress = address
                        btnNearestStopDest.Enabled = True
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

    Private Sub gMap1_OnMarkerClick(item As WindowsForms.GMapMarker, e As MouseEventArgs) _
        Handles gMap1.OnMarkerClick
        stopMarker = TryCast(item, GMarkerGoogle)
        'Checks if marker exists and is a stop marker not a bus or tram or trolley marker
        If stopMarker IsNot Nothing And Regex.IsMatch(stopMarker.ToolTipText, "^[a-zA-ZäöüõšžÄÖÜÕŠŽ][a-zA-ZäöüõšžÄÖÜÕŠŽ\s\-0-9.]*$") Then

            stopMarker.ToolTipMode = MarkerTooltipMode.Never
            Dim clientPoint As Point = Me.PointToClient(e.Location)
            Dim screenPoint As Point = Me.PointToScreen(clientPoint)
            panelPopup.Location = New Point(screenPoint.X, screenPoint.Y - panelPopup.Height)
            Dim text As String = stopMarker.ToolTipText
            Dim padText As String = text.PadLeft(text.Length + 14, " ").PadRight(text.Length + 28, " ")
            Dim panelWidth As Integer = TextRenderer.MeasureText(padText, lblStopPopup.Font).Width
            lblStopPopup.Text = padText

            ' Calculate the height of the label and the center point
            Dim labelHeight As Integer = lblStopPopup.Height
            Dim centerY As Integer = labelHeight \ 2

            ' Calculate the width of the label and the center point
            Dim labelWidth As Integer = lblStopPopup.Width
            Dim centerX As Integer = labelWidth \ 2

            ' Calculate the position of the text within the label
            Dim textSize As Size = TextRenderer.MeasureText(padText, lblStopPopup.Font)
            Dim textX As Integer = centerX - (textSize.Width \ 2)
            Dim textY As Integer = centerY - (textSize.Height \ 2)

            ' Set the location of the text within the label
            lblStopPopup.Location = New Point(textX, textY)

            ' Set the width of the label and panel to the width of the padded text
            panelPopup.Width = panelWidth
            lblStopPopup.Width = panelWidth
            tableLayoutPopup.Width = panelWidth

            Dim url As String = "https://transport.tallinn.ee/siri-stop-departures.php?stopid="
            url &= stopMarker.Tag.ToString()
            Dim time As Double
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "GET"
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As New StreamReader(response.GetResponseStream())
                Dim linetime As String = reader.ReadLine()
                Dim fieldstime As String() = linetime.Split(",")
                time = Double.Parse(fieldstime(4), CultureInfo.InvariantCulture)
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim fields As String() = line.Split(",")
                    If fields.Length >= 7 Then
                        Dim routetype As String = fields(0)
                        If routetype = "bus" Then
                            routetype = "Buss"
                        End If
                        If routetype = "trol" Then
                            routetype = "Troll"
                        End If
                        If routetype = "tram" Then
                            routetype = "Tramm"
                        End If
                        Dim routenum As String = fields(1)
                        Dim timebuf As Integer = Integer.Parse(fields(2))
                        timebuf = (timebuf - time) / 60
                        Dim formatted As String = timebuf.ToString("F0")
                        Dim lineRealTime As String = routetype & " " & routenum & "   " & formatted & " min"
                        lBoxRealTime.Items.Add(lineRealTime)
                    End If
                End While
            End Using
            response.Close()
            If lBoxRealTime.Items.Count < 1 Then
                lBoxRealTime.Items.Add("Reaalaja")
                lBoxRealTime.Items.Add("väljumised")
                lBoxRealTime.Items.Add("puuduvad")
            End If
            panelPopup.Visible = True

        End If
    End Sub

    Public Sub gMap1_MouseDown(sender As Object, e As MouseEventArgs) _
        Handles gMap1.MouseDown
        If e.Button = MouseButtons.Right Then
            ' Get the latitude and longitude of the clicked point
            Dim pointLatLng As PointLatLng = gMap1.FromLocalToLatLng(e.X, e.Y)
            RaiseEvent LocationClicked(pointLatLng.Lat, pointLatLng.Lng)
        End If
    End Sub

    ' Events to see coordinates and stops on the form
    Public Event LocationClicked(ByVal latitude As Double, ByVal longitude As Double)
    Public Event MarkerClicked(ByVal value As String, ByVal latitude As Double, ByVal longitude As Double)
    'Event for route info
    Public Event DisplayRouteInfo(ByVal route As RouteInfo)
    Public Event ClearRouteInfo()

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
    Private Sub gMap1_OnMarkerLeave(item As GMapMarker) _
        Handles gMap1.OnMarkerLeave
        lBoxRealTime.Items.Clear()
        panelPopup.Visible = False
        item.ToolTipMode = MarkerTooltipMode.OnMouseOver
    End Sub

    '--------------------------------------------------

    '-----------------------------Class functions and methods----------------------------------
    'All functions and methods that are not events

    'Gets stops from database and adds them to the map
    Public Function getStopsSQL(ByRef markerBitmap As Bitmap)
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

    'This method is for displaying the route for a selected line on the map
    Public Sub DisplayShapes(ByVal routePoints As List(Of StopStruct), ByVal routeStops As List(Of StopStruct))
        gMap1.Overlays.Clear()
        lblStart.Text = ""
        lblDest.Text = ""
        cbStops.Checked = False
        Dim Route As New WindowsForms.GMapRoute(New List(Of PointLatLng), "My Route")
        For Each point As StopStruct In routePoints
            Route.Points.Add(New PointLatLng(point.Latitude, point.Longitude))
        Next
        Dim marker As GMarkerGoogle
        Dim markerBitmap As Bitmap = drawMarker("Orange", 9)
        For i As Integer = 0 To routeStops.Count - 1
            Dim stop_el As StopStruct = routeStops(i)
            marker = New GMarkerGoogle(New PointLatLng(stop_el.Latitude, stop_el.Longitude), markerBitmap)
            If i = 0 OrElse i = routeStops.Count - 1 Then
                marker.ToolTipMode = MarkerTooltipMode.Always
            Else
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
            End If
            Dim toolTip As New CustomToolTip(marker)
            toolTip.Offset = New Point(5, -drawMarker("Orange", 9).Height / 2)
            marker.ToolTip = toolTip
            marker.ToolTipText = stop_el.Name
            marker.Tag = stop_el.ID
            gMap1.UpdateMarkerLocalPosition(marker) 'This ensures that the markers appear on map
            routesOverlay.Markers.Add(marker)
        Next
        routesOverlay.Routes.Add(Route)
        gMap1.Overlays.Insert(0, routesOverlay)
        gMap1.UpdateRouteLocalPosition(Route)
        gMap1.ZoomAndCenterRoute(Route)
        gMap1.Refresh()
        btnClear.Enabled = True
    End Sub

    Public Sub ClearShapes()
        routesOverlay.Clear()
        gMap1.Refresh()
    End Sub

    'This method calculates distance between two points on mapand is used to get the closest bus stop to the selected location
    Private Function DistanceBetweenPoints(ByVal lat1 As Double, ByVal lon1 As Double, ByVal lat2 As Double, ByVal lon2 As Double) As Double
        Dim R As Double = 6371 ' Earth's radius in kilometers
        Dim dLat As Double = Math.PI / 180 * (lat2 - lat1)
        Dim dLon As Double = Math.PI / 180 * (lon2 - lon1)
        Dim a As Double = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(Math.PI / 180 * lat1) * Math.Cos(Math.PI / 180 * lat2) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
        Dim c As Double = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
        Return R * c
    End Function

    'This method is used to show or hide bus stops on the map
    Public Sub showHideStops(ByRef isChecked As Boolean, ByRef stopsOverlay As GMapOverlay)
        If (isChecked = True) Then
            gMap1.Overlays.Add(stopsOverlay)
            gMap1.Refresh()
        Else
            stopsOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub

    'This method gets the transit route using Bing Maps API and plots it onto the map
    'In addition to the route it adds markers on the map for the start, destination and stops on the route
    Public Function getRoute(startCoord As PointLatLng, endCoord As PointLatLng, optimize As String)
        showHideStops(False, getStopsSQL(drawMarker("Orange", 9)))
        ' Define the route overlay and add it to the map
        Dim mapOverlay As GMapOverlay = New GMapOverlay("routes")

        'Define structures to add the route info
        Dim myRoute As New RouteInfo()
        myRoute.Steps = New List(Of StepInfo)

        'Define current time
        Dim currentTime As DateTime = DateTime.UtcNow
        Dim formattedTime As String = currentTime.ToString("yyyy-MM-ddTHH:mm:ssZ")

        ' Construct the Bing Maps API URL with necessary parameters
        Dim apiUrl As String = "https://dev.virtualearth.net/REST/v1/Routes/Transit?wayPoint.1={latitude1},{longitude1}&wayPoint.2={latitude2},{longitude2}&key={BingMapsAPIKey}&optimize={optimize}&routeAttributes=routePath,transitStops&dateTime={dateTime}&timeType=Departure"

        ' Replace the placeholders with actual values
        apiUrl = apiUrl.Replace("{latitude1}", startCoord.Lat)
        apiUrl = apiUrl.Replace("{longitude1}", startCoord.Lng)
        apiUrl = apiUrl.Replace("{latitude2}", endCoord.Lat)
        apiUrl = apiUrl.Replace("{longitude2}", endCoord.Lng)
        apiUrl = apiUrl.Replace("{BingMapsAPIKey}", apiKey)
        apiUrl = apiUrl.Replace("{dateTime}", formattedTime)
        apiUrl = apiUrl.Replace("{optimize}", optimize)

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
                            Dim myStep As New StepInfo()
                            If item("iconType") IsNot Nothing AndAlso item("iconType") = "Walk" Then
                                For i = CType(item("details")(0)("startPathIndices")(0), Integer) To CType(item("details")(0)("endPathIndices")(0), Integer)
                                    'Debug.WriteLine("startIndeks: " & item("details")(0)("startPathIndices")(0).ToString & " " & item("details")(0)("endPathIndices")(0).ToString)
                                    walkingPath.Add(New List(Of PointLatLng))

                                    Dim latitude As Double = coordinates(i)(0)
                                    Dim longitude As Double = coordinates(i)(1)
                                    Dim loc As New PointLatLng(latitude, longitude)
                                    walkingPath(walkCount).Add(loc)
                                Next
                                walkCount = walkCount + 1
                                myStep.IconPath = "Walk"
                                myStep.LineNr = ""
                                If item("travelDuration") IsNot Nothing Then
                                    myStep.Time = CInt(Math.Floor(item("travelDuration").Value(Of Double)() / 60))
                                Else
                                    myStep.Time = 0
                                End If
                                myRoute.Steps.Add(myStep)
                            Else
                                For i = CType(item("details")(0)("startPathIndices")(0), Integer) To CType(item("details")(0)("endPathIndices")(0), Integer)
                                    Debug.WriteLine("startIndeks: " & item("details")(0)("startPathIndices")(0).ToString & " " & item("details")(0)("endPathIndices")(0).ToString)
                                    busPath.Add(New List(Of PointLatLng))
                                    Dim latitude As Double = jsonResponse("resourceSets")(0)("resources")(0)("routePath")("line")("coordinates")(i)(0)
                                    Dim longitude As Double = jsonResponse("resourceSets")(0)("resources")(0)("routePath")("line")("coordinates")(i)(1)
                                    Dim loc As New PointLatLng(latitude, longitude)
                                    busPath(busCount).Add(loc)
                                Next
                                myStep.IconPath = "Bus"
                                If item("travelDuration") IsNot Nothing Then
                                    myStep.Time = CInt(Math.Floor(item("travelDuration").Value(Of Double)() / 60))
                                Else
                                    myStep.Time = 0
                                End If
                                If item("transitLine")("abbreviatedName") IsNot Nothing Then
                                    myStep.LineNr = item("transitLine")("abbreviatedName")
                                Else
                                    myStep.LineNr = ""
                                End If
                                myRoute.Steps.Add(myStep)
                                busCount = busCount + 1
                            End If
                        End If

                        If item("transitStops") IsNot Nothing Then
                            For Each point In item("transitStops")
                                If point IsNot Nothing AndAlso point("position") IsNot Nothing AndAlso point("position")("coordinates") IsNot Nothing Then
                                    Dim loc As New PointLatLng(point("position")("coordinates")(0), point("position")("coordinates")(1))
                                    Dim stopMarker As GMarkerGoogle = New GMarkerGoogle(loc, CType(drawMarker("Orange", 9), Bitmap))
                                    Dim toolTipStop As New CustomToolTip(stopMarker)
                                    stopMarker.ToolTip = toolTipStop
                                    stopMarker.ToolTipText = point("stopName")
                                    stopMarker.Tag = point("stopId")
                                    mapOverlay.Markers.Add(stopMarker)
                                End If
                            Next
                        End If
                    Next
                Next
                If jsonResponse("resourceSets")(0)("resources")(0)("routeLegs")(0)("startTime") IsNot Nothing _
                    AndAlso jsonResponse("resourceSets")(0)("resources")(0)("routeLegs")(0)("endTime") IsNot Nothing Then
                    Dim startTime As String = jsonResponse("resourceSets")(0)("resources")(0)("routeLegs")(0)("startTime")
                    Dim endTime As String = jsonResponse("resourceSets")(0)("resources")(0)("routeLegs")(0)("endTime")
                    Dim dateTime As DateTime = DateTime.ParseExact(startTime, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                    myRoute.StartTime = dateTime.ToString("HH:mm")
                    dateTime = DateTime.ParseExact(endTime, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                    myRoute.EndTime = dateTime.ToString("HH:mm")
                End If
                If jsonResponse("resourceSets")(0)("resources")(0)("travelDuration") IsNot Nothing Then
                        myRoute.Duration = CInt(Math.Floor(jsonResponse("resourceSets")(0)("resources")(0)("travelDuration").Value(Of Double)() / 60))
                    Else
                        myRoute.Duration = 0
                    End If
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

            Dim startMarker As GMarkerGoogle = New GMarkerGoogle(startCoord, CType(drawMarker("lightgreen", 13), Bitmap))
            Dim toolTipStart As New CustomToolTip(startMarker)
            startMarker.ToolTip = toolTipStart
            startMarker.ToolTipText = "Algus: " & startAddress
            startMarker.Size = New Size(14, 14)
            startMarker.ToolTipMode = MarkerTooltipMode.Always
            mapOverlay.Markers.Add(startMarker)
            gMap1.UpdateMarkerLocalPosition(startMarker)
            Dim endMarker As GMarkerGoogle = New GMarkerGoogle(endCoord, CType(drawMarker("red", 13), Bitmap))
            Dim toolTipEnd As New CustomToolTip(endMarker)
            endMarker.ToolTip = toolTipEnd
            endMarker.ToolTipText = "Sihtkoht: " & destAddress
            endMarker.Size = New Size(14, 14)
            endMarker.ToolTipMode = MarkerTooltipMode.Always
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
        Return myRoute
    End Function

    'This method clears the route from the map and adds the stops back on the map
    Public Sub clearRoute()
        gMap1.Overlays.Clear()
        gMap1.Refresh()
        cbStops.Checked = False
        cbStops.Checked = True
    End Sub

    'This method shows or hides the buses on the map
    Public Sub showHideBuses(ByRef isChecked As Boolean, ByRef busesOverlay As GMapOverlay)
        If (isChecked = True) Then
            gMap1.Overlays.Add(busesOverlay)
            gMap1.Refresh()
        Else
            busesOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub

    'This method shows or hides the trams on the map
    Public Sub showHideTrams(ByRef isChecked As Boolean, ByRef tramsOverlay As GMapOverlay)
        If (isChecked = True) Then
            gMap1.Overlays.Add(tramsOverlay)
            gMap1.Refresh()
        Else
            tramsOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub

    'This method shows or hides the trolleys on the map
    Public Sub showHideTrolleys(ByRef isChecked As Boolean, ByRef trolleysOverlay As GMapOverlay)
        If (isChecked = True) Then
            gMap1.Overlays.Add(trolleysOverlay)
            gMap1.Refresh()
        Else
            trolleysOverlay.Markers.Clear()
            gMap1.Refresh()
        End If
    End Sub

    'This method gets the bus locations using realtime component and adds them to the map
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

    'This method gets the trams location and adds them to the map
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

    'This method gets the trolleys location and adds them to the map
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

End Class


'Class for creating a modern tooltip box For the bus stop markers
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