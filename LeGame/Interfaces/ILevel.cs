namespace LeGame.Interfaces
{
    using System.Collections.Generic;

    using LeGame.Models.Characters;
    using LeGame.Models.Items.Projectiles;

    public interface ILevel
    {
        ICharacter Character { get; }

        List<IProjectile> Projectiles { get; }

        List<ICharacter> Enemies { get; }

        List<IGameObject> Assets { get; }

        //List<NonInteractiveBg> Tiles { get; }
    }
}
