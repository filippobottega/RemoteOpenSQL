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
  '@ Description of an ABAP Dictionary Type
  '@ </summary>
  <Serializable, RfcStructure(AbapName :="DDTYPEDESC"  , Length := 48, Length2 := 80)> _
  Public Class DDTYPEDESC 
    Inherits SAPStructure
   

    '@ <summary>
    '@ Name of Dictionary Type
    '@ </summary>
 
    <RfcField(AbapName := "TYPENAME", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 30, Length2 := 60, Offset := 0, Offset2 := 0), _
    XmlElement("TYPENAME", Form := XmlSchemaForm.Unqualified)> _
    Public Property Typename As String
       Get
          Return _Typename
       End Get
       Set(ByVal Value As String)
          _Typename = Value
       End Set
    End Property
    Private _Typename As String

    '@ <summary>
    '@ Kind of Type
    '@ </summary>
 
    <RfcField(AbapName := "TYPEKIND", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 4, Length2 := 8, Offset := 30, Offset2 := 60), _
    XmlElement("TYPEKIND", Form := XmlSchemaForm.Unqualified)> _
    Public Property Typekind As String
       Get
          Return _Typekind
       End Get
       Set(ByVal Value As String)
          _Typekind = Value
       End Set
    End Property
    Private _Typekind As String

    '@ <summary>
    '@ 
    '@ </summary>
 
    <RfcField(AbapName:="FIELDS", RFCTYPE:=RFCTYPE.RFCTYPE_ITAB, Offset:=40, Offset2:=72), _
    XmlArray("FIELDS", IsNullable:=False, Form:=XmlSchemaForm.Unqualified), _
    XmlArrayItem("item", IsNullable:=False, Form:=XmlSchemaForm.Unqualified)> _
    Public Property Fields() As DDFIELDS
        Get
            Return _Fields
        End Get
        Set(ByVal Value As DDFIELDS)
            _Fields = Value
        End Set
    End Property
    Private _Fields As DDFIELDS
End Class
