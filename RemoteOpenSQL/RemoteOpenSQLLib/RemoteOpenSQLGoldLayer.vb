Imports com.calitha.goldparser
Imports RemoteOpenSQL.SapNetConnector2Proxy2010
Imports System.Text

Partial Public Class RemoteOpenSQL

  Private Function GetTableItems(ByVal ParseTree As NonterminalToken) As Dictionary(Of String, TableItem)
    Dim Result = New Dictionary(Of String, TableItem)
    For Each TableItemToken In ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("From Clause").NonTerminalChilds("Table Item", True)
      Dim TableName As String = ""
      For Each TerminalToken In TableItemToken.NonTerminalChild("Table Name").TerminalChilds
        TableName = TerminalToken.Text
      Next
      Dim TableAlias As String = ""
      Dim TableAliasToken As NonterminalToken = TableItemToken.NonTerminalChild("Table Alias")
      If Not TableAliasToken Is Nothing Then
        For Each TerminalToken In TableItemToken.NonTerminalChild("Table Alias").TerminalChilds
          TableAlias = TerminalToken.Text
        Next
      End If
      Dim TableItem = New TableItem(TableName, TableAlias)
      Result.Add(TableItem.UniqueName, TableItem)
    Next
    Return Result
  End Function

  Private Function GetFieldItems(ByVal ParseTree As NonterminalToken, TableItems As Dictionary(Of String, TableItem)) As FieldItems
    Dim Result = New FieldItems
    For Each ColumnItemToken In ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("Columns").NonTerminalChilds("Column Item", True)
      Dim ColumnAlias As String = ""
      Dim ColumnAliasToken As NonterminalToken = ColumnItemToken.NonTerminalChild("Column Alias")
      If Not ColumnAliasToken Is Nothing Then
        For Each TerminalToken In ColumnItemToken.NonTerminalChild("Column Alias").TerminalChilds
          ColumnAlias = TerminalToken.Text
        Next
      End If
      Dim ColumnName As String = ""
      For Each TerminalToken In ColumnItemToken.NonTerminalChild("Column Name").TerminalChilds
        ColumnName = TerminalToken.Text
      Next
      Dim ColumnNameTokens = Split(ColumnName, "~")
      Dim TableNameOrAlias As String = String.Empty
      Dim FieldName As String = String.Empty
      If ColumnNameTokens.Count = 1 Then
        FieldName = ColumnNameTokens(0)
      Else
        TableNameOrAlias = ColumnNameTokens(0)
        FieldName = ColumnNameTokens(1)
      End If

      ' Determino l'oggetto tabella associato
      Dim TableItem As TableItem = Nothing
      If TableNameOrAlias <> String.Empty Then
        If TableItems.ContainsKey(TableNameOrAlias) Then
          TableItem = TableItems(TableNameOrAlias)
        Else
          Throw New RemoteOpenSQLException("Table " & TableNameOrAlias & " not found.")
        End If
      Else
        ' Cerco la prima tabella contenente il nome del campo
        For Each TableItem In TableItems.Values
          If TableItem.DFIESTableIndex.ContainsKey(FieldName) Then
            TableItem = TableItem
            Exit For
          End If
        Next
        If TableItem Is Nothing Then
          Throw New RemoteOpenSQLException("Table not found for column " & ColumnName & ".")
        End If
      End If

      Result.Add(TableItem.GetFieldItem(FieldName, ColumnName, ColumnAlias, True))
    Next

    If Result.Count = 0 Then
      If ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("Columns").TerminalChild(" *") Is Nothing Then
        Throw New RemoteOpenSQLException("Select at least one field or use * wildchar.")
      End If

      Result.AsteriskWildcard = True

      For Each TableItem In TableItems.Values
        TableItem.AddAllFields(Result)
      Next

      If Result.Count = 0 Then
        Throw New RemoteOpenSQLException("Select at least one field and one table with at least one field.")
      End If
    End If

    Return Result
  End Function

  Private Function GetOrderNames(ByVal ParseTree As NonterminalToken) As List(Of String)
    Dim Result = New List(Of String)
    For Each OrderNameToken In ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("Order Clause").NonTerminalChilds("Order Name", True)
      For Each Token In OrderNameToken.TerminalChilds
        Result.Add(Token.Text)
      Next
    Next
    Return Result
  End Function

  Private Function GetOrderByPrimaryKey(ByVal ParseTree As NonterminalToken) As Boolean
    Return ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("Order Clause").Rule.ToString = "<Order Clause> ::= ORDER BY PRIMARY KEY"
  End Function

  Private Function GetClientSpecified(ByVal ParseTree As NonterminalToken) As Boolean
    Return ParseTree.NonTerminalChild("Select Stm").NonTerminalChild("From Clause").NonTerminalChild("Client Specified Clause").Rule.ToString = "<Client Specified Clause> ::= CLIENT SPECIFIED"
  End Function

  Private Function RebuildQuery(ByVal ParseTree As NonterminalToken, Optional ByVal SymbolNameToSkip As String = "") As String
    Dim TokenStack = New Stack(Of Token)
    Dim Result = New StringBuilder

    TokenStack.Push(ParseTree)
    Do While TokenStack.Count > 0
      Dim CurrToken = TokenStack.Pop
      If TypeOf CurrToken Is TerminalToken Then
        Dim CurrTerminalToken = CType(CurrToken, TerminalToken)
        If CurrTerminalToken.Symbol.Name <> SymbolNameToSkip Then
          If Result.Length > 0 AndAlso Left(CurrTerminalToken.Text, 1) <> " " Then
            Result.Append(" ")
          End If
          Result.Append(CurrTerminalToken.Text)
        End If
      ElseIf TypeOf CurrToken Is NonterminalToken Then
        Dim CurrNonterminalToken = CType(CurrToken, NonterminalToken)
        If CurrNonterminalToken.Symbol.Name <> SymbolNameToSkip Then
          For Count = CurrNonterminalToken.Tokens.Length - 1 To 0 Step -1
            TokenStack.Push(CurrNonterminalToken.Tokens(Count))
          Next
        End If
      End If
    Loop

    Return Result.ToString
  End Function

  Private Sub FillParseTreeTable(ByVal ParseTree As NonterminalToken, ByVal ParseTreeTable As ROS_PARSE_NODETable)
    Dim TokenStack = New Stack(Of Token)
    Dim IdStack = New Stack(Of Integer)
    Dim CurrentId = 0

    TokenStack.Push(ParseTree)
    IdStack.Push(0)

    Do While TokenStack.Count > 0
      Dim CurrToken = TokenStack.Pop
      CurrentId += 1
      Dim FatherId = IdStack.Pop
      Dim ParseTreeLine = New ROS_PARSE_NODE

      With ParseTreeLine
        .Id = CurrentId
        .Parent = FatherId
        If TypeOf CurrToken Is TerminalToken Then
          .Symbol = CType(CurrToken, TerminalToken).Symbol.Name
          .Text_Or_Rule = CType(CurrToken, TerminalToken).Text
          .Terminal = "X"
        ElseIf TypeOf CurrToken Is NonterminalToken Then
          Dim CurrNonterminalToken = CType(CurrToken, NonterminalToken)
          Dim RuleTokens = Split(CurrNonterminalToken.Rule.ToString, "::=")
          .Symbol = Left(RuleTokens(0), Len(RuleTokens(0)) - 1)
          .Text_Or_Rule = Mid(RuleTokens(1), 2)
          .Terminal = ""
          For Count = CurrNonterminalToken.Tokens.Length - 1 To 0 Step -1
            TokenStack.Push(CurrNonterminalToken.Tokens(Count))
            IdStack.Push(CurrentId)
          Next
        End If
      End With

      ParseTreeTable.Add(ParseTreeLine)
    Loop

  End Sub

  Private Function ParseQuery(ByVal GrammarReader As CGTReader, ByVal Query As String) As NonterminalToken
    If Query = String.Empty Then
      Throw New RemoteOpenSQLException("Query is empty")
    End If

    ' Parse Query
    Dim LALRParser = GrammarReader.CreateNewParser
    AddHandler LALRParser.OnParseError, Sub(parser As com.calitha.goldparser.LALRParser, args As com.calitha.goldparser.ParseErrorEventArgs)
                                          Throw New RemoteOpenSQLException("Parse error caused by token: '" + args.UnexpectedToken.ToString() + "'")
                                        End Sub
    Dim ParseTree = LALRParser.Parse(Query)

    If ParseTree Is Nothing Then
      Throw New RemoteOpenSQLException("Parse error")
    End If

    Return ParseTree
  End Function


  Private Function GetParseTreeStep1(ByVal RemoteOpenSQLParseTree As NonterminalToken, FieldItems As FieldItems) As NonterminalToken
    ' Costruisco la stringa contenente la query per il passo 1
    Dim QueryStep1 = "SELECT"

    With RemoteOpenSQLParseTree.NonTerminalChild("Select Stm")
      Dim Columns = RebuildQuery(.NonTerminalChild("Columns"))
      If Columns <> " *" Then
        For Each FieldItem In FieldItems.AsEnumerable
          QueryStep1 += " " & FieldItem.ColumnNameAndAlias
        Next
      Else
        JoinQuerySteps(QueryStep1, Columns)
      End If
      JoinQuerySteps(QueryStep1, RebuildQuery(.NonTerminalChild("From Clause")))
      JoinQuerySteps(QueryStep1, "UP TO uptorows ROWS")
      JoinQuerySteps(QueryStep1, "INTO CORRESPONDING FIELDS OF TABLE ta_lines")
      JoinQuerySteps(QueryStep1, RebuildQuery(.NonTerminalChild("Where Clause")))
      JoinQuerySteps(QueryStep1, RebuildQuery(.NonTerminalChild("Order Clause")))
    End With

    ' Parse Query
    Return ParseQuery(SapOpenSQLGrammarReader, QueryStep1)
  End Function

  Private Sub JoinQuerySteps(ByRef QueryStep1 As String, ByRef QueryStepN As String)
    If Right(QueryStep1, 1) <> " " AndAlso Left(QueryStepN, 1) <> " " Then
      QueryStep1 += " " & QueryStepN
    Else
      QueryStep1 += QueryStepN
    End If
  End Sub

  Private Function GetParseTreeStepN(ByVal RemoteOpenSQLParseTree As NonterminalToken, FieldItems As FieldItems) As NonterminalToken
    ' Costruisco la stringa contenente la query per il passo 1
    Dim QueryStepN = "SELECT"

    With RemoteOpenSQLParseTree.NonTerminalChild("Select Stm")
      Dim Columns = RebuildQuery(.NonTerminalChild("Columns"))
      If Columns <> " *" Then
        For Each FieldItem In FieldItems.AsEnumerable
          QueryStepN += " " & FieldItem.ColumnNameAndAlias
        Next
      Else
        JoinQuerySteps(QueryStepN, Columns)
      End If
      JoinQuerySteps(QueryStepN, RebuildQuery(.NonTerminalChild("From Clause")))
      JoinQuerySteps(QueryStepN, "UP TO uptorows ROWS")
      JoinQuerySteps(QueryStepN, "INTO CORRESPONDING FIELDS OF TABLE ta_lines")
      Dim WhereExpression = Trim(RebuildQuery(.NonTerminalChild("Where Clause").NonTerminalChild("Expression")))
      QueryStepN += " WHERE"
      If WhereExpression <> String.Empty Then
        QueryStepN += " ( " & WhereExpression & " ) AND"
      End If
      '(
      '(A > 0)
      ' OR (A = 0 AND B > 0) 
      ' OR (A = 0 AND B = 0 AND C > 0) 
      ' OR (A = 0 AND B = 0 AND C = 0 AND D >= 0) 
      ')

      Dim OrderFields = New List(Of FieldItem)
      For Each FieldItem In FieldItems.AsEnumerable
        If FieldItem.OrderName <> String.Empty Then
          OrderFields.Add(FieldItem)
        End If
      Next

      QueryStepN += " ("
      ' Ciclo degli OR
      For OrCount = 0 To OrderFields.Count - 1
        If OrCount = 0 Then
          QueryStepN += " ("
        Else
          QueryStepN += " OR ("
        End If
        ' Ciclo degli AND
        For AndCount = 0 To OrCount
          If AndCount > 0 Then
            QueryStepN += " AND"
          End If
          Dim OrderField = OrderFields(AndCount)
          Dim LogicalOperator As String
          If OrCount = OrderFields.Count - 1 And AndCount = OrderFields.Count - 1 Then
            LogicalOperator = ">="
          ElseIf AndCount = OrCount Then
            LogicalOperator = ">"
          Else
            LogicalOperator = "="
          End If
          QueryStepN += " " & OrderField.OrderName & " " & LogicalOperator & " wa_orderby-" & OrderField.AbapName
        Next
        QueryStepN += " )"
      Next
      QueryStepN += " )"

      JoinQuerySteps(QueryStepN, RebuildQuery(.NonTerminalChild("Order Clause")))
    End With

    ' Parse Query
    Return ParseQuery(SapOpenSQLGrammarReader, QueryStepN)
  End Function
End Class
