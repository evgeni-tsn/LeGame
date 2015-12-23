namespace LeGame.Models.Items.Weapons
{
    using Microsoft.Xna.Framework;

    public abstract class RangedWeapon : Weapon
    {
        protected RangedWeapon(Vector2 position, string type, int damage, int range)
            : base(position, type, damage, range)
        {
        }
    }
}