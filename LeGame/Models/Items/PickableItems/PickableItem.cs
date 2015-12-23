namespace LeGame.Models.Items.PickableItems
{
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public abstract class PickableItem : GameObject, IPickable
    {
        protected PickableItem(Vector2 position, string type)
            : base(position, type)
        {
        }

        public virtual bool HasBeenPicked { get; set; }

        public virtual void PickedUpBy(ICharacter character)
        {
            character.Level.Assets.Remove(this);
        }
    }
}