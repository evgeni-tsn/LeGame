namespace LeGame.Interfaces
{
    using System;

    public interface IKillable
    {
        event EventHandler Damaged;

        int MaxHealth { get; set; }

        int CurrentHealth { get; set; }

        void TakeDamage(ICharacter attacker);
    }
}
