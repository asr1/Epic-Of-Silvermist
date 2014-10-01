
Public Class Game1
    Inherits Microsoft.Xna.Framework.Game
    Private screenManager As ScreenManager

    Public Sub New()
        Globals.Graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
    End Sub


    Protected Overrides Sub Initialize()
        Me.IsMouseVisible = True 'We don't use the mouse, but it's visible.
        Window.AllowUserResizing = True 'Sure, why not?

        Globals.GameSize = New Vector2(512, 448) 'Resolution set here
        Globals.Graphics.PreferredBackBufferWidth = Globals.GameSize.X
        Globals.Graphics.PreferredBackBufferHeight = Globals.GameSize.Y
        Globals.Graphics.ApplyChanges()

        Globals.BackBuffer = New RenderTarget2D(Globals.Graphics.GraphicsDevice, Globals.GameSize.X, Globals.GameSize.Y) 'There's a bunch of arguments
        'In video 2 that I chose not to use here. I didn't use them. Hope it doesn't break anything.
        MyBase.Initialize()
    End Sub

    'LoadContent will be called once per game and is the place to load
    'all of your content.
    Protected Overrides Sub LoadContent()
        ' Create a new SpriteBatch, which can be used to draw textures.
        Globals.SpriteBatch = New SpriteBatch(GraphicsDevice)
        Globals.Content = Me.Content

        'Loading fonts, textures, and sounds
        Fonts.load()
        Textures.load()
        Sounds.load()

        'Add default screens
        screenManager = New ScreenManager
        screenManager.AddScreen(New TitleScreen)
        screenManager.AddScreen(New MainMenu)
    End Sub

    ' UnloadContent will be called once per game and is the place to unload
    ' all content.
    Protected Overrides Sub UnloadContent()
        ' TODO: Unload any non ContentManager content here
        'Probably unecessary, could delete.
    End Sub

    'Allows the game to run logic such as updating the world,
    'checking for collisions, gathering input, and playing audio.
    Protected Overrides Sub Update(ByVal gameTime As GameTime)

        'UPDATE LOGIC STARTS HERE
        MyBase.Update(gameTime)
        Globals.WindowFocused = Me.IsActive
        Globals.GameTime = gameTime

        'Update screens
        screenManager.update()

        'TODO screens will be added here

        'Input
        Input.update()
    End Sub

    ' This is called when the game should draw itself.
    Protected Overrides Sub Draw(ByVal gameTime As GameTime)
        Globals.Graphics.GraphicsDevice.SetRenderTargets(Globals.BackBuffer)
        GraphicsDevice.Clear(Color.Black) 'draws background color if nothing to draw.
        MyBase.Draw(gameTime)

        'Draw contents of screen manager
        screenManager.draw()

        Globals.Graphics.GraphicsDevice.SetRenderTarget(Nothing)

        'Draw backbuffer to screen
        Globals.SpriteBatch.Begin() 'Sprite batch begin starts every drawing
        Globals.SpriteBatch.Draw(Globals.BackBuffer, New Rectangle(0, 0, Globals.Graphics.GraphicsDevice.Viewport.Width, Globals.Graphics.GraphicsDevice.Viewport.Height), Color.White) 'Always ends in color


        Globals.SpriteBatch.End() 'sprite batch end ends every drawing


    End Sub

End Class
