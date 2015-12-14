namespace LeGame.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IAttacker
    {
        Vector2 Position { get; set; }

        IWeapon EquippedWeapon { get; set; }

        float FacingAngle { get; set; }

        float MovementAngle { get; set; }

        void AttackUsingWeapon();
    }
}