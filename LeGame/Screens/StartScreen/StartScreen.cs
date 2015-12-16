using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Screens.StartScreen
{
    using Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class StartScreen : Screen
    {

        public List<Button> buttons;
        public SpriteFont font;

        //public ICollection<IButton> Buttons { get; } 
        public StartScreen()
        {
            this.buttons = new List<Button>();
        }

        public void Load(ContentManager Content)
        {
            font = Content.Load<SpriteFont>(@"Fonts/DeathFont");
            Button buttonLeft = new Button(Content.Load<Texture2D>(@"TestObjects/redheadButton"), new Vector2(130, 150));
            Button buttonMid = new Button(Content.Load<Texture2D>(@"TestObjects/guyButton"), new Vector2(330, 150));
            Button buttonRight = new Button(Content.Load<Texture2D>(@"TestObjects/blondieButton"), new Vector2(530, 150));
            this.buttons.Add(buttonLeft);
            this.buttons.Add(buttonRight);
            this.buttons.Add(buttonMid);
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
            
            graphics.Clear(Color.Black);
            spriteBatch.DrawString(font, "Rattatak", new Vector2(5,5), Color.White);
            spriteBatch.DrawString(font,"Choose your character", new Vector2(250,280),Color.DarkMagenta);
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
                   // button.IsClicked = true;
                    return button;
            }
           
            return null;
        }

        




    }
}
