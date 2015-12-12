using System.Collections.Generic;
using LeGame.Models;
using LeGame.Models.Characters;
using LeGame.Models.LevelAssets;

namespace LeGame.Interfaces
{
    public interface ILevel
    {
        Character Character { get; }

        List<Character> Enemies { get; }

        List<IGameObject> Assets { get; }

        //List<NonInteractiveBg> Tiles { get; }
    }
}
