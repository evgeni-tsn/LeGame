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
    class Asset : GameObject, ICollisionable
    {
        public bool CanCollide
        {
            get { return CanCollide; }
            set { CanCollide = value; }
        }

        public Asset(Vector2 position, string displayName, Texture2D texture)
            : base(position, displayName, texture)
        {

        }


        
    }
}
