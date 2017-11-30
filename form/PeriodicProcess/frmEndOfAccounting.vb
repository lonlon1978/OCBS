Public Class frmEndOfAccounting
    Dim activemenu As New ActiveMenu()
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click

        Dim cl As New common()
        Dim strUpdateStatus = "update branch set status='9' where code='" + frmLogin.txtBranchID.Text.Trim() + "'"
        cl.Insert(strUpdateStatus)
        activemenu.menuStripParent()
        pBarEOA.Maximum = 1
        pBarEOA.Value = 1

        MessageBox.Show("General Ledger is successfully closed. Please re-login.")

        Dim procQuery As New ProcessQuery()
        'Dim cl = New common

        Dim strQuery = "update users set logged_in='0' where username='" + frmLogin.txtUserName.Text.Trim() + "'"

        'cl.logs(frmLogin.txtUserName.Text.Trim(), "exit", procQuery.getSystemDate())
        cl.Insert(strQuery)

        Application.Exit()

    End Sub
End Class