''' <summary>
''' Globale Funktionserweiterungen über Shared Sub und Functions
''' </summary>
Public Class Enhancements

    ''' <summary>
    ''' Zeigt ein Formular "Pseudo-Modal" an.
    ''' </summary>
    ''' <param name="pForm">Dieses Form soll angezeigt werden</param>
    ''' <param name="pParent">Dieses Form ist Träger und wird zwischenzeitlich deaktiviert</param>
    Public Shared Sub ShowForm(pForm As Form, Optional pParent As Form = Nothing)
        If Not pParent Is Nothing Then pParent.Enabled = False
        pForm.Show(pParent)
        Do While pForm.Visible
            Application.DoEvents()
        Loop
        If Not pParent Is Nothing Then
            pParent.Enabled = True
            pParent.Show()
            pParent.Focus()
        End If
    End Sub

End Class
