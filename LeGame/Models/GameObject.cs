using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LeGame.Interfaces;

namespace LeGame.Models
{
    public abstract class GameObject : IGameObject
    {
        protected GameObject(Vector2 position, string type)
        {
            // http://www.dotnetperls.com/random-string
            // random id for every object
            this.Id = Path.GetRandomFileName().Replace(".", "");
            this.Position = position;
            this.Type = type;
        }
        
        public string Id { get; set; }
        public string Type { get; set; }
        public Vector2 Position { get; set; }
    }
}
