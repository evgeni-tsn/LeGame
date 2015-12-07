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
    // Non Interactive Background -> Previously Tile
    // Class for non interactive background tiles
    public struct NonInteractiveBG : IGameObject
    {
        private Vector2 position;
        private string id;
        private string type;

        public NonInteractiveBG(Vector2 position, string type, int drawPriority)
            : this()
        {
            this.Position = position;
            this.DrawPriority = drawPriority;
            this.Type = type;
            this.Id = "Tile";
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

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        
        public int DrawPriority { get; set; }
    }
}
