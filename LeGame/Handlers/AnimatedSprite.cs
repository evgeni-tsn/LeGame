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

        private Dictionary<Keys, int[]> Frames = new Dictionary<Keys, int[]>()
        {
            { Keys.D, new int[] { 6, 7, 8 } },      //RightFrames
            { Keys.W, new int[] { 9, 10, 11 } },    //LeftFrames
            { Keys.A, new int[] { 3, 4, 5 } },      //DownFrames
            { Keys.S, new int[] { 0, 1, 2 } },      //UpFrames
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
            if (timeSinceLastFrame < timePerFrame)
            {
                return currentFrame;
            }
            timeSinceLastFrame -= timePerFrame;


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
    }
}