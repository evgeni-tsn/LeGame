namespace LeGame.Engine
{
    using System.Linq;

    using Enumerations;

    using Handlers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Models;
    using Models.Characters;
    using Models.Characters.Enemies;
    using Models.Characters.Player;
    using Models.Items.PickableItems;
    using Models.Items.Projectiles;

    public class GameEngine : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private readonly StatScreen statScreen;
        private SpriteBatch spriteBatch;

        private Player testPlayer;
        private Character sampleEnemy;
        private Level testLevel;
        private int oneSec = 1000;
        private int timeSinceLastUpdate = 0;
        private GameStages stages;
       

        public GameEngine()
        {
            this.statScreen = new StatScreen();
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }
        
        protected override void LoadContent()
        {
            this.IsMouseVisible = true;
            this.stages = GameStages.Stage1;

            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
           
            GfxHandler.Load(this.Content);
            
            GoldCoin coin = new GoldCoin(new Vector2(300, 300), "TestObjects/coin");

            // testEnemyTex = Content.Load<Texture2D>(@"TestObjects/cockSprite");
            Vector2 enemyPos = new Vector2(550, 350);
            Vector2 pos = new Vector2(
                GlobalVariables.WindowWidth / 2 - 140,
                GlobalVariables.WindowHeight / 2);

            this.sampleEnemy = new Enemy(enemyPos, @"TestObjects/cockSprite", 100, 100, 2, this.testLevel);
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
                this.Exit();
            }

            if (this.testLevel.Character.CurrentHealth <= 0)
            {
                this.stages = GameStages.Stage2;
            }

            if (this.stages == GameStages.Stage1)
            {
                this.timeSinceLastUpdate += gameTime.ElapsedGameTime.Milliseconds;
                if (this.timeSinceLastUpdate >= this.oneSec)
                {
                    this.timeSinceLastUpdate = 0;
                    this.testLevel.Character.CooldownTimer += 1;
                }
                this.testPlayer.Move();
                GfxHandler.GetSprite(this.testPlayer).Update(gameTime, this.testPlayer);

                foreach (Character enemy in this.testLevel.Enemies.ToList())
                {
                    enemy.Move();
                    GfxHandler.GetSprite(enemy).Update(gameTime, enemy);
                }

                foreach (Projectile projectile in this.testLevel.Projectiles.ToList())
                {
                    projectile.Move();
                    GfxHandler.GetSprite(projectile).Update(gameTime);
                }

            }
            else
            {

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            // Vector2 origin = new Vector2(GfxHandler.GetWidth(this.testPlayer) / 2, GfxHandler.GetHeight(this.testPlayer) / 2);
            // TODO: Add your drawing code here

            if (this.stages == GameStages.Stage1)
            {
                this.spriteBatch.Begin();


                this.testLevel.Assets.ForEach(t => this.spriteBatch.Draw(GfxHandler.GetTexture(t), t.Position));



                this.spriteBatch.End();
                this.statScreen.DrawHealth(this.testLevel.Character, this.Content, this.spriteBatch);
                GfxHandler.GetSprite(this.sampleEnemy).Draw(this.spriteBatch, this.sampleEnemy.Position);
                GfxHandler.GetSprite(this.testPlayer).Draw(this.spriteBatch, this.testPlayer.Position, this.testPlayer.FacingAngle, this.testPlayer.MovementAngle);

                foreach (var projectile in this.testLevel.Projectiles.ToList())
                {
                    GfxHandler.GetSprite(projectile).Draw(this.spriteBatch, projectile.Position, projectile.Angle);

                    if (projectile.Lifetime > projectile.Range)
                    {
                        this.testLevel.Projectiles.Remove(projectile);
                    }
                }
            }
            else
            {
                this.statScreen.EndScreen(this.Content, this.spriteBatch);
            }
            

            base.Draw(gameTime);
        }
    }
}
