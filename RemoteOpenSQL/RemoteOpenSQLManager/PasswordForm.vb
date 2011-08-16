Public Class PasswordForm
  Public Shared Function GetPassword() As String
    Dim PasswordForm As New PasswordForm
    If PasswordForm.ShowDialog = DialogResult.OK Then
      Return PasswordForm.PasswordTextBox.Text
    Else
      Return String.Empty
    End If
  End Function
End Class