Public Class FormLaporanPenulis

    Private Sub FormLaporanPenulis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rep As New CRMahasiswa1
        Dim DT As DataTable
        Dim DTMahasiswa As DTMahasiswaTableAdapters.Tabel_MahasiswaTableAdapter
        DTMahasiswa = New DTMahasiswaTableAdapters.Tabel_MahasiswaTableAdapter
        DT = DTMahasiswa.GetData()
        rep.SetDataSource(DT)
        CrystalReportViewer1.ReportSource = rep

    End Sub
End Class