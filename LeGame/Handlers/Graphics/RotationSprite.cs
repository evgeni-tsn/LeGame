using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;
using LeGame.Models.Characters;
using LeGame.Models.Characters.Enemies;
using LeGame.Models.Characters.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Handlers.Graphics
{
    public class RotationSprite
    {
        private Texture2D Texture;
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        private int timeSinceLastFrame = 0;
        private int timePerFrame = 130;

        public RotationSprite(Texture2D texture)
        {
            Texture = texture;
            Rows = Texture.Height / GlobalVariables.TILE_HEIGHT;
            Columns = Texture.Width / GlobalVariables.TILE_WIDTH;
            currentFrame = 0;
            totalFrames = Columns;
        }

        public void Update(GameTime gameTime, Character character)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame < timePerFrame)
            {
                return;
            }

            timeSinceLastFrame = gameTime.ElapsedGameTime.Milliseconds;

            Keys[] keys = { Keys.W, Keys.A, Keys.S, Keys.D };

            if (keys.Any(key => Keyboard.GetState().IsKeyDown(key)))
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, float rotation)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;
            // Color color = new Color(100, 100, 100, 100);
            Vector2 origin = new Vector2(16, 16);

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            spriteBatch.Draw(Texture, null, destinationRectangle, sourceRectangle, origin, rotation, null, null);
            spriteBatch.End();
        }
    }
}
