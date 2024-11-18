<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlaceItemForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlaceItemForm))
		Me.Label3 = New System.Windows.Forms.Label()
		Me.NameBox = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.ItemID = New System.Windows.Forms.TextBox()
		Me.ExpDate = New System.Windows.Forms.DateTimePicker()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.NoExpiration = New System.Windows.Forms.CheckBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.User = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.LocTextBox = New System.Windows.Forms.TextBox()
		Me.SelectLocationButton = New System.Windows.Forms.Button()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Notes = New System.Windows.Forms.TextBox()
		Me.SaveButton = New System.Windows.Forms.Button()
		Me.AbortButton = New System.Windows.Forms.Button()
		Me.EP1 = New System.Windows.Forms.ErrorProvider(Me.components)
		CType(Me.EP1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(108, 15)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(35, 13)
		Me.Label3.TabIndex = 11
		Me.Label3.Text = "Name"
		'
		'NameBox
		'
		Me.NameBox.Location = New System.Drawing.Point(111, 29)
		Me.NameBox.Name = "NameBox"
		Me.NameBox.Size = New System.Drawing.Size(284, 20)
		Me.NameBox.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(9, 15)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(18, 13)
		Me.Label1.TabIndex = 13
		Me.Label1.Text = "ID"
		'
		'ItemID
		'
		Me.ItemID.Location = New System.Drawing.Point(12, 29)
		Me.ItemID.Name = "ItemID"
		Me.ItemID.Size = New System.Drawing.Size(93, 20)
		Me.ItemID.TabIndex = 0
		'
		'ExpDate
		'
		Me.ExpDate.CustomFormat = ""
		Me.ExpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.ExpDate.Location = New System.Drawing.Point(12, 75)
		Me.ExpDate.Name = "ExpDate"
		Me.ExpDate.Size = New System.Drawing.Size(108, 20)
		Me.ExpDate.TabIndex = 2
		Me.ExpDate.Value = New Date(2024, 11, 4, 0, 0, 0, 0)
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(9, 61)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(54, 13)
		Me.Label2.TabIndex = 15
		Me.Label2.Text = "Exp. Date"
		'
		'NoExpiration
		'
		Me.NoExpiration.AutoSize = True
		Me.NoExpiration.Location = New System.Drawing.Point(65, 60)
		Me.NoExpiration.Name = "NoExpiration"
		Me.NoExpiration.Size = New System.Drawing.Size(52, 17)
		Me.NoExpiration.TabIndex = 3
		Me.NoExpiration.Text = "None"
		Me.NoExpiration.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(124, 61)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(29, 13)
		Me.Label4.TabIndex = 18
		Me.Label4.Text = "User"
		'
		'User
		'
		Me.User.Location = New System.Drawing.Point(127, 75)
		Me.User.Name = "User"
		Me.User.Size = New System.Drawing.Size(122, 20)
		Me.User.TabIndex = 4
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(252, 61)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(48, 13)
		Me.Label5.TabIndex = 20
		Me.Label5.Text = "Location"
		'
		'LocTextBox
		'
		Me.LocTextBox.Location = New System.Drawing.Point(255, 75)
		Me.LocTextBox.Name = "LocTextBox"
		Me.LocTextBox.ReadOnly = True
		Me.LocTextBox.Size = New System.Drawing.Size(71, 20)
		Me.LocTextBox.TabIndex = 19
		Me.LocTextBox.TabStop = False
		Me.LocTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'SelectLocationButton
		'
		Me.SelectLocationButton.Location = New System.Drawing.Point(332, 75)
		Me.SelectLocationButton.Name = "SelectLocationButton"
		Me.SelectLocationButton.Size = New System.Drawing.Size(63, 20)
		Me.SelectLocationButton.TabIndex = 8
		Me.SelectLocationButton.Text = "Select"
		Me.SelectLocationButton.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(9, 106)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(35, 13)
		Me.Label6.TabIndex = 23
		Me.Label6.Text = "Notes"
		'
		'Notes
		'
		Me.Notes.Location = New System.Drawing.Point(12, 120)
		Me.Notes.Multiline = True
		Me.Notes.Name = "Notes"
		Me.Notes.Size = New System.Drawing.Size(383, 41)
		Me.Notes.TabIndex = 5
		'
		'SaveButton
		'
		Me.SaveButton.Location = New System.Drawing.Point(206, 170)
		Me.SaveButton.Name = "SaveButton"
		Me.SaveButton.Size = New System.Drawing.Size(75, 23)
		Me.SaveButton.TabIndex = 6
		Me.SaveButton.Text = "Place Item"
		Me.SaveButton.UseVisualStyleBackColor = True
		'
		'AbortButton
		'
		Me.AbortButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.AbortButton.Location = New System.Drawing.Point(125, 170)
		Me.AbortButton.Name = "AbortButton"
		Me.AbortButton.Size = New System.Drawing.Size(75, 23)
		Me.AbortButton.TabIndex = 7
		Me.AbortButton.Text = "Cancel"
		Me.AbortButton.UseVisualStyleBackColor = True
		'
		'EP1
		'
		Me.EP1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		Me.EP1.ContainerControl = Me
		'
		'PlaceItemForm
		'
		Me.AcceptButton = Me.SaveButton
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.CancelButton = Me.AbortButton
		Me.ClientSize = New System.Drawing.Size(407, 201)
		Me.Controls.Add(Me.AbortButton)
		Me.Controls.Add(Me.SaveButton)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Notes)
		Me.Controls.Add(Me.SelectLocationButton)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.LocTextBox)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.User)
		Me.Controls.Add(Me.ExpDate)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.ItemID)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.NameBox)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.NoExpiration)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "PlaceItemForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Place Item"
		CType(Me.EP1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label3 As Label
	Friend WithEvents NameBox As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents ItemID As TextBox
	Friend WithEvents ExpDate As DateTimePicker
	Friend WithEvents Label2 As Label
	Friend WithEvents NoExpiration As CheckBox
	Friend WithEvents Label4 As Label
	Friend WithEvents User As TextBox
	Friend WithEvents Label5 As Label
	Friend WithEvents LocTextBox As TextBox
	Friend WithEvents SelectLocationButton As Button
	Friend WithEvents Label6 As Label
	Friend WithEvents Notes As TextBox
	Friend WithEvents SaveButton As Button
	Friend WithEvents AbortButton As Button
	Friend WithEvents EP1 As ErrorProvider
End Class
