using LeGame.Interfaces;

namespace LeGame.Models.Items.Weapons.Projectiles
{
    public class Grenade : Projectile
    {
        public Grenade(int damage) : base(damage)
        {
        }

        public override void Hit(ICharacter character)
        {
            base.Hit(character);
        }
    }
}