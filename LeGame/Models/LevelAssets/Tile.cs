using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LeGame.Interfaces;
using LeGame.Models;

namespace LeGame.Models.LevelAssets
{
    public struct Tile : IGameObject, ICollisionable //ICollisionable should be removed
    {
        private Vector2 position;
        private string id;
        private string displayName;
      


        public Tile(Vector2 position, Texture2D image, bool canCollide, int drawPriority)
            : this()
        {
            this.Position = position;
            this.Image = image;
            this.DrawPriority = drawPriority;
            this.CanCollide = canCollide;
            this.Id = "Tile";
            this.DisplayName = "Nothing right now"; //maybe deserves a logical improvement?
        }
        public  Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public string Id
        {
            get { return this.id; }
            set { this.id = value; }


        }
        public string DisplayName {
            get { return this.displayName; }
            set { this.displayName = value; }
        }
        public Texture2D Image { get; set; }
        public int DrawPriority { get; set; }
        public bool CanCollide { get; set; } // should be removed as well
    }
}
