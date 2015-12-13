using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Interfaces
{
    public interface ICharacter : IMovable, IAttacker
    {
        ILevel Level { get; set; }

        int MaxHealth { get; set; }

        int CurrentHealth { get; set; }
    }
}
