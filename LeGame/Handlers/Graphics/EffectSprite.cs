using LeGame.Models.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Handlers.Graphics
{
    public class EffectSprite : RotationSprite
    {
        private const int TimePerFrame = 50;

        public EffectSprite(Texture2D texture)
            : base(texture)
        {
            this.Rotation = 0;
        }

        private float Rotation { get; set; }

        public override void Update(GameTime gameTime, Character character = null)
        {
            this.TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (this.TimeSinceLastFrame < TimePerFrame)
            {
                return;
            }

            if (this.CurrentFrame != this.TotalFrames - 1)
            {
                this.CurrentFrame++;
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
