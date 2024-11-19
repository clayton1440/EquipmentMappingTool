<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindItemForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindItemForm))
		Me.Label1 = New System.Windows.Forms.Label()
		Me.ItemID = New System.Windows.Forms.TextBox()
		Me.ShowOnMapButton = New System.Windows.Forms.Button()
		Me.CloseButton = New System.Windows.Forms.Button()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
		Me.StatusStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(9, 17)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(41, 13)
		Me.Label1.TabIndex = 15
		Me.Label1.Text = "Item ID"
		'
		'ItemID
		'
		Me.ItemID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.ItemID.Location = New System.Drawing.Point(12, 31)
		Me.ItemID.Name = "ItemID"
		Me.ItemID.Size = New System.Drawing.Size(114, 20)
		Me.ItemID.TabIndex = 14
		'
		'ShowOnMapButton
		'
		Me.ShowOnMapButton.Enabled = False
		Me.ShowOnMapButton.Location = New System.Drawing.Point(140, 15)
		Me.ShowOnMapButton.Name = "ShowOnMapButton"
		Me.ShowOnMapButton.Size = New System.Drawing.Size(75, 23)
		Me.ShowOnMapButton.TabIndex = 16
		Me.ShowOnMapButton.Text = "Show"
		Me.ShowOnMapButton.UseVisualStyleBackColor = True
		'
		'CloseButton
		'
		Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.CloseButton.Location = New System.Drawing.Point(140, 38)
		Me.CloseButton.Name = "CloseButton"
		Me.CloseButton.Size = New System.Drawing.Size(75, 23)
		Me.CloseButton.TabIndex = 17
		Me.CloseButton.Text = "Close"
		Me.CloseButton.UseVisualStyleBackColor = True
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 72)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(230, 22)
		Me.StatusStrip1.SizingGrip = False
		Me.StatusStrip1.TabIndex = 18
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'StatusLabel
		'
		Me.StatusLabel.Name = "StatusLabel"
		Me.StatusLabel.Size = New System.Drawing.Size(64, 17)
		Me.StatusLabel.Text = "Not Found"
		'
		'FindItemForm
		'
		Me.AcceptButton = Me.ShowOnMapButton
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.CancelButton = Me.CloseButton
		Me.ClientSize = New System.Drawing.Size(230, 94)
		Me.Controls.Add(Me.ShowOnMapButton)
		Me.Controls.Add(Me.CloseButton)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.ItemID)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FindItemForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Find"
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents ItemID As TextBox
	Friend WithEvents ShowOnMapButton As Button
	Friend WithEvents CloseButton As Button
	Friend WithEvents StatusStrip1 As StatusStrip
	Friend WithEvents StatusLabel As ToolStripStatusLabel
End Class
