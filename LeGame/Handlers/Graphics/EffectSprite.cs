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
        }

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
    }
}
