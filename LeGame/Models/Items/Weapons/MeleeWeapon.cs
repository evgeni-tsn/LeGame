namespace LeGame.Models.Items.Weapons
{
    using LeGame.Interfaces;

    public abstract class MeleeWeapon : IWeapon
    {
        protected MeleeWeapon(int damage)
        {
            this.Damage = damage;
            this.Range = 1;
        }

        public int Damage { get; set; }

        public int Range { get; set; }

        public abstract void Attack(ILevel level, ICharacter attacker);
    }
}
