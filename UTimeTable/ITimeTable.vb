Public Interface ITimeTable
    Structure StopStruct
        Public Name As String
        Public ID As Integer
        Public Latitude As Double
        Public Longitude As Double
    End Structure
    Structure TransportStruct
        Public Number As String
        Public Latitude As Double
        Public Longitude As Double
    End Structure
    Function GetStopsCoordinates() As List(Of StopStruct)
    Function GetRealTimeTransport(type As String) As List(Of TransportStruct)
End Interface
