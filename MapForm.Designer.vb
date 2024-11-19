<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapForm
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MapForm))
		Me.MapContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.PlaceHereButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.IdItemsButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.StoreItemButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.RemoveItemButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.NewMapButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.OpenMapButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.SaveAsButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.MapSetupButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.AreaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.NewAreaButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.ExtendAreaButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.EditAreaButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.DeleteAreaButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.ShrinkAreaButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.MergeCellsButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.UnmergeCellsButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.ExitSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ExpiringItemsPage = New System.Windows.Forms.TabPage()
		Me.DGV_ExpiringItems = New System.Windows.Forms.DataGridView()
		Me.GridContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.Grid_PlaceOnMapButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.Grid_MoveToStorageButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.Grid_RemoveItemButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.MapPage = New System.Windows.Forms.TabPage()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		Me.StorageItemCount = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.MapItemCount = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.ExpiringItemCount = New System.Windows.Forms.Label()
		Me.MapGrid = New MapControl()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.StoredItemsPage = New System.Windows.Forms.TabPage()
		Me.DGV_StoredItems = New System.Windows.Forms.DataGridView()
		Me.MapItemsPage = New System.Windows.Forms.TabPage()
		Me.DGV_MapItems = New System.Windows.Forms.DataGridView()
		Me.AllItemsPage = New System.Windows.Forms.TabPage()
		Me.DGV_AllItems = New System.Windows.Forms.DataGridView()
		Me.StatusBar = New System.Windows.Forms.StatusStrip()
		Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
		Me.AreaHoverLabel = New System.Windows.Forms.ToolStripStatusLabel()
		Me.HoveredCellLabel = New System.Windows.Forms.ToolStripStatusLabel()
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.SelectedAreaLabel = New System.Windows.Forms.ToolStripStatusLabel()
		Me.SelectedCellLabel = New System.Windows.Forms.ToolStripStatusLabel()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.MapContext.SuspendLayout()
		Me.MenuStrip1.SuspendLayout()
		Me.ExpiringItemsPage.SuspendLayout()
		CType(Me.DGV_ExpiringItems, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GridContext.SuspendLayout()
		Me.MapPage.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.TableLayoutPanel1.SuspendLayout()
		Me.TabControl1.SuspendLayout()
		Me.StoredItemsPage.SuspendLayout()
		CType(Me.DGV_StoredItems, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.MapItemsPage.SuspendLayout()
		CType(Me.DGV_MapItems, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.AllItemsPage.SuspendLayout()
		CType(Me.DGV_AllItems, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StatusBar.SuspendLayout()
		Me.SuspendLayout()
		'
		'MapContext
		'
		Me.MapContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlaceHereButton, Me.IdItemsButton, Me.StoreItemButton, Me.RemoveItemButton})
		Me.MapContext.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
		Me.MapContext.Name = "MapContext"
		Me.MapContext.ShowCheckMargin = True
		Me.MapContext.ShowImageMargin = False
		Me.MapContext.Size = New System.Drawing.Size(163, 92)
		'
		'PlaceHereButton
		'
		Me.PlaceHereButton.Name = "PlaceHereButton"
		Me.PlaceHereButton.Size = New System.Drawing.Size(162, 22)
		Me.PlaceHereButton.Text = "Place Item Here"
		'
		'IdItemsButton
		'
		Me.IdItemsButton.Name = "IdItemsButton"
		Me.IdItemsButton.Size = New System.Drawing.Size(162, 22)
		Me.IdItemsButton.Text = "Identify Items"
		'
		'StoreItemButton
		'
		Me.StoreItemButton.Name = "StoreItemButton"
		Me.StoreItemButton.Size = New System.Drawing.Size(162, 22)
		Me.StoreItemButton.Text = "Move To Storage"
		'
		'RemoveItemButton
		'
		Me.RemoveItemButton.Name = "RemoveItemButton"
		Me.RemoveItemButton.Size = New System.Drawing.Size(162, 22)
		Me.RemoveItemButton.Text = "Remove Item"
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.AreaToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
		Me.MenuStrip1.TabIndex = 2
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'FileToolStripMenuItem
		'
		Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMapButton, Me.OpenMapButton, Me.SaveAsButton})
		Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
		Me.FileToolStripMenuItem.Size = New System.Drawing.Size(36, 20)
		Me.FileToolStripMenuItem.Text = "File"
		'
		'NewMapButton
		'
		Me.NewMapButton.Name = "NewMapButton"
		Me.NewMapButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
		Me.NewMapButton.Size = New System.Drawing.Size(192, 22)
		Me.NewMapButton.Text = "New"
		'
		'OpenMapButton
		'
		Me.OpenMapButton.Name = "OpenMapButton"
		Me.OpenMapButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
		Me.OpenMapButton.Size = New System.Drawing.Size(192, 22)
		Me.OpenMapButton.Text = "Open..."
		'
		'SaveAsButton
		'
		Me.SaveAsButton.Name = "SaveAsButton"
		Me.SaveAsButton.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
			Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
		Me.SaveAsButton.Size = New System.Drawing.Size(192, 22)
		Me.SaveAsButton.Text = "Save As..."
		'
		'ToolsToolStripMenuItem
		'
		Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindToolStripMenuItem, Me.MapSetupButton})
		Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
		Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
		Me.ToolsToolStripMenuItem.Text = "Tools"
		'
		'FindToolStripMenuItem
		'
		Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
		Me.FindToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
		Me.FindToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
		Me.FindToolStripMenuItem.Text = "Find"
		'
		'MapSetupButton
		'
		Me.MapSetupButton.CheckOnClick = True
		Me.MapSetupButton.Name = "MapSetupButton"
		Me.MapSetupButton.Size = New System.Drawing.Size(180, 22)
		Me.MapSetupButton.Text = "Map Setup"
		'
		'AreaToolStripMenuItem
		'
		Me.AreaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewAreaButton, Me.ExtendAreaButton, Me.EditAreaButton, Me.DeleteAreaButton, Me.ShrinkAreaButton, Me.MergeCellsButton, Me.UnmergeCellsButton, Me.ToolStripSeparator1, Me.ExitSetupToolStripMenuItem})
		Me.AreaToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AreaToolStripMenuItem.Name = "AreaToolStripMenuItem"
		Me.AreaToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
		Me.AreaToolStripMenuItem.Text = "Setup"
		Me.AreaToolStripMenuItem.Visible = False
		'
		'NewAreaButton
		'
		Me.NewAreaButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NewAreaButton.Name = "NewAreaButton"
		Me.NewAreaButton.Size = New System.Drawing.Size(180, 22)
		Me.NewAreaButton.Text = "New Area"
		'
		'ExtendAreaButton
		'
		Me.ExtendAreaButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ExtendAreaButton.Name = "ExtendAreaButton"
		Me.ExtendAreaButton.Size = New System.Drawing.Size(180, 22)
		Me.ExtendAreaButton.Text = "Extend Area"
		'
		'EditAreaButton
		'
		Me.EditAreaButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.EditAreaButton.Name = "EditAreaButton"
		Me.EditAreaButton.Size = New System.Drawing.Size(180, 22)
		Me.EditAreaButton.Text = "Edit Area"
		'
		'DeleteAreaButton
		'
		Me.DeleteAreaButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DeleteAreaButton.Name = "DeleteAreaButton"
		Me.DeleteAreaButton.Size = New System.Drawing.Size(180, 22)
		Me.DeleteAreaButton.Text = "Delete Area"
		'
		'ShrinkAreaButton
		'
		Me.ShrinkAreaButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ShrinkAreaButton.Name = "ShrinkAreaButton"
		Me.ShrinkAreaButton.Size = New System.Drawing.Size(180, 22)
		Me.ShrinkAreaButton.Text = "Shrink Area"
		'
		'MergeCellsButton
		'
		Me.MergeCellsButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MergeCellsButton.Name = "MergeCellsButton"
		Me.MergeCellsButton.Size = New System.Drawing.Size(180, 22)
		Me.MergeCellsButton.Text = "Merge Cells"
		Me.MergeCellsButton.Visible = False
		'
		'UnmergeCellsButton
		'
		Me.UnmergeCellsButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.UnmergeCellsButton.Name = "UnmergeCellsButton"
		Me.UnmergeCellsButton.Size = New System.Drawing.Size(180, 22)
		Me.UnmergeCellsButton.Text = "Unmerge Cells"
		Me.UnmergeCellsButton.Visible = False
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
		'
		'ExitSetupToolStripMenuItem
		'
		Me.ExitSetupToolStripMenuItem.Name = "ExitSetupToolStripMenuItem"
		Me.ExitSetupToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
		Me.ExitSetupToolStripMenuItem.Text = "Exit Setup"
		'
		'ExpiringItemsPage
		'
		Me.ExpiringItemsPage.Controls.Add(Me.DGV_ExpiringItems)
		Me.ExpiringItemsPage.Location = New System.Drawing.Point(4, 22)
		Me.ExpiringItemsPage.Name = "ExpiringItemsPage"
		Me.ExpiringItemsPage.Padding = New System.Windows.Forms.Padding(3)
		Me.ExpiringItemsPage.Size = New System.Drawing.Size(1000, 517)
		Me.ExpiringItemsPage.TabIndex = 2
		Me.ExpiringItemsPage.Text = "Expiring Soon"
		Me.ExpiringItemsPage.UseVisualStyleBackColor = True
		'
		'DGV_ExpiringItems
		'
		Me.DGV_ExpiringItems.AllowUserToAddRows = False
		Me.DGV_ExpiringItems.AllowUserToDeleteRows = False
		Me.DGV_ExpiringItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.DGV_ExpiringItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DGV_ExpiringItems.ContextMenuStrip = Me.GridContext
		Me.DGV_ExpiringItems.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DGV_ExpiringItems.Location = New System.Drawing.Point(3, 3)
		Me.DGV_ExpiringItems.Margin = New System.Windows.Forms.Padding(0)
		Me.DGV_ExpiringItems.Name = "DGV_ExpiringItems"
		Me.DGV_ExpiringItems.ReadOnly = True
		Me.DGV_ExpiringItems.RowHeadersVisible = False
		Me.DGV_ExpiringItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.DGV_ExpiringItems.Size = New System.Drawing.Size(994, 511)
		Me.DGV_ExpiringItems.TabIndex = 0
		'
		'GridContext
		'
		Me.GridContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Grid_PlaceOnMapButton, Me.Grid_MoveToStorageButton, Me.Grid_RemoveItemButton})
		Me.GridContext.Name = "GridContext"
		Me.GridContext.Size = New System.Drawing.Size(163, 70)
		'
		'Grid_PlaceOnMapButton
		'
		Me.Grid_PlaceOnMapButton.Name = "Grid_PlaceOnMapButton"
		Me.Grid_PlaceOnMapButton.Size = New System.Drawing.Size(162, 22)
		Me.Grid_PlaceOnMapButton.Text = "Place On Map"
		'
		'Grid_MoveToStorageButton
		'
		Me.Grid_MoveToStorageButton.Name = "Grid_MoveToStorageButton"
		Me.Grid_MoveToStorageButton.Size = New System.Drawing.Size(162, 22)
		Me.Grid_MoveToStorageButton.Text = "Move To Storage"
		'
		'Grid_RemoveItemButton
		'
		Me.Grid_RemoveItemButton.Name = "Grid_RemoveItemButton"
		Me.Grid_RemoveItemButton.Size = New System.Drawing.Size(162, 22)
		Me.Grid_RemoveItemButton.Text = "Remove Item"
		'
		'MapPage
		'
		Me.MapPage.Controls.Add(Me.Panel1)
		Me.MapPage.Controls.Add(Me.MapGrid)
		Me.MapPage.Location = New System.Drawing.Point(4, 22)
		Me.MapPage.Margin = New System.Windows.Forms.Padding(0)
		Me.MapPage.Name = "MapPage"
		Me.MapPage.Size = New System.Drawing.Size(1000, 517)
		Me.MapPage.TabIndex = 0
		Me.MapPage.Text = "Map"
		Me.MapPage.UseVisualStyleBackColor = True
		'
		'Panel1
		'
		Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Panel1.BackColor = System.Drawing.SystemColors.Control
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
		Me.Panel1.Location = New System.Drawing.Point(792, 14)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
		Me.Panel1.Size = New System.Drawing.Size(181, 57)
		Me.Panel1.TabIndex = 2
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.92655!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.07345!))
		Me.TableLayoutPanel1.Controls.Add(Me.StorageItemCount, 1, 1)
		Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
		Me.TableLayoutPanel1.Controls.Add(Me.MapItemCount, 1, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 2)
		Me.TableLayoutPanel1.Controls.Add(Me.ExpiringItemCount, 1, 2)
		Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(1, 1)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 3
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34!))
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(177, 53)
		Me.TableLayoutPanel1.TabIndex = 0
		'
		'StorageItemCount
		'
		Me.StorageItemCount.AutoSize = True
		Me.StorageItemCount.Dock = System.Windows.Forms.DockStyle.Fill
		Me.StorageItemCount.Location = New System.Drawing.Point(125, 17)
		Me.StorageItemCount.Name = "StorageItemCount"
		Me.StorageItemCount.Size = New System.Drawing.Size(49, 17)
		Me.StorageItemCount.TabIndex = 6
		Me.StorageItemCount.Text = "0"
		Me.StorageItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Label1.Location = New System.Drawing.Point(3, 17)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(116, 17)
		Me.Label1.TabIndex = 5
		Me.Label1.Text = "Items In Storage"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'MapItemCount
		'
		Me.MapItemCount.AutoSize = True
		Me.MapItemCount.Dock = System.Windows.Forms.DockStyle.Fill
		Me.MapItemCount.Location = New System.Drawing.Point(125, 0)
		Me.MapItemCount.Name = "MapItemCount"
		Me.MapItemCount.Size = New System.Drawing.Size(49, 17)
		Me.MapItemCount.TabIndex = 2
		Me.MapItemCount.Text = "0"
		Me.MapItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Label4.Location = New System.Drawing.Point(3, 0)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(116, 17)
		Me.Label4.TabIndex = 1
		Me.Label4.Text = "Items on Map"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Label6.Location = New System.Drawing.Point(3, 34)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(116, 19)
		Me.Label6.TabIndex = 3
		Me.Label6.Text = "Items Expiring Soon"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'ExpiringItemCount
		'
		Me.ExpiringItemCount.AutoSize = True
		Me.ExpiringItemCount.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ExpiringItemCount.Location = New System.Drawing.Point(125, 34)
		Me.ExpiringItemCount.Name = "ExpiringItemCount"
		Me.ExpiringItemCount.Size = New System.Drawing.Size(49, 19)
		Me.ExpiringItemCount.TabIndex = 4
		Me.ExpiringItemCount.Text = "0"
		Me.ExpiringItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'MapGrid
		'
		Me.MapGrid.AutoScroll = True
		Me.MapGrid.AutoScrollMinSize = New System.Drawing.Size(120, 120)
		Me.MapGrid.BackColor = System.Drawing.SystemColors.ControlDark
		Me.MapGrid.CellDefaultBackColor = System.Drawing.SystemColors.Control
		Me.MapGrid.CellSize = 12
		Me.MapGrid.Columns = 10
		Me.MapGrid.Cursor = System.Windows.Forms.Cursors.Cross
		Me.MapGrid.Dock = System.Windows.Forms.DockStyle.Fill
		Me.MapGrid.DrawBorder = False
		Me.MapGrid.HighlightPoints = CType(resources.GetObject("MapGrid.HighlightPoints"), System.Collections.Generic.List(Of System.Drawing.Point))
		Me.MapGrid.Location = New System.Drawing.Point(0, 0)
		Me.MapGrid.Margin = New System.Windows.Forms.Padding(0)
		Me.MapGrid.Name = "MapGrid"
		Me.MapGrid.Rows = 10
		Me.MapGrid.ShowGridlines = False
		Me.MapGrid.Size = New System.Drawing.Size(1000, 517)
		Me.MapGrid.TabIndex = 3
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.MapPage)
		Me.TabControl1.Controls.Add(Me.ExpiringItemsPage)
		Me.TabControl1.Controls.Add(Me.StoredItemsPage)
		Me.TabControl1.Controls.Add(Me.MapItemsPage)
		Me.TabControl1.Controls.Add(Me.AllItemsPage)
		Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TabControl1.Location = New System.Drawing.Point(0, 24)
		Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(1008, 543)
		Me.TabControl1.TabIndex = 0
		'
		'StoredItemsPage
		'
		Me.StoredItemsPage.Controls.Add(Me.DGV_StoredItems)
		Me.StoredItemsPage.Location = New System.Drawing.Point(4, 22)
		Me.StoredItemsPage.Name = "StoredItemsPage"
		Me.StoredItemsPage.Padding = New System.Windows.Forms.Padding(3)
		Me.StoredItemsPage.Size = New System.Drawing.Size(1000, 517)
		Me.StoredItemsPage.TabIndex = 4
		Me.StoredItemsPage.Text = "Items In Storage"
		Me.StoredItemsPage.UseVisualStyleBackColor = True
		'
		'DGV_StoredItems
		'
		Me.DGV_StoredItems.AllowUserToAddRows = False
		Me.DGV_StoredItems.AllowUserToDeleteRows = False
		Me.DGV_StoredItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.DGV_StoredItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DGV_StoredItems.ContextMenuStrip = Me.GridContext
		Me.DGV_StoredItems.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DGV_StoredItems.Location = New System.Drawing.Point(3, 3)
		Me.DGV_StoredItems.Margin = New System.Windows.Forms.Padding(0)
		Me.DGV_StoredItems.Name = "DGV_StoredItems"
		Me.DGV_StoredItems.ReadOnly = True
		Me.DGV_StoredItems.RowHeadersVisible = False
		Me.DGV_StoredItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.DGV_StoredItems.Size = New System.Drawing.Size(994, 511)
		Me.DGV_StoredItems.TabIndex = 1
		'
		'MapItemsPage
		'
		Me.MapItemsPage.Controls.Add(Me.DGV_MapItems)
		Me.MapItemsPage.Location = New System.Drawing.Point(4, 22)
		Me.MapItemsPage.Name = "MapItemsPage"
		Me.MapItemsPage.Padding = New System.Windows.Forms.Padding(3)
		Me.MapItemsPage.Size = New System.Drawing.Size(1000, 517)
		Me.MapItemsPage.TabIndex = 5
		Me.MapItemsPage.Text = "Items On Map"
		Me.MapItemsPage.UseVisualStyleBackColor = True
		'
		'DGV_MapItems
		'
		Me.DGV_MapItems.AllowUserToAddRows = False
		Me.DGV_MapItems.AllowUserToDeleteRows = False
		Me.DGV_MapItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.DGV_MapItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DGV_MapItems.ContextMenuStrip = Me.GridContext
		Me.DGV_MapItems.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DGV_MapItems.Location = New System.Drawing.Point(3, 3)
		Me.DGV_MapItems.Margin = New System.Windows.Forms.Padding(0)
		Me.DGV_MapItems.Name = "DGV_MapItems"
		Me.DGV_MapItems.ReadOnly = True
		Me.DGV_MapItems.RowHeadersVisible = False
		Me.DGV_MapItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.DGV_MapItems.Size = New System.Drawing.Size(994, 511)
		Me.DGV_MapItems.TabIndex = 1
		'
		'AllItemsPage
		'
		Me.AllItemsPage.Controls.Add(Me.DGV_AllItems)
		Me.AllItemsPage.Location = New System.Drawing.Point(4, 22)
		Me.AllItemsPage.Name = "AllItemsPage"
		Me.AllItemsPage.Padding = New System.Windows.Forms.Padding(3)
		Me.AllItemsPage.Size = New System.Drawing.Size(1000, 517)
		Me.AllItemsPage.TabIndex = 3
		Me.AllItemsPage.Text = "All Items"
		Me.AllItemsPage.UseVisualStyleBackColor = True
		'
		'DGV_AllItems
		'
		Me.DGV_AllItems.AllowUserToAddRows = False
		Me.DGV_AllItems.AllowUserToDeleteRows = False
		Me.DGV_AllItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.DGV_AllItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DGV_AllItems.ContextMenuStrip = Me.GridContext
		Me.DGV_AllItems.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DGV_AllItems.Location = New System.Drawing.Point(3, 3)
		Me.DGV_AllItems.Margin = New System.Windows.Forms.Padding(0)
		Me.DGV_AllItems.Name = "DGV_AllItems"
		Me.DGV_AllItems.ReadOnly = True
		Me.DGV_AllItems.RowHeadersVisible = False
		Me.DGV_AllItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.DGV_AllItems.Size = New System.Drawing.Size(994, 511)
		Me.DGV_AllItems.TabIndex = 1
		'
		'StatusBar
		'
		Me.StatusBar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel, Me.AreaHoverLabel, Me.HoveredCellLabel, Me.ToolStripStatusLabel1, Me.SelectedAreaLabel, Me.SelectedCellLabel})
		Me.StatusBar.Location = New System.Drawing.Point(0, 567)
		Me.StatusBar.Name = "StatusBar"
		Me.StatusBar.Size = New System.Drawing.Size(1008, 22)
		Me.StatusBar.SizingGrip = False
		Me.StatusBar.Stretch = False
		Me.StatusBar.TabIndex = 3
		Me.StatusBar.Text = "StatusStrip1"
		'
		'StatusLabel
		'
		Me.StatusLabel.Name = "StatusLabel"
		Me.StatusLabel.Size = New System.Drawing.Size(609, 17)
		Me.StatusLabel.Spring = True
		Me.StatusLabel.Text = "Ready"
		Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'AreaHoverLabel
		'
		Me.AreaHoverLabel.Margin = New System.Windows.Forms.Padding(20, 3, 0, 2)
		Me.AreaHoverLabel.Name = "AreaHoverLabel"
		Me.AreaHoverLabel.Size = New System.Drawing.Size(55, 17)
		Me.AreaHoverLabel.Text = "A: Area1"
		'
		'HoveredCellLabel
		'
		Me.HoveredCellLabel.Margin = New System.Windows.Forms.Padding(20, 3, 0, 2)
		Me.HoveredCellLabel.Name = "HoveredCellLabel"
		Me.HoveredCellLabel.Size = New System.Drawing.Size(72, 17)
		Me.HoveredCellLabel.Text = "X: 0     Y: 0"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(20, 3, 0, 2)
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(12, 17)
		Me.ToolStripStatusLabel1.Text = "|"
		'
		'SelectedAreaLabel
		'
		Me.SelectedAreaLabel.Margin = New System.Windows.Forms.Padding(20, 3, 0, 2)
		Me.SelectedAreaLabel.Name = "SelectedAreaLabel"
		Me.SelectedAreaLabel.Size = New System.Drawing.Size(65, 17)
		Me.SelectedAreaLabel.Text = "A: None ▢"
		'
		'SelectedCellLabel
		'
		Me.SelectedCellLabel.Margin = New System.Windows.Forms.Padding(20, 3, 0, 2)
		Me.SelectedCellLabel.Name = "SelectedCellLabel"
		Me.SelectedCellLabel.Size = New System.Drawing.Size(80, 17)
		Me.SelectedCellLabel.Text = "X: -1     Y: -1"
		'
		'ToolTip1
		'
		Me.ToolTip1.AutoPopDelay = 5000
		Me.ToolTip1.InitialDelay = 250
		Me.ToolTip1.ReshowDelay = 100
		'
		'MapForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(1008, 589)
		Me.Controls.Add(Me.TabControl1)
		Me.Controls.Add(Me.StatusBar)
		Me.Controls.Add(Me.MenuStrip1)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MainMenuStrip = Me.MenuStrip1
		Me.Name = "MapForm"
		Me.Text = "Equipment Mapping Tool"
		Me.MapContext.ResumeLayout(False)
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.ExpiringItemsPage.ResumeLayout(False)
		CType(Me.DGV_ExpiringItems, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GridContext.ResumeLayout(False)
		Me.MapPage.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.TableLayoutPanel1.PerformLayout()
		Me.TabControl1.ResumeLayout(False)
		Me.StoredItemsPage.ResumeLayout(False)
		CType(Me.DGV_StoredItems, System.ComponentModel.ISupportInitialize).EndInit()
		Me.MapItemsPage.ResumeLayout(False)
		CType(Me.DGV_MapItems, System.ComponentModel.ISupportInitialize).EndInit()
		Me.AllItemsPage.ResumeLayout(False)
		CType(Me.DGV_AllItems, System.ComponentModel.ISupportInitialize).EndInit()
		Me.StatusBar.ResumeLayout(False)
		Me.StatusBar.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents MapContext As ContextMenuStrip
	Friend WithEvents PlaceHereButton As ToolStripMenuItem
	Friend WithEvents IdItemsButton As ToolStripMenuItem
	Friend WithEvents StoreItemButton As ToolStripMenuItem
	Friend WithEvents RemoveItemButton As ToolStripMenuItem
	Friend WithEvents MenuStrip1 As MenuStrip
	Friend WithEvents ExpiringItemsPage As TabPage
	Friend WithEvents MapPage As TabPage
	Friend WithEvents Panel1 As Panel
	Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
	Friend WithEvents ExpiringItemCount As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents MapItemCount As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents TabControl1 As TabControl
	Friend WithEvents AllItemsPage As TabPage
	Friend WithEvents MapGrid As MapControl
	Friend WithEvents StatusBar As StatusStrip
	Friend WithEvents StatusLabel As ToolStripStatusLabel
	Friend WithEvents AreaToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents NewAreaButton As ToolStripMenuItem
	Friend WithEvents ExtendAreaButton As ToolStripMenuItem
	Friend WithEvents DeleteAreaButton As ToolStripMenuItem
	Friend WithEvents ShrinkAreaButton As ToolStripMenuItem
	Friend WithEvents SelectedCellLabel As ToolStripStatusLabel
	Friend WithEvents HoveredCellLabel As ToolStripStatusLabel
	Friend WithEvents AreaHoverLabel As ToolStripStatusLabel
	Friend WithEvents EditAreaButton As ToolStripMenuItem
	Friend WithEvents SelectedAreaLabel As ToolStripStatusLabel
	Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
	Friend WithEvents StorageItemCount As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents StoredItemsPage As TabPage
	Friend WithEvents MapItemsPage As TabPage
	Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents OpenMapButton As ToolStripMenuItem
	Friend WithEvents NewMapButton As ToolStripMenuItem
	Friend WithEvents SaveAsButton As ToolStripMenuItem
	Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents FindToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents MapSetupButton As ToolStripMenuItem
	Friend WithEvents DGV_ExpiringItems As DataGridView
	Friend WithEvents DGV_StoredItems As DataGridView
	Friend WithEvents DGV_MapItems As DataGridView
	Friend WithEvents DGV_AllItems As DataGridView
	Friend WithEvents ToolTip1 As ToolTip
	Friend WithEvents GridContext As ContextMenuStrip
	Friend WithEvents Grid_PlaceOnMapButton As ToolStripMenuItem
	Friend WithEvents Grid_MoveToStorageButton As ToolStripMenuItem
	Friend WithEvents Grid_RemoveItemButton As ToolStripMenuItem
	Friend WithEvents MergeCellsButton As ToolStripMenuItem
	Friend WithEvents UnmergeCellsButton As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
	Friend WithEvents ExitSetupToolStripMenuItem As ToolStripMenuItem
End Class
