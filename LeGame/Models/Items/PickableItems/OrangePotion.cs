namespace LeGame.Models.Items.PickableItems
{
    using Microsoft.Xna.Framework;

    public class OrangePotion : HealingItem
    {
        private const int DefaultOrangePotionHealingAmount = 110;

        private const string DefaultOrangePotionType = "Items/OrangePotion";

        public OrangePotion(Vector2 position)
            : base(position, DefaultOrangePotionType)
        {
            this.HealingAmount = DefaultOrangePotionHealingAmount;
        }
    }
}