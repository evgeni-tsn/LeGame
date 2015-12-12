using System;
using Microsoft.Xna.Framework;
using LeGame.Handlers;
using LeGame.Interfaces;

namespace LeGame.Models.Characters.Enemies
{
    public class Enemy : Character, ICollidable
    {
        public Enemy(Vector2 position, string type, int maxHealth, int currentHealth, int speed, Level level)
            : base(position, type, maxHealth, currentHealth, speed, level)
        {
            this.CanCollide = true;
        }

        public string Direction { get; set; }

        public bool CanCollide { get; set; }

        public override void Move()
        {
            AiPathfinder.FindPath(this.Level.Character, this);
        }

        public override void AttackUsingWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
