using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Screens
{
    public interface IButton
    {
        Texture2D Texture { get; }
        Vector2 Position { get; }
        Color Colour { get; }
        bool Down { get; }
        bool IsClicked { get; }
        Rectangle BoundingBox { get; }
        void Update(MouseState mouse);
    }
}
