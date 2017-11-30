Imports System.Text
Imports System.Data.SqlClient
Public Class DataPager
    Dim connection As New common()
    Dim conn = connection.connect()
    Public BS As New BindingSource
    Dim curcount As Integer = 1
    Public _menustrip As New MenuStrip
    Public Sub LoadData(ByVal tblname As String, ByVal txtboxname As TextBox, ByVal colname As String)
        Dim datas As New DataSet
        Dim query As New StringBuilder
        query.AppendLine("SELECT * from " + tblname)
        Try
            Dim cmd As New SqlCommand(query.ToString, conn)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(datas, tblname)
            BS.DataSource = datas.Tables(tblname)
            txtboxname.DataBindings.Add("Text", BS, colname)
        Catch ex As Exception
            Throw New Exception("Error in getting data.", ex)
        End Try
    End Sub
    Public Sub initLabel(ByVal lblname As Label)
        If BS.Count = 1 Then
            lblname.Visible = False
        Else
            lblname.Text = String.Format("Showing {0} of {1}", curcount, BS.Count)
        End If
    End Sub
    Public Sub getNext(ByVal labelName As Label)
        BS.MoveNext()
        If curcount < BS.Count Then
            curcount = curcount + 1
            labelName.Text = (String.Format("Showing {0} of {1}", curcount, BS.Count))
        End If
            End Sub
    Public Sub getPrevious(ByVal labelName As Label)
        BS.MovePrevious()
        If curcount > 1 Then
            curcount = curcount - 1
            labelName.Text = (String.Format("Showing {0} of {1}", curcount, BS.Count))
        End If
    End Sub
    Public Sub getFirst(ByVal labelName As Label)
        BS.MoveFirst()
        curcount = 1
        labelName.Text = (String.Format("Showing {0} of {1}", 1, BS.Count))
    End Sub
    Public Sub getLast(ByVal labelName As Label)
        BS.MoveLast()
        curcount = BS.Count
        labelName.Text = (String.Format("Showing {0} of {1}", BS.Count, BS.Count))
    End Sub
    Public Sub buttonGroup(ByVal menustrip As MenuStrip)
        Dim source As String = "Add, Edit, Delete, Save, Search, Cancel"
        Dim result As String() = Split(source, ",")
        For Each index In result
            Dim parentitem As New ToolStripMenuItem
            parentitem.Name = index
            parentitem.Text = index
            parentitem.Tag = index
            menustrip.Items.Add(parentitem)
            _menustrip = menustrip
            If menustrip.Name = "Save" Then
                menustrip.Enabled = False
            End If
            AddHandler parentitem.Click, AddressOf getEventHandler
        Next
    End Sub
    ' Set the event handler of every menu
    Public Sub getEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
End Class
