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
        private bool reverse;

        private int timeSinceLastFrame = 0;
        private int timePerFrame = 50;

        public RotationSprite(Texture2D texture)
        {
            Texture = texture;
            Rows = Texture.Height / GlobalVariables.TILE_HEIGHT;
            Columns = Texture.Width / GlobalVariables.TILE_WIDTH;
            currentFrame = 5;
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
            
            KeyboardState kbStatew = Keyboard.GetState();

            bool moving = (character as Player).KbKeys.Any(key => kbStatew.IsKeyDown(key));

            if (moving || currentFrame != 5)
            {
                if (reverse)
                {
                    currentFrame--;
                }
                else
                {
                    currentFrame++;
                }
                
                if ((currentFrame == totalFrames - 1 || currentFrame == 0))
                {
                    reverse = !reverse;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, float torsoRotation, float legRotation)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int legsRow = 0;
            int torsoRow = 3;
            int column = currentFrame % Columns;
            var origin = new Vector2(width / 2f, height / 2f);

            Rectangle torsoSource = new Rectangle(width * column, height * torsoRow, width, height);
            Rectangle legsSource = new Rectangle(width * column, height * legsRow, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            spriteBatch.Draw(Texture, null, destinationRectangle, legsSource, origin, legRotation, null, null);
            spriteBatch.Draw(Texture, null, destinationRectangle, torsoSource, origin, torsoRotation, null, null);
            spriteBatch.End();
        }
    }
}
