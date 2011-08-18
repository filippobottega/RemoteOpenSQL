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
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Xml.Serialization
Imports System.Xml.Schema
Imports System.Web.Services
Imports System.Web.Services.Description
Imports System.Web.Services.Protocols
Imports SAP.Connector


  '@ <summary>
  '@ Client SAP proxy class
  '@ </summary>
  <WebServiceBinding(Name:="dummy.Binding", Namespace:="urn:sap-com:document:sap:rfc:functions")> _
  Public Class SAPProxyClient 
    Inherits SAPClient

    '@ <summary>
    '@ Initializes a new SAPProxyClient.
    '@ </summary>
    Public Sub New()
    End Sub

    '@ <summary>
    '@ Initializes a new SAPProxyClient with a new connection based on the specified connection string.
    '@ </summary>
    '@ <param name="connectionString">A connection string (e.g. RFC or URL) specifying the system where the proxy should connect to.</param>
    Public Sub New(ByVal ConnectionString As String) 
      MyBase.New(ConnectionString)
    End Sub
    
    '@ <summary>
    '@ Initializes a new SAPProxyClient and adds it to the given container.
    '@ This allows automated connection mananged by VS component designer:
    '@ If container is disposed, it will also dispose this SAPClient instance,
    '@ which will dispose a contained connection if needed.
    '@ </summary>
    '@ <param name="Cont">The container where the new SAPClient instance is to be added.</param>
    Public Sub New(ByVal Cont As Container) 
      MyBase.New(Cont)
    End Sub
  
    '@ <summary>
    '@ Exception constant for ABAP-Exception INTERNAL_ERROR
    '@ </summary>
    Public Const Internal_Error As String = "INTERNAL_ERROR"
   
    '@ <summary>
    '@ Exception constant for ABAP-Exception NOT_FOUND
    '@ </summary>
    Public Const Not_Found As String = "NOT_FOUND"
   
    '@ <summary>
    '@ Remote Function Module DDIF_FIELDINFO_GET.  
    '@ DD: Interface for Reading Text on Tables or Types
    '@ </summary>
    '@ <param name="Ddobjtype">Kind of Type</param>
    '@ <param name="Dfies_Wa">Single Information if Necessary</param>
    '@ <param name="Lines_Descr">Information about Other Referenced Types</param>
    '@ <param name="X030l_Wa">Nametab Header of the Table (of the Type)</param>
    '@ <param name="All_Types">Take all Types into Consideration</param>
    '@ <param name="Fieldname">Use Parameter LFIELDNAME Instead</param>
    '@ <param name="Group_Names">Take Named Includes into Consideration</param>
    '@ <param name="Langu">Language of the Texts</param>
    '@ <param name="Lfieldname">If Filled, only Field with this Long Name</param>
    '@ <param name="Tabname">Name of the Table (of the Type) for which Information is Required</param>
    '@ <param name="Uclen">Unicode length with which runtime object was generated</param>
    '@ <param name="Dfies_Tab">Field List if Necessary</param>
    '@ <param name="Fixed_Values">Description of Domain Fixed Values</param> 
    '@ <exception cref="Internal_Error"/> 
    '@ <exception cref="Not_Found"/>
    <RfcMethod(AbapName := "DDIF_FIELDINFO_GET"), _
    SoapDocumentMethodAttribute("http://tempuri.org/DDIF_FIELDINFO_GET", _
     RequestNamespace := "urn:sap-com:document:sap:rfc:functions", _
     RequestElementName := "DDIF_FIELDINFO_GET", _
     ResponseNamespace := "urn:sap-com:document:sap:rfc:functions", _
     ResponseElementName := "DDIF_FIELDINFO_GET.Response")> _
    Public Overridable Sub Ddif_Fieldinfo_Get ( _
     <RfcParameter(AbapName := "ALL_TYPES", RfcType := RFCTYPE.RFCTYPE_CHAR, Optional := true, Direction := RFCINOUT.IN, Length := 1, Length2 := 2), _
     XmlElement("ALL_TYPES", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByVal All_Types As String, _
     <RfcParameter(AbapName := "FIELDNAME", RfcType := RFCTYPE.RFCTYPE_CHAR, Optional := true, Direction := RFCINOUT.IN, Length := 30, Length2 := 60), _
     XmlElement("FIELDNAME", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByVal Fieldname As String, _
     <RfcParameter(AbapName := "GROUP_NAMES", RfcType := RFCTYPE.RFCTYPE_CHAR, Optional := true, Direction := RFCINOUT.IN, Length := 1, Length2 := 2), _
     XmlElement("GROUP_NAMES", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByVal Group_Names As String, _
     <RfcParameter(AbapName := "LANGU", RfcType := RFCTYPE.RFCTYPE_CHAR, Optional := true, Direction := RFCINOUT.IN, Length := 1, Length2 := 2), _
     XmlElement("LANGU", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByVal Langu As String, _
     <RfcParameter(AbapName := "LFIELDNAME", RfcType := RFCTYPE.RFCTYPE_CHAR, Optional := true, Direction := RFCINOUT.IN, Length := 132, Length2 := 264), _
     XmlElement("LFIELDNAME", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByVal Lfieldname As String, _
     <RfcParameter(AbapName := "TABNAME", RfcType := RFCTYPE.RFCTYPE_CHAR, Optional := false, Direction := RFCINOUT.IN, Length := 30, Length2 := 60), _
     XmlElement("TABNAME", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByVal Tabname As String, _
     <RfcParameter(AbapName := "UCLEN", RfcType := RFCTYPE.RFCTYPE_BYTE, Optional := true, Direction := RFCINOUT.IN, Length := 1, Length2 := 1), _
     XmlElement("UCLEN", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByVal Uclen As Byte(), _
     <RfcParameter(AbapName := "DDOBJTYPE", RfcType := RFCTYPE.RFCTYPE_CHAR, Optional := true, Direction := RFCINOUT.OUT, Length := 8, Length2 := 16), _
     XmlElement("DDOBJTYPE", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByRef Ddobjtype As String, _
     <RfcParameter(AbapName := "DFIES_WA",RfcType := RFCTYPE.RFCTYPE_STRUCTURE, Optional := true, Direction := RFCINOUT.OUT), _
     XmlElement("DFIES_WA", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByRef Dfies_Wa As DFIES, _
     <RfcParameter(AbapName := "LINES_DESCR",RfcType := RFCTYPE.RFCTYPE_XMLDATA, Optional := true, Direction := RFCINOUT.OUT), _
     XmlArray("LINES_DESCR", IsNullable := False, Form := XmlSchemaForm.Unqualified), _
     XmlArrayItem("item", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByRef Lines_Descr As DDTYPELIST, _
     <RfcParameter(AbapName := "X030L_WA",RfcType := RFCTYPE.RFCTYPE_STRUCTURE, Optional := true, Direction := RFCINOUT.OUT), _
     XmlElement("X030L_WA", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByRef X030l_Wa As X030L, _
     <RfcParameter(AbapName := "DFIES_TAB",RfcType := RFCTYPE.RFCTYPE_ITAB, Optional := true, Direction := RFCINOUT.INOUT), _
     XmlArray("DFIES_TAB", IsNullable := False, Form := XmlSchemaForm.Unqualified), _
     XmlArrayItem("item", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByRef Dfies_Tab As DFIESTable, _
     <RfcParameter(AbapName := "FIXED_VALUES",RfcType := RFCTYPE.RFCTYPE_ITAB, Optional := true, Direction := RFCINOUT.INOUT), _
     XmlArray("FIXED_VALUES", IsNullable := False, Form := XmlSchemaForm.Unqualified), _
     XmlArrayItem("item", IsNullable := False, Form := XmlSchemaForm.Unqualified)> _
     ByRef Fixed_Values As DDFIXVALUES)
        Dim results As Object()
        results = SAPInvoke("Ddif_Fieldinfo_Get", new Object() { _
                            All_Types,Fieldname,Group_Names,Langu,Lfieldname,Tabname,Uclen,Dfies_Tab,Fixed_Values })
        Ddobjtype = CType(results(0), String) 
        Dfies_Wa = CType(results(1), DFIES) 
        Lines_Descr = CType(results(2), DDTYPELIST) 
        X030l_Wa = CType(results(3), X030L) 
        Dfies_Tab = CType(results(4), DFIESTable) 
        Fixed_Values = CType(results(5), DDFIXVALUES) 

    End Sub

    '@ <summary>
    '@ Structure for the Input-parameters of DDIF_FIELDINFO_GET
    '@ </summary>
    Public Class Ddif_Fieldinfo_Get_Input
      '@ <summary>
      '@ Take all Types into Consideration
      '@ </summary>
      Public All_Types As String
      '@ <summary>
      '@ Use Parameter LFIELDNAME Instead
      '@ </summary>
      Public Fieldname As String
      '@ <summary>
      '@ Take Named Includes into Consideration
      '@ </summary>
      Public Group_Names As String
      '@ <summary>
      '@ Language of the Texts
      '@ </summary>
      Public Langu As String
      '@ <summary>
      '@ If Filled, only Field with this Long Name
      '@ </summary>
      Public Lfieldname As String
      '@ <summary>
      '@ Name of the Table (of the Type) for which Information is Required
      '@ </summary>
      Public Tabname As String
      '@ <summary>
      '@ Unicode length with which runtime object was generated
      '@ </summary>
      Public Uclen As Byte()
      '@ <summary>
      '@ Field List if Necessary
      '@ </summary>
      Public Dfies_Tab As DFIESTable
      '@ <summary>
      '@ Description of Domain Fixed Values
      '@ </summary>
      Public Fixed_Values As DDFIXVALUES
    End Class

    '@ <summary>
    '@ Structure for the Output-parameters of DDIF_FIELDINFO_GET
    '@ </summary>
    Public Class Ddif_Fieldinfo_Get_Output
      '@ <summary>
      '@ Kind of Type
      '@ </summary>
      Public Ddobjtype As String
      '@ <summary>
      '@ Single Information if Necessary
      '@ </summary>
      Public Dfies_Wa As DFIES
      '@ <summary>
      '@ Information about Other Referenced Types
      '@ </summary>
      Public Lines_Descr As DDTYPELIST
      '@ <summary>
      '@ Nametab Header of the Table (of the Type)
      '@ </summary>
      Public X030l_Wa As X030L
      '@ <summary>
      '@ Field List if Necessary
      '@ </summary>
      Public Dfies_Tab As DFIESTable
      '@ <summary>
      '@ Description of Domain Fixed Values
      '@ </summary>
      Public Fixed_Values As DDFIXVALUES
    End Class

    '@ <summary>
    '@ IOStruct-Version of Remote Function Module DDIF_FIELDINFO_GET.  
    '@ </summary>
    '@ <param name="inp">A structure of input parameters.</param>
    '@ <returns>A structure with output parameters.</returns>
    Public Overridable Function Ddif_Fieldinfo_Get_(ByVal inp As Ddif_Fieldinfo_Get_Input) As Ddif_Fieldinfo_Get_Output
      Dim result As Ddif_Fieldinfo_Get_Output = new Ddif_Fieldinfo_Get_Output()

      Ddif_Fieldinfo_Get( _
   inp.All_Types, _
   inp.Fieldname, _
   inp.Group_Names, _
   inp.Langu, _
   inp.Lfieldname, _
   inp.Tabname, _
   inp.Uclen, _
   result.Ddobjtype, _
   result.Dfies_Wa, _
   result.Lines_Descr, _
   result.X030l_Wa, _
   inp.Dfies_Tab, _
   inp.Fixed_Values)
   
      result.Dfies_Tab = inp.Dfies_Tab
      result.Fixed_Values = inp.Fixed_Values
      Return result
    End Function 

    '@ <summary>
    '@ Remote Function Module Z_REMOTE_OPEN_SQL.  
    '@ 
    '@ </summary>
    <RfcMethod(AbapName := "Z_REMOTE_OPEN_SQL"), _
    SoapDocumentMethodAttribute("http://tempuri.org/Z_REMOTE_OPEN_SQL", _
     RequestNamespace := "urn:sap-com:document:sap:rfc:functions", _
     RequestElementName := "Z_REMOTE_OPEN_SQL", _
     ResponseNamespace := "urn:sap-com:document:sap:rfc:functions", _
     ResponseElementName := "Z_REMOTE_OPEN_SQL.Response")> _
    Public Overridable Sub Z_Remote_Open_Sql ( )
        Dim results As Object()
        results = SAPInvoke("Z_Remote_Open_Sql", new Object() { _
                             })

    End Sub

    '@ <summary>
    '@ Structure for the Input-parameters of Z_REMOTE_OPEN_SQL
    '@ </summary>
    Public Class Z_Remote_Open_Sql_Input
    End Class

    '@ <summary>
    '@ Structure for the Output-parameters of Z_REMOTE_OPEN_SQL
    '@ </summary>
    Public Class Z_Remote_Open_Sql_Output
    End Class

    '@ <summary>
    '@ IOStruct-Version of Remote Function Module Z_REMOTE_OPEN_SQL.  
    '@ </summary>
    '@ <param name="inp">A structure of input parameters.</param>
    '@ <returns>A structure with output parameters.</returns>
    Public Overridable Function Z_Remote_Open_Sql_(ByVal inp As Z_Remote_Open_Sql_Input) As Z_Remote_Open_Sql_Output
      Dim result As Z_Remote_Open_Sql_Output = new Z_Remote_Open_Sql_Output()

        Z_Remote_Open_Sql()
   
      Return result
    End Function 

  End Class
