namespace LeGame.Handlers.Graphics
{
    using LeGame.Engine;
    using LeGame.Interfaces;
    using LeGame.Models.Characters;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Sprite : ISprite
    {

        protected Sprite(Texture2D texture, int timePerFrame)
        {
            this.Texture = texture;
            this.Rows = this.Texture.Height / GlobalVariables.TileHeight;
            this.Columns = this.Texture.Width / GlobalVariables.TileWidth;
            this.TimePerFrame = timePerFrame;
        }

        public int Rows { get; set; }

        public int Columns { get; set; }

        protected int CurrentFrame { get; set; }

        protected int TotalFrames { get; set; }

        protected int TimePerFrame { get; set; }

        protected int TimeSinceLastFrame { get; set; }

        protected Texture2D Texture { get; }

        public abstract void Update(GameTime gameTime, ICharacter character = null);

        public abstract void Draw(SpriteBatch spriteBatch, Vector2 location, float rotationA = 0, float rotationB = 0);
    }
}