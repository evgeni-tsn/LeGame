namespace LeGame.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public interface IButton
    {
        Rectangle BoundingBox { get; }

        Color Colour { get; }

        bool Down { get; }

        bool IsClicked { get; set; }

        Vector2 Position { get; }

        Texture2D Texture { get; }

        void Update(MouseState mouse);
    }
}