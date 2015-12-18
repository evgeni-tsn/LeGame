using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Screens.StartScreen;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Screens
{
    using LeGame.Interfaces;

    public abstract class Screen : IScreen
    {
       
        public  ICollection<IButton> Buttons { get; set; }
        public abstract void Draw(SpriteBatch spriteBatch,  GraphicsDevice graphics);
        public abstract void Update(MouseState mouse);
        public abstract string IsClicked();
        public abstract void Load(ContentManager content);

        public void UnloadButtons()
        {
            foreach (Button button in Buttons)
            {
                button.IsClicked = false;
            }
        }
    
    }
}
