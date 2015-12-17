namespace LeGame.Models.Items.PickableItems
{
    using Microsoft.Xna.Framework;

    public class RedPotion : HealingItem
    {
        private const string DefaultRedPotionType = "Items/RedPotion";

        private const int DefaultRedPotionHealingAmount = 150;

        public RedPotion(Vector2 position)
            : base(position, DefaultRedPotionType)
        {
            this.HealingAmount = DefaultRedPotionHealingAmount;
        }
    }
}
