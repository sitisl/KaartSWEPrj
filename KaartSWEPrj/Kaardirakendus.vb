Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports System.IO
Imports System.Net
Imports UTimeTable.UTimeTable

Public Class Kaardirakendus

    Private lastMarker As GMapMarker
    Dim choose As Boolean = True

    Private Sub Kaardirakendus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UCtrlMapViewer.initMap()
        'InitChromeDriverIfNeeded()
    End Sub


    Private Sub Kaardirakendus_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            UTimeTable.CloseConnections()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
    Private Sub UTimeTale_ShapesReady(ByVal routepoints As List(Of StopStruct), ByVal routestops As List(Of StopStruct)) _
    Handles UTimeTable.ShapesReady
        UCtrlMapViewer.DisplayShapes(routepoints, routestops)
    End Sub

    Private Sub UTimeTale_ClearShapes() _
    Handles UTimeTable.ClearShapes
        UCtrlMapViewer.ClearShapes()
    End Sub

End Class