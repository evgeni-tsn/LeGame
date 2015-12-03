using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LeGame.Handlers;
using LeGame.Models.Levels;

namespace LeGame.Models.Characters
{
    public abstract class Character : GameObject, IUseWeapon, IKillable, IMovable
    {
        protected Character(Vector2 position, string displayName, int maxHealth, int currentHealth, int speed, Texture2D texture, Level level)
            : base(position, displayName, texture)
        {
            this.MaxHealth = maxHealth;
            this.CurrentHealth = currentHealth;
            this.Speed = speed;
            this.Level = level;
        }
       
        public Level Level { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Speed { get; set; }

        public abstract void Move();

        public abstract void AttackUsingWeapon();

    }
}
