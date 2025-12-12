Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    Friend NotInheritable Class MyApplication
        Inherits WindowsFormsApplicationBase

        Public Sub New()
            ' Application framework defaults - adjust if needed
            Me.IsSingleInstance = False
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = True
            Me.ShutdownStyle = ShutdownMode.AfterMainFormCloses
        End Sub

        Protected Overrides Sub OnCreateMainForm()
            ' Ensure the startup form instance is created here
            Me.MainForm = New FrmOpeningStock()
        End Sub
    End Class
End Namespace
