namespace LeGame.Models.Items.Projectiles
{
    using System;

    using LeGame.Models.Characters.Player;

    using Microsoft.Xna.Framework;

    public class EnergyBall : Projectile
    {
        private const int EnergyBallSpeed = 20;

        public EnergyBall(Player attacker, float angle, int damage, int range) 
            : base(attacker, "Projectiles/EnergyBallProjectile", damage, EnergyBallSpeed, angle, range)
        {
        }

        public override void Move()
        {
            this.Position = new Vector2(
                this.Position.X + (float)Math.Cos(this.Angle) * this.Speed,
                this.Position.Y + (float)Math.Sin(this.Angle) * this.Speed);

            this.Lifetime++;

            base.Move();
        }
    }
}