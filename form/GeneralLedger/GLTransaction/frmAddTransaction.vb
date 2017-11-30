Imports System.Text
Imports System.Data.SqlClient
Public Class frmAddTransaction
    Dim connection = New common()
    Dim conn = connection.connect()
    Dim cmd As New SqlCommand
    Public Sub getGLAccount()
        Try
            Dim query As New StringBuilder
            query.AppendLine("Select * from gl_account order by gl_account asc")
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                Dim gltypecode = ""
                Dim gltypedesc = ""
                CmbGLAccnt.Items.Clear()
                Dim collections As New AutoCompleteStringCollection
                For Each dr In ds.Tables(0).Rows
                    gltypedesc = IIf(Not IsDBNull(dr("description")), Trim(dr("description")), "description")
                    gltypecode = IIf(Not IsDBNull(dr("gl_account")), Trim(dr("gl_account")), "gl_account")
                    CmbGLAccnt.Items.Add(gltypecode + " - " + gltypedesc)
                    CmbGLAccnt.AutoCompleteCustomSource.Add(gltypedesc)
                    collections.Add(gltypedesc)
                Next
                CmbGLAccnt.AutoCompleteMode = AutoCompleteMode.Suggest
                CmbGLAccnt.AutoCompleteSource = AutoCompleteSource.CustomSource
                CmbGLAccnt.AutoCompleteCustomSource = collections
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If provideError() Then
                frmGLTransaction.dgvGLAddTrans.Rows.Add(New String() {txtGLAcctCode.Text.ToString, txtGLAcctDesc.Text.ToString(), TxtCredit.Text.ToString, TxtDebit.Text.ToString, txtRemarks.Text.ToString})
                Me.Hide()
                emptyFields()
                frmGLTransaction.getTotal()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub emptyFields()
        TxtCredit.Text = ""
        TxtDebit.Text = ""
        txtGLAcctCode.Text = ""
        txtGLAcctDesc.Text = ""
        txtRemarks.Text = ""
    End Sub
    Public Function provideError() As Boolean
        Dim result As Boolean = True
        AddTransErrorProvider.Clear()
        If txtGLAcctCode.Text.Trim.Length = 0 Then
            result = result And False
            AddTransErrorProvider.SetError(txtGLAcctDesc, "GL Account cannot be blank.")
        End If
        If TxtCredit.Text.Trim.Length = 0 And TxtDebit.Text.Trim.Length = 0 Then
            result = result And False
            AddTransErrorProvider.SetError(TxtCredit, "Credit cannot be blank.")
            AddTransErrorProvider.SetError(TxtDebit, "Debit cannot be blank.")
        ElseIf TxtCredit.Text.Trim = 0 And TxtDebit.Text.Trim = 0 Then
            result = result And False
            AddTransErrorProvider.SetError(TxtCredit, "Credit cannot be zero value.")
            AddTransErrorProvider.SetError(TxtDebit, "Debit cannot be zero value.")
        Else
            result = result And True
            If TxtCredit.Text.Trim.Length > 0 And TxtDebit.Text.Trim.Length = 0 Then
                TxtDebit.Text = 0
            ElseIf TxtDebit.Text.Trim.Length > 0 And TxtCredit.Text.Trim.Length = 0 Then
                TxtCredit.Text = 0
            End If
        End If
        Return result
    End Function
    Private Sub TxtCredit_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCredit.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If
    End Sub
    Private Sub TxtDebit_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDebit.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If
    End Sub
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub TxtCredit_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCredit.LostFocus
        TxtCredit.Text = String.Format("{0:#,##0.00}", Val(TxtCredit.Text))
    End Sub

    Private Sub TxtDebit_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDebit.LostFocus
        TxtDebit.Text = String.Format("{0:#,##0.00}", Val(TxtDebit.Text))
    End Sub

    Private Sub btnSearchGLSortCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchGLSortCode.Click
        Dim searchGLAccount = New frmSearchGLAccount()
        searchGLAccount.ShowDialog()
    End Sub
End Class