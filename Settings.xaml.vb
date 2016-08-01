' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class Settings
    Inherits Page


    Private Sub StandardBingo_Tapped(sender As Object, e As TappedRoutedEventArgs)
        g_Game.Combinations.Clear()
        g_Game.Name = "Standard Bingo"
        Dim oCombination As New List(Of Point)
        'top down all for columns
        For y = 0 To 4
            oCombination = New List(Of Point)
            For x = 0 To 4
                oCombination.Add(New Point(x, y))
            Next

            g_Game.Combinations.Add(New Combination() With {.Points = oCombination})
        Next


        'across for all rows
        For x = 0 To 4
            oCombination = New List(Of Point)
            For y = 0 To 4
                oCombination.Add(New Point(x, y))
            Next
            g_Game.Combinations.Add(New Combination() With {.Points = oCombination})
        Next

        'Back Slash
        oCombination = New List(Of Point)
        oCombination.Add(New Point(0, 0))
        oCombination.Add(New Point(1, 1))
        oCombination.Add(New Point(2, 2))
        oCombination.Add(New Point(3, 3))
        oCombination.Add(New Point(4, 4))
        g_Game.Combinations.Add(New Combination() With {.Points = oCombination})

        'Forward Slash
        oCombination = New List(Of Point)
        oCombination.Add(New Point(4, 0))
        oCombination.Add(New Point(3, 1))
        oCombination.Add(New Point(2, 2))
        oCombination.Add(New Point(1, 3))
        oCombination.Add(New Point(0, 4))
        g_Game.Combinations.Add(New Combination() With {.Points = oCombination})

        'Outer 4

        oCombination = New List(Of Point)
        oCombination.Add(New Point(0, 0))
        oCombination.Add(New Point(4, 4))
        oCombination.Add(New Point(0, 4))
        oCombination.Add(New Point(4, 0))
        g_Game.Combinations.Add(New Combination() With {.Points = oCombination})

        'Inner 4

        oCombination = New List(Of Point)
        oCombination.Add(New Point(1, 1))
        oCombination.Add(New Point(1, 3))
        oCombination.Add(New Point(3, 1))
        oCombination.Add(New Point(3, 3))
        g_Game.Combinations.Add(New Combination() With {.Points = oCombination})

        For Each oCard In g_Cards
            oCard.ResetCard()

            oCard.CalledNumber(0)
        Next
    End Sub

    Private Sub Reset_Tapped(sender As Object, e As TappedRoutedEventArgs)
        g_Game = New Game
        For Each oCard In g_Cards
            oCard.ResetCard()

            oCard.CalledNumber(0)
        Next
    End Sub

    Private Sub StandardBingoNo_Tapped(sender As Object, e As TappedRoutedEventArgs)
        g_Game.Combinations.Clear()
        g_Game.Name = "Standard Bingo"
        Dim oCombination As New List(Of Point)
        'top down all for columns
        For y = 0 To 4
            oCombination = New List(Of Point)
            For x = 0 To 4
                oCombination.Add(New Point(x, y))
            Next

            g_Game.Combinations.Add(New Combination() With {.Points = oCombination})
        Next


        'across for all rows
        For x = 0 To 4
            oCombination = New List(Of Point)
            For y = 0 To 4
                oCombination.Add(New Point(x, y))
            Next
            g_Game.Combinations.Add(New Combination() With {.Points = oCombination})
        Next

        'Back Slash
        oCombination = New List(Of Point)
        oCombination.Add(New Point(0, 0))
        oCombination.Add(New Point(1, 1))
        oCombination.Add(New Point(2, 2))
        oCombination.Add(New Point(3, 3))
        oCombination.Add(New Point(4, 4))
        g_Game.Combinations.Add(New Combination() With {.Points = oCombination})

        'Forward Slash
        oCombination = New List(Of Point)
        oCombination.Add(New Point(4, 0))
        oCombination.Add(New Point(3, 1))
        oCombination.Add(New Point(2, 2))
        oCombination.Add(New Point(1, 3))
        oCombination.Add(New Point(0, 4))
        g_Game.Combinations.Add(New Combination() With {.Points = oCombination})


        For Each oCard In g_Cards
            oCard.ResetCard()
            oCard.CalledNumber(0)
        Next
    End Sub

    Private Sub Blackout_Tapped(sender As Object, e As TappedRoutedEventArgs)
        g_Game.Combinations.Clear()
        g_Game.Name = "Blackout"
        Dim oCombination As New List(Of Point)
        For x = 0 To 4
            For y = 0 To 4
                oCombination.Add(New Point(x, y))
            Next
        Next
        g_Game.Combinations.Add(New Combination() With {.Points = oCombination})
    End Sub

    Private Sub FillFakeCard_Tapped(sender As Object, e As TappedRoutedEventArgs)
        Dim oCard As New Card()
        oCard.Name = "1"
        oCard.Add(15)
        oCard.Add(1)
        oCard.Add(4)
        oCard.Add(2)
        oCard.Add(7)
        oCard.Add(29)
        oCard.Add(18)
        oCard.Add(17)
        oCard.Add(23)
        oCard.Add(24)
        oCard.Add(33)
        oCard.Add(35)
        oCard.Add(40)
        oCard.Add(43)
        oCard.Add(60)
        oCard.Add(55)
        oCard.Add(53)
        oCard.Add(51)
        oCard.Add(47)
        oCard.Add(75)
        oCard.Add(72)
        oCard.Add(62)
        oCard.Add(71)
        oCard.Add(69)
        g_Cards.Add(oCard)
    End Sub
End Class
