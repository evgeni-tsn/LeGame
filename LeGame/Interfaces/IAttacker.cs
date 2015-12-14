namespace LeGame.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IAttacker
    {
        IWeapon EquippedWeapon { get; set; }

        float FacingAngle { get; set; }

        float MovementAngle { get; set; }

        void AttackUsingWeapon();
    }
}