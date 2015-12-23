namespace LeGame.Models.Items.Weapons
{
    using LeGame.Interfaces;
    using LeGame.Models.Items.Projectiles;

    using Microsoft.Xna.Framework;

    public class Unarmed : MeleeWeapon
    {
        private const int UnarmedDamage = 70;

        private const string UnarmedType = "Tiles/NULL";

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