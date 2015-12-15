namespace LeGame.Graphics
{
    using Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RotationSprite : Sprite
    {
        private const int RotationSpriteUpdateTIme = 40;

        public RotationSprite(Texture2D texture) 
            : base(texture, RotationSpriteUpdateTIme)
        {
            this.CurrentFrame = 0;
            this.TotalFrames = this.Rows * this.Columns;
        }

        public override void Update(GameTime gameTime, ICharacter character = null)
        {
            this.TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (this.TimeSinceLastFrame < this.TimePerFrame)
            {
                return;
            }
            this.TimeSinceLastFrame = gameTime.ElapsedGameTime.Milliseconds;

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
