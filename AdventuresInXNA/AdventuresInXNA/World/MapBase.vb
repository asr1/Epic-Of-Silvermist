Public Class MapBase
    Public TileList(0, 0) As Tile



    Public Sub New(width As Integer, height As Integer, start As Vector2)
        ReDim TileList(width, height)

        'Temporary map
        For x = 0 To width
            For y = 0 To height
                TileList(x, y) = New Tile
                With TileList(x, y)
                    .TerrainType = TileType.Water
                    .TileGFX = Textures.World
                    .aniFrame = 0
                    .isBlocked = False
                End With
            Next
        Next

        'Simple Island
        For z = 22 To 33
            For c = 22 To 31
                TileList(z, c).TerrainType = TileType.Grass
            Next
        Next

        TileList(27, 25).TerrainType = TileType.Foothills
        TileList(28, 25).TerrainType = TileType.Foothills
        TileList(27, 24).TerrainType = TileType.Foothills
        TileList(28, 26).TerrainType = TileType.Mountains
        TileList(28, 26).isBlocked = True

        For x = 0 To width
            For y = 0 To height
                TileList(x, y).srcRect = GetTileSource(TileList(x, y).TerrainType) 'Load the appropriate graphic for every tile
            Next
        Next

    End Sub

    'Return a tile of the given type
    Private Function GetTileSource(TType As TileType) As Rectangle
        Dim sRect As Rectangle 'The source rectangle
        Select Case TType
            Case TileType.Grass
                sRect = New Rectangle(0, 0, 16, 16)
            Case TileType.Water
                sRect = New Rectangle(0, 80, 16, 16)
            Case TileType.Foothills
                sRect = New Rectangle(48, 0, 16, 16)
            Case TileType.Mountains
                sRect = New Rectangle(32, 0, 16, 16)
        End Select
        Return sRect
    End Function

End Class
