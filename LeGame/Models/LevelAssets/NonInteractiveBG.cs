using Microsoft.Xna.Framework;
using LeGame.Interfaces;

namespace LeGame.Models.LevelAssets
{
    // Non Interactive Background -> Previously Tile
    // Class for non interactive background tiles
    public struct NonInteractiveBg : IGameObject
    {
        public NonInteractiveBg(Vector2 position, string type, int drawPriority)
            : this()
        {
            this.Position = position;
            this.DrawPriority = drawPriority;
            this.Type = type;
            this.Id = "Tile";
        }

        public Vector2 Position { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        public int DrawPriority { get; set; }
    }
}
