using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace LeGame.Screens
{
    public interface IScreen
    {
        ICollection<IButton> Buttons { get; }
        void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics);
        void Update(MouseState mouse);
        IButton IsClicked();
        void Load(ContentManager content);

    }
}
