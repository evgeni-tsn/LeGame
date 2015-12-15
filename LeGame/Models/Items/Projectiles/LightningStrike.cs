namespace LeGame.Models.Items.Projectiles
{
    using System;

    using Interfaces;

    using Microsoft.Xna.Framework;

    public class LightningStrike : Projectile
    {
        private const int LightningStrikeSpeed = 20;

        public LightningStrike(ICharacter attacker, float angle, int damage, int range) 
            : base(attacker, "Projectiles/LightningProjectile", damage, LightningStrikeSpeed, angle, range)
        {
        }

        public override void Move()
        {
            this.Position = new Vector2(
                this.Position.X + ((float)Math.Cos(this.Angle) * this.Speed),
                this.Position.Y + ((float)Math.Sin(this.Angle) * this.Speed));

            this.Lifetime++;

            base.Move();
        }
    }
}