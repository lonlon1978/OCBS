<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGLTypeSearch
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
        Me.GridGLTypeSearch = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtGLTypeSearch = New System.Windows.Forms.TextBox()
        CType(Me.GridGLTypeSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridGLTypeSearch
        '
        Me.GridGLTypeSearch.AllowUserToAddRows = False
        Me.GridGLTypeSearch.AllowUserToDeleteRows = False
        Me.GridGLTypeSearch.AllowUserToOrderColumns = True
        Me.GridGLTypeSearch.AllowUserToResizeColumns = False
        Me.GridGLTypeSearch.AllowUserToResizeRows = False
        Me.GridGLTypeSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridGLTypeSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridGLTypeSearch.BackgroundColor = System.Drawing.SystemColors.InactiveBorder
        Me.GridGLTypeSearch.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GridGLTypeSearch.Location = New System.Drawing.Point(1, 50)
        Me.GridGLTypeSearch.MultiSelect = False
        Me.GridGLTypeSearch.Name = "GridGLTypeSearch"
        Me.GridGLTypeSearch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.GridGLTypeSearch.RowTemplate.ReadOnly = True
        Me.GridGLTypeSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridGLTypeSearch.Size = New System.Drawing.Size(448, 437)
        Me.GridGLTypeSearch.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(84, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search"
        '
        'TxtGLTypeSearch
        '
        Me.TxtGLTypeSearch.Location = New System.Drawing.Point(131, 12)
        Me.TxtGLTypeSearch.Name = "TxtGLTypeSearch"
        Me.TxtGLTypeSearch.Size = New System.Drawing.Size(178, 20)
        Me.TxtGLTypeSearch.TabIndex = 3
        '
        'frmGLTypeSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 492)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtGLTypeSearch)
        Me.Controls.Add(Me.GridGLTypeSearch)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGLTypeSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "GL Type Data"
        CType(Me.GridGLTypeSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridGLTypeSearch As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtGLTypeSearch As System.Windows.Forms.TextBox
End Class
