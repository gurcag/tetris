<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HighScores
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_expert = New System.Windows.Forms.Label
        Me.lbl_hard = New System.Windows.Forms.Label
        Me.lbl_medium = New System.Windows.Forms.Label
        Me.lbl_easy = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "High Scores"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Expert"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Hard"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Medium"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Easy"
        '
        'lbl_expert
        '
        Me.lbl_expert.Location = New System.Drawing.Point(114, 46)
        Me.lbl_expert.Name = "lbl_expert"
        Me.lbl_expert.Size = New System.Drawing.Size(63, 13)
        Me.lbl_expert.TabIndex = 0
        Me.lbl_expert.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_hard
        '
        Me.lbl_hard.Location = New System.Drawing.Point(121, 83)
        Me.lbl_hard.Name = "lbl_hard"
        Me.lbl_hard.Size = New System.Drawing.Size(56, 13)
        Me.lbl_hard.TabIndex = 0
        Me.lbl_hard.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_medium
        '
        Me.lbl_medium.Location = New System.Drawing.Point(107, 120)
        Me.lbl_medium.Name = "lbl_medium"
        Me.lbl_medium.Size = New System.Drawing.Size(70, 13)
        Me.lbl_medium.TabIndex = 0
        Me.lbl_medium.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_easy
        '
        Me.lbl_easy.Location = New System.Drawing.Point(104, 156)
        Me.lbl_easy.Name = "lbl_easy"
        Me.lbl_easy.Size = New System.Drawing.Size(73, 13)
        Me.lbl_easy.TabIndex = 1
        Me.lbl_easy.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(66, 194)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(62, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Reset"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'HighScores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(189, 229)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbl_easy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_medium)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_hard)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_expert)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "HighScores"
        Me.Text = "High Scores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_expert As System.Windows.Forms.Label
    Friend WithEvents lbl_hard As System.Windows.Forms.Label
    Friend WithEvents lbl_medium As System.Windows.Forms.Label
    Friend WithEvents lbl_easy As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
