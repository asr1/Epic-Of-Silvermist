Public Enum TileType
    Grass
    Water
    Foothills
    Mountains
End Enum

Public Structure Tile
    Public Property TerrainType As TileType 'The terrain type
    Public Property TileGFX As Texture2D 'The image sprite
    Public Property srcRect As Rectangle 'The source we get of the tile sprite
    Public Property location As Vector2 ' Where we will draw it on screen
    Public Property aniFrame As Integer 'In case we want animation in the future

    'Tile Actions. Feel free to add more
    Public Property isActivated As Boolean 'Like a lever
    Public Property isBlocked As Boolean
    Public Property isTouchTrigger As Boolean 'like a sign, press a next to, etc
    Public Property isStepTrigger As Boolean 'Like portal, lava, switch, etc


End Structure
