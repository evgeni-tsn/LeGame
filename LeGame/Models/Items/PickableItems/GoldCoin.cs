using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LeGame.Interfaces;

namespace LeGame.Models.Items.Gold
{
    public class GoldCoin : PickableItem
    {
        
        public GoldCoin(Vector2 position, string type)
            : base(position, type)
        {
            this.HasBeenPicked = false;
        }
        public override bool HasBeenPicked { get; set; }
    }
}
