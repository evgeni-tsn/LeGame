namespace LeGame.Models.Characters.Enemies
{
    using System;

    using Handlers;
    using Interfaces;
    using Items.Weapons;

    using Microsoft.Xna.Framework;

    public class Enemy : Character
    {
        public Enemy(Vector2 position, string type, int maxHealth, int currentHealth, int speed, Level level)
            : base(position, type, maxHealth, currentHealth, speed, level)
        {
            this.CanCollide = true;
            this.EquippedWeapon = new Unarmed();
        }

        public string Direction { get; set; }

        public override void Move()
        {
            AiPathfinder.FindPath(this.Level.Character, this);
            CollisionHandler.AICollide(this, this.Level.Character);
        }
    }
}
