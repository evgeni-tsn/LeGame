using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LeGame.Models;
using LeGame.Interfaces;
using LeGame.Models.Characters;


namespace LeGame.Models.Items
{
    public abstract class PickableItem : GameObject, IPickable
    {
        public PickableItem(Vector2 position, string displayName, Texture2D texture)
            : base(position, displayName, texture)
        {

        }
        public abstract bool HasBeenPicked { get; set; }
        public virtual void UponPickUp(Character character)
        {
            character.Level.Assets.Remove(this);
        }
    }
}
