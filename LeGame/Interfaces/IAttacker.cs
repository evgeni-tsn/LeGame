namespace LeGame.Interfaces
{
    public interface IAttacker
    {
        IWeapon EquippedWeapon { get; set; }

        float FacingAngle { get; set; }

        float MovementAngle { get; set; }

        void AttackUsingWeapon();
    }
}