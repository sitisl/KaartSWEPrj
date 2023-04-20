Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Kaardirakendus
    Public Property startPoint As New PointLatLng
    Public Property endPoint As New PointLatLng

    Private Sub Kaardirakendus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnClear.Enabled = False
        btnRoute.Enabled = False
        UCtrlMapViewer1.initMap()
        Me.TransparencyKey = Color.Empty
    End Sub

    Private Sub UCtrlMapViewer1_LocationClicked(ByVal latitude As Double, ByVal longitude As Double) _
    Handles UCtrlMapViewer1.LocationClicked
        txtLat.Text = Math.Round(latitude, 5).ToString()
        txtLongName.Text = Math.Round(longitude, 5).ToString()
    End Sub

    Private Sub UCtrlMapViewer1_MarkerClicked(ByVal value As String, ByVal latitude As Double,
                                              ByVal longitude As Double) Handles UCtrlMapViewer1.MarkerClicked
        btnClear.Enabled = True
        If (txtStart.Text = "") Then
            txtStart.Text = value
            startPoint = New PointLatLng(latitude, longitude)
        Else
            txtEnd.Text = value
            endPoint = New PointLatLng(latitude, longitude)
            btnRoute.Enabled = True
        End If
    End Sub

    'Private Sub UCtrlMapViewer1_markerClick(ByVal stopName As String) Handles UCtrlMapViewer1.markerClick
    'End Sub

    Private Sub btnRoute_Click(sender As Object, e As EventArgs) Handles btnRoute.Click
        If txtStart.Text IsNot "" And txtEnd.Text IsNot "" _
            And txtStart.Text IsNot txtEnd.Text Then
            UCtrlMapViewer1.getRoute(startPoint, endPoint)
        End If
        btnRoute.Enabled = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtStart.Text = ""
        txtEnd.Text = ""
        btnClear.Enabled = False
        btnRoute.Enabled = False
        UCtrlMapViewer1.clearRoute()
    End Sub
End Class
