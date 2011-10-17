' Remote Open SQL makes it easier for SAP R3 users and developers to run Open SQL Queries on SAP R3 database. 
' It's developed in Visual Basic .NET 2010 and ABAP.
' Copyright (C) 2011 Filippo Bottega
'
' This program is free software; you can redistribute it and/or
' modify it under the terms of the GNU General Public License
' as published by the Free Software Foundation; either version 2
' of the License, or (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program; if not, write to the Free Software
' Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
'
' Home Page: www.remoteopensql.com
' EMail of the author: filippo.bottega@gmail.com

Imports System.IO
Imports RemoteOpenSQL.RemoteOpenSQLLib

Public Class MainForm

  Private WithEvents RemoteOpenSQL As RemoteOpenSQLLib.RemoteOpenSQL
  Private RemoteOpenSQLDestinationsFullPath As String
  Private RemoteOpenSQLQueriesFullPath As String
  Private ConsumerTypeToolStripButtons As New List(Of ToolStripButton)
  Private Consumer As DataConsumer
  Private QueryStartTime As DateTime

  Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    If RemoteOpenSQLDestinations.HasChanges Then
      Select Case MsgBox("Do you want to save chages to " & Path.GetFileName(RemoteOpenSQLDestinationsFullPath) & " ?", MsgBoxStyle.YesNoCancel)
        Case MsgBoxResult.Cancel
          e.Cancel = True
          Exit Sub
        Case MsgBoxResult.Yes
          RemoteOpenSQLDestinations.AcceptChanges()
          RemoteOpenSQLDestinations.WriteXml(RemoteOpenSQLDestinationsFullPath)
      End Select
    End If

    If RemoteOpenSQLQueries.HasChanges Then
      Select Case MsgBox("Do you want to save chages to " & Path.GetFileName(RemoteOpenSQLQueriesFullPath) & " ?", MsgBoxStyle.YesNoCancel)
        Case MsgBoxResult.Cancel
          e.Cancel = True
          Exit Sub
        Case MsgBoxResult.Yes
          RemoteOpenSQLQueries.AcceptChanges()
          RemoteOpenSQLQueries.WriteXml(RemoteOpenSQLQueriesFullPath)
      End Select
    End If

    My.Settings.TextToolStripButtonCheckState = TextToolStripButton.CheckState
    My.Settings.ExcelToolStripButtonCheckState = ExcelToolStripButton.CheckState
    My.Settings.AccessToolStripButtonCheckState = AccessToolStripButton.CheckState

  End Sub

  Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Try
      RemoteOpenSQL = New RemoteOpenSQLLib.RemoteOpenSQL

      AbapCodeToInstallForm.AbapCodeTextBox.Text = RemoteOpenSQL.GetAbapCodeRfcRemoteOpenSql
      AbapCodeToInstallForm.AbapCodeTextBox.Select(0, 0)
      RemoteOpenSQLGrammarForm.GrammarTextBox.Text = RemoteOpenSQL.GetRemoteOpenSQLGrammar
      RemoteOpenSQLGrammarForm.GrammarTextBox.Select(0, 0)

      RemoteOpenSQLDestinationsFullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RemoteOpenSQLDestinations.xml")
      RemoteOpenSQLQueriesFullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RemoteOpenSQLQueries.xml")

      If File.Exists(RemoteOpenSQLDestinationsFullPath) Then
        RemoteOpenSQLDestinations.ReadXml(RemoteOpenSQLDestinationsFullPath, XmlReadMode.IgnoreSchema)
      End If

      If RemoteOpenSQLDestinations.DestinationTree.Rows.Count = 0 Then
        DestinationSelectedID = RemoteOpenSQLDestinations.DestinationTree.AddDestinationTreeRow(0, True, "Destinations", True).ID
      End If

      If File.Exists(RemoteOpenSQLQueriesFullPath) Then
        RemoteOpenSQLQueries.ReadXml(RemoteOpenSQLQueriesFullPath, XmlReadMode.IgnoreSchema)
      End If

      If RemoteOpenSQLQueries.QueryTree.Rows.Count = 0 Then
        QuerySelectedID = RemoteOpenSQLQueries.QueryTree.AddQueryTreeRow(0, True, "Queries", True).ID
      End If

      UpdateDestinationTree()
      UpdateQueryTree()

      If MainTabControl.SelectedTab Is LogonTabPage Then
        DestinationTreeView.Select()
      End If

      If MainTabControl.SelectedTab Is QueriesTabPage Then
        QueryTreeView.Select()
      End If

      ConsumerTypeToolStripButtons.Add(TextToolStripButton)
      ConsumerTypeToolStripButtons.Add(ExcelToolStripButton)
      ConsumerTypeToolStripButtons.Add(AccessToolStripButton)

      TextToolStripButton.CheckState = My.Settings.TextToolStripButtonCheckState
      ExcelToolStripButton.CheckState = My.Settings.ExcelToolStripButtonCheckState
      AccessToolStripButton.CheckState = My.Settings.AccessToolStripButtonCheckState

      If My.Settings.PartitionSizeTextBox = String.Empty Then
        My.Settings.PartitionSizeTextBox = "50000"
      End If
      If My.Settings.BufferTextBox = String.Empty Then
        My.Settings.BufferTextBox = "100"
      End If

      For Each Control In Me.AllControls
        If TypeOf Control Is TextBox Then
          AddHandler Control.KeyPress, AddressOf TextBox_KeyPress
        End If
      Next

    Catch ex As Exception
      MsgBox(ex.ToString)
    End Try

  End Sub

  Private Sub DestinationNewFolderToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinationNewFolderToolStripButton.Click
    AddNewDestinationRow(True)
  End Sub

  Private Sub UpdateDestinationTree()
    With DestinationTreeView
      .BeginUpdate()
      .Nodes.Clear()

      For Each DestinationTreeRow In RemoteOpenSQLDestinations.DestinationTree
        Dim AddedNode As TreeNode = Nothing
        Dim FatherNode As TreeNode = Nothing
        If DestinationTreeRow.ID = 0 Then
          AddedNode = .Nodes.Add(DestinationTreeRow.ID.ToString, DestinationTreeRow.Name, IIf(DestinationTreeRow.IsFolder, 0, 1), IIf(DestinationTreeRow.IsFolder, 0, 1))
        Else
          FatherNode = .Nodes.Find(DestinationTreeRow.FatherID.ToString, True)(0)
          AddedNode = FatherNode.Nodes.Add(DestinationTreeRow.ID.ToString, DestinationTreeRow.Name, IIf(DestinationTreeRow.IsFolder, 0, 1), IIf(DestinationTreeRow.IsFolder, 0, 1))
          If CType(RemoteOpenSQLDestinations.DestinationTree.Rows.Find(Integer.Parse(FatherNode.Tag)), RemoteOpenSQLDestinations.DestinationTreeRow).IsExpanded Then
            FatherNode.Expand()
          End If
        End If
        AddedNode.Tag = DestinationTreeRow.ID
      Next
      .Sort()
      If .Nodes.Count > 0 Then
        .Nodes(0).Expand()
      End If

      Dim FoundNodes() As TreeNode = .Nodes.Find(DestinationSelectedID.ToString, True)
      If FoundNodes.Count > 0 Then
        .SelectedNode = FoundNodes(0)
        .SelectedNode.EnsureVisible()
      End If
      .Focus()

      .EndUpdate()
      .Refresh()
    End With
  End Sub

  Private Sub UpdateQueryTree(Optional ByVal SelectedID As Integer = -1)
    With QueryTreeView
      .BeginUpdate()
      .Nodes.Clear()

      For Each QueryTreeRow In RemoteOpenSQLQueries.QueryTree
        Dim AddedNode As TreeNode = Nothing
        If QueryTreeRow.ID = 0 Then
          AddedNode = .Nodes.Add(QueryTreeRow.ID.ToString, QueryTreeRow.Name, IIf(QueryTreeRow.IsFolder, 0, 1), IIf(QueryTreeRow.IsFolder, 0, 1))
        Else
          AddedNode = .Nodes.Find(QueryTreeRow.FatherID.ToString, True)(0).Nodes.Add(QueryTreeRow.ID.ToString, QueryTreeRow.Name, IIf(QueryTreeRow.IsFolder, 0, 1), IIf(QueryTreeRow.IsFolder, 0, 1))
        End If
        AddedNode.Tag = QueryTreeRow.ID
      Next
      .Sort()
      If .Nodes.Count > 0 Then
        .Nodes(0).Expand()
      End If

      Dim FoundNodes() As TreeNode = .Nodes.Find(QuerySelectedID.ToString, True)
      If FoundNodes.Count > 0 Then
        .SelectedNode = FoundNodes(0)
        .SelectedNode.EnsureVisible()
      End If
      .Focus()

      .EndUpdate()
      .Refresh()
    End With
  End Sub

  Private Property DestinationSelectedID() As Integer
    Get
      With RemoteOpenSQLDestinations.DestinationTreeSelectedID
        If .Rows.Count = 0 Then
          .AddDestinationTreeSelectedIDRow(0)
          Return 0
        Else
          Return .Item(0).SelectedID
        End If
      End With
    End Get
    Set(ByVal value As Integer)
      With RemoteOpenSQLDestinations.DestinationTreeSelectedID
        If .Rows.Count = 0 Then
          .AddDestinationTreeSelectedIDRow(value)
        Else
          .Item(0).SelectedID = value
        End If
      End With
    End Set
  End Property

  Private Property QuerySelectedID() As Integer
    Get
      With RemoteOpenSQLQueries.QueriesTreeSelectedID
        If .Rows.Count = 0 Then
          .AddQueriesTreeSelectedIDRow(0)
          Return 0
        Else
          Return .Item(0).SelectedID
        End If
      End With
    End Get
    Set(ByVal value As Integer)
      With RemoteOpenSQLQueries.QueriesTreeSelectedID
        If .Rows.Count = 0 Then
          .AddQueriesTreeSelectedIDRow(value)
        Else
          .Item(0).SelectedID = value
        End If
      End With
    End Set
  End Property

  Private Sub AddNewDestinationRow(ByVal IsFolder As Boolean)

    Dim NewName As String

    If IsFolder Then
      NewName = InputBox("Name", "Folder Name")
    Else
      NewName = InputBox("Name", "Destination Name")
    End If

    Dim NewID As Integer

    If NewName = String.Empty Then
      Exit Sub
    End If

    With RemoteOpenSQLDestinations.DestinationTree
      If DestinationTreeView.SelectedNode Is Nothing Then
        Try
          NewID = .AddDestinationTreeRow(0, IsFolder, NewName, True).ID
        Catch ex As System.Data.ConstraintException
          MsgBox("The name " & NewName & " already exists.", MsgBoxStyle.Critical)
          Exit Sub
        End Try
      Else
        Dim FolderTreeRow = CType(.Rows.Find(DestinationTreeView.SelectedNode.Tag), RemoteOpenSQLDestinations.DestinationTreeRow)
        If Not FolderTreeRow.IsFolder Then
          FolderTreeRow = CType(.Rows.Find(FolderTreeRow.FatherID), RemoteOpenSQLDestinations.DestinationTreeRow)
        End If
        Try
          NewID = .AddDestinationTreeRow(FolderTreeRow.ID, IsFolder, NewName, True).ID
        Catch ex As Exception
          MsgBox("The name " & NewName & " already exists.", MsgBoxStyle.Critical)
          Exit Sub
        End Try
      End If
    End With

    DestinationSelectedID = NewID
    UpdateDestinationTree()
  End Sub

  Private Sub AddNewQueryRow(ByVal IsFolder As Boolean)

    Dim NewName As String

    If IsFolder Then
      NewName = InputBox("Name", "Folder Name")
    Else
      NewName = InputBox("Name", "Query Name")
    End If

    Dim NewID As Integer

    If NewName = String.Empty Then
      Exit Sub
    End If

    With RemoteOpenSQLQueries.QueryTree
      If QueryTreeView.SelectedNode Is Nothing Then
        Try
          NewID = .AddQueryTreeRow(0, IsFolder, NewName, True).ID
        Catch ex As System.Data.ConstraintException
          MsgBox("The name " & NewName & " already exists.", MsgBoxStyle.Critical)
          Exit Sub
        End Try
      Else
        Dim FolderTreeRow = CType(.Rows.Find(QueryTreeView.SelectedNode.Tag), RemoteOpenSQLQueries.QueryTreeRow)
        If Not FolderTreeRow.IsFolder Then
          FolderTreeRow = CType(.Rows.Find(FolderTreeRow.FatherID), RemoteOpenSQLQueries.QueryTreeRow)
        End If
        Try
          NewID = .AddQueryTreeRow(FolderTreeRow.ID, IsFolder, NewName, True).ID
        Catch ex As System.Data.ConstraintException
          MsgBox("The name " & NewName & " already exists.", MsgBoxStyle.Critical)
          Exit Sub
        End Try
      End If
    End With

    QuerySelectedID = NewID
    UpdateQueryTree()
  End Sub

  Private Sub DestinationNewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinationNewToolStripButton.Click
    AddNewDestinationRow(False)
  End Sub

  Private Sub DestinationDeleteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinationDeleteToolStripButton.Click
    If Not DestinationTreeView.SelectedNode Is Nothing AndAlso Not DestinationTreeView.SelectedNode Is DestinationTreeView.Nodes(0) AndAlso MessageBox.Show("Delete " & DestinationTreeView.SelectedNode.Text & " ?", "Delete", MessageBoxButtons.YesNoCancel) = vbYes Then
      Dim NodesToDelete = New List(Of TreeNode)()
      Dim NextSelectedNode = DestinationTreeView.SelectedNode.PrevVisibleNode
      NodesToDelete.Add(DestinationTreeView.SelectedNode)
      Do While NodesToDelete.Count > 0
        If NodesToDelete(0).Nodes.Count > 0 Then
          For Each NodeItem In NodesToDelete(0).Nodes
            NodesToDelete.Add(NodeItem)
          Next
        End If
        RemoteOpenSQLDestinations.DestinationTree.Rows.Find(NodesToDelete(0).Tag).Delete()
        NodesToDelete.RemoveAt(0)
      Loop
      If Not NextSelectedNode Is Nothing Then
        DestinationSelectedID = Integer.Parse(NextSelectedNode.Tag)
      End If

      UpdateDestinationTree()
    End If
  End Sub

  Private Sub DestinationTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles DestinationTreeView.AfterSelect
    DestinationSelectedID = Integer.Parse(e.Node.Tag)
    DestinationPassword.Text = ""

    With RemoteOpenSQLDestinations
      .Destination.AcceptChanges()
      Dim DestinationTreeRow = CType(.DestinationTree.Rows.Find(e.Node.Tag), RemoteOpenSQLDestinations.DestinationTreeRow)
      If DestinationTreeRow.IsFolder Then
        For Each ControlItem In DestinationsSplitContainer.Panel2.Controls
          CType(ControlItem, Control).Visible = False
        Next
      Else
        For Each ControlItem In DestinationsSplitContainer.Panel2.Controls
          CType(ControlItem, Control).Visible = True
        Next
        Dim DestinationRow = .Destination.Rows.Find(e.Node.Tag)
        If DestinationRow Is Nothing Then
          .Destination.AddDestinationRow(DestinationTreeRow, "", "", 0, 0, "", "")
        End If
        With DestinationBindingSource
          .Position = .Find("ID", Integer.Parse(e.Node.Tag))
        End With
      End If

    End With
  End Sub

  Private Sub QueriesTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles QueryTreeView.AfterSelect
    QuerySelectedID = Integer.Parse(e.Node.Tag)

    OutputTextBox.Text = String.Empty

    With RemoteOpenSQLQueries
      .Query.AcceptChanges()
      Dim QueryTreeRow As RemoteOpenSQLQueries.QueryTreeRow
      With QueryTreeBindingSource
        .Position = .Find("ID", QuerySelectedID)
        If .Current Is Nothing Then
          Exit Sub
        End If
        QueryTreeRow = CType(.Current.row, RemoteOpenSQLQueries.QueryTreeRow)
      End With

      If QueryTreeRow.IsFolder Then
        For Each ControlItem In QueriesSplitContainer.Panel2.Controls
          CType(ControlItem, Control).Visible = False
        Next
        StartToolStripButton.Enabled = False
        StopToolStripButton.Enabled = False
        ViewToolStripButton.Enabled = False
      Else
        For Each ControlItem In QueriesSplitContainer.Panel2.Controls
          CType(ControlItem, Control).Visible = True
        Next
        Dim QueryRow = .Query.Rows.Find(e.Node.Tag)
        If QueryRow Is Nothing Then
          .Query.AddQueryRow(QueryTreeRow, "", "")
        End If
        With QueryBindingSource
          .Position = .Find("ID", QuerySelectedID)
        End With
        StartToolStripButton.Enabled = True
        StopToolStripButton.Enabled = False
        ViewToolStripButton.Enabled = False
      End If

    End With
  End Sub

  Private Sub DestinationTreeView_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles DestinationTreeView.AfterExpand
    CType(RemoteOpenSQLDestinations.DestinationTree.Rows.Find(Integer.Parse(e.Node.Tag)), RemoteOpenSQLDestinations.DestinationTreeRow).IsExpanded = e.Node.IsExpanded
  End Sub

  Private Sub DestinationTreeView_AfterCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles DestinationTreeView.AfterCollapse
    CType(RemoteOpenSQLDestinations.DestinationTree.Rows.Find(Integer.Parse(e.Node.Tag)), RemoteOpenSQLDestinations.DestinationTreeRow).IsExpanded = e.Node.IsExpanded
  End Sub

  Private Sub DestinationTreeView_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles DestinationTreeView.AfterLabelEdit
    If e.Label Is Nothing Then
      Exit Sub
    End If
    CType(RemoteOpenSQLDestinations.DestinationTree.Rows.Find(Integer.Parse(e.Node.Tag)), RemoteOpenSQLDestinations.DestinationTreeRow).Name = e.Label
  End Sub

  Private Sub MainTabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainTabControl.SelectedIndexChanged
    If MainTabControl.SelectedTab Is LogonTabPage Then
      DestinationTreeView.Select()
    End If

    If MainTabControl.SelectedTab Is QueriesTabPage Then
      QueryTreeView.Select()
    End If
  End Sub

  Private Sub TextPathButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    FolderBrowserDialog.SelectedPath = OptionsForm.TextPathTextBox.Text
    If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
      OptionsForm.TextPathTextBox.Text = FolderBrowserDialog.SelectedPath
    End If
  End Sub

  Private Sub TextApplicationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    OpenFileDialog.DefaultExt = "exe"
    OpenFileDialog.Filter = "Application (*.exe)|*.exe"
    If OptionsForm.TextApplicationTextBox.Text <> String.Empty Then
      OpenFileDialog.InitialDirectory = Path.GetDirectoryName(OptionsForm.TextApplicationTextBox.Text)
      OpenFileDialog.FileName = Path.GetFileName(OptionsForm.TextApplicationTextBox.Text)
    End If

    If OpenFileDialog.ShowDialog = DialogResult.OK Then
      OptionsForm.TextApplicationTextBox.Text = OpenFileDialog.FileName
    End If
  End Sub

  Private Sub ExcelPathButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    FolderBrowserDialog.SelectedPath = OptionsForm.ExcelPathTextBox.Text
    If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
      OptionsForm.ExcelPathTextBox.Text = FolderBrowserDialog.SelectedPath
    End If
  End Sub

  Private Sub AccessPathButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    OpenFileDialog.DefaultExt = "accdb"
    OpenFileDialog.Filter = "Microsoft Access (*.accdb;*.mdb)|*.accdb;*.mdb"
    If OptionsForm.AccessPathTextBox.Text <> String.Empty Then
      OpenFileDialog.InitialDirectory = Path.GetDirectoryName(OptionsForm.AccessPathTextBox.Text)
      OpenFileDialog.FileName = Path.GetFileName(OptionsForm.AccessPathTextBox.Text)
    End If

    If OpenFileDialog.ShowDialog = DialogResult.OK Then
      OptionsForm.AccessPathTextBox.Text = OpenFileDialog.FileName
    End If
  End Sub

  Private Sub QueryNewFolderToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryNewFolderToolStripButton.Click
    AddNewQueryRow(True)
  End Sub

  Private Sub QueryNewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryNewToolStripButton.Click
    AddNewQueryRow(False)
  End Sub

  Private Sub QueryDeleteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryDeleteToolStripButton.Click
    With QueryTreeView
      If Not .SelectedNode Is Nothing AndAlso Not .SelectedNode Is .Nodes(0) AndAlso MessageBox.Show("Delete " & .SelectedNode.Text & " ?", "Delete", MessageBoxButtons.YesNoCancel) = vbYes Then
        Dim NodesToDelete = New List(Of TreeNode)()
        Dim NextSelectedNode = .SelectedNode.PrevVisibleNode
        NodesToDelete.Add(.SelectedNode)
        Do While NodesToDelete.Count > 0
          If NodesToDelete(0).Nodes.Count > 0 Then
            For Each NodeItem In NodesToDelete(0).Nodes
              NodesToDelete.Add(NodeItem)
            Next
          End If
          RemoteOpenSQLQueries.QueryTree.Rows.Find(NodesToDelete(0).Tag).Delete()
          NodesToDelete.RemoveAt(0)
        Loop
        If Not NextSelectedNode Is Nothing Then
          QuerySelectedID = Integer.Parse(NextSelectedNode.Tag)
        End If

        UpdateQueryTree()
      End If
    End With
  End Sub

  Private Sub QueryTreeView_AfterCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles QueryTreeView.AfterCollapse
    CType(RemoteOpenSQLQueries.QueryTree.Rows.Find(Integer.Parse(e.Node.Tag)), RemoteOpenSQLQueries.QueryTreeRow).IsExpanded = e.Node.IsExpanded
  End Sub

  Private Sub QueryTreeView_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles QueryTreeView.AfterExpand
    CType(RemoteOpenSQLQueries.QueryTree.Rows.Find(Integer.Parse(e.Node.Tag)), RemoteOpenSQLQueries.QueryTreeRow).IsExpanded = e.Node.IsExpanded
  End Sub

  Private Sub QueryTreeView_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles QueryTreeView.AfterLabelEdit
    If e.Label Is Nothing Then
      Exit Sub
    End If
    CType(RemoteOpenSQLQueries.QueryTree.Rows.Find(Integer.Parse(e.Node.Tag)), RemoteOpenSQLQueries.QueryTreeRow).Name = e.Label
  End Sub

  Private Sub QueryStartToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartToolStripButton.Click

    OutputTextBox.Text = String.Empty
    Dim QueryName = Replace(CType(QueryTreeBindingSource.Current.row, RemoteOpenSQLQueries.QueryTreeRow).Name, " ", "")

    If My.Settings.TextToolStripButtonCheckState = CheckState.Checked Then
      If My.Settings.TextApplicationTextBox <> String.Empty AndAlso Not File.Exists(My.Settings.TextApplicationTextBox) Then
        MsgBox("File " & My.Settings.TextApplicationTextBox & " not found.", vbCritical)
        Exit Sub
      End If
      Consumer = New DelimitedTextFileConsumer(QueryName, My.Settings.TextPathTextBox)
      CType(Consumer, DelimitedTextFileConsumer).ViewerPath = My.Settings.TextApplicationTextBox
    ElseIf My.Settings.ExcelToolStripButtonCheckState = CheckState.Checked Then
      Consumer = New MicrosoftExcelConsumer(QueryName, My.Settings.ExcelPathTextBox)
    ElseIf My.Settings.AccessToolStripButtonCheckState = CheckState.Checked Then
      If Not File.Exists(My.Settings.AccessPathTextBox) Then
        MsgBox("File " & My.Settings.AccessPathTextBox & " not found.", vbCritical)
        Exit Sub
      End If
      Consumer = New MicrosoftAccessConsumer(QueryName, My.Settings.AccessPathTextBox)
    Else
      Consumer = New DelimitedTextFileConsumer(QueryName, My.Settings.TextPathTextBox)
      CType(Consumer, DelimitedTextFileConsumer).ViewerPath = My.Settings.TextApplicationTextBox
    End If

    If DestinationBindingSource.Current Is Nothing Then
      MsgBox("Please select a valid destination first.", MsgBoxStyle.Information)
      Exit Sub
    End If

    If DestinationPassword.Text = String.Empty Then
      DestinationPassword.Text = PasswordForm.GetPassword
    End If

    If DestinationPassword.Text = String.Empty Then
      Exit Sub
    End If

    QueryStartTime = Now
    QueryTimer.Enabled = True

    With CType(DestinationBindingSource.Current.row, RemoteOpenSQLDestinations.DestinationRow)

      Try
        RemoteOpenSQL.SetLogonParameters(
          .AppServerHost,
          .SystemNumber,
          .Client,
          .Username,
          DestinationPassword.Text,
          .SAPRouterString)
      Catch ex As Exception
        DestinationPassword.Text = ""
        OutputTextBox.Text += ex.ToString & vbCrLf
        Exit Sub
      End Try

    End With

    Dim PartitionSize As Integer
    If Integer.TryParse(My.Settings.PartitionSizeTextBox, PartitionSize) Then
      If PartitionSize > 2000000 Then
        PartitionSize = 2000000
      ElseIf PartitionSize < 1000 And PartitionSize > 0 Then
        PartitionSize = 1000
      ElseIf PartitionSize = 0 Then
        PartitionSize = 50000
      End If
    Else
      PartitionSize = 50000
    End If

    Dim Buffer As Integer
    If Integer.TryParse(My.Settings.BufferTextBox, Buffer) Then
      If Buffer > 1000 Then
        Buffer = 1000
      ElseIf Buffer < 10 And Buffer > 0 Then
        Buffer = 10
      ElseIf Buffer = 0 Then
        Buffer = 100
      End If
    Else
      Buffer = 100
    End If

    RemoteOpenSQL.PartitionSize = PartitionSize
    RemoteOpenSQL.Buffer = Buffer
    RemoteOpenSQL.StartRunQuery(QueryTextBox.Text, Consumer)

    StartToolStripButton.Enabled = False
    StopToolStripButton.Enabled = True
    ViewToolStripButton.Enabled = False
    QueryToolStripProgressBar.Style = ProgressBarStyle.Marquee
  End Sub

  Private Sub RemoteOpenSQL_QueryExecuted(ByVal sender As RemoteOpenSQLLib.RemoteOpenSQL, ByVal e As QueryExecutedEventArgs) Handles RemoteOpenSQL.QueryExecuted
    Me.UIThreadInvoke(Sub()
                        StartToolStripButton.Enabled = True
                        StopToolStripButton.Enabled = False
                        If e.Exception Is Nothing Then
                          ViewToolStripButton.Enabled = True
                        Else
                          ViewToolStripButton.Enabled = False
                          OutputTextBox.Text += e.Exception.ToString & vbCrLf
                        End If
                        QueryToolStripProgressBar.Style = ProgressBarStyle.Blocks
                        QueryTimer.Enabled = False
                      End Sub)
  End Sub

  Private Sub RemoteOpenSQL_QueryStatusChanged(ByVal sender As RemoteOpenSQLLib.RemoteOpenSQL, ByVal e As QueryStatusChangedEventArgs) Handles RemoteOpenSQL.QueryStatusChanged
    Me.UIThreadInvoke(Sub()
                        OutputTextBox.AppendText(e.StatusText & vbCrLf)
                        OutputTextBox.ScrollToCaret()
                      End Sub)
  End Sub

  Private Sub QueryTreeView_BeforeSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles QueryTreeView.BeforeSelect
    If RemoteOpenSQL.Status = Threading.Tasks.TaskStatus.Running Then
      e.Cancel = True
    End If
  End Sub

  Private Sub QueryQuickOpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewToolStripButton.Click
    Try
      Consumer.ViewData()
    Catch ex As Exception
      OutputTextBox.Text += ex.ToString & vbCrLf
      Exit Sub
    End Try
  End Sub

  Private Sub NumericKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    Dim SenderTextBox As TextBox = sender

    If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
      e.Handled = True
    End If

  End Sub

  Private Sub QueryTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryTimer.Tick
    QueryToolStripStatusLabel.Text = New TimeSpan(0, 0, DateDiff(DateInterval.Second, QueryStartTime, Now)).ToString
  End Sub

  Private Sub QueryStopToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripButton.Click
    RemoteOpenSQL.StopQuery()
  End Sub

  Private Sub PrivacyCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles PrivacyCheckBox.CheckedChanged
    If PrivacyCheckBox.Checked Then
      For Each ControlItem In CType(DestinationsSplitContainer.Panel2.Controls(0), GroupBox).Controls
        If TypeOf (ControlItem) Is TextBox AndAlso Not ControlItem Is DestinationPassword Then
          CType(ControlItem, TextBox).PasswordChar = "*"
          CType(ControlItem, TextBox).UseSystemPasswordChar = True
        End If
      Next
    Else
      For Each ControlItem In CType(DestinationsSplitContainer.Panel2.Controls(0), GroupBox).Controls
        If TypeOf (ControlItem) Is TextBox AndAlso Not ControlItem Is DestinationPassword Then
          CType(ControlItem, TextBox).PasswordChar = ""
          CType(ControlItem, TextBox).UseSystemPasswordChar = False
        End If
      Next
    End If
  End Sub

  Private Sub AbabCodeToInstallToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AbabCodeToInstallToolStripMenuItem.Click
    AbapCodeToInstallForm.ShowDialog()
  End Sub

  Private Sub OptionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
    OptionsForm.ShowDialog()
  End Sub

  Private Sub RemoteOpenSQLGrammarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteOpenSQLGrammarToolStripMenuItem.Click
    RemoteOpenSQLGrammarForm.ShowDialog()
  End Sub

  Private Sub ConsumerTypeToolStripButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextToolStripButton.CheckedChanged, ExcelToolStripButton.CheckedChanged, AccessToolStripButton.CheckedChanged
    If Not CType(sender, ToolStripButton).Checked Then
      Exit Sub
    End If

    For Each ToolStripButton In ConsumerTypeToolStripButtons
      If Not ToolStripButton Is CType(sender, ToolStripButton) AndAlso ToolStripButton.Checked = True Then
        ToolStripButton.Checked = False
      End If
    Next
  End Sub

  Private Sub SaveDestinations(Optional ByRef Cancel As Boolean = False, Optional AskToSave As Boolean = True, Optional SaveAs As Boolean = False)
    If RemoteOpenSQLDestinations.HasChanges Then
      If AskToSave Then
        Select Case MsgBox("Do you want to save destinations chages?", MsgBoxStyle.YesNoCancel)
          Case MsgBoxResult.Cancel
            Cancel = True
            Exit Sub
          Case MsgBoxResult.No
            Exit Sub
        End Select
      End If

      If RemoteOpenSQLDestinationsFullPath = String.Empty OrElse SaveAs Then
        Select Case DestinationsSaveFileDialog.ShowDialog
          Case Windows.Forms.DialogResult.OK Or Windows.Forms.DialogResult.Yes
            RemoteOpenSQLDestinationsFullPath = DestinationsSaveFileDialog.FileName
          Case Else
            Cancel = True
            Exit Sub
        End Select
      End If

      If RemoteOpenSQLDestinationsFullPath = String.Empty Then
        Cancel = True
        Exit Sub
      End If

      RemoteOpenSQLDestinations.AcceptChanges()
      RemoteOpenSQLDestinations.WriteXml(RemoteOpenSQLDestinationsFullPath)

    End If
  End Sub

  Private Sub NewDestinationsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewDestinationsToolStripMenuItem.Click
    Dim Cancel As Boolean = False

    SaveDestinations(Cancel)

    If Cancel Then
      Exit Sub
    End If

    RemoteOpenSQLDestinationsFullPath = String.Empty
    RemoteOpenSQLDestinations.Clear()
    DestinationSelectedID = RemoteOpenSQLDestinations.DestinationTree.AddDestinationTreeRow(0, True, "Destinations", True).ID

    UpdateDestinationTree()
 
    If MainTabControl.SelectedTab Is LogonTabPage Then
      DestinationTreeView.Select()
    End If
  End Sub

  Private Sub SaveQueries(Optional ByRef Cancel As Boolean = False, Optional AskToSave As Boolean = True, Optional SaveAs As Boolean = False)
    If RemoteOpenSQLQueries.HasChanges Then
      If AskToSave Then
        Select Case MsgBox("Do you want to save queries chages?", MsgBoxStyle.YesNoCancel)
          Case MsgBoxResult.Cancel
            Cancel = True
            Exit Sub
          Case MsgBoxResult.No
            Exit Sub
        End Select
      End If

      If RemoteOpenSQLQueriesFullPath = String.Empty OrElse SaveAs Then
        Select Case QueriesSaveFileDialog.ShowDialog
          Case Windows.Forms.DialogResult.OK Or Windows.Forms.DialogResult.Yes
            RemoteOpenSQLQueriesFullPath = QueriesSaveFileDialog.FileName
          Case Else
            Cancel = True
            Exit Sub
        End Select
      End If

      If RemoteOpenSQLQueriesFullPath = String.Empty Then
        Cancel = True
        Exit Sub
      End If

      RemoteOpenSQLQueries.AcceptChanges()
      RemoteOpenSQLQueries.WriteXml(RemoteOpenSQLQueriesFullPath)

    End If
  End Sub

  Private Sub NewQueriesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewQueriesToolStripMenuItem.Click
    Dim Cancel As Boolean = False

    SaveQueries(Cancel)

    If Cancel Then
      Exit Sub
    End If

    RemoteOpenSQLQueriesFullPath = String.Empty
    RemoteOpenSQLQueries.Clear()
    QuerySelectedID = RemoteOpenSQLQueries.QueryTree.AddQueryTreeRow(0, True, "Queries", True).ID

    UpdateQueryTree()

    If MainTabControl.SelectedTab Is QueriesTabPage Then
      QueryTreeView.Select()
    End If
  End Sub

  Private Sub OpenDestinationsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenDestinationsToolStripMenuItem.Click
    Dim Cancel As Boolean = False

    SaveDestinations(Cancel)

    If Cancel Then
      Exit Sub
    End If

    If File.Exists(RemoteOpenSQLDestinationsFullPath) Then
      DestinationsOpenFileDialog.InitialDirectory = Path.GetDirectoryName(RemoteOpenSQLDestinationsFullPath)
    End If

    Select Case DestinationsOpenFileDialog.ShowDialog
      Case Windows.Forms.DialogResult.OK Or Windows.Forms.DialogResult.Yes

        RemoteOpenSQLDestinationsFullPath = DestinationsOpenFileDialog.FileName

        If File.Exists(RemoteOpenSQLDestinationsFullPath) Then
          RemoteOpenSQLDestinations.ReadXml(RemoteOpenSQLDestinationsFullPath, XmlReadMode.IgnoreSchema)
        End If

        UpdateDestinationTree()
 
        If MainTabControl.SelectedTab Is LogonTabPage Then
          DestinationTreeView.Select()
        End If
    End Select
  End Sub

  Private Sub OpenQueriesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenQueriesToolStripMenuItem.Click
    Dim Cancel As Boolean = False

    SaveQueries(Cancel)

    If Cancel Then
      Exit Sub
    End If

    If File.Exists(RemoteOpenSQLQueriesFullPath) Then
      QueriesOpenFileDialog.InitialDirectory = Path.GetDirectoryName(RemoteOpenSQLQueriesFullPath)
    End If

    Select Case QueriesOpenFileDialog.ShowDialog
      Case Windows.Forms.DialogResult.OK Or Windows.Forms.DialogResult.Yes

        RemoteOpenSQLQueriesFullPath = QueriesOpenFileDialog.FileName

        If File.Exists(RemoteOpenSQLQueriesFullPath) Then
          RemoteOpenSQLQueries.ReadXml(RemoteOpenSQLQueriesFullPath, XmlReadMode.IgnoreSchema)
        End If

        UpdateQueryTree()

        If MainTabControl.SelectedTab Is QueriesTabPage Then
          QueryTreeView.Select()
        End If
    End Select

  End Sub

  Private Sub SaveDestinationsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveDestinationsToolStripMenuItem.Click
    SaveDestinations(, False)
  End Sub

  Private Sub SaveQueriesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveQueriesToolStripMenuItem.Click
    SaveQueries(, False)
  End Sub

  Private Sub SaveDestinationsAsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveDestinationsAsToolStripMenuItem.Click
    SaveDestinations(, False, True)
  End Sub

  Private Sub SaveQueriesAsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveQueriesAsToolStripMenuItem.Click
    SaveQueries(, False, True)
  End Sub

  Private Sub ImportDestinationsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImportDestinationsToolStripMenuItem.Click

  End Sub

  Private Sub ImportQueriesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImportQueriesToolStripMenuItem.Click

  End Sub
End Class
