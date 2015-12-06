using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LeGame.Models.Characters;
using LeGame.Interfaces;
using LeGame.Models.Characters.Enemies;

namespace LeGame.Handlers
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        private Dictionary<Keys, string> keyToDirection = new Dictionary<Keys, string>
        {
            { Keys.D, "Right" },
            { Keys.A, "Left" },
            { Keys.W, "Up"},
            { Keys.S, "Down" },
        };

        private Dictionary<string, int[]> directionToFrames = new Dictionary<string, int[]>
        {
            { "Right", new[] { 6, 7, 8 } },
            { "Up", new[] { 9, 10, 11 } },
            { "Left", new[] { 3, 4, 5 } }, 
            { "Down", new[] { 0, 1, 2 } },
        };

        private int timeSinceLastFrame = 0;
        private int timePerFrame = 150;

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Update(GameTime gameTime, Character character)
        {
            if(character is ICollisionable)
            {
                // Enemy
                SpriteRotaions(gameTime, (character as SampleEnemy).Direction);
            }
            else
            {
                // Player
                foreach (var key in keyToDirection.Keys.Where(key => Keyboard.GetState().IsKeyDown(key)))
                {
                    SpriteRotaions(gameTime, keyToDirection[key]);
                    break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;
            // Color color = new Color(100, 100, 100, 100);
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle,Color.White);
            spriteBatch.End();
        }

        public int SpriteRotaions(GameTime gameTime, string direction)
        {
            // Coldown for the animation
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame < timePerFrame)
            {
                return currentFrame;
            }
            timeSinceLastFrame = gameTime.ElapsedGameTime.Milliseconds;
            // If enough time has passed 

            // go through directionToFrames and find the one coresponding to the direction
            foreach (var direct in directionToFrames.Keys.Where(key => direction.Equals(key)))
            {
                if (directionToFrames[direct].Contains(currentFrame))
                {
                    currentFrame++;
                    if (currentFrame == directionToFrames[direct][2] + 1)
                    {
                        currentFrame = directionToFrames[direct][0];
                    }
                }
                else
                {
                    currentFrame = directionToFrames[direct][0];
                }
            }

            return currentFrame;
        }
    }
}