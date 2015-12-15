namespace LeGame.Graphics
{
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Models.Characters.Enemies;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class FourDirectionSprite : Sprite
    {
        private const int FourDirectionSpriteUpdateTime = 130;

        private readonly Dictionary<Keys, string> keyToDirection = new Dictionary<Keys, string>
        {
            { Keys.D, "Right" },
            { Keys.A, "Left" },
            { Keys.W, "Up"},
            { Keys.S, "Down" }
        };

        private readonly Dictionary<string, int[]> directionToFrames = new Dictionary<string, int[]>
        {
            { "Right", new[] { 6, 7, 8 } },
            { "Up", new[] { 9, 10, 11 } },
            { "Left", new[] { 3, 4, 5 } },
            { "Down", new[] { 0, 1, 2 } }
        };

        public FourDirectionSprite(Texture2D texture, ICharacter character = null) 
            : base(texture, FourDirectionSpriteUpdateTime)
        {
            this.Character = character;
            this.TotalFrames = this.Rows * this.Columns;
            this.CurrentFrame = 0;
        }

        public ICharacter Character { get; }

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
                foreach (var key in this.keyToDirection.Keys.Where(key => Keyboard.GetState().IsKeyDown(key)))
                {
                    this.SpriteRotaions(gameTime, this.keyToDirection[key]);
                    break;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, float a = 0, float b = 0)
        {
            int width = this.Texture.Width / this.Columns;
            int height = this.Texture.Height / this.Rows;
            int row = this.CurrentFrame / this.Columns;
            int column = this.CurrentFrame % this.Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        private void SpriteRotaions(GameTime gameTime, string direction)
        {
            // If enough time has passed 
            // go through directionToFrames and find the one coresponding to the direction
            foreach (string direct in this.directionToFrames.Keys.Where(key => direction.Equals(key)))
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