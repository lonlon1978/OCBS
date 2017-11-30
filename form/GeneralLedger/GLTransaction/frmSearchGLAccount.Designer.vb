<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchGLAccount
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
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.LblSearch = New System.Windows.Forms.Label()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtSearch
        '
        Me.TxtSearch.Location = New System.Drawing.Point(139, 2)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(180, 20)
        Me.TxtSearch.TabIndex = 46
        '
        'LblSearch
        '
        Me.LblSearch.AutoSize = True
        Me.LblSearch.Location = New System.Drawing.Point(93, 6)
        Me.LblSearch.Name = "LblSearch"
        Me.LblSearch.Size = New System.Drawing.Size(41, 13)
        Me.LblSearch.TabIndex = 45
        Me.LblSearch.Text = "Search"
        '
        'dgvSearch
        '
        Me.dgvSearch.AllowUserToAddRows = False
        Me.dgvSearch.AllowUserToDeleteRows = False
        Me.dgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearch.Location = New System.Drawing.Point(3, 27)
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.ReadOnly = True
        Me.dgvSearch.RowHeadersVisible = False
        Me.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearch.Size = New System.Drawing.Size(442, 206)
        Me.dgvSearch.TabIndex = 44
        '
        'frmSearchGLAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 236)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.LblSearch)
        Me.Controls.Add(Me.dgvSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchGLAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search GL Account"
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents LblSearch As System.Windows.Forms.Label
    Friend WithEvents dgvSearch As System.Windows.Forms.DataGridView
End Class
