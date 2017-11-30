<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEndOfDay
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
        Me.pBarEOD = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "End of Day Process"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(252, 164)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(86, 30)
        Me.btnStart.TabIndex = 8
        Me.btnStart.Text = "Proceed"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(357, 164)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(86, 30)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pBarEOD
        '
        Me.pBarEOD.Location = New System.Drawing.Point(40, 85)
        Me.pBarEOD.Maximum = 500
        Me.pBarEOD.Name = "pBarEOD"
        Me.pBarEOD.Size = New System.Drawing.Size(629, 44)
        Me.pBarEOD.Step = 1
        Me.pBarEOD.TabIndex = 6
        '
        'frmEndOfDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 222)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.pBarEOD)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(290, 115)
        Me.Name = "frmEndOfDay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "End Of Day Process"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pBarEOD As System.Windows.Forms.ProgressBar
End Class
