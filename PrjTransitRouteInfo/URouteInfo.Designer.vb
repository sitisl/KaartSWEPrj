<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class URouteInfo
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.wBrowserInfo = New System.Windows.Forms.WebBrowser()
        Me.tblLayoutRouteInf = New System.Windows.Forms.TableLayoutPanel()
        Me.tblLayoutRouteInf.SuspendLayout()
        Me.SuspendLayout()
        '
        'wBrowserInfo
        '
        Me.wBrowserInfo.AllowWebBrowserDrop = False
        Me.wBrowserInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wBrowserInfo.CausesValidation = False
        Me.wBrowserInfo.IsWebBrowserContextMenuEnabled = False
        Me.wBrowserInfo.Location = New System.Drawing.Point(0, 0)
        Me.wBrowserInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.wBrowserInfo.MinimumSize = New System.Drawing.Size(20, 24)
        Me.wBrowserInfo.Name = "wBrowserInfo"
        Me.wBrowserInfo.ScrollBarsEnabled = False
        Me.wBrowserInfo.Size = New System.Drawing.Size(500, 300)
        Me.wBrowserInfo.TabIndex = 0
        Me.wBrowserInfo.WebBrowserShortcutsEnabled = False
        '
        'tblLayoutRouteInf
        '
        Me.tblLayoutRouteInf.ColumnCount = 1
        Me.tblLayoutRouteInf.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayoutRouteInf.Controls.Add(Me.wBrowserInfo, 0, 0)
        Me.tblLayoutRouteInf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayoutRouteInf.Location = New System.Drawing.Point(0, 0)
        Me.tblLayoutRouteInf.Margin = New System.Windows.Forms.Padding(0)
        Me.tblLayoutRouteInf.Name = "tblLayoutRouteInf"
        Me.tblLayoutRouteInf.RowCount = 1
        Me.tblLayoutRouteInf.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblLayoutRouteInf.Size = New System.Drawing.Size(500, 300)
        Me.tblLayoutRouteInf.TabIndex = 1
        '
        'URouteInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.Controls.Add(Me.tblLayoutRouteInf)
        Me.Enabled = False
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "URouteInfo"
        Me.Size = New System.Drawing.Size(500, 300)
        Me.tblLayoutRouteInf.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents wBrowserInfo As WebBrowser
    Friend WithEvents tblLayoutRouteInf As TableLayoutPanel
End Class
