Public Class WorldScreen
    Inherits BaseScreen

    'Map dimmensions
    Public Map As MapBase
    Public MapWidth As Integer = 100
    Public MapHeight As Integer = 100
    Public TileSize As Integer = 32

    'Current Coordinate
    Public MapX As Integer = 20
    Public mapY As Integer = 19

    'Sprite source
    Private sRect As Rectangle

    Public Sub New()
        Name = "WorldScreen"
        Map = New MapBase(MapWidth, MapHeight, New Vector2(0, 0))
    End Sub

    Public Overrides Sub HandleInput()
        If AvatarOffsetX = 0 And AvatarOffsetY = 0 Then 'And AvatarMoving = False Then
            If Input.keydown(Keys.S) Or Input.keydown(Keys.Down) Then
                moveAvatar(1, AvatarX, AvatarY + 1)
                LastDir = 1
            ElseIf Input.keydown(Keys.W) Or Input.keydown(Keys.Up) Then
                moveAvatar(4, AvatarX, AvatarY - 1)
                LastDir = 4
            ElseIf Input.keydown(Keys.A) Or Input.keydown(Keys.Left) Then
                moveAvatar(2, AvatarX - 1, AvatarY)
                LastDir = 2
            ElseIf Input.keydown(Keys.D) Or Input.keydown(Keys.Right) Then
                moveAvatar(3, AvatarX + 1, AvatarY)
                LastDir = 3
            End If
        Else
            MoveDir = 0
        End If

        'Debug turbo speed boost
        If Input.keydown(Keys.X) Then
            MoveSpeed = 9
        Else
            MoveSpeed = 3
        End If

    End Sub



    Public Overrides Sub Update()
        'character movement updates
        MoveTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If MoveTime > 25 And AvatarMoving = True Then
            If MoveDir = 0 And (AvatarOffsetX <> 0 Or AvatarOffsetY <> 0) Then
                'finish move cycle before accepting new inputs
                Move(LastDir)
            Else 'If not between movements, accept new
                Move(MoveDir)
            End If

            'Between movements
            If AvatarOffsetX = 0 And AvatarOffsetY = 0 Then
                AvatarMoving = False
            End If

            MoveTime = 0 'reset time to reset cycle
        End If

        'update characater's coordinates
        AvatarX = MapX + avatarScreenX 'He's not in top corner like it thinks he his, give accurate position info
        AvatarY = mapY + avatarScreenY

        'End character movement updates

    End Sub

    Public Overrides Sub Draw()
        MyBase.Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)

        'Draw the layer
        For drawX = -1 To 16 'Start drawing to the left of the screen, avoiding clipping
            For drawY = -1 To 15
                Dim x As Integer = drawX + MapX 'Current coordinate mapping screenVal to MapVal]
                Dim y As Integer = drawY + mapY

                If x >= 0 And x <= MapWidth And y >= 0 And y <= MapHeight Then
                    Globals.SpriteBatch.Draw(Map.TileList(x, y).TileGFX, New Rectangle(drawX * TileSize + AvatarOffsetX, drawY * TileSize + AvatarOffsetY, TileSize, TileSize), Map.TileList(x, y).srcRect, Color.White)
                    'DEBUG view coordinates on tile
                    'Globals.SpriteBatch.DrawString(Fonts.Centaur_10, "x: " & x & vbCrLf & "Y: " & y, New Vector2(drawX * TileSize, drawY * TileSize), Color.Black)
                End If
            Next
        Next 'Tiles are drawn

        'Now let's draw our Pirate on top of the sprites
        'He's not 32*32 so it might scale
        Globals.SpriteBatch.Draw(Textures.PiratePlayer, New Rectangle(avatarScreenX * 32, avatarScreenY * 32, 32, 32), FetchAvatarSrc(LastDir), Color.White)


        Globals.SpriteBatch.End()
    End Sub

End Class
