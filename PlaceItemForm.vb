Imports System.Security.Cryptography

Public Class PlaceItemForm

	Private itemRef As Dictionary(Of String, Item)
	Private ready As Boolean = False
	Public Shared Function PlaceItem(GridLocation As Point, ExistingItemRef As Dictionary(Of String, Item), Optional RefItem As Item = Nothing) As (Item, DialogResult)
		Dim frm As New PlaceItemForm
		frm.itemRef = ExistingItemRef
		frm.LocTextBox.Text = $"({GridLocation.X}, {GridLocation.Y})"

		If RefItem IsNot Nothing Then
			frm.ItemID.Text = RefItem.ID
			frm.NameBox.Text = RefItem.Name
			frm.NoExpiration.Checked = RefItem.ExpDate = Nothing
			If RefItem.ExpDate = Nothing Then
				frm.ExpDate.Value = Date.Today
				frm.ExpDate.MinDate = Date.Today
			Else
				frm.ExpDate.Value = RefItem.ExpDate
				If RefItem.ExpDate <> Nothing AndAlso RefItem.ExpDate < Date.Today Then
					frm.EP1.SetError(frm.SaveButton, "Item is expired. Update expiration date or remove from storage.")
					frm.SaveButton.Enabled = False
				End If
			End If
			frm.Notes.Text = RefItem.Notes
			frm.User.Text = RefItem.User
			If RefItem.ExpDate = Nothing Then frm.ExpDate.Enabled = False
		Else
			frm.ExpDate.Value = Date.Today
			frm.ExpDate.MinDate = Date.Today
		End If

		frm.ready = True

		Dim dr As DialogResult = frm.ShowDialog
		If dr = DialogResult.OK Or dr = DialogResult.Retry Then
			Return (New Item() With {
				.ID = frm.ItemID.Text,
				.Name = frm.NameBox.Text,
				.User = frm.User.Text,
				.Row = GridLocation.Y,
				.Column = GridLocation.X,
				.ExpDate = If(frm.NoExpiration.Checked, Nothing, frm.ExpDate.Value.ToString("yyyy-MM-dd")),
				.Notes = frm.Notes.Text
			}, dr)
		Else
			Return (Nothing, dr)
		End If
	End Function

	Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
		If String.IsNullOrWhiteSpace(ItemID.Text) Then
			Beep()
			MessageBox.Show("Enter an ID for the Item.")
			Exit Sub
		End If

		DialogResult = DialogResult.OK
		Close()
	End Sub

	Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
		DialogResult = DialogResult.Cancel
		Close()
	End Sub

	Private Sub SelectLocationButton_Click(sender As Object, e As EventArgs) Handles SelectLocationButton.Click
		DialogResult = DialogResult.Retry
		Close()
	End Sub

	Private Sub ItemID_TextChanged(sender As Object, e As EventArgs) Handles ItemID.TextChanged
		If Not ready Then Exit Sub
		If itemRef.ContainsKey(ItemID.Text) Then
			Dim item As Item = itemRef(ItemID.Text)
			NameBox.Text = item.Name
			NoExpiration.Checked = item.ExpDate = Nothing
			If item.ExpDate <> Nothing AndAlso item.ExpDate < Date.Today Then
				ExpDate.MinDate = item.ExpDate
				EP1.SetError(SaveButton, "Item is expired. Update expiration date or remove from storage.")
				SaveButton.Enabled = False
			Else
				EP1.Clear()
				SaveButton.Enabled = True
			End If
			ExpDate.Value = If(item.ExpDate = Nothing, Date.Today, item.ExpDate)
			Notes.Text = item.Notes
			User.Text = item.User
		End If
	End Sub

	Private Sub NoExpiration_CheckedChanged(sender As Object, e As EventArgs) Handles NoExpiration.CheckedChanged
		If Not ready Then Exit Sub
		If NoExpiration.Checked Then
			ExpDate.Enabled = False
		Else
			ExpDate.Enabled = True
		End If
	End Sub

	Private Sub PlaceItemForm_Load(sender As Object, e As EventArgs) Handles Me.Load

	End Sub

	Private Sub ExpDate_ValueChanged(sender As Object, e As EventArgs) Handles ExpDate.ValueChanged
		If ExpDate.Value < Date.Today Then
			EP1.SetError(SaveButton, "Item is expired. Update expiration date or remove from storage.")
			SaveButton.Enabled = False
		Else
			EP1.Clear()
			SaveButton.Enabled = True
		End If
	End Sub

	'Private Sub Form_Closed(sender As Object, e As EventArgs) Handles Me.Closed
	'	Dispose()
	'End Sub
End Class