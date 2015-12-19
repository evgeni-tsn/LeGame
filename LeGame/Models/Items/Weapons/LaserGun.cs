namespace LeGame.Models.Items.Weapons
{
    using Interfaces;

    using Microsoft.Xna.Framework;

    using Projectiles;

    public class LaserGun : RangedWeapon
    {
        private const string LaserGunType = "Items/LaserGun";
        private const int LaserGunDamage = 4;
        private const int LaserGunRange = 20;

        public LaserGun(Vector2 position) 
            : base(position, LaserGunType, LaserGunDamage, LaserGunRange)
        {
        }

        public override void Attack(ILevel level, ICharacter attacker)
        {
            level.Projectiles.Add(new LaserBlast(attacker, attacker.FacingAngle - 1.55f, this.Damage, this.Range));
        }
    }
}
