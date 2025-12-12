Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing.Printing

Public Class Form3
    ' ... (Connection string logic remains same)
    Dim dbPath As String = "C:\Users\ATAM\MYPROJ\hello\INVENTORY.accdb"
    Dim connString As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};Persist Security Info=False;"
    Dim conn As OleDbConnection
    
    ' Printing variables
    Dim WithEvents ptr As PrintDocument
    Dim itemsToPrint As DataTable
    Dim printRowIndex As Integer



    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        InitializeDatabase()
        LoadData()
    End Sub

    ' ... (InitializeDatabase, LoadData, Search Logic, Button Clicks remain same) ...

    ' PRINT Button Click
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvInventory.Rows.Count = 0 Then
            MessageBox.Show("No items to print", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        
        ' Prepare data for printing
        itemsToPrint = CType(dgvInventory.DataSource, DataTable)
        printRowIndex = 0
        
        ptr = New PrintDocument()
        Dim ppd As New PrintPreviewDialog()
        ppd.Document = ptr
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub

    Private Sub ptr_PrintPage(sender As Object, e As PrintPageEventArgs) Handles ptr.PrintPage
        Dim fontTitle As New Font("Arial", 16, FontStyle.Bold)
        Dim fontHeader As New Font("Arial", 10, FontStyle.Bold)
        Dim fontItem As New Font("Arial", 10, FontStyle.Regular)
        
        Dim margin As Integer = 50
        Dim yPos As Integer = margin
        
        ' Title
        e.Graphics.DrawString("Inventory List", fontTitle, Brushes.Black, margin, yPos)
        yPos += 40
        
        ' Header
        e.Graphics.DrawString("ID", fontHeader, Brushes.Black, margin, yPos)
        e.Graphics.DrawString("Item Name", fontHeader, Brushes.Black, margin + 60, yPos)
        e.Graphics.DrawString("Price", fontHeader, Brushes.Black, margin + 350, yPos)
        e.Graphics.DrawString("Qty", fontHeader, Brushes.Black, margin + 450, yPos)
        
        ' Draw Line
        yPos += 20
        e.Graphics.DrawLine(Pens.Black, margin, yPos, e.PageBounds.Width - margin, yPos)
        yPos += 10
        
        ' Items
        While printRowIndex < itemsToPrint.Rows.Count
             Dim row As DataRow = itemsToPrint.Rows(printRowIndex)
             
             e.Graphics.DrawString(row("ItemID").ToString(), fontItem, Brushes.Black, margin, yPos)
             e.Graphics.DrawString(row("ItemName").ToString(), fontItem, Brushes.Black, margin + 60, yPos)
             e.Graphics.DrawString(FormatCurrency(row("Price")), fontItem, Brushes.Black, margin + 350, yPos)
             e.Graphics.DrawString(row("Quantity").ToString(), fontItem, Brushes.Black, margin + 450, yPos)
             
             yPos += 25
             printRowIndex += 1
             
             If yPos >= e.PageBounds.Height - margin Then
                 e.HasMorePages = True
                 Return
             End If
        End While
        
        e.HasMorePages = False
    End Sub

    ' ... (Rest of existing methods: btnAdd, btnUpdate, etc.) ...

    ' ... (InitializeDatabase and LoadData methods remain the same) ...

    ' Search Button Click
    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        PerformSearch()
    End Sub

    ' Real-time search/filter as user types
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        PerformSearch()
    End Sub

    Private Sub PerformSearch()
        If dgvInventory.DataSource IsNot Nothing Then
            Dim dt As DataTable = CType(dgvInventory.DataSource, DataTable)
            ' Filter by ItemName or ItemID
            ' Note: ID is numeric, so we cast to string for LIKE search or filter only by Name
            ' Let's filter by Name (case-insensitive)
            Dim filter As String = $"ItemName LIKE '%{txtSearch.Text}%'"
            
            ' If the input is numeric, we can also try to match ID
            If IsNumeric(txtSearch.Text) Then
                 filter &= $" OR ItemID = {txtSearch.Text}"
            End If
            
            ' Apply filter safely
            Try
                 dt.DefaultView.RowFilter = filter
            Catch ex As Exception
                 ' Fallback to just name if ID filter fails typemismatch (though IsNumeric check helps)
                 dt.DefaultView.RowFilter = $"ItemName LIKE '%{txtSearch.Text}%'"
            End Try
        End If
    End Sub

    ' Reload / Reset Filter Button
    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        txtSearch.Text = ""
        If dgvInventory.DataSource IsNot Nothing Then
            CType(dgvInventory.DataSource, DataTable).DefaultView.RowFilter = String.Empty
        End If
        LoadData()
    End Sub

    ' Check if DB exists and Table exists, create if not
    Private Sub InitializeDatabase()
        If Not File.Exists(dbPath) Then
            Try
                ' Create new Access database using ADOX via late binding
                ' Using simplified connection string for creation to avoid "Multiple-step OLE DB operation" errors
                Dim cat As Object = CreateObject("ADOX.Catalog")
                cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbPath)
                cat = Nothing
            Catch ex As Exception
                MessageBox.Show("Could not create database file: " & ex.Message & vbCrLf & "Please ensure Microsoft Access Database Engine is installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If

        Try
            ' Check if table exists by trying to select from it
            Using con As New OleDbConnection(connString)
                con.Open()
                Dim schema As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
                Dim tableExists As Boolean = False
                For Each row As DataRow In schema.Rows
                    If row("TABLE_NAME").ToString().Equals("Items", StringComparison.OrdinalIgnoreCase) Then
                        tableExists = True
                        Exit For
                    End If
                Next

                If Not tableExists Then
                    ' Create the table with AutoIncrement ID
                    ' Note: in Access SQL, AUTOINCREMENT is used for auto-numbering
                    Dim cmd As New OleDbCommand("CREATE TABLE Items (ItemID AUTOINCREMENT PRIMARY KEY, ItemName VARCHAR(255), Price CURRENCY, Quantity INT)", con)
                    cmd.ExecuteNonQuery()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error initializing database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            Using con As New OleDbConnection(connString)
                Dim cmd As New OleDbCommand("SELECT * FROM Items", con)
                Dim da As New OleDbDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                dgvInventory.DataSource = dt

                ' Set column widths
                If dgvInventory.Columns.Count > 0 Then
                    If dgvInventory.Columns.Contains("ItemID") Then dgvInventory.Columns("ItemID").Width = 80
                    If dgvInventory.Columns.Contains("ItemName") Then dgvInventory.Columns("ItemName").Width = 300
                    If dgvInventory.Columns.Contains("Price") Then dgvInventory.Columns("Price").Width = 100
                    If dgvInventory.Columns.Contains("Quantity") Then dgvInventory.Columns("Quantity").Width = 100
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtName.Text = "" Then
            MessageBox.Show("Please enter Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using con As New OleDbConnection(connString)
                con.Open()

                ' Check for Duplicate Name
                Dim checkQuery As String = "SELECT COUNT(*) FROM Items WHERE ItemName = @checkName"
                Using checkCmd As New OleDbCommand(checkQuery, con)
                    checkCmd.Parameters.AddWithValue("@checkName", txtName.Text)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                         MessageBox.Show("Item Name already exists! Please use a unique name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                         Return
                    End If
                End Using

                ' ID is not included in INSERT as it is AutoIncrement
                Dim query As String = "INSERT INTO Items (ItemName, Price, Quantity) VALUES (@name, @price, @qty)"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("@name", txtName.Text)
                    cmd.Parameters.AddWithValue("@price", If(IsNumeric(txtPrice.Text), Convert.ToDecimal(txtPrice.Text), 0))
                    cmd.Parameters.AddWithValue("@qty", If(IsNumeric(txtQty.Text), Convert.ToInt32(txtQty.Text), 0))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Item Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error adding item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtID.Text = "" Then
            MessageBox.Show("Please select an item to update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using con As New OleDbConnection(connString)
                con.Open()
                Dim query As String = "UPDATE Items SET ItemName = @name, Price = @price, Quantity = @qty WHERE ItemID = @id"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("@name", txtName.Text)
                    cmd.Parameters.AddWithValue("@price", If(IsNumeric(txtPrice.Text), Convert.ToDecimal(txtPrice.Text), 0))
                    cmd.Parameters.AddWithValue("@qty", If(IsNumeric(txtQty.Text), Convert.ToInt32(txtQty.Text), 0))
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text)) ' Ensure ID is treated as number
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Item Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error updating item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtID.Text = "" Then
            MessageBox.Show("Please select an Item to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("Are you sure you want to delete this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using con As New OleDbConnection(connString)
                    con.Open()
                    Dim query As String = "DELETE FROM Items WHERE ItemID = @id"
                    Using cmd As New OleDbCommand(query, con)
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text))
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show("Item Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearFields()
            Catch ex As Exception
                MessageBox.Show("Error deleting item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtID.Text = ""
        txtName.Text = ""
        txtPrice.Text = ""
        txtQty.Text = ""
        txtName.Focus() ' Focus on Name instead of ID
    End Sub

    Private Sub dgvInventory_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvInventory.Rows(e.RowIndex)
            txtID.Text = row.Cells("ItemID").Value.ToString()
            txtName.Text = row.Cells("ItemName").Value.ToString()
            txtPrice.Text = row.Cells("Price").Value.ToString()
            txtQty.Text = row.Cells("Quantity").Value.ToString()
        End If
    End Sub
End Class
