Imports System.Runtime.CompilerServices
Imports com.calitha.goldparser

Module TokenExtensions
  <Extension()>
  Public Function Childs(ByVal Token As NonterminalToken, ByVal SymbolName As String, Optional ByVal Recursive As Boolean = False) As List(Of Token)
    Dim Result = New List(Of Token)
    For Each ChildToken In Token.Tokens
      If TypeOf ChildToken Is NonterminalToken Then
        If CType(ChildToken, NonterminalToken).Symbol.Name = SymbolName Then
          Result.Add(ChildToken)
        End If
        If Recursive Then
          Result.AddRange(CType(ChildToken, NonterminalToken).Childs(SymbolName, Recursive))
        End If
      ElseIf TypeOf ChildToken Is TerminalToken Then
        If CType(ChildToken, TerminalToken).Symbol.Name = SymbolName Then
          Result.Add(ChildToken)
        End If
      End If
    Next
    Return Result
  End Function

  <Extension()>
  Public Function NonTerminalChilds(ByVal Token As NonterminalToken, ByVal SymbolName As String, Optional ByVal Recursive As Boolean = False) As List(Of NonterminalToken)
    Dim Result = New List(Of NonterminalToken)
    For Each ChildToken In Token.Tokens
      If TypeOf ChildToken Is NonterminalToken Then
        If CType(ChildToken, NonterminalToken).Symbol.Name = SymbolName Then
          Result.Add(ChildToken)
        End If
        If Recursive Then
          Result.AddRange(CType(ChildToken, NonterminalToken).NonTerminalChilds(SymbolName, Recursive))
        End If
      End If
    Next
    Return Result
  End Function

  <Extension()>
  Public Function TerminalChilds(ByVal Token As NonterminalToken, ByVal SymbolName As String, Optional ByVal Recursive As Boolean = False) As List(Of TerminalToken)
    Dim Result = New List(Of TerminalToken)
    For Each ChildToken In Token.Tokens
      If TypeOf ChildToken Is NonterminalToken Then
        If Recursive Then
          Result.AddRange(CType(ChildToken, NonterminalToken).TerminalChilds(SymbolName, Recursive))
        End If
      ElseIf TypeOf ChildToken Is TerminalToken Then
        If CType(ChildToken, TerminalToken).Symbol.Name = SymbolName Then
          Result.Add(ChildToken)
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
