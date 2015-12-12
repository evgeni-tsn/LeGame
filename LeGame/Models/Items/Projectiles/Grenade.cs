using Microsoft.Xna.Framework;

namespace LeGame.Models.Items.Projectiles
{
    using LeGame.Models.Characters.Player;

    public class Grenade : Projectile
    {
        public Grenade(Player attacker, string type, int damage, int speed, float angle, int range)
            : base(attacker, type, damage, speed, angle, range)
        {
        }
        
    }
}