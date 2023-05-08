Imports System.Data.SQLite
Public Interface IDataGetter
    Sub MakeSqlConn()
    Sub CloseConnections()
    Function MakeQuery(query As String) As SQLiteDataReader

End Interface