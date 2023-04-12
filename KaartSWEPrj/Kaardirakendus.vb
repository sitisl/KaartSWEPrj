Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports System.IO
Imports System.Net
Imports System.Windows

Imports MySql.Data.MySqlClient

Public Class Kaardirakendus
    Private Const CONN_STRING As String = "server=localhost;userid=root;password='1234';database=kaardidb"
    'Private Const CONN_STRING As String = "server=b4jkjdcm9aadnnrqpgms-mysql.services.clever-cloud.com;userid=utkgha0in26npszi;password='AnYMkrGnd7P3qce4HZz7';database=b4jkjdcm9aadnnrqpgms"
    Dim conn As MySqlConnection
    Dim Suund As String
    Dim LinkHalf As String
    Dim SelectedLine As String
    Dim SelectedStop As String
    Dim SelectedStopId As String

    'Algne versioon
    Private Sub LoadLines()
        conn = New MySqlConnection
        conn.ConnectionString = CONN_STRING

        Try
            conn.Open()
            Dim query As String = "select Line from liinid"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                lBoxLiinid.Items.Add(reader.GetString(0))
            End While
            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadLineStops(Suund As String)
        lBoxPeatused.Items.Clear()
        If lBoxPeatused.Visible = False Then
            lBoxPeatused.Visible = True
        End If
        Dim asi As String = SelectedLine
        conn = New MySqlConnection
        conn.ConnectionString = CONN_STRING

        Try
            conn.Open()
            Dim query As String = "select * from koikpeatused where liin = '" & asi & "' And suund ='" & Suund & "';"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                lBoxPeatused.Items.Add(reader.GetString(2))
            End While
            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub LoadLineSuund(Liin As String)
        btnAB.Visible = True
        btnBA.Visible = True

        btnAB.Text = Nothing
        btnBA.Text = Nothing

        conn = New MySqlConnection
        conn.ConnectionString = CONN_STRING

        Try
            conn.Open()
            Dim query As String = "select `a-b`,`b-a` from liinid where Line = '" & Liin & "';"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                btnAB.Text = reader.GetString(0)
                btnBA.Text = reader.GetString(1)
            End While
            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub LoadLineLink(Suund As String)
        conn = New MySqlConnection
        conn.ConnectionString = CONN_STRING
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
            conn.Open()
            Dim query As String = "select `" & SelectElement & "` from liinid Where line = '" & SelectedLine & "';"
            'MsgBox(query)
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                LinkHalf = reader.GetString(0)

            End While
            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub Kaardirakendus_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GMapControl1.MapProvider = GoogleMapProvider.Instance
        GMaps.Instance.Mode = AccessMode.ServerAndCache
        GMapControl1.ShowCenter = False

        GMapControl1.Position = New GMap.NET.PointLatLng(59.4380930599551, 24.7590637207031)
        GMapControl1.MinZoom = 5
        GMapControl1.MaxZoom = 100
        GMapControl1.Zoom = 10
    End Sub

    Private Sub GMapControl1_OnMapClick(sender As Object, e As MouseEventArgs) Handles GMapControl1.OnMapClick
        ' Get the latitude and longitude of the clicked point
        Dim lat As Double = GMapControl1.FromLocalToLatLng(e.X, e.Y).Lat
        Dim lng As Double = GMapControl1.FromLocalToLatLng(e.X, e.Y).Lng
        If (choose) Then
            btnChoose.Text = "Name"
            lblLongName.Text = "Longitude"
            lblLat.Visible = True
            txtLat.Visible = True
            choose = False
        End If
        txtLongName.Text = lng
        txtLat.Text = lat
    End Sub

    Dim choose As Boolean = True

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        If (choose) Then
            btnChoose.Text = "Name"
            lblLongName.Text = "Longitude"
            txtLongName.Text = ""
            lblLat.Visible = True
            txtLat.Visible = True
            choose = False
        Else
            btnChoose.Text = "Coordinates"
            lblLongName.Text = "Name"
            txtLongName.Text = ""
            txtLat.Text = ""
            lblLat.Visible = False
            txtLat.Visible = False
            choose = True
        End If
    End Sub

    Private lastMarker As GMapMarker

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        If (choose) Then

        Else
            ' Clear all markers from the map
            GMapControl1.Overlays.Clear()

            ' Get the longitude and latitude coordinates from the textboxes
            Dim longCoord As Double = CDbl(Val(txtLat.Text))
            Dim latCoord As Double = CDbl(Val(txtLongName.Text))

            ' Set the position of the map control to the specified coordinates
            GMapControl1.ShowCenter = False
            GMapControl1.Position = New GMap.NET.PointLatLng(longCoord, latCoord)

            ' Create a new marker and add it to the map
            Dim markers As GMapOverlay = New GMapOverlay("polygons")
            Dim marker As GMapMarker = New GMarkerGoogle(GMapControl1.Position, GMarkerGoogleType.blue_dot)
            markers.Markers.Add(marker)
            GMapControl1.Overlays.Add(markers)

            ' Set some zoom properties and tooltip mode for the marker
            GMapControl1.MinZoom = 5
            GMapControl1.MaxZoom = 100
            GMapControl1.Zoom = 14
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
        End If
    End Sub

    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        ' Clear all markers from the map
        GMapControl1.Overlays.Clear()

        ' Download the stops.txt file
        Dim client As WebClient = New WebClient()
        Dim data As Stream = client.OpenRead("https://transport.tallinn.ee/data/stops.txt")
        Dim reader As New StreamReader(data)
        Dim line As String
        Dim fields As String()
        Dim lat As Double
        Dim lng As Double

        GMapControl1.ShowCenter = False
        Dim markers As GMapOverlay = New GMapOverlay("markers")
        While Not reader.EndOfStream
            line = reader.ReadLine()
            fields = line.Split(";")
            If fields.Length >= 4 AndAlso Integer.TryParse(fields(2), Nothing) AndAlso Integer.TryParse(fields(3), Nothing) Then
                lat = CDbl(fields(2)) / 100000
                lng = CDbl(fields(3)) / 100000
                Dim busStop As PointLatLng = New GMap.NET.PointLatLng(lat, lng)
                Dim marker As GMapMarker = New GMarkerGoogle(busStop, GMarkerGoogleType.red_small)
                markers.Markers.Add(marker)
                'Console.WriteLine("Bus Stop at Latitude: " & busStop.Lat.ToString() & ", Longitude: " & busStop.Lng.ToString())
            End If
        End While

        ' Add the markers overlay to the map
        GMapControl1.Overlays.Add(markers)
        GMapControl1.Refresh()
    End Sub

    Private Sub btnShowLines_Click(sender As Object, e As EventArgs) Handles btnShowLines.Click
        If lBoxPeatused.Visible = True Then
            Exit Sub
        End If
        lBoxLiinid.Visible = True
        LoadLines()
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
        SelectedLine = lBoxLiinid.SelectedItem
        LoadLineSuund(SelectedLine)
    End Sub

    Private Function lBoxPeatused_SelectedValueChanged(sender As Object, e As EventArgs) Handles lBoxPeatused.SelectedIndexChanged
        SelectedStop = lBoxPeatused.SelectedItem
        'MsgBox(SelectedLine & " " & SelectedStop & " " & Suund & " " & LinkHalf)
        conn = New MySqlConnection
        conn.ConnectionString = CONN_STRING
        Dim PeatuseID As String = Nothing

        Try
            conn.Open()
            Dim query As String = "select PeatuseID from koikpeatused where PeatuseNimi = '" & SelectedStop & "' And Liin ='" & SelectedLine & "';"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                PeatuseID = reader.GetString(0)
            End While
            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        Dim LinkFull As String = LinkHalf & "/" & PeatuseID
        tBoxLink.Visible = True
        tBoxLink.Text = LinkFull
        Return LinkFull
    End Function

End Class