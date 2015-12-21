namespace LeGame.Models.Items.Projectiles
{
    using System;

    using Interfaces;

    using Microsoft.Xna.Framework;

    public class LightningStrike : Projectile
    {
        private const string LightningStrikeType = "Projectiles/LightningProjectile";

        private const int LightningStrikeSpeed = 32;

        public LightningStrike(ICharacter attacker, float angle, int damage, int range) 
            : base(attacker, LightningStrikeType, damage, LightningStrikeSpeed, angle, range)
        {
        }

        public sealed override void Move()
        {
            this.Position = new Vector2(
                this.Position.X + ((float)Math.Cos(this.Angle) * this.Speed),
                this.Position.Y + ((float)Math.Sin(this.Angle) * this.Speed));

            this.Lifetime++;

            base.Move();
        }
    }
}