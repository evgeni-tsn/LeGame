using LeGame.Interfaces;
using Microsoft.Xna.Framework;

namespace LeGame.Models.Items.Projectiles
{
    public class Grenade : Projectile
    {
        public Grenade(Vector2 position, string type, int damage, int speed, float angle)
            : base(position, type, damage, speed, angle)
        {
        }

        public override void Hit(ICharacter target)
        {
            base.Hit(target);
        }
    }
}