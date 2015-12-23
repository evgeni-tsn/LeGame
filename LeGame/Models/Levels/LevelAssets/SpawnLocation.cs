namespace LeGame.Models.Levels.LevelAssets
{
    using LeGame.Handlers;
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public class SpawnLocation : LevelAsset, ISpawnLocation
    {
        public SpawnLocation(Vector2 position, string type, int drawPriority, bool canCollide)
            : base(position, type, drawPriority, canCollide)
        {
        }

        public Rectangle InflateBBox()
        {
            Rectangle originaBBox = GfxHandler.GetBBox(this);
            originaBBox.Inflate(50, 50);
            return originaBBox;
        }
    }
}