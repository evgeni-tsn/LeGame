﻿using System.Collections.Generic;
using LeGame.Interfaces;
using LeGame.Models.Characters;
using LeGame.Models.LevelAssets;
using Microsoft.Xna.Framework.Content;

namespace LeGame.Models
{
    public class Level : ILevel
    {
        Character character;

        private List<GameObject> assets = new List<GameObject>();
        private List<Character> enemies;


        List<NonInteractiveBG> tiles = new List<NonInteractiveBG>();

        public Level(string path, Character character)
        {
            this.Character = character;
            BackgroundBuilder assetBuilder = new BackgroundBuilder(path);

            this.Assets = assetBuilder.Assets;
            this.Tiles = assetBuilder.Tiles;
            this.Enemies = new List<Character>();
        }

        public List<Character> Enemies
        {
            get { return enemies; }
            private set { enemies = value; }
        }

        public Character Character
        {
            get { return character; }
            private set { this.character = value; }
        }

        public List<GameObject> Assets

        {
            get { return assets; }
            private set { this.assets = value; }
        }

        public List<NonInteractiveBG> Tiles
        {
            get { return tiles; }
            private set { this.tiles = value; }
        }
    }
}
