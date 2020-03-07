Imports MySql.Data.MySqlClient
Imports System.Data
Public Class Formanggota
    Dim conn As New KoneksiDatabase
    Sub tampil()
        Dim mycom As New MySqlCommand
        Dim myadap As New MySqlDataAdapter
        Dim mydata As New DataTable
        Dim sql As String
        sql = "SELECT * FROM tb_anggota"

        mycom.Connection = conn.koneksi
        mycom.CommandText = sql
        myadap.SelectCommand = mycom
        myadap.Fill(mydata)
        DataGridView1.DataSource = mydata
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan

    End Sub
    Sub bersih()
        txtkd.Text = ""
        txtn.Text = ""
        txta.Text = ""
        txtk.Text = ""
        txte.Text = ""
    End Sub

    Private Sub btna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btna.Click
        Dim mycom As New MySqlCommand
        Dim sql As String
        Dim hasil As Integer
        sql = "INSERT INTO tb_anggota (kodeanggota,namaanggota,alamat,kontak,email) values(@kodeanggota,@namaanggota,@alamat,@kontak,@email) "
        Try
            mycom.Connection = conn.koneksi
            mycom.CommandText = sql
            mycom.Parameters.Add("@kodeanggota", MySqlDbType.String, 9).Value = txtkd.Text
            mycom.Parameters.Add("@namaanggota", MySqlDbType.String, 30).Value = txtn.Text
            mycom.Parameters.Add("@alamat", MySqlDbType.String, 30).Value = txta.Text
            mycom.Parameters.Add("@kontak", MySqlDbType.String, 15).Value = txtk.Text
            mycom.Parameters.Add("@email", MySqlDbType.String, 30).Value = txte.Text
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
        sql = "UPDATE tb_anggota SET kodeanggota=@kodeanggota,namaanggota=@namaanggota,alamat=@alamat,kontak=@kontak,email=@email WHERE kodeanggota='" & txtkd.Text & "'"
        Try
            mycom.Connection = conn.koneksi
            mycom.CommandText = sql
            mycom.Parameters.Add("@kodeanggota", MySqlDbType.String, 9).Value = txtkd.Text
            mycom.Parameters.Add("@namaanggota", MySqlDbType.String, 30).Value = txtn.Text
            mycom.Parameters.Add("@alamat", MySqlDbType.String, 30).Value = txta.Text
            mycom.Parameters.Add("@kontak", MySqlDbType.String, 15).Value = txtk.Text
            mycom.Parameters.Add("@email", MySqlDbType.String, 30).Value = txte.Text
            hasil = mycom.ExecuteNonQuery()
            If hasil > 0 Then
                MessageBox.Show("Record Berhasil diubah", "Biodata", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtkd.Text = ""
                txtn.Text = ""
                txta.Text = ""
                txtk.Text = ""
                txte.Text = ""
                txtkd.Focus()
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
        query = "SELECT kodeanggota,namaanggota,alamat,kontak,email FROM tb_anggota WHERE kodeanggota= '" & txtkd.Text & "'"
        Try
            mycom_cari.Connection = conn.koneksi
            mycom_cari.CommandText = query
            cari = mycom_cari.ExecuteReader
            If cari.Read() Then
                txtn.Text = cari.GetString(1)
                txta.Text = cari.GetString(2)
                txtk.Text = cari.GetString(3)
                txte.Text = cari.GetString(4)
            End If
        Catch ex As Exception

        End Try
        mycom_cari.Dispose()
    End Sub

    Private Sub btnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnc.Click
        Application.Exit()
    End Sub

    Private Sub Formanggota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil()
    End Sub
End Class