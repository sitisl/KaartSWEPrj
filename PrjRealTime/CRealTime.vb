Imports System.Globalization
Imports System.IO
Imports System.Net

Public Class CRealTime

    Public Structure TransportStruct
        Public Number As String
        Public Latitude As Double
        Public Longitude As Double
    End Structure

    Public Function GetRealTimeTransport(type As String) As List(Of TransportStruct)

        Dim transport As New List(Of TransportStruct)
        Dim url As String = "https://transport.tallinn.ee/gps.txt"

        Try
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "GET"
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            Using reader As New StreamReader(response.GetResponseStream())
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim fields As String() = line.Split(",")
                    If fields.Length >= 8 Then
                        Dim t As New TransportStruct
                        Select Case type
                            Case "bus"
                                If fields(0) = 2 Then
                                    t.Number = fields(1)
                                    t.Latitude = Double.Parse(fields(3), CultureInfo.InvariantCulture) / 1000000
                                    t.Longitude = Double.Parse(fields(2), CultureInfo.InvariantCulture) / 1000000
                                    transport.Add(t)
                                End If
                            Case "tram"
                                If fields(0) = 3 Then
                                    t.Number = fields(1)
                                    t.Latitude = Double.Parse(fields(3), CultureInfo.InvariantCulture) / 1000000
                                    t.Longitude = Double.Parse(fields(2), CultureInfo.InvariantCulture) / 1000000
                                    transport.Add(t)
                                End If
                            Case "trolley"
                                If fields(0) = 1 Then
                                    t.Number = fields(1)
                                    t.Latitude = Double.Parse(fields(3), CultureInfo.InvariantCulture) / 1000000
                                    t.Longitude = Double.Parse(fields(2), CultureInfo.InvariantCulture) / 1000000
                                    transport.Add(t)
                                End If
                        End Select
                    End If
                End While
            End Using
            response.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return transport
    End Function
End Class
