using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Screens.StartScreen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Screens.DeathScreen
{
    public class DeathScreen
    {
        public List<Button> buttons;

        public DeathScreen()
        {
            this.buttons = new List<Button>();
        }

        public void Update(MouseState mouse)
        {
            foreach (Button button in buttons)
            {
                button.Update(mouse);
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
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

        public bool IsClicked()
        {
            foreach (Button button in buttons)
            {
                if (button.isClicked)
                    return true;
            }
            return false;
        }

    }
}
