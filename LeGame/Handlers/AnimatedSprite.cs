using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LeGame.Models.Characters;

namespace LeGame.Handlers
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        private int timeSinceLastFrame = 0;
        private int timePerFrame = 150;
        private int[] RightFrames = { 6, 7, 8 };
        private int[] LeftFrames = { 3, 4, 5 };
        private int[] DownFrames = { 0, 1, 2 };
        private int[] UpFrames = { 9, 10, 11 };

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
            SpriteRotations(gameTime);
            
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
        public int SpriteRotations(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (timeSinceLastFrame >= timePerFrame)
                {
                    timeSinceLastFrame -= timePerFrame;
                    if (RightFrames.Contains(currentFrame))
                    {
                        currentFrame++;
                        if (currentFrame == RightFrames[2] + 1)
                        {
                            currentFrame = RightFrames[0];
                        }
                    }
                    else
                    {
                        currentFrame = RightFrames[0];
                    }
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (timeSinceLastFrame >= timePerFrame)
                {
                    timeSinceLastFrame -= timePerFrame;
                    if (UpFrames.Contains(currentFrame))
                    {
                        currentFrame++;
                        if (currentFrame >= UpFrames[2] + 1)
                        {
                            currentFrame = UpFrames[0];
                        }
                    }
                    else
                    {
                        currentFrame = UpFrames[0];
                    }
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (timeSinceLastFrame >= timePerFrame)
                {
                    timeSinceLastFrame -= timePerFrame;
                    if (LeftFrames.Contains(currentFrame))
                    {
                        currentFrame++;
                        if (currentFrame >= LeftFrames[2] + 1)
                        {
                            currentFrame = LeftFrames[0];
                        }
                    }
                    else
                    {
                        currentFrame = LeftFrames[0];
                    }
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (timeSinceLastFrame >= timePerFrame)
                {
                    timeSinceLastFrame -= timePerFrame;
                    if (DownFrames.Contains(currentFrame))
                    {
                        currentFrame++;
                        if (currentFrame >= DownFrames[2] + 1)
                        {
                            currentFrame = DownFrames[0];
                        }
                    }
                    else
                    {
                        currentFrame = DownFrames[0];
                    }

                }

            }
            return currentFrame;
        }
    }
}