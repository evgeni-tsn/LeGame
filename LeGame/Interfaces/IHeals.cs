namespace LeGame.Interfaces
{
    public interface IHeals
    {
        int HealingAmount { get; set; }

        void HealCharacter(ICharacter character);
    }
}