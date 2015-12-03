using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Models.Items.Medicine
{
    public abstract class Medicine : HealingItem, IBonus
    {
        protected Medicine(Vector2 position, string displayName, int healingAmount, Texture2D texture) 
            : base(position, displayName, healingAmount, texture)
        {
        }
    }
}
