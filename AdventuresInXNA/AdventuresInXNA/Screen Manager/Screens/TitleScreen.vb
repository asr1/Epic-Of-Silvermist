Public Class TitleScreen
    Inherits BaseScreen

    Private AniTime As Double = 0 'The animation timer
    'RGB
    Private r As Integer = 0
    Private g As Integer = 0
    Private b As Integer = 192

    Private rnd As Random = New Random

    Public Sub New()
        Name = "TitleScreen"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()

    End Sub

    Public Overrides Sub Update()
        'Used for flashing effect
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds

        If AniTime > 200 Then
            r = rnd.Next(40, 200)
            g = rnd.Next(40, 200)
            b = rnd.Next(40, 200)

            AniTime = 0
        End If
    End Sub

    Public Overrides Sub Draw()
        MyBase.Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        Globals.SpriteBatch.Draw(Textures.menu1, New Rectangle(0, 0, Globals.GameSize.X, Globals.GameSize.Y), New Rectangle(0, 0, 1, 64), New Color(255, 92, 38))
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "The Epic Of", New Vector2(10, 10), New Color(230, 215, 184), 0, New Vector2(0, 0), 2.4, SpriteEffects.None, 0)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Silvermist", New Vector2(91, 98), New Color(r, g, b), 0, New Vector2(0, 0), 4, SpriteEffects.None, 0)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Silvermist", New Vector2(93, 100), New Color(r, g, b), 0, New Vector2(0, 0), 4, SpriteEffects.None, 0)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Silvermist", New Vector2(92, 99), New Color(1, 1, 1), 0, New Vector2(0, 0), 4, SpriteEffects.None, 0)
        Globals.SpriteBatch.End()

    End Sub

    Public Overrides Sub unload()
        MyBase.unload()

    End Sub
End Class
