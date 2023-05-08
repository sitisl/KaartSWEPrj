Public Interface IRouteInfo
    Structure RouteInfo
        Public Steps As List(Of StepInfo)
        Public StartTime As String
        Public EndTime As String
        Public Duration As Integer
    End Structure
    Structure StepInfo
        Public Time As Integer
        Public IconPath As String
        Public LineNr As String
    End Structure

    Sub DisplayInfo(route As RouteInfo)
    Sub ClearBrowser()

End Interface
