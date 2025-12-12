<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLocation
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
        Panel1 = New Panel()
        Label1 = New Label()
        txtLocID = New TextBox()
        Label2 = New Label()
        txtLocName = New TextBox()
        Label3 = New Label()
        txtLocAddress = New TextBox()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        Label4 = New Label()
        txtSearch = New TextBox()
        btnReload = New Button()
        dgvLocation = New DataGridView()
        Panel1.SuspendLayout()
        CType(dgvLocation, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(txtLocID)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(txtLocName)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(txtLocAddress)
        Panel1.Controls.Add(btnAdd)
        Panel1.Controls.Add(btnUpdate)
        Panel1.Controls.Add(btnDelete)
        Panel1.Controls.Add(btnClear)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(txtSearch)
        Panel1.Controls.Add(btnReload)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1067, 150)
        Panel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F)
        Label1.Location = New Point(20, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(79, 19)
        Label1.TabIndex = 0
        Label1.Text = "Location ID"
        Label1.Visible = False
        ' 
        ' txtLocID
        ' 
        txtLocID.Font = New Font("Segoe UI", 10F)
        txtLocID.Location = New Point(120, 17)
        txtLocID.Name = "txtLocID"
        txtLocID.ReadOnly = True
        txtLocID.Size = New Size(150, 25)
        txtLocID.TabIndex = 1
        txtLocID.Visible = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.Location = New Point(20, 20)
        Label2.Name = "Label2"
        Label2.Size = New Size(101, 19)
        Label2.TabIndex = 2
        Label2.Text = "Location Name"
        ' 
        ' txtLocName
        ' 
        txtLocName.Font = New Font("Segoe UI", 10F)
        txtLocName.Location = New Point(120, 17)
        txtLocName.Name = "txtLocName"
        txtLocName.Size = New Size(250, 25)
        txtLocName.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F)
        Label3.Location = New Point(20, 60)
        Label3.Name = "Label3"
        Label3.Size = New Size(58, 19)
        Label3.TabIndex = 4
        Label3.Text = "Address"
        ' 
        ' txtLocAddress
        ' 
        txtLocAddress.Font = New Font("Segoe UI", 10F)
        txtLocAddress.Location = New Point(120, 57)
        txtLocAddress.Multiline = True
        txtLocAddress.Name = "txtLocAddress"
        txtLocAddress.Size = New Size(250, 66)
        txtLocAddress.TabIndex = 5
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.MediumSeaGreen
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(471, 14)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(80, 30)
        btnAdd.TabIndex = 6
        btnAdd.Text = "&ADD"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.SteelBlue
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location = New Point(471, 47)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(80, 30)
        btnUpdate.TabIndex = 7
        btnUpdate.Text = "&UPDATE"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.IndianRed
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(471, 83)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(80, 30)
        btnDelete.TabIndex = 8
        btnDelete.Text = "&DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.Gray
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(471, 114)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(80, 30)
        btnClear.TabIndex = 9
        btnClear.Text = "&CLEAR"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F)
        Label4.Location = New Point(674, 20)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 19)
        Label4.TabIndex = 10
        Label4.Text = "Search"
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Segoe UI", 10F)
        txtSearch.Location = New Point(738, 17)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(200, 25)
        txtSearch.TabIndex = 11
        ' 
        ' btnReload
        ' 
        btnReload.BackColor = Color.Teal
        btnReload.FlatStyle = FlatStyle.Flat
        btnReload.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold)
        btnReload.ForeColor = Color.White
        btnReload.Location = New Point(961, 17)
        btnReload.Name = "btnReload"
        btnReload.Size = New Size(70, 25)
        btnReload.TabIndex = 12
        btnReload.Text = "&REFRESH"
        btnReload.UseVisualStyleBackColor = False
        ' 
        ' dgvLocation
        ' 
        dgvLocation.AllowUserToAddRows = False
        dgvLocation.AllowUserToDeleteRows = False
        dgvLocation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvLocation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLocation.Dock = DockStyle.Fill
        dgvLocation.Location = New Point(0, 150)
        dgvLocation.Name = "dgvLocation"
        dgvLocation.ReadOnly = True
        dgvLocation.RowHeadersVisible = False
        dgvLocation.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLocation.Size = New Size(1067, 298)
        dgvLocation.TabIndex = 1
        ' 
        ' FrmLocation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1067, 448)
        Controls.Add(dgvLocation)
        Controls.Add(Panel1)
        Name = "FrmLocation"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Location Master"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(dgvLocation, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLocID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLocName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLocAddress As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnReload As System.Windows.Forms.Button
    Friend WithEvents dgvLocation As System.Windows.Forms.DataGridView
End Class
