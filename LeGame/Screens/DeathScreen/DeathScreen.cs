using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.buttons = new List<Button>();
        }

        public override void Load(ContentManager content)
        {
            font = content.Load<SpriteFont>(@"Fonts/SpriteFont");
            Button replay = new Button(content.Load<Texture2D>(@"TestObjects/kappa"), new Vector2(300, 150));
            buttons.Add(replay);
        }

        public override void Update(MouseState mouse)
        {
            foreach (Button button in buttons)
            {
                button.Update(mouse);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "GG NOOB", new Vector2(300, 100), Color.Red);
            spriteBatch.DrawString(font, "I AM NOT A NOOB BUTTON", new Vector2(260, 300), Color.Red);
            foreach (Button button in buttons)
            {
                button.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public override IButton IsClicked()
        {
            foreach (Button button in buttons)
            {
                if (button.IsClicked)
                    return button;
            }
            return null;
        }

    }
}
