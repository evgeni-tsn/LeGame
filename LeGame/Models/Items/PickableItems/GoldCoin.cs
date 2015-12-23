namespace LeGame.Models.Items.PickableItems
{
    using Microsoft.Xna.Framework;

    public class GoldCoin : PickableItem
    {
        public GoldCoin(Vector2 position, string type)
            : base(position, type)
        {
            this.HasBeenPicked = false;
        }

        public override sealed bool HasBeenPicked { get; set; }
    }
}
