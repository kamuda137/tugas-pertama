Imports MySql.Data.MySqlClient
Imports System.Data
Public Class Formbuku
    Dim conn As New KoneksiDatabase
    Sub tampil()
        Dim mycom As New MySqlCommand
        Dim myadap As New MySqlDataAdapter
        Dim mydata As New DataTable
        Dim sql As String
        sql = "SELECT * FROM tb_buku"

        mycom.Connection = conn.koneksi
        mycom.CommandText = sql
        myadap.SelectCommand = mycom
        myadap.Fill(mydata)
        DataGridView1.DataSource = mydata
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan

    End Sub
    Sub bersih()
        txtkdb.Text = ""
        txtj.Text = ""
        txtkdps.Text = ""
        txtkdpb.Text = ""
        txttp.Text = ""
        txtjh.Text = ""

    End Sub

    Private Sub Formbuku_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil()
    End Sub

    Private Sub btna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btna.Click
        Dim mycom As New MySqlCommand
        Dim sql As String
        Dim hasil As Integer
        sql = "INSERT INTO tb_buku (kodebuku,judulbuku,kodepenulis,kodepenerbit,tahunpenerbit,jumlahhalaman) values(@kodebuku,@judulbuku,@kodepenulis,@kodepenerbit,@tahunpenerbit,@jumlahhalaman) "
        Try
            mycom.Connection = conn.koneksi
            mycom.CommandText = sql
            mycom.Parameters.Add("@kodebuku", MySqlDbType.String, 9).Value = txtkdb.Text
            mycom.Parameters.Add("@judulbuku", MySqlDbType.String, 30).Value = txtj.Text
            mycom.Parameters.Add("@kodepenulis", MySqlDbType.String, 9).Value = txtkdps.Text
            mycom.Parameters.Add("@kodepenerbit", MySqlDbType.String, 9).Value = txtkdpb.Text
            mycom.Parameters.Add("@tahunpenerbit", MySqlDbType.String, 4).Value = txttp.Text
            mycom.Parameters.Add("@jumlahhalaman", MySqlDbType.String, 4).Value = txtjh.Text
            If MessageBox.Show("Yakin data ditambahkan", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                hasil = mycom.ExecuteNonQuery
            Else
                hasil = 0
            End If

            If hasil > 0 Then
                MessageBox.Show("Record Berhasil ditambahkan", "Biodata", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call bersih()
                Call tampil()
            End If
        Catch ex As Exception
        Finally
            mycom.Dispose()
            conn.koneksi.Close()
        End Try
    End Sub

    Private Sub btne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btne.Click
        Dim mycom As New MySqlCommand
        Dim sql As String
        Dim hasil As Integer
        sql = "UPDATE tb_buku SET kodebuku=@kodebuku,judulbuku=@judulbuku,kodepenulis=@kodepenulis,kodepenerbit=@kodepenerbit,tahunpenerbit=@tahunpenerbit,jumlahhalaman=@jumlahhalaman WHERE kodebuku='" & txtkdb.Text & "'"
        Try
            mycom.Connection = conn.koneksi
            mycom.CommandText = sql
            mycom.Parameters.Add("@kodebuku", MySqlDbType.String, 9).Value = txtkdb.Text
            mycom.Parameters.Add("@judulbuku", MySqlDbType.String, 30).Value = txtj.Text
            mycom.Parameters.Add("@kodepenulis", MySqlDbType.String, 9).Value = txtkdps.Text
            mycom.Parameters.Add("@kodepenerbit", MySqlDbType.String, 9).Value = txtkdpb.Text
            mycom.Parameters.Add("@tahunpenerbit", MySqlDbType.String, 4).Value = txttp.Text
            mycom.Parameters.Add("@jumlahhalaman", MySqlDbType.String, 4).Value = txtjh.Text
            hasil = mycom.ExecuteNonQuery()
            If hasil > 0 Then
                MessageBox.Show("Record Berhasil diubah", "Biodata", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtkdb.Text = ""
                txtj.Text = ""
                txtkdps.Text = ""
                txtkdpb.Text = ""
                txttp.Text = ""
                txtjh.Text = ""
                txtkdb.Focus()
                Call tampil()
            End If
        Catch ex As Exception
        Finally
            mycom.Dispose()
            conn.koneksi.Close()
        End Try
    End Sub

    Private Sub btns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btns.Click
        Dim mycom_cari As New MySqlCommand
        Dim cari As MySqlDataReader
        Dim query As String
        query = "SELECT kodebuku,judulbuku,kodepenulis,kodepenerbit,tahunpenerbit,jumlahhalaman FROM tb_buku WHERE kodeanggota= '" & txtkdb.Text & "'"
        Try
            mycom_cari.Connection = conn.koneksi
            mycom_cari.CommandText = query
            cari = mycom_cari.ExecuteReader
            If cari.Read() Then
                txtkdb.Text = cari.GetString(1)
                txtj.Text = cari.GetString(2)
                txtkdps.Text = cari.GetString(3)
                txtkdpb.Text = cari.GetString(4)
                txttp.Text = cari.GetString(5)
                txtjh.Text = cari.GetString(6)
            End If
        Catch ex As Exception

        End Try
        mycom_cari.Dispose()
    End Sub

    Private Sub btnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnc.Click
        Application.Exit()
    End Sub
End Class