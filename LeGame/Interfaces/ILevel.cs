using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LeGame.Models;
using LeGame.Models.Characters;
using LeGame.Models.LevelAssets;

namespace LeGame.Interfaces
{
    public interface ILevel
    {
        Character Character { get; }
        List<Character> Enemies { get; }
        List<GameObject> Assets { get; }
        List<NonInteractiveBG> Tiles { get; }
    }
}
