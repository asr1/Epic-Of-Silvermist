Public Class CreditScreen
    Inherits BaseScreen

    Public Sub New()
        Name = "CreditScreen"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin()
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "I'd like to thank the academy", New Vector2(130, 30), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Back", New Vector2(10, Globals.GameSize.Y - Fonts.Georgia_16.MeasureString("Back").Y), Color.Red)
        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub HandleInput()
        'Back is the only thing "highlighted"
        If (Input.keyPressed(Keys.Enter)) Then
            ScreenManager.UnloadScreen("CreditScreen")
            ScreenManager.AddScreen(New TitleScreen)
            ScreenManager.AddScreen(New MainMenu)
        End If



    End Sub

End Class
