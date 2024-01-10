Public MustInherit Class Shape
    Private c1 As Cube
    Private c2 As Cube
    Private c3 As Cube
    Private c4 As Cube
    Private type As Integer
    Public Cubes As New ArrayList
    Public MatrixesPoints(,) As Cube
    Public Direction As ShapeDirection
    Public IsShapeCannotRotate As Boolean = False

    Public ReadOnly Property ShapeType() As Integer
        Get
            Return type
        End Get
    End Property
    Public Property CubeOne() As Cube
        Get
            Return c1
        End Get
        Set(ByVal value As Cube)
            c1 = value
        End Set
    End Property
    Public Property CubeTwo() As Cube
        Get
            Return c2
        End Get
        Set(ByVal value As Cube)
            c2 = value
        End Set
    End Property
    Public Property CubeThree() As Cube
        Get
            Return c3
        End Get
        Set(ByVal value As Cube)
            c3 = value
        End Set
    End Property
    Public Property CubeFour() As Cube
        Get
            Return c4
        End Get
        Set(ByVal value As Cube)
            c4 = value
        End Set
    End Property
    Public ReadOnly Property XPoint() As Integer
        Get
            Dim PointX As Integer = Me.CubeOne.IndexX
            For Each item As Cube In Me.Cubes
                If item.IndexX < PointX Then
                    PointX = item.Location.X
                End If
            Next
            Return PointX
        End Get
    End Property
    Public ReadOnly Property LeftCorner() As Integer
        Get
            Dim LocationLeft As Integer = Me.CubeOne.Location.X
            For Each item As Cube In Me.Cubes
                If item.Location.X < LocationLeft Then
                    LocationLeft = item.Location.X
                End If
            Next
            Return LocationLeft
        End Get
    End Property
    Public ReadOnly Property RightCorner() As Integer
        Get
            Dim LocationRight As Integer = Me.CubeOne.Location.X

            For Each item As Cube In Me.Cubes

                If item.Location.X > LocationRight Then
                    LocationRight = item.Location.X
                End If
            Next

            Return LocationRight + c1.Width
        End Get
    End Property
    Public ReadOnly Property Bottom() As Integer
        Get
            Dim LocationBottom As Integer = Me.CubeOne.Height

            For Each item As Cube In Me.Cubes

                If item.Location.Y > LocationBottom Then
                    LocationBottom = item.Location.Y
                End If

            Next

            Return LocationBottom + c1.Height
        End Get
    End Property
    Public Sub Draw(ByVal Control As Control)
        Control.Controls.Add(CubeOne)
        Control.Controls.Add(CubeTwo)
        Control.Controls.Add(CubeThree)
        Control.Controls.Add(CubeFour)
    End Sub
    Public ReadOnly Property CanMove(ByVal Direction As Integer) As Boolean

        Get
            If Direction = 1 Then
                For Each item As Cube In Me.Cubes
                    If item.IndexX - 1 >= Me.MatrixesPoints.GetLowerBound(0) Then
                        If Me.MatrixesPoints(item.IndexX - 1, item.IndexY) IsNot Nothing Then
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Next
            ElseIf Direction = 2 Then
                For Each item As Cube In Me.Cubes
                    If item.IndexX + 1 <= Me.MatrixesPoints.GetUpperBound(0) Then
                        If Me.MatrixesPoints(item.IndexX + 1, item.IndexY) IsNot Nothing Then
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Next
            ElseIf Direction = 3 Then
                For Each item As Cube In Me.Cubes
                    If item.IndexY + 1 <= Me.MatrixesPoints.GetUpperBound(1) Then
                        If Me.MatrixesPoints(item.IndexX, item.IndexY + 1) IsNot Nothing Then
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Next
            End If
            Return True
        End Get
    End Property
    Public Sub Move_Right(ByVal shape As Shape)

        If Me.CanMove(2) Then
            shape.CubeOne.Location = New Point(shape.CubeOne.Location.X + c1.Width, shape.CubeOne.Location.Y)
            shape.CubeTwo.Location = New Point(shape.CubeTwo.Location.X + c1.Width, shape.CubeTwo.Location.Y)
            shape.CubeThree.Location = New Point(shape.CubeThree.Location.X + c1.Width, shape.CubeThree.Location.Y)
            shape.CubeFour.Location = New Point(shape.CubeFour.Location.X + c1.Width, shape.CubeFour.Location.Y)
        End If

    End Sub
    Public Sub Move_Left(ByVal shape As Shape)
        If Me.CanMove(1) Then
            shape.CubeOne.Location = New Point(shape.CubeOne.Location.X - c1.Width, shape.CubeOne.Location.Y)
            shape.CubeTwo.Location = New Point(shape.CubeTwo.Location.X - c1.Width, shape.CubeTwo.Location.Y)
            shape.CubeThree.Location = New Point(shape.CubeThree.Location.X - c1.Width, shape.CubeThree.Location.Y)
            shape.CubeFour.Location = New Point(shape.CubeFour.Location.X - c1.Width, shape.CubeFour.Location.Y)
        End If
    End Sub
    Function Move_Down(ByVal shape As Shape) As Boolean
        If Me.CanMove(3) Then
            shape.CubeOne.Location = New Point(shape.CubeOne.Location.X, shape.CubeOne.Location.Y + c1.Height)
            shape.CubeTwo.Location = New Point(shape.CubeTwo.Location.X, shape.CubeTwo.Location.Y + c1.Height)
            shape.CubeThree.Location = New Point(shape.CubeThree.Location.X, shape.CubeThree.Location.Y + c1.Height)
            shape.CubeFour.Location = New Point(shape.CubeFour.Location.X, shape.CubeFour.Location.Y + c1.Height)
            Return True
        Else
            Return False
        End If
    End Function
    Function ListOfPointsX(ByVal shape As Shape) As ArrayList
        Dim list As New ArrayList
        list.Add(c1.Location.X)
        list.Add(c2.Location.X)
        list.Add(c3.Location.X)
        list.Add(c4.Location.X)
        Return list
    End Function
    Function ListOfPointsY(ByVal par As Shape) As ArrayList
        Dim list As New ArrayList()
        list.Add(c1.Location.Y)
        list.Add(c2.Location.Y)
        list.Add(c3.Location.Y)
        list.Add(c4.Location.Y)
        Return list
    End Function
    Public Overridable Sub Rotate()

        '    Dim NewPoints As New ArrayList
        '    Dim Point1, Point2, Point3, Point4 As New Point

        '    If Me.ShapeType = 5 Then 'Kare
        '        Exit Sub
        '    ElseIf Me.ShapeType = 1 Then 'I
        '        If (Me.Direction Mod 2) = 1 Then
        '            Point1 = New Point(Me.CubeTwo.IndexX - 1, Me.CubeTwo.IndexY)
        '            Point2 = New Point(Me.CubeTwo.IndexX, Me.CubeTwo.IndexY)
        '            Point3 = New Point(Me.CubeTwo.IndexX + 1, Me.CubeTwo.IndexY)
        '            Point4 = New Point(Me.CubeTwo.IndexX + 2, Me.CubeTwo.IndexY)
        '        Else
        '            Point1 = New Point(Me.CubeTwo.IndexX, Me.CubeTwo.IndexY - 1)
        '            Point2 = New Point(Me.CubeTwo.IndexX, Me.CubeTwo.IndexY)
        '            Point3 = New Point(Me.CubeTwo.IndexX, Me.CubeTwo.IndexY + 1)
        '            Point4 = New Point(Me.CubeTwo.IndexX, Me.CubeTwo.IndexY + 2)
        '        End If
        '    ElseIf Me.ShapeType = 2 Then 'L
        '        If Me.Direction = 1 Then
        '            Point1 = New Point(Me.CubeThree.IndexX - 1, Me.CubeThree.IndexY - 1)
        '            Point2 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY - 1)
        '            Point3 = New Point(Me.CubeThree.IndexX + 1, Me.CubeThree.IndexY - 1)
        '            Point4 = New Point(Me.CubeThree.IndexX + 1, Me.CubeThree.IndexY - 2)
        '        ElseIf Me.Direction = 2 Then
        '            Point1 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY + 1)
        '            Point2 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY)
        '            Point3 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY - 1)
        '            Point4 = New Point(Me.CubeThree.IndexX - 1, Me.CubeThree.IndexY - 1)
        '        ElseIf Me.Direction = 3 Then
        '            Point1 = New Point(Me.CubeThree.IndexX - 2, Me.CubeThree.IndexY + 1)
        '            Point2 = New Point(Me.CubeThree.IndexX - 1, Me.CubeThree.IndexY)
        '            Point3 = New Point(Me.CubeThree.IndexX - 2, Me.CubeThree.IndexY)
        '            Point4 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY)
        '        ElseIf Me.Direction = 4 Then
        '            Point1 = New Point(Me.CubeThree.IndexX + 1, Me.CubeThree.IndexY)
        '            Point2 = New Point(Me.CubeThree.IndexX + 1, Me.CubeThree.IndexY + 1)
        '            Point3 = New Point(Me.CubeThree.IndexX + 1, Me.CubeThree.IndexY + 2)
        '            Point4 = New Point(Me.CubeThree.IndexX + 2, Me.CubeThree.IndexY + 2)
        '        End If
        '    ElseIf Me.ShapeType = 3 Then 'J
        '        If Me.Direction = 1 Then
        '            Point1 = New Point(Me.CubeThree.IndexX - 2, Me.CubeThree.IndexY - 2)
        '            Point2 = New Point(Me.CubeThree.IndexX - 1, Me.CubeThree.IndexY - 2)
        '            Point3 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY - 2)
        '            Point4 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY - 1)
        '        ElseIf Me.Direction = 2 Then
        '            Point1 = New Point(Me.CubeThree.IndexX - 1, Me.CubeThree.IndexY + 2)
        '            Point2 = New Point(Me.CubeThree.IndexX - 1, Me.CubeThree.IndexY + 1)
        '            Point3 = New Point(Me.CubeThree.IndexX - 1, Me.CubeThree.IndexY)
        '            Point4 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY)
        '        ElseIf Me.Direction = 3 Then
        '            Point1 = New Point(Me.CubeThree.IndexX - 1, Me.CubeThree.IndexY)
        '            Point2 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY + 1)
        '            Point3 = New Point(Me.CubeThree.IndexX - 1, Me.CubeThree.IndexY + 1)
        '            Point4 = New Point(Me.CubeThree.IndexX + 1, Me.CubeThree.IndexY + 1)
        '        ElseIf Me.Direction = 4 Then
        '            Point1 = New Point(Me.CubeThree.IndexX + 2, Me.CubeThree.IndexY - 1)
        '            Point2 = New Point(Me.CubeThree.IndexX + 2, Me.CubeThree.IndexY)
        '            Point3 = New Point(Me.CubeThree.IndexX + 2, Me.CubeThree.IndexY + 1)
        '            Point4 = New Point(Me.CubeThree.IndexX + 1, Me.CubeThree.IndexY + 1)
        '        End If
        '    ElseIf Me.ShapeType = 4 Then 'T
        '        If Me.Direction = 1 Then
        '            Point1 = New Point(Me.CubeOne.IndexX + 1, Me.CubeOne.IndexY)
        '            Point2 = New Point(Me.CubeTwo.IndexX, Me.CubeTwo.IndexY + 1)
        '            Point3 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY + 1)
        '            Point4 = New Point(Me.CubeFour.IndexX, Me.CubeFour.IndexY + 1)
        '        ElseIf Me.Direction = 2 Then
        '            Point1 = New Point(Me.CubeOne.IndexX, Me.CubeOne.IndexY)
        '            Point2 = New Point(Me.CubeTwo.IndexX, Me.CubeTwo.IndexY)
        '            Point3 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY)
        '            Point4 = New Point(Me.CubeFour.IndexX - 1, Me.CubeFour.IndexY - 1)
        '        ElseIf Me.Direction = 3 Then
        '            Point1 = New Point(Me.CubeOne.IndexX, Me.CubeOne.IndexY)
        '            Point2 = New Point(Me.CubeTwo.IndexX, Me.CubeTwo.IndexY)
        '            Point3 = New Point(Me.CubeThree.IndexX - 1, Me.CubeThree.IndexY + 1)
        '            Point4 = New Point(Me.CubeFour.IndexX, Me.CubeFour.IndexY)
        '        ElseIf Me.Direction = 4 Then
        '            Point1 = New Point(Me.CubeOne.IndexX - 1, Me.CubeOne.IndexY)
        '            Point2 = New Point(Me.CubeTwo.IndexX, Me.CubeTwo.IndexY - 1)
        '            Point3 = New Point(Me.CubeThree.IndexX + 1, Me.CubeThree.IndexY - 2)
        '            Point4 = New Point(Me.CubeFour.IndexX + 1, Me.CubeFour.IndexY)
        '        End If
        '    ElseIf Me.ShapeType = 6 Then 'Z
        '        If (Me.Direction Mod 2) = 1 Then
        '            Point2 = New Point(Me.CubeOne.IndexX, Me.CubeOne.IndexY + 1)
        '            Point3 = New Point(Me.CubeTwo.IndexX, Me.CubeTwo.IndexY + 1)
        '            Point1 = New Point(Me.CubeOne.IndexX, Me.CubeOne.IndexY + 2)
        '            Point4 = New Point(Me.CubeFour.IndexX - 1, Me.CubeFour.IndexY - 1)
        '        Else
        '            Point1 = New Point(Me.CubeTwo.IndexX, Me.CubeTwo.IndexY - 1)
        '            Point2 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY - 1)
        '            Point3 = New Point(Me.CubeOne.IndexX + 1, Me.CubeOne.IndexY - 1)
        '            Point4 = New Point(Me.CubeOne.IndexX + 2, Me.CubeOne.IndexY - 1)
        '        End If
        '    ElseIf Me.ShapeType = 7 Then 'S
        '        If (Me.Direction Mod 2) = 1 Then
        '            Point1 = New Point(Me.CubeOne.IndexX - 1, Me.CubeOne.IndexY + 1)
        '            Point2 = New Point(Me.CubeTwo.IndexX - 2, Me.CubeTwo.IndexY)
        '            Point3 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY)
        '            Point4 = New Point(Me.CubeFour.IndexX + 1, Me.CubeFour.IndexY + 1)
        '        Else
        '            Point1 = New Point(Me.CubeOne.IndexX + 1, Me.CubeOne.IndexY - 1)
        '            Point2 = New Point(Me.CubeTwo.IndexX + 2, Me.CubeTwo.IndexY)
        '            Point3 = New Point(Me.CubeThree.IndexX, Me.CubeThree.IndexY)
        '            Point4 = New Point(Me.CubeFour.IndexX - 1, Me.CubeFour.IndexY - 1)
        '        End If
        '    End If

        '    NewPoints.Add(Point1)
        '    NewPoints.Add(Point2)
        '    NewPoints.Add(Point3)
        '    NewPoints.Add(Point4)
        '    If CanRotate(NewPoints) Then
        '        Me.CubeOne.Location = New Point(Point1.X * CubeOne.Width, Point1.Y * CubeOne.Width)
        '        Me.CubeTwo.Location = New Point(Point2.X * CubeOne.Width, Point2.Y * CubeOne.Width)
        '        Me.CubeThree.Location = New Point(Point3.X * CubeOne.Width, Point3.Y * CubeOne.Width)
        '        Me.CubeFour.Location = New Point(Point4.X * CubeOne.Width, Point4.Y * CubeOne.Width)

        '        Me.Direction = (Me.Direction Mod 4) + 1
        '    End If
    End Sub
    Public Function CanRotate(ByVal arrayPoints As ArrayList) As Boolean

        For Each item As Point In arrayPoints

            If item.X >= Me.MatrixesPoints.GetLowerBound(0) And item.Y >= Me.MatrixesPoints.GetLowerBound(1) And item.X <= Me.MatrixesPoints.GetUpperBound(0) And item.Y + 1 <= Me.MatrixesPoints.GetUpperBound(1) Then
                If Me.MatrixesPoints(item.X, item.Y) IsNot Nothing Then
                    Return False
                End If
            Else
                Return False
            End If
        Next

        Return True

    End Function
    Public Enum ShapeDirection As Integer
        Top = 1
        Right = 2
        Bottom = 3
        Left = 4
    End Enum
End Class