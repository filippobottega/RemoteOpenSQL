<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemoteOpenSQLGrammarForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RemoteOpenSQLGrammarForm))
    Me.GrammarGroupBox = New System.Windows.Forms.GroupBox()
    Me.GrammarTextBox = New System.Windows.Forms.TextBox()
    Me.GrammarGroupBox.SuspendLayout()
    Me.SuspendLayout()
    '
    'GrammarGroupBox
    '
    Me.GrammarGroupBox.Controls.Add(Me.GrammarTextBox)
    Me.GrammarGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GrammarGroupBox.Location = New System.Drawing.Point(0, 0)
    Me.GrammarGroupBox.Name = "GrammarGroupBox"
    Me.GrammarGroupBox.Size = New System.Drawing.Size(686, 361)
    Me.GrammarGroupBox.TabIndex = 1
    Me.GrammarGroupBox.TabStop = False
    Me.GrammarGroupBox.Text = "Grammar"
    '
    'GrammarTextBox
    '
    Me.GrammarTextBox.BackColor = System.Drawing.SystemColors.Window
    Me.GrammarTextBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GrammarTextBox.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrammarTextBox.Location = New System.Drawing.Point(3, 16)
    Me.GrammarTextBox.Multiline = True
    Me.GrammarTextBox.Name = "GrammarTextBox"
    Me.GrammarTextBox.ReadOnly = True
    Me.GrammarTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.GrammarTextBox.Size = New System.Drawing.Size(680, 342)
    Me.GrammarTextBox.TabIndex = 0
    '
    'RemoteOpenSQLGrammarForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(686, 361)
    Me.Controls.Add(Me.GrammarGroupBox)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "RemoteOpenSQLGrammarForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "RemoteOpenSQL grammar"
    Me.GrammarGroupBox.ResumeLayout(False)
    Me.GrammarGroupBox.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents GrammarGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents GrammarTextBox As System.Windows.Forms.TextBox
End Class
