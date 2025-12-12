Public Class Form2
    Private ItemList As New List(Of String)

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Sample data (replace with database data)
        ItemList.AddRange({
            "Apple",
            "Banana",
            "Mango",
            "Grapes",
            "Orange",
            "Papaya",
            "Pineapple",
            "Watermelon",
            "Waatermelon",
            "Wattermelon"
        })

        cboitem.IntegralHeight = False
        cboitem.MaxDropDownItems = 8

        LoadCombo("")
    End Sub

    ' ✅ Load & filter ComboBox
    Private Sub LoadCombo(searchText As String)

            cboItem.BeginUpdate()
            cboItem.Items.Clear()

            For Each itm As String In ItemList
                If itm.ToLower().Contains(searchText.ToLower()) Then
                    cboItem.Items.Add(itm)
                End If
            Next

            cboItem.EndUpdate()
        End Sub

        ' ✅ Search as you type
        Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) _
        Handles txtSearch.TextChanged

            LoadCombo(txtSearch.Text)

            cboItem.DroppedDown = True
            cboItem.SelectionStart = cboItem.Text.Length
        End Sub

        ' ✅ DOWN arrow → move focus to ComboBox
        Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles txtSearch.KeyDown

            If e.KeyCode = Keys.Down Then
                e.SuppressKeyPress = True

                If cboItem.Items.Count > 0 Then
                    cboItem.Focus()
                    cboItem.SelectedIndex = 0
                    cboItem.DroppedDown = True
                End If
            End If
        End Sub

        ' ✅ ENTER → select item
        Private Sub cboItem_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles cboItem.KeyDown

            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                txtSearch.Text = cboItem.Text
                lblSelected.Text = "Selected: " & cboItem.Text

                cboItem.DroppedDown = False
                txtSearch.Focus()
                txtSearch.SelectionStart = txtSearch.Text.Length
            End If

            ' ✅ UP arrow at top → go back to search box
            If e.KeyCode = Keys.Up And cboItem.SelectedIndex = 0 Then
                txtSearch.Focus()
            End If
        End Sub

    End Class

