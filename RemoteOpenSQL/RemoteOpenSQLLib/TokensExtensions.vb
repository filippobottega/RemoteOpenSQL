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

Imports System.Runtime.CompilerServices
Imports com.calitha.goldparser

Module TokenExtensions
  <Extension()>
  Public Function Childs(ByVal Token As NonterminalToken, Optional ByVal SymbolName As String = "", Optional ByVal Recursive As Boolean = False) As List(Of Token)
    Dim Result = New List(Of Token)
    For Each ChildToken In Token.Tokens
      If TypeOf ChildToken Is NonterminalToken Then
        If SymbolName = String.Empty Then
          Result.Add(ChildToken)
        Else
          If CType(ChildToken, NonterminalToken).Symbol.Name = SymbolName Then
            Result.Add(ChildToken)
          End If
        End If
        If Recursive Then
          Result.AddRange(CType(ChildToken, NonterminalToken).Childs(SymbolName, Recursive))
        End If
      ElseIf TypeOf ChildToken Is TerminalToken Then
        If SymbolName = String.Empty Then
          Result.Add(ChildToken)
        Else
          If CType(ChildToken, TerminalToken).Symbol.Name = SymbolName Then
            Result.Add(ChildToken)
          End If
        End If
      End If
    Next
    Return Result
  End Function

  <Extension()>
  Public Function NonTerminalChilds(ByVal Token As NonterminalToken, Optional ByVal SymbolName As String = "", Optional ByVal Recursive As Boolean = False) As List(Of NonterminalToken)
    Dim Result = New List(Of NonterminalToken)
    For Each ChildToken In Token.Tokens
      If TypeOf ChildToken Is NonterminalToken Then
        If SymbolName = String.Empty Then
          Result.Add(ChildToken)
        Else
          If CType(ChildToken, NonterminalToken).Symbol.Name = SymbolName Then
            Result.Add(ChildToken)
          End If
        End If
        If Recursive Then
          Result.AddRange(CType(ChildToken, NonterminalToken).NonTerminalChilds(SymbolName, Recursive))
        End If
      End If
    Next
    Return Result
  End Function

  <Extension()>
  Public Function TerminalChilds(ByVal Token As NonterminalToken, Optional ByVal SymbolName As String = "", Optional ByVal Recursive As Boolean = False) As List(Of TerminalToken)
    Dim Result = New List(Of TerminalToken)
    For Each ChildToken In Token.Tokens
      If TypeOf ChildToken Is NonterminalToken Then
        If Recursive Then
          Result.AddRange(CType(ChildToken, NonterminalToken).TerminalChilds(SymbolName, Recursive))
        End If
      ElseIf TypeOf ChildToken Is TerminalToken Then
        If SymbolName = String.Empty Then
          Result.Add(ChildToken)
        Else
          If CType(ChildToken, TerminalToken).Symbol.Name = SymbolName Then
            Result.Add(ChildToken)
          End If
        End If
      End If
    Next
    Return Result
  End Function

  <Extension()>
  Public Function Child(ByVal Token As NonterminalToken, ByVal SymbolName As String) As Token
    For Each ChildToken In Token.Tokens
      If TypeOf ChildToken Is NonterminalToken Then
        If CType(ChildToken, NonterminalToken).Symbol.Name = SymbolName Then
          Return ChildToken
        End If
      ElseIf TypeOf ChildToken Is TerminalToken Then
        If CType(ChildToken, TerminalToken).Symbol.Name = SymbolName Then
          Return ChildToken
        End If
      End If
    Next
    Return Nothing
  End Function

  <Extension()>
  Public Function NonTerminalChild(ByVal Token As NonterminalToken, ByVal SymbolName As String) As NonterminalToken
    For Each ChildToken In Token.Tokens
      If TypeOf ChildToken Is NonterminalToken Then
        If CType(ChildToken, NonterminalToken).Symbol.Name = SymbolName Then
          Return ChildToken
        End If
      End If
    Next
    Return Nothing
  End Function

  <Extension()>
  Public Function TerminalChild(ByVal Token As NonterminalToken, ByVal SymbolName As String) As TerminalToken
    For Each ChildToken In Token.Tokens
      If TypeOf ChildToken Is TerminalToken Then
        If CType(ChildToken, TerminalToken).Symbol.Name = SymbolName Then
          Return ChildToken
        End If
      End If
    Next
    Return Nothing
  End Function
End Module
