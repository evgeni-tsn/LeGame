using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;

namespace LeGame.Models.Items.Weapons
{
    abstract class MeleeWeapon : IWeapon
    {
        protected MeleeWeapon(double damage)
        {
            Damage = damage;
            Range = 0;
        }

        public double Damage { get; set; }
        public double Range { get; set; }

        public abstract void Attack();
    }
}
