namespace LeGame.Models.Items.Projectiles
{
    using System;

    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public class LaserBlast : Projectile
    {
        private const int LazerBlastSpeed = 20;

        private const string LazerBlastType = "Projectiles/LaserProjectile";

        public LaserBlast(ICharacter attacker, float angle, int damage, int range)
            : base(attacker, LazerBlastType, damage, LazerBlastSpeed, angle, range)
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