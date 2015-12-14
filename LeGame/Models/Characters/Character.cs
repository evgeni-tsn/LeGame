namespace LeGame.Models.Characters
{
    using System;

    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public abstract class Character : GameObject, ICharacter, IUseWeapon
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

        public int CooldownTimer { get;  set; }

        public ILevel Level { get; set; }

        public int MaxHealth { get; set; }

        public int CurrentHealth { get; set; }

        public int Speed { get; set; }

        public float FacingAngle { get; set; }

        public float MovementAngle { get; set; }

        public IWeapon EquippedWeapon { get; set; }

        public abstract void Move();
        
        public virtual void AttackUsingWeapon()
        {
            this.EquippedWeapon?.Attack(this.Level, this);
        }

        public virtual void TakeDamage(ICharacter attacker)
        {
            this.CurrentHealth -= attacker.EquippedWeapon.Damage;

            this.Damaged?.Invoke(this, new EventArgs());
        }

    }
}
