Imports System.Security.Policy
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify

Public Class URouteInfo

    Public Structure RouteInfo
        Public Steps As List(Of StepInfo)
        Public StartTime As String
        Public EndTime As String
        Public Duration As Integer
        Public Sub Reset()
            Steps = Nothing
            StartTime = ""
            EndTime = ""
            Duration = 0
        End Sub
    End Structure
    Public Structure StepInfo
        Public Time As Integer
        Public IconPath As String
        Public LineNr As String
        Public Sub Reset()
            Time = 0
            IconPath = ""
            LineNr = ""
        End Sub
    End Structure


    Public Sub DisplayInfo(route As RouteInfo)
        Dim transitIconPath As String = IO.Path.Combine(IO.Path.GetTempPath(), Guid.NewGuid().ToString() + "_bus_route.png")
        My.Resources.bus_route.Save(transitIconPath, Imaging.ImageFormat.Png)
        Dim busIconPath As String = IO.Path.Combine(IO.Path.GetTempPath(), Guid.NewGuid().ToString() + "_bus_icon.png")
        My.Resources.bus_icon.Save(busIconPath, Imaging.ImageFormat.Png)
        Dim walkIconPath As String = IO.Path.Combine(IO.Path.GetTempPath(), Guid.NewGuid().ToString() + "_walk_icon.png")
        My.Resources.walk_icon.Save(walkIconPath, Imaging.ImageFormat.Png)
        'Dim tramIconPath As String = IO.Path.Combine(IO.Path.GetTempPath(), "tram_icon.png")
        'My.Resources.tram_icon.Save(tramIconPath, Imaging.ImageFormat.Png)
        'Dim trollIconPath As String = IO.Path.Combine(IO.Path.GetTempPath(), "troll_icon.png")
        'My.Resources.troll_icon.Save(trollIconPath, Imaging.ImageFormat.Png)
        ' Create the HTML table content as a string
        Dim stepsHtml As String = ""
        Dim table As String = "<table>" &
    "<tbody>" &
        "<tr>" &
            "<td rowspan='4' valign='middle'><div class='bus-icon'><img src='" & transitIconPath & "' width='50' height='50'/></div></td>" &
            "<td colspan='3' style='font-size: 20px; font-weight: bold;'>" & route.StartTime & " - " & route.EndTime & "</td>" &
            "<td rowspan='3' class='duration-cell' style='text-align:center; vertical-align:middle; '>" &
                "<table><tbody><tr></tr><tr><td><div class='duration-number'>" & route.Duration & "</div><div class='duration-text'>min</div></td></tr><tr></tr></tbody></table>" &
            "</td>" &
        "</tr>" &
        "<tr>" &
        "</tr>" &
        "<tr>" &
        "<td>" &
        "<table>"

        ' Add each step to a new column
        For Each item As StepInfo In route.Steps
            Dim iconPath As String = If(item.IconPath = "Bus", busIconPath, walkIconPath)
            Dim iconSize As Integer = If(item.IconPath = "Bus", 25, 25)
            table &= "<td>" &
                "<table>" &
                "<tbody>" &
                "<tr>" &
                "<td><div class='transit-icon'" & item.IconPath & "-icon'><img src='" & iconPath & "' width='" & iconSize & "' height='" & iconSize & "'/>" & item.LineNr & "</div></td>" &
                "</tr>" &
                "<tr>" &
                "<td>" & item.Time & "&nbsp;min</td>" &
                "</tr>" &
                "</tbody>" &
                "</table>" &
                "</td>"
        Next
        Dim css As String = "<style>" &
            "body {" &
                "user-select: none;" &
                "-webkit-user-select: none;" &
                "-moz-user-select: none;" &
                "-ms-user-select: none;" &
                "user-interaction: none;" &
                "background-color :  #212121;" &
                "padding: 0;" &
                "margin: 0;" &
            "}" &
            "table {" &
                "border-collapse: collapse;" &
                "width: 100%;" &
                "height: 100%;" &
                "box-sizing: border-box;" &
                "font-family: Segoe UI, sans-serif;" &
                "font-size: 14px;" &
                "color: white;" &
            "}" &
            "th, td {" &
                "border: none;" &
                "text-align: center;" &
                "padding: 0px;" &
            "}" &
            "th {" &
                "background-color: #f2f2f2;" &
                "font-weight: normal;" &
            "}" &
            ".bus-icon {" &
                "width: auto;" &
                "height: auto;" &
                "border: none;" &
                "display: flex;" &
                "align-items: center;" &
        "}" &
        ".duration-cell {" &
        "padding: 0;" &
        "vertical-align: middle;" &
        "}" &
        ".duration-number {" &
        "font-size: 30px;" &
        "font-weight: bold;" &
        "}" &
        ".duration-text {" &
        "font-size: 14px;" &
        "text-align: center;" &
        "}" &
        ".transit-icon {" &
        "width: auto;" &
        "height: auto;" &
        "display: flex;" &
        "align-items: center;" &
        "}" &
        ".bus-icon img {" &
        "margin: auto;" &
        "}" &
        ".walk-icon img {" &
        "margin: auto;" &
        "}" &
        ".transit-icon img {" &
        "margin: auto;" &
        "}" &
        "</style>"
        ' Complete the HTML table content string
        table &= "</tr></tbody></table>"
        stepsHtml &= table & "</td></tr></tbody></table>"

        ' Combine all the HTML content and display it in a web browser control
        Dim html As String = "<html><head>" & css & "</head><body>" & stepsHtml & "</body></html>"
        wBrowserInfo.DocumentText = html
        'wBrowserInfo.Refresh()
    End Sub

    Public Sub ClearBrowser()
        wBrowserInfo.Refresh()
    End Sub
    Private Sub URouteInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class
