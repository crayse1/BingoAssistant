' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class AddCard
    Inherits Page
    Public _Card As New Card
    Private Async Sub Input_KeyDown(sender As Object, e As KeyRoutedEventArgs)
        Dim iInput As Integer
        Dim blnError As Boolean = False
        If e.Key = Windows.System.VirtualKey.Enter Then
            If Input.Text = "" Then Exit Sub
            Dim sNumber As String = Input.Text
            Input.Text = ""
            Try

                Dim oSpace As Space = Nothing
                If Integer.TryParse(sNumber, iInput) Then
                    oSpace = _Card.Add(iInput)
                    If oSpace Is Nothing Then
                        blnError = True
                    End If
                Else
                    blnError = True
                End If
                If blnError Then
                    Await New Windows.UI.Popups.MessageDialog(sNumber & " Is not a valid number").ShowAsync
                Else
                    FillSpace(oSpace)
                End If
                Input.Focus(FocusState.Pointer)

            Catch ex As Exception

                Debug.WriteLine(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        FillSpace(New Space(2, 2, "N", "Free Space"))
    End Sub
    Public Sub FillSpace(oSpace As Space)

        Select Case oSpace.ColumnLetter
            Case "B"
                Select Case oSpace.Row
                    Case 0
                        B1.Text = oSpace.Value
                    Case 1
                        B2.Text = oSpace.Value
                    Case 2
                        B3.Text = oSpace.Value
                    Case 3
                        B4.Text = oSpace.Value
                    Case 4
                        B5.Text = oSpace.Value
                End Select
            Case "I"
                Select Case oSpace.Row
                    Case 0
                        I1.Text = oSpace.Value
                    Case 1
                        I2.Text = oSpace.Value
                    Case 2
                        I3.Text = oSpace.Value
                    Case 3
                        I4.Text = oSpace.Value
                    Case 4
                        I5.Text = oSpace.Value
                End Select
            Case "N"
                Select Case oSpace.Row
                    Case 0
                        N1.Text = oSpace.Value
                    Case 1
                        N2.Text = oSpace.Value
                    Case 2
                        N3.Text = oSpace.Value
                    Case 3
                        N4.Text = oSpace.Value
                    Case 4
                        N5.Text = oSpace.Value
                End Select
            Case "G"
                Select Case oSpace.Row
                    Case 0
                        G1.Text = oSpace.Value
                    Case 1
                        G2.Text = oSpace.Value
                    Case 2
                        G3.Text = oSpace.Value
                    Case 3
                        G4.Text = oSpace.Value
                    Case 4
                        G5.Text = oSpace.Value
                End Select
            Case "O"
                Select Case oSpace.Row
                    Case 0
                        O1.Text = oSpace.Value
                    Case 1
                        O2.Text = oSpace.Value
                    Case 2
                        O3.Text = oSpace.Value
                    Case 3
                        O4.Text = oSpace.Value
                    Case 4
                        O5.Text = oSpace.Value
                End Select
        End Select
    End Sub

    Private Sub Save_Tapped(sender As Object, e As TappedRoutedEventArgs)
        _Card.Name = txtName.Text
        g_Cards.Add(_Card)
        FillSpace(New Space(0, 0, "B"c, ""))
        FillSpace(New Space(0, 1, "B"c, ""))
        FillSpace(New Space(0, 2, "B"c, ""))
        FillSpace(New Space(0, 3, "B"c, ""))
        FillSpace(New Space(0, 4, "B"c, ""))


        FillSpace(New Space(1, 0, "I"c, ""))
        FillSpace(New Space(1, 1, "I"c, ""))
        FillSpace(New Space(1, 2, "I"c, ""))
        FillSpace(New Space(1, 3, "I"c, ""))
        FillSpace(New Space(1, 4, "I"c, ""))

        FillSpace(New Space(2, 0, "N"c, ""))
        FillSpace(New Space(2, 1, "N"c, ""))
        'FillSpace(New Space(2, 2, "N"c, ""))
        FillSpace(New Space(2, 3, "N"c, ""))
        FillSpace(New Space(2, 4, "N"c, ""))

        FillSpace(New Space(3, 0, "G"c, ""))
        FillSpace(New Space(3, 1, "G"c, ""))
        FillSpace(New Space(3, 2, "G"c, ""))
        FillSpace(New Space(3, 3, "G"c, ""))
        FillSpace(New Space(3, 4, "G"c, ""))

        FillSpace(New Space(4, 0, "O"c, ""))
        FillSpace(New Space(4, 1, "O"c, ""))
        FillSpace(New Space(4, 2, "O"c, ""))
        FillSpace(New Space(4, 3, "O"c, ""))
        FillSpace(New Space(4, 4, "O"c, ""))
    End Sub
End Class
