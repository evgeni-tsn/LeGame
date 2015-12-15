namespace LeGame.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IGameObject
    {
        string Id { get; set; }

        Vector2 Position { get; set; }

        string Type { get; set; }
    }
}
