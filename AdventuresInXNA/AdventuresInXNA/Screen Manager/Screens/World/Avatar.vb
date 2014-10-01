Public Enum Direction
    none
    down
    left
    right
    up
End Enum

Partial Public Class WorldScreen
    'Screen position
    Public avatarScreenX As Integer = 8
    Public avatarScreenY As Integer = 6

    'Avatar's map coordinates
    Public AvatarX As Integer = 0
    Public AvatarY As Integer = 0

    'Avatar's offset for smooth walkign
    Public AvatarOffsetX As Integer = 0
    Public AvatarOffsetY As Integer = 0

    'Movement
    Public AvatarMoving As Boolean = False
    Public MoveTime As Double = 0 'Movement timer
    Public MoveSpeed As Integer = 3 'Movement speed (can slow for difficult terrain, etc
    Public MoveDir As Direction = Direction.none
    Public LastDir As Direction = Direction.down 'So I can point in a direction when not moving

    Private AvatarFrame As Integer = 0

    Public Sub Move(dir As Direction)
        MoveDir = dir

        Select Case dir
            Case Direction.down
                AvatarOffsetY -= MoveSpeed

                If AvatarOffsetY <= -32 Then 'height of one tile
                    mapY += 1 'Move the mpa down once
                    AvatarOffsetY = 0 'Reset for next movement
                End If
            Case Direction.left
                AvatarOffsetX += MoveSpeed

                If AvatarOffsetX >= 32 Then
                    MapX -= 1
                    AvatarOffsetX = 0
                End If
            Case Direction.right
                AvatarOffsetX -= MoveSpeed

                If AvatarOffsetX <= -32 Then
                    MapX += 1
                    AvatarOffsetX = 0
                End If

            Case Direction.up
                AvatarOffsetY += MoveSpeed

                If AvatarOffsetY >= 32 Then 'height of one tile
                    mapY -= 1 'Move the mpa up once
                    AvatarOffsetY = 0 'Reset for next movement
                End If
        End Select

        If AvatarOffsetX <> 0 Then
            AvatarFrame = Math.Floor(Math.Abs(AvatarOffsetX) / 32 * 4)
        ElseIf AvatarOffsetY <> 0 Then
            AvatarFrame = Math.Floor(Math.Abs(AvatarOffsetY) / 32 * 4)
        Else
            AvatarFrame = 0
        End If

        If MoveDir <> Direction.none Then
            LastDir = dir
        End If

    End Sub

    Public Sub moveAvatar(dir As Direction, avatarX As Integer, avatarY As Integer)
        If inBounds(avatarX, avatarY) Then

            If Map.TileList(avatarX, avatarY).isBlocked = False Then
                AvatarMoving = True
                MoveDir = dir
            End If

        End If
    End Sub

    'Stop the stupid crashing for out of bounds
    Private Function inBounds(avatarX As Integer, avatarY As Integer) As Boolean
        Try
            If avatarX > MapWidth Or avatarY > MapHeight Or avatarX < 0 Or avatarY < 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    'Based on direction, return specific sprite
    Private Function FetchAvatarSrc(dir As Direction) As Rectangle
        Select Case dir
            Case Direction.down
                sRect = New Rectangle(32 * AvatarFrame, 0, 32, 47)
            Case Direction.left
                sRect = New Rectangle(32 * AvatarFrame, 47, 32, 47)
            Case Direction.right
                sRect = New Rectangle(32 * AvatarFrame, 94, 32, 47)
            Case Direction.up
                sRect = New Rectangle(32 * AvatarFrame, 142, 32, 47)
        End Select
        Return sRect
    End Function
End Class
