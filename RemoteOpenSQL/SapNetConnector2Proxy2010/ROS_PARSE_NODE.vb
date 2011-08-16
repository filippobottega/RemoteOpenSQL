' Remote open sql 
' © Copyright 2011 By Filippo Bottega, all rights reserved.

Imports System
Imports System.Text
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Xml.Serialization
Imports System.Xml.Schema
Imports System.Web.Services
Imports System.Web.Services.Description
Imports System.Web.Services.Protocols
Imports SAP.Connector



'@ <summary>
'@ Transfer: Field Name/Value
'@ </summary>
<Serializable(), RfcStructure(AbapName:="ROS_PARSE_NODE", Length:=519, Length2:=1030)> _
Public Class ROS_PARSE_NODE
  Inherits SAPStructure


  '@ <summary>
  '@ ID
  '@ </summary>

  <RfcField(AbapName:="ID", RFCTYPE:=RFCTYPE.RFCTYPE_INT, Length:=4, Length2:=4, Offset:=0, Offset2:=0), _
  XmlElement("ID", Form:=XmlSchemaForm.Unqualified)> _
  Public Property Id As Integer
    Get
      Return _Id
    End Get
    Set(ByVal Value As Integer)
      _Id = Value
    End Set
  End Property
  Private _Id As Integer

  '@ <summary>
  '@ PARENT
  '@ </summary>

  <RfcField(AbapName:="PARENT", RFCTYPE:=RFCTYPE.RFCTYPE_INT, Length:=4, Length2:=4, Offset:=4, Offset2:=4), _
  XmlElement("PARENT", Form:=XmlSchemaForm.Unqualified)> _
  Public Property Parent As Integer
    Get
      Return _Parent
    End Get
    Set(ByVal Value As Integer)
      _Parent = Value
    End Set
  End Property
  Private _Parent As Integer

  '@ <summary>
  '@ Symbol
  '@ </summary>

  <RfcField(AbapName:="SYMBOL", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Length:=255, Length2:=510, Offset:=8, Offset2:=8), _
  XmlElement("SYMBOL", Form:=XmlSchemaForm.Unqualified)> _
  Public Property Symbol As String
    Get
      Return _Symbol
    End Get
    Set(ByVal Value As String)
      _Symbol = Value
    End Set
  End Property
  Private _Symbol As String

  '@ <summary>
  '@ Text_Or_Rule
  '@ </summary>

  <RfcField(AbapName:="TEXT_OR_RULE", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Length:=255, Length2:=510, Offset:=263, Offset2:=518), _
  XmlElement("TEXT_OR_RULE", Form:=XmlSchemaForm.Unqualified)> _
  Public Property Text_Or_Rule As String
    Get
      Return _Text_Or_Rule
    End Get
    Set(ByVal Value As String)
      _Text_Or_Rule = Value
    End Set
  End Property
  Private _Text_Or_Rule As String

  '@ <summary>
  '@ Terminal
  '@ </summary>

  <RfcField(AbapName:="TERMINAL", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Length:=1, Length2:=2, Offset:=518, Offset2:=1028), _
  XmlElement("TERMINAL", Form:=XmlSchemaForm.Unqualified)> _
  Public Property Terminal As String
    Get
      Return _Terminal
    End Get
    Set(ByVal Value As String)
      _Terminal = Value
    End Set
  End Property
  Private _Terminal As String
End Class

