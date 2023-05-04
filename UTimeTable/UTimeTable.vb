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

    Private Structure TimeStruct
        Dim Name As String
        Dim Time As String
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

            If driver IsNot Nothing Then
                driver.Quit()
            End If
        Catch ex As Exception
            ' Handle exception here
        End Try
    End Sub

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

        Dim tripID As Integer
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
        Try
            MakeSqlConn()
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()
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
            SQLiteReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If closestTime IsNot Nothing Then
            'MsgBox("Next closest arrival time is: " & closestTime & " " & tripID)
        Else
            MsgBox("There are no more arrivals today.")
        End If
        Return tripID
    End Function

    Private Sub LoadLines()
        Dim query As String
        If (Suund Is Nothing) Then
            query = "Select Distinct Liin From koikpeatused where PeatuseID In (Select Distinct PeatuseID from koikpeatused where PeatuseNimi = '" & SelectedStop & "');"
            lBoxLiinid.Visible = True
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
        If allStopsQuery Is Nothing Then
            query = "select Distinct PeatuseNimi from koikpeatused where Liin = '" & SelectedLine & "' And Suund ='" & Suund & "';"
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

    Private Sub LoadLineSuund(Liin As String)
        btnAB.Text = Nothing
        btnBA.Text = Nothing

        Try
            Dim query As String = "select `a-b`,`b-a` from liinid where Line = '" & Liin & "';"
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()

            While SQLiteReader.Read()
                btnAB.Text = SQLiteReader.GetString(0)
                btnBA.Text = SQLiteReader.GetString(1)
            End While
            SQLiteReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub LoadLineLink(Suund As String)

        Dim SelectElement As String
        If Suund = "a-b" Then
            SelectElement = "link_a-b"
        ElseIf Suund = "b-a" Then
            SelectElement = "link_b-a"
        Else
            SelectElement = Nothing
            Exit Sub
        End If
        Try

            Dim query As String = "select `" & SelectElement & "` from liinid Where line = '" & SelectedLine & "';"
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()

            While SQLiteReader.Read()
                LinkHalf = SQLiteReader.GetString(0)

            End While
            SQLiteReader.Close()

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
    End Sub

    Private Sub lBoxPeatused_SelectedValueChanged(sender As Object, e As EventArgs) Handles lBoxPeatused.SelectedIndexChanged
        SelectedStop = lBoxPeatused.SelectedItem

        Dim PeatuseID As String = Nothing

        If Suund = Nothing Then
            lBoxLiinid.Visible = True
            lblLiinid.Visible = True
            lBoxLiinid.Items.Clear()
            LoadLines()
        Else
            Try
                Dim query As String = "select PeatuseID from koikpeatused where PeatuseNimi = '" & SelectedStop & "' And Suund ='" & Suund & "' And Liin ='" & SelectedLine & "';"
                SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
                SQLiteReader = SQLiteCmd.ExecuteReader()
                While SQLiteReader.Read()
                    PeatuseID = SQLiteReader.GetString(0)
                End While
                SQLiteReader.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                SQLiteCon.Close()
            End Try
            LinkFull = LinkHalf & "/" & PeatuseID
            GetStopTimes()
        End If
    End Sub


    Private Sub InitChromeDriver()
        options = New OpenQA.Selenium.Chrome.ChromeOptions()
        options.AddArguments("headless", "disable-logging", "disable-extensions")
        Dim driverService As ChromeDriverService = ChromeDriverService.CreateDefaultService()
        driverService.HideCommandPromptWindow = True
        driver = New OpenQA.Selenium.Chrome.ChromeDriver(driverService, options)
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(250)
    End Sub
    Private Sub GetStopTimes()
        Dim InvaColor As Color = Color.DeepSkyBlue
        lblAbi.ForeColor = InvaColor
        lblAbi.Font = New Font(lblAbi.Font, FontStyle.Underline)
        rtbAjad.Clear()

        InitChromeDriver()
        driver.Navigate().GoToUrl(LinkFull)

        Dim timeTable As ReadOnlyCollection(Of IWebElement)
        timeTable = driver.FindElements(By.XPath("//*[@id='divScheduleContentInner']/table[1]/tbody/tr"))

        Dim isFirstIteration As Boolean = True
        For Each time As IWebElement In timeTable
            If isFirstIteration Then
                isFirstIteration = False
                Continue For
            End If

            Dim hourEl As IWebElement = time.FindElement(By.XPath("./th"))
            Dim hourVal As String = hourEl.Text
            hourVal = hourVal.PadRight(3)
            Dim minuteElements As ReadOnlyCollection(Of IWebElement) = time.FindElements(By.XPath("./td/a"))
            Dim minuteValues As String = ""
            rtbAjad.SelectionColor = Color.Black
            rtbAjad.AppendText(hourVal & ": ")
            For Each minuteElement As IWebElement In minuteElements
                Dim color As Color
                If minuteElement.GetAttribute("class") = "highlighted" Or minuteElement.GetAttribute("class") = "other1 highlighted" Then
                    color = InvaColor
                    rtbAjad.SelectionFont = New Font(rtbAjad.Font, FontStyle.Underline)
                Else
                    color = color.Black
                    rtbAjad.SelectionFont = New Font(rtbAjad.Font, FontStyle.Regular)
                End If

                rtbAjad.SelectionColor = color
                rtbAjad.AppendText(minuteElement.Text)
                rtbAjad.SelectionColor = color.Black
                rtbAjad.SelectionFont = New Font(rtbAjad.Font, FontStyle.Regular)
                rtbAjad.AppendText(" ")
            Next
            rtbAjad.SelectionColor = Color.Black
            rtbAjad.AppendText(Environment.NewLine)
        Next

        GetStopTimesRealTime()
        driver.Quit()
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
        Suund = ""
        LoadLines()
    End Sub

    Private Sub btnShowStops_Click(sender As Object, e As EventArgs) Handles btnShowStops.Click
        lBoxLiinid.Items.Clear()
        LoadLineStops(Suund, "select Distinct PeatuseNimi from koikpeatused Order by PeatuseNimi ASC;")
    End Sub

    Private Sub btnAB_Click(sender As Object, e As EventArgs) Handles btnAB.Click
        Suund = "a-b"
        LoadLineLink(Suund)
        LoadLineStops(Suund)
    End Sub

    Private Sub btnBA_Click(sender As Object, e As EventArgs) Handles btnBA.Click
        Suund = "b-a"
        LoadLineLink(Suund)
        LoadLineStops(Suund)
    End Sub

    Private Sub lBoxLiinid_SelectedValueChanged(sender As Object, e As EventArgs) Handles lBoxLiinid.SelectedValueChanged
        lBoxPeatused.Items.Clear()
        SelectedLine = lBoxLiinid.SelectedItem
        LoadLineSuund(SelectedLine)
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
        btnAB.Visible = True
        btnBA.Visible = True
    End Sub


End Class
