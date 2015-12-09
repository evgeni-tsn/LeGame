using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;
using LeGame.Models.Characters.Player;

namespace LeGame.Models.Items.Weapons
{
    abstract class RangedWeapon : IWeapon
    {
        protected RangedWeapon(int damage, int range)
        {
            Damage = damage;
            Range = range;
        }

        public int Damage { get; set; }
        public int Range { get; set; }

        public abstract void Attack(Level level, Player attacker);
    }
}
