Imports System.Text
Imports System.Data.SqlClient
Imports System.Net.Dns
Imports System.Net
Public Class frmStartOfDay
    Dim activemenu As New ActiveMenu()
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Dim dtPreviousDate As Date
    Dim sysStatus As String
    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        Dim dtFrom As Date
        Dim dtTo As Date
        Dim ds As DataTable
        Dim dt As DataTable
        Dim prinDue As Double
        Dim intDue As Double
        Dim scDue As Double
        Dim acntNumber As String
        Dim advancePrinPayment As Double
        Dim instID As Integer

        Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or _
            MsgBoxStyle.Information

        'Time Deposit - rollover process

        'Loan 
        ' - compute due amounts (principal due, interest due, penalty due, sc due) then update loans table
        ' - update status of loan_installment.status field for due accounts

        ' Sysparam
        ' - update system_date

        ' process clear checks 

        Dim cl As New common()
        Dim procQuery As New ProcessQuery()

        Dim nextSystemDate = dtpNextSysDate.Value

        Dim lOk = validateNextSystemDate(nextSystemDate)

        If lOk <> 0 And lOk <> 4 Then
            MessageBox.Show(errorMessage)
        Else

            Dim lanswer As Boolean = True
            If lOk = 4 Then

                Dim msg = "Selected date is a weekend. Continue?"
                Dim title = "Confirmation"

                Dim response = MsgBox(msg, style, title)

                If response = MsgBoxResult.Yes Then
                    lanswer = True
                Else
                    lanswer = False
                End If

            End If

            If lanswer Then

                Dim DayOfWeek = nextSystemDate.DayOfWeek
                If DayOfWeek.ToString() = "Monday" Then
                    dtFrom = nextSystemDate.AddDays(-2D)
                    dtTo = nextSystemDate
                Else
                    dtFrom = nextSystemDate
                    dtTo = nextSystemDate
                End If

                Dim increment As Integer = 0
                Dim nCnt As Integer = 0

                ds = getNumberOfAccounts(dtFrom, dtTo)
                dt = clearChecks()

                nCnt = ds.Rows.Count + dt.Rows.Count
                pBarSOD.Maximum = nCnt

                If nCnt > 0 Then

                    For Each dr In ds.Rows

                        instID = dr("id")
                        acntNumber = dr("account_number")
                        prinDue = dr("principal_due")
                        intDue = dr("interest_due")
                        scDue = dr("service_charge_due")
                        advancePrinPayment = dr("advance_principal_payment")

                        If advancePrinPayment > 0 Then
                            Dim diff As Double = advancePrinPayment - prinDue

                            If diff >= 0 Then
                                prinDue = 0
                                advancePrinPayment = diff
                            Else
                                advancePrinPayment = 0
                                prinDue = diff * -1
                            End If

                        End If

                        Dim strUpdate = "UPDATE loans set principal_due=principal_due+" + prinDue + ",interest_due=interest_due+" + intDue + ",service_charge_due=service_charge_due+" + scDue +
                                        ",advance_principal_payment=" + advancePrinPayment + " where account_number='" + acntNumber + "'"

                        Dim instUpdate = "UPDATE loan_installment set status=1 where id=" + instID

                        cl.Insert(strUpdate)
                        cl.Insert(instUpdate)

                        increment = increment + 1
                        pBarSOD.Value = increment
                    Next

                    Dim strID As String, strAccountNumber As String
                    Dim valCheckAmount As Double
                    ' clear checks
                    For Each dr In dt.Rows

                        strID = dr("id")
                        strAccountNumber = dr("account_number")
                        valCheckAmount = dr("check_amount")

                        Dim strUpdateSv = "update savings set available_balance=available_balance+" + valCheckAmount.ToString() +
                            " where account_number='" + strAccountNumber + "'"
                        cl.Insert(strUpdateSv)

                        Dim strUpdateChqDep = "update cheque_deposit set status='1' where id=" + strID
                        cl.Insert(strUpdateChqDep)

                    Next

                Else
                    pBarSOD.Maximum = 1
                    pBarSOD.Value = 1

                End If

                Dim updateUsers = "update users set balanced='0' where branch_id='" + frmLogin.txtBranchID.Text.Trim() + "'"
                cl.Insert(updateUsers)

                Dim updateBranch = "update branch set status='0',system_date='" + nextSystemDate.ToString("MM/dd/yyyy") + "' where code='" + frmLogin.txtBranchID.Text.Trim() + "'"
                cl.Insert(updateBranch)
                activemenu.menuStripParent()
                'cl.logs(frmLogin.txtUserName.Text.Trim(), "start of day", procQuery.getSystemDate())

                MessageBox.Show("Start of Day process is successfully completed. Please re-login.")

                'Dim procQuery As New ProcessQuery()
                'Dim cl = New common

                Dim strQuery = "update users set logged_in='0' where username='" + frmLogin.txtUserName.Text.Trim() + "'"

                'cl.logs(frmLogin.txtUserName.Text.Trim(), "exit", procQuery.getSystemDate())
                cl.Insert(strQuery)

                Application.Exit()

            End If


        End If
        btnStart.Enabled = False
    End Sub
    Dim errorMessage As String
    Private Function validateNextSystemDate(ByVal nextSysDate As Date) As Integer
        Dim result As Integer = 0

        If dtPreviousDate = nextSysDate And sysStatus = "9" Then
            'MessageBox.Show("System is already closed for this date.")
            result = 1 ' same date
            errorMessage = "System is already closed for this date."
        End If

        If sysStatus = "0" Then
            result = 2 ' system is still open
            errorMessage = "System is still open"
        End If

        Dim lHoliday As Boolean
        lHoliday = checkIfHoliday(nextSysDate)
        If lHoliday Then
            result = 3 ' holiday
            errorMessage = "Selected date is a Holiday"
        End If

        If nextSysDate.DayOfWeek = DayOfWeek.Saturday Or nextSysDate.DayOfWeek = DayOfWeek.Sunday Then
            result = 4
            errorMessage = "Selected date is a weekend"
        End If

        If dtPreviousDate > nextSysDate Then
            result = 5
            errorMessage = "Select a future date"
        End If

        Return result
    End Function

    Private Function checkIfHoliday(ByVal sysDate As Date) As Boolean
        Dim result As Boolean = False

        Dim strArr() As String
        Dim cl As New common

        Dim searchDate = sysDate.ToString("MMMM dd, yyyy")
        Dim strHolidays = cl.getHolidays()

        strArr = strHolidays.Split(";")

        Dim value1 As String = Array.Find(strArr, Function(x) (x.StartsWith(searchDate)))

        If value1 = Nothing Then
            result = False
        Else
            result = True
        End If

        Return result
    End Function

    Private Function getNumberOfAccounts(ByVal dteFrom As Date, ByVal dteTo As Date) As DataTable
        Dim nCount As DataTable
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("     A.id, ")
            xSQL.AppendLine("     A.account_number, ")
            xSQL.AppendLine("     A.due_date, ")
            xSQL.AppendLine("     A.principal_due, ")
            xSQL.AppendLine("     A.interest_due, ")
            xSQL.AppendLine("     A.service_charge_due,")
            xSQL.AppendLine("     B.advance_principal_payment")
            xSQL.AppendLine("from loan_installment A ")
            xSQL.AppendLine("inner join loans B on B.account_number=A.account_number ")
            xSQL.AppendLine("where A.due_date >= cast('" + dteFrom.ToString.Trim() + "' as date) and A.due_date <= cast('" + dteTo.ToString.Trim() + "' as date) and B.branch_id='" + frmLogin.txtBranchID.Text.Trim() + "'")

            Try
                Dim cl = New common()
                Dim conn = cl.connect()

                Dim cmd As New SqlCommand(xSQL.ToString, conn)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)

                nCount = ds.Tables(0)

            Catch ex As Exception
                Throw New Exception("Error in listing data.", ex)
            End Try
        Catch ex As Exception
            Throw (ex)
        End Try

        Return nCount
    End Function

    Private Function clearChecks() As DataTable
        Dim nResult As DataTable = Nothing

        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("     A.id, ")
            xSQL.AppendLine("     A.account_number, ")
            xSQL.AppendLine("     A.check_amount ")
            xSQL.AppendLine("from cheque_deposit A ")
            xSQL.AppendLine("inner join savings B on B.account_number=A.account_number ")
            xSQL.AppendLine("where A.clearing_date='" + dtpNextSysDate.Value.ToString() + "' and A.status='0' and B.branch_id='" + frmLogin.txtBranchID.Text.Trim() + "'")

            Try
                Dim cl = New common()
                Dim conn = cl.connect()

                Dim cmd As New SqlCommand(xSQL.ToString, conn)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)

                nResult = ds.Tables(0)

            Catch ex As Exception
                Throw New Exception("Error in listing data.", ex)
            End Try
        Catch ex As Exception
            Throw (ex)
        End Try

        Return nResult
    End Function

    Private Sub frmStartOfDay_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'dtpNextSysDate.Value = frmMainMenu.dtSystemDate
        btnStart.Enabled = False
        Dim cl = New common()
        Dim conn = cl.connect()

        Dim strQuery = "select * from branch where code='" + frmLogin.txtBranchID.Text.Trim() + "'"

        Dim DA As New SqlDataAdapter(strQuery, conn)
        Dim ds As New DataSet
        DA.Fill(ds)
        If ds.Tables(0).Rows.Count <> 0 Then
            For Each dr In ds.Tables(0).Rows
                dtpNextSysDate.Value = dr("system_date")
                dtPreviousDate = dr("system_date")
                sysStatus = dr("status")
            Next

        End If
    End Sub

    Private Sub dtpNextSysDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpNextSysDate.ValueChanged
        btnStart.Enabled = True
    End Sub
End Class