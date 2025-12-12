Imports System.Data.OleDb
Imports System.IO

Public Class FrmOpeningStock
    Dim dbPath As String = "C:\Users\ATAM\MYPROJ\hello\INVENTORY.accdb"
    Dim connString As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};Persist Security Info=False;"
    
    Private Sub FrmOpeningStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        InitializeDatabase()
        LoadComboData()
        LoadData()
    End Sub

    Private Sub InitializeDatabase()
        ' Ensure table exists
        Try
            Using con As New OleDbConnection(connString)
                con.Open()
                Dim schema As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
                Dim tableExists As Boolean = False
                For Each row As DataRow In schema.Rows
                    If row("TABLE_NAME").ToString().Equals("OpeningStock", StringComparison.OrdinalIgnoreCase) Then
                        tableExists = True
                        Exit For
                    End If
                Next

                If Not tableExists Then
                    ' Create OpeningStock table
                    ' StockID (PK), LocationID (Int), ItemID (Int), Quantity (Int)
                    Dim cmd As New OleDbCommand("CREATE TABLE OpeningStock (StockID AUTOINCREMENT PRIMARY KEY, LocationID INT, ItemID INT, Quantity INT)", con)
                    cmd.ExecuteNonQuery()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error initializing database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadComboData()
        Try
            Using con As New OleDbConnection(connString)
                con.Open()
                
                ' Load Locations
                Dim daLoc As New OleDbDataAdapter("SELECT LocID, LocName FROM Location", con)
                Dim dtLoc As New DataTable()
                daLoc.Fill(dtLoc)
                cmbLocation.DataSource = dtLoc
                cmbLocation.DisplayMember = "LocName"
                cmbLocation.ValueMember = "LocID"
                cmbLocation.SelectedIndex = -1

                ' Load Items
                Dim daItem As New OleDbDataAdapter("SELECT ItemID, ItemName FROM Items", con)
                Dim dtItem As New DataTable()
                daItem.Fill(dtItem)
                cmbItem.DataSource = dtItem
                cmbItem.DisplayMember = "ItemName"
                cmbItem.ValueMember = "ItemID"
                cmbItem.SelectedIndex = -1
            End Using
        Catch ex As Exception
             MessageBox.Show("Error loading combos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            Using con As New OleDbConnection(connString)
                ' Join with Location and Items to show names instead of IDs
                Dim query As String = "SELECT O.StockID, L.LocName, I.ItemName, O.Quantity, O.LocationID, O.ItemID " &
                                    "FROM ((OpeningStock O " &
                                    "LEFT JOIN Location L ON O.LocationID = L.LocID) " &
                                    "LEFT JOIN Items I ON O.ItemID = I.ItemID)"
                
                Dim cmd As New OleDbCommand(query, con)
                Dim da As New OleDbDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                dgvStock.DataSource = dt
                
                ' Hide ID columns if desired, or keep them for debug
                If dgvStock.Columns.Contains("LocationID") Then dgvStock.Columns("LocationID").Visible = False
                If dgvStock.Columns.Contains("ItemID") Then dgvStock.Columns("ItemID").Visible = False
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cmbLocation.SelectedIndex = -1 Or cmbItem.SelectedIndex = -1 Or txtQty.Text = "" Then
            MessageBox.Show("Please select Location, Item and enter Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using con As New OleDbConnection(connString)
                con.Open()
                
                ' Check if entry already exists for this Location + Item
                Dim checkQuery As String = "SELECT COUNT(*) FROM OpeningStock WHERE LocationID = @loc AND ItemID = @item"
                Using checkCmd As New OleDbCommand(checkQuery, con)
                    checkCmd.Parameters.AddWithValue("@loc", cmbLocation.SelectedValue)
                    checkCmd.Parameters.AddWithValue("@item", cmbItem.SelectedValue)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                         MessageBox.Show("Opening stock for this Item at this Location already exists! Please use Update.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                         Return
                    End If
                End Using

                Dim query As String = "INSERT INTO OpeningStock (LocationID, ItemID, Quantity) VALUES (@loc, @item, @qty)"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("@loc", cmbLocation.SelectedValue)
                    cmd.Parameters.AddWithValue("@item", cmbItem.SelectedValue)
                    cmd.Parameters.AddWithValue("@qty", If(IsNumeric(txtQty.Text), Convert.ToInt32(txtQty.Text), 0))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Stock Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error adding stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtID.Text = "" Then
             MessageBox.Show("Please select a record to update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
             Return
        End If

        Try
            Using con As New OleDbConnection(connString)
                con.Open()
                Dim query As String = "UPDATE OpeningStock SET LocationID = @loc, ItemID = @item, Quantity = @qty WHERE StockID = @id"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("@loc", cmbLocation.SelectedValue)
                    cmd.Parameters.AddWithValue("@item", cmbItem.SelectedValue)
                    cmd.Parameters.AddWithValue("@qty", If(IsNumeric(txtQty.Text), Convert.ToInt32(txtQty.Text), 0))
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Stock Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error updating stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtID.Text = "" Then
             MessageBox.Show("Please select a record to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
             Return
        End If

        If MessageBox.Show("Are you sure you want to delete this stock entry?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using con As New OleDbConnection(connString)
                    con.Open()
                    Dim query As String = "DELETE FROM OpeningStock WHERE StockID = @id"
                    Using cmd As New OleDbCommand(query, con)
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text))
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show("Stock Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearFields()
            Catch ex As Exception
                MessageBox.Show("Error deleting stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtID.Text = ""
        cmbLocation.SelectedIndex = -1
        cmbItem.SelectedIndex = -1
        txtQty.Text = ""
    End Sub

    Private Sub dgvStock_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStock.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvStock.Rows(e.RowIndex)
            txtID.Text = row.Cells("StockID").Value.ToString()
            cmbLocation.SelectedValue = row.Cells("LocationID").Value
            cmbItem.SelectedValue = row.Cells("ItemID").Value
            txtQty.Text = row.Cells("Quantity").Value.ToString()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If dgvStock.DataSource IsNot Nothing Then
             Dim dt As DataTable = CType(dgvStock.DataSource, DataTable)
             ' Filter by Location Name or Item Name
             Dim filter As String = $"LocName LIKE '%{txtSearch.Text}%' OR ItemName LIKE '%{txtSearch.Text}%'"
             Try
                 dt.DefaultView.RowFilter = filter
             Catch ex As Exception
             End Try
        End If
    End Sub
End Class
