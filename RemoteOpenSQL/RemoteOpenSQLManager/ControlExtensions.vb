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

Module ControlExtensions

  <Extension()>
  Public Sub UIThread(ByVal control As Control, ByVal code As Action)
    If control.InvokeRequired Then
      control.BeginInvoke(code)
      Return
    End If
    code.Invoke()
  End Sub

  <Extension()>
  Public Sub UIThreadInvoke(ByVal control As Control, ByVal code As Action)
    If control.InvokeRequired Then
      control.Invoke(code)
      Return
    End If
    code.Invoke()
  End Sub

  <Extension()>
  Public Function AllControls(control As Control) As List(Of Control)
    Dim Result As New List(Of Control)

    Result.Add(control)
    For Each control In control.Controls
      Result.AddRange(control.AllControls.ToArray)
    Next

    Return Result
  End Function
End Module
