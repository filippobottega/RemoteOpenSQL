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
Imports System.Web.Services
Imports System.Web.Services.Description
Imports System.Web.Services.Protocols
Imports SAP.Connector



  '@ <summary>
  '@ A typed collection of DDFIXVALUE elements.
  '@ </summary>
  <Serializable> _
  Public Class DDFIXVALUES 
    Inherits SAPTable 
  
    '@ <summary>
    '@ Returns the element type DDFIXVALUE.
    '@ </summary>
    '@ <returns>The type DDFIXVALUE.</returns>
    Public Overloads Overrides Function GetElementType() As Type
        Return GetType(DDFIXVALUE)
    End Function

    '@ <summary>
    '@ Creates an empty new row of type DDFIXVALUE.
    '@ </summary>
    '@ <returns>The newDDFIXVALUE.</returns>
    Overrides Public Function CreateNewRow() As Object 
        Return new DDFIXVALUE()
    End Function
     
    '@ <summary>
    '@ The indexer of the collection.
    '@ </summary>
    Default Public Property Item(ByVal Index As Integer) As DDFIXVALUE 
        Get 
            Return CType(List(Index), DDFIXVALUE)
        End Get
        Set(ByVal Value As DDFIXVALUE)
            List(Index) = Value
        End Set
    End Property
        
    '@ <summary>
    '@ Adds a DDFIXVALUE to the end of the collection.
    '@ </summary>
    '@ <param name="value">The DDFIXVALUE to be added to the end of the collection.</param>
    '@ <returns>The index of the newDDFIXVALUE.</returns>
    Public Function Add(ByVal Value As DDFIXVALUE) As Integer 
        Return List.Add(Value)
    End Function
        
    '@ <summary>
    '@ Inserts a DDFIXVALUE into the collection at the specified index.
    '@ </summary>
    '@ <param name="index">The zero-based index at which value should be inserted.</param>
    '@ <param name="value">The DDFIXVALUE to insert.</param>
    Public Sub Insert(ByVal Index As Integer, ByVal Value As DDFIXVALUE) 
        List.Insert(Index, value)
    End Sub
        
    '@ <summary>
    '@ Searches for the specified DDFIXVALUE and returnes the zero-based index of the first occurrence in the collection.
    '@ </summary>
    '@ <param name="value">The DDFIXVALUE to locate in the collection.</param>
    '@ <returns>The index of the object found or -1.</returns>
    Public Function IndexOf(ByVal Value As DDFIXVALUE) As Integer
        Return List.IndexOf(value)
    End Function
        
    '@ <summary>
    '@ Determines wheter an element is in the collection.
    '@ </summary>
    '@ <param name="value">The DDFIXVALUE to locate in the collection.</param>
    '@ <returns>True if found; else false.</returns>
    Public Function Contains(ByVal Value As DDFIXVALUE) As Boolean
        Return List.Contains(value)
    End Function
        
    '@ <summary>
    '@ Removes the first occurrence of the specified DDFIXVALUE from the collection.
    '@ </summary>
    '@ <param name="value">The DDFIXVALUE to remove from the collection.</param>
    Public Sub Remove(ByVal Value As DDFIXVALUE) 
        List.Remove(value)
    End Sub

    '@ <summary>
    '@ Copies the contents of the DDFIXVALUES to the specified one-dimensional array starting at the specified index in the target array.
    '@ </summary>
    '@ <param name="array">The one-dimensional destination array.</param>           
    '@ <param name="index">The zero-based index in array at which copying begins.</param>           
    Public Sub CopyTo(ByVal Array() As DDFIXVALUE, ByVal Index As Integer) 
        List.CopyTo(array, index)
    End Sub
  End Class
