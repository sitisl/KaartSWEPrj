Imports System.Data.SQLite
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports StopStruct = UTimeTable.ITimeTable.StopStruct
Imports TransportStruct = UTimeTable.ITimeTable.TransportStruct

Public Class UTimeTable
    Implements ITimeTable

    Dim SQLiteCon As SQLiteConnection
    Dim SQLiteCmd As SQLiteCommand
    Dim SQLiteReader As SQLiteDataReader
    Public Suund As String = Nothing
    Public SelectedLine As String = Nothing
    Public SelectedStop As String = Nothing
    Public SelectedDay As String = "monday"
    Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
    Dim dbFilePath As String = Path.Combine(desktopPath, "mapdb.db")
    Dim CData As PrjData.IDataGetter = New PrjData.CDataGetter
    Private Structure TimeStruct
        Dim Name As String
        Dim Time As String
    End Structure

    Private Sub UTimeTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnDay1.Font = New Font(btnDay1.Font, FontStyle.Bold)
        btnDisplayLines.Enabled = False
        btnAB.Enabled = False
        btnBA.Enabled = False
    End Sub

    Public Function GetRealTimeTransport(type As String) As List(Of ITimeTable.TransportStruct) Implements ITimeTable.GetRealTimeTransport
        Dim transport As New List(Of TransportStruct)
        Dim url As String = "https://transport.tallinn.ee/gps.txt"

        Try
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "GET"
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            Using reader As New StreamReader(response.GetResponseStream())
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim fields As String() = line.Split(",")
                    If fields.Length >= 8 Then
                        Dim t As New TransportStruct
                        Select Case type
                            Case "bus"
                                If fields(0) = 2 Then
                                    t.Number = fields(1)
                                    t.Latitude = Double.Parse(fields(3), CultureInfo.InvariantCulture) / 1000000
                                    t.Longitude = Double.Parse(fields(2), CultureInfo.InvariantCulture) / 1000000
                                    transport.Add(t)
                                End If
                            Case "tram"
                                If fields(0) = 3 Then
                                    t.Number = fields(1)
                                    t.Latitude = Double.Parse(fields(3), CultureInfo.InvariantCulture) / 1000000
                                    t.Longitude = Double.Parse(fields(2), CultureInfo.InvariantCulture) / 1000000
                                    transport.Add(t)
                                End If
                            Case "trolley"
                                If fields(0) = 1 Then
                                    t.Number = fields(1)
                                    t.Latitude = Double.Parse(fields(3), CultureInfo.InvariantCulture) / 1000000
                                    t.Longitude = Double.Parse(fields(2), CultureInfo.InvariantCulture) / 1000000
                                    transport.Add(t)
                                End If
                        End Select
                    End If
                End While
            End Using
            response.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return transport
    End Function

    Public Function GetStopsCoordinates() As List(Of StopStruct) Implements ITimeTable.GetStopsCoordinates
        Dim query As String = "SELECT name, stop_id, lat, lon FROM stops;"
        Dim stops As New List(Of StopStruct)

        Try
            MakeSqlConn()
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()
            While SQLiteReader.Read()
                Dim s As New StopStruct
                s.Name = SQLiteReader.GetString(0)
                s.ID = SQLiteReader.GetInt32(1)
                s.Latitude = SQLiteReader.GetDouble(2)
                s.Longitude = SQLiteReader.GetDouble(3)
                stops.Add(s)
            End While
            SQLiteReader.Close()
            SQLiteCon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return stops
    End Function

    Public Sub MakeSqlConn() Implements ITimeTable.MakeSqlConn
        Try
            SQLiteCon = New SQLiteConnection($"Data Source={dbFilePath};Version=3;")
            SQLiteCon.Open()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Public Sub CloseConnections() Implements ITimeTable.CloseConnections
        Try
            SQLiteCon.Close()
        Catch
            Exit Sub
        End Try
    End Sub

    Private Sub LoadLines()
        Dim query As String
        If String.IsNullOrEmpty(lBoxPeatused.Text) Then
            query = "SELECT route_short_name FROM routes ORDER BY CAST(SUBSTRING(route_short_name, 6) AS UNSIGNED) ASC;"
        Else
            query = "SELECT DISTINCT routes.route_short_name FROM routes
             JOIN trips ON routes.route_id = trips.route_id
             JOIN stoptimes ON trips.trip_id = stoptimes.trip_id
             JOIN stops ON stoptimes.stop_id = stops.stop_id
             WHERE stops.name = '" & SelectedStop & "';"
        End If
        SQLiteReader = CData.MakeQuery(query)
        While SQLiteReader.Read()
            lBoxLiinid.Items.Add(SQLiteReader.GetString(0))
        End While
    End Sub

    Private Sub LoadLineStops()
        Dim query As String
        If String.IsNullOrEmpty(lBoxLiinid.Text) Then ' Ühtegi liini pole kuvatud, seega kuvame kõik peatused
            query = "select Distinct name from stops Order by name ASC;"
        Else
            query = "SELECT DISTINCT name FROM stops
             JOIN stoptimes ON stops.stop_id = stoptimes.stop_id
             JOIN trips ON stoptimes.trip_id = trips.trip_id
             JOIN routes ON trips.route_id = routes.route_id
             WHERE routes.route_short_name = '" & SelectedLine & "'
             AND trips.direction_code = '" & Suund & "'
             ORDER BY CAST(stoptimes.stop_sequence AS UNSIGNED);"
        End If
        SQLiteReader = CData.MakeQuery(query)
        While SQLiteReader.Read()
            lBoxPeatused.Items.Add(SQLiteReader.GetString(0))
        End While
    End Sub

    Private Sub AppendStopDepartureTimes(tripID As Integer)
        If tripID = 0 Then
            Exit Sub
        End If
        Dim routeTimeList As New List(Of TimeStruct)
        Dim query As String = "Select stoptimes.arrival_time, stops.name, routes.route_short_name
                                From stoptimes
                                Join stops On stoptimes.stop_id = stops.stop_id
                                Join trips On stoptimes.trip_id = trips.trip_id
                                Join calender On trips.service_id = calender.service_id
                                Join routes On trips.route_id = routes.route_id
                                Where trips.trip_id = '" & tripID & "'"
        SQLiteReader = CData.MakeQuery(query)
        While SQLiteReader.Read()
            Dim r As New TimeStruct
            r.Time = SQLiteReader.GetString(0).Substring(0, 5)
            r.Name = SQLiteReader.GetString(1)
            routeTimeList.Add(r)
        End While
        Dim updatedItems As New List(Of String)
        For Each item As String In lBoxPeatused.Items
            For Each r As TimeStruct In routeTimeList
                If item.Contains(":") Then
                    item = item.Substring(6)
                End If
                If r.Name = item Then
                    updatedItems.Add(r.Time & " " & item)
                    Exit For ' Exit inner loop once a match is found
                End If
            Next
        Next
        RemoveHandler lBoxPeatused.SelectedValueChanged, AddressOf lBoxPeatused_SelectedValueChanged
        Dim index As Integer = lBoxPeatused.SelectedIndex
        lBoxPeatused.Items.Clear()
        lBoxPeatused.Items.AddRange(updatedItems.ToArray())
        lBoxPeatused.SelectedIndex = index
        AddHandler lBoxPeatused.SelectedValueChanged, AddressOf lBoxPeatused_SelectedValueChanged
        SQLiteReader.Close()
    End Sub

    Public Event ShapesReady(ByVal routepoints As List(Of StopStruct), ByVal routestops As List(Of StopStruct))
    Public Event ClearShapes()

    Private Function GetCurrentTimeTripID()
        Dim tempStop As String
        If SelectedStop = Nothing And Not String.IsNullOrEmpty(lBoxPeatused.Text) Then ' Kui pole veel valitud peatust, siis automaatselt valitakse esimene peatus
            tempStop = lBoxPeatused.Items(0)
        Else
            tempStop = SelectedStop
        End If
        If tempStop = Nothing Then
            Return 0
        End If

        Dim tripID As Int32
        Dim query = "SELECT stoptimes.arrival_time, trips.trip_id
             FROM stoptimes
             JOIN stops ON stoptimes.stop_id = stops.stop_id
             JOIN trips ON stoptimes.trip_id = trips.trip_id
             JOIN calender ON trips.service_id = calender.service_id
             JOIN routes ON trips.route_id = routes.route_id
             WHERE routes.route_short_name = '" & SelectedLine & "'
             AND stops.name = '" & tempStop & "'
             AND trips.direction_code = '" & Suund & "'
             AND calender.'" & SelectedDay & "' = ""1""
             ORDER by arrival_time;"

        Dim time As DateTime = DateTime.Now
        Dim closestTime As String = Nothing
        SQLiteReader = CData.MakeQuery(query)
        While SQLiteReader.Read()
            Dim arrivalTime As String = SQLiteReader.GetString(0)
            tripID = SQLiteReader.GetInt32(1)
            Dim hour As Integer = Integer.Parse(arrivalTime.Substring(0, 2))
            Dim minute As Integer = Integer.Parse(arrivalTime.Substring(3, 2))
            If hour = 24 Then
                hour = 0
            End If
            Dim arrivalDateTime As DateTime = New DateTime(time.Year, time.Month, time.Day, hour, minute, 0)

            If arrivalDateTime > time AndAlso (closestTime Is Nothing OrElse arrivalDateTime < DateTime.Parse(closestTime)) Then
                closestTime = arrivalTime
                Exit While
            End If
        End While
        If closestTime IsNot Nothing Then
                lblPeatused.Text = "Peatused"
            Else
                lblPeatused.Text = "Tänased viimased ajad olid"
                lblPeatused.TextAlign = ContentAlignment.MiddleCenter
            End If
            Return tripID
    End Function

    Private Sub LoadLineSuund()
        Dim query As String
        query = "SELECT trips.trip_long_name FROM trips
                JOIN routes ON trips.route_id = routes.route_id
                WHERE routes.route_short_name = '" & SelectedLine & "'
                AND trips.direction_code = ""A>B""
                GROUP BY trips.trip_long_name;"
        SQLiteReader = CData.MakeQuery(query)
        SQLiteReader.Read()
        btnAB.Text = SQLiteReader.GetString(0)

        query = "SELECT trips.trip_long_name FROM trips
                JOIN routes ON trips.route_id = routes.route_id
                WHERE routes.route_short_name = '" & SelectedLine & "'
                AND trips.direction_code = ""B>A""
                GROUP BY trips.trip_long_name;"

        SQLiteReader = CData.MakeQuery(query)
        SQLiteReader.Read()
        btnBA.Text = SQLiteReader.GetString(0)
    End Sub

    Private Sub LoadShapes()
        Dim routePoints As New List(Of StopStruct)
        Dim routestops As New List(Of StopStruct)
        Dim query = "SELECT shape_pt_lat, shape_pt_lon FROM shapes
                    JOIN trips ON shapes.shape_id = trips.shape_id
                    JOIN routes ON trips.route_id = routes.route_id
                    WHERE routes.route_short_name = '" & SelectedLine & "'
                    AND trips.direction_code = '" & Suund & "'
                    ORDER BY shape_pt_sequence;"

        SQLiteReader = CData.MakeQuery(query)
        While SQLiteReader.Read()
            Dim point As New StopStruct
            point.Latitude = SQLiteReader.GetDouble(0)
            point.Longitude = SQLiteReader.GetDouble(1)
            routePoints.Add(point)
        End While
        query = "SELECT name, lat, lon FROM stops
                    JOIN stoptimes ON stops.stop_id = stoptimes.stop_id
                    JOIN trips ON stoptimes.trip_id = trips.trip_id
                    JOIN routes ON trips.route_id = routes.route_id
                    WHERE routes.route_short_name = '" & SelectedLine & "'
                    AND trips.direction_code = '" & Suund & "'
                    ORDER BY CAST(stoptimes.stop_sequence AS UNSIGNED);"

        SQLiteReader = CData.MakeQuery(query)
        While SQLiteReader.Read()
            Dim s As New StopStruct
            s.Name = SQLiteReader.GetString(0)
            s.Latitude = SQLiteReader.GetDouble(1)
            s.Longitude = SQLiteReader.GetDouble(2)
            routestops.Add(s)
        End While
        RaiseEvent ShapesReady(routePoints, routestops)
        btnDisplayLines.Enabled = False
    End Sub

    Private Sub GetStopTimesRealTime()
        lBoxRealTime.Items.Clear()
        Dim url As String = "https://transport.tallinn.ee/siri-stop-departures.php?stopid="
        Dim SelectedStopID As Integer
        Dim query = "SELECT stops.stop_id FROM stops
                    JOIN stoptimes ON stops.stop_id = stoptimes.stop_id
                    JOIN trips ON stoptimes.trip_id = trips.trip_id
                    JOIN routes ON trips.route_id = routes.route_id
                    WHERE routes.route_short_name = '" & SelectedLine & "'
                    AND stops.name = '" & SelectedStop & "'
                    AND trips.direction_code = '" & Suund & "';"
        SQLiteReader = CData.MakeQuery(query)
        SQLiteReader.Read()
        SelectedStopID = SQLiteReader.GetInt32(0)
        url &= SelectedStopID.ToString()
        Dim parts As String() = SelectedLine.Split(" "c)
        Dim transport As String = parts(0).ToLower()
        transport = transport.Substring(0, 3)
        Dim number As String = parts(parts.Length - 1)
        Dim time As Double
        Try
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
                    If fields.Length >= 7 And fields(0) = transport And fields(1) = number Then
                        Dim timebuf = Double.Parse(fields(2), CultureInfo.InvariantCulture)
                        timebuf = (timebuf - time) / 60
                        Dim formatted As String = timebuf.ToString("F0")
                        formatted &= " min"
                        lBoxRealTime.Items.Add(formatted)
                    End If
                End While
            End Using
            response.Close()
            If lBoxRealTime.Items.Count = 0 Then
                lBoxRealTime.Items.Add("Reaalaja")
                lBoxRealTime.Items.Add("väljumised")
                lBoxRealTime.Items.Add("puuduvad")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnShowLines_Click(sender As Object, e As EventArgs) Handles btnShowLines.Click
        lBoxLiinid.Items.Clear()
        lBoxPeatused.Items.Clear()
        lBoxRealTime.Items.Clear()
        btnBA.Font = New Font(btnBA.Font, FontStyle.Regular)
        btnAB.Font = New Font(btnAB.Font, FontStyle.Regular)
        SelectedStop = Nothing
        SelectedLine = Nothing
        Suund = Nothing
        RaiseEvent ClearShapes()
        rtbAjad.Clear()
        btnAB.Text = Nothing
        btnBA.Text = Nothing
        btnAB.Enabled = False
        btnBA.Enabled = False
        lblAbi.Visible = False
        LoadLines()
    End Sub

    Private Sub btnShowStops_Click(sender As Object, e As EventArgs) Handles btnShowStops.Click
        lBoxLiinid.Items.Clear()
        lBoxPeatused.Items.Clear()
        lBoxRealTime.Items.Clear()
        btnAB.Font = New Font(btnAB.Font, FontStyle.Regular)
        btnBA.Font = New Font(btnBA.Font, FontStyle.Regular)
        SelectedStop = Nothing
        SelectedLine = Nothing
        Suund = Nothing
        RaiseEvent ClearShapes()
        rtbAjad.Clear()
        btnAB.Text = Nothing
        btnBA.Text = Nothing
        btnAB.Enabled = False
        btnBA.Enabled = False
        lblAbi.Visible = False
        LoadLineStops()
    End Sub

    Private Sub btnAB_Click(sender As Object, e As EventArgs) Handles btnAB.Click
        If String.IsNullOrEmpty(lBoxLiinid.Text) And String.IsNullOrEmpty(lBoxPeatused.Text) Or Suund = "A>B" Then
            Return
        End If
        btnAB.Font = New Font(btnAB.Font, FontStyle.Bold)
        btnBA.Font = New Font(btnBA.Font, FontStyle.Regular)
        rtbAjad.Clear()
        lblAbi.Visible = False
        lBoxRealTime.Items.Clear()
        lBoxPeatused.Items.Clear()
        Suund = "A>B"
        LoadLineStops()
        lBoxPeatused.SelectedIndex = 0
        btnDisplayLines.Enabled = True
        RaiseEvent ClearShapes()
    End Sub

    Private Sub btnBA_Click(sender As Object, e As EventArgs) Handles btnBA.Click
        If String.IsNullOrEmpty(lBoxLiinid.Text) And String.IsNullOrEmpty(lBoxPeatused.Text) Or Suund = "B>A" Then
            Return
        End If
        btnAB.Font = New Font(btnAB.Font, FontStyle.Regular)
        btnBA.Font = New Font(btnBA.Font, FontStyle.Bold)
        rtbAjad.Clear()
        lblAbi.Visible = False
        lBoxRealTime.Items.Clear()
        lBoxPeatused.Items.Clear()
        Suund = "B>A"
        LoadLineStops()
        lBoxPeatused.SelectedIndex = 0
        btnDisplayLines.Enabled = True
        RaiseEvent ClearShapes()
    End Sub

    Private Sub lBoxLiinid_SelectedValueChanged(sender As Object, e As EventArgs) Handles lBoxLiinid.SelectedValueChanged
        If lBoxLiinid.SelectedItem IsNot Nothing Then
            lBoxPeatused.Items.Clear()
            lBoxRealTime.Items.Clear()
            btnBA.Font = New Font(btnBA.Font, FontStyle.Regular)
            btnAB.Font = New Font(btnAB.Font, FontStyle.Regular)
            SelectedStop = Nothing
            Suund = Nothing
            rtbAjad.Clear()
            RaiseEvent ClearShapes()
            lblAbi.Visible = False
            btnDisplayLines.Enabled = False
            SelectedLine = lBoxLiinid.SelectedItem
            LoadLineSuund()
            btnAB.Enabled = True
            btnBA.Enabled = True
        End If
    End Sub

    Private Sub lBoxPeatused_SelectedValueChanged(sender As Object, e As EventArgs) Handles lBoxPeatused.SelectedValueChanged
        If lBoxPeatused.SelectedItem.ToString().Contains(":") Then
            SelectedStop = lBoxPeatused.SelectedItem.Substring(6)
        Else
            SelectedStop = lBoxPeatused.SelectedItem
        End If
        rtbAjad.Clear()
        lblAbi.Visible = False
        lBoxRealTime.Items.Clear()
        If String.IsNullOrEmpty(lBoxLiinid.Text) Then
            SelectedLine = Nothing
            LoadLines()
        Else
            GetStopTimes()
            GetStopTimesRealTime()
            Dim tripID As Integer = GetCurrentTimeTripID()
            AppendStopDepartureTimes(tripID)
        End If
    End Sub

    Private Sub GetStopTimes()
        If SelectedStop = Nothing Then
            Exit Sub
        End If
        Dim InvaColor As Color = Color.DeepSkyBlue
        lblAbi.ForeColor = InvaColor
        lblAbi.Font = New Font(lblAbi.Font, FontStyle.Regular)
        lblAbi.Visible = True
        rtbAjad.Visible = True
        rtbAjad.Clear()

        Dim query = "SELECT stoptimes.arrival_time, trips.wheelchair_accessible
             FROM stoptimes
             JOIN stops ON stoptimes.stop_id = stops.stop_id
             JOIN trips ON stoptimes.trip_id = trips.trip_id
             JOIN calender ON trips.service_id = calender.service_id
             JOIN routes ON trips.route_id = routes.route_id
             WHERE routes.route_short_name = '" & SelectedLine & "'
             AND stops.name = '" & SelectedStop & "'
             AND trips.direction_code = '" & Suund & "'
             AND calender.'" & SelectedDay & "' = ""1""
             ORDER by arrival_time;"

        SQLiteReader = CData.MakeQuery(query)
        Dim currentHour As Integer = -1 ' initialize current hour to -1
        While SQLiteReader.Read()
            rtbAjad.SelectionColor = Color.White
            Dim arrivalTime As String = SQLiteReader.GetString(0)
            Dim hour As Integer = Integer.Parse(arrivalTime.Substring(0, 2))
            If hour >= 24 Then
                hour = hour - 24
            End If
            Dim minute As Integer = Integer.Parse(arrivalTime.Substring(3, 2))
            Dim wheelchairAccessible As Int32 = (SQLiteReader.GetInt32(1))
            If currentHour <> hour Then ' new hour, add hour header
                If currentHour >= 0 Then ' not the first hour, add newline
                    rtbAjad.AppendText(Environment.NewLine)
                End If
                rtbAjad.AppendText(hour) ' add hour header
                rtbAjad.AppendText(": ") ' add space separator between minutes
                currentHour = hour
            End If
            If wheelchairAccessible = 1 Then
                rtbAjad.SelectionColor = InvaColor
            End If
            rtbAjad.AppendText(minute) ' append minute string
            rtbAjad.AppendText(" ") ' add space separator between minutes
        End While
    End Sub

    Private Sub btnDay1_Click(sender As Object, e As EventArgs) Handles btnDay1.Click
        SelectedDay = "monday"
        btnDay1.Font = New Font(btnDay1.Font, FontStyle.Bold)
        btnDay2.Font = New Font(btnDay2.Font, FontStyle.Regular)
        btnDay3.Font = New Font(btnDay3.Font, FontStyle.Regular)
        GetStopTimes()
        Dim tripID As Integer = GetCurrentTimeTripID()
        AppendStopDepartureTimes(tripID)
    End Sub

    Private Sub btnDay2_Click(sender As Object, e As EventArgs) Handles btnDay2.Click
        SelectedDay = "saturday"
        btnDay1.Font = New Font(btnDay1.Font, FontStyle.Regular)
        btnDay2.Font = New Font(btnDay2.Font, FontStyle.Bold)
        btnDay3.Font = New Font(btnDay3.Font, FontStyle.Regular)
        GetStopTimes()
        Dim tripID As Integer = GetCurrentTimeTripID()
        AppendStopDepartureTimes(tripID)
    End Sub

    Private Sub btnDay3_Click(sender As Object, e As EventArgs) Handles btnDay3.Click
        SelectedDay = "sunday"
        btnDay1.Font = New Font(btnDay1.Font, FontStyle.Regular)
        btnDay2.Font = New Font(btnDay2.Font, FontStyle.Regular)
        btnDay3.Font = New Font(btnDay3.Font, FontStyle.Bold)
        GetStopTimes()
        Dim tripID As Integer = GetCurrentTimeTripID()
        AppendStopDepartureTimes(tripID)
    End Sub

    Private Sub btnDisplayLines_Click(sender As Object, e As EventArgs) Handles btnDisplayLines.Click

        If String.IsNullOrEmpty(Suund) Or String.IsNullOrEmpty(SelectedLine) Then
            Return
        Else
            LoadShapes()
        End If
    End Sub

    Private Sub btnShowLines_Paint(sender As Object, e As PaintEventArgs) Handles btnShowLines.Paint
        Dim textSize As SizeF = e.Graphics.MeasureString(btnShowLines.Text, btnShowLines.Font)

        Dim textRect As New RectangleF(0, 0, btnShowLines.Width, btnShowLines.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        If btnShowLines.ClientRectangle.Contains(btnShowLines.PointToClient(Control.MousePosition)) AndAlso btnShowLines.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnShowLines.ClientRectangle)
            If btnShowLines.Enabled = True Then
                e.Graphics.DrawString(btnShowLines.Text, btnShowLines.Font, Brushes.Black, textRect, format)
            Else
                e.Graphics.DrawString(btnShowLines.Text, btnShowLines.Font, Brushes.Gray, textRect, format)
            End If
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnShowLines.Width, btnShowLines.Height)
            ' Draw button outline
            Dim outlinePen As Pen = New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(outlinePen, rect)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            If btnShowLines.Enabled = True Then
                e.Graphics.DrawString(btnShowLines.Text, btnShowLines.Font, Brushes.White, textRect, format)
            Else
                e.Graphics.DrawString(btnShowLines.Text, btnShowLines.Font, Brushes.Gray, textRect, format)
            End If
        End If

    End Sub

    Private Sub btnShowStops_Paint(sender As Object, e As PaintEventArgs) Handles btnShowStops.Paint
        Dim textSize As SizeF = e.Graphics.MeasureString(btnShowStops.Text, btnShowStops.Font)

        Dim textRect As New RectangleF(0, 0, btnShowStops.Width, btnShowStops.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        If btnShowStops.ClientRectangle.Contains(btnShowStops.PointToClient(Control.MousePosition)) AndAlso btnShowStops.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnShowStops.ClientRectangle)
            If btnShowLines.Enabled = True Then
                e.Graphics.DrawString(btnShowStops.Text, btnShowStops.Font, Brushes.Black, textRect, format)
            Else
                e.Graphics.DrawString(btnShowStops.Text, btnShowStops.Font, Brushes.Gray, textRect, format)
            End If
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnShowStops.Width, btnShowStops.Height)
            ' Draw button outline
            Dim outlinePen As Pen = New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(outlinePen, rect)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            If btnShowLines.Enabled = True Then
                e.Graphics.DrawString(btnShowStops.Text, btnShowStops.Font, Brushes.White, textRect, format)
            Else
                e.Graphics.DrawString(btnShowStops.Text, btnShowStops.Font, Brushes.Gray, textRect, format)
            End If
        End If

    End Sub

    Private Sub btnDisplayLines_Paint(sender As Object, e As PaintEventArgs) Handles btnDisplayLines.Paint
        Dim textSize As SizeF = e.Graphics.MeasureString(btnDisplayLines.Text, btnDisplayLines.Font)

        Dim textRect As New RectangleF(0, 0, btnDisplayLines.Width, btnDisplayLines.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        If btnDisplayLines.ClientRectangle.Contains(btnDisplayLines.PointToClient(Control.MousePosition)) AndAlso btnDisplayLines.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnDisplayLines.ClientRectangle)
            If btnDisplayLines.Enabled = True Then
                e.Graphics.DrawString(btnDisplayLines.Text, btnDisplayLines.Font, Brushes.Black, textRect, format)
            Else
                e.Graphics.DrawString(btnDisplayLines.Text, btnDisplayLines.Font, Brushes.Gray, textRect, format)
            End If
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnDisplayLines.Width, btnDisplayLines.Height)
            ' Draw button outline
            Dim outlinePen As Pen = New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(outlinePen, rect)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            If btnDisplayLines.Enabled = True Then
                e.Graphics.DrawString(btnDisplayLines.Text, btnDisplayLines.Font, Brushes.White, textRect, format)
            Else
                e.Graphics.DrawString(btnDisplayLines.Text, btnDisplayLines.Font, Brushes.Gray, textRect, format)
            End If
        End If

    End Sub

    Private Sub btnAB_Paint(sender As Object, e As PaintEventArgs) Handles btnAB.Paint
        Dim textSize As SizeF = e.Graphics.MeasureString(btnAB.Text, btnAB.Font)

        Dim textRect As New RectangleF(0, 0, btnAB.Width, btnAB.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        If btnAB.ClientRectangle.Contains(btnAB.PointToClient(Control.MousePosition)) AndAlso btnAB.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnAB.ClientRectangle)
            If btnAB.Enabled = True Then
                e.Graphics.DrawString(btnAB.Text, btnAB.Font, Brushes.Black, textRect, format)
            Else
                e.Graphics.DrawString(btnAB.Text, btnAB.Font, Brushes.Gray, textRect, format)
            End If
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnAB.Width, btnAB.Height)
            ' Draw button outline
            Dim outlinePen As Pen = New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(outlinePen, rect)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            If btnAB.Enabled = True Then
                e.Graphics.DrawString(btnAB.Text, btnAB.Font, Brushes.White, textRect, format)
            Else
                e.Graphics.DrawString(btnAB.Text, btnAB.Font, Brushes.Gray, textRect, format)
            End If
        End If

    End Sub

    Private Sub btnBA_Paint(sender As Object, e As PaintEventArgs) Handles btnBA.Paint
        Dim textSize As SizeF = e.Graphics.MeasureString(btnBA.Text, btnBA.Font)

        Dim textRect As New RectangleF(0, 0, btnBA.Width, btnBA.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        If btnBA.ClientRectangle.Contains(btnBA.PointToClient(Control.MousePosition)) AndAlso btnBA.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnBA.ClientRectangle)
            If btnBA.Enabled = True Then
                e.Graphics.DrawString(btnBA.Text, btnBA.Font, Brushes.Black, textRect, format)
            Else
                e.Graphics.DrawString(btnBA.Text, btnBA.Font, Brushes.Gray, textRect, format)
            End If
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnBA.Width, btnBA.Height)
            ' Draw button outline
            Dim outlinePen As Pen = New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(outlinePen, rect)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            If btnBA.Enabled = True Then
                e.Graphics.DrawString(btnBA.Text, btnBA.Font, Brushes.White, textRect, format)
            Else
                e.Graphics.DrawString(btnBA.Text, btnBA.Font, Brushes.Gray, textRect, format)
            End If
        End If

    End Sub

    Private Sub btnDay1_Paint(sender As Object, e As PaintEventArgs) Handles btnDay1.Paint
        Dim textSize As SizeF = e.Graphics.MeasureString(btnDay1.Text, btnDay1.Font)

        Dim textRect As New RectangleF(0, 0, btnDay1.Width, btnDay1.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        If btnDay1.ClientRectangle.Contains(btnDay1.PointToClient(Control.MousePosition)) AndAlso btnDay1.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnDay1.ClientRectangle)
            If btnDay1.Enabled = True Then
                e.Graphics.DrawString(btnDay1.Text, btnDay1.Font, Brushes.Black, textRect, format)
            Else
                e.Graphics.DrawString(btnDay1.Text, btnDay1.Font, Brushes.Gray, textRect, format)
            End If
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnDay1.Width, btnDay1.Height)
            ' Draw button outline
            Dim outlinePen As Pen = New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(outlinePen, rect)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            If btnDay1.Enabled = True Then
                e.Graphics.DrawString(btnDay1.Text, btnDay1.Font, Brushes.White, textRect, format)
            Else
                e.Graphics.DrawString(btnDay1.Text, btnDay1.Font, Brushes.Gray, textRect, format)
            End If
        End If

    End Sub

    Private Sub btnDay2_Paint(sender As Object, e As PaintEventArgs) Handles btnDay2.Paint
        Dim textSize As SizeF = e.Graphics.MeasureString(btnDay2.Text, btnDay2.Font)

        Dim textRect As New RectangleF(0, 0, btnDay2.Width, btnDay2.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        If btnDay2.ClientRectangle.Contains(btnDay2.PointToClient(Control.MousePosition)) AndAlso btnDay2.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnDay2.ClientRectangle)
            If btnDay2.Enabled = True Then
                e.Graphics.DrawString(btnDay2.Text, btnDay2.Font, Brushes.Black, textRect, format)
            Else
                e.Graphics.DrawString(btnDay2.Text, btnDay2.Font, Brushes.Gray, textRect, format)
            End If
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnDay2.Width, btnDay2.Height)
            ' Draw button outline
            Dim outlinePen As Pen = New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(outlinePen, rect)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            If btnDay2.Enabled = True Then
                e.Graphics.DrawString(btnDay2.Text, btnDay2.Font, Brushes.White, textRect, format)
            Else
                e.Graphics.DrawString(btnDay2.Text, btnDay2.Font, Brushes.Gray, textRect, format)
            End If
        End If
    End Sub

    Private Sub btnDay3_Paint(sender As Object, e As PaintEventArgs) Handles btnDay3.Paint
        Dim textSize As SizeF = e.Graphics.MeasureString(btnDay3.Text, btnDay3.Font)
        Dim textRect As New RectangleF(0, 0, btnDay3.Width, btnDay3.Height)
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        If btnDay3.ClientRectangle.Contains(btnDay3.PointToClient(Control.MousePosition)) AndAlso btnDay3.Enabled = True Then
            e.Graphics.FillRectangle(SystemBrushes.Control, btnDay3.ClientRectangle)
            If btnDay3.Enabled = True Then
                e.Graphics.DrawString(btnDay3.Text, btnDay3.Font, Brushes.Black, textRect, format)
            Else
                e.Graphics.DrawString(btnDay3.Text, btnDay3.Font, Brushes.Gray, textRect, format)
            End If
        Else
            Dim rect As Rectangle = New Rectangle(0, 0, btnDay3.Width, btnDay3.Height)
            ' Draw button outline
            Dim outlinePen As Pen = New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(outlinePen, rect)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(204, 35, 35, 35), Color.FromArgb(204, 20, 20, 20), LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
            If btnDay3.Enabled = True Then
                e.Graphics.DrawString(btnDay3.Text, btnDay3.Font, Brushes.White, textRect, format)
            Else
                e.Graphics.DrawString(btnDay3.Text, btnDay3.Font, Brushes.Gray, textRect, format)
            End If
        End If
    End Sub
    Private Sub lBoxLiinid_Paint(sender As Object, e As PaintEventArgs) Handles lBoxLiinid.Paint
        ' Draw custom border
        Using pen As New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(pen, 0, 0, lBoxLiinid.Width - 1, lBoxLiinid.Height - 1)
        End Using
    End Sub

    Private Sub panelRtbAjad_Paint(sender As Object, e As PaintEventArgs) Handles panelRtbAjad.Paint
        ' Draw custom border
        Using pen As New Pen(Color.Black, 1)
            e.Graphics.DrawRectangle(pen, 0, 0, panelRtbAjad.Width - 1, panelRtbAjad.Height - 1)
        End Using
    End Sub

    Private Sub panelLboxRealtime_Paint(sender As Object, e As PaintEventArgs) Handles panelLboxRealtime.Paint
        ' Draw custom border
        Using pen As New Pen(Color.Black, 1)
            e.Graphics.DrawRectangle(pen, 0, 0, panelLboxRealtime.Width - 1, panelLboxRealtime.Height - 1)
        End Using
    End Sub

    Private Sub panelLBoxPeatused_Paint(sender As Object, e As PaintEventArgs) Handles panelLBoxPeatused.Paint
        ' Draw custom border
        Using pen As New Pen(Color.Black, 1)
            e.Graphics.DrawRectangle(pen, 0, 0, panelLBoxPeatused.Width - 1, panelLBoxPeatused.Height - 1)
        End Using
    End Sub

    Private Sub panelLBoxLiinid_Paint(sender As Object, e As PaintEventArgs) Handles panelLBoxLiinid.Paint
        ' Draw custom border
        Using pen As New Pen(Color.Black, 1)
            e.Graphics.DrawRectangle(pen, 0, 0, panelLBoxLiinid.Width - 1, panelLBoxLiinid.Height - 1)
        End Using
    End Sub

End Class