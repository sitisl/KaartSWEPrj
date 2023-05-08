Imports GMap.NET.WindowsForms
Imports StopStruct = UTimeTable.ITimeTable.StopStruct
Imports RouteInfo = PrjTransitRouteInfo.IRouteInfo.RouteInfo
Imports System.Drawing.Drawing2D

Public Class Kaardirakendus

    Private lastMarker As GMapMarker
    Dim choose As Boolean = True

    Private Sub Kaardirakendus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UCtrlMapViewer1.initMap()
        URouteInfo1.Visible = False
    End Sub

    Private Sub Kaardirakendus_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            UTimeTable1.CloseConnections()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub UTimeTable1_ShapesReady(ByVal routepoints As List(Of StopStruct), ByVal routestops As List(Of StopStruct)) _
    Handles UTimeTable1.ShapesReady
        UCtrlMapViewer1.DisplayShapes(routepoints, routestops)
    End Sub

    Private Sub UTimeTable_ClearShapes() Handles UTimeTable1.ClearShapes
        UCtrlMapViewer1.ClearShapes()
    End Sub

    Private Sub HandleDisplayRouteInfo(ByVal route As RouteInfo) _
        Handles UCtrlMapViewer1.DisplayRouteInfo
        URouteInfo1.DisplayInfo(route)
        URouteInfo1.Visible = True
        URouteInfo1.Invalidate()
    End Sub

    Private Sub HandleClearRouteInfo() Handles UCtrlMapViewer1.ClearRouteInfo
        URouteInfo1.Visible = False
        URouteInfo1.ClearBrowser()
    End Sub

    Private Sub btnSaveStops_Paint(sender As Object, e As PaintEventArgs) Handles btnSaveStops.Paint
        Dim textSize As SizeF = e.Graphics.MeasureString(btnSaveStops.Text, btnSaveStops.Font)

        Dim textRect As New RectangleF(0, 0, btnSaveStops.Width, btnSaveStops.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        Dim text As String = "Salvesta peatused..."
        If btnSaveStops.ClientRectangle.Contains(btnSaveStops.PointToClient(Control.MousePosition)) Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnSaveStops.ClientRectangle)
            e.Graphics.DrawString(text, btnSaveStops.Font, Brushes.Black, textRect, format)
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnSaveStops.Width, btnSaveStops.Height)
            ' Draw button outline
            Dim outlinePen As Pen = New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(outlinePen, rect)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            e.Graphics.DrawString(text, btnSaveStops.Font, Brushes.White, textRect, format)
        End If
    End Sub

    Private Sub btnSaveStops_Click(sender As Object, e As EventArgs) Handles btnSaveStops.Click
        formCSV.ShowDialog()
    End Sub
End Class

