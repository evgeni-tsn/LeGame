using System.Collections.Generic;
using LeGame.Interfaces;
using LeGame.Models.Characters;
using LeGame.Models.LevelAssets;
using Microsoft.Xna.Framework.Content;

namespace LeGame.Models
{
    public class Level
    {
        Character character;

        List<GameObject> assets = new List<GameObject>();

        List<Tile> tiles = new List<Tile>();
        ContentManager content;

        public Level(string path, Character character, ContentManager content)
        {
            this.Content = content;
            this.Character = character;
            AssetBuilder assetBuilder = new AssetBuilder(content, path);
            this.Assets = assetBuilder.Assets;
            //should use method GenerateTiles
            this.Tiles = assetBuilder.Tiles;
        }

        public Character Character
        {
            get { return character; }
            private set { character = value; }
        }


        public List<GameObject> Assets

        {
            get { return assets; }
            private set { this.assets = value; }
        }

        public List<Tile> Tiles
        {
            get { return tiles; }
            private set{this.tiles = value;}

        }

        public ContentManager Content
        {
            get { return content; }
            private set { this.content = value; }
            
        }
    }
}
