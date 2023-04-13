Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports System.IO
Imports System.Net
Imports System.Windows

Imports MySql.Data.MySqlClient
Imports System.Data.SQLite

Public Class Kaardirakendus
    Dim con As SQLiteConnection
    Dim cmd As SQLiteCommand


    Private Sub btnShowLines_Click(sender As Object, e As EventArgs) Handles btnShowLines.Click

        Try
            con = New SQLiteConnection("Data Source=C://Users//S11M//Desktop//sqliteDB//mapsdb.db;Version=3;")
            con.Open()
            cmd = New SQLiteCommand("SELECT Line FROM liinid", con)
            Dim reader As SQLiteDataReader = cmd.ExecuteReader()

            lBoxLiinid.Visible = True

            While reader.Read()
                Dim line As String = reader.GetString(0)
                lBoxLiinid.Items.Add(line)

            End While

        Catch ex As Exception
            MsgBox(ex)
        Finally
            con.Close()
        End Try
    End Sub

End Class