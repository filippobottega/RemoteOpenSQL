<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsForm))
    Me.OutputFormatGroupBox = New System.Windows.Forms.GroupBox()
    Me.AccessGroupBox = New System.Windows.Forms.GroupBox()
    Me.AccessPathButton = New System.Windows.Forms.Button()
    Me.AccessPathLabel = New System.Windows.Forms.Label()
    Me.AccessPathTextBox = New System.Windows.Forms.TextBox()
    Me.ExcelGroupBox = New System.Windows.Forms.GroupBox()
    Me.ExcelPathButton = New System.Windows.Forms.Button()
    Me.ExcelPathLabel = New System.Windows.Forms.Label()
    Me.ExcelPathTextBox = New System.Windows.Forms.TextBox()
    Me.TextFormatGroupBox = New System.Windows.Forms.GroupBox()
    Me.TextApplicationButton = New System.Windows.Forms.Button()
    Me.TextPathButton = New System.Windows.Forms.Button()
    Me.TextApplicationTextBox = New System.Windows.Forms.TextBox()
    Me.TextApplicationLabel = New System.Windows.Forms.Label()
    Me.TextPathLabel = New System.Windows.Forms.Label()
    Me.TextPathTextBox = New System.Windows.Forms.TextBox()
    Me.QueryOptionsGroupBox = New System.Windows.Forms.GroupBox()
    Me.BufferTextBox = New System.Windows.Forms.TextBox()
    Me.BufferLabel = New System.Windows.Forms.Label()
    Me.PartitionSizeTextBox = New System.Windows.Forms.TextBox()
    Me.PartitionSizeLabel = New System.Windows.Forms.Label()
    Me.OutputFormatGroupBox.SuspendLayout()
    Me.AccessGroupBox.SuspendLayout()
    Me.ExcelGroupBox.SuspendLayout()
    Me.TextFormatGroupBox.SuspendLayout()
    Me.QueryOptionsGroupBox.SuspendLayout()
    Me.SuspendLayout()
    '
    'OutputFormatGroupBox
    '
    Me.OutputFormatGroupBox.Controls.Add(Me.AccessGroupBox)
    Me.OutputFormatGroupBox.Controls.Add(Me.ExcelGroupBox)
    Me.OutputFormatGroupBox.Controls.Add(Me.TextFormatGroupBox)
    Me.OutputFormatGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OutputFormatGroupBox.Location = New System.Drawing.Point(0, 57)
    Me.OutputFormatGroupBox.Name = "OutputFormatGroupBox"
    Me.OutputFormatGroupBox.Size = New System.Drawing.Size(644, 217)
    Me.OutputFormatGroupBox.TabIndex = 5
    Me.OutputFormatGroupBox.TabStop = False
    Me.OutputFormatGroupBox.Text = "Output format"
    '
    'AccessGroupBox
    '
    Me.AccessGroupBox.Controls.Add(Me.AccessPathButton)
    Me.AccessGroupBox.Controls.Add(Me.AccessPathLabel)
    Me.AccessGroupBox.Controls.Add(Me.AccessPathTextBox)
    Me.AccessGroupBox.Dock = System.Windows.Forms.DockStyle.Top
    Me.AccessGroupBox.Location = New System.Drawing.Point(3, 151)
    Me.AccessGroupBox.Name = "AccessGroupBox"
    Me.AccessGroupBox.Size = New System.Drawing.Size(638, 59)
    Me.AccessGroupBox.TabIndex = 11
    Me.AccessGroupBox.TabStop = False
    Me.AccessGroupBox.Text = "Access"
    '
    'AccessPathButton
    '
    Me.AccessPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.AccessPathButton.Image = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.Resources.Resources.application_vnd_ms_access_small
    Me.AccessPathButton.Location = New System.Drawing.Point(537, 19)
    Me.AccessPathButton.Name = "AccessPathButton"
    Me.AccessPathButton.Size = New System.Drawing.Size(29, 23)
    Me.AccessPathButton.TabIndex = 15
    Me.AccessPathButton.UseVisualStyleBackColor = True
    '
    'AccessPathLabel
    '
    Me.AccessPathLabel.AutoSize = True
    Me.AccessPathLabel.Location = New System.Drawing.Point(26, 25)
    Me.AccessPathLabel.Name = "AccessPathLabel"
    Me.AccessPathLabel.Size = New System.Drawing.Size(78, 13)
    Me.AccessPathLabel.TabIndex = 11
    Me.AccessPathLabel.Text = "Database Path"
    '
    'AccessPathTextBox
    '
    Me.AccessPathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.AccessPathTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default, "AccessPathTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.AccessPathTextBox.Location = New System.Drawing.Point(110, 22)
    Me.AccessPathTextBox.Name = "AccessPathTextBox"
    Me.AccessPathTextBox.Size = New System.Drawing.Size(421, 20)
    Me.AccessPathTextBox.TabIndex = 10
    Me.AccessPathTextBox.Text = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default.AccessPathTextBox
    '
    'ExcelGroupBox
    '
    Me.ExcelGroupBox.Controls.Add(Me.ExcelPathButton)
    Me.ExcelGroupBox.Controls.Add(Me.ExcelPathLabel)
    Me.ExcelGroupBox.Controls.Add(Me.ExcelPathTextBox)
    Me.ExcelGroupBox.Dock = System.Windows.Forms.DockStyle.Top
    Me.ExcelGroupBox.Location = New System.Drawing.Point(3, 94)
    Me.ExcelGroupBox.Name = "ExcelGroupBox"
    Me.ExcelGroupBox.Size = New System.Drawing.Size(638, 57)
    Me.ExcelGroupBox.TabIndex = 10
    Me.ExcelGroupBox.TabStop = False
    Me.ExcelGroupBox.Text = "Excel"
    '
    'ExcelPathButton
    '
    Me.ExcelPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ExcelPathButton.Image = CType(resources.GetObject("ExcelPathButton.Image"), System.Drawing.Image)
    Me.ExcelPathButton.Location = New System.Drawing.Point(537, 19)
    Me.ExcelPathButton.Name = "ExcelPathButton"
    Me.ExcelPathButton.Size = New System.Drawing.Size(29, 23)
    Me.ExcelPathButton.TabIndex = 15
    Me.ExcelPathButton.UseVisualStyleBackColor = True
    '
    'ExcelPathLabel
    '
    Me.ExcelPathLabel.AutoSize = True
    Me.ExcelPathLabel.Location = New System.Drawing.Point(75, 24)
    Me.ExcelPathLabel.Name = "ExcelPathLabel"
    Me.ExcelPathLabel.Size = New System.Drawing.Size(29, 13)
    Me.ExcelPathLabel.TabIndex = 12
    Me.ExcelPathLabel.Text = "Path"
    '
    'ExcelPathTextBox
    '
    Me.ExcelPathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ExcelPathTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default, "ExcelPathTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.ExcelPathTextBox.Location = New System.Drawing.Point(110, 21)
    Me.ExcelPathTextBox.Name = "ExcelPathTextBox"
    Me.ExcelPathTextBox.Size = New System.Drawing.Size(421, 20)
    Me.ExcelPathTextBox.TabIndex = 7
    Me.ExcelPathTextBox.Text = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default.ExcelPathTextBox
    '
    'TextFormatGroupBox
    '
    Me.TextFormatGroupBox.Controls.Add(Me.TextApplicationButton)
    Me.TextFormatGroupBox.Controls.Add(Me.TextPathButton)
    Me.TextFormatGroupBox.Controls.Add(Me.TextApplicationTextBox)
    Me.TextFormatGroupBox.Controls.Add(Me.TextApplicationLabel)
    Me.TextFormatGroupBox.Controls.Add(Me.TextPathLabel)
    Me.TextFormatGroupBox.Controls.Add(Me.TextPathTextBox)
    Me.TextFormatGroupBox.Dock = System.Windows.Forms.DockStyle.Top
    Me.TextFormatGroupBox.Location = New System.Drawing.Point(3, 16)
    Me.TextFormatGroupBox.Name = "TextFormatGroupBox"
    Me.TextFormatGroupBox.Size = New System.Drawing.Size(638, 78)
    Me.TextFormatGroupBox.TabIndex = 9
    Me.TextFormatGroupBox.TabStop = False
    Me.TextFormatGroupBox.Text = "Text"
    '
    'TextApplicationButton
    '
    Me.TextApplicationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TextApplicationButton.Image = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.Resources.Resources.TextEdit_app_small
    Me.TextApplicationButton.Location = New System.Drawing.Point(537, 42)
    Me.TextApplicationButton.Name = "TextApplicationButton"
    Me.TextApplicationButton.Size = New System.Drawing.Size(29, 23)
    Me.TextApplicationButton.TabIndex = 15
    Me.TextApplicationButton.UseVisualStyleBackColor = True
    '
    'TextPathButton
    '
    Me.TextPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TextPathButton.Image = CType(resources.GetObject("TextPathButton.Image"), System.Drawing.Image)
    Me.TextPathButton.Location = New System.Drawing.Point(537, 17)
    Me.TextPathButton.Name = "TextPathButton"
    Me.TextPathButton.Size = New System.Drawing.Size(29, 23)
    Me.TextPathButton.TabIndex = 14
    Me.TextPathButton.UseVisualStyleBackColor = True
    '
    'TextApplicationTextBox
    '
    Me.TextApplicationTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TextApplicationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default, "TextApplicationTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.TextApplicationTextBox.Location = New System.Drawing.Point(110, 45)
    Me.TextApplicationTextBox.Name = "TextApplicationTextBox"
    Me.TextApplicationTextBox.Size = New System.Drawing.Size(421, 20)
    Me.TextApplicationTextBox.TabIndex = 13
    Me.TextApplicationTextBox.Text = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default.TextApplicationTextBox
    '
    'TextApplicationLabel
    '
    Me.TextApplicationLabel.AutoSize = True
    Me.TextApplicationLabel.Location = New System.Drawing.Point(8, 47)
    Me.TextApplicationLabel.Name = "TextApplicationLabel"
    Me.TextApplicationLabel.Size = New System.Drawing.Size(96, 13)
    Me.TextApplicationLabel.TabIndex = 12
    Me.TextApplicationLabel.Text = "Default Application"
    '
    'TextPathLabel
    '
    Me.TextPathLabel.AutoSize = True
    Me.TextPathLabel.Location = New System.Drawing.Point(75, 22)
    Me.TextPathLabel.Name = "TextPathLabel"
    Me.TextPathLabel.Size = New System.Drawing.Size(29, 13)
    Me.TextPathLabel.TabIndex = 11
    Me.TextPathLabel.Text = "Path"
    '
    'TextPathTextBox
    '
    Me.TextPathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TextPathTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default, "TextPathTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.TextPathTextBox.Location = New System.Drawing.Point(110, 19)
    Me.TextPathTextBox.Name = "TextPathTextBox"
    Me.TextPathTextBox.Size = New System.Drawing.Size(421, 20)
    Me.TextPathTextBox.TabIndex = 10
    Me.TextPathTextBox.Text = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default.TextPathTextBox
    '
    'QueryOptionsGroupBox
    '
    Me.QueryOptionsGroupBox.Controls.Add(Me.BufferTextBox)
    Me.QueryOptionsGroupBox.Controls.Add(Me.BufferLabel)
    Me.QueryOptionsGroupBox.Controls.Add(Me.PartitionSizeTextBox)
    Me.QueryOptionsGroupBox.Controls.Add(Me.PartitionSizeLabel)
    Me.QueryOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top
    Me.QueryOptionsGroupBox.Location = New System.Drawing.Point(0, 0)
    Me.QueryOptionsGroupBox.Name = "QueryOptionsGroupBox"
    Me.QueryOptionsGroupBox.Size = New System.Drawing.Size(644, 57)
    Me.QueryOptionsGroupBox.TabIndex = 6
    Me.QueryOptionsGroupBox.TabStop = False
    Me.QueryOptionsGroupBox.Text = "Query Options"
    '
    'BufferTextBox
    '
    Me.BufferTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default, "BufferTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.BufferTextBox.Location = New System.Drawing.Point(555, 23)
    Me.BufferTextBox.Name = "BufferTextBox"
    Me.BufferTextBox.Size = New System.Drawing.Size(45, 20)
    Me.BufferTextBox.TabIndex = 3
    Me.BufferTextBox.Text = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default.BufferTextBox
    '
    'BufferLabel
    '
    Me.BufferLabel.AutoSize = True
    Me.BufferLabel.Location = New System.Drawing.Point(369, 26)
    Me.BufferLabel.Name = "BufferLabel"
    Me.BufferLabel.Size = New System.Drawing.Size(180, 13)
    Me.BufferLabel.TabIndex = 2
    Me.BufferLabel.Text = "Buffer (MB) (Max. 1000, Default 100)"
    '
    'PartitionSizeTextBox
    '
    Me.PartitionSizeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default, "PartitionSizeTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.PartitionSizeTextBox.Location = New System.Drawing.Point(232, 23)
    Me.PartitionSizeTextBox.Name = "PartitionSizeTextBox"
    Me.PartitionSizeTextBox.Size = New System.Drawing.Size(100, 20)
    Me.PartitionSizeTextBox.TabIndex = 1
    Me.PartitionSizeTextBox.Text = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default.PartitionSizeTextBox
    '
    'PartitionSizeLabel
    '
    Me.PartitionSizeLabel.AutoSize = True
    Me.PartitionSizeLabel.Location = New System.Drawing.Point(8, 26)
    Me.PartitionSizeLabel.Name = "PartitionSizeLabel"
    Me.PartitionSizeLabel.Size = New System.Drawing.Size(218, 13)
    Me.PartitionSizeLabel.TabIndex = 0
    Me.PartitionSizeLabel.Text = "Partition Size (Max. 2000000, Default 50000)"
    '
    'OptionsForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(644, 274)
    Me.Controls.Add(Me.OutputFormatGroupBox)
    Me.Controls.Add(Me.QueryOptionsGroupBox)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MinimumSize = New System.Drawing.Size(660, 312)
    Me.Name = "OptionsForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Options"
    Me.OutputFormatGroupBox.ResumeLayout(False)
    Me.AccessGroupBox.ResumeLayout(False)
    Me.AccessGroupBox.PerformLayout()
    Me.ExcelGroupBox.ResumeLayout(False)
    Me.ExcelGroupBox.PerformLayout()
    Me.TextFormatGroupBox.ResumeLayout(False)
    Me.TextFormatGroupBox.PerformLayout()
    Me.QueryOptionsGroupBox.ResumeLayout(False)
    Me.QueryOptionsGroupBox.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents OutputFormatGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents AccessGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents AccessPathButton As System.Windows.Forms.Button
  Friend WithEvents AccessPathLabel As System.Windows.Forms.Label
  Friend WithEvents AccessPathTextBox As System.Windows.Forms.TextBox
  Friend WithEvents ExcelGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents ExcelPathButton As System.Windows.Forms.Button
  Friend WithEvents ExcelPathLabel As System.Windows.Forms.Label
  Friend WithEvents ExcelPathTextBox As System.Windows.Forms.TextBox
  Friend WithEvents TextFormatGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents TextApplicationButton As System.Windows.Forms.Button
  Friend WithEvents TextPathButton As System.Windows.Forms.Button
  Friend WithEvents TextApplicationTextBox As System.Windows.Forms.TextBox
  Friend WithEvents TextApplicationLabel As System.Windows.Forms.Label
  Friend WithEvents TextPathLabel As System.Windows.Forms.Label
  Friend WithEvents TextPathTextBox As System.Windows.Forms.TextBox
  Friend WithEvents QueryOptionsGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents BufferTextBox As System.Windows.Forms.TextBox
  Friend WithEvents BufferLabel As System.Windows.Forms.Label
  Friend WithEvents PartitionSizeTextBox As System.Windows.Forms.TextBox
  Friend WithEvents PartitionSizeLabel As System.Windows.Forms.Label
End Class
