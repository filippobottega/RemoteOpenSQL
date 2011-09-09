Imports System.Configuration
Imports System.IO

Namespace My
  ' I seguenti eventi sono disponibili per MyApplication:
  ' 
  ' Startup: generato all'avvio dell'applicazione, prima della creazione del form di avvio.
  ' Shutdown: generato dopo la chiusura di tutti i form dell'applicazione. L'evento non è generato se l'applicazione termina in modo anormale.
  ' UnhandledException: generato se l'applicazione rileva un'eccezione non gestita.
  ' StartupNextInstance: generato quando si avvia un'applicazione istanza singola e l'applicazione è già attiva. 
  ' NetworkAvailabilityChanged: generato quando la connessione di rete è connessa o disconnessa.
  Partial Friend Class MyApplication

    Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
      Try
        MySettings.[Default].Reload()
        Me.MainForm = Global.RemoteOpenSQL.RemoteOpenSQLManager.MainForm
      Catch ex As InvalidOperationException
        '(requires System.Configuration)
        Dim filename As String = DirectCast(ex.InnerException.InnerException, ConfigurationErrorsException).Filename

        If MessageBox.Show(My.Application.Info.Title &
                           " has detected that your" &
                           " user settings file has become corrupted." &
                           " This may be due to a crash or improper exiting" &
                           " of the program. " &
                           My.Application.Info.Title &
                           " must reset your" &
                           " user settings in order to continue." &
                           vbLf &
                           vbLf &
                           "Click" &
                           " Yes to reset your user settings and continue." &
                           vbLf &
                           vbLf &
                           "Click No if you wish to attempt manual repair" &
                           " or to rescue information before proceeding.",
                           "Corrupt user settings",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.[Error]) = MsgBoxResult.Yes Then
          File.Delete(filename)
          System.Windows.Forms.Application.Restart()
        End If
        Process.GetCurrentProcess().Kill()
        ' avoid the inevitable crash
      End Try
    End Sub
  End Class


End Namespace

