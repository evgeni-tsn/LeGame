using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using LeGame.Exceptions;
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
        
        public AssetBuilder(ContentManager content, string mapFilePath)
        {
            List<string> mapFile = ReadMapFile(mapFilePath);
            int separatorLocation = mapFile.FindIndex(s => s.Contains("Legend:"));
            if (separatorLocation == -1)
            {
                throw new MapException(string.Format(Messages.MissingLegendMap,mapFilePath));
            }

            List<string> mapRows = mapFile
                .Take(separatorLocation)
                .ToList();

            Dictionary<char, string> legend = mapFile
                .Skip(separatorLocation + 1)
                .ToDictionary(item => item[0], item => item.Substring(2));

            this.assets = new List<GameObject>();
            this.tiles = new List<Tile>();
            for (int row = 0; row < mapRows.Count; row++)
            {
                for (int col = 0; col < mapRows[row].Length; col++)
                {
                    char currentChar = mapRows[row][col];

                    if (!legend.ContainsKey(currentChar))
                    {
                        throw new MapException(string.Format(Messages.InvalidLegendMap, mapFilePath));
                    }

                    string[] parameters = legend[currentChar].Split(':');

                    string contentPath = parameters[0];
                    bool hasCollision = parameters[1].Equals("true");
                    int drawPriority = parameters.Length > 2 ? int.Parse(parameters[2]) : 0;
                    var texture = content.Load<Texture2D>(contentPath);
                    var position = new Vector2(col * 32, row * 32);

                    if (hasCollision)
                    {
                        this.assets.Add(new Asset(position, contentPath, drawPriority));
                    }
                    else
                    {
                        this.tiles.Add(new Tile(position, contentPath, drawPriority));
                    }
                }
            }
        }
        // Properties
        public List<GameObject> Assets
        {
            get
            {
                return this.assets
                .Select(ass => (Asset)ass)
                .OrderBy(ass => ass.DrawPriority)
                .Select(ass => (GameObject)ass)
                .ToList();
            }
            private set { this.assets = value; }
        }

        public List<Tile> Tiles
        {
            get
            {
                return this.tiles
                    .OrderBy(till => till.DrawPriority)
                    .ToList();
            }
            private set { this.tiles = value; }
        }

        // Methods
        private List<string> ReadMapFile(string textFilePath)
        {
            if (!File.Exists(textFilePath))
            {
                throw new FileNotFoundException("The supplied file path \"{0}\" for the tile builder is invalid.",textFilePath);
            }

            return File.ReadAllLines(textFilePath).ToList();
        }

    }
}
