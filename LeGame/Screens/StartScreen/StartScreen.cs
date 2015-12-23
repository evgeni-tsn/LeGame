namespace LeGame.Screens.StartScreen
{
    using System.Collections.Generic;

    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class StartScreen : Screen
    {
        private List<Button> buttons;

        private SpriteFont font;

        // public ICollection<IButton> Buttons { get; } 
        public StartScreen()
        {
            this.Buttons = new List<IButton>();
        }

        public override void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            spriteBatch.Begin();

            graphics.Clear(Color.Black);
            spriteBatch.DrawString(this.font, "Rattatak", new Vector2(5, 5), Color.White);
            spriteBatch.DrawString(this.font, "Choose your character", new Vector2(250, 280), Color.DarkMagenta);
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
                    string characterClass;
                    if (button.Position.X.Equals(130))
                    {
                        characterClass = "Redhead";
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

        public override void Load(ContentManager content)
        {
            this.font = content.Load<SpriteFont>(@"Fonts/DeathFont");
            Button buttonLeft = new Button(content.Load<Texture2D>(@"TestObjects/redheadButton"), new Vector2(130, 150));
            Button buttonMid = new Button(content.Load<Texture2D>(@"TestObjects/guyButton"), new Vector2(330, 150));
            Button buttonRight = new Button(
                content.Load<Texture2D>(@"TestObjects/blondieButton"), 
                new Vector2(530, 150));
            this.Buttons.Add(buttonLeft);
            this.Buttons.Add(buttonRight);
            this.Buttons.Add(buttonMid);
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