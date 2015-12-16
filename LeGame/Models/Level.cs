namespace LeGame.Models
{
    using System.Collections.Generic;

    using Interfaces;

    using LeGame.Models.Items.LevelAssets;

    using LevelAssets;

    public class Level : ILevel
    {
        public Level(string path, ICharacter player)
        {
            this.Player = player;
            
            var backgroundBuilder = new BackgroundBuilder(path);

            this.Assets = backgroundBuilder.Background;
            this.Enemies = new List<ICharacter>();
            this.Projectiles = new List<IProjectile>();
        }

        public ICharacter Player { get; set; }

        public List<IProjectile> Projectiles { get; } 

        public List<ICharacter> Enemies { get; }

        public List<IGameObject> Assets { get; }
    }
}
