Imports System.Text
Imports System.Data.SqlClient
Public Class frmGLSortCode
    Dim connection = New common()
    Dim conn = connection.connect()
    Dim cmd As New SqlCommand
    Dim datapager As New DataPager()
    Dim query As String
    Dim processQuery As New ProcessQuery()
    Public actiontag = ""
    Dim WithEvents bs As New BindingSource
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_SYSCOMMAND As Integer = &H112
        Const SC_MOVE As Integer = &HF010

        Select Case m.Msg
            Case WM_SYSCOMMAND
                Dim command As Integer = m.WParam.ToInt32() And &HFFF0
                If command = SC_MOVE Then
                    Return
                End If
                Exit Select
        End Select
        MyBase.WndProc(m)
    End Sub
    Private Sub frmGLSortCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'getGLType()
        displayFields(False)
        actionSecondary(False)
        loadSearchGridView()
    End Sub
    Public Sub getGLType()
        Dim query As New StringBuilder
        query.AppendLine("SELECT * FROM(SELECT  Convert(varchar(1),code)+' - '+Convert(varchar(255),description) AS GL_TYPE from gl_type)A")
        Try
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                'Dim gltypecode = ""
                Dim gltypedesc = ""
                CmbGLType.Items.Clear()
                Dim collections As New AutoCompleteStringCollection
                For Each dr In ds.Tables(0).Rows
                    gltypedesc = IIf(Not IsDBNull(dr("GL_TYPE")), Trim(dr("GL_TYPE")), "desc")
                    CmbGLType.Items.Add(gltypedesc)
                    CmbGLType.AutoCompleteCustomSource.Add(gltypedesc)
                    collections.Add(gltypedesc)
                Next
                CmbGLType.SelectAll()
                CmbGLType.AutoCompleteMode = AutoCompleteMode.Suggest
                CmbGLType.AutoCompleteSource = AutoCompleteSource.CustomSource
                CmbGLType.AutoCompleteCustomSource = collections
            End If
        Catch ex As Exception
            Throw New Exception("Error in getting GL TYpe - ", ex)
        End Try
    End Sub
    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        'TxtSortCode.Text = processQuery.getNextCode("gl_sortcode", "sortcode")
        performAction("Add")
        actiontag = "Add"
        emptyFields()
        TxtSortCode.Enabled = True
    End Sub
    Private Sub performAction(ByVal action As String)
        If action = "Add" Then
            'paginationProcess()
            displayFields(True)
            actionPrimary(False)
            actionSecondary(True)
        ElseIf action = "Edit" Then
            'paginationProcess()
            displayFields(True)
            actionPrimary(False)
            actionSecondary(True)
        ElseIf action = "Cancel" Then
            actionPrimary(True)
            actionSecondary(False)
        End If
    End Sub
    Private Sub paginationProcess()
        'BtnFirst.Visible = False
        'BtnNext.Visible = False
        'BtnPrevious.Visible = False
        'BtnLast.Visible = False
        'LableDataCount.Visible = False
    End Sub
    Public Sub displayFields(ByVal value As Boolean)
        TxtSortCode.Enabled = value
        TxtDesc.Enabled = value
        CmbGLType.Enabled = value
        btnSearchGLType.Enabled = value
    End Sub
    Public Sub emptyFields()
        TxtSortCode.Text = ""
        TxtDesc.Text = ""
        txtGLTypeCode.Text = ""
        txtGLTypeDesc.Text = ""
    End Sub
    Private Sub actionPrimary(ByVal value As Boolean)
        Add.Enabled = value
        Edit.Enabled = value
        Delete.Enabled = value
        Search.Enabled = value
    End Sub
    Private Sub actionSecondary(ByVal value As Boolean)
        Cancel.Enabled = value
        Save.Enabled = value
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        performAction("Cancel")
        displayFields(False)
        SortCodeErrorProvider.Clear()
        loadSearchGridView()

    End Sub
    Private Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit.Click
        performAction("Edit")
        actiontag = "Edit"
        TxtSortCode.Enabled = False
    End Sub
    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close.Click
        Me.Hide()
    End Sub
    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        If provideError() Then
            If actiontag = "Add" Then
                actionCreate()
                '/
            ElseIf actiontag = "Edit" Then
                actionUpdate()
            End If
        End If
    End Sub
    ' Saving in gl sort code
    Public Sub actionCreate()
        Dim values = "('" + TxtSortCode.Text.ToString + "', '" +
            TxtDesc.Text.ToString + "', '" +
            txtGLTypeCode.Text.ToString() + "')"
        query = "INSERT INTO gl_sortcode (sortcode, description, gl_type) VALUES" + values
        Try
            cmd = New SqlCommand(query, conn)
            cmd.ExecuteNonQuery()
            displayFields(False)
            emptyFields()
            performAction("Cancel")
            MsgBox("New Sort Code successfuly created.")
            loadSearchGridView()
        Catch ex As Exception
            MessageBox.Show("Sort Code " + TxtSortCode.Text.ToString() + " already exist.", "Invalid",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Update in gl type
    Public Sub actionUpdate()
        query = "UPDATE gl_sortcode SET description=@desc, gl_type=@gl_type WHERE sortcode=@sortcode"
        'as
        Try
            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@sortcode", TxtSortCode.Text.ToString)
            cmd.Parameters.AddWithValue("@desc", TxtDesc.Text.ToString)
            cmd.Parameters.AddWithValue("@gl_type", txtGLTypeCode.Text.ToString)
            cmd.ExecuteNonQuery()
            displayFields(False)
            emptyFields()
            performAction("Cancel")
            MsgBox("Successfully updated.")
            loadSearchGridView()
        Catch ex As Exception
            MessageBox.Show("Error updating - " & ex.Message)
        End Try
    End Sub
    ' Delete in gl type
    Public Sub actionDelete()
        query = "DELETE FROM gl_sortcode WHERE sortcode=@sortcode"
        'as
        Try
            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@sortcode", TxtSortCode.Text.ToString)
            cmd.ExecuteNonQuery()
            MsgBox("Successfully deleted.")
            displayFields(False)
            emptyFields()
            performAction("Cancel")
            loadSearchGridView()
        Catch ex As Exception
            MessageBox.Show("Error deleting - " & ex.Message)
        End Try
    End Sub
    Public Function provideError() As Boolean
        Dim result As Boolean = True
        SortCodeErrorProvider.Clear()
        If TxtSortCode.Text.Trim.Length = 0 Then
            result = result And False
            SortCodeErrorProvider.SetError(TxtSortCode, "Sort Code cannot be blank")
        Else If TxtSortCode.Text.Trim.Length < 17 Then
            result = result And False
            SortCodeErrorProvider.SetError(TxtSortCode, "Sort Code is invalid.")
        End If
        If TxtDesc.Text.Trim.Length = 0 Then
            result = result And False
            SortCodeErrorProvider.SetError(TxtDesc, "Description cannot be blank.")
        End If
        If txtGLTypeCode.Text.Trim.Length = 0 Then
            result = result And False
            SortCodeErrorProvider.SetError(txtGLTypeDesc, "GL Type cannot be blank.")
        End If
            Return result
    End Function

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        actionDelete()
    End Sub
    Private Sub Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.Click
        'frmSearchGLType.ShowDialog()
    End Sub
    Public Sub loadSearchGridView()
        Try
            Dim keyword = TxtSearch.Text.ToString
            Dim query As New StringBuilder
            Dim dt As DataTable = Nothing
            query.AppendLine("SELECT A.sortcode 'Sort Code', A.description 'Description', B.description 'GL Type'  FROM gl_sortcode A ")
            query.AppendLine("LEFT JOIN gl_type B on A.gl_type=B.code ")
            If keyword <> "" Then
                query.AppendLine(" WHERE A.sortcode like '%" + keyword + "%' OR A.description like '%" + keyword + "%'")
            End If
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                dt = ds.Tables(0)
                For Each dr In ds.Tables(0).Rows
                    If Not IsDBNull(dr("Sort Code")) Then TxtSortCode.Text = dr("Sort Code")
                    If Not IsDBNull(dr("Description")) Then TxtDesc.Text = dr("Description")
                    'If Not IsDBNull(dr("GL Type Code")) Then txtGLTypeCode.Text = dr("GL Type Code")
                    If Not IsDBNull(dr("GL Type")) Then txtGLTypeDesc.Text = dr("GL Type")
                Next
            End If
            bs.DataSource = dt
            dgvGLSortCode.DataSource = bs
        Catch ex As Exception
            MessageBox.Show("Error in gl_sortcode list - ", ex.Message.ToString)
        End Try
    End Sub
    Private Sub TxtSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.KeyUp
        loadSearchGridView()
    End Sub
    Private Sub bs_changeEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bs.CurrentChanged
        Dim bloading As Boolean = False
        Dim nPosition As Integer = 0
        If bLoading Then Exit Sub
        If bs.Position <> -1 Then
            Dim vSortCode As String
            vSortCode = DirectCast(bs.Current, System.Data.DataRowView).Item("Sort Code")
            getGLSortCodeList(vSortCode)
            nPosition = bs.Position
        Else
            'UIClearValues()
        End If
    End Sub
    Private Sub getGLSortCodeList(ByVal vCode As String)
        Try
            Dim query As New StringBuilder
            Dim dt As DataTable = Nothing
            query.AppendLine("SELECT A.sortcode 'Sort Code', A.description 'Description', B.code 'GL Type Code', B.description 'GL Type'  FROM gl_sortcode A ")
            query.AppendLine("LEFT JOIN gl_type B on A.gl_type=B.code ")
            query.AppendLine("WHERE sortcode ='" + vCode + "'")
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                For Each dr In ds.Tables(0).Rows
                    If Not IsDBNull(dr("Sort Code")) Then TxtSortCode.Text = dr("Sort Code")
                    If Not IsDBNull(dr("Description")) Then TxtDesc.Text = dr("Description")
                    If Not IsDBNull(dr("GL Type Code")) Then txtGLTypeCode.Text = dr("GL Type Code")
                    If Not IsDBNull(dr("GL Type")) Then txtGLTypeDesc.Text = dr("GL Type")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSearchGLType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchGLType.Click
        frmSearchGLType.ShowDialog()
    End Sub
End Class
