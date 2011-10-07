<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PasswordForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PasswordForm))
    Me.PasswordTextBox = New System.Windows.Forms.TextBox()
    Me.OkButton = New System.Windows.Forms.Button()
    Me.PasswordCancelButton = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'PasswordTextBox
    '
    Me.PasswordTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.PasswordTextBox.Location = New System.Drawing.Point(12, 12)
    Me.PasswordTextBox.Name = "PasswordTextBox"
    Me.PasswordTextBox.Size = New System.Drawing.Size(285, 20)
    Me.PasswordTextBox.TabIndex = 0
    Me.PasswordTextBox.UseSystemPasswordChar = True
    '
    'OkButton
    '
    Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.OkButton.Location = New System.Drawing.Point(141, 38)
    Me.OkButton.Name = "OkButton"
    Me.OkButton.Size = New System.Drawing.Size(75, 23)
    Me.OkButton.TabIndex = 1
    Me.OkButton.Text = "Ok"
    Me.OkButton.UseVisualStyleBackColor = True
    '
    'PasswordCancelButton
    '
    Me.PasswordCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.PasswordCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.PasswordCancelButton.Location = New System.Drawing.Point(222, 38)
    Me.PasswordCancelButton.Name = "PasswordCancelButton"
    Me.PasswordCancelButton.Size = New System.Drawing.Size(75, 23)
    Me.PasswordCancelButton.TabIndex = 2
    Me.PasswordCancelButton.Text = "Cancel"
    Me.PasswordCancelButton.UseVisualStyleBackColor = True
    '
    'PasswordForm
    '
    Me.AcceptButton = Me.OkButton
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.PasswordCancelButton
    Me.ClientSize = New System.Drawing.Size(311, 72)
    Me.Controls.Add(Me.PasswordCancelButton)
    Me.Controls.Add(Me.OkButton)
    Me.Controls.Add(Me.PasswordTextBox)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "PasswordForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Password"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
  Friend WithEvents OkButton As System.Windows.Forms.Button
  Friend WithEvents PasswordCancelButton As System.Windows.Forms.Button
End Class
