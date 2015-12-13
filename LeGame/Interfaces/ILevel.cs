namespace LeGame.Interfaces
{
    using System.Collections.Generic;
    
    using Models.Characters;
    using Models.Items.Projectiles;

    public interface ILevel
    {
        Character Character { get; }

        List<Projectile> Projectiles { get; }

        List<Character> Enemies { get; }

        List<IGameObject> Assets { get; }

        //List<NonInteractiveBg> Tiles { get; }
    }
}
