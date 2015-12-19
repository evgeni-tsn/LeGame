namespace LeGame.Models.Items.Weapons
{
    using Interfaces;

    using Microsoft.Xna.Framework;

    using Projectiles;

    public class IceSpear : MeleeWeapon
    {
        private const string IceSpearType = "Items/IceSpear";
        private const int IceSpearDamage = 30;

        public IceSpear(Vector2 position) 
            : base(position, IceSpearType, IceSpearDamage)
        {
        }

        public override void Attack(ILevel level, ICharacter attacker)
        {
            level.Projectiles.Add(new IceStrike(attacker, attacker.FacingAngle - 1.55f, this.Damage, this.Range));
        }
    }
}
