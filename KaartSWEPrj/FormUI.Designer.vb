<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Kaardirakendus
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.lblLat = New System.Windows.Forms.Label()
        Me.lblLongName = New System.Windows.Forms.Label()
        Me.lblChooseStop = New System.Windows.Forms.Label()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.txtLongName = New System.Windows.Forms.TextBox()
        Me.txtLat = New System.Windows.Forms.TextBox()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.btnDisplayComponent = New System.Windows.Forms.Button()
        Me.checkBoxStops = New System.Windows.Forms.CheckBox()
        Me.UCtrlMapViewer1 = New UCtrlMapViewer.UCtrlMapViewer()
        Me.SuspendLayout()
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(18, 71)
        Me.btnChoose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(112, 35)
        Me.btnChoose.TabIndex = 1
        Me.btnChoose.Text = "Name"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'lblLat
        '
        Me.lblLat.AutoSize = True
        Me.lblLat.Location = New System.Drawing.Point(18, 198)
        Me.lblLat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(67, 20)
        Me.lblLat.TabIndex = 2
        Me.lblLat.Text = "Latitude"
        '
        'lblLongName
        '
        Me.lblLongName.AutoSize = True
        Me.lblLongName.Location = New System.Drawing.Point(14, 129)
        Me.lblLongName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLongName.Name = "lblLongName"
        Me.lblLongName.Size = New System.Drawing.Size(80, 20)
        Me.lblLongName.TabIndex = 3
        Me.lblLongName.Text = "Longitude"
        '
        'lblChooseStop
        '
        Me.lblChooseStop.AutoSize = True
        Me.lblChooseStop.BackColor = System.Drawing.SystemColors.Control
        Me.lblChooseStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblChooseStop.Location = New System.Drawing.Point(18, 37)
        Me.lblChooseStop.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChooseStop.Name = "lblChooseStop"
        Me.lblChooseStop.Size = New System.Drawing.Size(99, 20)
        Me.lblChooseStop.TabIndex = 4
        Me.lblChooseStop.Text = "Choose stop"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(140, 71)
        Me.btnDisplay.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(112, 35)
        Me.btnDisplay.TabIndex = 5
        Me.btnDisplay.Text = "Display"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        'txtLongName
        '
        Me.txtLongName.Location = New System.Drawing.Point(18, 154)
        Me.txtLongName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLongName.Name = "txtLongName"
        Me.txtLongName.Size = New System.Drawing.Size(232, 26)
        Me.txtLongName.TabIndex = 6
        '
        'txtLat
        '
        Me.txtLat.Location = New System.Drawing.Point(18, 223)
        Me.txtLat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLat.Name = "txtLat"
        Me.txtLat.Size = New System.Drawing.Size(232, 26)
        Me.txtLat.TabIndex = 7
        '
        'btnAll
        '
        Me.btnAll.Location = New System.Drawing.Point(22, 278)
        Me.btnAll.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(230, 35)
        Me.btnAll.TabIndex = 8
        Me.btnAll.Text = "Display All"
        Me.btnAll.UseVisualStyleBackColor = True
        '
        'btnDisplayComponent
        '
        Me.btnDisplayComponent.Location = New System.Drawing.Point(22, 366)
        Me.btnDisplayComponent.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDisplayComponent.Name = "btnDisplayComponent"
        Me.btnDisplayComponent.Size = New System.Drawing.Size(230, 35)
        Me.btnDisplayComponent.TabIndex = 9
        Me.btnDisplayComponent.Text = "Display all using component"
        Me.btnDisplayComponent.UseVisualStyleBackColor = True
        '
        'checkBoxStops
        '
        Me.checkBoxStops.AutoSize = True
        Me.checkBoxStops.Location = New System.Drawing.Point(52, 409)
        Me.checkBoxStops.Name = "checkBoxStops"
        Me.checkBoxStops.Size = New System.Drawing.Size(137, 24)
        Me.checkBoxStops.TabIndex = 11
        Me.checkBoxStops.Text = "Show all stops"
        Me.checkBoxStops.UseVisualStyleBackColor = True
        '
        'UCtrlMapViewer1
        '
        Me.UCtrlMapViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UCtrlMapViewer1.Location = New System.Drawing.Point(298, 37)
        Me.UCtrlMapViewer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UCtrlMapViewer1.Name = "UCtrlMapViewer1"
        Me.UCtrlMapViewer1.Size = New System.Drawing.Size(1155, 586)
        Me.UCtrlMapViewer1.TabIndex = 10
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1924, 858)
        Me.Controls.Add(Me.checkBoxStops)
        Me.Controls.Add(Me.UCtrlMapViewer1)
        Me.Controls.Add(Me.btnDisplayComponent)
        Me.Controls.Add(Me.btnAll)
        Me.Controls.Add(Me.txtLat)
        Me.Controls.Add(Me.txtLongName)
        Me.Controls.Add(Me.btnDisplay)
        Me.Controls.Add(Me.lblChooseStop)
        Me.Controls.Add(Me.lblLongName)
        Me.Controls.Add(Me.lblLat)
        Me.Controls.Add(Me.btnChoose)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Kaardirakendus"
        Me.Text = "Ühistransport"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnChoose As Button
    Friend WithEvents lblLat As Label
    Friend WithEvents lblLongName As Label
    Friend WithEvents lblChooseStop As Label
    Friend WithEvents btnDisplay As Button
    Friend WithEvents txtLongName As TextBox
    Friend WithEvents txtLat As TextBox
    Friend WithEvents btnAll As Button
    Friend WithEvents btnDisplayComponent As Button
    Friend WithEvents UCtrlMapViewer1 As UCtrlMapViewer.UCtrlMapViewer
    Friend WithEvents checkBoxStops As CheckBox
End Class
