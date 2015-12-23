namespace LeGame.Models.Items.Projectiles
{
    using System;

    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public class MeleeSwing : Projectile
    {
        private const int MeleeSwingSpeed = 3;

        private const string MeleeSwingType = "Projectiles/SwingProjectileEdit";

        public MeleeSwing(ICharacter attacker, float angle, int damage, int range)
            : base(attacker, MeleeSwingType, damage, MeleeSwingSpeed, angle, range)
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