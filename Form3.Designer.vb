<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        txtName = New TextBox()
        Label3 = New Label()
        txtPrice = New TextBox()
        Label4 = New Label()
        txtQty = New TextBox()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        btnReload = New Button()
        btnPrint = New Button()
        Label5 = New Label()
        txtSearch = New TextBox()
        dgvInventory = New DataGridView()
        Panel1 = New Panel()
        CType(dgvInventory, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F)
        Label1.Location = New Point(20, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(55, 19)
        Label1.TabIndex = 0
        Label1.Text = "Item ID"
        ' 
        ' txtID
        ' 
        txtID.Font = New Font("Segoe UI", 10F)
        txtID.Location = New Point(100, 17)
        txtID.Name = "txtID"
        txtID.ReadOnly = True
        txtID.Size = New Size(150, 25)
        txtID.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.Location = New Point(20, 60)
        Label2.Name = "Label2"
        Label2.Size = New Size(77, 19)
        Label2.TabIndex = 2
        Label2.Text = "Item Name"
        ' 
        ' txtName
        ' 
        txtName.Font = New Font("Segoe UI", 10F)
        txtName.Location = New Point(100, 57)
        txtName.Name = "txtName"
        txtName.Size = New Size(250, 25)
        txtName.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F)
        Label3.Location = New Point(380, 20)
        Label3.Name = "Label3"
        Label3.Size = New Size(38, 19)
        Label3.TabIndex = 4
        Label3.Text = "Price"
        ' 
        ' txtPrice
        ' 
        txtPrice.Font = New Font("Segoe UI", 10F)
        txtPrice.Location = New Point(440, 17)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(120, 25)
        txtPrice.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F)
        Label4.Location = New Point(380, 60)
        Label4.Name = "Label4"
        Label4.Size = New Size(32, 19)
        Label4.TabIndex = 6
        Label4.Text = "Qty"
        ' 
        ' txtQty
        ' 
        txtQty.Font = New Font("Segoe UI", 10F)
        txtQty.Location = New Point(440, 57)
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
        btnAdd.Location = New Point(600, 15)
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
        btnUpdate.Location = New Point(690, 15)
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
        btnDelete.Location = New Point(776, 14)
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
        btnClear.Location = New Point(862, 15)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(80, 30)
        btnClear.TabIndex = 11
        btnClear.Text = "&CLEAR"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnReload
        ' 
        btnReload.BackColor = Color.Teal
        btnReload.FlatStyle = FlatStyle.Flat
        btnReload.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnReload.ForeColor = Color.White
        btnReload.Location = New Point(877, 61)
        btnReload.Name = "btnReload"
        btnReload.Size = New Size(65, 25)
        btnReload.TabIndex = 15
        btnReload.Text = "&REFRESH"
        btnReload.UseVisualStyleBackColor = False
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.Goldenrod
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnPrint.ForeColor = Color.White
        btnPrint.Location = New Point(950, 15) ' Positioned to the right of CLEAR
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(80, 30)
        btnPrint.TabIndex = 16
        btnPrint.Text = "&PRINT"
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.DarkRed
        Label5.Location = New Point(690, 95)
        Label5.Name = "Label5"
        Label5.Size = New Size(48, 17)
        Label5.TabIndex = 12
        Label5.Text = "Search"
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Segoe UI", 10F)
        txtSearch.Location = New Point(745, 92)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(250, 25)
        txtSearch.TabIndex = 13
        ' 
        ' dgvInventory
        ' 
        dgvInventory.AllowUserToAddRows = False
        dgvInventory.AllowUserToDeleteRows = False
        dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInventory.Dock = DockStyle.Fill
        dgvInventory.Location = New Point(0, 130)
        dgvInventory.Name = "dgvInventory"
        dgvInventory.ReadOnly = True
        dgvInventory.RowHeadersVisible = False
        dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInventory.Size = New Size(1067, 320)
        dgvInventory.TabIndex = 16
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(txtID)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(txtName)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(txtPrice)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(txtQty)
        Panel1.Controls.Add(btnAdd)
        Panel1.Controls.Add(btnUpdate)
        Panel1.Controls.Add(btnDelete)
        Panel1.Controls.Add(btnClear)
        Panel1.Controls.Add(btnPrint)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(txtSearch)
        Panel1.Controls.Add(btnReload)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1067, 130)
        Panel1.TabIndex = 17
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1067, 450)
        Controls.Add(dgvInventory)
        Controls.Add(Panel1)
        Name = "Form3"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inventory Master"
        WindowState = FormWindowState.Maximized
        CType(dgvInventory, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents dgvInventory As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnReload As System.Windows.Forms.Button
End Class
