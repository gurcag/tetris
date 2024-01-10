Public Class HighScores

    Private Sub HighScores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main.ReadScoresFromTxt()
        lbl_expert.Text = Main.ScoreExpert.ToString()
        lbl_hard.Text = Main.ScoreHard.ToString()
        lbl_medium.Text = Main.ScoreMedium.ToString()
        lbl_easy.Text = Main.ScoreEasy.ToString()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If IO.File.Exists(Main.path) Then
            Try
                IO.File.Delete(Main.path)
                lbl_expert.Text = "0"
                lbl_hard.Text = "0"
                lbl_medium.Text = "0"
                lbl_easy.Text = "0"
            Catch
            End Try
        End If

    End Sub
End Class