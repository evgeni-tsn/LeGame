namespace LeGame.Models.Items.Weapons
{
    using LeGame.Interfaces;
    using LeGame.Models.Items.Projectiles;

    using Microsoft.Xna.Framework;

    public class IceSpear : MeleeWeapon
    {
        private const int IceSpearDamage = 30;

        private const string IceSpearType = "Items/IceSpear";

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