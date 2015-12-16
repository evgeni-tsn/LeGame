namespace LeGame.Models.Items.Weapons
{
    public abstract class MeleeWeapon : Weapon
    {
        private const int MeleeWeaponDefaultRange = 1;

        protected MeleeWeapon(int damage) 
            : base(damage, MeleeWeaponDefaultRange)
        {
        }
    }
}
