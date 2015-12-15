namespace LeGame.Models
{
    using System.IO;

    using Interfaces;

    using Microsoft.Xna.Framework;

    public abstract class GameObject : IGameObject
    {
        protected GameObject(Vector2 position, string type)
        {
            // http://www.dotnetperls.com/random-string
            // random id for every object
            this.Id = Path.GetRandomFileName().Replace(".", string.Empty);
            this.Position = position;
            this.Type = type;
        }
        
        public string Id { get; set; }

        public string Type { get; set; }

        public Vector2 Position { get; set; }
    }
}
