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
  '@ Description of a Fixed Value
  '@ </summary>
  <Serializable, RfcStructure(AbapName :="DDFIXVALUE"  , Length := 83, Length2 := 166)> _
  Public Class DDFIXVALUE 
    Inherits SAPStructure
   

    '@ <summary>
    '@ Values for Domains: Single Value / Upper Limit
    '@ </summary>
 
    <RfcField(AbapName := "LOW", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 10, Length2 := 20, Offset := 0, Offset2 := 0), _
    XmlElement("LOW", Form := XmlSchemaForm.Unqualified)> _
    Public Property Low As String
       Get
          Return _Low
       End Get
       Set(ByVal Value As String)
          _Low = Value
       End Set
    End Property
    Private _Low As String

    '@ <summary>
    '@ Values for domains, upper limit
    '@ </summary>
 
    <RfcField(AbapName := "HIGH", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 10, Length2 := 20, Offset := 10, Offset2 := 20), _
    XmlElement("HIGH", Form := XmlSchemaForm.Unqualified)> _
    Public Property High As String
       Get
          Return _High
       End Get
       Set(ByVal Value As String)
          _High = Value
       End Set
    End Property
    Private _High As String

    '@ <summary>
    '@ Option for domain fixed values
    '@ </summary>
 
    <RfcField(AbapName := "OPTION", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 2, Length2 := 4, Offset := 20, Offset2 := 40), _
    XmlElement("OPTION", Form := XmlSchemaForm.Unqualified)> _
    Public Property Option0 As String
       Get
          Return _Option0
       End Get
       Set(ByVal Value As String)
          _Option0 = Value
       End Set
    End Property
    Private _Option0 As String

    '@ <summary>
    '@ Language Key
    '@ </summary>
 
    <RfcField(AbapName := "DDLANGUAGE", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 22, Offset2 := 44), _
    XmlElement("DDLANGUAGE", Form := XmlSchemaForm.Unqualified)> _
    Public Property Ddlanguage As String
       Get
          Return _Ddlanguage
       End Get
       Set(ByVal Value As String)
          _Ddlanguage = Value
       End Set
    End Property
    Private _Ddlanguage As String

    '@ <summary>
    '@ Short Text for Fixed Values
    '@ </summary>
 
    <RfcField(AbapName := "DDTEXT", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 60, Length2 := 120, Offset := 23, Offset2 := 46), _
    XmlElement("DDTEXT", Form := XmlSchemaForm.Unqualified)> _
    Public Property Ddtext As String
       Get
          Return _Ddtext
       End Get
       Set(ByVal Value As String)
          _Ddtext = Value
       End Set
    End Property
    Private _Ddtext As String
  End Class
