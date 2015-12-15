namespace LeGame.Screens.StartScreen
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Button
    {
        public Button(Texture2D texture, Vector2 position)
        {
            this.ButtonPic = texture;
            this.Position = position;
        }

        public Texture2D ButtonPic { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)this.Position.X, (int)this.Position.Y, this.ButtonPic.Width, this.ButtonPic.Height);
            }
        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(this.ButtonPic, this.Position, this.BoundingBox, Color.White);
            sb.End();
        }
    }
}
