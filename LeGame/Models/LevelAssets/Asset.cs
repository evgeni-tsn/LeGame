using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LeGame.Interfaces;

namespace LeGame.Models.LevelAssets
{
    //class for all the interactable assets other than tiles
    public class Asset : GameObject, ICollisionable
    {
        public bool CanCollide { get; set; }
        public int DrawPriority { get; set; }

        public Asset(Vector2 position, string displayName, Texture2D texture, int drawPriority)
            : base(position, displayName, texture)
        {
            this.DrawPriority = drawPriority;

            this.CanCollide = true;


        }


        
    }
}
