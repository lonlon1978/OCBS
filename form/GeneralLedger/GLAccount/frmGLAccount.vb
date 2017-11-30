Imports System.Text
Imports System.Data.SqlClient
Public Class frmGLAccount
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
    Private Sub frmGLAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'getSortCode()
        displayFields(False)
        actionSecondary(False)
        loadSearchGridView()
        TxtSearch.Enabled = True
    End Sub
    Public Sub getSortCode()
        Dim query As New StringBuilder
        query.AppendLine("Select * from gl_sortcode order by sortcode asc")
        Try
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                Dim sortcode = ""
                Dim description = ""
                CmbSortCode.Items.Clear()
                Dim collections As New AutoCompleteStringCollection
                For Each dr In ds.Tables(0).Rows
                    description = IIf(Not IsDBNull(dr("description")), Trim(dr("description")), "description")
                    sortcode = IIf(Not IsDBNull(dr("sortcode")), Trim(dr("sortcode")), "sortcode")
                    CmbSortCode.Items.Add(sortcode + " - " + description)
                    CmbSortCode.AutoCompleteCustomSource.Add(description)
                    collections.Add(description)
                Next
                'CmbSortCode.AutoCompleteMode = AutoCompleteMode.Suggest
                'CmbSortCode.AutoCompleteSource = AutoCompleteSource.CustomSource
                'CmbSortCode.AutoCompleteCustomSource = Collections
            End If
        Catch ex As Exception
            Throw New Exception("Error in getting GL Sort Code - ", ex)
        End Try
    End Sub
    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        'TxtSortCode.Text = processQuery.getNextCode("gl_sortcode", "sortcode")
        performAction("Add")
        actiontag = "Add"
        emptyFields()
        TxtAccountNo.Enabled = True
    End Sub
    Private Sub performAction(ByVal action As String)
        If action = "Add" Then
            displayFields(True)
            actionPrimary(False)
            actionSecondary(True)
        ElseIf action = "Edit" Then
            displayFields(True)
            actionPrimary(False)
            actionSecondary(True)
        ElseIf action = "Cancel" Then
            actionPrimary(True)
            actionSecondary(False)
            TxtSearch.Enabled = True
        End If
    End Sub
    Public Sub displayFields(ByVal value As Boolean)
        TxtAccountNo.Enabled = value
        TxtDesc.Enabled = value
        btnSearchGLSortCode.Enabled = value
    End Sub
    Public Sub emptyFields()
        TxtAccountNo.Text = ""
        TxtDesc.Text = ""
        txtGLSortCode.Text = ""
        txtGLSortDesc.Text = ""
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
        GLAccountErrorProvider.Clear()
        loadSearchGridView()
    End Sub
    Private Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit.Click
        performAction("Edit")
        actiontag = "Edit"
        TxtAccountNo.Enabled = False
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
    ' Saving in gl account
    Public Sub actionCreate()
        Dim values = "('" + TxtAccountNo.Text.ToString + "', '" +
            TxtDesc.Text.ToString + "', '" +
            txtGLSortCode.Text.ToString + "', 0, 0, '" + processQuery.getBranchId.ToString + "')"
        query = "INSERT INTO gl_account (gl_account, description, sortcode, debit, credit, branch_id) VALUES" + values
        Try
            cmd = New SqlCommand(query, conn)
            cmd.ExecuteNonQuery()
            displayFields(False)
            performAction("Cancel")
            emptyFields()
            MsgBox("New GL Account successfuly created.")
            loadSearchGridView()
        Catch ex As Exception
            MessageBox.Show("Account Code " + TxtAccountNo.Text.ToString() + " already exist.", "Invalid",
           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Update in gl type
    Public Sub actionUpdate()
        query = "UPDATE gl_account SET description=@description, sortcode=@sortcode WHERE gl_account=@gl_account"
        'as
        Try
            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@gl_account", TxtAccountNo.Text.ToString)
            cmd.Parameters.AddWithValue("@description", TxtDesc.Text.ToString)
            cmd.Parameters.AddWithValue("@sortcode", txtGLSortCode.Text.ToString())
            cmd.ExecuteNonQuery()
            MsgBox("Successfully updated.")
            displayFields(False)
            emptyFields()
            performAction("Cancel")
            loadSearchGridView()
        Catch ex As Exception
            MessageBox.Show("Error updating - " & ex.Message)
        End Try
    End Sub
    ' Delete in gl type
    Public Sub actionDelete()
        query = "DELETE FROM gl_account WHERE gl_account=@gl_account"
        'as
        Try
            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@gl_account", TxtAccountNo.Text.ToString)
            cmd.ExecuteNonQuery()
            displayFields(False)
            emptyFields()
            performAction("Cancel")
            MsgBox("Successfully deleted.")
            loadSearchGridView()
        Catch ex As Exception
            MessageBox.Show("Error deleting - " & ex.Message)
        End Try
    End Sub
    Public Function provideError() As Boolean
        Dim result As Boolean = True
        GLAccountErrorProvider.Clear()
        If TxtAccountNo.Text.Trim.Length = 0 Then
            result = result And False
            GLAccountErrorProvider.SetError(TxtAccountNo, "Account number cannot be blank.")
        ElseIf TxtAccountNo.Text.Trim.Length < 17 Then
            result = result And False
            GLAccountErrorProvider.SetError(TxtAccountNo, "Account number is invalid.")
        End If
        If TxtDesc.Text.Trim.Length = 0 Then
            result = result And False
            GLAccountErrorProvider.SetError(TxtDesc, "Description cannot be blank.")
        End If
        If txtGLSortCode.Text.Trim.Length = 0 Then
            result = result And False
            GLAccountErrorProvider.SetError(txtGLSortDesc, "Sort code cannot be blank.")
        End If
        Return result
    End Function

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        actionDelete()
    End Sub
    Public Sub loadSearchGridView()
        Try
            Dim keyword = TxtSearch.Text.ToString
            Dim query As New StringBuilder
            Dim dt As DataTable = Nothing
            query.AppendLine("SELECT A.gl_account 'GL Account', A.description 'Description', B.description 'Sort Code'  FROM gl_account A ")
            query.AppendLine("LEFT JOIN gl_sortcode B on A.sortcode=B.sortcode ")
            query.Append("WHERE A.branch_id='" + processQuery.getBranchId.ToString() + "' ")
            If keyword <> "" Then
                query.AppendLine("OR A.gl_account like '%" + keyword + "%' OR A.description like '%" + keyword + "%'")
            End If
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                dt = ds.Tables(0)
                For Each dr In ds.Tables(0).Rows
                    If Not IsDBNull(dr("GL Account")) Then TxtAccountNo.Text = dr("GL Account")
                    If Not IsDBNull(dr("Description")) Then TxtDesc.Text = dr("Description")
                    'If Not IsDBNull(dr("sortcode")) Then txtGLSortCode.Text = dr("sortcode")
                    If Not IsDBNull(dr("Sort Code")) Then txtGLSortDesc.Text = dr("Sort Code")
                Next
            End If
            bs.DataSource = dt
            dgvGLAccount.DataSource = bs
        Catch ex As Exception
            MessageBox.Show("Error in gl_account list - ", ex.Message.ToString)
        End Try
    End Sub
    Private Sub TxtSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.KeyUp
        loadSearchGridView()
    End Sub
    Private Sub bs_changeEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bs.CurrentChanged
        Dim bloading As Boolean = False
        Dim nPosition As Integer = 0
        If bloading Then Exit Sub
        If bs.Position <> -1 Then
            Dim vSortCode As String
            vSortCode = DirectCast(bs.Current, System.Data.DataRowView).Item("GL Account")
            getGLAccountList(vSortCode)
            nPosition = bs.Position
        Else
            'UIClearValues()
        End If
    End Sub
    Private Sub getGLAccountList(ByVal vCode As String)
        Try
            Dim query As New StringBuilder
            Dim dt As DataTable = Nothing
            query.AppendLine("SELECT A.gl_account 'GL Account', A.description 'Description', B.sortcode 'sortcode',  B.description 'Sort Code'  FROM gl_account A ")
            query.AppendLine("LEFT JOIN gl_sortcode B on A.sortcode=B.sortcode ")
            query.AppendLine("WHERE gl_account ='" + vCode + "'")
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                For Each dr In ds.Tables(0).Rows
                    If Not IsDBNull(dr("GL Account")) Then TxtAccountNo.Text = dr("GL Account")
                    If Not IsDBNull(dr("Description")) Then TxtDesc.Text = dr("Description")
                    If Not IsDBNull(dr("sortcode")) Then txtGLSortCode.Text = dr("sortcode")
                    If Not IsDBNull(dr("Sort Code")) Then txtGLSortDesc.Text = dr("Sort Code")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnSearchGLSortCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchGLSortCode.Click
        Dim searchGLSortCode = New frmSearchGLSortCode()
        searchGLSortCode.ShowDialog()
    End Sub
End Class