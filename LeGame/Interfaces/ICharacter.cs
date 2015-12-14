namespace LeGame.Interfaces
{
    public interface ICharacter : IMovable, IAttacker, IKillable, ICooldown
    {
        ILevel Level { get; set; }
    }
}
