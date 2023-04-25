﻿Imports System.Collections.ObjectModel
Imports System.Data.SQLite
Imports System.IO
Imports System.Reflection.Emit
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class UTimeTable
    Dim options As OpenQA.Selenium.Chrome.ChromeOptions
    Dim driver As OpenQA.Selenium.Chrome.ChromeDriver

    Dim SQLiteCon As SQLiteConnection
    Dim SQLiteCmd As SQLiteCommand
    Dim SQLiteReader As SQLiteDataReader

    Public Suund As String = Nothing
    Private LinkHalf As String = Nothing
    Public LinkFull As String = Nothing
    Public SelectedLine As String = Nothing
    Public SelectedStop As String = Nothing
    Public SelectedStopId As String = Nothing
    Dim dbFilePath As String = Path.Combine(Application.StartupPath, "mapdb.db")

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
            driver.Quit()
        Catch
            Exit Sub
        End Try
    End Sub

    Private Sub LoadLines()
        Dim query As String
        If (Suund Is Nothing) Then
            query = "Select Distinct Liin From koikpeatused where PeatuseID In (Select Distinct PeatuseID from koikpeatused where PeatuseNimi = '" & SelectedStop & "');"
            lBoxLiinid.Visible = True
        Else
            query = "Select Line FROM liinid;"
        End If

        Try
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

    Private Sub LoadLineStops(Suund As String, Optional allStopsQuery As String = Nothing)
        lBoxPeatused.Items.Clear()
        If lBoxPeatused.Visible = False Then
            lBoxPeatused.Visible = True
        End If
        MakeSqlConn()
        Dim query As String
        If allStopsQuery Is Nothing Then
            query = "select Distinct PeatuseNimi from koikpeatused where Liin = '" & SelectedLine & "' And Suund ='" & Suund & "';"
        Else
            query = allStopsQuery
        End If

        Try
            'MsgBox(query)
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
        btnAB.Visible = True
        btnBA.Visible = True

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
            SQLiteCon.Close()
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
            tBoxLink.Visible = True
            tBoxLink.Text = LinkFull
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
        lblAbi.Visible = True
        lblAjad.Visible = True
        rtbAjad.Visible = True
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
                    color = Color.Black
                    rtbAjad.SelectionFont = New Font(rtbAjad.Font, FontStyle.Regular)
                End If

                rtbAjad.SelectionColor = color
                rtbAjad.AppendText(minuteElement.Text)
                rtbAjad.SelectionColor = Color.Black
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
        lBoxRealTime.Visible = True
        lblReaalajad.Visible = True
        lBoxRealTime.Items.Clear()
        'Dim wait As New WebDriverWait(driver, TimeSpan.FromSeconds(2))
        'Dim liElements = wait.Until(Function(driver) driver.FindElements(By.XPath("//*[@id='divScheduleContent']/div[1]/div[4]/ul/li")))
        Dim liElements As ReadOnlyCollection(Of IWebElement) = driver.FindElements(By.XPath("//*[@id='divScheduleContent']/div[1]/div[4]/ul/li"))

        For Each li In liElements
            Try
                Dim strong As IWebElement = li.FindElement(By.XPath("./a/strong"))
                lBoxRealTime.Items.Add(strong.Text)
            Catch
                lBoxRealTime.Items.Add("Reaalaja")
                lBoxRealTime.Items.Add("väljumised")
                lBoxRealTime.Items.Add("puuduvad")
                Exit Sub
            End Try
        Next
    End Sub
    ' -----------------------------BUTTONS EVENTS--------------------------------------------
    Private Sub btnShowLines_Click(sender As Object, e As EventArgs) Handles btnShowLines.Click
        lBoxLiinid.Items.Clear()
        lBoxLiinid.Visible = True
        lblLiinid.Visible = True
        'btnShowStops.Visible = False
        Suund = ""
        LoadLines()
    End Sub

    Private Sub btnShowStops_Click(sender As Object, e As EventArgs) Handles btnShowStops.Click
        Suund = Nothing
        lBoxPeatused.Visible = True
        lblPeatused.Visible = True
        'btnShowLines.Visible = False
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

End Class