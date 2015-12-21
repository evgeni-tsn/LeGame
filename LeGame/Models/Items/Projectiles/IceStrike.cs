namespace LeGame.Models.Items.Projectiles
{
    using System;

    using Interfaces;

    using Microsoft.Xna.Framework;

    public class IceStrike : Projectile
    {
        private const string IceStrikeType = "Projectiles/IceProjectileTilt";

        private const int IceStrikeSpeed = 15;

        public IceStrike(ICharacter attacker, float angle, int damage, int range)
            : base(attacker, IceStrikeType, damage, IceStrikeSpeed, angle, range)
        {
            // Initial displacement to match weapon position
            this.Move();
        }

        public sealed override void Move()
        {
            this.Position = new Vector2(
                this.Position.X + (float)Math.Cos(this.Angle) * this.Speed,
                this.Position.Y + (float)Math.Sin(this.Angle) * this.Speed);

            this.Lifetime++;

            base.Move();
        }
    }
}
