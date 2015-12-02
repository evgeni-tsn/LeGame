using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using LeGame.Interfaces;

namespace LeGame.Classes
{
    public abstract class GameObject : IGameObject
    {
        protected GameObject(Vector2 position, string displayName)
        {
            // http://www.dotnetperls.com/random-string
            // random id for every object
            this.Id = Path.GetRandomFileName().Replace(".", "");
            this.Position = position;
            this.DisplayName = displayName;
        }

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public Vector2 Position { get; set; }
    }
}
