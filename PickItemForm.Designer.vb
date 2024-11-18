<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PickItemForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PickItemForm))
		Me.SelectButton = New System.Windows.Forms.Button()
		Me.AbortButton = New System.Windows.Forms.Button()
		Me.ItemListBox = New System.Windows.Forms.ListBox()
		Me.SuspendLayout()
		'
		'SelectButton
		'
		Me.SelectButton.Location = New System.Drawing.Point(103, 212)
		Me.SelectButton.Name = "SelectButton"
		Me.SelectButton.Size = New System.Drawing.Size(75, 23)
		Me.SelectButton.TabIndex = 0
		Me.SelectButton.Text = "Select"
		Me.SelectButton.UseVisualStyleBackColor = True
		'
		'AbortButton
		'
		Me.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.AbortButton.Location = New System.Drawing.Point(22, 212)
		Me.AbortButton.Name = "AbortButton"
		Me.AbortButton.Size = New System.Drawing.Size(75, 23)
		Me.AbortButton.TabIndex = 1
		Me.AbortButton.Text = "Cancel"
		Me.AbortButton.UseVisualStyleBackColor = True
		'
		'ItemListBox
		'
		Me.ItemListBox.FormattingEnabled = True
		Me.ItemListBox.Location = New System.Drawing.Point(12, 12)
		Me.ItemListBox.Name = "ItemListBox"
		Me.ItemListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
		Me.ItemListBox.Size = New System.Drawing.Size(175, 186)
		Me.ItemListBox.TabIndex = 2
		'
		'PickItemForm
		'
		Me.AcceptButton = Me.SelectButton
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.CancelButton = Me.AbortButton
		Me.ClientSize = New System.Drawing.Size(199, 247)
		Me.Controls.Add(Me.ItemListBox)
		Me.Controls.Add(Me.AbortButton)
		Me.Controls.Add(Me.SelectButton)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "PickItemForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Choose Items"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents SelectButton As Button
	Friend WithEvents AbortButton As Button
	Friend WithEvents ItemListBox As ListBox
End Class
