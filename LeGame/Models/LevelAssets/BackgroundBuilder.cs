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
    // Previously AssetBuilder
    public class BackgroundBuilder
    {
        //TODO: assets and tiles to be renamed to something mroe descriptive.
        private List<GameObject> assets;
        private List<NonInteractiveBG> tiles;
        
        public BackgroundBuilder(string mapFilePath)
        {
            // Read the text file for the map and find the separation between map and legend.
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
            this.tiles = new List<NonInteractiveBG>();
            // Go through the chars and store their corresponding items in the assets/tiles
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
                    var position = new Vector2(col * 32, row * 32);

                    if (hasCollision)
                    {
                        this.assets.Add(new InteractiveBG(position, contentPath, drawPriority));
                    }
                    else
                    {
                        this.tiles.Add(new NonInteractiveBG(position, contentPath, drawPriority));
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
                    .OrderBy(ass => (ass as InteractiveBG).DrawPriority)
                    .ToList();
            }
            private set { this.assets = value; }
        }

        public List<NonInteractiveBG> Tiles
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
                throw new FileNotFoundException("The supplied file path \"{0}\" for the tile builder is invalid.", textFilePath);
            }

            return File.ReadAllLines(textFilePath).ToList();
        }

    }
}
