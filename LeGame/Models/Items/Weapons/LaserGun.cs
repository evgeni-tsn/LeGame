namespace LeGame.Models.Items.Weapons
{
    using Interfaces;
    using Projectiles;

    public class LaserGun : RangedWeapon
    {
        private const int LaserGunDamage = 4;
        private const int LaserGunRange = 20;

        public LaserGun() : base(LaserGunDamage, LaserGunRange)
        {
        }

        public override void Attack(ILevel level, ICharacter attacker)
        {
            level.Projectiles.Add(new LaserBlast(attacker, attacker.FacingAngle - 1.55f, this.Damage, this.Range));
        }
    }
}
