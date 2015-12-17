namespace LeGame.Models.Items.PickableItems
{
    using Microsoft.Xna.Framework;

    public class Steak : HealingItem
    {
        private const string DefaultSteakType = "Items/Steak";

        private const int DefaultSteakHealingAmount = 70;

        public Steak(Vector2 position)
            : base(position, DefaultSteakType)
        {
            this.HealingAmount = DefaultSteakHealingAmount;
        }
    }
}
