Public NotInheritable Class ShapeSquare : Inherits Shape
    Public Sub New(ByVal pointx As Integer, ByVal pointy As Integer, ByVal cubewidth As Integer, ByVal cubeColor As Color, ByVal parDirection As Integer, ByVal Points(,) As Cube)
        MatrixesPoints = Points
        CubeOne = New Cube(cubeColor, pointx, pointy, cubewidth)
        CubeTwo = New Cube(cubeColor, CubeOne.Location.X, CubeOne.Location.Y + cubewidth, cubewidth)
        CubeThree = New Cube(cubeColor, CubeTwo.Location.X + cubewidth, CubeOne.Location.Y, cubewidth)
        CubeFour = New Cube(cubeColor, CubeThree.Location.X, CubeTwo.Location.Y, cubewidth)

        Cubes.Add(CubeOne)
        Cubes.Add(CubeTwo)
        Cubes.Add(CubeThree)
        Cubes.Add(CubeFour)
    End Sub

    Public Overrides Sub Rotate()
    End Sub
End Class
