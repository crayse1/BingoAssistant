' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

Imports Windows.UI.Xaml.Data

Public NotInheritable Class BoardControl
    Inherits UserControl
    Public ReadOnly Property Card() As Card
        Get
            Return CType(Me.DataContext, Card)
        End Get
    End Property


    Public Sub FillSpace(oSpace As Space)
        Dim oPoint = New Point(oSpace.Column, oSpace.Row)
        If Card.PointNumber.ContainsKey(oPoint) Then
            Dim strValue = Card.PointNumber(oPoint).ToString
            Select Case oSpace.ColumnLetter
                Case "B"
                    Select Case oSpace.Row
                        Case 0
                            B1.Foreground = New SolidColorBrush(Windows.UI.Colors.Red)
                        Case 1
                            B2.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) 'oSpace.Value
                        Case 2
                            B3.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) 'oSpace.Value
                        Case 3
                            B4.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 4
                            B5.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                    End Select
                Case "I"
                    Select Case oSpace.Row
                        Case 0
                            I1.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 1
                            I2.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 2
                            I3.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 3
                            I4.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 4
                            I5.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                    End Select
                Case "N"
                    Select Case oSpace.Row
                        Case 0
                            N1.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) 'oSpace.Value
                        Case 1
                            N2.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) 'oSpace.Value
                        Case 2
                            N3.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) 'oSpace.Value
                        Case 3
                            N4.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 4
                            N5.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                    End Select
                Case "G"
                    Select Case oSpace.Row
                        Case 0
                            G1.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 1
                            G2.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 2
                            G3.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 3
                            G4.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 4
                            G5.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                    End Select
                Case "O"
                    Select Case oSpace.Row
                        Case 0
                            O1.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 1
                            O2.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 2
                            O3.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 3
                            O4.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                        Case 4
                            O5.Foreground = New SolidColorBrush(Windows.UI.Colors.Red) ' oSpace.Value
                    End Select
            End Select
        End If
    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        txtName.Text = Card.Name
        For Each oValue In Card.PointSelected
            FillSpace(New Space() With {.Column = oValue.Key.X, .Row = oValue.Key.Y, .ColumnLetter = CChar("BINGO".Substring(oValue.Key.X, 1))})
        Next
        For x = 0 To 4
            For y = 0 To 4
                Dim strvalue = Card.PointNumber(New Point(x, y)).ToString
                Select Case x
                    Case 0
                        Select Case y
                            Case 0
                                B1.Text = strvalue 'oSpace.Value
                            Case 1
                                B2.Text = strvalue 'oSpace.Value
                            Case 2
                                B3.Text = strvalue 'oSpace.Value
                            Case 3
                                B4.Text = strvalue ' oSpace.Value
                            Case 4
                                B5.Text = strvalue ' oSpace.Value
                        End Select
                    Case 1
                        Select Case y
                            Case 0
                                I1.Text = strvalue ' oSpace.Value
                            Case 1
                                I2.Text = strvalue ' oSpace.Value
                            Case 2
                                I3.Text = strvalue ' oSpace.Value
                            Case 3
                                I4.Text = strvalue ' oSpace.Value
                            Case 4
                                I5.Text = strvalue ' oSpace.Value
                        End Select
                    Case 2
                        Select Case y
                            Case 0
                                N1.Text = strvalue 'oSpace.Value
                            Case 1
                                N2.Text = strvalue 'oSpace.Value
                            Case 2
                                N3.Text = "Free Space" 'oSpace.Value
                            Case 3
                                N4.Text = strvalue ' oSpace.Value
                            Case 4
                                N5.Text = strvalue ' oSpace.Value
                        End Select
                    Case 3
                        Select Case y
                            Case 0
                                G1.Text = strvalue ' oSpace.Value
                            Case 1
                                G2.Text = strvalue ' oSpace.Value
                            Case 2
                                G3.Text = strvalue ' oSpace.Value
                            Case 3
                                G4.Text = strvalue ' oSpace.Value
                            Case 4
                                G5.Text = strvalue ' oSpace.Value
                        End Select
                    Case 4
                        Select Case y
                            Case 0
                                O1.Text = strvalue ' oSpace.Value
                            Case 1
                                O2.Text = strvalue ' oSpace.Value
                            Case 2
                                O3.Text = strvalue ' oSpace.Value
                            Case 3
                                O4.Text = strvalue ' oSpace.Value
                            Case 4
                                O5.Text = strvalue ' oSpace.Value
                        End Select
                End Select
            Next
        Next
    End Sub

    Private Sub UserControl_DataContextChanged(sender As FrameworkElement, args As DataContextChangedEventArgs)
        Try
            For Each oValue In Card.PointSelected
                FillSpace(New Space() With {.Column = oValue.Key.X, .Row = oValue.Key.Y, .ColumnLetter = CChar("BINGO".Substring(oValue.Key.X, 1))})
            Next
        Catch
        End Try
    End Sub
End Class
