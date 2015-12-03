using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using LeGame.Models.Characters;

namespace LeGame.Handlers
{
    internal static class CollisionHandler
    {
        public static Object Collide(Character character)
        {
            List<Rectangle> objectRects = new List<Rectangle>();
            foreach (var item in character.Level.Tiles)
            {
                Rectangle obj = new Rectangle((int)item.Position.X, (int)item.Position.Y, item.Image.Width, item.Image.Height);
                Rectangle playerRec = character.BoundingBox;
                if (item.CanCollide == true && playerRec.Intersects(obj))
                {
                    return item;
                }
            }
            return 1;
           
        }
    }
}
