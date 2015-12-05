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
            //character.Sprite.Update("Right");
           
            Vector2 temp = new Vector2(character.Position.X, character.Position.Y);
            temp.X += character.Speed;
            character.Position = temp;
            
          
            

            if (character.Position.X >= GlobalVariables.WINDOW_WIDTH - GfxHandler.GetWidth(character))
            {
                Vector2 tempy = new Vector2(character.Position.X, character.Position.Y);
                tempy.X = GlobalVariables.WINDOW_WIDTH - GfxHandler.GetWidth(character);
                character.Position = tempy;
            }
        }
        public static void MoveLeft(Character character)
        {
           
            Vector2 temp = new Vector2(character.Position.X, character.Position.Y);
            temp.X -= character.Speed;

            character.Position = temp;

            if (character.Position.X < 0)
            {
                Vector2 tempy = new Vector2(character.Position.X, character.Position.Y);
                tempy.X = 0;
                character.Position = tempy;
            }
        }
        public static void MoveUp(Character character)
        {
            
            Vector2 temp = new Vector2(character.Position.X, character.Position.Y);
            temp.Y -= character.Speed;

            character.Position = temp;

           

            if (character.Position.Y < 0)
            {
                Vector2 tempy = new Vector2(character.Position.X, character.Position.Y);
                tempy.Y = 0;
                character.Position = tempy;
            }

        }
        public static void MoveDown(Character character)
        {
            
            Vector2 temp = new Vector2(character.Position.X, character.Position.Y);
            temp.Y += character.Speed;

            character.Position = temp;

            

            if (character.Position.Y >= GlobalVariables.WINDOW_HEIGHT - GfxHandler.GetHeight(character))
            {
                Vector2 tempy = new Vector2(character.Position.X, character.Position.Y);
                tempy.Y = GlobalVariables.WINDOW_HEIGHT - GfxHandler.GetHeight(character);
                character.Position = tempy;
            }
        }     
    }
}
