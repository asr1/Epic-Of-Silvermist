Public Class OptionScreen
        Inherits BaseScreen

    Dim ActiveVol As Color 'Tracks the color of the on/off toggle for volume
    Dim invActiveVol As Color ' The inverse of ActiveVol

        Public Sub New()
        Name = "OptionScreen"
            State = ScreenState.Active
        End Sub

        Public Overrides Sub Draw()
            Globals.SpriteBatch.Begin()
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Volume", New Vector2(10, 130), Color.White)


        If SoundManager.soundOn Then
            ActiveVol = Color.Red
            invActiveVol = Color.White
        Else
            ActiveVol = Color.White
            invActiveVol = Color.Red
        End If

        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "On", New Vector2(30 + Fonts.Georgia_16.MeasureString("Volume").X, 130), ActiveVol)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Off", New Vector2(35 + Fonts.Georgia_16.MeasureString("Volume").X + Fonts.Georgia_16.MeasureString("On").X, 130), invActiveVol)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Back", New Vector2(10, Globals.GameSize.Y - Fonts.Georgia_16.MeasureString("Back").Y), Color.Red)
        Globals.SpriteBatch.End()
    End Sub

        Public Overrides Sub HandleInput()
            If (Input.keyPressed(Keys.Enter)) Then
            ScreenManager.UnloadScreen("OptionScreen")
                ScreenManager.AddScreen(New TitleScreen)
                ScreenManager.AddScreen(New MainMenu)
            End If



        End Sub

    End Class