using System;
using Microsoft.Xna.Framework;

namespace LeGame.Models.Items.Projectiles
{
    public class LaserBlast : Projectile
    {
        private const int LazerBlastSpeed = 20;

        public LaserBlast(Vector2 position, float angle, int damage, int range) 
            : base(position, "Projectiles/LaserProjectile", damage, LazerBlastSpeed, angle, range)
        {
        }

        public override void Move()
        {
            this.Position = new Vector2(
                this.Position.X + (float)Math.Cos(this.Angle) * this.Speed,
                this.Position.Y + (float)Math.Sin(this.Angle) * this.Speed);

            this.Lifetime++;
        }
    }
}