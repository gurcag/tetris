Public NotInheritable Class ShapeS : Inherits Shape
    Public Sub New(ByVal pointx As Integer, ByVal pointy As Integer, ByVal cubewidth As Integer, ByVal cubeColor As Color, ByVal parDirection As Integer, ByVal Points(,) As Cube)
        MatrixesPoints = Points
        CubeOne = New Cube(cubeColor, pointx + cubewidth, pointy, cubewidth)
        CubeTwo = New Cube(cubeColor, CubeOne.Location.X + cubewidth, CubeOne.Location.Y, cubewidth)
        CubeThree = New Cube(cubeColor, CubeOne.Location.X, CubeTwo.Location.Y + cubewidth, cubewidth)
        CubeFour = New Cube(cubeColor, CubeThree.Location.X - cubewidth, CubeThree.Location.Y, cubewidth)

        Direction = 1

        While Direction <> parDirection
            Rotate()
            If IsShapeCannotRotate = False Then
                Exit While
            End If
        End While

        Cubes.Add(CubeOne)
        Cubes.Add(CubeTwo)
        Cubes.Add(CubeThree)
        Cubes.Add(CubeFour)
    End Sub

    Public Overrides Sub Rotate()
        Dim NewPoints As New ArrayList
        Dim Point1, Point2, Point3, Point4 As New Point

        If (Me.Direction Mod 2) = 1 Then
            Point1 = New Point(CubeOne.IndexX - 1, CubeOne.IndexY + 1)
            Point2 = New Point(CubeTwo.IndexX - 2, CubeTwo.IndexY)
            Point3 = New Point(CubeThree.IndexX, CubeThree.IndexY)
            Point4 = New Point(CubeFour.IndexX + 1, CubeFour.IndexY + 1)
        Else
            Point1 = New Point(CubeOne.IndexX + 1, CubeOne.IndexY - 1)
            Point2 = New Point(CubeTwo.IndexX + 2, CubeTwo.IndexY)
            Point3 = New Point(CubeThree.IndexX, CubeThree.IndexY)
            Point4 = New Point(CubeFour.IndexX - 1, CubeFour.IndexY - 1)
        End If

        NewPoints.Add(Point1)
        NewPoints.Add(Point2)
        NewPoints.Add(Point3)
        NewPoints.Add(Point4)

        If CanRotate(NewPoints) Then
            CubeOne.Location = New Point(Point1.X * CubeOne.Width, Point1.Y * CubeOne.Width)
            CubeTwo.Location = New Point(Point2.X * CubeOne.Width, Point2.Y * CubeOne.Width)
            CubeThree.Location = New Point(Point3.X * CubeOne.Width, Point3.Y * CubeOne.Width)
            CubeFour.Location = New Point(Point4.X * CubeOne.Width, Point4.Y * CubeOne.Width)
            Direction = (Direction Mod 4) + 1
        Else
            IsShapeCannotRotate = False
        End If
    End Sub
End Class
