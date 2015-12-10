using LeGame.Interfaces;
using LeGame.Models.Characters.Player;

namespace LeGame.Models.Items.Weapons
{
    abstract class MeleeWeapon : IWeapon
    {
        protected MeleeWeapon(int damage)
        {
            this.Damage = damage;
            this.Range = 0;
        }

        public int Damage { get; set; }

        public int Range { get; set; }

        public abstract void Attack(Level level, Player attacker);
    }
}
