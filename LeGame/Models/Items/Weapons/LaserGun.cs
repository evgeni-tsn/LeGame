using LeGame.Models.Characters.Player;
using LeGame.Models.Items.Projectiles;

namespace LeGame.Models.Items.Weapons
{
    class LaserGun : RangedWeapon
    {
        private const int LaserGunDamage = 2;
        private const int LaserGunRange = 20;

        public LaserGun() : base(LaserGunDamage, LaserGunRange)
        {

        }

        public override void Attack(Level level, Player attacker)
        {
            level.Projectiles.Add(new LaserBlast(attacker, attacker.FacingAngle - 1.55f, this.Damage, this.Range));
        }
    }
}
