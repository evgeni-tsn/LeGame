namespace LeGame.Interfaces
{
    using System.Collections.Generic;

    public interface ILevel
    {
        List<IGameObject> Assets { get; }

        List<ICharacter> Enemies { get; }

        ICharacter Player { get; set; }

        List<IProjectile> Projectiles { get; }

        string Type { get; }
    }
}