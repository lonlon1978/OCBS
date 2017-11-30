Imports System.Data.SqlClient
Public Class frmGLTypeSearch
    Private Sub frmGLTypeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSearchGridView()
    End Sub
    Public Sub TxtGLTypeSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGLTypeSearch.TextChanged
        loadSearchGridView()
        Dim cm As CurrencyManager = DirectCast(BindingContext(GridGLTypeSearch.DataSource), CurrencyManager)
        cm.Refresh()
    End Sub
    Private Sub GridGLTypeSearch_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridGLTypeSearch.CellDoubleClick
        Dim index As Integer
        index = GridGLTypeSearch.CurrentRow.Index
        frmGLType.TxtCode.Text = GridGLTypeSearch.Item(0, index).Value.ToString()
        frmGLType.TxtType.Text = GridGLTypeSearch.Item(1, index).Value.ToString()
        Me.Hide()
    End Sub
    ' Load GridView
    Public Sub loadSearchGridView()
        Try
            Dim keyword = TxtGLTypeSearch.Text.ToString
            Dim connection As New common()
            Dim ds As New DataSet
            Dim query = "SELECT code 'Code', description 'Description' FROM gl_type"
            If keyword <> "" Then
                query &= " WHERE code like '%" + keyword + "%' OR description like '%" + keyword + "%'"
            End If
            Dim sda As SqlDataAdapter = New SqlDataAdapter(query, connection.connect())
            sda.Fill(ds, "gl_type")
            GridGLTypeSearch.DataSource = ds.Tables("gl_type")
        Catch ex As Exception
            MessageBox.Show("Error in gl_type search - ", ex.Message.ToString)
        End Try
    End Sub
End Class