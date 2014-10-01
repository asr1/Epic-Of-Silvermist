Public Class Fonts
    Public Shared Georgia_16 As SpriteFont
    Public Shared Centaur_10 As SpriteFont
    'Add fonts here, follow the example.
    Public Shared Sub load()

        'Deleted this like a Myspace profile, yo.
        Georgia_16 = Globals.Content.Load(Of SpriteFont)("Fonts/Georgia_16")
        Centaur_10 = Globals.Content.Load(Of SpriteFont)("Fonts/Centaur_10")
    End Sub
End Class
