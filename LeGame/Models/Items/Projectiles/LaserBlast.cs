using System;
using LeGame.Interfaces;
using Microsoft.Xna.Framework;

namespace LeGame.Models.Items.Projectiles
{
    public class LaserBlast : Projectile
    {
        public LaserBlast(Vector2 position, float angle) 
            : base(position, "Projectiles/LaserProjectile", 25, 20, angle)
        {
        }


        public override void Move()
        {
            this.Position = new Vector2(
                this.Position.X + (float)Math.Cos(this.Angle) * this.Speed,
                this.Position.Y + (float)Math.Sin(this.Angle) * this.Speed);

            this.Lifetime++;
        }

        public override void Hit(ICharacter target)
        {
            base.Hit(target);
        }
    }
}