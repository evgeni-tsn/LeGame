namespace LeGame.Core
{
    using LeGame.Core.Factories;
    using LeGame.Enumerations;
    using LeGame.Handlers;
    using LeGame.Interfaces;
    using LeGame.Screens;
    using LeGame.Screens.DeathScreen;
    using LeGame.Screens.StartScreen;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class GameEngine : Game
    {
        private readonly GraphicsDeviceManager graphics;

        private DeathScreen deathScreen;

        private ICharacter player;

        private SpriteBatch spriteBatch;

        private GameStages stage;

        private StartScreen startScreen;

        private StatPanel statPanel;

        public GameEngine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            // Vector2 origin = new Vector2(GfxHandler.GetWidth(this.testPlayer) / 2, GfxHandler.GetHeight(this.testPlayer) / 2);
            // TODO: Add your drawing code here
            if (this.stage == GameStages.GameStage)
            {
                this.statPanel.Draw(this.player, this.spriteBatch);

                GfxHandler.DrawLevel(this.spriteBatch, this.player.Level);
            }
            else if (this.stage == GameStages.DeathStage)
            {
                // this.statPanel.EndScreen(this.Content, this.spriteBatch);
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

        protected override void LoadContent()
        {
            this.IsMouseVisible = true;

            this.graphics.PreferredBackBufferWidth = GlobalVariables.WindowWidthDefault;

                // set this value to the desired width of your window
            this.graphics.PreferredBackBufferHeight = GlobalVariables.WindowHeightDefault;

                // set this value to the desired height of your window
            this.graphics.ApplyChanges();

            this.statPanel = new StatPanel();
            this.startScreen = new StartScreen();
            this.deathScreen = new DeathScreen();

            this.stage = GameStages.StartStage;

            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            GfxHandler.Load(this.Content);

            this.startScreen.Load(this.Content);
            this.deathScreen.Load(this.Content);
            this.statPanel.Load(this.Content);
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

            if (this.stage == GameStages.StartStage)
            {
                string characterClass = this.startScreen.IsClicked();

                if (characterClass != null)
                {
                    if (characterClass == "Redhead")
                    {
                        this.player = PlayerFactory.MakePlayer(PlayerChars.Redhead);
                    }
                    else if (characterClass == "Guy")
                    {
                        this.player = PlayerFactory.MakePlayer(PlayerChars.TheGuy);
                    }
                    else if (characterClass == "Blondie")
                    {
                        this.player = PlayerFactory.MakePlayer(PlayerChars.Blondy);
                    }

                    this.startScreen.UnloadButtons();
                    this.stage = GameStages.GameStage;

                    this.player.Level = LevelFactory.MakeLevel(this.player);
                }

                this.startScreen.Update(mouse);
            }

            if (this.stage == GameStages.DeathStage)
            {
                this.player.Level = null;
                string death = this.deathScreen.IsClicked();
                if (death != null)
                {
                    this.startScreen.UnloadButtons();
                    this.stage = GameStages.StartStage;
                }

                this.deathScreen.Update(mouse);
            }

            if (this.stage == GameStages.GameStage)
            {
                GfxHandler.UpdateLevel(gameTime, this.player.Level);

                if (this.player.CurrentHealth <= 0)
                {
                    this.stage = GameStages.DeathStage;
                    this.player.Level = null;
                }
            }

            base.Update(gameTime);
        }
    }
}