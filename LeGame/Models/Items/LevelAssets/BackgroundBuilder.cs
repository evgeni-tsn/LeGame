namespace LeGame.Models.Items.LevelAssets
{
    using System.Collections.Generic;
    using System.Linq;

    using LeGame.Core;
    using LeGame.Exceptions;
    using LeGame.Handlers;
    using LeGame.Interfaces;
    using LeGame.Models.LevelAssets;

    using Microsoft.Xna.Framework;

    public class BackgroundBuilder
    {
        private readonly List<IGameObject> background;
        
        public BackgroundBuilder(string mapFilePath)
        {
            // Read the text file for the map and find the separation between map and legend.
            List<string> mapFile = FileHandler.ReadMapFile(mapFilePath);
            int separatorLocation = mapFile.FindIndex(s => s.Contains("Legend:"));
            if (separatorLocation == -1)
            {
                throw new MapException(string.Format(Messages.MissingLegendMap, mapFilePath));
            }

            List<string> mapRows = mapFile
                .Take(separatorLocation)
                .ToList();

            Dictionary<char, string> legend = mapFile
                .Skip(separatorLocation + 1)
                .ToDictionary(item => item[0], item => item.Substring(2));

            this.background = new List<IGameObject>();
            
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

                        this.background.Add(new BackgroundAsset(position, contentPath, drawPriority, hasCollision));
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
                    .OrderBy(ass => ((BackgroundAsset)ass).DrawPriority)
                    .ToList();
            }
        }
    }
}
