Imports System.Data.SqlClient
Imports System.Text
Public Class frmGLTransDetail
    Private Sub frmGLTransDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim batch_no As String = frmGLTransaction.TxtBatchNo.Text.Trim.ToString()
        If batch_no <> "" Then
            Try
                LblBatchNo.Text = batch_no
                Dim connection As New common()
                Dim ds As New DataSet
                Dim query As New StringBuilder
                query.AppendLine("SELECT A.trans_no 'Trans No.',  A.gl_account 'Account Code', B.description 'Account Description',  CONVERT(varchar, CAST(A.debit AS money), 1) 'Debit Amount', CONVERT(varchar, CAST(A.credit AS money), 1) 'Credit Amount' FROM gl_trans_detail A ")
                query.AppendLine("LEFT JOIN gl_account B on A.gl_account=B.gl_account ")
                query.AppendLine("WHERE batch_no='" + batch_no + "'")
                Dim cmd As New SqlCommand(query.ToString, connection.connect())
                Dim da As New SqlDataAdapter(cmd)
                'Dim ds As New DataSet
                'da.Fill(ds)
                'Dim sda As SqlDataAdapter = New SqlDataAdapter(query, connection.connect())
                da.Fill(ds, "detail")
                dgvGLTransDetail.DataSource = ds.Tables("detail")
            Catch ex As Exception

            End Try
        Else
            LblBatchNo.Text = ""
        End If
    End Sub
End Class
