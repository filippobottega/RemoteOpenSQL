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

