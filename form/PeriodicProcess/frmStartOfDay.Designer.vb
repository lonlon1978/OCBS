<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartOfDay
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
        Me.pBarSOD = New System.Windows.Forms.ProgressBar()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpNextSysDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pBarSOD
        '
        Me.pBarSOD.Location = New System.Drawing.Point(41, 106)
        Me.pBarSOD.Maximum = 500
        Me.pBarSOD.Name = "pBarSOD"
        Me.pBarSOD.Size = New System.Drawing.Size(629, 44)
        Me.pBarSOD.Step = 1
        Me.pBarSOD.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(359, 186)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(86, 30)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(254, 186)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(86, 30)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Proceed"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Start of Day Process"
        '
        'dtpNextSysDate
        '
        Me.dtpNextSysDate.Location = New System.Drawing.Point(295, 62)
        Me.dtpNextSysDate.Name = "dtpNextSysDate"
        Me.dtpNextSysDate.Size = New System.Drawing.Size(232, 21)
        Me.dtpNextSysDate.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(191, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "System Date"
        '
        'frmStartOfDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 237)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpNextSysDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.pBarSOD)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(290, 115)
        Me.Name = "frmStartOfDay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Start Of Day Process"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pBarSOD As System.Windows.Forms.ProgressBar
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpNextSysDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
