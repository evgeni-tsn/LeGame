namespace LeGame.Models.Items.PickableItems
{
    using Microsoft.Xna.Framework;

    public class OrangePotion : HealingItem
    {
        private const string DefaultOrangePotionType = "Items/OrangePotion";

        private const int DefaultOrangePotionHealingAmount = 110;

        public OrangePotion(Vector2 position)
            : base(position, DefaultOrangePotionType)
        {
            this.HealingAmount = DefaultOrangePotionHealingAmount;
        }
    }
}
