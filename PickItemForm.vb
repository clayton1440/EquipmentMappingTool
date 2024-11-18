Public Class PickItemForm
	Private cellRef As Cell


	Public Function PickItems(cell As Cell) As List(Of Item)
		Dim frm As New PickItemForm
		frm.cellRef = cell
		frm.Text = $"Pick Item{If(cell.Items.Count > 1, "s", "")}"

		For Each item As Item In cell.Items.Values
			frm.ItemListBox.Items.Add(item.ID)
		Next

		Dim dr As DialogResult = frm.ShowDialog()

		If dr = DialogResult.OK Then
			Dim items As New List(Of Item)
			For Each itemID As String In frm.ItemListBox.SelectedItems
				items.Add(frm.cellRef.Items(itemID))
			Next
			Return items
		Else
			Return Nothing
		End If

	End Function

	Private Sub SelectButton_Click(sender As Object, e As EventArgs) Handles SelectButton.Click
		Me.DialogResult = DialogResult.OK
		Close()
	End Sub

	Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
		Me.DialogResult = DialogResult.Cancel
		Close()
	End Sub

	Private Sub PickItemForm_Load(sender As Object, e As EventArgs) Handles Me.Shown
		If ItemListBox.Items.Count > 0 Then
			ItemListBox.SelectedIndex = 0
		End If
	End Sub
End Class