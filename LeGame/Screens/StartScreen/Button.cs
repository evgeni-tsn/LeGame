using System;
using LeGame.Core;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Screens.StartScreen
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Button : IButton
    {
        private Color colour = new Color(255, 255, 255, 255);
        Texture2D texture;
        private Vector2 position;
        private bool down;
        private bool isClicked;

        public Button(Texture2D newTexture, Vector2 position)
        {
           
            this.Position = position;
            this.Texture = newTexture;
        }

        public Rectangle BoundingBox
        {
            get { return new Rectangle((int) Position.X, (int) Position.Y, (int)Texture.Width, (int)Texture.Height); }

        }

        public Texture2D Texture
        {
            get
            {
                return texture;
            }

            set
            {
                texture = value;
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

        public bool Down
        {
            get
            {
                return down;
            }

            set
            {
                down = value;
            }
        }

        public bool IsClicked
        {
            get
            {
                return isClicked;
            }

            set
            {
                isClicked = value;
            }
        }

        public Color Colour
        {
            get
            {
                return colour;
            }

            set
            {
                colour = value;
            }
        }


        public void Update(MouseState mouse)
        {
            
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1,1);

            if (mouseRectangle.Intersects(this.BoundingBox))
            {
                if (colour.A == 255)
                {
                    down = false;
                }   
                if (colour.A == 27)
                {
                    down = true;
                }
                if (down)
                {
                    colour.A += 3;
                }
                else
                {
                    colour.A -= 3;
                }

                if (mouse.LeftButton == ButtonState.Pressed) IsClicked = true;
               
            }
            else if (colour.A < 255)
            {
                colour.A += 3;
                IsClicked = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, this.BoundingBox,Colour);

        }
    }
}
