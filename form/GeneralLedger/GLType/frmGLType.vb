Imports System.Text
Imports System.Data.SqlClient
Public Class frmGLType
    Dim connection = New common()
    Dim conn = connection.connect()
    Dim cmd As New SqlCommand
    Dim query As String
    Dim datapager As New DataPager()
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
    Private Sub frmGLType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSearchGridView()
        displayFields(False)
        actionSecondary(False)
    End Sub
    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        'TxtCode.Text = processQuery.getNextCode("gl_type", "code")
        performAction("Add")
        actiontag = "Add"
        emptyFields()
        TxtCode.Enabled = True
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
            TxtCode.ReadOnly = True
        ElseIf action = "Cancel" Then
            actionPrimary(True)
            actionSecondary(False)
            'loadDatas()
        End If
    End Sub
    Public Sub displayFields(ByVal value As Boolean)
        TxtCode.Enabled = value
        TxtType.Enabled = value
        cmbPosition.Enabled = value
    End Sub
    Public Sub emptyFields()
        TxtCode.Text = ""
        TxtType.Text = ""
        cmbPosition.Text = ""
    End Sub
    Private Sub actionPrimary(ByVal value As Boolean)
        'ToolStrip1.Enabled = value
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
        emptyFields()
        GLTypeErrorProvider.Clear()
        loadSearchGridView()
    End Sub
    Private Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit.Click
        performAction("Edit")
        actiontag = "Edit"
        TxtCode.Enabled = False
    End Sub
    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close.Click
        Me.Hide()
        emptyFields()
    End Sub
    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        If provideError() Then
            If actiontag = "Add" Then
                AddGLType()
                '/
            ElseIf actiontag = "Edit" Then
                UpdateGLType()
            End If
        End If
    End Sub
    ' Saving in gl type
    Public Sub AddGLType()
        Dim values = "('" + TxtCode.Text.ToString + "', '" + TxtType.Text.ToString + "', '" + cmbPosition.Text.ToString() + "')"
        query = "INSERT INTO gl_type (code, description, position) VALUES" + values
        Try
            cmd = New SqlCommand(query, conn)
            cmd.ExecuteNonQuery()
            MsgBox("New GL Type successfuly created.")
            displayFields(False)
            emptyFields()
            performAction("Cancel")
            loadSearchGridView()
        Catch ex As Exception
            MessageBox.Show("Code " + TxtCode.Text.ToString() + " already exist.", "Invalid",
             MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Update in gl type
    Public Sub UpdateGLType()
        query = "UPDATE gl_type SET description=@desc, position=@position WHERE code=@code"
        'as
        Try
            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@code", TxtCode.Text.ToString)
            cmd.Parameters.AddWithValue("@desc", TxtType.Text.ToString)
            cmd.Parameters.AddWithValue("@position", cmbPosition.Text.ToString)
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
    Public Sub deleteGLType()
        query = "DELETE FROM gl_type WHERE code=@code"
        'as
        Try
            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@code", TxtCode.Text.ToString)
            cmd.ExecuteNonQuery()
            MsgBox("Successfully deleted.")
            emptyFields()
            loadSearchGridView()
        Catch ex As Exception
            MessageBox.Show("Error deleting - " & ex.Message)
        End Try
    End Sub
    Public Function provideError() As Boolean
        Dim result As Boolean = True
        GLTypeErrorProvider.Clear()
        If TxtCode.Text.Trim.Length = 0 Then
            result = result And False
            GLTypeErrorProvider.SetError(TxtCode, "Code cannot be blank")
        End If
        If cmbPosition.Text.Trim.Length = 0 Then
            result = result And False
            GLTypeErrorProvider.SetError(cmbPosition, "Code cannot be blank")
        End If
        If TxtType.Text.Trim.Length = 0 Then
            result = result And False
            GLTypeErrorProvider.SetError(TxtType, "Description cannot be blank")
        End If
        Return result
    End Function
    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        deleteGLType()
    End Sub
    Private Sub Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.Click
        frmGLTypeSearch.ShowDialog()
    End Sub
    Public Sub loadSearchGridView()
        Try
            Dim keyword = TxtSearch.Text.ToString
            Dim query As New StringBuilder
            Dim dt As DataTable = Nothing
            query.AppendLine("SELECT code 'Code', description 'Description' FROM gl_type ")
            If keyword <> "" Then
                query.AppendLine(" WHERE code like '%" + keyword + "%' OR description like '%" + keyword + "%'")
            End If
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                dt = ds.Tables(0)
                For Each dr In ds.Tables(0).Rows
                    If Not IsDBNull(dr("Code")) Then TxtCode.Text = dr("Code")
                    If Not IsDBNull(dr("Description")) Then TxtType.Text = dr("Description")
                Next
            End If
            bs.DataSource = dt
            dgvGLType.DataSource = bs
        Catch ex As Exception
            MessageBox.Show("Error in gl_type search - ", ex.Message.ToString)
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
            Dim vCode As String
            'vUserNo = DirectCast(bx.Current, System.Data.DataRowView).Item("UserNo")
            vCode = DirectCast(bs.Current, System.Data.DataRowView).Item("Code")
            getGLTypeList(vCode)
            nPosition = bs.Position
        Else
            'UIClearValues()
        End If
    End Sub
    Private Sub getGLTypeList(ByVal vCode As String)
        Try
            Dim query As New StringBuilder
            Dim dt As DataTable = Nothing
            query.AppendLine("SELECT code 'Code', description 'Description' FROM gl_type")
            query.AppendLine("WHERE code ='" + vCode + "'")
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                For Each dr In ds.Tables(0).Rows
                    If Not IsDBNull(dr("Code")) Then TxtCode.Text = dr("Code")
                    If Not IsDBNull(dr("Description")) Then TxtType.Text = dr("Description")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class