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
        Me.UCtrlMapViewer = New UCtrlMapViewer.UCtrlMapViewer()
        Me.UTimeTable = New UTimeTable.UTimeTable()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UCtrlMapViewer
        '
        Me.UCtrlMapViewer.BackColor = System.Drawing.Color.Transparent
        Me.UCtrlMapViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UCtrlMapViewer.Location = New System.Drawing.Point(3, 3)
        Me.UCtrlMapViewer.Name = "UCtrlMapViewer"
        Me.UCtrlMapViewer.Size = New System.Drawing.Size(1100, 654)
        Me.UCtrlMapViewer.TabIndex = 24
        '
        'UTimeTable
        '
        Me.UTimeTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UTimeTable.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.UTimeTable.Location = New System.Drawing.Point(1109, 3)
        Me.UTimeTable.Name = "UTimeTable"
        Me.UTimeTable.Size = New System.Drawing.Size(480, 654)
        Me.UTimeTable.TabIndex = 21
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 486.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.UTimeTable, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.UCtrlMapViewer, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1592, 660)
        Me.TableLayoutPanel1.TabIndex = 25
        '
        'Kaardirakendus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1592, 660)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Kaardirakendus"
        Me.Text = "Form1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UTimeTable As UTimeTable.UTimeTable
    Friend WithEvents UCtrlMapViewer1 As UCtrlMapViewer.UCtrlMapViewer
    Friend WithEvents UCtrlMapViewer As UCtrlMapViewer.UCtrlMapViewer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
