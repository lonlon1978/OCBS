Imports System.Data.SqlClient
Imports System.Text
Public Class frmSearchGLSortCode
    Private Sub frmSearchGLSortCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSearchGridView()
    End Sub
    Public Sub loadSearchGridView()
        Try
            Dim keyword = TxtSearch.Text.ToString
            Dim connection As New common()
            Dim ds As New DataSet
            Dim query As New StringBuilder
            query.AppendLine("SELECT sortcode AS 'Code', description AS 'Description' FROM gl_sortcode ")
            If keyword <> "" Then
                query.AppendLine("WHERE sortcode like '%" + keyword + "%' OR ")
                query.AppendLine("description like '%" + keyword + "%' ")
            End If
            Dim cmd As New SqlCommand(query.ToString, connection.connect())
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "gl_sortcode")
            dgvSearch.DataSource = ds.Tables("gl_sortcode")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        loadSearchGridView()
        Dim cm As CurrencyManager = DirectCast(BindingContext(dgvSearch.DataSource), CurrencyManager)
        cm.Refresh()
    End Sub
    Private Sub dgvGLType_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow = dgvSearch.Rows(e.RowIndex)
            Dim code As Windows.Forms.DataGridViewCell = dgvSearch.Rows(selectedRow.Index).Cells("Code")
            Dim description As Windows.Forms.DataGridViewCell = dgvSearch.Rows(selectedRow.Index).Cells("Description")
            frmGLAccount.txtGLSortCode.Text = code.Value.ToString()
            frmGLAccount.txtGLSortDesc.Text = description.Value.ToString()
        End If
        Me.Close()
    End Sub
End Class