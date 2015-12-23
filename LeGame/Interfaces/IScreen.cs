namespace LeGame.Interfaces
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public interface IScreen
    {
        ICollection<IButton> Buttons { get; }

        void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics);

        string IsClicked();

        void Load(ContentManager content);

        void UnloadButtons();

        void Update(MouseState mouse);
    }
}