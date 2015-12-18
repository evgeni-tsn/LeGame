using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Handlers;
using LeGame.Screens.StartScreen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Screens.DeathScreen
{
    public class DeathScreen : Screen
    {
        public List<Button> buttons;
        private SpriteFont font;

        public DeathScreen()
        {
            this.Buttons = new List<IButton>();
        }

        public override void Load(ContentManager content)
        {
            font = content.Load<SpriteFont>(@"Fonts/SpriteFont");
            Button replay = new Button(content.Load<Texture2D>(@"TestObjects/kappa"), new Vector2(300, 250));
            Buttons.Add(replay);
        }

        public override void Update(MouseState mouse)
        {
            foreach (Button button in Buttons)
            {
                button.Update(mouse);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "GG NOOB", new Vector2(300, 100), Color.Red);
            spriteBatch.DrawString(font, "I AM NOT A NOOB BUTTON", new Vector2(260, 350), Color.Red);
            foreach (Button button in Buttons)
            {
                button.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public override string IsClicked()
        {
            foreach (Button button in Buttons)
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

    }
}
