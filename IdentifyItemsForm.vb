Public Class IdentifyItemsForm

	Public Shared Sub IdentifyItemsInCell(cell As Cell)
		If cell.Items.Count = 0 Then
			MessageBox.Show("No items in cell.")
			Exit Sub
		End If
		Dim frm As New IdentifyItemsForm
		frm.LocLabel.Text = $"Item{If(cell.Items.Count > 1, "s", "")} in cell ( {cell.Column} ,  {cell.Row} ) :"
		frm.Text = $"Identify Item{If(cell.Items.Count > 1, "s", "")}"

		Dim IDString As String = ""
		For Each item As Item In cell.Items.Values
			IDString &= $"{item.ID}{vbCrLf}"
		Next

		frm.TextBox1.Text = IDString
		frm.ShowDialog()

	End Sub
	Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
		Me.Close()
	End Sub

	Private Sub Form_Closed(sender As Object, e As EventArgs) Handles Me.Closed
		Dispose()
	End Sub
End Class