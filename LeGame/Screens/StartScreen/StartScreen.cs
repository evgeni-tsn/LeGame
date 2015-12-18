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
            this.Buttons = new List<IButton>();
        }

        public override void Load(ContentManager Content)
        {
            font = Content.Load<SpriteFont>(@"Fonts/DeathFont");
            Button buttonLeft = new Button(Content.Load<Texture2D>(@"TestObjects/redheadButton"), new Vector2(130, 150));
            Button buttonMid = new Button(Content.Load<Texture2D>(@"TestObjects/guyButton"), new Vector2(330, 150));
            Button buttonRight = new Button(Content.Load<Texture2D>(@"TestObjects/blondieButton"), new Vector2(530, 150));
            this.Buttons.Add(buttonLeft);
            this.Buttons.Add(buttonRight);
            this.Buttons.Add(buttonMid);
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
            
            graphics.Clear(Color.Black);
            spriteBatch.DrawString(font, "Rattatak", new Vector2(5,5), Color.White);
            spriteBatch.DrawString(font,"Choose your character", new Vector2(250,280),Color.DarkMagenta);
            foreach (Button button in Buttons)
            {
                button.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public override string IsClicked()
        {
            string characterClass = "";
            foreach (Button button in Buttons)
            {
                if (button.IsClicked)
                {
                    if (button.Position.X.Equals(130))
                    {
                        characterClass= "Redhead";
                        button.IsClicked = false;
                        return characterClass;
                    }
                    else if (button.Position.X.Equals(330))
                    {
                        characterClass = "Guy";
                        button.IsClicked = false;
                        return characterClass;
                    }
                    else
                    {
                        characterClass = "Blondie";
                        button.IsClicked = false;
                        return characterClass;
                    }
                }

                
            }

            return null;
        }

            
    }
}
