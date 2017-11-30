<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGLType
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
        Me.LableDataCount = New System.Windows.Forms.Label()
        Me.LBLCode = New System.Windows.Forms.Label()
        Me.LBLType = New System.Windows.Forms.Label()
        Me.TxtCode = New System.Windows.Forms.TextBox()
        Me.TxtType = New System.Windows.Forms.TextBox()
        Me.GLTypeMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.Search = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Close = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBoxGL = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GLTypeErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgvGLType = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbPosition = New System.Windows.Forms.ComboBox()
        Me.GLTypeMenuStrip.SuspendLayout()
        Me.GroupBoxGL.SuspendLayout()
        CType(Me.GLTypeErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGLType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LableDataCount
        '
        Me.LableDataCount.AutoSize = True
        Me.LableDataCount.Location = New System.Drawing.Point(491, 339)
        Me.LableDataCount.Name = "LableDataCount"
        Me.LableDataCount.Size = New System.Drawing.Size(96, 13)
        Me.LableDataCount.TabIndex = 0
        Me.LableDataCount.Text = "Showing 1 of 1000"
        '
        'LBLCode
        '
        Me.LBLCode.AutoSize = True
        Me.LBLCode.Location = New System.Drawing.Point(80, 34)
        Me.LBLCode.Name = "LBLCode"
        Me.LBLCode.Size = New System.Drawing.Size(35, 13)
        Me.LBLCode.TabIndex = 1
        Me.LBLCode.Text = "Code "
        '
        'LBLType
        '
        Me.LBLType.AutoSize = True
        Me.LBLType.Location = New System.Drawing.Point(80, 73)
        Me.LBLType.Name = "LBLType"
        Me.LBLType.Size = New System.Drawing.Size(31, 13)
        Me.LBLType.TabIndex = 2
        Me.LBLType.Text = "Type"
        '
        'TxtCode
        '
        Me.TxtCode.Location = New System.Drawing.Point(173, 27)
        Me.TxtCode.MaxLength = 1
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(137, 20)
        Me.TxtCode.TabIndex = 3
        '
        'TxtType
        '
        Me.TxtType.Location = New System.Drawing.Point(173, 66)
        Me.TxtType.MaxLength = 125
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Size = New System.Drawing.Size(332, 20)
        Me.TxtType.TabIndex = 4
        '
        'GLTypeMenuStrip
        '
        Me.GLTypeMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Add, Me.Edit, Me.Delete, Me.Save, Me.Search, Me.Cancel, Me.Close})
        Me.GLTypeMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.GLTypeMenuStrip.Name = "GLTypeMenuStrip"
        Me.GLTypeMenuStrip.Size = New System.Drawing.Size(714, 24)
        Me.GLTypeMenuStrip.TabIndex = 13
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
        'GroupBoxGL
        '
        Me.GroupBoxGL.Controls.Add(Me.cmbPosition)
        Me.GroupBoxGL.Controls.Add(Me.Label5)
        Me.GroupBoxGL.Controls.Add(Me.Label6)
        Me.GroupBoxGL.Controls.Add(Me.Label3)
        Me.GroupBoxGL.Controls.Add(Me.Label2)
        Me.GroupBoxGL.Controls.Add(Me.Label1)
        Me.GroupBoxGL.Controls.Add(Me.TxtType)
        Me.GroupBoxGL.Controls.Add(Me.LBLCode)
        Me.GroupBoxGL.Controls.Add(Me.LBLType)
        Me.GroupBoxGL.Controls.Add(Me.LableDataCount)
        Me.GroupBoxGL.Controls.Add(Me.TxtCode)
        Me.GroupBoxGL.Location = New System.Drawing.Point(25, 40)
        Me.GroupBoxGL.Name = "GroupBoxGL"
        Me.GroupBoxGL.Size = New System.Drawing.Size(654, 146)
        Me.GroupBoxGL.TabIndex = 14
        Me.GroupBoxGL.TabStop = False
        Me.GroupBoxGL.Text = "GL Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(114, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(111, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(514, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Fields with * is required."
        '
        'GLTypeErrorProvider
        '
        Me.GLTypeErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.GLTypeErrorProvider.ContainerControl = Me
        '
        'dgvGLType
        '
        Me.dgvGLType.AllowUserToAddRows = False
        Me.dgvGLType.AllowUserToDeleteRows = False
        Me.dgvGLType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGLType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLType.Location = New System.Drawing.Point(25, 206)
        Me.dgvGLType.Name = "dgvGLType"
        Me.dgvGLType.ReadOnly = True
        Me.dgvGLType.RowHeadersVisible = False
        Me.dgvGLType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGLType.Size = New System.Drawing.Size(654, 218)
        Me.dgvGLType.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(364, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Search"
        '
        'TxtSearch
        '
        Me.TxtSearch.Location = New System.Drawing.Point(410, 3)
        Me.TxtSearch.MaxLength = 3
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(152, 20)
        Me.TxtSearch.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(114, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(70, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Position"
        '
        'cmbPosition
        '
        Me.cmbPosition.FormattingEnabled = True
        Me.cmbPosition.Items.AddRange(New Object() {"Debit", "Credit"})
        Me.cmbPosition.Location = New System.Drawing.Point(173, 103)
        Me.cmbPosition.Name = "cmbPosition"
        Me.cmbPosition.Size = New System.Drawing.Size(137, 21)
        Me.cmbPosition.TabIndex = 10
        '
        'frmGLType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(714, 436)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgvGLType)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.GroupBoxGL)
        Me.Controls.Add(Me.GLTypeMenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(290, 115)
        Me.MainMenuStrip = Me.GLTypeMenuStrip
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGLType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "General Ledger Type"
        Me.GLTypeMenuStrip.ResumeLayout(False)
        Me.GLTypeMenuStrip.PerformLayout()
        Me.GroupBoxGL.ResumeLayout(False)
        Me.GroupBoxGL.PerformLayout()
        CType(Me.GLTypeErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGLType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LableDataCount As System.Windows.Forms.Label
    Friend WithEvents LBLCode As System.Windows.Forms.Label
    Friend WithEvents LBLType As System.Windows.Forms.Label
    Friend WithEvents GLTypeMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents GroupBoxGL As System.Windows.Forms.GroupBox
    Friend WithEvents Add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Search As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Close As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GLTypeErrorProvider As System.Windows.Forms.ErrorProvider
    Public WithEvents TxtCode As System.Windows.Forms.TextBox
    Public WithEvents TxtType As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvGLType As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmbPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
