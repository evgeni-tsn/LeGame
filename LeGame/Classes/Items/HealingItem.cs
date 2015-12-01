using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;
using Microsoft.Xna.Framework;

namespace LeGame.Classes.Items
{
    abstract class HealingItem : GameObject, IHeals
    {
        protected HealingItem(Vector2 position, string displayName, int healingAmount) : base(position, displayName)
        {
            this.HealingAmount = healingAmount;
        }

        public int HealingAmount { get; set; }
    }
}
