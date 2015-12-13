namespace LeGame.Models.Items.Weapons
{
    using Characters.Player;

    using Interfaces;

    using Projectiles;

    public class Unarmed : MeleeWeapon
    {
        private const int UnarmedDamage = 70;

        public Unarmed() : base(UnarmedDamage)
        {
        }

        public override void Attack(ILevel level, ICharacter attacker)
        {
            level.Projectiles.Add(new MeleeSwing(attacker, attacker.FacingAngle - 1.55f, this.Damage, this.Range));
        }
    }
}
