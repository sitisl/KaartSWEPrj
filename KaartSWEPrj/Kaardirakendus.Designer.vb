﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.UTimeTable1 = New UTimeTable.UTimeTable()
        Me.tblLayoutMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblLayoutMain
        '
        Me.tblLayoutMain.ColumnCount = 2
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tblLayoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tblLayoutMain.Controls.Add(Me.UCtrlMapViewer1, 0, 0)
        Me.tblLayoutMain.Controls.Add(Me.UTimeTable1, 1, 0)
        Me.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayoutMain.Location = New System.Drawing.Point(0, 0)
        Me.tblLayoutMain.Name = "tblLayoutMain"
        Me.tblLayoutMain.RowCount = 1
        Me.tblLayoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayoutMain.Size = New System.Drawing.Size(1582, 753)
        Me.tblLayoutMain.TabIndex = 25
        '
        'UCtrlMapViewer1
        '
        Me.UCtrlMapViewer1.BackColor = System.Drawing.Color.Transparent
        Me.UCtrlMapViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UCtrlMapViewer1.Location = New System.Drawing.Point(4, 5)
        Me.UCtrlMapViewer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UCtrlMapViewer1.Name = "UCtrlMapViewer1"
        Me.UCtrlMapViewer1.Size = New System.Drawing.Size(941, 743)
        Me.UCtrlMapViewer1.TabIndex = 26
        '
        'UTimeTable1
        '
        Me.UTimeTable1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UTimeTable1.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.UTimeTable1.Location = New System.Drawing.Point(953, 3)
        Me.UTimeTable1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.UTimeTable1.Name = "UTimeTable1"
        Me.UTimeTable1.Size = New System.Drawing.Size(616, 644)
        Me.UTimeTable1.TabIndex = 27
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1582, 753)
        Me.Controls.Add(Me.tblLayoutMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "Kaardirakendus"

        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ühistranspordi rakendus"
        Me.tblLayoutMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblLayoutMain As TableLayoutPanel
    Friend WithEvents UCtrlMapViewer1 As UCtrlMapViewer.UCtrlMapViewer
    Friend WithEvents UTimeTable1 As UTimeTable.UTimeTable
End Class
