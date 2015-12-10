using LeGame.Models.Characters;
using Microsoft.Xna.Framework;

namespace LeGame.Interfaces
{
    public interface ISprite
    {
        int Rows { get; set; }
        int Columns { get; set; }
        void Update(GameTime gameTime, Character character);
    }
}