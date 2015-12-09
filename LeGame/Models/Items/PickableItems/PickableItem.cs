using LeGame.Interfaces;
using LeGame.Models.Characters;
using Microsoft.Xna.Framework;

namespace LeGame.Models.Items.PickableItems
{
    public abstract class PickableItem : GameObject, IPickable
    {
        public PickableItem(Vector2 position, string type)
            : base(position, type)
        {

        }
        public abstract bool HasBeenPicked { get; set; }
        public virtual void UponPickUp(Character character)
        {
            character.Level.Assets.Remove(this);
        }
    }
}
