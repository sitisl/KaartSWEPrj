Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports System.IO
Imports System.Net
Imports UTimeTable.UTimeTable
Imports CSVExporterDNF

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
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub UTimeTable1_ShapesReady(ByVal routepoints As List(Of StopStruct), ByVal routestops As List(Of StopStruct)) _
    Handles UTimeTable1.ShapesReady
        UCtrlMapViewer1.DisplayShapes(routepoints, routestops)
    End Sub

    Private Sub UTimeTable_ClearShapes()
        UCtrlMapViewer1.ClearShapes()
    End Sub

    Dim filePath As String = Nothing
    Dim exporter As IExporter = New CSVExporterDNF.CExporter

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If tbQualifier.Text = Nothing Or tbDelimiter.Text = Nothing Then
                MessageBox.Show("Täida väljad.")
                Exit Sub
            End If
            exporter.delimiter = tbDelimiter.Text
            exporter.textQualifier = tbQualifier.Text
            If cbSaveType.Checked Then
                filePath = exporter.setFileToSave()
                If String.IsNullOrEmpty(filePath) Then
                    lblFilePath.Text = filePath
                    LblFileName.Text = Path.GetFileName(filePath)
                    lblFilePathText.Visible = False
                    lblFileNameText.Visible = False
                    MessageBox.Show("Faili asukohta pole valitud.")
                    Exit Sub
                End If
                lblFilePathText.Visible = True
                lblFileNameText.Visible = True
                lblFilePath.Text = filePath
                LblFileName.Text = Path.GetFileName(filePath)
            Else
                If String.IsNullOrEmpty(filePath) Then
                    MessageBox.Show("Faili asukohta pole valitud.")
                    Exit Sub
                End If
            End If
            Dim data As Array = GetMyData()
            Dim rowsWritten As Integer = exporter.saveDataToCsv(data, cbAppend.Checked)
            MessageBox.Show(String.Format("{0} rows written to {1}", rowsWritten, filePath))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetMyData() As String(,)
        Dim data(,) As String = New String(2, 2) {{"Buss 1", "08:00", "1"}, {"Tramm 3", "06:42", "0"}, {"Buss 60", "21:34", "1"}} 'Asendada reaalsete andmetega
        Return data
    End Function

End Class