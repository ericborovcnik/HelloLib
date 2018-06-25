<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Redlight
    Inherits System.Windows.Forms.Control

    Public Enum RedlightStatus
        RedlightNone = 0
        RedlightRed = 1
        RedlightYellow = 2
        RedlightGreen = 3
    End Enum

    Private oStatus As RedlightStatus
    Private oBorderWidth As Single = 1.0!
    Public Event StatusChanged(ByVal NewStatus As RedlightStatus)

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Redlight
        Me.Name = "Redlight"
        Me.Size = New System.Drawing.Size(45, 126)
        Me.ResumeLayout(False)
    End Sub

End Class
