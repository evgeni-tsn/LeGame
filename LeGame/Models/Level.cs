using System.Collections.Generic;
using LeGame.Interfaces;
using LeGame.Models.Characters;
using LeGame.Models.Items.Projectiles;
using LeGame.Models.LevelAssets;

namespace LeGame.Models
{
    public class Level : ILevel
    {
        public Level(string path, Character character)
        {
            this.Character = character;
            BackgroundBuilder assetBuilder = new BackgroundBuilder(path);

            this.Assets = assetBuilder.Background;
            //this.Tiles = assetBuilder.Tiles;
            this.Enemies = new List<Character>();
            this.Projectiles = new List<Projectile>();
        }

        public List<Projectile> Projectiles { get; private set; } 

        public List<Character> Enemies { get; private set; }

        public Character Character { get; private set; }

        public List<IGameObject> Assets { get; private set; }

        //public List<NonInteractiveBg> Tiles { get; private set; }
    }
}
