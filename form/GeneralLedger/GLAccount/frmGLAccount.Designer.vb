<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGLAccount
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
        Me.GLTypeMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.Search = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Close = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearchGLSortCode = New System.Windows.Forms.Button()
        Me.txtGLSortDesc = New System.Windows.Forms.TextBox()
        Me.txtGLSortCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.TxtAccountNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbSortCode = New System.Windows.Forms.ComboBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GLAccountErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgvGLAccount = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.GLTypeMenuStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GLAccountErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGLAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GLTypeMenuStrip
        '
        Me.GLTypeMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Add, Me.Edit, Me.Delete, Me.Save, Me.Search, Me.Cancel, Me.Close})
        Me.GLTypeMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.GLTypeMenuStrip.Name = "GLTypeMenuStrip"
        Me.GLTypeMenuStrip.Size = New System.Drawing.Size(768, 24)
        Me.GLTypeMenuStrip.TabIndex = 15
        Me.GLTypeMenuStrip.Text = "GLTypeMenuStrip"
        '
        'Add
        '
        Me.Add.Name = "Add"
        Me.Add.Size = New System.Drawing.Size(41, 20)
        Me.Add.Text = "Add"
        '
        'Edit
        '
        Me.Edit.Name = "Edit"
        Me.Edit.Size = New System.Drawing.Size(39, 20)
        Me.Edit.Text = "Edit"
        '
        'Delete
        '
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(52, 20)
        Me.Delete.Text = "Delete"
        '
        'Save
        '
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(43, 20)
        Me.Save.Text = "Save"
        '
        'Search
        '
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(54, 20)
        Me.Search.Text = "Search"
        Me.Search.Visible = False
        '
        'Cancel
        '
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(55, 20)
        Me.Cancel.Text = "Cancel"
        '
        'Close
        '
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(48, 20)
        Me.Close.Text = "Close"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearchGLSortCode)
        Me.GroupBox1.Controls.Add(Me.txtGLSortDesc)
        Me.GroupBox1.Controls.Add(Me.txtGLSortCode)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtDesc)
        Me.GroupBox1.Controls.Add(Me.TxtAccountNo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbSortCode)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(718, 173)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'btnSearchGLSortCode
        '
        Me.btnSearchGLSortCode.Location = New System.Drawing.Point(167, 103)
        Me.btnSearchGLSortCode.Name = "btnSearchGLSortCode"
        Me.btnSearchGLSortCode.Size = New System.Drawing.Size(37, 23)
        Me.btnSearchGLSortCode.TabIndex = 20
        Me.btnSearchGLSortCode.Text = "..."
        Me.btnSearchGLSortCode.UseVisualStyleBackColor = True
        '
        'txtGLSortDesc
        '
        Me.txtGLSortDesc.Enabled = False
        Me.txtGLSortDesc.Location = New System.Drawing.Point(381, 105)
        Me.txtGLSortDesc.MaxLength = 18
        Me.txtGLSortDesc.Name = "txtGLSortDesc"
        Me.txtGLSortDesc.Size = New System.Drawing.Size(304, 20)
        Me.txtGLSortDesc.TabIndex = 19
        '
        'txtGLSortCode
        '
        Me.txtGLSortCode.Enabled = False
        Me.txtGLSortCode.Location = New System.Drawing.Point(210, 105)
        Me.txtGLSortCode.MaxLength = 18
        Me.txtGLSortCode.Name = "txtGLSortCode"
        Me.txtGLSortCode.Size = New System.Drawing.Size(165, 20)
        Me.txtGLSortCode.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(140, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(140, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(141, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(80, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Sort Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(75, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Account Code"
        '
        'TxtDesc
        '
        Me.TxtDesc.Location = New System.Drawing.Point(169, 67)
        Me.TxtDesc.MaxLength = 125
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(440, 20)
        Me.TxtDesc.TabIndex = 10
        '
        'TxtAccountNo
        '
        Me.TxtAccountNo.Location = New System.Drawing.Point(169, 25)
        Me.TxtAccountNo.MaxLength = 18
        Me.TxtAccountNo.Name = "TxtAccountNo"
        Me.TxtAccountNo.Size = New System.Drawing.Size(230, 20)
        Me.TxtAccountNo.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(580, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Fields with * is required."
        '
        'CmbSortCode
        '
        Me.CmbSortCode.FormattingEnabled = True
        Me.CmbSortCode.Location = New System.Drawing.Point(83, 140)
        Me.CmbSortCode.Name = "CmbSortCode"
        Me.CmbSortCode.Size = New System.Drawing.Size(440, 21)
        Me.CmbSortCode.TabIndex = 14
        Me.CmbSortCode.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'GLAccountErrorProvider
        '
        Me.GLAccountErrorProvider.ContainerControl = Me
        '
        'dgvGLAccount
        '
        Me.dgvGLAccount.AllowUserToAddRows = False
        Me.dgvGLAccount.AllowUserToDeleteRows = False
        Me.dgvGLAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGLAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLAccount.Location = New System.Drawing.Point(25, 220)
        Me.dgvGLAccount.Name = "dgvGLAccount"
        Me.dgvGLAccount.ReadOnly = True
        Me.dgvGLAccount.RowHeadersVisible = False
        Me.dgvGLAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGLAccount.Size = New System.Drawing.Size(718, 204)
        Me.dgvGLAccount.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(322, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Search"
        '
        'TxtSearch
        '
        Me.TxtSearch.Location = New System.Drawing.Point(368, 3)
        Me.TxtSearch.MaxLength = 3
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(152, 20)
        Me.TxtSearch.TabIndex = 24
        '
        'frmGLAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 436)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvGLAccount)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.GLTypeMenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(290, 115)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGLAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GL Account"
        Me.GLTypeMenuStrip.ResumeLayout(False)
        Me.GLTypeMenuStrip.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GLAccountErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGLAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GLTypeMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents Add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Search As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Close As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    Friend WithEvents TxtAccountNo As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents CmbSortCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GLAccountErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgvGLAccount As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchGLSortCode As System.Windows.Forms.Button
    Friend WithEvents txtGLSortDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtGLSortCode As System.Windows.Forms.TextBox
End Class
