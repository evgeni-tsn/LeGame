using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LeGame.Handlers;
using LeGame.Interfaces;

namespace LeGame.Models.Characters.Enemies
{
    class SampleEnemy : Character, ICollisionable
    {
        public string Direction { get; set; }

        public SampleEnemy(Vector2 position, string type, int maxHealth, int currentHealth, int speed, Level level)
            :base(position, type, maxHealth, currentHealth, speed, level)
        {

        }
        public bool CanCollide { get; set; }
        public override void Move()
        {
            AIPathfinder.FindPath(this.Level.Character, this);
        }
        public override void AttackUsingWeapon()
        {
            throw new NotImplementedException();
        }

       
    }
}
