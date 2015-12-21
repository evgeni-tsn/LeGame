using System;
using LeGame.Handlers;
using LeGame.Interfaces;
using LeGame.Models.Items.LevelAssets;
using Microsoft.Xna.Framework;


namespace LeGame.Models.Misc
{
    public class SpawnLocation : BackgroundAsset, ISpawnLocation
    {
        public SpawnLocation(Vector2 position, string type, int drawPriority, bool canCollide)
            : base(position, type, drawPriority, canCollide)
        {
        }

        public Rectangle InfalateBBox()
        {
            Rectangle originaBBox = GfxHandler.GetBBox(this);
            originaBBox.Inflate(50,50);
            return originaBBox; 
        }

        public bool CanCollide { get; set; }

        
    }
}
