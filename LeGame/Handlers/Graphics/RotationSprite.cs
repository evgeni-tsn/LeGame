namespace LeGame.Handlers.Graphics
{
    using LeGame.Models.Characters;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RotationSprite : Sprite
    {
        private const int TimePerFrame = 30;

        public RotationSprite(Texture2D texture) 
            : base(texture)
        {
            this.CurrentFrame = 0;
            this.TotalFrames = this.Rows * this.Columns;
        }

        public override void Update(GameTime gameTime, Character character = null)
        {
            this.TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (this.TimeSinceLastFrame < TimePerFrame)
            {
                return;
            }

            // this.CurrentFrame = GlobalVariables.Rng.Next(0, this.TotalFrames);
            this.CurrentFrame++;
            if (this.CurrentFrame == this.TotalFrames)
            {
                this.CurrentFrame = 0;
            }

        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, float rotation = 0, float rotationB = 0)
        {
            int width = this.Texture.Width / this.Columns;
            int height = this.Texture.Height / this.Rows;
            int row = this.CurrentFrame / this.Columns;
            int column = this.CurrentFrame % this.Columns;
            var origin = new Vector2(width / 2f, height / 2f);
            
            Rectangle source = new Rectangle(width * column, height * row, width, height);
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(this.Texture, null, destination, source, origin, rotation + 1.55f, null, null);
            spriteBatch.End();
        }
    }
}
