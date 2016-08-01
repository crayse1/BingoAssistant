Public Class Card
    Implements INotifyPropertyChanged

    Public Sub New()
        'Add Free Space
        _PointNumber.Add(New Point(2, 2), 0)
        _NumberPoint.Add(0, New Point(2, 2))
        Dim oBingoList As New List(Of String)
        oBingoList.Add("Free Space")
        _BingoNumber.Add("N", oBingoList)
    End Sub
    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
            NotifyPropertyChanged("Name")
        End Set
    End Property
    Private _PointSelected As New Dictionary(Of Point, Boolean)
    Public Property PointSelected() As Dictionary(Of Point, Boolean)
        Get
            Return _PointSelected
        End Get
        Set(ByVal value As Dictionary(Of Point, Boolean))
            _PointSelected = value
            NotifyPropertyChanged("PointSelected")
        End Set
    End Property
    Private _PointNumber As New Dictionary(Of Point, Integer)
    Public Property PointNumber() As Dictionary(Of Point, Integer)
        Get
            Return _PointNumber
        End Get
        Set(ByVal value As Dictionary(Of Point, Integer))
            _PointNumber = value
            NotifyPropertyChanged("PointNumber")
        End Set
    End Property
    Private _NumberPoint As New Dictionary(Of Integer, Point)
    Public Property NumberPoint() As Dictionary(Of Integer, Point)
        Get
            Return _NumberPoint
        End Get
        Set(ByVal value As Dictionary(Of Integer, Point))
            _NumberPoint = value
            NotifyPropertyChanged("NumberPoint")
        End Set
    End Property
    Private _BingoNumber As New Dictionary(Of Char, List(Of String))
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property BingoNumber() As Dictionary(Of Char, List(Of String))
        Get
            Return _BingoNumber
        End Get
        Set(ByVal value As Dictionary(Of Char, List(Of String)))
            _BingoNumber = value
            NotifyPropertyChanged("BingoNumber")
        End Set
    End Property


    Private Sub NotifyPropertyChanged(info As String)

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))

    End Sub
    Public Function Add(InNumber As Integer) As Space
        Dim iRemainder = Math.IEEERemainder(InNumber - 1, 15)
        If iRemainder < 0 Then iRemainder += 15
        Dim iColumn As Integer = CInt((InNumber - 1 - iRemainder) / 15.0)
        Dim cColumn As Char = "BINGO".Substring(iColumn, 1)
        If _BingoNumber.ContainsKey(cColumn) AndAlso _BingoNumber(cColumn).Count = 5 Then
            Return Nothing
        End If
        If _PointNumber.Count = 25 Then
            Return Nothing
        End If
        If 1 < InNumber And InNumber > 75 Then
            Return Nothing
        End If
        Dim iRow As Integer = 0
        Dim oBingoList As New List(Of String)
        If _BingoNumber.ContainsKey(cColumn) Then
            oBingoList = _BingoNumber(cColumn)
        End If
        iRow = oBingoList.Count - If(cColumn = "N"c, If(oBingoList.Count <= 2, 1, 0), 0)
        Dim oPoint As New Point(iColumn, iRow)
        If _NumberPoint.ContainsKey(InNumber) Or _PointNumber.ContainsKey(oPoint) Then
            Return Nothing
        End If
        If cColumn = "N"c Then
            oBingoList.RemoveAll(Function(i) i = "Free Space")
            iRow = oBingoList.Count
            If iRow >= 2 Then iRow += 1
            oBingoList.Add(InNumber.ToString)
            If oBingoList.Count <= 1 Then
                oBingoList.Add("Free Space")
            Else
                oBingoList.Insert(2, "Free Space")
            End If
        Else
            iRow = oBingoList.Count
            oBingoList.Add(InNumber.ToString)
        End If
        _NumberPoint.Add(InNumber, oPoint)
        _PointNumber.Add(oPoint, InNumber)
        If oBingoList.Count = 1 Then
            _BingoNumber.Add(cColumn, oBingoList)
        Else
            _BingoNumber(cColumn) = oBingoList
        End If
        Return New Space(iColumn, iRow, cColumn, InNumber.ToString)
    End Function
    Public Sub CalledNumber(InNumber As Integer)
        If _NumberPoint.ContainsKey(InNumber) Then
            If Not _PointSelected.ContainsKey(_NumberPoint(InNumber)) Then
                _PointSelected.Add(_NumberPoint(InNumber), True)
            End If
        End If
    End Sub
    Public Sub ResetCard()
        _PointSelected = New Dictionary(Of Point, Boolean)
    End Sub
End Class
Public Class Space
    Public Sub New(InColumn As Integer, InRow As Integer, InColumnLetter As Char, InValue As String)
        _Column = InColumn
        _Row = InRow
        _Value = InValue
        _ColumnLetter = InColumnLetter
    End Sub
    Public Sub New()

    End Sub
    Private _ColumnLetter As Char
    Public Property ColumnLetter() As Char
        Get
            Return _ColumnLetter
        End Get
        Set(ByVal value As Char)
            _ColumnLetter = value
        End Set
    End Property
    Private _Column As Integer
    Public Property Column() As Integer
        Get
            Return _Column
        End Get
        Set(ByVal value As Integer)
            _Column = value
        End Set
    End Property
    Private _Row As Integer
    Public Property Row() As Integer
        Get
            Return _Row
        End Get
        Set(ByVal value As Integer)
            _Row = value
        End Set
    End Property
    Private _Value As String
    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property
End Class
Public Class Game
    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property
    Private _Combinations As New List(Of Combination)
    Public Property Combinations() As List(Of Combination)
        Get
            Return _Combinations
        End Get
        Set(ByVal value As List(Of Combination))
            _Combinations = value
        End Set
    End Property
    Public Function IsCardWinner(InCard As Card) As Boolean
        For Each oCombo In Combinations
            If oCombo.IsCardWinner(InCard) Then
                Return True
            End If
        Next
        Return False
    End Function
    Private _CalledNumbers As New ObservableCollection(Of CalledNumber)
    Public Property CalledNumbers() As ObservableCollection(Of CalledNumber)
        Get
            Return _CalledNumbers
        End Get
        Set(ByVal value As ObservableCollection(Of CalledNumber))
            _CalledNumbers = value
        End Set
    End Property

End Class
Public Class Combination

    Private _Points As New List(Of Point)
    Public Property Points() As List(Of Point)
        Get
            Return _Points
        End Get
        Set(ByVal value As List(Of Point))
            _Points = value
        End Set
    End Property
    Public Function IsCardWinner(InCard As Card) As Boolean
        For Each oPoint In Points
            If Not InCard.PointSelected.ContainsKey(oPoint) Then
                Return False
            End If
        Next
        Return True
    End Function
    Public Function GetNeededPoints(InCard) As List(Of Point)
        Dim collNeededPoints As New List(Of Point)
        For Each oPoint In Points
            If Not InCard.PointNumber.ContainsKey(oPoint) Then
                collNeededPoints.Add(oPoint)
            End If
        Next
        Return collNeededPoints
    End Function

    Public Function GetRemainingNumber(InCard As Card) As RemainingNumber
        Dim collNeededPoints As New List(Of Point)
        Dim strRemainingText As String = ""
        For Each oPoint In Points
            If Not InCard.PointSelected.ContainsKey(oPoint) Then
                strRemainingText &= " " & InCard.PointNumber(oPoint).ToString
                collNeededPoints.Add(oPoint)
            End If
        Next
        Return New RemainingNumber() With {.CardName = InCard.Name, .CountToWin = collNeededPoints.Count, .NumberRemaining = strRemainingText}

    End Function

End Class
Public Class CalledNumber
    Private _Number As String
    Public Property Number() As String
        Get
            Return _Number
        End Get
        Set(ByVal value As String)
            _Number = value
        End Set
    End Property
End Class
Public Class RemainingNumber
    Private _CardName As String
    Public Property CardName() As String
        Get
            Return _CardName
        End Get
        Set(ByVal value As String)
            _CardName = value
        End Set
    End Property
    Private _CountToWin As Integer
    Public Property CountToWin() As Integer
        Get
            Return _CountToWin
        End Get
        Set(ByVal value As Integer)
            _CountToWin = value
        End Set
    End Property
    Private _NumberRemaining As String
    Public Property NumberRemaining() As String
        Get
            Return _NumberRemaining
        End Get
        Set(ByVal value As String)
            _NumberRemaining = value
        End Set
    End Property
End Class