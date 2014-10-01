Public Class MainMenu
    Inherits BaseScreen

    Private Entries As New List(Of MenuEntry)
    Private menuSelect As Integer = 0   'Selected item in the menu


    Private menuSize As New Vector2(250, 160)
    Private menuPos As New Vector2(130, 280)

    Public Sub New()
        Name = "MainMenu"
        State = ScreenState.Active



        'Add entries here
        addEntry("New Game", True)
        addEntry("Continue", False)
        addEntry("Options", True)
        addEntry("Credits", True)
    End Sub

    Public Sub addEntry(text As String, enabled As Boolean)
        Dim entry As MenuEntry
        entry = New MenuEntry
        With entry
            .text = text
            .enabled = enabled
        End With
        Entries.Add(entry)
    End Sub

    Public Overrides Sub HandleInput()
        'Menu up
        If Input.keyPressed(Keys.Up) Or Input.keyPressed(Keys.W) Then
            menuSelect -= 1
            If (menuSelect < 0) Then 'Enable wrap-around, baby
                menuSelect = Entries.Count - 1
            End If
            'Skip disabled
            Do Until Entries(menuSelect).enabled = True
                menuSelect -= 1
                If menuSelect < 0 Then
                    menuSelect = Entries.Count - 1
                End If
            Loop
        End If

        'Menu down
        If Input.keyPressed(Keys.Down) Or Input.keyPressed(Keys.S) Then
            menuSelect += 1
            If (menuSelect > Entries.Count - 1) Then 'Enable wrap-around, baby
                menuSelect = 0
            End If
            'Skip disabled
            Do Until Entries(menuSelect).enabled = True
                menuSelect += 1
                If menuSelect > Entries.Count - 1 Then
                    menuSelect = 0
                End If
            Loop
        End If


        'invoke selected menu item when selected
        If Input.keyPressed(Keys.Enter) Then
            Select Case menuSelect
                Case 0 ' New Game
                    ScreenManager.UnloadScreen("TitleScreen")
                    ScreenManager.UnloadScreen("MainMenu")
                    ScreenManager.AddScreen(New WorldScreen)
                Case 1 'Continue Game
                    MsgBox("You want more?")
                Case 2 ' Options
                    ScreenManager.UnloadScreen("TitleScreen")
                    ScreenManager.UnloadScreen("MainMenu")
                    ScreenManager.AddScreen(New OptionScreen)
                Case 3 'Creditss
                    ScreenManager.UnloadScreen("TitleScreen")
                    ScreenManager.UnloadScreen("MainMenu")
                    ScreenManager.AddScreen(New CreditScreen)

                    'MsgBox("I'd like to thank the academy")

            End Select
        End If
    End Sub

    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin()
        'Draw Menu Graphcis
        For Each entry In Entries

        Next
        'Draw Menu Options
        Dim menuY As Integer = menuPos.Y + 20
        For x = 0 To Entries.Count - 1
            If x = menuSelect Then 'selected
                Globals.SpriteBatch.DrawString(Fonts.Georgia_16, Entries.Item(x).text, New Vector2(menuPos.X + (menuSize.X / 2) - Fonts.Georgia_16.MeasureString(Entries.Item(x).text).X / 2, menuY), Color.Red)
            ElseIf Entries.Item(x).enabled = True Then 'enabled
                Globals.SpriteBatch.DrawString(Fonts.Georgia_16, Entries.Item(x).text, New Vector2(menuPos.X + (menuSize.X / 2) - Fonts.Georgia_16.MeasureString(Entries.Item(x).text).X / 2, menuY), Color.White)
            Else 'disabled
                Globals.SpriteBatch.DrawString(Fonts.Georgia_16, Entries.Item(x).text, New Vector2(menuPos.X + (menuSize.X / 2) - Fonts.Georgia_16.MeasureString(Entries.Item(x).text).X / 2, menuY), Color.Gray)
            End If

            menuY += 30 'Move down so we don't write on top of ourselves
        Next
        Globals.SpriteBatch.End()
    End Sub
End Class
