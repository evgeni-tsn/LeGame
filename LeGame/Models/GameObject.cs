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
        protected GameObject(Vector2 position, string displayName, Texture2D texture)
        {
            // http://www.dotnetperls.com/random-string
            // random id for every object
            this.Id = Path.GetRandomFileName().Replace(".", "");
            this.Position = position;
            this.DisplayName = displayName;
            this.Texture = texture;
        }

        public Texture2D Texture { get; set; }
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int) (Position.X + 3),
                    (int) (this.Position.Y + 3),
                    (int) (this.Texture.Width - 6),
                    (int) (this.Texture.Height - 5));
            }
        }
        
    }
}
