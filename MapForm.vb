Imports System.ComponentModel
Imports System.Data.SQLite

Public Class MapForm

#Region "Load"

	Private Sub Map_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		MapGrid.ShowGridlines = False
		MapGrid.CellDefaultBackColor = SystemColors.ControlDark
		MapGrid.CellSize = Math.Round(MapGrid.CellSize * DisplayScale())

		If Config.StartMaximized Then Me.WindowState = FormWindowState.Maximized

		'If String.IsNullOrWhiteSpace(Config.LastMapPath) Then
		'	Dim dPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\EquipmentMappingTool\Local.map"
		'	Config.LastMapPath = dPath
		'End If

		Dim Args As String() = Environment.GetCommandLineArgs
		If Args.Count > 1 Then
			If IO.File.Exists(Args(1)) AndAlso Args(1).ToLower.Trim("""").EndsWith(".emap") Then
				Config.LastMapPath = Args(1).Trim("""")
			End If
		End If

		If Not String.IsNullOrWhiteSpace(Config.LastMapPath) Then
			LoadMap()
		End If
	End Sub
	Private Sub Map_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
		Config.StartMaximized = Me.WindowState = FormWindowState.Maximized
	End Sub

	Private Areas As New Dictionary(Of Integer, Area)
	'Private GridLayout As New Dictionary(Of Integer, Cell)
	Public GridPoints As New Dictionary(Of Point, Cell)
	Public Items As New Dictionary(Of String, Item)
	Public StoredItems As New Dictionary(Of String, Item)
	Private mapName As String

	Private Sub LoadMap()

		If Not IO.File.Exists(Config.LastMapPath) AndAlso Not NewMapForm.CreateMap() Then
			IO.File.Delete(Config.LastMapPath)
			Exit Sub
		End If

		MapGrid.Reset()

		Dim MapTable As New DataTable
		Try
			Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
			Dim cmd As New SQLiteCommand
			cmd.Connection = conn
			cmd.CommandText = "SELECT * FROM Map;"

			conn.Open()
			MapTable.Load(cmd.ExecuteReader())
			conn.Close()
		Catch ex As Exception
			MessageBox.Show("Failed to load map")
			MapSetupButton.Checked = False
			MapSetupButton.Font = New Font(MapSetupButton.Font, FontStyle.Regular)
			Exit Sub
		End Try

		mapName = MapTable.Rows(0).Item("Name")
		Dim mHeight As Integer = MapTable.Rows(0).Item("Height")
		Dim mWidth As Integer = MapTable.Rows(0).Item("Width")

		Me.Text = $"Equipment Mapping Tool - {mapName}"
		MapGrid.Rows = mHeight
		MapGrid.Columns = mWidth

		Dim aTable As New DataTable
		Dim lTable As New DataTable
		Dim iTable As New DataTable
		Dim sTable As New DataTable

		Try
			Dim cmd As New SQLiteCommand
			Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
			cmd.Connection = conn
			cmd.CommandText = "SELECT * FROM Area;"

			conn.Open()
			aTable.Load(cmd.ExecuteReader())
			conn.Close()

			cmd = New SQLiteCommand
			cmd.Connection = conn
			cmd.CommandText = "SELECT * FROM Layout;"

			conn.Open()
			lTable.Load(cmd.ExecuteReader())
			conn.Close()

			cmd = New SQLiteCommand
			cmd.Connection = conn
			cmd.CommandText = "SELECT * FROM Item;"

			conn.Open()
			iTable.Load(cmd.ExecuteReader())
			conn.Close()

			cmd = New SQLiteCommand
			cmd.Connection = conn
			cmd.CommandText = "SELECT * FROM Storage;"

			conn.Open()
			sTable.Load(cmd.ExecuteReader())
			conn.Close()
		Catch ex As Exception
			MessageBox.Show("Failed to load map data")
			Throw New Exception(ex.Message, ex)
		End Try

		Areas.Clear()
		If aTable.Rows.Count > 0 Then
			For Each area As DataRow In aTable.Rows
				Dim aID As Integer = area.Item("ID")
				Dim aName As String = area.Item("Name")
				Dim aColor As Color = Color.FromArgb(area.Item("Color"))
				Dim aHoldsItems As Boolean = area.Item("CanHoldItems")

				Areas.Add(aID, New Area With {.ID = aID, .Name = aName, .Color = aColor, .CanHoldItems = aHoldsItems})
			Next
		End If
		GridPoints.Clear()
		If lTable.Rows.Count > 0 Then
			For Each cell As DataRow In lTable.Rows
				Dim cId As Integer = cell.Item("ID")
				Dim cRow As Integer = cell.Item("Row")
				Dim cCol As Integer = cell.Item("Column")
				Dim cArea As Integer = cell.Item("AreaID")

				GridPoints.Add(New Point(cCol, cRow), New Cell With {.ID = cId, .AreaID = cArea, .Row = cRow, .Column = cCol})
			Next
		End If
		Items.Clear()
		If iTable.Rows.Count > 0 Then
			For Each item As DataRow In iTable.Rows
				Dim iID As String = item.Item("ID")
				Dim iName As String = item.Item("Name")
				Dim iRow As Integer = item.Item("Row")
				Dim iCol As Integer = item.Item("Column")
				Dim iExp As String = item.Item("ExpDate").ToString
				Dim iUser As String = item.Item("User")
				Dim iNotes As String = item.Item("Notes")

				Items.Add(iID, New Item With {.ID = iID, .Name = iName, .Row = iRow, .Column = iCol, .ExpDate = iExp, .User = iUser, .Notes = iNotes})
				GridPoints(New Point(iCol, iRow)).Items.Add(Items(iID).ID, Items(iID))
			Next
		End If
		StoredItems.Clear()
		If sTable.Rows.Count > 0 Then
			For Each sItem As DataRow In sTable.Rows
				Dim sID As String = sItem.Item("ID")
				Dim sName As String = sItem.Item("Name")
				Dim sExp As String = sItem.Item("ExpDate").ToString
				Dim sUser As String = sItem.Item("User")
				Dim sNotes As String = sItem.Item("Notes")

				StoredItems.Add(sID, New Item With {.ID = sID, .Name = sName, .ExpDate = sExp, .User = sUser, .Notes = sNotes})
			Next
		End If

		For Each c As Cell In GridPoints.Values
			MapGrid.CellBackColor(c.Row, c.Column) = Areas(c.AreaID).Color
		Next
		For Each i As Item In Items.Values
			Dim oVal As String = MapGrid.CellValue(i.Row, i.Column)
			MapGrid.CellValue(i.Row, i.Column) = If(oVal = "", 0, CInt(oVal)) + 1
		Next

	End Sub

#End Region

#Region "Horizontal Mouse Wheel"

	'	MustInherit Class Win32Messages
	'		Public Const WM_MOUSEHWHEEL As Integer = &H20E 'setting constant for horizontal mouse wheel WndProc message
	'		Public Const WM_MOUSE_ESC As Integer = -1
	'	End Class

	'	Protected Overrides Sub WndProc(ByRef m As Message)
	'		'override the WndProc. If the horizontal mouse wheel message is sent, intercept it, else return the message to the normal WndProc
	'		Try
	'			MyBase.WndProc(m)
	'			If m.HWnd <> Me.Handle Then
	'				Return
	'			End If
	'			Select Case m.Msg
	'				Case Win32Messages.WM_MOUSEHWHEEL
	'					'if message is for horizontal scroll, send the WParam to determine which direction and actually do the scrolling.
	'					'Set the WndProc result so the nothing else processes the same message
	'					MouseHorizontalScroll(m.WParam.ToInt64)
	'					m.Result = CType(1, IntPtr)
	'					Exit Select
	'				Case Else

	'					Exit Select
	'			End Select
	'		Catch ex As Exception
	'			'MessageBox.Show(ex.Message)
	'		End Try

	'	End Sub

	'	Private Sub MouseHorizontalScroll(WParam)
	'		If MapGrid Is Nothing OrElse Not MapGrid.Visible Then Exit Sub
	'		If Not MapGrid.HorizontalScroll.Visible Then Exit Sub
	'		Dim scrollColumns As Integer

	'		Console.WriteLine(WParam)
	'		If WParam < 1000000000 AndAlso WParam > 0 Then 'wheel tilt right/horz wheel up
	'			scrollColumns = 1
	'		Else 'wheel tilt left/horz wheel down
	'			scrollColumns = -1
	'			'Else
	'			'Exit Sub
	'		End If

	'		Dim scrollMultiplier As Integer
	'		If My.Computer.Keyboard.CtrlKeyDown Then
	'			scrollMultiplier = 20
	'		Else
	'			scrollMultiplier = 5
	'		End If

	'		' Determine the new horizontal scroll position
	'		Dim newScrollPosition As Integer = MapGrid.HorizontalScroll.Value + (scrollColumns * scrollMultiplier * MapGrid.CellSize)

	'		' Determine the maximum scroll position
	'		Dim maxScrollPosition As Integer = MapGrid.HorizontalScroll.Maximum

	'		' Ensure the scroll position is within the valid range
	'		If newScrollPosition < 0 Then
	'			newScrollPosition = 0
	'		ElseIf newScrollPosition > maxScrollPosition Then
	'			newScrollPosition = maxScrollPosition
	'		End If

	'		' Set the new horizontal scroll position
	'		MapGrid.HorizontalScroll.Value = newScrollPosition
	'		'MapGrid.Invalidate()
	'	End Sub



#End Region

#Region "Map Events"

	Private Sub MapGrid_BeforePaint(sender As Object, e As PaintEventArgs) Handles MapGrid.MapBeforePaint
		MapGrid.HighlightPoints.Clear()
		For Each item As Item In Items.Values
			If item.ExpDate = Nothing OrElse String.IsNullOrWhiteSpace(item.ExpDate) Then Continue For
			If item.ExpDate < Date.Today.AddDays(7) Then
				MapGrid.HighlightPoints.Add(New Point(item.Column, item.Row))
			End If
		Next
	End Sub

	Private Sub MapGrid_MapPaint(sender As Object, e As PaintEventArgs) Handles MapGrid.MapPaint
		MapItemCount.Text = Items.Count
		StorageItemCount.Text = StoredItems.Count
		ExpiringItemCount.Text = 0

		For Each item As Item In Items.Values
			If item.ExpDate = Nothing OrElse String.IsNullOrWhiteSpace(item.ExpDate) Then Continue For
			If item.ExpDate < Date.Today.AddDays(7) Then
				ExpiringItemCount.Text = CInt(ExpiringItemCount.Text) + 1
			End If
		Next
		For Each item As Item In StoredItems.Values
			If item.ExpDate = Nothing OrElse String.IsNullOrWhiteSpace(item.ExpDate) Then Continue For
			If item.ExpDate < Date.Today.AddDays(7) Then
				ExpiringItemCount.Text = CInt(ExpiringItemCount.Text) + 1
			End If
		Next

	End Sub

	Private Sub StatusLabel_TextChanged(sender As Object, e As EventArgs) Handles StatusLabel.TextChanged
		'If StatusLabel.Text = "Please Wait..." Then
		'	Application.UseWaitCursor = True
		'ElseIf StatusLabel.Text = "Ready" Then
		'	Application.UseWaitCursor = False
		'End If
		Application.DoEvents()
	End Sub

	Private ClickPoint As Point = Nothing

	Private Sub MapGrid_CellMouseHover(sender As Object, e As MapControl.CellEventArgs) Handles MapGrid.CellMouseHover
		HoveredCellLabel.Text = $"X: {e.Column}     Y: {e.Row}"
		AreaHoverLabel.Text = $"A: {If(GridPoints.ContainsKey(New Point(e.Column, e.Row)), Areas(GridPoints(New Point(e.Column, e.Row)).AreaID).Name & If(Areas(GridPoints(New Point(e.Column, e.Row)).AreaID).CanHoldItems, " ▣", " ▢"), "None ▢")}"

		If GridPoints.ContainsKey(New Point(e.Column, e.Row)) Then
			Dim cItems As Dictionary(Of String, Item) = GridPoints(New Point(e.Column, e.Row)).Items
			If cItems.Count > 0 Then
				Dim cItemStr As String = String.Concat(Of String)(cItems.Select(Function(x) x.Value.ID & vbCrLf)).TrimEnd(vbCrLf)
				ToolTip1.SetToolTip(MapGrid, cItemStr)
			Else
				ToolTip1.SetToolTip(MapGrid, "")
			End If
		End If


		If UserSelectingNewArea2 Then 'temporarily set backcolor of cells while selecting new area
			MapGrid.ResetBackColors()
			If NewAreaPoint1.Y > e.Row Then
				For r = e.Row To NewAreaPoint1.Y
					If NewAreaPoint1.X > e.Column Then
						For c = e.Column To NewAreaPoint1.X
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					Else
						For c = NewAreaPoint1.X To e.Column
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					End If
				Next
			Else
				For r = NewAreaPoint1.Y To e.Row
					If NewAreaPoint1.X > e.Column Then
						For c = e.Column To NewAreaPoint1.X
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					Else
						For c = NewAreaPoint1.X To e.Column
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					End If
				Next
			End If
		End If

		If UserExtendingArea2 Then
			MapGrid.ResetBackColors()
			If UserExtendingPoint1.Y > e.Row Then
				For r = e.Row To UserExtendingPoint1.Y
					If UserExtendingPoint1.X > e.Column Then
						For c = e.Column To UserExtendingPoint1.X
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					Else
						For c = UserExtendingPoint1.X To e.Column
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					End If
				Next
			Else
				For r = UserExtendingPoint1.Y To e.Row
					If UserExtendingPoint1.X > e.Column Then
						For c = e.Column To UserExtendingPoint1.X
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					Else
						For c = UserExtendingPoint1.X To e.Column
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					End If
				Next
			End If
		End If

		If UserShrinkingArea2 Then
			MapGrid.ResetBackColors()
			If ShrinkAreaPoint1.Y > e.Row Then
				For r = e.Row To ShrinkAreaPoint1.Y
					If ShrinkAreaPoint1.X > e.Column Then
						For c = e.Column To ShrinkAreaPoint1.X
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					Else
						For c = ShrinkAreaPoint1.X To e.Column
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					End If
				Next
			Else
				For r = ShrinkAreaPoint1.Y To e.Row
					If ShrinkAreaPoint1.X > e.Column Then
						For c = e.Column To ShrinkAreaPoint1.X
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					Else
						For c = ShrinkAreaPoint1.X To e.Column
							MapGrid.CellBackColor(r, c) = Color.LightGray
						Next
					End If
				Next
			End If
		End If

	End Sub

	Private Sub MapGrid_CellDoubleClicked(sender As Object, e As MapControl.CellEventArgs) Handles MapGrid.CellDoubleClicked
		ClickPoint = New Point(e.Column, e.Row)

		If Not GridPoints.ContainsKey(ClickPoint) Then Exit Sub
		If Not Areas.ContainsKey(GridPoints(ClickPoint).AreaID) Then Exit Sub

		If Areas(GridPoints(ClickPoint).AreaID).CanHoldItems Then
			PlaceHereButton.PerformClick()
		End If
	End Sub

	Private RightClickArea As Area = Nothing
	Private Sub MapGrid_CellRightClicked(sender As Object, e As MapControl.CellEventArgs) Handles MapGrid.CellRightClicked
		RightClickArea = If(GridPoints.ContainsKey(New Point(e.Column, e.Row)), Areas(GridPoints(New Point(e.Column, e.Row)).AreaID), Nothing)

		SelectedCellLabel.Text = $"X: {e.Column}     Y: {e.Row}"
		SelectedAreaLabel.Text = $"A: {If(RightClickArea IsNot Nothing, RightClickArea.Name & If(RightClickArea.CanHoldItems, " ▣", " ▢"), "None ▢")}"

		ClickPoint = New Point(e.Column, e.Row)

		If Not GridPoints.ContainsKey(ClickPoint) Then Exit Sub
		Dim offset As Integer = If(GridPoints(ClickPoint).Items.Count > 0, 1, 1)
		MapContext.Show(AdjustPointForWindowLocation(MapGrid.GetSelectedCellScreenPosition, offset))

	End Sub
	Private Sub MapContext_Opening(sender As Object, e As CancelEventArgs) Handles MapContext.Opening
		If MapSetupButton.Checked OrElse RightClickArea Is Nothing OrElse Not RightClickArea.CanHoldItems Then
			e.Cancel = True
			Exit Sub
		End If

		Dim cItems As Dictionary(Of String, Item) = GridPoints(ClickPoint).Items

		If cItems.Count = 0 Then
			StoreItemButton.Visible = False
			RemoveItemButton.Visible = False
			IdItemsButton.Visible = False
		End If
		If cItems.Count > 1 Then
			IdItemsButton.Text = "Identify Items"
		End If

	End Sub
	Private Sub MapContext_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles MapContext.Closed
		IdItemsButton.Text = "Identify Item"
		IdItemsButton.Visible = True
		PlaceHereButton.Visible = True
		StoreItemButton.Visible = True
		RemoveItemButton.Visible = True
	End Sub

	Private Function AdjustPointForWindowLocation(point As Point?, offset As Integer) As Point?
		If point Is Nothing Then Return Nothing
		Return New Point(point.Value.X + Me.Location.X + MapGrid.CellSize, point.Value.Y + Me.Location.Y - (MapGrid.CellSize * offset) + MapContext.Height)
	End Function

	Private Sub Map_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
		If e.KeyCode = Keys.Menu Then
			MenuStrip1.Visible = Not MenuStrip1.Visible
		End If

		If e.KeyCode = Keys.Escape Then
			UserSelectingNewArea1 = False
			UserSelectingNewArea2 = False
			UserExtendingArea1 = False
			UserExtendingArea2 = False
			UserSelectingEditArea = False
			UserDeletingArea = False
			UserShrinkingArea1 = False
			UserShrinkingArea2 = False
			UserRetryPlaceItem = False
			MapGrid.ResetBackColors()
			StatusLabel.Text = "Ready"
			SelectedCellLabel.Text = "X: -1     Y: -1"
			SelectedAreaLabel.Text = "A: None ▢"
			LoadMap()
		End If
	End Sub
	Private Sub MapGrid_CellClicked(sender As Object, e As MapControl.CellEventArgs) Handles MapGrid.CellClicked
		SelectedCellLabel.Text = $"X: {e.Column}     Y: {e.Row}"
		SelectedAreaLabel.Text = $"A: {If(GridPoints.ContainsKey(New Point(e.Column, e.Row)), Areas(GridPoints(New Point(e.Column, e.Row)).AreaID).Name & If(Areas(GridPoints(New Point(e.Column, e.Row)).AreaID).CanHoldItems, " ▣", " ▢"), "None ▢")}"

		ClickPoint = New Point(e.Column, e.Row)

		If UserSelectingNewArea1 Then
			UserSelectingNewArea1 = False
			NewArea1(New Point(e.Column, e.Row))
			Exit Sub
		End If
		If UserSelectingNewArea2 Then
			UserSelectingNewArea2 = False
			NewArea2(New Point(e.Column, e.Row))
			Exit Sub
		End If

		If UserExtendingArea1 Then
			UserExtendingArea1 = False
			ExtendArea1(New Point(e.Column, e.Row))
			Exit Sub
		End If
		If UserExtendingArea2 Then
			UserExtendingArea2 = False
			ExtendArea2(New Point(e.Column, e.Row))
			Exit Sub
		End If

		If UserSelectingEditArea Then
			UserSelectingEditArea = False
			EditArea1(New Point(e.Column, e.Row))
			Exit Sub
		End If

		If UserDeletingArea Then
			DeleteArea(New Point(e.Column, e.Row))
			Exit Sub
		End If

		If UserShrinkingArea1 Then
			UserShrinkingArea1 = False
			ShrinkArea1(New Point(e.Column, e.Row))
			Exit Sub
		End If
		If UserShrinkingArea2 Then
			UserShrinkingArea2 = False
			ShrinkArea2(New Point(e.Column, e.Row))
			Exit Sub
		End If

		If UserRetryPlaceItem Then
			If Not MapPointHoldsItems(ClickPoint) Then
				Beep()
				MessageBox.Show("Selected location does not hold items")
				Exit Sub
			End If
			PlaceHere(ClickPoint)
			Exit Sub
		End If
	End Sub

#End Region

#Region "Map Setup"

	Private Sub MapSetupButton_Click(sender As Object, e As EventArgs) Handles MapSetupButton.CheckedChanged
		AreaToolStripMenuItem.Visible = MapSetupButton.Checked
		'CellsToolStripMenuItem.Visible = MapSetupButton.Checked
		MapGrid.ShowGridlines = MapSetupButton.Checked

		If MapSetupButton.Checked Then
			MapSetupButton.Font = New Font(MapSetupButton.Font, FontStyle.Bold)
			MapGrid.CellDefaultBackColor = SystemColors.Control

			If Not IO.File.Exists(Config.LastMapPath) Then
				If NewMapForm.CreateMap Then


					LoadMap()


				Else
					MapSetupButton.Checked = False
				End If
			End If
		Else
			MapSetupButton.Font = New Font(MapSetupButton.Font, FontStyle.Regular)
			MapGrid.CellDefaultBackColor = SystemColors.ControlDark
		End If
	End Sub

#End Region

#Region "New Area"

	Dim UserSelectingNewArea1 As Boolean = False
	Dim NewAreaPoint1 As Point
	Dim UserSelectingNewArea2 As Boolean = False
	Dim NewAreaPoint2 As Point

	Private Sub NewAreaButton_Click(sender As Object, e As EventArgs) Handles NewAreaButton.Click
		StatusLabel.Text = "Select first corner"
		UserSelectingNewArea1 = True
	End Sub

	Private Sub NewArea1(MapPosition As Point)
		NewAreaPoint1 = MapPosition
		StatusLabel.Text = "Select opposite corner"
		MapGrid.SaveBackColors()
		UserSelectingNewArea2 = True
	End Sub

	Private Sub NewArea2(MapPosition As Point)
		NewAreaPoint2 = MapPosition

		MapGrid.ResetBackColors()

		For r = NewAreaPoint1.Y To NewAreaPoint2.Y
			For c = NewAreaPoint1.X To NewAreaPoint2.X
				MapGrid.CellBackColor(r, c) = Color.LightBlue
			Next
		Next
		Application.DoEvents()

		Dim tArea As Area = NewAreaForm.NewArea()


		If tArea Is Nothing Then
			MapGrid.ResetBackColors()
			NewAreaPoint1 = Nothing
			NewAreaPoint2 = Nothing
			UserSelectingNewArea1 = False
			UserSelectingNewArea2 = False

			StatusLabel.Text = "Ready"
			Exit Sub
		End If

		StatusLabel.Text = "Please Wait..."
		Application.DoEvents()

		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		Dim cmd As New SQLiteCommand
		cmd.Connection = conn
		cmd.CommandText = "INSERT INTO Area (Name, Color, CanHoldItems) VALUES (@Name, @Color, @HoldsItems) RETURNING ID;"

		cmd.Parameters.AddWithValue("@Name", tArea.Name)
		cmd.Parameters.AddWithValue("@Color", tArea.Color.ToArgb)
		cmd.Parameters.AddWithValue("@HoldsItems", tArea.CanHoldItems)

		Dim id As Integer
		Try
			conn.Open()
			id = CInt(cmd.ExecuteScalar())
			conn.Close()
		Catch ex As Exception
			Beep()
			MessageBox.Show("Failed to add new area to database")
			Throw New Exception(ex.Message, ex)
		End Try

		tArea.ID = id
		'Areas = New Dictionary(Of Integer, Area)
		Areas.Add(id, tArea)

		cmd = New SQLiteCommand
		cmd.Connection = conn

		Dim i As Integer = 0
		Dim overlapOk As Boolean = Nothing
		Dim insertCmd As String = "INSERT INTO Layout (AreaID, Row, Column) VALUES"

		If NewAreaPoint1.Y > NewAreaPoint2.Y Then
			For r = NewAreaPoint2.Y To NewAreaPoint1.Y
				If NewAreaPoint1.X > NewAreaPoint2.X Then
					For c = NewAreaPoint2.X To NewAreaPoint1.X
						If GridPoints.ContainsKey(New Point(c, r)) Then
							If overlapOk = Nothing Then
								Dim dr As DialogResult = MessageBox.Show("Selected area overlaps an existing area. OK to overwrite area?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
								If dr = DialogResult.Yes Then
									overlapOk = True
								Else
									overlapOk = False
								End If
							End If
							If overlapOk Then
								cmd.CommandText &= $"DELETE FROM Layout WHERE ID = @ID{i};" & vbCrLf
								cmd.Parameters.AddWithValue($"@ID{i}", GridPoints(New Point(c, r)).ID)
								i += 1

								GridPoints.Remove(New Point(c, r))
								MapGrid.CellBackColor(r, c) = tArea.Color

								insertCmd &= $" (@AreaID{i}, @Row{i}, @Column{i}),"
								cmd.Parameters.AddWithValue($"@AreaID{i}", id)
								cmd.Parameters.AddWithValue($"@Row{i}", r)
								cmd.Parameters.AddWithValue($"@Column{i}", c)
								i += 1

								GridPoints.Add(New Point(c, r), New Cell With {.AreaID = id, .Row = r, .Column = c})
							End If
						Else
							MapGrid.CellBackColor(r, c) = tArea.Color

							insertCmd &= $" (@AreaID{i}, @Row{i}, @Column{i}),"
							cmd.Parameters.AddWithValue($"@AreaID{i}", id)
							cmd.Parameters.AddWithValue($"@Row{i}", r)
							cmd.Parameters.AddWithValue($"@Column{i}", c)
							i += 1

							GridPoints.Add(New Point(c, r), New Cell With {.AreaID = id, .Row = r, .Column = c})
						End If
					Next
				Else
					For c = NewAreaPoint1.X To NewAreaPoint2.X
						If GridPoints.ContainsKey(New Point(c, r)) Then
							If overlapOk = Nothing Then
								Dim dr As DialogResult = MessageBox.Show("Selected area overlaps an existing area. OK to overwrite area?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
								If dr = DialogResult.Yes Then
									overlapOk = True
								Else
									overlapOk = False
								End If
							End If
							If overlapOk Then
								cmd.CommandText &= $"DELETE FROM Layout WHERE ID = @ID{i};" & vbCrLf
								cmd.Parameters.AddWithValue($"@ID{i}", GridPoints(New Point(c, r)).ID)
								i += 1

								GridPoints.Remove(New Point(c, r))
								MapGrid.CellBackColor(r, c) = tArea.Color

								insertCmd &= $" (@AreaID{i}, @Row{i}, @Column{i}),"
								cmd.Parameters.AddWithValue($"@AreaID{i}", id)
								cmd.Parameters.AddWithValue($"@Row{i}", r)
								cmd.Parameters.AddWithValue($"@Column{i}", c)
								i += 1

								GridPoints.Add(New Point(c, r), New Cell With {.AreaID = id, .Row = r, .Column = c})
							End If
						Else
							MapGrid.CellBackColor(r, c) = tArea.Color

							insertCmd &= $" (@AreaID{i}, @Row{i}, @Column{i}),"
							cmd.Parameters.AddWithValue($"@AreaID{i}", id)
							cmd.Parameters.AddWithValue($"@Row{i}", r)
							cmd.Parameters.AddWithValue($"@Column{i}", c)
							i += 1

							GridPoints.Add(New Point(c, r), New Cell With {.AreaID = id, .Row = r, .Column = c})
						End If
					Next
				End If
			Next
		Else
			For r = NewAreaPoint1.Y To NewAreaPoint2.Y
				If NewAreaPoint1.X > NewAreaPoint2.X Then
					For c = NewAreaPoint2.X To NewAreaPoint1.X
						If GridPoints.ContainsKey(New Point(c, r)) Then
							If overlapOk = Nothing Then
								Dim dr As DialogResult = MessageBox.Show("Selected area overlaps an existing area. OK to overwrite area?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
								If dr = DialogResult.Yes Then
									overlapOk = True
								Else
									overlapOk = False
								End If
							End If
							If overlapOk Then
								cmd.CommandText &= $"DELETE FROM Layout WHERE ID = @ID{i};" & vbCrLf
								cmd.Parameters.AddWithValue($"@ID{i}", GridPoints(New Point(c, r)).ID)
								i += 1

								GridPoints.Remove(New Point(c, r))
								MapGrid.CellBackColor(r, c) = tArea.Color

								insertCmd &= $" (@AreaID{i}, @Row{i}, @Column{i}),"
								cmd.Parameters.AddWithValue($"@AreaID{i}", id)
								cmd.Parameters.AddWithValue($"@Row{i}", r)
								cmd.Parameters.AddWithValue($"@Column{i}", c)
								i += 1

								GridPoints.Add(New Point(c, r), New Cell With {.AreaID = id, .Row = r, .Column = c})
							End If
						Else
							MapGrid.CellBackColor(r, c) = tArea.Color

							insertCmd &= $" (@AreaID{i}, @Row{i}, @Column{i}),"
							cmd.Parameters.AddWithValue($"@AreaID{i}", id)
							cmd.Parameters.AddWithValue($"@Row{i}", r)
							cmd.Parameters.AddWithValue($"@Column{i}", c)
							i += 1

							GridPoints.Add(New Point(c, r), New Cell With {.AreaID = id, .Row = r, .Column = c})
						End If
					Next
				Else
					For c = NewAreaPoint1.X To NewAreaPoint2.X
						If GridPoints.ContainsKey(New Point(c, r)) Then
							If overlapOk = Nothing Then
								Dim dr As DialogResult = MessageBox.Show("Selected area overlaps an existing area. OK to overwrite area?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
								If dr = DialogResult.Yes Then
									overlapOk = True
								Else
									overlapOk = False
								End If
							End If
							If overlapOk Then
								cmd.CommandText &= $"DELETE FROM Layout WHERE ID = @ID{i};" & vbCrLf
								cmd.Parameters.AddWithValue($"@ID{i}", GridPoints(New Point(c, r)).ID)
								i += 1

								GridPoints.Remove(New Point(c, r))
								MapGrid.CellBackColor(r, c) = tArea.Color

								insertCmd &= $" (@AreaID{i}, @Row{i}, @Column{i}),"
								cmd.Parameters.AddWithValue($"@AreaID{i}", id)
								cmd.Parameters.AddWithValue($"@Row{i}", r)
								cmd.Parameters.AddWithValue($"@Column{i}", c)
								i += 1

								GridPoints.Add(New Point(c, r), New Cell With {.AreaID = id, .Row = r, .Column = c})
							End If
						Else
							MapGrid.CellBackColor(r, c) = tArea.Color

							insertCmd &= $" (@AreaID{i}, @Row{i}, @Column{i}),"
							cmd.Parameters.AddWithValue($"@AreaID{i}", id)
							cmd.Parameters.AddWithValue($"@Row{i}", r)
							cmd.Parameters.AddWithValue($"@Column{i}", c)
							i += 1

							GridPoints.Add(New Point(c, r), New Cell With {.AreaID = id, .Row = r, .Column = c})
						End If
					Next
				End If
			Next
		End If

		If insertCmd.Length > 50 Then cmd.CommandText &= insertCmd.TrimEnd(","c) & ";"

		Try
			conn.Open()
			cmd.ExecuteNonQuery()
			conn.Close()
		Catch ex As Exception
			Beep()
			MessageBox.Show("Failed to add area.")
			Throw New Exception(ex.Message, ex)
		End Try

		NewAreaPoint1 = Nothing
		NewAreaPoint2 = Nothing
		UserSelectingNewArea1 = False
		UserSelectingNewArea2 = False

		StatusLabel.Text = "Ready"
		'My.Computer.Audio.PlaySystemSound(SystemSounds.Hand)



	End Sub

	Private Function NewArea3(AreaID As Integer, Row As Integer, Column As Integer) As Integer
		Dim cmd As New SQLiteCommand
		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		cmd.Connection = conn
		cmd.CommandText = "INSERT INTO Layout (AreaID, Row, Column) VALUES (@AreaID, @Row, @Column) RETURNING ID;"
		cmd.Parameters.AddWithValue("@AreaID", AreaID)
		cmd.Parameters.AddWithValue("@Row", Row)
		cmd.Parameters.AddWithValue("@Column", Column)

		Dim id As Integer
		Try
			conn.Open()
			id = CInt(cmd.ExecuteScalar())
			conn.Close()
		Catch ex As Exception
			Beep()
			MessageBox.Show("Failed to add new area to database")
			Throw New Exception(ex.Message, ex)
		End Try

		Return id
	End Function
	Private Sub NewArea4(LayoutID As Integer, c As Integer, r As Integer)
		'remove existing layout id from Layout and GridPoints
		Dim cmd As New SQLiteCommand
		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		cmd.Connection = conn
		cmd.CommandText = "DELETE FROM Layout WHERE ID = @ID;"
		cmd.Parameters.AddWithValue("@ID", LayoutID)

		Try
			conn.Open()
			cmd.ExecuteNonQuery()
			conn.Close()
		Catch ex As Exception
			Beep()
			MessageBox.Show("Failed to remove existing cell from database")
			Throw New Exception(ex.Message, ex)
		End Try

		GridPoints.Remove(New Point(c, r))
	End Sub

#End Region

#Region "Extend Area"

	Dim UserExtendingArea1 As Boolean = False
	Dim UserExtendingArea2 As Boolean = False
	Dim UserExtendingAreaID As Integer
	Dim UserExtendingPoint1 As Point
	Dim UserExtendingPoint2 As Point


	Private Sub ExtendAreaButton_Click(sender As Object, e As EventArgs) Handles ExtendAreaButton.Click
		StatusLabel.Text = "Select first corner"
		UserExtendingArea1 = True
	End Sub

	Private Sub ExtendArea1(MapPosition As Point)
		'ensure cell is in an area or adjacent to one
		If Not GridPoints.ContainsKey(MapPosition) Then

			Beep()
			MessageBox.Show("Selected cell is not in an existing area")
			UserExtendingArea1 = True
			Exit Sub
		End If

		UserExtendingPoint1 = MapPosition
		UserExtendingAreaID = GridPoints(MapPosition).AreaID
		StatusLabel.Text = "Select opposite corner"
		MapGrid.SaveBackColors()
		UserExtendingArea2 = True
	End Sub

	Private Sub ExtendArea2(MapPosition As Point)
		'check if the new area overlaps an existing one. if so, ask for confirmation... yes, no, retry
		'if yes, extend the area and overwrite the existing area where it overlaps
		'if no, cancel the operation
		'if retry, go back to selecting the second corner

		If GridPoints.ContainsKey(MapPosition) Then
			Beep()
			Dim dr As DialogResult = MessageBox.Show("Selected area overlaps an existing area.", "Continue?", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning)
			If dr = DialogResult.Abort Then
				UserExtendingArea1 = False
				UserExtendingArea2 = False
				UserExtendingPoint1 = Nothing
				UserExtendingPoint2 = Nothing
				UserExtendingAreaID = 0
				StatusLabel.Text = "Ready"
				MapGrid.ResetBackColors()
				Exit Sub
			ElseIf dr = DialogResult.Retry Then
				UserExtendingArea1 = False
				UserExtendingArea2 = True
				StatusLabel.Text = "Select opposite corner"
				Exit Sub
			Else 'Ignore
				'continue
			End If
		End If

		MapGrid.ResetBackColors()
		StatusLabel.Text = "Please Wait..."
		Application.DoEvents()


		Dim tArea As Area = Areas(UserExtendingAreaID)

		If UserExtendingPoint1.Y > MapPosition.Y Then
			For r = MapPosition.Y To UserExtendingPoint1.Y
				If UserExtendingPoint1.X > MapPosition.X Then
					For c = MapPosition.X To UserExtendingPoint1.X
						MapGrid.CellBackColor(r, c) = tArea.Color
						ExtendArea3(UserExtendingAreaID, r, c)
					Next
				Else
					For c = UserExtendingPoint1.X To MapPosition.X
						MapGrid.CellBackColor(r, c) = tArea.Color
						ExtendArea3(UserExtendingAreaID, r, c)
					Next
				End If
			Next
		Else
			For r = UserExtendingPoint1.Y To MapPosition.Y
				If UserExtendingPoint1.X > MapPosition.X Then
					For c = MapPosition.X To UserExtendingPoint1.X
						MapGrid.CellBackColor(r, c) = tArea.Color
						ExtendArea3(UserExtendingAreaID, r, c)
					Next
				Else
					For c = UserExtendingPoint1.X To MapPosition.X
						MapGrid.CellBackColor(r, c) = tArea.Color
						ExtendArea3(UserExtendingAreaID, r, c)
					Next
				End If
			Next
		End If

		UserExtendingArea1 = False
		UserExtendingArea2 = False
		UserExtendingPoint1 = Nothing
		UserExtendingPoint2 = Nothing
		UserExtendingAreaID = 0
		StatusLabel.Text = "Ready"
	End Sub

	Private Sub ExtendArea3(AreaID As Integer, Row As Integer, Column As Integer)
		'if point overlaps existing area, update the layout instead of inserting
		Dim cmd As New SQLiteCommand
		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		cmd.Connection = conn

		If GridPoints.ContainsKey(New Point(Column, Row)) Then
			cmd.CommandText = "UPDATE Layout SET AreaID = @AreaID WHERE ID = @lID;"
			cmd.Parameters.AddWithValue("@AreaID", AreaID)
			cmd.Parameters.AddWithValue("@lID", GridPoints(New Point(Column, Row)).ID)

			Dim id As Integer
			Try
				conn.Open()
				id = cmd.ExecuteNonQuery
				conn.Close()
			Catch ex As Exception
				Beep()
				MessageBox.Show("Failed to add new area to database")
				Throw New Exception(ex.Message, ex)
			End Try

			If id > 0 Then GridPoints(New Point(Column, Row)).AreaID = AreaID
		Else
			cmd.CommandText = "INSERT INTO Layout (AreaID, Row, Column) VALUES (@AreaID, @Row, @Column) RETURNING ID;"
			cmd.Parameters.AddWithValue("@AreaID", AreaID)
			cmd.Parameters.AddWithValue("@Row", Row)
			cmd.Parameters.AddWithValue("@Column", Column)

			Dim id As Integer
			Try
				conn.Open()
				id = CInt(cmd.ExecuteScalar())
				conn.Close()
			Catch ex As Exception
				Beep()
				MessageBox.Show("Failed to add new area to database")
				Throw New Exception(ex.Message, ex)
			End Try

			GridPoints.Add(New Point(Column, Row), New Cell With {.AreaID = AreaID, .Row = Row, .Column = Column})
		End If
	End Sub

#End Region

#Region "Delete Area"

	Private UserDeletingArea As Boolean = False

	Private Sub DeleteAreaButton_Click(sender As Object, e As EventArgs) Handles DeleteAreaButton.Click
		StatusLabel.Text = "Select cell within area to delete"
		UserDeletingArea = True
	End Sub

	Private Sub DeleteArea(MapPosition As Point)
		If Not GridPoints.ContainsKey(MapPosition) Then Exit Sub

		Dim tArea As Area = Areas(GridPoints(MapPosition).AreaID)

		Dim dr As DialogResult = MessageBox.Show($"Delete Area ""{tArea.Name}""?", "Delete Area?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

		UserDeletingArea = False
		StatusLabel.Text = "Please Wait..."
		Application.DoEvents()

		If dr = DialogResult.Yes Then
			Dim cmd As New SQLiteCommand
			Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
			cmd.Connection = conn
			cmd.CommandText = "DELETE FROM Area WHERE ID = @aID1; DELETE FROM Layout WHERE AreaID = @aID2;"
			cmd.Parameters.AddWithValue("@aID1", tArea.ID)
			cmd.Parameters.AddWithValue("@aID2", tArea.ID)

			Try
				conn.Open()
				cmd.ExecuteNonQuery()
				conn.Close()
			Catch ex As Exception
				Beep()
				MessageBox.Show("Failed to delete area from database")
				Throw New Exception(ex.Message, ex)
			End Try

			For i = GridPoints.Values.Count - 1 To 0 Step -1
				Dim cell As Cell = GridPoints.Values(i)
				If cell.AreaID = tArea.ID Then
					MapGrid.CellBackColor(cell.Row, cell.Column) = MapGrid.CellDefaultBackColor
					GridPoints.Remove(New Point(cell.Column, cell.Row))
				End If
			Next
			Areas.Remove(tArea.ID)
		End If

		StatusLabel.Text = "Ready"

	End Sub

#End Region

#Region "Shrink Area"

	Private UserShrinkingArea1 As Boolean = False
	Private UserShrinkingArea2 As Boolean = False
	Private ShrinkAreaPoint1 As Point
	Private ShrinkAreaPoint2 As Point

	Private Sub ShrinkAreaButton_Click(sender As Object, e As EventArgs) Handles ShrinkAreaButton.Click
		StatusLabel.Text = "Select first corner"
		UserShrinkingArea1 = True
	End Sub

	Private Sub ShrinkArea1(MapPosition As Point)
		'ensure cell is in an area
		If Not GridPoints.ContainsKey(MapPosition) Then
			Beep()
			MessageBox.Show("Selected cell is not in an existing area")
			UserShrinkingArea1 = True
			Exit Sub
		End If

		ShrinkAreaPoint1 = MapPosition
		StatusLabel.Text = "Select opposite corner"
		MapGrid.SaveBackColors()
		UserShrinkingArea2 = True
	End Sub

	Private Sub ShrinkArea2(MapPosition As Point)
		If Not GridPoints.ContainsKey(MapPosition) Then
			Beep()
			MessageBox.Show("Selected cell is not in an existing area")
			UserShrinkingArea2 = True
			Exit Sub
		End If
		'ensure cell is within the same area as the first corner
		If Not GridPoints(MapPosition).AreaID = GridPoints(ShrinkAreaPoint1).AreaID Then
			Beep()
			MessageBox.Show("Selected cell is not in the same area as the first corner")
			UserShrinkingArea2 = True
			Exit Sub
		End If

		StatusLabel.Text = "Please Wait..."
		Application.DoEvents()

		ShrinkAreaPoint2 = MapPosition

		If ShrinkAreaPoint1.Y > ShrinkAreaPoint2.Y Then
			For r = ShrinkAreaPoint2.Y To ShrinkAreaPoint1.Y
				If ShrinkAreaPoint1.X > ShrinkAreaPoint2.X Then
					For c = ShrinkAreaPoint2.X To ShrinkAreaPoint1.X
						ShrinkArea3(r, c)
					Next
				Else
					For c = ShrinkAreaPoint1.X To ShrinkAreaPoint2.X
						ShrinkArea3(r, c)
					Next
				End If
			Next
		Else
			For r = ShrinkAreaPoint1.Y To ShrinkAreaPoint2.Y
				If ShrinkAreaPoint1.X > ShrinkAreaPoint2.X Then
					For c = ShrinkAreaPoint2.X To ShrinkAreaPoint1.X
						ShrinkArea3(r, c)
					Next
				Else
					For c = ShrinkAreaPoint1.X To ShrinkAreaPoint2.X
						ShrinkArea3(r, c)
					Next
				End If
			Next
		End If

		ShrinkAreaPoint1 = Nothing
		ShrinkAreaPoint2 = Nothing
		UserShrinkingArea1 = False
		UserShrinkingArea2 = False

		StatusLabel.Text = "Ready"
	End Sub

	Private Sub ShrinkArea3(Row As Integer, Column As Integer)
		Dim cmd As New SQLiteCommand
		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		cmd.Connection = conn
		cmd.CommandText = "DELETE FROM Layout WHERE ID = @lID;"
		cmd.Parameters.AddWithValue("@lID", GridPoints(New Point(Column, Row)).ID)
		cmd.Parameters.AddWithValue("@Row", Row)
		cmd.Parameters.AddWithValue("@Column", Column)

		Try
			conn.Open()
			cmd.ExecuteNonQuery()
			conn.Close()
		Catch ex As Exception
			Beep()
			MessageBox.Show("Failed to remove cell from area")
			Throw New Exception(ex.Message, ex)
		End Try

		GridPoints.Remove(New Point(Column, Row))
		MapGrid.CellBackColor(Row, Column) = MapGrid.CellDefaultBackColor
	End Sub

#End Region

#Region "Edit Area"

	Private UserSelectingEditArea As Boolean = False

	Private Sub EditAreaButton_Click(sender As Object, e As EventArgs) Handles EditAreaButton.Click
		StatusLabel.Text = "Select cell within area to edit"
		UserSelectingEditArea = True

	End Sub

	Private Sub EditArea1(MapPosition As Point)
		'ensure cell is in an area
		If Not GridPoints.ContainsKey(MapPosition) Then
			Beep()
			MessageBox.Show("Selected cell is not in an existing area")
			UserSelectingEditArea = True
			Exit Sub
		End If


		Dim tArea As Area = NewAreaForm.EditArea(Areas(GridPoints(MapPosition).AreaID))

		If tArea Is Nothing Then
			UserSelectingEditArea = False
			StatusLabel.Text = "Ready"
			Exit Sub
		End If

		StatusLabel.Text = "Please Wait..."
		Application.DoEvents()

		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		Dim cmd As New SQLiteCommand
		cmd.Connection = conn
		cmd.CommandText = "UPDATE Area SET Name = @Name, Color = @Color, CanHoldItems = @CanHoldItems WHERE ID = @ID;"
		cmd.Parameters.AddWithValue("@Name", tArea.Name)
		cmd.Parameters.AddWithValue("@Color", tArea.Color.ToArgb)
		cmd.Parameters.AddWithValue("@CanHoldItems", tArea.CanHoldItems)
		cmd.Parameters.AddWithValue("@ID", tArea.ID)

		Try
			conn.Open()
			Dim ru As Integer = cmd.ExecuteNonQuery()
			conn.Close()


		Catch ex As Exception
			Beep()
			MessageBox.Show("Failed to update area in database")
			Throw New Exception(ex.Message, ex)
		End Try

		If Not Areas(tArea.ID).Color = tArea.Color Then
			cmd = New SQLiteCommand
			cmd.Connection = conn
			cmd.CommandText = "SELECT Row, Column FROM Layout WHERE AreaID = @aID;"
			cmd.Parameters.AddWithValue("@aID", tArea.ID)

			Dim cTable As New DataTable

			Try
				conn.Open()
				cTable.Load(cmd.ExecuteReader())
				conn.Close()
			Catch ex As Exception
				Beep()
				MessageBox.Show("Failed to load cells for area")
				Throw New Exception(ex.Message, ex)
			End Try

			For Each cell As DataRow In cTable.Rows
				MapGrid.CellBackColor(cell.Item("Row"), cell.Item("Column")) = tArea.Color
			Next

		End If

		Areas(tArea.ID) = tArea
		StatusLabel.Text = "Ready"

	End Sub

#End Region

#Region "Merge Cells"
	Private Sub MergeCellsButton_Click(sender As Object, e As EventArgs) Handles MergeCellsButton.Click

	End Sub

	Private Sub UnmergeCellButton_Click(sender As Object, e As EventArgs) Handles UnmergeCellsButton.Click

	End Sub

#End Region 'not implemented

#Region "Place Item"

	Dim UserRetryPlaceItem As Boolean = False
	Dim rItem As Item = Nothing

	Private Sub PlaceHereButton_Click(sender As Object, e As EventArgs) Handles PlaceHereButton.Click
		PlaceHere(ClickPoint)
	End Sub

	Private Sub PlaceHere(MapLocation As Point)
		Dim tDict As New Dictionary(Of String, Item)
		For Each item As Item In Items.Values
			tDict.Add(item.ID, item)
		Next
		For Each item As Item In StoredItems.Values
			tDict.Add(item.ID, item)
		Next
		Dim tObj As (Item, DialogResult) = PlaceItemForm.PlaceItem(MapLocation, tDict, rItem)
		Dim tItem As Item = tObj.Item1
		Dim tDr As DialogResult = tObj.Item2

		If tDr = DialogResult.Cancel Then Exit Sub
		If tDr = DialogResult.Retry Then
			StatusLabel.Text = "Select new location"
			UserRetryPlaceItem = True
			rItem = tItem
			Exit Sub
		End If

		UserRetryPlaceItem = False
		rItem = Nothing

		StatusLabel.Text = "Placing Item..."
		Application.DoEvents()

		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		Dim cmd As New SQLiteCommand
		cmd.Connection = conn

		If Items.ContainsKey(tItem.ID) Then
			cmd.CommandText = "UPDATE Item SET Name = @Name, Row = @Row, Column = @Column, ExpDate = @ExpDate, User = @User, Notes = @Notes WHERE ID = @ID;"
			cmd.Parameters.AddWithValue("@Name", tItem.Name)
			cmd.Parameters.AddWithValue("@Row", tItem.Row)
			cmd.Parameters.AddWithValue("@Column", tItem.Column)
			cmd.Parameters.AddWithValue("@ExpDate", tItem.ExpDate)
			cmd.Parameters.AddWithValue("@User", tItem.User)
			cmd.Parameters.AddWithValue("@Notes", tItem.Notes)
			cmd.Parameters.AddWithValue("@ID", tItem.ID)

			Try
				conn.Open()
				cmd.ExecuteNonQuery()
				conn.Close()
			Catch ex As Exception
				Beep()
				MessageBox.Show("Failed to add item to database")
				Throw New Exception(ex.Message, ex)
			End Try

			Dim oItem As Item = Items(tItem.ID)

			Dim oldCellVal As String = MapGrid.CellValue(oItem.Row, oItem.Column)
			If oldCellVal = "1" Then
				MapGrid.CellValue(oItem.Row, oItem.Column) = ""
			Else
				MapGrid.CellValue(oItem.Row, oItem.Column) = If((MapGrid.CellValue(oItem.Row, oItem.Column) - 1) = 0, "", MapGrid.CellValue(oItem.Row, oItem.Column) - 1)
			End If

			GridPoints(New Point(oItem.Column, oItem.Row)).Items.Remove(oItem.ID)

			Items(tItem.ID).Name = tItem.Name
			Items(tItem.ID).Row = tItem.Row
			Items(tItem.ID).Column = tItem.Column
			Items(tItem.ID).ExpDate = tItem.ExpDate
			Items(tItem.ID).User = tItem.User
			Items(tItem.ID).Notes = tItem.Notes
		Else
			If StoredItems.ContainsKey(tItem.ID) Then
				cmd.CommandText = "DELETE FROM Storage WHERE ID = @ID1; INSERT INTO Item (ID, Name, Row, Column, ExpDate, User, Notes) VALUES (@ID2, @Name, @Row, @Column, @ExpDate, @User, @Notes);"
				cmd.Parameters.AddWithValue("@ID1", tItem.ID)
				cmd.Parameters.AddWithValue("@ID2", tItem.ID)
				cmd.Parameters.AddWithValue("@Name", tItem.Name)
				cmd.Parameters.AddWithValue("@Row", tItem.Row)
				cmd.Parameters.AddWithValue("@Column", tItem.Column)
				cmd.Parameters.AddWithValue("@ExpDate", tItem.ExpDate)
				cmd.Parameters.AddWithValue("@User", tItem.User)
				cmd.Parameters.AddWithValue("@Notes", tItem.Notes)

				Try
					conn.Open()
					cmd.ExecuteNonQuery()
					conn.Close()
				Catch ex As Exception
					Beep()
					MessageBox.Show("Failed to add item to database")
					Throw New Exception(ex.Message, ex)
				End Try

				StoredItems.Remove(tItem.ID)
				Items.Add(tItem.ID, tItem)

			Else
				cmd.CommandText = "INSERT INTO Item (ID, Name, Row, Column, ExpDate, User, Notes) VALUES (@ID, @Name, @Row, @Column, @ExpDate, @User, @Notes);"
				cmd.Parameters.AddWithValue("@ID", tItem.ID)
				cmd.Parameters.AddWithValue("@Name", tItem.Name)
				cmd.Parameters.AddWithValue("@Row", tItem.Row)
				cmd.Parameters.AddWithValue("@Column", tItem.Column)
				cmd.Parameters.AddWithValue("@ExpDate", tItem.ExpDate)
				cmd.Parameters.AddWithValue("@User", tItem.User)
				cmd.Parameters.AddWithValue("@Notes", tItem.Notes)

				Try
					conn.Open()
					cmd.ExecuteNonQuery()
					conn.Close()
				Catch ex As Exception
					Beep()
					MessageBox.Show("Failed to add item to database")
					Throw New Exception(ex.Message, ex)
				End Try

				Items.Add(tItem.ID, tItem)
			End If
		End If

		GridPoints(New Point(tItem.Column, tItem.Row)).Items.Add(tItem.ID, tItem)

		MapGrid.CellValue(tItem.Row, tItem.Column) = If(MapGrid.CellValue(tItem.Row, tItem.Column) = "", 0, CInt(MapGrid.CellValue(tItem.Row, tItem.Column))) + 1

		StatusLabel.Text = "Ready"

	End Sub

#End Region

#Region "Identify Items"
	Private Sub IdItemsButton_Click(sender As Object, e As EventArgs) Handles IdItemsButton.Click
		Dim cell As Cell = GridPoints(ClickPoint)
		IdentifyItemsForm.IdentifyItemsInCell(cell)

	End Sub

#End Region

#Region "Store Items"
	Private Sub StoreItemButton_Click(sender As Object, e As EventArgs) Handles StoreItemButton.Click
		Dim sItems As List(Of Item) = PickItemForm.PickItems(GridPoints(ClickPoint))
		StoreItems(sItems)

	End Sub

	Private Sub StoreItems(sItems As List(Of Item))
		If sItems Is Nothing OrElse sItems.Count = 0 Then Exit Sub

		StatusLabel.Text = "Please Wait..."
		Application.DoEvents()

		For i = 0 To sItems.Count - 1
			Dim cmd As New SQLiteCommand
			Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
			cmd.Connection = conn
			cmd.CommandText = "DELETE FROM Item WHERE ID = @ItemID; INSERT INTO Storage (ID, Name, ExpDate, User, Notes) VALUES (@ItemID2, @Name, @ExpDate, @User, @Notes);"
			cmd.Parameters.AddWithValue("@ItemID", sItems(i).ID)
			cmd.Parameters.AddWithValue("@ItemID2", sItems(i).ID)
			cmd.Parameters.AddWithValue("@Name", sItems(i).Name)
			cmd.Parameters.AddWithValue("@ExpDate", sItems(i).ExpDate)
			cmd.Parameters.AddWithValue("@User", sItems(i).User)
			cmd.Parameters.AddWithValue("@Notes", sItems(i).Notes)

			Try
				conn.Open()
				cmd.ExecuteNonQuery()
				conn.Close()
			Catch ex As Exception
				Beep()
				MessageBox.Show("Failed to store item")
				Throw New Exception(ex.Message, ex)
			End Try

			Items.Remove(sItems(i).ID)
			GridPoints(ClickPoint).Items.Remove(sItems(i).ID)
			StoredItems.Add(sItems(i).ID, sItems(i))

			Dim oldCellVal As String = MapGrid.CellValue(sItems(i).Row, sItems(i).Column)
			If oldCellVal = "1" Then
				MapGrid.CellValue(sItems(i).Row, sItems(i).Column) = ""
			Else
				MapGrid.CellValue(sItems(i).Row, sItems(i).Column) = If((MapGrid.CellValue(sItems(i).Row, sItems(i).Column) - 1) = 0, "", MapGrid.CellValue(sItems(i).Row, sItems(i).Column) - 1)
			End If
		Next

		StatusLabel.Text = "Ready"
	End Sub

#End Region

#Region "Remove Items"
	Private Sub RemoveItemButton_Click(sender As Object, e As EventArgs) Handles RemoveItemButton.Click
		Dim sItems As List(Of Item) = PickItemForm.PickItems(GridPoints(ClickPoint))
		RemoveItems(sItems)
	End Sub

	Private Sub RemoveItems(rItems As List(Of Item))
		If rItems Is Nothing OrElse rItems.Count = 0 Then Exit Sub

		StatusLabel.Text = "Please Wait..."
		Application.DoEvents()

		For i = 0 To rItems.Count - 1
			Dim cmd As New SQLiteCommand
			Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
			cmd.Connection = conn
			cmd.CommandText = "DELETE FROM Item WHERE ID = @ItemID;"
			cmd.Parameters.AddWithValue("@ItemID", rItems(i).ID)

			Try
				conn.Open()
				cmd.ExecuteNonQuery()
				conn.Close()
			Catch ex As Exception
				Beep()
				MessageBox.Show("Failed to remove item")
				Throw New Exception(ex.Message, ex)
			End Try

			Items.Remove(rItems(i).ID)
			GridPoints(ClickPoint).Items.Remove(rItems(i).ID)

			Dim oldCellVal As String = MapGrid.CellValue(rItems(i).Row, rItems(i).Column)
			If oldCellVal = "1" Then
				MapGrid.CellValue(rItems(i).Row, rItems(i).Column) = ""
			Else
				MapGrid.CellValue(rItems(i).Row, rItems(i).Column) = If((MapGrid.CellValue(rItems(i).Row, rItems(i).Column) - 1) = 0, "", MapGrid.CellValue(rItems(i).Row, rItems(i).Column) - 1)
			End If

		Next

		StatusLabel.Text = "Ready"
	End Sub

	Private Sub RemoveStoredItem(ID As String)
		Dim cmd As New SQLiteCommand
		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		cmd.Connection = conn
		cmd.CommandText = "DELETE FROM Storage WHERE ID = @ItemID;"
		cmd.Parameters.AddWithValue("@ItemID", ID)

		Try
			conn.Open()
			cmd.ExecuteNonQuery()
			conn.Close()
		Catch ex As Exception
			Beep()
			MessageBox.Show("Failed to remove item")
			Throw New Exception(ex.Message, ex)
		End Try

		StoredItems.Remove(ID)
	End Sub

#End Region

#Region "File Menu"
	Private Sub NewMapButton_Click(sender As Object, e As EventArgs) Handles NewMapButton.Click
		Dim sfd As New SaveFileDialog
		sfd.Filter = "Equipment Map|*.eMap"
		sfd.Title = "Specify File Location"
		sfd.InitialDirectory = Config.LastMapPath
		sfd.FileName = "New Map"
		sfd.DefaultExt = ".eMap"
		sfd.AddExtension = True

		If sfd.ShowDialog = DialogResult.OK Then
			Config.LastMapPath = sfd.FileName
			LoadMap()
			MapSetupButton.Checked = True
		End If
	End Sub

	Private Sub OpenMapButton_Click(sender As Object, e As EventArgs) Handles OpenMapButton.Click
		Dim ofd As New OpenFileDialog
		ofd.Filter = "Equipment Map|*.eMap"
		ofd.Title = "Select Map File"
		ofd.InitialDirectory = Config.LastMapPath

		If ofd.ShowDialog = DialogResult.OK Then
			Config.LastMapPath = ofd.FileName
			LoadMap()
		End If
	End Sub

	Private Sub SaveAsButton_Click(sender As Object, e As EventArgs) Handles SaveAsButton.Click
		Dim sfd As New SaveFileDialog
		sfd.Filter = "Equipment Map|*.eMap"
		sfd.Title = "Save Map As..."
		sfd.InitialDirectory = Config.LastMapPath
		sfd.FileName = $"{mapName} - Copy"
		sfd.DefaultExt = ".eMap"
		sfd.AddExtension = True

		If sfd.ShowDialog = DialogResult.OK Then
			IO.File.Copy(Config.LastMapPath, sfd.FileName, True)
			Config.LastMapPath = sfd.FileName
		End If
	End Sub

	Private Sub FindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindToolStripMenuItem.Click
		FindItemForm.Show()
	End Sub

#End Region

#Region "Grid Events"
	Private Sub ExpiringItems_GridLoad() Handles ExpiringItemsPage.Enter
		Dim cmd As New SQLiteCommand
		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		cmd.Connection = conn
		cmd.CommandText = "SELECT * FROM AllItems WHERE ExpDate <= date('now', '+7 days');"

		Dim eTable As New DataTable

		Try
			conn.Open()
			eTable.Load(cmd.ExecuteReader())
			conn.Close()
		Catch ex As Exception
			Beep()
			MessageBox.Show("Failed to load Expiring Items grid")
			'Throw New Exception(ex.Message, ex)
		End Try

		DGV_ExpiringItems.DataSource = eTable
	End Sub

	Private Sub AllItems_GridLoad() Handles AllItemsPage.Enter
		Dim cmd As New SQLiteCommand
		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		cmd.Connection = conn
		cmd.CommandText = "SELECT * FROM AllItems;"

		Dim eTable As New DataTable

		Try
			conn.Open()
			eTable.Load(cmd.ExecuteReader())
			conn.Close()
		Catch ex As Exception
			Beep()
			MessageBox.Show("Failed to load All Items grid")
			'Throw New Exception(ex.Message, ex)
		End Try

		DGV_AllItems.DataSource = eTable
	End Sub

	Private Sub MapItems_GridLoad() Handles MapItemsPage.Enter
		Dim cmd As New SQLiteCommand
		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		cmd.Connection = conn
		cmd.CommandText = "SELECT * FROM Item;"

		Dim eTable As New DataTable

		Try
			conn.Open()
			eTable.Load(cmd.ExecuteReader())
			conn.Close()
		Catch ex As Exception
			Beep()
			MessageBox.Show("Failed to load Map Items grid")
			'Throw New Exception(ex.Message, ex)
		End Try

		DGV_MapItems.DataSource = eTable
	End Sub

	Private Sub StoredItems_GridLoad() Handles StoredItemsPage.Enter
		Dim cmd As New SQLiteCommand
		Dim conn As New SQLiteConnection("Data Source=" & Config.LastMapPath & ";Version=3;", True)
		cmd.Connection = conn
		cmd.CommandText = "SELECT * FROM Storage;"

		Dim eTable As New DataTable

		Try
			conn.Open()
			eTable.Load(cmd.ExecuteReader())
			conn.Close()
		Catch ex As Exception
			Beep()
			MessageBox.Show("Failed to load Stored Items grid")
			'Throw New Exception(ex.Message, ex)
		End Try

		DGV_StoredItems.DataSource = eTable
	End Sub

	Private Sub ReloadVisibleGrid()
		Select Case TabControl1.SelectedTab.Name
			Case "ExpiringItemsPage"
				ExpiringItems_GridLoad()
			Case "AllItemsPage"
				AllItems_GridLoad()
			Case "MapItemsPage"
				MapItems_GridLoad()
			Case "StoredItemsPage"
				StoredItems_GridLoad()
			Case Else

		End Select
	End Sub

#End Region

#Region "Grid Context Menu"


	Private UserPlacingFromGrid As Boolean = False
	Private Sub Grid_PlaceOnMapButton_Click(sender As Object, e As EventArgs) Handles Grid_PlaceOnMapButton.Click
		Dim dgv As DataGridView = GetVisibleGrid()
		If dgv Is Nothing Then Exit Sub

		'MapPage.Show()
		TabControl1.SelectedTab = MapPage
		StatusLabel.Text = "Select location"
		UserRetryPlaceItem = True
		rItem = StoredItems(dgv.SelectedRows(0).Cells("ID").Value)

	End Sub

	Private Sub Grid_MoveToStorageButton_Click(sender As Object, e As EventArgs) Handles Grid_MoveToStorageButton.Click
		Dim dgv As DataGridView = GetVisibleGrid()
		If dgv Is Nothing Then Exit Sub

		StoreItems(New List(Of Item) From {Items(dgv.SelectedRows(0).Cells("ID").Value)})
		ReloadVisibleGrid()
	End Sub

	Private Sub Grid_RemoveItemButton_Click(sender As Object, e As EventArgs) Handles Grid_RemoveItemButton.Click
		Dim dgv As DataGridView = GetVisibleGrid()
		If dgv Is Nothing Then Exit Sub



		If Items.ContainsKey(dgv.SelectedRows(0).Cells("ID").Value) Then
			ClickPoint = Items(dgv.SelectedRows(0).Cells("ID").Value).Point
			RemoveItems(New List(Of Item) From {Items(dgv.SelectedRows(0).Cells("ID").Value)})
		ElseIf StoredItems.ContainsKey(dgv.SelectedRows(0).Cells("ID").Value) Then
			RemoveStoredItem(dgv.SelectedRows(0).Cells("ID").Value)
		End If
		ReloadVisibleGrid()
	End Sub

	Private Sub GridContext_Opening(sender As Object, e As CancelEventArgs) Handles GridContext.Opening
		Dim dgv As DataGridView = GetVisibleGrid()
		If dgv Is Nothing OrElse dgv.SelectedRows.Count = 0 Then
			e.Cancel = True
			Exit Sub
		End If

		Grid_PlaceOnMapButton.Visible = False
		Grid_MoveToStorageButton.Visible = False
		Grid_RemoveItemButton.Visible = False

		Dim itemID As String = dgv.SelectedRows(0).Cells("ID").Value

		If dgv.Name = "DGV_ExpiringItems" Then
			Grid_RemoveItemButton.Visible = True
			If Items.ContainsKey(itemID) Then
				Grid_MoveToStorageButton.Visible = True
			ElseIf StoredItems.ContainsKey(itemID) Then
				Grid_PlaceOnMapButton.Visible = True
			End If
		ElseIf dgv.Name = "DGV_AllItems" Then
			Grid_RemoveItemButton.Visible = True
			If Items.ContainsKey(itemID) Then
				Grid_MoveToStorageButton.Visible = True
			ElseIf StoredItems.ContainsKey(itemID) Then
				Grid_PlaceOnMapButton.Visible = True
			End If
		ElseIf dgv.Name = "DGV_MapItems" Then
			Grid_RemoveItemButton.Visible = True
			Grid_MoveToStorageButton.Visible = True
		ElseIf dgv.Name = "DGV_StoredItems" Then
			Grid_RemoveItemButton.Visible = True
			Grid_PlaceOnMapButton.Visible = True
		Else
			e.Cancel = True
		End If
	End Sub

	'Private Sub GridContext_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles GridContext.Closed
	'End Sub


#End Region

#Region "HelperFunctions"

	Private Function GetVisibleGrid() As DataGridView
		Select Case TabControl1.SelectedTab.Name
			Case "ExpiringItemsPage"
				Return DGV_ExpiringItems
			Case "AllItemsPage"
				Return DGV_AllItems
			Case "MapItemsPage"
				Return DGV_MapItems
			Case "StoredItemsPage"
				Return DGV_StoredItems
			Case Else
				Return Nothing
		End Select
	End Function
	Public Function DisplayScale() As Double
		Dim graphics As Graphics = CreateGraphics()
		Dim DpiX As Single = graphics.DpiX
		Dim ScaleX As Double = DpiX / 96

		Return ScaleX

	End Function

	Public Function MapPointHoldsItems(P As Point) As Boolean
		If Not GridPoints.ContainsKey(P) Then Return False
		Return Areas(GridPoints(P).AreaID).CanHoldItems

	End Function

	Private Sub Map_MouseWheel(sender As Object, e As MouseEventArgs) Handles MapGrid.MouseWheel
		If Not My.Computer.Keyboard.CtrlKeyDown Then Exit Sub

		If e.Delta > 0 Then
			MapGrid.CellSize += 1
		Else
			MapGrid.CellSize -= 1
		End If
	End Sub

	Private Sub ExitSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitSetupToolStripMenuItem.Click
		MapSetupButton.Checked = False
	End Sub



#End Region

End Class

Public Class Area
	Public Property ID As Integer
	Public Property Name As String
	Public Property Color As Color
	Public Property CanHoldItems As Boolean
End Class

Public Class Item
	Public Property ID As String
	Public Property Name As String
	Public Property Row As Integer
	Public Property Column As Integer
	Public ReadOnly Property Point As Point
		Get
			Return New Point(Column, Row)
		End Get
	End Property
	Public Property ExpDate As String
	Public Property User As String
	Public Property Notes As String
End Class

Public Class Cell
	Public Property ID As Integer
	Public Property AreaID As Integer
	Public Property Row As Integer
	Public Property Column As Integer
	Public Property Items As New Dictionary(Of String, Item)
End Class