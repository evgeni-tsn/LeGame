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

        private Dictionary<Keys, int[]> Frames = new Dictionary<Keys, int[]>()
        {
            { Keys.D, new int[] { 6, 7, 8 } },          //RightFrames
            { Keys.W, new int[] { 9, 10, 11 } },        //LeftFrames
            { Keys.A, new int[] { 3, 4, 5 } },          //DownFrames
            { Keys.S, new int[] { 0, 1, 2 } },          //UpFrames
        };

        private Dictionary<string, int[]> AIFrames = new Dictionary<string, int[]>()
        {
            { "Right", new int[] { 6, 7, 8 } },
            { "Up", new int[] { 9, 10, 11 } },
            { "Left", new int[] { 3, 4, 5 } }, 
            { "Down", new int[] { 0, 1, 2 } },
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
                AISpriteRotaions(gameTime, (character as SampleEnemy).Direction);
            }
            else
            {
                PlayerSpriteRotations(gameTime);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
           // Color color = new Color(100, 100, 100, 100);
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle,Color.White);
            spriteBatch.End();
        }

        public int PlayerSpriteRotations(GameTime gameTime) 
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame < timePerFrame)
            {
                return currentFrame;
            }
            timeSinceLastFrame = gameTime.ElapsedGameTime.Milliseconds;

            foreach (var key in Frames.Keys)
            {
                if (Keyboard.GetState().IsKeyDown(key))
                {
                    if (Frames[key].Contains(currentFrame))
                    {
                        currentFrame++;
                        if (currentFrame == Frames[key][2] + 1)
                        {
                            currentFrame = Frames[key][0];
                        }
                    }
                    else
                    {
                        currentFrame = Frames[key][0];
                    }
                }
            }

            return currentFrame;
        }

        public int AISpriteRotaions(GameTime gameTime, string direction)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame < timePerFrame)
            {
                return currentFrame;
            }
            timeSinceLastFrame = gameTime.ElapsedGameTime.Milliseconds;

            foreach (var key in AIFrames.Keys.Where(key => direction.Equals(key)))
            {
                if (AIFrames[key].Contains(currentFrame))
                {
                    currentFrame++;
                    if (currentFrame == AIFrames[key][2] + 1)
                    {
                        currentFrame = AIFrames[key][0];
                    }
                }
                else
                {
                    currentFrame = AIFrames[key][0];
                }
            }

            return currentFrame;
        }
    }
}