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
