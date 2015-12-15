namespace LeGame.Models.LevelAssets
{
    using Interfaces;

    using Microsoft.Xna.Framework;
    
    public class BackgroundAsset : GameObject, ICollidable
    {
        public BackgroundAsset(Vector2 position, string type, int drawPriority, bool canCollide)
            : base(position, type)
        {
            this.DrawPriority = drawPriority;
            this.CanCollide = canCollide;
        }

        public bool CanCollide { get; set; }

        public int DrawPriority { get; private set; }
    }
}
