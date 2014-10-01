Public Class Debug
    Inherits BaseScreen

    Public screens As String = ""
    Public focusScreen As String

    Private fps As Integer
    Private fpsCounter As Integer
    Private fpsTimer As Double
    Private fpsText As String = ""

    Private BGRect As Rectangle

    Public Sub New()
        Name = "Debug"
        State = ScreenState.Hidden
        GrabFocus = False
    End Sub

    Public Overrides Sub HandleInput()
        MyBase.HandleInput()
        'Temporary until we create an input class
        If Input.keyPressed(Keys.F1) Then
            If State = ScreenState.Active Then
                State = ScreenState.Hidden
            ElseIf State = ScreenState.Hidden Then
                State = ScreenState.Active
            End If
        End If

        'debug sound info. Having it on the omnipresernt Debug screen means it can be toggled from anywhere
        'Right now set to Z
        If Input.keyPressed(Keys.Z) Then
            If SoundManager.soundOn Then
                SoundManager.pause()
                SoundManager.soundOn = False
            ElseIf SoundManager.soundOn = False Then
                SoundManager.play()
                SoundManager.soundOn = True
            End If
        End If


    End Sub

    Public Overrides Sub Update()
        MyBase.Update()

        If screens.Length > 1 Then
            screens = screens.Substring(0, screens.Length - 2)
        End If

        Dim txtWidth As Integer = 0
        Dim txtHeight As Integer = 0

        If Fonts.Centaur_10.MeasureString(screens).X > txtWidth Then
            txtWidth = Fonts.Centaur_10.MeasureString(screens).X
        End If
        If Fonts.Centaur_10.MeasureString(focusScreen).X > txtWidth Then
            txtWidth = Fonts.Centaur_10.MeasureString(focusScreen).X
        End If
        txtHeight = Fonts.Centaur_10.MeasureString(fpsText).Y * 3
        BGRect = New Rectangle(0, 0, txtWidth + 20, txtHeight + 20)
    End Sub

    Public Overrides Sub Draw()
        MyBase.Draw()

        If Globals.GameTime.TotalGameTime.TotalMilliseconds > fpsTimer Then
            fps = fpsCounter
            fpsTimer = Globals.GameTime.TotalGameTime.TotalMilliseconds + 1000
            fpsCounter = 1
            fpsText = "FPS: " & fps
        Else
            fpsCounter += 1
        End If

        Globals.SpriteBatch.Begin()
        Globals.SpriteBatch.Draw(Textures.owlbearAvatar, BGRect, Color.Black * 0.6F)
        Globals.SpriteBatch.DrawString(Fonts.Centaur_10, fpsText, New Vector2(10, 10), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Centaur_10, screens, New Vector2(10, 22), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Centaur_10, focusScreen, New Vector2(10, 34), Color.White)
        Globals.SpriteBatch.End()
    End Sub
End Class
