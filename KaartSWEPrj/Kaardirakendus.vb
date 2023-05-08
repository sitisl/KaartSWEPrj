Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports System.IO
Imports System.Net
Imports UTimeTable.UTimeTable
Imports PrjTransitRouteInfo.URouteInfo

Public Class Kaardirakendus

    Private lastMarker As GMapMarker
    Dim choose As Boolean = True

    Private Sub Kaardirakendus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UCtrlMapViewer1.initMap()
        URouteInfo1.Visible = False
        'UCtrlMapViewer.Invalidate()
        'UTimeTable1.Invalidate()
        'InitChromeDriverIfNeeded()
    End Sub

    Private Sub Kaardirakendus_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            UTimeTable1.CloseConnections()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
    Private Sub UTimeTable1_ShapesReady(ByVal routepoints As List(Of StopStruct), ByVal routestops As List(Of StopStruct)) _
    Handles UTimeTable1.ShapesReady
        UCtrlMapViewer1.DisplayShapes(routepoints, routestops)
    End Sub

    Private Sub UTimeTable_ClearShapes()
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

End Class