namespace LeGame.Screens.StartScreen
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Button : IButton
    {
        private Color colour = new Color(255, 255, 255, 255);

        public Button(Texture2D newTexture, Vector2 position)
        {
           
            this.Position = position;
            this.Texture = newTexture;
        }

        public Rectangle BoundingBox => new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Texture.Width, this.Texture.Height);

        public Texture2D Texture { get; set; }

        public Vector2 Position { get; set; }

        public bool Down { get; set; }

        public bool IsClicked { get; set; }

        public Color Colour
        {
            get
            {
                return this.colour;
            }

            set
            {
                this.colour = value;
            }
        }
        
        public void Update(MouseState mouse)
        {
            
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(this.BoundingBox))
            {
                if (this.colour.A == 255)
                {
                    this.Down = false;
                }
   
                if (this.colour.A == 27)
                {
                    this.Down = true;
                }

                if (this.Down)
                {
                    this.colour.A += 3;
                }
                else
                {
                    this.colour.A -= 3;
                }

                if (mouse.LeftButton == ButtonState.Pressed) this.IsClicked = true;
               
            }
            else if (this.colour.A < 255)
            {
                this.colour.A += 3;
                this.IsClicked = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.BoundingBox, this.Colour);

        }
    }
}
