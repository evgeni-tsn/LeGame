using LeGame.Handlers;
using LeGame.Interfaces;
using LeGame.Models.Characters.Player;

namespace LeGame.Models.Items.Projectiles
{
    public abstract class Projectile : GameObject, IMovable
    {
        protected Projectile(Player attacker, string type, int damage, int speed, float angle, int range)
            : base(attacker.Position, type)
        {
            this.Attacker = attacker;
            this.Damage = damage;
            this.Angle = angle;
            this.Speed = speed;
            this.Range = range;
            this.Lifetime = 0;
        }
        
        public int Damage { get; }

        public int Speed { get; set; }

        public float Angle { get; }

        public int Lifetime { get; protected set; }

        public int Range { get; }

        private Player Attacker { get; }

        public virtual void Move()
        {
            CollisionHandler.ProjectileReaction(this, this.Attacker);
        }

        public virtual void Hit(ICharacter target)
        {
        }
    }
}