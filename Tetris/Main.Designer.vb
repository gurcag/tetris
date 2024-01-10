<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.Game = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Easy = New System.Windows.Forms.ToolStripMenuItem
        Me.Medium = New System.Windows.Forms.ToolStripMenuItem
        Me.Hard = New System.Windows.Forms.ToolStripMenuItem
        Me.Expert = New System.Windows.Forms.ToolStripMenuItem
        Me.ShapesSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShapeSize10 = New System.Windows.Forms.ToolStripMenuItem
        Me.ShapeSize20 = New System.Windows.Forms.ToolStripMenuItem
        Me.ShapeSize30 = New System.Windows.Forms.ToolStripMenuItem
        Me.ShapeSize40 = New System.Windows.Forms.ToolStripMenuItem
        Me.High = New System.Windows.Forms.ToolStripMenuItem
        Me.Quit = New System.Windows.Forms.ToolStripMenuItem
        Me.About = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Game, Me.About})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(354, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Game
        '
        Me.Game.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ShapesSizeToolStripMenuItem, Me.High, Me.Quit})
        Me.Game.Name = "Game"
        Me.Game.Size = New System.Drawing.Size(50, 20)
        Me.Game.Text = "Game"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Easy, Me.Medium, Me.Hard, Me.Expert})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem1.Text = "New Game"
        '
        'Easy
        '
        Me.Easy.Name = "Easy"
        Me.Easy.Size = New System.Drawing.Size(119, 22)
        Me.Easy.Text = "Easy"
        '
        'Medium
        '
        Me.Medium.Name = "Medium"
        Me.Medium.Size = New System.Drawing.Size(119, 22)
        Me.Medium.Text = "Medium"
        '
        'Hard
        '
        Me.Hard.Name = "Hard"
        Me.Hard.Size = New System.Drawing.Size(119, 22)
        Me.Hard.Text = "Hard"
        '
        'Expert
        '
        Me.Expert.Name = "Expert"
        Me.Expert.Size = New System.Drawing.Size(119, 22)
        Me.Expert.Text = "Expert"
        '
        'ShapesSizeToolStripMenuItem
        '
        Me.ShapesSizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShapeSize10, Me.ShapeSize20, Me.ShapeSize30, Me.ShapeSize40})
        Me.ShapesSizeToolStripMenuItem.Name = "ShapesSizeToolStripMenuItem"
        Me.ShapesSizeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ShapesSizeToolStripMenuItem.Text = "Shape Size"
        '
        'ShapeSize10
        '
        Me.ShapeSize10.Name = "ShapeSize10"
        Me.ShapeSize10.Size = New System.Drawing.Size(152, 22)
        Me.ShapeSize10.Text = "10 Pixels"
        '
        'ShapeSize20
        '
        Me.ShapeSize20.Name = "ShapeSize20"
        Me.ShapeSize20.Size = New System.Drawing.Size(152, 22)
        Me.ShapeSize20.Text = "20 Pixels"
        '
        'ShapeSize30
        '
        Me.ShapeSize30.Checked = True
        Me.ShapeSize30.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShapeSize30.Name = "ShapeSize30"
        Me.ShapeSize30.Size = New System.Drawing.Size(152, 22)
        Me.ShapeSize30.Text = "30 Pixels"
        '
        'ShapeSize40
        '
        Me.ShapeSize40.Name = "ShapeSize40"
        Me.ShapeSize40.Size = New System.Drawing.Size(152, 22)
        Me.ShapeSize40.Text = "40 Pixels"
        '
        'High
        '
        Me.High.Name = "High"
        Me.High.Size = New System.Drawing.Size(152, 22)
        Me.High.Text = "High Scores"
        '
        'Quit
        '
        Me.Quit.Name = "Quit"
        Me.Quit.Size = New System.Drawing.Size(152, 22)
        Me.Quit.Text = "Quit"
        '
        'About
        '
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(52, 20)
        Me.About.Text = "About"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(354, 316)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Main"
        Me.ShowIcon = False
        Me.Text = "Tetris"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Game As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Easy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Medium As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Hard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Expert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents High As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Quit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShapesSizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShapeSize10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShapeSize20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShapeSize30 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShapeSize40 As System.Windows.Forms.ToolStripMenuItem

End Class
