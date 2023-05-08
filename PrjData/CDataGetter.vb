Imports System.Data.SQLite
Imports System.Globalization
Imports System.IO
Imports System.Net
Public Class CDataGetter
    Implements IDataGetter

    Private SQLiteCon As SQLiteConnection
    Private SQLiteCmd As SQLiteCommand
    Private SQLiteReader As SQLiteDataReader
    Private desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
    Private dbFilePath As String = Path.Combine(desktopPath, "mapdb.db")

    Private Sub CloseConnections() Implements IDataGetter.CloseConnections
        Try
            SQLiteCon.Close()
        Catch
            Exit Sub
        End Try
    End Sub

    Private Sub MakeSqlConn() Implements IDataGetter.MakeSqlConn
        Try
            SQLiteCon = New SQLiteConnection($"Data Source={dbFilePath};Version=3;")
            SQLiteCon.Open()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Public Function MakeQuery(query As String) As SQLiteDataReader Implements IDataGetter.MakeQuery
        Try
            MakeSqlConn()
            SQLiteCmd = New SQLiteCommand(query, SQLiteCon)
            SQLiteReader = SQLiteCmd.ExecuteReader()
            Return SQLiteReader
        Catch ex As Exception
            MsgBox(ex)
            SQLiteCon.Close()
        End Try
        SQLiteCon.Close()
        Return Nothing
    End Function

End Class
