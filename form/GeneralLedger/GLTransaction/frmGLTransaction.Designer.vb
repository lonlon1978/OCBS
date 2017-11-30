<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGLTransaction
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GBSortCode = New System.Windows.Forms.GroupBox()
        Me.TxtTrnDate = New System.Windows.Forms.TextBox()
        Me.BtnCreate = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtTotCred = New System.Windows.Forms.TextBox()
        Me.TxtTotDeb = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblGLType = New System.Windows.Forms.Label()
        Me.LblDesc = New System.Windows.Forms.Label()
        Me.LblSortCode = New System.Windows.Forms.Label()
        Me.TxtTellerId = New System.Windows.Forms.TextBox()
        Me.TxtBatchNo = New System.Windows.Forms.TextBox()
        Me.BtnFind = New System.Windows.Forms.Button()
        Me.dgvGLAddTrans = New System.Windows.Forms.DataGridView()
        Me.GL_Acct_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GL_Acct_Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStripGL = New System.Windows.Forms.MenuStrip()
        Me.Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Search = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvGLTransData = New System.Windows.Forms.DataGridView()
        Me.LblSearch = New System.Windows.Forms.Label()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.ErrorProviderGLTrans = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GBSortCode.SuspendLayout()
        CType(Me.dgvGLAddTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStripGL.SuspendLayout()
        CType(Me.dgvGLTransData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderGLTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GBSortCode
        '
        Me.GBSortCode.Controls.Add(Me.TxtTrnDate)
        Me.GBSortCode.Controls.Add(Me.BtnCreate)
        Me.GBSortCode.Controls.Add(Me.Label6)
        Me.GBSortCode.Controls.Add(Me.Label5)
        Me.GBSortCode.Controls.Add(Me.TxtTotCred)
        Me.GBSortCode.Controls.Add(Me.TxtTotDeb)
        Me.GBSortCode.Controls.Add(Me.Label4)
        Me.GBSortCode.Controls.Add(Me.Label3)
        Me.GBSortCode.Controls.Add(Me.Label2)
        Me.GBSortCode.Controls.Add(Me.Label1)
        Me.GBSortCode.Controls.Add(Me.LblGLType)
        Me.GBSortCode.Controls.Add(Me.LblDesc)
        Me.GBSortCode.Controls.Add(Me.LblSortCode)
        Me.GBSortCode.Controls.Add(Me.TxtTellerId)
        Me.GBSortCode.Controls.Add(Me.TxtBatchNo)
        Me.GBSortCode.Controls.Add(Me.BtnFind)
        Me.GBSortCode.Location = New System.Drawing.Point(37, 44)
        Me.GBSortCode.Name = "GBSortCode"
        Me.GBSortCode.Size = New System.Drawing.Size(765, 173)
        Me.GBSortCode.TabIndex = 17
        Me.GBSortCode.TabStop = False
        '
        'TxtTrnDate
        '
        Me.TxtTrnDate.Enabled = False
        Me.TxtTrnDate.Location = New System.Drawing.Point(440, 44)
        Me.TxtTrnDate.MaxLength = 50
        Me.TxtTrnDate.Name = "TxtTrnDate"
        Me.TxtTrnDate.Size = New System.Drawing.Size(151, 20)
        Me.TxtTrnDate.TabIndex = 15
        '
        'BtnCreate
        '
        Me.BtnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCreate.Location = New System.Drawing.Point(440, 109)
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(86, 23)
        Me.BtnCreate.TabIndex = 14
        Me.BtnCreate.Text = "Entry"
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Total Debit"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(220, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Total Credit"
        '
        'TxtTotCred
        '
        Me.TxtTotCred.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotCred.Location = New System.Drawing.Point(223, 111)
        Me.TxtTotCred.MaxLength = 50
        Me.TxtTotCred.Name = "TxtTotCred"
        Me.TxtTotCred.ReadOnly = True
        Me.TxtTotCred.Size = New System.Drawing.Size(151, 22)
        Me.TxtTotCred.TabIndex = 11
        Me.TxtTotCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotDeb
        '
        Me.TxtTotDeb.Cursor = System.Windows.Forms.Cursors.Default
        Me.TxtTotDeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotDeb.Location = New System.Drawing.Point(34, 111)
        Me.TxtTotDeb.MaxLength = 3
        Me.TxtTotDeb.Name = "TxtTotDeb"
        Me.TxtTotDeb.ReadOnly = True
        Me.TxtTotDeb.Size = New System.Drawing.Size(151, 22)
        Me.TxtTotDeb.TabIndex = 10
        Me.TxtTotDeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(259, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(532, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(113, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(622, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Fields with * is required."
        '
        'LblGLType
        '
        Me.LblGLType.AutoSize = True
        Me.LblGLType.Location = New System.Drawing.Point(437, 25)
        Me.LblGLType.Name = "LblGLType"
        Me.LblGLType.Size = New System.Drawing.Size(89, 13)
        Me.LblGLType.TabIndex = 5
        Me.LblGLType.Text = "Transaction Date"
        '
        'LblDesc
        '
        Me.LblDesc.AutoSize = True
        Me.LblDesc.Location = New System.Drawing.Point(220, 25)
        Me.LblDesc.Name = "LblDesc"
        Me.LblDesc.Size = New System.Drawing.Size(33, 13)
        Me.LblDesc.TabIndex = 4
        Me.LblDesc.Text = "Teller"
        '
        'LblSortCode
        '
        Me.LblSortCode.AutoSize = True
        Me.LblSortCode.Location = New System.Drawing.Point(32, 25)
        Me.LblSortCode.Name = "LblSortCode"
        Me.LblSortCode.Size = New System.Drawing.Size(75, 13)
        Me.LblSortCode.TabIndex = 3
        Me.LblSortCode.Text = "Batch Number"
        '
        'TxtTellerId
        '
        Me.TxtTellerId.Enabled = False
        Me.TxtTellerId.Location = New System.Drawing.Point(223, 44)
        Me.TxtTellerId.MaxLength = 50
        Me.TxtTellerId.Name = "TxtTellerId"
        Me.TxtTellerId.Size = New System.Drawing.Size(151, 20)
        Me.TxtTellerId.TabIndex = 1
        '
        'TxtBatchNo
        '
        Me.TxtBatchNo.Enabled = False
        Me.TxtBatchNo.Location = New System.Drawing.Point(34, 44)
        Me.TxtBatchNo.MaxLength = 3
        Me.TxtBatchNo.Name = "TxtBatchNo"
        Me.TxtBatchNo.Size = New System.Drawing.Size(151, 20)
        Me.TxtBatchNo.TabIndex = 0
        '
        'BtnFind
        '
        Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BtnFind.Location = New System.Drawing.Point(440, 108)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(86, 23)
        Me.BtnFind.TabIndex = 16
        Me.BtnFind.Text = "View Detail"
        Me.BtnFind.UseVisualStyleBackColor = True
        '
        'dgvGLAddTrans
        '
        Me.dgvGLAddTrans.AllowUserToAddRows = False
        Me.dgvGLAddTrans.AllowUserToDeleteRows = False
        Me.dgvGLAddTrans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGLAddTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvGLAddTrans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GL_Acct_Code, Me.GL_Acct_Desc, Me.Debit, Me.Credit, Me.Remarks})
        Me.dgvGLAddTrans.Location = New System.Drawing.Point(37, 234)
        Me.dgvGLAddTrans.Name = "dgvGLAddTrans"
        Me.dgvGLAddTrans.ReadOnly = True
        Me.dgvGLAddTrans.RowHeadersVisible = False
        Me.dgvGLAddTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGLAddTrans.Size = New System.Drawing.Size(765, 218)
        Me.dgvGLAddTrans.TabIndex = 22
        '
        'GL_Acct_Code
        '
        Me.GL_Acct_Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.GL_Acct_Code.FillWeight = 415.0327!
        Me.GL_Acct_Code.Frozen = True
        Me.GL_Acct_Code.HeaderText = "GL Acct Code"
        Me.GL_Acct_Code.Name = "GL_Acct_Code"
        Me.GL_Acct_Code.ReadOnly = True
        Me.GL_Acct_Code.Width = 120
        '
        'GL_Acct_Desc
        '
        Me.GL_Acct_Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.GL_Acct_Desc.FillWeight = 94.54642!
        Me.GL_Acct_Desc.HeaderText = "GL Acct Desc"
        Me.GL_Acct_Desc.Name = "GL_Acct_Desc"
        Me.GL_Acct_Desc.ReadOnly = True
        Me.GL_Acct_Desc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GL_Acct_Desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GL_Acct_Desc.Width = 200
        '
        'Debit
        '
        Me.Debit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Debit.FillWeight = 14.202!
        Me.Debit.HeaderText = "Debit"
        Me.Debit.Name = "Debit"
        Me.Debit.ReadOnly = True
        Me.Debit.Width = 120
        '
        'Credit
        '
        Me.Credit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Credit.FillWeight = 14.202!
        Me.Credit.HeaderText = "Credit"
        Me.Credit.Name = "Credit"
        Me.Credit.ReadOnly = True
        Me.Credit.Width = 120
        '
        'Remarks
        '
        Me.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Remarks.FillWeight = 11.25553!
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        Me.Remarks.Width = 200
        '
        'MenuStripGL
        '
        Me.MenuStripGL.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Add, Me.Cancel, Me.Save, Me.CloseToolStripMenuItem, Me.Search})
        Me.MenuStripGL.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripGL.Name = "MenuStripGL"
        Me.MenuStripGL.Size = New System.Drawing.Size(827, 24)
        Me.MenuStripGL.TabIndex = 23
        Me.MenuStripGL.Text = "MenuStrip1"
        '
        'Add
        '
        Me.Add.Name = "Add"
        Me.Add.Size = New System.Drawing.Size(41, 20)
        Me.Add.Text = "Add"
        '
        'Cancel
        '
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(55, 20)
        Me.Cancel.Text = "Cancel"
        '
        'Save
        '
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(43, 20)
        Me.Save.Text = "Save"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'Search
        '
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(54, 20)
        Me.Search.Text = "Search"
        Me.Search.Visible = False
        '
        'dgvGLTransData
        '
        Me.dgvGLTransData.AllowUserToAddRows = False
        Me.dgvGLTransData.AllowUserToDeleteRows = False
        Me.dgvGLTransData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGLTransData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLTransData.Location = New System.Drawing.Point(37, 234)
        Me.dgvGLTransData.Name = "dgvGLTransData"
        Me.dgvGLTransData.ReadOnly = True
        Me.dgvGLTransData.RowHeadersVisible = False
        Me.dgvGLTransData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGLTransData.Size = New System.Drawing.Size(765, 218)
        Me.dgvGLTransData.TabIndex = 24
        '
        'LblSearch
        '
        Me.LblSearch.AutoSize = True
        Me.LblSearch.Location = New System.Drawing.Point(261, 6)
        Me.LblSearch.Name = "LblSearch"
        Me.LblSearch.Size = New System.Drawing.Size(41, 13)
        Me.LblSearch.TabIndex = 25
        Me.LblSearch.Text = "Search"
        '
        'TxtSearch
        '
        Me.TxtSearch.Location = New System.Drawing.Point(307, 2)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(180, 20)
        Me.TxtSearch.TabIndex = 26
        '
        'ErrorProviderGLTrans
        '
        Me.ErrorProviderGLTrans.ContainerControl = Me
        '
        'frmGLTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 471)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.LblSearch)
        Me.Controls.Add(Me.dgvGLAddTrans)
        Me.Controls.Add(Me.GBSortCode)
        Me.Controls.Add(Me.MenuStripGL)
        Me.Controls.Add(Me.dgvGLTransData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(290, 115)
        Me.MainMenuStrip = Me.MenuStripGL
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGLTransaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "General Ledger Transaction"
        Me.GBSortCode.ResumeLayout(False)
        Me.GBSortCode.PerformLayout()
        CType(Me.dgvGLAddTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStripGL.ResumeLayout(False)
        Me.MenuStripGL.PerformLayout()
        CType(Me.dgvGLTransData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderGLTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GBSortCode As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblGLType As System.Windows.Forms.Label
    Friend WithEvents LblDesc As System.Windows.Forms.Label
    Friend WithEvents LblSortCode As System.Windows.Forms.Label
    Friend WithEvents TxtTellerId As System.Windows.Forms.TextBox
    Friend WithEvents TxtBatchNo As System.Windows.Forms.TextBox
    Friend WithEvents BtnCreate As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtTotCred As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotDeb As System.Windows.Forms.TextBox
    Friend WithEvents TxtTrnDate As System.Windows.Forms.TextBox
    Friend WithEvents dgvGLAddTrans As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStripGL As System.Windows.Forms.MenuStrip
    Friend WithEvents Save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvGLTransData As System.Windows.Forms.DataGridView
    Friend WithEvents Add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Search As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblSearch As System.Windows.Forms.Label
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProviderGLTrans As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnFind As System.Windows.Forms.Button
    Friend WithEvents GL_Acct_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GL_Acct_Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Credit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
