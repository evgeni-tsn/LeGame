namespace LeGame.Interfaces
{
    public interface IWeapon : IGameObject
    {
        int Damage { get; set; }

        int Range { get; set; }

        void Attack(ILevel level, ICharacter attacker);

        void EquipCharacter(ICharacter character);
    }
}
