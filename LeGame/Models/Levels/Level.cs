using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Models.Levels
{
    internal class Level
    {
        public Level(string textFilePath, ContentManager content)
        {
            if (!File.Exists(textFilePath))
            {
                throw new FileNotFoundException($"The supplied file path \"{textFilePath}\" for the tile builder is invalid.");
            }
            List<string> textFileRows = File.ReadAllLines(textFilePath).ToList();
            int separatorLocation = textFileRows.FindIndex(s => s.Contains("Legend:"));

            List<string> mapRows = textFileRows.Take(separatorLocation).ToList();
            IEnumerable<string> legendRows = textFileRows.Skip(separatorLocation + 1);
            Dictionary<char, string> legend = legendRows.ToDictionary(item => item[0], item => item.Substring(2));

            Tiles = new List<Tile>();
            for (int row = 0; row < mapRows.Count; row++)
            {
                for (int col = 0; col < mapRows[row].Length; col++)
                {
                    char currentChar = mapRows[row][col];
                    if (legend.ContainsKey(currentChar))
                    {
                        string[] parameters = legend[currentChar].Split(':');

                        string textureFile = parameters[0];
                        bool hasCollision = parameters[1].Equals("true");

                        var texture = content.Load<Texture2D>(textureFile);
                        var position = new Vector2(col * texture.Width, row * texture.Height);

                        Tiles.Add(new Tile(position, texture, hasCollision));
                    }
                }
            }
        }

        public List<Tile> Tiles { get; }

        internal struct Tile
        {
            public Vector2 Position;
            public Texture2D Image;
            public bool HasCollision;

            public Tile(Vector2 position, Texture2D image, bool hasCollision)
            {
                this.Position = position;
                this.Image = image;
                this.HasCollision = hasCollision;
            }
        }
    }
}
