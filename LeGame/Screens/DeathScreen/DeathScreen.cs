namespace LeGame.Screens.DeathScreen
{
    using System.Collections.Generic;

    using LeGame.Handlers;
    using LeGame.Interfaces;
    using LeGame.Screens.StartScreen;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class DeathScreen : Screen
    {
        private List<Button> buttons;

        private SpriteFont font;

        public DeathScreen()
        {
            this.Buttons = new List<IButton>();
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(this.font, "GG NOOB", new Vector2(300, 100), Color.Red);
            spriteBatch.DrawString(this.font, "I AM NOT A NOOB BUTTON", new Vector2(260, 350), Color.Red);
            foreach (Button button in this.Buttons)
            {
                button.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        public override string IsClicked()
        {
            foreach (Button button in this.Buttons)
            {
                if (button.IsClicked)
                {
                    GfxHandler.ClearEffects();
                    button.IsClicked = false;
                    return "Replay";
                }
            }

            return null;
        }

        public override void Load(ContentManager content)
        {
            this.font = content.Load<SpriteFont>(@"Fonts/SpriteFont");
            Button replay = new Button(content.Load<Texture2D>(@"TestObjects/kappa"), new Vector2(300, 250));
            this.Buttons.Add(replay);
        }

        public override void Update(MouseState mouse)
        {
            foreach (Button button in this.Buttons)
            {
                button.Update(mouse);
            }
        }
    }
}