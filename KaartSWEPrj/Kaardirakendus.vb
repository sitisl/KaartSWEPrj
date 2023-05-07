Imports GMap.NET.WindowsForms
Imports StopStruct = UTimeTable.ITimeTable.StopStruct

Public Class Kaardirakendus

    Private lastMarker As GMapMarker
    Dim choose As Boolean = True

    Private Sub Kaardirakendus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UCtrlMapViewer1.initMap()
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

End Class