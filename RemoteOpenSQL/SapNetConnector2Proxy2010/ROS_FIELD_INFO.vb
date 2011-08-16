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
'@ ROS_FIELD_INFO
'@ </summary>
<Serializable(), RfcStructure(AbapName:="ROS_FIELD_INFO", Length:=64, Length2:=124)> _
Public Class ROS_FIELD_INFO
  Inherits SAPStructure


  '@ <summary>
  '@ FIELDNAME
  '@ </summary>

  <RfcField(AbapName:="FIELDNAME", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Length:=30, Length2:=60, Offset:=0, Offset2:=0), _
  XmlElement("FIELDNAME", Form:=XmlSchemaForm.Unqualified)> _
  Public Property FieldName As String
    Get
      Return _FieldName
    End Get
    Set(ByVal Value As String)
      _FieldName = Value
    End Set
  End Property
  Private _FieldName As String

  '@ <summary>
  '@ ROLLNAME
  '@ </summary>

  <RfcField(AbapName:="ROLLNAME_OR_ABAPTYPE", RFCTYPE:=RFCTYPE.RFCTYPE_CHAR, Length:=30, Length2:=60, Offset:=30, Offset2:=60), _
  XmlElement("ROLLNAME_OR_ABAPTYPE", Form:=XmlSchemaForm.Unqualified)> _
  Public Property RollNameOrABAPType As String
    Get
      Return _RollNameOrABAPType
    End Get
    Set(ByVal Value As String)
      _RollNameOrABAPType = Value
    End Set
  End Property
  Private _RollNameOrABAPType As String

  '@ <summary>
  '@ DFIESINDEX
  '@ </summary>

  <RfcField(AbapName:="DFIESINDEX", RFCTYPE:=RFCTYPE.RFCTYPE_INT, Length:=4, Length2:=4, Offset:=60, Offset2:=120), _
  XmlElement("DFIESINDEX", Form:=XmlSchemaForm.Unqualified)> _
  Public Property DfiesIndex As Integer
    Get
      Return _DfiesIndex
    End Get
    Set(ByVal Value As Integer)
      _DfiesIndex = Value
    End Set
  End Property
  Private _DfiesIndex As Integer

End Class
