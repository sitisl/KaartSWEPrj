Imports System.IO
Imports RouteInfo = PrjTransitRouteInfo.IRouteInfo.RouteInfo
Imports StepInfo = PrjTransitRouteInfo.IRouteInfo.StepInfo

Public Class URouteInfo
    Implements IRouteInfo

    Private tempFile As String

    Public Sub DisplayInfo(route As RouteInfo) Implements IRouteInfo.DisplayInfo
        ' wBrowserInfo.Navigate("about:blank")
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
            "<td rowspan='3' valign='middle'><div class='bus-icon'><img src='" & transitIconPath & "' width='50' height='50'/></div></td>" &
            "<td colspan='3' style='vertical-align:bottom; font-size: 24px; font-weight: 600;'>" & route.StartTime & " - " & route.EndTime & "</td>" &
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
            Dim lineNr As String = If(item.LineNr IsNot "", "<div class='line-number'>" & item.LineNr & "</div>",
            item.LineNr)
            table &= "<td>" &
                "<table>" &
                "<tbody>" &
                "<tr style='height: 44px;'>" &
                "<td style='vertical-align: middle;'>" & lineNr & "<div class='transit-icon'" & item.IconPath & "-icon'><img src='" & iconPath & "' width='" & iconSize & "' height='" & iconSize & "'/></div></td>" &
                "</tr>" &
                "<tr style='height:20px'>" &
                "<td style='vertical-align: top'>" & item.Time & "&nbsp;min</td>" &
                "</tr>" &
                "</tbody>" &
                "</table>" &
                "</td>"
        Next
        Dim css As String = "<style>" &
            "body {" &
                "background-color :  #212121;" &
                "padding: 2px;" &
                "margin: 0;" &
            "}" &
            "table {" &
                "border-collapse: separate !important;" &
                "overflow: hidden;" &
                "width: 100%;" &
                "height: 100%;" &
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
                "background-color: #212121;" &
                "font-weight: normal;" &
            "}" &
            ".bus-icon {" &
                "width: auto;" &
                "height: auto;" &
                "border: none;" &
                "display: inline-block" &
                "align-items: center;" &
        "}" &
        ".duration-cell {" &
        "padding: 0;" &
        "vertical-align: middle;" &
        "}" &
        ".duration-number {" &
        "font-size: 30px;" &
        "font-weight: 600;" &
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
        ".line-number {" &
        "background-color: #0062FF;" &
        "border-radius: 10px;" &
        "width: 25px;" &
        "font-weight: 600;" &
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
        ' Navigate to a blank page to clear any previous content
        tempFile = Path.GetTempFileName() & ".html"
        File.WriteAllText(tempFile, html)
        wBrowserInfo.Navigate(tempFile)
    End Sub

    Public Sub ClearBrowser() Implements IRouteInfo.ClearBrowser
        wBrowserInfo.Navigate("about:blank")
        If File.Exists(tempFile) Then
            File.Delete(tempFile)
        End If
    End Sub

End Class
