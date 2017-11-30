Imports System.Text
Imports System.Data.SqlClient
Public Class ProcessQuery
    Dim connection = New common()
    Dim conn = connection.connect()
    ' Query sysmenu then convert to arraylist
    ' @params mnu_name check if parent has child
    Public Function getSysmenuArray(ByVal mnu_name As String) As ArrayList
        Dim datas As New ArrayList()
        Dim query As New StringBuilder
        query.AppendLine("SELECT * from sysmenu where parent=@mnu_name and avail='1' order by position asc")
        Try
            Dim cmd As New SqlCommand(query.ToString, conn)
            cmd.Parameters.AddWithValue("@mnu_name", mnu_name)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            For Each datarow As DataRow In ds.Tables(0).Rows
                datas.Add(datarow)
            Next
        Catch ex As Exception
            Throw New Exception("Error in getting sysmenu arraylist.", ex)
        End Try
        Return datas
    End Function
    ' Getting all menus in sysrights
    ' @return String Array
    Public Function getUserRights(ByVal user_code As String) As String()
        Dim conn As New common
        Dim mnu_name As String()
        Dim query As New StringBuilder
        query.AppendLine("SELECT * from sysright where user_code=@user_code")
        Try
            Dim cmd As New SqlCommand(query.ToString, conn.connect())
            cmd.Parameters.AddWithValue("@user_code", user_code)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            mnu_name = (From rowdata In ds.Tables(0).AsEnumerable
                   Select rowdata.Field(Of String)("mnu_name")).ToArray
        Catch ex As Exception
            Throw New Exception("Error in getting all menu name", ex)

        End Try
        Return mnu_name
    End Function
    ' Saving in sysright table
    Public Sub CreateSystemRights(ByVal values As String)
        Dim cmd As New SqlCommand
        Dim query As String = "INSERT INTO sysright (user_code, mnu_name, user_type) VALUES "
        Try
            query &= values.TrimEnd(CChar(","))
            cmd = New SqlCommand(query, conn)
            cmd.ExecuteNonQuery()
            MsgBox("New previleged successfuly created.")
        Catch ex As Exception
            MessageBox.Show("Error saving" & ex.Message)
        End Try
    End Sub
    ' Delete previous record in sysright table
    Public Sub DeleteSystemRights(ByVal user_code As String)
        Dim cmd As New SqlCommand
        Try
            cmd = New SqlCommand("DELETE FROM sysright where user_code='" + user_code + "'", conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error deleting" & ex.Message)
        End Try
    End Sub
    ' User GridView
    Public Sub loadUserGridView(ByRef grid As DataGridView, ByVal keyword As String)
        Try
            Dim connection As New common()
            Dim ds As New DataSet
            Dim query = "SELECT username 'User Name', fullname 'Full Name', usertype 'User Type'  FROM users"
            If keyword <> "" Then
                query &= " WHERE username like '%" + keyword + "%' OR fullname like '%" + keyword + "%' OR usertype like '%" + keyword + "%'"
            End If
            Dim sda As SqlDataAdapter = New SqlDataAdapter(query, connection.connect())
            sda.Fill(ds, "users")
            grid.DataSource = ds.Tables("users")
        Catch ex As Exception
            MessageBox.Show("Error in users - ", ex.Message.ToString)
        End Try
    End Sub
    Public Function getBatchNumber() As String
        Dim result = ""
        Dim cmd As New SqlCommand
        Dim query As String = "SELECT dbo.LPAD(MAX(ISNULL(batch_number,0))+1, 5, 0) FROM branch WHERE code=(select branch_id from users where username='" + frmLogin.txtUserName.Text.ToString + "')"
        Try
            cmd = New SqlCommand(query, conn)
            result = cmd.ExecuteScalar()
        Catch ex As Exception
            MessageBox.Show("Error getting batch number" & ex.Message)
        End Try
        Return result
    End Function
    Public Function getBranchId() As String
        Dim result = ""
        Dim cmd As New SqlCommand
        Dim query As String = "SELECT branch_id from users WHERE username='" + frmLogin.txtUserName.Text.ToString + "'"
        Try
            cmd = New SqlCommand(query, conn)
            result = cmd.ExecuteScalar()
        Catch ex As Exception
            MessageBox.Show("Error getting branch id" & ex.Message)
        End Try
        Return result
    End Function
    Public Function getTellerId() As String
        Dim result = ""
        Dim cmd As New SqlCommand
        Dim query As String = "SELECT id from users WHERE username='" + frmLogin.txtUserName.Text.ToString + "'"
        Try
            cmd = New SqlCommand(query, conn)
            result = cmd.ExecuteScalar()
        Catch ex As Exception
            MessageBox.Show("Error getting teller id" & ex.Message)
        End Try
        Return result
    End Function
    Public Function getNextCode() As String
        Return getBranchId() + "-" + getBatchNumber()
    End Function
    Public Function getBranchStatus() As String
        Dim result = ""
        Dim cmd As New SqlCommand
        Dim query As String = "SELECT status from branch WHERE code='" + getBranchId() + "'"
        Try
            cmd = New SqlCommand(query, conn)
            result = cmd.ExecuteScalar()
        Catch ex As Exception
            MessageBox.Show("Error getting branch status" & ex.Message)
        End Try
        Return result
    End Function
    Public Function getSystemDate() As String
        Dim result = ""
        Dim cmd As New SqlCommand
        Dim query As String = "SELECT system_date from branch WHERE code='" + getBranchId() + "'"
        Try
            cmd = New SqlCommand(query, conn)
            result = cmd.ExecuteScalar()
        Catch ex As Exception
            MessageBox.Show("Error getting branch status" & ex.Message)
        End Try
        Return result
    End Function
End Class
