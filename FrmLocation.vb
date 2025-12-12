Imports System.Data.OleDb
Imports System.IO

Public Class FrmLocation
    Dim dbPath As String = "C:\Users\ATAM\MYPROJ\hello\INVENTORY.accdb"
    Dim connString As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};Persist Security Info=False;"
    
    Private Sub FrmLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        InitializeDatabase()
        LoadData()
    End Sub

    Private Sub InitializeDatabase()
        If Not File.Exists(dbPath) Then
            Try
                Dim cat As Object = CreateObject("ADOX.Catalog")
                cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbPath)
                cat = Nothing
            Catch ex As Exception
                MessageBox.Show("Error creating database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If

        Try
            Using con As New OleDbConnection(connString)
                con.Open()
                Dim schema As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
                Dim tableExists As Boolean = False
                For Each row As DataRow In schema.Rows
                    If row("TABLE_NAME").ToString().Equals("Location", StringComparison.OrdinalIgnoreCase) Then
                        tableExists = True
                        Exit For
                    End If
                Next

                If Not tableExists Then
                    Dim cmd As New OleDbCommand("CREATE TABLE Location (LocID AUTOINCREMENT PRIMARY KEY, LocName VARCHAR(255), LocAddress VARCHAR(255))", con)
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
                Dim cmd As New OleDbCommand("SELECT * FROM Location", con)
                Dim da As New OleDbDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                dgvLocation.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtLocName.Text = "" Then
            MessageBox.Show("Please enter Location Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using con As New OleDbConnection(connString)
                con.Open()

                ' Check for Duplicate Location Name
                Dim checkQuery As String = "SELECT COUNT(*) FROM Location WHERE LocName = @checkName"
                Using checkCmd As New OleDbCommand(checkQuery, con)
                    checkCmd.Parameters.AddWithValue("@checkName", txtLocName.Text)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                         MessageBox.Show("Location Name already exists! Please use a unique name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                         Return
                    End If
                End Using

                Dim query As String = "INSERT INTO Location (LocName, LocAddress) VALUES (@name, @address)"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("@name", txtLocName.Text)
                    cmd.Parameters.AddWithValue("@address", txtLocAddress.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Location Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error adding location: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtLocID.Text = "" Then
            MessageBox.Show("Please select a location to update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using con As New OleDbConnection(connString)
                con.Open()
                Dim query As String = "UPDATE Location SET LocName = @name, LocAddress = @address WHERE LocID = @id"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("@name", txtLocName.Text)
                    cmd.Parameters.AddWithValue("@address", txtLocAddress.Text)
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtLocID.Text))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Location Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error updating location: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtLocID.Text = "" Then
            MessageBox.Show("Please select a location to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("Are you sure you want to delete this location?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using con As New OleDbConnection(connString)
                    con.Open()
                    Dim query As String = "DELETE FROM Location WHERE LocID = @id"
                    Using cmd As New OleDbCommand(query, con)
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtLocID.Text))
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show("Location Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearFields()
            Catch ex As Exception
                MessageBox.Show("Error deleting location: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtLocID.Text = ""
        txtLocName.Text = ""
        txtLocAddress.Text = ""
        txtLocName.Focus()
    End Sub

    Private Sub dgvLocation_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLocation.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvLocation.Rows(e.RowIndex)
            txtLocID.Text = row.Cells("LocID").Value.ToString()
            txtLocName.Text = row.Cells("LocName").Value.ToString()
            txtLocAddress.Text = row.Cells("LocAddress").Value.ToString()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If dgvLocation.DataSource IsNot Nothing Then
             Dim dt As DataTable = CType(dgvLocation.DataSource, DataTable)
             Dim filter As String = $"LocName LIKE '%{txtSearch.Text}%'"
             Try
                 dt.DefaultView.RowFilter = filter
             Catch ex As Exception
             End Try
        End If
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        txtSearch.Text = ""
        If dgvLocation.DataSource IsNot Nothing Then
            CType(dgvLocation.DataSource, DataTable).DefaultView.RowFilter = String.Empty
        End If
        LoadData()
    End Sub
End Class
