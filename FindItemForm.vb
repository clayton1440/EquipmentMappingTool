Imports System.ComponentModel

Public Class FindItemForm
	Private Sub ItemID_TextChanged(sender As Object, e As EventArgs) Handles ItemID.TextChanged
		If MapForm.Items.ContainsKey(ItemID.Text) Then
			StatusLabel.Text = "Found"
			ShowOnMapButton.Enabled = True
		ElseIf MapForm.StoredItems.ContainsKey(ItemID.Text) Then
			StatusLabel.Text = "In Storage"
			ShowOnMapButton.Enabled = False
		Else
			StatusLabel.Text = "Not Found"
			ShowOnMapButton.Enabled = False
		End If
	End Sub

	Private Sub ShowOnMapButton_Click(sender As Object, e As EventArgs) Handles ShowOnMapButton.Click
		MapForm.TabControl1.SelectedTab = MapForm.MapPage
		MapForm.MapGrid.SetSelectedCell(MapForm.Items(ItemID.Text).Point)
		Me.Hide()
	End Sub

	Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
		Me.Hide()
	End Sub

	Private Sub FindItemForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
		If sender Is Me Then
			e.Cancel = True
			Me.Hide()
		End If
	End Sub

	Private Sub FindItemForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
		'ItemID.Focus()
		ItemID.SelectAll()
	End Sub
End Class