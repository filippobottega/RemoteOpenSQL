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
'@ A typed collection of ROS_PARSE_NODE elements.
'@ </summary>
<Serializable()> _
Public Class ROS_PARSE_NODETable
  Inherits SAPTable

  '@ <summary>
  '@ Returns the element type ROS_PARSE_NODE.
  '@ </summary>
  '@ <returns>The type ROS_PARSE_NODE.</returns>
  Public Overloads Overrides Function GetElementType() As Type
    Return GetType(ROS_PARSE_NODE)
  End Function

  '@ <summary>
  '@ Creates an empty new row of type ROS_PARSE_NODE.
  '@ </summary>
  '@ <returns>The newROS_PARSE_NODE.</returns>
  Public Overrides Function CreateNewRow() As Object
    Return New ROS_PARSE_NODE()
  End Function

  '@ <summary>
  '@ The indexer of the collection.
  '@ </summary>
  Default Public Property Item(ByVal Index As Integer) As ROS_PARSE_NODE
    Get
      Return CType(List(Index), ROS_PARSE_NODE)
    End Get
    Set(ByVal Value As ROS_PARSE_NODE)
      List(Index) = Value
    End Set
  End Property

  '@ <summary>
  '@ Adds a ROS_PARSE_NODE to the end of the collection.
  '@ </summary>
  '@ <param name="value">The ROS_PARSE_NODE to be added to the end of the collection.</param>
  '@ <returns>The index of the newROS_PARSE_NODE.</returns>
  Public Function Add(ByVal Value As ROS_PARSE_NODE) As Integer
    Return List.Add(Value)
  End Function

  '@ <summary>
  '@ Inserts a ROS_PARSE_NODE into the collection at the specified index.
  '@ </summary>
  '@ <param name="index">The zero-based index at which value should be inserted.</param>
  '@ <param name="value">The ROS_PARSE_NODE to insert.</param>
  Public Sub Insert(ByVal Index As Integer, ByVal Value As ROS_PARSE_NODE)
    List.Insert(Index, Value)
  End Sub

  '@ <summary>
  '@ Searches for the specified ROS_PARSE_NODE and returnes the zero-based index of the first occurrence in the collection.
  '@ </summary>
  '@ <param name="value">The ROS_PARSE_NODE to locate in the collection.</param>
  '@ <returns>The index of the object found or -1.</returns>
  Public Function IndexOf(ByVal Value As ROS_PARSE_NODE) As Integer
    Return List.IndexOf(Value)
  End Function

  '@ <summary>
  '@ Determines wheter an element is in the collection.
  '@ </summary>
  '@ <param name="value">The ROS_PARSE_NODE to locate in the collection.</param>
  '@ <returns>True if found; else false.</returns>
  Public Function Contains(ByVal Value As ROS_PARSE_NODE) As Boolean
    Return List.Contains(Value)
  End Function

  '@ <summary>
  '@ Removes the first occurrence of the specified ROS_PARSE_NODE from the collection.
  '@ </summary>
  '@ <param name="value">The ROS_PARSE_NODE to remove from the collection.</param>
  Public Sub Remove(ByVal Value As ROS_PARSE_NODE)
    List.Remove(Value)
  End Sub

  '@ <summary>
  '@ Copies the contents of the ROS_PARSE_NODETable to the specified one-dimensional array starting at the specified index in the target array.
  '@ </summary>
  '@ <param name="array">The one-dimensional destination array.</param>           
  '@ <param name="index">The zero-based index in array at which copying begins.</param>           
  Public Sub CopyTo(ByVal Array() As ROS_PARSE_NODE, ByVal Index As Integer)
    List.CopyTo(Array, Index)
  End Sub
End Class
