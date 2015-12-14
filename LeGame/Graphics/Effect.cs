namespace LeGame.Graphics
{
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public struct Effect
    {
        public Effect(ISprite sprite, Vector2 location)
        {
            this.Sprite = sprite;
            this.Location = location;
        }

        public Vector2 Location { get; }

        public ISprite Sprite { get; }
    }
}
