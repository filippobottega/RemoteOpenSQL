<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
    Me.MainTabControl = New System.Windows.Forms.TabControl()
    Me.LogonTabPage = New System.Windows.Forms.TabPage()
    Me.DestinationsSplitContainer = New System.Windows.Forms.SplitContainer()
    Me.DestinationTreeView = New System.Windows.Forms.TreeView()
    Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
    Me.SapRouterStringLabel = New System.Windows.Forms.Label()
    Me.PasswordLabel = New System.Windows.Forms.Label()
    Me.UsernameLabel = New System.Windows.Forms.Label()
    Me.ClientLabel = New System.Windows.Forms.Label()
    Me.SystemNumberLabel = New System.Windows.Forms.Label()
    Me.AppServerHostLabel = New System.Windows.Forms.Label()
    Me.DescriptionLabel = New System.Windows.Forms.Label()
    Me.DestinationSapRouterString = New System.Windows.Forms.TextBox()
    Me.DestinationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.RemoteOpenSQLDestinations = New RemoteOpenSQLManager.RemoteOpenSQLDestinations()
    Me.DestinationPassword = New System.Windows.Forms.TextBox()
    Me.DestinationUsername = New System.Windows.Forms.TextBox()
    Me.DestinationClient = New System.Windows.Forms.TextBox()
    Me.DestinationSystemNumber = New System.Windows.Forms.TextBox()
    Me.DestinationAppServerHost = New System.Windows.Forms.TextBox()
    Me.DestinationDescription = New System.Windows.Forms.TextBox()
    Me.DestinationToolStrip = New System.Windows.Forms.ToolStrip()
    Me.DestinationNewFolderToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.DestinationNewToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.DestinationDeleteToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.ABAPTabPage = New System.Windows.Forms.TabPage()
    Me.AbapCodeTextBox = New System.Windows.Forms.TextBox()
    Me.OptionsTabPage = New System.Windows.Forms.TabPage()
    Me.OutputFormatGroupBox = New System.Windows.Forms.GroupBox()
    Me.AccessGroupBox = New System.Windows.Forms.GroupBox()
    Me.AccessPathButton = New System.Windows.Forms.Button()
    Me.AccessPathLabel = New System.Windows.Forms.Label()
    Me.AccessPathTextBox = New System.Windows.Forms.TextBox()
    Me.AccessRadioButton = New System.Windows.Forms.RadioButton()
    Me.ExcelGroupBox = New System.Windows.Forms.GroupBox()
    Me.ExcelPathButton = New System.Windows.Forms.Button()
    Me.ExcelPathLabel = New System.Windows.Forms.Label()
    Me.ExcelPathTextBox = New System.Windows.Forms.TextBox()
    Me.ExcelRadioButton = New System.Windows.Forms.RadioButton()
    Me.TextFormatGroupBox = New System.Windows.Forms.GroupBox()
    Me.TextRadioButton = New System.Windows.Forms.RadioButton()
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
    Me.GrammarTabPage = New System.Windows.Forms.TabPage()
    Me.GrammarGroupBox = New System.Windows.Forms.GroupBox()
    Me.GrammarTextBox = New System.Windows.Forms.TextBox()
    Me.QueriesTabPage = New System.Windows.Forms.TabPage()
    Me.QueriesSplitContainer = New System.Windows.Forms.SplitContainer()
    Me.QueryTreeView = New System.Windows.Forms.TreeView()
    Me.QuerySplitContainer = New System.Windows.Forms.SplitContainer()
    Me.QueryGroupBox = New System.Windows.Forms.GroupBox()
    Me.QueryTextBox = New System.Windows.Forms.TextBox()
    Me.QueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.RemoteOpenSQLQueries = New RemoteOpenSQLManager.RemoteOpenSQLQueries()
    Me.OutputGroupBox = New System.Windows.Forms.GroupBox()
    Me.OutputTextBox = New System.Windows.Forms.TextBox()
    Me.QueryDescriptionGroupBox = New System.Windows.Forms.GroupBox()
    Me.QueryDescriptionTextBox = New System.Windows.Forms.TextBox()
    Me.QueryStatusStrip = New System.Windows.Forms.StatusStrip()
    Me.QueryToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
    Me.QueryToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
    Me.QueriesToolStrip = New System.Windows.Forms.ToolStrip()
    Me.QueryNewFolderToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.QueryNewToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.QueryDeleteToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.QueryToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.QueryStartToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.QueryStopToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.QueryToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.QueryQuickOpenToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.QueryToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
    Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
    Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
    Me.QueryTimer = New System.Windows.Forms.Timer(Me.components)
    Me.DestinationGroupBox = New System.Windows.Forms.GroupBox()
    Me.MainTabControl.SuspendLayout()
    Me.LogonTabPage.SuspendLayout()
    CType(Me.DestinationsSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.DestinationsSplitContainer.Panel1.SuspendLayout()
    Me.DestinationsSplitContainer.Panel2.SuspendLayout()
    Me.DestinationsSplitContainer.SuspendLayout()
    CType(Me.DestinationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.RemoteOpenSQLDestinations, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.DestinationToolStrip.SuspendLayout()
    Me.ABAPTabPage.SuspendLayout()
    Me.OptionsTabPage.SuspendLayout()
    Me.OutputFormatGroupBox.SuspendLayout()
    Me.AccessGroupBox.SuspendLayout()
    Me.ExcelGroupBox.SuspendLayout()
    Me.TextFormatGroupBox.SuspendLayout()
    Me.QueryOptionsGroupBox.SuspendLayout()
    Me.GrammarTabPage.SuspendLayout()
    Me.GrammarGroupBox.SuspendLayout()
    Me.QueriesTabPage.SuspendLayout()
    CType(Me.QueriesSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.QueriesSplitContainer.Panel1.SuspendLayout()
    Me.QueriesSplitContainer.Panel2.SuspendLayout()
    Me.QueriesSplitContainer.SuspendLayout()
    CType(Me.QuerySplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.QuerySplitContainer.Panel1.SuspendLayout()
    Me.QuerySplitContainer.Panel2.SuspendLayout()
    Me.QuerySplitContainer.SuspendLayout()
    Me.QueryGroupBox.SuspendLayout()
    CType(Me.QueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.RemoteOpenSQLQueries, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.OutputGroupBox.SuspendLayout()
    Me.QueryDescriptionGroupBox.SuspendLayout()
    Me.QueryStatusStrip.SuspendLayout()
    Me.QueriesToolStrip.SuspendLayout()
    Me.DestinationGroupBox.SuspendLayout()
    Me.SuspendLayout()
    '
    'MainTabControl
    '
    Me.MainTabControl.Controls.Add(Me.LogonTabPage)
    Me.MainTabControl.Controls.Add(Me.ABAPTabPage)
    Me.MainTabControl.Controls.Add(Me.OptionsTabPage)
    Me.MainTabControl.Controls.Add(Me.GrammarTabPage)
    Me.MainTabControl.Controls.Add(Me.QueriesTabPage)
    Me.MainTabControl.DataBindings.Add(New System.Windows.Forms.Binding("SelectedIndex", Global.RemoteOpenSQLManager.My.MySettings.Default, "MainTabControl", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
    Me.MainTabControl.Location = New System.Drawing.Point(0, 0)
    Me.MainTabControl.Name = "MainTabControl"
    Me.MainTabControl.SelectedIndex = Global.RemoteOpenSQLManager.My.MySettings.Default.MainTabControl
    Me.MainTabControl.Size = New System.Drawing.Size(884, 389)
    Me.MainTabControl.TabIndex = 0
    '
    'LogonTabPage
    '
    Me.LogonTabPage.Controls.Add(Me.DestinationsSplitContainer)
    Me.LogonTabPage.Controls.Add(Me.DestinationToolStrip)
    Me.LogonTabPage.Location = New System.Drawing.Point(4, 22)
    Me.LogonTabPage.Name = "LogonTabPage"
    Me.LogonTabPage.Padding = New System.Windows.Forms.Padding(3)
    Me.LogonTabPage.Size = New System.Drawing.Size(876, 363)
    Me.LogonTabPage.TabIndex = 0
    Me.LogonTabPage.Text = "Logon parameters"
    Me.LogonTabPage.UseVisualStyleBackColor = True
    '
    'DestinationsSplitContainer
    '
    Me.DestinationsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DestinationsSplitContainer.Location = New System.Drawing.Point(3, 42)
    Me.DestinationsSplitContainer.Name = "DestinationsSplitContainer"
    '
    'DestinationsSplitContainer.Panel1
    '
    Me.DestinationsSplitContainer.Panel1.Controls.Add(Me.DestinationTreeView)
    '
    'DestinationsSplitContainer.Panel2
    '
    Me.DestinationsSplitContainer.Panel2.Controls.Add(Me.DestinationGroupBox)
    Me.DestinationsSplitContainer.Size = New System.Drawing.Size(870, 318)
    Me.DestinationsSplitContainer.SplitterDistance = 242
    Me.DestinationsSplitContainer.TabIndex = 0
    '
    'DestinationTreeView
    '
    Me.DestinationTreeView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DestinationTreeView.ImageIndex = 0
    Me.DestinationTreeView.ImageList = Me.ImageList
    Me.DestinationTreeView.LabelEdit = True
    Me.DestinationTreeView.Location = New System.Drawing.Point(0, 0)
    Me.DestinationTreeView.Name = "DestinationTreeView"
    Me.DestinationTreeView.SelectedImageIndex = 0
    Me.DestinationTreeView.Size = New System.Drawing.Size(242, 318)
    Me.DestinationTreeView.TabIndex = 1
    '
    'ImageList
    '
    Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList.Images.SetKeyName(0, "folder-yellow.png")
    Me.ImageList.Images.SetKeyName(1, "kaddressbook-4.png")
    '
    'SapRouterStringLabel
    '
    Me.SapRouterStringLabel.AutoSize = True
    Me.SapRouterStringLabel.Location = New System.Drawing.Point(13, 186)
    Me.SapRouterStringLabel.Name = "SapRouterStringLabel"
    Me.SapRouterStringLabel.Size = New System.Drawing.Size(91, 13)
    Me.SapRouterStringLabel.TabIndex = 13
    Me.SapRouterStringLabel.Text = "Sap Router String"
    '
    'PasswordLabel
    '
    Me.PasswordLabel.AutoSize = True
    Me.PasswordLabel.Location = New System.Drawing.Point(51, 160)
    Me.PasswordLabel.Name = "PasswordLabel"
    Me.PasswordLabel.Size = New System.Drawing.Size(53, 13)
    Me.PasswordLabel.TabIndex = 12
    Me.PasswordLabel.Text = "Password"
    '
    'UsernameLabel
    '
    Me.UsernameLabel.AutoSize = True
    Me.UsernameLabel.Location = New System.Drawing.Point(49, 134)
    Me.UsernameLabel.Name = "UsernameLabel"
    Me.UsernameLabel.Size = New System.Drawing.Size(55, 13)
    Me.UsernameLabel.TabIndex = 11
    Me.UsernameLabel.Text = "Username"
    '
    'ClientLabel
    '
    Me.ClientLabel.AutoSize = True
    Me.ClientLabel.Location = New System.Drawing.Point(71, 108)
    Me.ClientLabel.Name = "ClientLabel"
    Me.ClientLabel.Size = New System.Drawing.Size(33, 13)
    Me.ClientLabel.TabIndex = 10
    Me.ClientLabel.Text = "Client"
    '
    'SystemNumberLabel
    '
    Me.SystemNumberLabel.AutoSize = True
    Me.SystemNumberLabel.Location = New System.Drawing.Point(23, 82)
    Me.SystemNumberLabel.Name = "SystemNumberLabel"
    Me.SystemNumberLabel.Size = New System.Drawing.Size(81, 13)
    Me.SystemNumberLabel.TabIndex = 9
    Me.SystemNumberLabel.Text = "System Number"
    '
    'AppServerHostLabel
    '
    Me.AppServerHostLabel.AutoSize = True
    Me.AppServerHostLabel.Location = New System.Drawing.Point(41, 56)
    Me.AppServerHostLabel.Name = "AppServerHostLabel"
    Me.AppServerHostLabel.Size = New System.Drawing.Size(63, 13)
    Me.AppServerHostLabel.TabIndex = 8
    Me.AppServerHostLabel.Text = "Server Host"
    '
    'DescriptionLabel
    '
    Me.DescriptionLabel.AutoSize = True
    Me.DescriptionLabel.Location = New System.Drawing.Point(44, 30)
    Me.DescriptionLabel.Name = "DescriptionLabel"
    Me.DescriptionLabel.Size = New System.Drawing.Size(60, 13)
    Me.DescriptionLabel.TabIndex = 7
    Me.DescriptionLabel.Text = "Description"
    '
    'DestinationSapRouterString
    '
    Me.DestinationSapRouterString.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "SAPRouterString", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.DestinationSapRouterString.Location = New System.Drawing.Point(110, 183)
    Me.DestinationSapRouterString.Name = "DestinationSapRouterString"
    Me.DestinationSapRouterString.Size = New System.Drawing.Size(338, 20)
    Me.DestinationSapRouterString.TabIndex = 6
    '
    'DestinationBindingSource
    '
    Me.DestinationBindingSource.DataMember = "Destination"
    Me.DestinationBindingSource.DataSource = Me.RemoteOpenSQLDestinations
    '
    'RemoteOpenSQLDestinations
    '
    Me.RemoteOpenSQLDestinations.DataSetName = "RemoteOpenSQLDestinations"
    Me.RemoteOpenSQLDestinations.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
    '
    'DestinationPassword
    '
    Me.DestinationPassword.Location = New System.Drawing.Point(110, 157)
    Me.DestinationPassword.Name = "DestinationPassword"
    Me.DestinationPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.DestinationPassword.Size = New System.Drawing.Size(100, 20)
    Me.DestinationPassword.TabIndex = 5
    Me.DestinationPassword.UseSystemPasswordChar = True
    '
    'DestinationUsername
    '
    Me.DestinationUsername.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "Username", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.DestinationUsername.Location = New System.Drawing.Point(110, 131)
    Me.DestinationUsername.Name = "DestinationUsername"
    Me.DestinationUsername.Size = New System.Drawing.Size(100, 20)
    Me.DestinationUsername.TabIndex = 4
    '
    'DestinationClient
    '
    Me.DestinationClient.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "Client", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"))
    Me.DestinationClient.Location = New System.Drawing.Point(110, 105)
    Me.DestinationClient.MaxLength = 3
    Me.DestinationClient.Name = "DestinationClient"
    Me.DestinationClient.Size = New System.Drawing.Size(39, 20)
    Me.DestinationClient.TabIndex = 3
    '
    'DestinationSystemNumber
    '
    Me.DestinationSystemNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "SystemNumber", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"))
    Me.DestinationSystemNumber.Location = New System.Drawing.Point(110, 79)
    Me.DestinationSystemNumber.MaxLength = 2
    Me.DestinationSystemNumber.Name = "DestinationSystemNumber"
    Me.DestinationSystemNumber.Size = New System.Drawing.Size(39, 20)
    Me.DestinationSystemNumber.TabIndex = 2
    '
    'DestinationAppServerHost
    '
    Me.DestinationAppServerHost.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "AppServerHost", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.DestinationAppServerHost.Location = New System.Drawing.Point(110, 53)
    Me.DestinationAppServerHost.Name = "DestinationAppServerHost"
    Me.DestinationAppServerHost.Size = New System.Drawing.Size(338, 20)
    Me.DestinationAppServerHost.TabIndex = 1
    '
    'DestinationDescription
    '
    Me.DestinationDescription.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.DestinationBindingSource, "Description", True))
    Me.DestinationDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "Description", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.DestinationDescription.Location = New System.Drawing.Point(110, 27)
    Me.DestinationDescription.Name = "DestinationDescription"
    Me.DestinationDescription.Size = New System.Drawing.Size(338, 20)
    Me.DestinationDescription.TabIndex = 0
    '
    'DestinationToolStrip
    '
    Me.DestinationToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
    Me.DestinationToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DestinationNewFolderToolStripButton, Me.DestinationNewToolStripButton, Me.DestinationDeleteToolStripButton, Me.ToolStripSeparator3})
    Me.DestinationToolStrip.Location = New System.Drawing.Point(3, 3)
    Me.DestinationToolStrip.Name = "DestinationToolStrip"
    Me.DestinationToolStrip.Size = New System.Drawing.Size(870, 39)
    Me.DestinationToolStrip.TabIndex = 14
    Me.DestinationToolStrip.Text = "ToolStrip1"
    '
    'DestinationNewFolderToolStripButton
    '
    Me.DestinationNewFolderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.DestinationNewFolderToolStripButton.Image = Global.RemoteOpenSQLManager.My.Resources.Resources.folder_new_8
    Me.DestinationNewFolderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.DestinationNewFolderToolStripButton.Name = "DestinationNewFolderToolStripButton"
    Me.DestinationNewFolderToolStripButton.Size = New System.Drawing.Size(36, 36)
    Me.DestinationNewFolderToolStripButton.Text = "Add New Folder"
    '
    'DestinationNewToolStripButton
    '
    Me.DestinationNewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.DestinationNewToolStripButton.Image = Global.RemoteOpenSQLManager.My.Resources.Resources.address_book_new_4
    Me.DestinationNewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.DestinationNewToolStripButton.Name = "DestinationNewToolStripButton"
    Me.DestinationNewToolStripButton.Size = New System.Drawing.Size(36, 36)
    Me.DestinationNewToolStripButton.Text = "Add New Destination"
    '
    'DestinationDeleteToolStripButton
    '
    Me.DestinationDeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.DestinationDeleteToolStripButton.Image = Global.RemoteOpenSQLManager.My.Resources.Resources.edit_delete_6
    Me.DestinationDeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.DestinationDeleteToolStripButton.Name = "DestinationDeleteToolStripButton"
    Me.DestinationDeleteToolStripButton.Size = New System.Drawing.Size(36, 36)
    Me.DestinationDeleteToolStripButton.Text = "Delete Folder or Destination"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
    '
    'ABAPTabPage
    '
    Me.ABAPTabPage.Controls.Add(Me.AbapCodeTextBox)
    Me.ABAPTabPage.Location = New System.Drawing.Point(4, 22)
    Me.ABAPTabPage.Name = "ABAPTabPage"
    Me.ABAPTabPage.Padding = New System.Windows.Forms.Padding(3)
    Me.ABAPTabPage.Size = New System.Drawing.Size(876, 363)
    Me.ABAPTabPage.TabIndex = 2
    Me.ABAPTabPage.Text = "Abap Code To Install"
    Me.ABAPTabPage.UseVisualStyleBackColor = True
    '
    'AbapCodeTextBox
    '
    Me.AbapCodeTextBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.AbapCodeTextBox.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.AbapCodeTextBox.Location = New System.Drawing.Point(3, 3)
    Me.AbapCodeTextBox.Multiline = True
    Me.AbapCodeTextBox.Name = "AbapCodeTextBox"
    Me.AbapCodeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.AbapCodeTextBox.Size = New System.Drawing.Size(870, 357)
    Me.AbapCodeTextBox.TabIndex = 0
    Me.AbapCodeTextBox.WordWrap = False
    '
    'OptionsTabPage
    '
    Me.OptionsTabPage.Controls.Add(Me.OutputFormatGroupBox)
    Me.OptionsTabPage.Controls.Add(Me.QueryOptionsGroupBox)
    Me.OptionsTabPage.Location = New System.Drawing.Point(4, 22)
    Me.OptionsTabPage.Name = "OptionsTabPage"
    Me.OptionsTabPage.Padding = New System.Windows.Forms.Padding(3)
    Me.OptionsTabPage.Size = New System.Drawing.Size(876, 363)
    Me.OptionsTabPage.TabIndex = 3
    Me.OptionsTabPage.Text = "Options"
    Me.OptionsTabPage.UseVisualStyleBackColor = True
    '
    'OutputFormatGroupBox
    '
    Me.OutputFormatGroupBox.Controls.Add(Me.AccessGroupBox)
    Me.OutputFormatGroupBox.Controls.Add(Me.ExcelGroupBox)
    Me.OutputFormatGroupBox.Controls.Add(Me.TextFormatGroupBox)
    Me.OutputFormatGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OutputFormatGroupBox.Location = New System.Drawing.Point(3, 60)
    Me.OutputFormatGroupBox.Name = "OutputFormatGroupBox"
    Me.OutputFormatGroupBox.Size = New System.Drawing.Size(870, 300)
    Me.OutputFormatGroupBox.TabIndex = 3
    Me.OutputFormatGroupBox.TabStop = False
    Me.OutputFormatGroupBox.Text = "Output format"
    '
    'AccessGroupBox
    '
    Me.AccessGroupBox.Controls.Add(Me.AccessPathButton)
    Me.AccessGroupBox.Controls.Add(Me.AccessPathLabel)
    Me.AccessGroupBox.Controls.Add(Me.AccessPathTextBox)
    Me.AccessGroupBox.Controls.Add(Me.AccessRadioButton)
    Me.AccessGroupBox.Dock = System.Windows.Forms.DockStyle.Top
    Me.AccessGroupBox.Location = New System.Drawing.Point(3, 167)
    Me.AccessGroupBox.Name = "AccessGroupBox"
    Me.AccessGroupBox.Size = New System.Drawing.Size(864, 73)
    Me.AccessGroupBox.TabIndex = 11
    Me.AccessGroupBox.TabStop = False
    Me.AccessGroupBox.Text = "Access"
    '
    'AccessPathButton
    '
    Me.AccessPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.AccessPathButton.Image = Global.RemoteOpenSQLManager.My.Resources.Resources.application_vnd_ms_access_small
    Me.AccessPathButton.Location = New System.Drawing.Point(829, 30)
    Me.AccessPathButton.Name = "AccessPathButton"
    Me.AccessPathButton.Size = New System.Drawing.Size(29, 23)
    Me.AccessPathButton.TabIndex = 15
    Me.AccessPathButton.UseVisualStyleBackColor = True
    '
    'AccessPathLabel
    '
    Me.AccessPathLabel.AutoSize = True
    Me.AccessPathLabel.Location = New System.Drawing.Point(92, 36)
    Me.AccessPathLabel.Name = "AccessPathLabel"
    Me.AccessPathLabel.Size = New System.Drawing.Size(78, 13)
    Me.AccessPathLabel.TabIndex = 11
    Me.AccessPathLabel.Text = "Database Path"
    '
    'AccessPathTextBox
    '
    Me.AccessPathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.AccessPathTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQLManager.My.MySettings.Default, "AccessPathTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.AccessPathTextBox.Location = New System.Drawing.Point(176, 33)
    Me.AccessPathTextBox.Name = "AccessPathTextBox"
    Me.AccessPathTextBox.Size = New System.Drawing.Size(647, 20)
    Me.AccessPathTextBox.TabIndex = 10
    Me.AccessPathTextBox.Text = Global.RemoteOpenSQLManager.My.MySettings.Default.AccessPathTextBox
    '
    'AccessRadioButton
    '
    Me.AccessRadioButton.Image = CType(resources.GetObject("AccessRadioButton.Image"), System.Drawing.Image)
    Me.AccessRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.AccessRadioButton.Location = New System.Drawing.Point(7, 17)
    Me.AccessRadioButton.Name = "AccessRadioButton"
    Me.AccessRadioButton.Size = New System.Drawing.Size(59, 50)
    Me.AccessRadioButton.TabIndex = 9
    Me.AccessRadioButton.TabStop = True
    Me.AccessRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.AccessRadioButton.UseVisualStyleBackColor = True
    '
    'ExcelGroupBox
    '
    Me.ExcelGroupBox.Controls.Add(Me.ExcelPathButton)
    Me.ExcelGroupBox.Controls.Add(Me.ExcelPathLabel)
    Me.ExcelGroupBox.Controls.Add(Me.ExcelPathTextBox)
    Me.ExcelGroupBox.Controls.Add(Me.ExcelRadioButton)
    Me.ExcelGroupBox.Dock = System.Windows.Forms.DockStyle.Top
    Me.ExcelGroupBox.Location = New System.Drawing.Point(3, 94)
    Me.ExcelGroupBox.Name = "ExcelGroupBox"
    Me.ExcelGroupBox.Size = New System.Drawing.Size(864, 73)
    Me.ExcelGroupBox.TabIndex = 10
    Me.ExcelGroupBox.TabStop = False
    Me.ExcelGroupBox.Text = "Excel"
    '
    'ExcelPathButton
    '
    Me.ExcelPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ExcelPathButton.Image = CType(resources.GetObject("ExcelPathButton.Image"), System.Drawing.Image)
    Me.ExcelPathButton.Location = New System.Drawing.Point(829, 26)
    Me.ExcelPathButton.Name = "ExcelPathButton"
    Me.ExcelPathButton.Size = New System.Drawing.Size(29, 23)
    Me.ExcelPathButton.TabIndex = 15
    Me.ExcelPathButton.UseVisualStyleBackColor = True
    '
    'ExcelPathLabel
    '
    Me.ExcelPathLabel.AutoSize = True
    Me.ExcelPathLabel.Location = New System.Drawing.Point(141, 31)
    Me.ExcelPathLabel.Name = "ExcelPathLabel"
    Me.ExcelPathLabel.Size = New System.Drawing.Size(29, 13)
    Me.ExcelPathLabel.TabIndex = 12
    Me.ExcelPathLabel.Text = "Path"
    '
    'ExcelPathTextBox
    '
    Me.ExcelPathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ExcelPathTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQLManager.My.MySettings.Default, "ExcelPathTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.ExcelPathTextBox.Location = New System.Drawing.Point(176, 28)
    Me.ExcelPathTextBox.Name = "ExcelPathTextBox"
    Me.ExcelPathTextBox.Size = New System.Drawing.Size(647, 20)
    Me.ExcelPathTextBox.TabIndex = 7
    Me.ExcelPathTextBox.Text = Global.RemoteOpenSQLManager.My.MySettings.Default.ExcelPathTextBox
    '
    'ExcelRadioButton
    '
    Me.ExcelRadioButton.Image = CType(resources.GetObject("ExcelRadioButton.Image"), System.Drawing.Image)
    Me.ExcelRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.ExcelRadioButton.Location = New System.Drawing.Point(7, 12)
    Me.ExcelRadioButton.Name = "ExcelRadioButton"
    Me.ExcelRadioButton.Size = New System.Drawing.Size(59, 50)
    Me.ExcelRadioButton.TabIndex = 6
    Me.ExcelRadioButton.TabStop = True
    Me.ExcelRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.ExcelRadioButton.UseVisualStyleBackColor = True
    '
    'TextFormatGroupBox
    '
    Me.TextFormatGroupBox.Controls.Add(Me.TextRadioButton)
    Me.TextFormatGroupBox.Controls.Add(Me.TextApplicationButton)
    Me.TextFormatGroupBox.Controls.Add(Me.TextPathButton)
    Me.TextFormatGroupBox.Controls.Add(Me.TextApplicationTextBox)
    Me.TextFormatGroupBox.Controls.Add(Me.TextApplicationLabel)
    Me.TextFormatGroupBox.Controls.Add(Me.TextPathLabel)
    Me.TextFormatGroupBox.Controls.Add(Me.TextPathTextBox)
    Me.TextFormatGroupBox.Dock = System.Windows.Forms.DockStyle.Top
    Me.TextFormatGroupBox.Location = New System.Drawing.Point(3, 16)
    Me.TextFormatGroupBox.Name = "TextFormatGroupBox"
    Me.TextFormatGroupBox.Size = New System.Drawing.Size(864, 78)
    Me.TextFormatGroupBox.TabIndex = 9
    Me.TextFormatGroupBox.TabStop = False
    Me.TextFormatGroupBox.Text = "Text"
    '
    'TextRadioButton
    '
    Me.TextRadioButton.Checked = True
    Me.TextRadioButton.Image = CType(resources.GetObject("TextRadioButton.Image"), System.Drawing.Image)
    Me.TextRadioButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.TextRadioButton.Location = New System.Drawing.Point(8, 15)
    Me.TextRadioButton.Name = "TextRadioButton"
    Me.TextRadioButton.Size = New System.Drawing.Size(58, 50)
    Me.TextRadioButton.TabIndex = 9
    Me.TextRadioButton.TabStop = True
    Me.TextRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.TextRadioButton.UseVisualStyleBackColor = True
    '
    'TextApplicationButton
    '
    Me.TextApplicationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TextApplicationButton.Image = Global.RemoteOpenSQLManager.My.Resources.Resources.TextEdit_app_small
    Me.TextApplicationButton.Location = New System.Drawing.Point(829, 42)
    Me.TextApplicationButton.Name = "TextApplicationButton"
    Me.TextApplicationButton.Size = New System.Drawing.Size(29, 23)
    Me.TextApplicationButton.TabIndex = 15
    Me.TextApplicationButton.UseVisualStyleBackColor = True
    '
    'TextPathButton
    '
    Me.TextPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TextPathButton.Image = CType(resources.GetObject("TextPathButton.Image"), System.Drawing.Image)
    Me.TextPathButton.Location = New System.Drawing.Point(829, 17)
    Me.TextPathButton.Name = "TextPathButton"
    Me.TextPathButton.Size = New System.Drawing.Size(29, 23)
    Me.TextPathButton.TabIndex = 14
    Me.TextPathButton.UseVisualStyleBackColor = True
    '
    'TextApplicationTextBox
    '
    Me.TextApplicationTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TextApplicationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQLManager.My.MySettings.Default, "TextApplicationTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.TextApplicationTextBox.Location = New System.Drawing.Point(176, 45)
    Me.TextApplicationTextBox.Name = "TextApplicationTextBox"
    Me.TextApplicationTextBox.Size = New System.Drawing.Size(647, 20)
    Me.TextApplicationTextBox.TabIndex = 13
    Me.TextApplicationTextBox.Text = Global.RemoteOpenSQLManager.My.MySettings.Default.TextApplicationTextBox
    '
    'TextApplicationLabel
    '
    Me.TextApplicationLabel.AutoSize = True
    Me.TextApplicationLabel.Location = New System.Drawing.Point(74, 47)
    Me.TextApplicationLabel.Name = "TextApplicationLabel"
    Me.TextApplicationLabel.Size = New System.Drawing.Size(96, 13)
    Me.TextApplicationLabel.TabIndex = 12
    Me.TextApplicationLabel.Text = "Default Application"
    '
    'TextPathLabel
    '
    Me.TextPathLabel.AutoSize = True
    Me.TextPathLabel.Location = New System.Drawing.Point(141, 22)
    Me.TextPathLabel.Name = "TextPathLabel"
    Me.TextPathLabel.Size = New System.Drawing.Size(29, 13)
    Me.TextPathLabel.TabIndex = 11
    Me.TextPathLabel.Text = "Path"
    '
    'TextPathTextBox
    '
    Me.TextPathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TextPathTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQLManager.My.MySettings.Default, "TextPathTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.TextPathTextBox.Location = New System.Drawing.Point(176, 19)
    Me.TextPathTextBox.Name = "TextPathTextBox"
    Me.TextPathTextBox.Size = New System.Drawing.Size(647, 20)
    Me.TextPathTextBox.TabIndex = 10
    Me.TextPathTextBox.Text = Global.RemoteOpenSQLManager.My.MySettings.Default.TextPathTextBox
    '
    'QueryOptionsGroupBox
    '
    Me.QueryOptionsGroupBox.Controls.Add(Me.BufferTextBox)
    Me.QueryOptionsGroupBox.Controls.Add(Me.BufferLabel)
    Me.QueryOptionsGroupBox.Controls.Add(Me.PartitionSizeTextBox)
    Me.QueryOptionsGroupBox.Controls.Add(Me.PartitionSizeLabel)
    Me.QueryOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top
    Me.QueryOptionsGroupBox.Location = New System.Drawing.Point(3, 3)
    Me.QueryOptionsGroupBox.Name = "QueryOptionsGroupBox"
    Me.QueryOptionsGroupBox.Size = New System.Drawing.Size(870, 57)
    Me.QueryOptionsGroupBox.TabIndex = 4
    Me.QueryOptionsGroupBox.TabStop = False
    Me.QueryOptionsGroupBox.Text = "Query Options"
    '
    'BufferTextBox
    '
    Me.BufferTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQLManager.My.MySettings.Default, "BufferTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.BufferTextBox.Location = New System.Drawing.Point(555, 23)
    Me.BufferTextBox.Name = "BufferTextBox"
    Me.BufferTextBox.Size = New System.Drawing.Size(45, 20)
    Me.BufferTextBox.TabIndex = 3
    Me.BufferTextBox.Text = Global.RemoteOpenSQLManager.My.MySettings.Default.BufferTextBox
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
    Me.PartitionSizeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RemoteOpenSQLManager.My.MySettings.Default, "PartitionSizeTextBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.PartitionSizeTextBox.Location = New System.Drawing.Point(232, 23)
    Me.PartitionSizeTextBox.Name = "PartitionSizeTextBox"
    Me.PartitionSizeTextBox.Size = New System.Drawing.Size(100, 20)
    Me.PartitionSizeTextBox.TabIndex = 1
    Me.PartitionSizeTextBox.Text = Global.RemoteOpenSQLManager.My.MySettings.Default.PartitionSizeTextBox
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
    'GrammarTabPage
    '
    Me.GrammarTabPage.Controls.Add(Me.GrammarGroupBox)
    Me.GrammarTabPage.Location = New System.Drawing.Point(4, 22)
    Me.GrammarTabPage.Name = "GrammarTabPage"
    Me.GrammarTabPage.Padding = New System.Windows.Forms.Padding(3)
    Me.GrammarTabPage.Size = New System.Drawing.Size(876, 363)
    Me.GrammarTabPage.TabIndex = 4
    Me.GrammarTabPage.Text = "Remote Open SQL Grammar"
    Me.GrammarTabPage.UseVisualStyleBackColor = True
    '
    'GrammarGroupBox
    '
    Me.GrammarGroupBox.Controls.Add(Me.GrammarTextBox)
    Me.GrammarGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GrammarGroupBox.Location = New System.Drawing.Point(3, 3)
    Me.GrammarGroupBox.Name = "GrammarGroupBox"
    Me.GrammarGroupBox.Size = New System.Drawing.Size(870, 357)
    Me.GrammarGroupBox.TabIndex = 0
    Me.GrammarGroupBox.TabStop = False
    Me.GrammarGroupBox.Text = "Remote Open SQL Grammar"
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
    Me.GrammarTextBox.Size = New System.Drawing.Size(864, 338)
    Me.GrammarTextBox.TabIndex = 0
    '
    'QueriesTabPage
    '
    Me.QueriesTabPage.Controls.Add(Me.QueriesSplitContainer)
    Me.QueriesTabPage.Controls.Add(Me.QueriesToolStrip)
    Me.QueriesTabPage.Location = New System.Drawing.Point(4, 22)
    Me.QueriesTabPage.Name = "QueriesTabPage"
    Me.QueriesTabPage.Padding = New System.Windows.Forms.Padding(3)
    Me.QueriesTabPage.Size = New System.Drawing.Size(876, 363)
    Me.QueriesTabPage.TabIndex = 1
    Me.QueriesTabPage.Text = "Remote Open SQL Queries"
    Me.QueriesTabPage.UseVisualStyleBackColor = True
    '
    'QueriesSplitContainer
    '
    Me.QueriesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QueriesSplitContainer.Location = New System.Drawing.Point(3, 42)
    Me.QueriesSplitContainer.Name = "QueriesSplitContainer"
    '
    'QueriesSplitContainer.Panel1
    '
    Me.QueriesSplitContainer.Panel1.Controls.Add(Me.QueryTreeView)
    '
    'QueriesSplitContainer.Panel2
    '
    Me.QueriesSplitContainer.Panel2.Controls.Add(Me.QuerySplitContainer)
    Me.QueriesSplitContainer.Panel2.Controls.Add(Me.QueryDescriptionGroupBox)
    Me.QueriesSplitContainer.Panel2.Controls.Add(Me.QueryStatusStrip)
    Me.QueriesSplitContainer.Size = New System.Drawing.Size(870, 318)
    Me.QueriesSplitContainer.SplitterDistance = 233
    Me.QueriesSplitContainer.TabIndex = 0
    '
    'QueryTreeView
    '
    Me.QueryTreeView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QueryTreeView.ImageIndex = 0
    Me.QueryTreeView.ImageList = Me.ImageList
    Me.QueryTreeView.Location = New System.Drawing.Point(0, 0)
    Me.QueryTreeView.Name = "QueryTreeView"
    Me.QueryTreeView.SelectedImageIndex = 0
    Me.QueryTreeView.Size = New System.Drawing.Size(233, 318)
    Me.QueryTreeView.TabIndex = 0
    '
    'QuerySplitContainer
    '
    Me.QuerySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QuerySplitContainer.Location = New System.Drawing.Point(0, 95)
    Me.QuerySplitContainer.Name = "QuerySplitContainer"
    Me.QuerySplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'QuerySplitContainer.Panel1
    '
    Me.QuerySplitContainer.Panel1.Controls.Add(Me.QueryGroupBox)
    '
    'QuerySplitContainer.Panel2
    '
    Me.QuerySplitContainer.Panel2.Controls.Add(Me.OutputGroupBox)
    Me.QuerySplitContainer.Size = New System.Drawing.Size(633, 201)
    Me.QuerySplitContainer.SplitterDistance = 101
    Me.QuerySplitContainer.TabIndex = 2
    '
    'QueryGroupBox
    '
    Me.QueryGroupBox.Controls.Add(Me.QueryTextBox)
    Me.QueryGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QueryGroupBox.Location = New System.Drawing.Point(0, 0)
    Me.QueryGroupBox.Name = "QueryGroupBox"
    Me.QueryGroupBox.Size = New System.Drawing.Size(633, 101)
    Me.QueryGroupBox.TabIndex = 0
    Me.QueryGroupBox.TabStop = False
    Me.QueryGroupBox.Text = "Query"
    '
    'QueryTextBox
    '
    Me.QueryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QueryBindingSource, "Query", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.QueryTextBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QueryTextBox.Location = New System.Drawing.Point(3, 16)
    Me.QueryTextBox.Multiline = True
    Me.QueryTextBox.Name = "QueryTextBox"
    Me.QueryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.QueryTextBox.Size = New System.Drawing.Size(627, 82)
    Me.QueryTextBox.TabIndex = 0
    '
    'QueryBindingSource
    '
    Me.QueryBindingSource.DataMember = "Query"
    Me.QueryBindingSource.DataSource = Me.RemoteOpenSQLQueries
    '
    'RemoteOpenSQLQueries
    '
    Me.RemoteOpenSQLQueries.DataSetName = "RemoteOpenSQLQueries"
    Me.RemoteOpenSQLQueries.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
    '
    'OutputGroupBox
    '
    Me.OutputGroupBox.Controls.Add(Me.OutputTextBox)
    Me.OutputGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OutputGroupBox.Location = New System.Drawing.Point(0, 0)
    Me.OutputGroupBox.Name = "OutputGroupBox"
    Me.OutputGroupBox.Size = New System.Drawing.Size(633, 96)
    Me.OutputGroupBox.TabIndex = 0
    Me.OutputGroupBox.TabStop = False
    Me.OutputGroupBox.Text = "Output"
    '
    'OutputTextBox
    '
    Me.OutputTextBox.BackColor = System.Drawing.SystemColors.Window
    Me.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OutputTextBox.Location = New System.Drawing.Point(3, 16)
    Me.OutputTextBox.Multiline = True
    Me.OutputTextBox.Name = "OutputTextBox"
    Me.OutputTextBox.ReadOnly = True
    Me.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.OutputTextBox.Size = New System.Drawing.Size(627, 77)
    Me.OutputTextBox.TabIndex = 0
    '
    'QueryDescriptionGroupBox
    '
    Me.QueryDescriptionGroupBox.Controls.Add(Me.QueryDescriptionTextBox)
    Me.QueryDescriptionGroupBox.Dock = System.Windows.Forms.DockStyle.Top
    Me.QueryDescriptionGroupBox.Location = New System.Drawing.Point(0, 0)
    Me.QueryDescriptionGroupBox.Name = "QueryDescriptionGroupBox"
    Me.QueryDescriptionGroupBox.Size = New System.Drawing.Size(633, 95)
    Me.QueryDescriptionGroupBox.TabIndex = 1
    Me.QueryDescriptionGroupBox.TabStop = False
    Me.QueryDescriptionGroupBox.Text = "Description"
    '
    'QueryDescriptionTextBox
    '
    Me.QueryDescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QueryBindingSource, "Description", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.QueryDescriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QueryDescriptionTextBox.Location = New System.Drawing.Point(3, 16)
    Me.QueryDescriptionTextBox.Multiline = True
    Me.QueryDescriptionTextBox.Name = "QueryDescriptionTextBox"
    Me.QueryDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.QueryDescriptionTextBox.Size = New System.Drawing.Size(627, 76)
    Me.QueryDescriptionTextBox.TabIndex = 0
    '
    'QueryStatusStrip
    '
    Me.QueryStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueryToolStripProgressBar, Me.QueryToolStripStatusLabel})
    Me.QueryStatusStrip.Location = New System.Drawing.Point(0, 296)
    Me.QueryStatusStrip.Name = "QueryStatusStrip"
    Me.QueryStatusStrip.Size = New System.Drawing.Size(633, 22)
    Me.QueryStatusStrip.TabIndex = 0
    Me.QueryStatusStrip.Text = "StatusStrip1"
    '
    'QueryToolStripProgressBar
    '
    Me.QueryToolStripProgressBar.Name = "QueryToolStripProgressBar"
    Me.QueryToolStripProgressBar.Size = New System.Drawing.Size(100, 16)
    '
    'QueryToolStripStatusLabel
    '
    Me.QueryToolStripStatusLabel.Name = "QueryToolStripStatusLabel"
    Me.QueryToolStripStatusLabel.Size = New System.Drawing.Size(77, 17)
    Me.QueryToolStripStatusLabel.Text = "Time Elapsed"
    '
    'QueriesToolStrip
    '
    Me.QueriesToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
    Me.QueriesToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueryNewFolderToolStripButton, Me.QueryNewToolStripButton, Me.QueryDeleteToolStripButton, Me.QueryToolStripSeparator1, Me.QueryStartToolStripButton, Me.QueryStopToolStripButton, Me.QueryToolStripSeparator2, Me.QueryQuickOpenToolStripButton, Me.QueryToolStripSeparator3})
    Me.QueriesToolStrip.Location = New System.Drawing.Point(3, 3)
    Me.QueriesToolStrip.Name = "QueriesToolStrip"
    Me.QueriesToolStrip.Size = New System.Drawing.Size(870, 39)
    Me.QueriesToolStrip.TabIndex = 15
    Me.QueriesToolStrip.Text = "Add New Folder"
    '
    'QueryNewFolderToolStripButton
    '
    Me.QueryNewFolderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.QueryNewFolderToolStripButton.Image = Global.RemoteOpenSQLManager.My.Resources.Resources.folder_new_8
    Me.QueryNewFolderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.QueryNewFolderToolStripButton.Name = "QueryNewFolderToolStripButton"
    Me.QueryNewFolderToolStripButton.Size = New System.Drawing.Size(36, 36)
    Me.QueryNewFolderToolStripButton.Text = "Add New Folder"
    '
    'QueryNewToolStripButton
    '
    Me.QueryNewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.QueryNewToolStripButton.Image = Global.RemoteOpenSQLManager.My.Resources.Resources.address_book_new_4
    Me.QueryNewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.QueryNewToolStripButton.Name = "QueryNewToolStripButton"
    Me.QueryNewToolStripButton.Size = New System.Drawing.Size(36, 36)
    Me.QueryNewToolStripButton.Text = "Add New Query"
    '
    'QueryDeleteToolStripButton
    '
    Me.QueryDeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.QueryDeleteToolStripButton.Image = Global.RemoteOpenSQLManager.My.Resources.Resources.edit_delete_6
    Me.QueryDeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.QueryDeleteToolStripButton.Name = "QueryDeleteToolStripButton"
    Me.QueryDeleteToolStripButton.Size = New System.Drawing.Size(36, 36)
    Me.QueryDeleteToolStripButton.Text = "Delete Folder or Query"
    '
    'QueryToolStripSeparator1
    '
    Me.QueryToolStripSeparator1.Name = "QueryToolStripSeparator1"
    Me.QueryToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
    '
    'QueryStartToolStripButton
    '
    Me.QueryStartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.QueryStartToolStripButton.Enabled = False
    Me.QueryStartToolStripButton.Image = CType(resources.GetObject("QueryStartToolStripButton.Image"), System.Drawing.Image)
    Me.QueryStartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.QueryStartToolStripButton.Name = "QueryStartToolStripButton"
    Me.QueryStartToolStripButton.Size = New System.Drawing.Size(36, 36)
    Me.QueryStartToolStripButton.Text = "Start Query"
    '
    'QueryStopToolStripButton
    '
    Me.QueryStopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.QueryStopToolStripButton.Enabled = False
    Me.QueryStopToolStripButton.Image = CType(resources.GetObject("QueryStopToolStripButton.Image"), System.Drawing.Image)
    Me.QueryStopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.QueryStopToolStripButton.Name = "QueryStopToolStripButton"
    Me.QueryStopToolStripButton.Size = New System.Drawing.Size(36, 36)
    Me.QueryStopToolStripButton.Text = "Stop Query"
    '
    'QueryToolStripSeparator2
    '
    Me.QueryToolStripSeparator2.Name = "QueryToolStripSeparator2"
    Me.QueryToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
    '
    'QueryQuickOpenToolStripButton
    '
    Me.QueryQuickOpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.QueryQuickOpenToolStripButton.Enabled = False
    Me.QueryQuickOpenToolStripButton.Image = Global.RemoteOpenSQLManager.My.Resources.Resources.quickopen
    Me.QueryQuickOpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.QueryQuickOpenToolStripButton.Name = "QueryQuickOpenToolStripButton"
    Me.QueryQuickOpenToolStripButton.Size = New System.Drawing.Size(36, 36)
    Me.QueryQuickOpenToolStripButton.Text = "Open Query Result"
    '
    'QueryToolStripSeparator3
    '
    Me.QueryToolStripSeparator3.Name = "QueryToolStripSeparator3"
    Me.QueryToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
    '
    'ToolStripButton1
    '
    Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton1.Image = Global.RemoteOpenSQLManager.My.Resources.Resources.address_book_new_4
    Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1.Name = "ToolStripButton1"
    Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton1.Text = "ToolStripButton1"
    '
    'QueryTimer
    '
    Me.QueryTimer.Interval = 1000
    '
    'DestinationGroupBox
    '
    Me.DestinationGroupBox.Controls.Add(Me.DescriptionLabel)
    Me.DestinationGroupBox.Controls.Add(Me.SapRouterStringLabel)
    Me.DestinationGroupBox.Controls.Add(Me.DestinationDescription)
    Me.DestinationGroupBox.Controls.Add(Me.PasswordLabel)
    Me.DestinationGroupBox.Controls.Add(Me.DestinationAppServerHost)
    Me.DestinationGroupBox.Controls.Add(Me.UsernameLabel)
    Me.DestinationGroupBox.Controls.Add(Me.DestinationSystemNumber)
    Me.DestinationGroupBox.Controls.Add(Me.ClientLabel)
    Me.DestinationGroupBox.Controls.Add(Me.DestinationClient)
    Me.DestinationGroupBox.Controls.Add(Me.SystemNumberLabel)
    Me.DestinationGroupBox.Controls.Add(Me.DestinationUsername)
    Me.DestinationGroupBox.Controls.Add(Me.AppServerHostLabel)
    Me.DestinationGroupBox.Controls.Add(Me.DestinationPassword)
    Me.DestinationGroupBox.Controls.Add(Me.DestinationSapRouterString)
    Me.DestinationGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DestinationGroupBox.Location = New System.Drawing.Point(0, 0)
    Me.DestinationGroupBox.Name = "DestinationGroupBox"
    Me.DestinationGroupBox.Size = New System.Drawing.Size(624, 318)
    Me.DestinationGroupBox.TabIndex = 14
    Me.DestinationGroupBox.TabStop = False
    Me.DestinationGroupBox.Text = "Destination"
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(884, 389)
    Me.Controls.Add(Me.MainTabControl)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Remote Open SQL Manager"
    Me.MainTabControl.ResumeLayout(False)
    Me.LogonTabPage.ResumeLayout(False)
    Me.LogonTabPage.PerformLayout()
    Me.DestinationsSplitContainer.Panel1.ResumeLayout(False)
    Me.DestinationsSplitContainer.Panel2.ResumeLayout(False)
    CType(Me.DestinationsSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
    Me.DestinationsSplitContainer.ResumeLayout(False)
    CType(Me.DestinationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.RemoteOpenSQLDestinations, System.ComponentModel.ISupportInitialize).EndInit()
    Me.DestinationToolStrip.ResumeLayout(False)
    Me.DestinationToolStrip.PerformLayout()
    Me.ABAPTabPage.ResumeLayout(False)
    Me.ABAPTabPage.PerformLayout()
    Me.OptionsTabPage.ResumeLayout(False)
    Me.OutputFormatGroupBox.ResumeLayout(False)
    Me.AccessGroupBox.ResumeLayout(False)
    Me.AccessGroupBox.PerformLayout()
    Me.ExcelGroupBox.ResumeLayout(False)
    Me.ExcelGroupBox.PerformLayout()
    Me.TextFormatGroupBox.ResumeLayout(False)
    Me.TextFormatGroupBox.PerformLayout()
    Me.QueryOptionsGroupBox.ResumeLayout(False)
    Me.QueryOptionsGroupBox.PerformLayout()
    Me.GrammarTabPage.ResumeLayout(False)
    Me.GrammarGroupBox.ResumeLayout(False)
    Me.GrammarGroupBox.PerformLayout()
    Me.QueriesTabPage.ResumeLayout(False)
    Me.QueriesTabPage.PerformLayout()
    Me.QueriesSplitContainer.Panel1.ResumeLayout(False)
    Me.QueriesSplitContainer.Panel2.ResumeLayout(False)
    Me.QueriesSplitContainer.Panel2.PerformLayout()
    CType(Me.QueriesSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
    Me.QueriesSplitContainer.ResumeLayout(False)
    Me.QuerySplitContainer.Panel1.ResumeLayout(False)
    Me.QuerySplitContainer.Panel2.ResumeLayout(False)
    CType(Me.QuerySplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
    Me.QuerySplitContainer.ResumeLayout(False)
    Me.QueryGroupBox.ResumeLayout(False)
    Me.QueryGroupBox.PerformLayout()
    CType(Me.QueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.RemoteOpenSQLQueries, System.ComponentModel.ISupportInitialize).EndInit()
    Me.OutputGroupBox.ResumeLayout(False)
    Me.OutputGroupBox.PerformLayout()
    Me.QueryDescriptionGroupBox.ResumeLayout(False)
    Me.QueryDescriptionGroupBox.PerformLayout()
    Me.QueryStatusStrip.ResumeLayout(False)
    Me.QueryStatusStrip.PerformLayout()
    Me.QueriesToolStrip.ResumeLayout(False)
    Me.QueriesToolStrip.PerformLayout()
    Me.DestinationGroupBox.ResumeLayout(False)
    Me.DestinationGroupBox.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
  Friend WithEvents LogonTabPage As System.Windows.Forms.TabPage
  Friend WithEvents QueriesTabPage As System.Windows.Forms.TabPage
  Friend WithEvents QueriesSplitContainer As System.Windows.Forms.SplitContainer
  Friend WithEvents ABAPTabPage As System.Windows.Forms.TabPage
  Friend WithEvents DestinationsSplitContainer As System.Windows.Forms.SplitContainer
  Friend WithEvents DestinationPassword As System.Windows.Forms.TextBox
  Friend WithEvents DestinationUsername As System.Windows.Forms.TextBox
  Friend WithEvents DestinationBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents RemoteOpenSQLDestinations As RemoteOpenSQLManager.RemoteOpenSQLDestinations
  Friend WithEvents DestinationClient As System.Windows.Forms.TextBox
  Friend WithEvents DestinationSystemNumber As System.Windows.Forms.TextBox
  Friend WithEvents DestinationAppServerHost As System.Windows.Forms.TextBox
  Friend WithEvents DestinationDescription As System.Windows.Forms.TextBox
  Friend WithEvents RemoteOpenSQLQueries As RemoteOpenSQLManager.RemoteOpenSQLQueries
  Friend WithEvents SapRouterStringLabel As System.Windows.Forms.Label
  Friend WithEvents PasswordLabel As System.Windows.Forms.Label
  Friend WithEvents UsernameLabel As System.Windows.Forms.Label
  Friend WithEvents ClientLabel As System.Windows.Forms.Label
  Friend WithEvents SystemNumberLabel As System.Windows.Forms.Label
  Friend WithEvents AppServerHostLabel As System.Windows.Forms.Label
  Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
  Friend WithEvents DestinationSapRouterString As System.Windows.Forms.TextBox
  Friend WithEvents DestinationTreeView As System.Windows.Forms.TreeView
  Friend WithEvents OptionsTabPage As System.Windows.Forms.TabPage
  Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
  Friend WithEvents DestinationToolStrip As System.Windows.Forms.ToolStrip
  Friend WithEvents DestinationNewFolderToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents DestinationNewToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents DestinationDeleteToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents ImageList As System.Windows.Forms.ImageList
  Friend WithEvents AbapCodeTextBox As System.Windows.Forms.TextBox
  Friend WithEvents QueryTreeView As System.Windows.Forms.TreeView
  Friend WithEvents QueriesToolStrip As System.Windows.Forms.ToolStrip
  Friend WithEvents QueryNewFolderToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents QueryNewToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents QueryDeleteToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents QueryToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents QueryStartToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents QueryStopToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents QueryToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents QueryQuickOpenToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents QueryToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents QuerySplitContainer As System.Windows.Forms.SplitContainer
  Friend WithEvents QueryGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents OutputGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents QueryDescriptionGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents QueryStatusStrip As System.Windows.Forms.StatusStrip
  Friend WithEvents OutputFormatGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents QueryTextBox As System.Windows.Forms.TextBox
  Friend WithEvents OutputTextBox As System.Windows.Forms.TextBox
  Friend WithEvents QueryDescriptionTextBox As System.Windows.Forms.TextBox
  Friend WithEvents AccessGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents AccessPathLabel As System.Windows.Forms.Label
  Friend WithEvents AccessPathTextBox As System.Windows.Forms.TextBox
  Friend WithEvents AccessRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents ExcelGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents ExcelPathLabel As System.Windows.Forms.Label
  Friend WithEvents ExcelPathTextBox As System.Windows.Forms.TextBox
  Friend WithEvents ExcelRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents TextFormatGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents TextPathButton As System.Windows.Forms.Button
  Friend WithEvents TextApplicationTextBox As System.Windows.Forms.TextBox
  Friend WithEvents TextApplicationLabel As System.Windows.Forms.Label
  Friend WithEvents TextPathLabel As System.Windows.Forms.Label
  Friend WithEvents TextPathTextBox As System.Windows.Forms.TextBox
  Friend WithEvents TextRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
  Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
  Friend WithEvents AccessPathButton As System.Windows.Forms.Button
  Friend WithEvents ExcelPathButton As System.Windows.Forms.Button
  Friend WithEvents TextApplicationButton As System.Windows.Forms.Button
  Friend WithEvents QueryBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents QueryToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
  Friend WithEvents QueryOptionsGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents PartitionSizeLabel As System.Windows.Forms.Label
  Friend WithEvents PartitionSizeTextBox As System.Windows.Forms.TextBox
  Friend WithEvents QueryTimer As System.Windows.Forms.Timer
  Friend WithEvents QueryToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents GrammarTabPage As System.Windows.Forms.TabPage
  Friend WithEvents GrammarGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents GrammarTextBox As System.Windows.Forms.TextBox
  Friend WithEvents BufferTextBox As System.Windows.Forms.TextBox
  Friend WithEvents BufferLabel As System.Windows.Forms.Label
  Friend WithEvents DestinationGroupBox As System.Windows.Forms.GroupBox
End Class
