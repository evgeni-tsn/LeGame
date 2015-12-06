using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LeGame.Interfaces;
using LeGame.Models.Characters;


namespace LeGame.Handlers
{
    public static class MovementHandler
    {
        public static void MoveRight(Character character)
        {
            if (character.Position.X + character.Speed <= GlobalVariables.WINDOW_WIDTH - GfxHandler.GetWidth(character))
            {
                character.Position = new Vector2(character.Position.X + character.Speed, character.Position.Y);
            }
        }

        public static void MoveLeft(Character character)
        {
            if (character.Position.X - character.Speed > 0)
            {
                character.Position = new Vector2(character.Position.X - character.Speed, character.Position.Y);
            }
        }

        public static void MoveUp(Character character)
        {
            if (character.Position.Y - character.Speed > 0)
            {
                character.Position = new Vector2(character.Position.X, character.Position.Y - character.Speed);
            }
        }

        public static void MoveDown(Character character)
        {
            if (character.Position.Y + character.Speed <= GlobalVariables.WINDOW_HEIGHT - GfxHandler.GetHeight(character))
            {
                character.Position = new Vector2(character.Position.X, character.Position.Y + character.Speed);
            }
        }     
    }
}
