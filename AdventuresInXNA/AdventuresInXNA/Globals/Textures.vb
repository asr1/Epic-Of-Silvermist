Public Class Textures
    Public Shared owlbearAvatar As Texture2D
    Public Shared menu1 As Texture2D
    Public Shared World As Texture2D

    'Avatars
    Public Shared PiratePlayer As Texture2D


    Public Shared Sub load()
        owlbearAvatar = Globals.Content.Load(Of Texture2D)("GFX/Owlbear")
        menu1 = Globals.Content.Load(Of Texture2D)("GFX/Menu1")
        World = Globals.Content.Load(Of Texture2D)("GFX/World/tileset")
        PiratePlayer = Globals.Content.Load(Of Texture2D)("GFX/Avatars/Pirate")
    End Sub
End Class
