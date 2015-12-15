using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Screens.StartScreen
{
    using Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class StartScreen
    {

        public List<Button> buttons;

        public StartScreen()
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
            spriteBatch.DrawString(font,"Choose your character", new Vector2(300,300),Color.Black);
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
