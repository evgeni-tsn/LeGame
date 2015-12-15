using System;
using LeGame.Core;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Screens.StartScreen
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Button
    {
        Texture2D texture;
        private Vector2 position;

        Rectangle rectangle;
        Color colour = new Color(255,255,255,255);

        public Vector2 size;

        public Button(Texture2D newTexture, Vector2 position)
        {
            //global width = 800 global height = 480
            //img w = 140 h = 100
            this.position = position;
            this.texture = newTexture;
            size = new Vector2(texture.Width, texture.Height);

        }

        bool down;
        public bool isClicked;
        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int) position.X, (int) position.Y, (int)size.X,(int)size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1,1);

            if (mouseRectangle.Intersects(rectangle))
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

                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
               
            }
            else if (colour.A < 255)
            {
                colour.A += 3;
                isClicked = false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);

        }
    }
}
