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
  '@ DD Interface: Table Fields for DDIF_FIELDINFO_GET
  '@ </summary>
  <Serializable, RfcStructure(AbapName :="DFIES"  , Length := 671, Length2 := 1342)> _
  Public Class DFIES 
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
    '@ Field Name
    '@ </summary>
 
    <RfcField(AbapName := "FIELDNAME", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 30, Length2 := 60, Offset := 30, Offset2 := 60), _
    XmlElement("FIELDNAME", Form := XmlSchemaForm.Unqualified)> _
    Public Property Fieldname As String
       Get
          Return _Fieldname
       End Get
       Set(ByVal Value As String)
          _Fieldname = Value
       End Set
    End Property
    Private _Fieldname As String

    '@ <summary>
    '@ Language Key
    '@ </summary>
 
    <RfcField(AbapName := "LANGU", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 60, Offset2 := 120), _
    XmlElement("LANGU", Form := XmlSchemaForm.Unqualified)> _
    Public Property Langu As String
       Get
          Return _Langu
       End Get
       Set(ByVal Value As String)
          _Langu = Value
       End Set
    End Property
    Private _Langu As String

    '@ <summary>
    '@ Position of the field in the table
    '@ </summary>
 
    <RfcField(AbapName := "POSITION", RfcType := RFCTYPE.RFCTYPE_NUM, Length := 4, Length2 := 8, Offset := 61, Offset2 := 122), _
    XmlElement("POSITION", Form := XmlSchemaForm.Unqualified)> _
    Public Property Position As String
       Get
          Return _Position
       End Get
       Set(ByVal Value As String)
          _Position = Value
       End Set
    End Property
    Private _Position As String

    '@ <summary>
    '@ Offset of a field
    '@ </summary>
 
    <RfcField(AbapName := "OFFSET", RfcType := RFCTYPE.RFCTYPE_NUM, Length := 6, Length2 := 12, Offset := 65, Offset2 := 130), _
    XmlElement("OFFSET", Form := XmlSchemaForm.Unqualified)> _
    Public Property Offset As String
       Get
          Return _Offset
       End Get
       Set(ByVal Value As String)
          _Offset = Value
       End Set
    End Property
    Private _Offset As String

    '@ <summary>
    '@ Domain name
    '@ </summary>
 
    <RfcField(AbapName := "DOMNAME", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 30, Length2 := 60, Offset := 71, Offset2 := 142), _
    XmlElement("DOMNAME", Form := XmlSchemaForm.Unqualified)> _
    Public Property Domname As String
       Get
          Return _Domname
       End Get
       Set(ByVal Value As String)
          _Domname = Value
       End Set
    End Property
    Private _Domname As String

    '@ <summary>
    '@ Data element (semantic domain)
    '@ </summary>
 
    <RfcField(AbapName := "ROLLNAME", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 30, Length2 := 60, Offset := 101, Offset2 := 202), _
    XmlElement("ROLLNAME", Form := XmlSchemaForm.Unqualified)> _
    Public Property Rollname As String
       Get
          Return _Rollname
       End Get
       Set(ByVal Value As String)
          _Rollname = Value
       End Set
    End Property
    Private _Rollname As String

    '@ <summary>
    '@ Table Name
    '@ </summary>
 
    <RfcField(AbapName := "CHECKTABLE", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 30, Length2 := 60, Offset := 131, Offset2 := 262), _
    XmlElement("CHECKTABLE", Form := XmlSchemaForm.Unqualified)> _
    Public Property Checktable As String
       Get
          Return _Checktable
       End Get
       Set(ByVal Value As String)
          _Checktable = Value
       End Set
    End Property
    Private _Checktable As String

    '@ <summary>
    '@ Length (No. of Characters)
    '@ </summary>
 
    <RfcField(AbapName := "LENG", RfcType := RFCTYPE.RFCTYPE_NUM, Length := 6, Length2 := 12, Offset := 161, Offset2 := 322), _
    XmlElement("LENG", Form := XmlSchemaForm.Unqualified)> _
    Public Property Leng As String
       Get
          Return _Leng
       End Get
       Set(ByVal Value As String)
          _Leng = Value
       End Set
    End Property
    Private _Leng As String

    '@ <summary>
    '@ Internal Length in Bytes
    '@ </summary>
 
    <RfcField(AbapName := "INTLEN", RfcType := RFCTYPE.RFCTYPE_NUM, Length := 6, Length2 := 12, Offset := 167, Offset2 := 334), _
    XmlElement("INTLEN", Form := XmlSchemaForm.Unqualified)> _
    Public Property Intlen As String
       Get
          Return _Intlen
       End Get
       Set(ByVal Value As String)
          _Intlen = Value
       End Set
    End Property
    Private _Intlen As String

    '@ <summary>
    '@ Output Length
    '@ </summary>
 
    <RfcField(AbapName := "OUTPUTLEN", RfcType := RFCTYPE.RFCTYPE_NUM, Length := 6, Length2 := 12, Offset := 173, Offset2 := 346), _
    XmlElement("OUTPUTLEN", Form := XmlSchemaForm.Unqualified)> _
    Public Property Outputlen As String
       Get
          Return _Outputlen
       End Get
       Set(ByVal Value As String)
          _Outputlen = Value
       End Set
    End Property
    Private _Outputlen As String

    '@ <summary>
    '@ Number of Decimal Places
    '@ </summary>
 
    <RfcField(AbapName := "DECIMALS", RfcType := RFCTYPE.RFCTYPE_NUM, Length := 6, Length2 := 12, Offset := 179, Offset2 := 358), _
    XmlElement("DECIMALS", Form := XmlSchemaForm.Unqualified)> _
    Public Property Decimals As String
       Get
          Return _Decimals
       End Get
       Set(ByVal Value As String)
          _Decimals = Value
       End Set
    End Property
    Private _Decimals As String

    '@ <summary>
    '@ ABAP/4 Dictionary: Screen data type for Screen Painter
    '@ </summary>
 
    <RfcField(AbapName := "DATATYPE", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 4, Length2 := 8, Offset := 185, Offset2 := 370), _
    XmlElement("DATATYPE", Form := XmlSchemaForm.Unqualified)> _
    Public Property Datatype As String
       Get
          Return _Datatype
       End Get
       Set(ByVal Value As String)
          _Datatype = Value
       End Set
    End Property
    Private _Datatype As String

    '@ <summary>
    '@ ABAP data type (C,D,N,...)
    '@ </summary>
 
    <RfcField(AbapName := "INTTYPE", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 189, Offset2 := 378), _
    XmlElement("INTTYPE", Form := XmlSchemaForm.Unqualified)> _
    Public Property Inttype As String
       Get
          Return _Inttype
       End Get
       Set(ByVal Value As String)
          _Inttype = Value
       End Set
    End Property
    Private _Inttype As String

    '@ <summary>
    '@ Table for reference field
    '@ </summary>
 
    <RfcField(AbapName := "REFTABLE", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 30, Length2 := 60, Offset := 190, Offset2 := 380), _
    XmlElement("REFTABLE", Form := XmlSchemaForm.Unqualified)> _
    Public Property Reftable As String
       Get
          Return _Reftable
       End Get
       Set(ByVal Value As String)
          _Reftable = Value
       End Set
    End Property
    Private _Reftable As String

    '@ <summary>
    '@ Reference field for currency and qty fields
    '@ </summary>
 
    <RfcField(AbapName := "REFFIELD", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 30, Length2 := 60, Offset := 220, Offset2 := 440), _
    XmlElement("REFFIELD", Form := XmlSchemaForm.Unqualified)> _
    Public Property Reffield As String
       Get
          Return _Reffield
       End Get
       Set(ByVal Value As String)
          _Reffield = Value
       End Set
    End Property
    Private _Reffield As String

    '@ <summary>
    '@ Name of included table
    '@ </summary>
 
    <RfcField(AbapName := "PRECFIELD", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 30, Length2 := 60, Offset := 250, Offset2 := 500), _
    XmlElement("PRECFIELD", Form := XmlSchemaForm.Unqualified)> _
    Public Property Precfield As String
       Get
          Return _Precfield
       End Get
       Set(ByVal Value As String)
          _Precfield = Value
       End Set
    End Property
    Private _Precfield As String

    '@ <summary>
    '@ Authorization class
    '@ </summary>
 
    <RfcField(AbapName := "AUTHORID", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 3, Length2 := 6, Offset := 280, Offset2 := 560), _
    XmlElement("AUTHORID", Form := XmlSchemaForm.Unqualified)> _
    Public Property Authorid As String
       Get
          Return _Authorid
       End Get
       Set(ByVal Value As String)
          _Authorid = Value
       End Set
    End Property
    Private _Authorid As String

    '@ <summary>
    '@ Set/Get parameter ID
    '@ </summary>
 
    <RfcField(AbapName := "MEMORYID", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 20, Length2 := 40, Offset := 283, Offset2 := 566), _
    XmlElement("MEMORYID", Form := XmlSchemaForm.Unqualified)> _
    Public Property Memoryid As String
       Get
          Return _Memoryid
       End Get
       Set(ByVal Value As String)
          _Memoryid = Value
       End Set
    End Property
    Private _Memoryid As String

    '@ <summary>
    '@ Indicator for writing change documents
    '@ </summary>
 
    <RfcField(AbapName := "LOGFLAG", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 303, Offset2 := 606), _
    XmlElement("LOGFLAG", Form := XmlSchemaForm.Unqualified)> _
    Public Property Logflag As String
       Get
          Return _Logflag
       End Get
       Set(ByVal Value As String)
          _Logflag = Value
       End Set
    End Property
    Private _Logflag As String

    '@ <summary>
    '@ Template (not used)
    '@ </summary>
 
    <RfcField(AbapName := "MASK", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 20, Length2 := 40, Offset := 304, Offset2 := 608), _
    XmlElement("MASK", Form := XmlSchemaForm.Unqualified)> _
    Public Property Mask As String
       Get
          Return _Mask
       End Get
       Set(ByVal Value As String)
          _Mask = Value
       End Set
    End Property
    Private _Mask As String

    '@ <summary>
    '@ Template length (not used)
    '@ </summary>
 
    <RfcField(AbapName := "MASKLEN", RfcType := RFCTYPE.RFCTYPE_NUM, Length := 4, Length2 := 8, Offset := 324, Offset2 := 648), _
    XmlElement("MASKLEN", Form := XmlSchemaForm.Unqualified)> _
    Public Property Masklen As String
       Get
          Return _Masklen
       End Get
       Set(ByVal Value As String)
          _Masklen = Value
       End Set
    End Property
    Private _Masklen As String

    '@ <summary>
    '@ Conversion Routine
    '@ </summary>
 
    <RfcField(AbapName := "CONVEXIT", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 5, Length2 := 10, Offset := 328, Offset2 := 656), _
    XmlElement("CONVEXIT", Form := XmlSchemaForm.Unqualified)> _
    Public Property Convexit As String
       Get
          Return _Convexit
       End Get
       Set(ByVal Value As String)
          _Convexit = Value
       End Set
    End Property
    Private _Convexit As String

    '@ <summary>
    '@ Maximum length of heading
    '@ </summary>
 
    <RfcField(AbapName := "HEADLEN", RfcType := RFCTYPE.RFCTYPE_NUM, Length := 2, Length2 := 4, Offset := 333, Offset2 := 666), _
    XmlElement("HEADLEN", Form := XmlSchemaForm.Unqualified)> _
    Public Property Headlen As String
       Get
          Return _Headlen
       End Get
       Set(ByVal Value As String)
          _Headlen = Value
       End Set
    End Property
    Private _Headlen As String

    '@ <summary>
    '@ Max. length for short field label
    '@ </summary>
 
    <RfcField(AbapName := "SCRLEN1", RfcType := RFCTYPE.RFCTYPE_NUM, Length := 2, Length2 := 4, Offset := 335, Offset2 := 670), _
    XmlElement("SCRLEN1", Form := XmlSchemaForm.Unqualified)> _
    Public Property Scrlen1 As String
       Get
          Return _Scrlen1
       End Get
       Set(ByVal Value As String)
          _Scrlen1 = Value
       End Set
    End Property
    Private _Scrlen1 As String

    '@ <summary>
    '@ Max. length for medium field label
    '@ </summary>
 
    <RfcField(AbapName := "SCRLEN2", RfcType := RFCTYPE.RFCTYPE_NUM, Length := 2, Length2 := 4, Offset := 337, Offset2 := 674), _
    XmlElement("SCRLEN2", Form := XmlSchemaForm.Unqualified)> _
    Public Property Scrlen2 As String
       Get
          Return _Scrlen2
       End Get
       Set(ByVal Value As String)
          _Scrlen2 = Value
       End Set
    End Property
    Private _Scrlen2 As String

    '@ <summary>
    '@ Max. length for long field label
    '@ </summary>
 
    <RfcField(AbapName := "SCRLEN3", RfcType := RFCTYPE.RFCTYPE_NUM, Length := 2, Length2 := 4, Offset := 339, Offset2 := 678), _
    XmlElement("SCRLEN3", Form := XmlSchemaForm.Unqualified)> _
    Public Property Scrlen3 As String
       Get
          Return _Scrlen3
       End Get
       Set(ByVal Value As String)
          _Scrlen3 = Value
       End Set
    End Property
    Private _Scrlen3 As String

    '@ <summary>
    '@ Short Description of Repository Objects
    '@ </summary>
 
    <RfcField(AbapName := "FIELDTEXT", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 60, Length2 := 120, Offset := 341, Offset2 := 682), _
    XmlElement("FIELDTEXT", Form := XmlSchemaForm.Unqualified)> _
    Public Property Fieldtext As String
       Get
          Return _Fieldtext
       End Get
       Set(ByVal Value As String)
          _Fieldtext = Value
       End Set
    End Property
    Private _Fieldtext As String

    '@ <summary>
    '@ Heading
    '@ </summary>
 
    <RfcField(AbapName := "REPTEXT", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 55, Length2 := 110, Offset := 401, Offset2 := 802), _
    XmlElement("REPTEXT", Form := XmlSchemaForm.Unqualified)> _
    Public Property Reptext As String
       Get
          Return _Reptext
       End Get
       Set(ByVal Value As String)
          _Reptext = Value
       End Set
    End Property
    Private _Reptext As String

    '@ <summary>
    '@ Short Field Label
    '@ </summary>
 
    <RfcField(AbapName := "SCRTEXT_S", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 10, Length2 := 20, Offset := 456, Offset2 := 912), _
    XmlElement("SCRTEXT_S", Form := XmlSchemaForm.Unqualified)> _
    Public Property Scrtext_S As String
       Get
          Return _Scrtext_S
       End Get
       Set(ByVal Value As String)
          _Scrtext_S = Value
       End Set
    End Property
    Private _Scrtext_S As String

    '@ <summary>
    '@ Medium Field Label
    '@ </summary>
 
    <RfcField(AbapName := "SCRTEXT_M", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 20, Length2 := 40, Offset := 466, Offset2 := 932), _
    XmlElement("SCRTEXT_M", Form := XmlSchemaForm.Unqualified)> _
    Public Property Scrtext_M As String
       Get
          Return _Scrtext_M
       End Get
       Set(ByVal Value As String)
          _Scrtext_M = Value
       End Set
    End Property
    Private _Scrtext_M As String

    '@ <summary>
    '@ Long Field Label
    '@ </summary>
 
    <RfcField(AbapName := "SCRTEXT_L", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 40, Length2 := 80, Offset := 486, Offset2 := 972), _
    XmlElement("SCRTEXT_L", Form := XmlSchemaForm.Unqualified)> _
    Public Property Scrtext_L As String
       Get
          Return _Scrtext_L
       End Get
       Set(ByVal Value As String)
          _Scrtext_L = Value
       End Set
    End Property
    Private _Scrtext_L As String

    '@ <summary>
    '@ Identifies a key field of a table
    '@ </summary>
 
    <RfcField(AbapName := "KEYFLAG", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 526, Offset2 := 1052), _
    XmlElement("KEYFLAG", Form := XmlSchemaForm.Unqualified)> _
    Public Property Keyflag As String
       Get
          Return _Keyflag
       End Get
       Set(ByVal Value As String)
          _Keyflag = Value
       End Set
    End Property
    Private _Keyflag As String

    '@ <summary>
    '@ Lowercase letters allowed/not allowed
    '@ </summary>
 
    <RfcField(AbapName := "LOWERCASE", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 527, Offset2 := 1054), _
    XmlElement("LOWERCASE", Form := XmlSchemaForm.Unqualified)> _
    Public Property Lowercase As String
       Get
          Return _Lowercase
       End Get
       Set(ByVal Value As String)
          _Lowercase = Value
       End Set
    End Property
    Private _Lowercase As String

    '@ <summary>
    '@ Flag if search help is attached to the field
    '@ </summary>
 
    <RfcField(AbapName := "MAC", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 528, Offset2 := 1056), _
    XmlElement("MAC", Form := XmlSchemaForm.Unqualified)> _
    Public Property Mac As String
       Get
          Return _Mac
       End Get
       Set(ByVal Value As String)
          _Mac = Value
       End Set
    End Property
    Private _Mac As String

    '@ <summary>
    '@ Flag (X or Blank)
    '@ </summary>
 
    <RfcField(AbapName := "GENKEY", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 529, Offset2 := 1058), _
    XmlElement("GENKEY", Form := XmlSchemaForm.Unqualified)> _
    Public Property Genkey As String
       Get
          Return _Genkey
       End Get
       Set(ByVal Value As String)
          _Genkey = Value
       End Set
    End Property
    Private _Genkey As String

    '@ <summary>
    '@ Flag (X or Blank)
    '@ </summary>
 
    <RfcField(AbapName := "NOFORKEY", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 530, Offset2 := 1060), _
    XmlElement("NOFORKEY", Form := XmlSchemaForm.Unqualified)> _
    Public Property Noforkey As String
       Get
          Return _Noforkey
       End Get
       Set(ByVal Value As String)
          _Noforkey = Value
       End Set
    End Property
    Private _Noforkey As String

    '@ <summary>
    '@ Existence of fixed values
    '@ </summary>
 
    <RfcField(AbapName := "VALEXI", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 531, Offset2 := 1062), _
    XmlElement("VALEXI", Form := XmlSchemaForm.Unqualified)> _
    Public Property Valexi As String
       Get
          Return _Valexi
       End Get
       Set(ByVal Value As String)
          _Valexi = Value
       End Set
    End Property
    Private _Valexi As String

    '@ <summary>
    '@ Flag (X or Blank)
    '@ </summary>
 
    <RfcField(AbapName := "NOAUTHCH", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 532, Offset2 := 1064), _
    XmlElement("NOAUTHCH", Form := XmlSchemaForm.Unqualified)> _
    Public Property Noauthch As String
       Get
          Return _Noauthch
       End Get
       Set(ByVal Value As String)
          _Noauthch = Value
       End Set
    End Property
    Private _Noauthch As String

    '@ <summary>
    '@ Flag for sign in numerical fields
    '@ </summary>
 
    <RfcField(AbapName := "SIGN", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 533, Offset2 := 1066), _
    XmlElement("SIGN", Form := XmlSchemaForm.Unqualified)> _
    Public Property Sign As String
       Get
          Return _Sign
       End Get
       Set(ByVal Value As String)
          _Sign = Value
       End Set
    End Property
    Private _Sign As String

    '@ <summary>
    '@ Flag: field to be displayed on the screen
    '@ </summary>
 
    <RfcField(AbapName := "DYNPFLD", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 534, Offset2 := 1068), _
    XmlElement("DYNPFLD", Form := XmlSchemaForm.Unqualified)> _
    Public Property Dynpfld As String
       Get
          Return _Dynpfld
       End Get
       Set(ByVal Value As String)
          _Dynpfld = Value
       End Set
    End Property
    Private _Dynpfld As String

    '@ <summary>
    '@ Does the field have an input help
    '@ </summary>
 
    <RfcField(AbapName := "F4AVAILABL", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 535, Offset2 := 1070), _
    XmlElement("F4AVAILABL", Form := XmlSchemaForm.Unqualified)> _
    Public Property F4availabl As String
       Get
          Return _F4availabl
       End Get
       Set(ByVal Value As String)
          _F4availabl = Value
       End Set
    End Property
    Private _F4availabl As String

    '@ <summary>
    '@ DD: Component Type
    '@ </summary>
 
    <RfcField(AbapName := "COMPTYPE", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 536, Offset2 := 1072), _
    XmlElement("COMPTYPE", Form := XmlSchemaForm.Unqualified)> _
    Public Property Comptype As String
       Get
          Return _Comptype
       End Get
       Set(ByVal Value As String)
          _Comptype = Value
       End Set
    End Property
    Private _Comptype As String

    '@ <summary>
    '@ Field name
    '@ </summary>
 
    <RfcField(AbapName := "LFIELDNAME", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 132, Length2 := 264, Offset := 537, Offset2 := 1074), _
    XmlElement("LFIELDNAME", Form := XmlSchemaForm.Unqualified)> _
    Public Property Lfieldname As String
       Get
          Return _Lfieldname
       End Get
       Set(ByVal Value As String)
          _Lfieldname = Value
       End Set
    End Property
    Private _Lfieldname As String

    '@ <summary>
    '@ Basic write direction has been defined LTR (left-to-right)
    '@ </summary>
 
    <RfcField(AbapName := "LTRFLDDIS", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 669, Offset2 := 1338), _
    XmlElement("LTRFLDDIS", Form := XmlSchemaForm.Unqualified)> _
    Public Property Ltrflddis As String
       Get
          Return _Ltrflddis
       End Get
       Set(ByVal Value As String)
          _Ltrflddis = Value
       End Set
    End Property
    Private _Ltrflddis As String

    '@ <summary>
    '@ DD: No Filtering of BIDI Formatting Characters
    '@ </summary>
 
    <RfcField(AbapName := "BIDICTRLC", RfcType := RFCTYPE.RFCTYPE_CHAR, Length := 1, Length2 := 2, Offset := 670, Offset2 := 1340), _
    XmlElement("BIDICTRLC", Form := XmlSchemaForm.Unqualified)> _
    Public Property Bidictrlc As String
       Get
          Return _Bidictrlc
       End Get
       Set(ByVal Value As String)
          _Bidictrlc = Value
       End Set
    End Property
    Private _Bidictrlc As String
  End Class
