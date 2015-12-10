using System;
using System.Collections.Generic;
using System.Linq;
using LeGame.Interfaces;
using LeGame.Models;
using LeGame.Models.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Handlers
{
    internal static class CollisionHandler
    {
        public static object Collide(Character character)
        {
            List<GameObject> collisionItems = character.Level.Assets.Concat(character.Level.Enemies).ToList(); 
            // certainly NEEDS to be revamped

            foreach (var item in collisionItems)// character.Level.Background)
            {
                Rectangle obj = GfxHandler.GetBBox(item);

                if (((item is ICollisionable && ((ICollisionable)item).CanCollide) || item is IPickable)
                    && GfxHandler.GetBBox(character).Intersects(obj))
                {
                    return item;
                }
            }
            return -1;
        }
        public static void Reaction(Character character, Keys key)
        {
            if (Collide(character) != (object)1)
            {
                 Vector2 temp = new Vector2(character.Position.X, character.Position.Y);
               
                //movement reactions
            
                if (Collide(character) is ICollisionable && key == Keys.D)
                {
                    temp.X -= character.Speed;
                    character.Position = temp;
                }
                if (Collide(character) is ICollisionable && key == Keys.W)
                {
                    temp.Y += character.Speed;
                    character.Position = temp;
                }
                if (Collide(character) is ICollisionable && key == Keys.S)
                {
                    temp.Y -= character.Speed;
                    character.Position = temp;
                }
                if (Collide(character) is ICollisionable && key == Keys.A)
                {
                    temp.X += character.Speed;
                    character.Position = temp;
                }
            
                if (Collide(character) is IPickable)
                {
                    GameObject item = (GameObject)Collide(character);
                    Console.Beep(8000,50); 

                    // legit cool gold-pickup sound 
                    // the freeze it causes based on the duration is also legit :D

                    character.Level.Assets.Remove(item);
                }
            }

        }
    }
}
