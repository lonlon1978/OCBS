<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGLTransDetail
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblBatchNo = New System.Windows.Forms.Label()
        Me.dgvGLTransDetail = New System.Windows.Forms.DataGridView()
        CType(Me.dgvGLTransDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(255, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Batch Number : "
        '
        'LblBatchNo
        '
        Me.LblBatchNo.AutoSize = True
        Me.LblBatchNo.Font = New System.Drawing.Font("Georgia", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBatchNo.Location = New System.Drawing.Point(373, 9)
        Me.LblBatchNo.Name = "LblBatchNo"
        Me.LblBatchNo.Size = New System.Drawing.Size(95, 17)
        Me.LblBatchNo.TabIndex = 1
        Me.LblBatchNo.Text = "LblBatchNo"
        '
        'dgvGLTransDetail
        '
        Me.dgvGLTransDetail.AllowUserToAddRows = False
        Me.dgvGLTransDetail.AllowUserToDeleteRows = False
        Me.dgvGLTransDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGLTransDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLTransDetail.Location = New System.Drawing.Point(8, 32)
        Me.dgvGLTransDetail.Name = "dgvGLTransDetail"
        Me.dgvGLTransDetail.ReadOnly = True
        Me.dgvGLTransDetail.RowHeadersVisible = False
        Me.dgvGLTransDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGLTransDetail.Size = New System.Drawing.Size(666, 218)
        Me.dgvGLTransDetail.TabIndex = 25
        '
        'frmGLTransDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 262)
        Me.Controls.Add(Me.dgvGLTransDetail)
        Me.Controls.Add(Me.LblBatchNo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGLTransDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "GL Transaction Detail"
        CType(Me.dgvGLTransDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblBatchNo As System.Windows.Forms.Label
    Friend WithEvents dgvGLTransDetail As System.Windows.Forms.DataGridView
End Class
