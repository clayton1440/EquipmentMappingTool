Imports System.Data.SQLite


Public Class NewMapForm

	Public Shared Function CreateMap() As Boolean
		Dim mapSetup As New NewMapForm
		Dim fName As String = Config.LastMapPath
		mapSetup.TextBox1.Text = fName.Substring(fName.LastIndexOf("\") + 1).Substring(0, fName.Substring(fName.LastIndexOf("\") + 1).LastIndexOf("."))
		Try
			If mapSetup.ShowDialog = DialogResult.Yes Then
				Return True
			Else
				Return False
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message)
			Return False
		End Try
	End Function

	Private Sub MapCreationTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		If Not IO.File.Exists(Config.LastMapPath) Then
			IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(Config.LastMapPath))
			Try
				Dim cs As String = "Data Source=" & Config.LastMapPath & ";Version=3;"
				Dim conn As New SQLiteConnection(cs, True)
				Dim cmd As New SQLiteCommand
				cmd.Connection = conn
				cmd.CommandText = My.Resources.MapInitSQL

				conn.Open()
				cmd.ExecuteNonQuery()
				conn.Close()
			Catch ex As Exception
				Throw New Exception("Failed to create map database")
				Me.Close()
			End Try
		End If
	End Sub

	Private Sub Misc_NumericUpDownMouseWheelImprovement(sender As Object, e As HandledMouseEventArgs) Handles NumericUpDown1.MouseWheel, NumericUpDown2.MouseWheel
		Try
			Dim nud As NumericUpDown = sender
			e.Handled = True
			If e.Delta > 0 Then
				nud.UpButton()
			Else
				nud.DownButton()
			End If
		Catch ex As Exception

		End Try
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		If String.IsNullOrWhiteSpace(TextBox1.Text) Then
			Beep()
			MessageBox.Show("Enter a name for the Map.")
			Exit Sub
		End If

		Dim cs As String = "Data Source=" & Config.LastMapPath & ";Version=3;"
		Dim conn As New SQLiteConnection(cs, True)
		Dim cmd As New SQLiteCommand
		cmd.Connection = conn
		cmd.CommandText = "INSERT INTO Map (Name, Height, Width) VALUES (@Name, @Height, @Width);"

		cmd.Parameters.AddWithValue("@Name", TextBox1.Text)
		cmd.Parameters.AddWithValue("@Height", NumericUpDown1.Value)
		cmd.Parameters.AddWithValue("@Width", NumericUpDown2.Value)

		Try
			conn.Open()
			cmd.ExecuteNonQuery()
			conn.Close()
			Me.DialogResult = DialogResult.Yes
			Me.Close()
		Catch ex As Exception
			Throw New Exception("Failed to create map")
			Me.Close()
		End Try
	End Sub

	Private Sub Form_Closed(sender As Object, e As EventArgs) Handles Me.Closed
		Dispose()
	End Sub
End Class