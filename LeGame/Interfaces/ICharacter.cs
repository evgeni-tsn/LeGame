using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Interfaces
{
    public interface ICharacter
    {
        int MaxHealth { get; set; }

        int CurrentHealth { get; set; }

        int Speed { get; set; }
    }
}
