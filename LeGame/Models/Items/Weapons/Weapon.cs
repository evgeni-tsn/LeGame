namespace LeGame.Models.Items.Weapons
{
    using LeGame.Interfaces;
    using LeGame.Models.Items.PickableItems;

    using Microsoft.Xna.Framework;

    public abstract class Weapon : PickableItem, IWeapon
    {
        protected Weapon(Vector2 position, string type, int damage, int range)
            : base(position, type)
        {
            this.Damage = damage;
            this.Range = range;
        }

        public int Damage { get; set; }

        public int Range { get; set; }

        public abstract void Attack(ILevel level, ICharacter attacker);

        public void EquipCharacter(ICharacter character)
        {
            character.EquippedWeapon = this;
        }
    }
}
