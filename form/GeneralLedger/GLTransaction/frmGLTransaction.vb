Imports System.Text
Imports System.Data.SqlClient
Public Class frmGLTransaction
    Public actiontag = ""
    Dim processquery As New ProcessQuery()
    Dim connection = New common()
    Dim conn = connection.connect()
    Dim cmd As New SqlCommand
    Dim datapager As New DataPager()
    Dim query As String
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
    Private Sub frmGLTrans_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvGLAddTrans.Visible = False
        BtnCreate.Visible = False
        actionSecondary(False)
        emptyFields()
        loadSearchGridView()
        ErrorProviderGLTrans.Clear()
    End Sub
    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        'Dim addtrans = New frmAddTransaction()
        'addtrans.ShowDialog()
        frmAddTransaction.ShowDialog()
    End Sub
    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        dgvGLAddTrans.Visible = True
        BtnCreate.Visible = True
        emptyFields()
        valueFields()
        actiontag = "Add"
        dgvGLAddTrans.Rows.Clear()
        updateSysparam()
    End Sub
    Private Sub valueFields()
        performAction("Add")
        'TxtTrnDate.Text = DateTime.Now.ToString("yyyy-MM-dd")
        TxtTrnDate.Text = processquery.getSystemDate()
        TxtTellerId.Text = frmLogin.txtUserName.Text.ToString
        TxtBatchNo.Text = processquery.getNextCode()
        TxtTotDeb.Text = "0.00"
        TxtTotCred.Text = "0.00"
    End Sub
    Private Sub emptyFields()
        TxtTrnDate.Text = ""
        TxtTellerId.Text = ""
        TxtBatchNo.Text = ""
        TxtTotDeb.Text = ""
        TxtTotCred.Text = ""
        TxtSearch.Text = ""
    End Sub
    Private Sub performAction(ByVal action As String)
        If action = "Add" Then
            actionPrimary(False)
            actionSecondary(True)
        ElseIf action = "Cancel" Then
            actionPrimary(True)
            actionSecondary(False)
        End If
    End Sub
    Private Sub actionPrimary(ByVal value As Boolean)
        Add.Enabled = value
        TxtSearch.Enabled = value
    End Sub
    Private Sub actionSecondary(ByVal value As Boolean)
        Cancel.Enabled = value
        Save.Enabled = value
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        performAction("Cancel")
        dgvGLAddTrans.Visible = False
        BtnCreate.Visible = False
        emptyFields()
        loadSearchGridView()
        ErrorProviderGLTrans.Clear()
        dgvGLAddTrans.Rows.Clear()
    End Sub
    Private Sub dgvGLAddTrans_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGLAddTrans.CellContentClick
        If e.ColumnIndex = 3 Then
            If MessageBox.Show("Delete record?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Dim index As Integer
                index = dgvGLAddTrans.CurrentCell.RowIndex
                dgvGLAddTrans.Rows.RemoveAt(index)
                getTotal()
            End If
        End If
    End Sub
    Private Sub dgvAddTrans_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGLAddTrans.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow = dgvGLAddTrans.Rows(e.RowIndex)
            If MessageBox.Show("Delete entry?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Dim index As Integer = dgvGLAddTrans.CurrentCell.RowIndex
                dgvGLAddTrans.Rows.RemoveAt(index)
                getTotal()
            End If
        End If
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        If (provideError()) Then
            createHeader()
        End If
    End Sub
    Public Sub getTotal()
        Dim totaldebt As Double = 0
        Dim totalcredt As Double = 0
        For i = 0 To dgvGLAddTrans.Rows.Count - 1
            totaldebt += dgvGLAddTrans(2, i).Value.Trim.Replace(",", "")
            totalcredt += dgvGLAddTrans(3, i).Value.Trim.Replace(",", "")
        Next
        TxtTotDeb.Text = String.Format("{0:#,##0.00}", Val(totaldebt))
        TxtTotCred.Text = String.Format("{0:#,##0.00}", Val(totalcredt))
    End Sub
    ' Saving in gl transaction header
    Public Sub createHeader()
        Dim values = "('" & TxtBatchNo.Text.Trim.ToString() & "', '" &
           TxtTrnDate.Text & "', '" &
           processquery.getTellerId.Trim() & "', " &
           TxtTotDeb.Text.Trim().Replace(",", "") & ", " &
           TxtTotCred.Text.Trim().Replace(",", "") & ", '" &
            processquery.getBranchId.ToString() & "')"
        query = "INSERT INTO gl_trans_header (batch_no, trans_date, teller_id, total_debit, total_credit, branch_id) VALUES" + values
        Try
            'MessageBox.Show(query)
            cmd = New SqlCommand(query, conn)
            If (cmd.ExecuteNonQuery() > 0) Then
                createDetail()
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving in header- " & ex.Message)
        End Try
    End Sub
    ' Saving in gl transaction headedetail
    Public Sub createDetail()
        Dim query As String = "INSERT INTO gl_trans_detail (batch_no,gl_account, debit, credit, remarks) VALUES "
        Dim queryValues As String = ""
        For i = 0 To dgvGLAddTrans.Rows.Count - 1
            queryValues &= "('" &
                TxtBatchNo.Text.ToString & "', '" &
                dgvGLAddTrans(0, i).Value.ToString() & "', " &
                dgvGLAddTrans(2, i).Value.Trim.Replace(",", "") & "," &
                dgvGLAddTrans(3, i).Value.Trim.Replace(",", "") & ", '" &
                dgvGLAddTrans(4, i).Value.ToString & "'),"
        Next
        Try
            If queryValues <> "" Then
                query &= queryValues.TrimEnd(CChar(","))
                'MessageBox.Show(query)
                cmd = New SqlCommand(query, conn)
                If (cmd.ExecuteNonQuery() > 0) Then
                    Dim result = MessageBox.Show("New GL Transaction successfuly created.", "Saved",
                         MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If result = DialogResult.OK Then
                        updateGLAccount()
                        performAction("Cancel")
                        dgvGLAddTrans.Visible = False
                        BtnCreate.Visible = False
                        emptyFields()
                        loadSearchGridView()
                        ErrorProviderGLTrans.Clear()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving in detail- " & ex.Message)
        End Try
    End Sub
    Public Sub updateSysparam()
        Try
            Dim query As String = "UPDATE branch SET batch_number='" + processquery.getBatchNumber() + "'"
            cmd = New SqlCommand(query, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error updatin sysParam- " & ex.Message)
        End Try
    End Sub
    Public Sub updateGLAccount()
        Try
            Dim balance As Double = 0
            Dim query As New StringBuilder
            For i = 0 To dgvGLAddTrans.Rows.Count - 1
                Dim gl_account = dgvGLAddTrans(0, i).Value.ToString()
                Dim debit As Double = dgvGLAddTrans(2, i).Value.Trim.Replace(",", "")
                Dim credit As Double = dgvGLAddTrans(3, i).Value.Trim.Replace(",", "")
                For Each gl In getGeneralLedger(gl_account)
                    If (gl("position") = "Debit") Then
                        balance = gl("balance") + (debit - credit)
                    Else
                        balance = gl("balance") + (credit - debit)
                    End If
                Next
                'MessageBox.Show(balance.ToString())
                query.AppendLine("UPDATE gl_account SET debit=debit+" + debit.ToString() + ", credit=credit+" + credit.ToString())
                query.AppendLine(", balance=" + balance.ToString())
                query.AppendLine("WHERE gl_account='" + gl_account + "'")
                cmd = New SqlCommand(query.ToString, conn)
                cmd.ExecuteNonQuery()
                query.Clear()
            Next
        Catch ex As Exception
            MessageBox.Show("Error updating gl_account- " & ex.Message)
        End Try
    End Sub
    Public Function getGeneralLedger(ByVal gl_account As String) As ArrayList
        Dim datas As New ArrayList()
        Dim query As New StringBuilder
        query.AppendLine("SELECT C.position, ISNULL(A.balance,0) balance, ISNULL(A.debit,0) debit, ISNULL(A.credit,0) credit FROM gl_account A ")
        query.AppendLine("LEFT JOIN gl_sortcode B ON A.sortcode=B.sortcode ")
        query.AppendLine("LEFT JOIN gl_type C ON B.gl_type=C.code ")
        query.AppendLine("WHERE gl_account=@gl_account ")
        Try
            Dim cmd As New SqlCommand(query.ToString, conn)
            cmd.Parameters.AddWithValue("@gl_account", gl_account)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            For Each datarow As DataRow In ds.Tables(0).Rows
                datas.Add(datarow)
            Next
        Catch ex As Exception
            Throw New Exception("Error in getting general ledger arraylist.", ex)
        End Try
        Return datas
    End Function
    Public Sub loadSearchGridView()
        Try
            Dim keyword = TxtSearch.Text.ToString
            Dim query As New StringBuilder
            Dim dt As DataTable = Nothing
            query.AppendLine("SELECT A.batch_no 'Batch No.', A.trans_date 'Trans Date', B.username 'Teller', CONVERT(varchar, CAST(A.total_debit AS money), 1) 'Total Debit', CONVERT(varchar, CAST(A.total_credit AS money), 1) 'Total Credit' FROM gl_trans_header A ")
            query.AppendLine("LEFT JOIN users B on A.teller_id=B.id ")
            query.AppendLine("WHERE A.branch_id='" + processquery.getBranchId.ToString() + "' ")
            If keyword <> "" Then
                query.AppendLine("OR A.batch_no like '%" + keyword + "%'")
            End If
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                dt = ds.Tables(0)
                For Each dr In ds.Tables(0).Rows
                    If Not IsDBNull(dr("Batch No.")) Then TxtBatchNo.Text = dr("Batch No.")
                    If Not IsDBNull(dr("Trans Date")) Then TxtTrnDate.Text = dr("Trans Date")
                    If Not IsDBNull(dr("Teller")) Then TxtTellerId.Text = dr("Teller")
                    If Not IsDBNull(dr("Total Debit")) Then TxtTotDeb.Text = dr("Total Debit")
                    If Not IsDBNull(dr("Total Credit")) Then TxtTotCred.Text = dr("Total Credit")
                Next
            End If
            bs.DataSource = dt
            dgvGLTransData.DataSource = bs
        Catch ex As Exception
            MessageBox.Show("Error in gl_trans_header list - ", ex.Message.ToString)
        End Try
    End Sub
    Private Sub TxtSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.KeyUp
        loadSearchGridView()
        Dim cm As CurrencyManager = DirectCast(BindingContext(dgvGLTransData.DataSource), CurrencyManager)
        cm.Refresh()
    End Sub
    Private Sub bs_changeEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bs.CurrentChanged
        Dim bloading As Boolean = False
        Dim nPosition As Integer = 0
        If bLoading Then Exit Sub
        If bs.Position <> -1 Then
            Dim vSortCode As String
            vSortCode = DirectCast(bs.Current, System.Data.DataRowView).Item("Batch No.")
            getGLTransList(vSortCode)
            nPosition = bs.Position
        Else
            'UIClearValues()
        End If
    End Sub
    Public Function provideError() As Boolean
        Dim result As Boolean = True
        ErrorProviderGLTrans.Clear()
        If Convert.ToDouble(TxtTotCred.Text.Trim()) = 0 And Convert.ToDouble(TxtTotDeb.Text.Trim()) = 0 Then
            result = result And False
            ErrorProviderGLTrans.SetError(TxtTotCred, "Total Credit cannot be zero.")
            ErrorProviderGLTrans.SetError(TxtTotDeb, "Total Debit cannot be zero.")
        ElseIf Convert.ToDouble(TxtTotCred.Text.Trim()) > 0 And Convert.ToDouble(TxtTotDeb.Text.Trim()) > 0 Then
            If Convert.ToDouble(TxtTotCred.Text.Trim()) <> Convert.ToDouble(TxtTotDeb.Text.Trim()) Then
                result = result And False
                ErrorProviderGLTrans.SetError(TxtTotCred, "Total Credit should be equal to Total Debit.")
                ErrorProviderGLTrans.SetError(TxtTotDeb, "Total Debit should be equal to Total Credit.")
            End If
        End If
        Return result
    End Function
    Private Sub getGLTransList(ByVal vCode As String)
        Try
            Dim query As New StringBuilder
            Dim dt As DataTable = Nothing
            query.AppendLine("SELECT A.batch_no 'Batch No.', A.trans_date 'Trans Date', B.username 'Teller', CONVERT(varchar, CAST(A.total_debit AS money), 1) 'Total Debit', CONVERT(varchar, CAST(A.total_credit AS money), 1) 'Total Credit' FROM gl_trans_header A ")
            query.AppendLine("LEFT JOIN users B on A.teller_id=B.id ")
            query.AppendLine("WHERE batch_no ='" + vCode + "'")
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                For Each dr In ds.Tables(0).Rows
                    If Not IsDBNull(dr("Batch No.")) Then TxtBatchNo.Text = dr("Batch No.")
                    If Not IsDBNull(dr("Trans Date")) Then TxtTrnDate.Text = dr("Trans Date")
                    If Not IsDBNull(dr("Teller")) Then TxtTellerId.Text = dr("Teller")
                    If Not IsDBNull(dr("Total Debit")) Then TxtTotDeb.Text = dr("Total Debit")
                    If Not IsDBNull(dr("Total Credit")) Then TxtTotCred.Text = dr("Total Credit")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
        performAction("Cancel")
        dgvGLAddTrans.Visible = False
        BtnCreate.Visible = False
        emptyFields()
        loadSearchGridView()
        ErrorProviderGLTrans.Clear()
        dgvGLAddTrans.Rows.Clear()
    End Sub
    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        frmGLTransDetail.ShowDialog()
    End Sub
End Class