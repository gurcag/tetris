Imports System.IO

Public Class Main

    Private currentShape, nextShape As Shape
    Private timer As Timer
    Private cubewidth As Integer = 10
    Private Matrix(,) As Cube
    Private clearedrow, point, gameAreaWidth, gameAreaHeight As Integer
    Private labelSpaceHeight, labelSpaceWidth, tempSpace, currentLevel, selectedLevel, pointThisLevel As Integer
    Private lblPoint As Label
    Public panelNextShape, panelGame, panelRight, panelLabels As Panel
    Public path As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\TetrisHighScores.txt"
    Public ScoreEasy, ScoreMedium, ScoreHard, ScoreExpert As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cubewidth = GetSelectedShapeSize()
        Me.MaximizeBox = False
        gameAreaWidth = cubewidth * 10
        gameAreaHeight = cubewidth * 20
        Me.Width = gameAreaWidth + 250

        If gameAreaHeight + ToolStripMenuItem1.Height + 30 < 300 Then
            Me.Height = 300
        Else
            Me.Height = gameAreaHeight + ToolStripMenuItem1.Height + 30
        End If

        Dim fontStrings = New Font("Arial", 12, FontStyle.Bold)
        Dim fontChars = New Font("Unicode", 12, FontStyle.Regular)
        labelSpaceHeight = 30
        labelSpaceWidth = 130
        tempSpace = 20

        panelRight = New Panel
        panelRight.Width = Me.Width - gameAreaWidth
        panelRight.Height = Me.Height
        panelRight.Location = New Point(gameAreaWidth, ToolStripMenuItem1.Height + 2)
        panelRight.BackColor = Color.SteelBlue
        Me.Controls.Add(panelRight)

        panelGame = New Panel
        panelGame.Width = gameAreaWidth
        panelGame.Height = gameAreaHeight
        panelGame.Location = New Point(0, ToolStripMenuItem1.Height + 2)
        panelGame.BackColor = Color.Silver
        Me.Controls.Add(panelGame)

        panelNextShape = New Panel
        panelNextShape.Width = cubewidth * 5
        panelNextShape.Height = cubewidth * 5
        panelNextShape.Location = New Point(labelSpaceHeight, labelSpaceHeight)
        panelNextShape.BackColor = panelRight.BackColor
        panelRight.Controls.Add(panelNextShape)

        Dim lblNextShape = New Label
        lblNextShape.Font = fontStrings
        lblNextShape.Text = "NEXT SHAPE"
        lblNextShape.BackColor = panelRight.BackColor
        lblNextShape.Width = 180
        lblNextShape.Location = New Point(labelSpaceHeight, 0)
        panelRight.Controls.Add(lblNextShape)

        panelLabels = New Panel
        panelLabels.Width = panelRight.Width
        panelLabels.Height = labelSpaceHeight * 7
        panelLabels.Location = New Point(0, panelNextShape.Height + labelSpaceHeight)
        panelLabels.BackColor = panelRight.BackColor
        panelRight.Controls.Add(panelLabels)

        lblPoint = New Label
        lblPoint.Text = ""
        lblPoint.BackColor = panelNextShape.BackColor
        lblPoint.Location = New Point(labelSpaceHeight, tempSpace)
        lblPoint.Font = fontStrings
        If panelNextShape.Width > 180 Then
            lblPoint.Width = panelNextShape.Width
        Else
            lblPoint.Width = 180
        End If
        panelLabels.Controls.Add(lblPoint)

        Dim lbl1 = New Label
        lbl1.Text = "MOVE DOWN"
        lbl1.BackColor = panelRight.BackColor
        lbl1.Location = New Point(labelSpaceHeight, labelSpaceHeight * 2)
        lbl1.Font = fontStrings
        panelLabels.Controls.Add(lbl1)

        lbl1 = New Label
        lbl1.Text = "MOVE LEFT"
        lbl1.BackColor = panelRight.BackColor
        lbl1.Location = New Point(labelSpaceHeight, labelSpaceHeight * 3)
        lbl1.Font = fontStrings
        panelLabels.Controls.Add(lbl1)

        lbl1 = New Label
        lbl1.Text = "MOVE RIGHT"
        lbl1.BackColor = panelRight.BackColor
        lbl1.Location = New Point(labelSpaceHeight, labelSpaceHeight * 4)
        lbl1.Font = fontStrings
        panelLabels.Controls.Add(lbl1)

        lbl1 = New Label
        lbl1.Text = "ROTATE"
        lbl1.BackColor = panelRight.BackColor
        lbl1.Location = New Point(labelSpaceHeight, labelSpaceHeight * 5)
        lbl1.Font = fontStrings
        panelLabels.Controls.Add(lbl1)

        lbl1 = New Label
        lbl1.Text = "PAUSE"
        lbl1.BackColor = panelRight.BackColor
        lbl1.Location = New Point(labelSpaceHeight, labelSpaceHeight * 6)
        lbl1.Font = fontStrings
        panelLabels.Controls.Add(lbl1)

        lbl1 = New Label
        lbl1.Text = Char.ConvertFromUtf32(8595)
        lbl1.BackColor = panelRight.BackColor
        lbl1.Location = New Point(labelSpaceWidth, labelSpaceHeight * 2)
        lbl1.Font = fontChars
        panelLabels.Controls.Add(lbl1)

        lbl1 = New Label
        lbl1.Text = Char.ConvertFromUtf32(8594)
        lbl1.BackColor = panelRight.BackColor
        lbl1.Location = New Point(labelSpaceWidth, labelSpaceHeight * 3)
        lbl1.Font = fontChars
        panelLabels.Controls.Add(lbl1)

        lbl1 = New Label
        lbl1.Text = Char.ConvertFromUtf32(8592)
        lbl1.BackColor = panelRight.BackColor
        lbl1.Location = New Point(labelSpaceWidth, labelSpaceHeight * 4)
        lbl1.Font = fontChars
        panelLabels.Controls.Add(lbl1)

        lbl1 = New Label
        lbl1.Text = "pace"
        lbl1.BackColor = panelRight.BackColor
        lbl1.Location = New Point(labelSpaceWidth, labelSpaceHeight * 5)
        lbl1.Font = New Font("SWGamekeys MT", 15, FontStyle.Regular)
        panelLabels.Controls.Add(lbl1)

        lbl1 = New Label
        lbl1.Text = "P"
        lbl1.BackColor = panelRight.BackColor
        lbl1.Location = New Point(labelSpaceWidth, labelSpaceHeight * 6)
        lbl1.Font = New Font("SWGamekeys MT", 15, FontStyle.Regular)
        panelLabels.Controls.Add(lbl1)


        timer = New Timer()
        AddHandler timer.Tick, AddressOf Timer_Tick
    End Sub
    Private Sub SetControlsSizes()

        panelGame.Controls.Clear()
        panelNextShape.Controls.Clear()

        cubewidth = GetSelectedShapeSize()
        Me.MaximizeBox = False
        gameAreaWidth = cubewidth * 10
        gameAreaHeight = cubewidth * 20
        Me.Width = gameAreaWidth + 250

        If gameAreaHeight + ToolStripMenuItem1.Height + 30 < 300 Then
            Me.Height = 400
        Else
            Me.Height = gameAreaHeight + ToolStripMenuItem1.Height + 30
        End If

        panelRight.Width = Me.Width - gameAreaWidth
        panelRight.Height = Me.Height
        panelRight.Location = New Point(gameAreaWidth, ToolStripMenuItem1.Height + 2)

        panelGame.Width = gameAreaWidth
        panelGame.Height = gameAreaHeight
        panelGame.Location = New Point(0, ToolStripMenuItem1.Height + 2)

        panelNextShape.Width = cubewidth * 5
        panelNextShape.Height = cubewidth * 5
        panelNextShape.Location = New Point(labelSpaceHeight, labelSpaceHeight)

        panelLabels.Width = panelRight.Width
        panelLabels.Location = New Point(0, panelNextShape.Height + labelSpaceHeight)

    End Sub
    Private Function GetSelectedShapeSize() As Integer

        For Each item As ToolStripMenuItem In ShapesSizeToolStripMenuItem.DropDownItems
            If item.Checked Then
                Return Convert.ToInt32(item.Text.Substring(0, 2))
                Exit For
            End If
        Next

        Return 50
    End Function
    Private Sub StartGame()
        point = 0
        ReDim Matrix((gameAreaWidth / cubewidth) - 1, (gameAreaHeight / cubewidth) - 1)

        For index As Integer = panelGame.Controls.Count - 1 To 0 Step -1
            If panelGame.Controls.Item(index).GetType().Name = "Cube" Then
                panelGame.Controls.RemoveAt(index)
            End If
        Next

        nextShape = GetRandomShape()
        timer.Interval = (11 - currentLevel) * 100
        lblPoint.Text = "LEVEL " + currentLevel.ToString() + "  |  0"
        InsertShape()
        timer.Start()
    End Sub
    Public Sub Timer_Tick(ByVal obj As Object, ByVal e As EventArgs)
        If Not currentShape.Move_Down(currentShape) Then
            Me.FillMatrix()
            FindFullRow()
            InsertShape()
        End If
    End Sub
    Private Sub InsertShape()
        Dim point1, point2, point3, point4 As New Point
        point1 = New Point((nextShape.CubeOne.Location.X - cubewidth) + ((gameAreaWidth / cubewidth) / 2) * cubewidth, nextShape.CubeOne.Location.Y - cubewidth)
        point2 = New Point((nextShape.CubeTwo.Location.X - cubewidth) + ((gameAreaWidth / cubewidth) / 2) * cubewidth, nextShape.CubeTwo.Location.Y - cubewidth)
        point3 = New Point((nextShape.CubeThree.Location.X - cubewidth) + ((gameAreaWidth / cubewidth) / 2) * cubewidth, nextShape.CubeThree.Location.Y - cubewidth)
        point4 = New Point((nextShape.CubeFour.Location.X - cubewidth) + ((gameAreaWidth / cubewidth) / 2) * cubewidth, nextShape.CubeFour.Location.Y - cubewidth)

        If IsGameOver(point1, point2, point3, point4) Then
            timer.Stop()
            WriteScoreToTxt()
            If MessageBox.Show("GAME OVER ! YOUR SCORE IS : " + point.ToString() + Environment.NewLine + Environment.NewLine + "DO YOU WANT TO PLAY AGAIN?", "GAME OVER", MessageBoxButtons.YesNo) = vbYes Then
                StartGame()
            End If
        Else
            currentShape = nextShape
            panelNextShape.Controls.Clear()
            currentShape.CubeOne.Location = point1
            currentShape.CubeTwo.Location = point2
            currentShape.CubeThree.Location = point3
            currentShape.CubeFour.Location = point4
            nextShape = GetRandomShape()
            currentShape.Draw(panelGame)
            nextShape.Draw(panelNextShape)
        End If
    End Sub
    Private Function GetRandomColor() As Color
        Dim randomColor As New Color

        Select Case GetRandomNumber(1, 5)
            Case 1
                randomColor = Color.Red
                Exit Select
            Case 2
                randomColor = Color.Yellow
                Exit Select
            Case 3
                randomColor = Color.Purple
                Exit Select
            Case 4
                randomColor = Color.LimeGreen
                Exit Select
        End Select

        Return randomColor
    End Function
    Private Function GetRandomShape() As Shape
        Dim randomshape As Shape
        Select Case GetRandomNumber(1, 8)
            Case 1
                randomshape = New ShapeI(cubewidth, cubewidth, cubewidth, Me.GetRandomColor(), GetRandomNumber(1, 5), Me.Matrix)
                Exit Select
            Case 2
                randomshape = New ShapeJ(cubewidth, cubewidth, cubewidth, Me.GetRandomColor(), GetRandomNumber(1, 5), Me.Matrix)
                Exit Select
            Case 3
                randomshape = New ShapeL(cubewidth, cubewidth, cubewidth, Me.GetRandomColor(), GetRandomNumber(1, 5), Me.Matrix)
                Exit Select
            Case 4
                randomshape = New ShapeS(cubewidth, cubewidth, cubewidth, Me.GetRandomColor(), GetRandomNumber(1, 5), Me.Matrix)
                Exit Select
            Case 5
                randomshape = New ShapeSquare(cubewidth, cubewidth, cubewidth, Me.GetRandomColor(), GetRandomNumber(1, 5), Me.Matrix)
                Exit Select
            Case 6
                randomshape = New ShapeT(cubewidth, cubewidth, cubewidth, Me.GetRandomColor(), GetRandomNumber(1, 5), Me.Matrix)
                Exit Select
            Case 7
                randomshape = New ShapeZ(cubewidth, cubewidth, cubewidth, Me.GetRandomColor(), GetRandomNumber(1, 5), Me.Matrix)
                Exit Select
        End Select

        Return randomshape
    End Function
    Private Function GetRandomNumber(ByVal minValue As Integer, ByVal maxValue As Integer) As Integer
        If minValue < maxValue Then
            Dim randomInt As New Random()
            Dim time As Integer = Date.Now.Hour + Date.Now.Minute + Date.Now.Millisecond
            Return (time Mod randomInt.Next(minValue, maxValue)) + 1
        End If
    End Function
    Public Sub FindFullRow()
        Dim isfull As Boolean = False
        clearedrow = 0
        Dim x As Integer
        For columnindex As Integer = (Matrix.GetUpperBound(1)) To Matrix.GetLowerBound(1) Step -1
            isfull = True

            For rowindex As Integer = Matrix.GetLowerBound(0) To Matrix.GetUpperBound(0)

                If Matrix(rowindex, columnindex) Is Nothing Then
                    isfull = False
                    Exit For
                End If
            Next

            If isfull Then
                ClearRow(columnindex)
                x = columnindex
                clearedrow += 1
                CalculatePoint()
            Else
                Continue For
            End If
        Next

        If clearedrow > 0 Then
            timer.Stop()
            RowsMoveDown(x)
            IncreaseLevel()
            timer.Start()
        End If
    End Sub
    Public Sub ClearRow(ByVal rowindex As Integer)
        For columnindex As Integer = Matrix.GetLowerBound(0) To Matrix.GetUpperBound(0)
            If Me.Matrix(columnindex, rowindex) IsNot Nothing Then
                panelGame.Controls.Remove(CType(Me.Matrix(columnindex, rowindex), Cube))
                Me.Matrix(columnindex, rowindex) = Nothing
            End If
        Next
    End Sub
    Public Sub RowsMoveDown(ByVal clearedrowindex As Integer)
        'For rowindex As Integer = clearedrowindex - 1 To Matrix.GetLowerBound(1) Step -1
        '    For columnindex As Integer = Matrix.GetLowerBound(0) To Matrix.GetUpperBound(0)
        '        If Me.Matrix(columnindex, rowindex) IsNot Nothing Then
        '            'Me.Controls.Remove(CType(Me.Matrix(columnindex, rowindex), Cube))
        '            'Me.Matrix(columnindex, rowindex) = Nothing
        '            For bottompoint As Integer = Matrix.GetUpperBound(1) To clearedrowindex Step -1
        '                If Me.Matrix(columnindex, bottompoint) Is Nothing Then
        '                    Me.Matrix(columnindex, rowindex).Location = New Point(columnindex * cubewidth, bottompoint * cubewidth)
        '                    Me.Matrix(columnindex, bottompoint) = Me.Matrix(columnindex, rowindex)
        '                    'Me.Controls.Remove(CType(Me.Matrix(columnindex, rowindex), Cube))
        '                    Me.Matrix(columnindex, rowindex) = Nothing
        '                    Threading.Thread.Sleep(100)
        '                    Exit For
        '                End If
        '            Next
        '        End If
        '    Next
        'Next
        For rowindex As Integer = clearedrowindex - 1 To Matrix.GetLowerBound(1) Step -1
            For columnindex As Integer = Matrix.GetLowerBound(0) To Matrix.GetUpperBound(0)
                If Not Me.Matrix(columnindex, rowindex) Is Nothing Then
                    Me.Matrix(columnindex, rowindex).Location = New Point(columnindex * cubewidth, (rowindex + clearedrow) * cubewidth)
                    Me.Matrix(columnindex, rowindex + clearedrow) = Me.Matrix(columnindex, rowindex)
                    Me.Matrix(columnindex, rowindex) = Nothing
                Else
                    'Me.Matrix(columnindex, rowindex - 1) = Nothing
                End If
            Next
            Threading.Thread.Sleep(50)
        Next
    End Sub
    Public Sub CalculatePoint()
        point += (100 * currentLevel * clearedrow)
        pointThisLevel = point
    End Sub
    Private Sub IncreaseLevel()
        'If point >= (currentLevel * (currentLevel + 1) * 1000) - ((currentLevel - selectedLevel) * 1000) Then
        '    currentLevel += 1
        'End If
        If pointThisLevel > currentLevel * 2000 Then
            currentLevel += 1
            pointThisLevel = 0
        End If


        If currentLevel > 10 And currentLevel < 20 Then
            timer.Interval = (20 - currentLevel) * 10
        Else
            timer.Interval = (11 - currentLevel) * 100
        End If

        lblPoint.Text = "LEVEL " + currentLevel.ToString() + "  |  " + point.ToString()
    End Sub
    Public Sub PlayPause()
        If timer.Enabled Then
            timer.Stop()

            Dim frm As PauseScreen = New PauseScreen()
            frm.Opacity = 0.7
            frm.Height = Me.Height - 25
            frm.Width = Me.Width - 5
            frm.Location = New Point(Me.Location.X + 3, Me.Location.Y + MenuStrip1.Height)
            frm.StartPosition = FormStartPosition.Manual
            frm.ShowDialog()

            timer.Start()
        End If
    End Sub
    Private Sub FillMatrix()
        For Each item As Cube In Me.currentShape.Cubes
            Me.Matrix(item.IndexX, item.IndexY) = item
        Next
    End Sub
    Public Function IsGameOver(ByVal p1 As Point, ByVal p2 As Point, ByVal p3 As Point, ByVal p4 As Point) As Boolean
        If Matrix(p1.X / cubewidth, p1.Y / cubewidth) IsNot Nothing Or Matrix(p2.X / cubewidth, p2.Y / cubewidth) IsNot Nothing _
        Or Matrix(p3.X / cubewidth, p3.Y / cubewidth) IsNot Nothing Or Matrix(p4.X / cubewidth, p4.Y / cubewidth) IsNot Nothing _
        Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub WriteScoreToTxt()
        Dim sw As StreamWriter
        Dim newtext As String
        ReadScoresFromTxt()

        Select Case selectedLevel
            Case Level.Easy
                If ScoreEasy < point Then
                    ScoreEasy = point
                End If
                Exit Select
            Case Level.Medium
                If ScoreMedium < point Then
                    ScoreMedium = point
                End If
                Exit Select
            Case Level.Hard
                If ScoreHard < point Then
                    ScoreHard = point
                End If
                Exit Select
            Case Level.Expert
                If ScoreExpert < point Then
                    ScoreExpert = point
                End If
                Exit Select
        End Select

        newtext = ScoreExpert.ToString() + "," + "Expert" + "-"
        newtext += ScoreHard.ToString() + "," + "Hard" + "-"
        newtext += ScoreMedium.ToString() + "," + "Medium" + "-"
        newtext += ScoreEasy.ToString() + "," + "Easy" + "-"

        If File.Exists(path) Then
            File.WriteAllText(path, newtext)
        Else
            sw = File.CreateText(path)
            sw.Write(newtext)
            sw.Close()
        End If
    End Sub
    Public Sub ReadScoresFromTxt()
        If IO.File.Exists(Me.path) Then
            Dim sr As IO.StreamReader = New IO.StreamReader(Me.path)
            Dim text As String = sr.ReadToEnd()
            sr.Close()
            text = text.Substring(0, text.Length - 1)

            For Each str2 As String In text.Split("-")
                Select Case str2.Split(",")(1).ToString()
                    Case "Easy"
                        ScoreEasy = str2.Split(",")(0).ToString()
                        Exit Select
                    Case "Medium"
                        ScoreMedium = str2.Split(",")(0).ToString()
                        Exit Select
                    Case "Hard"
                        ScoreHard = str2.Split(",")(0).ToString()
                        Exit Select
                    Case "Expert"
                        ScoreExpert = str2.Split(",")(0).ToString()
                        Exit Select
                End Select
            Next
        Else
            ScoreEasy = 0
            ScoreExpert = 0
            ScoreHard = 0
            ScoreMedium = 0
        End If
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Right Then
            currentShape.Move_Right(currentShape)
            Exit Sub
        ElseIf e.KeyCode = Keys.Left Then
            currentShape.Move_Left(currentShape)
            Exit Sub
        ElseIf e.KeyCode = Keys.Down Then
            currentShape.Move_Down(currentShape)
            Exit Sub
        ElseIf e.KeyCode = Keys.Space Then
            currentShape.Rotate()
        ElseIf e.KeyCode = Keys.P Then
            PlayPause()
        End If

    End Sub
    Private Sub ToolStripMenuItem1_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStripMenuItem1.DropDownItemClicked
        If e.ClickedItem.Name = "Easy" Then
            currentLevel = Level.Easy
            selectedLevel = currentLevel
        ElseIf e.ClickedItem.Name = "Medium" Then
            currentLevel = Level.Medium
            selectedLevel = currentLevel
        ElseIf e.ClickedItem.Name = "Hard" Then
            currentLevel = Level.Hard
            selectedLevel = currentLevel
        ElseIf e.ClickedItem.Name = "Expert" Then
            currentLevel = Level.Expert
            selectedLevel = currentLevel
        End If

        StartGame()
    End Sub
    Private Sub Game_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Game.DropDownItemClicked
        If e.ClickedItem.Name = "High" Then

            If timer.Enabled Then
                timer.Stop()
                Dim form As HighScores = New HighScores
                form.ShowDialog()
                timer.Start()
            Else
                Dim form As HighScores = New HighScores
                form.ShowDialog()
            End If
        ElseIf e.ClickedItem.Name = "Quit" Then
            Try
                Me.Close()
            Catch
            End Try
        End If
    End Sub
    Private Sub About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles About.Click
        If timer.Enabled Then
            timer.Stop()
            MessageBox.Show("Tetris 1.0" + Environment.NewLine + Environment.NewLine + "Developed by Gürçağ", "About")
            timer.Start()
        Else
            MessageBox.Show("Tetris 1.0" + Environment.NewLine + Environment.NewLine + "Developed by Gürçağ", "About")
        End If
    End Sub
    Private Enum Level As Integer
        Easy = 1
        Medium = 4
        Hard = 7
        Expert = 10
    End Enum

    Private Sub ShapesSizeToolStripMenuItem_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ShapesSizeToolStripMenuItem.DropDownItemClicked
        If ShapesSizeToolStripMenuItem.Enabled Then
            Dim selectedItem As New ToolStripMenuItem
            selectedItem = e.ClickedItem

            If selectedItem.Checked Then
                Exit Sub
            End If

            For Each item As ToolStripMenuItem In ShapesSizeToolStripMenuItem.DropDownItems
                If e.ClickedItem IsNot item Then
                    item.Checked = False
                Else
                    item.Checked = True
                End If
            Next

            cubewidth = Convert.ToInt32(selectedItem.Text.Substring(0, 2))
            SetControlsSizes()
        End If
    End Sub

    Private Sub Game_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Game.Click

        If timer.Enabled Then
            ShapesSizeToolStripMenuItem.Enabled = False
        Else
            ShapesSizeToolStripMenuItem.Enabled = True
        End If

    End Sub
End Class
