<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOpeningStock
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
        Label1 = New Label()
        txtID = New TextBox()
        Label2 = New Label()
        cmbLocation = New ComboBox()
        Label3 = New Label()
        cmbItem = New ComboBox()
        Label4 = New Label()
        txtQty = New TextBox()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        Label5 = New Label()
        txtSearch = New TextBox()
        dgvStock = New DataGridView()
        Panel1 = New Panel()
        CType(dgvStock, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F)
        Label1.Location = New Point(20, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(59, 19)
        Label1.TabIndex = 0
        Label1.Text = "Stock ID"
        ' 
        ' txtID
        ' 
        txtID.Font = New Font("Segoe UI", 10F)
        txtID.Location = New Point(100, 17)
        txtID.Name = "txtID"
        txtID.ReadOnly = True
        txtID.Size = New Size(100, 25)
        txtID.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.Location = New Point(20, 60)
        Label2.Name = "Label2"
        Label2.Size = New Size(61, 19)
        Label2.TabIndex = 2
        Label2.Text = "Location"
        ' 
        ' cmbLocation
        ' 
        cmbLocation.Font = New Font("Segoe UI", 10F)
        cmbLocation.FormattingEnabled = True
        cmbLocation.Location = New Point(100, 57)
        cmbLocation.Name = "cmbLocation"
        cmbLocation.Size = New Size(250, 25)
        cmbLocation.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F)
        Label3.Location = New Point(380, 60)
        Label3.Name = "Label3"
        Label3.Size = New Size(37, 19)
        Label3.TabIndex = 4
        Label3.Text = "Item"
        ' 
        ' cmbItem
        ' 
        cmbItem.Font = New Font("Segoe UI", 10F)
        cmbItem.FormattingEnabled = True
        cmbItem.Location = New Point(440, 57)
        cmbItem.Name = "cmbItem"
        cmbItem.Size = New Size(250, 25)
        cmbItem.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F)
        Label4.Location = New Point(380, 20)
        Label4.Name = "Label4"
        Label4.Size = New Size(32, 19)
        Label4.TabIndex = 6
        Label4.Text = "Qty"
        ' 
        ' txtQty
        ' 
        txtQty.Font = New Font("Segoe UI", 10F)
        txtQty.Location = New Point(440, 17)
        txtQty.Name = "txtQty"
        txtQty.Size = New Size(120, 25)
        txtQty.TabIndex = 7
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.MediumSeaGreen
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(720, 15)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(80, 30)
        btnAdd.TabIndex = 8
        btnAdd.Text = "&ADD"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.SteelBlue
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location = New Point(810, 15)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(80, 30)
        btnUpdate.TabIndex = 9
        btnUpdate.Text = "&UPDATE"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.IndianRed
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(900, 15)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(80, 30)
        btnDelete.TabIndex = 10
        btnDelete.Text = "&DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.Gray
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(720, 55)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(80, 30)
        btnClear.TabIndex = 11
        btnClear.Text = "&CLEAR"
        btnClear.UseVisualStyleBackColor = False
        '
        ' Label5
        '
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        Label5.ForeColor = Color.DarkRed
        Label5.Location = New Point(810, 62)
        Label5.Name = "Label5"
        Label5.Text = "Search:"
        Label5.Size = New Size(50, 20)
        '
        ' txtSearch
        '
        txtSearch.Font = New Font("Segoe UI", 10F)
        txtSearch.Location = New Point(865, 60)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(150, 25)
        txtSearch.TabIndex = 13
        ' 
        ' dgvStock
        ' 
        dgvStock.AllowUserToAddRows = False
        dgvStock.AllowUserToDeleteRows = False
        dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStock.Dock = DockStyle.Fill
        dgvStock.Location = New Point(0, 100)
        dgvStock.Name = "dgvStock"
        dgvStock.ReadOnly = True
        dgvStock.RowHeadersVisible = False
        dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStock.Size = New Size(1067, 350)
        dgvStock.TabIndex = 16
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(txtID)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(cmbLocation)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(cmbItem)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(txtQty)
        Panel1.Controls.Add(btnAdd)
        Panel1.Controls.Add(btnUpdate)
        Panel1.Controls.Add(btnDelete)
        Panel1.Controls.Add(btnClear)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(txtSearch)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1067, 100)
        Panel1.TabIndex = 17
        ' 
        ' FrmOpeningStock
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1067, 450)
        Controls.Add(dgvStock)
        Controls.Add(Panel1)
        Name = "FrmOpeningStock"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Opening Stock Master"
        WindowState = FormWindowState.Maximized
        CType(dgvStock, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents dgvStock As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSearch As TextBox
End Class
