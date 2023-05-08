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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Kaardirakendus))
        Me.tblLayoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.UCtrlMapViewer1 = New UCtrlMapViewer.UCtrlMapViewer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.UTimeTable1 = New UTimeTable.UTimeTable()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.cbAppend = New System.Windows.Forms.CheckBox()
        Me.tbDelimiter = New System.Windows.Forms.TextBox()
        Me.lblFilePathText = New System.Windows.Forms.Label()
        Me.LblFileName = New System.Windows.Forms.Label()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.lblFileNameText = New System.Windows.Forms.Label()
        Me.cbSaveType = New System.Windows.Forms.CheckBox()
        Me.tbQualifier = New System.Windows.Forms.TextBox()
        Me.lblQualifier = New System.Windows.Forms.Label()
        Me.lblDelimiter = New System.Windows.Forms.Label()
        Me.tblLayoutMain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblLayoutMain
        '
        Me.tblLayoutMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.tblLayoutMain.ColumnCount = 2
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 585.0!))
        Me.tblLayoutMain.Controls.Add(Me.UCtrlMapViewer1, 0, 0)
        Me.tblLayoutMain.Controls.Add(Me.TableLayoutPanel1, 1, 0)
        Me.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayoutMain.Location = New System.Drawing.Point(0, 0)
        Me.tblLayoutMain.Name = "tblLayoutMain"
        Me.tblLayoutMain.RowCount = 1
        Me.tblLayoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutMain.Size = New System.Drawing.Size(1382, 753)
        Me.tblLayoutMain.TabIndex = 25
        '
        'UCtrlMapViewer1
        '
        Me.UCtrlMapViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UCtrlMapViewer1.BackColor = System.Drawing.Color.Transparent
        Me.UCtrlMapViewer1.Location = New System.Drawing.Point(4, 5)
        Me.UCtrlMapViewer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UCtrlMapViewer1.Name = "UCtrlMapViewer1"
        Me.UCtrlMapViewer1.Size = New System.Drawing.Size(789, 743)
        Me.UCtrlMapViewer1.TabIndex = 28
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.UTimeTable1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(800, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 560.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(579, 747)
        Me.TableLayoutPanel1.TabIndex = 29
        '
        'UTimeTable1
        '
        Me.UTimeTable1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UTimeTable1.AutoSize = True
        Me.UTimeTable1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UTimeTable1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.UTimeTable1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UTimeTable1.Location = New System.Drawing.Point(4, 3)
        Me.UTimeTable1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.UTimeTable1.Name = "UTimeTable1"
        Me.UTimeTable1.Size = New System.Drawing.Size(571, 546)
        Me.UTimeTable1.TabIndex = 28
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.lblInfo)
        Me.Panel1.Controls.Add(Me.cbAppend)
        Me.Panel1.Controls.Add(Me.tbDelimiter)
        Me.Panel1.Controls.Add(Me.lblFilePathText)
        Me.Panel1.Controls.Add(Me.LblFileName)
        Me.Panel1.Controls.Add(Me.lblFilePath)
        Me.Panel1.Controls.Add(Me.lblFileNameText)
        Me.Panel1.Controls.Add(Me.cbSaveType)
        Me.Panel1.Controls.Add(Me.tbQualifier)
        Me.Panel1.Controls.Add(Me.lblQualifier)
        Me.Panel1.Controls.Add(Me.lblDelimiter)
        Me.Panel1.ForeColor = System.Drawing.SystemColors.Window
        Me.Panel1.Location = New System.Drawing.Point(3, 563)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(573, 181)
        Me.Panel1.TabIndex = 29
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Transparent
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(11, 113)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(197, 23)
        Me.btnSave.TabIndex = 22
        Me.btnSave.Text = "Salvesta"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(8, 7)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(173, 15)
        Me.lblInfo.TabIndex = 15
        Me.lblInfo.Text = "Peatuste andmete salvestamine"
        '
        'cbAppend
        '
        Me.cbAppend.AutoSize = True
        Me.cbAppend.ForeColor = System.Drawing.SystemColors.Info
        Me.cbAppend.Location = New System.Drawing.Point(134, 88)
        Me.cbAppend.Name = "cbAppend"
        Me.cbAppend.Size = New System.Drawing.Size(80, 19)
        Me.cbAppend.TabIndex = 14
        Me.cbAppend.Text = "Lisa lõppu"
        Me.cbAppend.UseVisualStyleBackColor = True
        '
        'tbDelimiter
        '
        Me.tbDelimiter.BackColor = System.Drawing.Color.White
        Me.tbDelimiter.Location = New System.Drawing.Point(120, 25)
        Me.tbDelimiter.Name = "tbDelimiter"
        Me.tbDelimiter.Size = New System.Drawing.Size(88, 23)
        Me.tbDelimiter.TabIndex = 13
        '
        'lblFilePathText
        '
        Me.lblFilePathText.AutoSize = True
        Me.lblFilePathText.ForeColor = System.Drawing.SystemColors.Window
        Me.lblFilePathText.Location = New System.Drawing.Point(11, 158)
        Me.lblFilePathText.Name = "lblFilePathText"
        Me.lblFilePathText.Size = New System.Drawing.Size(76, 15)
        Me.lblFilePathText.TabIndex = 12
        Me.lblFilePathText.Text = "Faili asukoht:"
        Me.lblFilePathText.Visible = False
        '
        'LblFileName
        '
        Me.LblFileName.AutoSize = True
        Me.LblFileName.ForeColor = System.Drawing.SystemColors.Window
        Me.LblFileName.Location = New System.Drawing.Point(90, 143)
        Me.LblFileName.Name = "LblFileName"
        Me.LblFileName.Size = New System.Drawing.Size(0, 15)
        Me.LblFileName.TabIndex = 11
        '
        'lblFilePath
        '
        Me.lblFilePath.AutoSize = True
        Me.lblFilePath.ForeColor = System.Drawing.SystemColors.Window
        Me.lblFilePath.Location = New System.Drawing.Point(90, 158)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(0, 15)
        Me.lblFilePath.TabIndex = 10
        '
        'lblFileNameText
        '
        Me.lblFileNameText.AutoSize = True
        Me.lblFileNameText.ForeColor = System.Drawing.SystemColors.Window
        Me.lblFileNameText.Location = New System.Drawing.Point(11, 143)
        Me.lblFileNameText.Name = "lblFileNameText"
        Me.lblFileNameText.Size = New System.Drawing.Size(58, 15)
        Me.lblFileNameText.TabIndex = 9
        Me.lblFileNameText.Text = "Faili nimi:"
        Me.lblFileNameText.Visible = False
        '
        'cbSaveType
        '
        Me.cbSaveType.AutoSize = True
        Me.cbSaveType.ForeColor = System.Drawing.SystemColors.Info
        Me.cbSaveType.Location = New System.Drawing.Point(11, 88)
        Me.cbSaveType.Name = "cbSaveType"
        Me.cbSaveType.Size = New System.Drawing.Size(120, 19)
        Me.cbSaveType.TabIndex = 8
        Me.cbSaveType.Text = "Salvesta uude faili"
        Me.cbSaveType.UseVisualStyleBackColor = True
        '
        'tbQualifier
        '
        Me.tbQualifier.Location = New System.Drawing.Point(120, 52)
        Me.tbQualifier.Name = "tbQualifier"
        Me.tbQualifier.Size = New System.Drawing.Size(88, 23)
        Me.tbQualifier.TabIndex = 7
        '
        'lblQualifier
        '
        Me.lblQualifier.AutoSize = True
        Me.lblQualifier.ForeColor = System.Drawing.Color.Snow
        Me.lblQualifier.Location = New System.Drawing.Point(8, 60)
        Me.lblQualifier.Name = "lblQualifier"
        Me.lblQualifier.Size = New System.Drawing.Size(106, 15)
        Me.lblQualifier.TabIndex = 4
        Me.lblQualifier.Text = "Teksti kvalifikaator:"
        '
        'lblDelimiter
        '
        Me.lblDelimiter.AutoSize = True
        Me.lblDelimiter.ForeColor = System.Drawing.Color.Snow
        Me.lblDelimiter.Location = New System.Drawing.Point(8, 33)
        Me.lblDelimiter.Name = "lblDelimiter"
        Me.lblDelimiter.Size = New System.Drawing.Size(91, 15)
        Me.lblDelimiter.TabIndex = 2
        Me.lblDelimiter.Text = "Väljade eraldaja:"
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1382, 753)
        Me.Controls.Add(Me.tblLayoutMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "Kaardirakendus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ühistranspordi rakendus"
        Me.tblLayoutMain.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblLayoutMain As TableLayoutPanel
    Friend WithEvents UCtrlMapViewer1 As UCtrlMapViewer.UCtrlMapViewer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents UTimeTable1 As UTimeTable.UTimeTable
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblDelimiter As Label
    Friend WithEvents cbSaveType As CheckBox
    Friend WithEvents tbQualifier As TextBox
    Friend WithEvents lblQualifier As Label
    Friend WithEvents lblFilePathText As Label
    Friend WithEvents LblFileName As Label
    Friend WithEvents lblFilePath As Label
    Friend WithEvents lblFileNameText As Label
    Friend WithEvents tbDelimiter As TextBox
    Friend WithEvents cbAppend As CheckBox
    Friend WithEvents lblInfo As Label
    Friend WithEvents btnSave As Button
End Class