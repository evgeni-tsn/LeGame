namespace LeGame.Models.Items.PickableItems
{
    using Interfaces;
    using Microsoft.Xna.Framework;

    public abstract class PickableItem : GameObject, IPickable
    {
        protected PickableItem(Vector2 position, string type)
            : base(position, type)
        {

        }

        public abstract bool HasBeenPicked { get; set; }

        public virtual void UponPickUp(ICharacter character)
        {
            character.Level.Assets.Remove(this);
        }
    }
}
