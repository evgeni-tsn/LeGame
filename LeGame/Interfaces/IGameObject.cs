using Microsoft.Xna.Framework;

namespace LeGame.Interfaces
{
    public interface IGameObject
    {
        string Id { get; set; }

        Vector2 Position { get; set; }

        string Type { get; set; }
    }
}
