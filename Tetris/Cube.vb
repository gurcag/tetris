Public Class Cube : Inherits Label
    Public Sub New(ByVal background As Color, ByVal pointx As Integer, ByVal pointy As Integer, ByVal width As Integer)
        Me.Height = width
        Me.Width = width
        Me.BackColor = background
        Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        Me.Location = New Point(pointx, pointy)
    End Sub
    Public ReadOnly Property IndexX() As Integer
        Get
            Return (Me.Location.X / Me.Width)
        End Get
    End Property
    Public ReadOnly Property IndexY() As Integer
        Get
            Return (Me.Location.Y / Me.Height)
        End Get
    End Property
End Class
