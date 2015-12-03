using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Models.Items
{
    public abstract class HealingItem : GameObject, IHeals
    {
        protected HealingItem(Vector2 position, string displayName, int healingAmount, Texture2D texture) : base(position, displayName, texture)
        {
            this.HealingAmount = healingAmount;
        }

        public int HealingAmount { get; set; }
    }
}
