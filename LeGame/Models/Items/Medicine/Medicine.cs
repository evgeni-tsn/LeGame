using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;
using Microsoft.Xna.Framework;

namespace LeGame.Models.Items.Medicine
{
    public abstract class Medicine : HealingItem, IBonus
    {
        protected Medicine(Vector2 position, string displayName, int healingAmount) 
            : base(position, displayName, healingAmount)
        {
        }
    }
}
