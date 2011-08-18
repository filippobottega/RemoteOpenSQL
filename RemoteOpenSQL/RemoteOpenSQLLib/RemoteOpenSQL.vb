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

Imports SapNetConnector2Proxy2010
Imports SAP.Connector
Imports com.calitha.goldparser
Imports System.IO
Imports System.Text
Imports System.Reflection
Imports System.Threading
Imports System.Collections.Concurrent
Imports System.Threading.Tasks

Public Class QueryExecutedEventArgs
  Inherits EventArgs
  Public Property Exception As Exception
End Class

Public Class QueryStatusChangedEventArgs
  Inherits EventArgs
  Public Property StatusText As String
  Public Property Records As Integer
End Class

Public Class CompileException
  Inherits Exception

  Public Sub New(ByVal Message As String)
    MyBase.New(Message)
  End Sub
End Class

Public Class OpenSQLException
  Inherits Exception

  Public Sub New(ByVal Message As String)
    MyBase.New(Message)
  End Sub
End Class

Public Class RemoteOpenSQL

  Private Shared ItemsValue As Dictionary(Of String, RemoteOpenSQL) = New Dictionary(Of String, RemoteOpenSQL)

  Private GUIDValue As String
  Private DestinationValue As New Destination
  Private RemoteOpenSQLCompiledGrammarFullPath As String = Path.Combine(My.Application.Info.DirectoryPath, "Gold\RemoteOpenSQL.cgt")
  Private SapOpenSQLCompiledGrammarFullPath As String = Path.Combine(My.Application.Info.DirectoryPath, "Gold\SapOpenSQL.cgt")
  Private RemoteOpenSQLGrammarFullPath As String = Path.Combine(My.Application.Info.DirectoryPath, "Gold\RemoteOpenSQL.grm")
  Private SapOpenSQLGrammarFullPath As String = Path.Combine(My.Application.Info.DirectoryPath, "Gold\SapOpenSQL.grm")
  Private RemoteOpenSQLGrammarReader As CGTReader = New CGTReader(RemoteOpenSQLCompiledGrammarFullPath)
  Private SapOpenSQLGrammarReader As CGTReader = New CGTReader(SapOpenSQLCompiledGrammarFullPath)
  Private CancelSourceValue As New CancellationTokenSource
  Private SAPCallContexts As New Dictionary(Of String, CallContext)
  Private SAPCallContextsCollection As New BlockingCollection(Of CallContext)(2)
  Private RunQueryTask As Task
  Private SessionTask1 As Task
  Private SessionTask2 As Task
  Private EventTasks As New List(Of Task)

  Private Consumer As DataConsumer
  ' 800.000 valore stabile per tabella CDPOS
  Private PartitionSizeValue = 50000
  Private EventsTaskFactory As New TaskFactory

  Private Class RosFieldInfo
    Public Property FieldName As String
    Public Property RollNameOrABAPType As String
    Public Property DfiesIndex As Integer

    Public Sub New(ByVal FieldName As String, ByVal RollNameOrABAPType As String, ByVal DfiesIndex As Integer)
      MyBase.New()
      Me.FieldName = FieldName
      Me.RollNameOrABAPType = RollNameOrABAPType
      Me.DfiesIndex = DfiesIndex
    End Sub
  End Class

  Private Class CallContext

    Private ContextGUIDValue As String
    Private Parse_Tree_Step_1Value As ROS_PARSE_NODETable
    Private Parse_Tree_Step_NValue As ROS_PARSE_NODETable
    Private Selected_FieldsValue As ROS_FIELD_INFOTable
    Private Orderby_FieldsValue As ROS_FIELD_INFOTable
    Private NextRowValue As SAPStructure
    Private MaxRowsValue As Integer
    Private PartitionSizeValue As Integer
    Private ContextIndexValue As Integer
    Private LinkedContextValue As CallContext = Nothing
    Private NextRowsCollection As New BlockingCollection(Of SAPStructure)(1)
    Private ReceiveRowsGateCollection As New BlockingCollection(Of Boolean)(1)

    Public Sub New(
                  ByVal Parse_Tree_Step_1 As ROS_PARSE_NODETable,
                  ByVal Parse_Tree_Step_N As ROS_PARSE_NODETable,
                  ByVal Selected_Fields As ROS_FIELD_INFOTable,
                  ByVal Orderby_Fields As ROS_FIELD_INFOTable,
                  ByVal MaxRows As Integer,
                  ByVal PartitionSize As Integer,
                  ByVal ContextIndex As Integer,
                  Optional ByVal LinkedContextToLink As CallContext = Nothing)
      MyBase.New()
      ContextGUIDValue = System.Guid.NewGuid.ToString()
      Parse_Tree_Step_1Value = Parse_Tree_Step_1
      Parse_Tree_Step_NValue = Parse_Tree_Step_N
      Selected_FieldsValue = Selected_Fields
      Orderby_FieldsValue = Orderby_Fields
      MaxRowsValue = MaxRows
      PartitionSizeValue = PartitionSize
      ContextIndexValue = ContextIndex
      LinkedContextValue = LinkedContextToLink
      If Not LinkedContextToLink Is Nothing Then
        LinkedContextToLink.LinkedContext = Me
      End If
      If ContextIndex = 1 Then
        ReceiveRowsGate.Add(True)
      End If
    End Sub

    Public ReadOnly Property NextRows As BlockingCollection(Of SAPStructure)
      Get
        Return NextRowsCollection
      End Get
    End Property

    Public ReadOnly Property ReceiveRowsGate As BlockingCollection(Of Boolean)
      Get
        Return ReceiveRowsGateCollection
      End Get
    End Property

    Public Property LinkedContext As CallContext
      Get
        Return LinkedContextValue
      End Get
      Set(ByVal value As CallContext)
        If LinkedContextValue Is Nothing Then
          LinkedContextValue = value
        End If
      End Set
    End Property

    Friend ReadOnly Property ContextGUID
      Get
        Return ContextGUIDValue
      End Get
    End Property

    Friend ReadOnly Property Parse_Tree_Step_1 As ROS_PARSE_NODETable
      Get
        Return Parse_Tree_Step_1Value
      End Get
    End Property
    Friend ReadOnly Property Parse_Tree_Step_N As ROS_PARSE_NODETable
      Get
        Return Parse_Tree_Step_NValue
      End Get
    End Property
    Friend ReadOnly Property Selected_Fields As ROS_FIELD_INFOTable
      Get
        Return Selected_FieldsValue
      End Get
    End Property
    Friend ReadOnly Property Orderby_Fields As ROS_FIELD_INFOTable
      Get
        Return Orderby_FieldsValue
      End Get
    End Property
    Friend ReadOnly Property NextRow As SAPStructure
      Get
        Return NextRowValue
      End Get
    End Property
    Friend ReadOnly Property MaxRows As Integer
      Get
        Return MaxRowsValue
      End Get
    End Property
    Friend ReadOnly Property PartitionSize As Integer
      Get
        Return PartitionSizeValue
      End Get
    End Property
    Friend ReadOnly Property ContextIndex As Integer
      Get
        Return ContextIndexValue
      End Get
    End Property

  End Class

  Public Sub New()
    MyBase.New()

    GUIDValue = System.Guid.NewGuid.ToString()
    ItemsValue.Add(GUIDValue, Me)
  End Sub

  Public Sub SendCallContext(
                            ByVal GUID As String,
                            ByVal ContextGUID As String,
                            ByRef ContextIndex As Integer,
                            ByRef MaxRows As Integer,
                            ByRef PartitionSize As Integer,
                            ByRef Parse_Tree_Step_1 As ROS_PARSE_NODETable,
                            ByRef Parse_Tree_Step_N As ROS_PARSE_NODETable,
                            ByRef Selected_Fields As ROS_FIELD_INFOTable,
                            ByRef Orderby_Fields As ROS_FIELD_INFOTable)

    If GUID <> GUIDValue Then
      Exit Sub
    End If

    Try
      With SAPCallContexts(ContextGUID)
        ContextIndex = .ContextIndex
        MaxRows = .MaxRows
        PartitionSize = .PartitionSize
        Parse_Tree_Step_1.FromADODataTable(.Parse_Tree_Step_1.ToADODataTable)
        Parse_Tree_Step_N.FromADODataTable(.Parse_Tree_Step_N.ToADODataTable)
        Selected_Fields.FromADODataTable(.Selected_Fields.ToADODataTable)
        Orderby_Fields.FromADODataTable(.Orderby_Fields.ToADODataTable)
      End With
    Catch ex As System.InvalidOperationException
    End Try
  End Sub

  Public Function GetConsumer() As DataConsumer
    Return Consumer
  End Function

  Public Property PartitionSize As Integer
    Get
      Return PartitionSizeValue
    End Get
    Set(ByVal value As Integer)
      PartitionSizeValue = value
    End Set
  End Property



  Public Sub WaitForReceiveRows(
                          ByVal GUID As String,
                          ByVal ContextGUID As String)

    If GUID <> GUIDValue Then
      Exit Sub
    End If

    Dim SAPCallContext = SAPCallContexts(ContextGUID)

    Try
      SAPCallContext.ReceiveRowsGate.Take()
    Catch ex As System.InvalidOperationException
      ' Todo: Anomalia che non deve verificarsi mai, trovare il modo per darne evidenza
    End Try
  End Sub

  Public Sub EndToReceiveRows(
                          ByVal GUID As String,
                          ByVal ContextGUID As String,
                          ByVal SelectLengthC As String,
                          ByVal CompleteAdding As String,
                          ByVal SelectError As String,
                          ByVal Message As String,
                          ByRef Cancel As String)

    If GUID <> GUIDValue Then
      Exit Sub
    End If

    RaiseQueryStatusChanged("Exporting data from SAP. Records already exported: " & Consumer.Records & " Last Application DB query time: " & Decimal.Parse(Replace(SelectLengthC, ".", ",")).ToString("F3") & " seconds.")

    Dim SAPCallContext = SAPCallContexts(ContextGUID)

    If CompleteAdding = "X" OrElse SelectError = "X" OrElse IsCancellationRequested() Then
      Cancel = "X"
      SAPCallContext.ReceiveRowsGate.CompleteAdding()
      SAPCallContext.NextRows.CompleteAdding()
      SAPCallContext.LinkedContext.ReceiveRowsGate.CompleteAdding()
      SAPCallContext.LinkedContext.NextRows.CompleteAdding()
      If SelectError = "X" Then
        Throw New OpenSQLException("Error reading records, try to change ORDER BY clause or increase partition size.")
      End If
      Exit Sub
    End If

    Try
      SAPCallContext.LinkedContext.ReceiveRowsGate.Add(True)
    Catch ex As System.InvalidOperationException
      ' Todo: Anomalia che non deve verificarsi mai, trovare il modo per darne evidenza
      Cancel = "X"
    End Try

  End Sub

  Public Sub ReceiveNextRow(
                            ByVal GUID As String,
                            ByVal ContextGUID As String,
                            ByVal NextRow As SAPStructure,
                            ByRef Cancel As String)

    If GUID <> GUIDValue Then
      Exit Sub
    End If

    Dim SAPCallContext = SAPCallContexts(ContextGUID)

    Try
      SAPCallContext.LinkedContext.NextRows.Add(NextRow)
    Catch ex As System.InvalidOperationException
      ' Todo: Anomalia che non deve verificarsi mai, trovare il modo per darne evidenza
      Cancel = "X"
    End Try
  End Sub

  Public Sub SendNextRow(
                          ByVal GUID As String,
                          ByVal ContextGUID As String,
                          ByRef NextRow As SAPStructure,
                          ByRef Cancel As String)

    If GUID <> GUIDValue Then
      Exit Sub
    End If

    Dim SAPCallContext = SAPCallContexts(ContextGUID)
    Try
      NextRow = SAPCallContext.NextRows.Take
    Catch ex As System.InvalidOperationException
      Cancel = "X"
    End Try
  End Sub

  Public Sub ReceiveMessage(
                          ByVal GUID As String,
                          ByVal ContextGUID As String,
                          ByVal Message As String,
                          ByVal Line As Integer)

    If GUID <> GUIDValue Then
      Exit Sub
    End If

    Dim SAPCallContext = SAPCallContexts(ContextGUID)

    If Not SAPCallContext Is Nothing Then
      RaiseQueryStatusChanged("GUID: " & GUID & " ContextGUID: " & ContextGUID & " Message: " & Message & " Line: " & Line.ToString)
    End If
    ' Todo: generare un'eccezione
  End Sub

  Friend ReadOnly Property GUID
    Get
      Return GUIDValue
    End Get
  End Property

  Public Shared ReadOnly Property Items(ByVal GUID As String) As RemoteOpenSQL
    Get
      If ItemsValue.ContainsKey(GUID) Then
        Return ItemsValue(GUID)
      Else
        Return Nothing
      End If
    End Get
  End Property

  Public Function IsCancellationRequested() As Boolean
    Return CancelSourceValue.IsCancellationRequested
  End Function

  Public Sub SetLogonParameters(
    ByVal AppServerHost As String,
    ByVal SystemNumber As Short,
    ByVal Client As Short,
    ByVal Username As String,
    ByVal Password As String,
    Optional ByVal SAPRouterString As String = "")

    With DestinationValue
      .AppServerHost = AppServerHost
      .SystemNumber = SystemNumber
      .Client = Client
      .Username = Username
      .Password = Password
      .SAPGui = 0
      .SAPRouterString = SAPRouterString
    End With
  End Sub

  Public Sub StartRunQuery(ByVal Query As String, ByVal Consumer As DataConsumer)
    RaiseQueryStatusChanged("Starting query setup...")
    Me.Consumer = Consumer
    RunQueryTask = New Task(Sub() Me.CallRfcRemoteOpenSQL(Query))
    RunQueryTask.ContinueWith(Sub() RaiseQueryExecuted(RunQueryTask))
    RunQueryTask.Start()
  End Sub

  Public Sub StopQuery()
    If Not RunQueryTask Is Nothing AndAlso RunQueryTask.Status = TaskStatus.Running Then
      CancelSourceValue.Cancel()
    End If
  End Sub

  Public ReadOnly Property Status As TaskStatus
    Get
      If Not RunQueryTask Is Nothing Then
        Return RunQueryTask.Status
      Else
        Return TaskStatus.Created
      End If
    End Get
  End Property

  Public Event QueryExecuted(ByVal sender As RemoteOpenSQL, ByVal e As QueryExecutedEventArgs)
  Public Event QueryStatusChanged(ByVal sender As RemoteOpenSQL, ByVal e As QueryStatusChangedEventArgs)

  Private Sub RaiseQueryExecuted(ByVal Task As task)
    Dim e As New QueryExecutedEventArgs
    e.Exception = Task.Exception
    Dim EventTask = EventsTaskFactory.StartNew(Sub() RaiseEvent QueryExecuted(Me, e))
    EventTask.ContinueWith(Sub() EventTaskCompleted(EventTask))
    EventTasks.Add(EventTask)
  End Sub

  Private Sub RaiseQueryStatusChanged(ByVal StatusText As String)
    Dim e As New QueryStatusChangedEventArgs
    e.StatusText = StatusText
    Dim EventTask = EventsTaskFactory.StartNew(Sub() RaiseEvent QueryStatusChanged(Me, e))
    EventTask.ContinueWith(Sub() EventTaskCompleted(EventTask))
    EventTasks.Add(EventTask)
  End Sub

  Private Sub EventTaskCompleted(ByVal EventTask As Task)
    EventTasks.Remove(EventTask)
  End Sub

  Public Sub Wait()
    ' Todo: Gestire l'eccezione System.AggregateException
    RunQueryTask.Wait()
  End Sub

  Private Sub CallRfcRemoteOpenSQL(ByVal Query As String)

    ' Parse Query
    Dim ParseTree = RemoteOpenSQLGrammarReader.CreateNewParser.Parse(Query)

    If ParseTree Is Nothing Then
      ' Todo: Generate exception
      Exit Sub
    End If

    ' Create SAPProxyClient instance
    Dim Client = New SAPProxyClient
    Client.Connection = New SAP.Connector.SAPConnection(DestinationValue)

    Dim TableName = GetTables(ParseTree)(0)
    Dim ColumnsIds = GetColumnsIds(ParseTree)
    Dim OrderByIds = GetOrderByIds(ParseTree)
    Dim OrderByPrimaryKey = GetOrderByPrimaryKey(ParseTree)
    Dim ClientSpecified = GetClientSpecified(ParseTree)

    ' Assegno il nome della tabella di destinazione

    If TypeOf Consumer Is MicrosoftAccessConsumer Then
      With CType(Consumer, MicrosoftAccessConsumer)
        If .TableName = String.Empty Then
          .TableName = TableName
        End If
      End With
    ElseIf TypeOf Consumer Is MicrosoftExcelConsumer Then
      With CType(Consumer, MicrosoftExcelConsumer)
        If .ExcelFileName = String.Empty Then
          .ExcelFileName = TableName & ".xlsx"
        End If
      End With
    ElseIf TypeOf Consumer Is DelimitedTextFileConsumer Then
      With CType(Consumer, DelimitedTextFileConsumer)
        If .FileName = String.Empty Then
          .FileName = TableName & ".txt"
        End If
      End With
    End If

    ' Leggo i metadati della tabella

    Dim Ddif_FieldinfoInput As New SAPProxyClient.Ddif_Fieldinfo_Get_Input
    Dim Ddif_FieldinfoOutput As New SAPProxyClient.Ddif_Fieldinfo_Get_Output
    InitSapObject(Ddif_FieldinfoInput)
    InitSapObject(Ddif_FieldinfoOutput)

    Ddif_FieldinfoInput.Tabname = TableName

    Try
      Ddif_FieldinfoOutput = Client.Ddif_Fieldinfo_Get_(Ddif_FieldinfoInput)
    Catch ex As RfcSystemException
      Client.Connection.Close()
      Throw
    End Try

    Client.Connection.Close()

    ' Creo un indice della tabella Dfies_Tab sul campo Fieldname
    Dim DfiesTabIndex = New Dictionary(Of String, Integer)
    For Count = 0 To Ddif_FieldinfoOutput.Dfies_Tab.Count - 1
      DfiesTabIndex.Add(Ddif_FieldinfoOutput.Dfies_Tab.Item(Count).Fieldname, Count)
    Next

    ' Creo la lista delle colonne per l'ordinamento
    Dim OrderByFields = New Dictionary(Of String, RosFieldInfo)

    If OrderByPrimaryKey Then
      For Count = 0 To Ddif_FieldinfoOutput.Dfies_Tab.Count - 1
        Dim DfiesItem = Ddif_FieldinfoOutput.Dfies_Tab.Item(Count)
        If DfiesItem.Keyflag <> "X" Then
          Exit For
        End If
        If Count = 0 AndAlso DfiesItem.Datatype = "CLNT" AndAlso Not ClientSpecified Then
          Continue For
        End If
        OrderByFields.Add(DfiesItem.Fieldname, New RosFieldInfo(DfiesItem.Fieldname, GetRollNameOrABAPType(DfiesItem), Count))
      Next
    Else
      For Count = 0 To OrderByIds.Count - 1
        Dim CurrentId = OrderByIds(Count)
        If Not DfiesTabIndex.ContainsKey(CurrentId) Then
          ' Todo: Raise an exception
          Exit Sub
        End If
        Dim DfiesIndex = DfiesTabIndex(CurrentId)
        Dim DfiesItem = Ddif_FieldinfoOutput.Dfies_Tab.Item(DfiesIndex)

        OrderByFields.Add(CurrentId, New RosFieldInfo(CurrentId, GetRollNameOrABAPType(DfiesItem), DfiesIndex))
      Next
    End If

    ' Creo la lista delle colonne selezionate dall'utente
    Dim RosSelectedFields = New Dictionary(Of String, RosFieldInfo)
    For Count = 0 To ColumnsIds.Count - 1
      Dim CurrentId = Trim(ColumnsIds(Count))

      If CurrentId = "*" Then
        If ColumnsIds.Count <> 1 Then
          ' Todo: Raise an exception
          Exit Sub
        End If
        For Count2 = 0 To Ddif_FieldinfoOutput.Dfies_Tab.Count - 1
          Dim DfiesItem2 = Ddif_FieldinfoOutput.Dfies_Tab.Item(Count2)
          RosSelectedFields.Add(DfiesItem2.Fieldname, New RosFieldInfo(DfiesItem2.Fieldname, GetRollNameOrABAPType(DfiesItem2), Count2))
        Next
        Exit For
      End If

      If Not DfiesTabIndex.ContainsKey(CurrentId) Then
        ' Todo: Raise an exception
        Exit Sub
      End If
      Dim DfiesIndex = DfiesTabIndex(CurrentId)
      Dim DfiesItem = Ddif_FieldinfoOutput.Dfies_Tab.Item(DfiesIndex)

      RosSelectedFields.Add(CurrentId, New RosFieldInfo(CurrentId, GetRollNameOrABAPType(DfiesItem), DfiesIndex))
    Next

    ' Aggiungo alle colonne selezionate dall'utente anche le colonne OrderBy se non presenti.
    Dim SelectedFields = New Dictionary(Of String, RosFieldInfo)(RosSelectedFields)
    For Each OrderByField In OrderByFields.Values
      If Not RosSelectedFields.ContainsKey(OrderByField.FieldName) Then
        If Not DfiesTabIndex.ContainsKey(OrderByField.FieldName) Then
          ' Todo: Raise an exception
          Exit Sub
        End If
        Dim DfiesIndex = DfiesTabIndex(OrderByField.FieldName)
        Dim DfiesItem = Ddif_FieldinfoOutput.Dfies_Tab.Item(DfiesIndex)

        SelectedFields.Add(OrderByField.FieldName, New RosFieldInfo(OrderByField.FieldName, GetRollNameOrABAPType(DfiesItem), DfiesIndex))
      End If
    Next

    ' Creo le strutture rfc per la generazione del CallbackServer

    Dim Offset As Integer = 0
    Dim Offset2 As Integer = 0
    Dim DfiesRow As DFIES = Nothing
    Dim PrevDfiesRow As DFIES = Nothing
    ' Determino l'elenco degli attributi RFC corrispondenti alle colonne della query Ros 
    Dim RosRfcFieldAttributes = New List(Of RfcFieldAttribute)

    For Index = 0 To RosSelectedFields.Values.Count - 1
      PrevDfiesRow = DfiesRow
      DfiesRow = Ddif_FieldinfoOutput.Dfies_Tab.Item(RosSelectedFields.Values(Index).DfiesIndex)
      RosRfcFieldAttributes.Add(GetRfcFieldAttribute(DfiesRow, PrevDfiesRow, Offset, Offset2))
    Next

    Consumer.RosRfcFieldAttributes = RosRfcFieldAttributes

    ' Determino l'elenco degli attributi RFC corrispondenti alle colonne di selezione in SAP
    ' dati dall'unione delle colonne della query Ros e dei campi OrderBy non presenti 
    Dim LineRfcFieldAttributes = New List(Of RfcFieldAttribute)(RosRfcFieldAttributes)
    For Each SelectedField In SelectedFields.Values
      If Not RosSelectedFields.ContainsKey(SelectedField.FieldName) Then
        PrevDfiesRow = DfiesRow
        DfiesRow = Ddif_FieldinfoOutput.Dfies_Tab.Item(SelectedField.DfiesIndex)
        LineRfcFieldAttributes.Add(GetRfcFieldAttribute(DfiesRow, PrevDfiesRow, Offset, Offset2))
      End If
    Next

    PrevDfiesRow = DfiesRow
    GetRfcFieldAttribute(Nothing, PrevDfiesRow, Offset, Offset2)

    Dim LineRfcStructure = New RfcStructureAttribute
    LineRfcStructure.AbapName = "linestruct"
    LineRfcStructure.Length = Offset
    LineRfcStructure.Length2 = Offset2

    ' Determino i parametri della struttura orderbystruct 
    Offset = 0
    Offset2 = 0
    PrevDfiesRow = Nothing
    DfiesRow = Nothing

    Dim OrderByRfcStructure = New RfcStructureAttribute
    Dim OrderByRfcFieldAttributes = New List(Of RfcFieldAttribute)

    For Each OrderByField In OrderByFields.Values
      PrevDfiesRow = DfiesRow
      DfiesRow = Ddif_FieldinfoOutput.Dfies_Tab.Item(OrderByField.DfiesIndex)
      OrderByRfcFieldAttributes.Add(GetRfcFieldAttribute(DfiesRow, PrevDfiesRow, Offset, Offset2))
    Next

    PrevDfiesRow = DfiesRow
    GetRfcFieldAttribute(Nothing, PrevDfiesRow, Offset, Offset2)

    OrderByRfcStructure.AbapName = "orderbystruct"
    OrderByRfcStructure.Length = Offset
    OrderByRfcStructure.Length2 = Offset2

    ' Creo i dati per le chiamate
    Dim Parse_Tree_Step_1 = New ROS_PARSE_NODETable
    Dim Parse_Tree_Step_N = New ROS_PARSE_NODETable
    Dim Selected_Fields = New ROS_FIELD_INFOTable
    Dim Orderby_Fields = New ROS_FIELD_INFOTable

    FillParseTreeTable(GetParseTreeStep1(ParseTree, SelectedFields), Parse_Tree_Step_1)
    FillParseTreeTable(GetParseTreeStepN(ParseTree, SelectedFields, OrderByFields), Parse_Tree_Step_N)
    FillFieldsTable(SelectedFields, Selected_Fields)
    FillFieldsTable(OrderByFields, Orderby_Fields)

    ' Todo: Introdurre la sintassi nella grammatica per il passaggio dei valori MaxRows e PartitionSize

    Dim CallContext1 = New CallContext(
                         Parse_Tree_Step_1,
                         Parse_Tree_Step_N,
                         Selected_Fields,
                         Orderby_Fields,
                         0,
                         PartitionSize,
                         1)

    Dim CallContext2 = New CallContext(
                         Parse_Tree_Step_1,
                         Parse_Tree_Step_N,
                         Selected_Fields,
                         Orderby_Fields,
                         0,
                         PartitionSize,
                         2,
                         CallContext1)

    SAPCallContexts.Add(CallContext1.ContextGUID, CallContext1)
    SAPCallContexts.Add(CallContext2.ContextGUID, CallContext2)
    SAPCallContextsCollection.Add(CallContext1)
    SAPCallContextsCollection.Add(CallContext2)

    Dim TaskFactoryValue As New TaskFactory

    Dim CallbackServer1 = GetSAPProxyCallbackServer(CallContext1.ContextGUID, LineRfcStructure, LineRfcFieldAttributes, OrderByRfcStructure, OrderByRfcFieldAttributes, RosRfcFieldAttributes)
    If CallbackServer1 Is Nothing Then
      Exit Sub
    End If

    Dim CallbackServer2 = GetSAPProxyCallbackServer(CallContext2.ContextGUID, LineRfcStructure, LineRfcFieldAttributes, OrderByRfcStructure, OrderByRfcFieldAttributes, RosRfcFieldAttributes)
    If CallbackServer2 Is Nothing Then
      Exit Sub
    End If

    ' Creazione del task per la chiamata delle funzione RunSession
    RaiseQueryStatusChanged("Starting call to Z_REMOTE_OPEN_SQL ...")
    Consumer.BeginConsume()
    SessionTask1 = TaskFactoryValue.StartNew(Sub() Me.RunSession(CallbackServer1))
    SessionTask2 = TaskFactoryValue.StartNew(Sub() Me.RunSession(CallbackServer2))
    SessionTask1.Wait()
    SessionTask2.Wait()
    For Each EventTask In EventTasks
      EventTask.Wait()
    Next
    EventTasks.Clear()
    Consumer.EndConsume()
    RaiseQueryStatusChanged("Query Excecuted. Records: " & Consumer.Records & ".")
  End Sub

  Private Function GetRollNameOrABAPType(ByVal DfiesItem As DFIES) As String
    If DfiesItem Is Nothing Then
      Return String.Empty
    End If

    With DfiesItem
      If Trim(.Rollname) <> String.Empty Then
        Return .Rollname
      Else
        Select Case .Inttype
          Case "I", "b", "s", "d", "t", "f"
            Return .Inttype
          Case "C"
            Return "c LENGTH " & .Leng
          Case "N"
            Return "n LENGTH " & .Leng
          Case "P"
            Return "p LENGTH " & .Intlen & " DECIMALS " & .Decimals
          Case "X"
            Return "x LENGTH " & .Intlen
        End Select
      End If
    End With

    Return String.Empty
  End Function

  Private Function IsEven(ByVal Number As Long) As Boolean
    IsEven = (Number Mod 2 = 0)
  End Function

  Private Function IsOdd(ByVal Number As Long) As Boolean
    IsOdd = (Number Mod 2 <> 0)
  End Function

  Private Function GetRfcFieldAttribute(ByVal DfiesRow As DFIES, ByVal PrevDfiesRow As DFIES, ByRef Offset As Integer, ByRef Offset2 As Integer) As RfcFieldAttribute
    Dim Result As RfcFieldAttribute = Nothing
    Dim CurrentRfcType As RFCTYPE = Nothing
    Dim PrevRfcType As RFCTYPE = Nothing

    If Not DfiesRow Is Nothing Then
      CurrentRfcType = GetRfcTypeFromAbapType(DfiesRow.Inttype)
    End If

    If Not PrevDfiesRow Is Nothing Then
      PrevRfcType = GetRfcTypeFromAbapType(PrevDfiesRow.Inttype)
    End If

    If DfiesRow Is Nothing Then
      If PrevDfiesRow Is Nothing Then
        Return Nothing
      End If
      If PrevRfcType = RFCTYPE.RFCTYPE_BCD AndAlso IsOdd(Offset2) Then
        Offset2 += 1
      End If
      Return Nothing
    Else
      If Not PrevDfiesRow Is Nothing AndAlso CurrentRfcType <> RFCTYPE.RFCTYPE_BCD AndAlso IsOdd(Offset2) Then
        Offset2 += 1
      End If

      If CurrentRfcType = RFCTYPE.RFCTYPE_FLOAT Then
        Dim OffsetMod8 = Offset Mod 8
        Dim Offset2Mod8 = Offset2 Mod 8
        If OffsetMod8 > 0 Then
          Offset += 8 - OffsetMod8
        End If
        If Offset2Mod8 > 0 Then
          Offset2 += 8 - Offset2Mod8
        End If
      End If
    End If

    Select Case CurrentRfcType
      Case RFCTYPE.RFCTYPE_INT
        ' Tipo interno I, Tipo .NET Integer, campo di esempio RLIB_OBJS-ANZAHL
        Result = New RfcFieldAttribute(DfiesRow.Fieldname, RFCTYPE.RFCTYPE_INT, DfiesRow.Intlen, DfiesRow.Intlen, 0, Offset, Offset2)
        Offset += DfiesRow.Intlen
        Offset2 += DfiesRow.Intlen
      Case RFCTYPE.RFCTYPE_INT1
        ' Tipo interno b, Tipo .NET Byte, campo di esempio T180S-COLOR
        Result = New RfcFieldAttribute(DfiesRow.Fieldname, RFCTYPE.RFCTYPE_INT1, DfiesRow.Intlen, DfiesRow.Intlen, 0, Offset, Offset2)
        Offset += DfiesRow.Intlen
        Offset2 += DfiesRow.Intlen
      Case RFCTYPE.RFCTYPE_INT2
        ' Tipo interno s, Tipo .NET Short, campo di esempio RLIB_TREES-CLUSTR
        Result = New RfcFieldAttribute(DfiesRow.Fieldname, RFCTYPE.RFCTYPE_INT2, DfiesRow.Intlen, DfiesRow.Intlen, 0, Offset, Offset2)
        Offset += DfiesRow.Intlen
        Offset2 += DfiesRow.Intlen
      Case RFCTYPE.RFCTYPE_DATE
        ' Tipo interno D, Tipo .NET String, campo di esempio MSTA-ERSDA
        Result = New RfcFieldAttribute(DfiesRow.Fieldname, RFCTYPE.RFCTYPE_DATE, DfiesRow.Leng, DfiesRow.Leng * 2, 0, Offset, Offset2)
        Offset += DfiesRow.Leng
        Offset2 += DfiesRow.Leng * 2
      Case RFCTYPE.RFCTYPE_FLOAT
        ' Tipo interno F, Tipo .NET Double, campo di esempio MARD-BSKRF
        Result = New RfcFieldAttribute(DfiesRow.Fieldname, RFCTYPE.RFCTYPE_FLOAT, DfiesRow.Intlen, DfiesRow.Intlen, 0, Offset, Offset2)
        Offset += DfiesRow.Intlen
        Offset2 += DfiesRow.Intlen
      Case RFCTYPE.RFCTYPE_TIME
        ' Tipo interno T, Tipo .NET String, campo di esempio MSEG-/BEV2/ED_AETIM
        Result = New RfcFieldAttribute(DfiesRow.Fieldname, RFCTYPE.RFCTYPE_TIME, DfiesRow.Leng, DfiesRow.Leng * 2, 0, Offset, Offset2)
        Offset += DfiesRow.Leng
        Offset2 += DfiesRow.Leng * 2
      Case RFCTYPE.RFCTYPE_CHAR
        ' Tipo interno C, Tipo .NET String, campo di esempio MSTA-AENAM
        Result = New RfcFieldAttribute(DfiesRow.Fieldname, RFCTYPE.RFCTYPE_CHAR, DfiesRow.Leng, DfiesRow.Leng * 2, 0, Offset, Offset2)
        Offset += DfiesRow.Leng
        Offset2 += DfiesRow.Leng * 2
      Case RFCTYPE.RFCTYPE_NUM
        ' Tipo interno N, Tipo .NET String, campo di esempio COEP-BELTP
        Result = New RfcFieldAttribute(DfiesRow.Fieldname, RFCTYPE.RFCTYPE_NUM, DfiesRow.Leng, DfiesRow.Leng * 2, 0, Offset, Offset2)
        Offset += DfiesRow.Leng
        Offset2 += DfiesRow.Leng * 2
      Case RFCTYPE.RFCTYPE_BCD
        ' Tipo interno P, Tipo .NET String, campo di esempio COEP-WTGBTR
        Result = New RfcFieldAttribute(DfiesRow.Fieldname, RFCTYPE.RFCTYPE_BCD, DfiesRow.Intlen, DfiesRow.Intlen, DfiesRow.Decimals, Offset, Offset2)
        Offset += DfiesRow.Intlen
        Offset2 += DfiesRow.Intlen
      Case RFCTYPE.RFCTYPE_BYTE
        ' Tipo interno X, Tipo .NET Byte(), campo di esempio TODIR-RELMAP
        Result = New RfcFieldAttribute(DfiesRow.Fieldname, RFCTYPE.RFCTYPE_BYTE, DfiesRow.Intlen, DfiesRow.Intlen, 0, Offset, Offset2)
        Offset += DfiesRow.Intlen
        Offset2 += DfiesRow.Intlen
      Case Else
        Return Nothing
    End Select

    Return Result
  End Function

  Private Function GetRfcTypeFromAbapType(ByVal AbapType As String) As RFCTYPE
    Select Case AbapType
      Case "b"
        Return RFCTYPE.RFCTYPE_INT1
      Case "I"
        Return RFCTYPE.RFCTYPE_INT
      Case "P"
        Return RFCTYPE.RFCTYPE_BCD
      Case "D"
        Return RFCTYPE.RFCTYPE_DATE
      Case "N"
        Return RFCTYPE.RFCTYPE_NUM
      Case "T"
        Return RFCTYPE.RFCTYPE_TIME
      Case "C"
        Return RFCTYPE.RFCTYPE_CHAR
      Case "F"
        Return RFCTYPE.RFCTYPE_FLOAT
      Case "s"
        Return RFCTYPE.RFCTYPE_INT2
      Case "X"
        Return RFCTYPE.RFCTYPE_BYTE
      Case "g"
        Return RFCTYPE.RFCTYPE_STRING
      Case "y"
        Return RFCTYPE.RFCTYPE_XSTRING
      Case "M"
        Return RFCTYPE.RFCTYPE_XMLDATA
      Case "ST"
        Return RFCTYPE.RFCTYPE_STRUCTURE
      Case "TA"
        Return RFCTYPE.RFCTYPE_ITAB
      Case Else
        Return Nothing
    End Select
  End Function

  Private Function RfcTypeToNetType(ByVal type As RFCTYPE) As String
    Select Case type
      Case RFCTYPE.RFCTYPE_CHAR
        Return "String"
      Case RFCTYPE.RFCTYPE_DATE
        Return "String"
      Case RFCTYPE.RFCTYPE_BCD
        Return "Decimal"
      Case RFCTYPE.RFCTYPE_TIME
        Return "String"
      Case RFCTYPE.RFCTYPE_BYTE
        Return "Byte()"
      Case RFCTYPE.RFCTYPE_NUM
        Return "String"
      Case RFCTYPE.RFCTYPE_FLOAT
        Return "Double"
      Case RFCTYPE.RFCTYPE_INT
        Return "Integer"
      Case RFCTYPE.RFCTYPE_INT2
        Return "Short"
      Case RFCTYPE.RFCTYPE_INT1
        Return "Byte"
      Case Else
        Return ""
    End Select
  End Function

  Private Sub RunSession(ByVal CallbackServer As SAPServer)

    Dim Client = New SAPProxyClient
    Client.Connection = New SAP.Connector.SAPConnection(DestinationValue)
    Client.CallbackServer = CallbackServer

    ' Chiamo la funzione Z_REMOTE_OPEN_SQL
    Dim Z_Remote_Open_SqlInput As New SAPProxyClient.Z_Remote_Open_Sql_Input
    Dim Z_Remote_Open_SqlOutput As New SAPProxyClient.Z_Remote_Open_Sql_Output
    InitSapObject(Z_Remote_Open_SqlInput)
    InitSapObject(Z_Remote_Open_SqlOutput)

    ' Call the method on the proxy
    Try
      Z_Remote_Open_SqlOutput = Client.Z_Remote_Open_Sql_(Z_Remote_Open_SqlInput)
    Catch ex As RfcSystemException
      Client.Connection.Close()
      Throw
    End Try
    Client.Connection.Close()
  End Sub

  Private Function MixedCase(ByVal origText As String, Optional ByVal delimiters As String = " ") As String

    For CharIndex = 1 To Len(delimiters)

      Dim CurrentDelimiter = Mid(delimiters, CharIndex, 1)

      Dim textParts() As String = Split(origText, CurrentDelimiter)

      For counter = 0 To textParts.Length - 1
        If (textParts(counter).Length > 0) Then
          textParts(counter) =
            UCase(Microsoft.VisualBasic.Left(textParts(counter), 1)) &
            LCase(Mid(textParts(counter), 2))
        End If
      Next counter

      origText = Join(textParts, CurrentDelimiter)

    Next

    Return origText

  End Function

  Private Function GetSAPProxyCallbackServer(
      ByVal ContextGUID As String,
      ByVal LineRfcStructure As RfcStructureAttribute,
      ByVal LineRfcFields As List(Of RfcFieldAttribute),
      ByVal OrderByRfcStructure As RfcStructureAttribute,
      ByVal OrderByRfcFields As List(Of RfcFieldAttribute),
      ByVal RosRfcFieldAttributes As List(Of RfcFieldAttribute)) As SAPServer

    Dim SourceCode = New StringBuilder()
    Dim MixedAbapName = MixedCase(LineRfcStructure.AbapName, "_")

    ' Sezione Imports
    SourceCode.AppendLine("Imports System")
    SourceCode.AppendLine("Imports System.Text")
    SourceCode.AppendLine("Imports System.Collections")
    SourceCode.AppendLine("Imports System.ComponentModel")
    SourceCode.AppendLine("Imports System.Runtime.InteropServices")
    SourceCode.AppendLine("Imports System.Xml.Serialization")
    SourceCode.AppendLine("Imports System.Xml.Schema")
    SourceCode.AppendLine("Imports System.Web.Services")
    SourceCode.AppendLine("Imports System.Web.Services.Description")
    SourceCode.AppendLine("Imports System.Web.Services.Protocols")
    SourceCode.AppendLine("Imports SAP.Connector")
    SourceCode.AppendLine("Imports System.IO")
    SourceCode.AppendLine("Imports System.Collections.Generic")
    SourceCode.AppendLine("Imports Microsoft.VisualBasic.Interaction")
    SourceCode.AppendLine("Imports RemoteOpenSQLLib")
    SourceCode.AppendLine("Imports SapNetConnector2Proxy2010")
    SourceCode.AppendLine("Imports System.Diagnostics")
    SourceCode.AppendLine("")

    ' Sezione per la definizione delle strutture

    ' Struttura linestruct
    AddSapStructureCode(SourceCode, LineRfcStructure, LineRfcFields)
    ' Struttura orderbystruct
    AddSapStructureCode(SourceCode, OrderByRfcStructure, OrderByRfcFields)

    ' Sezione per la definizione delle tabelle

    ' Tabella linestruct
    AddConsumerSapTableCode(ContextGUID, SourceCode, LineRfcStructure.AbapName)
    ' Tabella orderby
    ' AddSapTableCode(SourceCode, OrderByRfcStructure.AbapName)


    With SourceCode
      ' Sezione Classe SAPCS : Sap Callback Server

      .AppendLine("  Public Class SapCallbackServer")
      .AppendLine("      Inherits SAPServer")
      .AppendLine(" ")
      .AppendLine("    ' Constructors")
      .AppendLine("    Public Sub New()")
      .AppendLine("      MyBase.New()")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Sub New(ByVal ConnectionString As String)")
      .AppendLine("      MyBase.New(ConnectionString)")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Sub New(ByVal ConnectionString As String, ByVal host As SAPServerHost)")
      .AppendLine("      MyBase.New(ConnectionString, host)")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Sub New(ByVal args As String())")
      .AppendLine("      MyBase.New(args)")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Sub New(ByVal args As String(), ByVal host As SAPServerHost)")
      .AppendLine("      MyBase.New(args, host)")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Sub New(ByVal programId As String, ByVal gwhost As String, ByVal sapgwxx As String, ByVal codepage As String)")
      .AppendLine("      MyBase.New(programId, gwhost, sapgwxx, codepage)")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Sub New(ByVal programId As String, ByVal gwhost As String, ByVal sapgwxx As String, ByVal codepage As String, ByVal host As SAPServerHost)")
      .AppendLine("      MyBase.New(programId, gwhost, sapgwxx, codepage, host)")
      .AppendLine("    End Sub")
      .AppendLine("")

      ' Sezione per la definizione della funzione remota del server SEND_CALL_CONTEXT

      .AppendLine("      <RfcMethod(AbapName:=""SEND_CALL_CONTEXT"")> _")
      .AppendLine("    Protected Sub SEND_CALL_CONTEXT( _")
      .AppendLine("          <RfcParameter(AbapName := ""ABAP_CODE_VERSION"", RfcType := RFCTYPE.RFCTYPE_CHAR, Optional := false, Direction := RFCINOUT.IN, Length := 11, Length2 := 22), _")
      .AppendLine("          XmlElement(""ABAP_CODE_VERSION"", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Abap_Code_Version As String, _ ")
      .AppendLine("          <RfcParameter(AbapName := ""CONTEXT_INDEX"", RfcType := RFCTYPE.RFCTYPE_INT, Optional := false, Direction := RFCINOUT.OUT, Length := 4, Length2 := 4), _")
      .AppendLine("          XmlElement(""CONTEXT_INDEX"", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Context_Index As Integer, _ ")
      .AppendLine("          <RfcParameter(AbapName := ""MAX_ROWS"", RfcType := RFCTYPE.RFCTYPE_INT, Optional := false, Direction := RFCINOUT.OUT, Length := 4, Length2 := 4), _")
      .AppendLine("          XmlElement(""MAX_ROWS"", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Max_Rows As Integer, _ ")
      .AppendLine("          <RfcParameter(AbapName := ""PARTITION_SIZE"", RfcType := RFCTYPE.RFCTYPE_INT, Optional := false, Direction := RFCINOUT.OUT, Length := 4, Length2 := 4), _")
      .AppendLine("          XmlElement(""PARTITION_SIZE"", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Partition_Size As Integer, _")
      .AppendLine("          <RfcParameter(AbapName := ""PARSE_NODES_STEP_1"",RfcType := RFCTYPE.RFCTYPE_ITAB, Optional := false, Direction := RFCINOUT.INOUT), _")
      .AppendLine("          XmlArray(""PARSE_NODES_STEP_1"", IsNullable := False, Form := XmlSchemaForm.Unqualified), _")
      .AppendLine("          XmlArrayItem(""item"", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Parse_Nodes_Step_1 As ROS_PARSE_NODETable, _")
      .AppendLine("          <RfcParameter(AbapName := ""PARSE_NODES_STEP_N"",RfcType := RFCTYPE.RFCTYPE_ITAB, Optional := false, Direction := RFCINOUT.INOUT), _")
      .AppendLine("          XmlArray(""PARSE_NODES_STEP_N"", IsNullable := False, Form := XmlSchemaForm.Unqualified), _")
      .AppendLine("          XmlArrayItem(""item"", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Parse_Nodes_Step_N As ROS_PARSE_NODETable, _")
      .AppendLine("          <RfcParameter(AbapName := ""SELECTED_FIELDS"",RfcType := RFCTYPE.RFCTYPE_ITAB, Optional := false, Direction := RFCINOUT.INOUT), _")
      .AppendLine("          XmlArray(""SELECTED_FIELDS"", IsNullable := False, Form := XmlSchemaForm.Unqualified), _")
      .AppendLine("          XmlArrayItem(""item"", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Selected_Fields As ROS_FIELD_INFOTable, _")
      .AppendLine("          <RfcParameter(AbapName := ""ORDERBY_FIELDS"",RfcType := RFCTYPE.RFCTYPE_ITAB, Optional := false, Direction := RFCINOUT.INOUT), _")
      .AppendLine("          XmlArray(""ORDERBY_FIELDS"", IsNullable := False, Form := XmlSchemaForm.Unqualified), _")
      .AppendLine("          XmlArrayItem(""item"", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Orderby_Fields As ROS_FIELD_INFOTable, _")
      .AppendLine("          <RfcParameter(AbapName:=""CANCEL"", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Optional:=False, Direction:=RFCINOUT.OUT, Length:=1, Length2:=2), _")
      .AppendLine("          XmlElement(""CANCEL"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByVal Cancel As String)")
      .AppendLine("")
      .AppendLine("      Try")
      .AppendLine("        If RemoteOpenSQL.Items(""" & GUID & """).IsCancellationRequested OrElse Abap_Code_Version <> ""1.0.0.0"" Then")
      .AppendLine("          Cancel = ""X""")
      .AppendLine("          Exit Sub")
      .AppendLine("        End If")
      .AppendLine("")
      .AppendLine("        RemoteOpenSQL.Items(""" & GUID & """).SendCallContext(")
      .AppendLine("                                                             """ & GUID & """,")
      .AppendLine("                                                             """ & ContextGUID & """, ")
      .AppendLine("                                                             Context_Index, ")
      .AppendLine("                                                             Max_Rows, ")
      .AppendLine("                                                             Partition_Size, ")
      .AppendLine("                                                             Parse_Nodes_Step_1, ")
      .AppendLine("                                                             Parse_Nodes_Step_N, ")
      .AppendLine("                                                             Selected_Fields, ")
      .AppendLine("                                                             Orderby_Fields)")
       .AppendLine("      Catch ex As Exception")
      .AppendLine("      End Try")
      .AppendLine("")
      .AppendLine("    End Sub")
      .AppendLine("")

      ' Sezione per la definizione della funzione remota del server RECEIVE_NEXT_ROW

      .AppendLine("      <RfcMethod(AbapName:=""RECEIVE_NEXT_ROW"")> _")
      .AppendLine("    Protected Sub RECEIVE_NEXT_ROW( _")
      .AppendLine("          <RfcParameter(AbapName:=""NEXT_ROW"", RFCTYPE:=RFCTYPE.RFCTYPE_STRUCTURE, Optional:=False, Direction:=RFCINOUT.IN, Length:=" & OrderByRfcStructure.Length & ", Length2:=" & OrderByRfcStructure.Length2 & "), _")
      .AppendLine("          XmlElement(""NEXT_ROW"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByVal Next_Row As " & OrderByRfcStructure.AbapName & ", _")
      .AppendLine("          <RfcParameter(AbapName:=""CANCEL"", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Optional:=False, Direction:=RFCINOUT.OUT, Length:=1, Length2:=2), _")
      .AppendLine("          XmlElement(""CANCEL"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Cancel As String)")
      .AppendLine("")
      .AppendLine("      Try")
      .AppendLine("        If RemoteOpenSQL.Items(""" & GUID & """).IsCancellationRequested Then")
      .AppendLine("          Cancel = ""X""")
      .AppendLine("          Exit Sub")
      .AppendLine("        End If")
      .AppendLine("")
      .AppendLine("        RemoteOpenSQL.Items(""" & GUID & """).ReceiveNextRow(")
      .AppendLine("                                                              """ & GUID & """,")
      .AppendLine("                                                             """ & ContextGUID & """, ")
      .AppendLine("                                                             Next_Row,")
      .AppendLine("                                                             Cancel)")
      .AppendLine("      Catch ex As Exception")
      .AppendLine("      End Try")
      .AppendLine("")
      .AppendLine("    End Sub")
      .AppendLine("")

      ' Sezione per la definizione della funzione remota del server SEND_NEXT_ROW

      .AppendLine("      <RfcMethod(AbapName:=""SEND_NEXT_ROW"")> _")
      .AppendLine("    Protected Sub SEND_NEXT_ROW( _")
      .AppendLine("          <RfcParameter(AbapName:=""NEXT_ROW"", RFCTYPE:=RFCTYPE.RFCTYPE_STRUCTURE, Optional:=False, Direction:=RFCINOUT.OUT, Length:=" & OrderByRfcStructure.Length & ", Length2:=" & OrderByRfcStructure.Length2 & "), _")
      .AppendLine("          XmlElement(""NEXT_ROW"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef next_row As " & OrderByRfcStructure.AbapName & ", _")
      .AppendLine("          <RfcParameter(AbapName:=""CANCEL"", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Optional:=False, Direction:=RFCINOUT.OUT, Length:=1, Length2:=2), _")
      .AppendLine("          XmlElement(""CANCEL"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Cancel As String)")
      .AppendLine("")
      .AppendLine("      Try")
      .AppendLine("        If RemoteOpenSQL.Items(""" & GUID & """).IsCancellationRequested Then")
      .AppendLine("          Cancel = ""X""")
      .AppendLine("          Exit Sub")
      .AppendLine("        End If")
      .AppendLine("")
      .AppendLine("        Dim NextRow As SapStructure = Nothing")
      .AppendLine("        RemoteOpenSQL.Items(""" & GUID & """).SendNextRow(")
      .AppendLine("                                                          """ & GUID & """,")
      .AppendLine("                                                          """ & ContextGUID & """,")
      .AppendLine("                                                          NextRow,")
      .AppendLine("                                                          Cancel)")
      .AppendLine("        next_row = New " & OrderByRfcStructure.AbapName)
      .AppendLine("        For ItemIndex As Integer = 0 To SapStructure.GetSAPFieldsSchema(NextRow.GetType()).Length - 1")
      .AppendLine("          next_row.Item(ItemIndex) = NextRow.Item(ItemIndex)")
      .AppendLine("        Next")
      .AppendLine("")
      .AppendLine("      Catch ex As Exception")
      .AppendLine("      End Try")
      .AppendLine("")
      .AppendLine("    End Sub")
      .AppendLine("")

      ' Sezione per la definizione della funzione remota del server RECEIVE_ROWS

      .AppendLine("      <RfcMethod(AbapName:=""RECEIVE_ROWS"")> _")
      .AppendLine("    Protected Sub RECEIVE_ROWS( _")
      .AppendLine("          <RfcParameter(AbapName:=""BLOCKINDEX"", RFCTYPE:=RFCTYPE.RFCTYPE_INT, Optional:=False, Direction:=RFCINOUT.IN, Length := 4, Length2 := 4), _")
      .AppendLine("          XmlElement(""BLOCKINDEX"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByVal BlockIndex As Integer, _")
      .AppendLine("          <RfcParameter(AbapName:=""SELECTLENGTHC"", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Optional:=False, Direction:=RFCINOUT.IN, Length:=21, Length2:=42), _")
      .AppendLine("          XmlElement(""SELECTLENGTHC"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByVal SelectLenghtC As String, _")
      .AppendLine("          <RfcParameter(AbapName:=""COMPLETEADDING"", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Optional:=False, Direction:=RFCINOUT.IN, Length:=1, Length2:=2), _")
      .AppendLine("          XmlElement(""COMPLETEADDING"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByVal CompleteAdding As String, _")
      .AppendLine("          <RfcParameter(AbapName:=""SELECTERROR"", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Optional:=False, Direction:=RFCINOUT.IN, Length:=1, Length2:=2), _")
      .AppendLine("          XmlElement(""SELECTERROR"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByVal SelectError As String, _")
      .AppendLine("          <RfcParameter(AbapName:=""MESSAGE"", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Optional:=False, Direction:=RFCINOUT.IN, Length:=255, Length2:=510), _")
      .AppendLine("          XmlElement(""MESSAGE"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByVal Message As String, _")
      .AppendLine("          <RfcParameter(AbapName:=""CANCEL"", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Optional:=False, Direction:=RFCINOUT.OUT, Length:=1, Length2:=2), _")
      .AppendLine("          XmlElement(""CANCEL"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Cancel As String, _")
      .AppendLine("          <RfcParameter(AbapName:=""ROWS"",RfcType := RFCTYPE.RFCTYPE_ITAB, Optional := true, Direction := RFCINOUT.IN), _")
      .AppendLine("          XmlArray(""ROWS"", IsNullable := False, Form := XmlSchemaForm.Unqualified), ")
      .AppendLine("          XmlArrayItem(""item"", IsNullable := False, Form := XmlSchemaForm.Unqualified)>")
      .AppendLine("        ByRef Rows As " & LineRfcStructure.AbapName & "Table)")
      .AppendLine("")
      .AppendLine("      Try")
      .AppendLine("")
      .AppendLine("        Rows.SetReceiveRowsAllowed(False)")
      .AppendLine("")
      .AppendLine("        RemoteOpenSQL.Items(""" & GUID & """).EndToReceiveRows(")
      .AppendLine("                                                              """ & GUID & """,")
      .AppendLine("                                                               """ & ContextGUID & """,")
      .AppendLine("                                                               SelectLenghtC,")
      .AppendLine("                                                               CompleteAdding,")
      .AppendLine("                                                               SelectError,")
      .AppendLine("                                                               Message,")
      .AppendLine("                                                               Cancel)")
      .AppendLine("")
      .AppendLine("      Catch ex As Exception")
      .AppendLine("      End Try")
      .AppendLine("")
      .AppendLine("    End Sub")
      .AppendLine("")

      ' Sezione per la definizione della funzione remota del server RECEIVE_MESSAGE

      .AppendLine("      <RfcMethod(AbapName:=""RECEIVE_MESSAGE"")> _")
      .AppendLine("    Protected Sub RECEIVE_MESSAGE( _")
      .AppendLine("          <RfcParameter(AbapName := ""MESSAGE"", RfcType := RFCTYPE.RFCTYPE_CHAR, Optional := true, Direction := RFCINOUT.IN, Length := 255, Length2 := 510), _")
      .AppendLine("          XmlElement(""MESSAGE"", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByVal Message As String, _")
      .AppendLine("          <RfcParameter(AbapName := ""LINE"", RfcType := RFCTYPE.RFCTYPE_INT, Optional := true, Direction := RFCINOUT.IN), _")
      .AppendLine("          XmlElement(""LINE"", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByVal Line As Integer)")
      .AppendLine("")
      .AppendLine("      Try")
      .AppendLine("        RemoteOpenSQL.Items(""" & GUID & """).ReceiveMessage(")
      .AppendLine("                                                              """ & GUID & """,")
      .AppendLine("                                                             """ & ContextGUID & """,")
      .AppendLine("                                                             Message,")
      .AppendLine("                                                             Line)")
      .AppendLine("      Catch ex As Exception")
      .AppendLine("      End Try")
      .AppendLine("")
      .AppendLine("    End Sub")
      .AppendLine("")


      .AppendLine("  End Class")
      .AppendLine("")
    End With

    Dim CompileErrors As String = Nothing
    Dim ReferencedAssemblies = New List(Of String)

    With ReferencedAssemblies
      .Add("RemoteOpenSQLLib.dll")
      .Add("SAP.Connector.dll")
      .Add("SAP.Connector.Rfc.dll")
      .Add("SapNetConnector2Proxy2010.dll")
      .Add("System.dll")
      .Add("System.Core.dll")
      .Add("System.Web.dll")
      .Add("System.Web.Services.dll")
      .Add("System.Xml.dll")
      .Add("System.Xml.Linq.dll")
    End With

    Dim CompilerResults = CompilerServices.CompileCode(New Microsoft.VisualBasic.VBCodeProvider(), SourceCode.ToString, Nothing, Nothing, Nothing, ReferencedAssemblies, Nothing, CompileErrors)

    If CompilerResults.Errors.HasErrors Or CompilerResults.Errors.HasWarnings Then
      For Each CompilerError As CodeDom.Compiler.CompilerError In CompilerResults.Errors
        If CompilerError.ErrorNumber <> "BC42015" Then
          Throw New CompileException(CompilerError.ToString)
        End If
      Next
    End If

    If CompilerResults.Errors.HasErrors Then
      Return Nothing
    End If

    For Each TypeItem In CompilerResults.CompiledAssembly.GetTypes()
      If TypeItem.Name = "SapCallbackServer" Then
        Return Activator.CreateInstance(TypeItem)
      End If
    Next

    Return Nothing
  End Function

  Private Sub AddSapStructureCode(
                             ByVal SourceCode As StringBuilder,
                             ByVal RfcStructureAttribute As RfcStructureAttribute,
                             ByVal RfcFieldAttributes As List(Of RfcFieldAttribute),
                             Optional ByVal RosRfcFieldAttributes As List(Of RfcFieldAttribute) = Nothing)

    With SourceCode
      .AppendLine("  <Serializable, RfcStructure(AbapName :=""" & RfcStructureAttribute.AbapName & """  , Length := " & RfcStructureAttribute.Length & ", Length2 := " & RfcStructureAttribute.Length2 & ")> _")
      .AppendLine("  Public Class " & RfcStructureAttribute.AbapName & " ")
      .AppendLine("    Inherits RosSAPStructure")
      .AppendLine("")

      ' Aggiunta di tutti i campi
      For Each RfcFieldAttribute In RfcFieldAttributes
        Dim RFCTYPEString = [Enum].GetName(GetType(RFCTYPE), RfcFieldAttribute.RfcType)
        Dim NetType = RfcTypeToNetType(RfcFieldAttribute.RfcType)
        Dim SapCodePropertyName = GetSapCodePropertyName(RfcFieldAttribute)

        .AppendLine("    <RfcField(AbapName := """ & RfcFieldAttribute.AbapName &
                              """, RfcType := RFCTYPE." & RFCTYPEString &
                              ", Length := " & RfcFieldAttribute.Length &
                              ", Length2 := " & RfcFieldAttribute.Length2 &
                              ", Decimals := " & RfcFieldAttribute.Decimals &
                              ", Offset := " & RfcFieldAttribute.Offset &
                              ", Offset2 := " & RfcFieldAttribute.Offset2 & "), _")
        .AppendLine("    XmlElement(""" & GetSapCodeXmlElementName(RfcFieldAttribute) & """, Form := XmlSchemaForm.Unqualified)> _")
        .AppendLine("    Public Property [" & SapCodePropertyName & "] As " & NetType)
        .AppendLine("       Get")
        .AppendLine("          Return _" & SapCodePropertyName)
        .AppendLine("       End Get")
        .AppendLine("       Set(ByVal Value As " & NetType & ")")
        .AppendLine("          _" & SapCodePropertyName & " = Value")
        .AppendLine("       End Set")
        .AppendLine("    End Property")
        .AppendLine("    Private _" & SapCodePropertyName & " As  " & NetType)
        .AppendLine("")
      Next

      Dim EnabledRfcFieldAttributes As List(Of RfcFieldAttribute)
      Dim EnabledRfcFieldAttribute As RfcFieldAttribute
      Dim EnabledRfcFieldSapCodePropertyName = String.Empty

      If RosRfcFieldAttributes Is Nothing Then
        EnabledRfcFieldAttributes = RfcFieldAttributes
      Else
        EnabledRfcFieldAttributes = RosRfcFieldAttributes
      End If

      .AppendLine("    Public Overrides Function GetItemsArray As Object()")
      .AppendLine("      Return New Object(){")
      For Index = 0 To EnabledRfcFieldAttributes.Count - 2
        .AppendLine("                          _" & GetSapCodePropertyName(EnabledRfcFieldAttributes(Index)) & ",")
      Next
      .AppendLine("                          _" & GetSapCodePropertyName(EnabledRfcFieldAttributes.Last) & "}")
      .AppendLine("    End Function")
      .AppendLine("")
      .AppendLine("    Public Overrides Sub WriteToStreamWriter(ByVal StreamWriter As StreamWriter, ByVal FieldsSeparatorValue As String)")
      .AppendLine("      With StreamWriter")
      For Index = 0 To EnabledRfcFieldAttributes.Count - 2
        EnabledRfcFieldAttribute = EnabledRfcFieldAttributes(Index)
        EnabledRfcFieldSapCodePropertyName = GetSapCodePropertyName(EnabledRfcFieldAttribute)
        If EnabledRfcFieldAttribute.RfcType = RFCTYPE.RFCTYPE_BYTE Then
          .AppendLine("        For ByteArrayIndex As Integer = 0 To _" & EnabledRfcFieldSapCodePropertyName & ".Length - 1")
          .AppendLine("          .Write(_" & EnabledRfcFieldSapCodePropertyName & "(ByteArrayIndex).ToString(""X2""))")
          .AppendLine("        Next")
        Else
          .AppendLine("        .Write(_" & EnabledRfcFieldSapCodePropertyName & ".ToString)")
        End If
        .AppendLine("        .Write(FieldsSeparatorValue)")
      Next
      EnabledRfcFieldAttribute = EnabledRfcFieldAttributes.Last
      EnabledRfcFieldSapCodePropertyName = GetSapCodePropertyName(EnabledRfcFieldAttribute)
      If EnabledRfcFieldAttribute.RfcType = RFCTYPE.RFCTYPE_BYTE Then
        .AppendLine("        For ByteArrayIndex As Integer = 0 To _" & EnabledRfcFieldSapCodePropertyName & ".Length - 1")
        .AppendLine("          .Write(_" & EnabledRfcFieldSapCodePropertyName & "(ByteArrayIndex).ToString(""X2""))")
        .AppendLine("        Next")
      Else
        .AppendLine("        .Write(_" & EnabledRfcFieldSapCodePropertyName & ".ToString)")
      End If
      .AppendLine("      End With")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("  End Class")
      .AppendLine("")
    End With
  End Sub

  Private Function GetSapCodeXmlElementName(ByVal RfcFieldAttribute As RfcFieldAttribute) As String
    Return Replace(RfcFieldAttribute.AbapName, "/", "_-")
  End Function

  Private Function GetSapCodePropertyName(ByVal RfcFieldAttribute As RfcFieldAttribute) As String

    Dim Result = String.Empty

    With RfcFieldAttribute
      If Left(.AbapName, 1) = "/" Then
        Result = Mid(.AbapName, 2)
      Else
        Result = .AbapName
      End If

      Result = Replace(Result, "/", "_")

      Return MixedCase(Result, "_")
    End With

  End Function

  Private Sub AddSapTableCode(ByVal SourceCode As StringBuilder, ByVal AbapName As String)

    With SourceCode
      .AppendLine("  <Serializable> _")
      .AppendLine("  Public Class " & AbapName & "Table")
      .AppendLine("    Inherits SAPTable")
      .AppendLine("")
      .AppendLine("    Public Overloads Overrides Function GetElementType() As Type")
      .AppendLine("        Return GetType(" & AbapName & ")")
      .AppendLine("    End Function")
      .AppendLine("")
      .AppendLine("    Overrides Public Function CreateNewRow() As Object ")
      .AppendLine("        Return new " & AbapName & "()")
      .AppendLine("    End Function")
      .AppendLine("     ")
      .AppendLine("    Default Public Property Item(ByVal Index As Integer) As " & AbapName)
      .AppendLine("        Get ")
      .AppendLine("            Return CType(List(Index), " & AbapName & ")")
      .AppendLine("        End Get")
      .AppendLine("        Set(ByVal Value As " & AbapName & ")")
      .AppendLine("            List(Index) = Value")
      .AppendLine("        End Set")
      .AppendLine("    End Property")
      .AppendLine("        ")
      .AppendLine("    Public Function Add(ByVal Value As " & AbapName & ") As Integer ")
      .AppendLine("        Return List.Add(Value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Sub Insert(ByVal Index As Integer, ByVal Value As " & AbapName & ") ")
      .AppendLine("        List.Insert(Index, value)")
      .AppendLine("    End Sub")
      .AppendLine("        ")
      .AppendLine("    Public Function IndexOf(ByVal Value As " & AbapName & ") As Integer")
      .AppendLine("        Return List.IndexOf(value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Function Contains(ByVal Value As " & AbapName & ") As Boolean")
      .AppendLine("        Return List.Contains(value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Sub Remove(ByVal Value As " & AbapName & ") ")
      .AppendLine("        List.Remove(value)")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Sub CopyTo(ByVal Array() As " & AbapName & ", ByVal Index As Integer) ")
      .AppendLine("        List.CopyTo(array, index)")
      .AppendLine("    End Sub")
      .AppendLine("  End Class")
      .AppendLine("")
    End With

  End Sub

  Private Sub AddConsumerSapTableCode(ByVal ContextGUID As String, ByVal SourceCode As StringBuilder, ByVal AbapName As String)

    With SourceCode
      .AppendLine("  <Serializable> _")
      .AppendLine("  Public Class " & AbapName & "Table")
      .AppendLine("    Inherits SAPTable")
      .AppendLine("    Implements IList")
      .AppendLine("")
      .AppendLine("    Private Consumer As DataConsumer")
      .AppendLine("    Private ReceiveRowsAllowed As Boolean")
      .AppendLine("")
      .AppendLine("    Public Sub New()")
      .AppendLine("      Consumer = RemoteOpenSQL.Items(""" & GUID & """).GetConsumer()")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Friend Sub SetReceiveRowsAllowed(value As Boolean)")
      .AppendLine("      ReceiveRowsAllowed = value")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Function Add(ByVal Value As Object) As Integer Implements IList.Add")
      .AppendLine("      If Not ReceiveRowsAllowed Then")
      .AppendLine("        RemoteOpenSQL.Items(""" & GUID & """).WaitForReceiveRows(")
      .AppendLine("          """ & GUID & """,")
      .AppendLine("          """ & ContextGUID & """)")
      .AppendLine("        ReceiveRowsAllowed = True")
      .AppendLine("      End If")
      .AppendLine("      Consumer.Consume(CType(Value, RosSAPStructure))")
      .AppendLine("      Return 0")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Overloads Overrides Function GetElementType() As Type")
      .AppendLine("        Return GetType(" & AbapName & ")")
      .AppendLine("    End Function")
      .AppendLine("")
      .AppendLine("    Overrides Public Function CreateNewRow() As Object ")
      .AppendLine("        Return new " & AbapName & "()")
      .AppendLine("    End Function")
      .AppendLine("     ")
      .AppendLine("    Default Public Property Item(ByVal Index As Integer) As " & AbapName)
      .AppendLine("        Get ")
      .AppendLine("            Return CType(List(Index), " & AbapName & ")")
      .AppendLine("        End Get")
      .AppendLine("        Set(ByVal Value As " & AbapName & ")")
      .AppendLine("            List(Index) = Value")
      .AppendLine("        End Set")
      .AppendLine("    End Property")
      .AppendLine("        ")
      .AppendLine("    Public Function Add(ByVal Value As " & AbapName & ") As Integer ")
      .AppendLine("        Return List.Add(Value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Sub Insert(ByVal Index As Integer, ByVal Value As " & AbapName & ") ")
      .AppendLine("        List.Insert(Index, value)")
      .AppendLine("    End Sub")
      .AppendLine("        ")
      .AppendLine("    Public Function IndexOf(ByVal Value As " & AbapName & ") As Integer")
      .AppendLine("        Return List.IndexOf(value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Function Contains(ByVal Value As " & AbapName & ") As Boolean")
      .AppendLine("        Return List.Contains(value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Sub Remove(ByVal Value As " & AbapName & ") ")
      .AppendLine("        List.Remove(value)")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Sub CopyTo(ByVal Array() As " & AbapName & ", ByVal Index As Integer) ")
      .AppendLine("        List.CopyTo(array, index)")
      .AppendLine("    End Sub")
      .AppendLine("  End Class")
      .AppendLine("")
    End With
  End Sub



  Private Sub InitSapObject(ByVal sapObject As Object)
    ' Get the type and PropertyInfo.
    If Not sapObject Is Nothing Then
      Dim SapType As Type = sapObject.GetType
      Dim SapFields As FieldInfo() = SapType.GetFields
      Dim SapField As FieldInfo

      For Each SapField In SapFields
        If SapField.IsPublic AndAlso _
           (SapField.FieldType.IsSubclassOf(GetType(SAP.Connector.SAPTable)) OrElse _
            SapField.FieldType.IsSubclassOf(GetType(SAP.Connector.SAPStructure))) Then
          SapField.SetValue(sapObject, Activator.CreateInstance(SapField.FieldType))
        End If
      Next
    End If
  End Sub

  Private Function GetTables(ByVal ParseTree As NonterminalToken) As List(Of String)
    Dim Result = New List(Of String)
    For Each Token In ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("From Clause").TerminalChilds("Id", True)
      Result.Add(Token.Text)
    Next
    Return Result
  End Function

  Private Function GetColumnsIds(ByVal ParseTree As NonterminalToken) As List(Of String)
    Dim Result = New List(Of String)
    For Each Token In ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("Columns").TerminalChilds("Id", True)
      Result.Add(Token.Text)
    Next
    If Result.Count = 0 Then
      Result.Add(ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("Columns").TerminalChild(" *").Text)
    End If
    Return Result
  End Function

  Private Function GetOrderByIds(ByVal ParseTree As NonterminalToken) As List(Of String)
    Dim Result = New List(Of String)
    For Each Token In ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("Order Clause").TerminalChilds("Id", True)
      Result.Add(Token.Text)
    Next
    Return Result
  End Function

  Private Function GetOrderByPrimaryKey(ByVal ParseTree As NonterminalToken) As Boolean
    Return ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("Order Clause").Rule.ToString = "<Order Clause> ::= ORDER BY PRIMARY KEY"
  End Function

  Private Function GetClientSpecified(ByVal ParseTree As NonterminalToken) As Boolean
    Return ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("From Clause").NonTerminalChild("Client Specified Clause").Rule.ToString = "<Client Specified Clause> ::= CLIENT SPECIFIED"
  End Function

  Private Function RebuildQuery(ByVal ParseTree As NonterminalToken, Optional ByVal SymbolNameToSkip As String = "") As String
    Dim TokenStack = New Stack(Of Token)
    Dim Result = New StringBuilder

    TokenStack.Push(ParseTree)
    Do While TokenStack.Count > 0
      Dim CurrToken = TokenStack.Pop
      If TypeOf CurrToken Is TerminalToken Then
        Dim CurrTerminalToken = CType(CurrToken, TerminalToken)
        If CurrTerminalToken.Symbol.Name <> SymbolNameToSkip Then
          If Result.Length > 0 AndAlso Left(CurrTerminalToken.Text, 1) <> " " Then
            Result.Append(" ")
          End If
          Result.Append(CurrTerminalToken.Text)
        End If
      ElseIf TypeOf CurrToken Is NonterminalToken Then
        Dim CurrNonterminalToken = CType(CurrToken, NonterminalToken)
        If CurrNonterminalToken.Symbol.Name <> SymbolNameToSkip Then
          For Count = CurrNonterminalToken.Tokens.Length - 1 To 0 Step -1
            TokenStack.Push(CurrNonterminalToken.Tokens(Count))
          Next
        End If
      End If
    Loop

    Return Result.ToString
  End Function

  Private Sub FillParseTreeTable(ByVal ParseTree As NonterminalToken, ByVal ParseTreeTable As ROS_PARSE_NODETable)
    Dim TokenStack = New Stack(Of Token)
    Dim IdStack = New Stack(Of Integer)
    Dim CurrentId = 0

    TokenStack.Push(ParseTree)
    IdStack.Push(0)

    Do While TokenStack.Count > 0
      Dim CurrToken = TokenStack.Pop
      CurrentId += 1
      Dim FatherId = IdStack.Pop
      Dim ParseTreeLine = New ROS_PARSE_NODE

      With ParseTreeLine
        .Id = CurrentId
        .Parent = FatherId
        If TypeOf CurrToken Is TerminalToken Then
          .Symbol = CType(CurrToken, TerminalToken).Symbol.Name
          .Text_Or_Rule = CType(CurrToken, TerminalToken).Text
          .Terminal = "X"
        ElseIf TypeOf CurrToken Is NonterminalToken Then
          Dim CurrNonterminalToken = CType(CurrToken, NonterminalToken)
          Dim RuleTokens = Split(CurrNonterminalToken.Rule.ToString, "::=")
          .Symbol = Left(RuleTokens(0), Len(RuleTokens(0)) - 1)
          .Text_Or_Rule = Mid(RuleTokens(1), 2)
          .Terminal = ""
          For Count = CurrNonterminalToken.Tokens.Length - 1 To 0 Step -1
            TokenStack.Push(CurrNonterminalToken.Tokens(Count))
            IdStack.Push(CurrentId)
          Next
        End If
      End With

      ParseTreeTable.Add(ParseTreeLine)
    Loop

  End Sub

  Private Sub FillFieldsTable(ByVal FieldsList As Dictionary(Of String, RosFieldInfo), ByVal FieldsTable As ROS_FIELD_INFOTable)
    For Each FieldItem In FieldsList.Values
      Dim FieldTableLine = New ROS_FIELD_INFO

      With FieldTableLine
        .FieldName = LCase(FieldItem.FieldName)
        .RollNameOrABAPType = LCase(FieldItem.RollNameOrABAPType)
      End With
      FieldsTable.Add(FieldTableLine)
    Next
  End Sub

  Private Function GetParseTreeStep1(ByVal RemoteOpenSQLParseTree As NonterminalToken, ByVal SelectedFields As Dictionary(Of String, RosFieldInfo)) As NonterminalToken
    ' Costruisco la stringa contenente la query per il passo 1
    Dim QueryStep1 = "SELECT"

    With RemoteOpenSQLParseTree.NonTerminalChild("Select Stm")
      Dim Columns = RebuildQuery(.NonTerminalChild("Columns"))
      If Columns <> " *" Then
        For Each SelectedField In SelectedFields.Values
          QueryStep1 += " " & SelectedField.FieldName
        Next
      Else
        JoinQuerySteps(QueryStep1, Columns)
      End If
      JoinQuerySteps(QueryStep1, RebuildQuery(.NonTerminalChild("From Clause")))
      JoinQuerySteps(QueryStep1, "UP TO uptorows ROWS")
      JoinQuerySteps(QueryStep1, "INTO CORRESPONDING FIELDS OF TABLE ta_lines")
      JoinQuerySteps(QueryStep1, RebuildQuery(.NonTerminalChild("Where Clause")))
      JoinQuerySteps(QueryStep1, RebuildQuery(.NonTerminalChild("Order Clause")))
    End With

    ' Parse Query
    Dim Parser = SapOpenSQLGrammarReader.CreateNewParser
    Dim Result As NonterminalToken = Parser.Parse(QueryStep1)
    Return Result
  End Function

  Private Sub JoinQuerySteps(ByRef QueryStep1 As String, ByRef QueryStepN As String)
    If Right(QueryStep1, 1) <> " " AndAlso Left(QueryStepN, 1) <> " " Then
      QueryStep1 += " " & QueryStepN
    Else
      QueryStep1 += QueryStepN
    End If
  End Sub

  Private Function GetParseTreeStepN(ByVal RemoteOpenSQLParseTree As NonterminalToken, ByVal SelectedFields As Dictionary(Of String, RosFieldInfo), ByVal OrderByFields As Dictionary(Of String, RosFieldInfo)) As NonterminalToken
    ' Costruisco la stringa contenente la query per il passo 1
    Dim QueryStepN = "SELECT"

    With RemoteOpenSQLParseTree.NonTerminalChild("Select Stm")
      Dim Columns = RebuildQuery(.NonTerminalChild("Columns"))
      If Columns <> " *" Then
        For Each SelectedField In SelectedFields.Values
          QueryStepN += " " & SelectedField.FieldName
        Next
      Else
        JoinQuerySteps(QueryStepN, Columns)
      End If
      JoinQuerySteps(QueryStepN, RebuildQuery(.NonTerminalChild("From Clause")))
      JoinQuerySteps(QueryStepN, "UP TO uptorows ROWS")
      JoinQuerySteps(QueryStepN, "INTO CORRESPONDING FIELDS OF TABLE ta_lines")
      Dim WhereExpression = Trim(RebuildQuery(.NonTerminalChild("Where Clause").NonTerminalChild("Expression")))
      QueryStepN += " WHERE"
      If WhereExpression <> String.Empty Then
        QueryStepN += " ( " & WhereExpression & " ) AND"
      End If
      '(
      '(A > 0)
      ' OR (A = 0 AND B > 0) 
      ' OR (A = 0 AND B = 0 AND C > 0) 
      ' OR (A = 0 AND B = 0 AND C = 0 AND D >= 0) 
      ')
      QueryStepN += " ("
      ' Ciclo degli OR
      For OrCount = 0 To OrderByFields.Count - 1
        If OrCount = 0 Then
          QueryStepN += " ("
        Else
          QueryStepN += " OR ("
        End If
        ' Ciclo degli AND
        For AndCount = 0 To OrCount
          If AndCount > 0 Then
            QueryStepN += " AND"
          End If
          Dim OrderByField = OrderByFields.Values(AndCount)
          Dim LogicalOperator As String
          If OrCount = OrderByFields.Count - 1 And AndCount = OrderByFields.Count - 1 Then
            LogicalOperator = ">="
          ElseIf AndCount = OrCount Then
            LogicalOperator = ">"
          Else
            LogicalOperator = "="
          End If
          QueryStepN += " " & OrderByField.FieldName & " " & LogicalOperator & " wa_orderby-" & OrderByField.FieldName
        Next
        QueryStepN += " )"
      Next
      QueryStepN += " )"

      JoinQuerySteps(QueryStepN, RebuildQuery(.NonTerminalChild("Order Clause")))
    End With

    ' Parse Query
    Dim Parser = SapOpenSQLGrammarReader.CreateNewParser
    Dim Result As NonterminalToken = Parser.Parse(QueryStepN)
    Return Result
  End Function

  Public Function GetRemoteOpenSQLGrammar() As String
    Return File.ReadAllText(RemoteOpenSQLGrammarFullPath)
  End Function

  Public Function GetAbapCodeRfcRemoteOpenSql() As String
    Dim Result = File.ReadAllText(Path.Combine(My.Application.Info.DirectoryPath, "Z_REMOTE_OPEN_SQL.txt"), Encoding.Default)
    Dim GetProductionsFormHeader =
      "*&---------------------------------------------------------------------*" & vbCrLf &
      "*&      Form  get_productions" & vbCrLf &
      "*&---------------------------------------------------------------------*"

    Return Left(Result, InStr(Result, GetProductionsFormHeader) - 1) & vbCrLf & GetAbapCodeFormGetProductions()
  End Function

  Private Function GetAbapCodeFormGetProductions() As String
    Dim Result As New StringBuilder

    With Result
      .AppendLine("*&---------------------------------------------------------------------*")
      .AppendLine("*&      Form  get_productions")
      .AppendLine("*&---------------------------------------------------------------------*")
      .AppendLine("*       Build productions table")
      .AppendLine("*----------------------------------------------------------------------*")
      .AppendLine("*      -->PRODUCTIONS  productions of RemoteOpenSQL Grammar")
      .AppendLine("*----------------------------------------------------------------------*")
      .AppendLine("  FORM get_productions CHANGING productions TYPE table.")
      .AppendLine("    TYPES: BEGIN OF production,")
      .AppendLine("      index TYPE i,")
      .AppendLine("      head TYPE char255,")
      .AppendLine("      handle TYPE char255,")
      .AppendLine("      END OF production.")
      .AppendLine("")
      .AppendLine("    DATA: wa_production TYPE production.")
      .AppendLine("")

      Dim RuleIndex = 0
      For Each Rule In SapOpenSQLGrammarReader.Rules
        Dim RuleTokens = Split(Rule.ToString, "::=")
        .AppendLine("    wa_production-index = " & RuleIndex & ".")
        .AppendLine("    wa_production-head = '" & Replace(Left(RuleTokens(0), Len(RuleTokens(0)) - 1), "'", "''") & "'.")
        .AppendLine("    wa_production-handle = '" & Replace(Mid(RuleTokens(1), 2), "'", "''") & "'.")
        .AppendLine("    APPEND wa_production TO productions.")
        RuleIndex += 1
      Next
      .AppendLine("  ENDFORM.                    ""get_productions")
    End With

    Return Result.ToString
  End Function
End Class
