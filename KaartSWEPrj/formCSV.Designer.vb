<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCSV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formCSV))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gpSave = New System.Windows.Forms.GroupBox()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.lblFileNameText = New System.Windows.Forms.Label()
        Me.lblFilePathText = New System.Windows.Forms.Label()
        Me.cbAppend = New System.Windows.Forms.CheckBox()
        Me.cbSaveType = New System.Windows.Forms.CheckBox()
        Me.tbQualifier = New System.Windows.Forms.TextBox()
        Me.tbDelimiter = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDivider = New System.Windows.Forms.Label()
        Me.gpSave.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(10, 146)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(325, 29)
        Me.btnSave.TabIndex = 0
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gpSave
        '
        Me.gpSave.Controls.Add(Me.lblFilePath)
        Me.gpSave.Controls.Add(Me.lblFileName)
        Me.gpSave.Controls.Add(Me.lblFileNameText)
        Me.gpSave.Controls.Add(Me.lblFilePathText)
        Me.gpSave.Controls.Add(Me.cbAppend)
        Me.gpSave.Controls.Add(Me.cbSaveType)
        Me.gpSave.Controls.Add(Me.tbQualifier)
        Me.gpSave.Controls.Add(Me.tbDelimiter)
        Me.gpSave.Controls.Add(Me.Label2)
        Me.gpSave.Controls.Add(Me.lblDivider)
        Me.gpSave.Controls.Add(Me.btnSave)
        Me.gpSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gpSave.ForeColor = System.Drawing.Color.White
        Me.gpSave.Location = New System.Drawing.Point(12, 5)
        Me.gpSave.Name = "gpSave"
        Me.gpSave.Size = New System.Drawing.Size(355, 275)
        Me.gpSave.TabIndex = 1
        Me.gpSave.TabStop = False
        Me.gpSave.Text = "Peatuste andmete salvestamine"
        '
        'lblFilePath
        '
        Me.lblFilePath.AutoSize = True
        Me.lblFilePath.Location = New System.Drawing.Point(108, 221)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(0, 20)
        Me.lblFilePath.TabIndex = 10
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(108, 187)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(0, 20)
        Me.lblFileName.TabIndex = 9
        '
        'lblFileNameText
        '
        Me.lblFileNameText.AutoSize = True
        Me.lblFileNameText.Location = New System.Drawing.Point(31, 187)
        Me.lblFileNameText.Name = "lblFileNameText"
        Me.lblFileNameText.Size = New System.Drawing.Size(75, 20)
        Me.lblFileNameText.TabIndex = 8
        Me.lblFileNameText.Text = "Faili nimi: "
        Me.lblFileNameText.Visible = False
        '
        'lblFilePathText
        '
        Me.lblFilePathText.AutoSize = True
        Me.lblFilePathText.Location = New System.Drawing.Point(13, 221)
        Me.lblFilePathText.Name = "lblFilePathText"
        Me.lblFilePathText.Size = New System.Drawing.Size(93, 20)
        Me.lblFilePathText.TabIndex = 7
        Me.lblFilePathText.Text = "Faili asukoht:"
        Me.lblFilePathText.Visible = False
        '
        'cbAppend
        '
        Me.cbAppend.AutoSize = True
        Me.cbAppend.Location = New System.Drawing.Point(236, 116)
        Me.cbAppend.Name = "cbAppend"
        Me.cbAppend.Size = New System.Drawing.Size(99, 24)
        Me.cbAppend.TabIndex = 6
        Me.cbAppend.Text = "Lisa lõppu"
        Me.cbAppend.UseVisualStyleBackColor = True
        '
        'cbSaveType
        '
        Me.cbSaveType.AutoSize = True
        Me.cbSaveType.Location = New System.Drawing.Point(10, 116)
        Me.cbSaveType.Name = "cbSaveType"
        Me.cbSaveType.Size = New System.Drawing.Size(151, 24)
        Me.cbSaveType.TabIndex = 5
        Me.cbSaveType.Text = "Salvesta uude faili"
        Me.cbSaveType.UseVisualStyleBackColor = True
        '
        'tbQualifier
        '
        Me.tbQualifier.Location = New System.Drawing.Point(159, 79)
        Me.tbQualifier.Name = "tbQualifier"
        Me.tbQualifier.Size = New System.Drawing.Size(176, 27)
        Me.tbQualifier.TabIndex = 4
        '
        'tbDelimiter
        '
        Me.tbDelimiter.Location = New System.Drawing.Point(159, 37)
        Me.tbDelimiter.Name = "tbDelimiter"
        Me.tbDelimiter.Size = New System.Drawing.Size(176, 27)
        Me.tbDelimiter.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Teksti kvalifikaator:"
        '
        'lblDivider
        '
        Me.lblDivider.AutoSize = True
        Me.lblDivider.Location = New System.Drawing.Point(21, 40)
        Me.lblDivider.Name = "lblDivider"
        Me.lblDivider.Size = New System.Drawing.Size(119, 20)
        Me.lblDivider.TabIndex = 1
        Me.lblDivider.Text = "Väljade eraldaja:"
        '
        'formCSV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(379, 286)
        Me.Controls.Add(Me.gpSave)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "formCSV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Peatuste salvestamine..."
        Me.gpSave.ResumeLayout(False)
        Me.gpSave.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSave As Button
    Friend WithEvents gpSave As GroupBox
    Friend WithEvents lblFilePath As Label
    Friend WithEvents lblFileName As Label
    Friend WithEvents lblFileNameText As Label
    Friend WithEvents lblFilePathText As Label
    Friend WithEvents cbAppend As CheckBox
    Friend WithEvents cbSaveType As CheckBox
    Friend WithEvents tbQualifier As TextBox
    Friend WithEvents tbDelimiter As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblDivider As Label
End Class
