Imports System.Text
Imports System.Data.SqlClient
Imports System.Net.Dns
Imports System.Net

Friend Class UserM
#Region "Properties"

    Private _fullname As String
    Friend Property fullname() As String
        Get
            Return _fullname
        End Get
        Set(ByVal Value As String)
            _fullname = Value
        End Set
    End Property
    Private _wdl_limit As String
    Friend Property wdl_limit() As String
        Get
            Return _wdl_limit
        End Get
        Set(ByVal Value As String)
            _wdl_limit = Value
        End Set
    End Property
    Private _branch_id As String
    Friend Property branch_id() As String
        Get
            Return _branch_id
        End Get
        Set(ByVal Value As String)
            _branch_id = Value
        End Set
    End Property

    Private _UserName As String
    Friend Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal Value As String)
            _UserName = Value
        End Set
    End Property
    Private _Expiry_Date As String
    Friend Property Expiry_Date() As String
        Get
            Return _Expiry_Date
        End Get
        Set(ByVal Value As String)
            _Expiry_Date = Value
        End Set
    End Property

    Private _Password As String
    Friend Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property

    Private _UserID As String
    Friend Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(ByVal Value As String)
            _UserID = Value
        End Set
    End Property

    Private _UserLevel As String
    Friend Property UserLevel() As String
        Get
            Return _UserLevel
        End Get
        Set(ByVal Value As String)
            _UserLevel = Value
        End Set
    End Property

    Private _Status As String
    Friend Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal Value As String)
            _Status = Value
        End Set
    End Property

    Private _Found As Boolean = False
    Friend Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property

    Private _Updated As Boolean = False
    Friend Property Updated() As Boolean
        Get
            Return _Updated
        End Get
        Set(ByVal value As Boolean)
            _Updated = value
        End Set
    End Property
#End Region


End Class

Friend Class UserDB
    Private tbl As String = "users"

    Friend Function UserGetList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("     id, ")
            xSQL.AppendLine("     fullname as 'Fullname', ")
            xSQL.AppendLine("     Username as 'User ID', ")
            xSQL.AppendLine("     password as 'Password', ")
            xSQL.AppendLine("     usertype as 'User Level', ")
            xSQL.AppendLine("     wdl_limit as 'Withdrawal Limit', ")
            xSQL.AppendLine("     branch_id as 'Branch Code', ")
            xSQL.AppendLine("     Expiry_Date as 'Expiry Date', ")
            xSQL.AppendLine("     Status ")
            xSQL.AppendLine("FROM  " + tbl + "  ")

            Try
                Dim cl = New common()
                Dim conn = cl.connect()

                Dim DA As New SqlDataAdapter(xSQL.ToString, conn)
                Dim ds As New DataSet
                DA.Fill(ds)
                If ds.Tables(0).Rows.Count <> 0 Then
                    dt = ds.Tables(0)
                End If

            Catch ex As Exception
                Throw New Exception("Error in listing data.", ex)
            End Try
        Catch ex As Exception
            Throw (ex)
        End Try
        Return dt
    End Function
    Friend Function UserGetList(ByVal SearchField As String, ByVal SearchSTR As String) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("     id, ")
            xSQL.AppendLine("     fullname as 'Fullname', ")
            xSQL.AppendLine("     Username as 'User ID', ")
            xSQL.AppendLine("     password as 'Password', ")
            xSQL.AppendLine("     usertype as 'User Level', ")
            xSQL.AppendLine("     wdl_limit as 'Withdrawal Limit', ")
            xSQL.AppendLine("     branch_id as 'Branch Code', ")
            xSQL.AppendLine("     Expiry_Date as 'Expiry Date', ")
            xSQL.AppendLine("     Status ")
            xSQL.AppendLine("FROM  " + tbl + "  ")
            xSQL.AppendLine("WHERE CAST(" + SearchField + " as varchar(50)) like '%' + @SearchSTR + '%' ")

            Try
                Dim cl = New common()
                Dim conn = cl.connect()

                Dim cmd As New SqlCommand(xSQL.ToString, conn)
                cmd.Parameters.AddWithValue("@SearchSTR", SearchSTR)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)

                If ds.Tables(0).Rows.Count <> 0 Then
                    dt = ds.Tables(0)
                End If

            Catch ex As Exception
                Throw New Exception("Error in listing data.", ex)
            End Try
        Catch ex As Exception
            Throw (ex)
        End Try
        Return dt
    End Function

    Friend Function UserGetFile(ByVal pUserID As String) As UserM
        Dim dt As New UserM
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("     fullname, ")
            xSQL.AppendLine("     Username, ")
            xSQL.AppendLine("     password, ")
            xSQL.AppendLine("     usertype, ")
            xSQL.AppendLine("     wdl_limit, ")
            xSQL.AppendLine("     branch_id, ")
            xSQL.AppendLine("     Expiry_Date, ")
            xSQL.AppendLine("     Status ")
            xSQL.AppendLine("FROM  " + tbl + "  ")
            xSQL.AppendLine("WHERE id = @UserID ")
            Try

                Dim cl = New common()
                Dim conn = cl.connect()

                Dim cmd As New SqlCommand(xSQL.ToString, conn)
                cmd.Parameters.AddWithValue("@UserID", pUserID)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)
                If ds.Tables(0).Rows.Count <> 0 Then
                    For Each dr In ds.Tables(0).Rows
                        dt.Found = True

                        If Not IsDBNull(dr("Username")) Then dt.UserID = dr("Username")
                        If Not IsDBNull(dr("Status")) Then dt.Status = dr("Status")
                        If Not IsDBNull(dr("Expiry_Date")) Then dt.Expiry_Date = dr("Expiry_Date")
                        If Not IsDBNull(dr("Usertype")) Then dt.UserLevel = dr("Usertype")
                        If Not IsDBNull(dr("Password")) Then dt.Password = dr("Password")
                        If Not IsDBNull(dr("fullname")) Then dt.fullname = dr("fullName")
                        If Not IsDBNull(dr("Wdl_limit")) Then dt.wdl_limit = dr("Wdl_limit")
                        If Not IsDBNull(dr("branch_id")) Then dt.branch_id = dr("branch_id")

                    Next
                End If
                'MessageBox.Show(dt.Name)
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw (ex)
        End Try
        Return dt
    End Function


    Friend Function DeleteRecord(ByVal cItem As UserM) As UserM
        Dim cReturn As New UserM
        Try
            'MessageBox.Show(cItem.Name)

            Dim cl = New common()
            Dim conn = cl.connect()

            Dim xSQL As New StringBuilder
            xSQL.AppendLine("DELETE  FROM " + tbl)
            xSQL.AppendLine("WHERE UserID = @UserID ")

            Dim cmd As New SqlCommand(xSQL.ToString, conn)
            cmd.Parameters.AddWithValue("@UserID", cItem.UserID)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = cItem
        Return cReturn

    End Function

    'Friend Function UserInsertFile(ByVal cItem As UserM, ByVal strBranchCode As String) As UserM
    '    Dim cReturn As New UserM
    '    Try
    '        Dim cl = New common()
    '        Dim conn = cl.connect()

    '        Dim n1 As Integer
    '        n1 = CreateNewID(strBranchCode)
    '        If n1 > 99 Then Throw New Exception("UserNo limit exceeded!")
    '        cItem.UserNo = Str(n1).PadLeft(2, "0")
    '        Dim strUserNo = n1.ToString().PadLeft(2, "0")

    '        ' disbLimit = fullname

    '        Dim xSQL As New StringBuilder
    '        xSQL.AppendLine("INSERT INTO  " + tbl + "  ")
    '        xSQL.AppendLine("( ")
    '        xSQL.AppendLine("     BranchCode, ")
    '        xSQL.AppendLine("     UserNo, ")
    '        xSQL.AppendLine("     UserID, ")
    '        xSQL.AppendLine("     ExpiryDate, ")
    '        xSQL.AppendLine("     UserLevel, ")
    '        xSQL.AppendLine("     Status, ")
    '        xSQL.AppendLine("     DisbLimit, ")
    '        xSQL.AppendLine("     PassBkPrt, ")
    '        xSQL.AppendLine("     BoxLimit, ")
    '        xSQL.AppendLine("     SystemCode, ")
    '        xSQL.AppendLine("     MenuCode, ")
    '        xSQL.AppendLine("     HelpLevel, ")
    '        xSQL.AppendLine("     AltFlag, ")
    '        xSQL.AppendLine("     UsrCol, ")
    '        xSQL.AppendLine("     PrtPort, ")
    '        xSQL.AppendLine("     PrtWord, ")
    '        xSQL.AppendLine("     PrtBaud, ")
    '        xSQL.AppendLine("     UserFlag, ")
    '        'xSQL.AppendLine("     Name, ")
    '        'xSQL.AppendLine("     Department, ")
    '        xSQL.AppendLine("     FirstName, ")
    '        xSQL.AppendLine("     MiddleInitial, ")
    '        xSQL.AppendLine("     LastName, ")
    '        'xSQL.AppendLine("     Section, ")
    '        xSQL.AppendLine("     Password ")
    '        xSQL.AppendLine(") ")
    '        xSQL.AppendLine("VALUES ( ")
    '        xSQL.AppendLine("     @BranchCode, ")
    '        xSQL.AppendLine("     @UserNo, ")
    '        xSQL.AppendLine("     @UserID, ")
    '        xSQL.AppendLine("     @ExpiryDate, ")
    '        xSQL.AppendLine("     @UserLevel, ")
    '        xSQL.AppendLine("     @Status, ")
    '        xSQL.AppendLine("     @DisbLimit, ")
    '        xSQL.AppendLine("     ' ', ")
    '        xSQL.AppendLine("     @BoxLimit, ")
    '        xSQL.AppendLine("     '2', ")
    '        xSQL.AppendLine("     '3', ")
    '        xSQL.AppendLine("     '11', ")
    '        xSQL.AppendLine("     '0', ")
    '        xSQL.AppendLine("     '0', ")
    '        xSQL.AppendLine("     '0', ")
    '        xSQL.AppendLine("     '0', ")
    '        xSQL.AppendLine("     @PrtBaud, ")
    '        xSQL.AppendLine("     '0', ")
    '        ' xSQL.AppendLine("     @Name, ")
    '        'xSQL.AppendLine("     @Department, ")
    '        xSQL.AppendLine("     @FirstName, ")
    '        xSQL.AppendLine("     @MiddleInitial, ")
    '        xSQL.AppendLine("     @LastName, ")
    '        'xSQL.AppendLine("     ' ', ")
    '        xSQL.AppendLine("     @Password ")
    '        xSQL.AppendLine(")")

    '        Dim cmd As New SqlCommand(xSQL.ToString, conn)
    '        cmd.Parameters.AddWithValue("@BranchCode", strBranchCode)
    '        cmd.Parameters.AddWithValue("@UserNo", strUserNo)
    '        cmd.Parameters.AddWithValue("@UserID", cItem.UserID)
    '        cmd.Parameters.AddWithValue("@ExpiryDate", cItem.ExpiryDate)
    '        cmd.Parameters.AddWithValue("@UserLevel", cItem.UserLevel)
    '        cmd.Parameters.AddWithValue("@Status", cItem.Status)
    '        cmd.Parameters.AddWithValue("@Password", cItem.Password)
    '        cmd.Parameters.AddWithValue("@BoxLimit", "0")
    '        cmd.Parameters.AddWithValue("@PrtBaud", "001")
    '        'cmd.Parameters.AddWithValue("@FirstName", cItem.FirstName)
    '        'cmd.Parameters.AddWithValue("@MiddleInitial", cItem.MiddleInitial)
    '        'cmd.Parameters.AddWithValue("@LastName", cItem.LastName)
    '        'cmd.Parameters.AddWithValue("@DisbLimit", cItem.FirstName + " " + cItem.MiddleInitial + ". " + cItem.LastName)

    '        Dim n As Integer = cmd.ExecuteNonQuery

    '        If n <> 0 Then
    '            cItem.Updated = True
    '            'SaveNewID(CInt(cItem.UserNo))
    '            cReturn = cItem
    '        End If
    '    Catch ex As Exception
    '        Throw (ex)
    '    End Try
    '    Return cReturn
    'End Function

    Friend Function UserUpdateFile(ByVal cItem As UserM, ByVal OldUserID As String) As UserM
        Dim cReturn As New UserM
        Try
            Dim cl = New common()
            Dim conn = cl.connect()

            Dim xSQL As New StringBuilder
            xSQL.AppendLine("UPDATE  " + tbl + "  SET ")
            'xSQL.AppendLine("     BranchCode = @BranchCode, ")
            'xSQL.AppendLine("     UserID = @UserID, ")
            xSQL.AppendLine("     Status = @Status, ")
            xSQL.AppendLine("     ExpiryDate = @ExpiryDate, ")
            xSQL.AppendLine("     UserLevel = @UserLevel, ")
            'xSQL.AppendLine("     Name = @Name, ")
            xSQL.AppendLine("     FirstName = @FirstName, ")
            xSQL.AppendLine("     MiddleInitial = @MiddleInitial, ")
            xSQL.AppendLine("     LastName = @LastName, ")
            'xSQL.AppendLine("     PrtBaud = @PrtBaud, ")
            'xSQL.AppendLine("     Section = '', ")
            'xSQL.AppendLine("     BoxLimit = @BoxLimit, ")
            xSQL.AppendLine("     Password = @Password ")
            xSQL.AppendLine("WHERE UserID = @UserID")
            '  xSQL.AppendLine("WHERE UserNo = @UserNo")
            '  xSQL.AppendLine("   and UserID = @UserID")

            'Dim strBoxLimit = cItem.BoxLimit.ToString().PadLeft(18, "0")

            Dim cmd As New SqlCommand(xSQL.ToString, conn)
            'cmd.Parameters.AddWithValue("@BranchCode", cItem.BranchCode)
            cmd.Parameters.AddWithValue("@UserID", OldUserID)
            cmd.Parameters.AddWithValue("@Status", cItem.Status)
            cmd.Parameters.AddWithValue("@ExpiryDate", cItem.Expiry_Date)
            cmd.Parameters.AddWithValue("@UserLevel", cItem.UserLevel)
            'cmd.Parameters.AddWithValue("@Name", cItem.Name)
            cmd.Parameters.AddWithValue("@Password", cItem.Password)
            'cmd.Parameters.AddWithValue("@UserNo", cItem.UserNo)
            'cmd.Parameters.AddWithValue("@OldUserID", OldUserID.Trim)
            'cmd.Parameters.AddWithValue("@FirstName", cItem.FirstName)
            'cmd.Parameters.AddWithValue("@MiddleInitial", cItem.MiddleInitial)
            'cmd.Parameters.AddWithValue("@LastName", cItem.LastName)
            ''cmd.Parameters.AddWithValue("@PrtBaud", cItem.PrtBaud)


            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw (ex)
        End Try
        cReturn = cItem
        Return cReturn
    End Function

    Private Function CreateNewID(ByVal cBranchCode As String) As String
        Dim sReturn As String = ""
        Dim tbl As String = "usrfile"
        Try
            Dim cl = New common()
            Dim conn = cl.connect()

            Dim x As Integer
            For x = 1 To 99
                Dim cmd As New SqlCommand("select UserNo from " + tbl + " where  UserNo=@UserNo and LTRIM(RTRIM(branchcode))=@BranchCode", conn)
                cmd.Parameters.AddWithValue("@UserNo", x)
                cmd.Parameters.AddWithValue("@BranchCode", cBranchCode)

                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)

                If ds.Tables(0).Rows.Count = 0 Then Exit For
            Next
            sReturn = Str(x).PadLeft(2, "0")

        Catch ex As Exception

        End Try
        Return sReturn
    End Function
    Friend Function getBranchCode(ByVal pUserID As String) As String
        Dim dt As New UserM
        Dim BrCode As String = ""

        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("     BranchCode ")
            xSQL.AppendLine("FROM  " + tbl + "  ")
            xSQL.AppendLine("WHERE UserID = @UserID ")
            Try

                Dim cl = New common()
                Dim conn = cl.connect()

                Dim cmd As New SqlCommand(xSQL.ToString, conn)
                cmd.Parameters.AddWithValue("@UserID", pUserID)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)
                If ds.Tables(0).Rows.Count <> 0 Then
                    For Each dr In ds.Tables(0).Rows
                        dt.Found = True

                        BrCode = dr("BranchCode")

                    Next
                End If
                'MessageBox.Show(dt.Name)
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw (ex)
        End Try
        Return BrCode
    End Function
    Friend Function isDupliUserID(userID As String) As Boolean
        Dim cReturn As Boolean
        cReturn = False
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine(" username ")
            xSQL.AppendLine("FROM  " + tbl + "  ")
            xSQL.AppendLine("where username='" + userID + "'")

            Try

                Dim cl = New common
                Dim conn = cl.connect()

                Dim DA As New SqlDataAdapter(xSQL.ToString, conn)
                Dim ds As New DataSet
                DA.Fill(ds)
                If ds.Tables(0).Rows.Count <> 0 Then
                    For Each dr In ds.Tables(0).Rows
                        cReturn = True
                    Next
                    '   dt = ds.Tables(0)

                End If

            Catch ex As Exception
                Throw New Exception("Error in listing data.", ex)
            End Try
        Catch ex As Exception
            Throw (ex)
        End Try

        Return cReturn
    End Function

    Friend Function getCustomerList(ByVal SearchField As String, ByVal SearchSTR As String) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("     id, ")
            xSQL.AppendLine("     display_name as 'Display name', ")
            xSQL.AppendLine("     (numAndStreet+' '+Barangay+' '+municipality+' '+province) as address, ")
            xSQL.AppendLine("     type as 'Customer Type', ")
            xSQL.AppendLine("     date_of_birth as 'Birthdate', ")
            xSQL.AppendLine("FROM  customer where status='Active' ")
            xSQL.AppendLine("WHERE CAST(" + SearchField + " as varchar(50)) like '%' + @SearchSTR + '%' ")

            Try
                Dim cl = New common()
                Dim conn = cl.connect()

                Dim cmd As New SqlCommand(xSQL.ToString, conn)
                cmd.Parameters.AddWithValue("@SearchSTR", SearchSTR)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)

                If ds.Tables(0).Rows.Count <> 0 Then
                    dt = ds.Tables(0)
                End If

            Catch ex As Exception
                Throw New Exception("Error in listing data.", ex)
            End Try
        Catch ex As Exception
            Throw (ex)
        End Try
        Return dt
    End Function

    Friend Function getCustomerList() As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim xSQL As New StringBuilder
            xSQL.AppendLine("SELECT ")
            xSQL.AppendLine("     id, ")
            xSQL.AppendLine("     display_name as 'Display name', ")
            xSQL.AppendLine("     (numAndStreet+' '+Barangay+' '+municipality+' '+province) as address, ")
            xSQL.AppendLine("     type as 'Customer Type', ")
            xSQL.AppendLine("     date_of_birth as 'Birthdate' ")
            xSQL.AppendLine("FROM  customer where status='Active' ")

            Try
                Dim cl = New common()
                Dim conn = cl.connect()

                Dim cmd As New SqlCommand(xSQL.ToString, conn)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet
                da.Fill(ds)

                If ds.Tables(0).Rows.Count <> 0 Then
                    dt = ds.Tables(0)
                End If

            Catch ex As Exception
                Throw New Exception("Error in listing data.", ex)
            End Try
        Catch ex As Exception
            Throw (ex)
        End Try
        Return dt
    End Function

End Class

