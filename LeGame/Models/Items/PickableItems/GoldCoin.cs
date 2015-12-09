using Microsoft.Xna.Framework;

namespace LeGame.Models.Items.PickableItems
{
    public class GoldCoin : PickableItem
    {
        
        public GoldCoin(Vector2 position, string type)
            : base(position, type)
        {
            this.HasBeenPicked = false;
        }
        public override bool HasBeenPicked { get; set; }
    }
}
