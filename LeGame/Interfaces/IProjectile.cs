namespace LeGame.Interfaces
{
    public interface IProjectile : IGameObject, IMovable
    {
        float Angle { get; }

        int Lifetime { get; }

        int Range { get; }
    }
}
