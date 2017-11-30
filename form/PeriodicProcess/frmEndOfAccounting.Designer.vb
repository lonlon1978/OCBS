<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEndOfAccounting
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
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pBarEOA = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 25)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "End of Accounting"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(229, 168)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(86, 30)
        Me.btnStart.TabIndex = 12
        Me.btnStart.Text = "Proceed"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(334, 168)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(86, 30)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pBarEOA
        '
        Me.pBarEOA.Location = New System.Drawing.Point(17, 89)
        Me.pBarEOA.Maximum = 500
        Me.pBarEOA.Name = "pBarEOA"
        Me.pBarEOA.Size = New System.Drawing.Size(629, 44)
        Me.pBarEOA.Step = 1
        Me.pBarEOA.TabIndex = 10
        '
        'frmEndOfAccounting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 217)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.pBarEOA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(290, 115)
        Me.Name = "frmEndOfAccounting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "End of Accounting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pBarEOA As System.Windows.Forms.ProgressBar
End Class
