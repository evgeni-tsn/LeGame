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
            foreach (var asset in character.Level.Assets)
            {
                Rectangle obj = new Rectangle((int)asset.Position.X, (int)asset.Position.Y, asset.Texture.Width, asset.Texture.Height);
                Rectangle playerRec = character.BoundingBox;
                if (asset.CanCollide == true && playerRec.Intersects(obj))
                {
                    return asset;
                }
            }
            return 1;
           
        }
    }
}
