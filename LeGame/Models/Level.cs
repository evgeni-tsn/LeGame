namespace LeGame.Models
{
    using System.Collections.Generic;

    using LeGame.Interfaces;
    using LeGame.Models.LevelAssets;

    public class Level : ILevel
    {
        public Level(string path, ICharacter player)
        {
            this.Player = player;
            var assetBuilder = new BackgroundBuilder(path);

            this.Assets = assetBuilder.Background;
            this.Enemies = new List<ICharacter>();
            this.Projectiles = new List<IProjectile>();
        }

        public ICharacter Player { get; private set; }

        public List<IProjectile> Projectiles { get; private set; } 

        public List<ICharacter> Enemies { get; private set; }

        public List<IGameObject> Assets { get; private set; }
    }
}
