namespace LeGame.Models.Items.Weapons
{
    using Interfaces;

    using Microsoft.Xna.Framework;

    using Projectiles;

    public class Unarmed : MeleeWeapon
    {
        private const string UnarmedType = "Tiles/NULL";
        private const int UnarmedDamage = 70;

        public Unarmed(Vector2 position) 
            : base(position, UnarmedType, UnarmedDamage)
        {
        }

        public override void Attack(ILevel level, ICharacter attacker)
        {
            level.Projectiles.Add(new MeleeSwing(attacker, attacker.FacingAngle - 1.55f, this.Damage, this.Range));
        }
    }
}
