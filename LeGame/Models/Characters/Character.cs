namespace LeGame.Models.Characters
{
    using System;
    using System.Net;

    using LeGame.Engine;
    using LeGame.Interfaces;
    using LeGame.Models.Characters.Enemies;

    using Microsoft.Xna.Framework;

    public abstract class Character : GameObject, ICharacter, IUseWeapon, ICollidable
    {
        protected Character(Vector2 position, string type, int maxHealth, int currentHealth, int speed, Level level)
            : base(position, type)
        {
            this.MaxHealth = maxHealth;
            this.CurrentHealth = currentHealth;
            this.Speed = speed;
            this.Level = level;
            this.CooldownTimer = 5;
        }

        public event EventHandler Damaged;

        public event EventHandler Died;

        public ILevel Level { get; set; }

        public IWeapon EquippedWeapon { get; set; }

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
            //this.CooldownTimer += GlobalVariables.GlobalTime.
            this.CurrentHealth -= attacker.EquippedWeapon.Damage;

            this.Damaged?.Invoke(this, new EventArgs());

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
