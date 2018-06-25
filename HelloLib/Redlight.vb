Option Strict On
Imports System.ComponentModel


Public Class Redlight

    <DefaultValue(1.0!), Description("Width of the border around the traffic light")>
    Public Property BorderWidth() As Single
        Get
            Return oBorderWidth
        End Get
        Set(value As Single)
            If oBorderWidth <> value Then
                oBorderWidth = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Description("Status (color) of the traffic light")>
    Public Property Status As RedlightStatus
        Get
            Status = oStatus
        End Get
        Set(pStatus As RedlightStatus)
            If oStatus <> pStatus Then
                oStatus = pStatus
                RaiseEvent StatusChanged(oStatus)
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Sub ResetStatus()
        Status = RedlightStatus.RedlightYellow
    End Sub

    Private Sub Redlight_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Invalidate()
    End Sub
    Private Sub Redlight_Layout(sender As Object, e As LayoutEventArgs) Handles Me.Layout
        Select Case e.AffectedProperty
            Case "Bounds"
                Width = CInt(Height / 3)
        End Select
    End Sub
    'Private Sub Redlight_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    '    Dim lGraph As System.Drawing.Graphics
    '    lGraph = 
    'End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim lGraph As System.Drawing.Graphics
        MyBase.OnPaint(e)
        lGraph = e.Graphics
        DrawLight(RedlightStatus.RedlightRed, lGraph)
        DrawLight(RedlightStatus.RedlightYellow, lGraph)
        DrawLight(RedlightStatus.RedlightGreen, lGraph)
        Dim lPan As New System.Drawing.Pen(System.Drawing.Color.Black, oBorderWidth)
    End Sub


    Private Sub DrawLight(pLightToDraw As RedlightStatus, pGraphic As System.Drawing.Graphics)
        Dim lCircleX As Integer
        Dim lCircleY As Integer
        Dim lCircleDiameter As Integer
        Dim lCircleColor As System.Drawing.Color
        'Ermittelt die X-Koordinate und den Radius des Kreises
        lCircleX = CInt(Width * 0.02)
        lCircleDiameter = CInt(Width * 0.96)
        Select Case pLightToDraw
            Case RedlightStatus.RedlightRed
                If pLightToDraw = Status Then
                    lCircleColor = System.Drawing.Color.OrangeRed
                Else
                    lCircleColor = System.Drawing.Color.Maroon
                End If
                lCircleY = CInt(Height * 0.01)
            Case RedlightStatus.RedlightYellow
                If pLightToDraw = Status Then
                    lCircleColor = System.Drawing.Color.Yellow
                Else
                    lCircleColor = System.Drawing.Color.Tan
                End If
                lCircleY = CInt(Height * 0.34)
            Case RedlightStatus.RedlightGreen
                If pLightToDraw = Status Then
                    lCircleColor = System.Drawing.Color.LimeGreen
                Else
                    lCircleColor = System.Drawing.Color.ForestGreen
                End If
                lCircleY = CInt(Height * 0.67)
        End Select
        Dim lBrush As System.Drawing.Brush
        If pLightToDraw = Status Then
            lBrush = New System.Drawing.SolidBrush(lCircleColor)
        Else
            lBrush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(60, lCircleColor))
        End If
        pGraphic.FillEllipse(lBrush, lCircleX, lCircleY, lCircleDiameter, lCircleDiameter)
        lBrush.Dispose()
    End Sub

    Private Sub Redlight_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Dim lX As Integer = CInt(Width * 0.5)
        Dim lRadius As Integer = lX
        If Distance(e.X, e.Y, lX, CInt(Height / 6)) < lRadius Then
            Status = RedlightStatus.RedlightRed
            Exit Sub
        End If
        If Distance(e.X, e.Y, lX, CInt(Height / 2)) < lRadius Then
            Status = RedlightStatus.RedlightYellow
            Exit Sub
        End If
        If Distance(e.X, e.Y, lX, CInt(5 * Height / 6)) < lRadius Then
        End If
        Status = RedlightStatus.RedlightGreen
    End Sub

    Private Function Distance(X1 As Integer, Y1 As Integer, X2 As Integer, Y2 As Integer) As Integer
        Return CInt(System.Math.Sqrt((X1 - X2) ^ 2 + (Y1 - Y2) ^ 2))
    End Function
End Class
