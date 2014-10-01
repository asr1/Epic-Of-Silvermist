'Overriding the default input class
Public Class Input
    Shared CurrentKeyState As KeyboardState
    Shared LastKeyState As KeyboardState

    Public Shared Sub update()
        LastKeyState = CurrentKeyState
        CurrentKeyState = Keyboard.GetState
    End Sub

    'Holding a keydown.
    Public Shared Function keydown(key As Keys) As Boolean
        Return CurrentKeyState.IsKeyDown(key)
    End Function

    Public Shared Function keyPressed(key As Keys) As Boolean
        'Did we press a key or hold a key? This is for pressing and releasing
        If CurrentKeyState.IsKeyDown(key) And LastKeyState.IsKeyUp(key) Then
            Return True
        End If
        Return False
    End Function
End Class
