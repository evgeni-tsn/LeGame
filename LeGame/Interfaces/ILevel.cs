namespace LeGame.Interfaces
{
    using System.Collections.Generic;

    public interface ILevel
    {
        string Type { get; }

        ICharacter Player { get; set; }

        List<IProjectile> Projectiles { get; }

        List<ICharacter> Enemies { get; }

        List<IGameObject> Assets { get; }
    }
}
