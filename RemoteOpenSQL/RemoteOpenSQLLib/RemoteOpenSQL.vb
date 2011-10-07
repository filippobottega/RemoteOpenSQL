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

Imports SAP.Connector
Imports com.calitha.goldparser
Imports System.IO
Imports System.Text
Imports System.Reflection
Imports System.Threading
Imports System.Collections.Concurrent
Imports System.Threading.Tasks
Imports RemoteOpenSQL.SapNetConnector2Proxy2010

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

Public Class RemoteOpenSQLException
  Inherits Exception

  Public Sub New(ByVal Message As String)
    MyBase.New(Message)
  End Sub

  Public Sub New(ByVal message As String, ByVal innerException As System.Exception)
    MyBase.New(message, innerException)
  End Sub
End Class

Partial Public Class RemoteOpenSQL

  Private Shared ItemsValue As Dictionary(Of String, RemoteOpenSQL) = New Dictionary(Of String, RemoteOpenSQL)

  Private ExceptionsAggregator As List(Of Exception)

  Private GUIDValue As String
  Private DestinationValue As Destination
  Private RemoteOpenSQLCompiledGrammarFullPath As String = Path.Combine(My.Application.Info.DirectoryPath, "Gold\RemoteOpenSQL.cgt")
  Private SapOpenSQLCompiledGrammarFullPath As String = Path.Combine(My.Application.Info.DirectoryPath, "Gold\SapOpenSQL.cgt")
  Private RemoteOpenSQLGrammarFullPath As String = Path.Combine(My.Application.Info.DirectoryPath, "Gold\RemoteOpenSQL.grm")
  Private SapOpenSQLGrammarFullPath As String = Path.Combine(My.Application.Info.DirectoryPath, "Gold\SapOpenSQL.grm")
  Private RemoteOpenSQLGrammarReader As CGTReader = New CGTReader(RemoteOpenSQLCompiledGrammarFullPath)
  Private SapOpenSQLGrammarReader As CGTReader = New CGTReader(SapOpenSQLCompiledGrammarFullPath)
  Private CancelSourceValue As CancellationTokenSource
  Private SAPCallContexts As New Dictionary(Of String, CallContext)
  Private RunQueryTask As Task
  Private SessionTask1 As Task
  Private SessionTask2 As Task
  Private EventTasks As New List(Of Task)

  Private Consumer As DataConsumer
  ' 800.000 valore stabile per tabella CDPOS
  Private PartitionSizeValue = 50000
  Private BufferValue = 100
  Private EventsTaskFactory As New TaskFactory

  Private Const SupportedAbapCodeVersion As String = "2.0.0.0"

  Private Class FieldItem

    Private AbapNameValue As String
    Private ColumnNameValue As String
    Private ColumnAliasValue As String
    Private OrderNameValue As String

    ''' <summary>
    ''' Nome del campo per l'elemento di una struttura ABAP
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AbapName As String
      Get
        Return AbapNameValue
      End Get
    End Property

    ''' <summary>
    ''' Nome del campo all'interno dell'oggetto tabella
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FieldName As String
      Get
        Return DfiesItem.Fieldname
      End Get
    End Property

    ''' <summary>
    ''' Alias all'interno della query
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ColumnAlias As String
      Get
        Return ColumnAliasValue
      End Get
    End Property


    ''' <summary>
    ''' Nome della colonna senza selettore di colonna
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ColumnName As String
      Get
        Return ColumnNameValue
      End Get
    End Property

    ''' <summary>
    ''' Nome utilizzato nella clausola ORDER BY
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OrderName As String
      Set(value As String)
        If OrderNameValue <> String.Empty Then
          Throw New RemoteOpenSQLException("Order name already assigned. Current value: " & OrderNameValue & ", new value: " & value)
        End If
        OrderNameValue = value
      End Set
      Get
        Return OrderNameValue
      End Get
    End Property

    ''' <summary>
    ''' Elemento dati oppure tipo ABAP
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RollNameOrABAPType As String
      Get
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
      End Get
    End Property

    ''' <summary>
    ''' Riga corrispondente all'interno della tabella DFIES_TAB.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DfiesItem As DFIES

    ''' <summary>
    ''' Oggetto tabella associato al campo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TableItem As TableItem

    ''' <summary>
    ''' Nome con selettore di colonna
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TableNameOrTableAliasAndFieldName As String
      Get
        Return TableItem.UniqueName & "~" & FieldName
      End Get
    End Property

    ''' <summary>
    ''' Nome della colonna con l'eventuale alias
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ColumnNameAndAlias As String
      Get
        If ColumnAliasValue <> String.Empty Then
          Return ColumnNameValue & " AS " & ColumnAliasValue
        Else
          Return ColumnNameValue
        End If
      End Get
    End Property

    ''' <summary>
    ''' Field data will be transferred locally
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TransferData As Boolean

    Public Sub New(TableItem As TableItem, ByVal DfiesItem As DFIES, ColumnName As String, Optional ColumnAlias As String = "", Optional TransferData As Boolean = True)
      MyBase.New()

      ColumnNameValue = ColumnName
      ColumnAliasValue = ColumnAlias

      Me.DfiesItem = DfiesItem
      Me.TableItem = TableItem

      If ColumnAliasValue <> String.Empty Then
        AbapNameValue = ColumnAliasValue
      Else
        AbapNameValue = DfiesItem.Fieldname
      End If

      Me.TransferData = TransferData
    End Sub
  End Class

  Private Class FieldItems
    Private ColumnNamesIndex As New Dictionary(Of String, FieldItem)
    Private ColumnAliasIndex As New Dictionary(Of String, FieldItem)
    Private AbapNamesIndex As New Dictionary(Of String, FieldItem)
    Private FieldList As New List(Of FieldItem)
    Private AsteriskWildcardValue As Boolean

    Friend ReadOnly Property AsEnumerable As System.Collections.Generic.IEnumerable(Of FieldItem)
      Get
        Return FieldList.AsEnumerable
      End Get
    End Property

    Friend Property AsteriskWildcard
      Set(value)
        AsteriskWildcardValue = value
      End Set
      Get
        Return AsteriskWildcardValue
      End Get
    End Property

    Friend Sub Add(FieldItem As FieldItem)
      If FieldItem.ColumnName = String.Empty Then
        Throw New RemoteOpenSQLException("Column name empty.")
      End If
      If ColumnNamesIndex.ContainsKey(FieldItem.ColumnName) OrElse
        AbapNamesIndex.ContainsKey(FieldItem.AbapName) OrElse
        (FieldItem.ColumnAlias <> String.Empty AndAlso
         ColumnAliasIndex.ContainsKey(FieldItem.ColumnAlias)) Then
        Throw New RemoteOpenSQLException("Duplicate column found. Column name " & FieldItem.ColumnName)
      End If

      ColumnNamesIndex.Add(FieldItem.ColumnName, FieldItem)
      AbapNamesIndex.Add(FieldItem.AbapName, FieldItem)
      If FieldItem.ColumnAlias <> String.Empty Then
        ColumnAliasIndex.Add(FieldItem.ColumnAlias, FieldItem)
      End If
      FieldList.Add(FieldItem)
    End Sub

    Friend Sub AddOrderNames(OrderNames As List(Of String), TableItems As Dictionary(Of String, TableItem))
      ' Aggiungo le informazioni dei campi selezionati per l'ordinamento
      ' Se alcuni campi non sono già presenti fra i campi selezionati li aggiungo
      ' I campi aggiunti non saranno utilizzati nel trasferimento dei dati ma solo 
      ' nell'ordinamento.

      Dim OrderAbapNames As New List(Of String)

      For Each OrderName In OrderNames

        Dim OrderNameTokens = Split(OrderName, "~")
        Dim OrderAbapName As String = OrderNameTokens(OrderNameTokens.Count - 1)
        Dim TableNameOrAlias As String = String.Empty
        If OrderNameTokens.Count = 2 Then
          TableNameOrAlias = OrderNameTokens(0)
        End If

        ' Verifica dell'eventuale presenza di nomi di campo duplicati
        If OrderAbapNames.Contains(OrderAbapName) Then
          Throw New RemoteOpenSQLException("Duplicate name found in ORDER BY clause. Name: " & OrderAbapName)
        End If

        OrderAbapNames.Add(OrderAbapName)

        ' Cerco il campo corrispondente fra gli alias
        If ColumnAliasIndex.ContainsKey(OrderName) Then
          ColumnAliasIndex(OrderName).OrderName = OrderName
          Continue For
        End If

        ' Cerco il campo corrispondente fra i nomi di colonna
        If ColumnNamesIndex.ContainsKey(OrderName) Then
          ColumnNamesIndex(OrderName).OrderName = OrderName
          Continue For
        End If

        ' Cerco il campo corrispondente fra i nomi abap
        If AbapNamesIndex.ContainsKey(OrderAbapName) Then
          AbapNamesIndex(OrderAbapName).OrderName = OrderName
          Continue For
        End If

        ' Il campo per l'ordinamento non è stato trovato fra i campi selezionati
        ' Procedo con l'aggiunto del campo ai campi selezionati

        Dim FieldName As String = OrderAbapName

        ' Determino il nome della tabella
        Dim OrderNameTableItem As TableItem = Nothing
        If TableNameOrAlias <> String.Empty Then
          If TableItems.ContainsKey(TableNameOrAlias) Then
            OrderNameTableItem = TableItems(TableNameOrAlias)
          Else
            Throw New RemoteOpenSQLException("ORDER BY " & OrderName & ": table " & TableNameOrAlias & " not found.")
          End If
        Else
          ' Cerco la prima tabella contenente il nome del campo
          For Each TableItem In TableItems.Values
            If TableItem.DFIESTableIndex.ContainsKey(FieldName) Then
              OrderNameTableItem = TableItem
              Exit For
            End If
          Next
        End If

        ' A questo punto la tabella deve essere definita
        If OrderNameTableItem Is Nothing Then
          Throw New RemoteOpenSQLException("ORDER BY " & OrderName & ": table not found.")
        End If

        Dim OrderNameFieldItem As FieldItem
        If TableItems.Count > 1 Then
          OrderNameFieldItem = OrderNameTableItem.GetFieldItem(FieldName, OrderNameTableItem.UniqueName & "~" & FieldName, "", False)
        Else
          OrderNameFieldItem = OrderNameTableItem.GetFieldItem(FieldName, FieldName, "", False)
        End If
        OrderNameFieldItem.OrderName = OrderName
        Add(OrderNameFieldItem)
      Next

    End Sub

    Friend Function GetFieldItem(ColumnNameOrAlias As String) As FieldItem
      If ColumnAliasIndex.ContainsKey(ColumnNameOrAlias) Then
        Return ColumnAliasIndex(ColumnNameOrAlias)
      ElseIf ColumnNamesIndex.ContainsKey(ColumnNameOrAlias) Then
        Return ColumnNamesIndex(ColumnNameOrAlias)
      Else
        Return Nothing
      End If
    End Function

    Friend Function ContainAbapNamesKey(Key As String) As Boolean
      Return AbapNamesIndex.ContainsKey(Key)
    End Function

    Friend Function Count() As Integer
      Return FieldList.Count
    End Function

    Friend Function Item(Index As Integer) As FieldItem
      Return FieldList(Index)
    End Function

    Friend Function GetSelectedFields() As ROS_FIELD_INFOTable
      Dim Result As New ROS_FIELD_INFOTable

      For Each FieldItem In AsEnumerable

        Dim FieldTableLine = New ROS_FIELD_INFO
        With FieldTableLine
          .AbapName = LCase(FieldItem.AbapName)
          .RollNameOrABAPType = LCase(FieldItem.RollNameOrABAPType)
        End With
        Result.Add(FieldTableLine)

      Next

      Return Result

    End Function


    Friend Function GetOrderByFields() As ROS_FIELD_INFOTable
      Dim Result As New ROS_FIELD_INFOTable

      For Each FieldItem In AsEnumerable
        If FieldItem.OrderName = String.Empty Then
          Continue For
        End If

        Dim FieldTableLine = New ROS_FIELD_INFO
        With FieldTableLine
          .AbapName = LCase(FieldItem.AbapName)
          .RollNameOrABAPType = LCase(FieldItem.RollNameOrABAPType)
        End With
        Result.Add(FieldTableLine)

      Next

      Return Result

    End Function
  End Class

  Private Class TableItem

    Private DFIESTableValue As DFIESTable
    Private DFIESTableIndexValue As Dictionary(Of String, Integer)

    ''' <summary>
    ''' Nome della tabella.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property TableName As String
    ''' <summary>
    ''' Alias della tabella.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property TableAlias As String

    ''' <summary>
    ''' Nome che identifica univocamente la tabella all'interno della query OpenSQL
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property UniqueName As String
      Get
        If TableAlias = String.Empty Then
          Return TableName
        Else
          Return TableAlias
        End If
      End Get
    End Property

    Friend Property DFIESTable As DFIESTable
      Set(value As DFIESTable)
        DFIESTableValue = value
        DFIESTableIndexValue = New Dictionary(Of String, Integer)
        For Count = 0 To DFIESTableValue.Count - 1
          DFIESTableIndex.Add(DFIESTableValue.Item(Count).Fieldname, Count)
        Next
      End Set
      Get
        Return DFIESTableValue
      End Get
    End Property

    Friend Function GetPrimaryKeyColumnNames(ClientSpecified As Boolean, UseColumnSelector As Boolean) As List(Of String)

      Dim Result As New List(Of String)

      ' Ciclo su tutti i campi
      For Count = 0 To DFIESTableValue.Count - 1
        Dim DfiesItem = DFIESTableValue.Item(Count)
        If DfiesItem.Keyflag <> "X" Then
          Exit For
        End If
        If Count = 0 AndAlso DfiesItem.Datatype = "CLNT" AndAlso Not ClientSpecified Then
          Continue For
        End If
        ' Determino il nome del campo per l'ordinamento, può contenere il selettore di colonna
        Dim ColumnName As String
        If UseColumnSelector Then
          ColumnName = UniqueName & "~" & DfiesItem.Fieldname
        Else
          ColumnName = DfiesItem.Fieldname
        End If

        Result.Add(ColumnName)
      Next

      Return Result
    End Function

    Friend Sub AddAllFields(FieldItems As FieldItems)

      ' Ciclo su tutti i campi ed aggiungo solo i campi non presenti in FieldItems
      For Count = 0 To DFIESTableValue.Count - 1
        Dim DfiesItem = DFIESTableValue.Item(Count)
        If Not FieldItems.ContainAbapNamesKey(DfiesItem.Fieldname) Then
          FieldItems.Add(New FieldItem(Me, DfiesItem, DfiesItem.Fieldname))
        End If
      Next

    End Sub

    Friend Function GetFieldItem(FieldName As String, ColumnName As String, ColumnAlias As String, TransferData As Boolean) As FieldItem

      Dim DfiesItemIndex = DFIESTableIndexValue(FieldName)
      Dim DfiesItem = DFIESTableValue(DfiesItemIndex)
      Return New FieldItem(Me, DfiesItem, ColumnName, ColumnAlias, TransferData)

    End Function

    Friend ReadOnly Property DFIESTableIndex As Dictionary(Of String, Integer)
      Get
        Return DFIESTableIndexValue
      End Get
    End Property

    Friend Sub New(TableName As String, ByVal TableAlias As String)
      MyBase.New()
      Me.TableName = TableName
      Me.TableAlias = TableAlias
    End Sub
  End Class

  Private Class CallContext
    Implements IDisposable

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

    Public Sub Dispose() Implements IDisposable.Dispose

      If Not NextRowsCollection Is Nothing Then
        If Not NextRowsCollection.IsAddingCompleted Then
          NextRowsCollection.CompleteAdding()
        End If
        NextRowsCollection.Dispose()
        NextRowsCollection = Nothing
      End If

      If Not ReceiveRowsGateCollection Is Nothing Then
        If Not ReceiveRowsGateCollection.IsAddingCompleted Then
          ReceiveRowsGateCollection.CompleteAdding()
        End If
        ReceiveRowsGateCollection.Dispose()
        ReceiveRowsGateCollection = Nothing
      End If

      Parse_Tree_Step_1Value = Nothing
      Parse_Tree_Step_NValue = Nothing
      Selected_FieldsValue = Nothing
      Orderby_FieldsValue = Nothing
      NextRowValue = Nothing
      LinkedContextValue = Nothing

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

  Public Property Buffer As Integer
    Get
      Return BufferValue
    End Get
    Set(ByVal value As Integer)
      BufferValue = value
    End Set
  End Property

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

    If Not DestinationValue Is Nothing Then
      SAP.Connector.Connection.RemoveConnectionsFromPool(DestinationValue)
    End If

    DestinationValue = New Destination

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
      RaiseQueryStatusChanged("Cancel executing query. Plaese wait pending tasks to complete ...")
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
    RunQueryTask.Wait()
  End Sub


  Private Function GetDFIESTable(Client As SAPProxyClient, TableName As String) As DFIESTable
    ' Leggo i metadati della tabella

    Dim Ddif_Fieldinfo_GetInput As New SAPProxyClient.Ddif_Fieldinfo_Get_Input
    Dim Ddif_Fieldinfo_GetOutput As New SAPProxyClient.Ddif_Fieldinfo_Get_Output
    InitSapObject(Ddif_Fieldinfo_GetInput)
    InitSapObject(Ddif_Fieldinfo_GetOutput)

    Ddif_Fieldinfo_GetInput.Tabname = TableName

    Try
      Ddif_Fieldinfo_GetOutput = Client.Ddif_Fieldinfo_Get_(Ddif_Fieldinfo_GetInput)
    Catch ex As RfcSystemException
      Client.Connection.Close()
      Throw
    End Try

    Return Ddif_Fieldinfo_GetOutput.Dfies_Tab
  End Function

  Private Sub CallRfcRemoteOpenSQL(ByVal Query As String)

    Dim CallStartTime As DateTime = Now

    ' Inizializzo un nuovo aggregatore di eccezioni
    ExceptionsAggregator = New List(Of Exception)

    ' Inizializzo un nuovo Token per la cancellazione del processo
    CancelSourceValue = New CancellationTokenSource

    ' Parse Query
    Dim ParseTree = ParseQuery(RemoteOpenSQLGrammarReader, Query)

    ' Determino la lista delle tabelle presenti nella clausola FROM
    Dim TableItems = GetTableItems(ParseTree)

    If TableItems.Count < 1 Then
      Throw New RemoteOpenSQLException("Specify at least a table after FROM clause.")
    End If

    ' Leggo i metadati delle tabelle

    ' Create SAPProxyClient instance
    Dim Client = New SAPProxyClient
    Client.Connection = New SAP.Connector.SAPConnection(DestinationValue)

    For Each TableItem In TableItems.Values
      TableItem.DFIESTable = GetDFIESTable(Client, TableItem.TableName)
    Next

    Client.Connection.Close()

    ' Ottengo la lista di tutti i campi selezionati, se è stato utilizzato il carattere *
    ' creo la lista completa di tutte le colonne selezionabili 
    ' (rimuovo eventuali duplicati di campo presenti su più tabelle)
    Dim FieldItems = GetFieldItems(ParseTree, TableItems)

    Dim OrderNames = GetOrderNames(ParseTree)
    Dim OrderByPrimaryKey = GetOrderByPrimaryKey(ParseTree)
    Dim RebuildOrderClause As Boolean = False

    ' Se non specifico alcun campo per l'ordinamento allora ordino per chiave primaria
    Dim CreateOrderNames As Boolean = False
    If OrderNames.Count = 0 OrElse OrderByPrimaryKey Then
      CreateOrderNames = True
    End If

    If (OrderNames.Count = 0 AndAlso Not OrderByPrimaryKey) OrElse (OrderByPrimaryKey AndAlso TableItems.Count > 1) Then
      RebuildOrderClause = True
    End If

    Dim ClientSpecified = GetClientSpecified(ParseTree)

    ' Rispetto all'OpenSQL la clausola ORDER BY PRIMARY KEY considera solo la chiave primaria
    ' della prima tabella presente nella clausola FROM che abbia una chiave primaria
    If CreateOrderNames Then
      ' Determino se utilizzare il selettore di colonna
      Dim UseColumnSelector As Boolean = False
      If TableItems.Count > 1 Then
        UseColumnSelector = True
      End If

      ' Ciclo su tutte le tabelle
      For Each TableItem In TableItems.Values
        OrderNames = TableItem.GetPrimaryKeyColumnNames(ClientSpecified, UseColumnSelector)
        ' Se ho determinato i campi per l'ordinamento allora esco dal ciclo
        If OrderNames.Count > 0 Then
          Exit For
        End If
      Next
    End If

    ' Aggiungo alla lista dei campi selezionati le informazioni dei campi di ordinamento
    ' aggiungendo eventualmente quei campi di selezione mancanti
    FieldItems.AddOrderNames(OrderNames, TableItems)

    ' Creo le strutture rfc per la generazione del CallbackServer

    Dim Offset As Integer = 0
    Dim Offset2 As Integer = 0
    Dim DfiesItem As DFIES = Nothing
    Dim PrevDfiesItem As DFIES = Nothing

    ' Determino l'elenco degli attributi RFC per tutti i campi di selezione 
    Dim LineRfcFieldAttributes = New List(Of RfcFieldAttribute)

    For Each FieldItem In FieldItems.AsEnumerable
      PrevDfiesItem = DfiesItem
      DfiesItem = FieldItem.DfiesItem
      LineRfcFieldAttributes.Add(GetRfcFieldAttribute(FieldItem.AbapName, DfiesItem, PrevDfiesItem, Offset, Offset2))
    Next

    PrevDfiesItem = DfiesItem
    GetRfcFieldAttribute(String.Empty, Nothing, PrevDfiesItem, Offset, Offset2)

    Dim LineRfcStructure = New RfcStructureAttribute
    LineRfcStructure.AbapName = "linestruct"
    LineRfcStructure.Length = Offset
    LineRfcStructure.Length2 = Offset2

    ' Ridefinisco il parametro PartitionSize in base alla dimensione del buffer
    If CLng(PartitionSize) * CLng(LineRfcStructure.Length2) > CLng(Buffer) * CLng(1000000) Then
      PartitionSize = CInt((Buffer) * CLng(1000000) / CLng(LineRfcStructure.Length2))
    End If

    ' Determino i parametri della struttura orderbystruct 
    Offset = 0
    Offset2 = 0
    PrevDfiesItem = Nothing
    DfiesItem = Nothing

    Dim SelectedRfcFieldAttributes = New List(Of RfcFieldAttribute)

    For Each FieldItem In FieldItems.AsEnumerable
      If Not FieldItem.TransferData Then
        Continue For
      End If
      PrevDfiesItem = DfiesItem
      DfiesItem = FieldItem.DfiesItem
      SelectedRfcFieldAttributes.Add(GetRfcFieldAttribute(FieldItem.AbapName, DfiesItem, PrevDfiesItem, Offset, Offset2))
    Next

    PrevDfiesItem = DfiesItem
    GetRfcFieldAttribute(String.Empty, Nothing, PrevDfiesItem, Offset, Offset2)

    ' Assegno l'elenco dei campi selezionati dall'utente all'oggetto Consumer
    Consumer.SelectedRfcFieldAttributes = SelectedRfcFieldAttributes

    ' Determino i parametri della struttura orderbystruct 
    Offset = 0
    Offset2 = 0
    PrevDfiesItem = Nothing
    DfiesItem = Nothing

    Dim OrderByRfcFieldAttributes = New List(Of RfcFieldAttribute)

    For Each FieldItem In FieldItems.AsEnumerable
      If FieldItem.OrderName = String.Empty Then
        Continue For
      End If
      PrevDfiesItem = DfiesItem
      DfiesItem = FieldItem.DfiesItem
      OrderByRfcFieldAttributes.Add(GetRfcFieldAttribute(FieldItem.AbapName, DfiesItem, PrevDfiesItem, Offset, Offset2))
    Next

    PrevDfiesItem = DfiesItem
    GetRfcFieldAttribute(String.Empty, Nothing, PrevDfiesItem, Offset, Offset2)

    Dim OrderByRfcStructure = New RfcStructureAttribute
    OrderByRfcStructure.AbapName = "orderbystruct"
    OrderByRfcStructure.Length = Offset
    OrderByRfcStructure.Length2 = Offset2

    ' Creo i dati per le chiamate
    Dim Parse_Tree_Step_1 = New ROS_PARSE_NODETable
    Dim Parse_Tree_Step_N = New ROS_PARSE_NODETable
    Dim Selected_Fields As ROS_FIELD_INFOTable
    Dim Orderby_Fields As ROS_FIELD_INFOTable

    FillParseTreeTable(GetParseTreeStep1(ParseTree, FieldItems, RebuildOrderClause), Parse_Tree_Step_1)
    FillParseTreeTable(GetParseTreeStepN(ParseTree, FieldItems, RebuildOrderClause), Parse_Tree_Step_N)
    Selected_Fields = FieldItems.GetSelectedFields
    Orderby_Fields = FieldItems.GetOrderByFields

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

    Dim TaskFactoryValue As New TaskFactory

    Dim CallbackServer1 = GetSAPProxyCallbackServer(
                                                    CallContext1.ContextGUID,
                                                    LineRfcStructure,
                                                    LineRfcFieldAttributes,
                                                    OrderByRfcStructure,
                                                    OrderByRfcFieldAttributes,
                                                    SelectedRfcFieldAttributes)
    If CallbackServer1 Is Nothing Then
      Exit Sub
    End If

    Dim CallbackServer2 = GetSAPProxyCallbackServer(
                                                    CallContext2.ContextGUID,
                                                    LineRfcStructure,
                                                    LineRfcFieldAttributes,
                                                    OrderByRfcStructure,
                                                    OrderByRfcFieldAttributes,
                                                    SelectedRfcFieldAttributes)
    If CallbackServer2 Is Nothing Then
      Exit Sub
    End If

    ' Creazione del task per la chiamata delle funzione RunSession
    RaiseQueryStatusChanged("Starting call to Z_REMOTE_OPEN_SQL ...")
    Consumer.BeginConsume()

    SessionTask1 = TaskFactoryValue.StartNew(Sub() Me.RunSession(CallbackServer1))
    SessionTask2 = TaskFactoryValue.StartNew(Sub() Me.RunSession(CallbackServer2))

    Try
      SessionTask1.Wait()
    Catch ex As Exception
      DisposeContexts(SAPCallContexts)
      ExceptionsAggregator.Add(ex)
    End Try
    Try
      SessionTask2.Wait()
    Catch ex As Exception
      DisposeContexts(SAPCallContexts)
      ExceptionsAggregator.Add(ex)
    End Try
    For Each EventTask In EventTasks
      Try
        EventTask.Wait()
      Catch ex As Exception
        ExceptionsAggregator.Add(ex)
      End Try
    Next

    DisposeContexts(SAPCallContexts)

    EventTasks.Clear()

    Try
      Consumer.EndConsume()
    Catch ex As Exception
      ExceptionsAggregator.Add(ex)
    End Try

    If ExceptionsAggregator.Count > 0 Then
      Throw New AggregateException(ExceptionsAggregator.ToArray)
    End If

    Dim ExcecutionSeconds = DateDiff(DateInterval.Second, CallStartTime, Now)
    If ExcecutionSeconds = 0 Then
      ExcecutionSeconds = 1
    End If

    Dim Rate = Format(CLng((CLng(Consumer.Records) * CLng(3600) / ExcecutionSeconds)), "#,0")

    RaiseQueryStatusChanged("Query Excecuted. Records: " & Consumer.RecordsWithThousandSeparator & ", Rate: " & Rate & " records/h.")
  End Sub

  Private Sub DisposeContexts(Contexts As Dictionary(Of String, CallContext))
    For Each Context In Contexts.Values
      Try
        Context.Dispose()
      Catch ex As Exception
        ExceptionsAggregator.Add(ex)
      End Try
    Next
    Contexts.Clear()
  End Sub

  Private Function IsEven(ByVal Number As Long) As Boolean
    IsEven = (Number Mod 2 = 0)
  End Function

  Private Function IsOdd(ByVal Number As Long) As Boolean
    IsOdd = (Number Mod 2 <> 0)
  End Function

  Private Function GetRfcFieldAttribute(AbapName As String, ByVal DfiesRow As DFIES, ByVal PrevDfiesRow As DFIES, ByRef Offset As Integer, ByRef Offset2 As Integer) As RfcFieldAttribute
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
        Result = New RfcFieldAttribute(AbapName, RFCTYPE.RFCTYPE_INT, DfiesRow.Intlen, DfiesRow.Intlen, 0, Offset, Offset2)
        Offset += DfiesRow.Intlen
        Offset2 += DfiesRow.Intlen
      Case RFCTYPE.RFCTYPE_INT1
        ' Tipo interno b, Tipo .NET Byte, campo di esempio T180S-COLOR
        Result = New RfcFieldAttribute(AbapName, RFCTYPE.RFCTYPE_INT1, DfiesRow.Intlen, DfiesRow.Intlen, 0, Offset, Offset2)
        Offset += DfiesRow.Intlen
        Offset2 += DfiesRow.Intlen
      Case RFCTYPE.RFCTYPE_INT2
        ' Tipo interno s, Tipo .NET Short, campo di esempio RLIB_TREES-CLUSTR
        Result = New RfcFieldAttribute(AbapName, RFCTYPE.RFCTYPE_INT2, DfiesRow.Intlen, DfiesRow.Intlen, 0, Offset, Offset2)
        Offset += DfiesRow.Intlen
        Offset2 += DfiesRow.Intlen
      Case RFCTYPE.RFCTYPE_DATE
        ' Tipo interno D, Tipo .NET String, campo di esempio MSTA-ERSDA
        Result = New RfcFieldAttribute(AbapName, RFCTYPE.RFCTYPE_DATE, DfiesRow.Leng, DfiesRow.Leng * 2, 0, Offset, Offset2)
        Offset += DfiesRow.Leng
        Offset2 += DfiesRow.Leng * 2
      Case RFCTYPE.RFCTYPE_FLOAT
        ' Tipo interno F, Tipo .NET Double, campo di esempio MARD-BSKRF
        Result = New RfcFieldAttribute(AbapName, RFCTYPE.RFCTYPE_FLOAT, DfiesRow.Intlen, DfiesRow.Intlen, 0, Offset, Offset2)
        Offset += DfiesRow.Intlen
        Offset2 += DfiesRow.Intlen
      Case RFCTYPE.RFCTYPE_TIME
        ' Tipo interno T, Tipo .NET String, campo di esempio MSEG-/BEV2/ED_AETIM
        Result = New RfcFieldAttribute(AbapName, RFCTYPE.RFCTYPE_TIME, DfiesRow.Leng, DfiesRow.Leng * 2, 0, Offset, Offset2)
        Offset += DfiesRow.Leng
        Offset2 += DfiesRow.Leng * 2
      Case RFCTYPE.RFCTYPE_CHAR
        ' Tipo interno C, Tipo .NET String, campo di esempio MSTA-AENAM
        Result = New RfcFieldAttribute(AbapName, RFCTYPE.RFCTYPE_CHAR, DfiesRow.Leng, DfiesRow.Leng * 2, 0, Offset, Offset2)
        Offset += DfiesRow.Leng
        Offset2 += DfiesRow.Leng * 2
      Case RFCTYPE.RFCTYPE_NUM
        ' Tipo interno N, Tipo .NET String, campo di esempio COEP-BELTP
        Result = New RfcFieldAttribute(AbapName, RFCTYPE.RFCTYPE_NUM, DfiesRow.Leng, DfiesRow.Leng * 2, 0, Offset, Offset2)
        Offset += DfiesRow.Leng
        Offset2 += DfiesRow.Leng * 2
      Case RFCTYPE.RFCTYPE_BCD
        ' Tipo interno P, Tipo .NET String, campo di esempio COEP-WTGBTR
        Result = New RfcFieldAttribute(AbapName, RFCTYPE.RFCTYPE_BCD, DfiesRow.Intlen, DfiesRow.Intlen, DfiesRow.Decimals, Offset, Offset2)
        Offset += DfiesRow.Intlen
        Offset2 += DfiesRow.Intlen
      Case RFCTYPE.RFCTYPE_BYTE
        ' Tipo interno X, Tipo .NET Byte(), campo di esempio TODIR-RELMAP
        Result = New RfcFieldAttribute(AbapName, RFCTYPE.RFCTYPE_BYTE, DfiesRow.Intlen, DfiesRow.Intlen, 0, Offset, Offset2)
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
      CallbackServer.Stop()
      Client.Connection.Close()
      Throw
    End Try
    CallbackServer.Stop()
    Client.Connection.Close()
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
