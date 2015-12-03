using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Models.Items.Food
{
    abstract class Food : HealingItem
    {
        protected Food(Vector2 position, string displayName, int healingAmount, Texture2D texture) 
            : base(position, displayName, healingAmount, texture)
        {
        }
    }
}
