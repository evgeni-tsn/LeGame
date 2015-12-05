using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LeGame.Models.Characters;
using LeGame.Models.Characters.Player;
using LeGame.Models.LevelAssets;
using System;
using System.Collections.Generic;
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
    public class RolePlayingGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Character testChar;
        Character sampleEnemy;
        Texture2D testTex;
        Texture2D testEnemyTex;
        private Level testLevel;
        
        

        public RolePlayingGame()
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
            GfxHandler.Initialise(Content);
            
            GoldCoin coin = new GoldCoin(new Vector2(300, 300), "TestObjects/coin");
            testTex = Content.Load<Texture2D>(@"TestObjects/catSprite");
            testEnemyTex = Content.Load<Texture2D>(@"TestObjects/cockSprite");

            graphics.PreferredBackBufferWidth = GlobalVariables.WINDOW_WIDTH; // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = GlobalVariables.WINDOW_HEIGHT;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            Vector2 enemyPos = new Vector2(550, 350);
            Vector2 pos = new Vector2(
                GlobalVariables.WINDOW_WIDTH / 2 - 90,
                GlobalVariables.WINDOW_HEIGHT / 2);
            sampleEnemy = new SampleEnemy(enemyPos, @"TestObjects/cockSprite", 100, 100, 1, testLevel, testEnemyTex);
            testChar = new TestChar(pos, @"TestObjects/testChar", 100, 100, 2, testLevel, testTex);
            testLevel = new Level(@"..\..\..\Content\Maps\testMap2.txt", testChar, Content);
            testLevel.Assets.Add(coin);

            sampleEnemy.Level = testLevel;
            testChar.Level = testLevel;
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            testChar.Move();
            testChar.Sprite.Update(gameTime, testChar);
            sampleEnemy.Sprite.Update(gameTime, sampleEnemy);
            sampleEnemy.Move();
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Wheat);
            Vector2 origin = new Vector2(GfxHandler.GetWidth(testChar) / 2, GfxHandler.GetHeight(testChar) / 2);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
           
            testLevel.Tiles.ForEach(t=>spriteBatch.Draw(GfxHandler.GetTexture(t), t.Position));
            testLevel.Assets.ForEach(t => spriteBatch.Draw(GfxHandler.GetTexture(t), t.Position));
            
            //testLevel.Assets.ForEach(t => 
            //{
            //    if (t.Type != "uhm") spriteBatch.Draw(GfxHandler.GetTexture(t), t.Position);
            //});
            

            spriteBatch.End();
            testChar.Sprite.Draw(spriteBatch, testChar.Position);
            sampleEnemy.Sprite.Draw(spriteBatch, sampleEnemy.Position);
            base.Draw(gameTime);
        }
    }
}
