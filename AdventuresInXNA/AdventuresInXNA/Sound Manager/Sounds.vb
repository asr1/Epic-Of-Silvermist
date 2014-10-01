Public Class Sounds
    Public Shared ambientMusic As Song

    'Avatars
    Public Shared PiratePlayer As Texture2D


    Public Shared Sub load()
        ambientMusic = Globals.Content.Load(Of Song)("sounds/enthalpy")
    End Sub

End Class
