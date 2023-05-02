Imports System.Collections.ObjectModel
Imports System.Data.Entity.Core
Imports System.Data.SQLite
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Reflection.Emit
Imports System.Text
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class UTimeTable

    Dim SQLiteCon As SQLiteConnection
    Dim SQLiteCmd As SQLiteCommand
    Dim SQLiteReader As SQLiteDataReader
    Public Suund As String = Nothing
    Public SelectedLine As String = Nothing
    Public SelectedStop As String = Nothing
    Public SelectedDay As String = "monday"
    Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
    Dim dbFilePath As String = Path.Combine(desktopPath, "mapdb.db")

    Public Structure StopStruct
        Public Name As String
        Public Latitude As Double
        Public Longitude As Double
    End Structure

    Public Function GetStopsCoordinates() As List(Of StopStruct)
        Dim query As String = "SELECT name, lat, lon FROM stops;"
        Dim stops As New List(Of StopStruct)

        Try
            MakeSqlConn()
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()

            While SQLiteReader.Read()
                Dim s As New StopStruct
                s.Name = SQLiteReader.GetString(0)
                s.Latitude = SQLiteReader.GetDouble(1)
                s.Longitude = SQLiteReader.GetDouble(2)
                stops.Add(s)
            End While

            SQLiteReader.Close()
            SQLiteCon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return stops
    End Function
    Public Sub MakeSqlConn()
        Try
            SQLiteCon = New SQLiteConnection($"Data Source={dbFilePath};Version=3;")
            SQLiteCon.Open()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Public Sub CloseConnections()
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

        Try
            lBoxLiinid.Items.Clear()
            MakeSqlConn()
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()
            While SQLiteReader.Read()
                lBoxLiinid.Items.Add(SQLiteReader.GetString(0))
            End While
            SQLiteReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            SQLiteCon.Close()
        End Try
    End Sub

    Private Sub LoadLineStops()
        Dim query As String
        If String.IsNullOrEmpty(lBoxLiinid.Text) Then
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

        Try
            lBoxPeatused.Items.Clear()
            MakeSqlConn()
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()
            While SQLiteReader.Read()
                lBoxPeatused.Items.Add(SQLiteReader.GetString(0))
            End While
            SQLiteReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetCurrentTimeTripID()
        Dim tempStop As String = lBoxPeatused.Items(0)
        'MsgBox(tempStop)
        Dim time As DateTime = DateTime.Now
        Dim tripID As Integer
        MsgBox(time.Hour & ":" & time.Minute)
        Label1.Text = SelectedLine
        Label2.Text = Suund

        Dim hourMin As Integer
        Dim hourMax As Integer
        Dim minuteMax As Integer
        Dim minuteMin As Integer
        Dim firstIteration As Boolean = True

        Dim query = "SELECT stoptimes.arrival_time
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
        Try
            MakeSqlConn()
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()

            Dim currentHour As Integer = -1 ' initialize current hour to -1
            While SQLiteReader.Read()
                rtbAjad.SelectionColor = Color.Black
                Dim arrivalTime As String = SQLiteReader.GetString(0)
                Dim hour As Integer = Integer.Parse(arrivalTime.Substring(0, 2))


                If hour >= 24 Then
                    hour = hour - 24
                End If
                Dim minute As Integer = Integer.Parse(arrivalTime.Substring(3, 2))

                If firstIteration = True Then
                    hourMin = hour
                    hourMax = hour
                    minuteMax = minute
                    minuteMin = minute
                    firstIteration = False
                Else
                    If hourMax < hour Then
                        hourMax = hour
                    End If
                    If hourMin > hour Then
                        hourMin = hour
                    End If
                End If

                If 19 = hour And 25 < minute Then
                    MsgBox(hour & minute)
                End If

                'If time.Hour < hourMax And time.Hour < hourMin Then
                '    MsgBox("Jargmine aeg alles homme")
                'End If

                If currentHour <> hour Then ' new hour, add hour header
                    If currentHour >= 0 Then ' not the first hour, add newline

                    End If

                    currentHour = hour
                End If

            End While
            SQLiteReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'MsgBox(hourMax & " " & minuteMax & " " & hourMin & " " & minuteMin)
        Return tripID
    End Function

    Private Sub LoadLineSuund()
        Try
            Dim query = "SELECT trips.trip_long_name FROM trips
             JOIN routes ON trips.route_id = routes.route_id
             WHERE routes.route_short_name = '" & SelectedLine & "'
             AND trips.direction_code = ""A>B""
             GROUP BY trips.trip_long_name;"
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()
            SQLiteReader.Read()
            btnAB.Text = SQLiteReader.GetString(0)
            SQLiteReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            SQLiteCon.Close()
        End Try

        Try
            Dim query = "SELECT trips.trip_long_name FROM trips
             JOIN routes ON trips.route_id = routes.route_id
             WHERE routes.route_short_name = '" & SelectedLine & "'
             AND trips.direction_code = ""B>A""
             GROUP BY trips.trip_long_name;"
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()
            SQLiteReader.Read()
            btnBA.Text = SQLiteReader.GetString(0)
            SQLiteReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            SQLiteCon.Close()
        End Try

    End Sub


    Private Sub LoadShapes()
        Try
            Dim routePoints As New List(Of StopStruct)
            Dim query = "SELECT shape_pt_lat, shape_pt_lon FROM shapes
             JOIN trips ON shapes.shape_id = trips.shape_id
             JOIN routes ON trips.route_id = routes.route_id
             WHERE routes.route_short_name = '" & SelectedLine & "'
             AND trips.direction_code = '" & Suund & "';"
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()
            SQLiteReader.Read()
            While SQLiteReader.Read()
                Dim point As New StopStruct
                point.Latitude = SQLiteReader.GetDouble(2)
                point.Longitude = SQLiteReader.GetDouble(2)
                routePoints.Add(point)
            End While
            SQLiteReader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            SQLiteCon.Close()
        End Try

    End Sub

    Private Sub GetStopTimesRealTime()

        lBoxRealTime.Items.Clear()
        Dim url As String = "https://transport.tallinn.ee/siri-stop-departures.php?stopid="
        Dim SelectedStopID As Integer
        Try
            Dim query = "SELECT stops.stop_id FROM stops
             JOIN stoptimes ON stops.stop_id = stoptimes.stop_id
             JOIN trips ON stoptimes.trip_id = trips.trip_id
             JOIN routes ON trips.route_id = routes.route_id
             WHERE routes.route_short_name = '" & SelectedLine & "'
             AND stops.name = '" & SelectedStop & "'
             AND trips.direction_code = '" & Suund & "';"
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()
            SQLiteReader.Read()
            SelectedStopID = SQLiteReader.GetInt32(0)
            url &= SelectedStopID.ToString()
            SQLiteReader.Close()
            Dim parts As String() = SelectedLine.Split(" "c)
            Dim transport As String = parts(0).ToLower()
            transport = transport.Substring(0, 3)
            Dim number As String = parts(parts.Length - 1)
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
            SQLiteCon.Close()
        End Try

    End Sub

    Private Sub btnShowLines_Click(sender As Object, e As EventArgs) Handles btnShowLines.Click
        lBoxLiinid.Items.Clear()
        lBoxPeatused.Items.Clear()
        lBoxRealTime.Items.Clear()
        rtbAjad.Clear()
        btnAB.Text = Nothing
        btnBA.Text = Nothing
        LoadLines()
    End Sub

    Private Sub btnShowStops_Click(sender As Object, e As EventArgs) Handles btnShowStops.Click
        lBoxLiinid.Items.Clear()
        lBoxPeatused.Items.Clear()
        lBoxRealTime.Items.Clear()
        rtbAjad.Clear()
        btnAB.Text = Nothing
        btnBA.Text = Nothing
        LoadLineStops()
    End Sub

    Private Sub btnAB_Click(sender As Object, e As EventArgs) Handles btnAB.Click
        If String.IsNullOrEmpty(lBoxLiinid.Text) And String.IsNullOrEmpty(lBoxPeatused.Text) Then
            Return
        End If
        rtbAjad.Clear()
        lBoxRealTime.Items.Clear()
        Suund = "A>B"
        LoadLineStops()
        'LoadShapes()
    End Sub

    Private Sub btnBA_Click(sender As Object, e As EventArgs) Handles btnBA.Click
        If String.IsNullOrEmpty(lBoxLiinid.Text) And String.IsNullOrEmpty(lBoxPeatused.Text) Then
            Return
        End If
        rtbAjad.Clear()
        lBoxRealTime.Items.Clear()
        Suund = "B>A"
        LoadLineStops()
        'LoadShapes()
    End Sub

    Private Sub lBoxLiinid_SelectedValueChanged(sender As Object, e As EventArgs) Handles lBoxLiinid.SelectedValueChanged
        lBoxPeatused.Items.Clear()
        lBoxRealTime.Items.Clear()
        rtbAjad.Clear()
        SelectedLine = lBoxLiinid.SelectedItem
        LoadLineSuund()
    End Sub

    Private Sub lBoxPeatused_SelectedValueChanged(sender As Object, e As EventArgs) Handles lBoxPeatused.SelectedIndexChanged
        SelectedStop = lBoxPeatused.SelectedItem
        rtbAjad.Clear()
        lBoxRealTime.Items.Clear()

        If String.IsNullOrEmpty(lBoxLiinid.Text) Then
            LoadLines()
        Else
            GetStopTimes()
            GetStopTimesRealTime()
        End If
    End Sub

    Private Sub GetStopTimes()
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

        Try
            MakeSqlConn()
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()
            Dim currentHour As Integer = -1 ' initialize current hour to -1
            While SQLiteReader.Read()
                rtbAjad.SelectionColor = Color.Black
                Dim arrivalTime As String = SQLiteReader.GetString(0)
                Dim hour As Integer = Integer.Parse(arrivalTime.Substring(0, 2))
                If hour >= 24 Then
                    hour = hour - 24
                End If
                Dim minute As Integer = Integer.Parse(arrivalTime.Substring(3, 2))
                Dim wheelchairAccessible As Boolean = (SQLiteReader.GetString(1) = "1")
                If currentHour <> hour Then ' new hour, add hour header
                    If currentHour >= 0 Then ' not the first hour, add newline
                        rtbAjad.AppendText(Environment.NewLine)
                    End If
                    rtbAjad.AppendText(hour) ' add hour header
                    rtbAjad.AppendText(": ") ' add space separator between minutes
                    currentHour = hour
                End If
                If wheelchairAccessible Then
                    rtbAjad.SelectionColor = InvaColor
                End If
                rtbAjad.AppendText(minute) ' append minute string
                rtbAjad.AppendText(" ") ' add space separator between minutes
            End While
            SQLiteReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDay1_Click(sender As Object, e As EventArgs) Handles btnDay1.Click
        SelectedDay = "monday"
        btnDay1.Font = New Font(btnDay1.Font, FontStyle.Bold)
        btnDay2.Font = New Font(btnDay2.Font, FontStyle.Regular)
        btnDay3.Font = New Font(btnDay3.Font, FontStyle.Regular)
        GetStopTimes()
    End Sub

    Private Sub btnDay2_Click(sender As Object, e As EventArgs) Handles btnDay2.Click
        SelectedDay = "saturday"
        btnDay1.Font = New Font(btnDay1.Font, FontStyle.Regular)
        btnDay2.Font = New Font(btnDay2.Font, FontStyle.Bold)
        btnDay3.Font = New Font(btnDay3.Font, FontStyle.Regular)
        GetStopTimes()
    End Sub

    Private Sub btnDay3_Click(sender As Object, e As EventArgs) Handles btnDay3.Click
        SelectedDay = "sunday"
        btnDay1.Font = New Font(btnDay1.Font, FontStyle.Regular)
        btnDay2.Font = New Font(btnDay2.Font, FontStyle.Regular)
        btnDay3.Font = New Font(btnDay3.Font, FontStyle.Bold)
        GetStopTimes()
    End Sub

    Private Sub UTimeTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnDay1.Font = New Font(btnDay1.Font, FontStyle.Bold)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetCurrentTimeTripID()
    End Sub
End Class
