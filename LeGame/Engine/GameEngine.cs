using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LeGame.Models.Characters;
using LeGame.Models.Characters.Player;
using LeGame.Models.LevelAssets;
using System;
using LeGame.Handlers;
using LeGame.Interfaces;
using LeGame.Models;
using LeGame.Models.Items.Gold;
using LeGame.Models.Characters.Enemies;


namespace LeGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Player testPlayer;
        Character sampleEnemy;
        private Level testLevel;
        private float rotationAngle;

        public GameEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            IsMouseVisible = true;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GfxHandler.Load(Content);
            
            GoldCoin coin = new GoldCoin(new Vector2(300, 300), "TestObjects/coin");
            //testEnemyTex = Content.Load<Texture2D>(@"TestObjects/cockSprite");

            graphics.PreferredBackBufferWidth = GlobalVariables.WINDOW_WIDTH; // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = GlobalVariables.WINDOW_HEIGHT;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            Vector2 enemyPos = new Vector2(550, 350);
            Vector2 pos = new Vector2(
                GlobalVariables.WINDOW_WIDTH / 2 - 140,
                GlobalVariables.WINDOW_HEIGHT / 2);

            sampleEnemy = new SampleEnemy(enemyPos, @"TestObjects/cockSprite", 100, 100, 1, testLevel);
            testPlayer = new TestChar(pos, @"TestObjects/catRotation", 100, 100, 2, testLevel);

            testLevel = new Level(@"..\..\..\Content\Maps\testMap2.txt", testPlayer);

            testLevel.Assets.Add(coin);

            sampleEnemy.Level = testLevel;
            testPlayer.Level = testLevel;
            testLevel.Enemies.Add(sampleEnemy);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TODO: Add your update logic here

            // The mouse position should probably be implemented in the player class.
            var positionMouse = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            rotationAngle = (float)((Math.PI * 0.5f) + Math.Atan2(positionMouse.Y - testPlayer.Position.Y, positionMouse.X - testPlayer.Position.X));


            testPlayer.Move();
            GfxHandler.GetRotationSprite(testPlayer).Update(gameTime, testPlayer);
            
            sampleEnemy.Move();
            GfxHandler.GetSprite(sampleEnemy).Update(gameTime, sampleEnemy);
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Wheat);
            Vector2 origin = new Vector2(GfxHandler.GetWidth(testPlayer) / 2, GfxHandler.GetHeight(testPlayer) / 2);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
           
            testLevel.Tiles.ForEach(t => spriteBatch.Draw(GfxHandler.GetTexture(t), t.Position));
            testLevel.Assets.ForEach(t => spriteBatch.Draw(GfxHandler.GetTexture(t), t.Position));

            //testLevel.Assets.ForEach(t => 
            //{
            //    if (t.Type != "uhm") spriteBatch.Dra(GfxHandler.GetTexture(t), t.Position);
            //});

            spriteBatch.End();

            GfxHandler.GetRotationSprite(testPlayer).Draw(spriteBatch, testPlayer.Position, rotationAngle);
            GfxHandler.GetSprite(sampleEnemy).Draw(spriteBatch, sampleEnemy.Position);

            base.Draw(gameTime);
        }
    }
}
