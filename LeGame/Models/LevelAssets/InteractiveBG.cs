using Microsoft.Xna.Framework;
using LeGame.Interfaces;

namespace LeGame.Models.LevelAssets
{
    // Interactive Background -> Previously Asset
    // Class for all the interactable background other than tiles
    public class InteractiveBg : GameObject, ICollisionable
    {
        public bool CanCollide { get; set; }
        public int DrawPriority { get; set; }

        public InteractiveBg(Vector2 position, string type, int drawPriority)
            : base(position, type)
        {
            this.DrawPriority = drawPriority;
            this.CanCollide = true;
        }
        
    }
}
