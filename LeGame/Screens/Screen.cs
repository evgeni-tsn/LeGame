using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Screens
{
    public abstract class Screen : IScreen
    {
       
        public  ICollection<IButton> Buttons { get; }
        public abstract void Draw(SpriteBatch spriteBatch,  GraphicsDevice graphics);
        public abstract void Update(MouseState mouse);
        public abstract IButton IsClicked();
        public abstract void Load(ContentManager content);
    }
}
