' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class Play
    Inherits Page
    Private _collRemainingNumbers As ObservableCollection(Of RemainingNumber)
    Public Property collRemainingNumbers() As ObservableCollection(Of RemainingNumber)
        Get
            Return _collRemainingNumbers
        End Get
        Set(ByVal value As ObservableCollection(Of RemainingNumber))
            _collRemainingNumbers = value
        End Set
    End Property
    Private _collItems As ObservableCollection(Of CalledNumber)
    Public Property collItems() As ObservableCollection(Of CalledNumber)
        Get
            Return g_Game.CalledNumbers
        End Get
        Set(ByVal value As ObservableCollection(Of CalledNumber))
            g_Game.CalledNumbers = value
        End Set
    End Property
    Public ReadOnly Property PlayCards() As ObservableCollection(Of Card)
        Get
            Return g_Cards
        End Get
    End Property
    Private Async Sub Number_KeyDown(sender As Object, e As KeyRoutedEventArgs)
        Try
            If e.Key = Windows.System.VirtualKey.Enter Then
                If Number.Text = "" Then Exit Sub
                Dim iNumber As Integer = CInt(Number.Text)
                Dim sNumber As String = Number.Text
                Number.Text = ""
                If g_Game.CalledNumbers.Count = 0 Then
                    g_Game.CalledNumbers.Add(New CalledNumber() With {.Number = sNumber})
                Else
                    g_Game.CalledNumbers.Insert(0, New CalledNumber() With {.Number = sNumber})
                End If
                For Each oCard In g_Cards
                    oCard.CalledNumber(iNumber)
                    If g_Game.IsCardWinner(oCard) Then
                        Await New Windows.UI.Popups.MessageDialog(oCard.Name & " Is Winner").ShowAsync
                    End If
                Next
                collRemainingNumbers = New ObservableCollection(Of RemainingNumber)
                Dim collRemNum As New List(Of RemainingNumber)
                For Each combo In g_Game.Combinations
                    For Each oCard In g_Cards
                        collRemNum.Add(combo.GetRemainingNumber(oCard))
                    Next
                Next
                For Each oRow In collRemNum.OrderBy(Function(r) r.CountToWin)
                    collRemainingNumbers.Add(oRow)
                Next
                lvRemainingNumbers.ItemsSource = collRemainingNumbers

                lvPreview.ItemsSource = Nothing
                lvPreview.ItemsSource = PlayCards
                Number.Text = ""
                Number.Focus(FocusState.Pointer)
            End If
        Catch
        End Try
    End Sub

End Class
