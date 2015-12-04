using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LeGame.Interfaces;
using LeGame.Models.LevelAssets;
using LeGame.Models.Characters;

using Microsoft.Xna.Framework.Storage;


namespace LeGame.Models.Levels
{
    public  class Level
    {
        Character character;
        List<IGameObject> assets = new List<IGameObject>();
        List<Tile> tiles = new List<Tile>();
        ContentManager content;

        public Level(string path, Character character, ContentManager content)
        {
            this.Content = content;
            //not implemented yet
            //this.assets = AssetBuilder.GenerateAssets(path, this.Content);
            this.Character = character;
            //should use method GenerateTiles
            this.Tiles = AssetBuilder.GenerateAssets(path, this.Content);
        }
        public Character Character
        {
            get { return character; }
            private set { character = value; }
        }
        public List<IGameObject> Assets
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
