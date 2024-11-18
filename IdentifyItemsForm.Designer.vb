<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IdentifyItemsForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IdentifyItemsForm))
		Me.LocLabel = New System.Windows.Forms.Label()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.CloseButton = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'LocLabel
		'
		Me.LocLabel.AutoSize = True
		Me.LocLabel.Location = New System.Drawing.Point(12, 20)
		Me.LocLabel.Name = "LocLabel"
		Me.LocLabel.Size = New System.Drawing.Size(134, 13)
		Me.LocLabel.TabIndex = 1
		Me.LocLabel.Text = "Item at Location  ( -1 ,  -1 ):"
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(12, 36)
		Me.TextBox1.Multiline = True
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.ReadOnly = True
		Me.TextBox1.Size = New System.Drawing.Size(172, 171)
		Me.TextBox1.TabIndex = 2
		'
		'CloseButton
		'
		Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.CloseButton.Location = New System.Drawing.Point(58, 213)
		Me.CloseButton.Name = "CloseButton"
		Me.CloseButton.Size = New System.Drawing.Size(75, 23)
		Me.CloseButton.TabIndex = 3
		Me.CloseButton.Text = "Close"
		Me.CloseButton.UseVisualStyleBackColor = True
		'
		'IdentifyItemsForm
		'
		Me.AcceptButton = Me.CloseButton
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.CancelButton = Me.CloseButton
		Me.ClientSize = New System.Drawing.Size(196, 241)
		Me.Controls.Add(Me.CloseButton)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.LocLabel)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "IdentifyItemsForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Identify Item"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents LocLabel As Label
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents CloseButton As Button
End Class
