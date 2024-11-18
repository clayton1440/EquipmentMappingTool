<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewAreaForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewAreaForm))
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.SaveButton = New System.Windows.Forms.Button()
		Me.AbortButton = New System.Windows.Forms.Button()
		Me.CanHoldItems = New System.Windows.Forms.CheckBox()
		Me.SuspendLayout()
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(12, 25)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(254, 20)
		Me.TextBox1.TabIndex = 0
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(9, 11)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(60, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Area Name"
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.PaleTurquoise
		Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
		Me.Panel1.Location = New System.Drawing.Point(12, 71)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(86, 26)
		Me.Panel1.TabIndex = 2
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(9, 57)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(56, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Area Color"
		'
		'SaveButton
		'
		Me.SaveButton.Location = New System.Drawing.Point(147, 111)
		Me.SaveButton.Name = "SaveButton"
		Me.SaveButton.Size = New System.Drawing.Size(75, 23)
		Me.SaveButton.TabIndex = 4
		Me.SaveButton.Text = "Save"
		Me.SaveButton.UseVisualStyleBackColor = True
		'
		'AbortButton
		'
		Me.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.AbortButton.Location = New System.Drawing.Point(57, 111)
		Me.AbortButton.Name = "AbortButton"
		Me.AbortButton.Size = New System.Drawing.Size(75, 23)
		Me.AbortButton.TabIndex = 5
		Me.AbortButton.Text = "Cancel"
		Me.AbortButton.UseVisualStyleBackColor = True
		'
		'CanHoldItems
		'
		Me.CanHoldItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.CanHoldItems.AutoSize = True
		Me.CanHoldItems.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.CanHoldItems.Checked = True
		Me.CanHoldItems.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CanHoldItems.Location = New System.Drawing.Point(169, 71)
		Me.CanHoldItems.Name = "CanHoldItems"
		Me.CanHoldItems.Size = New System.Drawing.Size(81, 17)
		Me.CanHoldItems.TabIndex = 6
		Me.CanHoldItems.Text = "Holds Items"
		Me.CanHoldItems.UseVisualStyleBackColor = True
		'
		'NewAreaForm
		'
		Me.AcceptButton = Me.SaveButton
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.CancelButton = Me.AbortButton
		Me.ClientSize = New System.Drawing.Size(278, 145)
		Me.Controls.Add(Me.CanHoldItems)
		Me.Controls.Add(Me.AbortButton)
		Me.Controls.Add(Me.SaveButton)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.TextBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "NewAreaForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "New Area"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Panel1 As Panel
	Friend WithEvents ColorDialog1 As ColorDialog
	Friend WithEvents Label2 As Label
	Friend WithEvents SaveButton As Button
	Friend WithEvents AbortButton As Button
	Friend WithEvents CanHoldItems As CheckBox
End Class
