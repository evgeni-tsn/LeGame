using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;

namespace LeGame.Models.Items.Weapons
{
    abstract class RangedWeapon : IWeapon
    {
        protected RangedWeapon(double damage, double range)
        {
            Damage = damage;
            Range = range;
        }

        public double Damage { get; set; }
        public double Range { get; set; }

        public abstract void Attack();
    }
}
