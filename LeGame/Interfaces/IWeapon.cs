namespace LeGame.Interfaces
{
    public interface IWeapon
    {
        int Damage { get; set; }

        int Range { get; set; }

        void Attack(ILevel level, ICharacter attacker);
    }
}
