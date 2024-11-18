Imports System.Security.Cryptography

Public Class NewAreaForm
	Public Shared Function NewArea() As Area
		Dim frm As New NewAreaForm
		If frm.ShowDialog = DialogResult.OK Then
			Return New Area() With {
				.Name = frm.TextBox1.Text,
				.Color = frm.Panel1.BackColor,
				.CanHoldItems = frm.CanHoldItems.Checked
			}
		Else
			Return Nothing
		End If

	End Function

	Public Shared Function EditArea(area As Area) As Area
		Dim frm As New NewAreaForm
		frm.Text = "Edit Area"
		frm.TextBox1.Text = area.Name
		frm.Panel1.BackColor = area.Color
		frm.CanHoldItems.Checked = area.CanHoldItems
		If frm.ShowDialog = DialogResult.OK Then
			Return New Area() With {
				.Name = frm.TextBox1.Text,
				.Color = frm.Panel1.BackColor,
				.CanHoldItems = frm.CanHoldItems.Checked,
				.ID = area.ID
			}
		Else
			Return Nothing
		End If
	End Function


	Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
		Dim cDialog As New ColorDialog
		cDialog.FullOpen = True
		If Me.Text.Contains("Edit") Then cDialog.Color = Panel1.BackColor
		If cDialog.ShowDialog = DialogResult.OK Then
			Panel1.BackColor = cDialog.Color
		End If
	End Sub

	Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
		If String.IsNullOrWhiteSpace(TextBox1.Text) Then
			MessageBox.Show("Please enter a name for the area.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Exit Sub
		End If

		DialogResult = DialogResult.OK
		Close()
	End Sub

	Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
		DialogResult = DialogResult.Cancel
		Close()
	End Sub

End Class