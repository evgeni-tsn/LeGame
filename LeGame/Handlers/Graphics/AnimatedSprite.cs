using System.Collections.Generic;
using System.Linq;
using LeGame.Interfaces;
using LeGame.Models.Characters;
using LeGame.Models.Characters.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Handlers.Graphics
{
    public class AnimatedSprite : Sprite
    {
        private const int TimePerFrame = 130;
        
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

        private int totalFrames;
        private int currentFrame;
        private int timeSinceLastFrame;

        public AnimatedSprite(Texture2D texture) 
            : base(texture)
        {
            this.totalFrames = this.Rows * this.Columns;
            this.currentFrame = 0;
        }
        
        public override void Update(GameTime gameTime, Character character)
        {
            if (character is ICollisionable)
            {
                // Enemy
                SpriteRotaions(gameTime, ((SampleEnemy)character).Direction);
            }
            else
            {
                // Player
                foreach (var key in this.keyToDirection.Keys.Where(key => Keyboard.GetState().IsKeyDown(key)))
                {
                    SpriteRotaions(gameTime, this.keyToDirection[key]);
                    break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = this.Texture.Width / this.Columns;
            int height = this.Texture.Height / this.Rows;
            int row = this.currentFrame / this.Columns;
            int column = this.currentFrame % this.Columns;
            // Color color = new Color(100, 100, 100, 100);
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public int SpriteRotaions(GameTime gameTime, string direction)
        {
            // Coldown for the animation
            this.timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (this.timeSinceLastFrame < TimePerFrame)
            {
                return this.currentFrame;
            }
            this.timeSinceLastFrame = gameTime.ElapsedGameTime.Milliseconds;
            // If enough time has passed 

            // go through directionToFrames and find the one coresponding to the direction
            foreach (var direct in this.directionToFrames.Keys.Where(key => direction.Equals(key)))
            {
                if (this.directionToFrames[direct].Contains(this.currentFrame))
                {
                    this.currentFrame++;
                    if (this.currentFrame == this.directionToFrames[direct][2] + 1)
                    {
                        this.currentFrame = this.directionToFrames[direct][0];
                    }
                }
                else
                {
                    this.currentFrame = this.directionToFrames[direct][0];
                }
            }
            return this.currentFrame;
        }
    }
}