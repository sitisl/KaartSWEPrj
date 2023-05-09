Imports System.Data.SQLite
Imports System.IO

Public Class CDataGetter
    Implements IDataGetter

    Private SQLiteCon As SQLiteConnection
    Private SQLiteCmd As SQLiteCommand
    Private SQLiteReader As SQLiteDataReader
    Dim dbFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mapdb.db")

    Private Sub CloseConnections() Implements IDataGetter.CloseConnections
        Try
            SQLiteCon.Close()
        Catch ex As Exception
            MsgBox(ex)
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
