Imports MySql.Data.MySqlClient
Imports System.Data
Public Class Formpenulis
    Dim conn As New KoneksiDatabase
    Sub tampil()
        Dim mycom As New MySqlCommand
        Dim myadap As New MySqlDataAdapter
        Dim mydata As New DataTable
        Dim sql As String
        sql = "SELECT * FROM tb_penulis"

        mycom.Connection = conn.koneksi
        mycom.CommandText = sql
        myadap.SelectCommand = mycom
        myadap.Fill(mydata)
        DataGridView1.DataSource = mydata
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan

    End Sub
    Sub bersih()
        txtkdps.Text = ""
        txtnps.Text = ""
        txtaps.Text = ""
        txtkps.Text = ""
        txteps.Text = ""
    End Sub

    Private Sub btnaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaps.Click
        Dim mycom As New MySqlCommand
        Dim sql As String
        Dim hasil As Integer
        sql = "INSERT INTO tb_penulis (kodepenulis,namapenulis,alamatpenulis,kontak,emailpenulis) values(@kodepenulis,@namapenulis,@alamatpenulis,@kontak,@emailpenulis) "
        Try
            mycom.Connection = conn.koneksi
            mycom.CommandText = sql
            mycom.Parameters.Add("@kodepenulis", MySqlDbType.String, 9).Value = txtkdps.Text
            mycom.Parameters.Add("@namapenulis", MySqlDbType.String, 30).Value = txtnps.Text
            mycom.Parameters.Add("@alamatpenulis", MySqlDbType.String, 30).Value = txtaps.Text
            mycom.Parameters.Add("@kontak", MySqlDbType.String, 15).Value = txtkps.Text
            mycom.Parameters.Add("@emailpenulis", MySqlDbType.String, 30).Value = txteps.Text
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

    Private Sub btneps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneps.Click
        Dim mycom As New MySqlCommand
        Dim sql As String
        Dim hasil As Integer
        sql = "UPDATE tb_penulis SET kodepenulis=@kodepenulis,namapenulis=@namapenulis,alamatpenulis=@alamatpenulis,kontak=@kontak,emailpenulis=@emailpenulis WHERE kodepenulis='" & txtkdps.Text & "'"
        Try
            mycom.Connection = conn.koneksi
            mycom.CommandText = sql
            mycom.Parameters.Add("@kodepenulis", MySqlDbType.String, 9).Value = txtkdps.Text
            mycom.Parameters.Add("@namapenulis", MySqlDbType.String, 30).Value = txtnps.Text
            mycom.Parameters.Add("@alamatpenulis", MySqlDbType.String, 30).Value = txtaps.Text
            mycom.Parameters.Add("@kontak", MySqlDbType.String, 15).Value = txtkps.Text
            mycom.Parameters.Add("@emailpenulis", MySqlDbType.String, 30).Value = txteps.Text
            hasil = mycom.ExecuteNonQuery()
            If hasil > 0 Then
                MessageBox.Show("Record Berhasil diubah", "Biodata", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtkdps.Text = ""
                txtnps.Text = ""
                txtaps.Text = ""
                txtkps.Text = ""
                txteps.Text = ""
                txtkdps.Focus()
                Call tampil()
            End If
        Catch ex As Exception
        Finally
            mycom.Dispose()
            conn.koneksi.Close()
        End Try
    End Sub

    Private Sub btnsps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsps.Click
        Dim mycom_cari As New MySqlCommand
        Dim cari As MySqlDataReader
        Dim query As String
        query = "SELECT kodepenulis,namapenulis,alamatpenulis,kontak,emailpenulis FROM tb_penulis WHERE kodepenulis= '" & txtkdps.Text & "'"
        Try
            mycom_cari.Connection = conn.koneksi
            mycom_cari.CommandText = query
            cari = mycom_cari.ExecuteReader
            If cari.Read() Then
                txtnps.Text = cari.GetString(1)
                txtaps.Text = cari.GetString(2)
                txtkps.Text = cari.GetString(3)
                txteps.Text = cari.GetString(4)
            End If
        Catch ex As Exception

        End Try
        mycom_cari.Dispose()
    End Sub

    Private Sub btncps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncps.Click
        Application.Exit()
    End Sub
    Private Sub Formpenulis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil()
    End Sub
End Class