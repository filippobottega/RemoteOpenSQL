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
    Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
    Me.DestinationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.RemoteOpenSQLDestinations = New RemoteOpenSQL.RemoteOpenSQLManager.RemoteOpenSQLDestinations()
    Me.QueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.RemoteOpenSQLQueries = New RemoteOpenSQL.RemoteOpenSQLManager.RemoteOpenSQLQueries()
    Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
    Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
    Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
    Me.QueryTimer = New System.Windows.Forms.Timer(Me.components)
    Me.QueryTreeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.MenuStrip = New System.Windows.Forms.MenuStrip()
    Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.NewDestinationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.NewQueriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
    Me.OpenDestinationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.OpenQueriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.SaveDestinationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.SaveQueriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.SaveDestinationsAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.SaveQueriesAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
    Me.ImportDestinationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ImportQueriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.AbabCodeToInstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.RemoteOpenSQLGrammarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.DestinationsSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
    Me.QueriesSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
    Me.MainTabControl = New System.Windows.Forms.TabControl()
    Me.LogonTabPage = New System.Windows.Forms.TabPage()
    Me.DestinationsSplitContainer = New System.Windows.Forms.SplitContainer()
    Me.DestinationTreeView = New System.Windows.Forms.TreeView()
    Me.DestinationGroupBox = New System.Windows.Forms.GroupBox()
    Me.PrivacyCheckBox = New System.Windows.Forms.CheckBox()
    Me.PrivacyLabel = New System.Windows.Forms.Label()
    Me.DescriptionLabel = New System.Windows.Forms.Label()
    Me.SapRouterStringLabel = New System.Windows.Forms.Label()
    Me.DestinationDescription = New System.Windows.Forms.TextBox()
    Me.PasswordLabel = New System.Windows.Forms.Label()
    Me.DestinationAppServerHost = New System.Windows.Forms.TextBox()
    Me.UsernameLabel = New System.Windows.Forms.Label()
    Me.DestinationSystemNumber = New System.Windows.Forms.TextBox()
    Me.ClientLabel = New System.Windows.Forms.Label()
    Me.DestinationClient = New System.Windows.Forms.TextBox()
    Me.SystemNumberLabel = New System.Windows.Forms.Label()
    Me.DestinationUsername = New System.Windows.Forms.TextBox()
    Me.AppServerHostLabel = New System.Windows.Forms.Label()
    Me.DestinationPassword = New System.Windows.Forms.TextBox()
    Me.DestinationSapRouterString = New System.Windows.Forms.TextBox()
    Me.DestinationToolStrip = New System.Windows.Forms.ToolStrip()
    Me.DestinationNewFolderToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.DestinationNewToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.DestinationDeleteToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.QueriesTabPage = New System.Windows.Forms.TabPage()
    Me.QueriesSplitContainer = New System.Windows.Forms.SplitContainer()
    Me.QueryTreeView = New System.Windows.Forms.TreeView()
    Me.QuerySplitContainer = New System.Windows.Forms.SplitContainer()
    Me.QueryGroupBox = New System.Windows.Forms.GroupBox()
    Me.QueryTextBox = New System.Windows.Forms.TextBox()
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
    Me.StartToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.StopToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.ViewToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.QueryToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.TextToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.ExcelToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.AccessToolStripButton = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
    Me.DestinationsOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
    Me.QueriesOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
    CType(Me.DestinationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.RemoteOpenSQLDestinations, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.QueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.RemoteOpenSQLQueries, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.QueryTreeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.MenuStrip.SuspendLayout()
    Me.MainTabControl.SuspendLayout()
    Me.LogonTabPage.SuspendLayout()
    CType(Me.DestinationsSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.DestinationsSplitContainer.Panel1.SuspendLayout()
    Me.DestinationsSplitContainer.Panel2.SuspendLayout()
    Me.DestinationsSplitContainer.SuspendLayout()
    Me.DestinationGroupBox.SuspendLayout()
    Me.DestinationToolStrip.SuspendLayout()
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
    Me.OutputGroupBox.SuspendLayout()
    Me.QueryDescriptionGroupBox.SuspendLayout()
    Me.QueryStatusStrip.SuspendLayout()
    Me.QueriesToolStrip.SuspendLayout()
    Me.SuspendLayout()
    '
    'ImageList
    '
    Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList.Images.SetKeyName(0, "folder-yellow.png")
    Me.ImageList.Images.SetKeyName(1, "kaddressbook-4.png")
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
    'ToolStripButton1
    '
    Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton1.Image = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.Resources.Resources.address_book_new_4
    Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1.Name = "ToolStripButton1"
    Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton1.Text = "ToolStripButton1"
    '
    'QueryTimer
    '
    Me.QueryTimer.Interval = 1000
    '
    'QueryTreeBindingSource
    '
    Me.QueryTreeBindingSource.DataMember = "QueryTree"
    Me.QueryTreeBindingSource.DataSource = Me.RemoteOpenSQLQueries
    '
    'MenuStrip
    '
    Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
    Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip.Name = "MenuStrip"
    Me.MenuStrip.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
    Me.MenuStrip.Size = New System.Drawing.Size(1179, 28)
    Me.MenuStrip.TabIndex = 1
    Me.MenuStrip.Text = "MenuStrip1"
    '
    'FileToolStripMenuItem
    '
    Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewDestinationsToolStripMenuItem, Me.NewQueriesToolStripMenuItem, Me.ToolStripSeparator6, Me.OpenDestinationsToolStripMenuItem, Me.OpenQueriesToolStripMenuItem, Me.ToolStripSeparator1, Me.SaveDestinationsToolStripMenuItem, Me.SaveQueriesToolStripMenuItem, Me.ToolStripSeparator2, Me.SaveDestinationsAsToolStripMenuItem, Me.SaveQueriesAsToolStripMenuItem, Me.ToolStripSeparator4, Me.ImportDestinationsToolStripMenuItem, Me.ImportQueriesToolStripMenuItem})
    Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
    Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
    Me.FileToolStripMenuItem.Text = "File"
    '
    'NewDestinationsToolStripMenuItem
    '
    Me.NewDestinationsToolStripMenuItem.Name = "NewDestinationsToolStripMenuItem"
    Me.NewDestinationsToolStripMenuItem.Size = New System.Drawing.Size(211, 24)
    Me.NewDestinationsToolStripMenuItem.Text = "New destinations"
    '
    'NewQueriesToolStripMenuItem
    '
    Me.NewQueriesToolStripMenuItem.Name = "NewQueriesToolStripMenuItem"
    Me.NewQueriesToolStripMenuItem.Size = New System.Drawing.Size(211, 24)
    Me.NewQueriesToolStripMenuItem.Text = "New queries"
    '
    'ToolStripSeparator6
    '
    Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
    Me.ToolStripSeparator6.Size = New System.Drawing.Size(208, 6)
    '
    'OpenDestinationsToolStripMenuItem
    '
    Me.OpenDestinationsToolStripMenuItem.Name = "OpenDestinationsToolStripMenuItem"
    Me.OpenDestinationsToolStripMenuItem.Size = New System.Drawing.Size(211, 24)
    Me.OpenDestinationsToolStripMenuItem.Text = "Open destinations"
    '
    'OpenQueriesToolStripMenuItem
    '
    Me.OpenQueriesToolStripMenuItem.Name = "OpenQueriesToolStripMenuItem"
    Me.OpenQueriesToolStripMenuItem.Size = New System.Drawing.Size(211, 24)
    Me.OpenQueriesToolStripMenuItem.Text = "Open queries"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(208, 6)
    '
    'SaveDestinationsToolStripMenuItem
    '
    Me.SaveDestinationsToolStripMenuItem.Name = "SaveDestinationsToolStripMenuItem"
    Me.SaveDestinationsToolStripMenuItem.Size = New System.Drawing.Size(211, 24)
    Me.SaveDestinationsToolStripMenuItem.Text = "Save destinations"
    '
    'SaveQueriesToolStripMenuItem
    '
    Me.SaveQueriesToolStripMenuItem.Name = "SaveQueriesToolStripMenuItem"
    Me.SaveQueriesToolStripMenuItem.Size = New System.Drawing.Size(211, 24)
    Me.SaveQueriesToolStripMenuItem.Text = "Save queries"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(208, 6)
    '
    'SaveDestinationsAsToolStripMenuItem
    '
    Me.SaveDestinationsAsToolStripMenuItem.Name = "SaveDestinationsAsToolStripMenuItem"
    Me.SaveDestinationsAsToolStripMenuItem.Size = New System.Drawing.Size(211, 24)
    Me.SaveDestinationsAsToolStripMenuItem.Text = "Save destinations as"
    '
    'SaveQueriesAsToolStripMenuItem
    '
    Me.SaveQueriesAsToolStripMenuItem.Name = "SaveQueriesAsToolStripMenuItem"
    Me.SaveQueriesAsToolStripMenuItem.Size = New System.Drawing.Size(211, 24)
    Me.SaveQueriesAsToolStripMenuItem.Text = "Save queries as"
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(208, 6)
    '
    'ImportDestinationsToolStripMenuItem
    '
    Me.ImportDestinationsToolStripMenuItem.Name = "ImportDestinationsToolStripMenuItem"
    Me.ImportDestinationsToolStripMenuItem.Size = New System.Drawing.Size(211, 24)
    Me.ImportDestinationsToolStripMenuItem.Text = "Import destinations"
    '
    'ImportQueriesToolStripMenuItem
    '
    Me.ImportQueriesToolStripMenuItem.Name = "ImportQueriesToolStripMenuItem"
    Me.ImportQueriesToolStripMenuItem.Size = New System.Drawing.Size(211, 24)
    Me.ImportQueriesToolStripMenuItem.Text = "Import queries"
    '
    'ToolsToolStripMenuItem
    '
    Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.AbabCodeToInstallToolStripMenuItem})
    Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
    Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(57, 24)
    Me.ToolsToolStripMenuItem.Text = "Tools"
    '
    'OptionsToolStripMenuItem
    '
    Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
    Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(212, 24)
    Me.OptionsToolStripMenuItem.Text = "Options"
    '
    'AbabCodeToInstallToolStripMenuItem
    '
    Me.AbabCodeToInstallToolStripMenuItem.Name = "AbabCodeToInstallToolStripMenuItem"
    Me.AbabCodeToInstallToolStripMenuItem.Size = New System.Drawing.Size(212, 24)
    Me.AbabCodeToInstallToolStripMenuItem.Text = "Abab code to install"
    '
    'HelpToolStripMenuItem
    '
    Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoteOpenSQLGrammarToolStripMenuItem})
    Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
    Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(53, 24)
    Me.HelpToolStripMenuItem.Text = "Help"
    '
    'RemoteOpenSQLGrammarToolStripMenuItem
    '
    Me.RemoteOpenSQLGrammarToolStripMenuItem.Name = "RemoteOpenSQLGrammarToolStripMenuItem"
    Me.RemoteOpenSQLGrammarToolStripMenuItem.Size = New System.Drawing.Size(258, 24)
    Me.RemoteOpenSQLGrammarToolStripMenuItem.Text = "RemoteOpenSQL Grammar"
    '
    'DestinationsSaveFileDialog
    '
    Me.DestinationsSaveFileDialog.DefaultExt = "xml"
    Me.DestinationsSaveFileDialog.Filter = "Destinations|*.xml"
    '
    'QueriesSaveFileDialog
    '
    Me.QueriesSaveFileDialog.Filter = "Queries|*.xml"
    '
    'MainTabControl
    '
    Me.MainTabControl.Controls.Add(Me.LogonTabPage)
    Me.MainTabControl.Controls.Add(Me.QueriesTabPage)
    Me.MainTabControl.DataBindings.Add(New System.Windows.Forms.Binding("SelectedIndex", Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default, "MainTabControl", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
    Me.MainTabControl.Location = New System.Drawing.Point(0, 28)
    Me.MainTabControl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.MainTabControl.Name = "MainTabControl"
    Me.MainTabControl.SelectedIndex = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default.MainTabControl
    Me.MainTabControl.Size = New System.Drawing.Size(1179, 451)
    Me.MainTabControl.TabIndex = 0
    '
    'LogonTabPage
    '
    Me.LogonTabPage.Controls.Add(Me.DestinationsSplitContainer)
    Me.LogonTabPage.Controls.Add(Me.DestinationToolStrip)
    Me.LogonTabPage.Location = New System.Drawing.Point(4, 25)
    Me.LogonTabPage.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.LogonTabPage.Name = "LogonTabPage"
    Me.LogonTabPage.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.LogonTabPage.Size = New System.Drawing.Size(1171, 422)
    Me.LogonTabPage.TabIndex = 0
    Me.LogonTabPage.Text = "Logon parameters"
    Me.LogonTabPage.UseVisualStyleBackColor = True
    '
    'DestinationsSplitContainer
    '
    Me.DestinationsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DestinationsSplitContainer.Location = New System.Drawing.Point(4, 31)
    Me.DestinationsSplitContainer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.DestinationsSplitContainer.Name = "DestinationsSplitContainer"
    '
    'DestinationsSplitContainer.Panel1
    '
    Me.DestinationsSplitContainer.Panel1.Controls.Add(Me.DestinationTreeView)
    '
    'DestinationsSplitContainer.Panel2
    '
    Me.DestinationsSplitContainer.Panel2.Controls.Add(Me.DestinationGroupBox)
    Me.DestinationsSplitContainer.Size = New System.Drawing.Size(1163, 387)
    Me.DestinationsSplitContainer.SplitterDistance = 323
    Me.DestinationsSplitContainer.SplitterWidth = 5
    Me.DestinationsSplitContainer.TabIndex = 0
    '
    'DestinationTreeView
    '
    Me.DestinationTreeView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DestinationTreeView.HideSelection = False
    Me.DestinationTreeView.ImageIndex = 0
    Me.DestinationTreeView.ImageList = Me.ImageList
    Me.DestinationTreeView.LabelEdit = True
    Me.DestinationTreeView.Location = New System.Drawing.Point(0, 0)
    Me.DestinationTreeView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.DestinationTreeView.Name = "DestinationTreeView"
    Me.DestinationTreeView.SelectedImageIndex = 0
    Me.DestinationTreeView.Size = New System.Drawing.Size(323, 387)
    Me.DestinationTreeView.TabIndex = 1
    '
    'DestinationGroupBox
    '
    Me.DestinationGroupBox.Controls.Add(Me.PrivacyCheckBox)
    Me.DestinationGroupBox.Controls.Add(Me.PrivacyLabel)
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
    Me.DestinationGroupBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.DestinationGroupBox.Name = "DestinationGroupBox"
    Me.DestinationGroupBox.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.DestinationGroupBox.Size = New System.Drawing.Size(835, 387)
    Me.DestinationGroupBox.TabIndex = 14
    Me.DestinationGroupBox.TabStop = False
    Me.DestinationGroupBox.Text = "Destination"
    '
    'PrivacyCheckBox
    '
    Me.PrivacyCheckBox.AutoSize = True
    Me.PrivacyCheckBox.Checked = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default.PrivacyCheckBox
    Me.PrivacyCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default, "PrivacyCheckBox", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.PrivacyCheckBox.Location = New System.Drawing.Point(147, 290)
    Me.PrivacyCheckBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.PrivacyCheckBox.Name = "PrivacyCheckBox"
    Me.PrivacyCheckBox.Size = New System.Drawing.Size(18, 17)
    Me.PrivacyCheckBox.TabIndex = 15
    Me.PrivacyCheckBox.UseVisualStyleBackColor = True
    '
    'PrivacyLabel
    '
    Me.PrivacyLabel.AutoSize = True
    Me.PrivacyLabel.Location = New System.Drawing.Point(83, 290)
    Me.PrivacyLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.PrivacyLabel.Name = "PrivacyLabel"
    Me.PrivacyLabel.Size = New System.Drawing.Size(54, 17)
    Me.PrivacyLabel.TabIndex = 14
    Me.PrivacyLabel.Text = "Privacy"
    '
    'DescriptionLabel
    '
    Me.DescriptionLabel.AutoSize = True
    Me.DescriptionLabel.Location = New System.Drawing.Point(59, 37)
    Me.DescriptionLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.DescriptionLabel.Name = "DescriptionLabel"
    Me.DescriptionLabel.Size = New System.Drawing.Size(79, 17)
    Me.DescriptionLabel.TabIndex = 7
    Me.DescriptionLabel.Text = "Description"
    '
    'SapRouterStringLabel
    '
    Me.SapRouterStringLabel.AutoSize = True
    Me.SapRouterStringLabel.Location = New System.Drawing.Point(17, 229)
    Me.SapRouterStringLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.SapRouterStringLabel.Name = "SapRouterStringLabel"
    Me.SapRouterStringLabel.Size = New System.Drawing.Size(121, 17)
    Me.SapRouterStringLabel.TabIndex = 13
    Me.SapRouterStringLabel.Text = "Sap Router String"
    '
    'DestinationDescription
    '
    Me.DestinationDescription.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.DestinationBindingSource, "Description", True))
    Me.DestinationDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "Description", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.DestinationDescription.Location = New System.Drawing.Point(147, 33)
    Me.DestinationDescription.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.DestinationDescription.Name = "DestinationDescription"
    Me.DestinationDescription.Size = New System.Drawing.Size(449, 22)
    Me.DestinationDescription.TabIndex = 0
    '
    'PasswordLabel
    '
    Me.PasswordLabel.AutoSize = True
    Me.PasswordLabel.Location = New System.Drawing.Point(68, 197)
    Me.PasswordLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.PasswordLabel.Name = "PasswordLabel"
    Me.PasswordLabel.Size = New System.Drawing.Size(69, 17)
    Me.PasswordLabel.TabIndex = 12
    Me.PasswordLabel.Text = "Password"
    '
    'DestinationAppServerHost
    '
    Me.DestinationAppServerHost.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "AppServerHost", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.DestinationAppServerHost.Location = New System.Drawing.Point(147, 65)
    Me.DestinationAppServerHost.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.DestinationAppServerHost.Name = "DestinationAppServerHost"
    Me.DestinationAppServerHost.Size = New System.Drawing.Size(449, 22)
    Me.DestinationAppServerHost.TabIndex = 1
    '
    'UsernameLabel
    '
    Me.UsernameLabel.AutoSize = True
    Me.UsernameLabel.Location = New System.Drawing.Point(65, 165)
    Me.UsernameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.UsernameLabel.Name = "UsernameLabel"
    Me.UsernameLabel.Size = New System.Drawing.Size(73, 17)
    Me.UsernameLabel.TabIndex = 11
    Me.UsernameLabel.Text = "Username"
    '
    'DestinationSystemNumber
    '
    Me.DestinationSystemNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "SystemNumber", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"))
    Me.DestinationSystemNumber.Location = New System.Drawing.Point(147, 97)
    Me.DestinationSystemNumber.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.DestinationSystemNumber.MaxLength = 2
    Me.DestinationSystemNumber.Name = "DestinationSystemNumber"
    Me.DestinationSystemNumber.Size = New System.Drawing.Size(51, 22)
    Me.DestinationSystemNumber.TabIndex = 2
    '
    'ClientLabel
    '
    Me.ClientLabel.AutoSize = True
    Me.ClientLabel.Location = New System.Drawing.Point(95, 133)
    Me.ClientLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.ClientLabel.Name = "ClientLabel"
    Me.ClientLabel.Size = New System.Drawing.Size(43, 17)
    Me.ClientLabel.TabIndex = 10
    Me.ClientLabel.Text = "Client"
    '
    'DestinationClient
    '
    Me.DestinationClient.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "Client", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"))
    Me.DestinationClient.Location = New System.Drawing.Point(147, 129)
    Me.DestinationClient.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.DestinationClient.MaxLength = 3
    Me.DestinationClient.Name = "DestinationClient"
    Me.DestinationClient.Size = New System.Drawing.Size(51, 22)
    Me.DestinationClient.TabIndex = 3
    '
    'SystemNumberLabel
    '
    Me.SystemNumberLabel.AutoSize = True
    Me.SystemNumberLabel.Location = New System.Drawing.Point(31, 101)
    Me.SystemNumberLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.SystemNumberLabel.Name = "SystemNumberLabel"
    Me.SystemNumberLabel.Size = New System.Drawing.Size(108, 17)
    Me.SystemNumberLabel.TabIndex = 9
    Me.SystemNumberLabel.Text = "System Number"
    '
    'DestinationUsername
    '
    Me.DestinationUsername.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "Username", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.DestinationUsername.Location = New System.Drawing.Point(147, 161)
    Me.DestinationUsername.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.DestinationUsername.Name = "DestinationUsername"
    Me.DestinationUsername.Size = New System.Drawing.Size(132, 22)
    Me.DestinationUsername.TabIndex = 4
    '
    'AppServerHostLabel
    '
    Me.AppServerHostLabel.AutoSize = True
    Me.AppServerHostLabel.Location = New System.Drawing.Point(55, 69)
    Me.AppServerHostLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.AppServerHostLabel.Name = "AppServerHostLabel"
    Me.AppServerHostLabel.Size = New System.Drawing.Size(83, 17)
    Me.AppServerHostLabel.TabIndex = 8
    Me.AppServerHostLabel.Text = "Server Host"
    '
    'DestinationPassword
    '
    Me.DestinationPassword.Location = New System.Drawing.Point(147, 193)
    Me.DestinationPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.DestinationPassword.Name = "DestinationPassword"
    Me.DestinationPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.DestinationPassword.Size = New System.Drawing.Size(132, 22)
    Me.DestinationPassword.TabIndex = 5
    Me.DestinationPassword.UseSystemPasswordChar = True
    '
    'DestinationSapRouterString
    '
    Me.DestinationSapRouterString.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DestinationBindingSource, "SAPRouterString", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.DestinationSapRouterString.Location = New System.Drawing.Point(147, 225)
    Me.DestinationSapRouterString.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.DestinationSapRouterString.Name = "DestinationSapRouterString"
    Me.DestinationSapRouterString.Size = New System.Drawing.Size(449, 22)
    Me.DestinationSapRouterString.TabIndex = 6
    '
    'DestinationToolStrip
    '
    Me.DestinationToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
    Me.DestinationToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DestinationNewFolderToolStripButton, Me.DestinationNewToolStripButton, Me.DestinationDeleteToolStripButton, Me.ToolStripSeparator3})
    Me.DestinationToolStrip.Location = New System.Drawing.Point(4, 4)
    Me.DestinationToolStrip.Name = "DestinationToolStrip"
    Me.DestinationToolStrip.Size = New System.Drawing.Size(1163, 27)
    Me.DestinationToolStrip.TabIndex = 14
    Me.DestinationToolStrip.Text = "ToolStrip1"
    '
    'DestinationNewFolderToolStripButton
    '
    Me.DestinationNewFolderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.DestinationNewFolderToolStripButton.Image = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.Resources.Resources.folder_new_8
    Me.DestinationNewFolderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.DestinationNewFolderToolStripButton.Name = "DestinationNewFolderToolStripButton"
    Me.DestinationNewFolderToolStripButton.Size = New System.Drawing.Size(89, 24)
    Me.DestinationNewFolderToolStripButton.Text = "New Folder"
    '
    'DestinationNewToolStripButton
    '
    Me.DestinationNewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.DestinationNewToolStripButton.Image = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.Resources.Resources.address_book_new_4
    Me.DestinationNewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.DestinationNewToolStripButton.Name = "DestinationNewToolStripButton"
    Me.DestinationNewToolStripButton.Size = New System.Drawing.Size(123, 24)
    Me.DestinationNewToolStripButton.Text = "New Destination"
    '
    'DestinationDeleteToolStripButton
    '
    Me.DestinationDeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.DestinationDeleteToolStripButton.Image = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.Resources.Resources.edit_delete_6
    Me.DestinationDeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.DestinationDeleteToolStripButton.Name = "DestinationDeleteToolStripButton"
    Me.DestinationDeleteToolStripButton.Size = New System.Drawing.Size(57, 24)
    Me.DestinationDeleteToolStripButton.Text = "Delete"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
    '
    'QueriesTabPage
    '
    Me.QueriesTabPage.Controls.Add(Me.QueriesSplitContainer)
    Me.QueriesTabPage.Controls.Add(Me.QueriesToolStrip)
    Me.QueriesTabPage.Location = New System.Drawing.Point(4, 25)
    Me.QueriesTabPage.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.QueriesTabPage.Name = "QueriesTabPage"
    Me.QueriesTabPage.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.QueriesTabPage.Size = New System.Drawing.Size(1171, 422)
    Me.QueriesTabPage.TabIndex = 1
    Me.QueriesTabPage.Text = "Remote Open SQL Queries"
    Me.QueriesTabPage.UseVisualStyleBackColor = True
    '
    'QueriesSplitContainer
    '
    Me.QueriesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QueriesSplitContainer.Location = New System.Drawing.Point(4, 31)
    Me.QueriesSplitContainer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
    Me.QueriesSplitContainer.Size = New System.Drawing.Size(1163, 387)
    Me.QueriesSplitContainer.SplitterDistance = 311
    Me.QueriesSplitContainer.SplitterWidth = 5
    Me.QueriesSplitContainer.TabIndex = 1
    '
    'QueryTreeView
    '
    Me.QueryTreeView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QueryTreeView.HideSelection = False
    Me.QueryTreeView.ImageIndex = 0
    Me.QueryTreeView.ImageList = Me.ImageList
    Me.QueryTreeView.LabelEdit = True
    Me.QueryTreeView.Location = New System.Drawing.Point(0, 0)
    Me.QueryTreeView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.QueryTreeView.Name = "QueryTreeView"
    Me.QueryTreeView.SelectedImageIndex = 0
    Me.QueryTreeView.Size = New System.Drawing.Size(311, 387)
    Me.QueryTreeView.TabIndex = 0
    '
    'QuerySplitContainer
    '
    Me.QuerySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QuerySplitContainer.Location = New System.Drawing.Point(0, 117)
    Me.QuerySplitContainer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
    Me.QuerySplitContainer.Size = New System.Drawing.Size(847, 241)
    Me.QuerySplitContainer.SplitterDistance = 118
    Me.QuerySplitContainer.SplitterWidth = 5
    Me.QuerySplitContainer.TabIndex = 1
    '
    'QueryGroupBox
    '
    Me.QueryGroupBox.Controls.Add(Me.QueryTextBox)
    Me.QueryGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QueryGroupBox.Location = New System.Drawing.Point(0, 0)
    Me.QueryGroupBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.QueryGroupBox.Name = "QueryGroupBox"
    Me.QueryGroupBox.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.QueryGroupBox.Size = New System.Drawing.Size(847, 118)
    Me.QueryGroupBox.TabIndex = 0
    Me.QueryGroupBox.TabStop = False
    Me.QueryGroupBox.Text = "Query"
    '
    'QueryTextBox
    '
    Me.QueryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QueryBindingSource, "Query", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.QueryTextBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QueryTextBox.Location = New System.Drawing.Point(4, 19)
    Me.QueryTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.QueryTextBox.Multiline = True
    Me.QueryTextBox.Name = "QueryTextBox"
    Me.QueryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.QueryTextBox.Size = New System.Drawing.Size(839, 95)
    Me.QueryTextBox.TabIndex = 0
    '
    'OutputGroupBox
    '
    Me.OutputGroupBox.Controls.Add(Me.OutputTextBox)
    Me.OutputGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OutputGroupBox.Location = New System.Drawing.Point(0, 0)
    Me.OutputGroupBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.OutputGroupBox.Name = "OutputGroupBox"
    Me.OutputGroupBox.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.OutputGroupBox.Size = New System.Drawing.Size(847, 118)
    Me.OutputGroupBox.TabIndex = 0
    Me.OutputGroupBox.TabStop = False
    Me.OutputGroupBox.Text = "Output"
    '
    'OutputTextBox
    '
    Me.OutputTextBox.BackColor = System.Drawing.SystemColors.Window
    Me.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OutputTextBox.Location = New System.Drawing.Point(4, 19)
    Me.OutputTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.OutputTextBox.Multiline = True
    Me.OutputTextBox.Name = "OutputTextBox"
    Me.OutputTextBox.ReadOnly = True
    Me.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.OutputTextBox.Size = New System.Drawing.Size(839, 95)
    Me.OutputTextBox.TabIndex = 0
    '
    'QueryDescriptionGroupBox
    '
    Me.QueryDescriptionGroupBox.Controls.Add(Me.QueryDescriptionTextBox)
    Me.QueryDescriptionGroupBox.Dock = System.Windows.Forms.DockStyle.Top
    Me.QueryDescriptionGroupBox.Location = New System.Drawing.Point(0, 0)
    Me.QueryDescriptionGroupBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.QueryDescriptionGroupBox.Name = "QueryDescriptionGroupBox"
    Me.QueryDescriptionGroupBox.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.QueryDescriptionGroupBox.Size = New System.Drawing.Size(847, 117)
    Me.QueryDescriptionGroupBox.TabIndex = 0
    Me.QueryDescriptionGroupBox.TabStop = False
    Me.QueryDescriptionGroupBox.Text = "Description"
    '
    'QueryDescriptionTextBox
    '
    Me.QueryDescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.QueryBindingSource, "Description", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.QueryDescriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.QueryDescriptionTextBox.Location = New System.Drawing.Point(4, 19)
    Me.QueryDescriptionTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.QueryDescriptionTextBox.Multiline = True
    Me.QueryDescriptionTextBox.Name = "QueryDescriptionTextBox"
    Me.QueryDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.QueryDescriptionTextBox.Size = New System.Drawing.Size(839, 94)
    Me.QueryDescriptionTextBox.TabIndex = 0
    '
    'QueryStatusStrip
    '
    Me.QueryStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueryToolStripProgressBar, Me.QueryToolStripStatusLabel})
    Me.QueryStatusStrip.Location = New System.Drawing.Point(0, 358)
    Me.QueryStatusStrip.Name = "QueryStatusStrip"
    Me.QueryStatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
    Me.QueryStatusStrip.Size = New System.Drawing.Size(847, 29)
    Me.QueryStatusStrip.TabIndex = 2
    Me.QueryStatusStrip.Text = "StatusStrip1"
    '
    'QueryToolStripProgressBar
    '
    Me.QueryToolStripProgressBar.Name = "QueryToolStripProgressBar"
    Me.QueryToolStripProgressBar.Size = New System.Drawing.Size(133, 23)
    '
    'QueryToolStripStatusLabel
    '
    Me.QueryToolStripStatusLabel.Name = "QueryToolStripStatusLabel"
    Me.QueryToolStripStatusLabel.Size = New System.Drawing.Size(98, 24)
    Me.QueryToolStripStatusLabel.Text = "Time Elapsed"
    '
    'QueriesToolStrip
    '
    Me.QueriesToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
    Me.QueriesToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueryNewFolderToolStripButton, Me.QueryNewToolStripButton, Me.QueryDeleteToolStripButton, Me.QueryToolStripSeparator1, Me.StartToolStripButton, Me.StopToolStripButton, Me.ViewToolStripButton, Me.QueryToolStripSeparator2, Me.TextToolStripButton, Me.ExcelToolStripButton, Me.AccessToolStripButton, Me.ToolStripSeparator5})
    Me.QueriesToolStrip.Location = New System.Drawing.Point(4, 4)
    Me.QueriesToolStrip.Name = "QueriesToolStrip"
    Me.QueriesToolStrip.Size = New System.Drawing.Size(1163, 27)
    Me.QueriesToolStrip.TabIndex = 0
    Me.QueriesToolStrip.Text = "Add New Folder"
    '
    'QueryNewFolderToolStripButton
    '
    Me.QueryNewFolderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.QueryNewFolderToolStripButton.Image = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.Resources.Resources.folder_new_8
    Me.QueryNewFolderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.QueryNewFolderToolStripButton.Name = "QueryNewFolderToolStripButton"
    Me.QueryNewFolderToolStripButton.Size = New System.Drawing.Size(89, 24)
    Me.QueryNewFolderToolStripButton.Text = "New Folder"
    '
    'QueryNewToolStripButton
    '
    Me.QueryNewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.QueryNewToolStripButton.Image = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.Resources.Resources.address_book_new_4
    Me.QueryNewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.QueryNewToolStripButton.Name = "QueryNewToolStripButton"
    Me.QueryNewToolStripButton.Size = New System.Drawing.Size(86, 24)
    Me.QueryNewToolStripButton.Text = "New Query"
    '
    'QueryDeleteToolStripButton
    '
    Me.QueryDeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.QueryDeleteToolStripButton.Image = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.Resources.Resources.edit_delete_6
    Me.QueryDeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.QueryDeleteToolStripButton.Name = "QueryDeleteToolStripButton"
    Me.QueryDeleteToolStripButton.Size = New System.Drawing.Size(57, 24)
    Me.QueryDeleteToolStripButton.Text = "Delete"
    '
    'QueryToolStripSeparator1
    '
    Me.QueryToolStripSeparator1.Name = "QueryToolStripSeparator1"
    Me.QueryToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
    '
    'StartToolStripButton
    '
    Me.StartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.StartToolStripButton.Enabled = False
    Me.StartToolStripButton.Image = CType(resources.GetObject("StartToolStripButton.Image"), System.Drawing.Image)
    Me.StartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.StartToolStripButton.Name = "StartToolStripButton"
    Me.StartToolStripButton.Size = New System.Drawing.Size(38, 24)
    Me.StartToolStripButton.Text = "Run"
    '
    'StopToolStripButton
    '
    Me.StopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.StopToolStripButton.Enabled = False
    Me.StopToolStripButton.Image = CType(resources.GetObject("StopToolStripButton.Image"), System.Drawing.Image)
    Me.StopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.StopToolStripButton.Name = "StopToolStripButton"
    Me.StopToolStripButton.Size = New System.Drawing.Size(44, 24)
    Me.StopToolStripButton.Text = "Stop"
    '
    'ViewToolStripButton
    '
    Me.ViewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ViewToolStripButton.Enabled = False
    Me.ViewToolStripButton.Image = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.Resources.Resources.quickopen
    Me.ViewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ViewToolStripButton.Name = "ViewToolStripButton"
    Me.ViewToolStripButton.Size = New System.Drawing.Size(45, 24)
    Me.ViewToolStripButton.Text = "View"
    '
    'QueryToolStripSeparator2
    '
    Me.QueryToolStripSeparator2.Name = "QueryToolStripSeparator2"
    Me.QueryToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
    '
    'TextToolStripButton
    '
    Me.TextToolStripButton.CheckOnClick = True
    Me.TextToolStripButton.CheckState = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default.TextToolStripButtonCheckState
    Me.TextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.TextToolStripButton.Image = CType(resources.GetObject("TextToolStripButton.Image"), System.Drawing.Image)
    Me.TextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.TextToolStripButton.Name = "TextToolStripButton"
    Me.TextToolStripButton.Size = New System.Drawing.Size(41, 24)
    Me.TextToolStripButton.Text = "Text"
    '
    'ExcelToolStripButton
    '
    Me.ExcelToolStripButton.CheckOnClick = True
    Me.ExcelToolStripButton.CheckState = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default.ExcelToolStripButtonCheckState
    Me.ExcelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ExcelToolStripButton.Image = CType(resources.GetObject("ExcelToolStripButton.Image"), System.Drawing.Image)
    Me.ExcelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ExcelToolStripButton.Name = "ExcelToolStripButton"
    Me.ExcelToolStripButton.Size = New System.Drawing.Size(47, 24)
    Me.ExcelToolStripButton.Text = "Excel"
    '
    'AccessToolStripButton
    '
    Me.AccessToolStripButton.CheckOnClick = True
    Me.AccessToolStripButton.CheckState = Global.RemoteOpenSQL.RemoteOpenSQLManager.My.MySettings.Default.AccessToolStripButtonCheckState
    Me.AccessToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.AccessToolStripButton.Image = CType(resources.GetObject("AccessToolStripButton.Image"), System.Drawing.Image)
    Me.AccessToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.AccessToolStripButton.Name = "AccessToolStripButton"
    Me.AccessToolStripButton.Size = New System.Drawing.Size(57, 24)
    Me.AccessToolStripButton.Text = "Access"
    '
    'ToolStripSeparator5
    '
    Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
    Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 27)
    '
    'DestinationsOpenFileDialog
    '
    Me.DestinationsOpenFileDialog.Filter = "Destinations|*.xml"
    '
    'QueriesOpenFileDialog
    '
    Me.QueriesOpenFileDialog.Filter = "Queries|*.xml"
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1179, 479)
    Me.Controls.Add(Me.MainTabControl)
    Me.Controls.Add(Me.MenuStrip)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MainMenuStrip = Me.MenuStrip
    Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Remote Open SQL Manager"
    CType(Me.DestinationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.RemoteOpenSQLDestinations, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.QueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.RemoteOpenSQLQueries, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.QueryTreeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    Me.MenuStrip.ResumeLayout(False)
    Me.MenuStrip.PerformLayout()
    Me.MainTabControl.ResumeLayout(False)
    Me.LogonTabPage.ResumeLayout(False)
    Me.LogonTabPage.PerformLayout()
    Me.DestinationsSplitContainer.Panel1.ResumeLayout(False)
    Me.DestinationsSplitContainer.Panel2.ResumeLayout(False)
    CType(Me.DestinationsSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
    Me.DestinationsSplitContainer.ResumeLayout(False)
    Me.DestinationGroupBox.ResumeLayout(False)
    Me.DestinationGroupBox.PerformLayout()
    Me.DestinationToolStrip.ResumeLayout(False)
    Me.DestinationToolStrip.PerformLayout()
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
    Me.OutputGroupBox.ResumeLayout(False)
    Me.OutputGroupBox.PerformLayout()
    Me.QueryDescriptionGroupBox.ResumeLayout(False)
    Me.QueryDescriptionGroupBox.PerformLayout()
    Me.QueryStatusStrip.ResumeLayout(False)
    Me.QueryStatusStrip.PerformLayout()
    Me.QueriesToolStrip.ResumeLayout(False)
    Me.QueriesToolStrip.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
  Friend WithEvents LogonTabPage As System.Windows.Forms.TabPage
  Friend WithEvents QueriesTabPage As System.Windows.Forms.TabPage
  Friend WithEvents QueriesSplitContainer As System.Windows.Forms.SplitContainer
  Friend WithEvents DestinationsSplitContainer As System.Windows.Forms.SplitContainer
  Friend WithEvents DestinationPassword As System.Windows.Forms.TextBox
  Friend WithEvents DestinationUsername As System.Windows.Forms.TextBox
  Friend WithEvents DestinationBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents RemoteOpenSQLDestinations As RemoteOpenSQLDestinations
  Friend WithEvents DestinationClient As System.Windows.Forms.TextBox
  Friend WithEvents DestinationSystemNumber As System.Windows.Forms.TextBox
  Friend WithEvents DestinationAppServerHost As System.Windows.Forms.TextBox
  Friend WithEvents DestinationDescription As System.Windows.Forms.TextBox
  Friend WithEvents RemoteOpenSQLQueries As RemoteOpenSQLQueries
  Friend WithEvents SapRouterStringLabel As System.Windows.Forms.Label
  Friend WithEvents PasswordLabel As System.Windows.Forms.Label
  Friend WithEvents UsernameLabel As System.Windows.Forms.Label
  Friend WithEvents ClientLabel As System.Windows.Forms.Label
  Friend WithEvents SystemNumberLabel As System.Windows.Forms.Label
  Friend WithEvents AppServerHostLabel As System.Windows.Forms.Label
  Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
  Friend WithEvents DestinationSapRouterString As System.Windows.Forms.TextBox
  Friend WithEvents DestinationTreeView As System.Windows.Forms.TreeView
  Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
  Friend WithEvents DestinationToolStrip As System.Windows.Forms.ToolStrip
  Friend WithEvents DestinationNewFolderToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents DestinationNewToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents DestinationDeleteToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents ImageList As System.Windows.Forms.ImageList
  Friend WithEvents QueryTreeView As System.Windows.Forms.TreeView
  Friend WithEvents QueriesToolStrip As System.Windows.Forms.ToolStrip
  Friend WithEvents QueryNewFolderToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents QueryNewToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents QueryDeleteToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents QueryToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents StartToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents StopToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents QueryToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ViewToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents QuerySplitContainer As System.Windows.Forms.SplitContainer
  Friend WithEvents QueryGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents OutputGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents QueryDescriptionGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents QueryStatusStrip As System.Windows.Forms.StatusStrip
  Friend WithEvents QueryTextBox As System.Windows.Forms.TextBox
  Friend WithEvents OutputTextBox As System.Windows.Forms.TextBox
  Friend WithEvents QueryDescriptionTextBox As System.Windows.Forms.TextBox
  Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
  Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
  Friend WithEvents QueryBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents QueryToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
  Friend WithEvents QueryTimer As System.Windows.Forms.Timer
  Friend WithEvents QueryToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents DestinationGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents QueryTreeBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents PrivacyCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents PrivacyLabel As System.Windows.Forms.Label
  Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
  Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents OpenDestinationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents OpenQueriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents SaveDestinationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SaveQueriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents SaveDestinationsAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SaveQueriesAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ImportDestinationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ImportQueriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents AbabCodeToInstallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents RemoteOpenSQLGrammarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents TextToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents ExcelToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents AccessToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents NewDestinationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents NewQueriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents DestinationsSaveFileDialog As System.Windows.Forms.SaveFileDialog
  Friend WithEvents QueriesSaveFileDialog As System.Windows.Forms.SaveFileDialog
  Friend WithEvents DestinationsOpenFileDialog As System.Windows.Forms.OpenFileDialog
  Friend WithEvents QueriesOpenFileDialog As System.Windows.Forms.OpenFileDialog
End Class
