Module ControlExtensions

  <System.Runtime.CompilerServices.Extension()> _
  Public Sub UIThread(ByVal control As Control, ByVal code As Action)
    If control.InvokeRequired Then
      control.BeginInvoke(code)
      Return
    End If
    code.Invoke()
  End Sub

  <System.Runtime.CompilerServices.Extension()> _
  Public Sub UIThreadInvoke(ByVal control As Control, ByVal code As Action)
    If control.InvokeRequired Then
      control.Invoke(code)
      Return
    End If
    code.Invoke()
  End Sub

End Module
