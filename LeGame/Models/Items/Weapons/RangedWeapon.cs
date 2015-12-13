namespace LeGame.Models.Items.Weapons
{
    using Interfaces;

    public abstract class RangedWeapon : IWeapon
    {
        protected RangedWeapon(int damage, int range)
        {
            this.Damage = damage;
            this.Range = range;
        }

        public int Damage { get; set; }

        public int Range { get; set; }

        public abstract void Attack(ILevel level, ICharacter attacker);
    }
}
