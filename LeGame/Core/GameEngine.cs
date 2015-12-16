namespace LeGame.Core
{
    using Enumerations;

    using Handlers;

    using LeGame.Core.Factories;
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Models.Items.PickableItems;

    using Screens;
    using Screens.DeathScreen;
    using Screens.StartScreen;

    public class GameEngine : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private StartScreen startScreen;
        private DeathScreen deathScreen;
        private StatPanel statPanel;
        private GameStages stage;

        private ICharacter player;

        public GameEngine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }
        
        protected override void LoadContent()
        {
            this.IsMouseVisible = true;

            this.graphics.PreferredBackBufferWidth = GlobalVariables.WindowWidthDefault; // set this value to the desired width of your window
            this.graphics.PreferredBackBufferHeight = GlobalVariables.WindowHeightDefault;   // set this value to the desired height of your window
            this.graphics.ApplyChanges();
            this.statPanel = new StatPanel();
            this.startScreen = new StartScreen();
            this.deathScreen = new DeathScreen();

            this.stage = GameStages.Start_Stage;

            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            
            GfxHandler.Load(this.Content);
            
            // TODO: Ad an item factory.
            GoldCoin coin = new GoldCoin(new Vector2(300, 300), "TestObjects/coin");

            this.startScreen.Load(this.Content);
            this.deathScreen.Load(this.Content);
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            GlobalVariables.GlobalTimer += gameTime.ElapsedGameTime.Milliseconds;

            MouseState mouse = Mouse.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (this.stage == GameStages.Start_Stage)
            {
                IButton button = this.startScreen.IsClicked();

                if (button != null)
                {
                    if (button.Position.X.Equals(130))
                    {
                        this.player = PlayerFacory.MakePlayer(PlayerChars.Redhead);
                    }
                    else if (button.Position.X.Equals(330))
                    {
                        this.player = PlayerFacory.MakePlayer(PlayerChars.TheGuy);
                    }
                    else
                    {
                        this.player = PlayerFacory.MakePlayer(PlayerChars.Blondy);
                    }

                    this.stage = GameStages.GameStage;
                    this.player.Level = LevelFactory.MakeLevel(Maps.HouseMap, this.player);
                }

                this.startScreen.Update(mouse);
            }

            if (this.stage == GameStages.DeathStage)
            {
                var button = this.deathScreen.IsClicked();
                if (button != null)
                {    
                    this.stage = GameStages.Start_Stage;
                }

                this.deathScreen.Update(mouse);
            }

            if (this.stage == GameStages.GameStage)
            {
                GfxHandler.UpdateLevel(gameTime, this.player.Level);

                if (this.player.CurrentHealth <= 0)
                {
                    this.stage = GameStages.DeathStage;
                }
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
                this.statPanel.DrawHealth(this.player, this.Content, this.spriteBatch);

                GfxHandler.DrawLevel(this.spriteBatch, this.player.Level);
            }
            else if (this.stage == GameStages.DeathStage)
            {
                //this.statPanel.EndScreen(this.Content, this.spriteBatch);
                this.GraphicsDevice.Clear(Color.AliceBlue);
                this.deathScreen.Draw(this.spriteBatch, this.GraphicsDevice);
            }
            else
            {
                this.GraphicsDevice.Clear(Color.Wheat);
                this.startScreen.Draw(this.spriteBatch, this.GraphicsDevice);
            }


            base.Draw(gameTime);
        }   
    }
}
