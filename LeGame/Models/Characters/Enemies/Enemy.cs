namespace LeGame.Models.Characters.Enemies
{
    using LeGame.Enumerations;
    using LeGame.Handlers;
    using LeGame.Interfaces;
    using LeGame.Models.Items.Weapons;

    using Microsoft.Xna.Framework;

    public class Enemy : Character
    {
        public Enemy(
            Vector2 position, 
            ISpawnLocation spawnLocation, 
            string type, 
            int maxHealth, 
            int currentHealth, 
            int speed, 
            int hitCooldown, 
            ILevel level)
            : base(position, type, maxHealth, currentHealth, speed, hitCooldown, level)
        {
            this.CanCollide = true;
            this.EquippedWeapon = new Unarmed(this.Position);
            this.SpawnLocation = spawnLocation;
            this.IsAggroed = false;
        }

        public MoveDirection Direction { get; set; }

        public bool IsAggroed { get; set; }

        public ISpawnLocation SpawnLocation { get; set; }

        public override void Move()
        {
            AiPathfinder.FindPath(this.Level.Player, this);
            CollisionHandler.AiCollide(this, this.Level.Player);
        }

        public override void TakeDamage(ICharacter attacker)
        {
            if (!this.IsAggroed)
            {
                this.IsAggroed = true;
            }

            base.TakeDamage(attacker);
        }
    }
}