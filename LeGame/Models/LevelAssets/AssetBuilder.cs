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
        private List<Asset> assets;
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

            this.Assets = new List<Asset>();
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
        public List<Asset> Assets
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

        //public List<Tile> GenerateAssets()
        //{

        //}
        // ANOTHER METHOD FOR GENERATING SOLELY TILES

        //public static List<Tile> GenerateTiles(string textFilePath, ContentManager content)
        //{
        //    if (!File.Exists(textFilePath))
        //    {  
        //       //commented out just to Build
        //       //throw new FileNotFoundException($"The supplied file path \"{textFilePath}\" for the tile builder is invalid.");
        //    }
        //    List<string> textFileRows = File.ReadAllLines(textFilePath).ToList();
        //    int separatorLocation = textFileRows.FindIndex(s => s.Contains("Legend:"));
        //    if (separatorLocation == -1)
        //    {
        //        // TODO: Make a new exception for this case.
        //       // throw new Exception($"Map file \"{textFilePath}\" doesn't contain \"Legend:\" separator.");
        //    }

        //    // Split the map matrix and the legend rows.
        //    List<string> mapRows = textFileRows.Take(separatorLocation).ToList();
        //    IEnumerable<string> legendRows = textFileRows.Skip(separatorLocation + 1);
        //    Dictionary<char, string> legend = legendRows.ToDictionary(item => item[0], item => item.Substring(2));


        //    List<Tile> assets = new List<Tile>();
        //    for (int row = 0; row < mapRows.Count; row++)
        //    {
        //        for (int col = 0; col < mapRows[row].Length; col++)
        //        {
        //            char currentChar = mapRows[row][col];

        //            if (!legend.ContainsKey(currentChar))
        //            {
        //                // TODO: Make a new exception for this case.
        //               // throw new Exception($"Invalid legend in \"{textFilePath}\" file.");
        //            }

        //            string[] parameters = legend[currentChar].Split(':');

        //            string textureFile = parameters[0];
        //            bool hasCollision = parameters[1].Equals("true");
        //            int drawPriority = parameters.Length > 2 ? int.Parse(parameters[2]) : 0;

        //            var texture = content.Load<Texture2D>(textureFile);
        //            var position = new Vector2(col * 32, row * 32);

        //            assets.Add(new Tile(position, texture, hasCollision, drawPriority));
        //        }
        //    }
        //    // Sort the list based on drawPriority, so it can be drawn in proper order if needed.
        //    // assets = assets.OrderBy(t => t.DrawPriority).ToList(); removed due to compatability issues, reuse possible lower in the hierarchy
        //    return assets;
        //}
    }
}
