namespace LeGame.Models.Items.Weapons
{
    using Microsoft.Xna.Framework;

    public abstract class MeleeWeapon : Weapon
    {
        private const int MeleeWeaponDefaultRange = 1;

        protected MeleeWeapon(Vector2 position, string type, int damage)
            : base(position, type, damage, MeleeWeaponDefaultRange)
        {
        }
    }
}