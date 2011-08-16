Imports SAP.Connector
Imports System.IO

Public MustInherit Class RosSAPStructure
  Inherits SAPStructure

  Public MustOverride Function GetItemsArray() As Object()
  Public MustOverride Sub WriteToStreamWriter(ByVal StreamWriter As StreamWriter, ByVal FieldsSeparatorValue As String)
End Class
