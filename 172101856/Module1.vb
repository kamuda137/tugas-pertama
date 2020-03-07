Imports MySql.Data.MySqlClient
Imports System.Data
Public Class koneksiDatabase
    Private conn As MySqlConnection = Nothing
    Public Function koneksi() As MySqlConnection
        Dim connString As String
        connString = ";server=localhost" & ";user=root" & ";password=''" & ";database=dbase_172101856"
        Try
            conn = New MySqlConnection(connString)
            conn.Open()
        Catch ex As Exception
MessageBox.Show("Koneksi Error.." + ex.Message)
        End Try
        Return conn
    End Function
End Class
