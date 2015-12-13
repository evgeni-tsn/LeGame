namespace LeGame.Interfaces
{
    public interface IKillable
    {
        int MaxHealth { get; set; }

        int CurrentHealth { get; set; }

        void TakeDamage();
    }
}
