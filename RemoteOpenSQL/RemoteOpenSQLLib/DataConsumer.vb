Imports SAP.Connector
Imports System.Threading
Imports System.IO
Imports System.Text
Imports System.Reflection
Imports System.Globalization
Imports System.Threading.Tasks
Imports System.Runtime

Public MustInherit Class DataConsumer
  Protected RosRfcFieldAttributesValue As List(Of RfcFieldAttribute)
  Protected LengthArray() As Integer
  Protected ColumnsUBound As Integer
  Protected ColumnsUBoundMinus1 As Integer

  Public Property Records As Integer

  Public Sub New()
    MyBase.New()
  End Sub

  Friend Sub TryReleaseComObject(ByVal ComObject As Object)
    Try
      System.Runtime.InteropServices.Marshal.ReleaseComObject(ComObject)
    Catch
    Finally
      ComObject = Nothing
    End Try
  End Sub

  Public Property RosRfcFieldAttributes As List(Of RfcFieldAttribute)
    Get
      Return RosRfcFieldAttributesValue
    End Get
    Set(ByVal value As List(Of RfcFieldAttribute))
      RosRfcFieldAttributesValue = value

      ColumnsUBound = RosRfcFieldAttributesValue.Count - 1
      ColumnsUBoundMinus1 = ColumnsUBound - 1

      ReDim LengthArray(ColumnsUBound)
      For Count = 0 To ColumnsUBound

        'Dim Length = 0
        'Select Case RfcFieldsValue(Count).RfcType
        '  Case RFCTYPE.RFCTYPE_CHAR
        '    Length = RfcFieldsValue(Count).Length
        '  Case RFCTYPE.RFCTYPE_DATE
        '    Return "String"
        '  Case RFCTYPE.RFCTYPE_BCD
        '    Return "Decimal"
        '  Case RFCTYPE.RFCTYPE_TIME
        '    Return "String"
        '  Case RFCTYPE.RFCTYPE_BYTE
        '    Return "Byte()"
        '  Case RFCTYPE.RFCTYPE_NUM
        '    Return "String"
        '  Case RFCTYPE.RFCTYPE_FLOAT
        '    Return "Double"
        '  Case RFCTYPE.RFCTYPE_INT
        '    Return "Integer"
        '  Case RFCTYPE.RFCTYPE_INT2
        '    Return "Short"
        '  Case RFCTYPE.RFCTYPE_INT1
        '    Return "Byte"
        '  Case Else
        'End Select

        LengthArray(Count) = RosRfcFieldAttributesValue(Count).Length
      Next
    End Set
  End Property

  Public MustOverride Sub BeginConsume()
  Public MustOverride Sub Consume(ByVal Row As RosSAPStructure)
  Public MustOverride Sub EndConsume()
  Public MustOverride Sub ViewData()

End Class

'Public Class FixedLenghtTextFileConsumer
'  Inherits DataConsumer

'  Private FullPathValue As String
'  Private WriteHeaderValue As Boolean
'  Private TextStreamWriter As StreamWriter
'  Private RowsSeparatorValue As String = vbCrLf

'  Public Sub New(ByVal FullPath As String, Optional ByVal WriteHeader As Boolean = True, Optional ByVal RowsSeparator As String = vbCrLf)
'    MyBase.New()

'    FullPathValue = FullPath
'    WriteHeaderValue = WriteHeader
'    RowsSeparatorValue = RowsSeparator
'  End Sub

'  Public Property RowsSeparator As String
'    Get
'      Return RowsSeparatorValue
'    End Get
'    Set(ByVal value As String)
'      RowsSeparatorValue = value
'    End Set
'  End Property

'  Public Property FullPath As String
'    Get
'      Return FullPathValue
'    End Get
'    Set(ByVal value As String)
'      FullPathValue = value
'    End Set
'  End Property

'  Public Overrides Sub BeginConsume()

'    ' Todo: gestire l'eccezione se il file è bloccato
'    File.Delete(FullPathValue)

'    TextStreamWriter = New StreamWriter(FullPath, True, Encoding.Unicode)

'    If WriteHeaderValue Then
'      For Count = 0 To ColumnsUBound
'        TextStreamWriter.Write(Left(RfcFieldsValue(Count).AbapName.PadRight(LengthArray(Count)), LengthArray(Count)))
'      Next
'      TextStreamWriter.Write(RowsSeparatorValue)
'    End If
'  End Sub

'  Public Overrides Sub Consume(ByVal Row As RosSAPStructure)

'    'Dim Stopwatch = New Stopwatch
'    'Stopwatch.Start()

'    With TextStreamWriter
'      Dim ItemsArray = Row.GetItemsArray
'      For Index = 0 To ColumnsUBound
'        .Write(ItemsArray(Index).ToString.PadRight(LengthArray(Index)))
'      Next
'      .Write(RowsSeparatorValue)
'    End With

'    'Stopwatch.Stop()
'    'Console.WriteLine("Consume time: " & Stopwatch.ElapsedMilliseconds)

'  End Sub

'  Public Overrides Sub EndConsume()
'    TextStreamWriter.Close()
'  End Sub
'End Class

Public Class DelimitedTextFileConsumer
  Inherits DataConsumer

  Private PathNameValue As String = String.Empty
  Private FileNameValue As String = String.Empty
  Private WriteHeaderValue As Boolean
  Private FieldsSeparatorValue As String = vbTab
  Private RowsSeparatorValue As String = vbCrLf
  Private TextStreamWriter As StreamWriter
  Private ViewerPathValue As String

  Public Sub New(
                Optional ByVal PathName As String = "",
                Optional ByVal FileName As String = "",
                Optional ByVal WriteHeader As Boolean = True,
                Optional ByVal RowsSeparator As String = vbCrLf,
                Optional ByVal FieldsSeparator As String = vbTab)
    MyBase.New()

    If PathName = String.Empty Then
      PathNameValue = Path.GetTempPath
    Else
      PathNameValue = PathName
    End If

    FileNameValue = FileName
    WriteHeaderValue = WriteHeader
    RowsSeparatorValue = RowsSeparator
    FieldsSeparatorValue = FieldsSeparator
  End Sub

  Public Property ViewerPath As String
    Get
      Return ViewerPathValue
    End Get
    Set(ByVal value As String)
      ViewerPathValue = value
    End Set
  End Property

  Public Property FieldsSeparator As String
    Get
      Return FieldsSeparatorValue
    End Get
    Set(ByVal value As String)
      FieldsSeparatorValue = value
    End Set
  End Property

  Public Property RowsSeparator As String
    Get
      Return RowsSeparatorValue
    End Get
    Set(ByVal value As String)
      RowsSeparatorValue = value
    End Set
  End Property

  Public ReadOnly Property FullPath As String
    Get
      Return Path.Combine(PathNameValue, FileNameValue)
    End Get
  End Property

  Public Property FileName As String
    Get
      Return FileNameValue
    End Get
    Set(ByVal value As String)
      FileNameValue = value
    End Set
  End Property

  Public Property PathName As String
    Get
      Return PathNameValue
    End Get
    Set(ByVal value As String)
      PathNameValue = value
    End Set
  End Property

  Public Overrides Sub ViewData()
    If File.Exists(ViewerPath) Then
      Shell("""" & ViewerPath & """ """ & FullPath & """", AppWinStyle.NormalFocus)
    Else
      Process.Start("""" & FullPath & """")
    End If
  End Sub

  Public Overrides Sub BeginConsume()

    ' Todo: gestire l'eccezione se il file è bloccato
    File.Delete(FullPath)

    TextStreamWriter = New StreamWriter(FullPath, True, Encoding.Unicode)

    If WriteHeaderValue Then
      For Count = 0 To ColumnsUBoundMinus1
        TextStreamWriter.Write(RosRfcFieldAttributesValue(Count).AbapName)
        TextStreamWriter.Write(FieldsSeparatorValue)
      Next
      TextStreamWriter.Write(RosRfcFieldAttributesValue(ColumnsUBound).AbapName)
      TextStreamWriter.Write(RowsSeparatorValue)
    End If

  End Sub

  Public Overrides Sub Consume(ByVal Row As RosSAPStructure)

    'Dim Stopwatch = New Stopwatch
    'Stopwatch.Start()
    'Stopwatch.Stop()
    'Console.WriteLine("Consume time: " & Stopwatch.ElapsedMilliseconds)

    Row.WriteToStreamWriter(TextStreamWriter, FieldsSeparatorValue)
    TextStreamWriter.Write(RowsSeparatorValue)
    Records += 1
  End Sub

  Public Overrides Sub EndConsume()
    TextStreamWriter.Close()
  End Sub
End Class

Public Class MicrosoftAccessConsumer
  Inherits DataConsumer

  Private DatabaseFullPathValue As String
  Private RowsSeparatorValue As String = vbCrLf
  Private FieldsSeparatorValue As String = vbTab
  Private TextDelimiterValue As String = "none"
  Private TableNameValue As String
  Private TextStreamWriter As StreamWriter
  Private AccessApp As Object
  Private SessionGUID As String
  Private TempTextFileGUID As String
  Private RowsCount As Integer
  Private MaxRowsCount = 1000
  Private AccessTaskFactoryValue As New TaskFactory
  Private AccessTask As Task = Nothing
  Private SessionTempFolder As String

  Public Sub New(
                ByVal DatabaseFullPath As String,
                Optional ByVal TableName As String = "",
                Optional ByVal RowsSeparator As String = vbCrLf,
                Optional ByVal FieldsSeparator As String = vbTab,
                Optional ByVal TextDelimiter As String = "none")
    MyBase.New()

    DatabaseFullPathValue = DatabaseFullPath
    RowsSeparatorValue = RowsSeparator
    If FieldsSeparator.Length = 1 Then
      FieldsSeparatorValue = FieldsSeparator
    End If
    If TextDelimiter.Length = 1 Then
      TextDelimiterValue = TextDelimiter
    End If
    TableNameValue = TableName
  End Sub

  Public Property TableName As String
    Get
      Return TableNameValue
    End Get
    Set(ByVal value As String)
      TableNameValue = value
    End Set
  End Property

  Public Property FieldsSeparator As String
    Get
      Return FieldsSeparatorValue
    End Get
    Set(ByVal value As String)
      FieldsSeparatorValue = value
    End Set
  End Property

  Public Property RowsSeparator As String
    Get
      Return RowsSeparatorValue
    End Get
    Set(ByVal value As String)
      RowsSeparatorValue = value
    End Set
  End Property

  Public Property DatabaseFullPath As String
    Get
      Return DatabaseFullPathValue
    End Get
    Set(ByVal value As String)
      DatabaseFullPathValue = value
    End Set
  End Property

  Public Property TextDelimiter As String
    Get
      Return TextDelimiterValue
    End Get
    Set(ByVal value As String)
      TextDelimiterValue = value
    End Set
  End Property

  Public Overrides Sub ViewData()
    Process.Start("""" & DatabaseFullPath & """")
  End Sub

  Public Overrides Sub BeginConsume()

    ' Todo: gestire l'eccezione se il file è bloccato

    If Not File.Exists(DatabaseFullPathValue) Then
      ' Todo: generare un'eccezione
      Exit Sub
    End If

    AccessApp = GetObject(DatabaseFullPathValue)

    If AccessApp Is Nothing Then
      ' Todo: generare un'eccezione
      Exit Sub
    End If

    SessionGUID = Guid.NewGuid.ToString
    SessionTempFolder = Directory.CreateDirectory(Path.Combine(Path.GetTempPath, "RemoteOpenSQL", SessionGUID)).FullName

    TempTextFileGUID = Guid.NewGuid.ToString

    Dim TableToDrop As Object = Nothing

    Try
      TableToDrop = AccessApp.CurrentDb.TableDefs(TableNameValue)
    Catch ex As System.Runtime.InteropServices.COMException
    End Try

    If Not TableToDrop Is Nothing Then
      Try
        AccessApp.CurrentDb.Execute("DROP TABLE " & TableNameValue, 128)
      Catch ex As System.Runtime.InteropServices.COMException
        ' Impossibile cancellare la tabella
        ' Todo: generare un'eccezione
        Throw
      End Try
    End If

    Dim CreateTableQuery = New StringBuilder
    With CreateTableQuery
      .Append("CREATE TABLE " & TableNameValue & " ( ")
      For Count = 0 To ColumnsUBoundMinus1
        .Append("[" & RosRfcFieldAttributesValue(Count).AbapName & "] " & GetJetType(RosRfcFieldAttributesValue(Count)) & ",")
      Next
      .Append("[" & RosRfcFieldAttributesValue(ColumnsUBound).AbapName & "] " & GetJetType(RosRfcFieldAttributesValue(ColumnsUBound)))
      .Append(" ) ")
      Try
        AccessApp.CurrentDb.Execute(.ToString)
      Catch ex As System.Runtime.InteropServices.COMException
        ' Impossibile creare la tabella
        Throw
      End Try
    End With

    TextStreamWriter = New StreamWriter(Path.Combine(SessionTempFolder, TempTextFileGUID & ".txt"), True, Encoding.Unicode)
  End Sub

  Private Sub WriteSchemaIni(ByVal AccessTempTextFileGUID As String)
    Dim SchemaBody = New StringBuilder

    With SchemaBody
      .AppendLine("[" & AccessTempTextFileGUID & ".txt]")
      .AppendLine("ColNameHeader = False")

      Select Case FieldsSeparatorValue
        Case vbTab
          .AppendLine("Format = TabDelimited")
        Case CultureInfo.CurrentCulture.TextInfo.ListSeparator
          .AppendLine("Format = CSVDelimited")
        Case Else
          .AppendLine("Format = Delimited(" & FieldsSeparatorValue & ")")
      End Select

      .AppendLine("CharacterSet = UNICODE")
      If TextDelimiterValue = "none" Then
        .AppendLine("TextDelimiter = ""none""")
      Else
        .AppendLine("TextDelimiter = " & TextDelimiterValue)
      End If

      For Count = 0 To ColumnsUBound
        .AppendLine("Col" & (Count + 1).ToString & " = " & RosRfcFieldAttributesValue(Count).AbapName & " " & GetSchemaFieldType(RosRfcFieldAttributesValue(Count)))
      Next
    End With

    File.WriteAllText(Path.Combine(SessionTempFolder, "Schema.ini"), SchemaBody.ToString)
  End Sub

  Private Function GetSchemaFieldType(ByVal RfcFieldAttribute As RfcFieldAttribute) As String
    Select Case RfcFieldAttribute.RfcType
      Case RFCTYPE.RFCTYPE_INT
        Return "Long"
      Case RFCTYPE.RFCTYPE_INT1
        Return "Byte"
      Case RFCTYPE.RFCTYPE_INT2
        Return "Short"
      Case RFCTYPE.RFCTYPE_DATE
        Return "Text Width 8"
      Case RFCTYPE.RFCTYPE_FLOAT
        Return "Double"
      Case RFCTYPE.RFCTYPE_TIME
        Return "Text Width 6"
      Case RFCTYPE.RFCTYPE_CHAR
        If RfcFieldAttribute.Length <= 255 Then
          Return "Text Width " & RfcFieldAttribute.Length
        Else
          Return "Memo"
        End If
      Case RFCTYPE.RFCTYPE_NUM
        If RfcFieldAttribute.Length <= 255 Then
          Return "Text Width " & RfcFieldAttribute.Length
        Else
          Return "Memo"
        End If
      Case RFCTYPE.RFCTYPE_BCD
        ' p = ((m+1)/2) => m = p * 2 - 1 + sign + decimal separator
        Return "Text Width " & ((RfcFieldAttribute.Length * 2 - 1) + 1 + 1)
      Case RFCTYPE.RFCTYPE_BYTE
        If RfcFieldAttribute.Length * 2 <= 255 Then
          Return "Text Width " & RfcFieldAttribute.Length * 2
        Else
          Return "Memo"
        End If
      Case Else
        Return Nothing
    End Select
  End Function

  Private Function GetJetType(ByVal RfcFieldAttribute As RfcFieldAttribute) As String
    Select Case RfcFieldAttribute.RfcType
      Case RFCTYPE.RFCTYPE_INT
        Return "INTEGER"
      Case RFCTYPE.RFCTYPE_INT1
        Return "TINYINT"
      Case RFCTYPE.RFCTYPE_INT2
        Return "SMALLINT"
      Case RFCTYPE.RFCTYPE_DATE
        Return "TEXT(8)"
      Case RFCTYPE.RFCTYPE_FLOAT
        Return "FLOAT"
      Case RFCTYPE.RFCTYPE_TIME
        Return "TEXT(6)"
      Case RFCTYPE.RFCTYPE_CHAR
        If RfcFieldAttribute.Length <= 255 Then
          Return "TEXT(" & RfcFieldAttribute.Length & ")"
        Else
          Return "MEMO"
        End If
      Case RFCTYPE.RFCTYPE_NUM
        If RfcFieldAttribute.Length <= 255 Then
          Return "TEXT(" & RfcFieldAttribute.Length & ")"
        Else
          Return "MEMO"
        End If
      Case RFCTYPE.RFCTYPE_BCD
        ' p = ((m+1)/2) => m = p * 2 - 1 + sign + decimal separator
        Return "TEXT(" & ((RfcFieldAttribute.Length * 2 - 1) + 1 + 1) & ")"
      Case RFCTYPE.RFCTYPE_BYTE
        If RfcFieldAttribute.Length * 2 <= 255 Then
          Return "TEXT(" & RfcFieldAttribute.Length * 2 & ")"
        Else
          Return "MEMO"
        End If
      Case Else
        Return Nothing
    End Select
  End Function

  Public Overrides Sub Consume(ByVal Row As RosSAPStructure)

    'Dim Stopwatch = New Stopwatch
    'Stopwatch.Start()
    'Stopwatch.Stop()
    'Console.WriteLine("Consume time: " & Stopwatch.ElapsedMilliseconds)

    Row.WriteToStreamWriter(TextStreamWriter, FieldsSeparatorValue)
    TextStreamWriter.Write(RowsSeparatorValue)

    RowsCount += 1

    If RowsCount >= MaxRowsCount Then
      CloseStreamAndStartSendDataToAccess(False, True)
    End If

    Records += 1
  End Sub

  Private Sub SendDataToAccess(ByVal AccessTempTextFileGUID As String)
    WriteSchemaIni(AccessTempTextFileGUID)

    Try
      'ErrorCode = -2146825239
      'HelpLink=jeterr40.chm#5003049
      'Message=Impossibile aprire il database 'INSERT INTO AUSP SELECT * FROM [Text;HDR=NO;DATABASE=C:\Users\<user>\AppData\Local\Temp\RemoteOpenSQL\98a8ad96-9493-4060-ac04-0fb7cfdf13eb\].[04250005-cb65-4f6e-af7d-0ee7bf52429a.txt]'. È possibile che il database non sia riconoscibile per l'applicazione oppure che il file sia danneggiato.
      'Si verifica quando il file raggiunge i 2 GB
      AccessApp.CurrentDb.Execute("INSERT INTO " & TableNameValue & " SELECT * FROM [Text;HDR=NO;DATABASE=" & SessionTempFolder & "\].[" & AccessTempTextFileGUID & ".txt]")
    Catch ex As InteropServices.COMException
      Throw
    End Try
    File.Delete(Path.Combine(SessionTempFolder, "Schema.ini"))
    File.Delete(Path.Combine(SessionTempFolder, AccessTempTextFileGUID & ".txt"))
  End Sub

  Private Sub CloseStreamAndStartSendDataToAccess(ByVal Wait As Boolean, ByVal OpenNewStream As Boolean)
    TextStreamWriter.Close()
    If Not AccessTask Is Nothing Then
      AccessTask.Wait()
    End If
    Dim AccessTempTextFileGUID = String.Copy(TempTextFileGUID)
    AccessTask = AccessTaskFactoryValue.StartNew(Sub() Me.SendDataToAccess(AccessTempTextFileGUID))
    If Wait Then
      AccessTask.Wait()
    End If
    If OpenNewStream Then
      TempTextFileGUID = Guid.NewGuid.ToString
      TextStreamWriter = New StreamWriter(Path.Combine(SessionTempFolder, TempTextFileGUID & ".txt"), True, Encoding.Unicode)
    End If
    RowsCount = 0
  End Sub

  Public Overrides Sub EndConsume()
    CloseStreamAndStartSendDataToAccess(True, False)
    If Not AccessApp Is Nothing Then
      AccessApp.Quit(2)
    End If
  End Sub
End Class

Public Class MicrosoftExcelConsumer
  Inherits DelimitedTextFileConsumer

  Private ExcelFileNameValue As String

  Public Sub New(
              Optional ByVal PathName As String = "",
              Optional ByVal ExcelFileName As String = "")
    MyBase.New(PathName)

    ExcelFileNameValue = ExcelFileName
    If ExcelFileNameValue <> String.Empty Then
      FileName = Path.GetFileNameWithoutExtension(ExcelFileNameValue) & ".txt"
    End If
  End Sub

  Public Overloads Property ExcelFileName As String
    Get
      Return ExcelFileNameValue
    End Get
    Set(ByVal value As String)
      ExcelFileNameValue = value
      MyBase.FileName = Path.GetFileNameWithoutExtension(value) & ".txt"
    End Set
  End Property

  Public Overloads ReadOnly Property ExcelFullPath As String
    Get
      Return Path.Combine(PathName, ExcelFileNameValue)
    End Get
  End Property

  Public Overrides Sub ViewData()
    Process.Start("""" & ExcelFullPath & """")
  End Sub

  Public Overrides Sub EndConsume()
    MyBase.EndConsume()

    'Create a new instance of Excel
    Dim ExcelApplication As Object
    Dim Workbooks As Object
    Dim ActiveWorkbook As Object

    ExcelApplication = CreateObject("Excel.Application")
    Workbooks = ExcelApplication.Workbooks

    'Open the text file
    Workbooks.OpenText(FullPath, FieldInfo:=GetFieldInfo)
    TryReleaseComObject(Workbooks)

    ActiveWorkbook = ExcelApplication.ActiveWorkbook

    'Save as Excel workbook and Quit Excel
    Const xlWorkbookDefault = 51

    Try
      ActiveWorkbook.SaveAs(ExcelFullPath, xlWorkbookDefault)
    Catch ex As System.Runtime.InteropServices.COMException
      ActiveWorkbook.Close(False)
      TryReleaseComObject(ActiveWorkbook)

      ExcelApplication.Quit()
      TryReleaseComObject(ExcelApplication)

      GC.Collect()
      GC.WaitForPendingFinalizers()

      File.Delete(MyBase.FullPath)
      Throw
    End Try

    ActiveWorkbook.Close(False)
    TryReleaseComObject(ActiveWorkbook)

    ExcelApplication.Quit()
    TryReleaseComObject(ExcelApplication)

    GC.Collect()
    GC.WaitForPendingFinalizers()

    File.Delete(MyBase.FullPath)
  End Sub

  Private Function GetFieldInfo() As Object(,)
    Dim Result As Object(,)
    ReDim Result(ColumnsUBound, 1)
    For Count = 0 To ColumnsUBound
      Result(Count, 0) = Count + 1
      Result(Count, 1) = GetXlColumnDataType(RosRfcFieldAttributesValue(Count))
    Next
    Return Result
  End Function

  Private Function GetXlColumnDataType(ByVal RfcFieldAttribute As RfcFieldAttribute) As Integer

    Const xlGeneralFormat = 1
    Const xlTextFormat = 2

    Select Case RfcFieldAttribute.RfcType
      Case RFCTYPE.RFCTYPE_DATE, RFCTYPE.RFCTYPE_TIME, RFCTYPE.RFCTYPE_CHAR, RFCTYPE.RFCTYPE_BYTE
        Return xlTextFormat
      Case RFCTYPE.RFCTYPE_FLOAT, RFCTYPE.RFCTYPE_NUM, RFCTYPE.RFCTYPE_BCD
        Return xlGeneralFormat
      Case Else
        Return Nothing
    End Select
  End Function
End Class