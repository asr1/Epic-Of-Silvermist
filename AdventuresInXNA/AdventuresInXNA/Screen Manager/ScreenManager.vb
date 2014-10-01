Public Enum ScreenState
    Active
    ShutDown
    Hidden
End Enum

Public Class ScreenManager
    Private Shared Screens As New List(Of BaseScreen) 'List of screens
    Private Shared NewScreens As New List(Of BaseScreen) ' Screens to be added
    'Use to so we can remove w/o affecting index #s
    Private debugScreen As New Debug()


    Public Sub New()
        AddScreen(debugScreen)

        'Debug sound test
        SoundManager.play()


    End Sub

    Public Sub update()
        debugScreen.screens = "Screens: "



        'Generate list of dead screens for removal
        Dim RemoveScreens As New List(Of BaseScreen)

        For Each foundScreen As BaseScreen In Screens
            If foundScreen.State = ScreenState.ShutDown Then
                RemoveScreens.Add(foundScreen)
            Else
                debugScreen.screens += foundScreen.Name + ", "
                foundScreen.Focused = False
            End If
        Next

        'Now remove
        'Two lists so that we don't delete and go out of bounds.
        'Could be circumvented by iterating backwards through the list ONCE.
        For Each foundScreen As BaseScreen In RemoveScreens
            Screens.Remove(foundScreen)
        Next

        'Add new screens to manager list
        For Each foundScreen As BaseScreen In NewScreens
            Screens.Add(foundScreen)
        Next
        NewScreens.Clear()

        'Reset debug screen to top of list
        Screens.Remove(debugScreen)
        Screens.Add(debugScreen)

        'Check screen focus
        'This time we're going to count backwards.
        If Screens.Count > 0 Then
            For i = Screens.Count - 1 To 0 Step -1
                If Screens(i).GrabFocus Then
                    Screens(i).Focused = True
                    debugScreen.focusScreen = "Focused Screen: " & Screens(i).Name
                    Exit For
                End If
            Next
        End If

        'Handle input for focus screen
        For Each foundScreen As BaseScreen In Screens
            If Globals.WindowFocused Then
                foundScreen.HandleInput()
            End If
            foundScreen.Update()
        Next


    End Sub

    Public Sub draw()
        'Draw all the active screens
        For Each foundScreen As BaseScreen In Screens
            If foundScreen.State = ScreenState.Active Then
                foundScreen.Draw()
            End If
        Next
    End Sub

    Public Shared Sub AddScreen(screen As BaseScreen)
        NewScreens.Add(screen)
    End Sub

    Public Shared Sub UnloadScreen(screen As String)
        For Each foundScreen As BaseScreen In Screens
            If foundScreen.Name = screen Then
                foundScreen.unload()
                Exit For
            End If

        Next
    End Sub


End Class
