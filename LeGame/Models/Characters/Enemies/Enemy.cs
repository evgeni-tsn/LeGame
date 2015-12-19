namespace LeGame.Models.Characters.Enemies
{
    using Handlers;
    using Interfaces;
    using Items.Weapons;

    using Microsoft.Xna.Framework;

    public class Enemy : Character
    {
        public Enemy(Vector2 position, string type, int maxHealth, int currentHealth, int speed, int hitCooldown, ILevel level)
            : base(position, type, maxHealth, currentHealth, speed, hitCooldown, level)
        {
            this.CanCollide = true;
            this.EquippedWeapon = new Unarmed(this.Position);
        }

        public string Direction { get; set; }

        public override void Move()
        {
            AiPathfinder.FindPath(this.Level.Player, this);
            CollisionHandler.AiCollide(this, this.Level.Player);
        }
    }
}
