namespace LeGame.Models.Items.Projectiles
{
    using Handlers;
    using Interfaces;

    public abstract class Projectile : GameObject, IProjectile
    {
        protected Projectile(ICharacter attacker, string type, int damage, int speed, float angle, int range)
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

        public float Speed { get; set; }

        public float Angle { get; }

        public int Lifetime { get; protected set; }

        public int Range { get; }

        public ICharacter Attacker { get; }

        public virtual void Move()
        {
            CollisionHandler.ProjectileReaction(this, this.Attacker.Level);
        }

        // TODO: Might be redundant, consider removal
        public virtual void Hit(ICharacter target)
        {
        }
    }
}