namespace LeGame.Models.Items.Weapons
{
    using LeGame.Interfaces;
    using LeGame.Models.Items.Projectiles;

    using Microsoft.Xna.Framework;

    public class LaserGun : RangedWeapon
    {
        private const int LaserGunDamage = 4;

        private const int LaserGunRange = 20;

        private const string LaserGunType = "Items/LaserGun";

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