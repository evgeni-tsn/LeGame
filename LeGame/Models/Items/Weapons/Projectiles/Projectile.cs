using LeGame.Interfaces;

namespace LeGame.Models.Items.Weapons.Projectiles
{
    public class Projectile
    {
        public Projectile(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }

        public virtual void Hit(ICharacter character)
        {
        }
    }
}