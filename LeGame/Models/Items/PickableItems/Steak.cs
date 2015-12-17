namespace LeGame.Models.Items.PickableItems
{
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public sealed class Steak : PickableItem, IHeals
    {
        private const int SteakHealingAmount = 70;

        public Steak(Vector2 position, string type)
            : base(position, type)
        {
            this.HasBeenPicked = false;
            this.HealingAmount = SteakHealingAmount;
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
