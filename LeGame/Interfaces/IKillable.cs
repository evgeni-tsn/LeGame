namespace LeGame.Interfaces
{
    using System;

    public interface IKillable
    {
        event EventHandler Damaged;

        event EventHandler Died;

        int CurrentHealth { get; set; }

        int MaxHealth { get; set; }

        void TakeDamage(ICharacter attacker);
    }
}