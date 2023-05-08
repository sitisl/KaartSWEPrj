Imports System.Drawing.Drawing2D
Imports CSVExporterDNF
Imports System.IO
Imports StopStruct = UTimeTable.ITimeTable.StopStruct

Public Class formCSV

    Dim filePath As String = Nothing
    Dim exporter As IExporter = New CSVExporterDNF.CExporter

    Private Function GetStopsData() As String(,)
        Dim timeT As UTimeTable.ITimeTable = New UTimeTable.UTimeTable
        Dim stops As List(Of StopStruct) = timeT.GetStopsCoordinates()
        Dim data(,) As String = New String(stops.Count - 1, 2) {}
        For i As Integer = 0 To stops.Count - 1
            data(i, 0) = stops(i).Name
            data(i, 1) = stops(i).Latitude.ToString()
            data(i, 2) = stops(i).Longitude.ToString()
        Next
        Return data
    End Function

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
                    lblFileName.Text = Path.GetFileName(filePath)
                    lblFilePathText.Visible = False
                    lblFileNameText.Visible = False
                    MessageBox.Show("Faili asukohta pole valitud.")
                    Exit Sub
                End If
                lblFilePathText.Visible = True
                lblFileNameText.Visible = True
                lblFilePath.Text = filePath
                lblFileName.Text = Path.GetFileName(filePath)
            Else
                If String.IsNullOrEmpty(filePath) Then
                    MessageBox.Show("Faili asukohta pole valitud.")
                    Exit Sub
                End If
            End If
            Dim data As String(,) = GetStopsData()
            Dim rowsWritten As Integer = exporter.saveDataToCsv(data, cbAppend.Checked)
            MessageBox.Show(String.Format("{0} rows written to {1}", rowsWritten, filePath))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub btnSave_Paint(sender As Object, e As PaintEventArgs) Handles btnSave.Paint
        Dim textSize As SizeF = e.Graphics.MeasureString(btnSave.Text, btnSave.Font)

        Dim textRect As New RectangleF(0, 0, btnSave.Width, btnSave.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        Dim text As String = "Salvesta"
        If btnSave.ClientRectangle.Contains(btnSave.PointToClient(Control.MousePosition)) Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnSave.ClientRectangle)
            e.Graphics.DrawString(text, btnSave.Font, Brushes.Black, textRect, format)
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnSave.Width, btnSave.Height)
            ' Draw button outline
            Dim outlinePen As Pen = New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(outlinePen, rect)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            e.Graphics.DrawString(text, btnSave.Font, Brushes.White, textRect, format)
        End If
    End Sub
End Class