<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AbapCodeToInstallForm
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AbapCodeToInstallForm))
    Me.AbapCodeTextBox = New System.Windows.Forms.TextBox()
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.CopyToClipboardToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'AbapCodeTextBox
    '
    Me.AbapCodeTextBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.AbapCodeTextBox.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.AbapCodeTextBox.Location = New System.Drawing.Point(0, 25)
    Me.AbapCodeTextBox.Multiline = True
    Me.AbapCodeTextBox.Name = "AbapCodeTextBox"
    Me.AbapCodeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.AbapCodeTextBox.Size = New System.Drawing.Size(615, 301)
    Me.AbapCodeTextBox.TabIndex = 1
    Me.AbapCodeTextBox.WordWrap = False
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToClipboardToolStripButton})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.Size = New System.Drawing.Size(615, 25)
    Me.ToolStrip1.TabIndex = 2
    Me.ToolStrip1.Text = "ToolStrip"
    '
    'CopyToClipboardToolStripButton
    '
    Me.CopyToClipboardToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.CopyToClipboardToolStripButton.Image = CType(resources.GetObject("CopyToClipboardToolStripButton.Image"), System.Drawing.Image)
    Me.CopyToClipboardToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.CopyToClipboardToolStripButton.Name = "CopyToClipboardToolStripButton"
    Me.CopyToClipboardToolStripButton.Size = New System.Drawing.Size(106, 22)
    Me.CopyToClipboardToolStripButton.Text = "Copy to clipboard"
    '
    'AbapCodeToInstallForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(615, 326)
    Me.Controls.Add(Me.AbapCodeTextBox)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "AbapCodeToInstallForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Abap code to install"
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents AbapCodeTextBox As System.Windows.Forms.TextBox
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents CopyToClipboardToolStripButton As System.Windows.Forms.ToolStripButton
End Class
