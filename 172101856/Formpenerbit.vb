Imports MySql.Data.MySqlClient
Imports System.Data
Public Class Formpenerbit
    Dim conn As New koneksiDatabase
    Sub tampil()
        Dim mycom As New MySqlCommand
        Dim myadap As New MySqlDataAdapter
        Dim mydata As New DataTable
        Dim sql As String
        sql = "SELECT * FROM tb_penerbit"

        mycom.Connection = conn.koneksi
        mycom.CommandText = sql
        myadap.SelectCommand = mycom
        myadap.Fill(mydata)
        DataGridView1.DataSource = mydata
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan

    End Sub
    Sub bersih()
        txtkdpb.Text = ""
        txtnpb.Text = ""
        txtapb.Text = ""
        txtkpb.Text = ""
        txtepb.Text = ""
    End Sub
    Private Sub Formpenerbit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil()
    End Sub

    Private Sub btnapb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnapb.Click
        Dim mycom As New MySqlCommand
        Dim sql As String
        Dim hasil As Integer
        sql = "INSERT INTO tb_penerbit (kodepenerbit,namapenerbit,alamatpenerbit,kontak,emailpenerbit) values(@kodepenerbit,@namapenerbit,@alamatpenerbit,@kontak,@emailpenerbit) "
        Try
            mycom.Connection = conn.koneksi
            mycom.CommandText = sql
            mycom.Parameters.Add("@kodepenerbit", MySqlDbType.String, 9).Value = txtkdpb.Text
            mycom.Parameters.Add("@namapenerbit", MySqlDbType.String, 30).Value = txtnpb.Text
            mycom.Parameters.Add("@alamatpenerbit", MySqlDbType.String, 30).Value = txtapb.Text
            mycom.Parameters.Add("@kontak", MySqlDbType.String, 15).Value = txtkpb.Text
            mycom.Parameters.Add("@emailpenerbit", MySqlDbType.String, 30).Value = txtepb.Text
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

    Private Sub btnepb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnepb.Click
        Dim mycom As New MySqlCommand
        Dim sql As String
        Dim hasil As Integer
        sql = "UPDATE tb_penerbit SET kodepenerbit=@kodepenerbit,namapenerbit=@namapenerbit,alamatpenerbit=@alamatpenerbit,kontak=@kontak,emailpenerbit=@emailpenerbit WHERE kodepenerbit='" & txtkdpb.Text & "'"
        Try
            mycom.Connection = conn.koneksi
            mycom.CommandText = sql
            mycom.Parameters.Add("@kodepenerbit", MySqlDbType.String, 9).Value = txtkdpb.Text
            mycom.Parameters.Add("@namapenerbit", MySqlDbType.String, 30).Value = txtnpb.Text
            mycom.Parameters.Add("@alamatpenerbit", MySqlDbType.String, 30).Value = txtapb.Text
            mycom.Parameters.Add("@kontak", MySqlDbType.String, 15).Value = txtkpb.Text
            mycom.Parameters.Add("@emailpenerbit", MySqlDbType.String, 30).Value = txtepb.Text
            hasil = mycom.ExecuteNonQuery()
            If hasil > 0 Then
                MessageBox.Show("Record Berhasil diubah", "Biodata", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtkdpb.Text = ""
                txtnpb.Text = ""
                txtapb.Text = ""
                txtkpb.Text = ""
                txtepb.Text = ""
                txtkdpb.Focus()
                Call tampil()
            End If
        Catch ex As Exception
        Finally
            mycom.Dispose()
            conn.koneksi.Close()
        End Try
    End Sub

    Private Sub btnspb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnspb.Click
        Dim mycom_cari As New MySqlCommand
        Dim cari As MySqlDataReader
        Dim query As String
        query = "SELECT kodepenerbit,namapenerbit,alamatpenerbit,kontak,emailpenerbit FROM tb_penerbit WHERE kodepenerbit= '" & txtkdpb.Text & "'"
        Try
            mycom_cari.Connection = conn.koneksi
            mycom_cari.CommandText = query
            cari = mycom_cari.ExecuteReader
            If cari.Read() Then
                txtnpb.Text = cari.GetString(1)
                txtapb.Text = cari.GetString(2)
                txtkpb.Text = cari.GetString(3)
                txtepb.Text = cari.GetString(4)
            End If
        Catch ex As Exception

        End Try
        mycom_cari.Dispose()
    End Sub

    Private Sub btncpb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncpb.Click
        Application.Exit()
    End Sub
End Class