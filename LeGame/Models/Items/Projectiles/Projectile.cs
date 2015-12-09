using LeGame.Interfaces;
using Microsoft.Xna.Framework;

namespace LeGame.Models.Items.Projectiles
{
    public abstract class Projectile : GameObject, IMovable
    {
        protected Projectile(Vector2 position, string type, int damage, int speed, float angle, int range)
            :base(position, type)
        {
            this.Damage = damage;
            this.Angle = angle;
            this.Speed = speed;
            this.Range = range;
            this.Lifetime = 0;
        }

        public int Damage { get; set; }
        public int Speed { get; set; }
        public float Angle { get; set; }
        public int Lifetime { get; set; }
        public int Range { get; set; }

        public virtual void Move()
        {
        }

        public virtual void Hit(ICharacter target)
        {
        }
    }
}