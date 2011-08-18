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

Imports System.Collections.Specialized

Friend Class CompilerServices

  ''' <summary>
  ''' Function to compile .Net C#/VB source codes at runtime
  ''' </summary>
  ''' <param name="codeProvider">Base class for compiler provider</param>
  ''' <param name="sourceCode">C# or VB source code as a string</param>
  ''' <param name="sourceFile">External file containing C# or VB source code</param>
  ''' <param name="exeFile">File path to create external executable file</param>
  ''' <param name="assemblyName">File path to create external assembly file</param>
  ''' <param name="resourceFiles">Required resource files to compile the code</param>
  ''' <param name="errors">String variable to store any errors occurred during the process</param>
  ''' <returns>Return TRUE if successfully compiled the code, else return FALSE</returns>
  Friend Shared Function CompileCode(
      ByVal codeProvider As System.CodeDom.Compiler.CodeDomProvider,
      ByVal sourceCode As String,
      ByVal sourceFile As String,
      ByVal exeFile As String,
      ByVal assemblyName As String,
      ByVal referencedAssemblies As List(Of String),
      ByVal resourceFiles As String(),
      ByRef errors As String) As System.CodeDom.Compiler.CompilerResults

    ' Define parameters to invoke a compiler
    Dim CompilerParameters As New System.CodeDom.Compiler.CompilerParameters()

    If exeFile IsNot Nothing Then
      ' Set the assembly file name to generate.
      CompilerParameters.OutputAssembly = exeFile

      ' Generate an executable instead of a class library.
      CompilerParameters.GenerateExecutable = True
      CompilerParameters.GenerateInMemory = False
    ElseIf assemblyName IsNot Nothing Then
      ' Set the assembly file name to generate.
      CompilerParameters.OutputAssembly = assemblyName

      ' Generate an executable instead of a class library.
      CompilerParameters.GenerateExecutable = False
      CompilerParameters.GenerateInMemory = False
    Else
      ' Generate an executable instead of a class library.
      CompilerParameters.GenerateExecutable = False
      CompilerParameters.GenerateInMemory = True
    End If

#If DEBUG Then
    CompilerParameters.IncludeDebugInformation = True
#Else
    CompilerParameters.IncludeDebugInformation = False
#End If

    If Not referencedAssemblies Is Nothing Then
      CompilerParameters.ReferencedAssemblies.AddRange(referencedAssemblies.ToArray)
    End If

    ' Generate debug information.
    ' CompilerParameters.IncludeDebugInformation = true;

    ' Set the level at which the compiler 
    ' should start displaying warnings.
    CompilerParameters.WarningLevel = 3

    ' Set whether to treat all warnings as errors.
    CompilerParameters.TreatWarningsAsErrors = False

    ' Set compiler argument to optimize output.
    CompilerParameters.CompilerOptions = "/optimize"

    ' Set a temporary files collection.
    ' The TempFileCollection stores the temporary files
    ' generated during a build in the current directory,
    ' and does not delete them after compilation.
#If DEBUG Then
    CompilerParameters.TempFiles = New System.CodeDom.Compiler.TempFileCollection(".", True)
#Else
    CompilerParameters.TempFiles = New System.CodeDom.Compiler.TempFileCollection(".", False)
#End If

    If resourceFiles IsNot Nothing AndAlso resourceFiles.Length > 0 Then
      For Each _ResourceFile As String In resourceFiles
        ' Set the embedded resource file of the assembly.
        CompilerParameters.EmbeddedResources.Add(_ResourceFile)
      Next
    End If


    Try
      ' Invoke compilation
      Dim CompilerResults As System.CodeDom.Compiler.CompilerResults = Nothing

      If sourceFile IsNot Nothing AndAlso System.IO.File.Exists(sourceFile) Then
        ' soruce code in external file
        CompilerResults = codeProvider.CompileAssemblyFromFile(CompilerParameters, sourceFile)
      Else
        ' source code pass as a string
        CompilerResults = codeProvider.CompileAssemblyFromSource(CompilerParameters, sourceCode)
      End If

      If CompilerResults.Errors.Count > 0 Then
        ' Return compilation errors
        errors = ""
        For Each CompErr As System.CodeDom.Compiler.CompilerError In CompilerResults.Errors
          errors += "Line number " & CompErr.Line & ", Error Number: " & CompErr.ErrorNumber & ", '" & CompErr.ErrorText & ";" & vbCr & vbLf & vbCr & vbLf
        Next

        ' Return the results of compilation - Failed
      Else
        ' no compile errors
        errors = Nothing
      End If

      ' Return the results of compilation - Success
      Return CompilerResults

    Catch _Exception As Exception
      ' Error occurred when trying to compile the code
      errors = _Exception.Message
      Return Nothing
    End Try

    Return Nothing
  End Function

End Class
