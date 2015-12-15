namespace LeGame.Models.Items.Projectiles
{
    using Interfaces;

    public class Grenade : Projectile
    {
        public Grenade(ICharacter attacker, string type, int damage, int speed, float angle, int range)
            : base(attacker, type, damage, speed, angle, range)
        {
        }
        
    }
}