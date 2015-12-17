namespace LeGame.Models.Characters
{
    using System;

    using Core;
    using Interfaces;
    using Enemies;

    using Microsoft.Xna.Framework;

    public abstract class Character : GameObject, ICharacter, ICollidable
    {
        

        protected Character( Vector2 position,string type, int maxHealth, int currentHealth, int speed, int hitCooldown, ILevel level)
            : base(position, type)
        {
            this.MaxHealth = maxHealth;
            this.CurrentHealth = currentHealth;
            this.Speed = speed;
            this.Level = level;
            this.CooldownTimer = hitCooldown;
            this.TimeAtLastHit = 0;
        }

        public event EventHandler Damaged;

        public event EventHandler Died;

        public ILevel Level { get; set; }

        public IWeapon EquippedWeapon { get; set; }

        public int TimeAtLastHit { get; set; }

        public int CooldownTimer { get;  set; }

        public int MaxHealth { get; set; }

        public int CurrentHealth { get; set; }

        public int Speed { get; set; }

        public float FacingAngle { get; set; }

        public float MovementAngle { get; set; }

        public bool CanCollide { get; set; }

        public abstract void Move();
        
        public virtual void AttackUsingWeapon()
        {
            this.EquippedWeapon?.Attack(this.Level, this);
        }

        public virtual void TakeDamage(ICharacter attacker)
        {
            var currentTime = GlobalVariables.GlobalTimer;
            if (currentTime - this.TimeAtLastHit < this.CooldownTimer)
            {
                return;
            }
            this.TimeAtLastHit = currentTime;

            this.CurrentHealth -= attacker.EquippedWeapon.Damage;
            this.Damaged?.Invoke(this, new EventArgs());
            Console.Beep(2000, 10);
            if (this.CurrentHealth <= 0)
            {
                this.Died?.Invoke(this, new EventArgs());
                if (this is Enemy)
                {
                    this.Level.Enemies.Remove(this);
                }
            }
        }
    }
}
