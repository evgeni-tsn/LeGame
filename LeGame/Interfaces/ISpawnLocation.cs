namespace LeGame.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface ISpawnLocation : IGameObject
    {
        Rectangle InflateBBox();
    }
}