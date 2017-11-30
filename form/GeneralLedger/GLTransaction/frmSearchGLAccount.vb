Imports System.Data.SqlClient
Imports System.Text
Public Class frmSearchGLAccount
    Public glAccountCode As String = ""
    Public glAccountDesc As String = ""
    Dim processquery As New ProcessQuery()
    Private Sub frmSearchGLAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSearchGridView()
    End Sub
    Public Sub loadSearchGridView()
        Try
            Dim keyword = TxtSearch.Text.ToString
            Dim connection As New common()
            Dim ds As New DataSet
            Dim query As New StringBuilder
            query.AppendLine("SELECT gl_account AS 'Code', description AS 'Description' FROM gl_account ")
            query.AppendLine("WHERE branch_id='" + processquery.getBranchId.ToString() + "' ")
            If keyword <> "" Then
                query.AppendLine("OR gl_account like '%" + keyword + "%' OR ")
                query.AppendLine("description like '%" + keyword + "%' ")
            End If
            Dim cmd As New SqlCommand(query.ToString, connection.connect())
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "gl_account")
            dgvSearch.DataSource = ds.Tables("gl_account")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        loadSearchGridView()
        Dim cm As CurrencyManager = DirectCast(BindingContext(dgvSearch.DataSource), CurrencyManager)
        cm.Refresh()
    End Sub
    Private Sub dgvSearch_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow = dgvSearch.Rows(e.RowIndex)
            Dim code As Windows.Forms.DataGridViewCell = dgvSearch.Rows(selectedRow.Index).Cells("Code")
            Dim description As Windows.Forms.DataGridViewCell = dgvSearch.Rows(selectedRow.Index).Cells("Description")
            frmAddTransaction.txtGLAcctCode.Text = code.Value.ToString()
            frmAddTransaction.txtGLAcctDesc.Text = description.Value.ToString()
            'MessageBox.Show(frmAddTransaction.txtGLAcctDesc.Text)
        End If
        Me.Close()
    End Sub
End Class