using Microsoft.Xna.Framework;
using LeGame.Interfaces;

namespace LeGame.Models.LevelAssets
{
    // Interactive Background -> Previously Asset
    // Class for all the interactable background other than tiles
    public class InteractiveBg : GameObject, ICollidable
    {

        public InteractiveBg(Vector2 position, string type, int drawPriority, bool canCollide)
            : base(position, type)
        {
            this.DrawPriority = drawPriority;
            this.CanCollide = canCollide;
        }

        public bool CanCollide { get; set; }

        public int DrawPriority { get; private set; }
    }
}
