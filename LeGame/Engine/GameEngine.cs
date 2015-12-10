using System.Linq;
using LeGame.Handlers;
using LeGame.Models;
using LeGame.Models.Characters;
using LeGame.Models.Characters.Enemies;
using LeGame.Models.Characters.Player;
using LeGame.Models.Items.PickableItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Engine
{
    public class GameEngine : Game
    {
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Player testPlayer;
        private Character sampleEnemy;
        private Level testLevel;

        public GameEngine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }
        
        protected override void LoadContent()
        {
            this.IsMouseVisible = true;
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            GfxHandler.Load(this.Content);
            
            GoldCoin coin = new GoldCoin(new Vector2(300, 300), "TestObjects/coin");
            //testEnemyTex = Content.Load<Texture2D>(@"TestObjects/cockSprite");

            Vector2 enemyPos = new Vector2(550, 350);
            Vector2 pos = new Vector2(
                GlobalVariables.WindowWidth / 2 - 140,
                GlobalVariables.WindowHeight / 2);

            this.sampleEnemy = new SampleEnemy(enemyPos, @"TestObjects/cockSprite", 100, 100, 1, this.testLevel);
            this.testPlayer = new TestChar(pos, @"Player/p1Rotation", 100, 100, 2, this.testLevel);

            this.testLevel = new Level(@"..\..\..\Content\Maps\testMap2.txt", this.testPlayer);

            this.testLevel.Assets.Add(coin);

            this.sampleEnemy.Level = this.testLevel;
            this.testPlayer.Level = this.testLevel;
            this.testLevel.Enemies.Add(this.sampleEnemy);

            // TODO: Get Width and Heignt based on the level size?
            this.graphics.PreferredBackBufferWidth = GlobalVariables.WindowWidth; // set this value to the desired width of your window
            this.graphics.PreferredBackBufferHeight = GlobalVariables.WindowHeight;   // set this value to the desired height of your window
            this.graphics.ApplyChanges();
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

           
            this.testPlayer.Move();
            GfxHandler.GetRotationSprite(this.testPlayer).Update(gameTime, this.testPlayer);
            
            this.sampleEnemy.Move();
            GfxHandler.GetSprite(this.sampleEnemy).Update(gameTime, this.sampleEnemy);

            foreach (var projectile in this.testLevel.Projectiles)
            {
                projectile.Move();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Wheat);
            Vector2 origin = new Vector2(GfxHandler.GetWidth(this.testPlayer) / 2, GfxHandler.GetHeight(this.testPlayer) / 2);
            // TODO: Add your drawing code here
            this.spriteBatch.Begin();
           
            this.testLevel.Tiles.ForEach(t => this.spriteBatch.Draw(GfxHandler.GetTexture(t), t.Position));
            this.testLevel.Assets.ForEach(t => this.spriteBatch.Draw(GfxHandler.GetTexture(t), t.Position));

            //testLevel.Assets.ForEach(t => 
            //{
            //    if (t.Type != "uhm") spriteBatch.Dra(GfxHandler.GetTexture(t), t.Position);
            //});

            this.spriteBatch.End();

            GfxHandler.GetRotationSprite(this.testPlayer).Draw(this.spriteBatch, this.testPlayer.Position, this.testPlayer.FacingAngle, this.testPlayer.MovementAngle);
            GfxHandler.GetSprite(this.sampleEnemy).Draw(this.spriteBatch, this.sampleEnemy.Position);

            foreach (var projectile in this.testLevel.Projectiles.ToList())
            {
                GfxHandler.GetRotationSprite(projectile).Draw(this.spriteBatch, projectile.Position, projectile.Angle, projectile.Angle);

                if (projectile.Lifetime > projectile.Range)
                {
                    this.testLevel.Projectiles.Remove(projectile);
                }
            }

            base.Draw(gameTime);
        }
    }
}
