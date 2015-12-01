using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;
using Microsoft.Xna.Framework;

namespace LeGame.Classes.Items.Medicine
{
    abstract class Medicine : HealingItem, IBonus
    {
        public Medicine(Vector2 position, string displayName, int healingAmount) 
            : base(position, displayName, healingAmount)
        {
        }
    }
}
