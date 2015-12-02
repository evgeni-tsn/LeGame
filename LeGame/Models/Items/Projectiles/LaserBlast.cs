using LeGame.Interfaces;

namespace LeGame.Models.Items.Weapons.Projectiles
{
    public class LaserBlast : Projectile
    {
        public LaserBlast(int damage) 
            : base(damage)
        {
        }

        public override void Hit(ICharacter character)
        {
            base.Hit(character);
        }
    }
}