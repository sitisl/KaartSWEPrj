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
        Me.UTimeTable1 = New UTimeTable.UTimeTable()
        Me.UCtrlMapViewer1 = New UCtrlMapViewer.UCtrlMapViewer()
        Me.tblLayoutMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblLayoutMain
        '
        Me.tblLayoutMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.tblLayoutMain.ColumnCount = 2
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 590.0!))
        Me.tblLayoutMain.Controls.Add(Me.UTimeTable1, 1, 0)
        Me.tblLayoutMain.Controls.Add(Me.UCtrlMapViewer1, 0, 0)
        Me.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayoutMain.Location = New System.Drawing.Point(0, 0)
        Me.tblLayoutMain.Name = "tblLayoutMain"
        Me.tblLayoutMain.RowCount = 1
        Me.tblLayoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutMain.Size = New System.Drawing.Size(1382, 753)
        Me.tblLayoutMain.TabIndex = 25
        '
        'UTimeTable1
        '
        Me.UTimeTable1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UTimeTable1.AutoSize = True
        Me.UTimeTable1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UTimeTable1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.UTimeTable1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UTimeTable1.Location = New System.Drawing.Point(796, 3)
        Me.UTimeTable1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.UTimeTable1.Name = "UTimeTable1"
        Me.UTimeTable1.Size = New System.Drawing.Size(582, 728)
        Me.UTimeTable1.TabIndex = 27
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
        Me.UCtrlMapViewer1.Size = New System.Drawing.Size(784, 743)
        Me.UCtrlMapViewer1.TabIndex = 28
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
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
        Me.tblLayoutMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblLayoutMain As TableLayoutPanel
    Friend WithEvents UTimeTable1 As UTimeTable.UTimeTable
    Friend WithEvents UCtrlMapViewer1 As UCtrlMapViewer.UCtrlMapViewer
End Class
