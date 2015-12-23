namespace LeGame.Models.Items.Projectiles
{
    using LeGame.Handlers;
    using LeGame.Interfaces;

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

        public float Angle { get; }

        public ICharacter Attacker { get; }

        public int Damage { get; }

        public int Lifetime { get; protected set; }

        public int Range { get; }

        public float Speed { get; set; }

        // TODO: Might be redundant, consider removal
        public virtual void Hit(ICharacter target)
        {
        }

        public virtual void Move()
        {
            CollisionHandler.ProjectileReaction(this, this.Attacker.Level);
        }
    }
}