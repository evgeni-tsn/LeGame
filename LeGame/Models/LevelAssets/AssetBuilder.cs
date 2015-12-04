using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using LeGame.Models;
using LeGame.Models.LevelAssets;
using Microsoft.Xna.Framework.Content;
using LeGame.Interfaces;

namespace LeGame.Models.LevelAssets
{
    public class AssetBuilder
    {
        private List<GameObject> assets;
        private List<Tile> tiles;

        // Constructor
        public AssetBuilder(ContentManager content, string mapFilePath)
        {
            List<string> mapFile = ReadMapFile(mapFilePath);
            int separatorLocation = mapFile.FindIndex(s => s.Contains("Legend:"));
            if (separatorLocation == -1)
            {
                // TODO: Make a new exception for this case.
                //throw new Exception($"Map file \"{mapFilePath}\" doesn't contain \"Legend:\" separator.");
            }

            List<string> mapRows = mapFile
                .Take(separatorLocation)
                .ToList();

            Dictionary<char, string> legend = mapFile
                .Skip(separatorLocation + 1)
                .ToDictionary(item => item[0], item => item.Substring(2));

            this.Assets = new List<GameObject>();
            this.Tiles = new List<Tile>();
            for (int row = 0; row < mapRows.Count; row++)
            {
                for (int col = 0; col < mapRows[row].Length; col++)
                {
                    char currentChar = mapRows[row][col];

                    if (!legend.ContainsKey(currentChar))
                    {
                        // TODO: Make a new exception for this case.
                        //throw new Exception($"Invalid legend in \"{mapFilePath}\" file.");
                    }

                    string[] parameters = legend[currentChar].Split(':');

                    string textureFile = parameters[0];
                    bool hasCollision = parameters[1].Equals("true");

                    int drawPriority = parameters.Length > 2 ? int.Parse(parameters[2]) : 0;
                    var texture = content.Load<Texture2D>(textureFile);
                    var position = new Vector2(col * 32, row * 32);

                    if (hasCollision)
                    {
                        this.Assets.Add(new Asset(position, textureFile, texture, drawPriority));
                    }
                    else
                    {
                        this.Tiles.Add(new Tile(position, texture, drawPriority));
                    }
                }
            }
        }

        // Properties

        public List<GameObject> Assets
        {
            get { return this.assets; }
            private set { this.assets = value; }
        }

        public List<Tile> Tiles
        {
            get { return this.tiles; }
            private set { this.tiles = value; }
        }

        // Methods
        private List<string> ReadMapFile(string textFilePath)
        {
            if (!File.Exists(textFilePath))
            {
                //throw new FileNotFoundException($"The supplied file path \"{textFilePath}\" for the tile builder is invalid.");
            }

            return File.ReadAllLines(textFilePath).ToList();
        }

        
    }
}
