Imports System.Data.SqlClient
Imports System.Text
Public Class frmSearchGLType
    Private Sub SearchGLType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSearchGridView()
    End Sub
    Public Sub loadSearchGridView()
        Try
            Dim keyword = TxtSearch.Text.ToString
            Dim connection As New common()
            Dim ds As New DataSet
            Dim query As New StringBuilder
            query.AppendLine("SELECT code AS 'Code', description AS 'Description' FROM gl_type ")
            If keyword <> "" Then
                query.AppendLine("WHERE code like '%" + keyword + "%' OR ")
                query.AppendLine("description like '%" + keyword + "%' ")
            End If
            Dim cmd As New SqlCommand(query.ToString, connection.connect())
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "gl_type")
            dgvSearch.DataSource = ds.Tables("gl_type")
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
            frmGLSortCode.txtGLTypeCode.Text = code.Value.ToString()
            frmGLSortCode.txtGLTypeDesc.Text = description.Value.ToString()
        End If
        Me.Close()
    End Sub
End Class