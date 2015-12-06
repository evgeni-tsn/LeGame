using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LeGame.Models.Characters;
using LeGame.Models.LevelAssets;

namespace LeGame.Interfaces
{
    public interface ILevel
    {
        Character Character { get; set; }
        List<InteractiveBG> Assets { get; set; }
        List<NonInteractiveBG> Tiles { get; set; }
    }
}
