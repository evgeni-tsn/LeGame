namespace LeGame.Models.Items.Weapons
{
    public abstract class RangedWeapon : Weapon
    {
        protected RangedWeapon(int damage, int range)
            : base(damage, range)
        {
        }
    }
}
