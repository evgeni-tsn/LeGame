using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.IO;
using LeGame.Exceptions;

namespace LeGame.Models.LevelAssets
{
    using LeGame.Engine;
    using LeGame.Interfaces;

    // Previously AssetBuilder
    public class BackgroundBuilder
    {
        private List<IGameObject> background;

        // private List<NonInteractiveBg> tiles;
        public BackgroundBuilder(string mapFilePath)
        {
            // Read the text file for the map and find the separation between map and legend.
            List<string> mapFile = this.ReadMapFile(mapFilePath);
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

            this.background = new List<IGameObject>();

            // this.tiles = new List<NonInteractiveBg>();
            // Go through the chars and store their corresponding items in the background/tiles
            for (int row = 0; row < mapRows.Count; row++)
            {
                for (int col = 0; col < mapRows[row].Length; col++)
                {
                    char currentChar = mapRows[row][col];

                    if (!legend.ContainsKey(currentChar))
                    {
                        throw new MapException(string.Format(Messages.InvalidLegendMap, mapFilePath));
                    }

                    string[] layers = legend[currentChar].Split('|');

                    foreach (string layer in layers)
                    {
                        string[] parameters = layer.Split(':');

                        string contentPath = parameters[0];
                        bool hasCollision = parameters[1].Equals("true");
                        int drawPriority = parameters.Length > 2 ? int.Parse(parameters[2]) : 0;
                        var position = new Vector2(col * GlobalVariables.TileHeight, row * GlobalVariables.TileWidth);

                        //if (hasCollision)
                        //{
                        this.background.Add(new InteractiveBg(position, contentPath, drawPriority, hasCollision));
                        //}
                        //else
                        //{
                        //    this.tiles.Add(new NonInteractiveBg(position, contentPath, drawPriority));
                        //}
                    }
                }
            }
        }
        // Properties
        public List<IGameObject> Background
        {
            get
            {
                return this.background
                    .OrderBy(ass => ((InteractiveBg) ass).DrawPriority)
                    .ToList();
            }
            private set { this.background = value; }
        }

        //public List<NonInteractiveBg> Tiles
        //{
        //    get
        //    {
        //        return this.tiles
        //            .OrderBy(till => till.DrawPriority)
        //            .ToList();
        //    }
        //    private set { this.tiles = value; }
        //}
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
