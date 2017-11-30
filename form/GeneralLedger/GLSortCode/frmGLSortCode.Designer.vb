<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGLSortCode
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
        Me.GBSortCode = New System.Windows.Forms.GroupBox()
        Me.btnSearchGLType = New System.Windows.Forms.Button()
        Me.txtGLTypeDesc = New System.Windows.Forms.TextBox()
        Me.txtGLTypeCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblGLType = New System.Windows.Forms.Label()
        Me.LblDesc = New System.Windows.Forms.Label()
        Me.LblSortCode = New System.Windows.Forms.Label()
        Me.CmbGLType = New System.Windows.Forms.ComboBox()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.TxtSortCode = New System.Windows.Forms.TextBox()
        Me.SortCodeErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgvGLSortCode = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.GLTypeMenuStrip.SuspendLayout()
        Me.GBSortCode.SuspendLayout()
        CType(Me.SortCodeErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGLSortCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GLTypeMenuStrip
        '
        Me.GLTypeMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Add, Me.Edit, Me.Delete, Me.Save, Me.Search, Me.Cancel, Me.Close})
        Me.GLTypeMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.GLTypeMenuStrip.Name = "GLTypeMenuStrip"
        Me.GLTypeMenuStrip.Size = New System.Drawing.Size(768, 24)
        Me.GLTypeMenuStrip.TabIndex = 14
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
        'GBSortCode
        '
        Me.GBSortCode.Controls.Add(Me.btnSearchGLType)
        Me.GBSortCode.Controls.Add(Me.txtGLTypeDesc)
        Me.GBSortCode.Controls.Add(Me.txtGLTypeCode)
        Me.GBSortCode.Controls.Add(Me.Label4)
        Me.GBSortCode.Controls.Add(Me.Label3)
        Me.GBSortCode.Controls.Add(Me.Label2)
        Me.GBSortCode.Controls.Add(Me.Label1)
        Me.GBSortCode.Controls.Add(Me.LblGLType)
        Me.GBSortCode.Controls.Add(Me.LblDesc)
        Me.GBSortCode.Controls.Add(Me.LblSortCode)
        Me.GBSortCode.Controls.Add(Me.CmbGLType)
        Me.GBSortCode.Controls.Add(Me.TxtDesc)
        Me.GBSortCode.Controls.Add(Me.TxtSortCode)
        Me.GBSortCode.Location = New System.Drawing.Point(27, 36)
        Me.GBSortCode.Name = "GBSortCode"
        Me.GBSortCode.Size = New System.Drawing.Size(715, 171)
        Me.GBSortCode.TabIndex = 15
        Me.GBSortCode.TabStop = False
        '
        'btnSearchGLType
        '
        Me.btnSearchGLType.Location = New System.Drawing.Point(158, 97)
        Me.btnSearchGLType.Name = "btnSearchGLType"
        Me.btnSearchGLType.Size = New System.Drawing.Size(37, 23)
        Me.btnSearchGLType.TabIndex = 12
        Me.btnSearchGLType.Text = "..."
        Me.btnSearchGLType.UseVisualStyleBackColor = True
        '
        'txtGLTypeDesc
        '
        Me.txtGLTypeDesc.Enabled = False
        Me.txtGLTypeDesc.Location = New System.Drawing.Point(372, 99)
        Me.txtGLTypeDesc.MaxLength = 18
        Me.txtGLTypeDesc.Name = "txtGLTypeDesc"
        Me.txtGLTypeDesc.ReadOnly = True
        Me.txtGLTypeDesc.Size = New System.Drawing.Size(304, 20)
        Me.txtGLTypeDesc.TabIndex = 11
        '
        'txtGLTypeCode
        '
        Me.txtGLTypeCode.Enabled = False
        Me.txtGLTypeCode.Location = New System.Drawing.Point(201, 99)
        Me.txtGLTypeCode.MaxLength = 18
        Me.txtGLTypeCode.Name = "txtGLTypeCode"
        Me.txtGLTypeCode.ReadOnly = True
        Me.txtGLTypeCode.Size = New System.Drawing.Size(165, 20)
        Me.txtGLTypeCode.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(106, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(106, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(106, 25)
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
        Me.Label1.Location = New System.Drawing.Point(574, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Fields with * is required."
        '
        'LblGLType
        '
        Me.LblGLType.AutoSize = True
        Me.LblGLType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGLType.Location = New System.Drawing.Point(46, 104)
        Me.LblGLType.Name = "LblGLType"
        Me.LblGLType.Size = New System.Drawing.Size(52, 15)
        Me.LblGLType.TabIndex = 5
        Me.LblGLType.Text = "GL Type"
        '
        'LblDesc
        '
        Me.LblDesc.AutoSize = True
        Me.LblDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDesc.Location = New System.Drawing.Point(29, 62)
        Me.LblDesc.Name = "LblDesc"
        Me.LblDesc.Size = New System.Drawing.Size(69, 15)
        Me.LblDesc.TabIndex = 4
        Me.LblDesc.Text = "Description"
        '
        'LblSortCode
        '
        Me.LblSortCode.AutoSize = True
        Me.LblSortCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSortCode.Location = New System.Drawing.Point(37, 23)
        Me.LblSortCode.Name = "LblSortCode"
        Me.LblSortCode.Size = New System.Drawing.Size(61, 15)
        Me.LblSortCode.TabIndex = 3
        Me.LblSortCode.Text = "Sort Code"
        '
        'CmbGLType
        '
        Me.CmbGLType.FormattingEnabled = True
        Me.CmbGLType.Location = New System.Drawing.Point(161, 126)
        Me.CmbGLType.Name = "CmbGLType"
        Me.CmbGLType.Size = New System.Drawing.Size(394, 21)
        Me.CmbGLType.TabIndex = 2
        Me.CmbGLType.Visible = False
        '
        'TxtDesc
        '
        Me.TxtDesc.Location = New System.Drawing.Point(161, 57)
        Me.TxtDesc.MaxLength = 125
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(515, 20)
        Me.TxtDesc.TabIndex = 1
        '
        'TxtSortCode
        '
        Me.TxtSortCode.Location = New System.Drawing.Point(161, 18)
        Me.TxtSortCode.MaxLength = 18
        Me.TxtSortCode.Name = "TxtSortCode"
        Me.TxtSortCode.Size = New System.Drawing.Size(187, 20)
        Me.TxtSortCode.TabIndex = 0
        '
        'SortCodeErrorProvider
        '
        Me.SortCodeErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.SortCodeErrorProvider.ContainerControl = Me
        '
        'dgvGLSortCode
        '
        Me.dgvGLSortCode.AllowUserToAddRows = False
        Me.dgvGLSortCode.AllowUserToDeleteRows = False
        Me.dgvGLSortCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGLSortCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLSortCode.Location = New System.Drawing.Point(27, 222)
        Me.dgvGLSortCode.Name = "dgvGLSortCode"
        Me.dgvGLSortCode.ReadOnly = True
        Me.dgvGLSortCode.RowHeadersVisible = False
        Me.dgvGLSortCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGLSortCode.Size = New System.Drawing.Size(715, 202)
        Me.dgvGLSortCode.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(313, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Search"
        '
        'TxtSearch
        '
        Me.TxtSearch.Location = New System.Drawing.Point(359, 2)
        Me.TxtSearch.MaxLength = 3
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(152, 20)
        Me.TxtSearch.TabIndex = 22
        '
        'frmGLSortCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 436)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.dgvGLSortCode)
        Me.Controls.Add(Me.GBSortCode)
        Me.Controls.Add(Me.GLTypeMenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(290, 115)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGLSortCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sort Code"
        Me.GLTypeMenuStrip.ResumeLayout(False)
        Me.GLTypeMenuStrip.PerformLayout()
        Me.GBSortCode.ResumeLayout(False)
        Me.GBSortCode.PerformLayout()
        CType(Me.SortCodeErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGLSortCode, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GBSortCode As System.Windows.Forms.GroupBox
    Friend WithEvents LblGLType As System.Windows.Forms.Label
    Friend WithEvents LblDesc As System.Windows.Forms.Label
    Friend WithEvents LblSortCode As System.Windows.Forms.Label
    Friend WithEvents CmbGLType As System.Windows.Forms.ComboBox
    Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    Friend WithEvents TxtSortCode As System.Windows.Forms.TextBox
    Friend WithEvents SortCodeErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvGLSortCode As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchGLType As System.Windows.Forms.Button
    Friend WithEvents txtGLTypeDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtGLTypeCode As System.Windows.Forms.TextBox
End Class
