﻿namespace LeGame.Models.Items.Projectiles
{
    using System;

    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public class EnergyBall : Projectile
    {
        private const int EnergyBallSpeed = 20;

        private const string EnergyBallType = "Projectiles/EnergyBallProjectile";

        public EnergyBall(ICharacter attacker, float angle, int damage, int range)
            : base(attacker, EnergyBallType, damage, EnergyBallSpeed, angle, range)
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