using Microsoft.Xna.Framework;

namespace LeGame.Models
{
    using System.Collections.Generic;

    using Interfaces;
    using LevelAssets;

    public class Level : ILevel
    {
        public Level(string path, ICharacter player = null)
        {
            this.Player = player;
            
            var assetBuilder = new BackgroundBuilder(path);
            this.Assets = assetBuilder.Background;
            this.Enemies = new List<ICharacter>();
            this.Projectiles = new List<IProjectile>();
        }

        public ICharacter Player { get; set; }

        public List<IProjectile> Projectiles { get; } 

        public List<ICharacter> Enemies { get; }

        public List<IGameObject> Assets { get; }
    }
}
