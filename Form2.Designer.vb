<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        txtsearch = New TextBox()
        cboitem = New ComboBox()
        lblselected = New Label()
        SuspendLayout()
        ' 
        ' txtsearch
        ' 
        txtsearch.Location = New Point(267, 30)
        txtsearch.Name = "txtsearch"
        txtsearch.Size = New Size(255, 23)
        txtsearch.TabIndex = 0
        ' 
        ' cboitem
        ' 
        cboitem.FormattingEnabled = True
        cboitem.Location = New Point(267, 59)
        cboitem.Name = "cboitem"
        cboitem.Size = New Size(326, 23)
        cboitem.TabIndex = 1
        ' 
        ' lblselected
        ' 
        lblselected.AutoSize = True
        lblselected.Location = New Point(190, 33)
        lblselected.Name = "lblselected"
        lblselected.Size = New Size(41, 15)
        lblselected.TabIndex = 2
        lblselected.Text = "Label1"
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lblselected)
        Controls.Add(cboitem)
        Controls.Add(txtsearch)
        Name = "Form2"
        Text = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtsearch As TextBox
    Friend WithEvents cboitem As ComboBox
    Friend WithEvents lblselected As Label
End Class
