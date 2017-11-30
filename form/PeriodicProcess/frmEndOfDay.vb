Imports System.Text
Imports System.Data.SqlClient
Imports System.Net.Dns
Imports System.Net
Public Class frmEndOfDay
    Dim sysStatus As Integer
    Dim activemenu As New ActiveMenu()
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Public svAccounts As DataTable
    Public headOffice As String
    Public dtsystemDate As Date
    Dim processquery As New ProcessQuery()
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        ' loan reclassification
        ' update branch status
        ' compute adb value
        ' create gl entries

        'status   0 - open
        '         1 - end of day
        '         9 - end of accounting

        validateSystem()

        Dim lUser = validateUsers()

        If sysStatus = "9" Or sysStatus = "1" Then
            MessageBox.Show("The system is already closed.")
        Else

            If lUser Then
                MessageBox.Show("Process is terminated. There are still unbalanced tellers.")
            Else
                Dim increment As Integer = 0
                Dim nCnt As Integer = 0
                Dim sv As Integer = 0
                Dim cu As Integer = 0
                Dim ln As Integer = 0
                Dim valOpenDate

                Dim cl As New common
                Dim procQuery As New ProcessQuery()

                'cl.logs(frmLogin.txtUserName.Text.Trim(), "end of day", procQuery.getSystemDate())
                'ds = getNumberOfAccounts(dtFrom, dtTo)

                'nCnt = ds.Rows.Count

                sv = getSVAccounts()
                nCnt = sv + cu + ln

                pBarEOD.Maximum = nCnt

                If nCnt > 0 Then

                    Dim inc As Integer
                    Dim strAcntNumber As String
                    Dim NumOfDays As Integer = 1
                    Dim numMonthly As Integer
                    Dim strADBBalance As Double
                    Dim strNewADBBalance As Double
                    Dim strCurrentBalance As Double

                    getSystemDate()

                    Dim dDate = dtsystemDate.Month
                    Dim dYear = dtsystemDate.Year
                    Dim week = dtsystemDate.DayOfWeek
                    numMonthly = System.DateTime.DaysInMonth(dYear, dDate)

                    If week = 1 Then ' monday
                        NumOfDays = 3
                    End If

                    For Each dr In svAccounts.Rows

                        '// adb savings - start
                        strAcntNumber = dr("account_number")
                        strADBBalance = dr("adb_balance")
                        strCurrentBalance = dr("current_balance")
                        valOpenDate = dr("opening_date")

                        If valOpenDate = dtsystemDate Then
                            strNewADBBalance = strCurrentBalance
                        Else
                            strNewADBBalance = computeADB(strCurrentBalance, numMonthly, NumOfDays)
                        End If

                        'update adb_balance
                        'Dim strQuery = "UPDATE savings set adb_balance=adb_balance+" + strNewADBBalance.ToString() + " where account_number='" + strAcntNumber + "'"

                        'cl.Insert(strQuery)
                        '// adb savings - end

                        increment = increment + 1
                        pBarEOD.Value = increment

                    Next

                Else

                    pBarEOD.Maximum = 1
                    pBarEOD.Value = 1

                End If

                '// update branch status to 1
                Dim strUpdateStatus = "UPDATE branch set status='1' where code='" + frmLogin.txtBranchID.Text.Trim() + "'"
                cl.Insert(strUpdateStatus)
                activemenu.menuStripParent()
                '// create gl entries
                If headOffice Then

                    Dim strPos As String
                    Dim strGLAccount As String
                    Dim valDebit As Double
                    Dim valCredit As Double
                    Dim strUpdate As String
                    Dim valID As Integer

                    Dim ds = getGLEntryDetails()
                    Dim totDebit As Double = 0
                    Dim totCredit As Double = 0

                    Dim batchNumber = processquery.getBatchNumber()
                    'cl.updateBatchNumber(batchNumber)

                    For Each dr In ds.Rows

                        valID = dr("id")
                        strPos = dr("position")
                        strGLAccount = dr("gl_account")
                        valDebit = dr("debit")
                        valCredit = dr("credit")

                        ' insert record in gl trans details
                        ' update gl_account : debit credit balance trandate fields
                        If strPos = "Debit" Then

                            strUpdate = "update gl_account set debit=debit+" + valDebit.ToString() + ",credit=credit+" + valCredit.ToString() +
                                            ",balance=balance +" + valDebit.ToString() + "-" + valCredit.ToString() + " where gl_account='" + strGLAccount + "'"
                        Else ' Credit

                            strUpdate = "update gl_account set debit=debit+" + valDebit.ToString() + ",credit=credit+" + valCredit.ToString() +
                                            ",balance=balance +" + valCredit.ToString() + "-" + valDebit.ToString() + " where gl_account='" + strGLAccount + "'"

                        End If
                        cl.Insert(strUpdate)

                        totDebit = totDebit + valDebit
                        totCredit = totCredit + valCredit

                        Dim updateGlEntryStatus = "update gl_entry_eod set status='1' where id=" + valID.ToString()
                        cl.Insert(updateGlEntryStatus)

                        Dim queryValues As String = "INSERT INTO gl_trans_detail (batch_no,gl_account, debit, credit, remarks) VALUES "
                        queryValues = queryValues + "('" &
                            frmLogin.txtBranchID.Text.Trim() + "-" + batchNumber & "', '" &
                            strGLAccount & "', " &
                            valDebit.ToString() & "," &
                            valCredit.ToString() & ", '" &
                            " " & "')"
                        cl.Insert(queryValues)

                    Next

                    Dim values = "('" & frmLogin.txtBranchID.Text.Trim() + "-" + batchNumber & "', '" &
                       frmMainMenu.dtsystemDate.ToString() & "', '" &
                       processquery.getTellerId.Trim() & "', " &
                       totDebit.ToString() & ", " &
                       totCredit.ToString() & ")"
                    Dim query = "INSERT INTO gl_trans_header (batch_no, trans_date, teller_id, total_debit, total_credit) VALUES" + values
                    cl.Insert(query)

                End If

                MessageBox.Show("End of Day process is completed. Please re-login.")

                'Dim procQuery As New ProcessQuery()
                'Dim cl = New common

                Dim strQuery = "update users set logged_in='0' where username='" + frmLogin.txtUserName.Text.Trim() + "'"

                'cl.logs(frmLogin.txtUserName.Text.Trim(), "exit", procQuery.getSystemDate())
                cl.Insert(strQuery)

                Application.Exit()

            End If

        End If

    End Sub

    Private Function getGLEntryDetails() As DataTable
        Dim dx As DataTable = Nothing

        Try
            Dim cl = New common()
            Dim conn = cl.connect()

            Dim strGetEntries = "select A.id,D.position,A.gl_account,A.debit,A.credit from gl_entry_eod A " +
                    "inner join gl_account B on B.gl_account=A.gl_account " +
                    "inner join gl_sortcode C on C.sortcode=B.sortcode inner join gl_type D on D.code=C.gl_type " +
                    "where A.branch_id='" + frmLogin.txtBranchID.Text.Trim() + "' and trandate='" + dtsystemDate.ToString() + "' and A.status='0' "
            Dim DA As New SqlDataAdapter(strGetEntries, conn)
            Dim ds As New DataSet
            DA.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                dx = ds.Tables(0)
            End If

        Catch ex As Exception

        End Try

        Return dx
    End Function


    Private Function computeADB(ByVal nCurrentBalance As Double, ByVal numMonthly As Integer, ByVal NumOfDays As Integer)
        Dim result As Double

        result = Math.Round(((nCurrentBalance * NumOfDays) / numMonthly), 2)

        Return result
    End Function


    Private Sub getSystemDate()

        Dim cl = New common()
        Dim conn = cl.connect()

        Dim strQuery = "select * from branch where code='" + frmLogin.txtBranchID.Text.Trim() + "'"

        Dim DA As New SqlDataAdapter(strQuery, conn)
        Dim ds As New DataSet
        DA.Fill(ds)
        If ds.Tables(0).Rows.Count <> 0 Then
            For Each dr In ds.Tables(0).Rows
                'lblInstitutionName.Text = dr("institutionname")
                'ToolStripDate.Text = ToolStripDate.Text + " " + dr("system_date").ToString.Substring(0, 10)
                dtsystemDate = dr("system_date")
                headOffice = dr("head_office")
            Next
        End If
    End Sub

    Private Function getSVAccounts()
        Dim result As Integer = 0

        Dim cl = New common()
        Dim conn = cl.connect()

        Dim strQuery = "select * from savings where account_status='Active'"

        Dim DA As New SqlDataAdapter(strQuery, conn)
        Dim ds As New DataSet
        DA.Fill(ds)
        If ds.Tables(0).Rows.Count <> 0 Then
            result = ds.Tables(0).Rows.Count
            svAccounts = ds.Tables(0)
        End If

        Return result
    End Function

    Private Sub validateSystem()
        'Dim result As Integer = 0

        Dim cl = New common()
        Dim conn = cl.connect()

        Dim strQuery = "select * from branch where code='" + frmLogin.txtBranchID.Text.Trim() + "'"

        Dim DA As New SqlDataAdapter(strQuery, conn)
        Dim ds As New DataSet
        DA.Fill(ds)
        If ds.Tables(0).Rows.Count <> 0 Then
            For Each dr In ds.Tables(0).Rows
                sysStatus = dr("status")
            Next
        End If
        'Return result
    End Sub

    Private Function validateUsers()
        Dim result As Boolean = False

        Dim cl = New common()
        Dim conn = cl.connect()

        Dim strQuery = "select * from users where balanced='0' and (cash<>0 or cheque<>0) and branch_id='" + frmLogin.txtBranchID.Text.Trim() + "'"

        Dim DA As New SqlDataAdapter(strQuery, conn)
        Dim ds As New DataSet
        DA.Fill(ds)
        If ds.Tables(0).Rows.Count <> 0 Then
            result = True
        End If

        Return result
    End Function

End Class