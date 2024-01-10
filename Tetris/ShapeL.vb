Public NotInheritable Class ShapeL : Inherits Shape
    Public Sub New(ByVal pointx As Integer, ByVal pointy As Integer, ByVal cubewidth As Integer, ByVal cubeColor As Color, ByVal parDirection As Integer, ByVal Points(,) As Cube)
        MatrixesPoints = Points
        CubeOne = New Cube(cubeColor, pointx, pointy, cubewidth)
        CubeTwo = New Cube(cubeColor, pointx, CubeOne.Location.Y + cubewidth, cubewidth)
        CubeThree = New Cube(cubeColor, pointx, CubeTwo.Location.Y + cubewidth, cubewidth)
        CubeFour = New Cube(cubeColor, pointx + cubewidth, CubeThree.Location.Y, cubewidth)

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

        If Direction = 1 Then
            Point1 = New Point(CubeThree.IndexX - 1, CubeThree.IndexY - 1)
            Point2 = New Point(CubeThree.IndexX, CubeThree.IndexY - 1)
            Point3 = New Point(CubeThree.IndexX + 1, CubeThree.IndexY - 1)
            Point4 = New Point(CubeThree.IndexX + 1, CubeThree.IndexY - 2)
        ElseIf Direction = 2 Then
            Point1 = New Point(CubeThree.IndexX, CubeThree.IndexY + 1)
            Point2 = New Point(CubeThree.IndexX, CubeThree.IndexY)
            Point3 = New Point(CubeThree.IndexX, CubeThree.IndexY - 1)
            Point4 = New Point(CubeThree.IndexX - 1, CubeThree.IndexY - 1)
        ElseIf Direction = 3 Then
            Point1 = New Point(CubeThree.IndexX - 2, CubeThree.IndexY + 1)
            Point2 = New Point(CubeThree.IndexX - 1, CubeThree.IndexY)
            Point3 = New Point(CubeThree.IndexX - 2, CubeThree.IndexY)
            Point4 = New Point(CubeThree.IndexX, CubeThree.IndexY)
        ElseIf Direction = 4 Then
            Point1 = New Point(CubeThree.IndexX + 1, CubeThree.IndexY)
            Point2 = New Point(CubeThree.IndexX + 1, CubeThree.IndexY + 1)
            Point3 = New Point(CubeThree.IndexX + 1, CubeThree.IndexY + 2)
            Point4 = New Point(CubeThree.IndexX + 2, CubeThree.IndexY + 2)
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
