namespace LeGame.Core
{
    using Enumerations;
    using Handlers;
    using Models;
    using Models.Characters;
    using Models.Characters.Enemies;
    using Models.Characters.Player;
    using Models.Items.PickableItems;
    using Screens.StartScreen;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class GameEngine : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private StartScreen startScreen;
        private StatScreen statScreen;

        private Player testPlayer;
        private Character sampleEnemy;
        private Level testLevel;
        private GameStages stage;
       

        public GameEngine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            
        }
        
        protected override void LoadContent()
        {
            this.IsMouseVisible = true;

            this.statScreen = new StatScreen();
            //Commented because it disables mouse capturing.
            //this.startScreen = new StartScreen();
            this.stage = GameStages.GameStage;

            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            
            GfxHandler.Load(this.Content);
            
            GoldCoin coin = new GoldCoin(new Vector2(300, 300), "TestObjects/coin");

            // testEnemyTex = Content.Load<Texture2D>(@"TestObjects/cockSprite");
            Vector2 enemyPos = new Vector2(550, 350);
            Vector2 pos = new Vector2(
                GlobalVariables.WindowWidthDefault / 2 - 140,
                GlobalVariables.WindowHeightDefault / 2f);

            this.sampleEnemy = new Chicken(enemyPos, this.testLevel);
            this.sampleEnemy.Damaged += (sender, args) => GfxHandler.AddBloodEffect(sender);
            this.sampleEnemy.Died += (sender, args) => GfxHandler.AddDeathEffect(sender);

            this.testPlayer = new TheGuy(pos, this.testLevel);
            this.testPlayer.Damaged += (sender, args) => GfxHandler.AddBloodEffect(sender);
            this.testPlayer.Died += (sender, args) => GfxHandler.AddDeathEffect(sender);

            this.testLevel = new Level(@"..\..\..\Content\Maps\BloodyMap.txt", this.testPlayer);
            this.testLevel.Assets.Add(coin);

            this.sampleEnemy.Level = this.testLevel;
            this.testPlayer.Level = this.testLevel;
            this.testLevel.Enemies.Add(this.sampleEnemy);

            // TODO: Get Width and Heignt based on the level size?
            this.graphics.PreferredBackBufferWidth = GlobalVariables.WindowWidthDefault; // set this value to the desired width of your window
            this.graphics.PreferredBackBufferHeight = GlobalVariables.WindowHeightDefault;   // set this value to the desired height of your window
            this.graphics.ApplyChanges();
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            GlobalVariables.GlobalTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (this.stage == GameStages.GameStage && this.testLevel.Player.CurrentHealth <= 0)
            {
                this.stage = GameStages.DeathStage;
            }

            //if(stage == GameStages.Start_Stage)
            //{
            //    this.staRtScreen.Update(gameTime);
            //}
            
            if (this.stage == GameStages.GameStage)
            {
                GfxHandler.UpdateLevel(gameTime, this.testLevel);
            }
            else
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            // Vector2 origin = new Vector2(GfxHandler.GetWidth(this.testPlayer) / 2, GfxHandler.GetHeight(this.testPlayer) / 2);
            // TODO: Add your drawing code here
            if (this.stage == GameStages.GameStage)
            {
                this.statScreen.DrawHealth(this.testLevel.Player, this.Content, this.spriteBatch);

                GfxHandler.DrawLevel(this.spriteBatch, this.testLevel);
            }
            else if (this.stage == GameStages.DeathStage)
            {
                this.statScreen.EndScreen(this.Content, this.spriteBatch);
            }
            else
            {
                //this.startScreen.DrawStartScreen(this.spriteBatch, this.Content);
            }


            base.Draw(gameTime);
        }   
    }
}
