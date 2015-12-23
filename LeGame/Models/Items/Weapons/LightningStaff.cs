namespace LeGame.Models.Items.Weapons
{
    using LeGame.Interfaces;
    using LeGame.Models.Items.Projectiles;

    using Microsoft.Xna.Framework;

    public class LightningStaff : RangedWeapon
    {
        private const int LightningStaffDamage = 5;

        private const int LightningStaffRange = 20;

        private const string LightningStaffType = "Items/LightningStaff";

        public LightningStaff(Vector2 position)
            : base(position, LightningStaffType, LightningStaffDamage, LightningStaffRange)
        {
        }

        public override void Attack(ILevel level, ICharacter attacker)
        {
            level.Projectiles.Add(new LightningStrike(attacker, attacker.FacingAngle - 1.55f, this.Damage, this.Range));
        }
    }
}