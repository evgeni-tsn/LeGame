using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;
using Microsoft.Xna.Framework;

namespace LeGame.Classes.Characters
{
    abstract class Character : GameObject, IUseWeapon, IKillable, IMovable
    {
        protected Character(Vector2 position, string displayName, int maxHealth, int currentHealth, int speed) 
            : base(position, displayName)
        {
            this.MaxHealth = maxHealth;
            this.CurrentHealth = currentHealth;
            this.Speed = speed;
        }

        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Speed { get; set; }
        
        public abstract void Move();
        public abstract void AttackUsingWeapon();
    }
}
