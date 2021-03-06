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
  '@ Nametab Header, Database Structure DDNTT
  '@ </summary>
  <Serializable, RfcStructure(AbapName :="X030L"  , Length := 147, Length2 := 254)> _
  Public Class X030L 
    Inherits SAPStructure
   

    '@ <summary>
    '@ Table Name
    '@ </summary>
 
    <RfcField(AbapName := "TABNAME", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 30, Length2 := 60, Offset := 0, Offset2 := 0), _
    XmlElement("TABNAME", Form := XmlSchemaForm.Unqualified)> _
    Public Property Tabname As String
       Get
          Return _Tabname
       End Get
       Set(ByVal Value As String)
          _Tabname = Value
       End Set
    End Property
    Private _Tabname As String

    '@ <summary>
    '@ Internal Name for Database
    '@ </summary>
 
    <RfcField(AbapName := "DBASE", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 30, Offset2 := 60), _
    XmlElement("DBASE", Form := XmlSchemaForm.Unqualified)> _
    Public Property Dbase As String
       Get
          Return _Dbase
       End Get
       Set(ByVal Value As String)
          _Dbase = Value
       End Set
    End Property
    Private _Dbase As String

    '@ <summary>
    '@ Global Unique ID for table
    '@ </summary>
 
    <RfcField(AbapName := "UUID", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 16, Length2 := 16, Offset := 31, Offset2 := 62), _
    XmlElement("UUID", Form := XmlSchemaForm.Unqualified)> _
    Public Property Uuid As Byte()
       Get
          Return _Uuid
       End Get
       Set(ByVal Value As Byte())
          _Uuid = Value
       End Set
    End Property
    Private _Uuid As Byte()

    '@ <summary>
    '@ Time of nametab generation
    '@ </summary>
 
    <RfcField(AbapName := "CRSTAMP", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 14, Length2 := 28, Offset := 47, Offset2 := 78), _
    XmlElement("CRSTAMP", Form := XmlSchemaForm.Unqualified)> _
    Public Property Crstamp As String
       Get
          Return _Crstamp
       End Get
       Set(ByVal Value As String)
          _Crstamp = Value
       End Set
    End Property
    Private _Crstamp As String

    '@ <summary>
    '@ ABAP Time Stamp
    '@ </summary>
 
    <RfcField(AbapName := "ABSTAMP", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 14, Length2 := 28, Offset := 61, Offset2 := 106), _
    XmlElement("ABSTAMP", Form := XmlSchemaForm.Unqualified)> _
    Public Property Abstamp As String
       Get
          Return _Abstamp
       End Get
       Set(ByVal Value As String)
          _Abstamp = Value
       End Set
    End Property
    Private _Abstamp As String

    '@ <summary>
    '@ Screen time stamp
    '@ </summary>
 
    <RfcField(AbapName := "DYSTAMP", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 14, Length2 := 28, Offset := 75, Offset2 := 134), _
    XmlElement("DYSTAMP", Form := XmlSchemaForm.Unqualified)> _
    Public Property Dystamp As String
       Get
          Return _Dystamp
       End Get
       Set(ByVal Value As String)
          _Dystamp = Value
       End Set
    End Property
    Private _Dystamp As String

    '@ <summary>
    '@ Number of table fields
    '@ </summary>
 
    <RfcField(AbapName := "FLDCNT", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 2, Length2 := 2, Offset := 89, Offset2 := 162), _
    XmlElement("FLDCNT", Form := XmlSchemaForm.Unqualified)> _
    Public Property Fldcnt As Byte()
       Get
          Return _Fldcnt
       End Get
       Set(ByVal Value As Byte())
          _Fldcnt = Value
       End Set
    End Property
    Private _Fldcnt As Byte()

    '@ <summary>
    '@ Table length in bytes
    '@ </summary>
 
    <RfcField(AbapName := "TABLEN", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 4, Length2 := 4, Offset := 91, Offset2 := 164), _
    XmlElement("TABLEN", Form := XmlSchemaForm.Unqualified)> _
    Public Property Tablen As Byte()
       Get
          Return _Tablen
       End Get
       Set(ByVal Value As Byte())
          _Tablen = Value
       End Set
    End Property
    Private _Tablen As Byte()

    '@ <summary>
    '@ Number of key fields in table
    '@ </summary>
 
    <RfcField(AbapName := "KEYCNT", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 1, Length2 := 1, Offset := 95, Offset2 := 168), _
    XmlElement("KEYCNT", Form := XmlSchemaForm.Unqualified)> _
    Public Property Keycnt As Byte()
       Get
          Return _Keycnt
       End Get
       Set(ByVal Value As Byte())
          _Keycnt = Value
       End Set
    End Property
    Private _Keycnt As Byte()

    '@ <summary>
    '@ Length of Table Key in Bytes
    '@ </summary>
 
    <RfcField(AbapName := "KEYLEN", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 2, Length2 := 2, Offset := 96, Offset2 := 169), _
    XmlElement("KEYLEN", Form := XmlSchemaForm.Unqualified)> _
    Public Property Keylen As Byte()
       Get
          Return _Keylen
       End Get
       Set(ByVal Value As Byte())
          _Keylen = Value
       End Set
    End Property
    Private _Keylen As Byte()

    '@ <summary>
    '@ Position number of the client field in the table
    '@ </summary>
 
    <RfcField(AbapName := "CLPOS", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 1, Length2 := 1, Offset := 98, Offset2 := 171), _
    XmlElement("CLPOS", Form := XmlSchemaForm.Unqualified)> _
    Public Property Clpos As Byte()
       Get
          Return _Clpos
       End Get
       Set(ByVal Value As Byte())
          _Clpos = Value
       End Set
    End Property
    Private _Clpos As Byte()

    '@ <summary>
    '@ Type of the Dictionary object
    '@ </summary>
 
    <RfcField(AbapName := "TABTYPE", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 99, Offset2 := 172), _
    XmlElement("TABTYPE", Form := XmlSchemaForm.Unqualified)> _
    Public Property Tabtype As String
       Get
          Return _Tabtype
       End Get
       Set(ByVal Value As String)
          _Tabtype = Value
       End Set
    End Property
    Private _Tabtype As String

    '@ <summary>
    '@ How the Dictionary object is implemented in the database
    '@ </summary>
 
    <RfcField(AbapName := "TABFORM", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 100, Offset2 := 174), _
    XmlElement("TABFORM", Form := XmlSchemaForm.Unqualified)> _
    Public Property Tabform As String
       Get
          Return _Tabform
       End Get
       Set(ByVal Value As String)
          _Tabform = Value
       End Set
    End Property
    Private _Tabform As String

    '@ <summary>
    '@ Name of physical table (for pool/cluster/view)
    '@ </summary>
 
    <RfcField(AbapName := "REFNAME", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 30, Length2 := 60, Offset := 101, Offset2 := 176), _
    XmlElement("REFNAME", Form := XmlSchemaForm.Unqualified)> _
    Public Property Refname As String
       Get
          Return _Refname
       End Get
       Set(ByVal Value As String)
          _Refname = Value
       End Set
    End Property
    Private _Refname As String

    '@ <summary>
    '@ Flag of length 1 byte for table attributes
    '@ </summary>
 
    <RfcField(AbapName := "FLAGBYTE", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 1, Length2 := 1, Offset := 131, Offset2 := 236), _
    XmlElement("FLAGBYTE", Form := XmlSchemaForm.Unqualified)> _
    Public Property Flagbyte As Byte()
       Get
          Return _Flagbyte
       End Get
       Set(ByVal Value As Byte())
          _Flagbyte = Value
       End Set
    End Property
    Private _Flagbyte As Byte()

    '@ <summary>
    '@ Flag if table to be compressed
    '@ </summary>
 
    <RfcField(AbapName := "EXROUT", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 1, Length2 := 1, Offset := 132, Offset2 := 237), _
    XmlElement("EXROUT", Form := XmlSchemaForm.Unqualified)> _
    Public Property Exrout As Byte()
       Get
          Return _Exrout
       End Get
       Set(ByVal Value As Byte())
          _Exrout = Value
       End Set
    End Property
    Private _Exrout As Byte()

    '@ <summary>
    '@ Flag of length 1 byte for table attributes
    '@ </summary>
 
    <RfcField(AbapName := "FLAG3", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 1, Length2 := 1, Offset := 133, Offset2 := 238), _
    XmlElement("FLAG3", Form := XmlSchemaForm.Unqualified)> _
    Public Property Flag3 As Byte()
       Get
          Return _Flag3
       End Get
       Set(ByVal Value As Byte())
          _Flag3 = Value
       End Set
    End Property
    Private _Flag3 As Byte()

    '@ <summary>
    '@ Flag of length 1 byte for table attributes
    '@ </summary>
 
    <RfcField(AbapName := "FLAG4", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 1, Length2 := 1, Offset := 134, Offset2 := 239), _
    XmlElement("FLAG4", Form := XmlSchemaForm.Unqualified)> _
    Public Property Flag4 As Byte()
       Get
          Return _Flag4
       End Get
       Set(ByVal Value As Byte())
          _Flag4 = Value
       End Set
    End Property
    Private _Flag4 As Byte()

    '@ <summary>
    '@ Flag of length 1 byte for table attributes
    '@ </summary>
 
    <RfcField(AbapName := "FLAG5", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 1, Length2 := 1, Offset := 135, Offset2 := 240), _
    XmlElement("FLAG5", Form := XmlSchemaForm.Unqualified)> _
    Public Property Flag5 As Byte()
       Get
          Return _Flag5
       End Get
       Set(ByVal Value As Byte())
          _Flag5 = Value
       End Set
    End Property
    Private _Flag5 As Byte()

    '@ <summary>
    '@ Flag of length 1 byte for table attributes
    '@ </summary>
 
    <RfcField(AbapName := "FLAG6", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 1, Length2 := 1, Offset := 136, Offset2 := 241), _
    XmlElement("FLAG6", Form := XmlSchemaForm.Unqualified)> _
    Public Property Flag6 As Byte()
       Get
          Return _Flag6
       End Get
       Set(ByVal Value As Byte())
          _Flag6 = Value
       End Set
    End Property
    Private _Flag6 As Byte()

    '@ <summary>
    '@ Buffering type of table
    '@ </summary>
 
    <RfcField(AbapName := "BUFSTATE", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 137, Offset2 := 242), _
    XmlElement("BUFSTATE", Form := XmlSchemaForm.Unqualified)> _
    Public Property Bufstate As String
       Get
          Return _Bufstate
       End Get
       Set(ByVal Value As String)
          _Bufstate = Value
       End Set
    End Property
    Private _Bufstate As String

    '@ <summary>
    '@ Supplementary information in generic buffering
    '@ </summary>
 
    <RfcField(AbapName := "BUFPARM", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 2, Length2 := 2, Offset := 138, Offset2 := 244), _
    XmlElement("BUFPARM", Form := XmlSchemaForm.Unqualified)> _
    Public Property Bufparm As Byte()
       Get
          Return _Bufparm
       End Get
       Set(ByVal Value As Byte())
          _Bufparm = Value
       End Set
    End Property
    Private _Bufparm As Byte()

    '@ <summary>
    '@ Table alignment
    '@ </summary>
 
    <RfcField(AbapName := "ALIGN", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 1, Length2 := 1, Offset := 140, Offset2 := 246), _
    XmlElement("ALIGN", Form := XmlSchemaForm.Unqualified)> _
    Public Property Align As Byte()
       Get
          Return _Align
       End Get
       Set(ByVal Value As Byte())
          _Align = Value
       End Set
    End Property
    Private _Align As Byte()

    '@ <summary>
    '@ Pointer length with which nametab was generated
    '@ </summary>
 
    <RfcField(AbapName := "POINTERLG", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 1, Length2 := 1, Offset := 141, Offset2 := 247), _
    XmlElement("POINTERLG", Form := XmlSchemaForm.Unqualified)> _
    Public Property Pointerlg As Byte()
       Get
          Return _Pointerlg
       End Get
       Set(ByVal Value As Byte())
          _Pointerlg = Value
       End Set
    End Property
    Private _Pointerlg As Byte()

    '@ <summary>
    '@ Unicode length with which runtime object was generated
    '@ </summary>
 
    <RfcField(AbapName := "UNICODELG", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 1, Length2 := 1, Offset := 142, Offset2 := 248), _
    XmlElement("UNICODELG", Form := XmlSchemaForm.Unqualified)> _
    Public Property Unicodelg As Byte()
       Get
          Return _Unicodelg
       End Get
       Set(ByVal Value As Byte())
          _Unicodelg = Value
       End Set
    End Property
    Private _Unicodelg As Byte()

    '@ <summary>
    '@ ABAP Dictionary: Number of Fields with Depth 0
    '@ </summary>
 
    <RfcField(AbapName := "COMPCNT", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 2, Length2 := 2, Offset := 143, Offset2 := 249), _
    XmlElement("COMPCNT", Form := XmlSchemaForm.Unqualified)> _
    Public Property Compcnt As Byte()
       Get
          Return _Compcnt
       End Get
       Set(ByVal Value As Byte())
          _Compcnt = Value
       End Set
    End Property
    Private _Compcnt As Byte()

    '@ <summary>
    '@ ABAP Dictionary: Leaf Content of Structure
    '@ </summary>
 
    <RfcField(AbapName := "LEAFCNT", RfcType := RFCTYPE.RFCTYPE_BYTE, Length := 2, Length2 := 2, Offset := 145, Offset2 := 251), _
    XmlElement("LEAFCNT", Form := XmlSchemaForm.Unqualified)> _
    Public Property Leafcnt As Byte()
       Get
          Return _Leafcnt
       End Get
       Set(ByVal Value As Byte())
          _Leafcnt = Value
       End Set
    End Property
    Private _Leafcnt As Byte()
  End Class
