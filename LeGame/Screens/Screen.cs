namespace LeGame.Screens
{
    using System.Collections.Generic;
    using LeGame.Interfaces;
    using LeGame.Screens.StartScreen;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public abstract class Screen : IScreen
    {
        public ICollection<IButton> Buttons { get; set; }

        public abstract void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics);

        public abstract void Update(MouseState mouse);

        public abstract string IsClicked();

        public abstract void Load(ContentManager content);

        public void UnloadButtons()
        {
            foreach (Button button in this.Buttons)
            {
                button.IsClicked = false;
            }
        }
    }
}
