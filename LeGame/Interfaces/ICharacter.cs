namespace LeGame.Interfaces
{
    public interface ICharacter : IGameObject, IMovable, IAttacker, IKillable, ICooldown
    {
        ILevel Level { get; set; }
    }
}