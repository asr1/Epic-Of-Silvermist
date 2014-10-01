Public Class TestScreen
    Inherits BaseScreen

    Private testText As String = "Arr, matey"
    Private textPos As New Vector2(20, 195)
    Private isAlive As Boolean = True

    Private LifeSpan As Double = 0

    Public Sub New()
        Name = "testScreen"
    End Sub

    Public Overrides Sub update()
        If LifeSpan < 5000 Then
            LifeSpan += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        Else
            isAlive = False
        End If
        If isAlive = False Then
            Me.State = ScreenState.ShutDown
        End If
    End Sub

    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin()
        Globals.SpriteBatch.Draw(Textures.owlbearAvatar, New Rectangle(0, 0, Globals.GameSize.X, Globals.GameSize.Y), New Rectangle(16, 16, 1, 1), Color.WhiteSmoke)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, testText, textPos, Color.Red)
        Globals.SpriteBatch.End()
    End Sub
End Class
