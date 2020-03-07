Public Class Form1

    Private Sub btnps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnps.Click
        Formpenulis.StartPosition = FormStartPosition.CenterScreen
        Formpenulis.Show()
    End Sub

    Private Sub btnpb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpb.Click
        Formpenerbit.StartPosition = FormStartPosition.CenterScreen
        Formpenerbit.Show()
    End Sub

    Private Sub btnb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnb.Click
        Formbuku.StartPosition = FormStartPosition.CenterScreen
        Formbuku.Show()
    End Sub

    Private Sub btna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btna.Click
        Formanggota.StartPosition = FormStartPosition.CenterScreen
        Formanggota.Show()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Application.Exit()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class