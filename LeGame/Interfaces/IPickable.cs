namespace LeGame.Interfaces
{
    public interface IPickable
    {
        bool HasBeenPicked { get; set; }

        void PickedUpBy(ICharacter character);
    }
}
