Imports System.Data.SqlClient
Imports System.Net.NetworkInformation
Public Class frmLogin
    Dim dtExpiryDate As Date
    Dim activemenu As New ActiveMenu()
    Dim sys_name As String = "Core Banking System"
    Dim strLogged As String = ""
    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click

        Application.Exit()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click

        Dim cl = New common
        Dim conn = cl.connect()

        Dim macAddress = getMacAddress()
        Dim userMacAddress = getUserMacAddress()

        Dim dateToday As Date = DateTime.Now
        Dim expiryDate As Date = "11-30-2017"

        Dim num = DateDiff(DateInterval.Day, dateToday, expiryDate)

        'If DateDiff(DateInterval.Day, dateToday, expiryDate) = 0 Then

        '    MessageBox.Show("Trial version has expired.")

        'Else
        '    If macAddress <> userMacAddress Then
        '        MessageBox.Show("User is not allowed to access the system using this local computer.")
        '    Else
        '        conn.Close()
        '        Dim encrypPass = cl.base64Encode(txtPassword.Text.Trim())

        '        Dim lOk = funcValidate(txtUserName.Text.Trim(), encrypPass, conn)

        '        If lOk = "1" Then

        'If strLogged = "0" Then
        Dim strQuery = "update users set logged_in='1' where username='" + txtUserName.Text.Trim() + "'"

        cl.Insert(strQuery)

        Me.Hide()
        frmMainMenu.Show()
        activemenu.generateActiveMenus(sys_name)
        activemenu.menuStripParent()
        'Else
        'lOk = "2"
        'End If

        '        End If

        'If lOk = "2" Then
        '    MessageBox.Show("User is already logged in.")
        'Else
        '    If lOk = "3" Then
        '        MessageBox.Show("Invalid User Name / Password.")
        '    End If
        'End If

        '    End If
        'End If
    End Sub
    Function getMacAddress()

        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()

        Return nics(0).GetPhysicalAddress.ToString
    End Function

    Function getUserMacAddress()
        Dim strMacAddress As String = ""

        Dim cl = New common
        Dim conn = cl.connect()

        Dim strQuery = "select physical_address from users where username='" + txtUserName.Text.Trim() + "'"

        Dim DA As New SqlDataAdapter(strQuery, conn)
        Dim ds As New DataSet
        DA.Fill(ds)
        If ds.Tables(0).Rows.Count <> 0 Then
            'lvalid = "1"
            For Each dr In ds.Tables(0).Rows
                strMacAddress = dr("physical_address")
            Next

        End If
        conn.Close()
        Return strMacAddress
    End Function


    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Refresh()
    End Sub

    Public Function funcValidate(ByVal strUser As String, ByVal encryptedVal As String, ByVal con As SqlConnection)
        Dim lvalid = "0"


        Dim strQuery = "select fullname,usertype,branch_id,logged_in,expiry_date from users where username='" + strUser + "' and password='" + encryptedVal + "'"

        Dim DA As New SqlDataAdapter(strQuery, con)
        Dim ds As New DataSet
        DA.Fill(ds)
        If ds.Tables(0).Rows.Count <> 0 Then
            lvalid = "1"
            For Each dr In ds.Tables(0).Rows
                txtFullName.Text = dr("fullname")
                txtUserType.Text = dr("usertype")
                txtBranchID.Text = dr("branch_id")
                strLogged = dr("logged_in")
                dtExpiryDate = dr("expiry_date")
            Next


        Else
            lvalid = "3"
        End If


        'Dim strQuery2 = "select system_date from sysparam"

        'Dim DA2 As New SqlDataAdapter(strQuery2, con)
        'Dim ds2 As New DataSet
        'DA2.Fill(ds)
        'If ds2.Tables(0).Rows.Count <> 0 Then
        '    For Each dr2 In ds2.Tables(0).Rows
        '        dtExpiryDate = dr("expiry_date")
        '    Next

        'End If

        Return lvalid
    End Function
    Private Sub ListMenuItems()
        For Each _control As Object In Me.Controls
            If TypeOf (_control) Is MenuStrip Then
                For Each itm As ToolStripMenuItem In _control.items
                    MessageBox.Show("Parent : " & itm.Name)
                    If itm.DropDownItems.Count > 0 Then LoopMenuItems(itm)
                Next
            End If
        Next

    End Sub

    Private Function LoopMenuItems(ByVal parent As ToolStripMenuItem) As Object

        Dim retval As Object = Nothing

        For Each child As Object In parent.DropDownItems

            MessageBox.Show("Child : " & child.name)

            If TypeOf (child) Is ToolStripMenuItem Then
                If child.DropDownItems.Count > 0 Then
                    retval = LoopMenuItems(child)
                    If Not retval Is Nothing Then Exit For
                End If
            End If
        Next

        Return retval
    End Function
End Class
