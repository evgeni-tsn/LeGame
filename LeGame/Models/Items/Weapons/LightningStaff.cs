namespace LeGame.Models.Items.Weapons
{
    using Interfaces;

    using Microsoft.Xna.Framework;

    using Projectiles;

    public class LightningStaff : RangedWeapon
    {
        private const string LightningStaffType = "Items/LightningStaff";
        private const int LightningStaffDamage = 5;
        private const int LightningStaffRange = 20;

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
