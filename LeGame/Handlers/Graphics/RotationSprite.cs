using System.Linq;
using LeGame.Models.Characters;
using LeGame.Models.Characters.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Handlers.Graphics
{
    public class RotationSprite : Sprite
    {
        private const int timePerFrame = 50;
        private readonly int totalFrames;

        private bool reverse;
        private int currentFrame;
        private int timeSinceLastFrame;

        public RotationSprite(Texture2D texture) 
            : base(texture)
        {
            this.currentFrame = 5;
            this.totalFrames = this.Columns;
        }

        public override void Update(GameTime gameTime, Character character)
        {
            this.timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (this.timeSinceLastFrame < timePerFrame)
            {
                return;
            }

            this.timeSinceLastFrame = gameTime.ElapsedGameTime.Milliseconds;
            
            KeyboardState kbStatew = Keyboard.GetState();

            bool moving = ((Player) character).KbKeys.Any(key => kbStatew.IsKeyDown(key));

            if (moving || this.currentFrame != 5)
            {
                if (this.reverse)
                {
                    this.currentFrame--;
                }
                else
                {
                    this.currentFrame++;
                }
                
                if ((this.currentFrame == this.totalFrames - 1 || this.currentFrame == 0))
                {
                    this.reverse = !this.reverse;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, float torsoRotation, float legRotation)
        {
            int width = this.Texture.Width /this.Columns;
            int height = this.Texture.Height /this.Rows;
            int legsRow = 0;
            int torsoRow = 3;
            int column = this.currentFrame %this.Columns;
            var origin = new Vector2(width / 2f, height / 2f);

            Rectangle torsoSource = new Rectangle(width * column, height * torsoRow, width, height);
            Rectangle legsSource = new Rectangle(width * column, height * legsRow, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            spriteBatch.Draw(this.Texture, null, destinationRectangle, legsSource, origin, legRotation, null, null);
            spriteBatch.Draw(this.Texture, null, destinationRectangle, torsoSource, origin, torsoRotation, null, null);
            spriteBatch.End();
        }
    }
}
