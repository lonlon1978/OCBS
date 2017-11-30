<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddTransaction
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
        Me.CmbGLAccnt = New System.Windows.Forms.ComboBox()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtDebit = New System.Windows.Forms.TextBox()
        Me.TxtCredit = New System.Windows.Forms.TextBox()
        Me.AddTransErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearchGLSortCode = New System.Windows.Forms.Button()
        Me.txtGLAcctDesc = New System.Windows.Forms.TextBox()
        Me.txtGLAcctCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.AddTransErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbGLAccnt
        '
        Me.CmbGLAccnt.FormattingEnabled = True
        Me.CmbGLAccnt.Location = New System.Drawing.Point(0, -3)
        Me.CmbGLAccnt.Name = "CmbGLAccnt"
        Me.CmbGLAccnt.Size = New System.Drawing.Size(478, 21)
        Me.CmbGLAccnt.TabIndex = 14
        Me.CmbGLAccnt.Visible = False
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(338, 320)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 23)
        Me.BtnAdd.TabIndex = 13
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Credit Amount"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Debit Amount"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "GL Account"
        '
        'TxtDebit
        '
        Me.TxtDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDebit.Location = New System.Drawing.Point(33, 158)
        Me.TxtDebit.Name = "TxtDebit"
        Me.TxtDebit.Size = New System.Drawing.Size(229, 21)
        Me.TxtDebit.TabIndex = 9
        Me.TxtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCredit
        '
        Me.TxtCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCredit.Location = New System.Drawing.Point(33, 101)
        Me.TxtCredit.Name = "TxtCredit"
        Me.TxtCredit.Size = New System.Drawing.Size(229, 21)
        Me.TxtCredit.TabIndex = 8
        Me.TxtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AddTransErrorProvider
        '
        Me.AddTransErrorProvider.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearchGLSortCode)
        Me.GroupBox1.Controls.Add(Me.txtGLAcctDesc)
        Me.GroupBox1.Controls.Add(Me.txtGLAcctCode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtCredit)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtDebit)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbGLAccnt)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(478, 302)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'btnSearchGLSortCode
        '
        Me.btnSearchGLSortCode.Location = New System.Drawing.Point(34, 49)
        Me.btnSearchGLSortCode.Name = "btnSearchGLSortCode"
        Me.btnSearchGLSortCode.Size = New System.Drawing.Size(35, 23)
        Me.btnSearchGLSortCode.TabIndex = 23
        Me.btnSearchGLSortCode.Text = "..."
        Me.btnSearchGLSortCode.UseVisualStyleBackColor = True
        '
        'txtGLAcctDesc
        '
        Me.txtGLAcctDesc.Enabled = False
        Me.txtGLAcctDesc.Location = New System.Drawing.Point(219, 49)
        Me.txtGLAcctDesc.MaxLength = 18
        Me.txtGLAcctDesc.Name = "txtGLAcctDesc"
        Me.txtGLAcctDesc.Size = New System.Drawing.Size(234, 20)
        Me.txtGLAcctDesc.TabIndex = 22
        '
        'txtGLAcctCode
        '
        Me.txtGLAcctCode.Enabled = False
        Me.txtGLAcctCode.Location = New System.Drawing.Point(74, 49)
        Me.txtGLAcctCode.MaxLength = 18
        Me.txtGLAcctCode.Name = "txtGLAcctCode"
        Me.txtGLAcctCode.Size = New System.Drawing.Size(139, 20)
        Me.txtGLAcctCode.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(33, 216)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(386, 67)
        Me.txtRemarks.TabIndex = 15
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(424, 320)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 16
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmAddTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 351)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddTransaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Transaction"
        CType(Me.AddTransErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmbGLAccnt As System.Windows.Forms.ComboBox
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtDebit As System.Windows.Forms.TextBox
    Friend WithEvents TxtCredit As System.Windows.Forms.TextBox
    Friend WithEvents AddTransErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchGLSortCode As System.Windows.Forms.Button
    Friend WithEvents txtGLAcctDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtGLAcctCode As System.Windows.Forms.TextBox
End Class
