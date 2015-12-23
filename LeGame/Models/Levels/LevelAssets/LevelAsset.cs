namespace LeGame.Models.Levels.LevelAssets
{
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public class LevelAsset : GameObject, IColidable
    {
        public LevelAsset(Vector2 position, string type, int drawPriority, bool canCollide)
            : base(position, type)
        {
            this.DrawPriority = drawPriority;
            this.CanCollide = canCollide;
        }

        public bool CanCollide { get; set; }

        public int DrawPriority { get; private set; }
    }
}
