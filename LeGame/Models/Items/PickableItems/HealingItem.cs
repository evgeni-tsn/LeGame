namespace LeGame.Models.Items.PickableItems
{
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public class HealingItem : PickableItem, IHeals
    {
        public HealingItem(Vector2 position, string type)
            : base(position, type)
        {
        }

        public int HealingAmount { get; set; }

        public void HealCharacter(ICharacter character)
        {
            character.CurrentHealth += this.HealingAmount;

            if (character.CurrentHealth > character.MaxHealth)
            {
                character.CurrentHealth = character.MaxHealth;
            }
        }
    }
}