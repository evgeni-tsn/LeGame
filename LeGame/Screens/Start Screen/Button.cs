using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace LeGame.Screens.Start_Screen
{
    public class Button
    {
        private Texture2D buttonPic;
        private Vector2 position;
        public Button(Texture2D texture, Vector2 position)
        {
            this.ButtonPic = texture;
            this.Position = position;
        }

        public Texture2D ButtonPic
        {
            get
            {
                return buttonPic;
            }

            set
            {
                buttonPic = value;
            }
        }
        public Vector2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public Rectangle BoundingBox { get { return new Rectangle((int)this.Position.X, (int)this.Position.Y, this.ButtonPic.Width, this.ButtonPic.Height);} }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(this.ButtonPic, this.Position, this.BoundingBox, Color.White);
            sb.End();
        }
    }
}
