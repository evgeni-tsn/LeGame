namespace LeGame.Graphics
{
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;

    using LeGame.Enumerations;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Models.Characters.Enemies;

    public class FourDirectionSprite : Sprite
    {
        private const int FourDirectionSpriteUpdateTime = 130;

        private readonly Dictionary<Keys, MoveDirection> keyToDirection = new Dictionary<Keys, MoveDirection>
        {
            { Keys.D, MoveDirection.Right },
            { Keys.A, MoveDirection.Left },
            { Keys.W, MoveDirection.Up },
            { Keys.S, MoveDirection.Down }
        };

        private readonly Dictionary<MoveDirection, int[]> directionToFrames = new Dictionary<MoveDirection, int[]>
        {
            { MoveDirection.Right, new[] { 6, 7, 8 } },
            { MoveDirection.Up, new[] { 9, 10, 11 } },
            { MoveDirection.Left, new[] { 3, 4, 5 } },
            { MoveDirection.Down, new[] { 0, 1, 2 } }
        };

        public FourDirectionSprite(Texture2D texture) 
            : base(texture, FourDirectionSpriteUpdateTime)
        {
            this.TotalFrames = this.Rows * this.Columns;
            this.CurrentFrame = 0;
        }

        public override void Update(GameTime gameTime, ICharacter character)
        {
            this.TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (this.TimeSinceLastFrame < this.TimePerFrame)
            {
                return;
            }
            this.TimeSinceLastFrame = gameTime.ElapsedGameTime.Milliseconds;

            if (character is ICollidable)
            {
                // Enemy
                this.SpriteRotaions(gameTime, ((Enemy)character).Direction);
            }
            else
            {
                // Player
                foreach (Keys key in this.keyToDirection.Keys.Where(key => Keyboard.GetState().IsKeyDown(key)))
                {
                    this.SpriteRotaions(gameTime, this.keyToDirection[key]);
                    break;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, float a = 0, float b = 0, Texture2D additionalTexture = null)
        {
            int width = this.Texture.Width / this.Columns;
            int height = this.Texture.Height / this.Rows;
            int row = this.CurrentFrame / this.Columns;
            int column = this.CurrentFrame % this.Columns;

            var sourceRectangle = new Rectangle(width * column, height * row, width, height);
            var destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        private void SpriteRotaions(GameTime gameTime, MoveDirection direction)
        {
            foreach (MoveDirection direct in this.directionToFrames.Keys.Where(key => direction.Equals(key)))
            {
                if (this.directionToFrames[direct].Contains(this.CurrentFrame))
                {
                    this.CurrentFrame++;
                    if (this.CurrentFrame == this.directionToFrames[direct][2] + 1)
                    {
                        this.CurrentFrame = this.directionToFrames[direct][0];
                    }
                }
                else
                {
                    this.CurrentFrame = this.directionToFrames[direct][0];
                }
            }
        }
    }
}