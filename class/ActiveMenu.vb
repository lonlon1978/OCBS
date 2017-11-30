Public Class ActiveMenu
    Dim processquery As New ProcessQuery()
    ' Generate dynamic menu based on the system rights 
    ' of user
    Public Sub generateActiveMenus(ByVal sys_name As String)
        Dim menustrip = frmMainMenu.MenuStrip1
        For Each parentmenu In processquery.getSysmenuArray(sys_name)
            Dim parentitem As New ToolStripMenuItem
            If processquery.getUserRights(frmLogin.txtUserName.Text.ToString).Contains(parentmenu("mnu_name")) Then
                parentitem.Name = parentmenu("mnu_name")
                parentitem.Text = parentmenu("caption")
                parentitem.Tag = parentmenu("link")
                parentitem.TextAlign = ContentAlignment.MiddleLeft
                parentitem.Font = New Font("Segoe UI", 10)
                menustrip.Items.Add(parentitem)
                getChildMenus(parentitem, parentmenu("mnu_name"))
                AddHandler parentitem.Click, AddressOf getEventHandler
            End If
        Next
        menustrip.Items.Add(frmMainMenu.LOGOUTMenuItem)
        menustrip.Items.Add(frmMainMenu.EXITMenuItem)
    End Sub
    ' Passing parent toolstrip and parent menu
    ' To get the child menus if any
    Private Sub getChildMenus(ByRef magulang As ToolStripMenuItem, ByRef colmagulang As String)
        For Each colchild In processquery.getSysmenuArray(colmagulang)
            If processquery.getUserRights(frmLogin.txtUserName.Text.ToString).Contains(colchild("mnu_name")) Then
                Dim anak As New ToolStripMenuItem
                anak.Name = colchild("mnu_name")
                anak.Text = colchild("caption")
                anak.Tag = colchild("link")
                magulang.DropDownItems.Add(anak)
                AddHandler anak.Click, AddressOf getEventHandler
                getChildMenus(anak, anak.Name)
            End If
        Next
    End Sub
    'Iterating through all parent menus
    Public Sub menuStripParent()
        For Each item As ToolStripItem In frmMainMenu.MenuStrip1.Items
            ' IF 1 - USERMAINTENANCE, SYSTEMSETTINGS, ENDOFDAY, GL
            ' ID 9 - USERMAINTENANCE, SYSTEMSETTINGS
            ' IF 0 - ENABLED ALL
            Try
                If (processquery.getBranchStatus() = "1") Then
                    If item.Name = "USERMAINTENANCE" Or item.Name = "SETTINGS" Or item.Name = "GENERALLEDGER" Or item.Name = "PERIODICPROCESS" Then
                        item.Enabled = True
                    Else
                        item.Enabled = False
                    End If
                ElseIf (processquery.getBranchStatus() = "9") Then
                    If item.Name = "USERMAINTENANCE" Or item.Name = "SETTINGS" Then
                        item.Enabled = True
                    Else
                        item.Enabled = False
                    End If
                Else
                    item.Enabled = True
                End If

                If (item.Name = "LOGOUTMenuItem" Or item.Name = "EXITMenuItem") Then
                    item.Enabled = True
                End If
                menuStripChild(item)
            Catch ex As Exception
            End Try
        Next
    End Sub
    'Iterating through all child menus
    Public Sub menuStripChild(ByVal magulang As ToolStripMenuItem)
        If (magulang.DropDownItems.Count > 0) Then
            For Each child In magulang.DropDownItems
                If (processquery.getBranchStatus() = "1") Then
                    If child.Name = "PPEndOfDay" Then
                        child.Enabled = True
                    End If
                End If
            Next
        End If
    End Sub
    ' Set the event handler of every menu
    Private Sub getEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim link = DirectCast(sender, ToolStripMenuItem).Tag
        Dim formName = link
        If link <> "#" Then
            'System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(frmMainMenu.ProductName & "." & link).showDialog()
            showForm(link)
        End If
    End Sub
    ' Set the static form to show
    ' @params - string the name of string form to show
    Public Sub showForm(ByVal link As String)
        Try
            If link = "frmSystemAccess" Then
                frmSystemAccess.ShowDialog()
            ElseIf link = "frmGLAccount" Then
                frmGLAccount.ShowDialog()
            ElseIf link = "frmGLSortCode" Then
                frmGLSortCode.ShowDialog()
                'ElseIf link = "frmGLTransaction" Then
                '    frmGLTransaction.ShowDialog()
            ElseIf link = "frmBatchDebit" Then
                frmBatchDebit.ShowDialog()
            ElseIf link = "frmGLTransaction" Then
                frmGLTransaction.ShowDialog()
            ElseIf link = "frmBatchRelease" Then
                frmBatchRelease.ShowDialog()
            ElseIf link = "frmBatchPayment" Then
                frmBatchPayment.ShowDialog()
            ElseIf link = "frmBatchCredit" Then
                frmBatchCredit.ShowDialog()
            Else
                System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(frmMainMenu.ProductName & "." & link).showDialog()
            End If
        Catch ex As Exception
            MessageBox.Show("Invalid Form Name")
        End Try
    End Sub
End Class
