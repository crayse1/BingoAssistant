' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub



    Private Sub HamburgerButton_Click(sender As Object, e As RoutedEventArgs)
        MySplitVeiw.IsPaneOpen = Not MySplitVeiw.IsPaneOpen
    End Sub

    Private Sub TextBlock_SelectionChanged(sender As Object, e As RoutedEventArgs)
        Dim itm = CType(IconsListBox.SelectedItem, ListBoxItem)
        Select Case itm.Name
            Case "IconAddCard"
                ScenarioFrame.Navigate(GetType(AddCard))
            Case "IconSetupGame"
                ScenarioFrame.Navigate(GetType(Settings))
            Case "IconPlayGame"
                ScenarioFrame.Navigate(GetType(Play))
        End Select
    End Sub

End Class
