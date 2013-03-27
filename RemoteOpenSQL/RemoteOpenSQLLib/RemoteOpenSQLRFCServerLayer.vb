Imports SAP.Connector
Imports System.Text
Imports RemoteOpenSQL.SapNetConnector2Proxy2010

Partial Public Class RemoteOpenSQL

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
      ByVal SelectedRfcFields As List(Of RfcFieldAttribute)) As SAPServer

    Dim SourceCode = New StringBuilder()
    Dim MixedAbapName = MixedCase(LineRfcStructure.AbapName, "_")
    Dim UniqueIdentifier = "_" & Replace(Replace(Replace(ContextGUID, "-", ""), "{", ""), "}", "")

    ' Sezione Imports
    SourceCode.AppendLine("Imports Microsoft.VisualBasic.Interaction")
    SourceCode.AppendLine("Imports SAP.Connector")
    SourceCode.AppendLine("Imports System")
    SourceCode.AppendLine("Imports System.Collections")
    SourceCode.AppendLine("Imports System.Collections.Generic")
    SourceCode.AppendLine("Imports System.ComponentModel")
    SourceCode.AppendLine("Imports System.Diagnostics")
    SourceCode.AppendLine("Imports System.IO")
    SourceCode.AppendLine("Imports System.Runtime.InteropServices")
    SourceCode.AppendLine("Imports System.Text")
    SourceCode.AppendLine("Imports System.Web.Services")
    SourceCode.AppendLine("Imports System.Web.Services.Description")
    SourceCode.AppendLine("Imports System.Web.Services.Protocols")
    SourceCode.AppendLine("Imports System.Xml.Schema")
    SourceCode.AppendLine("Imports System.Xml.Serialization")
    SourceCode.AppendLine("")
    SourceCode.AppendLine("Imports RemoteOpenSQL.SapNetConnector2Proxy2010")
    SourceCode.AppendLine("Imports RemoteOpenSQL.RemoteOpenSQLLib")
    SourceCode.AppendLine("")

    ' Sezione per la definizione delle strutture

    ' Struttura linestruct
    AddSapStructureCode(UniqueIdentifier, SourceCode, LineRfcStructure, LineRfcFields, SelectedRfcFields)
    ' Struttura orderbystruct
    AddSapStructureCode(UniqueIdentifier, SourceCode, OrderByRfcStructure, OrderByRfcFields)

    ' Sezione per la definizione delle tabelle

    ' Tabella linestruct
    AddConsumerSapTableCode(UniqueIdentifier, ContextGUID, SourceCode, LineRfcStructure.AbapName)
    ' Tabella orderby
    ' AddSapTableCode(SourceCode, OrderByRfcStructure.AbapName)


    With SourceCode
      ' Sezione Classe SAPCS : Sap Callback Server

      .AppendLine("  Public Class SapCallbackServer" & UniqueIdentifier)
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
      .AppendLine("        ByRef Cancel As String)")
      .AppendLine("")
      .AppendLine("      Try")
      .AppendLine("        If RemoteOpenSQL.RemoteOpenSQLLib.RemoteOpenSQL.Items(""" & GUID & """).IsCancellationRequested Then")
      .AppendLine("          Cancel = ""X""")
      .AppendLine("          Exit Sub")
      .AppendLine("        End If")
      .AppendLine("")
      .AppendLine("        RemoteOpenSQL.RemoteOpenSQLLib.RemoteOpenSQL.Items(""" & GUID & """).SendCallContext(")
      .AppendLine("                                                             """ & GUID & """,")
      .AppendLine("                                                             """ & ContextGUID & """, ")
      .AppendLine("                                                             Abap_Code_Version, ")
      .AppendLine("                                                             Context_Index, ")
      .AppendLine("                                                             Max_Rows, ")
      .AppendLine("                                                             Partition_Size, ")
      .AppendLine("                                                             Parse_Nodes_Step_1, ")
      .AppendLine("                                                             Parse_Nodes_Step_N, ")
      .AppendLine("                                                             Selected_Fields, ")
      .AppendLine("                                                             Orderby_Fields)")
      .AppendLine("      Catch ex As Exception")
      .AppendLine("        Cancel = ""X""")
      .AppendLine("      End Try")
      .AppendLine("")
      .AppendLine("    End Sub")
      .AppendLine("")

      ' Sezione per la definizione della funzione remota del server RECEIVE_NEXT_ROW

      .AppendLine("      <RfcMethod(AbapName:=""RECEIVE_NEXT_ROW"")> _")
      .AppendLine("    Protected Sub RECEIVE_NEXT_ROW( _")
      .AppendLine("          <RfcParameter(AbapName:=""NEXT_ROW"", RFCTYPE:=RFCTYPE.RFCTYPE_STRUCTURE, Optional:=False, Direction:=RFCINOUT.IN, Length:=" & OrderByRfcStructure.Length & ", Length2:=" & OrderByRfcStructure.Length2 & "), _")
      .AppendLine("          XmlElement(""NEXT_ROW"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByVal Next_Row As " & OrderByRfcStructure.AbapName & UniqueIdentifier & ", _")
      .AppendLine("          <RfcParameter(AbapName:=""CANCEL"", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Optional:=False, Direction:=RFCINOUT.OUT, Length:=1, Length2:=2), _")
      .AppendLine("          XmlElement(""CANCEL"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Cancel As String)")
      .AppendLine("")
      .AppendLine("      Try")
      .AppendLine("        If RemoteOpenSQL.RemoteOpenSQLLib.RemoteOpenSQL.Items(""" & GUID & """).IsCancellationRequested Then")
      .AppendLine("          Cancel = ""X""")
      .AppendLine("          Exit Sub")
      .AppendLine("        End If")
      .AppendLine("")
      .AppendLine("        RemoteOpenSQL.RemoteOpenSQLLib.RemoteOpenSQL.Items(""" & GUID & """).ReceiveNextRow(")
      .AppendLine("                                                              """ & GUID & """,")
      .AppendLine("                                                             """ & ContextGUID & """, ")
      .AppendLine("                                                             Next_Row,")
      .AppendLine("                                                             Cancel)")
      .AppendLine("      Catch ex As Exception")
      .AppendLine("        Cancel = ""X""")
      .AppendLine("      End Try")
      .AppendLine("")
      .AppendLine("    End Sub")
      .AppendLine("")

      ' Sezione per la definizione della funzione remota del server SEND_NEXT_ROW

      .AppendLine("      <RfcMethod(AbapName:=""SEND_NEXT_ROW"")> _")
      .AppendLine("    Protected Sub SEND_NEXT_ROW( _")
      .AppendLine("          <RfcParameter(AbapName:=""NEXT_ROW"", RFCTYPE:=RFCTYPE.RFCTYPE_STRUCTURE, Optional:=False, Direction:=RFCINOUT.OUT, Length:=" & OrderByRfcStructure.Length & ", Length2:=" & OrderByRfcStructure.Length2 & "), _")
      .AppendLine("          XmlElement(""NEXT_ROW"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef next_row As " & OrderByRfcStructure.AbapName & UniqueIdentifier & ", _")
      .AppendLine("          <RfcParameter(AbapName:=""CANCEL"", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Optional:=False, Direction:=RFCINOUT.OUT, Length:=1, Length2:=2), _")
      .AppendLine("          XmlElement(""CANCEL"", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _")
      .AppendLine("        ByRef Cancel As String)")
      .AppendLine("")
      .AppendLine("      Try")
      .AppendLine("        If RemoteOpenSQL.RemoteOpenSQLLib.RemoteOpenSQL.Items(""" & GUID & """).IsCancellationRequested Then")
      .AppendLine("          Cancel = ""X""")
      .AppendLine("          Exit Sub")
      .AppendLine("        End If")
      .AppendLine("")
      .AppendLine("        Dim NextRow As SapStructure = Nothing")
      .AppendLine("        RemoteOpenSQL.RemoteOpenSQLLib.RemoteOpenSQL.Items(""" & GUID & """).SendNextRow(")
      .AppendLine("                                                          """ & GUID & """,")
      .AppendLine("                                                          """ & ContextGUID & """,")
      .AppendLine("                                                          NextRow,")
      .AppendLine("                                                          Cancel)")
      .AppendLine("        next_row = New " & OrderByRfcStructure.AbapName & UniqueIdentifier)
      .AppendLine("")
      .AppendLine("        If Cancel <> ""X"" AndAlso Not NextRow Is Nothing Then")
      .AppendLine("          For ItemIndex As Integer = 0 To SapStructure.GetSAPFieldsSchema(NextRow.GetType()).Length - 1")
      .AppendLine("            next_row.Item(ItemIndex) = NextRow.Item(ItemIndex)")
      .AppendLine("          Next")
      .AppendLine("        End If")
      .AppendLine("")
      .AppendLine("      Catch ex As Exception")
      .AppendLine("        Cancel = ""X""")
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
      .AppendLine("        ByRef Rows As " & LineRfcStructure.AbapName & "Table" & UniqueIdentifier & ")")
      .AppendLine("")
      .AppendLine("      Try")
      .AppendLine("")
      .AppendLine("        Rows.SetReceiveRowsAllowed(False)")
      .AppendLine("")
      .AppendLine("        RemoteOpenSQL.RemoteOpenSQLLib.RemoteOpenSQL.Items(""" & GUID & """).EndToReceiveRows(")
      .AppendLine("                                                              """ & GUID & """,")
      .AppendLine("                                                               """ & ContextGUID & """,")
      .AppendLine("                                                               SelectLenghtC,")
      .AppendLine("                                                               CompleteAdding,")
      .AppendLine("                                                               SelectError,")
      .AppendLine("                                                               Message,")
      .AppendLine("                                                               Cancel)")
      .AppendLine("")
      .AppendLine("      Catch ex As Exception")
      .AppendLine("        Cancel = ""X""")
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
      .AppendLine("        RemoteOpenSQL.RemoteOpenSQLLib.RemoteOpenSQL.Items(""" & GUID & """).ReceiveMessage(")
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
      If TypeItem.Name = "SapCallbackServer" & UniqueIdentifier Then
        Return Activator.CreateInstance(TypeItem)
      End If
    Next

    Return Nothing
  End Function

  Private Sub AddSapStructureCode(
                             ByVal UniqueIdentifier As String,
                             ByVal SourceCode As StringBuilder,
                             ByVal RfcStructureAttribute As RfcStructureAttribute,
                             ByVal RfcFieldAttributes As List(Of RfcFieldAttribute),
                             Optional ByVal SelectedRfcFieldsAttributes As List(Of RfcFieldAttribute) = Nothing)

    With SourceCode
      .AppendLine("  <Serializable, RfcStructure(AbapName :=""" & RfcStructureAttribute.AbapName & """  , Length := " & RfcStructureAttribute.Length & ", Length2 := " & RfcStructureAttribute.Length2 & ")> _")
      .AppendLine("  Public Class " & RfcStructureAttribute.AbapName & UniqueIdentifier & " ")
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

      If SelectedRfcFieldsAttributes Is Nothing Then
        EnabledRfcFieldAttributes = RfcFieldAttributes
      Else
        EnabledRfcFieldAttributes = SelectedRfcFieldsAttributes
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

  Private Sub AddSapTableCode(UniqueIdentifier As String, ByVal SourceCode As StringBuilder, ByVal AbapName As String)

    With SourceCode
      .AppendLine("  <Serializable> _")
      .AppendLine("  Public Class " & AbapName & "Table" & UniqueIdentifier)
      .AppendLine("    Inherits SAPTable")
      .AppendLine("")
      .AppendLine("    Public Overloads Overrides Function GetElementType() As Type")
      .AppendLine("        Return GetType(" & AbapName & UniqueIdentifier & ")")
      .AppendLine("    End Function")
      .AppendLine("")
      .AppendLine("    Overrides Public Function CreateNewRow() As Object ")
      .AppendLine("        Return new " & AbapName & "()")
      .AppendLine("    End Function")
      .AppendLine("     ")
      .AppendLine("    Default Public Property Item(ByVal Index As Integer) As " & AbapName & UniqueIdentifier)
      .AppendLine("        Get ")
      .AppendLine("            Return CType(List(Index), " & AbapName & UniqueIdentifier & ")")
      .AppendLine("        End Get")
      .AppendLine("        Set(ByVal Value As " & AbapName & UniqueIdentifier & ")")
      .AppendLine("            List(Index) = Value")
      .AppendLine("        End Set")
      .AppendLine("    End Property")
      .AppendLine("        ")
      .AppendLine("    Public Function Add(ByVal Value As " & AbapName & UniqueIdentifier & ") As Integer ")
      .AppendLine("        Return List.Add(Value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Sub Insert(ByVal Index As Integer, ByVal Value As " & AbapName & UniqueIdentifier & ") ")
      .AppendLine("        List.Insert(Index, value)")
      .AppendLine("    End Sub")
      .AppendLine("        ")
      .AppendLine("    Public Function IndexOf(ByVal Value As " & AbapName & UniqueIdentifier & ") As Integer")
      .AppendLine("        Return List.IndexOf(value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Function Contains(ByVal Value As " & AbapName & UniqueIdentifier & ") As Boolean")
      .AppendLine("        Return List.Contains(value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Sub Remove(ByVal Value As " & AbapName & UniqueIdentifier & ") ")
      .AppendLine("        List.Remove(value)")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Sub CopyTo(ByVal Array() As " & AbapName & UniqueIdentifier & ", ByVal Index As Integer) ")
      .AppendLine("        List.CopyTo(array, index)")
      .AppendLine("    End Sub")
      .AppendLine("  End Class")
      .AppendLine("")
    End With

  End Sub

  Private Sub AddConsumerSapTableCode(
                                     ByVal UniqueIdentifier As String,
                                     ByVal ContextGUID As String,
                                     ByVal SourceCode As StringBuilder,
                                     ByVal AbapName As String)

    With SourceCode
      .AppendLine("  <Serializable> _")
      .AppendLine("  Public Class " & AbapName & "Table" & UniqueIdentifier)
      .AppendLine("    Inherits SAPTable")
      .AppendLine("    Implements IList")
      .AppendLine("")
      .AppendLine("    Private Consumer As DataConsumer")
      .AppendLine("    Private ReceiveRowsAllowed As Boolean")
      .AppendLine("")
      .AppendLine("    Public Sub New()")
      .AppendLine("      Consumer = RemoteOpenSQL.RemoteOpenSQLLib.RemoteOpenSQL.Items(""" & GUID & """).GetConsumer()")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Friend Sub SetReceiveRowsAllowed(value As Boolean)")
      .AppendLine("      ReceiveRowsAllowed = value")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Function Add(ByVal Value As Object) As Integer Implements IList.Add")
      .AppendLine("      If Not ReceiveRowsAllowed Then")
      .AppendLine("        RemoteOpenSQL.RemoteOpenSQLLib.RemoteOpenSQL.Items(""" & GUID & """).WaitForReceiveRows(")
      .AppendLine("          """ & GUID & """,")
      .AppendLine("          """ & ContextGUID & """)")
      .AppendLine("        ReceiveRowsAllowed = True")
      .AppendLine("      End If")
      .AppendLine("      Consumer.Consume(CType(Value, RosSAPStructure))")
      .AppendLine("      Return 0")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Overloads Overrides Function GetElementType() As Type")
      .AppendLine("        Return GetType(" & AbapName & UniqueIdentifier & ")")
      .AppendLine("    End Function")
      .AppendLine("")
      .AppendLine("    Overrides Public Function CreateNewRow() As Object ")
      .AppendLine("        Return new " & AbapName & UniqueIdentifier & "()")
      .AppendLine("    End Function")
      .AppendLine("     ")
      .AppendLine("    Default Public Property Item(ByVal Index As Integer) As " & AbapName & UniqueIdentifier)
      .AppendLine("        Get ")
      .AppendLine("            Return CType(List(Index), " & AbapName & UniqueIdentifier & ")")
      .AppendLine("        End Get")
      .AppendLine("        Set(ByVal Value As " & AbapName & UniqueIdentifier & ")")
      .AppendLine("            List(Index) = Value")
      .AppendLine("        End Set")
      .AppendLine("    End Property")
      .AppendLine("        ")
      .AppendLine("    Public Function Add(ByVal Value As " & AbapName & UniqueIdentifier & ") As Integer ")
      .AppendLine("        Return List.Add(Value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Sub Insert(ByVal Index As Integer, ByVal Value As " & AbapName & UniqueIdentifier & ") ")
      .AppendLine("        List.Insert(Index, value)")
      .AppendLine("    End Sub")
      .AppendLine("        ")
      .AppendLine("    Public Function IndexOf(ByVal Value As " & AbapName & UniqueIdentifier & ") As Integer")
      .AppendLine("        Return List.IndexOf(value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Function Contains(ByVal Value As " & AbapName & UniqueIdentifier & ") As Boolean")
      .AppendLine("        Return List.Contains(value)")
      .AppendLine("    End Function")
      .AppendLine("        ")
      .AppendLine("    Public Sub Remove(ByVal Value As " & AbapName & UniqueIdentifier & ") ")
      .AppendLine("        List.Remove(value)")
      .AppendLine("    End Sub")
      .AppendLine("")
      .AppendLine("    Public Sub CopyTo(ByVal Array() As " & AbapName & UniqueIdentifier & ", ByVal Index As Integer) ")
      .AppendLine("        List.CopyTo(array, index)")
      .AppendLine("    End Sub")
      .AppendLine("  End Class")
      .AppendLine("")
    End With
  End Sub

  Public Sub SendCallContext(
                            ByVal GUID As String,
                            ByVal ContextGUID As String,
                            ByRef Abap_Code_Version As String,
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
      If Abap_Code_Version <> SupportedAbapCodeVersion Then
        Throw New CompileException("Function module Z_REMOTE_OPEN_SQL has version " & Abap_Code_Version & " RemoteOpenSQLManager support version " & SupportedAbapCodeVersion)
      End If

      With SAPCallContexts(ContextGUID)
        ContextIndex = .ContextIndex
        MaxRows = .MaxRows
        PartitionSize = .PartitionSize
        Parse_Tree_Step_1.FromADODataTable(.Parse_Tree_Step_1.ToADODataTable)
        Parse_Tree_Step_N.FromADODataTable(.Parse_Tree_Step_N.ToADODataTable)
        Selected_Fields.FromADODataTable(.Selected_Fields.ToADODataTable)
        Orderby_Fields.FromADODataTable(.Orderby_Fields.ToADODataTable)
      End With
    Catch ex As Exception
      ExceptionsAggregator.Add(ex)
      Throw
    End Try
  End Sub


  Public Sub WaitForReceiveRows(
                          ByVal GUID As String,
                          ByVal ContextGUID As String)

    If GUID <> GUIDValue Then
      Exit Sub
    End If

    Try
      Dim SAPCallContext = SAPCallContexts(ContextGUID)

      Try
        SAPCallContext.ReceiveRowsGate.Take()
      Catch ex As System.InvalidOperationException
        If Not CancelSourceValue.IsCancellationRequested Then
          Throw
        End If
      End Try
    Catch ex As Exception
      ExceptionsAggregator.Add(ex)
      Throw
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

    Try
      RaiseQueryStatusChanged("Exporting data from SAP. Records already exported: " & Consumer.RecordsWithThousandSeparator & " Last Application DB query time: " & Decimal.Parse(Replace(SelectLengthC, ".", ",")).ToString("F3") & " seconds.")

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
        If Not CancelSourceValue.IsCancellationRequested Then
          Throw
        End If
        Cancel = "X"
      End Try
    Catch ex As Exception
      ExceptionsAggregator.Add(ex)
      Throw
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

    Try
      Dim SAPCallContext = SAPCallContexts(ContextGUID)

      Try
        SAPCallContext.LinkedContext.NextRows.Add(NextRow)
      Catch ex As System.InvalidOperationException
        If Not CancelSourceValue.IsCancellationRequested Then
          Throw
        End If
        Cancel = "X"
      End Try
    Catch ex As Exception
      ExceptionsAggregator.Add(ex)
      Throw
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

    Try
      Dim SAPCallContext = SAPCallContexts(ContextGUID)
      Try
        NextRow = SAPCallContext.NextRows.Take
      Catch ex As System.InvalidOperationException
        Cancel = "X"
      Catch ex As System.OperationCanceledException
        Cancel = "X"
      Catch ex As System.ArgumentNullException
        Cancel = "X"
      End Try
    Catch ex As Exception
      ExceptionsAggregator.Add(ex)
      Throw
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

    Try
      Throw New CompileException("GUID: " & GUID & " ContextGUID: " & ContextGUID & " Message: " & Message & " Line: " & Line.ToString)
    Catch ex As Exception
      ExceptionsAggregator.Add(ex)
      Throw
    End Try
  End Sub
End Class
