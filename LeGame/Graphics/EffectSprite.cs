namespace LeGame.Graphics
{
    using LeGame.Engine;
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class EffectSprite : RotationSprite
    {
        public EffectSprite(Texture2D texture, bool isPersistant = false)
            : base(texture)
        {
            this.Rotation = 0;
            this.HasEnded = false;
            this.IsPersistant = isPersistant;
        }

        public bool HasEnded { get; private set; }

        public bool IsPersistant { get; private set; }

        private float Rotation { get; set; }

        public override void Update(GameTime gameTime, ICharacter character = null)
        {
            this.TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (this.TimeSinceLastFrame < this.TimePerFrame)
            {
                return;
            }
            this.TimeSinceLastFrame = gameTime.ElapsedGameTime.Milliseconds;

            if (this.CurrentFrame != this.TotalFrames - 1)
            {
                this.CurrentFrame++;
            }
            else if (!this.HasEnded)
            {
                this.HasEnded = true;
            }

        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, float rotation = 0, float rotationB = 0)
        {
            // If rotation is not used, generate random rotation a single time for effect variety.
            if (this.Rotation.Equals(0) && rotation.Equals(0))
            {
                this.Rotation = (float)GlobalVariables.Rng.NextDouble() + GlobalVariables.Rng.Next(-1, 4);
            }
            else if (!rotation.Equals(0))
            {
                this.Rotation = rotation;
            }

            base.Draw(spriteBatch, location, this.Rotation, rotationB);
        }
    }
}
