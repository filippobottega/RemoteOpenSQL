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
  Private OutputFormatRadioButtons As New List(Of RadioButton)
  Private Consumer As DataConsumer
  Private QueryStartTime As DateTime

  Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    RemoteOpenSQLDestinations.Destination.AcceptChanges()
    RemoteOpenSQLDestinations.WriteXml(RemoteOpenSQLDestinationsFullPath)
    RemoteOpenSQLQueries.Query.AcceptChanges()
    RemoteOpenSQLQueries.WriteXml(RemoteOpenSQLQueriesFullPath)

    My.Settings.TextRadioButton = TextRadioButton.Checked
    My.Settings.ExcelRadioButton = ExcelRadioButton.Checked
    My.Settings.AccessRadioButton = AccessRadioButton.Checked
  End Sub

  Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Try
      RemoteOpenSQL = New RemoteOpenSQLLib.RemoteOpenSQL

      AbapCodeTextBox.Text = RemoteOpenSQL.GetAbapCodeRfcRemoteOpenSql
      GrammarTextBox.Text = RemoteOpenSQL.GetRemoteOpenSQLGrammar

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

      For Each ControItem In GetAllControls(OutputFormatGroupBox.Controls)
        If TypeOf (ControItem) Is RadioButton Then
          OutputFormatRadioButtons.Add(CType(ControItem, RadioButton))
        End If
      Next

      TextRadioButton.Checked = My.Settings.TextRadioButton
      ExcelRadioButton.Checked = My.Settings.ExcelRadioButton
      AccessRadioButton.Checked = My.Settings.AccessRadioButton
      If PartitionSizeTextBox.Text = String.Empty Then
        PartitionSizeTextBox.Text = "50000"
      End If
      If BufferTextBox.Text = String.Empty Then
        BufferTextBox.Text = "100"
      End If
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
        NewID = .AddDestinationTreeRow(0, IsFolder, NewName, True).ID
      Else
        Dim FolderTreeRow = CType(.Rows.Find(DestinationTreeView.SelectedNode.Tag), RemoteOpenSQLDestinations.DestinationTreeRow)
        If Not FolderTreeRow.IsFolder Then
          FolderTreeRow = CType(.Rows.Find(FolderTreeRow.FatherID), RemoteOpenSQLDestinations.DestinationTreeRow)
        End If
        NewID = .AddDestinationTreeRow(FolderTreeRow.ID, IsFolder, NewName, True).ID
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
        NewID = .AddQueryTreeRow(0, IsFolder, NewName, True).ID
      Else
        Dim FolderTreeRow = CType(.Rows.Find(QueryTreeView.SelectedNode.Tag), RemoteOpenSQLQueries.QueryTreeRow)
        If Not FolderTreeRow.IsFolder Then
          FolderTreeRow = CType(.Rows.Find(FolderTreeRow.FatherID), RemoteOpenSQLQueries.QueryTreeRow)
        End If
        NewID = .AddQueryTreeRow(FolderTreeRow.ID, IsFolder, NewName, True).ID
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
      Dim QueryTreeRow = CType(.QueryTree.Rows.Find(e.Node.Tag), RemoteOpenSQLQueries.QueryTreeRow)
      If QueryTreeRow.IsFolder Then
        For Each ControlItem In QueriesSplitContainer.Panel2.Controls
          CType(ControlItem, Control).Visible = False
        Next
        QueryStartToolStripButton.Enabled = False
        QueryStopToolStripButton.Enabled = False
        QueryQuickOpenToolStripButton.Enabled = False
      Else
        For Each ControlItem In QueriesSplitContainer.Panel2.Controls
          CType(ControlItem, Control).Visible = True
        Next
        Dim QueryRow = .Query.Rows.Find(e.Node.Tag)
        If QueryRow Is Nothing Then
          .Query.AddQueryRow(QueryTreeRow, "", "")
        End If
        With QueryBindingSource
          .Position = .Find("ID", Integer.Parse(e.Node.Tag))
        End With
        QueryStartToolStripButton.Enabled = True
        QueryStopToolStripButton.Enabled = False
        QueryQuickOpenToolStripButton.Enabled = False
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

  Private Sub OutputFormatRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextRadioButton.CheckedChanged, ExcelRadioButton.CheckedChanged, AccessRadioButton.CheckedChanged
    If Not CType(sender, RadioButton).Checked Then
      Exit Sub
    End If

    For Each RadioButton In OutputFormatRadioButtons
      If Not RadioButton Is CType(sender, RadioButton) AndAlso RadioButton.Checked = True Then
        RadioButton.Checked = False
      End If
    Next
  End Sub

  Private Function GetAllControls(ByRef Controls As System.Windows.Forms.Control.ControlCollection) As List(Of Control)
    Dim Result = New List(Of Control)
    For Each ControlItem As Control In Controls
      Result.Add(ControlItem)
      Result.AddRange(GetAllControls(ControlItem.Controls))
    Next
    Return Result
  End Function

  Private Sub TextPathButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextPathButton.Click
    FolderBrowserDialog.SelectedPath = TextPathTextBox.Text
    If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
      TextPathTextBox.Text = FolderBrowserDialog.SelectedPath
    End If
  End Sub

  Private Sub TextApplicationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextApplicationButton.Click
    OpenFileDialog.DefaultExt = "exe"
    OpenFileDialog.Filter = "Application (*.exe)|*.exe"
    If TextApplicationTextBox.Text <> String.Empty Then
      OpenFileDialog.InitialDirectory = Path.GetDirectoryName(TextApplicationTextBox.Text)
      OpenFileDialog.FileName = Path.GetFileName(TextApplicationTextBox.Text)
    End If

    If OpenFileDialog.ShowDialog = DialogResult.OK Then
      TextApplicationTextBox.Text = OpenFileDialog.FileName
    End If
  End Sub

  Private Sub ExcelPathButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelPathButton.Click
    FolderBrowserDialog.SelectedPath = ExcelPathTextBox.Text
    If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
      ExcelPathTextBox.Text = FolderBrowserDialog.SelectedPath
    End If
  End Sub

  Private Sub AccessPathButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccessPathButton.Click
    OpenFileDialog.DefaultExt = "accdb"
    OpenFileDialog.Filter = "Microsoft Access (*.accdb;*.mdb)|*.accdb;*.mdb"
    If AccessPathTextBox.Text <> String.Empty Then
      OpenFileDialog.InitialDirectory = Path.GetDirectoryName(AccessPathTextBox.Text)
      OpenFileDialog.FileName = Path.GetFileName(AccessPathTextBox.Text)
    End If

    If OpenFileDialog.ShowDialog = DialogResult.OK Then
      AccessPathTextBox.Text = OpenFileDialog.FileName
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
    CType(RemoteOpenSQLQueries.QueryTree.Rows.Find(Integer.Parse(e.Node.Tag)), RemoteOpenSQLQueries.QueryTreeRow).Name = e.Label
  End Sub

  Private Sub QueryStartToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryStartToolStripButton.Click

    OutputTextBox.Text = String.Empty

    If TextRadioButton.Checked Then
      If TextApplicationTextBox.Text <> String.Empty AndAlso Not File.Exists(TextApplicationTextBox.Text) Then
        MsgBox("File " & TextApplicationTextBox.Text & " not found.", vbCritical)
        Exit Sub
      End If
      Consumer = New DelimitedTextFileConsumer(TextPathTextBox.Text)
      CType(Consumer, DelimitedTextFileConsumer).ViewerPath = TextApplicationTextBox.Text
    ElseIf ExcelRadioButton.Checked Then
      Consumer = New MicrosoftExcelConsumer(ExcelPathTextBox.Text)
    ElseIf AccessRadioButton.Checked Then
      If Not File.Exists(AccessPathTextBox.Text) Then
        MsgBox("File " & AccessPathTextBox.Text & " not found.", vbCritical)
        Exit Sub
      End If
      Consumer = New MicrosoftAccessConsumer(AccessPathTextBox.Text)
    Else
      Consumer = New DelimitedTextFileConsumer(TextPathTextBox.Text)
      CType(Consumer, DelimitedTextFileConsumer).ViewerPath = TextApplicationTextBox.Text
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
#If DEBUG Then
      RemoteOpenSQL.SetLogonParameters(
        .AppServerHost,
        .SystemNumber,
        .Client,
        .Username,
        DestinationPassword.Text,
        .SAPRouterString)
#Else
      Try
        RemoteOpenSQL.SetLogonParameters(
          .AppServerHost,
          .SystemNumber,
          .Client,
          .Username,
          DestinationPassword.Text,
          .SAPRouterString)
      Catch ex As Exception
        OutputTextBox.Text += ex.ToString & vbCrLf
        Exit Sub
      End Try
#End If
    End With

    Dim PartitionSize As Integer
    If Integer.TryParse(PartitionSizeTextBox.Text, PartitionSize) Then
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
    If Integer.TryParse(BufferTextBox.Text, Buffer) Then
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

    QueryStartToolStripButton.Enabled = False
    QueryStopToolStripButton.Enabled = True
    QueryQuickOpenToolStripButton.Enabled = False
    QueryToolStripProgressBar.Style = ProgressBarStyle.Marquee
  End Sub

  Private Sub RemoteOpenSQL_QueryExecuted(ByVal sender As RemoteOpenSQLLib.RemoteOpenSQL, ByVal e As QueryExecutedEventArgs) Handles RemoteOpenSQL.QueryExecuted
    Me.UIThreadInvoke(Sub()
                        QueryStartToolStripButton.Enabled = True
                        QueryStopToolStripButton.Enabled = False
                        If e.Exception Is Nothing Then
                          QueryQuickOpenToolStripButton.Enabled = True
                        Else
                          QueryQuickOpenToolStripButton.Enabled = False
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

  Private Sub QueryQuickOpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryQuickOpenToolStripButton.Click
    Consumer.ViewData()
  End Sub

  Private Sub NumericKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PartitionSizeTextBox.KeyPress, BufferTextBox.KeyPress

    Dim SenderTextBox As TextBox = sender

    If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
      e.Handled = True
    End If

  End Sub

  Private Sub QueryTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryTimer.Tick
    QueryToolStripStatusLabel.Text = New TimeSpan(0, 0, DateDiff(DateInterval.Second, QueryStartTime, Now)).ToString
  End Sub

  Private Sub QueryStopToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryStopToolStripButton.Click
    RemoteOpenSQL.StopQuery()
  End Sub
End Class
