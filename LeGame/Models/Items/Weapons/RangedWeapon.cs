using LeGame.Interfaces;
using LeGame.Models.Characters.Player;

namespace LeGame.Models.Items.Weapons
{
    abstract class RangedWeapon : IWeapon
    {
        protected RangedWeapon(int damage, int range)
        {
            this.Damage = damage;
            this.Range = range;
        }

        public int Damage { get; set; }

        public int Range { get; set; }

        public abstract void Attack(Level level, Player attacker);
    }
}
