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
            Dim dbFilePath As String = Path.Combine(Application.StartupPath, "mapsdb.db")
            If File.Exists(dbFilePath) Then
                con = New SQLiteConnection($"Data Source={dbFilePath};Version=3;")
            Else
                Dim dbStream As Stream = New MemoryStream(My.Resources.mapsdb)
                Using fileStream As FileStream = File.Create(dbFilePath)
                    dbStream.CopyTo(fileStream)
                End Using
                con = New SQLiteConnection($"Data Source={dbFilePath};Version=3;")
            End If

            con.Open()
            cmd = New SQLiteCommand("SELECT Line FROM liinid", con)
            Dim reader As SQLiteDataReader = cmd.ExecuteReader()

            lBoxLiinid.Visible = True

            While reader.Read()
                Dim line As String = reader.GetString(0)
                lBoxLiinid.Items.Add(line)

            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

End Class